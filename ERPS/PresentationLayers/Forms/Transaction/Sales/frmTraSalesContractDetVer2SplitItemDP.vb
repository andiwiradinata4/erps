Public Class frmTraSalesContractDetVer2SplitItemDP

#Region "Property"

    Private clsARAPItem As New VO.ARAPItem
    Private drData As DataRow
    Private decUnitPrice As Decimal
    Private bolIsSave As Boolean
    Private frmParent As frmTraSalesContractDetVer2SplitItem

    Public WriteOnly Property pubClsARAPItem As VO.ARAPItem
        Set(value As VO.ARAPItem)
            clsARAPItem = value
        End Set
    End Property

    Public Property pubDrData As DataRow
        Set(value As DataRow)
            drData = value
        End Set
        Get
            Return drData
        End Get
    End Property

    Public WriteOnly Property pubUnitPrice As Decimal
        Set(value As Decimal)
            decUnitPrice = value
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

    Private Sub prvFillForm()
        txtQuantity.Value = drData.Item("Quantity")
        txtWeight.Value = drData.Item("Weight")
        txtTotalWeight.Value = drData.Item("TotalWeight")
        txtUnitPrice.Value = decUnitPrice
        txtTotalPrice.Value = txtTotalWeight.Value * txtUnitPrice.Value
        txtPercentage.Value = clsARAPItem.Percentage
        prvCalculate()
    End Sub

    Private Sub prvCalculate()
        txtTotalWeight.Value = txtQuantity.Value * txtWeight.Value
        txtTotalPrice.Value = txtTotalWeight.Value * txtUnitPrice.Value
        txtTotalAmount.Value = ERPSLib.SharedLib.Math.Round(txtTotalPrice.Value * txtPercentage.Value / 100, 2)
        txtPPN.Value = ERPSLib.SharedLib.Math.Round(txtTotalAmount.Value * drData.Item("PPNPercent") / 100, 2)
        txtPPH.Value = ERPSLib.SharedLib.Math.Round(txtTotalAmount.Value * drData.Item("PPHPercent") / 100, 2)
        txtGrandTotal.Value = txtTotalAmount.Value + txtPPN.Value - txtPPH.Value
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()

        If drData.Item("TotalWeight") - txtTotalWeight.Value < 0 Then
            UI.usForm.frmMessageBox("Total berat tidak boleh melebihi nilai Total Berat Awal [ " & drData.Item("TotalWeight") & " ]")
            txtWeight.Focus()
            Exit Sub
        ElseIf drData.Item("Amount") - txtTotalAmount.Value < 0 Then
            UI.usForm.frmMessageBox("Total DPP tidak boleh melebihi nilai Total DPP Awal [ " & drData.Item("Amount") & " ]")
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf drData.Item("PPN") - txtPPN.Value < 0 Then
            UI.usForm.frmMessageBox("Total PPN tidak boleh melebihi nilai Total PPN Awal [ " & drData.Item("PPN") & " ]")
            txtPPN.Focus()
            Exit Sub
        ElseIf drData.Item("PPH") - txtPPH.Value < 0 Then
            UI.usForm.frmMessageBox("Total PPH tidak boleh melebihi nilai Total PPH Awal [ " & drData.Item("PPH") & " ]")
            txtPPH.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan Data?") Then Exit Sub

        drData.BeginEdit()
        drData.Item("Quantity") = txtQuantity.Value
        drData.Item("Weight") = txtWeight.Value
        drData.Item("TotalWeight") = txtTotalWeight.Value
        drData.Item("Amount") = txtTotalAmount.Value
        drData.Item("PPN") = txtPPN.Value
        drData.Item("PPH") = txtPPH.Value
        drData.EndEdit()

        bolIsSave = True
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDetVer2SplitItemDP_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraSalesContractDetVer2SplitItemDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub txtValue_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged,
        txtWeight.ValueChanged, txtTotalAmount.ValueChanged, txtPPN.ValueChanged, txtPPH.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class