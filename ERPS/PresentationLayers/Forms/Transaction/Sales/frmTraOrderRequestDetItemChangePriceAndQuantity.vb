Public Class frmTraOrderRequestDetItemChangePriceAndQuantity

#Region "Property"

    Private frmParent As frmTraOrderRequestDet
    Private drSelected As DataRow
    Private intItemID As Integer = 0
    Private strID As String = ""
    Private bolIsStock As Boolean
    Private bolIsSave As Boolean = False
    Private clsData As New VO.OrderRequestDet

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

    Public WriteOnly Property pubIsStock As Boolean
        Set(value As Boolean)
            bolIsStock = value
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

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim clsData As VO.OrderRequestDet = BL.OrderRequest.GetDetailItem(strID)
            strID = drSelected.Item("ID")
            intItemID = clsData.ItemID
            txtItemCode.Text = clsData.ItemCode
            txtItemName.Text = clsData.ItemName
            txtThick.Value = clsData.Thick
            txtWidth.Value = clsData.Width
            txtLength.Value = clsData.Length
            txtWeight.Value = clsData.Weight
            txtUnitPrice.Value = clsData.UnitPrice
            txtQuantity.Value = clsData.Quantity
            txtTotalWeight.Value = clsData.TotalWeight
            txtTotalPrice.Value = clsData.TotalPrice
            txtRemarks.Text = clsData.Remarks
            txtOrderNumberSupplier.Text = clsData.OrderNumberSupplier
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If Not UI.usForm.frmAskQuestion("Anda yakin ingin mengubah barang ini?") Then Exit Sub
        Exit Sub
        Try
            BL.OrderRequest.ChangeItemPriceAndQuantityDetail(strID, clsData)
            UI.usForm.frmMessageBox("Data berhasil diubah")
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

#Region "Form Handle"

    Private Sub frmTraOrderRequestDetItemChangePriceAndQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraOrderRequestDetItemChangePriceAndQuantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

#End Region

End Class