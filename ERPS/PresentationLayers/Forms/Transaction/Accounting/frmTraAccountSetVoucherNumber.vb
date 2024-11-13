Public Class frmTraAccountSetVoucherNumber

    Private bolSave As Boolean = False
    Private strVoucherNumber As String = ""
    Private dtmVoucherDate As DateTime = Now
    Private strRemarks As String = ""

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public Property pubVoucherNumber As String
        Set(value As String)
            strVoucherNumber = value
        End Set
        Get
            Return strVoucherNumber
        End Get
    End Property

    Public Property pubVoucherDate As DateTime
        Set(value As DateTime)
            dtmVoucherDate = value
        End Set
        Get
            Return dtmVoucherDate
        End Get
    End Property

    Public ReadOnly Property pubRemarks As String
        Get
            Return strRemarks
        End Get
    End Property

    Private Sub prvSave()
        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub
        bolSave = True
        strVoucherNumber = txtVoucherNumber.Text.Trim
        dtmVoucherDate = dtpVoucherDate.Value.Date
        strRemarks = txtRemarks.Text.Trim
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraAccountSetVoucherNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraAccountSetVoucherNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        txtVoucherNumber.Text = strVoucherNumber.Trim
        dtpVoucherDate.Value = dtmVoucherDate
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region
  
End Class