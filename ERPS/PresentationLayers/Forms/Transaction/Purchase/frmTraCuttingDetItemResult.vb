Public Class frmTraCuttingDetItemResult

#Region "Property"

    Private frmParent As frmTraCuttingDetItem
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private drSelected As DataRow
    Private strID As String = ""
    Private clsCS As VO.CS
    Private intBPID As Integer
    Private strPODetailID As String
    Private strPODetailResultID As String
    Private dtItemResultParent As New DataTable
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

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubPODetailID As String
        Set(value As String)
            strPODetailID = value
        End Set
    End Property

    Public WriteOnly Property pubTableItemResultParent As DataTable
        Set(value As DataTable)
            dtItemResultParent = value
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
                txtOrderNumberSupplier.Text = drSelected.Item("OrderNumberSupplier")
                strPODetailResultID = drSelected.Item("PODetailResultID")
                intItemID = drSelected.Item("ItemID")
                txtItemCode.Text = drSelected.Item("ItemCode")
                txtItemName.Text = drSelected.Item("ItemName")
                cboItemType.SelectedValue = drSelected.Item("ItemTypeID")
                cboItemSpecification.SelectedValue = drSelected.Item("ItemSpecificationID")
                txtThick.Value = drSelected.Item("Thick")
                txtWidth.Value = drSelected.Item("Width")
                txtLength.Value = drSelected.Item("Length")
                txtWeight.Value = drSelected.Item("Weight")
                txtQuantity.Value = drSelected.Item("Quantity")
                txtRemarks.Text = drSelected.Item("Remarks")
                txtUnitPriceHPP.Value = drSelected.Item("UnitPriceHPP")
                txtMaxTotalWeight.Value = drSelected.Item("MaxTotalWeight")
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
        ElseIf txtUnitPriceHPP.Value <= 0 Then
            UI.usForm.frmMessageBox("HPP harus lebih besar dari 0")
            txtUnitPriceHPP.Focus()
            Exit Sub
        ElseIf txtMaxTotalWeight.Value < txtTotalWeight.Value Then
            If Not UI.usForm.frmAskQuestion("Total Berat melebihi Maks. Total Berat, Apakah anda yakin ingin melanjutkannya?") Then Exit Sub
        End If

        If bolIsNew Then
            Dim dr As DataRow = dtItemResultParent.NewRow
            With dr
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
                .Item("CuttingID") = ""
                .Item("GroupID") = 0
                .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                .Item("PODetailResultID") = strPODetailResultID
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
                .Item("Remarks") = txtRemarks.Text.Trim
                .Item("UnitPriceHPP") = txtUnitPriceHPP.Value
                .Item("TotalPriceHPP") = txtUnitPriceHPP.Value * txtTotalWeight.Value
                .Item("MaxTotalWeight") = txtMaxTotalWeight.Value
                dr.EndEdit()
                dtItemResultParent.Rows.Add(dr)
                dtItemResultParent.AcceptChanges()
                frmParent.grdItemResultView.BestFitColumns()
                prvClear()
            End With
        Else
            For Each dr As DataRow In dtItemResultParent.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                        .Item("PODetailResultID") = strPODetailResultID
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
                        .Item("Remarks") = txtRemarks.Text.Trim
                        .Item("UnitPriceHPP") = txtUnitPriceHPP.Value
                        .Item("TotalPriceHPP") = txtUnitPriceHPP.Value * txtTotalWeight.Value
                        .Item("MaxTotalWeight") = txtMaxTotalWeight.Value
                        .EndEdit()
                        dtItemResultParent.AcceptChanges()
                        frmParent.grdItemResultView.BestFitColumns()
                        Exit For
                    End If
                End With
            Next
            Me.Close()
        End If
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraPurchaseOrderCuttingDetItemResultOustandingCutting
        With frmDetail
            .pubCS = clsCS
            .pubBPID = intBPID
            .pubPODetailID = strPODetailID
            .pubParentItem = dtItemResultParent
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookupGet Then
                strPODetailResultID = .pubLUdtRow.Item("PODetailResultID")
                txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                intItemID = .pubLUdtRow.Item("ItemID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                txtThick.Value = .pubLUdtRow.Item("Thick")
                txtWidth.Value = .pubLUdtRow.Item("Width")
                txtLength.Value = .pubLUdtRow.Item("Length")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtQuantity.Value = .pubLUdtRow.Item("Quantity")
                txtUnitPriceHPP.Value = .pubLUdtRow.Item("UnitPriceRawMaterial")
                txtMaxTotalWeight.Value = .pubLUdtRow.Item("MaxTotalWeight")
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
    End Sub

    Private Sub prvClear()
        strID = ""
        strPODetailResultID = ""
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
        txtQuantity.Value = 0
        txtRemarks.Text = ""
        txtUnitPriceHPP.Value = 0
        txtMaxTotalWeight.Value = 0
        txtItemCode.Focus()
    End Sub

#Region "Form Handle"

    Private Sub frmTraCuttingDetItemResult_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraCuttingDetItemResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        prvChooseItem()
    End Sub

    Private Sub txtQuantity_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

    Private Sub btnItemCustom_Click(sender As Object, e As EventArgs) Handles btnItemCustom.Click
        prvChooseItemCustom()
    End Sub

#End Region

End Class