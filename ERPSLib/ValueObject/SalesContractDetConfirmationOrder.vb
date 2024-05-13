Namespace VO
    Public Class SalesContractDetConfirmationOrder
        Property ID As String
        Property SCID As String
        Property CODetailID As String
        Property OrderRequestDetailID As String
        Property GroupID As Integer
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property Remarks As String
        Property RoundingWeight As Decimal
        Property LevelItem As Integer
        Property ParentID As String = ""
    End Class
End Namespace