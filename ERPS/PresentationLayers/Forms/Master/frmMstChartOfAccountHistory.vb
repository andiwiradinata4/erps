Imports DevExpress.XtraGrid
Public Class frmMstChartOfAccountHistory

#Region "Property"

    Private clsData As VO.ChartOfAccount
    Private frmParent As frmMstChartOfAccount

    Public WriteOnly Property pubClsData As VO.ChartOfAccount
        Set(value As VO.ChartOfAccount)
            clsData = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cRefresh As Byte = 0, cClose As Byte = 1

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ReferencesID", "Nomor Jurnal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TransactionDate", "Tanggal Jurnal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "Name", "Nama Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DebitAmount", "Debit", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "CreditAmount", "Kredit", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 100, UI.usDefGrid.gString)
    End Sub

    Private Sub prvQuery()
        ToolBar.Focus()
        If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Period salah")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Try
            grdMain.DataSource = BL.ChartOfAccount.ListDataHistory(ERPSLib.UI.usUserApp.CompanyID, ERPSLib.UI.usUserApp.ProgramID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, clsData.ID)
            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
        prvSetGrid()
    End Sub

    Private Sub prvSumGrid()
        Dim SumDebitAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DebitAmount", "Total Debit: {0:#,##0.00}")
        Dim SumCreditAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditAmount", "Total Credit: {0:#,##0.00}")

        If grdView.Columns("DebitAmount").SummaryText.Trim = "" Then
            grdView.Columns("DebitAmount").Summary.Add(SumDebitAmount)
        End If

        If grdView.Columns("CreditAmount").SummaryText.Trim = "" Then
            grdView.Columns("CreditAmount").Summary.Add(SumCreditAmount)
        End If

        grdView.BestFitColumns()
    End Sub

#Region "Form Handle"

    Private Sub frmMstChartOfAccountHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstChartOfAccountHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        Me.Text += " - " & clsData.Code & " | " & clsData.Name
        ToolBar.SetIcon(Me)
        prvSetGrid()
        dtpDateFrom.Value = Today.Date.AddDays(-7)
        dtpDateTo.Value = Today.Date
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            prvQuery()
        ElseIf e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        End If
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        prvClear()
    End Sub

#End Region


End Class