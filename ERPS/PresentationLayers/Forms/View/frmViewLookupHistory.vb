Public Class frmViewLookupHistory

#Region "Properties"

    Private dtData As New DataTable

    Public WriteOnly Property pubDtData As DataTable
        Set(value As DataTable)
            dtData = value
        End Set
    End Property

#End Region

    Private Const cClose As Byte = 0

#Region "Form Handle"

    Private Sub frmViewLookupHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmViewLookupHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar.SetIcon(Me)
        grdMain.DataSource = dtData
        grdView.BestFitColumns()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cClose).Name Then Me.Close()
    End Sub

#End Region
End Class