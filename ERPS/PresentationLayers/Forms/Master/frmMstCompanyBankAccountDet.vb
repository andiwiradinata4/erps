Public Class frmMstCompanyBankAccountDet

#Region "Property"

    Private frmParent As frmMstCompanyBankAccount
    Private clsData As VO.CompanyBankAccount
    Private intCompanyID As Integer = 0
    Property pubID As Integer
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
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.MasterCompanyBankAccount), "StatusID", "StatusName")
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
                clsData = New VO.CompanyBankAccount
                clsData = BL.CompanyBankAccount.GetDetail(pubID)
                intCompanyID = clsData.CompanyID
                txtCompanyName.Text = clsData.CompanyName
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
        If txtCompanyName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih perusahaan terlebih dahulu")
            txtCompanyName.Focus()
            Exit Sub
        ElseIf txtAccountName.Text.Trim = "" Then
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

        clsData = New VO.CompanyBankAccount
        clsData.ID = pubID
        clsData.CompanyID = intCompanyID
        clsData.AccountName = txtAccountName.Text.Trim
        clsData.BankName = txtBankName.Text.Trim
        clsData.AccountNumber = txtAccountNumber.Text.Trim
        clsData.Currency = txtCurrency.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        Try
            BL.CompanyBankAccount.SaveData(pubIsNew, clsData)
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

    Private Sub prvChooseCompany()
        Dim frmDetail As New frmViewCompany
        With frmDetail
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCompanyID = .pubLUdtRow.Item("CompanyID")
                txtCompanyName.Text = .pubLUdtRow.Item("CompanyName")
                txtAccountName.Focus()
            End If
        End With
    End Sub

    Private Sub prvClear()
        intCompanyID = ERPSLib.UI.usUserApp.CompanyID
        txtCompanyName.Text = ERPSLib.UI.usUserApp.CompanyName
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
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterCompanyBankAccount, IIf(pubIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

#Region "Form Handle"

    Private Sub frmMstCompanyBankAccountDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form ini?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstCompanyBankAccountDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnCompany_Click(sender As Object, e As EventArgs) Handles btnCompany.Click
        prvChooseCompany()
    End Sub

#End Region

End Class