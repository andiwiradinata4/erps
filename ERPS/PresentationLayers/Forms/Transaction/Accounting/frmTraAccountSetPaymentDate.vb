Public Class frmTraAccountSetPaymentDate

#Region "Property"

    Private bolSave As Boolean = False
    Private dtmPaymentDate As DateTime
    Private strRemarks As String = ""
    Private intCoAID As Integer = 0
    Private clsCS As New VO.CS
    Private strCoACode As String = ""
    Private strCoAName As String = ""
    Private bolChooseCoA As Boolean

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public ReadOnly Property pubPaymentDate As DateTime
        Get
            Return dtmPaymentDate
        End Get
    End Property

    Public ReadOnly Property pubRemarks As String
        Get
            Return strRemarks
        End Get
    End Property

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public Property pubCoAID As Integer
        Set(value As Integer)
            intCoAID = value
        End Set
        Get
            Return intCoAID
        End Get
    End Property

    Public WriteOnly Property pubCoACode As String
        Set(value As String)
            strCoACode = value
        End Set
    End Property

    Public WriteOnly Property pubCoAName As String
        Set(value As String)
            strCoAName = value
        End Set
    End Property

    Public WriteOnly Property pubChooseCoA As Boolean
        Set(value As Boolean)
            bolChooseCoA = value
        End Set
    End Property

#End Region

    Private Sub prvSave()
        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub
        bolSave = True
        dtmPaymentDate = dtpPaymentDate.Value
        strRemarks = txtRemarks.Text.Trim
        Me.Close()
    End Sub

    Private Sub prvChooseCOA()
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = clsCS.CompanyID
            .pubProgramID = clsCS.ProgramID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.CashOrBank
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAID = .pubLUdtRow.Item("ID")
                txtCoACode.Text = .pubLUdtRow.Item("Code")
                txtCoAName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraAccountSetPaymentDate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraAccountSetPaymentDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        dtpPaymentDate.Value = Now

        txtCoACode.Text = strCoACode.Trim
        txtCoAName.Text = strCoAName.Trim
        btnCoAOfOutgoingPayment.Enabled = bolChooseCoA
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnCoAOfOutgoingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfOutgoingPayment.Click
        prvChooseCOA()
    End Sub

#End Region

End Class