﻿Imports DevExpress.XtraGrid
Public Class frmTraPurchaseOrderTransportDet

#Region "Property"

    Enum ChooseBP
        Supplier
        Customer
    End Enum


    Private frmParent As frmTraPurchaseOrderTransport
    Private clsData As VO.PurchaseOrderTransport
    Private intBPID As Integer = 0
    Private intCustomerID As Integer = 0
    Private strSCID As String = ""
    Private dtItem As New DataTable
    Private dtPaymentTerm As New DataTable
    Private intPos As Integer = 0
    Property pubID As String = ""
    Property pubIsNew As Boolean = False
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, _
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
        '# PO Detail
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "SCDetailID", "SCDetailID", 100, UI.usDefGrid.gString, False)
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
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

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
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.TransactionPurchaseOrderTransport), "StatusID", "StatusName")
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
                clsData = New VO.PurchaseOrderTransport
                clsData = BL.PurchaseOrderTransport.GetDetail(pubID)
                txtPONumber.Text = clsData.PONumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                intCustomerID = clsData.CustomerID
                txtCustomerCode.Text = clsData.CustomerCode
                txtCustomerName.Text = clsData.CustomerName
                strSCID = clsData.SCID
                txtSCNumber.Text = clsData.SCNumber
                dtpPODate.Value = clsData.PODate
                txtPersonInCharge.Text = clsData.PersonInCharge
                dtpDeliveryPeriodFrom.Value = clsData.DeliveryPeriodFrom
                dtpDeliveryPeriodTo.Value = clsData.DeliveryPeriodTo
                txtDeliveryAddress.Text = clsData.DeliveryAddress
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                dtpPODate.Enabled = False
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
            UI.usForm.frmMessageBox("Pilih transporter terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf txtCustomerCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCustomerCode.Focus()
            Exit Sub
        ElseIf txtSCNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih No. Kontrak Penjualan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtSCNumber.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf txtPersonInCharge.Text.Trim = "" Then
            UI.usForm.frmMessageBox("PIC tidak boleh kosong")
            tcHeader.SelectedTab = tpMain
            txtPersonInCharge.Focus()
            Exit Sub
        ElseIf Format(dtpDeliveryPeriodFrom.Value, "yyyyMM") > Format(dtpDeliveryPeriodTo.Value, "yyyyMM") Then
            UI.usForm.frmMessageBox("Periode pengiriman tidak valid")
            tcHeader.SelectedTab = tpMain
            dtpDeliveryPeriodFrom.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item Pesanan kosong. Mohon untuk diinput item terlebih dahulu")
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
        

        Dim listDetail As New List(Of VO.PurchaseOrderTransportDet)
        For Each dr As DataRow In dtItem.Rows
            listDetail.Add(New ERPSLib.VO.PurchaseOrderTransportDet With
                                {
                                    .SCDetailID = dr.Item("SCDetailID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks")
                                })
        Next

        Dim listPaymentTerm As New List(Of VO.PurchaseOrderPaymentTerm)
        For Each dr As DataRow In dtPaymentTerm.Rows
            listPaymentTerm.Add(New VO.PurchaseOrderPaymentTerm With
                                {
                                    .Percentage = dr.Item("Percentage"),
                                    .PaymentTypeID = dr.Item("PaymentTypeID"),
                                    .PaymentModeID = dr.Item("PaymentModeID"),
                                    .CreditTerm = dr.Item("CreditTerm"),
                                    .Remarks = dr.Item("Remarks")
                                })
        Next

        clsData = New VO.PurchaseOrderTransport
        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.PONumber = txtPONumber.Text.Trim
        clsData.PODate = dtpPODate.Value.Date
        clsData.BPID = intBPID
        clsData.CustomerID = intCustomerID
        clsData.SCID = strSCID
        clsData.SCNumber = txtSCNumber.Text.Trim
        clsData.PersonInCharge = txtPersonInCharge.Text.Trim
        clsData.DeliveryPeriodFrom = dtpDeliveryPeriodFrom.Value.Date
        clsData.DeliveryPeriodTo = dtpDeliveryPeriodTo.Value.Date
        clsData.DeliveryAddress = txtDeliveryAddress.Text.Trim
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
        

        Try
            Dim strPONumber As String = BL.PurchaseOrderTransport.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strPONumber)
            pgMain.Value = 80
            
            frmParent.pubRefresh(strPONumber)
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
            
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvClear()
        txtBPCode.Focus()
        tcHeader.SelectedTab = tpMain
        pubID = ""
        txtPONumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        intCustomerID = 0
        txtCustomerCode.Text = ""
        txtCustomerName.Text = ""
        strSCID = ""
        txtSCNumber.Text = ""
        dtpPODate.Value = Now
        txtPersonInCharge.Text = ""
        dtpDeliveryPeriodFrom.Value = Now
        dtpDeliveryPeriodTo.Value = Now
        txtDeliveryAddress.Text = ""
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

    Private Sub prvChooseBP(ByVal enumchooseBP As ChooseBP)
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If enumchooseBP = ChooseBP.Supplier Then
                    intBPID = .pubLUdtRow.Item("ID")
                    txtBPCode.Text = .pubLUdtRow.Item("Code")
                    txtBPName.Text = .pubLUdtRow.Item("Name")
                ElseIf enumchooseBP = ChooseBP.Customer Then
                    If intCustomerID <> .pubLUdtRow.Item("ID") Then
                        strSCID = ""
                        txtSCNumber.Text = ""
                        prvClearItem()
                    End If

                    intCustomerID = .pubLUdtRow.Item("ID")
                    txtCustomerCode.Text = .pubLUdtRow.Item("Code")
                    txtCustomerName.Text = .pubLUdtRow.Item("Name")
                End If
            End If
        End With
    End Sub

    Private Sub prvChooseSC()
        Dim frmDetail As New frmTraSalesContractOutstandingPOTransport
        With frmDetail
            .pubCS = pubCS
            .pubBPID = intCustomerID
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookupGet Then
                If strSCID <> .pubLUdtRow.Item("ID") Then
                    prvClearItem()
                End If

                strSCID = .pubLUdtRow.Item("ID")
                txtSCNumber.Text = .pubLUdtRow.Item("SCNumber")
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Payment Term
        Dim SumTotalPercentagePayment As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Percentage", "Total: {0:#,##0.00}")

        If grdPaymentTermView.Columns("Percentage").SummaryText.Trim = "" Then
            grdPaymentTermView.Columns("Percentage").Summary.Add(SumTotalPercentagePayment)
        End If

        '# PO Detail
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
        txtTotalPPN.Value = txtTotalDPP.Value * (txtPPN.Value / 100)
        txtTotalPPH.Value = txtTotalDPP.Value * (txtPPH.Value / 100)
        txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchaseOrderTransport, IIf(pubIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
    End Sub

    Private Sub prvSetupTools()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, True, False)
        btnBP.Enabled = bolEnabled
        btnCustomer.Enabled = bolEnabled
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
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
            dtItem = BL.PurchaseOrderTransport.ListDataDetail(pubID.Trim)
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
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Pemasok terlebih dahulu")
            txtBPCode.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraPurchaseOrderTransportDetItem
        With frmDetail
            .pubIsNew = True
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubSCID = strSCID
            .pubTableParentItem = dtItem
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
        Dim frmDetail As New frmTraPurchaseOrderTransportDetItem
        With frmDetail
            .pubIsNew = False
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubSCID = strSCID
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .pubTableParentItem = dtItem
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
        
        Try
            dtPaymentTerm = BL.PurchaseOrder.ListDataPaymentTerm(pubID.Trim)
            grdPaymentTerm.DataSource = dtPaymentTerm
            prvSumGrid()
            grdPaymentTermView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            
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
        
        Try
            grdStatus.DataSource = BL.PurchaseOrder.ListDataStatus(pubID.Trim)
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

    Private Sub frmTraPurchaseOrderTransportDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmTraPurchaseOrderTransportDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
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
        End Select
    End Sub

    Private Sub ToolBarDetail_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
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
        prvChooseBP(ChooseBP.Supplier)
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        prvChooseBP(ChooseBP.Customer)
    End Sub

    Private Sub btnSC_Click(sender As Object, e As EventArgs) Handles btnSC.Click
        prvChooseSC()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtPPN.ValueChanged, txtPPH.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class