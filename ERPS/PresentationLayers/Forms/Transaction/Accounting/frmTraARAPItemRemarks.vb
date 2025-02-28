Public Class frmTraARAPItemRemarks

#Region "Property"

    Private bolIsNew As Boolean
    Private strRemarks As String = ""
    Private bolIsSave As Boolean

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public Property pubRemarks As String
        Set(value As String)
            strRemarks = value
        End Set
        Get
            Return strRemarks
        End Get
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            Me.Cursor = Cursors.Default
            If Not bolIsNew Then
                txtRemarks.Text = strRemarks
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtRemarks.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Keterangan tidak boleh kosong")
            txtRemarks.Focus()
            Exit Sub
        End If

        strRemarks = txtRemarks.Text.Trim
        bolIsSave = True
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPItemRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraARAPItemRemarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

#End Region

End Class