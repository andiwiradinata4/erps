Imports DevExpress.XtraGrid
Public Class frmTraDelivery

    Private intPos As Integer = 0
    Private clsData As New VO.Delivery
    Private intProgramID As Integer
    Private intCompanyID As Integer
    Private dtData As New DataTable
    Private bolExport As Boolean

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3,
       cSubmit As Byte = 4, cCancelSubmit As Byte = 5, cSep2 As Byte = 6, cPrint As Byte = 7,
       cExportExcel As Byte = 8, cSep3 As Byte = 9, cRefresh As Byte = 10, cClose As Byte = 11

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ProgramName", "ProgramName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyName", "CompanyName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "DeliveryNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DeliveryDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "BPCode", "Kode Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPName", "Nama Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TransporterID", "TransporterID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "TransporterCode", "Kode Transporter", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TransporterName", "Nama Transporter", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "SCNumber", "No. Kontrak Penjualan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ReferencesNumber", "No. Referensi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PlatNumber", "No. Plat", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Driver", "Nama Supirt", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TotalQuantity", "Total Quantity", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPN", "PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPH", "PPH", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPP", "Total DPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPN", "Total PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPH", "Total PPh", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "GrandTotal", "Grand Total", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "UnitPriceTransport", "Harga Pengiriman", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPPTransport", "Total DPP Transport", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPNTransport", "Total PPN Transport", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "IsFreePPNTransport", "Free PPN Transport ?", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPHTransport", "Total PPh Transport", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "IsFreePPHTransport", "Free PPH Transport ?", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "GrandTotalTransport", "Grand Total Transport", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "RoundingManual", "RoundingManual", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdView, "SubmitBy", "Disubmit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitDate", "Tanggal Disubmit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "IsDeleted", "IsDeleted", 100, UI.usDefGrid.gBoolean, False)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "StatusID", "StatusID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Dibuat Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Tanggal Buat", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogBy", "Diedit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LogDate", "Tanggal Edit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogInc", "LogInc", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "StatusInfo", "Status", 100, UI.usDefGrid.gString)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cDetail).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
            .Item(cSubmit).Enabled = bolEnable
            .Item(cCancelSubmit).Enabled = bolEnable
            .Item(cPrint).Enabled = bolEnable
            .Item(cExportExcel).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtData As DataTable = BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionSalesDelivery)
            Dim dr As DataRow
            dr = dtData.NewRow
            With dr
                .BeginEdit()
                .Item("StatusID") = VO.Status.Values.All
                .Item("StatusName") = "SEMUA"
                .EndEdit()
            End With
            dtData.Rows.Add(dr)
            dtData.AcceptChanges()
            dtData.DefaultView.Sort = "StatusID ASC"
            dtData = dtData.DefaultView.ToTable

            UI.usForm.FillComboBox(cboStatus, dtData, "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvDefaultFilter()
        intProgramID = ERPSLib.UI.usUserApp.ProgramID
        intCompanyID = ERPSLib.UI.usUserApp.CompanyID
        txtCompanyName.Text = ERPSLib.UI.usUserApp.CompanyName
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Try
            dtData = BL.Delivery.ListData(intProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, cboStatus.SelectedValue)
            grdMain.DataSource = dtData
            pgMain.Value = 80
            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvSetButton()
            prvResetProgressBar()
        End Try
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("DeliveryNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "DeliveryNumber", strSearch)
        End With
    End Sub

    Private Function prvGetCS() As VO.CS
        Dim clsCS As New VO.CS
        clsCS.ProgramID = ERPSLib.UI.usUserApp.ProgramID
        clsCS.ProgramName = ERPSLib.UI.usUserApp.ProgramName
        clsCS.CompanyID = intCompanyID
        clsCS.CompanyName = txtCompanyName.Text.Trim
        Return clsCS
    End Function

    Private Function prvGetData() As VO.Delivery
        Dim clsReturn As New VO.Delivery
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.ProgramID = grdView.GetRowCellValue(intPos, "ProgramID")
        clsReturn.ProgramName = grdView.GetRowCellValue(intPos, "ProgramName")
        clsReturn.CompanyID = grdView.GetRowCellValue(intPos, "CompanyID")
        clsReturn.CompanyName = grdView.GetRowCellValue(intPos, "CompanyName")
        clsReturn.DeliveryNumber = grdView.GetRowCellValue(intPos, "DeliveryNumber")
        clsReturn.DeliveryDate = grdView.GetRowCellValue(intPos, "DeliveryDate")
        clsReturn.BPID = grdView.GetRowCellValue(intPos, "BPID")
        clsReturn.BPCode = grdView.GetRowCellValue(intPos, "BPCode")
        clsReturn.BPName = grdView.GetRowCellValue(intPos, "BPName")
        clsReturn.SCID = grdView.GetRowCellValue(intPos, "SCID")
        clsReturn.SCNumber = grdView.GetRowCellValue(intPos, "SCNumber")
        clsReturn.ReferencesNumber = grdView.GetRowCellValue(intPos, "ReferencesNumber")
        clsReturn.PlatNumber = grdView.GetRowCellValue(intPos, "PlatNumber")
        clsReturn.Driver = grdView.GetRowCellValue(intPos, "Driver")
        clsReturn.TotalQuantity = grdView.GetRowCellValue(intPos, "TotalQuantity")
        clsReturn.TotalWeight = grdView.GetRowCellValue(intPos, "TotalWeight")
        clsReturn.PPN = grdView.GetRowCellValue(intPos, "PPN")
        clsReturn.PPH = grdView.GetRowCellValue(intPos, "PPH")
        clsReturn.TotalDPP = grdView.GetRowCellValue(intPos, "TotalDPP")
        clsReturn.TotalPPN = grdView.GetRowCellValue(intPos, "TotalPPN")
        clsReturn.TotalPPH = grdView.GetRowCellValue(intPos, "TotalPPH")
        clsReturn.GrandTotal = grdView.GetRowCellValue(intPos, "GrandTotal")
        clsReturn.TotalDPPTransport = grdView.GetRowCellValue(intPos, "TotalDPPTransport")
        clsReturn.TotalPPNTransport = grdView.GetRowCellValue(intPos, "TotalPPNTransport")
        clsReturn.TotalPPHTransport = grdView.GetRowCellValue(intPos, "TotalPPHTransport")
        clsReturn.GrandTotalTransport = grdView.GetRowCellValue(intPos, "GrandTotalTransport")
        clsReturn.RoundingManual = grdView.GetRowCellValue(intPos, "RoundingManual")
        clsReturn.IsDeleted = grdView.GetRowCellValue(intPos, "IsDeleted")
        clsReturn.Remarks = grdView.GetRowCellValue(intPos, "Remarks")
        clsReturn.StatusID = grdView.GetRowCellValue(intPos, "StatusID")
        clsReturn.CreatedBy = grdView.GetRowCellValue(intPos, "CreatedBy")
        clsReturn.CreatedDate = grdView.GetRowCellValue(intPos, "CreatedDate")
        clsReturn.LogBy = grdView.GetRowCellValue(intPos, "LogBy")
        clsReturn.LogDate = grdView.GetRowCellValue(intPos, "LogDate")
        clsReturn.LogInc = grdView.GetRowCellValue(intPos, "LogInc")
        clsReturn.StatusInfo = grdView.GetRowCellValue(intPos, "StatusInfo")
        Return clsReturn
    End Function

    Private Sub prvNew()
        prvResetProgressBar()
        Dim frmDetail As New frmTraDeliveryDet
        With frmDetail
            .pubIsNew = True
            .pubCS = prvGetCS()
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        prvResetProgressBar()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraDeliveryDet
        With frmDetail
            .pubIsNew = False
            .pubCS = prvGetCS()
            .pubID = clsData.ID
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Hapus Nomor " & clsData.DeliveryNumber & "?") Then Exit Sub

        Dim frmDetail As New usFormRemarks
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.Remarks = .pubValue
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Try
            BL.Delivery.DeleteData(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "DeliveryNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Submit Nomor " & clsData.DeliveryNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Try
            BL.Delivery.Submit(clsData.ID, "")
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "DeliveryNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvCancelSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Batal Submit Nomor " & clsData.DeliveryNumber & "?") Then Exit Sub

        Dim frmDetail As New usFormRemarks
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.Remarks = .pubValue
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Try
            BL.Delivery.Unsubmit(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Batal submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "DeliveryNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvPrint()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdView.GetRowCellValue(intPos, "ID")
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        prvGetCS()
        clsData = prvGetData()
        Try
            Dim dtData As DataTable = BL.Delivery.PrintVer00(clsData.ProgramID, intCompanyID, strID)
            'Dim intStatusID As Integer = 0
            'For Each dr As DataRow In dtData.Rows
            '    intStatusID = dr.Item("StatusID")
            '    Exit For
            'Next

            Dim crReport As New rptShippingInvoiceVer00

            ''# Setup Watermark Report
            'If intStatusID <> VO.Status.Values.Approved Then
            '    crReport.Watermark.ShowBehind = False
            '    crReport.Watermark.Text = "DRAFT" & vbCrLf & "NOT OFFICIAL"
            '    crReport.Watermark.ForeColor = System.Drawing.Color.DimGray
            '    crReport.Watermark.Font = New System.Drawing.Font("Tahoma", 70.0!, System.Drawing.FontStyle.Bold)
            '    crReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal
            '    crReport.Watermark.TextTransparency = 150
            'End If

            crReport.DataSource = dtData
            crReport.CreateDocument(True)
            crReport.ShowPreviewMarginLines = False
            crReport.ShowPrintMarginsWarning = False

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
            pgMain.Value = 100
            prvResetProgressBar()
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
        prvSetButton()
    End Sub

    Private Sub prvChooseCompany()
        Dim frmDetail As New frmViewCompany
        With frmDetail
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCompanyID = .pubLUdtRow.Item("CompanyID")
                txtCompanyName.Text = .pubLUdtRow.Item("CompanyName")
                prvClear()
                btnExecute.Focus()
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Main
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalQuantity", "Total Quantity: {0:#,##0.00}")
        Dim SumTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat: {0:#,##0.00}")
        Dim SumTotalDPP As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPP", "Total DPP: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPN", "Total PPN: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPH", "Total PPh: {0:#,##0.00}")
        Dim SumGrandTotal As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", "Grand Total: {0:#,##0.00}")

        If grdView.Columns("TotalQuantity").SummaryText.Trim = "" Then
            grdView.Columns("TotalQuantity").Summary.Add(SumTotalQuantity)
        End If

        If grdView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdView.Columns("TotalWeight").Summary.Add(SumTotalWeight)
        End If

        If grdView.Columns("TotalDPP").SummaryText.Trim = "" Then
            grdView.Columns("TotalDPP").Summary.Add(SumTotalDPP)
        End If

        If grdView.Columns("TotalPPN").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPN").Summary.Add(SumTotalPPN)
        End If

        If grdView.Columns("TotalPPH").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPH").Summary.Add(SumTotalPPH)
        End If

        If grdView.Columns("GrandTotal").SummaryText.Trim = "" Then
            grdView.Columns("GrandTotal").Summary.Add(SumGrandTotal)
        End If

        '# Transport
        Dim SumTotalDPPTransport As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPPTransport", "Total DPP Transport: {0:#,##0.00}")
        Dim SumTotalPPNTransport As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPNTransport", "Total PPN Transport: {0:#,##0.00}")
        Dim SumTotalPPHTransport As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPHTransport", "Total PPh Transport: {0:#,##0.00}")
        Dim SumGrandTotalTransport As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotalTransport", "Grand Total Transport: {0:#,##0.00}")

        If grdView.Columns("TotalDPPTransport").SummaryText.Trim = "" Then
            grdView.Columns("TotalDPPTransport").Summary.Add(SumTotalDPPTransport)
        End If

        If grdView.Columns("TotalPPNTransport").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPNTransport").Summary.Add(SumTotalPPNTransport)
        End If

        If grdView.Columns("TotalPPHTransport").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPHTransport").Summary.Add(SumTotalPPHTransport)
        End If

        If grdView.Columns("GrandTotalTransport").SummaryText.Trim = "" Then
            grdView.Columns("GrandTotalTransport").Summary.Add(SumGrandTotalTransport)
        End If

        grdView.BestFitColumns()
    End Sub

    Private Sub prvUserAccess()
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.DeleteAccess)
            .Item(cSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.SubmitAccess)
            .Item(cCancelSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.CancelSubmitAccess)
            .Item(cPrint).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.PrintReportAccess)
            .Item(cExportExcel).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.ExportExcelAccess)
            bolExport = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.ExportReportAccess)
            '.Item(cPrint).Visible = False
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraDelivery_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraDelivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillCombo()
        prvSetGrid()
        cboStatus.SelectedValue = VO.Status.Values.All
        dtpDateFrom.Value = Today.Date.AddDays(-7)
        dtpDateTo.Value = Today.Date
        prvDefaultFilter()
        prvQuery()
        prvUserAccess()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cNew).Name Then
            prvNew()
        ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cDetail).Name : prvDetail()
                Case ToolBar.Buttons(cDelete).Name : prvDelete()
                Case ToolBar.Buttons(cSubmit).Name : prvSubmit()
                Case ToolBar.Buttons(cCancelSubmit).Name : prvCancelSubmit()
                Case ToolBar.Buttons(cPrint).Name : prvPrint()
                Case ToolBar.Buttons(cExportExcel).Name : prvExportExcel()
            End Select
        End If
    End Sub

    Private Sub btnCompany_Click(sender As Object, e As EventArgs) Handles btnCompany.Click
        prvChooseCompany()
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        prvClear()
    End Sub

    Private Sub grdView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim bolIsDeleted As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("IsDeleted"))
            If bolIsDeleted = "Checked" And e.Appearance.BackColor <> Color.Salmon Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

#End Region

End Class