Namespace VO
    Public Class Modules
        Inherits Common
        Property ID As Integer
        Property Name As String
        Property Remarks As String

        Enum Values
            All = 0

            '# Master
            MasterCompany = 1
            MasterChartOfAccountGroup = 2
            MasterChartOfAccount = 3
            MasterUser = 4
            MasterBusinessPartners = 5
            MasterPaymentTerm = 6
            MasterPaymentReferences = 7
            MasterSalesDiscount = 8
            MasterUOM = 9
            MasterItem = 10

            '# Settings
            SettingPostingTransaction = 11
            SettingUnPostingTransaction = 12
            SettingSetupPostingJournalTransaction = 13
            SettingGenerateJurnal = 32
            SettingPostingTax = 33

            '# Transactions
            TransactionSales = 14
            TransactionSalesService = 30
            TransactionReceive = 15
            TransactionSalesReturn = 16
            TransactionReceiveReturn = 17
            TransactionAccountPayable = 18
            TransactionAccountReceivable = 19
            TransactionCost = 20
            TransactionJournal = 21
            TransactionSalesDownPayment = 24
            TransactionReceiveDownPayment = 25
            TransactionSplitReceive = 34

            '# Reports
            ReportProfitAndLoss = 22
            ReportBalanceSheet = 23
            ReportBukuBesar = 26
            ReportNeracaSaldo = 27
            ReportKartuPiutang = 28
            ReportKartuHutang = 29
            ReportKartuHutangHargaBeli2 = 31
        End Enum

    End Class
End Namespace

