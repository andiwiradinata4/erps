Public Class frmTraARAPDet

#Region "Property"

    Private frmParent As frmTraARAP
    Private clsData As VO.ARAP
    Private intBPID As Integer = 0
    Private intCoAID As Integer = 0
    Private strModules As String = ""
    Private intModuleID As Integer = 0
    Private enumDPType As VO.ARAP.ARAPTypeValue
    Private strReferencesID As String = ""
    Private strID As String = ""
    Private bolIsNew As Boolean = False
    Private clsCS As New VO.CS

    Public WriteOnly Property pubModules As String
        Set(value As String)
            strModules = value
        End Set
    End Property

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubDPType As VO.ARAP.ARAPTypeValue
        Set(value As VO.ARAP.ARAPTypeValue)
            enumDPType = value
        End Set
    End Property

    Public WriteOnly Property pubReferencesID As String
        Set(value As String)
            strReferencesID = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, _
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1

    Private Sub prvSetTitleForm()
        If bolIsNew Then
            Me.Text += " [baru] "
        Else
            Me.Text += " [edit] "
        End If
    End Sub

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionAccountPayableBalance), "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvFillForm()
        pgMain.Value = 30
        Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        prvFillCombo()
        Try
            If bolIsNew Then
                prvClear()
            Else
                clsData = New VO.ARAP
                clsData = BL.ARAP.GetDetail(strID, enumDPType)
                txtDPNumber.Text = clsData.TransNumber
                intCoAID = clsData.CoAID
                txtCoACode.Text = clsData.CoACode
                txtCoAName.Text = clsData.CoAName
                txtPercentage.Value = clsData.Percentage
                strModules = clsData.Modules
                dtpDPDate.Value = clsData.TransDate
                txtDueDateValue.Value = clsData.DueDateValue
                txtTotalAmount.Value = clsData.TotalAmount
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                dtpDPDate.Enabled = False
                If txtPercentage.Value > 0 Then chkUsePercentage.Checked = True
            End If
            prvGetAmount()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvGetAmount()
        If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
            Dim clsReferences As VO.SalesContract = BL.SalesContract.GetDetail(strReferencesID)
            txtGrandTotalContract.Value = clsReferences.GrandTotal
            txtTotalPayment.Value = clsReferences.DPAmount + clsReferences.ReceiveAmount
        Else
            Dim clsReferences As VO.PurchaseContract = BL.PurchaseContract.GetDetail(strReferencesID)
            txtGrandTotalContract.Value = clsReferences.GrandTotal
            txtTotalPayment.Value = clsReferences.DPAmount + clsReferences.ReceiveAmount
        End If
        txtOutstandingPayment.Value = txtGrandTotalContract.Value - txtTotalPayment.Value
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If txtCoACode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih akun terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCoACode.Focus()
            Exit Sub
        ElseIf txtTotalAmount.Value <= 0 Then
            UI.usForm.frmMessageBox("Total Bayar harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf txtDueDateValue.Value <= 0 Then
            UI.usForm.frmMessageBox("Jatuh Tempo harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtDueDateValue.Focus()
            Exit Sub
        ElseIf txtTotalAmount.Value > txtOutstandingPayment.Value Then
            UI.usForm.frmMessageBox("Total Bayar harus lebih kecil atau sama dengan nilai Sisa Bayar")
            tcHeader.SelectedTab = tpMain
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        End If

        Dim frmDetail As New usFormSave
        Dim intSave As VO.Save.Action
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then intSave = .pubValue
            If intSave = VO.Save.Action.CancelSave Then Exit Sub
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()

        clsData = New VO.ARAP
        clsData.ID = strID
        clsData.ProgramID = clsCS.ProgramID
        clsData.CompanyID = clsCS.CompanyID
        clsData.TransNumber = txtDPNumber.Text.Trim
        clsData.BPID = intBPID
        clsData.CoAID = intCoAID
        clsData.ReferencesID = strReferencesID
        clsData.ReferencesNote = ""
        clsData.TotalAmount = txtTotalAmount.Value
        clsData.Percentage = txtPercentage.Value
        clsData.TransDate = dtpDPDate.Value.Date
        clsData.DueDateValue = txtDueDateValue.Value
        clsData.Modules = strModules
        clsData.DPType = enumDPType
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave

        pgMain.Value = 60
        Application.DoEvents()

        Try
            Dim strDPNumber As String = BL.ARAP.SaveData(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strDPNumber)
            pgMain.Value = 80
            Application.DoEvents()
            frmParent.pubRefresh(strDPNumber)
            If bolIsNew Then
                prvClear()
                prvQueryHistory()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvClear()
        tcHeader.SelectedTab = tpMain
        strID = ""
        txtDPNumber.Text = ""
        intCoAID = 0
        txtCoACode.Text = ""
        txtCoAName.Text = ""
        dtpDPDate.Value = Now
        txtDueDateValue.Value = 0
        txtPercentage.Value = 0
        chkUsePercentage.Checked = False
        txtTotalAmount.Value = 0
        txtRemarks.Text = ""
        cboStatus.SelectedValue = VO.Status.Values.Draft
        txtGrandTotalContract.Value = 0
        txtTotalPayment.Value = 0
        txtOutstandingPayment.Value = 0
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
        prvGetAmount()
    End Sub

    Private Sub prvChooseCOA()
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = clsCS.CompanyID
            .pubProgramID = clsCS.ProgramID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.CashOrBank
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAID = .pubLUdtRow.Item("ID")
                txtCoACode.Text = .pubLUdtRow.Item("Code")
                txtCoAName.Text = .pubLUdtRow.Item("Name")
                txtPercentage.Focus()
            End If
        End With
    End Sub

    Private Sub prvGetModuleID()
        intModuleID = VO.Common.GetModuleID(strModules)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModuleID, IIf(bolIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

    Private Sub prvCalculate()
        If txtPercentage.Value <= 0 Then Exit Sub
        txtTotalAmount.Value = ERPSLib.SharedLib.Math.Round((txtGrandTotalContract.Value * txtPercentage.Value / 100), 0)
    End Sub

#Region "History Handle"

    Private Sub prvQueryHistory()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                grdStatus.DataSource = BL.AccountReceivable.ListDataStatus(strID)
            Else
                grdStatus.DataSource = BL.AccountPayable.ListDataStatus(strID)
            End If
            grdStatusView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraDownPaymentDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraDownPaymentDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prvGetModuleID()
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryHistory()
        prvUserAccess()
        txtDueDateValue.Minimum = 0
        AddHandler txtPercentage.ValueChanged, AddressOf txtPercentage_ValueChanged
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnCoAOfOutgoingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfOutgoingPayment.Click
        prvChooseCOA()
    End Sub

    Private Sub txtPercentage_ValueChanged(sender As Object, e As EventArgs)
        prvCalculate()
    End Sub

    Private Sub chkUsePercentage_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsePercentage.CheckedChanged
        If chkUsePercentage.Checked Then
            txtPercentage.Enabled = True
            txtPercentage.BackColor = Color.White
            txtTotalAmount.Value = 0
            txtTotalAmount.Enabled = False
            txtTotalAmount.BackColor = Color.LightYellow
        Else
            txtPercentage.Value = 0
            txtPercentage.Enabled = False
            txtPercentage.BackColor = Color.LightYellow
            txtTotalAmount.Enabled = True
            txtTotalAmount.BackColor = Color.White
        End If
    End Sub

#End Region

End Class