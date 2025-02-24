Namespace BL
    Public Class Cost

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cost.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "CO" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.Cost.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Cost) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.CostDate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.CostNumber.Trim = "" Then clsData.CostNumber = clsData.ID
                    Else
                        DL.Cost.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                    End If

                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Payment Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                    ElseIf DL.Cost.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.Cost.DataExists(sqlCon, sqlTrans, clsData.CostNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.CostNumber & " sudah ada.")
                    End If

                    DL.Cost.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.CostDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.CostID = clsData.ID
                        DL.Cost.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.CostNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.Cost
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cost.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf intStatusID = VO.Status.Values.Payment Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                    ElseIf DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    DL.Cost.DeleteData(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf intStatusID = VO.Status.Values.Payment Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah DIBAYAR")
            ElseIf DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.Cost.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf intStatusID = VO.Status.Values.Payment Then
                        Err.Raise(515, "", "Data tidak dapat di Batal submit. Dikarenakan status data telah DIBAYAR")
                    ElseIf DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.Cost.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Approve(ByVal strID As String, ByVal strRemarks As String,
                                       ByVal intCoAID As Integer, ByVal dtmPaymentDate As DateTime) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf intStatusID = VO.Status.Values.Payment Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah DIBAYAR")
                    ElseIf DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.Cost.Approve(sqlCon, sqlTrans, strID, intCoAID, dtmPaymentDate)

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    Dim clsData As VO.Cost = DL.Cost.GetDetail(sqlCon, sqlTrans, strID)
                    Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                    Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                    '# Generate Journal
                    Dim clsJournalDetail As New List(Of VO.JournalDet)
                    Dim dtDetail As DataTable = DL.Cost.ListDataDetail(sqlCon, sqlTrans, strID)
                    For Each dr As DataRow In dtDetail.Rows
                        clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = dr.Item("COAID"),
                                                 .DebitAmount = dr.Item("Amount"),
                                                 .CreditAmount = 0,
                                                 .Remarks = dr.Item("Remarks")
                                             })
                    Next

                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = clsData.CoAID,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsData.TotalAmount,
                                             .Remarks = "PEMBAYARAN BIAYA " & clsData.ID & IIf(clsData.Remarks.Trim <> "", " | ", "") & clsData.Remarks
                                         })

                    Dim clsJournal As New VO.Journal With
                        {
                            .ProgramID = clsData.ProgramID,
                            .CompanyID = clsData.CompanyID,
                            .ID = PrevJournal.ID,
                            .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                            .ReferencesID = clsData.ID,
                            .JournalDate = IIf(bolNew, clsData.CostDate, PrevJournal.JournalDate),
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

                    '# Update Journal ID in Cost
                    DL.Cost.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)

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
                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf intStatusID = VO.Status.Values.Payment Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah DIBAYAR")
                    ElseIf DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    End If

                    Dim clsData As VO.Cost = DL.Cost.GetDetail(sqlCon, sqlTrans, strID)

                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                    '# Unapprove Cost
                    DL.Cost.Unapprove(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupPayment(ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                            ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
                    If DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan data telah dihapus")
                    ElseIf intStatusID = VO.Status.Values.Payment Then
                        Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data telah DIBAYAR")
                    ElseIf intStatusID <> VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data harus disetujui terlebih dahulu")
                    End If

                    DL.Cost.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate)

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupCancelPayment(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
                    If DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data telah dihapus")
                    ElseIf intStatusID <> VO.Status.Values.Payment Then
                        Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data belum pernah diproses BAYAR")
                    End If

                    DL.Cost.SetupCancelPayment(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UpdateTaxInvoiceNumber(ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                      ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Cost.GetStatusID(sqlCon, sqlTrans, strID)
                    If DL.Cost.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data telah dihapus")
                    End If

                    DL.Cost.UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber)

                    '# Save Data Status
                    BL.Cost.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE NOMOR FAKTUR PAJAK", ERPSLib.UI.usUserApp.UserID, strRemarks)

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

        Public Shared Function ListDataDetail(ByVal strCostID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cost.ListDataDetail(sqlCon, Nothing, strCostID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strCostID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cost.ListDataStatus(sqlCon, Nothing, strCostID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strCostID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strCostID & "-" & Format(DL.Cost.GetMaxIDStatus(sqlCon, sqlTrans, strCostID) + 1, "000")
            Dim clsData As New VO.CostStatus With
                {
                    .ID = strNewID,
                    .CostID = strCostID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.Cost.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace