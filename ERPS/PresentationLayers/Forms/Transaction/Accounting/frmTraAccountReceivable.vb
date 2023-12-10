Imports DevExpress.XtraGrid
Public Class frmTraAccountReceivable

    Private intPos As Integer = 0
    Private clsData As New VO.AccountReceivable
    Private intCompanyID As Integer
    Private dtData As New DataTable
    Private strModules As String = ""

    Public WriteOnly Property pubModules As String
        Set(value As String)
            strModules = value
        End Set
    End Property

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3,
       cSubmit As Byte = 4, cCancelSubmit As Byte = 5, cApprove As Byte = 6, cCancelApprove As Byte = 7,
       cSep2 As Byte = 8, cSetPaymentDate As Byte = 9, cDeletePaymentDate As Byte = 10, cSetTaxInvoiceNumber As Byte = 11,
       cSep3 As Byte = 12, cExportExcel As Byte = 13, cSep4 As Byte = 14, cRefresh As Byte = 15, cClose As Byte = 16

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "Pick", "Pilih", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ProgramName", "Program", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyName", "Perusahaan", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ID", "Nomor", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ARNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ARDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "DueDateValue", "Jatuh Tempo", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "DueDate", "Tanggal Jatuh Tempo", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "BPCode", "Kode Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPName", "Nama Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CoAIDOfIncomePayment", "ID Akun", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CoACodeOfIncomePayment", "Kode Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CoANameOfIncomePayment", "Nama Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Modules", "Modules", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ReferencesID", "No. Referensi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TotalAmount", "Total Bayar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PaymentBy", "Dibayar Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PaymentDate", "Tanggal Bayar", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "TaxInvoiceNumber", "No. Faktur Pajak", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitBy", "Disubmit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitDate", "Tanggal Disubmit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ApprovedBy", "Diapprove Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ApproveL1", "ApproveL1", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ApprovedDate", "Tanggal Approve", 100, UI.usDefGrid.gFullDate)
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
            .Item(cApprove).Enabled = bolEnable
            .Item(cCancelApprove).Enabled = bolEnable
            .Item(cSetPaymentDate).Enabled = bolEnable
            .Item(cDeletePaymentDate).Enabled = bolEnable
            .Item(cSetTaxInvoiceNumber).Enabled = bolEnable
            .Item(cExportExcel).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtData As DataTable = BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionAccountReceivableBalance)
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
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvSetButton()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvDefaultFilter()
        intCompanyID = ERPSLib.UI.usUserApp.CompanyID
        txtCompanyName.Text = ERPSLib.UI.usUserApp.CompanyName
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Try
            dtData = BL.AccountReceivable.ListData(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, cboStatus.SelectedValue, strModules)
            grdMain.DataSource = dtData
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
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("ARNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "ARNumber", strSearch)
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

    Private Function prvGetData() As VO.AccountReceivable
        Dim clsReturn As New VO.AccountReceivable
        clsReturn.ProgramID = grdView.GetRowCellValue(intPos, "ProgramID")
        clsReturn.ProgramName = grdView.GetRowCellValue(intPos, "ProgramName")
        clsReturn.CompanyID = grdView.GetRowCellValue(intPos, "CompanyID")
        clsReturn.CompanyName = grdView.GetRowCellValue(intPos, "CompanyName")
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.ARNumber = grdView.GetRowCellValue(intPos, "ARNumber")
        clsReturn.ARDate = grdView.GetRowCellValue(intPos, "ARDate")
        clsReturn.BPID = grdView.GetRowCellValue(intPos, "BPID")
        clsReturn.BPCode = grdView.GetRowCellValue(intPos, "BPCode")
        clsReturn.BPName = grdView.GetRowCellValue(intPos, "BPName")
        clsReturn.CoAIDOfIncomePayment = grdView.GetRowCellValue(intPos, "CoAIDOfIncomePayment")
        clsReturn.CoACodeOfIncomePayment = grdView.GetRowCellValue(intPos, "CoACodeOfIncomePayment")
        clsReturn.CoANameOfIncomePayment = grdView.GetRowCellValue(intPos, "CoANameOfIncomePayment")
        clsReturn.Modules = grdView.GetRowCellValue(intPos, "Modules")
        clsReturn.ReferencesID = grdView.GetRowCellValue(intPos, "ReferencesID")
        clsReturn.TotalAmount = grdView.GetRowCellValue(intPos, "TotalAmount")
        clsReturn.TaxInvoiceNumber = grdView.GetRowCellValue(intPos, "TaxInvoiceNumber")
        Return clsReturn
    End Function

    Private Sub prvNew()
        prvResetProgressBar()
        Dim frmDetail As New frmTraAccountReceivableDet
        With frmDetail
            .pubIsNew = True
            .pubCS = prvGetCS()
            .pubModules = strModules
            .Text = Me.Text
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        prvResetProgressBar()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraAccountReceivableDet
        With frmDetail
            .pubIsNew = False
            .pubCS = prvGetCS()
            .pubID = clsData.ID
            .pubModules = strModules
            .Text = Me.Text
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        If Not UI.usForm.frmAskQuestion("Hapus Nomor " & clsData.ARNumber & "?") Then Exit Sub

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
            BL.AccountReceivable.DeleteData(clsData.ID, clsData.Modules, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
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
        If Not UI.usForm.frmAskQuestion("Submit Nomor " & clsData.ARNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Application.DoEvents()
        Try
            BL.AccountReceivable.Submit(clsData.ID, "")
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
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
        If Not UI.usForm.frmAskQuestion("Batal Submit Nomor " & clsData.ARNumber & "?") Then Exit Sub

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
            BL.AccountReceivable.Unsubmit(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Batal submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvApprove()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Approve Nomor " & clsData.ARNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Application.DoEvents()
        Try
            BL.AccountReceivable.Approve(clsData.ID, "")
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvCancelApprove()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Batal Approve Nomor " & clsData.ARNumber & "?") Then Exit Sub

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
            BL.AccountReceivable.Unapprove(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Batal approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSetupPaymentDate()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        Dim frmDetail As New frmTraAccountSetPaymentDate
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.PaymentDate = .pubPaymentDate
                clsData.PaymentBy = ERPSLib.UI.usUserApp.UserID
                clsData.Remarks = .pubRemarks
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Application.DoEvents()
        Try
            BL.AccountReceivable.SetupPayment(clsData.ID, clsData.PaymentDate, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Setup tanggal pembayaran berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSetupCancelPaymentDate()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        If Not UI.usForm.frmAskQuestion("Hapus Tanggal Pembayaran Nomor " & clsData.ARNumber & "?") Then Exit Sub

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
            BL.AccountReceivable.SetupCancelPayment(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Hapus tanggal pembayaran berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSetupTaxInvoiceNumber()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        Dim frmDetail As New frmTraAccountSetTaxInvoiceNumber
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.TaxInvoiceNumber = .pubTaxInvoiceNumber
                clsData.Remarks = .pubRemarks
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Application.DoEvents()
        Try
            BL.AccountReceivable.UpdateTaxInvoiceNumber(clsData.ID, clsData.TaxInvoiceNumber, clsData.Remarks)
            pgMain.Value = 100
            Application.DoEvents()
            UI.usForm.frmMessageBox("Update nomor faktur pajak berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ARNumber"))
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
        Dim SumTotalAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "Total Bayar: {0:#,##0.00}")
        If grdView.Columns("TotalAmount").SummaryText.Trim = "" Then
            grdView.Columns("TotalAmount").Summary.Add(SumTotalAmount)
        End If
    End Sub

    Private Sub prvUserAccess()
        Dim intModules As Integer = VO.Common.GetModuleID(strModules)
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.DeleteAccess)
            .Item(cSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.SubmitAccess)
            .Item(cCancelSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.CancelSubmitAccess)
            .Item(cApprove).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.ApproveAccess)
            .Item(cCancelApprove).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.CancelApproveAccess)
            .Item(cSetPaymentDate).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.PaymentAccess)
            .Item(cDeletePaymentDate).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.CancelPaymentAccess)
            .Item(cSetTaxInvoiceNumber).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.TaxInvoiceNumberAccess)
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraAccountReceivable_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraAccountReceivable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.Text = VO.Common.GetPaymentText(strModules)
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
                Case ToolBar.Buttons(cApprove).Name : prvApprove()
                Case ToolBar.Buttons(cCancelApprove).Name : prvCancelApprove()
                Case ToolBar.Buttons(cSetPaymentDate).Name : prvSetupPaymentDate()
                Case ToolBar.Buttons(cDeletePaymentDate).Name : prvSetupCancelPaymentDate()
                Case ToolBar.Buttons(cSetTaxInvoiceNumber).Name : prvSetupTaxInvoiceNumber()
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