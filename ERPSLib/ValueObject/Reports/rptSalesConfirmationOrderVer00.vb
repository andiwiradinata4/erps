Namespace VO
    Public Class rptSalesConfirmationOrderVer00
        '# Headers
        Inherits Common
        Property ID As String
        Property TransNumber As String
        Property TransDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property DeliveryPeriod As String
        Property BPPIC As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property AllItemName As String
        Property PaymentTerms As String
        Property AllReferencesNumber As String
        Property AllOrderNumberSupplier As String
        Property CompanySubDistrict As String
        Property CompanyDirectorName As String
        Property NumericToString As String
        Property DelegationSeller As String
        Property DelegationPositionSeller As String
        Property DelegationBuyer As String
        Property DelegationPositionBuyer As String

        '# Items
        Property DeliveryAddress As String
        Property OrderRequestNumber As String
        Property PONumber As String
        Property ItemID As Integer
        Property ItemCode As String
        Property ItemName As String
        Property ItemType As String
        Property ItemSpec As String
        Property ItemThick As Decimal
        Property ItemWidth As Decimal
        Property ItemLength As String
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeightItem As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property TotalPPNItem As Decimal
        Property TotalPriceIncPPN As Decimal
        Property ItemMin As Decimal
        Property ItemMax As Decimal
        Property ItemTolerances As Decimal
    End Class
End Namespace