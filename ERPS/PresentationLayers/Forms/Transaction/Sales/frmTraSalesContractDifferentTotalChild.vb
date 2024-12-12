Imports DevExpress.XtraGrid
Public Class frmTraSalesContractDifferentTotalChild

#Region "Form Handle"

    Private intProgramID As Integer
    Private intCompanyID As Integer
    Private dtDataF1 As New DataTable
    Private dtDataF2 As New DataTable
    Private dtDataF3 As New DataTable
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
        '# F1
        UI.usForm.SetGrid(grdViewF1, "SCNumber", "Nomor", 100, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdViewF1, "GroupID", "GroupID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdViewF1, "TotalChildSC", "Total Kontrak Penjualan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdViewF1, "TotalChildCO", "Total Konfirmasi Pesanan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdViewF1, "TotalDifferent", "Total Selisih", 100, UI.usDefGrid.gReal2Num)

        '# F2
        UI.usForm.SetGrid(grdViewF2, "SCNumber", "Nomor", 100, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdViewF2, "GroupID", "GroupID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdViewF2, "TotalParent", "Total Berat [Induk]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdViewF2, "TotalChild", "Total Berat [Subitem]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdViewF2, "TotalDifferent", "Total Selisih", 100, UI.usDefGrid.gReal2Num)

        '# F3
        UI.usForm.SetGrid(grdViewF3, "SCNumber", "Nomor", 100, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdViewF3, "GroupID", "GroupID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdViewF3, "TotalParent", "Total Berat [Induk]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdViewF3, "TotalChild", "Total Berat [Subitem]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdViewF3, "TotalDifferent", "Total Selisih", 100, UI.usDefGrid.gReal2Num)
    End Sub

#Region "F1"

    Private Sub prvSumGridF1()
        Dim SumTotalChildSC As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalChildSC", "Total Kontrak Penjualan: {0:#,##0.00}")
        Dim SumTotalChildCO As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalChildCO", "Total Konfirmasi Pesanan: {0:#,##0.00}")
        Dim SumTotalDiff As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDifferent", "Total Selisih: {0:#,##0.00}")

        If grdViewF1.Columns("TotalChildSC").SummaryText.Trim = "" Then
            grdViewF1.Columns("TotalChildSC").Summary.Add(SumTotalChildSC)
        End If

        If grdViewF1.Columns("TotalChildCO").SummaryText.Trim = "" Then
            grdViewF1.Columns("TotalChildCO").Summary.Add(SumTotalChildCO)
        End If

        If grdViewF1.Columns("TotalDifferent").SummaryText.Trim = "" Then
            grdViewF1.Columns("TotalDifferent").Summary.Add(SumTotalDiff)
        End If
        grdViewF1.BestFitColumns()
    End Sub

    Private Sub prvQueryF1()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtDataF1 = BL.SalesContract.ListDataDifferentTotalChild(intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            grdMainF1.DataSource = dtDataF1
            pgMain.Value = 80

            prvSumGridF1()
            grdViewF1.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Public Sub pubRefreshF1(Optional ByVal strSearch As String = "")
        With grdViewF1
            If Not grdViewF1.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdViewF1.GetDataRow(grdViewF1.FocusedRowHandle).Item("SCNumber")
            End If
            prvQueryF1()
            If grdViewF1.RowCount > 0 Then UI.usForm.GridMoveRow(grdViewF1, "SCNumber", strSearch)
        End With
    End Sub

#End Region

#Region "F2"

    Private Sub prvSumGridF2()
        Dim TotalParentF2 As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalParent", "Total Kontrak Penjualan: {0:#,##0.00}")
        Dim TotalChildF2 As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalChild", "Total Kontrak Penjualan: {0:#,##0.00}")
        Dim SumTotalDiffF2 As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDifferent", "Total Selisih: {0:#,##0.00}")

        If grdViewF2.Columns("TotalParent").SummaryText.Trim = "" Then
            grdViewF2.Columns("TotalParent").Summary.Add(TotalParentF2)
        End If

        If grdViewF2.Columns("TotalChild").SummaryText.Trim = "" Then
            grdViewF2.Columns("TotalChild").Summary.Add(TotalChildF2)
        End If

        If grdViewF2.Columns("TotalDifferent").SummaryText.Trim = "" Then
            grdViewF2.Columns("TotalDifferent").Summary.Add(SumTotalDiffF2)
        End If
        grdViewF2.BestFitColumns()
    End Sub

    Private Sub prvQueryF2()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtDataF2 = BL.SalesContract.ListDataDifferentParentWithTotalChild(intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            grdMainF2.DataSource = dtDataF2
            pgMain.Value = 80

            prvSumGridF2()
            grdViewF2.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Public Sub pubRefreshF2(Optional ByVal strSearch As String = "")
        With grdViewF2
            If Not grdViewF2.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdViewF2.GetDataRow(grdViewF2.FocusedRowHandle).Item("SCNumber")
            End If
            prvQueryF2()
            If grdViewF2.RowCount > 0 Then UI.usForm.GridMoveRow(grdViewF2, "SCNumber", strSearch)
        End With
    End Sub

#End Region

#Region "F3"

    Private Sub prvSumGridF3()
        Dim TotalParentF3 As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalParent", "Total Kontrak Penjualan: {0:#,##0.00}")
        Dim TotalChildF3 As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalChild", "Total Kontrak Penjualan: {0:#,##0.00}")
        Dim SumTotalDiffF3 As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDifferent", "Total Selisih: {0:#,##0.00}")

        If grdViewF3.Columns("TotalParent").SummaryText.Trim = "" Then
            grdViewF3.Columns("TotalParent").Summary.Add(TotalParentF3)
        End If

        If grdViewF3.Columns("TotalChild").SummaryText.Trim = "" Then
            grdViewF3.Columns("TotalChild").Summary.Add(TotalChildF3)
        End If

        If grdViewF3.Columns("TotalDifferent").SummaryText.Trim = "" Then
            grdViewF3.Columns("TotalDifferent").Summary.Add(SumTotalDiffF3)
        End If
        grdViewF3.BestFitColumns()
    End Sub

    Private Sub prvQueryF3()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtDataF3 = BL.SalesContract.ListDataDifferentParentWithTotalChildKO(intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            grdMainF3.DataSource = dtDataF3
            pgMain.Value = 80

            prvSumGridF3()
            grdViewF3.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Public Sub pubRefreshF3(Optional ByVal strSearch As String = "")
        With grdViewF3
            If Not grdViewF3.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdViewF3.GetDataRow(grdViewF3.FocusedRowHandle).Item("SCNumber")
            End If
            prvQueryF3()
            If grdViewF3.RowCount > 0 Then UI.usForm.GridMoveRow(grdViewF3, "SCNumber", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraSalesContractDifferentTotalChild_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            tcMain.SelectedTab = tpF1
        ElseIf e.KeyCode = Keys.F2 Then
            tcMain.SelectedTab = tpF2
        ElseIf e.KeyCode = Keys.F3 Then
            tcMain.SelectedTab = tpF3
        End If
    End Sub

    Private Sub frmTraSalesContractDifferentTotalChild_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBarF1.SetIcon(Me)
        ToolBarF2.SetIcon(Me)
        ToolBarF3.SetIcon(Me)
        prvSetGrid()
        prvSumGridF1()
        'prvQueryF1()
        'prvQueryF2()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarF1.ButtonClick
        If e.Button.Name = ToolBarF1.Buttons(cRefresh).Name Then
            pubRefreshF1()
        ElseIf e.Button.Name = ToolBarF1.Buttons(cClose).Name Then
            Me.Close()
        End If
    End Sub

    Private Sub ToolBarF2_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarF2.ButtonClick
        If e.Button.Name = ToolBarF2.Buttons(cRefresh).Name Then
            pubRefreshF2()
        ElseIf e.Button.Name = ToolBarF2.Buttons(cClose).Name Then
            Me.Close()
        End If
    End Sub

    Private Sub ToolBarF3_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarF3.ButtonClick
        If e.Button.Name = ToolBarF3.Buttons(cRefresh).Name Then
            pubRefreshF3()
        ElseIf e.Button.Name = ToolBarF3.Buttons(cClose).Name Then
            Me.Close()
        End If
    End Sub

#End Region

End Class