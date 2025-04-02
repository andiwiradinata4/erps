Public Class frmMstBusinessPartnerBankAccountDet

#Region "Property"

    Private frmParent As frmMstBusinessPartnerBankAccount
    Private clsData As VO.BusinessPartnerBankAccount
    Property pubID As Integer
    Property pubBPID As Integer
    Property pubIsNew As Boolean = False
    Property pubIsSave As Boolean = False

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvSetTitleForm()
        If pubIsNew Then
            Me.Text += " [baru] "
        Else
            Me.Text += " [edit] "
        End If
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.MasterDefault), "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvFillForm()
        prvFillCombo()
        Try
            If pubIsNew Then
                prvClear()
            Else
                clsData = New VO.BusinessPartnerBankAccount
                clsData = BL.BusinessPartner.GetDetailBankAccount(pubID)
                txtAccountName.Text = clsData.AccountName
                txtBankName.Text = clsData.BankName
                txtAccountNumber.Text = clsData.AccountNumber
                txtCurrency.Text = clsData.Currency
                txtRemarks.Text = clsData.Remarks
                cboStatus.SelectedValue = clsData.StatusID
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                If cboStatus.SelectedValue = VO.Status.Values.InActive Then cboStatus.Enabled = True
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvSave()
        If txtAccountName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nama Akun tidak boleh kosong")
            txtAccountName.Focus()
            Exit Sub
        ElseIf txtBankName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nama Bank tidak boleh kosong")
            txtBankName.Focus()
            Exit Sub
        ElseIf txtAccountNumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nomor Rekening tidak boleh kosong")
            txtAccountNumber.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            cboStatus.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        clsData = New VO.BusinessPartnerBankAccount
        clsData.ID = pubID
        clsData.BPID = pubBPID
        clsData.AccountName = txtAccountName.Text.Trim
        clsData.BankName = txtBankName.Text.Trim
        clsData.AccountNumber = txtAccountNumber.Text.Trim
        clsData.Currency = txtCurrency.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        Try
            BL.BusinessPartner.SaveDataBankAccount(pubIsNew, clsData)
            If pubIsNew Then
                UI.usForm.frmMessageBox("Data berhasil disimpan.")
                frmParent.pubRefresh(clsData.BankName)
                prvClear()
            Else
                pubIsSave = True
                frmParent.pubRefresh(clsData.BankName)
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        txtAccountName.Text = ""
        txtBankName.Text = ""
        txtAccountNumber.Text = ""
        txtCurrency.Text = "IDR"
        txtRemarks.Text = ""
        cboStatus.SelectedValue = VO.Status.Values.Active
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterBusinessPartnerBankAccount, IIf(pubIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
    End Sub

#Region "Form Handle"

    Private Sub frmMstBusinessPartnerBankAccountDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form ini?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstBusinessPartnerBankAccountDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetTitleForm()
        prvFillForm()
        prvUserAccess()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

#End Region

End Class