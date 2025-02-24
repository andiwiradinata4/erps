Namespace VO
    Public Class CuttingDetResult
        Property ID As String
        Property CuttingID As String
        Property GroupID As Integer
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property Remarks As String
        Property PODetailResultID As String
        Property OrderNumberSupplier As String
        Property RoundingWeight As Decimal
        Property LevelItem As Integer
        Property ParentID As String = ""
        Property UnitPriceHPP As Decimal
        Property TotalPriceHPP As Decimal
        Property InvoiceQuantity As Decimal
        Property InvoiceWeight As Decimal
        Property InvoiceTotalWeight As Decimal
        Property DPAmount As Decimal
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceiveAmount As Decimal
        Property ReceivePPN As Decimal
        Property ReceivePPH As Decimal
        Property AllocateDPAmount As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property UnitPriceClaim As Decimal
        Property TotalPriceClaim As Decimal
    End Class
End Namespace