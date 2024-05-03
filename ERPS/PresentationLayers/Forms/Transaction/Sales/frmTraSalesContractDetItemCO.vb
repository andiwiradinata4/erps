Public Class frmTraSalesContractDetItemCO

#Region "Property"

    Private frmParent As frmTraSalesContractDetItem
    Private dtParent As New DataTable
    Private dtParentAll As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private drSelected As DataRow
    Private strID As String = ""
    Private strCODetailID As String
    Private clsCS As VO.CS
    Private bolIsAutoSearch As Boolean

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

    Public WriteOnly Property pubCODetailID As String
        Set(value As String)
            strCODetailID = value
        End Set
    End Property

    Public WriteOnly Property pubTableParent As DataTable
        Set(value As DataTable)
            dtParent = value
        End Set
    End Property

    Public WriteOnly Property pubTableParentAll As DataTable
        Set(value As DataTable)
            dtParentAll = value
        End Set
    End Property

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public WriteOnly Property pubIsAutoSearch As Boolean
        Set(value As Boolean)
            bolIsAutoSearch = value
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
                strCODetailID = drSelected.Item("CODetailID")
                txtCONumber.Text = drSelected.Item("CONumber")
                txtOrderNumberSupplier.Text = drSelected.Item("OrderNumberSupplier")
                intItemID = drSelected.Item("ItemID")
                txtItemCode.Text = drSelected.Item("ItemCode")
                txtItemName.Text = drSelected.Item("ItemName")
                cboItemType.SelectedValue = drSelected.Item("ItemTypeID")
                cboItemSpecification.SelectedValue = drSelected.Item("ItemSpecificationID")
                txtThick.Value = drSelected.Item("Thick")
                txtWidth.Value = drSelected.Item("Width")
                txtLength.Value = drSelected.Item("Length")
                txtWeight.Value = drSelected.Item("Weight")
                txtMaxTotalWeight.Value = drSelected.Item("MaxTotalWeight")
                txtUnitPrice.Value = drSelected.Item("UnitPrice")
                txtQuantity.Value = drSelected.Item("Quantity")
                txtRemarks.Text = drSelected.Item("Remarks")
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtCONumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih No. Konfirmasi terlebih dahulu")
            txtCONumber.Focus()
            Exit Sub
        ElseIf txtItemCode.Text.Trim = "" Then
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
        ElseIf txtWeight.Value <= 0 Then
            UI.usForm.frmMessageBox("Berat harus lebih besar dari 0")
            txtWeight.Focus()
            Exit Sub
        End If

        If bolIsNew Then
            Dim dr As DataRow = dtParent.NewRow
            With dr
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
                .Item("SCID") = ""
                .Item("CODetailID") = strCODetailID
                .Item("GroupID") = 0
                .Item("CONumber") = txtCONumber.Text.Trim
                .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                .Item("ItemID") = intItemID
                .Item("ItemCode") = txtItemCode.Text.Trim
                .Item("ItemName") = txtItemName.Text.Trim
                .Item("Thick") = txtThick.Value
                .Item("Width") = txtWidth.Value
                .Item("Length") = txtLength.Value
                .Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
                .Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
                .Item("ItemTypeID") = cboItemType.SelectedValue
                .Item("ItemTypeName") = cboItemType.Text.Trim
                .Item("Quantity") = txtQuantity.Value
                .Item("Weight") = txtWeight.Value
                .Item("TotalWeight") = txtTotalWeight.Value
                .Item("MaxTotalWeight") = txtMaxTotalWeight.Value
                .Item("UnitPrice") = txtUnitPrice.Value
                .Item("TotalPrice") = txtTotalPrice.Value
                .Item("Remarks") = txtRemarks.Text.Trim
                dr.EndEdit()
                dtParent.Rows.Add(dr)
                dtParent.AcceptChanges()
                frmParent.grdItemCOView.BestFitColumns()
                prvClear()
            End With
        Else
            For Each dr As DataRow In dtParent.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("CODetailID") = strCODetailID
                        .Item("CONumber") = txtCONumber.Text.Trim
                        .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                        .Item("ItemID") = intItemID
                        .Item("ItemCode") = txtItemCode.Text.Trim
                        .Item("ItemName") = txtItemName.Text.Trim
                        .Item("Thick") = txtThick.Value
                        .Item("Width") = txtWidth.Value
                        .Item("Length") = txtLength.Value
                        .Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
                        .Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
                        .Item("ItemTypeID") = cboItemType.SelectedValue
                        .Item("ItemTypeName") = cboItemType.Text.Trim
                        .Item("Quantity") = txtQuantity.Value
                        .Item("Weight") = txtWeight.Value
                        .Item("TotalWeight") = txtTotalWeight.Value
                        .Item("MaxTotalWeight") = txtMaxTotalWeight.Value
                        .Item("UnitPrice") = txtUnitPrice.Value
                        .Item("TotalPrice") = txtTotalPrice.Value
                        .Item("Remarks") = txtRemarks.Text.Trim
                        .EndEdit()
                        dtParent.AcceptChanges()
                        frmParent.grdItemCOView.BestFitColumns()
                        Exit For
                    End If
                End With
            Next
            Me.Close()
        End If
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraConfirmationOrderOutstandingSalesContract
        With frmDetail
            .pubParentItem = dtParentAll
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookUpGet Then
                txtCONumber.Text = .pubLUdtRow.Item("CONumber")
                strCODetailID = .pubLUdtRow.Item("ID")
                txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                intItemID = .pubLUdtRow.Item("ItemID")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtThick.Value = .pubLUdtRow.Item("Thick")
                txtWidth.Value = .pubLUdtRow.Item("Width")
                txtLength.Value = .pubLUdtRow.Item("Length")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtMaxTotalWeight.Value = .pubLUdtRow.Item("TotalWeight")
                txtUnitPrice.Value = .pubLUdtRow.Item("UnitPrice")
                txtQuantity.Value = .pubLUdtRow.Item("Quantity")
                txtWeight.Focus()
                txtRemarks.Text = ""
                bolIsAutoSearch = False
            Else
                If bolIsAutoSearch Then Me.Close()
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
    End Sub

    Private Sub prvClear()
        strID = ""
        strCODetailID = ""
        txtCONumber.Text = ""
        txtOrderNumberSupplier.Text = ""
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
        txtQuantity.Value = 0
        txtMaxTotalWeight.Value = 0
        txtRemarks.Text = ""
        txtItemCode.Focus()
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemCO_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemCO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
        If bolIsAutoSearch Then prvChooseItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnCO_Click(sender As Object, e As EventArgs) Handles btnCO.Click
        prvChooseItem()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class