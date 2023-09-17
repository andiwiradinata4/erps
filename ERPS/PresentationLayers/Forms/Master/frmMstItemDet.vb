Public Class frmMstItemDet

#Region "Property"

    Private frmParent As frmMstItem
    Private clsData As VO.Item
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
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.MasterItem), "StatusID", "StatusName")
            UI.usForm.FillComboBox(cboItemType, BL.ItemType.ListDataForCombo, "ID", "Description")
            UI.usForm.FillComboBox(cboItemSpecification, BL.ItemSpecification.ListDataForCombo, "ID", "Description")
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
                clsData = New VO.Item
                clsData = BL.Item.GetDetail(pubID)
                txtItemCode.Text = clsData.ItemCode
                txtItemName.Text = clsData.ItemName
                cboItemType.SelectedValue = clsData.ItemTypeID
                txtThick.Text = clsData.Thick
                txtWidth.Text = clsData.Width
                txtLength.Text = clsData.Length
                txtWeight.Value = clsData.Weight
                cboItemSpecification.SelectedValue = clsData.ItemSpecificationID
                txtBasePrice.Value = clsData.BasePrice
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
        If txtItemCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Kode tidak boleh kosong")
            txtItemCode.Focus()
            Exit Sub
        ElseIf cboItemType.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Pilih tipe terlebih dahulu")
            cboItemType.Focus()
            Exit Sub
        ElseIf txtItemName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nama tidak boleh kosong")
            txtItemName.Focus()
            Exit Sub
        ElseIf txtThick.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Tebal tidak boleh kosong")
            txtThick.Focus()
            Exit Sub
        ElseIf txtWidth.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Lebar tidak boleh kosong")
            txtWidth.Focus()
            Exit Sub
        ElseIf txtLength.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Panjang tidak boleh kosong")
            txtLength.Focus()
            Exit Sub
        ElseIf txtWeight.Value <= 0 Then
            UI.usForm.frmMessageBox("Berat harus lebih besar dari 0")
            txtWeight.Focus()
            Exit Sub
        ElseIf cboItemSpecification.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Pilih spec terlebih dahulu")
            cboItemSpecification.Focus()
            Exit Sub
        ElseIf txtBasePrice.Value <= 0 Then
            UI.usForm.frmMessageBox("Harga harus lebih besar dari 0")
            txtBasePrice.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            cboStatus.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        clsData = New VO.Item
        clsData.ID = pubID
        clsData.ItemCode = txtItemCode.Text.Trim
        clsData.ItemTypeID = cboItemType.SelectedValue
        clsData.ItemName = txtItemName.Text.Trim
        clsData.Thick = txtThick.Text.Trim
        clsData.Width = txtWidth.Text.Trim
        clsData.Length = txtLength.Text.Trim
        clsData.Weight = txtWeight.Value
        clsData.ItemSpecificationID = cboItemSpecification.SelectedValue
        clsData.BasePrice = txtBasePrice.Value
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        Try
            BL.Item.SaveData(pubIsNew, clsData)
            If pubIsNew Then
                UI.usForm.frmMessageBox("Data berhasil disimpan.")
                frmParent.pubRefresh()
                prvClear()
            Else
                pubIsSave = True
                frmParent.pubRefresh()
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        txtItemCode.Text = ""
        txtItemName.Text = ""
        cboItemType.SelectedIndex = -1
        txtThick.Text = "0"
        txtWidth.Text = "0"
        txtLength.Text = ""
        txtWeight.Value = 0
        cboItemSpecification.SelectedIndex = -1
        txtBasePrice.Value = 0
        cboStatus.SelectedValue = VO.Status.Values.Active
        txtRemarks.Text = ""
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItem, IIf(pubIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

#Region "Form Handle"

    Private Sub frmMstItemDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form ini?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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