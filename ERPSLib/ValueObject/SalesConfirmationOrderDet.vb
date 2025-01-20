Namespace VO
    Public Class SalesConfirmationOrderDet
        Inherits Common
        Property ID As String
        Property COID As String
        Property ORDetailID As String
        Property PODetailID As String
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property Remarks As String
        Property RoundingWeight As Decimal
        Property LocationID As Integer
        Property ItemMin As Decimal
        Property ItemMax As Decimal
        Property ItemTolerances As Decimal
    End Class
End Namespace