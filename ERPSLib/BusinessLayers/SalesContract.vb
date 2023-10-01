Namespace BL
    Public Class SalesContract

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "SC" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.SalesContract.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.SalesContract) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.SCDate, clsData.CompanyID, clsData.ProgramID)
                        clsData.SCNumber = clsData.ID
                    Else
                        Dim dtItem As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.ID)

                        DL.SalesContract.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.SalesContract.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.ID)

                        '# Revert SC Quantity
                        For Each dr As DataRow In dtItem.Rows
                            DL.PurchaseOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailInternalID"))
                        Next
                    End If

                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.SalesContract.DataExists(sqlCon, sqlTrans, clsData.SCNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.SCNumber & " sudah ada.")
                    End If

                    DL.SalesContract.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.SalesContractDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                        clsDet.SCID = clsData.ID
                        DL.SalesContract.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Payment Term
                    intCount = 1
                    For Each clsDet As VO.SalesContractPaymentTerm In clsData.PaymentTerm
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.SCID = clsData.ID
                        DL.SalesContract.SaveDataPaymentTerm(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Calculate SC Quantity
                    For Each clsDet As VO.SalesContractDet In clsData.Detail
                        DL.PurchaseOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, clsDet.PODetailInternalID)
                    Next

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.SCNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.SalesContract
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, strID)

                    DL.SalesContract.DeleteData(sqlCon, sqlTrans, strID)

                    '# Revert SC Quantity
                    For Each dr As DataRow In dtItem.Rows
                        DL.PurchaseOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailInternalID"))
                    Next

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Function Submit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Submit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub Submit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                 ByVal strID As String, ByVal strRemarks As String)
            Dim bolReturn As Boolean = False
            Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.SalesContract.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesContract.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Approve(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesContract.Approve(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unapprove(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesContract.Unapprove(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetail(sqlCon, Nothing, strSCID)
            End Using
        End Function

#End Region

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataPaymentTerm(sqlCon, Nothing, strSCID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataStatus(sqlCon, Nothing, strSCID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strSCID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strSCID & "-" & Format(DL.SalesContract.GetMaxIDStatus(sqlCon, sqlTrans, strSCID) + 1, "000")
            Dim clsData As New VO.SalesContractStatus With
                {
                    .ID = strNewID,
                    .SCID = strSCID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace