Public Class frmSysJournalPost

#Region "Property"

    Private _
        intCoAIDofRevenue As Integer = 0, intCoAIDofAccountReceivable As Integer = 0, intCoAIDofSalesDiscount As Integer = 0, intCoAIDofPrepaidIncome As Integer = 0,
        intCoAIDofCOGS As Integer = 0, intCoAIDofStock As Integer = 0, intCoAIDofCashOrBank As Integer = 0, intCoAIDofAccountPayable As Integer = 0,
        intCoAIDofPurchaseDiscount As Integer = 0, intCoAIDofPurchaseEquipments As Integer = 0, intCoAIDofAdvancePayment As Integer = 0,
        intCoAIDofSalesTax As Integer = 0, intCoAIDofPurchaseTax As Integer = 0, intCoAIDofVentureCapital As Integer = 0, intCoAIDOfPPHSales As Integer = 0,
        intCoAIDOfPPHPurchase As Integer = 0, intCoAIDofPrepaidIncomeCutting As Integer = 0, intCoAIDofPrepaidIncomeTransport As Integer = 0,
        intCoAIDofStockCutting As Integer = 0, intCoAIDofStockCutting2 As Integer = 0, intCoAIDofStockCutting3 As Integer = 0, intCoAIDofStockTransport As Integer = 0,
        intCoAIDofAccountPayableCutting As Integer = 0, intCoAIDofAccountPayableCutting2 As Integer = 0, intCoAIDofAccountPayableCutting3 As Integer = 0,
        intCoAIDofAccountPayableTransport As Integer = 0, intCoAIDofAccountReceivableOutstandingPayment As Integer = 0, intCoAIDofAccountPayableOutstandingPayment As Integer = 0,
        intCoAIDofAccountPayableCuttingOutstandingPayment As Integer = 0, intCoAIDofAccountPayableTransportOutstandingPayment As Integer = 0,
        intCoAIDofCutting As Integer = 0, intCoAIDofTransport As Integer = 0, intCoAIDofCostRawMaterial As Integer = 0, intCoAIDofSalesReturn As Integer = 0,
        intCoAIDofCompensasionRevenue As Integer = 0, intCoAIDofClaimCost As Integer = 0, intCoAofRounding As Integer = 0

    Private clsData As New VO.JournalPost
    Private Const _
       cSave = 0, cClose = 1

#End Region

    Private Sub prvFillForm()
        Try
            clsData = BL.JournalPost.GetDetail(ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID)
            intCoAIDofRevenue = clsData.CoAofRevenue
            txtCoACodeOfRevenue.Text = clsData.CoACodeofRevenue
            txtCoANameOfRevenue.Text = clsData.CoANameofRevenue

            intCoAIDofAccountReceivable = clsData.CoAofAccountReceivable
            txtCoACodeOfAccountReceivable.Text = clsData.CoACodeofAccountReceivable
            txtCoANameOfAccountReceivable.Text = clsData.CoANameofAccountReceivable

            intCoAIDofSalesDiscount = clsData.CoAofSalesDisc
            txtCoACodeOfSalesDiscount.Text = clsData.CoACodeofSalesDisc
            txtCoANameOfSalesDiscount.Text = clsData.CoANameofSalesDisc

            intCoAIDofPrepaidIncome = clsData.CoAofPrepaidIncome
            txtCoACodeOfPrepaidIncome.Text = clsData.CoACodeofPrepaidIncome
            txtCoANameOfPrepaidIncome.Text = clsData.CoANameofPrepaidIncome

            intCoAIDofCOGS = clsData.CoAofCOGS
            txtCoACodeOfCOGS.Text = clsData.CoACodeofCOGS
            txtCoANameOfCOGS.Text = clsData.CoANameofCOGS

            intCoAIDofStock = clsData.CoAofStock
            txtCoACodeOfStock.Text = clsData.CoACodeofStock
            txtCoANameOfStock.Text = clsData.CoANameofStock

            intCoAIDofCashOrBank = clsData.CoAofCash
            txtCoACodeOfCashOrBank.Text = clsData.CoACodeofCash
            txtCoANameOfCashOrBank.Text = clsData.CoANameofCash

            intCoAIDofAccountPayable = clsData.CoAofAccountPayable
            txtCoACodeOfAccountPayable.Text = clsData.CoACodeofAccountPayable
            txtCoANameOfAccountPayable.Text = clsData.CoANameofAccountPayable

            intCoAIDofPurchaseDiscount = clsData.CoAofPurchaseDisc
            txtCoACodeOfPurchaseDiscount.Text = clsData.CoACodeofPurchaseDisc
            txtCoANameOfPurchaseDiscount.Text = clsData.CoANameofPurchaseDisc

            intCoAIDofPurchaseEquipments = clsData.CoAofPurchaseEquipments
            txtCoACodeOfEquipments.Text = clsData.CoACodeofPurchaseEquipments
            txtCoANameOfEquipments.Text = clsData.CoANameofPurchaseEquipments

            intCoAIDofAdvancePayment = clsData.CoAofAdvancePayment
            txtCoACodeOfAdvancePayment.Text = clsData.CoACodeofAdvancePayment
            txtCoANameOfAdvancePayment.Text = clsData.CoANameofAdvancePayment

            intCoAIDofSalesTax = clsData.CoAofSalesTax
            txtCoACodeOfSalesTax.Text = clsData.CoACodeofSalesTax
            txtCoANameOfSalesTax.Text = clsData.CoANameofSalesTax

            intCoAIDofPurchaseTax = clsData.CoAofPurchaseTax
            txtCoACodeOfPurchaseTax.Text = clsData.CoACodeofPurchaseTax
            txtCoANameOfPurchaseTax.Text = clsData.CoANameofPurchaseTax

            intCoAIDofVentureCapital = clsData.CoAofVentureCapital
            txtCoACodeofVentureCapital.Text = clsData.CoACodeofVentureCapital
            txtCoANameofVentureCapital.Text = clsData.CoANameofVentureCapital

            intCoAIDOfPPHSales = clsData.CoAofPPHSales
            txtCoACodeofPPHSales.Text = clsData.CoACodeofPPHSales
            txtCoANameofPPHSales.Text = clsData.CoANameofPPHSales

            intCoAIDOfPPHPurchase = clsData.CoAofPPHPurchase
            txtCoACodeofPPHPurchase.Text = clsData.CoACodeofPPHPurchase
            txtCoANameofPPHPurchase.Text = clsData.CoANameofPPHPurchase

            intCoAIDofPrepaidIncomeCutting = clsData.CoAofPrepaidIncomeCutting
            txtCoACodeofPrepaidIncomeCutting.Text = clsData.CoACodeofPrepaidIncomeCutting
            txtCoANameofPrepaidIncomeCutting.Text = clsData.CoANameofPrepaidIncomeCutting

            intCoAIDofPrepaidIncomeTransport = clsData.CoAofPrepaidIncomeTransport
            txtCoACodeofPrepaidIncomeTransport.Text = clsData.CoACodeofPrepaidIncomeTransport
            txtCoANameofPrepaidIncomeTransport.Text = clsData.CoANameofPrepaidIncomeTransport

            intCoAIDofStockCutting = clsData.CoAofStockCutting
            txtCoACodeofStockCutting.Text = clsData.CoACodeofStockCutting
            txtCoANameofStockCutting.Text = clsData.CoANameofStockCutting

            intCoAIDofStockCutting2 = clsData.CoAofStockCutting2
            txtCoACodeofStockCutting2.Text = clsData.CoACodeofStockCutting2
            txtCoANameofStockCutting2.Text = clsData.CoANameofStockCutting2

            intCoAIDofStockCutting3 = clsData.CoAofStockCutting3
            txtCoACodeofStockCutting3.Text = clsData.CoACodeofStockCutting3
            txtCoANameofStockCutting3.Text = clsData.CoANameofStockCutting3

            intCoAIDofStockTransport = clsData.CoAofStockTransport
            txtCoACodeofStockTransport.Text = clsData.CoACodeofStockTransport
            txtCoANameofStockTransport.Text = clsData.CoANameofStockTransport

            intCoAIDofAccountPayableCutting = clsData.CoAofAccountPayableCutting
            txtCoACodeofAccountPayableCutting.Text = clsData.CoACodeofAccountPayableCutting
            txtCoANameofAccountPayableCutting.Text = clsData.CoANameofAccountPayableCutting

            intCoAIDofAccountPayableCutting2 = clsData.CoAofAccountPayableCutting2
            txtCoACodeofAccountPayableCutting2.Text = clsData.CoACodeofAccountPayableCutting2
            txtCoANameofAccountPayableCutting2.Text = clsData.CoANameofAccountPayableCutting2

            intCoAIDofAccountPayableCutting3 = clsData.CoAofAccountPayableCutting3
            txtCoACodeofAccountPayableCutting3.Text = clsData.CoACodeofAccountPayableCutting3
            txtCoANameofAccountPayableCutting3.Text = clsData.CoANameofAccountPayableCutting3

            intCoAIDofAccountPayableTransport = clsData.CoAofAccountPayableTransport
            txtCoACodeofAccountPayableTransport.Text = clsData.CoACodeofAccountPayableTransport
            txtCoANameofAccountPayableTransport.Text = clsData.CoANameofAccountPayableTransport

            intCoAIDofAccountReceivableOutstandingPayment = clsData.CoAofAccountReceivableOutstandingPayment
            txtCoACodeOfAccountReceivableOutstandingPayment.Text = clsData.CoACodeofAccountReceivableOutstandingPayment
            txtCoANameOfAccountReceivableOutstandingPayment.Text = clsData.CoANameofAccountReceivableOutstandingPayment

            intCoAIDofAccountPayableOutstandingPayment = clsData.CoAofAccountPayableOutstandingPayment
            txtCoACodeOfAccountPayableOutstandingPayment.Text = clsData.CoACodeofAccountPayableOutstandingPayment
            txtCoANameOfAccountPayableOutstandingPayment.Text = clsData.CoANameofAccountPayableOutstandingPayment

            intCoAIDofAccountPayableCuttingOutstandingPayment = clsData.CoAofAccountPayableCuttingOutstandingPayment
            txtCoACodeofAccountPayableCuttingOutstandingPayment.Text = clsData.CoACodeofAccountPayableCuttingOutstandingPayment
            txtCoANameofAccountPayableCuttingOutstandingPayment.Text = clsData.CoANameofAccountPayableCuttingOutstandingPayment

            intCoAIDofAccountPayableTransportOutstandingPayment = clsData.CoAofAccountPayableTransportOutstandingPayment
            txtCoACodeofAccountPayableTransportOutstandingPayment.Text = clsData.CoACodeofAccountPayableTransportOutstandingPayment
            txtCoANameofAccountPayableTransportOutstandingPayment.Text = clsData.CoANameofAccountPayableTransportOutstandingPayment

            intCoAIDofCutting = clsData.CoAOfCutting
            txtCoACodeofCutting.Text = clsData.CoACodeofCutting
            txtCoANameofCutting.Text = clsData.CoANameofCutting

            intCoAIDofTransport = clsData.CoAOfTransport
            txtCoACodeofTransport.Text = clsData.CoACodeofTransport
            txtCoANameofTransport.Text = clsData.CoANameofTransport

            intCoAIDofCostRawMaterial = clsData.CoAOfCostRawMaterial
            txtCoACodeofCostRawMaterial.Text = clsData.CoACodeofCostRawMaterial
            txtCoANameofCostRawMaterial.Text = clsData.CoANameofCostRawMaterial

            intCoAIDofSalesReturn = clsData.CoAofSalesReturn
            txtCoACodeofSalesReturn.Text = clsData.CoACodeofSalesReturn
            txtCoANameofSalesReturn.Text = clsData.CoANameofSalesReturn

            intCoAIDofCompensasionRevenue = clsData.CoAofCompensasionRevenue
            txtCoACodeofCompensasionRevenue.Text = clsData.CoACodeofCompensasionRevenue
            txtCoANameofCompensasionRevenue.Text = clsData.CoANameofCompensasionRevenue

            intCoAIDofClaimCost = clsData.CoAofClaimCost
            txtCoACodeofClaimCost.Text = clsData.CoACodeofClaimCost
            txtCoANameofClaimCost.Text = clsData.CoANameofClaimCost

            intCoAIDofClaimCost = clsData.CoAofClaimCost
            txtCoACodeofClaimCost.Text = clsData.CoACodeofClaimCost
            txtCoANameofClaimCost.Text = clsData.CoANameofClaimCost

            intCoAofRounding = clsData.CoAofRounding
            txtCoACodeofRounding.Text = clsData.CoACodeofRounding
            txtCoANameofRounding.Text = clsData.CoANameofRounding

            ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
            ToolStripLogBy.Text = "Dibuat Oleh : " & IIf(clsData.LogBy Is Nothing, ERPSLib.UI.usUserApp.UserID, clsData.LogBy)
            ToolStripLogDate.Text = Format(IIf(clsData.LogBy Is Nothing, Now(), clsData.LogDate), UI.usDefCons.DateFull)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvSave()
        pgMain.Value = 30
        clsData = New VO.JournalPost
        clsData.ProgramID = ERPSLib.UI.usUserApp.ProgramID
        clsData.CoAofRevenue = intCoAIDofRevenue
        clsData.CoAofAccountReceivable = intCoAIDofAccountReceivable
        clsData.CoAofSalesDisc = intCoAIDofSalesDiscount
        clsData.CoAofPrepaidIncome = intCoAIDofPrepaidIncome
        clsData.CoAofCOGS = intCoAIDofCOGS
        clsData.CoAofStock = intCoAIDofStock
        clsData.CoAofCash = intCoAIDofCashOrBank
        clsData.CoAofAccountPayable = intCoAIDofAccountPayable
        clsData.CoAofPurchaseDisc = intCoAIDofPurchaseDiscount
        clsData.CoAofPurchaseEquipments = intCoAIDofPurchaseEquipments
        clsData.CoAofAdvancePayment = intCoAIDofAdvancePayment
        clsData.CoAofSalesTax = intCoAIDofSalesTax
        clsData.CoAofPurchaseTax = intCoAIDofPurchaseTax
        clsData.CoAofVentureCapital = intCoAIDofVentureCapital
        clsData.CoAofPPHSales = intCoAIDOfPPHSales
        clsData.CoAofPPHPurchase = intCoAIDOfPPHPurchase
        clsData.CoAofPrepaidIncomeCutting = intCoAIDofPrepaidIncomeCutting
        clsData.CoAofPrepaidIncomeTransport = intCoAIDofPrepaidIncomeTransport
        clsData.CoAofStockCutting = intCoAIDofStockCutting
        clsData.CoAofStockCutting2 = intCoAIDofStockCutting2
        clsData.CoAofStockCutting3 = intCoAIDofStockCutting3
        clsData.CoAofStockTransport = intCoAIDofStockTransport
        clsData.CoAofAccountPayableCutting = intCoAIDofAccountPayableCutting
        clsData.CoAofAccountPayableCutting2 = intCoAIDofAccountPayableCutting2
        clsData.CoAofAccountPayableCutting3 = intCoAIDofAccountPayableCutting3
        clsData.CoAofAccountPayableTransport = intCoAIDofAccountPayableTransport
        clsData.CoAofAccountReceivableOutstandingPayment = intCoAIDofAccountReceivableOutstandingPayment
        clsData.CoAofAccountPayableOutstandingPayment = intCoAIDofAccountPayableOutstandingPayment
        clsData.CoAofAccountPayableCuttingOutstandingPayment = intCoAIDofAccountPayableCuttingOutstandingPayment
        clsData.CoAofAccountPayableTransportOutstandingPayment = intCoAIDofAccountPayableTransportOutstandingPayment
        clsData.CoAOfCutting = intCoAIDofCutting
        clsData.CoAOfTransport = intCoAIDofTransport
        clsData.CoAOfCostRawMaterial = intCoAIDofCostRawMaterial
        clsData.Remarks = ""
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.CoAofSalesReturn = intCoAIDofSalesReturn
        clsData.CoAofCompensasionRevenue = intCoAIDofCompensasionRevenue
        clsData.CoAofClaimCost = intCoAIDofClaimCost
        clsData.CoAofRounding = intCoAofRounding
        clsData.CompanyID = ERPSLib.UI.usUserApp.CompanyID

        Me.Cursor = Cursors.WaitCursor
        Try
            If BL.JournalPost.SaveData(clsData) Then
                pgMain.Value = 100
                UI.usForm.frmMessageBox("Simpan data berhasil.")
                ERPSLib.UI.usUserApp.JournalPost = BL.JournalPost.GetDetail(ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID)
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
        End Try
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, VO.Access.Values.EditAccess)
    End Sub

