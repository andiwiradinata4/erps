Public Class frmTraSalesContractDetItemVer2RemapItem

#Region "Property"

    Private frmParent As frmTraSalesContractDetVer2
    Private strID As String = ""
    Private strIDCOItem As String = ""
    Private strCODetailID As String = ""
    Private strORDetailID As String = ""
    Private strSCID As String = ""
    Private intItemID As Integer = 0
    Private intItemIDCOItem As Integer = 0
    Private intGroupID As Integer = 0
    Private intLocationID As Integer = 0
    Private clsCS As VO.CS
    Private dtParentItem As New DataTable
    Private dtParentItemCO As New DataTable
    Private drSelectedItem As DataRow
    Private intLevelItem As Integer = 0
    Private bolIsSave As Boolean
    Private clsSCDetOld As New VO.SalesContractDet
    Private clsSCDetNew As New VO.SalesContractDet
    Private clsSCCOOld As New VO.SalesContractDetConfirmationOrder
    Private clsSCCONew As New VO.SalesContractDetConfirmationOrder
    Private intBPID As Integer

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

    Public WriteOnly Property pubSCID As String
        Set(value As String)
            strSCID = value
        End Set
    End Property

    Public WriteOnly Property pubDataRowSelected As DataRow
        Set(value As DataRow)
            drSelectedItem = value
        End Set
    End Property

    Public WriteOnly Property pubDataParentItem As DataTable
        Set(value As DataTable)
            dtParentItem = value
        End Set
    End Property

    Public WriteOnly Property pubDataParentItemCO As DataTable
        Set(value As DataTable)
            dtParentItemCO = value
        End Set
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            '# SC Item
            strID = drSelectedItem.Item("ID")
            strORDetailID = drSelectedItem.Item("ORDetailID")
            txtRequestNumber.Text = drSelectedItem.Item("RequestNumber")
            intGroupID = drSelectedItem.Item("GroupID")
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
            txtQuantity.Value = drSelectedItem.Item("Quantity")
            txtRemarks.Text = drSelectedItem.Item("Remarks")

            '# CO Item
            For Each drSelectedItemCO As DataRow In dtParentItemCO.Rows
                If drSelectedItemCO.Item("GroupID") = intGroupID Then
                    strIDCOItem = drSelectedItemCO.Item("ID")
                    strCODetailID = drSelectedItemCO.Item("CODetailID")
                    txtCONumber.Text = drSelectedItemCO.Item("CONumber")
                    txtOrderNumberSupplier.Text = drSelectedItemCO.Item("OrderNumberSupplier")
                    intItemIDCOItem = drSelectedItemCO.Item("ItemID")
                    txtItemCodeCO.Text = drSelectedItemCO.Item("ItemCode")
                    txtItemNameCO.Text = drSelectedItemCO.Item("ItemName")
                    cboItemTypeCO.SelectedValue = drSelectedItemCO.Item("ItemTypeID")
                    cboItemSpecificationCO.SelectedValue = drSelectedItemCO.Item("ItemSpecificationID")
                    txtThickCO.Value = drSelectedItemCO.Item("Thick")
                    txtWidthCO.Value = drSelectedItemCO.Item("Width")
                    txtLengthCO.Value = drSelectedItemCO.Item("Length")
                    txtWeightCO.Value = drSelectedItemCO.Item("Weight")
                    txtMaxTotalWeightCO.Value = drSelectedItemCO.Item("MaxTotalWeight")
                    txtUnitPriceCO.Value = drSelectedItemCO.Item("UnitPrice")
                    txtQuantityCO.Value = drSelectedItemCO.Item("Quantity")
                    txtRemarksCO.Text = drSelectedItemCO.Item("Remarks")
                    intLocationID = drSelectedItemCO.Item("LocationID")
                    txtBPLocationAddress.Text = drSelectedItemCO.Item("DeliveryAddress")

                    clsSCCOOld = New VO.SalesContractDetConfirmationOrder
                    clsSCCOOld.SCID = strSCID
                    clsSCCOOld.ID = strIDCOItem
                    clsSCCOOld.CODetailID = strCODetailID
                    clsSCCOOld.GroupID = intGroupID
                    clsSCCOOld.ItemID = intItemIDCOItem

                    clsSCCONew = New VO.SalesContractDetConfirmationOrder
                    clsSCCONew.SCID = strSCID
                    clsSCCONew.ID = strIDCOItem
                    clsSCCONew.CODetailID = strCODetailID
                    clsSCCONew.GroupID = intGroupID
                    clsSCCONew.ItemID = intItemIDCOItem
                    clsSCCONew.LocationID = intLocationID
                    Exit For
                End If
            Next

            clsSCDetOld = New VO.SalesContractDet
            clsSCDetOld.SCID = strSCID
            clsSCDetOld.ID = strID
            clsSCDetOld.ORDetailID = strORDetailID
            clsSCDetOld.GroupID = intGroupID
            clsSCDetOld.ItemID = intItemID
            clsSCDetOld.OrderNumberSupplier = drSelectedItem.Item("OrderNumberSupplier")

            clsSCDetNew = New VO.SalesContractDet
            clsSCDetNew.SCID = strSCID
            clsSCDetNew.ID = strID
            clsSCDetNew.ORDetailID = strORDetailID
            clsSCDetNew.GroupID = intGroupID
            clsSCDetNew.ItemID = intItemID
            clsSCDetNew.OrderNumberSupplier = txtOrderNumberSupplier.Text.Trim
            clsSCDetNew.OrderNumberSupplier = drSelectedItem.Item("OrderNumberSupplier")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If txtTotalWeightCO.Value <= 0 Then
            UI.usForm.frmMessageBox("Total Berat Item Konfirmasi Pesanan harus lebih besar dari 0")
            txtWeightCO.Focus()
            Exit Sub
            'ElseIf clsSCDetOld.OrderNumberSupplier.Trim <> txtOrderNumberSupplier.Text.Trim Then
            '    UI.usForm.frmMessageBox("Fitur ini tidak dapat mendukung perubahan Nomor Pesanan Pemasok")
            '    txtOrderNumberSupplier.Focus()
            '    Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Anda yakin ingin simpan data ini?") Then Exit Sub

        Dim drMaxGroupID() As DataRow = dtParentItem.Select("GroupID>0", "GroupID DESC")
        intGroupID = drMaxGroupID.First().Item("GroupID") + 1

        clsSCDetNew.GroupID = intGroupID
        clsSCDetNew.OrderNumberSupplier = txtOrderNumberSupplier.Text.Trim
        clsSCDetNew.UnitPriceHPP = txtUnitPriceHPP.Value

        clsSCCONew.CODetailID = strCODetailID
        clsSCCONew.GroupID = intGroupID
        clsSCCONew.ItemID = intItemIDCOItem
        clsSCCONew.Quantity = txtQuantityCO.Value
        clsSCCONew.Weight = txtWeightCO.Value
        clsSCCONew.TotalWeight = txtTotalWeightCO.Value
        clsSCCONew.UnitPrice = txtUnitPriceCO.Value
        clsSCCONew.TotalPrice = txtTotalPriceCO.Value
        clsSCCONew.Remarks = txtRemarksCO.Text.Trim
        clsSCCONew.LevelItem = intLevelItem
        clsSCCONew.ParentID = ""
        clsSCCONew.LocationID = intLocationID
        clsSCCONew.PCDetailID = ""
        clsSCCONew.OrderNumberSupplier = txtOrderNumberSupplier.Text.Trim

        Try
            BL.SalesContract.RemapSCDetailItem(clsSCDetOld, clsSCDetNew, clsSCCOOld, clsSCCONew)
            UI.usForm.frmMessageBox("Data berhasil diubah")
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvChooseBPLocation()
        Dim frmDetail As New frmMstBusinessPartnerLocation
        With frmDetail
            .pubIsLookUp = True
            .pubBPID = intBPID
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intLocationID = .pubLUdtRow.Item("ID")
                txtBPLocationAddress.Text = .pubLUdtRow.Item("Address")
            End If
        End With
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraConfirmationOrderOutstandingSalesContractVer1
        With frmDetail
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookUpGet Then
                txtCONumber.Text = .pubLUdtRow.Item("CONumber")
                strCODetailID = .pubLUdtRow.Item("ID")
                txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                intItemIDCOItem = .pubLUdtRow.Item("ItemID")
                txtItemCodeCO.Text = .pubLUdtRow.Item("ItemCode")
                txtItemNameCO.Text = .pubLUdtRow.Item("ItemName")
                txtThickCO.Value = .pubLUdtRow.Item("Thick")
                txtWidthCO.Value = .pubLUdtRow.Item("Width")
                txtLengthCO.Value = .pubLUdtRow.Item("Length")
                txtWeightCO.Value = .pubLUdtRow.Item("Weight")
                txtMaxTotalWeightCO.Value = .pubLUdtRow.Item("TotalWeight")
                txtUnitPriceHPP.Value = .pubLUdtRow.Item("UnitPrice")
                txtUnitPriceCO.Value = .pubLUdtRow.Item("UnitPrice")
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value

        txtTotalWeightCO.Value = txtWeightCO.Value * txtQuantityCO.Value
        txtTotalPriceCO.Value = txtUnitPriceCO.Value * txtTotalWeightCO.Value
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemVer2RemapItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemVer2RemapItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnCO_Click(sender As Object, e As EventArgs) Handles btnCO.Click
        prvChooseItem()
    End Sub

    Private Sub btnBPLocation_Click(sender As Object, e As EventArgs) Handles btnBPLocation.Click
        prvChooseBPLocation()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged,
        txtUnitPriceCO.ValueChanged, txtQuantityCO.ValueChanged, txtWeightCO.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class