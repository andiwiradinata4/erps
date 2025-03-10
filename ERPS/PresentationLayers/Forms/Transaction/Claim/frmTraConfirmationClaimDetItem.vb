﻿Public Class frmTraConfirmationClaimDetItem

#Region "Property"

    Private frmParent As frmTraConfirmationClaimDet
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private strReferencesDetailID As String = ""
    Private strReferencesID As String = ""
    Private intItemID As Integer = 0
    Private intPos As Integer = 0
    Private dtItem As New DataTable
    Private drSelectedItem As DataRow
    Private bolIsAutoSearch As Boolean
    Private intLevelItem As Integer
    Private strParentID As String
    Private intClaimType As VO.Claim.ClaimTypeValue

    Public WriteOnly Property pubReferencesID As String
        Set(value As String)
            strReferencesID = value
        End Set
    End Property

    Public WriteOnly Property pubTableItem As DataTable
        Set(value As DataTable)
            dtItem = value
        End Set
    End Property

    Public WriteOnly Property pubDataRowSelected As DataRow
        Set(value As DataRow)
            drSelectedItem = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
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

    Public WriteOnly Property pubClaimType As VO.Claim.ClaimTypeValue
        Set(value As VO.Claim.ClaimTypeValue)
            intClaimType = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

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
                strID = drSelectedItem.Item("ID")
                strReferencesDetailID = drSelectedItem.Item("ClaimDetailID")
                txtOrderNumberSupplier.Text = drSelectedItem.Item("OrderNumberSupplier")
                intItemID = drSelectedItem.Item("ItemID")
                cboItemType.SelectedValue = drSelectedItem.Item("ItemTypeID")
                txtItemCode.Text = drSelectedItem.Item("ItemCode")
                txtItemName.Text = drSelectedItem.Item("ItemName")
                cboItemSpecification.SelectedValue = drSelectedItem.Item("ItemSpecificationID")
                txtThick.Value = drSelectedItem.Item("Thick")
                txtWidth.Value = drSelectedItem.Item("Width")
                txtLength.Value = drSelectedItem.Item("Length")
                txtWeight.Value = drSelectedItem.Item("Weight")
                txtMaxTotalWeight.Value = drSelectedItem.Item("MaxTotalWeight")
                txtUnitPrice.Value = drSelectedItem.Item("UnitPrice")
                txtUnitPriceProduct.Value = drSelectedItem.Item("UnitPriceProduct")
                txtQuantity.Value = drSelectedItem.Item("Quantity")
                txtRemarks.Text = drSelectedItem.Item("Remarks")
                intLevelItem = drSelectedItem.Item("LevelItem")
                strParentID = drSelectedItem.Item("ParentID")
            End If
            prvCalculate()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtItemCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih barang terlebih dahulu")
            txtItemCode.Focus()
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
        ElseIf txtUnitPrice.Value > txtUnitPriceProduct.Value Then
            UI.usForm.frmMessageBox("Harga [Klaim] tidak boleh lebih besar dari Harga [Barang]")
            txtUnitPrice.Focus()
            Exit Sub
        ElseIf txtMaxTotalWeight.Value < txtTotalWeight.Value Then
            If Not UI.usForm.frmAskQuestion("Total Berat melebihi Maks. Total Berat, Apakah anda yakin ingin melanjutkannya?") Then Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtItem.NewRow
            With drItem
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
                .Item("ClaimDetailID") = strReferencesDetailID
                .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                .Item("ClaimNumber") = ""
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
                .Item("UnitPriceProduct") = txtUnitPriceProduct.Value
                .Item("TotalPriceProduct") = txtTotalPriceProduct.Value
                .Item("Remarks") = txtRemarks.Text.Trim
                .Item("LevelItem") = intLevelItem
                .Item("ParentID") = strParentID
                .Item("RoundingWeight") = 0
                .EndEdit()
            End With
            dtItem.Rows.Add(drItem)
        Else
            For Each dr As DataRow In dtItem.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("ID") = Guid.NewGuid
                        .Item("ClaimDetailID") = strReferencesDetailID
                        .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                        .Item("ClaimNumber") = ""
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
                        .Item("UnitPriceProduct") = txtUnitPriceProduct.Value
                        .Item("TotalPriceProduct") = txtTotalPriceProduct.Value
                        .Item("Remarks") = txtRemarks.Text.Trim
                        .Item("LevelItem") = intLevelItem
                        .Item("ParentID") = strParentID
                        .Item("RoundingWeight") = 0
                        .EndEdit()
                    End If
                End With
            Next
        End If
        dtItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()
        prvClear()
        If Not bolIsNew Then Me.Close()
    End Sub

    Private Sub prvClear()
        strID = ""
        txtItemCode.Focus()
        strReferencesDetailID = ""
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
        txtMaxTotalWeight.Value = 0
        txtUnitPrice.Value = 0
        txtUnitPriceProduct.Value = 0
        txtQuantity.Value = 0
        txtTotalWeight.Value = 0
        txtTotalPrice.Value = 0
        txtTotalPriceProduct.Value = 0
        txtRemarks.Text = ""
        intLevelItem = 0
        strParentID = ""
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraConfirmationClaimOutstandingClaimItem
        With frmDetail
            .pubParentID = strReferencesID
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookupGet Then
                strReferencesDetailID = .pubLUdtRow.Item("ID")
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
                txtMaxTotalWeight.Value = .pubLUdtRow.Item("MaxTotalWeight")
                txtUnitPriceProduct.Value = .pubLUdtRow.Item("UnitPriceProduct")
                txtUnitPrice.Value = .pubLUdtRow.Item("UnitPrice")
                txtQuantity.Value = .pubLUdtRow.Item("Quantity")
                intLevelItem = 0
                strParentID = ""
                txtQuantity.Focus()
                txtRemarks.Text = ""
                bolIsAutoSearch = False
            Else
                If bolIsAutoSearch Then Me.Close()
            End If
        End With
    End Sub

    Private Sub prvChooseItemCustom()
        If txtOrderNumberSupplier.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih nomor pesanan pemasok terlebih dahulu")
            txtOrderNumberSupplier.Focus()
            Exit Sub
        End If
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
                txtWeight.Focus()
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
        txtTotalPriceProduct.Value = txtUnitPriceProduct.Value * txtTotalWeight.Value
    End Sub

#Region "Form Handle"

    Private Sub frmTraConfirmationClaimDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraConfirmationClaimDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
        If bolIsAutoSearch Then prvChooseItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        prvChooseItem()
    End Sub

    Private Sub btnItemCustom_Click(sender As Object, e As EventArgs) Handles btnItemCustom.Click
        prvChooseItemCustom()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtUnitPriceProduct.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region
    
End Class