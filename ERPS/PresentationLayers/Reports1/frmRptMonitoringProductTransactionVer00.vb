Public Class frmRptMonitoringProductTransactionVer00

#Region "Property"

    Private bolExport As Boolean = False
    Private Const _
       cPreview As Byte = 0, cClose As Byte = 1

#End Region

    Private Sub prvSetProgressBar(ByVal intMax As Integer)
        pgMain.Value = 0
        pgMain.Maximum = intMax
        
    End Sub

    Private Sub prvRefreshProgressBar()
        pgMain.Value += 1
        
    End Sub

    Private Sub prvPreview()
        ToolBar.Focus()
        If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Period salah")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Dim strFilterDate As String = Format(dtpDateFrom.Value, "dd-MMM-yyyy") & " - " & Format(dtpDateTo.Value, "dd-MMM-yyyy")

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim crReport As New rptMonitoringProductTransactionVer00
            crReport.DataSource = BL.Reports.MonitoringProductTransactionReportVer00(ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            With crReport
                .Parameters.Item("FilterPeriod").Value = strFilterDate
                .Parameters.Item("CompanyName").Value = ERPSLib.UI.usUserApp.CompanyName
                .CreateDocument(True)
                .ShowPreviewMarginLines = False
                .ShowPrintMarginsWarning = False
            End With

            Dim frmDetail As New frmReportPreview
            With frmDetail
                .docViewer.DocumentSource = crReport
                .pgExportButton.Enabled = bolExport
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

    Private Sub frmRptMonitoringProductTransactionVer00_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmRptMonitoringProductTransactionVer00_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        dtpDateFrom.Value = Today.Date.AddDays(-14)
        dtpDateTo.Value = Today.Date
        bolExport = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportBukuBesar, VO.Access.Values.ExportReportAccess)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Lihat Laporan" : prvPreview()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class