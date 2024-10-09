Public Class frmTraSalesContractPrint

#Region "Properties"

    Private enumType As VO.SalesContract.PrintType = VO.SalesContract.PrintType.None
    Private strAdditionalTerm1 As String = ""
    Private strAdditionalTerm2 As String = ""
    Private strAdditionalTerm3 As String = ""
    Private strAdditionalTerm4 As String = ""
    Private strAdditionalTerm5 As String = ""
    Private strAdditionalTerm6 As String = ""
    Private strAdditionalTerm7 As String = ""
    Private strAdditionalTerm8 As String = ""
    Private strAdditionalTerm9 As String = ""
    Private strAdditionalTerm10 As String = ""

    Public ReadOnly Property pubType As VO.SalesContract.PrintType
        Get
            Return enumType
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm1 As String
        Get
            Return strAdditionalTerm1
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm2 As String
        Get
            Return strAdditionalTerm2
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm3 As String
        Get
            Return strAdditionalTerm3
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm4 As String
        Get
            Return strAdditionalTerm4
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm5 As String
        Get
            Return strAdditionalTerm5
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm6 As String
        Get
            Return strAdditionalTerm6
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm7 As String
        Get
            Return strAdditionalTerm7
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm8 As String
        Get
            Return strAdditionalTerm8
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm9 As String
        Get
            Return strAdditionalTerm9
        End Get
    End Property

    Public ReadOnly Property pubAdditionalTerm10 As String
        Get
            Return strAdditionalTerm10
        End Get
    End Property

#End Region

    Private Sub prvPreview()
        Dim strTipe As String = "None"
        If rdDefault.Checked Then
            enumType = VO.SalesContract.PrintType.DefaultValue
            strTipe = "Default"
        ElseIf rdSKBDN.Checked Then
            enumType = VO.SalesContract.PrintType.SKBDN
            strTipe = "SKBDN"
        End If

        strAdditionalTerm1 = txtAdditionalTerm1.Text.Trim
        strAdditionalTerm2 = txtAdditionalTerm2.Text.Trim
        strAdditionalTerm3 = txtAdditionalTerm3.Text.Trim
        strAdditionalTerm4 = txtAdditionalTerm4.Text.Trim
        strAdditionalTerm5 = txtAdditionalTerm5.Text.Trim
        strAdditionalTerm6 = txtAdditionalTerm6.Text.Trim
        strAdditionalTerm7 = txtAdditionalTerm7.Text.Trim
        strAdditionalTerm8 = txtAdditionalTerm8.Text.Trim
        strAdditionalTerm9 = txtAdditionalTerm9.Text.Trim
        strAdditionalTerm10 = txtAdditionalTerm10.Text.Trim

        If Not UI.usForm.frmAskQuestion("Cetak Kontrak Penjualan Tipe " & strTipe & "?") Then Exit Sub
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Print" : prvPreview()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class