Public Class frmTraARAPExtendDueDate

#Region "Form Handle"

    Private intPos As Integer = 0
    Private strParentID As String
    Private clsData As New VO.ARAPDueDateHistory

    Public WriteOnly Property pubParentID As String
        Set(value As String)
            strParentID = value
        End Set
    End Property

#End Region

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3,
       cRefresh As Byte = 4, cClose As Byte = 5

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "DueDate", "Tanggal Jatuh Tempo", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Dibuat Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Tanggal Buat", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogBy", "Diedit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LogDate", "Tanggal Edit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogInc", "LogInc", 100, UI.usDefGrid.gIntNum)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cDetail).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        Try
            grdMain.DataSource = BL.ARAPDueDateHistory.ListData(strParentID)
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            prvSetButton()
        End Try
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("ID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "ID", strSearch)
        End With
    End Sub

    Private Function prvGetData() As VO.ARAPDueDateHistory
        Dim clsReturn As New VO.ARAPDueDateHistory
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.ParentID = grdView.GetRowCellValue(intPos, "ParentID")
        clsReturn.DueDate = grdView.GetRowCellValue(intPos, "DueDate")
        clsReturn.Remarks = grdView.GetRowCellValue(intPos, "Remarks")
        Return clsReturn
    End Function

    Private Sub prvNew()
        Dim frmDetail As New frmTraARAPExtendDueDateDet
        With frmDetail
            .pubIsNew = True
            .pubParentID = strParentID
            .Text = Me.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            pubRefresh()
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraARAPExtendDueDateDet
        With frmDetail
            .pubIsNew = False
            .pubID = clsData.ID
            .pubParentID = strParentID
            .Text = Me.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        If Not UI.usForm.frmAskQuestion("Hapus Tanggal " & clsData.DueDate & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Try
            BL.ARAPDueDateHistory.DeleteData(clsData.ID, clsData.ParentID, clsData.LogBy)
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPExtendDueDate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraARAPExtendDueDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetGrid()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cNew).Name Then
            prvNew()
        ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cDetail).Name : prvDetail()
                Case ToolBar.Buttons(cDelete).Name : prvDelete()
            End Select
        End If
    End Sub

#End Region

End Class