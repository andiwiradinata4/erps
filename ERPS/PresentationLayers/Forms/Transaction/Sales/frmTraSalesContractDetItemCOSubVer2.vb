Public Class frmTraSalesContractDetItemCOSubVer2

#Region "Property"

    Private frmParent As frmTraSalesContractDetItemCOVer2
    Private bolIsNew As Boolean = False
    Private drSelected As DataRow
    Private strID As String = ""
    Private strParentID As String = ""
    Private strCODetailID As String
    Private intItemID As Integer = 0
    Private strOrderNumberSupplier As String = ""
    Private bolIsAutoSearch As Boolean
    Private intLevelItem As Integer
    Private strPCDetailID As String = ""
    Private drSelectedCO As DataRow

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

    Public WriteOnly Property pubParentID As String
        Set(value As String)
            strParentID = value
        End Set
    End Property

    Public WriteOnly Property pubIsAutoSearch As Boolean
        Set(value As Boolean)
            bolIsAutoSearch = value
        End Set
    End Property

    Public WriteOnly Property pubDataRowSelectedCO As DataRow
        Set(value As DataRow)
            drSelectedCO = value
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
                strPCDetailID = drSelected.Item("PCDetailID")
            End If
            prvCalculate()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        txtItemCode.Focus()
        prvCalculate()
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
        ElseIf txtWeight.Value <= 0 Then
            UI.usForm.frmMessageBox("Berat harus lebih besar dari 0")
            txtWeight.Focus()
            Exit Sub
        End If

        Try
            BL.SalesContract.SaveDataDetailCOSubitem(bolIsNew, drSelectedCO.Item("SCID"), New VO.SalesContractDetConfirmationOrder With
                                                    {
                                                        .ID = strID,
                                                        .SCID = drSelectedCO.Item("SCID"),
                                                        .CODetailID = strCODetailID,
                                                        .GroupID = drSelectedCO.Item("GroupID"),
                                                        .ItemID = intItemID,
                                                        .Quantity = txtQuantity.Value,
                                                        .Weight = txtWeight.Value,
                                                        .TotalWeight = txtTotalWeight.Value,
                                                        .UnitPrice = txtUnitPrice.Value,
                                                        .TotalPrice = txtTotalPrice.Value,
                                                        .Remarks = txtRemarks.Text.Trim,
                                                        .LevelItem = intLevelItem,
                                                        .ParentID = drSelectedCO.Item("ID"),
                                                        .LocationID = drSelectedCO.Item("LocationID"),
                                                        .PCDetailID = strPCDetailID
                                                    })
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraSalesContractDetItemCOSubItemVer2
        With frmDetail
            .pubParentID = drSelectedCO.Item("CODetailID")
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookUpGet Then
                If .pubLUdtRow.Count > 1 And bolIsNew Then
                    Dim listSCCO As New List(Of VO.SalesContractDetConfirmationOrder)
                    For Each dr As DataRow In .pubLUdtRow
                        If dr.Item("UnitPrice") <= 0 Then
                            UI.usForm.frmMessageBox("Harga harus lebih besar dari 0")
                            Exit Sub
                        ElseIf dr.Item("Weight") <= 0 Then
                            UI.usForm.frmMessageBox("Berat harus lebih besar dari 0")
                            Exit Sub
                        End If
                        strCODetailID = .pubLUdtRow.First.Item("CODetailID")
                        txtOrderNumberSupplier.Text = .pubLUdtRow.First.Item("OrderNumberSupplier")
                        intItemID = .pubLUdtRow.First.Item("ItemID")
                        cboItemType.SelectedValue = .pubLUdtRow.First.Item("ItemTypeID")
                        txtItemCode.Text = .pubLUdtRow.First.Item("ItemCode")
                        txtItemName.Text = .pubLUdtRow.First.Item("ItemName")
                        cboItemSpecification.SelectedValue = .pubLUdtRow.First.Item("ItemSpecificationID")
                        txtThick.Value = .pubLUdtRow.First.Item("Thick")
                        txtWidth.Value = .pubLUdtRow.First.Item("Width")
                        txtLength.Value = .pubLUdtRow.First.Item("Length")
                        txtWeight.Value = .pubLUdtRow.First.Item("Weight")
                        txtMaxTotalWeight.Value = .pubLUdtRow.First.Item("TotalWeight")
                        txtUnitPrice.Value = .pubLUdtRow.First.Item("UnitPrice")
                        txtQuantity.Value = .pubLUdtRow.First.Item("Quantity")
                        intLevelItem = .pubLUdtRow.First.Item("LevelItem")
                        strPCDetailID = .pubLUdtRow.First.Item("PCDetailID")

                        listSCCO.Add(New VO.SalesContractDetConfirmationOrder With
                                        {
                                            .ID = strID,
                                            .SCID = drSelectedCO.Item("SCID"),
                                            .CODetailID = dr.Item("CODetailID"),
                                            .GroupID = drSelectedCO.Item("GroupID"),
                                            .ItemID = dr.Item("ItemID"),
                                            .Quantity = dr.Item("Quantity"),
                                            .Weight = dr.Item("Weight"),
                                            .TotalWeight = dr.Item("Quantity") * dr.Item("Weight"),
                                            .UnitPrice = dr.Item("UnitPrice"),
                                            .TotalPrice = dr.Item("UnitPrice") * dr.Item("TotalWeight"),
                                            .Remarks = "",
                                            .LevelItem = dr.Item("LevelItem"),
                                            .ParentID = drSelectedCO.Item("ID"),
                                            .LocationID = drSelectedCO.Item("LocationID"),
                                            .PCDetailID = dr.Item("PCDetailID")
                                        })

                        Try
                            BL.SalesContract.SaveDataDetailCOSubitemMultiple(drSelectedCO.Item("SCID"), listSCCO)
                            Me.Close()
                        Catch ex As Exception
                            UI.usForm.frmMessageBox(ex.Message)
                        End Try
                    Next
                Else
                    strCODetailID = .pubLUdtRow.First.Item("CODetailID")
                    txtOrderNumberSupplier.Text = .pubLUdtRow.First.Item("OrderNumberSupplier")
                    intItemID = .pubLUdtRow.First.Item("ItemID")
                    cboItemType.SelectedValue = .pubLUdtRow.First.Item("ItemTypeID")
                    txtItemCode.Text = .pubLUdtRow.First.Item("ItemCode")
                    txtItemName.Text = .pubLUdtRow.First.Item("ItemName")
                    cboItemSpecification.SelectedValue = .pubLUdtRow.First.Item("ItemSpecificationID")
                    txtThick.Value = .pubLUdtRow.First.Item("Thick")
                    txtWidth.Value = .pubLUdtRow.First.Item("Width")
                    txtLength.Value = .pubLUdtRow.First.Item("Length")
                    txtWeight.Value = .pubLUdtRow.First.Item("Weight")
                    txtMaxTotalWeight.Value = .pubLUdtRow.First.Item("TotalWeight")
                    txtUnitPrice.Value = .pubLUdtRow.First.Item("UnitPrice")
                    txtQuantity.Value = .pubLUdtRow.First.Item("Quantity")
                    intLevelItem = .pubLUdtRow.First.Item("LevelItem")
                    strPCDetailID = .pubLUdtRow.First.Item("PCDetailID")
                    txtWeight.Focus()
                    txtRemarks.Text = ""
                    bolIsAutoSearch = False
                End If
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
        intLevelItem = 0
        txtRemarks.Text = ""
        strPCDetailID = ""
        txtItemCode.Focus()
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemCOSubVer2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemCOSubVer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class