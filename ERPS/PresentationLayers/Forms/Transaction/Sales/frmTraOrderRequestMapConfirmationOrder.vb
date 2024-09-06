Imports DevExpress.XtraGrid
Public Class frmTraOrderRequestMapConfirmationOrder

#Region "Property"

    Private frmParent As frmTraOrderRequest
    Private clsData As VO.OrderRequest
    Private intBPID As Integer = 0
    Private dtItem As New DataTable
    Private dtItemCO As New DataTable
    Private intPos As Integer = 0

    Property pubID As String = ""
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, _
       cMapItem As Byte = 0, cEditItem As Byte = 1, cDeleteItem As Byte = 2

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
        UI.usForm.SetGrid(grdItemView, "OrderRequestID", "OrderRequestID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "No. Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
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
        UI.usForm.SetGrid(grdItemView, "IsIgnoreValidationPayment", "Set Pengiriman", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

        '# CO Item
        UI.usForm.SetGrid(grdItemCOView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemCOView, "OrderRequestID", "OrderRequestID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemCOView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemCOView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemCOView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemCOView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemCOView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
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
        UI.usForm.SetGrid(grdItemCOView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemCOView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        grdItemCOView.Columns("GroupID").GroupIndex = 0
    End Sub

    Private Sub prvFillForm()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            clsData = New VO.OrderRequest
            clsData = BL.OrderRequest.GetDetail(pubID)
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
        ElseIf grdItemCOView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Map Konfirmasi Pesanan terlebih dahulu")
            grdItemCOView.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Dim listDetail As New List(Of VO.OrderRequestDet)
        For Each dr As DataRow In dtItem.Rows
            listDetail.Add(New ERPSLib.VO.OrderRequestDet With
                           {
                               .ID = dr.Item("ID"),
                               .OrderRequestID = pubID,
                               .ItemID = dr.Item("ItemID"),
                               .Quantity = dr.Item("Quantity"),
                               .Weight = dr.Item("Weight"),
                               .TotalWeight = dr.Item("TotalWeight"),
                               .UnitPrice = dr.Item("UnitPrice"),
                               .TotalPrice = dr.Item("TotalPrice"),
                               .Remarks = dr.Item("Remarks"),
                               .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                               .UnitPriceHPP = dr.Item("UnitPriceHPP")
                           })
        Next

        Dim clsDataItemAll As New List(Of VO.OrderRequestDet)
        For Each dr As DataRow In dtItem.Rows
            clsDataItemAll.Add(New VO.OrderRequestDet() With
                               {
                                   .ID = dr.Item("ID"),
                                   .OrderRequestID = dr.Item("OrderRequestID"),
                                   .GroupID = dr.Item("GroupID"),
                                   .ItemID = dr.Item("ItemID"),
                                   .Quantity = dr.Item("Quantity"),
                                   .Weight = dr.Item("Weight"),
                                   .TotalWeight = dr.Item("TotalWeight"),
                                   .UnitPrice = dr.Item("UnitPrice"),
                                   .TotalPrice = dr.Item("TotalPrice"),
                                   .Remarks = dr.Item("Remarks"),
                                   .RoundingWeight = dr.Item("RoundingWeight"),
                                   .OrderNumberSupplier = dr.Item("OrderNumberSupplier")
                               })
        Next

        Dim clsDataItemCOAll As New List(Of VO.OrderRequestDetConfirmationOrder)
        For Each dr As DataRow In dtItemCO.Rows
            clsDataItemCOAll.Add(New VO.OrderRequestDetConfirmationOrder() With
                               {
                                   .ID = dr.Item("ID"),
                                   .OrderRequestID = dr.Item("OrderRequestID"),
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
                                   .LevelItem = dr.Item("LevelItem"),
                                   .ParentID = dr.Item("ParentID"),
                                   .LocationID = dr.Item("LocationID"),
                                   .OrderNumberSupplier = dr.Item("OrderNumberSupplier")
                               }
                               )
        Next

        pgMain.Value = 60

        Try
            'Dim strOrderNumber As String = BL.OrderRequest.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan.")
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

        If grdItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdItemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
        End If

        If grdItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPrice)
        End If

        Dim SumTotalQuantityCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeightCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdItemCOView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemCOView.Columns("Quantity").Summary.Add(SumTotalQuantityCO)
        End If

        If grdItemCOView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemCOView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightCO)
        End If

        If grdItemCOView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemCOView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceCO)
        End If
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarItemOrderRequest
            .Buttons(cMapItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtItem = BL.OrderRequest.ListDataDetail(pubID.Trim)
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

    Private Sub prvMapItem()
        'Dim frmDetail As New frmTraOrderRequestDetItem
        'With frmDetail
        '    .pubIsNew = True
        '    .pubTableParent = dtItem
        '    .pubIsAutoSearch = True
        '    .pubIsStock = bolIsStock
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .pubShowDialog(Me)
        '    prvSetButtonItem()
        'End With
    End Sub

#End Region

#Region "Item CO Handle"

    Private Sub prvSetButtonItemCO()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarItemCO
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItemCO()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            'dtItem = BL.OrderRequest.ListDataDetail(pubID.Trim)
            'grdItem.DataSource = dtItem
            'prvSumGrid()
            'grdItemView.BestFitColumns()
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

    Private Sub prvEditItem()
        'Dim frmDetail As New frmTraOrderRequestDetItem
        'With frmDetail
        '    .pubIsNew = True
        '    .pubTableParent = dtItem
        '    .pubIsAutoSearch = True
        '    .pubIsStock = bolIsStock
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .pubShowDialog(Me)
        '    prvSetButtonItem()
        'End With
    End Sub

    Private Sub prvDeleteItem()
        'Dim frmDetail As New frmTraOrderRequestDetItem
        'With frmDetail
        '    .pubIsNew = True
        '    .pubTableParent = dtItem
        '    .pubIsAutoSearch = True
        '    .pubIsStock = bolIsStock
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .pubShowDialog(Me)
        '    prvSetButtonItem()
        'End With
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
        ToolBarItemOrderRequest.SetIcon(Me)
        ToolBarItemCO.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryItemCO()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItemOrderRequest_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemOrderRequest.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Map Konfirmasi Pesanan" : prvMapItem()
        End Select
    End Sub

    Private Sub ToolBarItemCO_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemCO.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Edit" : prvEditItem()
            Case "Hapus" : prvDeleteItem()
        End Select
    End Sub

#End Region

End Class