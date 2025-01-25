Public Class frmRptListPOCuttingVer00

#Region "Property"

    Private intBPID As Integer
    Private Const cPreview As Byte = 0, cClose As Byte = 1

#End Region

    Private Sub prvSetProgressBar(ByVal intMax As Integer)
        pgMain.Value = 0
        pgMain.Maximum = intMax
    End Sub

    Private Sub prvRefreshProgressBar()
        pgMain.Value += 1
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtItemType As DataTable = BL.ItemType.ListDataForCombo
            Dim dr As DataRow = dtItemType.NewRow
            With dr
                .BeginEdit()
                .Item("ID") = 0
                .Item("Description") = "ALL"
                .EndEdit()
            End With
            dtItemType.Rows.Add(dr)
            dtItemType.AcceptChanges()

            UI.usForm.FillComboBox(cboItemType, dtItemType, "ID", "Description", True)
            UI.usForm.FillComboBox(cboCheckedBy, BL.User.ListDataForCombo, "ID", "Name")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvChooseBP()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvPreview()
        ToolBar.Focus()
        If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Period salah")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Dim strFilterAdditional As String = ""
        Dim strFilterDate As String = Format(dtpDateFrom.Value, "dd-MMM-yyyy") & " s.d " & Format(dtpDateTo.Value, "dd-MMM-yyyy")
        Dim dtData As DataTable = BL.Reports.ListPOCutting(ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, intBPID, cboItemType.SelectedValue)

        Dim clsPrintedBy As VO.User = BL.User.GetDetail(ERPSLib.UI.usUserApp.UserID)

        If intBPID > 0 Then strFilterAdditional += "CUTTING CENTER : " & txtBPName.Text.Trim
        If cboItemType.SelectedValue > 0 Then strFilterAdditional += IIf(strFilterAdditional.Trim <> "", vbCrLf, "") & "JENIS : " & cboItemType.Text.Trim

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim crReport As New rptListPOCutting
            crReport.DataSource = dtData
            With crReport
                .paramFilterPeriod.Value = strFilterDate
                .paramCheckedBy.Value = cboCheckedBy.Text.Trim
                .paramPrintedBy.Value = clsPrintedBy.Name
                .paramFilterAdditional.Value = strFilterAdditional.Trim
                .CreateDocument(True)
                .ShowPreviewMarginLines = False
                .ShowPrintMarginsWarning = False
            End With

            Dim frmDetail As New frmReportPreview
            With frmDetail
                .docViewer.DocumentSource = crReport
                .pgExportButton.Enabled = True
                .Text = Me.Text & " - " & VO.Reports.PrintOut
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#Region "Form Handle"

    Private Sub frmRptListPOCutting_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmRptListPOCutting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        dtpDateFrom.Value = Today.Date.AddDays(-14)
        dtpDateTo.Value = Today.Date
        prvFillCombo()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Lihat Laporan" : prvPreview()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub txtBP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBPCode.KeyDown, txtBPName.KeyDown
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            intBPID = 0
            txtBPCode.Text = ""
            txtBPName.Text = ""
        End If
    End Sub

#End Region

End Class