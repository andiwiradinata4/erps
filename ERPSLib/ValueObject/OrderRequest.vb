Namespace VO
    Public Class OrderRequest
        Inherits Common
        Property ID As String
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property OrderNumber As String
        Property OrderDate As DateTime
        Property ReferencesNumber As String
        Property ItemSpecificationID As Integer
        Property ItemSpecificationName As String
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApprovedL1 As String
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property Detail As List(Of VO.OrderRequestDet)
    End Class
End Namespace