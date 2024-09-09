Imports DevExpress.XtraGrid
Public Class frmTraOrderRequestMapConfirmationOrder

#Region "Property"

    Private frmParent As frmTraOrderRequest
    Private clsData As VO.OrderRequestConfirmationOrder
    Private intBPID As Integer = 0
    Private dtItem As New DataTable
    Private dtItemCO As New DataTable
    Private intPos As Integer = 0
    Private strOrderRequestID As String
    Private bolIsNew As Boolean

    Property pubID As String = ""
    Property pubCS As New VO.CS

    Public WriteOnly Property pubOrderRequestID As String
        Set(value As String)
            strOrderRequestID = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, cAddItem As Byte = 0, cEditItem As Byte = 1, cDeleteItem As Byte = 2

    Private Sub prvSetTitleForm()
        Me.Text += " [Map Konfirmasi Pesanan] "
    End Sub

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        '# Item
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ORDetailID", "ORDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "GroupID", "GroupID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "CONumber", "No. Konfirmasi Pesanan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "No. Pesanan Pemasok", 100, UI.usDefGrid.gString)
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
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "RoundingWeight", "RoundingWeight", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "ItemIDCO", "ItemIDCO", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemCodeCO", "Kode Barang Konfirmasi Pesanan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemNameCO", "Nama Barang Konfirmasi Pesanan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ThickCO", "Tebal Konfirmasi Pesanan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "WidthCO", "Lebar Konfirmasi Pesanan", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "LengthCO", "Panjang Konfirmasi Pesanan", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationIDCO", "ItemSpecificationIDCO", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationNameCO", "Spec Konfirmasi Pesanan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemTypeIDCO", "ItemTypeIDCO", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemTypeNameCO", "Tipe Konfirmasi Pesanan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "QuantityCO", "Quantity Konfirmasi Pesanan", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "WeightCO", "Weight Konfirmasi Pesanan", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeightCO", "Total Berat Konfirmasi Pesanan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPriceCO", "Harga Konfirmasi Pesanan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPriceCO", "Total Harga Konfirmasi Pesanan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "RoundingWeightCO", "RoundingWeightCO", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "LocationID", "LocationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "UnitPriceHPP", "Unit Price HPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillForm()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            If bolIsNew Then
                Dim clsOrderRequest As VO.OrderRequest = BL.OrderRequest.GetDetail(strOrderRequestID)
                txtOrderNumber.Text = clsOrderRequest.OrderNumber
            Else
                clsData = New VO.OrderRequestConfirmationOrder
                clsData = BL.OrderRequest.GetDetailCO(pubID)
                strOrderRequestID = clsData.OrderRequestID
                txtOrderNumber.Text = clsData.OrderNumber
                txtTransactionNumber.Text = clsData.TransactionNumber
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            grdItemView.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Dim clsDataItemAll As New List(Of VO.OrderRequestConfirmationOrderDet)
        For Each dr As DataRow In dtItem.Rows
            clsDataItemAll.Add(New VO.OrderRequestConfirmationOrderDet() With
                               {
                                   .ID = dr.Item("ID"),
                                   .ParentID = pubID,
                                   .ORDetailID = dr.Item("ORDetailID"),
                                   .CODetailID = dr.Item("CODetailID"),
                                   .GroupID = dr.Item("GroupID"),
                                   .ItemID = dr.Item("ItemID"),
                                   .Quantity = dr.Item("Quantity"),
                                   .Weight = dr.Item("Weight"),
                                   .TotalWeight = dr.Item("TotalWeight"),
                                   .UnitPrice = dr.Item("UnitPrice"),
                                   .TotalPrice = dr.Item("TotalPrice"),
                                   .Remarks = dr.Item("Remarks"),
                                   .RoundingWeight = dr.Item("RoundingWeight"),
                                   .QuantityCO = dr.Item("QuantityCO"),
                                   .WeightCO = dr.Item("WeightCO"),
                                   .TotalWeightCO = dr.Item("TotalWeightCO"),
                                   .UnitPriceCO = dr.Item("UnitPriceCO"),
                                   .TotalPriceCO = dr.Item("TotalPriceCO"),
                                   .RoundingWeightCO = dr.Item("RoundingWeightCO"),
                                   .LevelItem = dr.Item("LevelItem"),
                                   .LocationID = dr.Item("LocationID"),
                                   .UnitPriceHPP = dr.Item("UnitPriceHPP"),
                                   .OrderNumberSupplier = dr.Item("OrderNumberSupplier")
                               })
        Next

        clsData = New VO.OrderRequestConfirmationOrder() With
            {
                .ID = pubID,
                .OrderRequestID = strOrderRequestID,
                .Detail = clsDataItemAll
            }

        pgMain.Value = 60

        Try
            Dim bolIsSuccess As Boolean = BL.OrderRequest.MapConfirmationOrder(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Mapping Data Berhasil.")
            pgMain.Value = 80
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPrice As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        Dim SumTotalQuantityCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantityCO", "Total Quantity Konfirmasi Pesanan: {0:#,##0.0000}")
        Dim SumGrandTotalWeightCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeightCO", "Total Berat Keseluruhan Konfirmasi Pesanan: {0:#,##0.00}")
        Dim SumGrandTotalPriceCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPriceCO", "Total Harga Keseluruhan Konfirmasi Pesanan: {0:#,##0.00}")

        If grdItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdItemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
        End If

        If grdItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPrice)
        End If

        If grdItemView.Columns("QuantityCO").SummaryText.Trim = "" Then
            grdItemView.Columns("QuantityCO").Summary.Add(SumTotalQuantityCO)
        End If

        If grdItemView.Columns("TotalWeightCO").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalWeightCO").Summary.Add(SumGrandTotalWeightCO)
        End If

        If grdItemView.Columns("TotalPriceCO").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPriceCO").Summary.Add(SumGrandTotalPriceCO)
        End If
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtItem = BL.OrderRequest.ListDataDetailCO(pubID.Trim)
            grdItem.DataSource = dtItem
            prvSumGrid()
            grdItemView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvSetButtonItem()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvAddItem()
        Dim frmDetail As New frmTraOrderRequestDetItem
        With frmDetail
            .pubIsNew = True
            .pubTableParent = dtItem
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
        End With
    End Sub

    Private Sub prvEditItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraOrderRequestDetItem
        With frmDetail
            .pubIsNew = False
            .pubTableParent = dtItem
            .pubDatRowSelected = grdItemView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
        End With
    End Sub

    Private Sub prvDeleteItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        For i As Integer = 0 To dtItem.Rows.Count - 1
            If dtItem.Rows(i).Item("ID") = strID Then
                dtItem.Rows(i).Delete()
                Exit For
            End If
        Next
        dtItem.AcceptChanges()
        grdItem.DataSource = dtItem
        prvSetButtonItem()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraOrderRequestMapConfirmationOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraOrderRequestMapConfirmationOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarDetail_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItem()
            Case "Edit" : prvEditItem()
            Case "Hapus" : prvDeleteItem()
        End Select
    End Sub

#End Region

End Class