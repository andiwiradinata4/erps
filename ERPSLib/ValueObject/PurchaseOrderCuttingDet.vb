Namespace VO
    Public Class PurchaseOrderCuttingDet
        Property ID As String
        Property POID As String
        Property PCDetailID As String
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property DoneQuantity As Decimal
        Property DoneWeight As Decimal
        Property Remarks As String
        Property UnitPriceRawMaterial As Decimal
        Property TotalPriceRawMaterial As Decimal
        Property ReceiveAmount As Decimal
        Property DPAmount As Decimal
        Property OrderNumberSupplier As String
        Property GroupID As Integer
        Property RoundingWeight As Decimal
        Property LevelItem As Decimal
        Property ParentID As String = ""
    End Class
End Namespace