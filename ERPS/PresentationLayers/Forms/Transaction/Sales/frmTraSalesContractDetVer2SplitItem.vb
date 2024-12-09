Imports DevExpress.XtraGrid

Public Class frmTraSalesContractDetVer2SplitItem

#Region "Property"

    Private frmParent As frmTraSalesContractDetVer2
    Private strID As String = ""
    Private strSCDetailCOID As String = ""
    Private bolIsSave As Boolean
    Private clsSC As New VO.SalesContract
    Private clsData As New VO.SalesContractDet
    Private clsDataSplit As New VO.SalesContractDet
    Private clsDataCO As New VO.SalesContractDetConfirmationOrder
    Private clsDataCOSplit As New VO.SalesContractDetConfirmationOrder
    Private clsARAP As New VO.ARAPItem
    Private dtSubItem As New DataTable
    Private dtSubItemMain As New DataTable
    Private dtSubItemSplit As New DataTable
    Private dtSubItemCO As New DataTable
    Private dtSubItemCOMain As New DataTable
    Private dtSubItemCOSplit As New DataTable
    Private dtDP As New DataTable
    Private dtDPMain As New DataTable
    Private dtDPSplit As New DataTable
    Private intPos As Integer = -1

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

        '# Down Payment
        UI.usForm.SetGrid(grdDownPaymentView, "Pick", "Pilih", 80, UI.usDefGrid.gBoolean, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ReferencesID", "ReferencesID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ReferencesDetailID", "ReferencesDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentView, "InvoiceAmount", "InvoiceAmount", 250, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentView, "Quantity", "Jumlah", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdDownPaymentView, "Weight", "Berat", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdDownPaymentView, "TotalWeight", "Total Berat", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdDownPaymentView, "Amount", "Total Tagihan", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdDownPaymentView, "DPAmount", "Total Panjar", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentView, "PPNPercent", "PPNPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentView, "PPHPercent", "PPHPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentView, "PPN", "PPN", 150, UI.usDefGrid.gReal2Num, True)
        UI.usForm.SetGrid(grdDownPaymentView, "PPH", "PPH", 150, UI.usDefGrid.gReal2Num, True)
        UI.usForm.SetGrid(grdDownPaymentView, "MaxPaymentAmount", "Total Maksimal Tagihan", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdDownPaymentView, "Remarks", "Keterangan", 250, UI.usDefGrid.gString, True)
        UI.usForm.SetGrid(grdDownPaymentView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentView, "ItemName", "Nama Barang", 250, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdDownPaymentView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdDownPaymentView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdDownPaymentView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdDownPaymentView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentView, "ReferencesParentID", "ReferencesParentID", 100, UI.usDefGrid.gString, False)
        'grdDownPaymentView.Columns("Amount").ColumnEdit = rpiValue
        'grdDownPaymentView.Columns("PPN").ColumnEdit = rpiValue
        'grdDownPaymentView.Columns("PPH").ColumnEdit = rpiValue

        '# Down Payment
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Pick", "Pilih", 80, UI.usDefGrid.gBoolean, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ReferencesID", "ReferencesID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ReferencesDetailID", "ReferencesDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "InvoiceAmount", "InvoiceAmount", 250, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Quantity", "Jumlah", 150, UI.usDefGrid.gReal2Num, True)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Weight", "Berat", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "TotalWeight", "Total Berat", 150, UI.usDefGrid.gReal2Num, True)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Amount", "Total Tagihan", 150, UI.usDefGrid.gReal2Num, True)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "DPAmount", "Total Panjar", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "PPNPercent", "PPNPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "PPHPercent", "PPHPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "PPN", "PPN", 150, UI.usDefGrid.gReal2Num, True)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "PPH", "PPH", 150, UI.usDefGrid.gReal2Num, True)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "MaxPaymentAmount", "Total Maksimal Tagihan", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Remarks", "Keterangan", 250, UI.usDefGrid.gString, True)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ItemName", "Nama Barang", 250, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdDownPaymentSplitView, "ReferencesParentID", "ReferencesParentID", 100, UI.usDefGrid.gString, False)
        'grdDownPaymentSplitView.Columns("Amount").ColumnEdit = rpiValue
        'grdDownPaymentSplitView.Columns("PPN").ColumnEdit = rpiValue
        'grdDownPaymentSplitView.Columns("PPH").ColumnEdit = rpiValue
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtItemType As DataTable = BL.ItemType.ListDataForCombo
            Dim dtItemSpecification As DataTable = BL.ItemSpecification.ListDataForCombo
            UI.usForm.FillComboBox(cboItemType, dtItemType, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, dtItemSpecification, "ID", "Description")

            UI.usForm.FillComboBox(cboItemTypeSplit, dtItemType, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecificationSplit, dtItemSpecification, "ID", "Description")

            UI.usForm.FillComboBox(cboItemTypeCO, dtItemType, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecificationCO, dtItemSpecification, "ID", "Description")

            UI.usForm.FillComboBox(cboItemTypeCOSplit, dtItemType, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecificationCOSplit, dtItemSpecification, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
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
            grdSubitemView.BestFitColumns()
            grdSubitemSplitView.BestFitColumns()

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
            grdSubItemCOView.BestFitColumns()
            grdSubItemCOSplitView.BestFitColumns()

            '# Fill ARAP
            clsARAP = BL.ARAP.GetDetailAmountByReferencesDetailID(strID)
            clsSC = BL.SalesContract.GetDetail(clsData.SCID)
            dtDP = BL.SalesContract.ListDataDownPaymentBySCDetailID(strID)
            dtDPMain = dtDP.Clone
            dtDPSplit = dtDP.Clone
            For Each dr As DataRow In dtDP.Rows
                dtDPMain.ImportRow(dr)
            Next
            dtDPMain.AcceptChanges()
            grdDownPayment.DataSource = dtDPMain
            grdDownPaymentSplit.DataSource = dtDPSplit
            grdDownPaymentView.BestFitColumns()
            grdDownPaymentSplitView.BestFitColumns()
            prvSumGrid()
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
            UI.usForm.frmMessageBox("Total Berat Keseluruhan harus sama dengan Maks. Total Berat [Kontrak Penjualan]")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
            'ElseIf (grdSubitemView.RowCount > 0 And grdSubitemSplitView.RowCount = 0) Or (grdSubitemView.RowCount = 0 And grdSubitemSplitView.RowCount > 0) Then
            '    UI.usForm.frmMessageBox("Subitem Kontrak Penjualan Belum dipindahkan")
            '    tcHeader.SelectedTab = tpSalesContract
            '    Exit Sub
        ElseIf txtTotalWeightCO.Value + txtTotalWeightCOSplit.Value <> clsDataCO.TotalWeight Then
            UI.usForm.frmMessageBox("Total Berat Keseluruhan harus sama dengan Maks. Total Berat [Konfirmasi Pesanan]")
            tcHeader.SelectedTab = tpConfirmationOrder
            Exit Sub
            'ElseIf (grdSubItemCOView.RowCount > 0 And grdSubItemCOSplitView.RowCount = 0) Or (grdSubItemCOView.RowCount = 0 And grdSubItemCOSplitView.RowCount > 0) Then
            '    UI.usForm.frmMessageBox("Subitem Konfirmasi Pesanan Belum dipindahkan")
            '    tcHeader.SelectedTab = tpConfirmationOrder
            '    Exit Sub
        ElseIf (grdDownPaymentView.RowCount > 0 And grdDownPaymentSplitView.RowCount = 0) Or (grdDownPaymentView.RowCount = 0 And grdDownPaymentSplitView.RowCount > 0) Then
            UI.usForm.frmMessageBox("Down Payment Pesanan Belum dipindahkan")
            tcHeader.SelectedTab = tpDownPayment
            Exit Sub
        End If

        Dim decDPAmount, decDPAmountPPN, decDPAmountPPH, decDPTotalWeight As Decimal
        For Each dr As DataRow In dtDPMain.Rows
            decDPTotalWeight += dr.Item("TotalWeight")
            decDPAmount += dr.Item("Amount")
            decDPAmountPPN += dr.Item("PPN")
            decDPAmountPPH += dr.Item("PPH")
        Next

        For Each dr As DataRow In dtDPSplit.Rows
            decDPTotalWeight += dr.Item("TotalWeight")
            decDPAmount += dr.Item("Amount")
            decDPAmountPPN += dr.Item("PPN")
            decDPAmountPPH += dr.Item("PPH")
        Next

        If clsARAP.Amount <> decDPAmount Then
            UI.usForm.frmMessageBox("Total DP secara keseluruhan tidak sesuai")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf clsARAP.PPN <> decDPAmountPPN Then
            UI.usForm.frmMessageBox("Total DP PPN secara keseluruhan tidak sesuai")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf clsARAP.PPH <> decDPAmountPPH Then
            UI.usForm.frmMessageBox("Total DP PPH secara keseluruhan tidak sesuai")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        ElseIf clsARAP.TotalWeight <> decDPTotalWeight Then
            UI.usForm.frmMessageBox("Total Berat DP secara keseluruhan tidak sesuai")
            tcHeader.SelectedTab = tpSalesContract
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Anda yakin ingin simpan data ini?") Then Exit Sub

        '# SC Item
        clsData.Weight = txtWeight.Value
        clsData.Quantity = txtQuantity.Value
        clsData.TotalWeight = txtTotalWeight.Value
        clsData.TotalPrice = txtTotalPrice.Value
        clsData.SubItem = New List(Of VO.SalesContractDet)
        clsData.DPItem = New List(Of VO.ARAPItem)

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

        For Each dr As DataRow In dtDPMain.Rows
            Dim cls As New VO.ARAPItem
            cls.ID = dr.Item("ID")
            cls.Quantity = dr.Item("Quantity")
            cls.Weight = dr.Item("Weight")
            cls.TotalWeight = dr.Item("TotalWeight")
            cls.Amount = dr.Item("Amount")
            cls.PPN = dr.Item("PPN")
            cls.PPH = dr.Item("PPH")
            cls.ReferencesID = clsData.SCID
            cls.ReferencesDetailID = dr.Item("ReferencesDetailID")
            clsData.DPItem.Add(cls)
        Next

        clsDataSplit.Weight = txtWeightSplit.Value
        clsDataSplit.Quantity = txtQuantitySplit.Value
        clsDataSplit.TotalWeight = txtTotalWeightSplit.Value
        clsDataSplit.TotalPrice = txtTotalPriceSplit.Value
        clsDataSplit.SplitFrom = clsData.ID
        clsDataSplit.SubItem = New List(Of VO.SalesContractDet)
        clsDataSplit.DPItem = New List(Of VO.ARAPItem)

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
            cls.SplitFrom = clsData.ID
            clsDataSplit.SubItem.Add(cls)
        Next

        For Each dr As DataRow In dtDPSplit.Rows
            Dim cls As New VO.ARAPItem
            cls.ID = dr.Item("ID")
            cls.Quantity = dr.Item("Quantity")
            cls.Weight = dr.Item("Weight")
            cls.TotalWeight = dr.Item("TotalWeight")
            cls.Amount = dr.Item("Amount")
            cls.PPN = dr.Item("PPN")
            cls.PPH = dr.Item("PPH")
            cls.ReferencesID = clsData.SCID
            cls.ReferencesDetailID = dr.Item("ReferencesDetailID")
            cls.SplitFrom = clsData.ID
            clsDataSplit.DPItem.Add(cls)
        Next

        '# CO Item
        clsDataCO.SCID = clsData.SCID
        clsDataCO.GroupID = clsData.GroupID
        clsDataCO.Weight = txtWeightCO.Value
        clsDataCO.Quantity = txtQuantityCO.Value
        clsDataCO.TotalWeight = txtTotalWeightCO.Value
        clsDataCO.TotalPrice = txtTotalPriceCO.Value
        clsDataCO.SubItem = New List(Of VO.SalesContractDetConfirmationOrder)

        '# CO Sub Item
        For Each dr As DataRow In dtSubItemCOMain.Rows
            Dim cls As New VO.SalesContractDetConfirmationOrder
            cls.ID = dr.Item("ID")
            cls.CODetailID = dr.Item("CODetailID")
            cls.GroupID = dr.Item("GroupID")
            cls.ItemID = dr.Item("ItemID")
            cls.Quantity = dr.Item("Quantity")
            cls.Weight = dr.Item("Weight")
            cls.TotalWeight = dr.Item("TotalWeight")
            cls.Remarks = dr.Item("Remarks")
            cls.LevelItem = dr.Item("LevelItem")
            cls.ParentID = dr.Item("ParentID")
            cls.LocationID = dr.Item("LocationID")
            clsDataCO.SubItem.Add(cls)
        Next

        '# CO Split
        clsDataCOSplit.SCID = clsData.SCID
        clsDataCOSplit.GroupID = clsData.GroupID
        clsDataCOSplit.Weight = txtWeightCOSplit.Value
        clsDataCOSplit.Quantity = txtQuantityCOSplit.Value
        clsDataCOSplit.TotalWeight = txtTotalWeightCOSplit.Value
        clsDataCOSplit.TotalPrice = txtTotalPriceCOSplit.Value
        clsDataCOSplit.SplitFrom = clsData.ID
        clsDataCOSplit.SubItem = New List(Of VO.SalesContractDetConfirmationOrder)

        '# CO Sub Item Split 
        For Each dr As DataRow In dtSubItemCOSplit.Rows
            Dim cls As New VO.SalesContractDetConfirmationOrder
            cls.ID = dr.Item("ID")
            cls.CODetailID = dr.Item("CODetailID")
            cls.GroupID = dr.Item("GroupID")
            cls.ItemID = dr.Item("ItemID")
            cls.Quantity = dr.Item("Quantity")
            cls.Weight = dr.Item("Weight")
            cls.TotalWeight = dr.Item("TotalWeight")
            cls.Remarks = dr.Item("Remarks")
            cls.LevelItem = dr.Item("LevelItem")
            cls.ParentID = dr.Item("ParentID")
            cls.LocationID = dr.Item("LocationID")
            cls.SplitFrom = clsData.ID
            clsDataCOSplit.SubItem.Add(cls)
        Next

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
        intPos = grdSubitemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub

        dtSubItemSplit.ImportRow(grdSubitemView.GetDataRow(intPos))
        dtSubItemSplit.AcceptChanges()
        grdSubitemSplit.DataSource = dtSubItemSplit
        grdSubitemSplitView.BestFitColumns()

        For Each dr As DataRow In dtSubItemMain.Rows
            If dr.Item("ID") = grdSubitemView.GetRowCellValue(intPos, "ID") Then dr.Delete() : Exit For
        Next
        dtSubItemMain.AcceptChanges()
        grdSubitem.DataSource = dtSubItemMain
        grdSubitemView.BestFitColumns()
    End Sub

    Private Sub prvMoveToMain()
        intPos = grdSubitemSplitView.FocusedRowHandle
        If intPos < 0 Then Exit Sub

        dtSubItemMain.ImportRow(grdSubitemSplitView.GetDataRow(intPos))
        dtSubItemMain.AcceptChanges()
        grdSubitem.DataSource = dtSubItemMain
        grdSubitemView.BestFitColumns()

        For Each dr As DataRow In dtSubItemSplit.Rows
            If dr.Item("ID") = grdSubitemSplitView.GetRowCellValue(intPos, "ID") Then dr.Delete() : Exit For
        Next
        dtSubItemSplit.AcceptChanges()
        grdSubitemSplit.DataSource = dtSubItemSplit
        grdSubitemSplitView.BestFitColumns()
    End Sub

    Private Sub prvMoveToSplitCO()
        intPos = grdSubItemCOView.FocusedRowHandle
        If intPos < 0 Then Exit Sub

        dtSubItemCOSplit.ImportRow(grdSubItemCOView.GetDataRow(intPos))
        dtSubItemCOSplit.AcceptChanges()
        grdSubItemCOSplit.DataSource = dtSubItemCOSplit
        grdSubItemCOSplitView.BestFitColumns()

        For Each dr As DataRow In dtSubItemCOMain.Rows
            If dr.Item("ID") = grdSubItemCOView.GetRowCellValue(intPos, "ID") Then dr.Delete() : Exit For
        Next
        dtSubItemCOMain.AcceptChanges()
        grdSubItemCO.DataSource = dtSubItemCOMain
        grdSubItemCOView.BestFitColumns()
    End Sub

    Private Sub prvMoveToMainCO()
        intPos = grdSubItemCOSplitView.FocusedRowHandle
        If intPos < 0 Then Exit Sub

        dtSubItemCOMain.ImportRow(grdSubItemCOSplitView.GetDataRow(intPos))
        dtSubItemCOMain.AcceptChanges()
        grdSubItemCO.DataSource = dtSubItemCOMain
        grdSubItemCOView.BestFitColumns()

        For Each dr As DataRow In dtSubItemCOSplit.Rows
            If dr.Item("ID") = grdSubItemCOSplitView.GetRowCellValue(intPos, "ID") Then dr.Delete() : Exit For
        Next
        dtSubItemCOSplit.AcceptChanges()
        grdSubItemCOSplit.DataSource = dtSubItemCOSplit
        grdSubItemCOSplitView.BestFitColumns()
    End Sub

    Private Sub prvMoveDPToSplit()
        intPos = grdDownPaymentView.FocusedRowHandle
        If intPos < 0 Then Exit Sub

        Dim dtClone As DataTable = dtDP.Clone
        For Each dr As DataRow In dtDP.Rows
            dtClone.ImportRow(dr)
        Next
        dtClone.AcceptChanges()

        Dim drSelected As DataRow = dtClone.NewRow
        For Each dr As DataRow In dtClone.Rows
            If dr.Item("ID") = grdDownPaymentView.GetRowCellValue(intPos, "ID") Then drSelected = dr : Exit For
        Next

        Dim frmDetail As New frmTraSalesContractDetVer2SplitItemDP
        With frmDetail
            .pubClsARAPItem = clsARAP
            .pubDrData = drSelected
            .pubUnitPrice = txtUnitPrice.Value
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsSave Then
                dtDPSplit.ImportRow(.pubDrData)
                dtDPSplit.AcceptChanges()
                grdDownPaymentSplit.DataSource = dtDPSplit
                grdDownPaymentSplitView.BestFitColumns()

                For Each dr As DataRow In dtDPMain.Rows
                    If dr.Item("ID") = .pubDrData.Item("ID") Then
                        If dr.Item("TotalWeight") - .pubDrData.Item("TotalWeight") = 0 Then
                            dr.Delete()
                        Else
                            dr.BeginEdit()
                            If dr.Item("Quantity") > 1 Then dr.Item("Quantity") -= .pubDrData.Item("Quantity")
                            If dr.Item("Quantity") <= 1 Then dr.Item("Weight") -= .pubDrData.Item("Weight")
                            dr.Item("TotalWeight") -= .pubDrData.Item("TotalWeight")
                            dr.Item("Amount") -= .pubDrData.Item("Amount")
                            dr.Item("PPN") -= .pubDrData.Item("PPN")
                            dr.Item("PPH") -= .pubDrData.Item("PPH")
                            dr.EndEdit()
                        End If
                        Exit For
                    End If
                Next
                dtDPMain.AcceptChanges()
                grdDownPayment.DataSource = dtDPMain
                grdDownPaymentView.BestFitColumns()
            End If
        End With
    End Sub

    Private Sub prvMoveDPToMain()
        intPos = grdDownPaymentSplitView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim drSplit As DataRow = grdDownPaymentSplitView.GetDataRow(intPos)

        For Each dr As DataRow In dtDPSplit.Rows
            If dr.Item("ID") = drSplit.Item("ID") Then dr.Delete()
        Next
        grdDownPaymentSplit.DataSource = dtDPSplit
        grdDownPaymentSplitView.BestFitColumns()

        For Each dr As DataRow In dtDPMain.Rows
            If dr.Item("ID") = drSplit.Item("ID") Then dr.Delete()
        Next
        dtDPMain.AcceptChanges()

        For Each dr As DataRow In dtDP.Rows
            If dr.Item("ID") = drSplit.Item("ID") Then dtDPMain.ImportRow(dr)
        Next
        dtDPMain.AcceptChanges()

        Dim dv As DataView = dtDPMain.DefaultView
        dv.Sort = "ID ASC"
        dtDPMain = dv.ToTable
        grdDownPayment.DataSource = dtDPMain
        grdDownPaymentView.BestFitColumns()
    End Sub

    Private Sub prvCalculate()
        If clsData.Quantity > 1 Then txtQuantity.Value = clsData.Quantity - txtQuantitySplit.Value
        If clsData.Quantity <= 1 Then txtWeight.Value = clsData.Weight - txtWeightSplit.Value

        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
        txtTotalWeightSplit.Value = txtWeightSplit.Value * txtQuantitySplit.Value
        txtTotalPriceSplit.Value = txtUnitPriceSplit.Value * txtTotalWeightSplit.Value

        If clsDataCO.Quantity > 1 Then txtQuantityCO.Value = clsDataCO.Quantity - txtQuantityCOSplit.Value
        If clsDataCO.Quantity <= 1 Then txtWeightCO.Value = clsDataCO.Weight - txtWeightCOSplit.Value
        txtTotalWeightCO.Value = txtWeightCO.Value * txtQuantityCO.Value
        txtTotalPriceCO.Value = txtUnitPriceCO.Value * txtTotalWeightCO.Value
        txtTotalWeightCOSplit.Value = txtWeightCOSplit.Value * txtQuantityCOSplit.Value
        txtTotalPriceCOSplit.Value = txtUnitPriceCOSplit.Value * txtTotalWeightCOSplit.Value
    End Sub

    Private Sub prvSumGrid()
        '# Sub Item
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPrice As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubitemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubitemView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdSubitemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubitemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
        End If

        If grdSubitemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubitemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPrice)
        End If
        grdSubitemView.BestFitColumns()

        Dim SumTotalQuantitySplit As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightSplit As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceSplit As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubitemSplitView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubitemSplitView.Columns("Quantity").Summary.Add(SumTotalQuantitySplit)
        End If

        If grdSubitemSplitView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubitemSplitView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightSplit)
        End If

        If grdSubitemSplitView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubitemSplitView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceSplit)
        End If
        grdSubitemSplitView.BestFitColumns()

        '# Confirmation Order
        Dim SumTotalQuantityOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubItemCOView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("Quantity").Summary.Add(SumTotalQuantityOrder)
        End If

        If grdSubItemCOView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightOrder)
        End If

        If grdSubItemCOView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubItemCOView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceOrder)
        End If
        grdSubItemCOView.BestFitColumns()

        '# Confirmation Order
        Dim SumTotalQuantityOrderSplit As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightOrderSplit As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceOrderSplit As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubItemCOSplitView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubItemCOSplitView.Columns("Quantity").Summary.Add(SumTotalQuantityOrderSplit)
        End If

        If grdSubItemCOSplitView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubItemCOSplitView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightOrderSplit)
        End If

        If grdSubItemCOSplitView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubItemCOSplitView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceOrderSplit)
        End If
        grdSubItemCOSplitView.BestFitColumns()
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
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpDownPayment
        End If
    End Sub

    Private Sub frmTraSalesContractDetVer2SplitItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItemCO.SetIcon(Me)
        ToolBarItemCOSplit.SetIcon(Me)
        ToolBarItemSubitem.SetIcon(Me)
        ToolBarItemSubitemSplit.SetIcon(Me)
        ToolBarDP.SetIcon(Me)
        ToolBarDPSplit.SetIcon(Me)
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

    Private Sub ToolBarDP_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDP.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Pindah" : prvMoveDPToSplit()
        End Select
    End Sub

    Private Sub ToolBarDPSplit_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDPSplit.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Hapus" : prvMoveDPToMain()
        End Select
    End Sub

    Private Sub txtValueSplit_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantitySplit.ValueChanged,
        txtWeightSplit.ValueChanged, txtTotalWeightSplit.ValueChanged, txtWeightCOSplit.ValueChanged, txtQuantityCOSplit.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class