Public Class frmTraSalesContractDetVer2SplitItem

#Region "Property"

    Private frmParent As frmTraSalesContractDetVer2
    Private strID As String = ""
    Private bolIsSave As Boolean
    Private clsData As New VO.SalesContractDet
    Private clsDataSplit As New VO.SalesContractDet
    Private clsDataCO As New VO.SalesContractDetConfirmationOrder
    Private dtSubItem As New DataTable
    Private dtSubItemMain As New DataTable
    Private dtSubItemSplit As New DataTable
    Private dtSubItemCO As New DataTable
    Private dtSubItemCOMain As New DataTable
    Private dtSubItemCOSplit As New DataTable

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
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

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            '# SC Item
            clsData = BL.SalesContract.GetDetailItem(strID)
            txtRequestNumber.Text = clsData.RequestNumber
            cboItemType.SelectedValue = clsData.ItemTypeID
            txtItemCode.Text = clsData.ItemCode
            txtItemName.Text = clsData.ItemName
            cboItemSpecification.SelectedValue = clsData.ItemSpecificationID
            txtThick.Value = clsData.Thick
            txtWidth.Value = clsData.Width
            txtLength.Value = clsData.Length
            txtWeight.Value = clsData.Weight
            txtMaxTotalWeight.Value = clsData.TotalWeight
            txtUnitPrice.Value = clsData.UnitPrice
            txtQuantity.Value = clsData.Quantity
            txtUnitPriceHPP.Value = clsData.UnitPriceHPP
            txtRemarks.Text = clsData.Remarks

            clsDataSplit = BL.SalesContract.GetDetailItem(strID)
            txtRequestNumberSplit.Text = clsDataSplit.RequestNumber
            cboItemType.SelectedValue = clsDataSplit.ItemTypeID
            txtItemCodeSplit.Text = clsDataSplit.ItemCode
            txtItemNameSplit.Text = clsDataSplit.ItemName
            cboItemSpecification.SelectedValue = clsDataSplit.ItemSpecificationID
            txtThickSplit.Value = clsDataSplit.Thick
            txtWidthSplit.Value = clsDataSplit.Width
            txtLengthSplit.Value = clsDataSplit.Length
            txtWeightSplit.Value = clsDataSplit.Weight
            txtMaxTotalWeightSplit.Value = clsDataSplit.TotalWeight
            txtUnitPriceSplit.Value = clsDataSplit.UnitPrice
            txtQuantitySplit.Value = 0
            txtUnitPriceHPPSplit.Value = clsDataSplit.UnitPriceHPP
            txtRemarksSplit.Text = clsDataSplit.Remarks

            '# Query Sub Item Sales Contract


            '# Fill Confirmation Order 
            '# Fill Confirmation Order Split
            '# Query Sub Item Purchase Contract

        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If txtTotalWeight.Value + txtTotalWeightSplit.Value <> txtMaxTotalWeight.Value Then
            UI.usForm.frmMessageBox("Total Berat Keseluruhan harus sama dengan Maks. Total Berat")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf grdSubitemView.RowCount > 0 And grdSubitemNewView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Subitem Kontrak Penjualan Belum dipindahkan")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub

        ElseIf grdSubItemCOView.RowCount > 0 And grdSubItemCOSplitView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Subitem Konfirmasi Pesanan Belum dipindahkan")
            tcHeader.SelectedTab = tpConfirmationOrder
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Anda yakin ingin simpan data ini?") Then Exit Sub

        clsData.Weight = txtWeight.Value
        clsData.Quantity = txtQuantity.Value
        clsData.TotalWeight = txtTotalWeight.Value
        clsData.TotalPrice = txtTotalPrice.Value
        clsData.Remarks = txtRemarks.Text.Trim

        clsDataSplit.Weight = txtWeightSplit.Value
        clsDataSplit.Quantity = txtQuantitySplit.Value
        clsDataSplit.TotalWeight = txtTotalWeightSplit.Value
        clsDataSplit.TotalPrice = txtTotalPriceSplit.Value
        clsDataSplit.Remarks = txtRemarksSplit.Text.Trim

        Try
            'BL.SalesContract.RemapSCDetailItem(clsSCDetOld, clsSCDetNew, clsSCCOOld, clsSCCONew)
            UI.usForm.frmMessageBox("Data berhasil diubah")
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvMoveToSplit()

    End Sub

    Private Sub prvMoveToMain()

    End Sub

    Private Sub prvMoveToSplitCO()

    End Sub

    Private Sub prvMoveToMainCO()

    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
        txtTotalWeightSplit.Value = txtWeightSplit.Value * txtQuantitySplit.Value
        txtTotalPriceSplit.Value = txtUnitPriceSplit.Value * txtTotalWeightSplit.Value
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDetVer2SplitItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        ElseIf e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpSalesContract
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpConfirmationOrder
        End If
    End Sub

    Private Sub frmTraSalesContractDetVer2SplitItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItemCO.SetIcon(Me)
        ToolBarItemCOSplit.SetIcon(Me)
        ToolBarItemSubitem.SetIcon(Me)
        ToolBarItemSubitemSplit.SetIcon(Me)
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItemSubitem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemSubitem.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Pindah" : prvMoveToSplit()
        End Select
    End Sub

    Private Sub ToolBarItemSubitemSplit_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemSubitemSplit.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Pindah" : prvMoveToMain()
        End Select
    End Sub

    Private Sub ToolBarItemCO_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemCO.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Pindah" : prvMoveToSplitCO()
        End Select
    End Sub

    Private Sub ToolBarItemCOSplit_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemCOSplit.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Pindah" : prvMoveToMainCO()
        End Select
    End Sub

    Private Sub txtValueSplit_ValueChanged(sender As Object, e As EventArgs) Handles txtWeightSplit.ValueChanged, txtQuantitySplit.ValueChanged
        prvCalculate()
    End Sub

#End Region

    
End Class