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
    End Class
End Namespace