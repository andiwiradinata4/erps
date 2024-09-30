Namespace VO
    Public Class SalesContractDet
        Property ID As String
        Property SCID As String
        Property ORDetailID As String
        Property GroupID As Integer
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property DCQuantity As Decimal
        Property DCWeight As Decimal
        Property Remarks As String
        Property ReceiveAmount As Decimal
        Property DPAmount As Decimal
        Property OrderNumberSupplier As String
        Property RoundingWeight As Decimal
        Property LevelItem As Integer
        Property ParentID As String = ""
        Property UnitPriceHPP As Decimal
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceivePPN As Decimal
        Property ReceivePPH As Decimal
        Property CODetailID As String = ""
        Property PCDetailID As String = ""
    End Class
End Namespace