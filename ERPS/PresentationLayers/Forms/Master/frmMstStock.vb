Public Class frmMstStock

#Region "Properties"

    Private dtData As New DataTable
    Private dtParent As New DataTable
    Private drLUdtRow As DataRow
    Private bolIsLookUp As Boolean = False
    Private bolIsLookUpGet As Boolean = False

    Public WriteOnly Property pubDataParent As DataTable
        Set(value As DataTable)
            dtParent = value
        End Set
    End Property

    Public ReadOnly Property pubLUdtRow As DataRow
        Get
            Return drLUdtRow
        End Get
    End Property

    Public WriteOnly Property pubIsLookUp As Boolean
        Set(value As Boolean)
            bolIsLookUp = value
        End Set
    End Property

    Public ReadOnly Property pubIsLookUpGet As Boolean
        Get
            Return bolIsLookUpGet
        End Get
    End Property

#End Region

    Private Const _
       cGet As Byte = 0, cSep1 As Byte = 1, cHistorySalesContract As Byte = 2, cHistoryPurchaseContract As Byte = 3, cSep2 As Byte = 4, cRefresh As Byte = 5, cClose As Byte = 6

    Private Sub prvSetTitleForm()
        If bolIsLookUp Then
            Me.Text += " [Lookup] "
        End If
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, bolIsLookUp)
        UI.usForm.SetGrid(grdView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemCodeExternal", "Kode Barang Eksternal", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ItemTypeName", "Jenis Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Thick", "Tebal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Width", "Lebar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Length", "Panjang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Weight", "Berat", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdView, "StatusID", "StatusID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "StatusInfo", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Balance", "Sisa Stok", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "UnitPrice", "Harga Beli", 100, UI.usDefGrid.gReal2Num, bolIsLookUp)
        UI.usForm.SetGrid(grdView, "OnProgressBalance", "Sisa Stok yang belum dikirim", 100, UI.usDefGrid.gReal2Num, False)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cGet).Visible = bolIsLookUp
            .Item(cSep1).Visible = bolIsLookUp
            .Item(cGet).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboItemType, BL.ItemType.ListDataForCombo, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, BL.ItemSpecification.ListDataForCombo, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvQuery()
        Try
            dtData = BL.Stock.ListData(cboItemType.SelectedValue, cboItemSpecification.SelectedValue, chkShowAll.Checked, bolIsLookUp)

            For Each dr As DataRow In dtData.Rows
                If dtParent.Rows.Count = 0 Then Exit For
                Dim drExists() As DataRow = dtParent.Select("OrderNumberSupplier='" & dr.Item("OrderNumberSupplier") & "' AND ItemID=" & dr.Item("ID"))
                If drExists.Length > 0 Then dr.Delete()
            Next
            dtData.AcceptChanges()

            grdMain.DataSource = dtData
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("ItemCode")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "ItemCode", strSearch)
        End With
    End Sub

    Private Sub prvGet()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not bolIsLookUp Then Exit Sub
        If grdView.GetRowCellValue(intPos, "StatusID") = VO.Status.Values.InActive Then
            UI.usForm.frmMessageBox("Tidak dapat pilih barang " & grdView.GetRowCellValue(intPos, "ItemCode") & " | " & grdView.GetRowCellValue(intPos, "ItemName") & ". Dikarenakan data tersebut sudah tidak aktif")
            Exit Sub
        ElseIf grdView.GetRowCellValue(intPos, "Balance") <= 0 Then
            UI.usForm.frmMessageBox("Tidak dapat pilih barang " & grdView.GetRowCellValue(intPos, "ItemCode") & " | " & grdView.GetRowCellValue(intPos, "ItemName") & ". Dikarenakan Sisa Stock lebih kecil atau sama dengan 0")
            Exit Sub
        Else
            drLUdtRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolIsLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmMstItemDet
        With frmDetail
            .pubIsNew = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstItemDet
        With frmDetail
            .pubIsNew = False
            .pubID = grdView.GetRowCellValue(intPos, "ID")
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not UI.usForm.frmAskQuestion("Hapus data  " & grdView.GetRowCellValue(intPos, "ItemCode") & " | " & grdView.GetRowCellValue(intPos, "ItemName") & "?") Then Exit Sub
        Try
            BL.Item.DeleteData(grdView.GetRowCellValue(intPos, "ID"))
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "ItemCode"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvHistory(ByVal enumHistory As VO.Stock.History)
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstStockHistory
        With frmDetail
            .pubItemID = grdView.GetRowCellValue(intPos, "ID")
            .pubOrderNumberSupplier = grdView.GetRowCellValue(intPos, "OrderNumberSupplier")
            .pubHistory = enumHistory
            .ShowDialog()
        End With
    End Sub

    Private Sub prvHistoryPurchaseContract()

    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
        prvSetGrid()
        prvSetButton()
    End Sub

#Region "Form Handle"

    Private Sub frmMstStock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillCombo()
        prvSetButton()
        btnExecute.Focus()
        chkShowAll.Checked = bolIsLookUp
        If bolIsLookUp Then prvQuery()
        If Not bolIsLookUp Then Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cGet).Name : prvGet()
                Case ToolBar.Buttons(cHistorySalesContract).Name : prvHistory(VO.Stock.History.SalesContract)
                Case ToolBar.Buttons(cHistoryPurchaseContract).Name : prvHistory(VO.Stock.History.PurchaseContract)
            End Select
        End If
    End Sub

    Private Sub chkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAll.CheckedChanged
        cboItemSpecification.Enabled = Not chkShowAll.Checked
        cboItemType.Enabled = Not chkShowAll.Checked
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        prvClear()
    End Sub

    Private Sub grdMain_DoubleClick(sender As Object, e As EventArgs) Handles grdMain.DoubleClick
        If bolIsLookUp Then prvGet()
    End Sub

    Private Sub grdView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim StatusID As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StatusID"))
            If StatusID = VO.Status.Values.InActive Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

#End Region

End Class