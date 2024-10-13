Namespace BL

    Public Class SalesReturn

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesReturn.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "SR" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & "A" & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.SalesReturn.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.SalesReturn) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.SalesReturnDate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.SalesReturnNumber.Trim = "" Then clsData.SalesReturnNumber = clsData.ID
                    Else
                        Dim dtDetail As DataTable = DL.SalesReturn.ListDataDetail(sqlCon, sqlTrans, clsData.ID)

                        DL.SalesReturn.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                        '# Calculate Total Used in Delivery Detail
                        For Each dr As DataRow In dtDetail.Rows
                            If DL.SalesReturn.IsAlreadyPaymentDetail(sqlCon, sqlTrans, dr.Item("ID")) Then
                                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di proses pembayaran")
                            End If

                            DL.Delivery.CalculateReturnTotalUsed(sqlCon, sqlTrans, dr.Item("DeliveryDetailID"))
                        Next
                    End If

                    Dim intStatusID As Integer = DL.SalesReturn.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.SalesReturn.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.SalesReturn.DataExists(sqlCon, sqlTrans, clsData.SalesReturnNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.SalesReturnNumber & " sudah ada.")
                    End If

                    DL.SalesReturn.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.SalesReturnDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.SalesReturnID = clsData.ID
                        DL.SalesReturn.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        '# Calculate Total Used in Delivery Detail
                        DL.Delivery.CalculateReturnTotalUsed(sqlCon, sqlTrans, clsDet.DeliveryDetailID)
                    Next

                    '# Save Data Status
                    BL.SalesReturn.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.SalesReturn
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesReturn.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.SalesReturn = DL.SalesReturn.GetDetail(sqlCon, sqlTrans, strID)
                    Dim dtDetail As DataTable = DL.SalesReturn.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                    If clsData.StatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf clsData.StatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.SalesReturn.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    DL.SalesReturn.DeleteData(sqlCon, sqlTrans, strID)

                    '# Calculate Total Used in Delivery Detail
                    For Each dr As DataRow In dtDetail.Rows
                        If DL.SalesReturn.IsAlreadyPaymentDetail(sqlCon, sqlTrans, dr.Item("ID")) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di proses pembayaran")
                        End If

                        DL.Delivery.CalculateReturnTotalUsed(sqlCon, sqlTrans, dr.Item("DeliveryDetailID"))
                    Next

                    '# Save Data Status
                    BL.SalesReturn.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.SalesReturn.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.SalesReturn.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.SalesReturn.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.SalesReturn.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesReturn.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.SalesReturn.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesReturn.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesReturn.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                    Dim clsData As VO.SalesReturn = DL.SalesReturn.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf clsData.StatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesReturn.Approve(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesReturn.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    GenerateJournal(sqlCon, sqlTrans, strID)

                    RecalculateStockIn(sqlCon, sqlTrans, clsData)

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
                    Dim dtDetail As DataTable = DL.SalesReturn.ListDataDetail(sqlCon, sqlTrans, strID)
                    Dim clsData As VO.SalesReturn = DL.SalesReturn.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf clsData.StatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.SalesReturn.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesReturn.Unapprove(sqlCon, sqlTrans, strID)

                    '# Calculate Total Used in Delivery Detail
                    For Each dr As DataRow In dtDetail.Rows
                        If DL.SalesReturn.IsAlreadyPaymentDetail(sqlCon, sqlTrans, dr.Item("ID")) Then
                            Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah di proses pembayaran")
                        End If
                    Next

                    '# Save Data Status
                    BL.SalesReturn.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                    RecalculateStockIn(sqlCon, sqlTrans, clsData)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                Dim clsData As VO.SalesReturn = DL.SalesReturn.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = clsData.TotalDPP + clsData.RoundingManual ' + clsData.TotalPPN - clsData.TotalPPH
                Dim clsJournalDetail As New List(Of VO.JournalDet) From {
                    New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAofStock,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     },
                    New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableOutstandingPayment,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalAmount,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     }
                }

                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = IIf(bolNew, clsData.SalesReturnDate, PrevJournal.JournalDate),
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.SalesReturnNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Sales Return
                DL.SalesReturn.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Shared Sub RecalculateStockIn(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.SalesReturn)
            Dim dtItem As DataTable = DL.SalesReturn.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
            Dim clsDataStockIN As New List(Of VO.StockIn)
            For Each dr As DataRow In dtItem.Rows
                clsDataStockIN.Add(New VO.StockIn With
                   {
                       .ProgramID = clsData.ProgramID,
                       .CompanyID = clsData.CompanyID,
                       .ParentID = "",
                       .ParentDetailID = "",
                       .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                       .SourceData = "",
                       .ItemID = dr.Item("ItemID"),
                       .InQuantity = 0,
                       .InWeight = 0,
                       .InTotalWeight = 0,
                       .UnitPrice = dr.Item("UnitPrice"),
                       .CoAofStock = dr.Item("CoAofStock")
                   })
            Next
            BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strSalesReturnID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesReturn.ListDataDetail(sqlCon, Nothing, strSalesReturnID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strPOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesReturn.ListDataStatus(sqlCon, Nothing, strPOID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strSalesReturnID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strSalesReturnID & "-" & Format(DL.SalesReturn.GetMaxIDStatus(sqlCon, sqlTrans, strSalesReturnID) + 1, "000")
            Dim clsData As New VO.SalesReturnStatus With
                {
                    .ID = strNewID,
                    .SalesReturnID = strSalesReturnID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.SalesReturn.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class

End Namespace