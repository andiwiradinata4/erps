Namespace BL

    Public Class Claim

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal intClaimType As VO.Claim.ClaimTypeValue) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Claim.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, intClaimType)
            End Using
        End Function

        Public Shared Function ListDataOutstandingConfirmationClaim(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                    ByVal intBPID As Integer, ByVal intClaimType As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Claim.ListDataOutstandingConfirmationClaim(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, intClaimType)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal intClaimType As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "CRP" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-" & Format(intClaimType, "00") & "-"
            strNewID &= Format(DL.Claim.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Claim) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ClaimDate, clsData.CompanyID, clsData.ProgramID, clsData.ClaimType)
                        If clsData.ClaimNumber.Trim = "" Then clsData.ClaimNumber = clsData.ID
                    Else
                        Dim dtDetail As DataTable = DL.Claim.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.Claim.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                        '# Calculate Total Used
                        For Each dr As DataRow In dtDetail.Rows
                            If clsData.ClaimType = VO.Claim.ClaimTypeValue.Receive Then DL.Receive.CalculateClaimTotalUsed(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                            If clsData.ClaimType = VO.Claim.ClaimTypeValue.Sales Then DL.SalesContract.CalculateClaimTotalUsed(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        Next
                    End If

                    Dim intStatusID As Integer = DL.Claim.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.Claim.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.Claim.DataExists(sqlCon, sqlTrans, clsData.ClaimNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.ClaimNumber & " sudah ada.")
                    End If

                    DL.Claim.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    Dim intCount As Integer = 1
                    For Each clsDet As VO.ClaimDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.ClaimID = clsData.ID
                        DL.Claim.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        '# Calculate Total Used Claim
                        If clsData.ClaimType = VO.Claim.ClaimTypeValue.Receive Then DL.Receive.CalculateClaimTotalUsed(sqlCon, sqlTrans, clsDet.ReferencesDetailID)
                        If clsData.ClaimType = VO.Claim.ClaimTypeValue.Sales Then DL.SalesContract.CalculateClaimTotalUsed(sqlCon, sqlTrans, clsDet.ReferencesDetailID)
                    Next

                    '# Save Data Status
                    BL.Claim.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.Claim
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Claim.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.Claim = DL.Claim.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtDetail As DataTable = DL.Claim.ListDataDetail(sqlCon, sqlTrans, strID)

                    DL.Claim.DeleteData(sqlCon, sqlTrans, strID)

                    '# Calculate Total Used
                    For Each dr As DataRow In dtDetail.Rows
                        If clsData.ClaimType = VO.Claim.ClaimTypeValue.Receive Then DL.Receive.CalculateClaimTotalUsed(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        If clsData.ClaimType = VO.Claim.ClaimTypeValue.Sales Then DL.SalesContract.CalculateClaimTotalUsed(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                    Next

                    '# Save Data Status
                    BL.Claim.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
            Dim clsData As VO.Claim = DL.Claim.GetDetail(sqlCon, sqlTrans, strID)
            If clsData.StatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf clsData.IsDeleted Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.Claim.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.Claim.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.Claim = DL.Claim.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    ElseIf DL.Claim.IsConfirmation(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dilakukan proses Konfirmasi Klaim")
                    End If

                    If clsData.DPAmount > 0 Or clsData.TotalPayment > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses pembayaran")
                    End If

                    DL.Claim.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Claim.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

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

        Public Shared Function ListDataDetail(ByVal strClaimID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Claim.ListDataDetail(sqlCon, Nothing, strClaimID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingConfirmationClaim(ByVal strClaimID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Claim.ListDataDetailOutstandingConfirmationClaim(sqlCon, Nothing, strClaimID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strClaimID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Claim.ListDataStatus(sqlCon, Nothing, strClaimID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strClaimID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strClaimID & "-" & Format(DL.Claim.GetMaxIDStatus(sqlCon, sqlTrans, strClaimID) + 1, "000")
            Dim clsData As New VO.ClaimStatus With
                {
                    .ID = strNewID,
                    .ClaimID = strClaimID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.Claim.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class

End Namespace

