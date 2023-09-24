Public Class usFormPaymentTerm

#Region "Properties"

    Private intPaymentTypeID As Integer
    Private intPaymentModeID As Integer
    Private dtParent As New DataTable
    Private bolIsNew As Boolean = False
    Private bolIsSave As Boolean = False
    Private strID As String = ""

    Public WriteOnly Property pubDataParent As DataTable
        Set(value As DataTable)
            dtParent = value
        End Set
    End Property

    
    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

#End Region

    Private Sub prvFillFom()
        If bolIsNew Then
            prvClear()
        Else
            For Each dr As DataRow In dtParent.Rows
                If dr.Item("ID") = strID Then
                    txtPercentage.Value = dr.Item("Percentage")
                    intPaymentTypeID = dr.Item("PaymentTypeID")
                    txtPaymentTypeCode.Text = dr.Item("PaymentTypeCode")
                    txtPaymentTypeName.Text = dr.Item("PaymentTypeName")
                    intPaymentModeID = dr.Item("PaymentModeID")
                    txtPaymentModeCode.Text = dr.Item("PaymentModeCode")
                    txtPaymentModeName.Text = dr.Item("PaymentModeName")
                    txtCreditTerm.Value = dr.Item("CreditTerm")
                    txtRemarks.Text = dr.Item("Remarks")
                    Exit For
                End If
            Next
            txtPercentage.Focus()
        End If
    End Sub

    Private Sub prvSave()
        If txtPercentage.Value <= 0 Then
            UI.usForm.frmMessageBox("Persentase harus lebih besar dari 0")
            txtPercentage.Focus()
            Exit Sub
        ElseIf txtPercentage.Value > 100 Then
            UI.usForm.frmMessageBox("Persentase tidak boleh lebih besar dari 100")
            txtPercentage.Focus()
            Exit Sub
        ElseIf txtPaymentTypeCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih jenis pembayaran terlebih dahulu")
            txtPaymentTypeCode.Focus()
            Exit Sub
        ElseIf txtPaymentModeCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih metode pembayaran terlebih dahulu")
            btnPaymentMode.Focus()
            Exit Sub
        ElseIf txtCreditTerm.Value <= 0 Then
            UI.usForm.frmMessageBox("Jangka waktu kredit harus lebih besar dari 0")
            txtCreditTerm.Focus()
            Exit Sub
        End If

        Dim decTotalPercentage As Decimal = 0
        For Each dr As DataRow In dtParent.Rows
            If Not bolIsNew And dr.Item("ID") = strID Then Continue For
            decTotalPercentage += dr.Item("Percentage")
        Next

        If decTotalPercentage + txtPercentage.Value > 100 Then
            UI.usForm.frmMessageBox("Total Persentase Syarat Pembayaran tidak boleh melebihi 100%")
            txtPercentage.Focus()
            Exit Sub
        End If

        Dim drItem As DataRow
        If bolIsNew Then
            drItem = dtParent.NewRow
        Else
            drItem = dtParent.Rows(0)
            For Each drParent As DataRow In dtParent.Rows
                If drParent.Item("ID") = strID Then drItem = drParent : Exit For
            Next
        End If
        With drItem
            .BeginEdit()
            .Item("ID") = IIf(bolIsNew, Guid.NewGuid.ToString, strID)
            .Item("Percentage") = txtPercentage.Value
            .Item("PaymentTypeID") = intPaymentTypeID
            .Item("PaymentTypeCode") = txtPaymentTypeCode.Text.Trim
            .Item("PaymentTypeName") = txtPaymentTypeName.Text.Trim
            .Item("PaymentModeID") = intPaymentModeID
            .Item("PaymentModeCode") = txtPaymentModeCode.Text.Trim
            .Item("PaymentModeName") = txtPaymentModeName.Text.Trim
            .Item("CreditTerm") = txtCreditTerm.Value
            .Item("Remarks") = txtRemarks.Text.Trim
            .EndEdit()
        End With
        If bolIsNew Then dtParent.Rows.Add(drItem)
        dtParent.AcceptChanges()
        prvClear()
        If Not bolIsNew Then Me.Close()
    End Sub

    Private Sub prvClear()
        txtPercentage.Minimum = 0
        txtPercentage.Maximum = 100
        txtCreditTerm.Minimum = 0

        txtPercentage.Value = 0
        intPaymentTypeID = 0
        txtPaymentTypeCode.Text = ""
        txtPaymentTypeName.Text = ""
        intPaymentModeID = 0
        txtPaymentModeCode.Text = ""
        txtPaymentModeName.Text = ""
        txtCreditTerm.Value = 0
        txtRemarks.Text = ""
        txtPercentage.Focus()
    End Sub

    Private Sub prvChoosePaymentType()
        Dim frmDetail As New frmMstPaymentType
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsLookUpGet Then
                intPaymentTypeID = .pubLUdtRow.Item("ID")
                txtPaymentTypeCode.Text = .pubLUdtRow.Item("Code")
                txtPaymentTypeName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvChoosePaymentMode()
        Dim frmDetail As New frmMstPaymentMode
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsLookUpGet Then
                intPaymentModeID = .pubLUdtRow.Item("ID")
                txtPaymentModeCode.Text = .pubLUdtRow.Item("Code")
                txtPaymentModeName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

#Region "Form Handle"

    Private Sub usFormPaymentTerm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar.SetIcon(Me)
        prvFillFom()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnPaymentType_Click(sender As Object, e As EventArgs) Handles btnPaymentType.Click
        prvChoosePaymentType()
    End Sub

    Private Sub txtPaymentMode_Click(sender As Object, e As EventArgs) Handles btnPaymentMode.Click
        prvChoosePaymentMode()
    End Sub

#End Region

End Class