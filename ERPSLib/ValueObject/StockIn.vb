Namespace VO
    Public Class StockIn
        Inherits Common
        Property ID As String = ""
        Property ParentID As String
        Property ParentDetailID As String
        Property OrderNumberSupplier As String
        Property SourceData As String
        Property ItemID As Integer
        Property InQuantity As Decimal
        Property InWeight As Decimal
        Property InTotalWeight As Decimal
        Property OutQuantity As Decimal
        Property OutWeight As Decimal
        Property OutTotalWeight As Decimal

        Public Const SourceDataReceive = "RECEIVE"
        Public Const SourceDataCutting = "CUTTING"

    End Class
End Namespace