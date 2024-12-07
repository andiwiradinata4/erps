Public Class frmTraSalesContractDetVer2SplitItem

#Region "Property"

    Private frmParent As frmTraSalesContractDetVer2
    Private strID As String = ""
    Private strSCDetailCOID As String = ""
    Private bolIsSave As Boolean
    Private clsData As New VO.SalesContractDet
    Private clsDataSplit As New VO.SalesContractDet
    Private clsDataCO As New VO.SalesContractDetConfirmationOrder
    Private clsDataCOSplit As New VO.SalesContractDetConfirmationOrder
    Private clsARAP As New VO.ARAP
    Private dtSubItem As New DataTable
    Private dtSubItemMain As New DataTable
    Private dtSubItemSplit As New DataTable
    Private dtSubItemCO As New DataTable
    Private dtSubItemCOMain As New DataTable
    Private dtSubItemCOSplit As New DataTable

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public WriteOnly Property pubSCDetailCOID As String
        Set(value As String)
            strSCDetailCOID = value
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

    Private Sub prvSetGrid()
        '# SC Sub Item
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

        '# SC Sub Item Split
        UI.usForm.SetGrid(grdSubitemSplitView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "ORDetailID", "ORDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemSplitView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemSplitView, "RequestNumber", "Nomor Permintaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemSplitView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemSplitView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemSplitView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemSplitView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemSplitView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemSplitView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemSplitView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemSplitView, "Quantity", "Quantity", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubitemSplitView, "Weight", "Weight", 100, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdSubitemSplitView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemSplitView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemSplitView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemSplitView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubitemSplitView, "IsIgnoreValidationPayment", "Set Pengiriman", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdSubitemSplitView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubitemSplitView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "UnitPriceHPP", "UnitPriceHPP", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubitemSplitView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)

        '# CO Sub Item
        UI.usForm.SetGrid(grdSubItemCOView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdSubItemCOView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdSubItemCOView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)

        '# CO Sub Item Split
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "SCID", "SCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "OrderRequestDetailID", "OrderRequestDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemCOSplitView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
    End Sub

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

            '# SC Item Split
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

            '# Query Sub Item Sales Contract
            dtSubItem = BL.SalesContract.ListDataDetail(clsData.SCID, clsData.ID)
            dtSubItemMain = dtSubItem.Clone
            dtSubItemSplit = dtSubItem.Clone
            For Each dr As DataRow In dtSubItem.Rows
                dtSubItemMain.ImportRow(dr)
            Next
            dtSubItemMain.AcceptChanges()
            grdSubitem.DataSource = dtSubItemMain
            grdSubitemSplit.DataSource = dtSubItemSplit

            '# Fill Confirmation Order 
            clsDataCO = BL.SalesContract.GetDetailCOItem(strSCDetailCOID)
            txtCONumberCO.Text = clsDataCO.CONumber
            txtOrderNumberSupplierCO.Text = clsDataCO.OrderNumberSupplier
            cboItemTypeCO.SelectedValue = clsDataCO.ItemTypeID
            txtItemCodeCO.Text = clsDataCO.ItemCode
            txtItemNameCO.Text = clsDataCO.ItemName
            cboItemSpecificationCO.SelectedValue = clsDataCO.ItemSpecificationID
            txtThickCO.Value = clsDataCO.Thick
            txtWidthCO.Value = clsDataCO.Width
            txtLengthCO.Value = clsDataCO.Length
            txtWeightCO.Value = clsDataCO.Weight
            txtMaxTotalWeightCO.Value = clsDataCO.TotalWeight
            txtUnitPriceCO.Value = clsDataCO.UnitPrice
            txtQuantityCO.Value = clsDataCO.Quantity

            '# Fill Confirmation Order Split
            clsDataCOSplit = BL.SalesContract.GetDetailCOItem(strSCDetailCOID)
            txtCONumberCOSplit.Text = clsDataCOSplit.CONumber
            txtOrderNumberSupplierCOSplit.Text = clsDataCOSplit.OrderNumberSupplier
            cboItemTypeCOSplit.SelectedValue = clsDataCOSplit.ItemTypeID
            txtItemCodeCOSplit.Text = clsDataCOSplit.ItemCode
            txtItemNameCOSplit.Text = clsDataCOSplit.ItemName
            cboItemSpecificationCOSplit.SelectedValue = clsDataCOSplit.ItemSpecificationID
            txtThickCOSplit.Value = clsDataCOSplit.Thick
            txtWidthCOSplit.Value = clsDataCOSplit.Width
            txtLengthCOSplit.Value = clsDataCOSplit.Length
            txtWeightCOSplit.Value = clsDataCOSplit.Weight
            txtMaxTotalWeightCOSplit.Value = clsDataCOSplit.TotalWeight
            txtUnitPriceCOSplit.Value = clsDataCOSplit.UnitPrice
            txtQuantityCOSplit.Value = clsDataCOSplit.Quantity

            '# Query Sub Item Confirmation Order
            dtSubItemCO = BL.SalesContract.ListDataDetailCO(clsDataCO.SCID, clsDataCO.ID)
            dtSubItemCOMain = dtSubItemCO.Clone
            dtSubItemCOSplit = dtSubItemCO.Clone
            For Each dr As DataRow In dtSubItemCO.Rows
                dtSubItemCOMain.ImportRow(dr)
            Next
            dtSubItemCOMain.AcceptChanges()
            grdSubItemCO.DataSource = dtSubItemCOMain
            grdSubItemCOSplit.DataSource = dtSubItemCOSplit

            'clsARAP = BL.ARAP.GetDetail(
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        prvCalculate()
        If txtTotalWeight.Value + txtTotalWeightSplit.Value <> clsData.TotalWeight Then
            UI.usForm.frmMessageBox("Total Berat Keseluruhan harus sama dengan Maks. Total Berat")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf grdSubitemView.RowCount > 0 And grdSubitemSplitView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Subitem Kontrak Penjualan Belum dipindahkan")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf txtTotalWeightCO.Value + txtTotalWeightCOSplit.Value <> clsDataCO.TotalWeight Then
            UI.usForm.frmMessageBox("Total Berat Keseluruhan harus sama dengan Maks. Total Berat")
            tcHeader.SelectedTab = tpConfirmationOrder
            Exit Sub
        ElseIf grdSubItemCOView.RowCount > 0 And grdSubItemCOSplitView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Subitem Konfirmasi Pesanan Belum dipindahkan")
            tcHeader.SelectedTab = tpConfirmationOrder
            Exit Sub
        ElseIf clsARAP.TotalAmount <> txtDPAmount.Value + txtDPAmountSplit.Value Then
            UI.usForm.frmMessageBox("Total DP secara keseluruhan tidak sesuai")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf clsARAP.TotalPPN <> txtDPAmountPPN.Value + txtDPAmountPPNSplit.Value Then
            UI.usForm.frmMessageBox("Total DP PPN secara keseluruhan tidak sesuai")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf clsARAP.TotalPPH <> txtDPAmountPPH.Value + txtDPAmountPPHSplit.Value Then
            UI.usForm.frmMessageBox("Total DP PPH secara keseluruhan tidak sesuai")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Anda yakin ingin simpan data ini?") Then Exit Sub

        '# SC Item
        clsData.Weight = txtWeight.Value
        clsData.Quantity = txtQuantity.Value
        clsData.TotalWeight = txtTotalWeight.Value
        clsData.TotalPrice = txtTotalPrice.Value

        '# SC Sub Item
        For Each dr As DataRow In dtSubItemMain.Rows
            Dim cls As New VO.SalesContractDet
            cls.ID = dr.Item("ID")
            cls.SCID = dr.Item("SCID")
            cls.ORDetailID = dr.Item("ORDetailID")
            cls.OrderNumberSupplier = dr.Item("OrderNumberSupplier")
            cls.GroupID = dr.Item("GroupID")
            cls.RequestNumber = dr.Item("RequestNumber")
            cls.ItemID = dr.Item("ItemID")
            cls.ItemCode = dr.Item("ItemCode")
            cls.ItemName = dr.Item("ItemName")
            cls.Thick = dr.Item("Thick")
            cls.Width = dr.Item("Width")
            cls.Length = dr.Item("Length")
            cls.ItemSpecificationID = dr.Item("ItemSpecificationID")
            cls.ItemSpecificationName = dr.Item("ItemSpecificationName")
            cls.ItemTypeID = dr.Item("ItemTypeID")
            cls.ItemTypeName = dr.Item("ItemTypeName")
            cls.Quantity = dr.Item("Quantity")
            cls.Weight = dr.Item("Weight")
            cls.TotalWeight = dr.Item("TotalWeight")
            cls.MaxTotalWeight = dr.Item("MaxTotalWeight")
            cls.UnitPrice = dr.Item("UnitPrice")
            cls.TotalPrice = dr.Item("TotalPrice")
            cls.IsIgnoreValidationPayment = dr.Item("IsIgnoreValidationPayment")
            cls.Remarks = dr.Item("Remarks")
            cls.LevelItem = dr.Item("LevelItem")
            cls.ParentID = dr.Item("ParentID")
            cls.UnitPriceHPP = dr.Item("UnitPriceHPP")
            cls.CODetailID = dr.Item("CODetailID")
            cls.PCDetailID = dr.Item("PCDetailID")
            clsData.SubItem.Add(cls)
        Next

        clsDataSplit.Weight = txtWeightSplit.Value
        clsDataSplit.Quantity = txtQuantitySplit.Value
        clsDataSplit.TotalWeight = txtTotalWeightSplit.Value
        clsDataSplit.TotalPrice = txtTotalPriceSplit.Value

        '# SC Sub Item Split 
        For Each dr As DataRow In dtSubItemSplit.Rows
            Dim cls As New VO.SalesContractDet
            cls.ID = dr.Item("ID")
            cls.SCID = dr.Item("SCID")
            cls.ORDetailID = dr.Item("ORDetailID")
            cls.OrderNumberSupplier = dr.Item("OrderNumberSupplier")
            cls.GroupID = dr.Item("GroupID")
            cls.RequestNumber = dr.Item("RequestNumber")
            cls.ItemID = dr.Item("ItemID")
            cls.ItemCode = dr.Item("ItemCode")
            cls.ItemName = dr.Item("ItemName")
            cls.Thick = dr.Item("Thick")
            cls.Width = dr.Item("Width")
            cls.Length = dr.Item("Length")
            cls.ItemSpecificationID = dr.Item("ItemSpecificationID")
            cls.ItemSpecificationName = dr.Item("ItemSpecificationName")
            cls.ItemTypeID = dr.Item("ItemTypeID")
            cls.ItemTypeName = dr.Item("ItemTypeName")
            cls.Quantity = dr.Item("Quantity")
            cls.Weight = dr.Item("Weight")
            cls.TotalWeight = dr.Item("TotalWeight")
            cls.MaxTotalWeight = dr.Item("MaxTotalWeight")
            cls.UnitPrice = dr.Item("UnitPrice")
            cls.TotalPrice = dr.Item("TotalPrice")
            cls.IsIgnoreValidationPayment = dr.Item("IsIgnoreValidationPayment")
            cls.Remarks = dr.Item("Remarks")
            cls.LevelItem = dr.Item("LevelItem")
            cls.ParentID = dr.Item("ParentID")
            cls.UnitPriceHPP = dr.Item("UnitPriceHPP")
            cls.CODetailID = dr.Item("CODetailID")
            cls.PCDetailID = dr.Item("PCDetailID")
            clsDataSplit.SubItem.Add(cls)
        Next

        '# CO Item
        '# CO Sub Item
        '# CO Sub Item Split 
        Try
            BL.SalesContract.SplitItem(clsData, clsDataSplit, clsDataCO, clsDataCOSplit)
            UI.usForm.frmMessageBox("Data berhasil di Split")
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
        If clsData.Quantity > 1 Then txtQuantity.Value = clsData.Quantity - txtQuantitySplit.Value : txtQuantityDP.Value = clsData.Quantity - txtQuantitySplit.Value
        If clsData.Quantity <= 1 Then txtWeight.Value = clsData.Weight - txtWeightSplit.Value : txtWeightDP.Value = clsData.Weight - txtWeightSplit.Value

        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
        txtTotalWeightSplit.Value = txtWeightSplit.Value * txtQuantitySplit.Value
        txtTotalPriceSplit.Value = txtUnitPriceSplit.Value * txtTotalWeightSplit.Value

        txtTotalWeightDP.Value = txtWeightDP.Value * txtQuantityDP.Value
        txtDPAmount.Value = ERPSLib.SharedLib.Math.Round(txtTotalPrice.Value * clsARAP.Percentage / 100, 2)
        txtDPAmountPPN.Value = ERPSLib.SharedLib.Math.Round(txtDPAmount.Value * clsARAP.PPNPercentage / 100, 2)
        txtDPAmountPPH.Value = ERPSLib.SharedLib.Math.Round(txtDPAmount.Value * clsARAP.PPHPercentage / 100, 2)

        txtTotalWeightDPSplit.Value = txtWeightDPSplit.Value * txtQuantityDPSplit.Value
        txtDPAmountSplit.Value = ERPSLib.SharedLib.Math.Round(txtTotalPriceSplit.Value * clsARAP.Percentage / 100, 2)
        txtDPAmountPPNSplit.Value = ERPSLib.SharedLib.Math.Round(txtDPAmountSplit.Value * clsARAP.PPNPercentage / 100, 2)
        txtDPAmountPPHSplit.Value = ERPSLib.SharedLib.Math.Round(txtDPAmountSplit.Value * clsARAP.PPHPercentage / 100, 2)

        If clsDataCO.Quantity > 1 Then txtQuantityCO.Value = clsDataCO.Quantity - txtQuantitySplit.Value
        If clsDataCO.Quantity <= 1 Then txtWeightCO.Value = clsDataCO.Weight - txtWeightSplit.Value
        txtTotalWeightCO.Value = txtWeightCO.Value * txtQuantityCO.Value
        txtTotalPriceCO.Value = txtUnitPriceCO.Value * txtTotalWeightCO.Value
        txtTotalWeightCOSplit.Value = txtWeightCOSplit.Value * txtQuantityCOSplit.Value
        txtTotalPriceCOSplit.Value = txtUnitPriceCOSplit.Value * txtTotalWeightCOSplit.Value
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
        UI.usForm.SetIcon(Me, "mylogo")
        ToolBar.SetIcon(Me)
        ToolBarItemCO.SetIcon(Me)
        ToolBarItemCOSplit.SetIcon(Me)
        ToolBarItemSubitem.SetIcon(Me)
        ToolBarItemSubitemSplit.SetIcon(Me)
        prvSetGrid()
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

    Private Sub txtValueSplit_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantitySplit.ValueChanged, txtWeightSplit.ValueChanged, txtTotalWeightSplit.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class