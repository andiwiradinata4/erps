Public Class frmTraAccountSetPaymentDate

#Region "Property"

    Private bolSave As Boolean = False
    Private dtmPaymentDate As DateTime
    Private strRemarks As String = ""
    Private intCoAID As Integer

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

    Public Property pubCoAID As Integer
        Set(value As Integer)
            intCoAID = value
        End Set
        Get
            Return intCoAID
        End Get
    End Property

#End Region

    Private Sub prvSave()
        If intCoAID <= 0 Then
            txtCoACode.Focus()
            UI.usForm.frmMessageBox("Pilih Akun terlebih dahulu")
            Exit Sub
        End If

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
            .pubCompanyID = ERPSLib.UI.usUserApp.CompanyID
            .pubProgramID = ERPSLib.UI.usUserApp.CompanyID
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

    Private Sub prvFillCoA()
        Try
            Dim clsCoA As VO.ChartOfAccount = BL.ChartOfAccount.GetDetail(intCoAID)
            txtCoACode.Text = clsCoA.Code
            txtCoAName.Text = clsCoA.Name
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
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
        prvFillCoA()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnCoA_Click(sender As Object, e As EventArgs) Handles btnCoA.Click
        prvChooseCOA()
    End Sub

#End Region

End Class