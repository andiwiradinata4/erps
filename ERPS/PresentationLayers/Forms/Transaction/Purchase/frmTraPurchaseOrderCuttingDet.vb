﻿Imports DevExpress.XtraGrid
Public Class frmTraPurchaseOrderCuttingDet

#Region "Property"

    Private frmParent As frmTraPurchaseOrderCutting
    Private clsData As VO.PurchaseOrderCutting
    Private intBPID As Integer = 0
    Private dtItem As New DataTable
    Private dtItemResult As New DataTable
    Private dtPaymentTerm As New DataTable
    Private dtRemarksResult As New DataTable
    Private intPos As Integer = 0
    Private decTotalDPPRawMaterial As Decimal = 0
    Private intCustomerID As Integer
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
        UI.usForm.SetGrid(grdItemView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReceiveDetailID", "ReceiveDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "PCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
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
        UI.usForm.SetGrid(grdItemView, "UnitPriceRawMaterial", "Harga Barang", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPriceRawMaterial", "Total Harga Barang", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ResultID", "ResultID", 300, UI.usDefGrid.gString, False)

        '# PO Detail Result
        UI.usForm.SetGrid(grdItemResultView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemResultView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemResultView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "UnitPriceRawMaterial", "UnitPriceRawMaterial", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemResultView, "TotalPriceRawMaterial", "TotalPriceRawMaterial", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemResultView, "ResultID", "ResultID", 300, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "UnitPrice", "Unit Price", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemResultView, "TotalPrice", "Total Price", 100, UI.usDefGrid.gReal2Num, False)
        grdItemResultView.Columns("GroupID").GroupIndex = 0

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.TransactionPurchasePurchaseOrderCutting), "StatusID", "StatusName")
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
                clsData = New VO.PurchaseOrderCutting
                clsData = BL.PurchaseOrderCutting.GetDetail(pubID)
                txtPONumber.Text = clsData.PONumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                dtpPODate.Value = clsData.PODate
                txtPersonInCharge.Text = clsData.PersonInCharge
                dtpDeliveryPeriodFrom.EditValue = clsData.DeliveryPeriodFrom
                dtpDeliveryPeriodTo.EditValue = clsData.DeliveryPeriodTo
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
                txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
                chkIsClaimCustomer.Checked = clsData.IsClaimCustomer
                intCustomerID = clsData.CustomerID
                txtCustomerCode.Text = clsData.CustomerCode
                txtCustomerName.Text = clsData.CustomerName
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
            UI.usForm.frmMessageBox("Pilih Cutting Center terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf dtpDeliveryPeriodFrom.EditValue > dtpDeliveryPeriodTo.EditValue Then
            UI.usForm.frmMessageBox("Periode pengiriman tidak valid")
            tcHeader.SelectedTab = tpMain
            dtpDeliveryPeriodFrom.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item Pesanan kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpItem
            grdItemView.Focus()
            Exit Sub
        ElseIf grdItemResultView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item hasil kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpItemResult
            grdItemResultView.Focus()
            Exit Sub
        ElseIf txtCustomerCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCustomerCode.Focus()
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

        Dim listDetail As New List(Of VO.PurchaseOrderCuttingDet)
        decTotalDPPRawMaterial = 0
        For Each dr As DataRow In dtItem.Rows
            listDetail.Add(New ERPSLib.VO.PurchaseOrderCuttingDet With
                                {
                                    .PCDetailID = dr.Item("PCDetailID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks"),
                                    .UnitPriceRawMaterial = dr.Item("UnitPriceRawMaterial"),
                                    .TotalPriceRawMaterial = dr.Item("TotalPriceRawMaterial"),
                                    .GroupID = dr.Item("GroupID"),
                                    .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                                    .ReceiveDetailID = dr.Item("ReceiveDetailID"),
                                    .ResultID = dr.Item("ResultID"),
                                    .IsShowCoil = dr.Item("IsShowCoil")
                                })
            decTotalDPPRawMaterial += dr.Item("TotalPriceRawMaterial")
        Next

        Dim listDetailResult As New List(Of VO.PurchaseOrderCuttingDetResult)
        For Each dr As DataRow In dtItemResult.Rows
            listDetailResult.Add(New ERPSLib.VO.PurchaseOrderCuttingDetResult With
                                {
                                    .GroupID = dr.Item("GroupID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                                    .Remarks = dr.Item("Remarks"),
                                    .UnitPriceRawMaterial = dr.Item("UnitPriceRawMaterial"),
                                    .TotalPriceRawMaterial = dr.Item("TotalPriceRawMaterial"),
                                    .IsShowPrintOut = True,
                                    .ResultID = dr.Item("ResultID"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice")
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

        Dim listRemarksResult As New List(Of VO.PurchaseOrderRemarksResult)
        For Each dr As DataRow In dtRemarksResult.Rows
            listRemarksResult.Add(New VO.PurchaseOrderRemarksResult With
                                  {
                                      .GroupID = dr.Item("GroupID"),
                                      .Remarks = dr.Item("Remarks")
                                  })
        Next

        clsData = New VO.PurchaseOrderCutting
        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.PONumber = txtPONumber.Text.Trim
        clsData.PODate = dtpPODate.Value.Date
        clsData.BPID = intBPID
        clsData.PersonInCharge = txtPersonInCharge.Text.Trim
        clsData.DeliveryPeriodFrom = dtpDeliveryPeriodFrom.EditValue
        clsData.DeliveryPeriodTo = dtpDeliveryPeriodTo.EditValue
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
        clsData.TotalDPPRawMaterial = decTotalDPPRawMaterial
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Detail = listDetail
        clsData.DetailResult = listDetailResult
        clsData.PaymentTerm = listPaymentTerm
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave
        clsData.CustomerID = intCustomerID
        clsData.IsClaimCustomer = chkIsClaimCustomer.Checked
        clsData.RemarksResultItem = listRemarksResult

        pgMain.Value = 60
        Try
            Dim strPONumber As String = BL.PurchaseOrderCutting.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strPONumber)
            pgMain.Value = 80
            frmParent.pubRefresh(strPONumber)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryItemResult()
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
        txtPONumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        dtpPODate.Value = Now
        txtPersonInCharge.Text = ""
        dtpDeliveryPeriodFrom.EditValue = New DateTime(Now.Year, Now.Month, 1)
        dtpDeliveryPeriodTo.EditValue = New DateTime(Now.Year, Now.Month, 1)
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
        intCustomerID = 0
        txtCustomerCode.Text = ""
        txtCustomerName.Text = ""
        chkIsClaimCustomer.Checked = False
    End Sub

    Private Sub prvChooseBP()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If intBPID <> .pubLUdtRow.Item("ID") Then
                    txtPPN.Value = .pubLUdtRow.Item("PPN")
                    txtPPH.Value = .pubLUdtRow.Item("PPH")
                End If

                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvChooseCustomer()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCustomerID = .pubLUdtRow.Item("ID")
                txtCustomerCode.Text = .pubLUdtRow.Item("Code")
                txtCustomerName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
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

        '# PO Detail Result
        Dim SumTotalQuantityResult As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeightResult As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")

        If grdItemResultView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemResultView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdItemResultView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemResultView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
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
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchasePurchaseOrderCutting, IIf(pubIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtItem = BL.PurchaseOrderCutting.ListDataDetail(pubID.Trim)
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
            UI.usForm.frmMessageBox("Pilih Cutting Center terlebih dahulu")
            txtBPCode.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraPurchaseOrderCuttingDetItem
        With frmDetail
            .pubIsNew = True
            .pubCS = pubCS
            .pubTableItem = dtItem
            .pubTableItemResultParent = dtItemResult
            .pubTableItemRemarksResultParent = dtRemarksResult
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            grdItemResultView.ExpandAllGroups()
        End With
    End Sub

    Private Sub prvEditItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraPurchaseOrderCuttingDetItem
        With frmDetail
            .pubIsNew = False
            .pubCS = pubCS
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .pubTableItem = dtItem
            .pubTableItemResultParent = dtItemResult
            .pubTableItemRemarksResultParent = dtRemarksResult
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            grdItemResultView.ExpandAllGroups()
        End With
    End Sub

    Private Sub prvDeleteItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        Dim intGroupID As Integer = grdItemView.GetRowCellValue(intPos, "GroupID")
        For i As Integer = 0 To dtItem.Rows.Count - 1
            If dtItem.Rows(i).Item("ID") = strID Then
                dtItem.Rows(i).Delete()
                Exit For
            End If
        Next
        dtItem.AcceptChanges()
        prvCalculate()

        '# Delete Item Result
        For Each dr As DataRow In dtItemResult.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtItemResult.AcceptChanges()

        '# Update Group ID Item
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("GroupID") > intGroupID Then
                dr.BeginEdit()
                dr.Item("GroupID") = dr.Item("GroupID") - 1
                dr.EndEdit()
            End If
        Next
        dtItem.AcceptChanges()

        '# Update Group ID Result
        For Each dr As DataRow In dtItemResult.Rows
            If dr.Item("GroupID") > intGroupID Then
                dr.BeginEdit()
                dr.Item("GroupID") = dr.Item("GroupID") - 1
                dr.EndEdit()
            End If
        Next
        dtItemResult.AcceptChanges()

        '# Delete Item Result Remarks
        For Each dr As DataRow In dtRemarksResult.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtRemarksResult.AcceptChanges()

        '# Update Group ID Result
        For Each dr As DataRow In dtRemarksResult.Rows
            If dr.Item("GroupID") > intGroupID Then
                dr.BeginEdit()
                dr.Item("GroupID") = dr.Item("GroupID") - 1
                dr.EndEdit()
            End If
        Next
        dtRemarksResult.AcceptChanges()

        prvSetButtonItem()
        grdItemResultView.ExpandAllGroups()
    End Sub

#End Region

#Region "Item Result Handle"

    Private Sub prvQueryItemResult()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtItemResult = BL.PurchaseOrderCutting.ListDataDetailResult(pubID.Trim)
            grdItemResult.DataSource = dtItemResult
            prvSumGrid()
            grdItemResultView.BestFitColumns()
            grdItemResultView.ExpandAllGroups()
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

#End Region

#Region "Item Result Remarks Handle"

    Private Sub prvQueryItemResultRemarks()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtRemarksResult = BL.PurchaseOrderCutting.ListDataRemarksResult(pubID.Trim)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
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

    Private Sub frmTraPurchaseOrderCuttingCuttingDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpAmount
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.F4 Then
            tcDetail.SelectedTab = tpItem
        ElseIf e.KeyCode = Keys.F5 Then
            tcDetail.SelectedTab = tpItemResult
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraPurchaseOrderCuttingCuttingDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryItemResult()
        prvQueryItemResultRemarks()
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

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        prvChooseCustomer()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtPPN.ValueChanged, txtPPH.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class