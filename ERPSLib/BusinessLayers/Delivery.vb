Namespace BL
    Public Class Delivery

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal bolIsStock As Boolean,
                                        ByVal strSelectedItemType As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, bolIsStock, strSelectedItemType)
            End Using
        End Function

        Public Shared Function ListDataOutstandingSalesReturn(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                             ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataOutstandingSalesReturn(sqlCon, Nothing, intProgramID, intCompanyID, intBPID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "SD" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.Delivery.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Delivery) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                'Dim clsDataStockOut As New List(Of VO.StockOut)
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.DeliveryDate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.DeliveryNumber.Trim = "" Then clsData.DeliveryNumber = clsData.ID
                    Else
                        Dim dtItem As DataTable = DL.Delivery.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        Dim dtItemTransport As DataTable = DL.Delivery.ListDataDetailTransport(sqlCon, sqlTrans, clsData.ID)

                        DL.Delivery.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.Delivery.DeleteDataDetailTransport(sqlCon, sqlTrans, clsData.ID)

                        For Each dr As DataRow In dtItem.Rows
                            '# Revert DC Quantity
                            If clsData.IsStock Then
                                DL.OrderRequest.CalculateDCTotalUsed(sqlCon, sqlTrans, dr.Item("SCDetailID"))
                            Else
                                DL.SalesContract.CalculateDCTotalUsed(sqlCon, sqlTrans, dr.Item("SCDetailID"))
                            End If

                            ''# Recalculate Stock Out
                            'clsDataStockOut = New List(Of VO.StockOut)
                            'clsDataStockOut.Add(New VO.StockOut With
                            '                   {
                            '                       .ProgramID = clsData.ProgramID,
                            '                       .CompanyID = clsData.CompanyID,
                            '                       .ParentID = "",
                            '                       .ParentDetailID = "",
                            '                       .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                            '                       .SourceData = "",
                            '                       .ItemID = dr.Item("ItemID"),
                            '                       .Quantity = 0,
                            '                       .Weight = 0,
                            '                       .TotalWeight = 0,
                            '                       .CoAofStock = clsData.CoAofStock
                            '                   })
                        Next
                        'BL.StockOut.SaveData(sqlCon, sqlTrans, clsDataStockOut)

                        '# Revert Done Quantity
                        For Each dr As DataRow In dtItemTransport.Rows
                            DL.PurchaseOrderTransport.CalculateDoneTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                        Next

                        Dim clsHelper As New DataSetHelper
                        Dim dtParentID As DataTable = clsHelper.SelectGroupByInto("ParentID", dtItem, "ParentID", "", "ParentID")
                        For Each dr As DataRow In dtParentID.Rows
                            '# Revert Payment Item Parent Amount
                            If dr.Item("ParentID") <> "" Then DL.SalesContract.CalculateDCTotalUsedParent(sqlCon, sqlTrans, dr.Item("ParentID"))
                        Next

                        Dim clsExists As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, clsData.ID)
                        If clsExists.DPAmount > 0 Or clsExists.TotalPayment > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                        End If

                        Dim dtDeliveryTransport As DataTable = DL.Delivery.ListDataDeliveryTransport(sqlCon, sqlTrans, clsData.ID)
                        For Each dr As DataRow In dtDeliveryTransport.Rows
                            If dr.Item("DPAmount") > 0 Or dr.Item("TotalPayment") > 0 Then
                                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data transport telah diproses pembayaran")
                            End If
                        Next

                        '# Delete Delivery Transport
                        DL.Delivery.DeleteDataDeliveryTransport(sqlCon, sqlTrans, clsData.ID)
                    End If

                    Dim intStatusID As Integer = DL.Delivery.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.Delivery.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.Delivery.DataExists(sqlCon, sqlTrans, clsData.DeliveryNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.DeliveryNumber & " sudah ada.")
                    End If

                    DL.Delivery.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    'clsDataStockOut = New List(Of VO.StockOut)
                    For Each clsDet As VO.DeliveryDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.DeliveryID = clsData.ID
                        DL.Delivery.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        'clsDataStockOut.Add(New VO.StockOut With
                        '   {
                        '       .ProgramID = clsData.ProgramID,
                        '       .CompanyID = clsData.CompanyID,
                        '       .ParentID = "",
                        '       .ParentDetailID = "",
                        '       .OrderNumberSupplier = clsDet.OrderNumberSupplier,
                        '       .SourceData = "",
                        '       .ItemID = clsDet.ItemID,
                        '       .Quantity = 0,
                        '       .Weight = 0,
                        '       .TotalWeight = 0
                        '   })
                    Next

                    '# Save Data Delivery Transport
                    intCount = 1
                    If clsData.DeliveryTransport IsNot Nothing Then
                        For Each clsDet As VO.DeliveryTransport In clsData.DeliveryTransport
                            clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                            clsDet.DeliveryID = clsData.ID
                            clsDet.DeliveryNumber = clsData.DeliveryNumber
                            DL.Delivery.SaveDataDeliveryTransport(sqlCon, sqlTrans, clsDet)
                            intCount += 1
                        Next
                    End If

                    '# Save Data Detail Transport
                    intCount = 1
                    If clsData.DetailTransport IsNot Nothing Then
                        For Each clsDet As VO.DeliveryDetTransport In clsData.DetailTransport
                            clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                            clsDet.DeliveryID = clsData.ID
                            DL.Delivery.SaveDataDetailTransport(sqlCon, sqlTrans, clsDet)
                            intCount += 1
                        Next
                    End If

                    '# Calculate DC Quantity
                    For Each clsDet As VO.DeliveryDet In clsData.Detail
                        If clsData.IsStock Then
                            DL.OrderRequest.CalculateDCTotalUsed(sqlCon, sqlTrans, clsDet.SCDetailID)
                        Else
                            DL.SalesContract.CalculateDCTotalUsed(sqlCon, sqlTrans, clsDet.SCDetailID)
                        End If
                    Next

                    Dim strParentIDExists As String = ""
                    For Each clsDet As VO.DeliveryDet In clsData.Detail
                        If strParentIDExists <> clsDet.ParentID Then
                            If clsDet.ParentID <> "" Then DL.SalesContract.CalculateDCTotalUsedParent(sqlCon, sqlTrans, clsDet.ParentID)
                            strParentIDExists = clsDet.ParentID
                        End If
                    Next

                    '# Calculate Done Quantity
                    If clsData.DetailTransport IsNot Nothing Then
                        For Each clsDet As VO.DeliveryDetTransport In clsData.DetailTransport
                            DL.PurchaseOrderTransport.CalculateDoneTotalUsed(sqlCon, sqlTrans, clsDet.PODetailID)
                        Next
                    End If

                    '# Save Data Status
                    BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    ''# Save Data Stock Out
                    'BL.StockOut.SaveData(sqlCon, sqlTrans, clsDataStockOut)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.DeliveryNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.Delivery
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                'Dim clsDataStockOut As New List(Of VO.StockOut)
                Try
                    Dim clsData As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.Delivery.ListDataDetail(sqlCon, sqlTrans, strID)
                    Dim dtItemTransport As DataTable = DL.Delivery.ListDataDetailTransport(sqlCon, sqlTrans, strID)

                    DL.Delivery.DeleteData(sqlCon, sqlTrans, strID)
                    DL.Delivery.DeleteDataDetailTransport(sqlCon, sqlTrans, strID)

                    For Each dr As DataRow In dtItem.Rows
                        '# Revert DC Quantity
                        DL.SalesContract.CalculateDCTotalUsed(sqlCon, sqlTrans, dr.Item("SCDetailID"))

                        ''# Recalculate Stock Out
                        'clsDataStockOut = New List(Of VO.StockOut)
                        'clsDataStockOut.Add(New VO.StockOut With
                        '                   {
                        '                       .ProgramID = clsData.ProgramID,
                        '                       .CompanyID = clsData.CompanyID,
                        '                       .ParentID = "",
                        '                       .ParentDetailID = "",
                        '                       .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                        '                       .SourceData = "",
                        '                       .ItemID = dr.Item("ItemID"),
                        '                       .Quantity = 0,
                        '                       .Weight = 0,
                        '                       .TotalWeight = 0
                        '                   })
                    Next
                    'BL.StockOut.SaveData(sqlCon, sqlTrans, clsDataStockOut)

                    '# Revert Done Quantity
                    For Each dr As DataRow In dtItemTransport.Rows
                        DL.PurchaseOrderTransport.CalculateDoneTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                    Next

                    Dim clsHelper As New DataSetHelper
                    Dim dtParentID As DataTable = clsHelper.SelectGroupByInto("ParentID", dtItem, "ParentID", "", "ParentID")
                    For Each dr As DataRow In dtParentID.Rows
                        '# Revert Payment Item Parent Amount
                        If dr.Item("ParentID") <> "" Then DL.SalesContract.CalculateDCTotalUsedParent(sqlCon, sqlTrans, dr.Item("ParentID"))
                    Next

                    '# Save Data Status
                    BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim clsData As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, strID)
            If clsData.StatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf clsData.IsDeleted Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.Delivery.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

            GenerateJournal(sqlCon, sqlTrans, strID)

            RecalculateStockOut(sqlCon, sqlTrans, clsData)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    If clsdata.DPAmount > 0 Or clsdata.TotalPayment > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses pembayaran")
                    ElseIf clsdata.DPAmountTransport > 0 Or clsdata.TotalPaymentTransport > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data transport telah diproses pembayaran")
                    End If

                    '# Cancel Approve Journal Delivery
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal Delivery
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                    If clsData.TotalDPPTransport > 0 Then
                        '# Cancel Approve Journal Delivery Transport
                        BL.Journal.Unapprove(clsData.JournalIDTransport.Trim, "")

                        '# Cancel Submit Journal Delivery Transport
                        BL.Journal.Unsubmit(clsData.JournalIDTransport.Trim, "")
                    End If

                    DL.Delivery.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    RecalculateStockOut(sqlCon, sqlTrans, clsData)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function PrintVer00(ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.Delivery.PrintVer00(sqlCon, Nothing, intProgramID, intCompanyID, strID)
                For Each dr As DataRow In dtReturn.Rows
                    If IsNumeric(dr.Item("ItemLength")) Then
                        Dim decValue As Decimal = Convert.ToDecimal(dr.Item("ItemLength"))
                        dr.Item("ItemLength") = Format(decValue / 100, "#,##0")
                    End If
                Next
            End Using
            Return dtReturn
        End Function

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                Dim clsData As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0
                Dim decTotalCostRawMaterial As Decimal = DL.Delivery.GetTotalCostRawMaterial(sqlCon, sqlTrans, strID)
                If decTotalCostRawMaterial <= 0 Then Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data pengiriman tidak memiliki nilai HPP")
                If ERPSLib.UI.usUserApp.JournalPost.CoAofRevenue < 0 Then Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan Akun Penjualan belum ditentukan")

                Dim clsJournalDetail As New List(Of VO.JournalDet)
                decTotalAmount += clsData.TotalDPP + clsData.RoundingManual
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

                intGroupID += 1
                '# Akun Biaya Bahan Baku -> Debit
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAOfCostRawMaterial,
                                         .DebitAmount = decTotalCostRawMaterial,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                '# Akun Persediaan -> Kredit || ERPSLib.UI.usUserApp.JournalPost.CoAofStock,
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAofStock,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalCostRawMaterial,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })
                decTotalAmount += decTotalCostRawMaterial

                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = IIf(bolNew, clsData.DeliveryDate, PrevJournal.JournalDate),
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.DeliveryNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Delivery
                DL.Delivery.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID, decTotalCostRawMaterial)

                If clsData.TotalDPPTransport > 0 Then
                    '# Delivery Transport
                    intGroupID = 1
                    PrevJournal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalIDTransport)
                    bolNew = IIf(PrevJournal.ID = "", True, False)

                    '# Generate Journal
                    decTotalAmount = 0
                    decTotalAmount += clsData.TotalDPPTransport
                    clsJournalDetail = New List(Of VO.JournalDet)
                    '# Biaya Transport -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                            {
                                .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAOfTransport,
                                .DebitAmount = decTotalAmount,
                                .CreditAmount = 0,
                                .Remarks = "",
                                .GroupID = intGroupID,
                                .BPID = clsData.TransporterID
                            })

                    '# Hutang Transport Belum ditagih -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                            {
                                .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableTransportOutstandingPayment,
                                .DebitAmount = 0,
                                .CreditAmount = decTotalAmount,
                                .Remarks = "",
                                .GroupID = intGroupID,
                                .BPID = clsData.TransporterID
                            })

                    clsJournal = New VO.Journal With
                    {
                        .ProgramID = clsData.ProgramID,
                        .CompanyID = clsData.CompanyID,
                        .ID = PrevJournal.ID,
                        .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                        .ReferencesID = clsData.ID,
                        .JournalDate = clsData.DeliveryDate,
                        .TotalAmount = decTotalAmount,
                        .IsAutoGenerate = True,
                        .StatusID = VO.Status.Values.Draft,
                        .Remarks = clsData.Remarks,
                        .LogBy = ERPSLib.UI.usUserApp.UserID,
                        .Initial = "",
                        .ReferencesNo = clsData.DeliveryNumber,
                        .Detail = clsJournalDetail,
                        .Save = VO.Save.Action.SaveAndSubmit
                    }

                    '# Save Journal
                    strJournalID = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                    '# Approve Journal
                    BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                    '# Update Journal ID in Delivery
                    DL.Delivery.UpdateJournalIDTransport(sqlCon, sqlTrans, clsData.ID, strJournalID)
                    DL.Delivery.UpdateJournalIDDeliveryTransport(sqlCon, sqlTrans, clsData.ID, strJournalID)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Shared Sub RecalculateStockOut(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.Delivery)
            Dim dtItem As DataTable = DL.Delivery.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
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
                               .CoAofStock = dr.Item("CoAofStock")
                           })
            Next
            BL.StockOut.SaveData(sqlCon, sqlTrans, clsDataStockOut)
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDetail(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingSalesReturnItem(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDetailOutstandingSalesReturnItem(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

#End Region

#Region "Delivery Transport"

        Public Shared Function ListDataDeliveryTransport(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDeliveryTransport(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

#End Region

#Region "Detail Transport"

        Public Shared Function ListDataDetailTransport(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDetailTransport(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataStatus(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strDeliveryID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strDeliveryID & "-" & Format(DL.Delivery.GetMaxIDStatus(sqlCon, sqlTrans, strDeliveryID) + 1, "000")
            Dim clsData As New VO.DeliveryStatus With
                {
                    .ID = strNewID,
                    .DeliveryID = strDeliveryID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.Delivery.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace