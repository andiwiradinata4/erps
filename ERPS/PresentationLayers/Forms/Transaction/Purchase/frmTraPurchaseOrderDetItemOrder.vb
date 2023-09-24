Public Class frmTraPurchaseOrderDetItemOrder

#Region "Property"

    Private frmParent As frmTraPurchaseOrderDetItem
    Private dtParent As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private drSelected As DataRow
    Private strID As String = ""
    Private strOrderRequestID As String
    Private strOrderRequestDetailID As String
    Private decCuttingPrice As Decimal, decTransportPrice As Decimal

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubDataRowSelected As DataRow
        Set(value As DataRow)
            drSelected = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public WriteOnly Property pubOrderRequestID As String
        Set(value As String)
            strOrderRequestID = value
        End Set
    End Property

    Public WriteOnly Property pubOrderRequestDetailID As String
        Set(value As String)
            strOrderRequestDetailID = value
        End Set
    End Property

    Public WriteOnly Property pubCuttingPrice As Decimal
        Set(value As Decimal)
            decCuttingPrice = value
        End Set
    End Property

    Public WriteOnly Property pubTransportPrice As Decimal
        Set(value As Decimal)
            decTransportPrice = value
        End Set
    End Property

    Public WriteOnly Property pubTableParent As DataTable
        Set(value As DataTable)
            dtParent = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1

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
            Me.Cursor = Cursors.Default
            If bolIsNew Then
                prvClear()
            Else
                strID = drSelected.Item("ID")
                intItemID = drSelected.Item("ItemID")
                txtItemCode.Text = drSelected.Item("ItemCode")
                txtItemName.Text = drSelected.Item("ItemName")
                cboItemType.SelectedValue = drSelected.Item("ItemTypeID")
                cboItemSpecification.SelectedValue = drSelected.Item("ItemSpecificationID")
                txtThick.Value = drSelected.Item("Thick")
                txtWidth.Value = drSelected.Item("Width")
                txtLength.Value = drSelected.Item("Length")
                txtWeight.Value = drSelected.Item("Weight")
                txtUnitPrice.Value = drSelected.Item("UnitPrice")
                txtCuttingPrice.Value = drSelected.Item("CuttingPrice")
                txtTransportPrice.Value = drSelected.Item("TransportPrice")
                txtQuantity.Value = drSelected.Item("Quantity")
                txtRemarks.Text = drSelected.Item("Remarks")
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        txtCuttingPrice.Enabled = False
        txtTransportPrice.Enabled = False
    End Sub

    Private Sub prvSave()
        If txtItemCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih item terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        ElseIf cboItemType.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Jenis barang tidak valid")
            cboItemType.Focus()
            Exit Sub
        ElseIf cboItemSpecification.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Spesifikasi barang tidak valid")
            cboItemSpecification.Focus()
            Exit Sub
        ElseIf txtUnitPrice.Value <= 0 Then
            UI.usForm.frmMessageBox("Harga harus lebih besar dari 0")
            txtUnitPrice.Focus()
            Exit Sub
        ElseIf txtQuantity.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        End If

        If bolIsNew Then
            Dim dr As DataRow
            dr = dtParent.NewRow
            dr.BeginEdit()
            dr.Item("ID") = Guid.NewGuid
            dr.Item("POID") = ""
            dr.Item("OrderRequestDetailID") = strOrderRequestDetailID
            dr.Item("GroupID") = 0
            dr.Item("ItemID") = intItemID
            dr.Item("ItemCode") = txtItemCode.Text.Trim
            dr.Item("ItemName") = txtItemName.Text.Trim
            dr.Item("Thick") = txtThick.Value
            dr.Item("Width") = txtWidth.Value
            dr.Item("Length") = txtLength.Value
            dr.Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
            dr.Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
            dr.Item("ItemTypeID") = cboItemType.SelectedValue
            dr.Item("ItemTypeName") = cboItemType.Text.Trim
            dr.Item("Quantity") = txtQuantity.Value
            dr.Item("Weight") = txtWeight.Value
            dr.Item("TotalWeight") = txtTotalWeight.Value
            dr.Item("UnitPrice") = txtUnitPrice.Value
            dr.Item("CuttingPrice") = txtCuttingPrice.Value
            dr.Item("TransportPrice") = txtTransportPrice.Value
            dr.Item("TotalPrice") = txtTotalPrice.Value
            dr.Item("CuttingQuantity") = 0
            dr.Item("CuttingWeight") = 0
            dr.Item("TransportQuantity") = 0
            dr.Item("TransportWeight") = 0
            dr.Item("Remarks") = txtRemarks.Text.Trim
            dr.EndEdit()
            dtParent.Rows.Add(dr)
            dtParent.AcceptChanges()
            frmParent.grdItemOrderView.BestFitColumns()
            prvClear()
        Else
            For Each dr As DataRow In dtParent.Rows
                If dr.Item("ID") = strID Then
                    dr.BeginEdit()
                    dr.Item("ItemID") = intItemID
                    dr.Item("ItemCode") = txtItemCode.Text.Trim
                    dr.Item("ItemName") = txtItemName.Text.Trim
                    dr.Item("Thick") = txtThick.Value
                    dr.Item("Width") = txtWidth.Value
                    dr.Item("Length") = txtLength.Value
                    dr.Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
                    dr.Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
                    dr.Item("ItemTypeID") = cboItemType.SelectedValue
                    dr.Item("ItemTypeName") = cboItemType.Text.Trim
                    dr.Item("Quantity") = txtQuantity.Value
                    dr.Item("Weight") = txtWeight.Value
                    dr.Item("TotalWeight") = txtTotalWeight.Value
                    dr.Item("UnitPrice") = txtUnitPrice.Value
                    dr.Item("CuttingPrice") = txtCuttingPrice.Value
                    dr.Item("TransportPrice") = txtTransportPrice.Value
                    dr.Item("TotalPrice") = txtTotalPrice.Value
                    dr.Item("CuttingQuantity") = 0
                    dr.Item("CuttingWeight") = 0
                    dr.Item("TransportQuantity") = 0
                    dr.Item("TransportWeight") = 0
                    dr.Item("Remarks") = txtRemarks.Text.Trim
                    dr.EndEdit()
                    dtParent.AcceptChanges()
                    frmParent.grdItemOrderView.BestFitColumns()
                    Exit For
                End If
            Next
            Me.Close()
        End If
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmMstItem
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intItemID = .pubLUdtRow.Item("ID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtThick.Text = .pubLUdtRow.Item("Thick")
                txtWidth.Text = .pubLUdtRow.Item("Width")
                txtLength.Text = .pubLUdtRow.Item("Length")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtUnitPrice.Value = .pubLUdtRow.Item("BasePrice")
                txtQuantity.Value = 0
                txtQuantity.Focus()
                txtRemarks.Text = ""
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtNettoPrice.Value = txtUnitPrice.Value - txtCuttingPrice.Value - txtTransportPrice.Value
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtNettoPrice.Value * txtTotalWeight.Value
    End Sub

    Private Sub prvClear()
        strID = ""
        intItemID = 0
        txtItemCode.Text = ""
        txtItemName.Text = ""
        cboItemType.SelectedIndex = -1
        cboItemSpecification.SelectedIndex = -1
        txtThick.Value = 0
        txtWidth.Value = 0
        txtLength.Value = 0
        txtWeight.Value = 0
        txtUnitPrice.Value = 0
        txtCuttingPrice.Value = decCuttingPrice
        txtTransportPrice.Value = decTransportPrice
        txtQuantity.Value = 0
        txtRemarks.Text = ""
        txtItemCode.Focus()
    End Sub

#Region "Form Handle"

    Private Sub frmTraPurchaseOrderDetItemRequest_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraPurchaseOrderDetItemRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        prvChooseItem()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged,
        txtCuttingPrice.ValueChanged, txtTransportPrice.ValueChanged, txtQuantity.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class