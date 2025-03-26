Imports DevExpress.XtraGrid
Public Class frmTraSalesContractDetItemVer2

#Region "Property"

    Private frmParent As frmTraSalesContractDetVer2
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private strORDetailID As String
    Private intBPID As Integer = 0
    Private intItemID As Integer = 0
    Private intPos As Integer = 0
    Private intGroupID As Integer = 0
    Private clsCS As VO.CS
    Private dtParentCOItem As New DataTable
    Private dtParentItem As New DataTable
    Private drSelectedItem As DataRow
    Private dtCO As New DataTable
    Private bolIsAutoSearch As Boolean
    Private intLevelItem As Integer = 0
    Private bolIsNeedRefresh As Boolean
    Private strSCID As String = ""

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

    Public WriteOnly Property pubLevelItem As Integer
        Set(value As Integer)
            intLevelItem = value
        End Set
    End Property

    Public ReadOnly Property pubIsNeedRefresh As Boolean
        Get
            Return bolIsNeedRefresh
        End Get
    End Property

    Public WriteOnly Property pubSCID As String
        Set(value As String)
            strSCID = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cAdd As Byte = 0, cEdit As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3, cChangeItem As Byte = 4, cAddAdditional As Byte = 5

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
        UI.usForm.SetGrid(grdItemCOView, "LocationID", "LocationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "DeliveryAddress", "Alamat Pengiriman", 100, UI.usDefGrid.gString)
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

        '# SC Detail
        UI.usForm.SetGrid(grdSubitemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemView, "ORDetailID", "ORDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemView, "RequestNumber", "Nomor Permintaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemView, "Quantity", "Quantity", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemView, "Weight", "Weight", 100, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdSubitemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemView, "IsIgnoreValidationPayment", "Set Pengiriman", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdSubitemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemView, "UnitPriceHPP", "UnitPriceHPP", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdSubitemView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
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

        '# Sub Item
        Dim SumTotalQuantitySubItemCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightSubItemCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceSubItemCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubItemCOView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("Quantity").Summary.Add(SumTotalQuantitySubItemCO)
        End If

        If grdSubItemCOView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightSubItemCO)
        End If

        If grdSubItemCOView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceSubItemCO)
        End If
        grdSubItemCOView.BestFitColumns()


        '# Sub Item
        Dim SumTotalQuantitySubItemSC As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightSubItemSC As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceSubItemSC As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubitemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubitemView.Columns("Quantity").Summary.Add(SumTotalQuantitySubItemSC)
        End If

        If grdSubitemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubitemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightSubItemSC)
        End If

        If grdSubitemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubitemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceSubItemSC)
        End If
        grdSubitemView.BestFitColumns()

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
            grdItemCO.DataSource = dtCO
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
        ElseIf txtTotalWeight.Value <> grdItemCOView.GetRowCellValue(0, "TotalWeight") Then
            UI.usForm.frmMessageBox("Total Berat Permintaan Pesanan harus sama dengan Total Berat Konfirmasi Pesanan")
            txtTotalWeight.Focus()
            Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtParentItem.NewRow
            Dim drMax() As DataRow = dtParentItem.Select("GroupID>0", "GroupID DESC")
            If drMax.Count > 0 Then intGroupID = drMax.First().Item("GroupID") + 1 Else intGroupID = dtParentItem.Rows.Count + 1
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
                .Item("UnitPriceHPP") = txtUnitPriceHPP.Value
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
                        .Item("UnitPriceHPP") = txtUnitPriceHPP.Value
                        .EndEdit()
                    End If
                End With
            Next
        End If
        dtParentItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()

        '# Delete Exists Row
        For Each dr As DataRow In dtParentCOItem.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtParentCOItem.AcceptChanges()

        '# Import Confirmation Order
        For Each dr As DataRow In dtCO.Rows
            dr.BeginEdit()
            dr.Item("GroupID") = intGroupID
            dr.EndEdit()
            dtParentCOItem.ImportRow(dr)
        Next
        dtParentCOItem.AcceptChanges()
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
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
        For i As Integer = 0 To grdItemCOView.RowCount - 1
            txtUnitPriceHPP.Value = grdItemCOView.GetRowCellValue(i, "UnitPrice")
            Exit For
        Next
    End Sub

    Private Sub prvToolsHandles()
        Dim bolEnabled As Boolean = IIf(grdItemCOView.RowCount = 0, True, False)
        btnRequestItem.Enabled = bolEnabled
        ToolBarItemCO.Buttons(cAdd).Enabled = bolEnabled
    End Sub

