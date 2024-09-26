Public Class frmTraUpdatePaymentType

    Private strID As String
    Private bolIsSave

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

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
            Dim clsData As VO.ConfirmationOrder = BL.ConfirmationOrder.GetDetail(strID)
            cboPaymentType.SelectedValue = clsData.PaymentTypeID
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If cboPaymentType.SelectedIndex = -1 Then
            UI.usForm.frmMessageBox("Pilih jenis pembayaran terlebih dahulu")
            cboPaymentType.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan Data?") Then Exit Sub

        Try
            BL.ConfirmationOrder.UpdatePaymentType(strID, cboPaymentType.SelectedValue)
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

#Region "Form Handle"

    Private Sub frmTraUpdatePaymentType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar.SetIcon(Me)
        prvFillCombo()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class