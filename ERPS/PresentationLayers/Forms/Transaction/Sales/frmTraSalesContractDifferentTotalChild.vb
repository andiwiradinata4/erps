Imports DevExpress.XtraGrid
Public Class frmTraSalesContractDifferentTotalChild

#Region "Form Handle"

    Private intProgramID As Integer
    Private intCompanyID As Integer
    Private dtData As New DataTable
    Private dtmDateFrom As DateTime
    Private dtmDateTo As DateTime

    Public WriteOnly Property pubProgramID As Integer
        Set(value As Integer)
            intProgramID = value
        End Set
    End Property

    Public WriteOnly Property pubCompanyID As Integer
        Set(value As Integer)
            intCompanyID = value
        End Set
    End Property

    Public WriteOnly Property pubDateFrom As DateTime
        Set(value As DateTime)
            dtmDateFrom = value
        End Set
    End Property

    Public WriteOnly Property pubDateTo As DateTime
        Set(value As DateTime)
            dtmDateTo = value
        End Set
    End Property

#End Region

    Private Const cRefresh As Byte = 0, cClose As Byte = 1

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "SCNumber", "Nomor", 100, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdView, "GroupID", "GroupID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "TotalChildSC", "Total Kontrak Penjualan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalChildCO", "Total Konfirmasi Pesanan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDifferent", "Total Selisih", 100, UI.usDefGrid.gReal2Num)
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtData = BL.SalesContract.ListDataDifferentTotalChild(intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            grdMain.DataSource = dtData
            pgMain.Value = 80

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

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("SCNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "SCNumber", strSearch)
        End With
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalChildSC As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalChildSC", "Total Kontrak Penjualan: {0:#,##0.00}")
        Dim SumTotalChildCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalChildCO", "Total Konfirmasi Pesanan: {0:#,##0.00}")
        Dim SumTotalDiff As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDifferent", "Total Selisih: {0:#,##0.00}")

        If grdView.Columns("TotalChildSC").SummaryText.Trim = "" Then
            grdView.Columns("TotalChildSC").Summary.Add(SumTotalChildSC)
        End If

        If grdView.Columns("TotalChildCO").SummaryText.Trim = "" Then
            grdView.Columns("TotalChildCO").Summary.Add(SumTotalChildCO)
        End If

        If grdView.Columns("TotalDifferent").SummaryText.Trim = "" Then
            grdView.Columns("TotalDifferent").Summary.Add(SumTotalDiff)
        End If

        grdView.BestFitColumns()
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractDifferentTotalChild_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraSalesContractDifferentTotalChild_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetGrid()
        prvSumGrid()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        End If
    End Sub

#End Region

End Class