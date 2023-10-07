Namespace VO
    Public Class BusinessPartnerAPBalance
        Inherits Common
        Property ID As String
        Property BPID As Integer
        Property InvoiceNumber As String
        Property InvoiceDate As DateTime
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property TotalPaymentDP As Decimal
        Property TotalPayment As Decimal
    End Class
End Namespace