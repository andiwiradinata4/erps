Public Class frmTraARAPInvoiceDet

#Region "Properties"

    Private bolIsNew As Boolean
    Private strID As String
    Private bolIsSave As Boolean
    Private decPPNPercentage As Decimal = 0
    Private decPPHPercentage As Decimal = 0
    Private intCoAID As Integer = 0
    Private clsData As New VO.ARAPInvoice
    Private strParentID As String = ""

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

    Public WriteOnly Property pubPPNPercentage As Decimal
        Set(value As Decimal)
            decPPNPercentage = value
        End Set
    End Property

    Public WriteOnly Property pubPPHPercentage As Decimal
        Set(value As Decimal)
            decPPHPercentage = value
        End Set
    End Property

    Public WriteOnly Property pubParentID As String
        Set(value As String)
            strParentID = value
        End Set
    End Property


#End Region

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionAccountPayable), "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        prvFillCombo()
        Try
            If bolIsNew Then
                prvClear()
            Else
                clsData = New VO.ARAPInvoice
                clsData = BL.ARAP.GetDetailInvoice(strID)
                txtInvoiceNumber.Text = clsData.InvoiceNumber
                dtpInvoiceDate.Value = clsData.InvoiceDate
                intCoAID = clsData.CoAID
                txtCoACode.Text = clsData.CoACode
                txtCoAName.Text = clsData.CoAName
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                txtTotalAmount.Value = clsData.TotalAmount
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                txtPPN.Value = decPPNPercentage
                txtPPH.Value = decPPHPercentage
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvClear()
        pubID = ""
        txtInvoiceNumber.Text = ""
        dtpInvoiceDate.Value = Now
        intCoAID = 0
        txtCoACode.Text = ""
        txtCoAName.Text = ""
        txtTotalDPP.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtTotalAmount.Value = 0
        cboStatus.SelectedValue = VO.Status.Values.Draft
        txtRemarks.Text = ""
        txtPPN.Value = decPPNPercentage
        txtPPH.Value = decPPHPercentage

        'ToolStripLogInc.Text = "Jumlah Edit : -"
        'ToolStripLogBy.Text = "Dibuat Oleh : -"
        'ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvChooseCOA()
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = ERPSLib.UI.usUserApp.CompanyID
            .pubProgramID = ERPSLib.UI.usUserApp.CompanyID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.CashOrBank
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAID = .pubLUdtRow.Item("ID")
                txtCoACode.Text = .pubLUdtRow.Item("Code")
                txtCoAName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvSave()
        If txtTotalDPP.Value <= 0 Then
            txtTotalDPP.Focus()
            UI.usForm.frmMessageBox("Total DPP harus lebih besar dari 0")
            Exit Sub
        ElseIf intCoAID <= 0 Then
            txtCoACode.Focus()
            UI.usForm.frmMessageBox("Pilih Akun terlebih dahulu")
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub
        clsData = New VO.ARAPInvoice With
            {
                .ID = strID,
                .ParentID = strParentID,
                .InvoiceNumber = txtInvoiceNumber.Text.Trim,
                .TotalDPP = txtTotalDPP.Value,
                .TotalPPN = txtTotalPPN.Value,
                .TotalPPH = txtTotalPPH.Value,
                .TotalAmount = txtTotalAmount.Value,
                .InvoiceDate = dtpInvoiceDate.Value,
                .CoAID = intCoAID,
                .PPN = txtPPN.Value,
                .PPH = txtPPH.Value,
                .Remarks = txtRemarks.Text.Trim,
                .StatusID = cboStatus.SelectedValue,
                .ReferencesNumber = ""
            }

        Try
            Dim strInvoiceNumber As String = BL.ARAP.SaveDataInvoice(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. Nomor Invoice " & strInvoiceNumber.Trim)
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvCalculate()
        txtTotalAmount.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPInvoiceDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraARAPInvoiceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar.SetIcon(Me)
        prvFillForm()

        AddHandler txtTotalAmount.ValueChanged, AddressOf txtTotalAmount_ValueChanged
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnCoA_Click(sender As Object, e As EventArgs) Handles btnCoA.Click
        prvChooseCOA()
    End Sub

    Private Sub txtTotalAmount_ValueChanged(sender As Object, e As EventArgs)
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then Exit Sub
        If txtPPN.Value > 0 Then
            txtTotalDPP.Value = txtTotalAmount.Value / (1 + (txtPPN.Value / 100))
            txtTotalPPN.Value = txtTotalDPP.Value * txtPPN.Value / 100
        Else
            txtTotalDPP.Value = txtTotalAmount.Value
            txtTotalPPN.Value = 0
        End If
    End Sub

    Private Sub txtTotalDPP_ValueChanged(sender As Object, e As EventArgs) Handles txtTotalDPP.ValueChanged
        If Not chkChangeTotalDPP.Checked Then Exit Sub
        prvCalculate()
    End Sub

    Private Sub txtTotalPPN_ValueChanged(sender As Object, e As EventArgs) Handles txtTotalPPN.ValueChanged
        If Not chkChangeTotalPPN.Checked Then Exit Sub
        prvCalculate()
    End Sub

    Private Sub txtTotalPPH_ValueChanged(sender As Object, e As EventArgs) Handles txtTotalPPH.ValueChanged
        If Not chkChangeTotalPPH.Checked Then Exit Sub
        prvCalculate()
    End Sub

    Private Sub chkChangeTotalDPP_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeTotalDPP.CheckedChanged
        If chkChangeTotalDPP.Checked Then
            txtTotalDPP.BackColor = System.Drawing.Color.White
            txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Else
            txtTotalDPP.BackColor = System.Drawing.Color.LightYellow
            txtTotalAmount.BackColor = System.Drawing.Color.White
        End If
        txtTotalDPP.Enabled = chkChangeTotalDPP.Checked
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then txtTotalAmount.Enabled = False Else txtTotalAmount.Enabled = True
    End Sub

    Private Sub chkChangeTotalPPN_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeTotalPPN.CheckedChanged
        If chkChangeTotalPPN.Checked Then
            txtTotalPPN.BackColor = System.Drawing.Color.White
            txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Else
            txtTotalPPN.BackColor = System.Drawing.Color.LightYellow
            txtTotalAmount.BackColor = System.Drawing.Color.White
        End If
        txtTotalPPN.Enabled = chkChangeTotalPPN.Checked
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then txtTotalAmount.Enabled = False Else txtTotalAmount.Enabled = True
    End Sub

    Private Sub chkChangeTotalPPH_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeTotalPPH.CheckedChanged
        If chkChangeTotalPPH.Checked Then
            txtTotalPPH.BackColor = System.Drawing.Color.White
            txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Else
            txtTotalPPH.BackColor = System.Drawing.Color.LightYellow
            txtTotalAmount.BackColor = System.Drawing.Color.White
        End If
        txtTotalPPH.Enabled = chkChangeTotalPPH.Checked
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then txtTotalAmount.Enabled = False Else txtTotalAmount.Enabled = True
    End Sub

#End Region

End Class