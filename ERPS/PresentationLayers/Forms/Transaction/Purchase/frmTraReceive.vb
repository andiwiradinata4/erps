Imports DevExpress.XtraGrid
Public Class frmTraReceive

    Private intPos As Integer = 0
    Private clsData As New VO.Receive
    Private intProgramID As Integer
    Private intCompanyID As Integer
    Private dtData As New DataTable
    Private bolExport As Boolean

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3,
       cSubmit As Byte = 4, cCancelSubmit As Byte = 5, cSep2 As Byte = 6, cExportExcel As Byte = 7,
       cSep3 As Byte = 8, cRefresh As Byte = 9, cClose As Byte = 10

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
        UI.usForm.SetGrid(grdView, "ReceiveNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ReceiveDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "BPCode", "Kode Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPName", "Nama Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PCID", "PCID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CoAofStock", "Akun Persediaan", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CoACodeofStock", "Kode Akun Persediaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CoANameofStock", "Nama Akun Persediaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ReferencesNumber", "No. Referensi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PlatNumber", "No. Plat", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Driver", "Nama Supir", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TotalQuantity", "Total Quantity", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPN", "PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPH", "PPH", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPP", "Total DPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPN", "Total PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPH", "Total PPh", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "GrandTotal", "Grand Total", 100, UI.usDefGrid.gReal2Num)
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
            .Item(cExportExcel).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtData As DataTable = BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionReceive)
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
        Application.DoEvents()
        Try
            dtData = BL.Receive.ListData(intProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, cboStatus.SelectedValue)
            grdMain.DataSource = dtData
            pgMain.Value = 80
            Application.DoEvents()
            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvSetButton()
            prvResetProgressBar()
        End Try
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("ReceiveNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "ReceiveNumber", strSearch)
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

    Private Function prvGetData() As VO.Receive
        Dim clsReturn As New VO.Receive
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.ProgramID = grdView.GetRowCellValue(intPos, "ProgramID")
        clsReturn.ProgramName = grdView.GetRowCellValue(intPos, "ProgramName")
        clsReturn.CompanyID = grdView.GetRowCellValue(intPos, "CompanyID")
        clsReturn.CompanyName = grdView.GetRowCellValue(intPos, "CompanyName")
        clsReturn.ReceiveNumber = grdView.GetRowCellValue(intPos, "ReceiveNumber")
        clsReturn.ReceiveDate = grdView.GetRowCellValue(intPos, "ReceiveDate")
        clsReturn.BPID = grdView.GetRowCellValue(intPos, "BPID")
        clsReturn.BPCode = grdView.GetRowCellValue(intPos, "BPCode")
        clsReturn.BPName = grdView.GetRowCellValue(intPos, "BPName")
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
        Dim frmDetail As New frmTraReceiveDet
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
        Dim frmDetail As New frmTraReceiveDet
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
        If Not UI.usForm.frmAskQuestion("Hapus Nomor " & clsData.ReceiveNumber & "?") Then Exit Sub

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
        Application.DoEvents()
        Try
            BL.Receive.DeleteData(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ReceiveNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Submit Nomor " & clsData.ReceiveNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Application.DoEvents()
        Try
            BL.Receive.Submit(clsData.ID, "")
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ReceiveNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvCancelSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Batal Submit Nomor " & clsData.ReceiveNumber & "?") Then Exit Sub

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
        Application.DoEvents()
        Try
            BL.Receive.Unsubmit(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Batal submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ReceiveNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
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
        grdView.BestFitColumns()
    End Sub

    Private Sub prvUserAccess()
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.DeleteAccess)
            .Item(cSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.SubmitAccess)
            .Item(cCancelSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.CancelSubmitAccess)
            .Item(cExportExcel).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.ExportExcelAccess)
            bolExport = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.ExportReportAccess)
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraReceive_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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