Namespace BL
    Public Class AccountReceivable

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strModules, 0, "")
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal strModules As String) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "AR" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-" & strModules & "-"
            strNewID &= Format(DL.AccountReceivable.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
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
            strNewID &= Format(DL.AccountReceivable.GetMaxNo(sqlCon, sqlTrans, dtmTransDate.Year, intCompanyID, intProgramID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.AccountReceivable) As String
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
                                        ByVal bolNew As Boolean, ByVal clsData As VO.AccountReceivable) As String
            Try
                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    clsData.ARNumber = GetNewNo(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtItem As New DataTable

                    '# For Setup Balance
                    If clsData.Modules.Trim = VO.AccountReceivable.SalesBalance Then
                        dtItem = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPayment Or
                        clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                        dtItem = DL.AccountReceivable.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                    End If

                    DL.AccountReceivable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                    '# Revert Payment Amount
                    For Each dr As DataRow In dtItem.Rows
                        '# For Setup Balance
                        If clsData.Modules.Trim = VO.AccountReceivable.SalesBalance Then
                            DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("SalesID"))
                        ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then
                            DL.SalesContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("SalesID"))
                        ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                            DL.SalesContract.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("SalesID"))
                        End If
                    Next
                End If

                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountReceivable.DataExists(sqlCon, sqlTrans, clsData.ARNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.ARNumber & " sudah ada.")
                End If

                clsData.DueDate = clsData.ARDate.AddDays(clsData.DueDateValue)
                DL.AccountReceivable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ARID = clsData.ID
                    DL.AccountReceivable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Calculate Payment Amount
                For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    '# For Setup Balance
                    If clsData.Modules = VO.AccountReceivable.SalesBalance Then
                        DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.SalesID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then
                        DL.SalesContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.SalesID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                        DL.SalesContract.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.SalesID)
                    End If
                Next

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ARNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.AccountReceivable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.GetDetail(sqlCon, Nothing, strID)
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
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                End If

                Dim dtItem As New DataTable

                '# For Setup Balance
                If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                    dtItem = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
                ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Or
                    strModules.Trim = VO.AccountReceivable.ReceivePayment Then
                    dtItem = DL.AccountReceivable.ListDataDetail(sqlCon, sqlTrans, strID)
                End If

                DL.AccountReceivable.DeleteData(sqlCon, sqlTrans, strID)

                '# Revert Payment Amount
                For Each dr As DataRow In dtItem.Rows
                    '# For Setup Balance
                    If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                        DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("SalesID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Then
                        DL.SalesContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("SalesID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.ReceivePayment Then
                        DL.SalesContract.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("SalesID"))
                    End If
                Next

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                    bolReturn = True
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
            Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf intStatusID = VO.Status.Values.Payment Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah DIBAYAR")
            ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.AccountReceivable.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal submit. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                End If

                DL.AccountReceivable.Unsubmit(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                End If

                DL.AccountReceivable.Approve(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)



                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim clsJournalDetail As New List(Of VO.JournalDet)
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAIDOfIncomePayment,
                                         .DebitAmount = clsData.TotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "PELUNASAN SALDO - " & clsData.ARNumber
                                     })
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = VO.Journal.Value.PiutangUsaha,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.TotalAmount,
                                         .Remarks = "PELUNASAN SALDO - " & clsData.ARNumber
                                     })

                Dim clsJournal As New VO.Journal With
                    {
                        .ProgramID = clsData.ProgramID,
                        .CompanyID = clsData.CompanyID,
                        .ID = PrevJournal.ID,
                        .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                        .ReferencesID = clsData.ID,
                        .JournalDate = IIf(bolNew, clsData.ARDate, PrevJournal.JournalDate),
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

                '# Update Journal ID in Business Partners
                DL.AccountReceivable.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
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
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                End If

                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)

                '# Cancel Approve Journal
                BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                '# Cancel Submit Journal
                BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                '# Unapprove Account Receivable
                DL.AccountReceivable.Unapprove(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data telah DIBAYAR")
                ElseIf intStatusID <> VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data harus disetujui terlebih dahulu")
                End If

                DL.AccountReceivable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID <> VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data belum pernah diproses BAYAR")
                End If

                DL.AccountReceivable.SetupCancelPayment(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data telah dihapus")
                End If

                DL.AccountReceivable.UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE NOMOR FAKTUR PAJAK", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetailForSetupBalance(ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, Nothing, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetailForSetupBalanceWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                            ByVal intBPID As Integer, ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailForSetupBalanceWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetail(ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetail(sqlCon, Nothing, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                             ByVal intBPID As Integer, ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strARID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataStatus(sqlCon, Nothing, strARID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strARID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strARID & "-" & Format(DL.AccountReceivable.GetMaxIDStatus(sqlCon, sqlTrans, strARID) + 1, "000")
            Dim clsData As New VO.AccountReceivableStatus With
                {
                    .ID = strNewID,
                    .ARID = strARID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace