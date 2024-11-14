Imports DevExpress.PivotGrid.OLAP.AdoWrappers
Imports DevExpress.XtraGrid

Public Class frmRptMonitoringProductTransactionVer00

#Region "Property"

    Private bolExport As Boolean = False
    Private intCompanyID As Integer
    Private Const _
       cPreview As Byte = 0, cClose As Byte = 1

#End Region

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "PCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PCDate", "Tanggal Kontrak", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemType", "Jenis Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemSpec", "Spesifikasi Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PCQuantity", "Jumlah [Kontrak Pembelian]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "PCTotalWeight", "Total Berat [Kontrak Pembelian]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SCQuantity", "Jumlah [Kontrak Penjualan]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "SCTotalWeight", "Total Berat [Kontrak Penjualan]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "RVQuantity", "Jumlah [Penerimaan]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "RVTotalWeight", "Total Berat [Penerimaan]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SPKQuantity", "Jumlah [SPK Potong]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "SPKTotalWeight", "Total Berat [SPK Potong]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "CUTQuantity", "Jumlah [Proses Potong]", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "CUTTotalWeight", "Total Berat [Proses Potong]", 100, UI.usDefGrid.gReal2Num)
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
            Dim ds As New DataSet
            Dim dtDataMain As DataTable = BL.Reports.MonitoringProductTransactionReportMainVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            Dim dtDataSalesContract As DataTable = BL.Reports.MonitoringProductTransactionReportSalesContractVer00(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            ds.Tables.Add(dtDataMain)
            ds.Tables.Add(dtDataSalesContract)

            ds.Relations.Add("SalesContract", dtDataMain.Columns.Item("PCDetailID"), dtDataSalesContract.Columns.Item("PCDetailID"))

            grdMain.DataSource = dtDataMain
            'grdMain.LevelTree.Nodes.Add("SalesContract", grdSalesContractView)

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

    Private Sub prvExportExcel()
        Dim dxExporter As New DX.usDXHelper
        dxExporter.DevExport(Me, grdMain, Me.Text, Me.Text, DX.usDxExportFormat.fXls, True, True, DX.usDXExportType.etDefault)
    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
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

        If grdView.GroupCount > 0 Then grdView.ExpandAllGroups()
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
            Case "Export Excel" : prvExportExcel()
            Case "Refresh" : prvQuery()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class