Namespace VO
    Public Class ChartOfAccount
        Inherits Common
        Property ID As Integer
        Property AccountGroupID As Integer
        Property AccountGroupName As String
        Property Code As String
        Property Name As String
        Property FirstBalance As Decimal
        Property FirstBalanceDate As DateTime
        Property StatusID As Integer
        Property Initial As String

        Public Const cProfitAndLoss = 43
        Public Const cStock = 23
        Enum FilterGroup
            All
            CashOrBank
            Expense
            Stock
            ViewOnly
        End Enum

        Enum DefaultTransaction
            Payment = 1
            ReceivableAKR = 4
            ReceivableSIA = 5
        End Enum

    End Class 
End Namespace

