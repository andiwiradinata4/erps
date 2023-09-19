Imports DevExpress.XtraGrid
Public Class frmTraPurchaseOrderDetItem

#Region "Property"

    Private frmParent As frmTraPurchaseOrderDet
    Private dtOrder As New DataTable
    Private dtParentRequest As New DataTable
    Private dtParentOrder As New DataTable
    Private drSelectedRequest As DataRow
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private strOrderRequestID As String
    Private strOrderRequestDetailID As String
    Private strID As String = ""
    Private intPos As Integer = 0
    Private intGroupID As Integer = 0

    Public WriteOnly Property pubTableParentOrder As DataTable
        Set(value As DataTable)
            dtParentOrder = value
        End Set
    End Property

    Public WriteOnly Property pubTableParentRequest As DataTable
        Set(value As DataTable)
            dtParentRequest = value
        End Set
    End Property

    Public WriteOnly Property pubSelectedRequest As DataRow
        Set(value As DataRow)
            drSelectedRequest = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubOrderRequestID As String
        Set(value As String)
            strOrderRequestID = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cAdd As Byte = 0, cEdit As Byte = 1, cDelete As Byte = 2

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdItemOrderView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemOrderView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemOrderView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemOrderView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum, False)
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
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboItemType, BL.ItemType.ListDataForCombo, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, BL.ItemSpecification.ListDataForCombo, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            dtOrder = dtParentOrder.Clone
            Me.Cursor = Cursors.Default
            If Not bolIsNew Then
                strID = drSelectedRequest.Item("ID")
                strOrderRequestDetailID = drSelectedRequest.Item("OrderRequestDetailID")
                intGroupID = drSelectedRequest.Item("GroupID")
                intItemID = drSelectedRequest.Item("ItemID")
                cboItemType.SelectedValue = drSelectedRequest.Item("ItemTypeID")
                txtItemCode.Text = drSelectedRequest.Item("ItemCode")
                txtItemName.Text = drSelectedRequest.Item("ItemName")
                cboItemSpecification.SelectedValue = drSelectedRequest.Item("ItemSpecificationID")
                txtThick.Text = drSelectedRequest.Item("Thick")
                txtWidth.Text = drSelectedRequest.Item("Width")
                txtLength.Text = drSelectedRequest.Item("Length")
                txtWeight.Text = drSelectedRequest.Item("Weight")
                txtMaxTotalWeight.Value = drSelectedRequest.Item("MaxTotalWeight")
                txtUnitPrice.Value = drSelectedRequest.Item("UnitPrice")
                txtCuttingPrice.Value = drSelectedRequest.Item("CuttingPrice")
                txtTransportPrice.Value = drSelectedRequest.Item("TransportPrice")
                txtQuantity.Value = drSelectedRequest.Item("Quantity")
                txtRemarks.Text = drSelectedRequest.Item("Remarks")

                For Each dr As DataRow In dtParentOrder.Rows
                    If dr.Item("GroupID") = intGroupID Then
                        dtOrder.ImportRow(dr)
                    End If
                Next
                dtOrder.AcceptChanges()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvQuery()
        grdItemOrder.DataSource = dtOrder
        prvSumGrid()
        prvSetButtonItemOrder()
    End Sub

    Private Sub prvSumGrid()
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

    Private Sub prvSave()
        If txtItemCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih barang terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        ElseIf txtQuantity.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        ElseIf grdItemOrderView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Pilih pesanan pembelian terlebih dahulu")
            ToolBarItemOrder.Focus()
            Exit Sub
        End If

        '# Request Handle
        If bolIsNew Then
            intGroupID = dtParentRequest.Rows.Count + 1
            Dim drRequest As DataRow = dtParentRequest.NewRow
            With drRequest
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
                .Item("POID") = ""
                .Item("OrderRequestDetailID") = strOrderRequestDetailID
                .Item("GroupID") = intGroupID
                .Item("ItemID") = intItemID
                .Item("ItemCode") = txtItemCode.Text.Trim
                .Item("ItemName") = txtItemName.Text.Trim
                .Item("Thick") = txtThick.Text.Trim
                .Item("Width") = txtWidth.Text.Trim
                .Item("Length") = txtLength.Text.Trim
                .Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
                .Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
                .Item("ItemTypeID") = cboItemType.SelectedValue
                .Item("ItemTypeName") = cboItemType.Text.Trim
                .Item("Quantity") = txtQuantity.Value
                .Item("Weight") = txtWeight.Value
                .Item("TotalWeight") = txtTotalWeight.Value
                .Item("MaxTotalWeight") = txtMaxTotalWeight.Value
                .Item("UnitPrice") = txtUnitPrice.Value
                .Item("CuttingPrice") = txtCuttingPrice.Value
                .Item("TransportPrice") = txtTransportPrice.Value
                .Item("TotalPrice") = txtTotalPrice.Value
                .Item("SalesContractQuantity") = 0
                .Item("SalesContractWeight") = 0
                .Item("Remarks") = txtRemarks.Text.Trim
                .EndEdit()
            End With
            dtParentRequest.Rows.Add(drRequest)
        Else
            For Each dr As DataRow In dtParentRequest.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("ID") = Guid.NewGuid
                        .Item("POID") = ""
                        .Item("OrderRequestDetailID") = strOrderRequestDetailID
                        .Item("GroupID") = intGroupID
                        .Item("ItemID") = intItemID
                        .Item("ItemCode") = txtItemCode.Text.Trim
                        .Item("ItemName") = txtItemName.Text.Trim
                        .Item("Thick") = txtThick.Text.Trim
                        .Item("Width") = txtWidth.Text.Trim
                        .Item("Length") = txtLength.Text.Trim
                        .Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
                        .Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
                        .Item("ItemTypeID") = cboItemType.SelectedValue
                        .Item("ItemTypeName") = cboItemType.Text.Trim
                        .Item("Quantity") = txtQuantity.Value
                        .Item("Weight") = txtWeight.Value
                        .Item("TotalWeight") = txtTotalWeight.Value
                        .Item("MaxTotalWeight") = txtMaxTotalWeight.Value
                        .Item("UnitPrice") = txtUnitPrice.Value
                        .Item("CuttingPrice") = txtCuttingPrice.Value
                        .Item("TransportPrice") = txtTransportPrice.Value
                        .Item("TotalPrice") = txtTotalPrice.Value
                        .Item("SalesContractQuantity") = 0
                        .Item("SalesContractWeight") = 0
                        .Item("Remarks") = txtRemarks.Text.Trim
                        .EndEdit()
                    End If
                End With
            Next
        End If
        dtParentRequest.AcceptChanges()
        frmParent.grdItemRequestView.BestFitColumns()

        '# Order Handle
        For Each dr As DataRow In dtParentOrder.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtParentOrder.AcceptChanges()

        For Each dr As DataRow In dtOrder.Rows
            dr.BeginEdit()
            dr.Item("GroupID") = intGroupID
            dr.EndEdit()
            dtParentOrder.ImportRow(dr)
        Next
        dtParentOrder.AcceptChanges()
        frmParent.grdItemOrderView.BestFitColumns()
        Me.Close()
    End Sub

    Private Sub prvAddItemRequest()
        Dim frmDetail As New frmTraPurchaseOrderDetItemOutstanding
        With frmDetail
            .pubOrderRequestID = strOrderRequestID
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookUpGet Then
                strOrderRequestDetailID = .pubLUdtRow.Item("ID")
                strOrderRequestID = .pubLUdtRow.Item("OrderRequestID")
                intItemID = .pubLUdtRow.Item("ItemID")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtThick.Text = .pubLUdtRow.Item("Thick")
                txtWidth.Text = .pubLUdtRow.Item("Width")
                txtLength.Text = .pubLUdtRow.Item("Length")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtMaxTotalWeight.Value = .pubLUdtRow.Item("TotalWeight")
                txtUnitPrice.Focus()
                txtCuttingPrice.Value = 0
                txtTransportPrice.Value = 0
                txtQuantity.Value = 0
                txtRemarks.Text = ""
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtNettoPrice.Value = txtUnitPrice.Value - txtCuttingPrice.Value - txtTransportPrice.Value
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtNettoPrice.Value * txtTotalWeight.Value
    End Sub

