Public Class frmTraSalesContractDetItemVer2ChangeItem

#Region "Property"

    Private frmParent As frmTraSalesContractDetItemVer2
    Private intItemIDOld As Integer = 0
    Private intItemIDNew As Integer = 0
    Private strCODetailIDOld As String = ""
    Private strCODetailIDNew As String = ""
    Private drSelected As DataRow
    Private strID As String = ""
    Private bolIsSave As Boolean = False
    Private clsCS As VO.CS
    Private decUnitPrice As Decimal
    Private decWeight As Decimal
    Private decTotalWeight As Decimal

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

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public WriteOnly Property pubWeight As Decimal
        Set(value As Decimal)
            decWeight = value
        End Set
    End Property

    Public WriteOnly Property pubTotalWeight As Decimal
        Set(value As Decimal)
            decTotalWeight = value
        End Set
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
            strID = drSelected.Item("ID")
            txtCONumber.Text = drSelected.Item("CONumber")
            txtOrderNumberSupplier.Text = drSelected.Item("OrderNumberSupplier")
            strCODetailIDOld = drSelected.Item("OrderNumberSupplier")
            intItemIDOld = drSelected.Item("ItemID")
            txtItemCodeOld.Text = drSelected.Item("ItemCode")
            txtItemNameOld.Text = drSelected.Item("ItemName")
            txtThickOld.Value = drSelected.Item("Thick")
            txtWidthOld.Value = drSelected.Item("Width")
            txtLengthOld.Value = drSelected.Item("Length")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtItemCodeNew.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih item terlebih dahulu")
            txtItemCodeNew.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Anda yakin ingin mengganti barang menjadi " & txtItemNameNew.Text.Trim & "?") Then Exit Sub

        Try
            Dim clsData As New VO.SalesContractDetConfirmationOrder With {
                .ID = strID,
                .SCID = drSelected.Item("SCID"),
                .GroupID = drSelected.Item("GroupID"),
                .CODetailID = strCODetailIDNew,
                .OrderNumberSupplier = txtOrderNumberSupplierNew.Text.Trim,
                .ItemID = intItemIDNew,
                .UnitPrice = decUnitPrice,
                .TotalPrice = decTotalWeight * decUnitPrice
            }
            BL.SalesContract.ChangeCODetailItem(clsData)
            UI.usForm.frmMessageBox("Data berhasil diubah")
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraConfirmationOrderOutstandingSalesContractVer1
        With frmDetail
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookUpGet Then
                txtCONumberNew.Text = .pubLUdtRow.Item("CONumber")
                strCODetailIDNew = .pubLUdtRow.Item("ID")
                txtOrderNumberSupplierNew.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                intItemIDNew = .pubLUdtRow.Item("ItemID")
                txtItemCodenew.Text = .pubLUdtRow.Item("ItemCode")
                txtItemNamenew.Text = .pubLUdtRow.Item("ItemName")
                txtThickNew.Value = .pubLUdtRow.Item("Thick")
                txtWidthNew.Value = .pubLUdtRow.Item("Width")
                txtLengthNew.Value = .pubLUdtRow.Item("Length")
                decUnitPrice = .pubLUdtRow.Item("UnitPrice")
            End If
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemVer2ChangeItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemVer2ChangeItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnCO_Click(sender As Object, e As EventArgs) Handles btnCO.Click
        prvChooseItem()
    End Sub

#End Region

End Class