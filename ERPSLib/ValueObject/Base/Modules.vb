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
        End Enum

    End Class
End Namespace

