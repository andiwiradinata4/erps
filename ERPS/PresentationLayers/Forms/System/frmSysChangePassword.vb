Public Class frmSysChangePassword

#Region "Property"

    Property pubUserID As String = ERPSLib.UI.usUserApp.UserID
    Private clsData As VO.User

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvSave()
        If txtUserID.Text.Trim = "" Then
            UI.usForm.frmMessageBox("User ID kosong")
            txtUserID.Focus()
            Exit Sub
        ElseIf txtOldPassword.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Password lama belum diinput")
            txtOldPassword.Focus()
            Exit Sub
        ElseIf txtNewPassword.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Password baru belum diinput")
            txtNewPassword.Focus()
            Exit Sub
        ElseIf txtConfirmPassword.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Konfirmasi password belum diinput")
            txtConfirmPassword.Focus()
            Exit Sub
        ElseIf txtNewPassword.Text.Trim <> txtConfirmPassword.Text.Trim Then
            UI.usForm.frmMessageBox("Password baru dan konfirmasi password tidak sama")
            txtConfirmPassword.Focus()
            Exit Sub
        End If

        clsData = New VO.User
        clsData.ID = txtUserID.Text.Trim
        clsData.Password = txtNewPassword.Text.Trim
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        Try
            BL.User.ChangePassword(clsData, txtOldPassword.Text.Trim)
            UI.usForm.frmMessageBox("Ubah password berhasil.")
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

#Region "Form Handle"

    Private Sub frmSysChangePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form ini?") Then Me.Close()
        End If
    End Sub

    Private Sub frmSysChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        txtUserID.Text = pubUserID
        txtOldPassword.CharacterCasing = CharacterCasing.Normal
        txtNewPassword.CharacterCasing = CharacterCasing.Normal
        txtConfirmPassword.CharacterCasing = CharacterCasing.Normal
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub chkShowOldPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowOldPassword.CheckedChanged
        txtOldPassword.UseSystemPasswordChar = Not chkShowOldPassword.Checked
    End Sub

    Private Sub chkShowNewPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowNewPassword.CheckedChanged
        txtNewPassword.UseSystemPasswordChar = Not chkShowNewPassword.Checked
    End Sub

    Private Sub chkShowConfirmPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowConfirmPassword.CheckedChanged
        txtConfirmPassword.UseSystemPasswordChar = Not chkShowConfirmPassword.Checked
    End Sub

#End Region

End Class