Public Class frmTraSalesContractPrint

#Region "Properties"

    Private enumType As VO.SalesContract.PrintType = VO.SalesContract.PrintType.None
    Private strID As String = ""
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

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
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

    Private Sub prvFillForm()
        Try
            Dim clsData As VO.SalesContract = BL.SalesContract.GetDetail(strID)
            txtAdditionalTerm1.Text = clsData.AdditionalTerm1
            txtAdditionalTerm2.Text = clsData.AdditionalTerm2
            txtAdditionalTerm3.Text = clsData.AdditionalTerm3
            txtAdditionalTerm4.Text = clsData.AdditionalTerm4
            txtAdditionalTerm5.Text = clsData.AdditionalTerm5
            txtAdditionalTerm6.Text = clsData.AdditionalTerm6
            txtAdditionalTerm7.Text = clsData.AdditionalTerm7
            txtAdditionalTerm8.Text = clsData.AdditionalTerm8
            txtAdditionalTerm9.Text = clsData.AdditionalTerm9
            txtAdditionalTerm10.Text = clsData.AdditionalTerm10
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

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
        txtAdditionalTerm1.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm2.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm3.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm4.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm5.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm6.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm7.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm8.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm9.CharacterCasing = CharacterCasing.Normal
        txtAdditionalTerm10.CharacterCasing = CharacterCasing.Normal
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Print" : prvPreview()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class