#Region "Order Item"

    Private Sub prvSetButtonItemOrder()
        Dim bolEnabled As Boolean = IIf(grdItemOrderView.RowCount = 0, False, True)
        With ToolBarItemOrder
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvAddItemOrder()
        Dim frmDetail As New frmTraPurchaseOrderDetItemOrder
        With frmDetail
            .pubIsNew = True
            .pubOrderRequestID = strOrderRequestID
            .pubOrderRequestDetailID = strOrderRequestDetailID
            .pubCuttingPrice = txtCuttingPrice.Value
            .pubTransportPrice = txtTransportPrice.Value
            .pubTableParent = dtOrder
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemOrder()
        End With
    End Sub

    Private Sub prvEditItemOrder()
        intPos = grdItemOrderView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraPurchaseOrderDetItemOrder
        With frmDetail
            .pubIsNew = False
            .pubOrderRequestID = strOrderRequestID
            .pubOrderRequestDetailID = strOrderRequestDetailID
            .pubTableParent = dtOrder
            .pubDataRowSelected = grdItemOrderView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemOrder()
        End With
    End Sub

    Private Sub prvDeleteItemOrder()
        intPos = grdItemOrderView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemOrderView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtOrder.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtOrder.AcceptChanges()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraPurchaseOrderDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraPurchaseOrderDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItemOrder.SetIcon(Me)
        prvSetGrid()
        prvFillForm()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        'Select Case e.Button.Text.Trim
        '    Case "Simpan" : prvSave()
        '    Case "Tutup" : Me.Close()
        'End Select
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItemOrder_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemOrder.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItemOrder()
            Case "Edit" : prvEditItemOrder()
            Case "Hapus" : prvDeleteItemOrder()
        End Select
    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        prvAddItemRequest()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged,
        txtCuttingPrice.ValueChanged, txtTransportPrice.ValueChanged, txtQuantity.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class