﻿Namespace VO
    Public Class PurchaseContract
        Inherits Common
        Property ID As String
        Property PCNumber As String
        Property PCDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property AllowanceProduction As Decimal
        Property Franco As String
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
        Property DPAmount As Decimal
        Property ReceiveAmount As Decimal
        Property IsAutoGenerate As Boolean
        Property IsUseSubItem As Boolean
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceiveAmountPPN As Decimal
        Property ReceiveAmountPPH As Decimal
        Property Detail As List(Of VO.PurchaseContractDet)
        Property PaymentTerm As List(Of VO.PurchaseContractPaymentTerm)
        Property Save As VO.Save.Action
        Property PaymentTypeID As Integer
        Property IsDone As Integer
        Property DoneBy As String
        Property DoneDate As DateTime
    End Class
End Namespace