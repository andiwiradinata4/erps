Public Class frmTraTransporterPriceListDetItem

    Private dtDeliveryLocation As New DataTable
    Private listSource As New List(Of VO.DeliveryLocation)
    Private listDestination As New List(Of VO.DeliveryLocation)

    Private Sub prvFillCombo()
        'dtDeliveryLocation = BL.DeliveryLocation.ListDataForCombo(False)
        'UI.usForm.FillComboBoxEdit(cboSource, dtDeliveryLocation, "ID", "Description", "Lokasi")
        'UI.usForm.FillComboBoxEdit(cboDestination, dtDeliveryLocation, "ID", "Description", "Lokasi")
    End Sub

    Private Sub prvSave()

    End Sub

#Region "Form Handle"

    Private Sub frmTraTransporterPriceListDetItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraTransporterPriceListDetItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick

    End Sub

#End Region

End Class