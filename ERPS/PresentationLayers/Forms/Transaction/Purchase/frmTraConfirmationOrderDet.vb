Imports DevExpress.XtraGrid
Public Class frmTraConfirmationOrderDet

#Region "Property"

    Private frmParent As frmTraConfirmationOrder
    Private clsData As New VO.ConfirmationOrder
    Private intBPID As Integer = 0
    Private dtItem As New DataTable
    Private dtPaymentTerm As New DataTable
    Private intPos As Integer = 0
    Private strCOID As String = ""
    Private strPCID As String = ""
    Property pubID As String = ""
    Property pubIsNew As Boolean = False
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, cSep As Byte = 2, cGenerateContract As Byte = 3,
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
        Application.DoEvents()
    End Sub

    Private Sub prvSetGrid()
        '# Detail
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "COID", "COID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PONumber", "Nomor Pesanan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "PODetailID", "PODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "DeliveryAddress", "Alamat Pengiriman", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
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
        UI.usForm.SetGrid(grdItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "PCQuantity", "PCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "PCWeight", "PCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "DCQuantity", "DCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "DCWeight", "DCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        grdItemView.Columns("OrderNumberSupplier").GroupIndex = 0

        '# PO Payment Term
        UI.usForm.SetGrid(grdPaymentTermView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdPaymentTermView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdPaymentTermView, "Percentage", "Percentage", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdPaymentTermView, "PaymentTypeID", "PaymentTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdPaymentTermView, "PaymentTypeCode", "Jenis Pembayaran [Kode]", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPaymentTermView, "PaymentTypeName", "Jenis Pembayaran [Nama]", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPaymentTermView, "PaymentModeID", "PaymentModeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdPaymentTermView, "PaymentModeCode", "Metode Pembayaran [Kode]", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPaymentTermView, "PaymentModeName", "Metode Pembayaran [Nama]", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPaymentTermView, "CreditTerm", "CreditTerm", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdPaymentTermView, "Remarks", "Remarks", 100, UI.usDefGrid.gString)

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "OrderRequestID", "OrderRequestID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionConfirmationOrder), "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvFillForm()
        pgMain.Value = 30
        Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        prvFillCombo()
        Try
            If pubIsNew Then
                prvClear()
            Else
                clsData = New VO.ConfirmationOrder
                clsData = BL.ConfirmationOrder.GetDetail(pubID)
                txtCONumber.Text = clsData.CONumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                dtpCODate.Value = clsData.CODate
                dtpDeliveryPeriodFrom.Value = clsData.DeliveryPeriodFrom
                dtpDeliveryPeriodTo.Value = clsData.DeliveryPeriodTo
                txtAllowanceProduction.Value = clsData.AllowanceProduction
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                strPCID = clsData.PCID
                txtPCNumber.Text = clsData.PCNumber
                txtFranco.Text = clsData.Franco
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                dtpCODate.Enabled = False
                txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
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
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf Format(dtpDeliveryPeriodFrom.Value, "yyyyMM") > Format(dtpDeliveryPeriodTo.Value, "yyyyMM") Then
            UI.usForm.frmMessageBox("Periode pengiriman tidak valid")
            tcHeader.SelectedTab = tpMain
            dtpDeliveryPeriodFrom.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpItem
            grdItemView.Focus()
            Exit Sub
        ElseIf grdPaymentTermView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Syarat pembayaran kosong. Mohon untuk diinput syarat pembayaran terlebih dahulu")
            tcHeader.SelectedTab = tpPaymentTerm
            grdPaymentTermView.Focus()
            Exit Sub
        ElseIf grdPaymentTermView.Columns("Percentage").SummaryItem.SummaryValue <> 100 Then
            UI.usForm.frmMessageBox("Total persentase syarat pembayaran harus 100%")
            tcHeader.SelectedTab = tpPaymentTerm
            grdPaymentTermView.Focus()
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
        Application.DoEvents()

        Dim listDetail As New List(Of VO.ConfirmationOrderDet)
        For Each dr As DataRow In dtItem.Rows
            listDetail.Add(New ERPSLib.VO.ConfirmationOrderDet With
                                {
                                    .PODetailID = dr.Item("PODetailID"),
                                    .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                                    .DeliveryAddress = dr.Item("DeliveryAddress"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks")
                                })
        Next

        Dim listPaymentTerm As New List(Of VO.ConfirmationOrderPaymentTerm)
        For Each dr As DataRow In dtPaymentTerm.Rows
            listPaymentTerm.Add(New VO.ConfirmationOrderPaymentTerm With
                                {
                                    .Percentage = dr.Item("Percentage"),
                                    .PaymentTypeID = dr.Item("PaymentTypeID"),
                                    .PaymentModeID = dr.Item("PaymentModeID"),
                                    .CreditTerm = dr.Item("CreditTerm"),
                                    .Remarks = dr.Item("Remarks")
                                })
        Next

        clsData = New VO.ConfirmationOrder
        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.CONumber = txtCONumber.Text.Trim
        clsData.CODate = dtpCODate.Value.Date
        clsData.BPID = intBPID
        clsData.AllowanceProduction = txtAllowanceProduction.Value
        clsData.DeliveryPeriodFrom = dtpDeliveryPeriodFrom.Value.Date
        clsData.DeliveryPeriodTo = dtpDeliveryPeriodTo.Value.Date
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
        clsData.Detail = listDetail
        clsData.PaymentTerm = listPaymentTerm
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave

        pgMain.Value = 60
        Application.DoEvents()

        Try
            Dim strCONumber As String = BL.ConfirmationOrder.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strCONumber)
            pgMain.Value = 80
            Application.DoEvents()
            frmParent.pubRefresh(strCONumber)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryHistory()
                prvQueryPaymentTerm()
                prvSetupTools()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvClear()
        txtBPCode.Focus()
        tcHeader.SelectedTab = tpMain
        pubID = ""
        txtCONumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        dtpCODate.Value = Now
        txtAllowanceProduction.Value = 0
        dtpDeliveryPeriodFrom.Value = Now
        dtpDeliveryPeriodTo.Value = Now
        txtPPN.Value = 0
        txtPPH.Value = 0
        txtTotalDPP.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtGrandTotal.Value = 0
        txtRemarks.Text = ""
        strPCID = ""
        txtPCNumber.Text = ""
        txtFranco.Text = ""
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
                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Payment Term
        Dim SumTotalPercentagePayment As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Percentage", "Total: {0:#,##0.00}")

        If grdPaymentTermView.Columns("Percentage").SummaryText.Trim = "" Then
            grdPaymentTermView.Columns("Percentage").Summary.Add(SumTotalPercentagePayment)
        End If

        '# Item
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

        If grdItemView.GroupCount > 0 Then grdItemView.ExpandAllGroups()
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
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionConfirmationOrder, IIf(pubIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

    Private Sub prvSetupTools()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, True, False)
        btnBP.Enabled = bolEnabled
        If clsData.StatusID <> VO.Status.Values.Submit Then
            ToolBar.Buttons.Item(cGenerateContract).Enabled = False
        Else
            ToolBar.Buttons.Item(cGenerateContract).Enabled = IIf(txtPCNumber.Text.Trim = "", True, False)
        End If
    End Sub

    Private Sub prvGenerateContract()
        If clsData.StatusID <> VO.Status.Values.Submit Then
            UI.usForm.frmMessageBox("Data harus di Submit terlebih dahulu.")
            Exit Sub
        End If

        Dim frmDetail As New frmTraConfirmationOrderGenerateContract
        With frmDetail
            .pubCOID = pubID
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            If .pubIsSave Then
                prvFillForm()
            End If
        End With
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarItem
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()
        Try
            dtItem = BL.ConfirmationOrder.ListDataDetail(pubID.Trim)
            grdItem.DataSource = dtItem
            prvSumGrid()
            grdItemView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvSetButtonItem()
            prvSetupTools()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvAddItem()
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pemasok terlebih dahulu")
            txtBPCode.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraConfirmationOrderDetItem
        With frmDetail
            .pubIsNew = True
            .pubBPID = intBPID
            .pubTableParentItem = dtItem
            .pubCS = pubCS
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
        Dim frmDetail As New frmTraConfirmationOrderDetItem
        With frmDetail
            .pubIsNew = False
            .pubBPID = intBPID
            .pubOrderNumberSupplier = grdItemView.GetRowCellValue(intPos, "OrderNumberSupplier")
            .pubTableParentItem = dtItem
            .pubCS = pubCS
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

#Region "Payment Term Handle"

    Private Sub prvSetButtonPaymentTerm()
        Dim bolEnabled As Boolean = IIf(grdPaymentTermView.RowCount = 0, False, True)
        With ToolBarPaymentTerm
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryPaymentTerm()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()
        Try
            dtPaymentTerm = BL.ConfirmationOrder.ListDataPaymentTerm(pubID.Trim)
            grdPaymentTerm.DataSource = dtPaymentTerm
            prvSumGrid()
            grdPaymentTermView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvSetButtonPaymentTerm()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvAddPaymentTerm()
        Dim frmDetail As New usFormPaymentTerm
        With frmDetail
            .pubDataParent = dtPaymentTerm
            .pubIsNew = True
            .pubID = ""
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog(Me)
            prvSetButtonPaymentTerm()
        End With
    End Sub

    Private Sub prvEditPaymentTerm()
        intPos = grdPaymentTermView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New usFormPaymentTerm
        With frmDetail
            .pubDataParent = dtPaymentTerm
            .pubIsNew = False
            .pubID = grdPaymentTermView.GetRowCellValue(intPos, "ID")
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub prvDeletePaymentTerm()
        intPos = grdPaymentTermView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdPaymentTermView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtPaymentTerm.Rows
            If dr.Item("ID") = strID Then
                dr.Delete()
            End If
        Next
        dtPaymentTerm.AcceptChanges()
        prvSetButtonPaymentTerm()
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()
        Try
            grdStatus.DataSource = BL.ConfirmationOrder.ListDataStatus(pubID.Trim)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraConfirmationOrderDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpAmount
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpPaymentTerm
        ElseIf e.KeyCode = Keys.F4 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.F5 Then
            tcDetail.SelectedTab = tpItem
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraConfirmationOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItem.SetIcon(Me)
        ToolBarPaymentTerm.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryPaymentTerm()
        prvQueryHistory()
        prvUserAccess()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
            Case "Generate Kontrak" : prvGenerateContract()
        End Select
    End Sub

    Private Sub ToolBarItem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItem.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItem()
            Case "Edit" : prvEditItem()
            Case "Hapus" : prvDeleteItem()
        End Select
    End Sub

    Private Sub ToolBarPaymentTerm_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarPaymentTerm.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddPaymentTerm()
            Case "Edit" : prvEditPaymentTerm()
            Case "Hapus" : prvDeletePaymentTerm()
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