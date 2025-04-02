Public Class frmMstCompanyDet

#Region "Property"

    Private frmParent As frmMstCompany
    Private clsData As VO.Company
    Property pubID As Integer
    Property pubIsNew As Boolean = False
    Property pubIsSave As Boolean = False

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave = 0, cClose = 1

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
        End Try
    End Sub

    Private Sub prvFillForm()
        txtCompanyInitial.MaxLength = 3
        prvFillCombo()
        Try
            If pubIsNew Then
                prvClear()
            Else
                clsData = New VO.Company
                clsData = BL.Company.GetDetail(pubID)
                txtName.Text = clsData.Name
                txtAddress.Text = clsData.Address
                txtAddress2.Text = clsData.Address2
                txtCountry.Text = clsData.Country
                txtProvince.Text = clsData.Province
                txtCity.Text = clsData.City
                txtSubDistrict.Text = clsData.SubDistrict
                txtArea.Text = clsData.Area
                txtDirectorName.Text = clsData.DirectorName
                txtWarehouse.Text = clsData.Warehouse
                txtPhoneNumber.Text = clsData.PhoneNumber
                txtCompanyInitial.Text = clsData.CompanyInitial
                txtNPWP.Text = clsData.NPWP
                cboStatus.SelectedValue = clsData.StatusID
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                If cboStatus.SelectedValue = VO.Status.Values.InActive Then cboStatus.Enabled = True
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Public Sub prvSave()
        If txtName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nama belum diinput")
            txtName.Focus()
            Exit Sub
        ElseIf txtCompanyInitial.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Inisial Perusahaan belum diinput")
            txtCompanyInitial.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            cboStatus.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        clsData = New VO.Company
        clsData.ID = pubID
        clsData.Name = txtName.Text.Trim
        clsData.Address = txtAddress.Text.Trim
        clsData.Address2 = txtAddress2.Text.Trim
        clsData.Country = txtCountry.Text.Trim
        clsData.Province = txtProvince.Text.Trim
        clsData.City = txtCity.Text.Trim
        clsData.SubDistrict = txtSubDistrict.Text.Trim
        clsData.Area = txtArea.Text.Trim
        clsData.DirectorName = txtDirectorName.Text.Trim
        clsData.Warehouse = txtWarehouse.Text.Trim
        clsData.PhoneNumber = txtPhoneNumber.Text.Trim
        clsData.CompanyInitial = txtCompanyInitial.Text.Trim
        clsData.NPWP = txtNPWP.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        Try
            BL.Company.SaveData(pubIsNew, clsData)
            If pubIsNew Then
                UI.usForm.frmMessageBox("Data berhasil disimpan.")
                frmParent.pubRefresh(clsData.ID)
                prvClear()
            Else
                pubIsSave = True
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        txtName.Text = ""
        txtAddress.Text = ""
        txtCountry.Text = ""
        txtProvince.Text = ""
        txtCity.Text = ""
        txtSubDistrict.Text = ""
        txtArea.Text = ""
        txtDirectorName.Text = ""
        txtWarehouse.Text = ""
        txtPhoneNumber.Text = ""
        txtCompanyInitial.Text = ""
        cboStatus.SelectedValue = VO.Status.Values.Active
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterCompany, IIf(pubIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
    End Sub

#Region "Form Handle"

    Private Sub frmMstCompanyDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close this form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmMstCompanyDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


