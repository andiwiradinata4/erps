Namespace VO
    Public Class rptSalesContractVer00
        '# Headers
        Inherits Common
        Property ID As String
        Property SCNumber As String
        Property SCDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property AllowanceProduction As Decimal
        Property Franco As String
        Property DelegationSeller As String
        Property DelegationPositionSeller As String
        Property DelegationBuyer As String
        Property DelegationPositionBuyer As String
        Property SCDateAndSubDistrict As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property RoundingManual As Decimal
        Property Remarks As String
        Property CompanyBankAccountID As Integer
        Property AccountName As String
        Property BankName As String
        Property AccountNumber As String
        Property CurrencyBank As String
        Property AllItemName As String
        Property PaymentTerms As String
        Property DeliveryPeriod As String
        Property AllReferencesNumber As String
        Property MaxCreditTerms As Integer
        Property AllOrderNumberSupplier As String
        Property CompanySubDistrict As String
        Property CompanyDirectorName As String
        Property NumericToString As String

        '# Items
        Property DeliveryAddress As String
        Property OrderNumberSupplier As String
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
        Property TotalPPNItem As Decimal
        Property TotalPriceIncPPN As Decimal
    End Class

End Namespace