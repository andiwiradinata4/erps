﻿Public Class frmMstUserUserAccess

#Region "Property"

    Private frmParent As frmMstUser
    Private clsData As VO.UserAccess
    Private dtData As New DataTable
    Private dsHelper As New DataSetHelper
    Property pubUserID As String

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cClose = 0

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "Pick", "Pick", 100, UI.usDefGrid.gBoolean, True, False)
        UI.usForm.SetGrid(grdView, "AccessID", "AccessID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "AccessName", "Nama Akses", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillProgram()
        Me.Cursor = Cursors.WaitCursor
        Try
            dsHelper = New DataSetHelper
            Dim dtProgram As New DataTable
            If ERPSLib.UI.usUserApp.IsSuperUser Then
                dtProgram = BL.Program.ListData
            Else
                dtProgram = dsHelper.SelectGroupByInto("Program", ERPSLib.UI.usUserApp.AccessList, "ProgramID,ProgramName", "", "ProgramID,ProgramName")
            End If
            UI.usForm.FillComboBox(cboProgram, dtProgram, "ProgramID", "ProgramName", True)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvFillModules()
        If cboProgram.SelectedIndex = -1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Try
            dsHelper = New DataSetHelper
            Dim dtModules As New DataTable
            Dim strFilter As String = "ProgramID=" & cboProgram.SelectedValue
            If ERPSLib.UI.usUserApp.IsSuperUser Then
                dtModules = BL.ProgramModules.ListDataByProgramID(cboProgram.SelectedValue)
            Else
                dtModules = dsHelper.SelectGroupByInto("Modules", ERPSLib.UI.usUserApp.AccessList, "ModulesID,ModulesName", strFilter, "ModulesID,ModulesName")
            End If
            UI.usForm.FillComboBoxEdit(cboModules, dtModules, "ModulesID", "ModulesName", "Module Name", True)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvFillCombo()
        prvFillProgram()
        prvFillModules()
    End Sub

    Private Sub prvQuery()
        If cboProgram.SelectedIndex = -1 Then Exit Sub
        If cboModules.EditValue Is Nothing Then
            Exit Sub
        ElseIf cboModules.Text.Trim = "" Then
            Exit Sub
        End If
        
        Me.Cursor = Cursors.WaitCursor
        Try
            dtData = BL.UserAccess.ListDataByModulesIDAndProgramID(pubUserID, cboProgram.SelectedValue, cboModules.EditValue)
            grdMain.DataSource = dtData
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        Dim drPick() As DataRow = dtData.Select("Pick=true")

        If drPick.Count = 0 Then
            If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub
        Else
            If Not UI.usForm.frmAskQuestion("Simpan semua akses yang dipilih?") Then Exit Sub
        End If

        Dim clsDataAll(drPick.Count - 1) As VO.UserAccess
        For i As Integer = 0 To drPick.Count - 1
            clsData = New VO.UserAccess
            clsData.UserID = pubUserID
            clsData.ModulesID = cboModules.EditValue
            clsData.ProgramID = cboProgram.SelectedValue
            clsData.AccessID = drPick(i).Item("AccessID")
            clsDataAll(i) = clsData
        Next

        Me.Cursor = Cursors.WaitCursor
        Try
            If BL.UserAccess.SaveData(clsDataAll, cboProgram.SelectedValue, cboModules.EditValue, pubUserID) Then
                UI.usForm.frmMessageBox("Simpan data berhasil")
                prvQuery()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
        prvSetGrid()
    End Sub

#Region "Form Handle"

    Private Sub frmMstUserUserAccess_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close this form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmMstUserUserAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        Me.Text += " [user: " & pubUserID & "] "
        prvSetGrid()
        prvFillCombo()

        AddHandler cboProgram.SelectedIndexChanged, AddressOf cboProgram_SelectedIndexChanged
        AddHandler cboModules.EditValueChanged, AddressOf cboModules_EditValueChanged
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        prvSave()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        prvQuery()
    End Sub

    Private Sub cboProgram_SelectedIndexChanged(sender As Object, e As EventArgs)
        prvFillModules()
    End Sub

    Private Sub cboModules_EditValueChanged(sender As Object, e As EventArgs)
        prvClear()
        prvQuery()
    End Sub

#End Region

End Class