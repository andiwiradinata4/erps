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
        Property LocationID As Integer
        Property PCDetailID As String = ""
        Property OrderNumberSupplier As String = ""
        Property CONumber As String = ""
        Property ItemCode As String = ""
        Property ItemName As String = ""
        Property Thick As Decimal
        Property Width As Decimal
        Property Length As Decimal
        Property ItemSpecificationID As Integer
        Property ItemSpecificationName As String = ""
        Property ItemTypeID As Integer
        Property ItemTypeName As String = ""
        Property MaxTotalWeight As Decimal
        Property SubItem As List(Of SalesContractDetConfirmationOrder)
    End Class
End Namespace