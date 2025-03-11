Public Class frmTraConfirmationOrderGenerateContract

#Region "Property"

    Private clsData As VO.PurchaseContract
    Private clsCO As New VO.ConfirmationOrder
    Private strCOID As String = ""
    Private bolIsSave As Boolean
    Private bolIsUpdate As Boolean

    Public WriteOnly Property pubCOID As String
        Set(value As String)
            strCOID = value
        End Set
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
    End Property

    Public WriteOnly Property pubIsUpdate As Boolean
        Set(value As Boolean)
            bolIsUpdate = value
        End Set
    End Property

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvFillForm()
        Try
            pgMain.Value = 30
            Me.Cursor = Cursors.WaitCursor
            clsCO = BL.ConfirmationOrder.GetDetail(strCOID)
            txtPCNumber.Text = clsCO.PCNumber
            txtFranco.Text = clsCO.Franco
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvResetProgressBar()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If Not bolIsSave Then If Not UI.usForm.frmAskQuestion("Generate Data Kontrak Pembelian?") Then Exit Sub
        If bolIsSave Then If Not UI.usForm.frmAskQuestion("Ubah Nomor Kontrak Pembelian?") Then Exit Sub
        prvResetProgressBar()

        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            If bolIsUpdate Then
                BL.ConfirmationOrder.UpdatePCNumber(strCOID, txtPCNumber.Text.Trim, txtFranco.Text.Trim)
                UI.usForm.frmMessageBox("Data berhasil di Update")
            Else
                BL.ConfirmationOrder.GeneratePurchaseContract(strCOID, txtPCNumber.Text.Trim, txtFranco.Text.Trim)
                UI.usForm.frmMessageBox("Data berhasil di Generate")
            End If
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvResetProgressBar()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvChooseFranco()
        Dim frmDetail As New frmTraPurchaseContractFranco
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsLookUpGet Then txtFranco.Text = .pubLUdtRow.Item("Franco")
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraConfirmationOrderGenerateContract_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraConfirmationOrderGenerateContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
    End Sub

    Private Sub btnFranco_Click(sender As Object, e As EventArgs) Handles btnFranco.Click
        prvChooseFranco()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region
End Class