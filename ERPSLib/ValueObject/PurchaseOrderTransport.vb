﻿Namespace VO
    Public Class PurchaseOrderTransport
        Inherits Common
        Property ID As String
        Property PONumber As String
        Property PODate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property CustomerID As Integer
        Property CustomerCode As String
        Property CustomerName As String
        Property SCID As String
        Property SCNumber As String
        Property PersonInCharge As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property DeliveryAddress As String
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
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property Detail As List(Of VO.PurchaseOrderTransportDet)
        Property PaymentTerm As List(Of VO.PurchaseOrderPaymentTerm)
        Property Save As VO.Save.Action
    End Class
End Namespace