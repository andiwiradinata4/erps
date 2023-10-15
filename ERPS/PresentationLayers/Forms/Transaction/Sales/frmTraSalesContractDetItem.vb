Imports DevExpress.XtraGrid
Public Class frmTraSalesContractDetItem

#Region "Property"

    Private frmParent As frmTraSalesContractDet
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private strORDetailID As String
    Private intBPID As Integer = 0
    Private intItemID As Integer = 0
    Private intPos As Integer = 0
    Private intGroupID As Integer = 0
    Private clsCS As VO.CS
    Private dtCOItemParent As New DataTable
    Private dtItem As New DataTable
    Private drSelectedItem As DataRow
    Private dtCO As New DataTable

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubTableCOItemParent As DataTable
        Set(value As DataTable)
            dtCOItemParent = value
        End Set
    End Property

    Public WriteOnly Property pubTableItem As DataTable
        Set(value As DataTable)
            dtItem = value
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
        UI.usForm.SetGrid(grdItemCOView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemCOView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemCOView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemCOView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
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
        '# Order | PO Detail
        Dim SumTotalQuantityOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
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
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            dtCO = dtCOItemParent.Clone
            Me.Cursor = Cursors.Default
            If Not bolIsNew Then
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

                For Each dr As DataRow In dtCOItemParent.Rows
                    If dr.Item("GroupID") = intGroupID Then dtCO.ImportRow(dr)
                Next
                dtCO.AcceptChanges()
            End If
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
        ElseIf txtMaxTotalWeight.Value < txtTotalWeight.Value Then
            If Not UI.usForm.frmAskQuestion("Total Berat melebihi Maks. Total Berat, Apakah anda yakin ingin melanjutkannya?") Then Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtItem.NewRow
            intGroupID = dtItem.Rows.Count + 1
            With drItem
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
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
                .EndEdit()
            End With
            dtItem.Rows.Add(drItem)
        Else
            For Each dr As DataRow In dtItem.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("COID") = ""
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
                        .EndEdit()
                    End If
                End With
            Next
        End If
        dtItem.AcceptChanges()
        frmParent.grdItemView.BestFitColumns()

        '# Confirmation Order Item
        For Each dr As DataRow In dtCOItemParent.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtCOItemParent.AcceptChanges()

        For Each dr As DataRow In dtCO.Rows
            dr.BeginEdit()
            dr.Item("GroupID") = intGroupID
            dr.EndEdit()
            dtCOItemParent.ImportRow(dr)
        Next
        dtCOItemParent.AcceptChanges()
        frmParent.grdItemCOView.BestFitColumns()
        Me.Close()
    End Sub

    Private Sub prvClear()
        strID = ""
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
        Dim frmDetail As New frmTraOrderRequestOutstandingItem
        With frmDetail
            .pubParentItem = dtItem
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
                txtQuantity.Focus()
                txtRemarks.Text = ""
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
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
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvAddItemConfirmationOrder()
        If intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih permintaan barang terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        ElseIf grdItemCOView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Pilih konfirmasi pesanan terlebih dahulu")
            grdItemCOView.Focus()
            Exit Sub
        End If

        Dim dtAllCO As DataTable = dtCO.Clone
        dtAllCO.Merge(dtCO)
        dtAllCO.Merge(dtCOItemParent)

        Dim frmDetail As New frmTraSalesContractDetItemCO
        With frmDetail
            .pubIsNew = True
            .pubTableParent = dtAllCO
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemConfirmationOrder()
            prvToolsHandles()
        End With
    End Sub

    Private Sub prvEditItemConfirmationOrder()
        intPos = grdItemCOView.FocusedRowHandle
        If intPos < 0 Then Exit Sub

        Dim dtAllCO As DataTable = dtCO.Clone
        dtAllCO.Merge(dtCO)
        dtAllCO.Merge(dtCOItemParent)

        Dim frmDetail As New frmTraSalesContractDetItemCO
        With frmDetail
            .pubIsNew = False
            .pubTableParent = dtAllCO
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemConfirmationOrder()
            prvToolsHandles()
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
        prvToolsHandles()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
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

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged
        prvCalculate()
    End Sub

#End Region


End Class