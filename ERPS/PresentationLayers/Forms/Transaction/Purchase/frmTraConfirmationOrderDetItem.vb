Imports DevExpress.XtraGrid
Public Class frmTraConfirmationOrderDetItem

#Region "Property"

    Private frmParent As frmTraConfirmationOrderDet
    Private dtParentItem As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private intBPID As Integer = 0
    Private strPODetailID As String
    Private strID As String = ""
    Private strOrderNumberSupplier As String = ""
    Private intPos As Integer = 0
    Private dtItem As New DataTable

    Public WriteOnly Property pubTableParentItem As DataTable
        Set(value As DataTable)
            dtParentItem = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubOrderNumberSupplier As String
        Set(value As String)
            strOrderNumberSupplier = value
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
        UI.usForm.SetGrid(grdItemView, "COID", "COID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PONumber", "Nomor Pesanan", 100, UI.usDefGrid.gString)
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
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "PCQuantity", "PCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "PCWeight", "PCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "DCQuantity", "DCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "DCWeight", "DCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            Me.Cursor = Cursors.Default
            dtItem = dtParentItem.Clone
            If Not bolIsNew Then
                For Each dr As DataRow In dtParentItem.Rows
                    txtOrderNumberSupplier.Text = strOrderNumberSupplier
                    txtDeliveryAddress.Text = dr.Item("DeliveryAddress")
                    If dr.Item("OrderNumberSupplier") = strOrderNumberSupplier Then
                        dtItem.ImportRow(dr)
                    End If
                Next
                dtItem.AcceptChanges()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvQuery()
        grdItem.DataSource = dtItem
        prvSumGrid()
        prvSetButtonItem()
    End Sub

    Private Sub prvSumGrid()
        '# Item
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

        grdItemView.BestFitColumns()
    End Sub

    Private Sub prvSave()
        If txtOrderNumberSupplier.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Isi nomor pesanan pemasok terlebih dahulu")
            txtOrderNumberSupplier.Focus()
            Exit Sub
        ElseIf txtDeliveryAddress.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Isi alamat pengiriman terlebih dahulu")
            txtDeliveryAddress.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Input barang terlebih dahulu")
            ToolBarItemOrder.Focus()
            Exit Sub
        End If

        If Not bolIsNew Then
            For Each dr As DataRow In dtParentItem.Rows
                If dr.Item("OrderNumberSupplier") = strOrderNumberSupplier Then
                    dr.Delete()
                End If
            Next
            dtParentItem.AcceptChanges()
        End If

        '# Item Handle
        For Each drItem As DataRow In dtItem.Rows
            Dim drNewItem As DataRow = dtParentItem.NewRow
            With drNewItem
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
                .Item("PONumber") = drItem.Item("PONumber")
                .Item("COID") = ""
                .Item("PODetailID") = drItem.Item("PODetailID")
                .Item("DeliveryAddress") = txtDeliveryAddress.Text.Trim
                .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                .Item("ItemID") = drItem.Item("ItemID")
                .Item("ItemCode") = drItem.Item("ItemCode")
                .Item("ItemName") = drItem.Item("ItemName")
                .Item("Thick") = drItem.Item("Thick")
                .Item("Width") = drItem.Item("Width")
                .Item("Length") = drItem.Item("Length")
                .Item("ItemSpecificationID") = drItem.Item("ItemSpecificationID")
                .Item("ItemSpecificationName") = drItem.Item("ItemSpecificationName")
                .Item("ItemTypeID") = drItem.Item("ItemTypeID")
                .Item("ItemTypeName") = drItem.Item("ItemTypeName")
                .Item("Quantity") = drItem.Item("Quantity")
                .Item("Weight") = drItem.Item("Weight")
                .Item("TotalWeight") = drItem.Item("TotalWeight")
                .Item("MaxTotalWeight") = drItem.Item("MaxTotalWeight")
                .Item("UnitPrice") = drItem.Item("UnitPrice")
                .Item("TotalPrice") = drItem.Item("TotalPrice")
                .Item("PCQuantity") = 0
                .Item("PCWeight") = 0
                .Item("DCQuantity") = 0
                .Item("DCWeight") = 0
                .Item("Remarks") = drItem.Item("Remarks")
                .EndEdit()
            End With
            dtParentItem.Rows.Add(drNewItem)
        Next

        dtParentItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()
        frmParent.grdItemView.ExpandAllGroups()

        If bolIsNew Then
            txtOrderNumberSupplier.Text = ""
            txtDeliveryAddress.Text = ""
            dtItem.Clear()
        Else
            Me.Close()
        End If
    End Sub

#Region "Item"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarItemOrder
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Public Function pubGetAllData() As DataTable
        Dim dtData As DataTable = dtParentItem.Clone
        For Each dr As DataRow In dtParentItem.Rows
            dtData.ImportRow(dr)
        Next

        For Each dr As DataRow In dtItem.Rows
            dtData.ImportRow(dr)
        Next
        Return dtData
    End Function

    Private Sub prvAddItem()
        Dim frmDetail As New frmTraConfirmationOrderDetItemOrder
        With frmDetail
            .pubIsNew = True
            .pubBPID = intBPID
            .pubTableItem = dtItem
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
        End With
    End Sub

    Private Sub prvEditItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraConfirmationOrderDetItemOrder
        With frmDetail
            .pubIsNew = False
            .pubBPID = intBPID
            .pubTableItem = dtItem
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
        End With
    End Sub

    Private Sub prvDeleteItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtItem.AcceptChanges()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraConfirmationOrderDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraConfirmationOrderDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItemOrder.SetIcon(Me)
        prvSetGrid()
        prvFillForm()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItemOrder_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemOrder.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItem()
            Case "Edit" : prvEditItem()
            Case "Hapus" : prvDeleteItem()
        End Select
    End Sub

#End Region

End Class