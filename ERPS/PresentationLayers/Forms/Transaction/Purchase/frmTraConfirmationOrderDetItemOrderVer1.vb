Imports DevExpress.XtraGrid

Public Class frmTraConfirmationOrderDetItemOrderVer1

#Region "Property"

    Private frmParent As frmTraConfirmationOrderDetItemVer1
    Private intBPID As Integer = 0
    Private dtParentItem As New DataTable
    Private dtParentSubItem As New DataTable
    Private dtSubItem As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private drSelectedItem As DataRow
    Private strPODetailID As String
    Private strID As String = Guid.NewGuid.ToString
    Private intPos As Integer = 0
    Private clsCS As VO.CS
    Private intLevelItem As Integer = 0
    Private bolIsAutoSearch As Boolean

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

    Public WriteOnly Property pubTableParentSubItem As DataTable
        Set(value As DataTable)
            dtParentSubItem = value
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

    Public WriteOnly Property publevelItem As Integer
        Set(value As Integer)
            intLevelItem = value
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
       cSave As Byte = 0, cClose As Byte = 1,
       cAdd As Byte = 0, cEdit As Byte = 1, cDelete As Byte = 2

    Private Sub prvSetGrid()
        '# Sub Item
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "COID", "COID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PONumber", "Nomor Pesanan", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PODetailID", "PODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "DeliveryAddress", "Alamat Pengiriman", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Weight", "Weight", 100, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "PCQuantity", "PCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "PCWeight", "PCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "DCQuantity", "DCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "DCWeight", "DCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdItemView.RowCount > 0, True, False)
        With ToolBarSubItem.Buttons
            .Item(cEdit).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
        End With
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
            If Not bolIsNew Then
                strID = drSelectedItem.Item("ID")
                txtPONumber.Text = drSelectedItem.Item("PONumber")
                strPODetailID = drSelectedItem.Item("PODetailID")
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
            End If

            dtSubItem = dtParentSubItem.Clone
            For Each dr As DataRow In dtParentSubItem.Rows
                If dr.Item("ParentID") = strID Then dtSubItem.ImportRow(dr)
            Next
            dtSubItem.AcceptChanges()
            grdItem.DataSource = dtSubItem
            prvSumGrid()
            prvSetButton()
            prvCalculate()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtPONumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih barang terlebih dahulu")
            txtPONumber.Focus()
            Exit Sub
        ElseIf txtItemCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih barang terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        ElseIf txtQuantity.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        ElseIf txtWeight.Value <= 0 Then
            UI.usForm.frmMessageBox("Berat harus lebih besar dari 0")
            txtWeight.Focus()
            Exit Sub
        ElseIf txtMaxTotalWeight.Value < txtTotalWeight.Value Then
            If Not UI.usForm.frmAskQuestion("Total Berat melebihi Maks. Total Berat, Apakah anda yakin ingin melanjutkannya?") Then Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtParentItem.NewRow
            With drItem
                .BeginEdit()
                .Item("ID") = strID
                .Item("COID") = ""
                .Item("PONumber") = txtPONumber.Text.Trim
                .Item("PODetailID") = strPODetailID
                .Item("DeliveryAddress") = ""
                .Item("OrderNumberSupplier") = ""
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
                .Item("PCQuantity") = 0
                .Item("PCWeight") = 0
                .Item("DCQuantity") = 0
                .Item("DCWeight") = 0
                .Item("Remarks") = txtRemarks.Text.Trim
                .Item("LevelItem") = 0
                .Item("ParentID") = ""
                .EndEdit()
            End With
            dtParentItem.Rows.Add(drItem)
        Else
            For Each dr As DataRow In dtParentItem.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("COID") = ""
                        .Item("PONumber") = txtPONumber.Text.Trim
                        .Item("PODetailID") = strPODetailID
                        .Item("DeliveryAddress") = ""
                        .Item("OrderNumberSupplier") = ""
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
                        .Item("PCQuantity") = 0
                        .Item("PCWeight") = 0
                        .Item("DCQuantity") = 0
                        .Item("DCWeight") = 0
                        .Item("Remarks") = txtRemarks.Text.Trim
                        .Item("LevelItem") = 0
                        .Item("ParentID") = ""
                        .EndEdit()

                        For Each drSubItem As DataRow In dtParentSubItem.Rows
                            If drSubItem.Item("ParentID") = strID Then drSubItem.Delete()
                        Next
                        dtParentSubItem.AcceptChanges()
                    End If
                End With
            Next
        End If
        dtParentItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()

        For Each dr As DataRow In dtSubItem.Rows
            Dim drSubItem As DataRow = dtParentSubItem.NewRow
            With drSubItem
                .BeginEdit()
                .Item("ID") = Guid.NewGuid.ToString
                .Item("COID") = ""
                .Item("PONumber") = txtPONumber.Text.Trim
                .Item("PODetailID") = strPODetailID
                .Item("DeliveryAddress") = ""
                .Item("OrderNumberSupplier") = ""
                .Item("ItemID") = dr.Item("ItemID")
                .Item("ItemCode") = dr.Item("ItemCode")
                .Item("ItemName") = dr.Item("ItemName")
                .Item("Thick") = dr.Item("Thick")
                .Item("Width") = dr.Item("Width")
                .Item("Length") = dr.Item("Length")
                .Item("ItemSpecificationID") = dr.Item("ItemSpecificationID")
                .Item("ItemSpecificationName") = dr.Item("ItemSpecificationName")
                .Item("ItemTypeID") = dr.Item("ItemTypeID")
                .Item("ItemTypeName") = dr.Item("ItemTypeName")
                .Item("Quantity") = dr.Item("Quantity")
                .Item("Weight") = dr.Item("Weight")
                .Item("TotalWeight") = dr.Item("TotalWeight")
                .Item("MaxTotalWeight") = 0
                .Item("UnitPrice") = dr.Item("UnitPrice")
                .Item("TotalPrice") = dr.Item("TotalPrice")
                .Item("PCQuantity") = 0
                .Item("PCWeight") = 0
                .Item("DCQuantity") = 0
                .Item("DCWeight") = 0
                .Item("Remarks") = dr.Item("Remarks")
                .Item("LevelItem") = dr.Item("LevelItem")
                .Item("ParentID") = dr.Item("ParentID")
                .EndEdit()
            End With
            dtParentSubItem.Rows.Add(drSubItem)
        Next
        dtParentSubItem.AcceptChanges()
        prvClear()
        Me.Close()
    End Sub

    Private Sub prvClear()
        strID = ""
        txtPONumber.Text = ""
        txtPONumber.Focus()
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
        txtMaxTotalWeight.Value = 0
        txtUnitPrice.Value = 0
        txtQuantity.Value = 0
        txtTotalWeight.Value = 0
        txtTotalPrice.Value = 0
        txtRemarks.Text = ""
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraConfirmationOrderDetItemOrderOutstandingVer1
        With frmDetail
            .pubParentItem = frmParent.pubGetAllData
            .pubBPID = intBPID
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookUpGet Then
                txtPONumber.Text = .pubLUdtRow.Item("PONumber")
                strPODetailID = .pubLUdtRow.Item("ID")
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
                txtQuantity.Focus()
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

