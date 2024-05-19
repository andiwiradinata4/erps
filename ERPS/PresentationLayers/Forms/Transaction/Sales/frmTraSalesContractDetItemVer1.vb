Imports DevExpress.XtraGrid

Public Class frmTraSalesContractDetItemVer1

#Region "Property"

    Private frmParent As frmTraSalesContractDetVer1
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private strORDetailID As String
    Private intBPID As Integer = 0
    Private intItemID As Integer = 0
    Private intPos As Integer = 0
    Private intGroupID As Integer = 0
    Private clsCS As VO.CS
    Private dtParentCOItem As New DataTable
    Private dtParentCOSubItem As New DataTable
    Private dtParentItem As New DataTable
    Private dtParentSubItem As New DataTable
    Private drSelectedItem As DataRow
    Private dtCO As New DataTable
    Private dtCOSub As New DataTable
    Private bolIsAutoSearch As Boolean
    Private intLevelItem As Integer = 0

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubTableParentCOItem As DataTable
        Set(value As DataTable)
            dtParentCOItem = value
        End Set
    End Property

    Public WriteOnly Property pubTableParentCOSubItem As DataTable
        Set(value As DataTable)
            dtParentCOSubItem = value
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

    Public WriteOnly Property pubIsAutoSearch As Boolean
        Set(value As Boolean)
            bolIsAutoSearch = value
        End Set
    End Property

    Public WriteOnly Property pubLevelItem As Integer
        Set(value As Integer)
            intLevelItem = value
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
        UI.usForm.SetGrid(grdItemCOView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemCOView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemCOView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemCOView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemCOView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "Quantity", "Quantity", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemCOView, "Weight", "Weight", 100, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdItemCOView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)

        UI.usForm.SetGrid(grdSubItemCOView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemName", "Nama Barang", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "Thick", "Tebal", 70, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "Width", "Lebar", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemCOView, "Length", "Panjang", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemTypeName", "Tipe", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "Quantity", "Quantity", 150, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemCOView, "Weight", "Weight", 70, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdSubItemCOView, "TotalWeight", "Total Berat", 250, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdSubItemCOView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "TotalPrice", "Total Harga", 250, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboItemType, BL.ItemType.ListDataForCombo, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, BL.ItemSpecification.ListDataForCombo, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvQuery()
        grdItemCO.DataSource = dtCO
        prvSumGrid()
        prvSetButtonItemConfirmationOrder()
    End Sub

    Private Sub prvSumGrid()
        '# Confirmation Order
        Dim SumTotalQuantityOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdItemCOView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemCOView.Columns("Quantity").Summary.Add(SumTotalQuantityOrder)
        End If

        If grdItemCOView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemCOView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightOrder)
        End If

        If grdItemCOView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemCOView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceOrder)
        End If
        grdItemCOView.BestFitColumns()

        For i As Integer = 0 To grdItemCOView.RowCount - 1
            grdItemCOView.ExpandMasterRow(i, "SubItem")
        Next

        '# Confirmation Order
        Dim SumTotalQuantitySubItemOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightSubItemOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceSubItemOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubItemCOView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("Quantity").Summary.Add(SumTotalQuantitySubItemOrder)
        End If

        If grdSubItemCOView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightSubItemOrder)
        End If

        If grdSubItemCOView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceSubItemOrder)
        End If
        grdSubItemCOView.BestFitColumns()
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            dtCO = dtParentCOItem.Clone
            Me.Cursor = Cursors.Default
            If bolIsNew Then
                prvClear()
            Else
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
            End If

            dtCO = dtParentCOItem.Clone
            For Each dr As DataRow In dtParentCOItem.Rows
                If dr.Item("GroupID") = intGroupID Then dtCO.ImportRow(dr)
            Next
            dtCO.AcceptChanges()

            dtCOSub = dtParentCOSubItem.Clone
            For Each dr As DataRow In dtParentCOSubItem.Rows
                If dr.Item("GroupID") = intGroupID Then dtCOSub.ImportRow(dr)
            Next
            dtCOSub.AcceptChanges()

            Dim dsMain As New DataSet
            dsMain.Tables.Add(dtCO)
            dsMain.Tables.Add(dtCOSub)
            dsMain.Relations.Add("SubItem", dtCO.Columns.Item("ID"), dtCOSub.Columns.Item("ParentID"))
            grdItemCO.DataSource = dtCO
            grdItemCO.LevelTree.Nodes.Add("SubItem", grdSubItemCOView)
            grdItemCO.Refresh()
            prvCalculate()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtRequestNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih barang terlebih dahulu")
            txtRequestNumber.Focus()
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
        ElseIf grdItemCOView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Pilih konfirmasi pesanan terlebih dahulu")
            grdItemCOView.Focus()
            Exit Sub
        ElseIf txtMaxTotalWeight.Value < txtTotalWeight.Value Then
            If Not UI.usForm.frmAskQuestion("Total Berat melebihi Maks. Total Berat, Apakah anda yakin ingin melanjutkannya?") Then Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtParentItem.NewRow
            intGroupID = dtParentItem.Rows.Count + 1
            With drItem
                .BeginEdit()
                .Item("ID") = strID
                .Item("SCID") = ""
                .Item("ORDetailID") = strORDetailID
                .Item("RequestNumber") = txtRequestNumber.Text.Trim
                .Item("GroupID") = intGroupID
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
                .Item("OrderNumberSupplier") = grdItemCOView.GetRowCellValue(0, "OrderNumberSupplier")
                .Item("ParentID") = ""
                .Item("LevelItem") = 0
                .EndEdit()
            End With
            dtParentItem.Rows.Add(drItem)
        Else
            For Each dr As DataRow In dtParentItem.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("SCID") = ""
                        .Item("ORDetailID") = strORDetailID
                        .Item("RequestNumber") = txtRequestNumber.Text.Trim
                        .Item("GroupID") = intGroupID
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
                        .Item("OrderNumberSupplier") = grdItemCOView.GetRowCellValue(0, "OrderNumberSupplier")
                        .Item("ParentID") = ""
                        .Item("LevelItem") = 0
                        .EndEdit()
                    End If
                End With
            Next
        End If
        dtParentItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()

        '# Delete Sub Item Exists with Parent ID
        For Each dr As DataRow In dtParentSubItem.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtParentSubItem.AcceptChanges()

        '# Delete Confirmation Order Item
        For Each dr As DataRow In dtParentCOItem.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtParentCOItem.AcceptChanges()
        dtParentCOSubItem.AcceptChanges()

        '# Import Confirmation Order
        For Each dr As DataRow In dtCO.Rows
            dr.BeginEdit()
            dr.Item("GroupID") = intGroupID
            dr.EndEdit()
            dtParentCOItem.ImportRow(dr)
        Next
        dtParentCOItem.AcceptChanges()

        '# Import Confirmation Order Sub Item
        For Each dr As DataRow In dtCOSub.Rows
            dr.BeginEdit()
            dr.Item("GroupID") = intGroupID
            dr.EndEdit()
            dtParentCOSubItem.ImportRow(dr)
        Next
        dtParentCOSubItem.AcceptChanges()

        '# Save Sub Item Parent
        For Each dr As DataRow In dtParentCOSubItem.Rows
            If dr.Item("GroupID") = intGroupID Then
                Dim drSubItem As DataRow = dtParentSubItem.NewRow
                With drSubItem
                    .BeginEdit()
                    .Item("ID") = Guid.NewGuid.ToString
                    .Item("SCID") = ""
                    .Item("ORDetailID") = strORDetailID
                    .Item("RequestNumber") = txtRequestNumber.Text.Trim
                    .Item("GroupID") = intGroupID
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
                    .Item("MaxTotalWeight") = dr.Item("MaxTotalWeight")
                    .Item("UnitPrice") = txtUnitPrice.Value
                    .Item("TotalPrice") = txtUnitPrice.Value * dr.Item("TotalWeight")
                    .Item("Remarks") = dr.Item("Remarks")
                    .Item("OrderNumberSupplier") = dr.Item("OrderNumberSupplier")
                    .Item("LevelItem") = dr.Item("LevelItem")
                    .Item("ParentID") = strID
                    .Item("UnitPriceHPP") = dr.Item("UnitPrice")
                    .EndEdit()
                End With
                dtParentSubItem.Rows.Add(drSubItem)
            End If
        Next
        dtParentSubItem.AcceptChanges()

        frmParent.grdItemCOView.BestFitColumns()
        Me.Close()
    End Sub

    Private Sub prvClear()
        txtRequestNumber.Text = ""
        txtRequestNumber.Focus()
        strORDetailID = ""
        intGroupID = 0
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
        Dim frmDetail As New frmTraOrderRequestOutstandingItemVer1
        With frmDetail
            .pubParentItem = dtParentItem
            .pubBPID = intBPID
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookupGet Then
                txtRequestNumber.Text = .pubLUdtRow.Item("OrderNumber")
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
                txtMaxTotalWeight.Value = .pubLUdtRow.Item("MaxTotalWeight")
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

        Dim decTotalWeight As Decimal = 0
        For Each dr As DataRow In dtCOSub.Rows
            decTotalWeight += dr.Item("TotalWeight")
        Next
        If decTotalWeight > 0 Then txtWeight.Value = decTotalWeight : txtTotalWeight.Value = decTotalWeight

        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
    End Sub

    Private Sub prvToolsHandles()
        Dim bolEnabled As Boolean = IIf(grdItemCOView.RowCount = 0, True, False)
        btnRequestItem.Enabled = bolEnabled
    End Sub

