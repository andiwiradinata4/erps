Public Class frmTraSalesServiceDetItem

#Region "Property"

    Private frmParent As frmTraSalesServiceDet
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private dtItem As New DataTable
    Private drSelectedItem As DataRow

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

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillCombo()
        Try
            Dim dtDeliveryLocation As DataTable = BL.DeliveryLocation.ListDataForCombo(False)
            UI.usForm.FillComboBoxEdit(cboSource, dtDeliveryLocation, "ID", "Description")
            UI.usForm.FillComboBoxEdit(cboDestination, dtDeliveryLocation, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            prvFillCombo()
            Me.Cursor = Cursors.Default
            If bolIsNew Then
                prvClear()
            Else
                strID = drSelectedItem.Item("ID")
                cboSource.EditValue = drSelectedItem.Item("SourceID")
                cboDestination.EditValue = drSelectedItem.Item("DestinationID")
                txtPlatNumber.Text = drSelectedItem.Item("PlatNumber")
                txtDeliveryNumber.Text = drSelectedItem.Item("DeliveryNumber")
                txtQuantity.EditValue = drSelectedItem.Item("Quantity")
                txtUnitPrice.EditValue = drSelectedItem.Item("Price")
                txtTotalPrice.EditValue = txtQuantity.EditValue * txtUnitPrice.EditValue
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtQuantity.EditValue <= 0 Then
            UI.usForm.frmMessageBox("Harga harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        ElseIf txtUnitPrice.editValue <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtUnitPrice.Focus()
            Exit Sub
        ElseIf cboSource.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Asal terlebih dahulu")
            cboSource.Focus()
            Exit Sub
        ElseIf cboDestination.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Tujuan terlebih dahulu")
            cboDestination.Focus()
            Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtItem.NewRow
            With drItem
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
                .Item("SourceID") = cboSource.EditValue
                .Item("SourceName") = cboSource.Text.Trim
                .Item("DestinationID") = cboDestination.EditValue
                .Item("DestinationName") = cboDestination.Text.Trim
                .Item("PlatNumber") = txtPlatNumber.Text.Trim
                .Item("DeliveryNumber") = txtDeliveryNumber.Text.Trim
                .Item("Quantity") = txtQuantity.EditValue
                .Item("Price") = txtUnitPrice.EditValue
                .Item("TotalPrice") = txtTotalPrice.EditValue
                .EndEdit()
            End With
            dtItem.Rows.Add(drItem)
        Else
            For Each dr As DataRow In dtItem.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("SourceID") = cboSource.EditValue
                        .Item("SourceName") = cboSource.Text.Trim
                        .Item("DestinationID") = cboDestination.EditValue
                        .Item("DestinationName") = cboDestination.Text.Trim
                        .Item("PlatNumber") = txtPlatNumber.Text.Trim
                        .Item("DeliveryNumber") = txtDeliveryNumber.Text.Trim
                        .Item("Quantity") = txtQuantity.EditValue
                        .Item("Price") = txtUnitPrice.EditValue
                        .Item("TotalPrice") = txtTotalPrice.EditValue
                        .EndEdit()
                    End If
                End With
            Next
        End If
        dtItem.AcceptChanges()
        'frmParent.grdItemView.BestFitColumns()
        prvClear()
        If Not bolIsNew Then Me.Close()
    End Sub

    Private Sub prvClear()
        strID = ""
        cboSource.Focus()
        cboSource.EditValue = 0
        cboDestination.EditValue = 0
        txtPlatNumber.Text = ""
        txtDeliveryNumber.Text = ""
        txtQuantity.EditValue = 0
        txtUnitPrice.EditValue = 0
        txtTotalPrice.EditValue = 0
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesServiceDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesServiceDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
    End Sub

    Private Sub Numberic_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.EditValueChanged, txtQuantity.EditValueChanged
        txtTotalPrice.EditValue = txtUnitPrice.EditValue * txtQuantity.EditValue
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

#End Region

End Class