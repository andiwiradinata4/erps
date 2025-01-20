Namespace VO
    Public Class SalesConfirmationOrder
        Inherits Common
        Property ID As String
        Property CONumber As String
        Property CODate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property RoundingManual As Decimal
        Property DelegationSeller As String
        Property DelegationPositionSeller As String
        Property DelegationBuyer As String
        Property DelegationPositionBuyer As String
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property IsDone As Boolean
        Property DoneBy As String
        Property DoneDate As DateTime
        Property Detail As New List(Of VO.SalesConfirmationOrderDet)
        Property PaymentTerm As New List(Of VO.SalesConfirmationOrderPaymentTerm)
        Property Save As VO.Save.Action
    End Class
End Namespace

