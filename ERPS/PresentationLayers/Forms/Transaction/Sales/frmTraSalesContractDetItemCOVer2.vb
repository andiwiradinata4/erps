﻿Imports DevExpress.XtraGrid
Public Class frmTraSalesContractDetItemCOVer2

#Region "Property"

    Private frmParent As frmTraSalesContractDetItemVer2
    Private dtParent As New DataTable
    Private dtParentAll As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private drSelected As DataRow
    Private strID As String = ""
    Private strCODetailID As String
    Private clsCS As VO.CS
    Private intPos As Integer
    Private bolIsAutoSearch As Boolean
    Private intBPID As Integer = 0
    Private intLocationID As Integer = 0
    Private strDeliveryAddress As String = ""
    Private drSelectedSC As DataRow

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

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubDeliveryAddress As String
        Set(value As String)
            strDeliveryAddress = value
        End Set
    End Property

    Public WriteOnly Property pubDatarowSelectedSC As DataRow
        Set(value As DataRow)
            drSelectedSC = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub


#End Region

    Private Const _
        cSave As Byte = 0, cClose As Byte = 1,
        cAdd As Byte = 0, cEdit As Byte = 1, cDelete As Byte = 2

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
    End Sub

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
                intLocationID = drSelected.Item("LocationID")
                txtBPLocationAddress.Text = drSelected.Item("DeliveryAddress")
            End If

            If Not bolIsNew Then grdItem.DataSource = BL.SalesContract.ListDataDetailCO(drSelected.Item("SCID"), drSelected.Item("CODetailID"))
            prvSumGrid()
            prvSetButtonSubItem()
            prvCalculate()
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
        ElseIf intLocationID = 0 Or txtBPLocationAddress.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih alamat pengiriman terlebih dahulu")
            txtBPLocationAddress.Focus()
            Exit Sub
        End If

        If bolIsNew Then
            Dim dr As DataRow = dtParent.NewRow
            With dr
                .BeginEdit()
                .Item("ID") = strID
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
                .Item("LevelItem") = 0
                .Item("ParentID") = ""
                .Item("LocationID") = intLocationID
                .Item("DeliveryAddress") = txtBPLocationAddress.Text.Trim
                dr.EndEdit()
                dtParent.Rows.Add(dr)
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
                        .Item("LevelItem") = 0
                        .Item("ParentID") = ""
                        .Item("LocationID") = intLocationID
                        .Item("DeliveryAddress") = txtBPLocationAddress.Text.Trim
                        .EndEdit()
                        Exit For
                    End If
                End With
            Next
        End If
        dtParent.AcceptChanges()
        frmParent.grdItemCOView.BestFitColumns()
        prvClear()
        Me.Close()
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraConfirmationOrderOutstandingSalesContractVer1
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

    Private Sub prvSumGrid()
        '# Item
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPrice As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdItemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
        End If

        If grdItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPrice)
        End If

        If grdItemView.GroupCount > 0 Then grdItemView.ExpandAllGroups()
        grdItemView.BestFitColumns(True)
    End Sub

    Private Sub prvClear()
        Dim clsBPLocation As VO.BusinessPartnerLocation = BL.BusinessPartner.GetDetailLocation(intBPID, True)
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
        intLocationID = clsBPLocation.ID
        txtBPLocationAddress.Text = clsBPLocation.Address
        txtItemCode.Focus()
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

#Region "Sub Item"

    Private Sub prvSetButtonSubItem()
        Dim bolEnable As Boolean = IIf(grdItemView.RowCount > 0, True, False)
        With ToolBarSubItem.Buttons
            .Item(cAdd).Enabled = IIf(bolIsNew, False, True)
            .Item(cEdit).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuerySubItem()
        Try
            If Not bolIsNew Then grdItem.DataSource = BL.SalesContract.ListDataDetailCO(drSelected.Item("SCID"), drSelected.Item("ID"))
            grdItemView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvSetButtonSubItem()
        End Try
    End Sub

    Private Sub prvAddSubItem()
        If intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih konfirmasi pesanan terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim frmDetail As New frmTraSalesContractDetItemCOSubVer2
        With frmDetail
            .pubIsNew = True
            .pubParentID = strID
            .pubIsAutoSearch = True
            .pubDataRowSelectedCO = drSelected
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvQuerySubItem()
            prvCalculate()
        End With
    End Sub

    Private Sub prvEditSubItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih konfirmasi pesanan terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim frmDetail As New frmTraSalesContractDetItemCOSubVer2
        With frmDetail
            .pubIsNew = False
            .pubParentID = strID
            .pubIsAutoSearch = False
            .pubDataRowSelectedCO = drSelected
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvQuerySubItem()
            prvCalculate()
        End With
    End Sub

    Private Sub prvDeleteSubItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")

        If Not UI.usForm.frmAskQuestion("Hapus data yang dipilih?") Then Exit Sub

        Try
            BL.SalesContract.DeleteDetailCOSubItem(strID, grdItemView.GetRowCellValue(intPos, "PCDetailID"))
            prvQuerySubItem()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemCOVer2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemCOVer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarSubItem.SetIcon(Me)
        prvSetGrid()
        prvFillForm()
        prvQuerySubItem()
        If bolIsAutoSearch Then prvChooseItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarSubItem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarSubItem.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddSubItem()
            Case "Edit" : prvEditSubItem()
            Case "Hapus" : prvDeleteSubItem()
        End Select
    End Sub

    Private Sub btnCO_Click(sender As Object, e As EventArgs) Handles btnCO.Click
        prvChooseItem()
    End Sub

    Private Sub btnBPLocation_Click(sender As Object, e As EventArgs) Handles btnBPLocation.Click
        prvChooseBPLocation()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class