#Region "Confirmation Order Item"

    Private Sub prvSetButtonItemConfirmationOrder()
        Dim bolEnabled As Boolean = IIf(grdItemCOView.RowCount = 0, False, True)
        With ToolBarItemCO
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
            .Buttons(cChangeItem).Enabled = IIf(bolIsNew, False, bolEnabled)
            .Buttons(cAddAdditional).Enabled = IIf(bolIsNew, False, Not bolEnabled)
            prvToolsHandles()
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
        For Each dr As DataRow In dtAllCO.Rows
            Dim drSelected() As DataRow = dtParentCOItem.Select("ID='" & dr.Item("ID") & "'")
            If drSelected.Count > 0 Then dr.Delete()
        Next
        dtAllCO.AcceptChanges()
        dtAllCO.Merge(dtParentCOItem)

        Dim frmDetail As New frmTraSalesContractDetItemCOVer2
        With frmDetail
            .pubIsNew = True
            .pubID = Guid.NewGuid.ToString
            .pubTableParent = dtCO
            .pubTableParentAll = dtAllCO
            .pubCS = clsCS
            .pubIsAutoSearch = True
            .pubBPID = intBPID
            .pubDatarowSelectedSC = drSelectedItem
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

        Dim frmDetail As New frmTraSalesContractDetItemCOVer2
        With frmDetail
            .pubIsNew = False
            .pubTableParent = dtCO
            .pubTableParentAll = dtAllCO
            .pubCS = clsCS
            .pubDataRowSelected = grdItemCOView.GetDataRow(intPos)
            .pubBPID = intBPID
            .pubDatarowSelectedSC = drSelectedItem
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

        For Each dr As DataRow In dtParentCOItem.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtParentCOItem.AcceptChanges()

        prvSumGrid()
        prvCalculate()
        prvToolsHandles()
    End Sub

    Private Sub prvChangeItemConfirmationOrder()
        intPos = grdItemCOView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemCOView.GetRowCellValue(intPos, "ID")
        Dim frmDetail As New frmTraSalesContractDetItemVer2ChangeItem
        With frmDetail
            .pubDatRowSelected = grdItemCOView.GetDataRow(intPos)
            .pubTotalWeight = grdItemCOView.GetRowCellValue(intPos, "TotalWeight")
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            If .pubIsSave Then bolIsNeedRefresh = True : Me.Close()
        End With
    End Sub

    Private Sub prvAddItemConfirmationOrderAdditional()
        If intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih permintaan barang terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim dtAllCO As DataTable = dtCO.Clone
        dtAllCO.Merge(dtCO)
        For Each dr As DataRow In dtAllCO.Rows
            Dim drSelected() As DataRow = dtParentCOItem.Select("ID='" & dr.Item("ID") & "'")
            If drSelected.Count > 0 Then dr.Delete()
        Next
        dtAllCO.AcceptChanges()
        dtAllCO.Merge(dtParentCOItem)

        Dim frmDetail As New frmTraSalesContractDetItemCOVer2AddAdditional
        With frmDetail
            .pubID = Guid.NewGuid.ToString
            .pubTableParentAll = dtAllCO
            .pubCS = clsCS
            .pubIsAutoSearch = True
            .pubBPID = intBPID
            .pubSCID = strSCID
            .pubGroupID = intGroupID
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            If .pubIsSave Then bolIsNeedRefresh = True : Me.Close()
        End With
    End Sub

#End Region

#Region "Sub Item"

    Private Sub prvQuerySubItem()
        Try
            If Not bolIsNew Then grdSubitem.DataSource = BL.SalesContract.ListDataDetail(drSelectedItem.Item("SCID"), strID)
            grdSubitemView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvSumGrid()
            prvSetButtonSubitem()
        End Try
    End Sub

    Private Sub prvSetButtonSubitem()
        Dim bolEnable As Boolean = IIf(grdSubitemView.RowCount > 0, True, False)
        With ToolBarItemSubitem.Buttons
            .Item(cAdd).Enabled = IIf(bolIsNew Or grdItemCOView.RowCount = 0, False, True)
            .Item(cEdit).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvAddSubItem()
        If grdItemCOView.RowCount < 0 Then
            UI.usForm.frmMessageBox("Pilih konfirmasi pesanan terlebih dahulu")
            Exit Sub
        ElseIf intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih item terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim frmDetail As New frmTraSalesContractDetItemVer1SubItem
        With frmDetail
            .pubIsNew = True
            .pubUnitPriceHPP = grdItemCOView.GetRowCellValue(0, "UnitPrice")
            .pubRowParentItem = drSelectedItem
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItemConfirmationOrder()
            prvQuerySubItem()
            prvCalculate()
        End With
    End Sub

    Private Sub prvEditSubItem()
        intPos = grdSubitemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If grdItemCOView.RowCount < 0 Then
            UI.usForm.frmMessageBox("Pilih konfirmasi pesanan terlebih dahulu")
            Exit Sub
        ElseIf intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih item terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim frmDetail As New frmTraSalesContractDetItemVer1SubItem
        With frmDetail
            .pubIsNew = False
            .pubUnitPriceHPP = grdItemCOView.GetRowCellValue(0, "UnitPrice")
            .pubRowParentItem = drSelectedItem
            .pubDataRowSelected = grdSubitemView.GetDataRow(intPos)
            .pubIsAutoSearch = False
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItemConfirmationOrder()
            prvQuerySubItem()
            prvCalculate()
        End With
    End Sub

    Private Sub prvDeleteSubItem()
        intPos = grdSubitemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdSubitemView.GetRowCellValue(intPos, "ID")

        Try
            If BL.SalesContract.IsAlreadyPaymentSubitem(strID) Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                Exit Sub
            ElseIf BL.SalesContract.IsAlreadyReceiveSubitem(strID) Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pengiriman")
                Exit Sub
            End If

            If Not UI.usForm.frmAskQuestion("Hapus data yang dipilih?") Then Exit Sub

            BL.SalesContract.DeleteSubItem(strID, drSelectedItem.Item("SCID"), grdSubitemView.GetRowCellValue(intPos, "PCDetailID"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvQuerySubItem()
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemVer2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemVer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItemCO.SetIcon(Me)
        ToolBarItemSubitem.SetIcon(Me)
        prvSetGrid()
        prvFillForm()
        prvQuery()
        prvQuerySubItem()
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
            Case "Ubah Barang" : prvChangeItemConfirmationOrder()
            Case "Add Additional" : prvAddItemConfirmationOrderAdditional()
        End Select
    End Sub

    Private Sub ToolBarItemSubitem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemSubitem.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddSubItem()
            Case "Edit" : prvEditSubItem()
            Case "Hapus" : prvDeleteSubItem()
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