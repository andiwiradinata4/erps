Public Class frmMstBusinessPartnerDet

#Region "Property"

    Private frmParent As frmMstBusinessPartner
    Private clsData As VO.BusinessPartner
    Private intCoAofCostOfRawMaterial As Integer
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
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.MasterBusinessPartner), "StatusID", "StatusName")
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
                clsData = New VO.BusinessPartner
                clsData = BL.BusinessPartner.GetDetail(pubID)
                txtCode.Text = clsData.Code
                txtName.Text = clsData.Name
                txtInitial.Text = clsData.Initial
                txtAddress.Text = clsData.Address
                txtPICName.Text = clsData.PICName
                txtPICPhoneNumber.Text = clsData.PICPhoneNumber
                txtRemarks.Text = clsData.Remarks
                intCoAofCostOfRawMaterial = clsData.CoAIDofStock
                txtCoACodeofCostRawMaterial.Text = clsData.CoACodeofStock
                txtCoANameofCostRawMaterial.Text = clsData.CoANameofStock
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
        If txtName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nama tidak boleh kosong")
            txtName.Focus()
            Exit Sub
        ElseIf txtInitial.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Inisial tidak boleh kosong")
            txtInitial.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            cboStatus.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        clsData = New VO.BusinessPartner
        clsData.ID = pubID
        clsData.Code = txtCode.Text.Trim
        clsData.Name = txtName.Text.Trim
        clsData.Initial = txtInitial.Text.Trim
        clsData.Address = txtAddress.Text.Trim
        clsData.PICName = txtPICName.Text.Trim
        clsData.PICPhoneNumber = txtPICPhoneNumber.Text.Trim
        clsData.CoAIDofStock = intCoAofCostOfRawMaterial
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        Try
            Dim strBPCode As String = BL.BusinessPartner.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan.")
            frmParent.pubRefresh(strBPCode)
            prvClear()
            If Not pubIsNew Then Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        txtCode.Text = ""
        txtName.Text = ""
        txtInitial.Text = ""
        txtAddress.Text = ""
        txtPICName.Text = ""
        txtPICPhoneNumber.Text = ""
        intCoAofCostOfRawMaterial = 0
        txtCoACodeofCostRawMaterial.Text = ""
        txtCoANameofCostRawMaterial.Text = ""
        txtRemarks.Text = ""
        cboStatus.SelectedValue = VO.Status.Values.Active
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterBusinessPartner, IIf(pubIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

#Region "Form Handle"

    Private Sub frmMstBusinessPartnerDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form ini?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmMstBusinessPartnerDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnCoAofCostOfRawMaterial_Click(sender As Object, e As EventArgs) Handles btnCoAofCostOfRawMaterial.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = ERPSLib.UI.usUserApp.CompanyID
            .pubProgramID = ERPSLib.UI.usUserApp.ProgramID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.Stock
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAofCostOfRawMaterial =.pubLUdtRow.Item("ID")
                txtCoACodeofCostRawMaterial.Text = .pubLUdtRow.Item("Code")
                txtCoANameofCostRawMaterial.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

#End Region

End Class