Namespace VO
    Public Class ItemResult
        Inherits Common
        Property ID As String
        Property Name As String
        Property StatusID As Integer
        Property ItemID As Integer
        Property ItemCode As String
        Property ItemName As String
        Property Thick As Decimal
        Property Width As Decimal
        Property Length As Decimal
        Property Weight As Decimal
        Property ItemTypeID As Integer
        Property ItemTypeName As String
        Property ItemSpecificationID As Integer
        Property ItemSpecificationName As String
        Property Remarks As String
        Property Detail As New List(Of ItemResultDet)
    End Class 
End Namespace