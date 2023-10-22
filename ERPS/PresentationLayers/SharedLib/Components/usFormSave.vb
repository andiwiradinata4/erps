Public Class usFormSave

#Region "Properties"

    Private intValue As VO.Save.Action
    Private bolIsSave As Boolean = False
    Private Const _
        cSave As Byte = 0, cClose = 1

    Public ReadOnly Property pubValue As VO.Save.Action
        Get
            Return intValue
        End Get
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

#End Region

    Private Sub prvSave()
        If Not rdSaveAsDraft.Checked And Not rdSaveAndSubmit.Checked And Not rdCancelSave.Checked Then
            UI.usForm.frmMessageBox("Pilih terlebih dahulu")
            rdSaveAsDraft.Focus()
            Exit Sub
        End If

        If rdCancelSave.Checked Then
            intValue = VO.Save.Action.CancelSave
            bolIsSave = False
            Me.Close()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        If rdSaveAsDraft.Checked Then
            intValue = VO.Save.Action.SaveAsDraft
        ElseIf rdSaveAndSubmit.Checked Then
            intValue = VO.Save.Action.SaveAndSubmit
        ElseIf rdCancelSave.Checked Then
            intValue = VO.Save.Action.CancelSave
        End If

        bolIsSave = True
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub usFormSave_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub usFormSave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class