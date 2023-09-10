Public Class frmmstStatusModules

#Region "Property"

    Private clsData As VO.StatusModules
    Property pubFilterBy As VO.StatusModules.FilterBy
    Property pubIsSave As Boolean = False
    Property pubRefID As Integer = 0
    Property pubRefName As String = ""
    Private dtData As New DataTable
    Private intPos As Integer

    Private Const _
       cSave = 0, cClose = 1,
       cAdd = 0, cDelete = 1

#End Region

    Private Sub prvSetTitleForm()
        If pubFilterBy = VO.StatusModules.FilterBy.StatusID Then
            Me.Text += "Status Detail"
            lblInfo.Text += "Status"
        ElseIf pubFilterBy = VO.StatusModules.FilterBy.ModulesID Then
            Me.Text += "Modules Detail"
            lblInfo.Text += "Modules"
        End If
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ModulesID", "Modules ID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "StatusID", "ID Status", 100, UI.usDefGrid.gIntNum, False)
        If pubFilterBy = VO.StatusModules.FilterBy.StatusID Then
            UI.usForm.SetGrid(grdView, "ModulesName", "Modules", 250, UI.usDefGrid.gString)
        ElseIf pubFilterBy = VO.StatusModules.FilterBy.ModulesID Then
            UI.usForm.SetGrid(grdView, "StatusName", "Status", 250, UI.usDefGrid.gString)
        End If
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBarDet.Buttons
            .Item(cDelete).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Try
            If pubFilterBy = VO.StatusModules.FilterBy.StatusID Then
                dtData = BL.StatusModules.ListDataByStatusID(pubRefID)
            ElseIf pubFilterBy = VO.StatusModules.FilterBy.ModulesID Then
                dtData = BL.StatusModules.ListDataByModulesID(pubRefID)
            End If

            grdMain.DataSource = dtData
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        prvSetButton()
    End Sub

    Private Sub prvAdd()
        If pubFilterBy = VO.StatusModules.FilterBy.StatusID Then
            Dim frmDetail As New frmMstModules
            With frmDetail
                .pubIsLookUp = True
                '.pubLUTableParent = dtData
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
                If .pubIsLookUpGet Then
                    Dim drNewRow As DataRow
                    For Each drRow As DataRow In .pubLUdtRow
                        drNewRow = dtData.NewRow
                        With drNewRow
                            .BeginEdit()
                            .Item("ID") = 0
                            .Item("StatusID") = pubRefID
                            .Item("ModulesID") = drRow.Item("ID")
                            .Item("ModulesName") = drRow.Item("Name")
                            .EndEdit()
                        End With
                        dtData.Rows.Add(drNewRow)
                    Next
                    dtData.AcceptChanges()
                    prvSetButton()
                End If
            End With
        ElseIf pubFilterBy = VO.StatusModules.FilterBy.ModulesID Then
            Dim frmDetail As New frmMstStatus
            With frmDetail
                .pubIsLookUp = True
                '.pubLUTableParent = dtData
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
                If .pubIsLookUpGet Then
                    Dim drNewRow As DataRow
                    For Each drRow As DataRow In .pubLUdtRow
                        drNewRow = dtData.NewRow
                        With drNewRow
                            .BeginEdit()
                            .Item("ID") = 0
                            .Item("StatusID") = drRow.Item("ID")
                            .Item("ModulesID") = pubRefID
                            .Item("StatusName") = drRow.Item("Name")
                            .EndEdit()
                        End With
                        dtData.Rows.Add(drNewRow)
                    Next
                    dtData.AcceptChanges()
                    prvSetButton()
                End If
            End With
        End If
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If pubFilterBy = VO.StatusModules.FilterBy.StatusID Then
            Dim intModuleID As Integer = grdView.GetRowCellValue(intPos, "ModulesID")
            For Each drRow As DataRow In dtData.Rows
                If drRow.Item("ModulesID") = intModuleID Then
                    drRow.Delete()
                    Exit For
                End If
            Next
        ElseIf pubFilterBy = VO.StatusModules.FilterBy.ModulesID Then
            Dim intStatusID As Integer = grdView.GetRowCellValue(intPos, "StatusID")
            For Each drRow As DataRow In dtData.Rows
                If drRow.Item("StatusID") = intStatusID Then
                    drRow.Delete()
                    Exit For
                End If
            Next
        End If

        dtData.AcceptChanges()
        grdMain.DataSource = dtData
        prvSetButton()
    End Sub

    Private Sub prvSave()
        If grdView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Tambah item terlebih dahulu")
            grdView.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        Dim clsData As VO.StatusModules
        Dim clsDataAll(grdView.RowCount - 1) As VO.StatusModules
        With grdView
            For i As Integer = 0 To .RowCount - 1
                clsData = New VO.StatusModules
                clsData.ModulesID = .GetRowCellValue(i, "ModulesID")
                clsData.StatusID = .GetRowCellValue(i, "StatusID")
                clsDataAll(i) = clsData
            Next
        End With

        Try
            If pubFilterBy = VO.StatusModules.FilterBy.StatusID Then
                BL.StatusModules.SaveDataByStatusID(clsDataAll)
                UI.usForm.frmMessageBox("Data berhasil disimpan.")
                Me.Close()
            ElseIf pubFilterBy = VO.StatusModules.FilterBy.ModulesID Then
                BL.StatusModules.SaveDataByModulesID(clsDataAll)
                UI.usForm.frmMessageBox("Data berhasil disimpan.")
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, VO.Access.Values.NewAccess)
    End Sub

#Region "Form Handle"

    Private Sub frmmstStatusModules_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form ini?") Then Me.Close()
        End If
    End Sub

    Private Sub frmStatusModules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDet.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        txtName.Text = pubRefName
        prvQuery()
        prvUserAccess()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarDet_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDet.ButtonClick
        Select Case e.Button.Text
            Case "Add" : prvAdd()
            Case "Delete" : prvDelete()
        End Select
    End Sub

#End Region

End Class