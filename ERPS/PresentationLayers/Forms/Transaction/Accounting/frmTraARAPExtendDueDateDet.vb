Public Class frmTraARAPExtendDueDateDet

#Region "Properties"

    Private bolIsNew As Boolean
    Private strID As String
    Private strParentID As String
    Private clsData As New VO.ARAPDueDateHistory

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public WriteOnly Property pubParentID As String
        Set(value As String)
            strParentID = value
        End Set
    End Property

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, _
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1

    Private Sub prvSetTitleForm()
        If bolIsNew Then
            Me.Text += " [baru] "
        Else
            Me.Text += " [edit] "
        End If
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            If bolIsNew Then
                prvClear()
            Else
                clsData = New VO.ARAPDueDateHistory
                clsData = BL.ARAPDueDateHistory.GetDetail(strID)
                dtpDueDate.Value = clsData.DueDate
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If Not UI.usForm.frmAskQuestion("Simpan Data?") Then Exit Sub
        
        Me.Cursor = Cursors.WaitCursor

        clsData = New VO.ARAPDueDateHistory
        clsData.ID = strID
        clsData.ParentID = strParentID
        clsData.DueDate = dtpDueDate.Value
        clsData.Remarks = ""
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        Try
            Dim strID As String = BL.ARAPDueDateHistory.SaveData(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan.")
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvClear()
        strID = ""
        dtpDueDate.Value = Now
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPExtendDueDateDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If  e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraARAPExtendDueDateDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetTitleForm()
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class