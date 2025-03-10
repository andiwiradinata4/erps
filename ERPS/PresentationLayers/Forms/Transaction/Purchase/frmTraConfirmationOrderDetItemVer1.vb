Imports DevExpress.XtraGrid
Public Class frmTraConfirmationOrderDetItemVer1

#Region "Property"

    Private frmParent As frmTraConfirmationOrderDetVer1
    Private dtParentItem As New DataTable
    Private dtParentSubItem As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private intBPID As Integer = 0
    Private strPODetailID As String
    Private strID As String = ""
    Private strOrderNumberSupplier As String = ""
    Private intPos As Integer = 0
    Private dtItem As New DataTable
    Private dtSubItem As New DataTable
    Private clsCS As VO.CS
    Private intLevelItem As Integer = 0

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

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
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
        '# Detail
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

        '# Sub Detail
        UI.usForm.SetGrid(grdSubItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "COID", "COID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "PONumber", "Nomor Pesanan", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "PODetailID", "PODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "DeliveryAddress", "Alamat Pengiriman", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "ItemName", "Nama Barang", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "Thick", "Tebal", 70, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "Width", "Lebar", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemView, "Length", "Panjang", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemTypeName", "Tipe", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "Quantity", "Quantity", 150, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemView, "Weight", "Weight", 70, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdSubItemView, "TotalWeight", "Total Berat", 250, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "TotalPrice", "Total Harga", 250, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "PCQuantity", "PCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdSubItemView, "PCWeight", "PCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdSubItemView, "DCQuantity", "DCQuantity", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdSubItemView, "DCWeight", "DCWeight", 100, UI.usDefGrid.gReal4Num, False)
        UI.usForm.SetGrid(grdSubItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            Me.Cursor = Cursors.Default
            dtItem = dtParentItem.Clone
            dtSubItem = dtParentSubItem.Clone
            If Not bolIsNew Then
                For Each dr As DataRow In dtParentItem.Rows
                    txtOrderNumberSupplier.Text = strOrderNumberSupplier
                    If dr.Item("OrderNumberSupplier") = strOrderNumberSupplier Then dtItem.ImportRow(dr) : txtDeliveryAddress.Text = dr.Item("DeliveryAddress")
                Next
                dtItem.AcceptChanges()

                For Each dr As DataRow In dtItem.Rows
                    For Each drItem As DataRow In dtParentSubItem.Rows
                        If dr.Item("ID") = drItem.Item("ParentID") Then dtSubItem.ImportRow(drItem)
                    Next
                Next

                dtSubItem.AcceptChanges()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvQuery()
        Dim dsMain As New DataSet
        dsMain.Tables.Add(dtItem)
        dsMain.Tables.Add(dtSubItem)
        dsMain.Relations.Add("SubItem", dtItem.Columns.Item("ID"), dtSubItem.Columns.Item("ParentID"))
        grdItem.DataSource = dtItem
        grdItem.LevelTree.Nodes.Add("SubItem", grdSubItemView)
        grdItem.Refresh()
        prvSumGrid()
        prvSetButtonItem()
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

        grdItemView.BestFitColumns()

        '# Sub Item
        Dim SumTotalQuantitySubItem As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightSubItem As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceSubItem As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubItemView.Columns("Quantity").Summary.Add(SumTotalQuantitySubItem)
        End If

        If grdSubItemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubItemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightSubItem)
        End If

        If grdSubItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubItemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceSubItem)
        End If

        For i As Integer = 0 To grdItemView.RowCount - 1
            grdItemView.ExpandMasterRow(i, "SubItem")
        Next
    End Sub

    Private Sub prvSave()
        If txtOrderNumberSupplier.Text.Trim = "" And Not chkGenerate.Checked Then
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
                    For Each drItem As DataRow In dtParentSubItem.Rows
                        If dr.Item("ID") = drItem.Item("ParentID") Then drItem.Delete()
                    Next
                    dtParentSubItem.AcceptChanges()
                    dr.Delete()
                End If
            Next
            dtParentItem.AcceptChanges()
        Else
            If chkGenerate.Checked Then txtOrderNumberSupplier.Text = Format(Now, "yyyyMMddHHmmssss")
        End If

        '# Item Handle
        For Each drItem As DataRow In dtItem.Rows
            Dim drNewItem As DataRow = dtParentItem.NewRow
            With drNewItem
                .BeginEdit()
                .Item("ID") = drItem.Item("ID")
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
                .Item("LevelItem") = drItem.Item("LevelItem")
                .Item("ParentID") = drItem.Item("ParentID")
                .EndEdit()
            End With
            dtParentItem.Rows.Add(drNewItem)
        Next
        dtParentItem.AcceptChanges()

        For Each drItem As DataRow In dtItem.Rows
            For Each drSubItem As DataRow In dtSubItem.Rows
                If drItem.Item("ID") = drSubItem.Item("ParentID") Then
                    drSubItem.BeginEdit()
                    drSubItem.Item("DeliveryAddress") = txtDeliveryAddress.Text.Trim
                    drSubItem.Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                    drSubItem.EndEdit()
                    dtParentSubItem.ImportRow(drSubItem)
                End If
            Next
        Next
        dtParentSubItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()
        frmParent.grdItemView.ExpandAllGroups()
        Me.Close()
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
            Dim drSelected() As DataRow = dtData.Select("PODetailID='" & dr.Item("PODetailID") & "'")
            If drSelected.Length = 0 Then dtData.ImportRow(dr)
        Next

        Return dtData
    End Function

    Public Function pubGetAllDataSubItem() As DataTable
        Dim dtData As DataTable = dtParentSubItem.Clone
        For Each dr As DataRow In dtParentSubItem.Rows
            dtData.ImportRow(dr)
        Next

        For Each dr As DataRow In dtSubItem.Rows
            Dim drSelected() As DataRow = dtData.Select("PODetailID='" & dr.Item("PODetailID") & "'")
            If drSelected.Length = 0 Then dtData.ImportRow(dr)
        Next

        Return dtData
    End Function

    Private Sub prvUpdateFromHeader()
        For Each dr As DataRow In dtItem.Rows
            dr.BeginEdit()
            dr.Item("DeliveryAddress") = txtDeliveryAddress.Text.Trim
            dr.Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
            dr.EndEdit()
        Next
        dtItem.AcceptChanges()

        For Each dr As DataRow In dtSubItem.Rows
            dr.BeginEdit()
            dr.Item("DeliveryAddress") = txtDeliveryAddress.Text.Trim
            dr.Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
            dr.EndEdit()
        Next
        dtSubItem.AcceptChanges()

        For i As Integer = 0 To grdItemView.RowCount - 1
            grdItemView.ExpandMasterRow(i, "SubItem")
            grdSubItemView.BestFitColumns()
        Next
    End Sub

    Private Sub prvAddItem()
        Dim frmDetail As New frmTraConfirmationOrderDetItemOrderVer1
        With frmDetail
            .pubIsNew = True
            .pubID = Guid.NewGuid.ToString
            .pubBPID = intBPID
            .pubTableParentItem = dtItem
            .pubTableParentSubItem = dtSubItem
            .pubCS = clsCS
            .publevelItem = intLevelItem
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvUpdateFromHeader()
        End With
    End Sub

    Private Sub prvEditItem()
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = grdItem.FocusedView
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraConfirmationOrderDetItemOrderVer1
        With frmDetail
            .pubIsNew = False
            .pubBPID = intBPID
            .pubTableParentItem = dtItem
            .pubTableParentSubItem = dtSubItem
            .pubCS = clsCS
            .publevelItem = intLevelItem
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvUpdateFromHeader()
        End With
    End Sub

    Private Sub prvDeleteItem()
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = grdItem.FocusedView
        If view.Name <> "grdItemView" Then Exit Sub
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtItem.AcceptChanges()
        dtSubItem.AcceptChanges()
    End Sub

    Private Sub prvChooseDeliveryAddress()
        Dim frmDetail As New frmTraConfirmationOrderDetItemAddress
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsLookUpGet Then txtDeliveryAddress.Text = .pubLUdtRow.Item("DeliveryAddress")
        End With
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

    Private Sub btnDeliveryAddress_Click(sender As Object, e As EventArgs) Handles btnDeliveryAddress.Click
        prvChooseDeliveryAddress()
    End Sub

#End Region

End Class