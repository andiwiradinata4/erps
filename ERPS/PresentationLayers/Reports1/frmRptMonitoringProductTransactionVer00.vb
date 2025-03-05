Imports DevExpress.XtraGrid

Public Class frmRptMonitoringProductTransactionVer00

#Region "Property"

    Private bolExport As Boolean = True
    Private intCompanyID As Integer
    Private ds As New DataSet
    Private dtDataMain As New DataTable
    Private dtDataSalesContract As New DataTable
    Private dtDataPurchaseContract As New DataTable
    Private dtDataReceive As New DataTable
    Private Const cPreview As Byte = 0, cExportExcel As Byte = 1, cSep1 As Byte = 2, cRefresh As Byte = 3, cClose As Byte = 4

#End Region

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "PCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PCDate", "Tanggal Kontrak", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ItemType", "Jenis Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemSpec", "Spesifikasi Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PCQuantity", "Jumlah [Kontrak Pembelian]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "PCTotalWeight", "Total Berat [Kontrak Pembelian]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "RVQuantity", "Jumlah [Penerimaan]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "RVTotalWeight", "Total Berat [Penerimaan]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SPKQuantity", "Jumlah [SPK Potong]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "SPKTotalWeight", "Total Berat [SPK Potong]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "CUTQuantity", "Jumlah [Proses Potong]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "CUTTotalWeight", "Total Berat [Proses Potong]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SCQuantity", "Jumlah [Kontrak Penjualan]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "SCTotalWeight", "Total Berat [Kontrak Penjualan]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "DVQuantity", "Jumlah [Pengiriman]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "DVTotalWeight", "Total Berat [Pengiriman]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "InventoryTotalWeight", "Total Berat [Kontrak Pembelian vs Kontrak Penjualan]", 100, UI.usDefGrid.gReal2Num)

        UI.usForm.SetGrid(grdSalesContractView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSalesContractView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSalesContractView, "SCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSalesContractView, "SCDate", "Tanggal Kontrak", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdSalesContractView, "BPName", "Nama Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSalesContractView, "SCQuantity", "Jumlah [Kontrak Penjualan]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSalesContractView, "SCTotalWeight", "Total Berat [Kontrak Penjualan]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSalesContractView, "DVQuantity", "Jumlah [Pengiriman]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSalesContractView, "DVTotalWeight", "Total Berat [Pengiriman]", 100, UI.usDefGrid.gReal2Num)


        UI.usForm.SetGrid(grdPurchaseContractView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdPurchaseContractView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdPurchaseContractView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPurchaseContractView, "ItemCodeExternal", "Kode Barang Eksternal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPurchaseContractView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPurchaseContractView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPurchaseContractView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPurchaseContractView, "Quantity", "Jumlah [Kontrak Pembelian]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdPurchaseContractView, "TotalWeight", "Total Berat [Kontrak Pembelian]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdPurchaseContractView, "DCQuantity", "Jumlah [Penerimaan]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdPurchaseContractView, "DCWeight", "Total Berat [Penerimaan]", 100, UI.usDefGrid.gReal2Num)

        UI.usForm.SetGrid(grdReceiveView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdReceiveView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdReceiveView, "ReceiveNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdReceiveView, "ReceiveDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdReceiveView, "ReferencesNumber", "Nomor Referesi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdReceiveView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdReceiveView, "ItemCodeExternal", "Kode Barang Eksternal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdReceiveView, "Quantity", "Jumlah [Penerimaan]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdReceiveView, "TotalWeight", "Total Berat [Penerimaan]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdReceiveView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdReceiveView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdReceiveView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdReceiveView, "ClaimQuantity", "Jumlah [Klaim]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdReceiveView, "ClaimWeight", "Total Berat [Klaim]", 100, UI.usDefGrid.gReal2Num)
    End Sub

    Private Sub prvSetProgressBar(ByVal intMax As Integer)
        pgMain.Value = 0
        pgMain.Maximum = intMax
    End Sub

    Private Sub prvRefreshProgressBar()
        pgMain.Value += 1
    End Sub

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
    End Sub

    Private Sub prvQuery()
        ToolBar.Focus()
        If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Period salah")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        prvSetProgressBar(10)
        prvRefreshProgressBar()

        Try
            ds = New DataSet
            dtDataMain = BL.Reports.MonitoringProductTransactionReportMainVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            dtDataSalesContract = BL.Reports.MonitoringProductTransactionReportSalesContractVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            dtDataPurchaseContract = BL.Reports.MonitoringProductTransactionReportPurchaseContractVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            dtDataReceive = BL.Reports.MonitoringProductTransactionReportReceiveVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)

            dtDataMain.Columns.Item("PCDetailID").Unique = True
            dtDataSalesContract.Columns.Item("ID").Unique = True
            dtDataPurchaseContract.Columns.Item("ID").Unique = True
            dtDataReceive.Columns.Item("ID").Unique = True

            ds.Tables.Add(dtDataMain)
            ds.Tables.Add(dtDataSalesContract)
            ds.Tables.Add(dtDataPurchaseContract)
            ds.Tables.Add(dtDataReceive)

            ds.Relations.Add("Kontrak Penjualan", dtDataMain.Columns.Item("PCDetailID"), dtDataSalesContract.Columns.Item("PCDetailID"))
            ds.Relations.Add("Kontrak Pembelian", dtDataMain.Columns.Item("PCDetailID"), dtDataPurchaseContract.Columns.Item("PCDetailID"))
            ds.Relations.Add("Penerimaan Pembelian", dtDataMain.Columns.Item("PCDetailID"), dtDataReceive.Columns.Item("PCDetailID"))

            grdMain.DataSource = dtDataMain
            grdMain.LevelTree.Nodes.Add("Kontrak Penjualan", grdSalesContractView)
            grdMain.LevelTree.Nodes.Add("Kontrak Pembelian", grdPurchaseContractView)
            grdMain.LevelTree.Nodes.Add("Penerimaan Pembelian", grdReceiveView)

            grdMain.Refresh()
            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvResetProgressBar()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvPreview()
        ToolBar.Focus()
        If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Period salah")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        prvSetProgressBar(10)
        prvRefreshProgressBar()

        Try
            If dtDataMain.Rows.Count = 0 Then
                dtDataMain = BL.Reports.MonitoringProductTransactionReportMainVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
                dtDataSalesContract = BL.Reports.MonitoringProductTransactionReportSalesContractVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
                dtDataMain.Columns.Item("PCDetailID").Unique = True
                dtDataSalesContract.Columns.Item("ID").Unique = True
            End If

            Dim results = From pc In dtDataMain.AsEnumerable
                          Join sc In dtDataSalesContract.AsEnumerable
                          On pc.Item("PCDetailID") Equals sc.Item("PCDetailID")
                          Select
                            PCDetailID = pc.Item("PCDetailID"), CODetailID = pc.Item("CODetailID"), PCNumber = pc.Item("PCNumber"), PCDate = pc.Item("PCDate"),
                            OrderNumberSupplier = pc.Item("OrderNumberSupplier"), ItemCode = pc.Item("ItemCode"), ItemType = pc.Item("ItemType"), ItemSpec = pc.Item("ItemSpec"),
                            Thick = pc.Item("Thick"), Width = pc.Item("Width"), Length = pc.Item("Length"), PCQuantity = pc.Item("PCQuantity"), PCTotalWeight = pc.Item("PCTotalWeight"),
                            SCNumber = sc.Item("SCNumber"), SCDate = sc.Item("SCDate"), CustomerName = sc.Item("BPName"), SCQuantity = sc.Item("SCQuantity"), SCTotalWeight = sc.Item("SCTotalWeight"),
                            RVQuantity = pc.Item("RVQuantity"), RVTotalWeight = pc.Item("RVTotalWeight"), SPKQuantity = pc.Item("SPKQuantity"), SPKTotalWeight = pc.Item("SPKTotalWeight"),
                            CUTQuantity = pc.Item("CUTQuantity"), CUTTotalWeight = pc.Item("CUTTotalWeight"), DVQuantity = pc.Item("DVQuantity"), DVTotalWeight = pc.Item("DVTotalWeight"),
                            InventoryTotalWeight = pc.Item("InventoryTotalWeight")

            Dim strFilterDate As String = Format(dtpDateFrom.Value, "dd-MMM-yyyy") & " - " & Format(dtpDateTo.Value, "dd-MMM-yyyy")
            Dim crReport As New rptMonitoringProductTransactionVer00
            With crReport
                .Parameters.Item("ParamFilterPeriod").Value = strFilterDate
                .Parameters.Item("ParamCompanyName").Value = ERPSLib.UI.usUserApp.CompanyName
                .DataSource = results
                .CreateDocument(True)
                .ShowPreviewMarginLines = False
                .ShowPrintMarginsWarning = False
            End With
            Dim frmDetail As New frmReportPreview
            With frmDetail
                .docViewer.DocumentSource = crReport
                .pgExportButton.Enabled = bolExport
                .Text = Me.Text & " - " & VO.Reports.PrintOut
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvResetProgressBar()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvExportExcel()
        Dim dxExporter As New DX.usDXHelper
        dxExporter.DevExport(Me, grdMain, Me.Text, Me.Text, DX.usDxExportFormat.fXls, True, True, DX.usDXExportType.etDefault)
    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
        grdSalesContractView.Columns.Clear()
        prvSetGrid()
    End Sub

    Private Sub prvSumGrid()
        Dim SumPCQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PCQuantity", "Jumlah [Kontrak Pembelian]: {0:#,##0.00}")
        Dim SumPCTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PCTotalWeight", "Total Berat [Kontrak Pembelian]: {0:#,##0.00}")
        Dim SumSCQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SCQuantity", "Jumlah [Kontrak Penjualan]: {0:#,##0.00}")
        Dim SumSCTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SCTotalWeight", "Total Berat [Kontrak Penjualan]: {0:#,##0.00}")
        Dim SumRVQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RVQuantity", "Jumlah [Penerimaan]: {0:#,##0.00}")
        Dim SumRVTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RVTotalWeight", "Total Berat [Penerimaan]: {0:#,##0.00}")
        Dim SumSPKQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SPKQuantity", "Jumlah [SPK Potong]: {0:#,##0.00}")
        Dim SumSPKTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SPKTotalWeight", "Total Berat [SPK Potong]: {0:#,##0.00}")
        Dim SumCUTQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUTQuantity", "Jumlah [Proses Potong]: {0:#,##0.00}")
        Dim SumCUTTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUTTotalWeight", "Total Berat [Proses Potong]: {0:#,##0.00}")
        Dim SumDVQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DVQuantity", "Jumlah [Pengiriman]: {0:#,##0.00}")
        Dim SumDVTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DVTotalWeight", "Total Berat [Pengiriman]: {0:#,##0.00}")

        If grdView.Columns("PCQuantity").SummaryText.Trim = "" Then grdView.Columns("PCQuantity").Summary.Add(SumPCQuantity)
        If grdView.Columns("PCTotalWeight").SummaryText.Trim = "" Then grdView.Columns("PCTotalWeight").Summary.Add(SumPCTotalWeight)

        If grdView.Columns("SCQuantity").SummaryText.Trim = "" Then grdView.Columns("SCQuantity").Summary.Add(SumSCQuantity)
        If grdView.Columns("SCTotalWeight").SummaryText.Trim = "" Then grdView.Columns("SCTotalWeight").Summary.Add(SumSCTotalWeight)

        If grdView.Columns("RVQuantity").SummaryText.Trim = "" Then grdView.Columns("RVQuantity").Summary.Add(SumRVQuantity)
        If grdView.Columns("RVTotalWeight").SummaryText.Trim = "" Then grdView.Columns("RVTotalWeight").Summary.Add(SumRVTotalWeight)

        If grdView.Columns("SPKQuantity").SummaryText.Trim = "" Then grdView.Columns("SPKQuantity").Summary.Add(SumSPKQuantity)
        If grdView.Columns("SPKTotalWeight").SummaryText.Trim = "" Then grdView.Columns("SPKTotalWeight").Summary.Add(SumSPKTotalWeight)

        If grdView.Columns("CUTQuantity").SummaryText.Trim = "" Then grdView.Columns("CUTQuantity").Summary.Add(SumCUTQuantity)
        If grdView.Columns("CUTTotalWeight").SummaryText.Trim = "" Then grdView.Columns("CUTTotalWeight").Summary.Add(SumCUTTotalWeight)

        If grdView.Columns("DVQuantity").SummaryText.Trim = "" Then grdView.Columns("DVQuantity").Summary.Add(SumDVQuantity)
        If grdView.Columns("DVTotalWeight").SummaryText.Trim = "" Then grdView.Columns("DVTotalWeight").Summary.Add(SumDVTotalWeight)

        If grdView.GroupCount > 0 Then grdView.ExpandAllGroups()

        '# Sales Contract
        Dim SumSCQuantitySub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SCQuantity", "Jumlah [Kontrak Penjualan]: {0:#,##0.00}")
        Dim SumSCTotalWeightSub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SCTotalWeight", "Total Berat [Kontrak Penjualan]: {0:#,##0.00}")
        Dim SumDVQuantitySub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DVQuantity", "Jumlah [Pengiriman]: {0:#,##0.00}")
        Dim SumDVTotalWeightSub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DVTotalWeight", "Total Berat [Pengiriman]: {0:#,##0.00}")

        If grdSalesContractView.Columns("SCQuantity").SummaryText.Trim = "" Then grdSalesContractView.Columns("SCQuantity").Summary.Add(SumSCQuantitySub)
        If grdSalesContractView.Columns("SCTotalWeight").SummaryText.Trim = "" Then grdSalesContractView.Columns("SCTotalWeight").Summary.Add(SumSCTotalWeightSub)

        If grdSalesContractView.Columns("DVQuantity").SummaryText.Trim = "" Then grdSalesContractView.Columns("DVQuantity").Summary.Add(SumDVQuantitySub)
        If grdSalesContractView.Columns("DVTotalWeight").SummaryText.Trim = "" Then grdSalesContractView.Columns("DVTotalWeight").Summary.Add(SumDVTotalWeightSub)

        '# Purchase Contract
        Dim SumPCQuantitySub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Jumlah [Kontrak Pembelian]: {0:#,##0.00}")
        Dim SumPCTotalWeightSub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat [Kontrak Pembelian]: {0:#,##0.00}")
        Dim SumDCQuantitySub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DCQuantity", "Jumlah [Penerimaan]: {0:#,##0.00}")
        Dim SumDCTotalWeightSub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DCWeight", "Total Berat [Penerimaan]: {0:#,##0.00}")

        If grdPurchaseContractView.Columns("Quantity").SummaryText.Trim = "" Then grdPurchaseContractView.Columns("Quantity").Summary.Add(SumPCQuantitySub)
        If grdPurchaseContractView.Columns("TotalWeight").SummaryText.Trim = "" Then grdPurchaseContractView.Columns("TotalWeight").Summary.Add(SumPCTotalWeightSub)

        If grdPurchaseContractView.Columns("DCQuantity").SummaryText.Trim = "" Then grdPurchaseContractView.Columns("DCQuantity").Summary.Add(SumDCQuantitySub)
        If grdPurchaseContractView.Columns("DCWeight").SummaryText.Trim = "" Then grdPurchaseContractView.Columns("DCWeight").Summary.Add(SumDCTotalWeightSub)

        '# Receive
        Dim SumReceiveQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Jumlah [Penerimaan]: {0:#,##0.00}")
        Dim SumReceiveWeightSub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat [Penerimaan]: {0:#,##0.00}")
        Dim SumClaimQuantitySub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClaimQuantity", "Jumlah [Klaim]: {0:#,##0.00}")
        Dim SumClaimTotalWeightSub As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClaimWeight", "Total Berat [Klaim]: {0:#,##0.00}")

        If grdReceiveView.Columns("Quantity").SummaryText.Trim = "" Then grdReceiveView.Columns("Quantity").Summary.Add(SumReceiveQuantity)
        If grdReceiveView.Columns("TotalWeight").SummaryText.Trim = "" Then grdReceiveView.Columns("TotalWeight").Summary.Add(SumReceiveWeightSub)

        If grdReceiveView.Columns("ClaimQuantity").SummaryText.Trim = "" Then grdReceiveView.Columns("ClaimQuantity").Summary.Add(SumClaimQuantitySub)
        If grdReceiveView.Columns("ClaimWeight").SummaryText.Trim = "" Then grdReceiveView.Columns("ClaimWeight").Summary.Add(SumClaimTotalWeightSub)

    End Sub

#Region "Form Handle"

    Private Sub frmRptMonitoringProductTransactionVer00_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmRptMonitoringProductTransactionVer00_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetGrid()
        dtpDateFrom.Value = Today.Date.AddDays(-14)
        dtpDateTo.Value = Today.Date
        intCompanyID = ERPSLib.UI.usUserApp.CompanyID
        Dim clsCompany As VO.Company = BL.Company.GetDetail(intCompanyID)
        txtCompanyName.Text = clsCompany.Name
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        prvClear()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Preview" : prvPreview()
            Case "Export Excel" : prvExportExcel()
            Case "Refresh" : prvQuery()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class