Namespace BL
    Public Class Cutting

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cutting.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "CP" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.Cutting.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Cutting) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                'Dim clsDataStockIN As New List(Of VO.StockIn)
                'Dim clsDataStockOut As New List(Of VO.StockOut)
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.CuttingDate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.CuttingNumber.Trim = "" Then clsData.CuttingNumber = clsData.ID
                    Else
                        Dim dtItem As DataTable = DL.Cutting.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        Dim dtItemResult As DataTable = DL.Cutting.ListDataDetailResult(sqlCon, sqlTrans, clsData.ID)

                        DL.Cutting.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.Cutting.DeleteDataDetailResult(sqlCon, sqlTrans, clsData.ID)

                        '# Revert Done Quantity PO Detail
                        For Each dr As DataRow In dtItem.Rows
                            DL.PurchaseOrderCutting.CalculateDoneTotalUsedDetail(sqlCon, sqlTrans, dr.Item("PODetailID"))
                        Next

                        '# Revert Done Quantity PO Detail Result
                        For Each dr As DataRow In dtItemResult.Rows
                            DL.PurchaseOrderCutting.CalculateDoneTotalUsedDetailResult(sqlCon, sqlTrans, dr.Item("PODetailResultID"))
                        Next

                        Dim clsExists As VO.Cutting = DL.Cutting.GetDetail(sqlCon, sqlTrans, clsData.ID)
                        If clsExists.DPAmount > 0 Or clsExists.TotalPayment > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                        End If
                    End If

                    Dim intStatusID As Integer = DL.Cutting.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.Cutting.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.Cutting.DataExists(sqlCon, sqlTrans, clsData.CuttingNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.CuttingNumber & " sudah ada.")
                    End If

                    DL.Cutting.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.CuttingDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.CuttingID = clsData.ID
                        DL.Cutting.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        'clsDataStockOut.Add(New VO.StockOut With
                        '{
                        '    .ProgramID = clsData.ProgramID,
                        '    .CompanyID = clsData.CompanyID,
                        '    .ParentID = "",
                        '    .ParentDetailID = "",
                        '    .OrderNumberSupplier = clsDet.OrderNumberSupplier,
                        '    .SourceData = "",
                        '    .ItemID = clsDet.ItemID,
                        '    .Quantity = 0,
                        '    .Weight = 0,
                        '    .TotalWeight = 0
                        '})
                    Next

                    '# Save Data Detail Result
                    intCount = 1
                    For Each clsDet As VO.CuttingDetResult In clsData.DetailResult
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.CuttingID = clsData.ID
                        DL.Cutting.SaveDataDetailResult(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        ' clsDataStockIN.Add(New VO.StockIn With
                        '{
                        '    .ProgramID = clsData.ProgramID,
                        '     .CompanyID = clsData.CompanyID,
                        '     .ParentID = "",
                        '     .ParentDetailID = "",
                        '     .OrderNumberSupplier = clsDet.OrderNumberSupplier,
                        '     .SourceData = "",
                        '     .ItemID = clsDet.ItemID,
                        '     .InQuantity = 0,
                        '     .InWeight = 0,
                        '     .InTotalWeight = 0,
                        '     .UnitPrice = clsDet.UnitPriceHPP
                        '})
                    Next

                    '# Calculate Done Quantity PO Detail
                    For Each clsDet As VO.CuttingDet In clsData.Detail
                        DL.PurchaseOrderCutting.CalculateDoneTotalUsedDetail(sqlCon, sqlTrans, clsDet.PODetailID)
                    Next

                    '# Calculate Done Quantity PO Detail Result
                    For Each clsDet As VO.CuttingDetResult In clsData.DetailResult
                        DL.PurchaseOrderCutting.CalculateDoneTotalUsedDetailResult(sqlCon, sqlTrans, clsDet.PODetailResultID)
                    Next

                    '# Save Data Status
                    BL.Cutting.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    ''# Save Data Stock IN
                    'BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)

                    ''# Save Data Stock Out
                    'BL.StockOut.SaveData(sqlCon, sqlTrans, clsDataStockOut)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.CuttingNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.Cutting
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cutting.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.Cutting = DL.Cutting.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.Cutting.ListDataDetail(sqlCon, sqlTrans, strID)
                    Dim dtItemResult As DataTable = DL.Cutting.ListDataDetailResult(sqlCon, sqlTrans, strID)

                    DL.Cutting.DeleteData(sqlCon, sqlTrans, strID)

                    '# Revert Done Quantity PO Detail Result
                    For Each dr As DataRow In dtItemResult.Rows
                        DL.PurchaseOrderCutting.CalculateDoneTotalUsedDetailResult(sqlCon, sqlTrans, dr.Item("PODetailResultID"))
                    Next

                    'Dim clsDataStockOut As New List(Of VO.StockOut)
                    For Each dr As DataRow In dtItem.Rows
                        '# Revert Done Quantity
                        DL.PurchaseOrderCutting.CalculateDoneTotalUsedDetail(sqlCon, sqlTrans, dr.Item("PODetailID"))

                        ''# Recalculate Stock OUT
                        'clsDataStockOut.Add(New VO.StockOut With
                        '{
                        '    .ProgramID = clsData.ProgramID,
                        '    .CompanyID = clsData.CompanyID,
                        '    .ParentID = "",
                        '    .ParentDetailID = "",
                        '    .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                        '    .SourceData = "",
                        '    .ItemID = dr.Item("ItemID"),
                        '    .Quantity = 0,
                        '    .Weight = 0,
                        '    .TotalWeight = 0
                        '})
                    Next

                    'Dim clsDataStockIN As New List(Of VO.StockIn)
                    'For Each dr As DataRow In dtItemResult.Rows
                    '    '# Recalculate Stock IN
                    '    clsDataStockIN.Add(New VO.StockIn With
                    '   {
                    '       .ProgramID = clsData.ProgramID,
                    '        .CompanyID = clsData.CompanyID,
                    '        .ParentID = "",
                    '        .ParentDetailID = "",
                    '        .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                    '        .SourceData = "",
                    '        .ItemID = dr.Item("ItemID"),
                    '        .InQuantity = 0,
                    '        .InWeight = 0,
                    '        .InTotalWeight = 0,
                    '        .UnitPrice = dr.Item("UnitPriceHPP")
                    '   })
                    'Next

                    '# Save Data Status
                    BL.Cutting.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    ''# Save Data Stock IN
                    'BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)

                    ''# Save Data Stock Out
                    'BL.StockOut.SaveData(sqlCon, sqlTrans, clsDataStockOut)
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
            Dim clsData As VO.Cutting = DL.Cutting.GetDetail(sqlCon, sqlTrans, strID)
            If clsData.StatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf clsData.IsDeleted Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.Cutting.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.Cutting.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

            GenerateJournal(sqlCon, sqlTrans, strID)

            RecalculateStockInOut(sqlCon, sqlTrans, clsData)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.Cutting = DL.Cutting.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    ElseIf clsdata.DPAmount > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses Down Payment")
                    ElseIf clsdata.TotalPayment > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses pembayaran")
                    End If

                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                    DL.Cutting.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Cutting.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    RecalculateStockInOut(sqlCon, sqlTrans, clsData)

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
                Dim clsData As VO.Cutting = DL.Cutting.GetDetail(sqlCon, sqlTrans, strID)
                Dim clsPO As VO.Cutting = DL.Cutting.GetDetail(sqlCon, sqlTrans, clsData.ID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0 '+ clsData.TotalPPN - clsData.TotalPPH 
                Dim clsJournalDetail As New List(Of VO.JournalDet)
                Dim decTotalDPPRawMaterial As Decimal = DL.Cutting.GetTotalCostRawMaterial(sqlCon, sqlTrans, strID)

                '# Akun Biaya Pemotongan -> Debit
                decTotalAmount += clsData.TotalDPP + clsData.RoundingManual
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAOfCutting,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                '# Akun Hutang Pemotongan Belum ditagih -> Kredit
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableCuttingOutstandingPayment,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalAmount,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                If clsPO.IsClaimCustomer Then
                    intGroupID += 1
                    '# Akun Piutang Usaha Belum ditagih -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivableOutstandingPayment,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    '# Akun Penjualan -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofRevenue,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalAmount,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })
                    decTotalAmount += decTotalAmount
                End If

                'intGroupID += 1
                ''# Akun Persediaan -> Debit
                'clsJournalDetail.Add(New VO.JournalDet With
                '                     {
                '                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofStock,
                '                         .DebitAmount = decTotalDPPRawMaterial,
                '                         .CreditAmount = 0,
                '                         .Remarks = "",
                '                         .GroupID = intGroupID,
                '                         .BPID = clsData.BPID
                '                     })

                ''# Akun Persediaan Cutting Center -> Kredit
                'clsJournalDetail.Add(New VO.JournalDet With
                '                     {
                '                         .CoAID = clsData.CoAIDofStock,
                '                         .DebitAmount = 0,
                '                         .CreditAmount = decTotalDPPRawMaterial,
                '                         .Remarks = "",
                '                         .GroupID = intGroupID,
                '                         .BPID = clsData.BPID
                '                     })
                'decTotalAmount += decTotalDPPRawMaterial

                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = IIf(bolNew, clsData.CuttingDate, PrevJournal.JournalDate),
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.CuttingNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Cutting
                DL.Cutting.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub RecalculateStockInOut(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.Cutting)
            Dim dtItem As DataTable = DL.Cutting.ListDataDetailResult(sqlCon, sqlTrans, clsData.ID)
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
                       .UnitPrice = dr.Item("UnitPriceHPP"),
                       .CoAofStock = dr.Item("CoAIDofStock")
                   })
            Next
            BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)

            dtItem = DL.Cutting.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
            Dim clsDataStockOut As New List(Of VO.StockOut)
            For Each dr As DataRow In dtItem.Rows
                clsDataStockOut.Add(New VO.StockOut With
                           {
                               .ProgramID = clsData.ProgramID,
                               .CompanyID = clsData.CompanyID,
                               .ParentID = "",
                               .ParentDetailID = "",
                               .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                               .SourceData = "",
                               .ItemID = dr.Item("ItemID"),
                               .Quantity = 0,
                               .Weight = 0,
                               .TotalWeight = 0,
                               .CoAofStock = dr.Item("CoAIDofStock")
                           })
            Next
            BL.StockOut.SaveData(sqlCon, sqlTrans, clsDataStockOut)

        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strCuttingID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cutting.ListDataDetail(sqlCon, Nothing, strCuttingID)
            End Using
        End Function

#End Region

#Region "Detail Result"

        Public Shared Function ListDataDetailResult(ByVal strCuttingID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cutting.ListDataDetailResult(sqlCon, Nothing, strCuttingID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strCuttingID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Cutting.ListDataStatus(sqlCon, Nothing, strCuttingID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strCuttingID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strCuttingID & "-" & Format(DL.Cutting.GetMaxIDStatus(sqlCon, sqlTrans, strCuttingID) + 1, "000")
            Dim clsData As New VO.CuttingStatus With
                {
                    .ID = strNewID,
                    .CuttingID = strCuttingID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.Cutting.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace