Namespace VO
    Public Class StockOut
        Inherits Common
        Property ID As String
        Property ParentID As String
        Property ParentDetailID As String
        Property OrderNumberSupplier As String
        Property SourceData As String
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property CoAofStock As Integer
    End Class
End Namespace