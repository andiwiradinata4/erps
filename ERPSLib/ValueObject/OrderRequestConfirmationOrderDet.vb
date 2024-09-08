Namespace VO
 
    Public Class OrderRequestConfirmationOrderDet
        Inherits Common
        Property ID As String
        Property ParentID As String
        Property ORDetailID As String
        Property CODetailID As String
        Property GroupID As Integer
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property Remarks As String
        Property RoundingWeight As Decimal
        Property QuantityCO As Decimal
        Property WeightCO As Decimal
        Property TotalWeightCO As Decimal
        Property UnitPriceCO As Decimal
        Property TotalPriceCO As Decimal
        Property RoundingWeightCO As Decimal
        Property LevelItem As Integer
        Property LocationID As Integer
        Property OrderNumberSupplier As String
        Property DPAmount As Decimal
        Property ReceiveAmount As Decimal
        Property UnitPriceHPP As Decimal
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceiveAmountPPN As Decimal
        Property ReceiveAmountPPH As Decimal
    End Class
End Namespace