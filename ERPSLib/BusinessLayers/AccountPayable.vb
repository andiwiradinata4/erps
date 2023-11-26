Namespace BL
    Public Class AccountPayable

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strModules, 0, "")
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal strModules As String) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "AP" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-" & strModules & "-"
            strNewID &= Format(DL.AccountPayable.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function GetNewNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim strNewID As String = Format(dtmTransDate, "yy") & "/"
            Select Case dtmTransDate.Month
                Case 1 : strNewID &= "I"
                Case 2 : strNewID &= "II"
                Case 3 : strNewID &= "III"
                Case 4 : strNewID &= "IV"
                Case 5 : strNewID &= "V"
                Case 6 : strNewID &= "VI"
                Case 7 : strNewID &= "VII"
                Case 8 : strNewID &= "VIII"
                Case 9 : strNewID &= "IX"
                Case 10 : strNewID &= "X"
                Case 11 : strNewID &= "XI"
                Case 12 : strNewID &= "XII"
            End Select
            strNewID &= "/"
            strNewID &= Format(DL.AccountPayable.GetMaxNo(sqlCon, sqlTrans, dtmTransDate.Year, intCompanyID, intProgramID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.AccountPayable) As String
            Dim strReturn As String = ""
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    strReturn = SaveData(sqlCon, sqlTrans, bolNew, clsData)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return strReturn
        End Function

        Public Shared Function SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal bolNew As Boolean, ByVal clsData As VO.AccountPayable) As String
            Try
                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    clsData.APNumber = GetNewNo(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtItem As New DataTable

                    '# For Setup Balance
                    If clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                        dtItem = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Or
                        clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
                        clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        dtItem = DL.AccountPayable.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                    End If

                    DL.AccountPayable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                    '# Revert Payment Amount
                    For Each dr As DataRow In dtItem.Rows
                        '# For Setup Balance
                        If clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                            DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Then
                            DL.PurchaseContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                            DL.PurchaseContract.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then
                            DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                            DL.PurchaseOrderCutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                            DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                            DL.PurchaseOrderTransport.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                        End If
                    Next
                End If

                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountPayable.DataExists(sqlCon, sqlTrans, clsData.APNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.APNumber & " sudah ada.")
                End If

                DL.AccountPayable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountPayableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.APID = clsData.ID
                    DL.AccountPayable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Calculate Payment Amount
                For Each clsDet As VO.AccountPayableDet In clsData.Detail
                    '# For Setup Balance
                    If clsData.Modules = VO.AccountPayable.PurchaseBalance Then
                        DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Then
                        DL.PurchaseContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                        DL.PurchaseContract.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                        DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        DL.PurchaseOrderTransport.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    End If
                Next

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.APNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.AccountPayable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DeleteData(sqlCon, sqlTrans, strID, strModules, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                End If

                Dim dtItem As New DataTable

                '# For Setup Balance
                If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                    dtItem = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
                ElseIf strModules.Trim = VO.AccountPayable.DownPayment Or
                    strModules.Trim = VO.AccountPayable.ReceivePayment Or
                    strModules.Trim = VO.AccountPayable.DownPaymentCutting Or
                    strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
                    strModules.Trim = VO.AccountPayable.DownPaymentTransport Or
                    strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                    dtItem = DL.AccountPayable.ListDataDetail(sqlCon, sqlTrans, strID)
                End If

                DL.AccountPayable.DeleteData(sqlCon, sqlTrans, strID)

                '# Revert Payment Amount
                For Each dr As DataRow In dtItem.Rows
                    '# For Setup Balance
                    If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                        DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPayment Then
                        DL.PurchaseContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePayment Then
                        DL.PurchaseContract.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPaymentTransport Then
                        DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        DL.PurchaseOrderTransport.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("PurchaseID"))
                    End If
                Next

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function Submit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = Submit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Submit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                      ByVal strID As String, ByVal strRemarks As String)
            Dim bolReturn As Boolean = False
            Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf intStatusID = VO.Status.Values.Payment Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah DIBAYAR")
            ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.AccountPayable.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
            bolReturn = True
            Return bolReturn
        End Function

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = Unsubmit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unsubmit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False

            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal submit. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                End If

                DL.AccountPayable.Unsubmit(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function Approve(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = Approve(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Approve(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                End If

                DL.AccountPayable.Approve(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim clsJournalDetail As New List(Of VO.JournalDet)
                Dim strJournalDetailRemarks As String = ""
                If clsData.Modules.Trim = VO.AccountPayable.DownPayment Then
                    strJournalDetailRemarks = "PEMBAYARAN PANJAR PEMBELIAN - " & clsData.APNumber
                ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentManual Then
                    strJournalDetailRemarks = "PEMBAYARAN PANJAR PEMBELIAN [MANUAL] - " & clsData.APNumber
                ElseIf clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                    strJournalDetailRemarks = "PEMBAYARAN SALDO - " & clsData.APNumber
                ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                    strJournalDetailRemarks = "PEMBAYARAN HUTANG PEMBELIAN - " & clsData.APNumber
                ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then
                    strJournalDetailRemarks = "PEMBAYARAN PANJAR PESANAN PEMOTONGAN - " & clsData.APNumber
                ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                    strJournalDetailRemarks = "PEMBAYARAN HUTANG PESANAN PEMOTONGAN - " & clsData.APNumber
                ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                    strJournalDetailRemarks = "PEMBAYARAN PANJAR PESANAN PENGIRIMAN - " & clsData.APNumber
                ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                    strJournalDetailRemarks = "PEMBAYARAN HUTANG PESANAN PENGIRIMAN - " & clsData.APNumber
                End If

                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = VO.Journal.Value.HutangUsaha,
                                         .DebitAmount = clsData.TotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = strJournalDetailRemarks
                                     })
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAIDOfOutgoingPayment,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.TotalAmount,
                                         .Remarks = strJournalDetailRemarks
                                     })

                Dim clsJournal As New VO.Journal With
                    {
                        .ProgramID = clsData.ProgramID,
                        .CompanyID = clsData.CompanyID,
                        .ID = PrevJournal.ID,
                        .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                        .ReferencesID = clsData.ID,
                        .JournalDate = IIf(bolNew, clsData.APDate, PrevJournal.JournalDate),
                        .TotalAmount = clsData.TotalAmount,
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

                '# Update Journal ID in Account Payable
                DL.AccountPayable.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function Unapprove(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Unapprove(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unapprove(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                End If

                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)

                '# Cancel Approve Journal
                BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                '# Cancel Submit Journal
                BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                '# Unapprove Account Receivable
                DL.AccountPayable.Unapprove(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function SetupPayment(ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                            ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                            ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data telah DIBAYAR")
                ElseIf intStatusID <> VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data harus disetujui terlebih dahulu")
                End If

                DL.AccountPayable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function SetupCancelPayment(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = SetupCancelPayment(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupCancelPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID <> VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data belum pernah diproses BAYAR")
                End If

                DL.AccountPayable.SetupCancelPayment(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)

                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function UpdateTaxInvoiceNumber(ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                      ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UpdateTaxInvoiceNumber(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                      ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data telah dihapus")
                End If

                DL.AccountPayable.UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE NOMOR FAKTUR PAJAK", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetailForSetupBalance(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailForSetupBalanceWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                            ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailForSetupBalanceWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetail(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetail(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                             ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstandingPurchaseOrderCutting(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                 ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderCutting(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstandingPurchaseOrderTransport(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                   ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderTransport(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataStatus(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strAPID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strAPID & "-" & Format(DL.AccountPayable.GetMaxIDStatus(sqlCon, sqlTrans, strAPID) + 1, "000")
            Dim clsData As New VO.AccountPayableStatus With
                {
                    .ID = strNewID,
                    .APID = strAPID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace