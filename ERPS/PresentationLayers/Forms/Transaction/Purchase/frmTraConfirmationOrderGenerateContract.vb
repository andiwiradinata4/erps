Public Class frmTraConfirmationOrderGenerateContract

#Region "Property"

    Private frmParent As frmTraConfirmationOrderDet
    Private clsData As VO.PurchaseContract
    Private clsCO As New VO.ConfirmationOrder
    Private strCOID As String = ""
    Private bolIsSave As Boolean

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

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

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
        If Not UI.usForm.frmAskQuestion("Generate Data Kontrak Pembelian?") Then Exit Sub
        prvResetProgressBar()

        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            'Dim clsData As VO.ConfirmationOrder = BL.ConfirmationOrder.GetDetail(strCOID)
            'Dim dtDetail As DataTable = BL.ConfirmationOrder.ListDataDetail(strCOID)
            'Dim dtPaymentTerm As DataTable = BL.ConfirmationOrder.ListDataPaymentTerm(strCOID)
            'Dim bolNew As Boolean = IIf(clsData.PCID.Trim = "", True, False)
            'Dim strPCID As String = clsData.PCID

            'If bolNew Then strPCID = BL.PurchaseContract.GetNewID(clsData.CODate, clsData.CompanyID, clsData.ProgramID)

            'Dim listDetailOrder As New List(Of VO.PurchaseContractDet)
            'For Each dr As DataRow In dtDetail.Rows
            '    listDetailOrder.Add(New ERPSLib.VO.PurchaseContractDet With
            '    {
            '        .CODetailID = dr.Item("ID"),
            '        .ItemID = dr.Item("ItemID"),
            '        .Quantity = dr.Item("Quantity"),
            '        .Weight = dr.Item("Weight"),
            '        .TotalWeight = dr.Item("TotalWeight"),
            '        .UnitPrice = dr.Item("UnitPrice"),
            '        .TotalPrice = dr.Item("TotalPrice"),
            '        .Remarks = dr.Item("Remarks")
            '    })
            'Next

            'Dim listPaymentTerm As New List(Of VO.PurchaseContractPaymentTerm)
            'For Each dr As DataRow In dtPaymentTerm.Rows
            '    listPaymentTerm.Add(New VO.PurchaseContractPaymentTerm With
            '    {
            '        .Percentage = dr.Item("Percentage"),
            '        .PaymentTypeID = dr.Item("PaymentTypeID"),
            '        .PaymentModeID = dr.Item("PaymentModeID"),
            '        .CreditTerm = dr.Item("CreditTerm"),
            '        .Remarks = dr.Item("Remarks")
            '    })
            'Next

            'Dim clsContract As New VO.PurchaseContract
            'clsContract = New VO.PurchaseContract With {
            '    .ID = "",
            '    .ProgramID = clsCO.ProgramID,
            '    .CompanyID = clsCO.CompanyID,
            '    .PCNumber = txtPCNumber.Text.Trim,
            '    .PCDate = clsCO.CODate,
            '    .BPID = clsCO.BPID,
            '    .DeliveryPeriodFrom = clsCO.DeliveryPeriodFrom,
            '    .DeliveryPeriodTo = clsCO.DeliveryPeriodTo,
            '    .Franco = txtFranco.Text.Trim,
            '    .AllowanceProduction = clsCO.AllowanceProduction,
            '    .PPN = clsCO.PPN,
            '    .PPH = clsCO.PPH,
            '    .TotalQuantity = clsCO.TotalQuantity,
            '    .TotalWeight = clsCO.TotalWeight,
            '    .TotalDPP = clsCO.TotalDPP,
            '    .TotalPPN = clsCO.TotalPPN,
            '    .TotalPPH = clsCO.TotalPPH,
            '    .RoundingManual = clsCO.RoundingManual,
            '    .Remarks = clsCO.Remarks,
            '    .StatusID = clsCO.StatusID,
            '    .Detail = listDetailOrder,
            '    .PaymentTerm = listPaymentTerm,
            '    .LogBy = ERPSLib.UI.usUserApp.UserID,
            '    .Save = VO.Save.Action.SaveAsDraft
            '}

            'BL.PurchaseContract.SaveData(bolNew, clsContract)
            BL.ConfirmationOrder.GeneratePurchaseContract(strCOID, txtPCNumber.Text.Trim, txtFranco.Text.Trim)
            UI.usForm.frmMessageBox("Data berhasil di Generate")
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            prvResetProgressBar()
            Me.Cursor = Cursors.Default
        End Try
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

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region
End Class