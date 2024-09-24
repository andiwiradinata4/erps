Public Class frmTraARAPChooseBankAccount

#Region "Property"

    Private frmParent As frmTraARAP
    Private clsDataAll As List(Of VO.CompanyBankAccount)
    Private clsSC As New VO.SalesContract
    Property pubCompanyID As Integer = 0
    Property pubIsNew As Boolean = False
    Property pubIsSave As Boolean = False
    Property pubCompanyBankAccount1 As Integer
    Property pubCompanyBankAccount2 As Integer
    Property pubID As String


    Enum ChooseBankAccount
        BankAccount1
        BankAccount2
    End Enum

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillForm()
        Try
            If pubCompanyBankAccount1 = 0 Then
                Dim clsPrevious As VO.AccountReceivable = BL.AccountReceivable.GetLastBankAccount(pubID)
                pubCompanyBankAccount1 = clsPrevious.CompanyBankAccountID1
                pubCompanyBankAccount2 = clsPrevious.CompanyBankAccountID2
            End If

            Dim clsData As New VO.CompanyBankAccount
            clsData = BL.CompanyBankAccount.GetDetail(pubCompanyBankAccount1)
            txtAccountName1.Text = clsData.AccountName
            txtBankName1.Text = clsData.BankName
            txtAccountNumber1.Text = clsData.AccountNumber
            txtCurrency1.Text = clsData.Currency

            clsData = BL.CompanyBankAccount.GetDetail(pubCompanyBankAccount2)
            txtAccountName2.Text = clsData.AccountName
            txtBankName2.Text = clsData.BankName
            txtAccountNumber2.Text = clsData.AccountNumber
            txtCurrency2.Text = clsData.Currency

            Dim clsDetail As VO.AccountReceivable = BL.AccountReceivable.GetDetail(pubID)
            txtPaymentTerm1.Text = IIf(clsDetail.PaymentTerm1.Trim = "", "Pembayaran dapat dilakukan dengan SKBDN", clsDetail.PaymentTerm1.Trim)
            txtPaymentTerm2.Text = IIf(clsDetail.PaymentTerm2.Trim = "", "Pembayaran Cash DP 10% maksimal 7 Hari dari tanggal PI", clsDetail.PaymentTerm2.Trim)
            txtPaymentTerm3.Text = IIf(clsDetail.PaymentTerm3.Trim = "", "Pembayaran Cash DP 90% paling lambat 7 Hari dari tanggal PI", clsDetail.PaymentTerm3.Trim)
            txtPaymentTerm4.Text = IIf(clsDetail.PaymentTerm4.Trim = "", "Pembayaran Cash lebih dari 7 Hari akan dikenakan sanksi pembelian berikutnya dengan DP 20%", clsDetail.PaymentTerm4.Trim)
            txtPaymentTerm5.Text = IIf(clsDetail.PaymentTerm5.Trim = "", "Toleransi Produksi Lebih Kurang 10%", clsDetail.PaymentTerm5.Trim)
            txtPaymentTerm6.Text = clsDetail.PaymentTerm6
            txtPaymentTerm7.Text = clsDetail.PaymentTerm7
            txtPaymentTerm8.Text = clsDetail.PaymentTerm8
            txtPaymentTerm9.Text = clsDetail.PaymentTerm9
            txtPaymentTerm10.Text = clsDetail.PaymentTerm10

            clsSC = BL.SalesContract.GetDetail(clsDetail.ReferencesID)
            txtPurchaseNumber.Text = clsSC.ReferencesNumber
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvSave()
        Try
            BL.AccountReceivable.UpdateCompanyBankAccount(pubID, pubCompanyBankAccount1, pubCompanyBankAccount2,
                                                          txtPaymentTerm1.Text.Trim, txtPaymentTerm2.Text.Trim,
                                                          txtPaymentTerm3.Text.Trim, txtPaymentTerm4.Text.Trim,
                                                          txtPaymentTerm5.Text.Trim, txtPaymentTerm6.Text.Trim,
                                                          txtPaymentTerm7.Text.Trim, txtPaymentTerm8.Text.Trim,
                                                          txtPaymentTerm9.Text.Trim, txtPaymentTerm10.Text.Trim,
                                                          clsSC.ID, txtPurchaseNumber.Text.Trim)
            pubIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvChooseBankAccount(ByVal enumChoose As ChooseBankAccount)
        Dim frmDetail As New frmMstCompanyBankAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = pubCompanyID
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsLookUpGet Then
                If enumChoose = ChooseBankAccount.BankAccount1 Then
                    pubCompanyBankAccount1 = .pubLUdtRow.Item("ID")
                    txtAccountName1.Text = .pubLUdtRow.Item("AccountName")
                    txtBankName1.Text = .pubLUdtRow.Item("BankName")
                    txtAccountNumber1.Text = .pubLUdtRow.Item("AccountNumber")
                    txtCurrency1.Text = .pubLUdtRow.Item("Currency")
                ElseIf enumChoose = ChooseBankAccount.BankAccount2 Then
                    pubCompanyBankAccount2 = .pubLUdtRow.Item("ID")
                    txtAccountName2.Text = .pubLUdtRow.Item("AccountName")
                    txtBankName2.Text = .pubLUdtRow.Item("BankName")
                    txtAccountNumber2.Text = .pubLUdtRow.Item("AccountNumber")
                    txtCurrency2.Text = .pubLUdtRow.Item("Currency")
                End If
            End If
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPChooseBankAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form ini?") Then Me.Close()
        End If
    End Sub

    Private Sub txtBankAccount2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountName2.KeyDown, txtAccountNumber2.KeyDown, txtBankName2.KeyDown, txtCurrency2.KeyDown
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            pubCompanyBankAccount2 = 0
            txtAccountName2.Text = ""
            txtAccountNumber2.Text = ""
            txtBankName2.Text = ""
            txtCurrency2.Text = ""
        End If
    End Sub

    Private Sub frmTraARAPChooseBankAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        txtPaymentTerm1.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm2.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm3.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm4.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm5.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm6.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm7.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm8.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm9.CharacterCasing = CharacterCasing.Normal
        txtPaymentTerm10.CharacterCasing = CharacterCasing.Normal
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub btnBankAccount1_Click(sender As Object, e As EventArgs) Handles btnBankAccount1.Click
        prvChooseBankAccount(ChooseBankAccount.BankAccount1)
    End Sub

    Private Sub btnBankAccount2_Click(sender As Object, e As EventArgs) Handles btnBankAccount2.Click
        prvChooseBankAccount(ChooseBankAccount.BankAccount2)
    End Sub

#End Region

End Class