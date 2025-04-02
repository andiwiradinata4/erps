Namespace VO
    Public Class Modules
        Inherits Common
        Property ID As Integer
        Property Name As String
        Property Remarks As String

        Enum Values
            All = 0

            '# Master
            MasterProgram = 1
            MasterStatus = 2
            MasterModule = 3
            MasterAccess = 4
            MasterCompany = 5
            MasterUser = 6
            MasterUOM = 7
            MasterItemType = 8
            MasterItemSpecification = 9
            MasterItem = 10
            MasterBusinessPartner = 11
            MasterPaymentType = 12
            MasterPaymentTypeCategory = 13
            MasterCompanyBankAccount = 14
            MasterPaymentMode = 19
            MasterChartOfAccount = 28
            MasterChartOfAccountType = 29
            MasterChartOfAccountGroup = 30

            '# Transaction
            TransactionOrderRequest = 15
            TransactionPurchaseOrder = 16
            TransactionPurchaseOrderCutting = 17
            TransactionPurchaseOrderTransport = 18
            TransactionConfirmationOrder = 20
            TransactionPurchaseContract = 21
            TransactionInstructionLetter = 22
            TransactionConfirmationDelivery = 23
            TransactionCuttingProcess = 24
            TransactionSalesContract = 25
            TransactionPickupMemo = 26
            TransactionSalesDelivery = 27
            TransactionReceive = 42

            '## Pembukuan
            TransactionJournal = 31
            TransactionAccountReceivableBalance = 33
            TransactionAccountPayableBalance = 34
            TransactionCost = 35
            TransactionSalesDPManual = 36
            TransactionPurchaseDPManual = 37
            TransactionSalesDP = 38
            TransactionPurchaseDP = 39
            TransactionAccountReceivable = 40
            TransactionAccountPayable = 41
            TransactionPurchaseDPCutting = 43
            TransactionAccountPayableCutting = 44
            TransactionPurchaseDPTransport = 45
            TransactionAccountPayableTransport = 46

            '# Reports
            ReportBukuBesar = 32
            ReportTransaksiBarang = 47
            ReportNeracaSaldo = 48
            ReportProfitAndLoss = 49
            ReportBalanceSheet = 50
        End Enum

        Enum Value
            All = 0

            '# Master
            MasterDefault = 1
            MasterProgram = 2
            MasterStatus = 3
            MasterModule = 4
            MasterAccess = 5
            MasterCompany = 6
            MasterUser = 7
            MasterUOM = 8
            MasterChartOfAccountType = 9
            MasterChartOfAccountGroup = 10
            MasterChartOfAccount = 11
            MasterItemType = 12
            MasterItemSpecification = 13
            MasterItem = 14
            MasterItemCopy = 86
            MasterStock = 15
            MasterBusinessPartner = 16
            MasterBusinessPartnerBankAccount = 17
            MasterBusinessPartnerLocation = 18
            MasterCompanyBankAccount = 19
            MasterPaymentTypeCategory = 20
            MasterPaymentMethod = 21
            MasterPaymentType = 22
            MasterDeliveryLocation = 23
            MasterTransportCostType = 24

            '# Transaction
            '# Sales
            TransactionSalesOrderRequest = 25
            TransactionSalesOrderRequestDownPayment = 26
            TransactionSalesOrderRequestMapConfirmationOrder = 27
            TransactionSalesConfirmationOrder = 28
            TransactionSalesSalesContract = 29
            TransactionSalesSalesContractDownPayment = 30
            TransactionSalesSalesContractDownPaymentInvoice = 31
            TransactionSalesSalesContractReceivePayment = 32
            TransactionSalesSalesContractReceivePaymentInvoice = 33
            TransactionSalesSalesContractSetupDelivery = 34
            TransactionSalesDelivery = 35
            TransactionSalesSalesReturn = 36
            TransactionSalesSalesReturnReceivePayment = 37
            TransactionSalesSalesReturnReceivePaymentTransport = 38
            TransactionSalesClaimRequest = 39
            TransactionSalesClaimConfirmation = 40
            TransactionSalesClaimReceivePayment = 41

            '# Sales Service
            TransactionSalesServiceDelivery = 42
            TransactionSalesServiceDeliveryReceivePayment = 43
            TransactionSalesServiceCutting = 44
            TransactionSalesServiceCuttingReceivePayment = 45
            TransactionSalesServiceInvoice = 46

            '# Purchase
            TransactionPurchasePurchaseOrder = 47
            TransactionPurchaseConfirmationOrder = 48
            TransactionPurchasePurchaseContract = 49
            TransactionPurchasePurchaseContractDownPayment = 50
            TransactionPurchasePurchaseContractReceivePayment = 51
            TransactionPurchasePurchaseContractDone = 52
            TransactionPurchaseReceive = 53
            TransactionPurchasePurchaseOrderCutting = 54
            TransactionPurchaseCutting = 55
            TransactionPurchaseCuttingReceive = 56
            TransactionPurchaseCuttingClaimCustomer = 57
            TransactionPurchaseClaimRequest = 58
            TransactionPurchaseClaimConfirmation = 59
            TransactionPurchaseClaimReceivePayment = 60

            '# Accounting
            TransactionAccountingAR = 61
            TransactionAccountingAP = 62
            TransactionAccountingARAPInvoice = 63
            TransactionAccountingARAPDueDate = 64
            TransactionAccountingCost = 65
            TransactionAccountingTransportCost = 66
            TransactionAccountingTransportCostSetPaymentDate = 67
            TransactionAccountingTransportCostSetTaxInvoiceNumber = 68
            TransactionAccountingCuttingCost = 69
            TransactionAccountingCuttingCostSetPaymentDate = 70
            TransactionAccountingCuttingCostSetTaxInvoiceNumber = 71
            TransactionAccountingBankVoucher = 72
            TransactionAccountingJournal = 73
            TransactionAccountingJournalAutoGenerate = 74

            '# Reports
            ReportPurchasePurchaseOrderCutting = 75
            ReportSalesConfirmationOrder = 76
            ReportItemTransaction = 77
            ReportAccountingAR = 78
            ReportAccountingDebtCard = 79
            ReportAccountingReceivableCard = 80
            ReportAccountingGeneralLedger = 81
            ReportAccountingTrialBalance = 82
            ReportAccountingProfitAndLoss = 83
            ReportAccountingBalanceSheet = 84

            '# Settings
            SetupPostingJournalTransaction = 85

        End Enum

    End Class
End Namespace