#Region "Confirmation Order Item"

    Private Sub prvSetButtonItemConfirmationOrder()
        Dim bolEnabled As Boolean = IIf(grdItemCOView.RowCount = 0, False, True)
        With ToolBarItemCO
            '.Buttons(cAdd).Enabled = Not bolEnabled
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvAddItemConfirmationOrder()
        If intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih permintaan barang terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim dtAllCO As DataTable = dtCO.Clone
        dtAllCO.Merge(dtCO)
        dtAllCO.Merge(dtParentCOItem)

        Dim dtAllCOSub As DataTable = dtCOSub.Clone
        dtAllCOSub.Merge(dtCOSub)
        dtAllCOSub.Merge(dtParentCOSubItem)

        Dim frmDetail As New frmTraSalesContractDetItemCOVer1
        With frmDetail
            .pubIsNew = True
            .pubID = Guid.NewGuid.ToString
            .pubTableParent = dtCO
            .pubTableParentAll = dtAllCO
            .pubTableParentSub = dtCOSub
            .pubTableParentAllSub = dtAllCOSub
            .pubCS = clsCS
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemConfirmationOrder()
            prvToolsHandles()
            prvCalculate()
            prvSumGrid()
        End With
    End Sub

    Private Sub prvEditItemConfirmationOrder()
        intPos = grdItemCOView.FocusedRowHandle
        If intPos < 0 Then Exit Sub

        Dim dtAllCO As DataTable = dtCO.Clone
        dtAllCO.Merge(dtCO)

        Dim dtAllCOSub As DataTable = dtCOSub.Clone
        dtAllCOSub.Merge(dtCOSub)

        Dim frmDetail As New frmTraSalesContractDetItemCOVer1
        With frmDetail
            .pubIsNew = False
            .pubTableParent = dtCO
            .pubTableParentAll = dtAllCO
            .pubTableParentSub = dtCOSub
            .pubTableParentAllSub = dtAllCOSub
            .pubCS = clsCS
            .pubDataRowSelected = grdItemCOView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemConfirmationOrder()
            prvToolsHandles()
            prvCalculate()
            prvSumGrid()
        End With
    End Sub

    Private Sub prvDeleteItemConfirmationOrder()
        intPos = grdItemCOView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemCOView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtCO.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtCO.AcceptChanges()
        dtCOSub.AcceptChanges()
        prvSumGrid()
        prvCalculate()
        prvToolsHandles()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemVer1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemVer1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItemCO.SetIcon(Me)
        prvSetGrid()
        prvFillForm()
        prvQuery()
        If bolIsAutoSearch Then prvChooseItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItemCO_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemCO.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItemConfirmationOrder()
            Case "Edit" : prvEditItemConfirmationOrder()
            Case "Hapus" : prvDeleteItemConfirmationOrder()
        End Select
    End Sub

    Private Sub btnRequestItem_Click(sender As Object, e As EventArgs) Handles btnRequestItem.Click
        prvChooseItem()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class