Imports DevExpress.XtraGrid
Public Class frmTraCuttingDetItem

#Region "Property"

    Private frmParent As frmTraCuttingDet
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private strPODetailID As String = ""
    Private intBPID As Integer = 0
    Private intItemID As Integer = 0
    Private intPos As Integer = 0
    Private intGroupID As Integer = 0
    Private clsCS As VO.CS
    Private dtItemResultParent As New DataTable
    Private dtItem As New DataTable
    Private drSelectedItem As DataRow
    Private dtResult As New DataTable
    Private strPOID As String = ""

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubTableItemResultParent As DataTable
        Set(value As DataTable)
            dtItemResultParent = value
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

    Public WriteOnly Property pubPOID As String
        Set(value As String)
            strPOID = value
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
        UI.usForm.SetGrid(grdItemResultView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "CuttingID", "CuttingID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemResultView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemResultView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
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
        grdItemResult.DataSource = dtResult
        prvSumGrid()
        prvSetButtonItemResult()
    End Sub

    Private Sub prvSumGrid()
        '# Item Result
        Dim SumTotalQuantityOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeightOrder As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")

        If grdItemResultView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemResultView.Columns("Quantity").Summary.Add(SumTotalQuantityOrder)
        End If

        If grdItemResultView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemResultView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightOrder)
        End If
        grdItemResultView.BestFitColumns()
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            dtResult = dtItemResultParent.Clone
            Me.Cursor = Cursors.Default
            If bolIsNew Then
                prvClear()
            Else
                strID = drSelectedItem.Item("ID")
                txtOrderNumberSupplier.Text = drSelectedItem.Item("OrderNumberSupplier")
                strPODetailID = drSelectedItem.Item("PODetailID")
                txtPONumber.Text = drSelectedItem.Item("PONumber")
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

                For Each dr As DataRow In dtItemResultParent.Rows
                    If dr.Item("GroupID") = intGroupID Then dtResult.ImportRow(dr)
                Next
                dtResult.AcceptChanges()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If txtPONumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih barang terlebih dahulu")
            txtPONumber.Focus()
            Exit Sub
        ElseIf txtItemCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih barang terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        ElseIf txtQuantity.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        ElseIf grdItemResultView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Pilih barang yang akan dihasilkan terlebih dahulu")
            grdItemResultView.Focus()
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
                .Item("CuttingID") = ""
                .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                .Item("PODetailID") = strPODetailID
                .Item("PONumber") = txtPONumber.Text.Trim
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
                        .Item("CuttingID") = ""
                        .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                        .Item("PODetailID") = strPODetailID
                        .Item("PONumber") = txtPONumber.Text.Trim
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

        '# Item Result Item
        For Each dr As DataRow In dtItemResultParent.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtItemResultParent.AcceptChanges()

        For Each dr As DataRow In dtResult.Rows
            dr.BeginEdit()
            dr.Item("GroupID") = intGroupID
            dr.EndEdit()
            dtItemResultParent.ImportRow(dr)
        Next
        dtItemResultParent.AcceptChanges()
        frmParent.grdItemResultView.BestFitColumns()
        Me.Close()
    End Sub

    Private Sub prvClear()
        strID = ""
        txtPONumber.Text = ""
        txtPONumber.Focus()
        strPODetailID = ""
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
        Dim frmDetail As New frmTraPurchaseOrderCuttingOutstandingItem
        With frmDetail
            .pubParentItem = dtItem
            .pubBPID = intBPID
            .pubCS = clsCS
            .pubPOID = strPOID
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookupGet Then
                txtPONumber.Text = .pubLUdtRow.Item("PONumber")
                txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                strPODetailID = .pubLUdtRow.Item("ID")
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

    Private Sub prvToolsHandles()
        Dim bolEnabled As Boolean = IIf(grdItemResultView.RowCount = 0, True, False)
        btnPOItem.Enabled = bolEnabled
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
    End Sub

#Region "Item Result Item"

    Private Sub prvSetButtonItemResult()
        Dim bolEnabled As Boolean = IIf(grdItemResultView.RowCount = 0, False, True)
        With ToolBarItemResult
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvAddItemResult()
        If intItemID = 0 Then
            UI.usForm.frmMessageBox("Pilih pesanan pemotongan barang terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim frmDetail As New frmTraCuttingDetItemResult
        With frmDetail
            .pubIsNew = True
            .pubCS = clsCS
            .pubBPID = intBPID
            .pubTableItemResultParent = dtResult
            .pubPODetailID = strPODetailID
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemResult()
            prvToolsHandles()
        End With
    End Sub

    Private Sub prvEditItemResult()
        intPos = grdItemResultView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        
        Dim frmDetail As New frmTraCuttingDetItemResult
        With frmDetail
            .pubIsNew = False
            .pubCS = clsCS
            .pubBPID = intBPID
            .pubTableItemResultParent = dtResult
            .pubDataRowSelected = grdItemResultView.GetDataRow(intPos)
            .pubPODetailID = strPODetailID
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButtonItemResult()
            prvToolsHandles()
        End With
    End Sub

    Private Sub prvDeleteItemResult()
        intPos = grdItemResultView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemResultView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtResult.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtResult.AcceptChanges()
        prvToolsHandles()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraCuttingDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraCuttingDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItemResult.SetIcon(Me)
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

    Private Sub ToolBarItemResult_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItemResult.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItemResult()
            Case "Edit" : prvEditItemResult()
            Case "Hapus" : prvDeleteItemResult()
        End Select
    End Sub

    Private Sub btnPOItem_Click(sender As Object, e As EventArgs) Handles btnPOItem.Click
        prvChooseItem()
    End Sub

    Private Sub txtQuantity_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class