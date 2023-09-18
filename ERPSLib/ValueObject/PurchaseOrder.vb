Namespace VO
    Public Class PurchaseOrder
        Inherits Common
        Property ID As String
        Property PONumber As String
        Property PODate As DateTime
        Property OrderRequestID As String
        Property OrderNumber As String
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property PersonInCharge As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property DeliveryAddress As String
        Property Validity As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property TotalInternalQuantity As Decimal
        Property TotalInternalWeight As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property RoundingManual As Decimal
        Property TotalInternalDPP As Decimal
        Property TotalInternalPPN As Decimal
        Property TotalInternalPPH As Decimal
        Property GrandTotalInternal As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property Detail As List(Of VO.PurchaseOrderDet)
        Property DetailInternal As List(Of VO.PurchaseOrderDetInternal)
        Property Save As VO.Save.Action
    End Class
End Namespace