#Region "Sub Item"

    Private Sub prvAddSubItem()
        Dim frmDetail As New frmTraConfirmationOrderDetItemOrderSubItem
        With frmDetail
            .pubIsNew = True
            .pubParentID = strID
            .pubItemLevel = 1
            .pubTableParentSubItem = dtSubItem
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButton()
        End With
    End Sub

    Private Sub prvEditSubItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraConfirmationOrderDetItemOrderSubItem
        With frmDetail
            .pubIsNew = False
            .pubParentID = strID
            .pubItemLevel = 1
            .pubTableParentSubItem = dtSubItem
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButton()
        End With
    End Sub

    Private Sub prvDeleteSubItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtSubItem.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtSubItem.AcceptChanges()
        prvSetButton()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraConfirmationOrderDetItemOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraConfirmationOrderDetItemOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarSubItem.SetIcon(Me)
        prvSetGrid()
        prvFillForm()
        '# Control Subitem in Purchase Contract
        ToolBarSubItem.Visible = True

        If bolIsAutoSearch Then prvChooseItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarSubItem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarSubItem.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddSubItem()
            Case "Edit" : prvEditSubItem()
            Case "Hapus" : prvDeleteSubItem()
        End Select
    End Sub

    Private Sub btnPO_Click(sender As Object, e As EventArgs) Handles btnPO.Click
        prvChooseItem()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class