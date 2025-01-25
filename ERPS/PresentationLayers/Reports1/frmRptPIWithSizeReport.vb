Public Class frmRptPIWithSizeReportVer00

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
            cboItemType.SelectedValue = 0
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
        Me.Cursor = Cursors.WaitCursor

        Dim strFilterAdditional As String = ""
        Dim strFilterDate As String = Format(dtpDateFrom.Value, "dd-MMM-yyyy") & " s.d " & Format(dtpDateTo.Value, "dd-MMM-yyyy")
        Dim dtData As DataTable = BL.Reports.SalesPIReport(ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, intBPID, cboItemType.SelectedValue)

        Dim clsPrintedBy As VO.User = BL.User.GetDetail(ERPSLib.UI.usUserApp.UserID)

        If intBPID > 0 Then strFilterAdditional += "PELANGGAN : " & txtBPName.Text.Trim
        If cboItemType.SelectedValue > 0 Then strFilterAdditional += IIf(strFilterAdditional.Trim <> "", vbCrLf, "") & "BARANG : " & cboItemType.Text.Trim

        If Not chkIsShowSize.Checked Then
            Dim dsHelper As New DataSetHelper
            Dim dtGroup As DataTable = dsHelper.SelectGroupByInto("DataGroup", dtData, "No, OrderNumber, ARNumber, ARDate, OrderNumberSupplier, Item, BPName, SUM(TotalWeight) TotalWeight, SUM(TotalIncPPN) TotalIncPPN, SUM(TotalInvoiceAmount) TotalInvoiceAmount, SUM(OutstandingPaid) OutstandingPaid", "", "No, OrderNumber, ARNumber, ARDate, OrderNumberSupplier, Item, BPName")
            dtData = dtGroup
        End If

        For i As Integer = 0 To dtData.Rows.Count - 1
            dtData.Rows(i).BeginEdit()
            dtData.Rows(i).Item("No") = i + 1
            dtData.Rows(i).EndEdit()
        Next
        dtData.AcceptChanges()

        Try
            Dim crReport As New rptPIWithSizeReportVer00
            crReport.DataSource = dtData
            With crReport
                .phDefault.Visible = chkIsShowSize.Checked
                .phWithOutSize.Visible = Not chkIsShowSize.Checked
                .sdDefault.Visible = chkIsShowSize.Checked
                .sdWithOutSize.Visible = Not chkIsShowSize.Checked
                .paramFilterPeriod.Value = strFilterDate
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

    Private Sub frmRptPIWithSizeReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmRptPIWithSizeReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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