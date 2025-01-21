Public Class frmTraSalesConfirmationOrderDetItem

#Region "Property"

    Private frmParent As frmTraSalesConfirmationOrderDet
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private strORDetailID As String
    Private strPODetailID As String
    Private intBPID As Integer = 0
    Private intItemID As Integer = 0
    Private intPos As Integer = 0
    Private clsCS As VO.CS
    Private dtParentItem As New DataTable
    Private drSelectedItem As DataRow
    Private bolIsAutoSearch As Boolean
    Private intBPLocationID As Integer = 0

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubTableParentItem As DataTable
        Set(value As DataTable)
            dtParentItem = value
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
                strID = drSelectedItem.Item("ID")
                strORDetailID = drSelectedItem.Item("ORDetailID")
                strPODetailID = drSelectedItem.Item("PODetailID")
                txtOrderNumber.Text = drSelectedItem.Item("OrderNumber")
                txtPONumber.Text = drSelectedItem.Item("PONumber")
                intItemID = drSelectedItem.Item("ItemID")
                cboItemType.SelectedValue = drSelectedItem.Item("ItemTypeID")
                txtItemCode.Text = drSelectedItem.Item("ItemCode")
                txtItemName.Text = drSelectedItem.Item("ItemName")
                cboItemSpecification.SelectedValue = drSelectedItem.Item("ItemSpecificationID")
                txtThick.Value = drSelectedItem.Item("Thick")
                txtWidth.Value = drSelectedItem.Item("Width")
                txtLength.Value = drSelectedItem.Item("Length")
                txtWeight.Value = drSelectedItem.Item("Weight")
                txtMaxTotalWeightRequest.Value = drSelectedItem.Item("MaxTotalWeightOR")
                txtMaxTotalWeightPO.Value = drSelectedItem.Item("MaxTotalWeightPO")
                txtUnitPrice.Value = drSelectedItem.Item("UnitPrice")
                txtQuantity.Value = drSelectedItem.Item("Quantity")
                txtRemarks.Text = drSelectedItem.Item("Remarks")
                txtItemTolerances.Value = drSelectedItem.Item("ItemTolerances")
                txtItemMin.Value = drSelectedItem.Item("ItemMin")
                txtItemMax.Value = drSelectedItem.Item("ItemMax")
                intBPLocationID = drSelectedItem.Item("LocationID")
                txtBPLocationAddress.Text = drSelectedItem.Item("DeliveryAddress")
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
        If txtOrderNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih No. Permintaan terlebih dahulu")
            txtOrderNumber.Focus()
            Exit Sub
        ElseIf txtPONumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih No. Pesanan terlebih dahulu")
            txtPONumber.Focus()
            Exit Sub
        ElseIf txtItemCode.Text.Trim = "" Then
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
        ElseIf intBPLocationID = 0 Or txtBPLocationAddress.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Alamat Pengiriman terlebih dahulu")
            txtBPLocationAddress.Focus()
            Exit Sub
        ElseIf txtMaxTotalWeightRequest.Value < txtTotalWeight.Value Then
            If Not UI.usForm.frmAskQuestion("Total Berat melebihi Maks. Total Berat, Apakah anda yakin ingin melanjutkannya?") Then Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtParentItem.NewRow
            With drItem
                .BeginEdit()
                .Item("ID") = Guid.NewGuid.ToString
                .Item("COID") = ""
                .Item("ORDetailID") = strORDetailID
                .Item("PODetailID") = strPODetailID
                .Item("OrderNumber") = txtOrderNumber.Text.Trim
                .Item("PONumber") = txtPONumber.Text.Trim
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
                .Item("MaxTotalWeightOR") = txtMaxTotalWeightRequest.Value
                .Item("MaxTotalWeightPO") = txtMaxTotalWeightPO.Value
                .Item("UnitPrice") = txtUnitPrice.Value
                .Item("TotalPrice") = txtTotalPrice.Value
                .Item("Remarks") = txtRemarks.Text.Trim
                .Item("LocationID") = intBPLocationID
                .Item("DeliveryAddress") = txtBPLocationAddress.Text.Trim
                .Item("ItemMin") = txtItemMin.Value
                .Item("ItemMax") = txtItemMax.Value
                .Item("ItemTolerances") = txtItemTolerances.Value
                .EndEdit()
            End With
            dtParentItem.Rows.Add(drItem)
        Else
            For Each dr As DataRow In dtParentItem.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("COID") = ""
                        .Item("ORDetailID") = strORDetailID
                        .Item("PODetailID") = strPODetailID
                        .Item("OrderNumber") = txtOrderNumber.Text.Trim
                        .Item("PONumber") = txtPONumber.Text.Trim
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
                        .Item("MaxTotalWeightOR") = txtMaxTotalWeightRequest.Value
                        .Item("MaxTotalWeightPO") = txtMaxTotalWeightPO.Value
                        .Item("UnitPrice") = txtUnitPrice.Value
                        .Item("TotalPrice") = txtTotalPrice.Value
                        .Item("Remarks") = txtRemarks.Text.Trim
                        .Item("LocationID") = intBPLocationID
                        .Item("DeliveryAddress") = txtBPLocationAddress.Text.Trim
                        .Item("ItemMin") = txtItemMin.Value
                        .Item("ItemMax") = txtItemMax.Value
                        .Item("ItemTolerances") = txtItemTolerances.Value
                        .EndEdit()
                    End If
                End With
            Next
        End If
        dtParentItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()
        Me.Close()
    End Sub

    Private Sub prvClear()
        txtOrderNumber.Text = ""
        txtPONumber.Text = ""
        txtOrderNumber.Focus()
        strORDetailID = ""
        strPODetailID = ""
        intItemID = 0
        txtItemCode.Text = ""
        txtItemName.Text = ""
        cboItemType.SelectedIndex = -1
        cboItemSpecification.SelectedIndex = -1
        txtThick.Value = 0
        txtWidth.Value = 0
        txtLength.Value = 0
        txtWeight.Value = 0
        txtMaxTotalWeightRequest.Value = 0
        txtMaxTotalWeightPO.Value = 0
        txtUnitPrice.Value = 0
        txtQuantity.Value = 0
        txtTotalWeight.Value = 0
        txtTotalPrice.Value = 0
        txtRemarks.Text = ""
        txtItemTolerances.Value = 0
        txtItemMin.Value = 0
        txtItemMax.Value = 0
        intBPLocationID = 0
        txtBPLocationAddress.Text = ""
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraSalesConfirmationOrderDetItemRequest
        With frmDetail
            .pubParentItem = dtParentItem
            .pubBPID = intBPID
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookupGet Then
                txtOrderNumber.Text = .pubLUdtRow.Item("OrderNumber")
                strORDetailID = .pubLUdtRow.Item("ID")
                intItemID = .pubLUdtRow.Item("ItemID")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtThick.Value = .pubLUdtRow.Item("Thick")
                txtWidth.Value = .pubLUdtRow.Item("Width")
                txtLength.Value = .pubLUdtRow.Item("Length")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtMaxTotalWeightRequest.Value = .pubLUdtRow.Item("MaxTotalWeight")
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

    Private Sub prvChoosePO()
        Dim frmDetail As New frmTraSalesConfirmationOrderDetItemPO
        With frmDetail
            .pubParentItem = dtParentItem
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookupGet Then
                txtPONumber.Text = .pubLUdtRow.Item("PONumber")
                strPODetailID = .pubLUdtRow.Item("ID")
                txtMaxTotalWeightPO.Value = .pubLUdtRow.Item("MaxTotalWeight")
                txtWeight.Focus()
                txtRemarks.Text = ""
            End If
        End With
    End Sub

    Private Sub prvChooseBPLocation()
        Dim frmDetail As New frmMstBusinessPartnerLocation
        With frmDetail
            .pubIsLookUp = True
            .pubBPID = intBPID
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intBPLocationID = .pubLUdtRow.Item("ID")
                txtBPLocationAddress.Text = .pubLUdtRow.Item("Address")
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesConfirmationOrderDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesConfirmationOrderDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnRequestItem_Click(sender As Object, e As EventArgs) Handles btnRequestItem.Click
        prvChooseItem()
    End Sub

    Private Sub btnPOItem_Click(sender As Object, e As EventArgs) Handles btnPOItem.Click
        prvChoosePO()
    End Sub

    Private Sub btnBPLocation_Click(sender As Object, e As EventArgs) Handles btnBPLocation.Click
        prvChooseBPLocation()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class