#Region "Form Handle"

    Private Sub frmSysJournalPost_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmSysJournalPost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
        prvUserAccess()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnCoAOfRevenue_Click(sender As Object, e As EventArgs) Handles btnCoAOfRevenue.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofRevenue = .pubLUdtRow.Item("ID")
                txtCoACodeOfRevenue.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfRevenue.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfAccountReceivable_Click(sender As Object, e As EventArgs) Handles btnCoAOfAccountReceivable.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountReceivable = .pubLUdtRow.Item("ID")
                txtCoACodeOfAccountReceivable.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfAccountReceivable.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfSalesDiscount_Click(sender As Object, e As EventArgs) Handles btnCoAOfSalesDiscount.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofSalesDiscount = .pubLUdtRow.Item("ID")
                txtCoACodeOfSalesDiscount.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfSalesDiscount.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfPrepaidIncome_Click(sender As Object, e As EventArgs) Handles btnCoAOfPrepaidIncome.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofPrepaidIncome = .pubLUdtRow.Item("ID")
                txtCoACodeOfPrepaidIncome.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfPrepaidIncome.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfCOGS_Click(sender As Object, e As EventArgs) Handles btnCoAOfCOGS.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofCOGS = .pubLUdtRow.Item("ID")
                txtCoACodeOfCOGS.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfCOGS.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfStock_Click(sender As Object, e As EventArgs) Handles btnCoAOfStock.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofStock = .pubLUdtRow.Item("ID")
                txtCoACodeOfStock.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfStock.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfCashOrBank_Click(sender As Object, e As EventArgs) Handles btnCoAOfCashOrBank.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofCashOrBank = .pubLUdtRow.Item("ID")
                txtCoACodeOfCashOrBank.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfCashOrBank.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfAccountPayable_Click(sender As Object, e As EventArgs) Handles btnCoAOfAccountPayable.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayable = .pubLUdtRow.Item("ID")
                txtCoACodeOfAccountPayable.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfAccountPayable.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfPurchaseDiscount_Click(sender As Object, e As EventArgs) Handles btnCoAOfPurchaseDiscount.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofPurchaseDiscount = .pubLUdtRow.Item("ID")
                txtCoACodeOfPurchaseDiscount.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfPurchaseDiscount.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfEquipments_Click(sender As Object, e As EventArgs) Handles btnCoAOfEquipments.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofPurchaseEquipments = .pubLUdtRow.Item("ID")
                txtCoACodeOfEquipments.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfEquipments.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfAdvancePayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfAdvancePayment.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAdvancePayment = .pubLUdtRow.Item("ID")
                txtCoACodeOfAdvancePayment.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfAdvancePayment.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfSalesTax_Click(sender As Object, e As EventArgs) Handles btnCoAOfSalesTax.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofSalesTax = .pubLUdtRow.Item("ID")
                txtCoACodeOfSalesTax.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfSalesTax.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfPurchaseTax_Click(sender As Object, e As EventArgs) Handles btnCoAOfPurchaseTax.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofPurchaseTax = .pubLUdtRow.Item("ID")
                txtCoACodeOfPurchaseTax.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfPurchaseTax.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofVentureCapital_Click(sender As Object, e As EventArgs) Handles btnCoAofVentureCapital.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofVentureCapital = .pubLUdtRow.Item("ID")
                txtCoACodeofVentureCapital.Text = .pubLUdtRow.Item("Code")
                txtCoANameofVentureCapital.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofPPHSales_Click(sender As Object, e As EventArgs) Handles btnCoAofPPHSales.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDOfPPHSales = .pubLUdtRow.Item("ID")
                txtCoACodeofPPHSales.Text = .pubLUdtRow.Item("Code")
                txtCoANameofPPHSales.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofPPHPurchase_Click(sender As Object, e As EventArgs) Handles btnCoAofPPHPurchase.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDOfPPHPurchase = .pubLUdtRow.Item("ID")
                txtCoACodeofPPHPurchase.Text = .pubLUdtRow.Item("Code")
                txtCoANameofPPHPurchase.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofPrepaidIncomeCutting_Click(sender As Object, e As EventArgs) Handles btnCoAofPrepaidIncomeCutting.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofPrepaidIncomeCutting = .pubLUdtRow.Item("ID")
                txtCoACodeofPrepaidIncomeCutting.Text = .pubLUdtRow.Item("Code")
                txtCoANameofPrepaidIncomeCutting.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofPrepaidIncomeTransport_Click(sender As Object, e As EventArgs) Handles btnCoAofPrepaidIncomeTransport.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofPrepaidIncomeTransport = .pubLUdtRow.Item("ID")
                txtCoACodeofPrepaidIncomeTransport.Text = .pubLUdtRow.Item("Code")
                txtCoANameofPrepaidIncomeTransport.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofStockCutting_Click(sender As Object, e As EventArgs) Handles btnCoAofStockCutting.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofStockCutting = .pubLUdtRow.Item("ID")
                txtCoACodeofStockCutting.Text = .pubLUdtRow.Item("Code")
                txtCoANameofStockCutting.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofStockCutting2_Click(sender As Object, e As EventArgs) Handles btnCoAofStockCutting2.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofStockCutting2 = .pubLUdtRow.Item("ID")
                txtCoACodeofStockCutting2.Text = .pubLUdtRow.Item("Code")
                txtCoANameofStockCutting2.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofStockCutting3_Click(sender As Object, e As EventArgs) Handles btnCoAofStockCutting3.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofStockCutting3 = .pubLUdtRow.Item("ID")
                txtCoACodeofStockCutting3.Text = .pubLUdtRow.Item("Code")
                txtCoANameofStockCutting3.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofStockTransport_Click(sender As Object, e As EventArgs) Handles btnCoAofStockTransport.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofStockTransport = .pubLUdtRow.Item("ID")
                txtCoACodeofStockTransport.Text = .pubLUdtRow.Item("Code")
                txtCoANameofStockTransport.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofAccountPayableCutting_Click(sender As Object, e As EventArgs) Handles btnCoAofAccountPayableCutting.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayableCutting = .pubLUdtRow.Item("ID")
                txtCoACodeofAccountPayableCutting.Text = .pubLUdtRow.Item("Code")
                txtCoANameofAccountPayableCutting.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofAccountPayableCutting2_Click(sender As Object, e As EventArgs) Handles btnCoAofAccountPayableCutting2.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayableCutting2 = .pubLUdtRow.Item("ID")
                txtCoACodeofAccountPayableCutting2.Text = .pubLUdtRow.Item("Code")
                txtCoANameofAccountPayableCutting2.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofAccountPayableCutting3_Click(sender As Object, e As EventArgs) Handles btnCoAofAccountPayableCutting3.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayableCutting3 = .pubLUdtRow.Item("ID")
                txtCoACodeofAccountPayableCutting3.Text = .pubLUdtRow.Item("Code")
                txtCoANameofAccountPayableCutting3.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofAccountPayableTransport_Click(sender As Object, e As EventArgs) Handles btnCoAofAccountPayableTransport.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayableTransport = .pubLUdtRow.Item("ID")
                txtCoACodeofAccountPayableTransport.Text = .pubLUdtRow.Item("Code")
                txtCoANameofAccountPayableTransport.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfAccountReceivableOutstandingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfAccountReceivableOutstandingPayment.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountReceivableOutstandingPayment = .pubLUdtRow.Item("ID")
                txtCoACodeOfAccountReceivableOutstandingPayment.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfAccountReceivableOutstandingPayment.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAOfAccountPayableOutstandingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfAccountPayableOutstandingPayment.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayableOutstandingPayment = .pubLUdtRow.Item("ID")
                txtCoACodeOfAccountPayableOutstandingPayment.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfAccountPayableOutstandingPayment.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofAccountPayableCuttingOutstandingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAofAccountPayableCuttingOutstandingPayment.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayableCuttingOutstandingPayment = .pubLUdtRow.Item("ID")
                txtCoACodeofAccountPayableCuttingOutstandingPayment.Text = .pubLUdtRow.Item("Code")
                txtCoANameofAccountPayableCuttingOutstandingPayment.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofAccountPayableTransportOutstandingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAofAccountPayableTransportOutstandingPayment.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofAccountPayableTransportOutstandingPayment = .pubLUdtRow.Item("ID")
                txtCoACodeofAccountPayableTransportOutstandingPayment.Text = .pubLUdtRow.Item("Code")
                txtCoANameofAccountPayableTransportOutstandingPayment.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofCutting_Click(sender As Object, e As EventArgs) Handles btnCoAofCutting.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofCutting = .pubLUdtRow.Item("ID")
                txtCoACodeofCutting.Text = .pubLUdtRow.Item("Code")
                txtCoANameofCutting.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofTransport_Click(sender As Object, e As EventArgs) Handles btnCoAofTransport.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofTransport = .pubLUdtRow.Item("ID")
                txtCoACodeofTransport.Text = .pubLUdtRow.Item("Code")
                txtCoANameofTransport.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofCostOfRawMaterial_Click(sender As Object, e As EventArgs) Handles btnCoAofCostOfRawMaterial.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofCostRawMaterial = .pubLUdtRow.Item("ID")
                txtCoACodeofCostRawMaterial.Text = .pubLUdtRow.Item("Code")
                txtCoANameofCostRawMaterial.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofSalesReturn_Click(sender As Object, e As EventArgs) Handles btnCoAofSalesReturn.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofSalesReturn = .pubLUdtRow.Item("ID")
                txtCoACodeofSalesReturn.Text = .pubLUdtRow.Item("Code")
                txtCoANameofSalesReturn.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofCompensasionRevenue_Click(sender As Object, e As EventArgs) Handles btnCoAofCompensasionRevenue.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofCompensasionRevenue = .pubLUdtRow.Item("ID")
                txtCoACodeofCompensasionRevenue.Text = .pubLUdtRow.Item("Code")
                txtCoANameofCompensasionRevenue.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofClaimCost_Click(sender As Object, e As EventArgs) Handles btnCoAofClaimCost.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofClaimCost = .pubLUdtRow.Item("ID")
                txtCoACodeofClaimCost.Text = .pubLUdtRow.Item("Code")
                txtCoANameofClaimCost.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub btnCoAofRounding_Click(sender As Object, e As EventArgs) Handles btnCoAofRounding.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAofRounding = .pubLUdtRow.Item("ID")
                txtCoACodeofRounding.Text = .pubLUdtRow.Item("Code")
                txtCoANameofRounding.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

#End Region

End Class