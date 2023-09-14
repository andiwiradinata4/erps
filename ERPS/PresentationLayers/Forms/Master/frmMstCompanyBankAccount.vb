Public Class frmMstCompanyBankAccount

    Public pubLUdtRow As DataRow
    Public pubIsLookUp As Boolean = False
    Public pubIsLookUpGet As Boolean = False
    Private dtData As New DataTable

    Private Const _
       cGet As Byte = 0, cSep1 As Byte = 1, cNew As Byte = 2, cDetail As Byte = 3, _
       cDelete As Byte = 4, cSep2 As Byte = 5, cRefresh As Byte = 6, cClose As Byte = 7

    Private Sub prvSetTitleForm()
        If pubIsLookUp Then
            Me.Text += " [Lookup] "
        End If
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyName", "Perusahaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "AccountName", "Nama Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BankName", "Nama Bank", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "AccountNumber", "Nomor Rekening", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Currency", "Mata Uang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "StatusID", "StatusID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "StatusInfo", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Dibuat Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Tanggal Buat", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogBy", "Diedit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LogDate", "Tanggal Edit", 100, UI.usDefGrid.gFullDate)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cGet).Visible = pubIsLookUp
            .Item(cSep1).Visible = pubIsLookUp
            .Item(cGet).Enabled = bolEnable
            .Item(cDetail).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = BL.CompanyBankAccount.ListData
            grdView.Columns("CompanyName").GroupIndex = 0
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
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("BankName")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "BankName", strSearch)
        End With
    End Sub

    Private Sub prvGet()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not pubIsLookUp Then Exit Sub
        If grdView.GetRowCellValue(intPos, "StatusID") = VO.Status.Values.InActive Then
            UI.usForm.frmMessageBox("Tidak dapat pilih akun " & grdView.GetRowCellValue(intPos, "AccountName") & "|" & grdView.GetRowCellValue(intPos, "BankName") & "|" & grdView.GetRowCellValue(intPos, "AccountNumber") & ". Dikarenakan data tersebut sudah tidak aktif")
            Exit Sub
        Else
            pubLUdtRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            pubIsLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmMstCompanyBankAccountDet
        With frmDetail
            .pubIsNew = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstCompanyBankAccountDet
        With frmDetail
            .pubIsNew = False
            .pubID = grdView.GetRowCellValue(intPos, "ID")
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not UI.usForm.frmAskQuestion("Hapus data  " & grdView.GetRowCellValue(intPos, "AccountName") & "|" & grdView.GetRowCellValue(intPos, "BankName") & "|" & grdView.GetRowCellValue(intPos, "AccountNumber") & "?") Then Exit Sub
        Try
            BL.CompanyBankAccount.DeleteData(grdView.GetRowCellValue(intPos, "ID"))
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "Name"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
        prvSetGrid()
        prvSetButton()
    End Sub

    Private Sub prvUserAccess()
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterCompanyBankAccount, VO.Access.Values.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterCompanyBankAccount, VO.Access.Values.DeleteAccess)
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmMstCompanyBankAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstCompanyBankAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cGet).Name : prvGet()
                Case ToolBar.Buttons(cDetail).Name : prvDetail()
                Case ToolBar.Buttons(cDelete).Name : prvDelete()
            End Select
        End If
    End Sub

    Private Sub grdMain_DoubleClick(sender As Object, e As EventArgs) Handles grdMain.DoubleClick
        If pubIsLookUp Then
            prvGet()
        End If
    End Sub

    Private Sub grdView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim StatusID As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StatusID"))
            If StatusID = VO.Status.Values.InActive Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

#End Region
   
End Class