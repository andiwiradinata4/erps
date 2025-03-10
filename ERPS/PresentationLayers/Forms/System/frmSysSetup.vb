Public Class frmSysSetup

    Private Sub btnCalculateSCWeightSubItemInPurchaseContract_Click(sender As Object, e As EventArgs) Handles btnCalculateSCWeightSubItemInPurchaseContract.Click
        Try
            BL.Setup.CalculateTotalSCWeightSubItemInPurchaseContract()
            UI.usForm.frmMessageBox(btnCalculateSCWeightSubItemInPurchaseContract.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCalculateSCWeightInPurchaseContract_Click(sender As Object, e As EventArgs) Handles btnCalculateSCWeightInPurchaseContract.Click
        Try
            BL.Setup.CalculateTotalSCWeightInPurchaseContract()
            UI.usForm.frmMessageBox(btnCalculateSCWeightInPurchaseContract.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCalculateTotalReceivePaymentInSalesContract_Click(sender As Object, e As EventArgs) Handles btnCalculateTotalReceivePaymentInSalesContract.Click
        Try
            BL.Setup.CalculateTotalTotalPaymentSalesContract()
            UI.usForm.frmMessageBox(btnCalculateTotalReceivePaymentInSalesContract.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCalculateTotalPriceSalesContractSubItem_Click(sender As Object, e As EventArgs) Handles btnCalculateTotalPriceSalesContractSubItem.Click
        Try
            BL.Setup.CalculateTotalPriceSalesContractSubItem()
            UI.usForm.frmMessageBox(btnCalculateTotalPriceSalesContractSubItem.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCalculateTotalPricePurchaseContractSubItem_Click(sender As Object, e As EventArgs) Handles btnCalculateTotalPricePurchaseContractSubItem.Click
        Try
            BL.Setup.CalculateTotalPricePurchaseContractSubItem()
            UI.usForm.frmMessageBox(btnCalculateTotalPricePurchaseContractSubItem.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCalculateSCWeightInSalesContract_Click(sender As Object, e As EventArgs) Handles btnCalculateSCWeightInSalesContract.Click
        Try
            BL.Setup.CalculateSCWeightInSalesContract()
            UI.usForm.frmMessageBox(btnCalculateSCWeightInSalesContract.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCalculateDPAmountInDPSalesContract_Click(sender As Object, e As EventArgs) Handles btnCalculateDPAmountInDPSalesContract.Click
        Try
            BL.Setup.CalculateDPAmountOrderRequestInDPSalesContract()
            UI.usForm.frmMessageBox(btnCalculateDPAmountInDPSalesContract.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGenerateVoucher_Click(sender As Object, e As EventArgs) Handles btnGenerateVoucher.Click
        Try
            BL.Setup.GenerateVoucher()
            UI.usForm.frmMessageBox(btnGenerateVoucher.Text.Trim & " berhasil")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

End Class