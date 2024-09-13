Public Class frmTraOrderRequestMapConfirmationOrderDetItem

#Region "Property"

    Private frmParent As frmTraOrderRequestMapConfirmationOrderDet
    Private dtParent As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private intItemIDCO As Integer = 0
    Private drSelected As DataRow
    Private strID As String = ""
    Private bolIsAutoSearch As Boolean
    Private strOrderRequestID As String = ""
    Private strCOID As String = ""
    Private strORDetailID As String = ""
    Private strCODetailID As String = ""
    Private clsCS As VO.CS

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

    Public WriteOnly Property pubOrderRequestID As String
        Set(value As String)
            strOrderRequestID = value
        End Set
    End Property

    Public WriteOnly Property pubIsAutoSearch As Boolean
        Set(value As Boolean)
            bolIsAutoSearch = value
        End Set
    End Property

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
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
            Dim dtItemType As DataTable = BL.ItemType.ListDataForCombo
            Dim dtItemSpecification As DataTable = BL.ItemSpecification.ListDataForCombo
            UI.usForm.FillComboBox(cboItemType, dtItemType, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, dtItemSpecification, "ID", "Description")
            UI.usForm.FillComboBox(cboItemTypeCO, dtItemType, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecificationCO, dtItemSpecification, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        txtItemCode.Focus()
        strID = ""
        strORDetailID = ""
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
        txtUnitPriceHPP.Value = 0

        txtCONumber.Text = ""
        strCODetailID = ""
        intItemIDCO = 0
        txtItemCodeCO.Text = ""
        txtOrderNumberSupplier.Text = ""
        cboItemTypeCO.SelectedIndex = -1
        txtItemNameCO.Text = ""
        txtThickCO.Value = 0
        txtWidthCO.Value = 0
        txtLengthCO.Value = 0
        txtWeightCO.Value = 0
        txtUnitPriceCO.Value = 0
        cboItemSpecificationCO.SelectedIndex = -1
        txtQuantityCO.Value = 0
        txtTotalWeightCO.Value = 0
        txtTotalPriceCO.Value = 0
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            If bolIsNew Then
                prvClear()
            Else
                strID = drSelected.Item("ID")
                strORDetailID = drSelected.Item("ORDetailID")
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

                txtCONumber.Text = drSelected.Item("CONumber")
                strCODetailID = drSelected.Item("CODetailID")
                intItemIDCO = drSelected.Item("ItemIDCO")
                txtItemCodeCO.Text = drSelected.Item("ItemCodeCO")
                txtItemNameCO.Text = drSelected.Item("ItemNameCO")
                cboItemTypeCO.SelectedValue = drSelected.Item("ItemTypeIDCO")
                txtThickCO.Value = drSelected.Item("ThickCO")
                txtWidthCO.Value = drSelected.Item("WidthCO")
                txtLengthCO.Value = drSelected.Item("LengthCO")
                txtWeightCO.Value = drSelected.Item("WeightCO")
                txtUnitPriceCO.Value = drSelected.Item("UnitPriceCO")
                cboItemSpecificationCO.SelectedValue = drSelected.Item("ItemSpecificationIDCO")
                txtQuantityCO.Value = drSelected.Item("QuantityCO")
                txtTotalWeightCO.Value = drSelected.Item("TotalWeightCO")
                txtTotalPriceCO.Value = drSelected.Item("TotalPriceCO")
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
        ElseIf txtOrderNumberSupplier.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nomor Pesanan Pemasok tidak boleh kosong")
            txtOrderNumberSupplier.Focus()
            Exit Sub
        ElseIf txtUnitPriceHPP.Value <= 0 Then
            UI.usForm.frmMessageBox("Harga Beli harus lebih besar dari 0 agar HPP Penjualan dapat diperoleh saat pengiriman")
            txtUnitPriceHPP.Focus()
            Exit Sub
        ElseIf txtItemCodeCO.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih item konfirmasi pesanan terlebih dahulu")
            txtItemCodeCO.Focus()
            Exit Sub
        ElseIf cboItemTypeCO.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Jenis barang konfirmasi pesanan tidak valid")
            cboItemTypeCO.Focus()
            Exit Sub
        ElseIf cboItemSpecificationCO.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Spesifikasi barang konfirmasi pesanan tidak valid")
            cboItemSpecificationCO.Focus()
            Exit Sub
        ElseIf txtQuantityCO.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah konfirmasi pesanan harus lebih besar dari 0")
            txtQuantityCO.Focus()
            Exit Sub
        ElseIf txtWeightCO.Value <= 0 Then
            UI.usForm.frmMessageBox("Berat konfirmasi pesanan harus lebih besar dari 0")
            txtWeightCO.Focus()
            Exit Sub
        End If

        If bolIsNew Then
            Dim dr As DataRow
            dr = dtParent.NewRow
            dr.BeginEdit()
            dr.Item("ID") = Guid.NewGuid
            dr.Item("ORDetailID") = strORDetailID
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
            dr.Item("RoundingWeight") = 0
            dr.Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
            dr.Item("UnitPriceHPP") = txtUnitPriceHPP.Value

            dr.Item("CONumber") = txtCONumber.Text.Trim
            dr.Item("CODetailID") = strCODetailID
            dr.Item("ItemIDCO") = intItemIDCO
            dr.Item("ItemCodeCO") = txtItemCodeCO.Text.Trim
            dr.Item("ItemNameCO") = txtItemNameCO.Text.Trim
            dr.Item("ThickCO") = txtThickCO.Value
            dr.Item("WidthCO") = txtWidthCO.Value
            dr.Item("LengthCO") = txtLengthCO.Value
            dr.Item("ItemSpecificationIDCO") = cboItemSpecificationCO.SelectedValue
            dr.Item("ItemSpecificationNameCO") = cboItemSpecificationCO.Text.Trim
            dr.Item("ItemTypeIDCO") = cboItemTypeCO.SelectedValue
            dr.Item("ItemTypeNameCO") = cboItemTypeCO.Text.Trim
            dr.Item("QuantityCO") = txtQuantityCO.Value
            dr.Item("WeightCO") = txtWeightCO.Value
            dr.Item("TotalWeightCO") = txtTotalWeightCO.Value
            dr.Item("UnitPriceCO") = txtUnitPriceCO.Value
            dr.Item("TotalPriceCO") = txtTotalPriceCO.Value
            dr.Item("RoundingWeightCO") = 0

            dr.EndEdit()
            dtParent.Rows.Add(dr)
            dtParent.AcceptChanges()
            frmParent.grdItemView.BestFitColumns()
            Me.Close()
        Else
            For Each dr As DataRow In dtParent.Rows
                If dr.Item("ID") = strID Then
                    dr.BeginEdit()
                    dr.Item("ORDetailID") = strORDetailID
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
                    dr.Item("RoundingWeight") = 0
                    dr.Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                    dr.Item("UnitPriceHPP") = txtUnitPriceHPP.Value

                    dr.Item("CONumber") = txtCONumber.Text.Trim
                    dr.Item("CODetailID") = strCODetailID
                    dr.Item("ItemIDCO") = intItemIDCO
                    dr.Item("ItemCodeCO") = txtItemCodeCO.Text.Trim
                    dr.Item("ItemNameCO") = txtItemNameCO.Text.Trim
                    dr.Item("ThickCO") = txtThickCO.Value
                    dr.Item("WidthCO") = txtWidthCO.Value
                    dr.Item("LengthCO") = txtLengthCO.Value
                    dr.Item("ItemSpecificationIDCO") = cboItemSpecificationCO.SelectedValue
                    dr.Item("ItemSpecificationNameCO") = cboItemSpecificationCO.Text.Trim
                    dr.Item("ItemTypeIDCO") = cboItemTypeCO.SelectedValue
                    dr.Item("ItemTypeNameCO") = cboItemTypeCO.Text.Trim
                    dr.Item("QuantityCO") = txtQuantityCO.Value
                    dr.Item("WeightCO") = txtWeightCO.Value
                    dr.Item("TotalWeightCO") = txtTotalWeightCO.Value
                    dr.Item("UnitPriceCO") = txtUnitPriceCO.Value
                    dr.Item("TotalPriceCO") = txtTotalPriceCO.Value
                    dr.Item("RoundingWeightCO") = 0
                    dr.EndEdit()
                    dtParent.AcceptChanges()
                    frmParent.grdItemView.BestFitColumns()
                    Exit For
                End If
            Next
            Me.Close()
        End If
    End Sub

    Private Sub prvRequestItem()
        Dim frmDetail As New frmTraOrderRequestOutstandingMapConfirmationOrder
        With frmDetail
            .pubCS = clsCS
            .pubOrderRequestID = strOrderRequestID
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                strOrderRequestID = .pubLUdtRow.Item("OrderRequestID")
                txtRequestNumber.Text = .pubLUdtRow.Item("OrderNumber")
                strORDetailID = .pubLUdtRow.Item("ID")
                intItemID = .pubLUdtRow.Item("ItemID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtThick.Value = .pubLUdtRow.Item("Thick")
                txtWidth.Value = .pubLUdtRow.Item("Width")
                txtLength.Value = .pubLUdtRow.Item("Length")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtUnitPrice.Value = .pubLUdtRow.Item("UnitPrice")
                txtQuantity.Value = .pubLUdtRow.Item("Quantity")
                bolIsAutoSearch = False
            Else
                If bolIsAutoSearch Then Me.Close()
            End If
        End With
    End Sub

    Private Sub prvCOItem()
        Dim frmDetail As New frmTraOrderRequestOutstandingMapConfirmationOrderItem
        With frmDetail
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookupGet Then
                strCOID = .pubLUdtRow.Item("COID")
                txtCONumber.Text = .pubLUdtRow.Item("CONumber")
                txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                strCODetailID = .pubLUdtRow.Item("ID")
                intItemIDCO = .pubLUdtRow.Item("ItemID")
                txtItemCodeCO.Text = .pubLUdtRow.Item("ItemCode")
                cboItemTypeCO.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                cboItemSpecificationCO.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtItemNameCO.Text = .pubLUdtRow.Item("ItemName")
                txtThickCO.Value = .pubLUdtRow.Item("Thick")
                txtWidthCO.Value = .pubLUdtRow.Item("Width")
                txtLengthCO.Value = .pubLUdtRow.Item("Length")
                txtWeightCO.Value = .pubLUdtRow.Item("Weight")
                txtUnitPriceCO.Value = .pubLUdtRow.Item("UnitPrice")
                txtQuantityCO.Value = .pubLUdtRow.Item("Quantity")
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtTotalWeight.Value * txtUnitPrice.Value

        txtTotalWeightCO.Value = txtWeightCO.Value * txtQuantityCO.Value
        txtTotalPriceCO.Value = txtTotalWeightCO.Value * txtUnitPriceCO.Value

        '# Calculate Unit Price HPP
        If txtTotalPriceCO.Value > 0 And txtTotalWeight.Value > 0 Then txtUnitPriceHPP.Value = txtTotalPriceCO.Value / txtTotalWeight.Value
        '# ------------------------------------
    End Sub

#Region "Form Handle"

    Private Sub frmTraOrderRequestMapConfirmationOrderDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraOrderRequestMapConfirmationOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
        If bolIsAutoSearch Then prvRequestItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnRequestItem_Click(sender As Object, e As EventArgs) Handles btnRequestItem.Click
        prvRequestItem()
    End Sub

    Private Sub btnCO_Click(sender As Object, e As EventArgs) Handles btnCO.Click
        prvCOItem()
    End Sub

#End Region

    Private Sub txtValue_ValueChanged(sender As Object, e As EventArgs) Handles txtWeight.ValueChanged,
        txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeightCO.ValueChanged, txtUnitPriceCO.ValueChanged,
        txtQuantityCO.ValueChanged
        prvCalculate()
    End Sub
End Class