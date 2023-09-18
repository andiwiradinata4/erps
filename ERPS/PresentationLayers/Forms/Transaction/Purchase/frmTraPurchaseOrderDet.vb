Imports DevExpress.XtraGrid
Public Class frmTraPurchaseOrderDet

#Region "Property"

    Private frmParent As frmTraPurchaseOrder
    Private clsData As VO.PurchaseOrder
    Private intBPID As Integer = 0
    Private dtItemRequest As New DataTable
    Private dtItemOrder As New DataTable
    Private intPos As Integer = 0
    Private strOrderRequestID As String = ""
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
        '# PO Detail Internal
        UI.usForm.SetGrid(grdItemRequestView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemRequestView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemRequestView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemRequestView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemRequestView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemRequestView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemRequestView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemRequestView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemRequestView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemRequestView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemRequestView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemRequestView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemRequestView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemRequestView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemRequestView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemRequestView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemRequestView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemRequestView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemRequestView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemRequestView, "CuttingPrice", "Harga Cutting", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemRequestView, "TransportPrice", "Harga Transport", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemRequestView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemRequestView, "SalesContractQuantity", "SalesContractQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemRequestView, "SalesContractWeight", "SalesContractWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemRequestView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

        '# PO Detail
        UI.usForm.SetGrid(grdItemOrderView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemOrderView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemOrderView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemOrderView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemOrderView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemOrderView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemOrderView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemOrderView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemOrderView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemOrderView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemOrderView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemOrderView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemOrderView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemOrderView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemOrderView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemOrderView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemOrderView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemOrderView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemOrderView, "CuttingPrice", "Harga Cutting", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemOrderView, "TransportPrice", "Harga Transport", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemOrderView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemOrderView, "CuttingQuantity", "CuttingQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemOrderView, "CuttingWeight", "CuttingWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemOrderView, "TransportQuantity", "TransportQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemOrderView, "TransportWeight", "TransportWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemOrderView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

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
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionOrderRequest), "StatusID", "StatusName")
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
                clsData = New VO.PurchaseOrder
                clsData = BL.PurchaseOrder.GetDetail(pubID)
                txtPONumber.Text = clsData.PONumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                dtpPODate.Value = clsData.PODate
                strOrderRequestID = clsData.OrderRequestID
                txtOrderNumber.Text = clsData.OrderNumber

                txtPersonInCharge.Text = clsData.PersonInCharge
                dtpDeliveryPeriodFrom.Value = clsData.DeliveryPeriodFrom
                dtpDeliveryPeriodTo.Value = clsData.DeliveryPeriodTo
                txtDeliveryAddress.Text = clsData.DeliveryAddress
                txtValidity.Text = clsData.Validity
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtTotalDPPOrder.Value = clsData.TotalDPP
                txtTotalPPNOrder.Value = clsData.TotalPPN
                txtTotalPPHOrder.Value = clsData.TotalPPH
                txtTotalDPPRequest.Value = clsData.TotalInternalDPP
                txtTotalPPNRequest.Value = clsData.TotalInternalPPN
                txtTotalPPHRequest.Value = clsData.TotalInternalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                dtpPODate.Enabled = False
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
        ElseIf txtOrderNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih nomor permintaan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtOrderNumber.Focus()
            Exit Sub
        ElseIf txtPersonInCharge.Text.Trim = "" Then
            UI.usForm.frmMessageBox("PIC tidak boleh kosong")
            tcHeader.SelectedTab = tpMain
            txtPersonInCharge.Focus()
            Exit Sub
        ElseIf dtpDeliveryPeriodFrom.Value.Month > dtpDeliveryPeriodTo.Value.Month Then
            UI.usForm.frmMessageBox("Periode pengiriman tidak valid")
            tcHeader.SelectedTab = tpMain
            dtpDeliveryPeriodFrom.Focus()
            Exit Sub
        ElseIf grdItemRequestView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item Permintaan kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpRequest
            grdItemRequestView.Focus()
            Exit Sub
        ElseIf grdItemOrderView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item Pesanan kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpOrder
            grdItemOrderView.Focus()
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

        Dim listDetailOrder As New List(Of VO.PurchaseOrderDet)
        For Each dr As DataRow In dtItemOrder.Rows
            listDetailOrder.Add(New ERPSLib.VO.PurchaseOrderDet With
                                {
                                    .ID = dr.Item("ID"),
                                    .POID = pubID,
                                    .OrderRequestDetailID = dr.Item("OrderRequestDetailID"),
                                    .GroupID = dr.Item("GroupID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .CuttingPrice = dr.Item("CuttingPrice"),
                                    .TransportPrice = dr.Item("TransportPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks")
                                })
        Next

        Dim listDetailRequest As New List(Of VO.PurchaseOrderDetInternal)
        For Each dr As DataRow In dtItemRequest.Rows
            listDetailRequest.Add(New ERPSLib.VO.PurchaseOrderDetInternal With
                                  {
                                      .ID = dr.Item("ID"),
                                      .POID = pubID,
                                      .OrderRequestDetailID = dr.Item("OrderRequestDetailID"),
                                      .GroupID = dr.Item("GroupID"),
                                      .ItemID = dr.Item("ItemID"),
                                      .Quantity = dr.Item("Quantity"),
                                      .Weight = dr.Item("Weight"),
                                      .TotalWeight = dr.Item("TotalWeight"),
                                      .UnitPrice = dr.Item("UnitPrice"),
                                      .CuttingPrice = dr.Item("CuttingPrice"),
                                      .TransportPrice = dr.Item("TransportPrice"),
                                      .TotalPrice = dr.Item("TotalPrice"),
                                      .Remarks = dr.Item("Remarks")
                                  })
        Next

        clsData = New VO.PurchaseOrder

        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.PONumber = txtPONumber.Text.Trim
        clsData.PODate = dtpPODate.Value.Date
        clsData.OrderRequestID = strOrderRequestID.Trim
        clsData.BPID = intBPID
        clsData.PersonInCharge = txtPersonInCharge.Text.Trim
        clsData.DeliveryPeriodFrom = dtpDeliveryPeriodFrom.Value.Date
        clsData.DeliveryPeriodTo = dtpDeliveryPeriodTo.Value.Date
        clsData.DeliveryAddress = txtDeliveryAddress.Text.Trim
        clsData.Validity = txtValidity.Text.Trim
        clsData.PPN = txtPPN.Value
        clsData.PPH = txtPPH.Value
        clsData.TotalQuantity = grdItemOrderView.Columns("Quantity").SummaryItem.SummaryValue
        clsData.TotalWeight = grdItemOrderView.Columns("TotalWeight").SummaryItem.SummaryValue
        clsData.TotalInternalQuantity = grdItemRequestView.Columns("Quantity").SummaryItem.SummaryValue
        clsData.TotalInternalWeight = grdItemRequestView.Columns("TotalWeight").SummaryItem.SummaryValue
        clsData.TotalDPP = txtTotalDPPOrder.Value
        clsData.TotalPPN = txtTotalPPNOrder.Value
        clsData.TotalPPH = txtTotalPPHOrder.Value
        clsData.RoundingManual = 0
        clsData.TotalInternalDPP = txtTotalDPPRequest.Value
        clsData.TotalInternalPPN = txtTotalPPNRequest.Value
        clsData.TotalInternalPPH = txtTotalPPHRequest.Value
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Detail = listDetailOrder
        clsData.DetailInternal = listDetailRequest
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave

        pgMain.Value = 60
        Application.DoEvents()

        Try
            Dim strPONumber As String = BL.PurchaseOrder.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strPONumber)
            pgMain.Value = 80
            Application.DoEvents()
            'frmParent.pubRefresh(strPONumber)
            If pubIsNew Then
                prvClear()
                prvQueryItemOrder()
                'prvQueryItemRequest()
                prvQueryHistory()
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
        tcHeader.SelectedTab = tpMain
        pubID = ""
        txtPONumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        dtpPODate.Value = Now
        strOrderRequestID = ""
        txtOrderNumber.Text = ""
        txtPersonInCharge.Text = ""
        dtpDeliveryPeriodFrom.Value = Now
        dtpDeliveryPeriodTo.Value = Now
        txtDeliveryAddress.Text = ""
        txtValidity.Text = ""
        txtPPN.Value = 0
        txtPPH.Value = 0
        txtTotalDPPOrder.Value = 0
        txtTotalPPNOrder.Value = 0
        txtTotalPPHOrder.Value = 0
        txtTotalDPPRequest.Value = 0
        txtTotalPPNRequest.Value = 0
        txtTotalPPHRequest.Value = 0
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
                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvSumGrid()

        '# Request | PO Detail Internal
        Dim SumTotalQuantityRequest As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeightRequest As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")

        If grdItemRequestView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemOrderView.Columns("Quantity").Summary.Add(SumTotalQuantityRequest)
        End If

        If grdItemRequestView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemOrderView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightRequest)
        End If

        '# Order | PO Detail
        Dim SumTotalQuantityOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeightOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")

        If grdItemOrderView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemOrderView.Columns("Quantity").Summary.Add(SumTotalQuantityOrder)
        End If

        If grdItemOrderView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemOrderView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightOrder)
        End If
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, IIf(pubIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

#Region "Item Request Handle"

    Private Sub prvSetButtonItemRequest()
        Dim bolEnabled As Boolean = IIf(grdItemOrderView.RowCount = 0, False, True)
        With ToolBarDetailOrder
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItemRequest()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()
        Try
            dtItemRequest = BL.PurchaseOrder.ListDataDetailInternal(pubID.Trim)
            grdItemOrder.DataSource = dtItemRequest
            prvSumGrid()
            grdItemRequestView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvSetButtonItemRequest()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvAddItemRequest()
        If txtOrderNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih No. Permintaan terlebih dahulu")
            txtOrderNumber.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraPurchaseOrderDetItem
        With frmDetail
            .pubTableParentOrder = dtItemOrder
            .pubTableParentRequest = dtItemRequest
            .pubIsNew = True
            .pubOrderRequestID = strOrderRequestID
            .pubID = ""
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemOrder()
        End With
    End Sub

    Private Sub prvEditItemRequest()
        intPos = grdItemRequestView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If txtOrderNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih No. Permintaan terlebih dahulu")
            txtOrderNumber.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraPurchaseOrderDetItem
        With frmDetail
            .pubTableParentOrder = dtItemOrder
            .pubTableParentRequest = dtItemRequest
            .pubIsNew = False
            .pubOrderRequestID = strOrderRequestID
            .pubSelectedRequest = grdItemRequestView.GetDataRow(intPos)
            .pubID = grdItemRequestView.GetRowCellValue(intPos, "ID")
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemOrder()
        End With
    End Sub

    Private Sub prvDeleteItemRequest()
        intPos = grdItemRequestView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim intGroupID As Integer = grdItemRequestView.GetRowCellValue(intPos, "GroupID")
        For Each dr As DataRow In dtItemRequest.Rows
            If dr.Item("GroupID") = intGroupID Then
                dr.Delete()
            End If
            If dr.Item("GroupID") > intGroupID Then
                dr.BeginEdit()
                dr.Item("GroupID") = dr.Item("GroupID") - 1
                dr.EndEdit()
            End If
        Next
        dtItemRequest.AcceptChanges()
        prvSetButtonItemOrder()
    End Sub

#End Region

#Region "Item Order Handle"

    Private Sub prvSetButtonItemOrder()
        Dim bolEnabled As Boolean = IIf(grdItemOrderView.RowCount = 0, False, True)
        With ToolBarDetailOrder
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItemOrder()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()
        Try
            dtItemOrder = BL.PurchaseOrder.ListDataDetail(pubID.Trim)
            grdItemOrder.DataSource = dtItemOrder
            prvSumGrid()
            grdItemOrderView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvSetButtonItemOrder()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvAddItem()
        Dim frmDetail As New frmTraOrderRequestDetItem
        With frmDetail
            .pubIsNew = True
            .pubTableParent = dtItemOrder
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemOrder()
        End With
    End Sub

    Private Sub prvEditItem()
        intPos = grdItemOrderView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraOrderRequestDetItem
        With frmDetail
            .pubIsNew = False
            .pubTableParent = dtItemOrder
            .pubDatRowSelected = grdItemOrderView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemOrder()
        End With
    End Sub

    Private Sub prvDeleteItem()
        intPos = grdItemOrderView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemOrderView.GetRowCellValue(intPos, "ID")
        For i As Integer = 0 To dtItemOrder.Rows.Count - 1
            If dtItemOrder.Rows(i).Item("ID") = strID Then
                dtItemOrder.Rows(i).Delete()
                Exit For
            End If
        Next
        dtItemOrder.AcceptChanges()
        grdItemOrder.DataSource = dtItemOrder
        prvSetButtonItemOrder()
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()
        Try
            grdStatus.DataSource = BL.PurchaseOrder.ListDataStatus(pubID.Trim)
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

    Private Sub frmTraPurchaseOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick

    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click

    End Sub

    Private Sub btnPermintaan_Click(sender As Object, e As EventArgs) Handles btnPermintaan.Click

    End Sub

    Private Sub ToolBarDetailRequest_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetailRequest.ButtonClick

    End Sub

    Private Sub ToolBarDetailOrder_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetailOrder.ButtonClick

    End Sub

    Private Sub ToolBarPaymentTerm_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarPaymentTerm.ButtonClick

    End Sub

#End Region

End Class