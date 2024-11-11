Public Class frmTraSalesContractDetItemCOVer2AddAdditional

#Region "Property"

    Private frmParent As frmTraSalesContractDetItemVer2
    Private intItemID As Integer = 0
    Private strID As String = ""
    Private strCODetailID As String
    Private clsCS As VO.CS
    Private intPos As Integer
    Private bolIsAutoSearch As Boolean
    Private intBPID As Integer = 0
    Private intLocationID As Integer = 0
    Private strDeliveryAddress As String = ""
    Private strSCID As String = ""
    Private intGroupID As Integer = 0
    Private bolIsSave As Boolean = False
    Private dtParentAll As New DataTable

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public WriteOnly Property pubTableParentAll As DataTable
        Set(value As DataTable)
            dtParentAll = value
        End Set
    End Property

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public WriteOnly Property pubIsAutoSearch As Boolean
        Set(value As Boolean)
            bolIsAutoSearch = value
        End Set
    End Property

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubSCID As String
        Set(value As String)
            strSCID = value
        End Set
    End Property

    Public WriteOnly Property pubGroupID As Integer
        Set(value As Integer)
            intGroupID = value
        End Set
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

    Public WriteOnly Property pubdtParentAll As DataTable
        Set(value As DataTable)
            dtParentAll = value
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

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboItemType, BL.ItemType.ListDataForCombo, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, BL.ItemSpecification.ListDataForCombo, "ID", "Description")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvSave()
        If txtCONumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih No. Konfirmasi terlebih dahulu")
            txtCONumber.Focus()
            Exit Sub
        ElseIf txtItemCode.Text.Trim = "" Then
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
        ElseIf txtUnitPrice.Value <= 0 Then
            UI.usForm.frmMessageBox("Harga harus lebih besar dari 0")
            txtUnitPrice.Focus()
            Exit Sub
        ElseIf txtQuantity.Value <= 0 Then
            UI.usForm.frmMessageBox("Jumlah harus lebih besar dari 0")
            txtQuantity.Focus()
            Exit Sub
        ElseIf txtWeight.Value <= 0 Then
            UI.usForm.frmMessageBox("Berat harus lebih besar dari 0")
            txtWeight.Focus()
            Exit Sub
        ElseIf intLocationID = 0 Or txtBPLocationAddress.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih alamat pengiriman terlebih dahulu")
            txtBPLocationAddress.Focus()
            Exit Sub
        End If
        Dim clsData As New VO.SalesContractDetConfirmationOrder
        clsData.ID = ""
        clsData.SCID = strSCID
        clsData.CODetailID = strCODetailID
        clsData.GroupID = intGroupID
        clsData.OrderNumberSupplier = txtOrderNumberSupplier.Text.Trim
        clsData.ItemID = intItemID
        clsData.Quantity = txtQuantity.Value
        clsData.Weight = txtWeight.Value
        clsData.TotalWeight = txtTotalWeight.Value
        clsData.UnitPrice = txtUnitPrice.Value
        clsData.TotalPrice = txtTotalPrice.Value
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.LevelItem = 0
        clsData.ParentID = ""
        clsData.LocationID = intLocationID

        Try
            If BL.SalesContract.AddAdditionalCOItem(clsData) Then
                UI.usForm.frmMessageBox("Data berhasil disimpan.")
                bolIsSave = True
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub prvChooseItem()
        Dim frmDetail As New frmTraConfirmationOrderOutstandingSalesContractVer1
        With frmDetail
            .pubParentItem = dtParentAll
            .pubCS = clsCS
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            If .pubIsLookUpGet Then
                txtCONumber.Text = .pubLUdtRow.Item("CONumber")
                strCODetailID = .pubLUdtRow.Item("ID")
                txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                intItemID = .pubLUdtRow.Item("ItemID")
                cboItemType.SelectedValue = .pubLUdtRow.Item("ItemTypeID")
                txtItemCode.Text = .pubLUdtRow.Item("ItemCode")
                txtItemName.Text = .pubLUdtRow.Item("ItemName")
                cboItemSpecification.SelectedValue = .pubLUdtRow.Item("ItemSpecificationID")
                txtThick.Value = .pubLUdtRow.Item("Thick")
                txtWidth.Value = .pubLUdtRow.Item("Width")
                txtLength.Value = .pubLUdtRow.Item("Length")
                txtWeight.Value = .pubLUdtRow.Item("Weight")
                txtMaxTotalWeight.Value = .pubLUdtRow.Item("TotalWeight")
                txtUnitPrice.Value = .pubLUdtRow.Item("UnitPrice")
                txtQuantity.Value = .pubLUdtRow.Item("Quantity")
                txtWeight.Focus()
                txtRemarks.Text = ""
                bolIsAutoSearch = False
            Else
                If bolIsAutoSearch Then Me.Close()
            End If
        End With
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtWeight.Value * txtQuantity.Value
        txtTotalPrice.Value = txtUnitPrice.Value * txtTotalWeight.Value
    End Sub

    Private Sub prvChooseBPLocation()
        Dim frmDetail As New frmMstBusinessPartnerLocation
        With frmDetail
            .pubIsLookUp = True
            .pubBPID = intBPID
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intLocationID = .pubLUdtRow.Item("ID")
                txtBPLocationAddress.Text = .pubLUdtRow.Item("Address")
            End If
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDetItemCOVer2AddAdditional_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetItemCOVer2AddAdditional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillCombo()
        If bolIsAutoSearch Then prvChooseItem()
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

    Private Sub btnBPLocation_Click(sender As Object, e As EventArgs) Handles btnBPLocation.Click
        prvChooseBPLocation()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.ValueChanged, txtQuantity.ValueChanged, txtWeight.ValueChanged
        prvCalculate()
    End Sub

#End Region
    
End Class