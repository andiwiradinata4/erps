﻿Public Class frmRptKartuHutangVer00

#Region "Property"

    Private bolExport As Boolean = False
    Private dtBP As New DataTable
    Private Const _
       cPreview = 0, cClose = 1

#End Region

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "Pick", "Pilih", 100, UI.usDefGrid.gIntNum, True, False)
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "Code", "Kode", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Name", "Nama", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Address", "Alamat", 100, UI.usDefGrid.gString)
    End Sub

    Private Sub prvQuery()
        Try
            dtBP = BL.BusinessPartner.ListData
            grdMain.DataSource = dtBP
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvSetProgressBar(ByVal intMax As Integer)
        pgMain.Value = 0
        pgMain.Maximum = intMax
    End Sub

    Private Sub prvRefreshProgressBar()
        pgMain.Value += 1
        Me.Refresh()
    End Sub

    Private Function prvGetFirstBalance(ByVal intBPID As Integer) As Decimal
        Dim decReturn As Decimal = 0
        Dim dtData As DataTable = BL.Reports.KartuHutangVer01Report(New DateTime(1900, 1, 1), dtpDateFrom.Value.Date.AddDays(-1), ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, intBPID)
        With dtData
            prvSetProgressBar(.Rows.Count)
            For i As Integer = 0 To .Rows.Count - 1
                .Rows(i).BeginEdit()
                .Rows(i).Item("FirstBalance") = 0
                If i = 0 Then
                    .Rows(i).Item("BalanceAmount") = 0 + .Rows(i).Item("CreditAmount") - .Rows(i).Item("DebitAmount")
                Else
                    .Rows(i).Item("BalanceAmount") = .Rows(i - 1).Item("BalanceAmount") + .Rows(i).Item("CreditAmount") - .Rows(i).Item("DebitAmount")
                End If
                .Rows(i).EndEdit()
                prvRefreshProgressBar()
            Next
            .AcceptChanges()
        End With
        If dtData.Rows.Count > 0 Then decReturn = dtData.Rows(dtData.Rows.Count - 1).Item("BalanceAmount")
        Return decReturn
    End Function

    Private Function prvCollectDataVer00(ByVal drPick() As DataRow) As DataTable
        Dim dtCurrent As New DataTable, dtReturn As New DataTable
        Try
            '# Loop All Selected Business Partners
            For Each dr As DataRow In drPick
                '# Get Last Balance
                Dim decFirstBalance As Decimal = prvGetFirstBalance(dr.Item("ID"))

                '# Calculate Table Return
                dtCurrent = BL.Reports.KartuHutangVer01Report(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, dr.Item("ID"))
                With dtCurrent
                    prvSetProgressBar(.Rows.Count)
                    For i As Integer = 0 To .Rows.Count - 1
                        .Rows(i).BeginEdit()
                        .Rows(i).Item("FirstBalance") = decFirstBalance
                        If i = 0 Then
                            .Rows(i).Item("BalanceAmount") = decFirstBalance + .Rows(i).Item("CreditAmount") - .Rows(i).Item("DebitAmount")
                        Else
                            .Rows(i).Item("BalanceAmount") = .Rows(i - 1).Item("BalanceAmount") + .Rows(i).Item("CreditAmount") - .Rows(i).Item("DebitAmount")
                        End If
                        .Rows(i).EndEdit()
                        prvRefreshProgressBar()
                    Next
                    .AcceptChanges()
                End With

                dtReturn.Merge(dtCurrent)
            Next
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        Return dtReturn
    End Function

    Private Sub prvPreview()
        ToolBar.Focus()
        If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Period salah")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Dim drPick() As DataRow = dtBP.Select("Pick=True")
        If drPick.Count = 0 Then
            UI.usForm.frmMessageBox("Pilih salah satu rekan bisnis terlebih dahulu")
            Exit Sub
        End If

        Dim strFilterDate As String = Format(dtpDateFrom.Value, "dd-MMM-yyyy") & " - " & Format(dtpDateTo.Value, "dd-MMM-yyyy")

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim crReport As New rptKartuHutangPiutangReportVer00
            With crReport
                .DataSource = prvCollectDataVer00(drPick)
                .Parameters.Item("FilterPeriod").Value = strFilterDate
                .Parameters.Item("ReportTitle").Value = "KARTU HUTANG"
                .Parameters.Item("CompanyName").Value = ERPSLib.UI.usUserApp.CompanyName
                .DisplayName = Me.Text
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

    Private Sub prvCheckUnchecked(ByVal bolValue As Boolean)
        For Each dr As DataRow In dtBP.Rows
            dr.BeginEdit()
            dr.Item("Pick") = bolValue
            dr.EndEdit()
        Next
        dtBP.AcceptChanges()
        grdMain.DataSource = dtBP
    End Sub

#Region "Form Handle"

    Private Sub frmRptKartuHutangVer00_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetGrid()
        dtpDateFrom.Value = Today.Date.AddDays(-14)
        dtpDateTo.Value = Today.Date
        prvQuery()
        'bolExport = BL.UserAccess.IsCanAccess(MPSLib.UI.usUserApp.UserID, MPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.ReportBukuBesar, VO.Access.Value.ExportReportAccess)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Lihat Laporan" : prvPreview()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarDetail_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Centang Semua" : prvCheckUnchecked(True)
            Case "Tidak Centang Semua" : prvCheckUnchecked(False)
        End Select
    End Sub

#End Region

End Class