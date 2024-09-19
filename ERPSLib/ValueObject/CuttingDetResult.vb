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
    End Class
End Namespace