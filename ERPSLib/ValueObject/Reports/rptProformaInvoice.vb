Namespace VO
    Public Class rptProformaInvoice
        '# Headers
        Inherits Common
        Property ID As String
        Property TransNumber As String
        Property TransDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property BPAddress As String
        Property ReferencesID As String
        Property ReferencesNote As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property CompanyBankAccountID As Integer
        Property AccountName As String
        Property BankName As String
        Property AccountNumber As String
        Property CurrencyBank As String
        Property CompanySubDistrict As String
        Property CompanyDirectorName As String
        Property NumericToString As String

        '# Items
        Property ItemID As Integer
        Property ItemCode As String
        Property ItemName As String
        Property ItemType As String
        Property ItemSpec As String
        Property ItemThick As Decimal
        Property ItemWidth As Decimal
        Property ItemLength As Decimal
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeightItem As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
    End Class
End Namespace