Public Class frmTraAccountSetInvoiceNumberBP

    Private bolSave As Boolean = False
    Private strInvoiceNumberSupplier As String = ""
    Private strRemarks As String = ""

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public Property pubInvoiceNumberSupplier As String
        Set(value As String)
            strInvoiceNumberSupplier = value
        End Set
        Get
            Return strInvoiceNumberSupplier
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
        strInvoiceNumberSupplier = txtTaxInvoiceNumber.Text.Trim
        strRemarks = txtRemarks.Text.Trim
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraAccountSetInvoiceNumberBP_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraAccountSetInvoiceNumberBP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        txtTaxInvoiceNumber.Text = strInvoiceNumberSupplier.Trim
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class