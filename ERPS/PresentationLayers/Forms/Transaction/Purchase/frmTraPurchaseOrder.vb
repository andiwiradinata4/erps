Public Class frmTraPurchaseOrder

    Private intPos As Integer = 0
    Private clsData As New VO.OrderRequest
    Private intProgramID As Integer
    Private intCompanyID As Integer
    Private dtData As New DataTable

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3,
       cSubmit As Byte = 4, cCancelSubmit As Byte = 5, cSep2 As Byte = 6, cExportExcel As Byte = 7,
       cSep3 As Byte = 8, cRefresh As Byte = 9, cClose As Byte = 10

#Region "Form Handle"

    Private Sub frmTraPurchaseOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    'Private Sub frmTraPurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    UI.usForm.SetIcon(Me, "MyLogo")
    '    ToolBar.SetIcon(Me)
    '    prvFillCombo()
    '    prvSetGrid()
    '    cboStatus.SelectedValue = VO.Status.Values.All
    '    dtpDateFrom.Value = Today.Date.AddDays(-7)
    '    dtpDateTo.Value = Today.Date
    '    prvDefaultFilter()
    '    prvQuery()
    '    prvUserAccess()
    '    Me.WindowState = FormWindowState.Maximized
    'End Sub

    'Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
    '    If e.Button.Name = ToolBar.Buttons(cNew).Name Then
    '        prvNew()
    '    ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
    '        pubRefresh()
    '    ElseIf e.Button.Name = ToolBar.Buttons(cClose).Name Then
    '        Me.Close()
    '    ElseIf grdView.FocusedRowHandle >= 0 Then
    '        Select Case e.Button.Name
    '            Case ToolBar.Buttons(cDetail).Name : prvDetail()
    '            Case ToolBar.Buttons(cDelete).Name : prvDelete()
    '            Case ToolBar.Buttons(cSubmit).Name : prvSubmit()
    '            Case ToolBar.Buttons(cCancelSubmit).Name : prvCancelSubmit()
    '            Case ToolBar.Buttons(cExportExcel).Name : prvExportExcel()
    '        End Select
    '    End If
    'End Sub

    'Private Sub btnCompany_Click(sender As Object, e As EventArgs) Handles btnCompany.Click
    '    prvChooseCompany()
    'End Sub

    'Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
    '    prvQuery()
    'End Sub

    'Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
    '    prvClear()
    'End Sub

    'Private Sub grdView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
    '    Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
    '    If (e.RowHandle >= 0) Then
    '        Dim bolIsDeleted As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("IsDeleted"))
    '        If bolIsDeleted = "Checked" And e.Appearance.BackColor <> Color.Salmon Then
    '            e.Appearance.BackColor = Color.Salmon
    '            e.Appearance.BackColor2 = Color.SeaShell
    '        End If
    '    End If
    'End Sub

#End Region
    
End Class