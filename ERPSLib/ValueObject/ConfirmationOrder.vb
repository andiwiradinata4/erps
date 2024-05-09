Namespace VO
    Public Class ConfirmationOrder
        Inherits Common
        Property ID As String
        Property CONumber As String
        Property CODate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property AllowanceProduction As Decimal
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property RoundingManual As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property PCID As String
        Property PCNumber As String
        Property Franco As String
        Property IsUseSubItem As Boolean
        Property Detail As List(Of VO.ConfirmationOrderDet)
        Property PaymentTerm As List(Of VO.ConfirmationOrderPaymentTerm)
        Property Save As VO.Save.Action
    End Class
End Namespace