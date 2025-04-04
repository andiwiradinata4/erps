﻿Imports DevExpress.XtraGrid
Public Class frmTraOrderRequestDet

#Region "Property"

    Private frmParent As Object
    Private clsData As VO.OrderRequest
    Private intBPID As Integer = 0
    Private dtItem As New DataTable
    Private intPos As Integer = 0
    Private bolIsStock As Boolean
    Private intCoAofStock As Integer = 0
    Property pubID As String = ""
    Property pubIsNew As Boolean = False
    Property pubCS As New VO.CS

    Public WriteOnly Property pubIsStock As Boolean
        Set(value As Boolean)
            bolIsStock = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cAddItem As Byte = 0, cEditItem As Byte = 1, cDeleteItem As Byte = 2, cSep1Item As Byte = 3, cChangeItem As Byte = 4,
       cChangeItemPriceAndQuantity As Byte = 5, cSep2Item As Byte = 6, cHistory As Byte = 7

    Private Sub prvSetTitleForm()
        If bolIsStock Then Me.Text += " [Stock]"
        If pubIsNew Then
            Me.Text += " [baru] "
        Else
            Me.Text += " [edit] "
        End If
    End Sub

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        '# Item
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderRequestID", "OrderRequestID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "No. Pesanan Pemasok", 100, UI.usDefGrid.gString, bolIsStock)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "IsIgnoreValidationPayment", "Set Pengiriman", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "OrderRequestID", "OrderRequestID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

        '# Sales Contract
        UI.usForm.SetGrid(grdSalesContractView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSalesContractView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSalesContractView, "ProgramName", "ProgramName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSalesContractView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSalesContractView, "CompanyName", "CompanyName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSalesContractView, "SCNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSalesContractView, "SCDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdSalesContractView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSalesContractView, "BPCode", "Kode Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSalesContractView, "BPName", "Nama Pelanggan", 100, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.TransactionSalesOrderRequest), "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvFillForm()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        prvFillCombo()
        Try
            If pubIsNew Then
                prvClear()
            Else
                clsData = New VO.OrderRequest
                clsData = BL.OrderRequest.GetDetail(pubID)
                txtOrderNumber.Text = clsData.OrderNumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                dtpOrderDate.Value = clsData.OrderDate
                txtReferencesNumber.Text = clsData.ReferencesNumber
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                bolIsStock = clsData.IsStock
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)
                txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
                intCoAofStock = clsData.CoAofStock
                txtCoACodeOfStock.Text = clsData.CoACodeOfStock
                txtCoANameOfStock.Text = clsData.CoANameOfStock
                txtPersonInCharge.Text = clsData.PIC
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvGetDefaultCOAStock()
        Try
            Dim clsCOA As VO.ChartOfAccount = BL.ChartOfAccount.GetDetail(VO.ChartOfAccount.cStock)
            intCoAofStock = clsCOA.ID
            txtCoACodeOfStock.Text = clsCOA.Code
            txtCoANameOfStock.Text = clsCOA.Name
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            grdItemView.Focus()
            Exit Sub
        End If

        Dim frmDetail As New usFormSave
        Dim intSave As VO.Save.Action
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then intSave = .pubValue
            If intSave = VO.Save.Action.CancelSave Then Exit Sub
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Dim listDetail As New List(Of VO.OrderRequestDet)
        For Each dr As DataRow In dtItem.Rows
            listDetail.Add(New ERPSLib.VO.OrderRequestDet With
                           {
                               .ID = dr.Item("ID"),
                               .OrderRequestID = pubID,
                               .ItemID = dr.Item("ItemID"),
                               .Quantity = dr.Item("Quantity"),
                               .Weight = dr.Item("Weight"),
                               .TotalWeight = dr.Item("TotalWeight"),
                               .UnitPrice = dr.Item("UnitPrice"),
                               .TotalPrice = dr.Item("TotalPrice"),
                               .Remarks = dr.Item("Remarks"),
                               .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                               .UnitPriceHPP = dr.Item("UnitPriceHPP")
                           })
        Next

        clsData = New VO.OrderRequest
        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.BPID = intBPID
        clsData.OrderNumber = txtOrderNumber.Text.Trim
        clsData.OrderDate = dtpOrderDate.Value.Date
        clsData.ReferencesNumber = txtReferencesNumber.Text.Trim
        clsData.PPN = txtPPN.Value
        clsData.PPH = txtPPH.Value
        clsData.TotalQuantity = grdItemView.Columns("Quantity").SummaryItem.SummaryValue
        clsData.TotalWeight = grdItemView.Columns("TotalWeight").SummaryItem.SummaryValue
        clsData.TotalDPP = txtTotalDPP.Value
        clsData.TotalPPN = txtTotalPPN.Value
        clsData.TotalPPH = txtTotalPPH.Value
        clsData.RoundingManual = 0
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.IsStock = bolIsStock
        clsData.Detail = listDetail
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave
        clsData.CoAofStock = intCoAofStock
        clsData.PIC = txtPersonInCharge.Text.Trim
        pgMain.Value = 60
        Try
            Dim strOrderNumber As String = BL.OrderRequest.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strOrderNumber)
            pgMain.Value = 80
            frmParent.pubRefresh(strOrderNumber)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryHistory()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvClear()
        tcHeader.SelectedTab = tpMain
        pubID = ""
        txtOrderNumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        dtpOrderDate.Value = Now
        txtReferencesNumber.Text = ""
        txtPPN.Value = 0
        txtPPH.Value = 0
        txtTotalDPP.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtGrandTotal.Value = 0
        txtRemarks.Text = ""
        cboStatus.SelectedValue = VO.Status.Values.Draft
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
        txtPersonInCharge.Text = ""
    End Sub

    Private Sub prvChooseBP()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
                txtPPN.Value = .pubLUdtRow.Item("PPN")
                txtPPH.Value = .pubLUdtRow.Item("PPH")
                txtPersonInCharge.Text = .pubLUdtRow.Item("PICName")
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPrice As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdItemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
        End If

        If grdItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPrice)
        End If
    End Sub

    Public Sub prvCalculate()
        txtTotalDPP.Value = 0
        For Each dr As DataRow In dtItem.Rows
            txtTotalDPP.Value += dr.Item("TotalPrice")
        Next
        txtTotalPPN.Value = ERPSLib.SharedLib.Math.Round(txtTotalDPP.Value * (txtPPN.Value / 100), 2)
        txtTotalPPH.Value = ERPSLib.SharedLib.Math.Round(txtTotalDPP.Value * (txtPPH.Value / 100), 2)
        txtGrandTotal.Value = ERPSLib.SharedLib.Math.Round(txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value, 2)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesOrderRequest, IIf(pubIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
            .Buttons(cChangeItem).Enabled = IIf(pubIsNew, False, bolEnabled)
            .Buttons(cChangeItemPriceAndQuantity).Enabled = IIf(pubIsNew, False, bolEnabled)
            .Buttons(cHistory).Enabled = IIf(pubIsNew, False, bolEnabled)
        End With
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtItem = BL.OrderRequest.ListDataDetail(pubID.Trim)
            grdItem.DataSource = dtItem
            prvSumGrid()
            grdItemView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvSetButtonItem()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvAddItem()
        Dim frmDetail As New frmTraOrderRequestDetItem
        With frmDetail
            .pubIsNew = True
            .pubTableParent = dtItem
            .pubIsAutoSearch = True
            .pubIsStock = bolIsStock
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
        End With
    End Sub

    Private Sub prvEditItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraOrderRequestDetItem
        With frmDetail
            .pubIsNew = False
            .pubTableParent = dtItem
            .pubDatRowSelected = grdItemView.GetDataRow(intPos)
            .pubIsStock = bolIsStock
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
        End With
    End Sub

    Private Sub prvDeleteItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        For i As Integer = 0 To dtItem.Rows.Count - 1
            If dtItem.Rows(i).Item("ID") = strID Then
                dtItem.Rows(i).Delete()
                Exit For
            End If
        Next
        dtItem.AcceptChanges()
        grdItem.DataSource = dtItem
        prvSetButtonItem()
    End Sub

    Private Sub prvChangeItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        Dim frmDetail As New frmTraOrderRequestDetChangeItem
        With frmDetail
            .pubID = strID
            .pubDatRowSelected = grdItemView.GetDataRow(intPos)
            .pubIsStock = bolIsStock
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsSave Then prvQueryItem()
        End With
    End Sub

    Private Sub prvChangeItemPriceAndQuantity()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        Dim frmDetail As New frmTraOrderRequestDetItemChangePriceAndQuantity
        With frmDetail
            .pubID = strID
            .pubDatRowSelected = grdItemView.GetDataRow(intPos)
            .pubIsStock = bolIsStock
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsSave Then prvQueryItem() : prvFillForm()
        End With
    End Sub

    Private Sub prvHistoryItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Try
            Dim frmDetail As New frmViewLookupHistory
            With frmDetail
                .pubDtData = BL.OrderRequest.ListDataDetailHistorySCItem(grdItemView.GetRowCellValue(intPos, "ID"))
                .Text += " Kontrak Penjualan"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            grdStatus.DataSource = BL.OrderRequest.ListDataStatus(pubID.Trim)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

#End Region

#Region "Sales Contract Handle"

    Private Sub prvQuerySalesContract()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            grdSalesContract.DataSource = BL.SalesContract.ListDataByOrderRequestID(pubID.Trim)
            grdSalesContractView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraOrderRequestDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpPrice
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraOrderRequestDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryHistory()
        prvQuerySalesContract()
        prvUserAccess()

        '# For Handle IsStock
        lblCoAofStock.Visible = bolIsStock
        txtCoACodeOfStock.Visible = bolIsStock
        txtCoANameOfStock.Visible = bolIsStock
        btnCoAOfStock.Visible = bolIsStock
        If bolIsStock Then prvGetDefaultCOAStock()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarDetail_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItem()
            Case "Edit" : prvEditItem()
            Case "Hapus" : prvDeleteItem()
            Case "Ubah Barang" : prvChangeItem()
            Case "Ubah Harga dan Jumlah" : prvChangeItemPriceAndQuantity()
            Case "Histori" : prvHistoryItem()
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtPPN.ValueChanged, txtPPH.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class