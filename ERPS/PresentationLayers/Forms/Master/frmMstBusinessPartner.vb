Public Class frmMstBusinessPartner

    Public pubLUdtRow As DataRow
    Public pubIsLookUp As Boolean = False
    Public pubIsLookUpGet As Boolean = False
    Private dtData As New DataTable

    Private Const _
       cGet As Byte = 0, cSep1 As Byte = 1, cNew As Byte = 2, cDetail As Byte = 3, _
       cDelete As Byte = 4, cBankAccount As Byte = 5, cSep2 As Byte = 6, cRefresh As Byte = 7,
       cClose As Byte = 8

    Private Sub prvSetTitleForm()
        If pubIsLookUp Then
            Me.Text += " [Lookup] "
        End If
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "Code", "Kode Rekan Bisnis", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Name", "Nama Rekan Bisnis", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Address", "Alamat", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PICName", "Nama PIC", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PICPhoneNumber", "No. HP PIC", 100, UI.usDefGrid.gString)
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
            .Item(cBankAccount).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = BL.BusinessPartner.ListData
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("Name")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "Name", strSearch)
        End With
    End Sub

    Private Sub prvGet()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not pubIsLookUp Then Exit Sub
        If grdView.GetRowCellValue(intPos, "StatusID") = VO.Status.Values.InActive Then
            UI.usForm.frmMessageBox("Tidak dapat pilih rekan bisnis " & grdView.GetRowCellValue(intPos, "Name") & ". Dikarenakan data tersebut sudah tidak aktif")
            Exit Sub
        Else
            pubLUdtRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            pubIsLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmMstBusinessPartnerDet
        With frmDetail
            .pubIsNew = True
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstBusinessPartnerDet
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
        If Not UI.usForm.frmAskQuestion("Hapus data  " & grdView.GetRowCellValue(intPos, "Name") & "?") Then Exit Sub
        Try
            BL.BusinessPartner.DeleteData(grdView.GetRowCellValue(intPos, "ID"))
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "Name"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvBankAccount()
        Dim intPos As Integer = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstBusinessPartnerBankAccount
        With frmDetail
            .pubBPID = grdView.GetRowCellValue(intPos, "ID")
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
        prvSetGrid()
        prvSetButton()
    End Sub

    Private Sub prvUserAccess()
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterBusinessPartner, VO.Access.Values.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterBusinessPartner, VO.Access.Values.DeleteAccess)
            .Item(cBankAccount).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterBusinessPartner, VO.Access.Values.BankInfoAccess)
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmMstBusinessPartner_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstBusinessPartner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Case ToolBar.Buttons(cBankAccount).Name : prvBankAccount()
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