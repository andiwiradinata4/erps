Public Class frmSysMain

    Dim bolLogOut As Boolean

    '# Master
    Dim frmMainMstProgram As frmMstProgram
    Dim frmMainMstStatus As frmMstStatus
    Dim frmMainMstModules As frmMstModules
    Dim frmMainMstAccess As frmMstAccess
    Dim frmMainMstCompany As frmMstCompany
    Dim frmMainMstUser As frmMstUser
    Dim frmMainMstUOM As frmMstUOM
    Dim frmMainMstItemType As frmMstItemType
    

    Private Sub prvSetupStatusStrip()
        tssUserID.Text = ERPSLib.UI.usUserApp.UserID
        tssVersion.Text = "Versi: " & FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion
        tssProgram.Text = ERPSLib.UI.usUserApp.ProgramName
        tssCompany.Text = ERPSLib.UI.usUserApp.CompanyName
        tssServer.Text = ERPSLib.UI.usUserApp.ServerName
    End Sub


#Region "Form Handle"

    Private Sub frmSysMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        bolLogOut = False
        prvSetupStatusStrip()
        'prvUserAccess()
    End Sub

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bolLogOut Then
            If UI.usForm.frmAskQuestion("Keluar dari sistem ?") Then
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "Master"

    Private Sub mnuMasterProgram_Click(sender As Object, e As EventArgs) Handles mnuMasterProgram.Click
        UI.usForm.frmOpen(frmMainMstProgram, "frmMstProgram", Me)
    End Sub

    Private Sub mnuMasterStatus_Click(sender As Object, e As EventArgs) Handles mnuMasterStatus.Click
        UI.usForm.frmOpen(frmMainMstStatus, "frmMstStatus", Me)
    End Sub

    Private Sub mnuMasterModule_Click(sender As Object, e As EventArgs) Handles mnuMasterModule.Click
        UI.usForm.frmOpen(frmMainMstModules, "frmMstModules", Me)
    End Sub

    Private Sub mnuMasterAkses_Click(sender As Object, e As EventArgs) Handles mnuMasterAkses.Click
        UI.usForm.frmOpen(frmMainMstAccess, "frmMstAccess", Me)
    End Sub

    Private Sub mnuMasterPerusahaan_Click(sender As Object, e As EventArgs) Handles mnuMasterPerusahaan.Click
        UI.usForm.frmOpen(frmMainMstCompany, "frmMstCompany", Me)
    End Sub

    Private Sub mnuMasterKaryawan_Click(sender As Object, e As EventArgs) Handles mnuMasterKaryawan.Click
        UI.usForm.frmOpen(frmMainMstUser, "frmMstUser", Me)
    End Sub

    Private Sub mnuMasterSatuan_Click(sender As Object, e As EventArgs) Handles mnuMasterSatuan.Click
        UI.usForm.frmOpen(frmMainMstUOM, "frmMstUOM", Me)
    End Sub

    Private Sub mnuMasterJenisBarang_Click(sender As Object, e As EventArgs) Handles mnuMasterJenisBarang.Click
        UI.usForm.frmOpen(frmMainMstItemType, "frmMstItemType", Me)
    End Sub

    Private Sub mnuMasterSpesifikasiBarang_Click(sender As Object, e As EventArgs) Handles mnuMasterSpesifikasiBarang.Click

    End Sub

    Private Sub mnuMasterBarang_Click(sender As Object, e As EventArgs) Handles mnuMasterBarang.Click

    End Sub

    Private Sub mnuMasterRekanBisnis_Click(sender As Object, e As EventArgs) Handles mnuMasterRekanBisnis.Click

    End Sub

    Private Sub mnuMasterJenisPembayaran_Click(sender As Object, e As EventArgs) Handles mnuMasterJenisPembayaran.Click

    End Sub

    Private Sub mnuMasterSyaratPembayaran_Click(sender As Object, e As EventArgs) Handles mnuMasterSyaratPembayaran.Click

    End Sub

#End Region

End Class