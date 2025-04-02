Public Class frmMstChartOfAccount

    Public pubLUdtRow As DataRow
    Public pubIsLookUp As Boolean = False
    Public pubIsLookUpGet As Boolean = False
    Public pubFilterGroup As VO.ChartOfAccount.FilterGroup = VO.ChartOfAccount.FilterGroup.All
    Public pubCompanyID As Integer = 0
    Public pubProgramID As Integer = 0
    Private intPos As Integer = 0
    Private dtData As New DataTable

    Private Const _
       cGet As Byte = 0, cSep1 As Byte = 1, cNew As Byte = 2, cDetail As Byte = 3, cDelete As Byte = 4, cSep2 As Byte = 5,
       cHistory As Byte = 6, cAssign As Byte = 7, cSync As Byte = 8, cSep3 As Byte = 9, cRefresh As Byte = 10, cClose As Byte = 11

    Private Sub prvSetTitleForm()
        If pubIsLookUp Then
            Me.Text += " [Lookup] "
        End If
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "AccountGroupID", "AccountGroupID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "AccountGroupName", "AccountGroupName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "TypeAccount", "Jenis", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "GroupAccount", "Group", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Code", "Kode Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Name", "Nama Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Balance", "Saldo", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "StatusID", "StatusID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Dibuat Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Tanggal Buat", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogBy", "Diedit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LogDate", "Tanggal Edit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogInc", "Jumlah Edit", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "StatusInfo", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Initial", "Inisial", 100, UI.usDefGrid.gString, False)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cGet).Visible = pubIsLookUp
            .Item(cSep1).Visible = pubIsLookUp
            .Item(cGet).Enabled = bolEnable
            .Item(cDetail).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
            .Item(cHistory).Enabled = bolEnable
            .Item(cAssign).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Try
            If pubProgramID = 0 Then pubProgramID = ERPSLib.UI.usUserApp.ProgramID
            If pubCompanyID = 0 Then pubCompanyID = ERPSLib.UI.usUserApp.CompanyID

            dtData = BL.ChartOfAccount.ListData(pubFilterGroup, pubCompanyID, pubProgramID, VO.Status.Values.All)
            grdMain.DataSource = dtData
            grdView.Columns("TypeAccount").GroupIndex = 0
            grdView.Columns("GroupAccount").GroupIndex = 1
            grdView.ExpandAllGroups()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("Code")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "Code", strSearch)
        End With
    End Sub

    Private Function prvGetData() As VO.ChartOfAccount
        Dim clsReturn As New VO.ChartOfAccount
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.ProgramID = grdView.GetRowCellValue(intPos, "ProgramID")
        clsReturn.CompanyID = grdView.GetRowCellValue(intPos, "CompanyID")
        clsReturn.AccountGroupID = grdView.GetRowCellValue(intPos, "AccountGroupID")
        clsReturn.AccountGroupName = grdView.GetRowCellValue(intPos, "AccountGroupName")
        clsReturn.Code = grdView.GetRowCellValue(intPos, "Code")
        clsReturn.Name = grdView.GetRowCellValue(intPos, "Name")
        Return clsReturn
    End Function

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not pubIsLookUp Then Exit Sub
        If grdView.GetRowCellValue(intPos, "StatusID") = VO.Status.Values.InActive Then
            UI.usForm.frmMessageBox("Tidak dapat pilih akun " & grdView.GetRowCellValue(intPos, "Name") & ". Dikarenakan akun tersebut sudah tidak aktif")
            Exit Sub
        Else
            pubLUdtRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            pubIsLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmMstChartOfAccountDet
        With frmDetail
            .pubIsNew = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstChartOfAccountDet
        With frmDetail
            .pubIsNew = False
            .pubID = grdView.GetRowCellValue(intPos, "ID")
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not UI.usForm.frmAskQuestion("Hapus nama akun " & grdView.GetRowCellValue(intPos, "Name") & "?") Then Exit Sub
        Try
            BL.ChartOfAccount.DeleteData(grdView.GetRowCellValue(intPos, "ID"))
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "Code"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvAssign()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstChartOfAccountAssign
        With frmDetail
            .pubClsData = prvGetData()
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvSync()
        Try
            BL.ChartOfAccount.SyncFromVPS()
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message, "Sync From VPS")
        End Try
    End Sub

    Private Sub prvHistory()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstChartOfAccountHistory
        With frmDetail
            .pubClsData = prvGetData()
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvUserAccess()
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccount, VO.Access.Value.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccount, VO.Access.Value.DeleteAccess)
            .Item(cAssign).Visible = False ' BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccount, VO.Access.Value.AssignAccess)
            .Item(cSync).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccount, -1)
            '.Item(cHistory).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccount, VO.Access.Value.HistoryAccess)
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmMstChartOfAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstChartOfAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvQuery()
        prvUserAccess()
        If Not pubIsLookUp Then Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        ElseIf e.Button.Name = ToolBar.Buttons(cNew).Name Then
            prvNew()
        ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf e.Button.Name = ToolBar.Buttons(cSync).Name Then
            prvSync()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cGet).Name : prvGet()
                Case ToolBar.Buttons(cHistory).Name : prvHistory()
                Case ToolBar.Buttons(cAssign).Name : prvAssign()
                Case ToolBar.Buttons(cDetail).Name : prvDetail()
                Case ToolBar.Buttons(cDelete).Name : prvDelete()
            End Select
        End If
    End Sub

    Private Sub grdView_DoubleClick(sender As Object, e As EventArgs) Handles grdView.DoubleClick
        If pubIsLookUp Then
            prvGet()
        End If
    End Sub

    Private Sub grdView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim intStatus As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StatusID"))
            If intStatus = VO.Status.Values.InActive Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

#End Region

End Class