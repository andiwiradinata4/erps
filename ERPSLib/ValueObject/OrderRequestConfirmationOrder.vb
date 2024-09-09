Namespace VO
 
    Public Class OrderRequestConfirmationOrder
        Inherits Common
        Property ID As String
        Property OrderRequestID As String
        Property OrderNumber As String
        Property TransactionNumber As String
        Property Remarks As String
        Property Detail As New List(Of VO.OrderRequestConfirmationOrderDet)
    End Class
End Namespace