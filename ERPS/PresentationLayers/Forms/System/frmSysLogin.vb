Public Class frmSysLogin

#Region "Functional Handle"

    Private Sub prvLoadXML()
        Dim strXML As String = Application.StartupPath & "\ERPS-CONFIG.XML"
        If Not IO.File.Exists(strXML) Then
            UI.usForm.frmMessageBox("XML File Not Found ... ")
            Exit Sub
        End If

        Dim xmlHandle As New usXML(strXML)
        With xmlHandle
            VO.DefaultServer.Server = .GetConfigInfo("CONNECTION", "SERVER", ".").Item(1)
            VO.DefaultServer.Database = .GetConfigInfo("CONNECTION", "DATABASE", "TMS1").Item(1)
            VO.DefaultServer.UserID = .GetConfigInfo("CONNECTION", "USERID", "").Item(1)
            VO.DefaultServer.Password = .GetConfigInfo("CONNECTION", "PASSWORD", "").Item(1)
            VO.DefaultServer.StartFrom = .GetConfigInfo("CONNECTION", "STARTFROM", "2021/01/01").Item(1)
        End With
    End Sub

    Private Sub prvLogin()
        If txtUserID.Text.Trim = "" Then
            txtUserID.Focus()
            UI.usForm.frmMessageBox("User ID belum diinput")
            Exit Sub
        ElseIf txtPassword.Text.Trim = "" Then
            txtUserID.Focus()
            UI.usForm.frmMessageBox("Password belum diinput")
            Exit Sub
        End If

        ERPSLib.UI.usUserApp.UserID = txtUserID.Text.Trim
        Dim strPassword As String = Encryption.Encrypt(txtPassword.Text.Trim)
        Dim dtUserValid As DataTable = BL.User.ListDataByUserIDAndPassword(txtUserID.Text.Trim, Encryption.Encrypt(txtPassword.Text.Trim))
        If dtUserValid.Rows.Count > 0 Then
            ERPSLib.UI.usUserApp.IsSuperUser = dtUserValid.Rows(0).Item("IsSuperUser")
            ERPSLib.UI.usUserApp.IsFirstCreated = dtUserValid.Rows(0).Item("IsFirstCreated")
            ERPSLib.UI.usUserApp.AccessList = BL.UserAccess.ListDataWithCompany(ERPSLib.UI.usUserApp.UserID, 0)
            ERPSLib.UI.usUserApp.ServerName = VO.DefaultServer.Server & "|" & VO.DefaultServer.Database

            Me.Hide()

            If ERPSLib.UI.usUserApp.AccessList.Rows.Count = 1 Then
                ERPSLib.UI.usUserApp.ProgramID = ERPSLib.UI.usUserApp.AccessList.Rows(0).Item("ProgramID")
                ERPSLib.UI.usUserApp.ProgramName = ERPSLib.UI.usUserApp.AccessList.Rows(0).Item("ProgramName")
                ERPSLib.UI.usUserApp.CompanyID = ERPSLib.UI.usUserApp.AccessList.Rows(0).Item("CompanyID")
                ERPSLib.UI.usUserApp.CompanyName = ERPSLib.UI.usUserApp.AccessList.Rows(0).Item("CompanyName")
                ERPSLib.UI.usUserApp.CompanyAddress = ERPSLib.UI.usUserApp.AccessList.Rows(0).Item("Address")
                ERPSLib.UI.usUserApp.CompanyInitial = ERPSLib.UI.usUserApp.AccessList.Rows(0).Item("CompanyInitial")
                'ERPSLib.UI.usUserApp.JournalPost = BL.JournalPost.GetDetail(ERPSLib.UI.usUserApp.ProgramID)
                frmSysMain.Show()
            Else
                Dim frmDetail As New frmViewProgramCompany
                With frmDetail
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                    If .pubIsChoose Then
                        ERPSLib.UI.usUserApp.ProgramID = .pubLUdtRow.Item("ProgramID")
                        ERPSLib.UI.usUserApp.ProgramName = .pubLUdtRow.Item("ProgramName")
                        ERPSLib.UI.usUserApp.CompanyID = .pubLUdtRow.Item("CompanyID")
                        ERPSLib.UI.usUserApp.CompanyName = .pubLUdtRow.Item("CompanyName")
                        ERPSLib.UI.usUserApp.CompanyAddress = .pubLUdtRow.Item("Address")
                        ERPSLib.UI.usUserApp.CompanyInitial = .pubLUdtRow.Item("CompanyInitial")
                        'ERPSLib.UI.usUserApp.JournalPost = BL.JournalPost.GetDetail(ERPSLib.UI.usUserApp.ProgramID)
                        frmSysMain.Show()
                    End If
                End With
            End If
        Else
            txtPassword.Focus()
            UI.usForm.frmMessageBox("User ID dan Password tidak valid!")
            Exit Sub
        End If
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmSysLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            prvLogin()
        End If
    End Sub

    Private Sub frmSysLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        txtUserID.Focus()
        txtPassword.CharacterCasing = CharacterCasing.Normal
        prvLoadXML()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        prvLogin()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If Not UI.usForm.frmAskQuestion("Keluar dari program?") Then Exit Sub
        Application.Exit()
    End Sub

    Private Sub txtLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserID.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            prvLogin()
        End If
    End Sub

#End Region
    
End Class
