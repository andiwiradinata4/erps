Public Class frmTraOrderRequestDetItem

#Region "Property"

    Private frmParent As frmTraOrderRequestDet
    Private dtParent As New DataTable
    Private bolIsNew As Boolean = False
    Private intItemID As Integer = 0
    Private drSelected As DataRow
    Private strID As String = ""

    Public WriteOnly Property pubTableParent As DataTable
        Set(value As DataTable)
            dtParent = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubDatRowSelected As DataRow
        Set(value As DataRow)
            drSelected = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave = 0, cClose = 1

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboItemType, BL.ItemType.ListDataForCombo, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, BL.ItemSpecification.ListDataForCombo, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        txtItemCode.Focus()
        strID = ""
        intItemID = 0
        txtItemCode.Text = ""
        cboItemType.SelectedIndex = -1
        txtItemName.Text = ""
        txtThick.Text = "0"
        txtWidth.Text = "0"
        txtLength.Text = "0"
        txtWeight.Value = 0
        cboItemSpecification.SelectedIndex = -1
        txtQuantity.Value = 0
        txtRemarks.Text = ""
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            If bolIsNew Then
                prvClear()
            Else
                strID = drSelected.Item("ID")
                intItemID = drSelected.Item("ItemID")
                txtItemCode.Text = drSelected.Item("ItemCode")
                txtItemName.Text = drSelected.Item("ItemName")
                cboItemType.SelectedValue = drSelected.Item("ItemTypeID")
                txtThick.Text = drSelected.Item("Thick")
                txtWidth.Text = drSelected.Item("Width")
                txtLength.Text = drSelected.Item("Length")
                txtWeight.Text = drSelected.Item("Weight")
                cboItemSpecification.SelectedValue = drSelected.Item("ItemSpecificationID")
                txtQuantity.Value = drSelected.Item("Quantity")
                txtRemarks.Text = drSelected.Item("Remarks")
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtItemCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih item terlebih dahulu")
            txtItemCode.Focus()
            Exit Sub
        ElseIf cboItemType.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Jenis barang tidak valid")
            cboItemType.Focus()
            Exit Sub
        ElseIf cboItemSpecification.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Spesifikasi barang tidak valid")
            cboItemSpecification.Focus()
            Exit Sub
        ElseIf txtQuantity.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        End If

        If bolIsNew Then
            Dim dr As DataRow
            dr = dtParent.NewRow
            dr.BeginEdit()
            dr.Item("ID") = Guid.NewGuid
            dr.Item("OrderRequestID") = ""
            dr.Item("ItemID") = intItemID
            dr.Item("ItemCode") = txtItemCode.Text.Trim
            dr.Item("ItemName") = txtItemName.Text.Trim
            dr.Item("Thick") = txtThick.Text.Trim
            dr.Item("Width") = txtWidth.Text.Trim
            dr.Item("Length") = txtLength.Text.Trim
            dr.Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
            dr.Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
            dr.Item("ItemTypeID") = cboItemType.SelectedValue
            dr.Item("ItemTypeName") = cboItemType.Text.Trim
            dr.Item("Quantity") = txtQuantity.Value
            dr.Item("Weight") = txtWeight.Value
            dr.Item("TotalWeight") = txtTotalWeight.Value
            dr.Item("POInternalQuantity") = 0
            dr.Item("POInternalWeight") = 0
            dr.Item("Remarks") = txtRemarks.Text.Trim
            dr.EndEdit()
            dtParent.Rows.Add(dr)
            dtParent.AcceptChanges()
            frmParent.grdItemView.BestFitColumns()
            prvClear()
        Else
            For Each dr As DataRow In dtParent.Rows
                If dr.Item("ID") = strID Then
                    dr.BeginEdit()
                    dr.Item("OrderRequestID") = ""
                    dr.Item("ItemID") = intItemID
                    dr.Item("ItemCode") = txtItemCode.Text.Trim
                    dr.Item("ItemName") = txtItemName.Text.Trim
                    dr.Item("Thick") = txtThick.Text.Trim
                    dr.Item("Width") = txtWidth.Text.Trim
                    dr.Item("Length") = txtLength.Text.Trim
                    dr.Item("ItemSpecificationID") = cboItemSpecification.SelectedValue
                    dr.Item("ItemSpecificationName") = cboItemSpecification.Text.Trim
                    dr.Item("ItemTypeID") = cboItemType.SelectedValue
                    dr.Item("ItemTypeName") = cboItemType.Text.Trim
                    dr.Item("Quantity") = txtQuantity.Value
                    dr.Item("Weight") = txtWeight.Value
                    dr.Item("TotalWeight") = txtTotalWeight.Value
                    dr.Item("POInternalQuantity") = 0
                    dr.Item("POInternalWeight") = 0
                    dr.Item("Remarks") = txtRemarks.Text.Trim
                    dr.EndEdit()
                    dtParent.AcceptChanges()
                    frmParent.grdItemView.BestFitColumns()
                    Exit For
                End If
            Next
            Me.Close()
        End If
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmMstItem
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intItemID = .pubLUdtRow.Item("ID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                txtThick.Text = .pubLUdtRow.Item("Thick")
                txtWidth.Text = .pubLUdtRow.Item("Width")
                txtLength.Text = .pubLUdtRow.Item("Length")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtQuantity.Value = 0
                txtQuantity.Focus()
                txtRemarks.Text = ""
            End If
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraOrderRequestDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraOrderRequestDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        prvChooseItem()
    End Sub

    Private Sub txtQuantity_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
    End Sub

#End Region
    
End Class