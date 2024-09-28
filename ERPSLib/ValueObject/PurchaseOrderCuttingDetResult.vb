Namespace VO
    Public Class PurchaseOrderCuttingDetResult
        Property ID As String
        Property POID As String
        Property GroupID As Integer
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property DoneQuantity As Decimal
        Property DoneWeight As Decimal
        Property OrderNumberSupplier As String
        Property Remarks As String
        Property RoundingWeight As Decimal
        Property LevelItem As Decimal
        Property ParentID As String = ""
        Property UnitPriceRawMaterial As Decimal
        Property TotalPriceRawMaterial As Decimal
    End Class
End Namespace