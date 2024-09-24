Public Class frmTraUpdatePaymentType

    Property pubID As String = ""

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboPaymentType, BL.PaymentType.ListDataForCombo("13,14"), "ID", "Name")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        prvFillCombo()
        Try
            Dim clsData As VO.ConfirmationOrder = BL.ConfirmationOrder.GetDetail(pubID)
            cboPaymentType.SelectedValue = clsData.PaymentTypeID
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()

    End Sub

#Region "Form Handle"

    Private Sub frmTraUpdatePaymentType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prvFillCombo()
    End Sub

#End Region

End Class