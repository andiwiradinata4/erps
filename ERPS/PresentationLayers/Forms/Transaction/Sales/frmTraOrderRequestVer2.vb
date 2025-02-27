Imports DevExpress.XtraGrid
Public Class frmTraOrderRequestVer2

#Region "Properties"

    Private intPos As Integer = 0
    Private clsData As New VO.OrderRequest
    Private intProgramID As Integer
    Private intCompanyID As Integer
    Private dtData As New DataTable
    Private bolIsStock As Boolean

    Public WriteOnly Property pubIsStock As Boolean
        Set(value As Boolean)
            bolIsStock = value
        End Set
    End Property

#End Region

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3, cSubmit As Byte = 4, cCancelSubmit As Byte = 5,
       cSep2 As Byte = 6, cDownPayment As Byte = 7, cReceive As Byte = 8, cSetupDelivery As Byte = 9, cCancelSetupDelivery As Byte = 10,
       cSep3 As Byte = 11, cMapConfirmationOrder As Byte = 12, cSep4 As Byte = 13, cExportExcel As Byte = 14, cSep5 As Byte = 15,
       cRefresh As Byte = 16, cClose As Byte = 17

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
        UI.usForm.SetGrid(grdView, "OrderNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "OrderDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "BPCode", "Kode Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPName", "Nama Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PIC", "PIC", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ReferencesNumber", "No. Referensi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TotalQuantity", "Total Quantity", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPN", "PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPH", "PPH", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPP", "Total DPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPN", "Total PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPH", "Total PPh", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "GrandTotal", "Grand Total", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "RoundingManual", "RoundingManual", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdView, "DPAmount", "Total Panjar", 100, UI.usDefGrid.gReal2Num, bolIsStock)
        UI.usForm.SetGrid(grdView, "ReceiveAmount", "Total Pelunasan", 100, UI.usDefGrid.gReal2Num, bolIsStock)
        UI.usForm.SetGrid(grdView, "OutstandingPayment", "Sisa Piutang", 100, UI.usDefGrid.gReal2Num, bolIsStock)
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
            .Item(cDownPayment).Enabled = bolEnable
            .Item(cReceive).Enabled = bolEnable
            .Item(cSetupDelivery).Enabled = bolEnable
            .Item(cCancelSetupDelivery).Enabled = bolEnable
            .Item(cMapConfirmationOrder).Enabled = bolEnable
            .Item(cExportExcel).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtData As DataTable = BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionOrderRequest)
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
            dtData = BL.OrderRequest.ListData(intProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, cboStatus.SelectedValue, bolIsStock)
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
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("OrderNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "OrderNumber", strSearch)
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

    Private Function prvGetData() As VO.OrderRequest
        Dim clsReturn As New VO.OrderRequest
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.ProgramID = grdView.GetRowCellValue(intPos, "ProgramID")
        clsReturn.ProgramName = grdView.GetRowCellValue(intPos, "ProgramName")
        clsReturn.CompanyID = grdView.GetRowCellValue(intPos, "CompanyID")
        clsReturn.CompanyName = grdView.GetRowCellValue(intPos, "CompanyName")
        clsReturn.BPID = grdView.GetRowCellValue(intPos, "BPID")
        clsReturn.BPCode = grdView.GetRowCellValue(intPos, "BPCode")
        clsReturn.BPName = grdView.GetRowCellValue(intPos, "BPName")
        clsReturn.OrderNumber = grdView.GetRowCellValue(intPos, "OrderNumber")
        clsReturn.OrderDate = grdView.GetRowCellValue(intPos, "OrderDate")
        clsReturn.ReferencesNumber = grdView.GetRowCellValue(intPos, "ReferencesNumber")
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
        clsReturn.DPAmount = grdView.GetRowCellValue(intPos, "DPAmount")
        clsReturn.ReceiveAmount = grdView.GetRowCellValue(intPos, "ReceiveAmount")
        Return clsReturn
    End Function

    Private Sub prvNew()
        prvResetProgressBar()
        Dim frmDetail As New frmTraOrderRequestDet
        With frmDetail
            .pubIsNew = True
            .pubCS = prvGetCS()
            .pubIsStock = bolIsStock
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        prvResetProgressBar()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraOrderRequestDet
        With frmDetail
            .pubIsNew = False
            .pubCS = prvGetCS()
            .pubID = clsData.ID
            .pubIsStock = bolIsStock
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Hapus Nomor " & clsData.OrderNumber & "?") Then Exit Sub

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
            BL.OrderRequest.DeleteData(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "OrderNumber"))
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
        If Not UI.usForm.frmAskQuestion("Submit Nomor " & clsData.OrderNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.OrderRequest.Submit(clsData.ID, "")
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "OrderNumber"))
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
        If Not UI.usForm.frmAskQuestion("Batal Submit Nomor " & clsData.OrderNumber & "?") Then Exit Sub

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
            BL.OrderRequest.Unsubmit(clsData.ID, clsData.Remarks)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Batal submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "OrderNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvDownPayment()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        If clsData.StatusID <> VO.Status.Values.Submit Then
            UI.usForm.frmMessageBox("Status Data harus disubmit terlebih dahulu")
            Exit Sub
        End If

        Dim frmDetail As New frmTraARAP
        With frmDetail
            .pubModules = VO.AccountReceivable.DownPaymentOrderRequest
            .pubARAPType = VO.ARAP.ARAPTypeValue.Sales
            .pubBPID = clsData.BPID
            .pubCS = prvGetCS()
            .pubReferencesID = clsData.ID
            .pubIsUseSubItem = False
            .pubPPNPercentage = clsData.PPN
            .pubPPHPercentage = clsData.PPH
            .ShowDialog()
        End With
    End Sub

    Private Sub prvReceivePayment()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        If clsData.StatusID <> VO.Status.Values.Submit Then
            UI.usForm.frmMessageBox("Status Data harus disubmit terlebih dahulu")
            Exit Sub
        End If

        Dim frmDetail As New frmTraARAP
        With frmDetail
            .pubModules = VO.AccountReceivable.ReceivePaymentOrderRequestVer2
            .pubARAPType = VO.ARAP.ARAPTypeValue.Sales
            .pubBPID = clsData.BPID
            .pubBPCode = clsData.BPCode
            .pubBPName = clsData.BPName
            .pubCS = prvGetCS()
            .pubReferencesID = clsData.ID
            .pubReferencesNumber = clsData.OrderNumber
            .pubPPNPercentage = clsData.PPN
            .pubPPHPercentage = clsData.PPH
            '.pubIsUseSubItem = clsData.IsUseSubItem
            .ShowDialog()
        End With
    End Sub

    Private Sub prvSetupDelivery(ByVal bolValue As Boolean)
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion(IIf(bolValue = False, "Batal ", "") & "Set Pengiriman Nomor " & clsData.OrderNumber & "?") Then Exit Sub

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
            BL.OrderRequest.SetupIsIgnoreValidationPayment(clsData.ID, bolValue, clsData.Remarks)
            pgMain.Value = 100
            UI.usForm.frmMessageBox(IIf(bolValue = False, "Batal ", "") & "Set Pengiriman Nomor berhasil.")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvMapConfirmationOrder()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraOrderRequestMapConfirmationOrder
        With frmDetail
            .pubID = clsData.ID
            .pubCS = prvGetCS()
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
        End With
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
        Dim SumDPAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DPAmount", "Total Panjar: {0:#,##0.00}")
        Dim SumReceiveAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ReceiveAmount", "Total Pembayaran: {0:#,##0.00}")
        Dim SumOutstandingPayment As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutstandingPayment", "Sisa Hutang: {0:#,##0.00}")
        Dim SumTotalDPP As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPP", "Total DPP: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPN", "Total PPN: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPH", "Total PPH: {0:#,##0.00}")
        Dim SumGrandTotal As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", "Grand Total: {0:#,##0.00}")

        If grdView.Columns("TotalQuantity").SummaryText.Trim = "" Then grdView.Columns("TotalQuantity").Summary.Add(SumTotalQuantity)
        If grdView.Columns("TotalWeight").SummaryText.Trim = "" Then grdView.Columns("TotalWeight").Summary.Add(SumTotalWeight)
        If grdView.Columns("DPAmount").SummaryText.Trim = "" Then grdView.Columns("DPAmount").Summary.Add(SumDPAmount)
        If grdView.Columns("ReceiveAmount").SummaryText.Trim = "" Then grdView.Columns("ReceiveAmount").Summary.Add(SumReceiveAmount)
        If grdView.Columns("OutstandingPayment").SummaryText.Trim = "" Then grdView.Columns("OutstandingPayment").Summary.Add(SumOutstandingPayment)
        If grdView.Columns("TotalDPP").SummaryText.Trim = "" Then grdView.Columns("TotalDPP").Summary.Add(SumTotalDPP)
        If grdView.Columns("TotalPPN").SummaryText.Trim = "" Then grdView.Columns("TotalPPN").Summary.Add(SumTotalPPN)
        If grdView.Columns("TotalPPH").SummaryText.Trim = "" Then grdView.Columns("TotalPPH").Summary.Add(SumTotalPPH)
        If grdView.Columns("GrandTotal").SummaryText.Trim = "" Then grdView.Columns("GrandTotal").Summary.Add(SumGrandTotal)

        grdView.BestFitColumns()
    End Sub

    Private Sub prvExportExcel()
        Dim dxExporter As New DX.usDXHelper
        dxExporter.DevExport(Me, grdMain, Me.Text, Me.Text, DX.usDxExportFormat.fXls, True, True, DX.usDXExportType.etDefault)
    End Sub

    Private Sub prvUserAccess()
        If ERPSLib.UI.usUserApp.IsSuperUser Then Exit Sub
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.DeleteAccess)
            .Item(cSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.SubmitAccess)
            .Item(cCancelSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.CancelSubmitAccess)
            .Item(cSetupDelivery).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.SetupDelivery)
            .Item(cCancelSetupDelivery).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.CancelSetupDelivery)
            .Item(cExportExcel).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.ExportExcelAccess)

            '.Item(cDownPayment).Visible = bolIsStock
            .Item(cReceive).Visible = bolIsStock
            If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.SetupDelivery) Then .Item(cSetupDelivery).Visible = bolIsStock
            If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.CancelSetupDelivery) Then .Item(cCancelSetupDelivery).Visible = bolIsStock
            If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.CancelSetupDelivery) Then .Item(cSep3).Visible = bolIsStock
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraOrderRequestVer2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraOrderRequestVer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If bolIsStock Then Me.Text += " [Stock] "
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
                Case ToolBar.Buttons(cDownPayment).Name : prvDownPayment()
                Case ToolBar.Buttons(cReceive).Name : prvReceivePayment()
                Case ToolBar.Buttons(cSetupDelivery).Name : prvSetupDelivery(True)
                Case ToolBar.Buttons(cCancelSetupDelivery).Name : prvSetupDelivery(False)
                Case ToolBar.Buttons(cMapConfirmationOrder).Name : prvMapConfirmationOrder()
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