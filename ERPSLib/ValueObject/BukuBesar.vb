Namespace VO
    Public Class BukuBesar
        Inherits Common
        Property ID As String
        Property TransactionDate As DateTime
        Property ReferencesID As String
        Property ReferencesNo As String
        Property COAIDParent As Integer
        Property COAIDChild As Integer
        Property DebitAmount As Decimal
        Property CreditAmount As Decimal
        Property Balance As Decimal
        Property Remarks As String
        Property IsClosedPeriod As Boolean
        Property ClosedPeriodBy As String
        Property ClosedPeriodDate As DateTime
        Property BPID As Integer
    End Class 
End Namespace