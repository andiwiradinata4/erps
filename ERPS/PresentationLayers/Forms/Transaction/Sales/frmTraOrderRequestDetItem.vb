Public Class frmTraOrderRequestDetItem

#Region "Property"

    Private frmParent As frmTraOrderRequestDet
    Private dtParent As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private drSelected As DataRow
    Private strID As String = ""
    Private bolIsAutoSearch As Boolean
    Private bolIsStock As Boolean

    Public WriteOnly Property pubTableParent As DataTable
        Set(value As DataTable)
            dtParent = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubDatRowSelected As DataRow
        Set(value As DataRow)
            drSelected = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public WriteOnly Property pubIsAutoSearch As Boolean
        Set(value As Boolean)
            bolIsAutoSearch = value
        End Set
    End Property

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
       cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboItemType, BL.ItemType.ListDataForCombo, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, BL.ItemSpecification.ListDataForCombo, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        txtItemCode.Focus()
        strID = ""
        intItemID = 0
        txtItemCode.Text = ""
        cboItemType.SelectedIndex = -1
        txtItemName.Text = ""
        txtThick.Value = 0
        txtWidth.Value = 0
        txtLength.Value = 0
        txtWeight.Value = 0
        txtUnitPrice.Value = 0
        cboItemSpecification.SelectedIndex = -1
        txtQuantity.Value = 0
        txtTotalWeight.Value = 0
        txtTotalPrice.Value = 0
        txtRemarks.Text = ""
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            If bolIsNew Then
                prvClear()
            Else
                strID = drSelected.Item("ID")
                intItemID = drSelected.Item("ItemID")
                txtItemCode.Text = drSelected.Item("ItemCode")
                txtItemName.Text = drSelected.Item("ItemName")
                cboItemType.SelectedValue = drSelected.Item("ItemTypeID")
                txtThick.Value = drSelected.Item("Thick")
                txtWidth.Value = drSelected.Item("Width")
                txtLength.Value = drSelected.Item("Length")
                txtWeight.Value = drSelected.Item("Weight")
                txtUnitPrice.Value = drSelected.Item("UnitPrice")
                cboItemSpecification.SelectedValue = drSelected.Item("ItemSpecificationID")
                txtQuantity.Value = drSelected.Item("Quantity")
                txtTotalWeight.Value = drSelected.Item("TotalWeight")
                txtTotalPrice.Value = drSelected.Item("TotalPrice")
                txtRemarks.Text = drSelected.Item("Remarks")
                txtOrderNumberSupplier.Text = drSelected.Item("OrderNumberSupplier")
                txtUnitPriceHPP.Value = drSelected.Item("UnitPriceHPP")
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
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
        ElseIf txtQuantity.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        ElseIf txtWeight.Value <= 0 Then
            UI.usForm.frmMessageBox("Berat harus lebih besar dari 0")
            txtWeight.Focus()
            Exit Sub
        ElseIf bolIsStock And txtOrderNumberSupplier.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nomor Pesanan Pemasok tidak boleh kosong")
            txtOrderNumberSupplier.Focus()
            Exit Sub
        ElseIf bolIsStock And txtUnitPriceHPP.Value <= 0 Then
            UI.usForm.frmMessageBox("Harga Beli harus lebih besar dari 0 agar HPP Penjualan dapat diperoleh saat pengiriman")
            txtUnitPriceHPP.Focus()
            Exit Sub
        End If

        If bolIsNew Then
            Dim dr As DataRow
            dr = dtParent.NewRow
            dr.BeginEdit()
            dr.Item("ID") = Guid.NewGuid
            dr.Item("OrderRequestID") = ""
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
            dr.Item("TotalPrice") = txtTotalPrice.Value
            dr.Item("Remarks") = txtRemarks.Text.Trim
            dr.Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
            dr.Item("UnitPriceHPP") = txtUnitPriceHPP.Value
            dr.EndEdit()
            dtParent.Rows.Add(dr)
            dtParent.AcceptChanges()
            frmParent.grdItemView.BestFitColumns()
            prvClear()
            frmParent.prvCalculate()
        Else
            For Each dr As DataRow In dtParent.Rows
                If dr.Item("ID") = strID Then
                    dr.BeginEdit()
                    dr.Item("OrderRequestID") = ""
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
                    dr.Item("TotalPrice") = txtTotalPrice.Value
                    dr.Item("Remarks") = txtRemarks.Text.Trim
                    dr.Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                    dr.Item("UnitPriceHPP") = txtUnitPriceHPP.Value
                    dr.EndEdit()
                    dtParent.AcceptChanges()
                    frmParent.grdItemView.BestFitColumns()
                    Exit For
                End If
            Next
            frmParent.prvCalculate()
            Me.Close()
        End If
    End Sub

    Private Sub prvChooseItem()
        If bolIsStock Then
            Dim frmDetail As New frmMstStock
            With frmDetail
                .pubIsLookUp = True
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
                If .pubIsLookUpGet Then
                    intItemID = .pubLUdtRow.Item("ID")
                    txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                    cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                    txtItemName.Text = .pubLUdtRow.Item("ItemName")
                    txtThick.Value = .pubLUdtRow.Item("Thick")
                    txtWidth.Value = .pubLUdtRow.Item("Width")
                    txtLength.Value = .pubLUdtRow.Item("Length")
                    cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                    txtWeight.Value = .pubLUdtRow.Item("Weight")
                    txtUnitPrice.Value = .pubLUdtRow.Item("BasePrice")
                    txtQuantity.Value = 0
                    txtUnitPrice.Focus()
                    txtRemarks.Text = ""
                    txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                    txtUnitPriceHPP.Value = .pubLUdtRow.Item("UnitPrice")
                    bolIsAutoSearch = False
                Else
                    If bolIsAutoSearch Then Me.Close()
                End If
            End With
        Else
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
                    txtThick.Value = .pubLUdtRow.Item("Thick")
                    txtWidth.Value = .pubLUdtRow.Item("Width")
                    txtLength.Value = .pubLUdtRow.Item("Length")
                    cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                    txtWeight.Value = .pubLUdtRow.Item("Weight")
                    txtUnitPrice.Value = .pubLUdtRow.Item("BasePrice")
                    txtQuantity.Value = 0
                    txtUnitPrice.Focus()
                    txtRemarks.Text = ""
                    txtOrderNumberSupplier.Text = ""
                    txtUnitPriceHPP.Value = 0
                    bolIsAutoSearch = False
                Else
                    If bolIsAutoSearch Then Me.Close()
                End If
            End With
        End If
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtTotalWeight.Value * txtUnitPrice.Value
    End Sub

    Private Sub prvSetupTools()
        lblOrderNumberSupplier.Visible = bolIsStock
        txtOrderNumberSupplier.Visible = bolIsStock
        lblUnitPriceHPP.Visible = bolIsStock
        txtUnitPriceHPP.Visible = bolIsStock
    End Sub

#Region "Form Handle"

    Private Sub frmTraOrderRequestDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraOrderRequestDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetupTools()
        prvFillForm()
        If bolIsAutoSearch Then prvChooseItem()
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

    Private Sub txtNumeric_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged, txtUnitPrice.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class