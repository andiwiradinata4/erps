Namespace VO.Report
    Public Class PurchaseOrder
        '# Headers
        Inherits Common
        Property ID As String
        Property PONumber As String
        Property PODate As DateTime
        Property OrderRequestID As String
        Property OrderNumber As String
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property PersonInCharge As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property DeliveryPeriod As String
        Property DeliveryAddress As String
        Property Validity As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property TotalInternalQuantity As Decimal
        Property TotalInternalWeight As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property RoundingManual As Decimal
        Property Remarks As String
        Property PODateAndCity As String
        Property PaymentTerms As String

        '# Items
        Property GroupID As Integer
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