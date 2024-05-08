Namespace BL
    Public Class PurchaseContract

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function ListDataOutstandingPayment(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                          ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListDataOutstandingPayment(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataOutstandingReceive(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                          ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListDataOutstandingReceive(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function GetNewID(ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return GetNewID(sqlCon, Nothing, dtmTransDate, intCompanyID, intProgramID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "PC" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.PurchaseContract.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PurchaseContract) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    BL.PurchaseContract.SaveData(sqlCon, sqlTrans, bolNew, clsData)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.PCNumber
        End Function

        Public Shared Function SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal bolNew As Boolean, ByVal clsData As VO.PurchaseContract) As String
            If bolNew Then
                If clsData.ID.Trim = "" Then clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.PCDate, clsData.CompanyID, clsData.ProgramID)
                If clsData.PCNumber.Trim = "" Then clsData.PCNumber = clsData.ID
            Else
                Dim dtSubItem As New DataTable
                Dim dtItem As DataTable = DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsData.ID, "")
                For Each dr As DataRow In dtItem.Rows
                    dtSubItem.Merge(DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsData.ID, dr.Item("ID")))
                Next

                DL.PurchaseContract.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                DL.PurchaseContract.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.ID)

                '# Revert PC Quantity
                For Each dr As DataRow In dtItem.Rows
                    DL.ConfirmationOrder.CalculatePCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                Next

                Dim clsExists As VO.PurchaseContract = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsData.ID)
                If clsExists.DPAmount > 0 Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses panjar")
                ElseIf clsExists.ReceiveAmount > 0 Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                End If
            End If

            Dim intStatusID As Integer = DL.PurchaseContract.GetStatusID(sqlCon, sqlTrans, clsData.ID)
            If intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
            ElseIf intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
            ElseIf DL.PurchaseContract.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
            ElseIf DL.PurchaseContract.DataExists(sqlCon, sqlTrans, clsData.PCNumber, clsData.ID) Then
                Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.PCNumber & " sudah ada.")
            End If

            DL.PurchaseContract.SaveData(sqlCon, sqlTrans, bolNew, clsData)

            '# Save Data Detail
            Dim intCount As Integer = 1
            For Each clsDet As VO.PurchaseContractDet In clsData.Detail
                clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                clsDet.PCID = clsData.ID
                DL.PurchaseContract.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                intCount += 1
            Next

            '# Save Data Payment Term
            intCount = 1
            For Each clsDet As VO.PurchaseContractPaymentTerm In clsData.PaymentTerm
                clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                clsDet.PCID = clsData.ID
                DL.PurchaseContract.SaveDataPaymentTerm(sqlCon, sqlTrans, clsDet)
                intCount += 1
            Next

            '# Calculate PC Quantity
            For Each clsDet As VO.PurchaseContractDet In clsData.Detail
                DL.ConfirmationOrder.CalculatePCTotalUsed(sqlCon, sqlTrans, clsDet.CODetailID)
            Next

            '# Save Data Status
            BL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

            If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

            Return clsData.PCNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.PurchaseContract
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.PurchaseContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.PurchaseContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, strID, "")

                    DL.PurchaseContract.DeleteData(sqlCon, sqlTrans, strID)

                    '# Revert PC Quantity
                    For Each dr As DataRow In dtItem.Rows
                        DL.ConfirmationOrder.CalculatePCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                    Next

                    '# Save Data Status
                    BL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.PurchaseContract.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.PurchaseContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.PurchaseContract.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    BL.PurchaseContract.Unsubmit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub Unsubmit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal strID As String, ByVal strRemarks As String)
            Try
                Dim intStatusID As Integer = DL.PurchaseContract.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                ElseIf DL.PurchaseContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                End If

                DL.PurchaseContract.Unsubmit(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function Approve(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    BL.PurchaseContract.Approve(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub Approve(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                  ByVal strID As String, ByVal strRemarks As String)
            Try
                Dim intStatusID As Integer = DL.PurchaseContract.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                ElseIf DL.PurchaseContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                End If

                DL.PurchaseContract.Approve(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                'GenerateJournal(sqlCon, sqlTrans, strID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function Unapprove(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    BL.PurchaseContract.Unapprove(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub Unapprove(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                    ByVal strID As String, ByVal strRemarks As String)
            Try
                Dim intStatusID As Integer = DL.PurchaseContract.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                ElseIf DL.PurchaseContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                ElseIf DL.PurchaseContract.IsAlreadyPayment(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dilanjutkan proses pembayaran")
                End If

                'Dim clsData As VO.PurchaseContract = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, strID)

                ''# Cancel Approve Journal
                'BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                ''# Cancel Submit Journal
                'BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                DL.PurchaseContract.Unapprove(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                Dim clsData As VO.PurchaseContract = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim decTotalAmount As Decimal = clsData.TotalDPP + clsData.TotalPPN - clsData.TotalPPH + clsData.RoundingManual
                Dim clsJournalDetail As New List(Of VO.JournalDet)

                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofStock,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "KONTRAK PEMBELIAN - " & clsData.PCNumber
                                     })
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayable,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalAmount,
                                         .Remarks = "KONTRAK PEMBELIAN - " & clsData.PCNumber
                                     })

                Dim clsJournal As New VO.Journal With
                    {
                        .ProgramID = clsData.ProgramID,
                        .CompanyID = clsData.CompanyID,
                        .ID = PrevJournal.ID,
                        .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                        .ReferencesID = clsData.ID,
                        .JournalDate = IIf(bolNew, Now, PrevJournal.JournalDate),
                        .TotalAmount = decTotalAmount,
                        .IsAutoGenerate = True,
                        .StatusID = VO.Status.Values.Draft,
                        .Remarks = clsData.Remarks,
                        .LogBy = ERPSLib.UI.usUserApp.UserID,
                        .Initial = "",
                        .Detail = clsJournalDetail,
                        .Save = VO.Save.Action.SaveAndSubmit
                    }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Purchase Contract
                DL.PurchaseContract.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strPCID As String, ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListDataDetail(sqlCon, Nothing, strPCID, strParentID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingReceive(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                ByVal intBPID As Integer, ByVal strPCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListDataDetailOutstandingReceive(sqlCon, Nothing, intProgramID, intCompanyID, intBPID, strPCID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingCutting(ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListDataDetailOutstandingCutting(sqlCon, Nothing, intProgramID, intCompanyID)
            End Using
        End Function

#End Region

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByVal strPCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListDataPaymentTerm(sqlCon, Nothing, strPCID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strPCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseContract.ListDataStatus(sqlCon, Nothing, strPCID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strPCID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strPCID & "-" & Format(DL.PurchaseContract.GetMaxIDStatus(sqlCon, sqlTrans, strPCID) + 1, "000")
            Dim clsData As New VO.PurchaseContractStatus With
                {
                    .ID = strNewID,
                    .PCID = strPCID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace