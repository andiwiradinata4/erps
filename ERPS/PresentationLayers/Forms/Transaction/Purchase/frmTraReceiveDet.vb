﻿Imports DevExpress.XtraGrid
Public Class frmTraReceiveDet

#Region "Property"

    Private frmParent As frmTraReceive
    Private clsData As VO.Receive
    Private intBPID As Integer = 0
    Private strPCID As String = ""
    Private intCoAIDOfStock As Integer = 0
    Private dtItem As New DataTable
    Private dtPaymentTerm As New DataTable
    Private intPos As Integer = 0
    Private bolIsUseSubItem As Boolean
    Property pubID As String = ""
    Property pubIsNew As Boolean = False
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cAddItem As Byte = 0, cEditItem As Byte = 1, cDeleteItem As Byte = 2

    Private Sub prvSetTitleForm()
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
        '# Re Detail
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReceiveID", "ReceiveID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "PCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
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
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Weight", "Weight", 100, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "RoundingWeight", "RoundingWeight", 100, UI.usDefGrid.gReal4Num, False)

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "ReceiveID", "ReceiveID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.TransactionPurchaseReceive), "StatusID", "StatusName")
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
                clsData = New VO.Receive
                clsData = BL.Receive.GetDetail(pubID)
                txtReceiveNumber.Text = clsData.ReceiveNumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                strPCID = clsData.PCID
                txtPCNumber.Text = clsData.PCNumber
                dtpReceiveDate.Value = clsData.ReceiveDate
                intCoAIDOfStock = clsData.CoAofStock
                txtCoACodeOfStock.Text = clsData.CoACodeOfStock
                txtCoANameOfStock.Text = clsData.CoANameOfStock
                txtReferencesNumber.Text = clsData.ReferencesNumber
                txtPlatNumber.Text = clsData.PlatNumber
                txtDriver.Text = clsData.Driver
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                bolIsUseSubItem = clsData.IsUseSubItem
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)
                txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
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

    Private Sub prvSave()
        ToolBar.Focus()
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pemasok terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf txtPCNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih nomor kontrak terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtPCNumber.Focus()
            Exit Sub
        ElseIf txtCoACodeOfStock.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih akun persediaan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCoACodeOfStock.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpItem
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


        Dim listDetailOrder As New List(Of VO.ReceiveDet)
        For Each dr As DataRow In dtItem.Rows
            listDetailOrder.Add(New ERPSLib.VO.ReceiveDet With
                                {
                                    .PCDetailID = dr.Item("PCDetailID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks"),
                                    .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                                    .LevelItem = dr.Item("LevelItem"),
                                    .ParentID = dr.Item("ParentID")
                                })
        Next

        clsData = New VO.Receive
        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.ReceiveNumber = txtReceiveNumber.Text.Trim
        clsData.ReceiveDate = dtpReceiveDate.Value.Date
        clsData.BPID = intBPID
        clsData.PCID = strPCID
        clsData.PCNumber = txtPCNumber.Text.Trim
        clsData.CoAofStock = intCoAIDOfStock
        clsData.CoACodeOfStock = txtCoACodeOfStock.Text.Trim
        clsData.CoANameOfStock = txtCoANameOfStock.Text.Trim
        clsData.ReferencesNumber = txtReferencesNumber.Text.Trim
        clsData.PlatNumber = txtPlatNumber.Text.Trim
        clsData.Driver = txtDriver.Text.Trim
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
        clsData.IsUseSubItem = bolIsUseSubItem
        clsData.Detail = listDetailOrder
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave

        pgMain.Value = 60
        Try
            Dim strReceiveNumber As String = BL.Receive.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strReceiveNumber)
            pgMain.Value = 80

            frmParent.pubRefresh(strReceiveNumber)
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
        txtBPCode.Focus()
        tcHeader.SelectedTab = tpMain
        pubID = ""
        txtReceiveNumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        strPCID = ""
        txtPCNumber.Text = ""
        dtpReceiveDate.Value = Now
        intCoAIDOfStock = 0
        txtCoACodeOfStock.Text = ""
        txtCoANameOfStock.Text = ""
        txtReferencesNumber.Text = ""
        txtPlatNumber.Text = ""
        txtDriver.Text = ""
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
    End Sub

    Private Sub prvChooseBP()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If intBPID <> .pubLUdtRow.Item("ID") Then
                    strPCID = ""
                    txtPCNumber.Text = ""
                    prvClearItem()
                End If

                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvChooseContract()
        Dim frmDetail As New frmTraReceiveDetOutstandingContract
        With frmDetail
            .pubBPID = intBPID
            .pubCS = pubCS
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If strPCID.Trim <> .pubLUdtRow.Item("ID") Then
                    prvClearItem()
                    Dim clsPC As VO.PurchaseContract = BL.PurchaseContract.GetDetail(.pubLUdtRow.Item("ID"))
                    txtPPN.Value = clsPC.PPN
                    txtPPH.Value = clsPC.PPH
                End If
                strPCID = .pubLUdtRow.Item("ID")
                txtPCNumber.Text = .pubLUdtRow.Item("PCNumber")
                bolIsUseSubItem = .pubLUdtRow.Item("IsUseSubItem")
            End If
        End With
    End Sub

    Private Sub prvChooseCOA()
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = pubCS.CompanyID
            .pubProgramID = pubCS.ProgramID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.Stock
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDOfStock = .pubLUdtRow.Item("ID")
                txtCoACodeOfStock.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfStock.Text = .pubLUdtRow.Item("Name")
                txtReferencesNumber.Focus()
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Item
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
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

    Private Sub prvCalculate()
        txtTotalDPP.Value = 0
        For Each dr As DataRow In dtItem.Rows
            txtTotalDPP.Value += dr.Item("TotalPrice")
        Next
        txtTotalPPN.Value = txtTotalDPP.Value * (txtPPN.Value / 100)
        txtTotalPPH.Value = txtTotalDPP.Value * (txtPPH.Value / 100)
        txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchaseReceive, IIf(pubIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
    End Sub

    Private Sub prvSetupTools()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, True, False)
        btnBP.Enabled = bolEnabled
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarItem
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvClearItem()
        dtItem.Clear()
        dtItem.AcceptChanges()
        grdItem.DataSource = dtItem
        prvCalculate()
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Try
            dtItem = BL.Receive.ListDataDetail(pubID.Trim)
            grdItem.DataSource = dtItem
            prvSumGrid()
            grdItemView.BestFitColumns()
            prvSetupTools()
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
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Pemasok terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf txtPCNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Nomor Kontrak terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtPCNumber.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraReceiveDetItem
        With frmDetail
            .pubIsNew = True
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubPCID = strPCID
            .pubTableParentItem = dtItem
            .pubIsAutoSearch = True
            .pubIsUseSubItem = bolIsUseSubItem
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            prvSetupTools()
        End With
    End Sub

    Private Sub prvEditItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraReceiveDetItem
        With frmDetail
            .pubIsNew = False
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubPCID = strPCID
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .pubTableParentItem = dtItem
            .pubIsUseSubItem = bolIsUseSubItem
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            prvSetupTools()
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
        prvCalculate()
        prvSetButtonItem()
        prvSetupTools()
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            grdStatus.DataSource = BL.Receive.ListDataStatus(pubID.Trim)
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

    Private Sub frmTraReceiveDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpAmount
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.F4 Then
            tcDetail.SelectedTab = tpItem
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraReceiveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItem.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryHistory()
        prvUserAccess()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItem.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItem()
            Case "Edit" : prvEditItem()
            Case "Hapus" : prvDeleteItem()
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtPPN.ValueChanged, txtPPH.ValueChanged
        prvCalculate()
    End Sub

    Private Sub btnPurchaseContract_Click(sender As Object, e As EventArgs) Handles btnPurchaseContract.Click
        prvChooseContract()
    End Sub

    Private Sub btnCoAOfStock_Click(sender As Object, e As EventArgs) Handles btnCoAOfStock.Click
        prvChooseCOA()
    End Sub

#End Region

End Class