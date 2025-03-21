﻿Namespace VO
    Public Class Cost
        Inherits Common
        Property ID As String
        Property CostNumber As String
        Property CoAID As Integer
        Property CoACode As String
        Property CoAName As String
        Property ReferencesID As String
        Property ReferencesNote As String
        Property CostDate As DateTime
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property TotalAmount As Decimal
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property PaymentBy As String
        Property PaymentDate As DateTime
        Property TaxInvoiceNumber As String
        Property IsClosedPeriod As Boolean
        Property ClosedPeriodBy As String
        Property ClosedPeriodDate As DateTime
        Property Remarks As String
        Property StatusID As Integer
        Property Detail As New List(Of VO.CostDet)
        Property DetailRemarks As New List(Of VO.ARAPRemarks)
        Property Save As VO.Save.Action
        Property PaidTo As String
        Property PaidAccount As String
        Property VoucherNumber As String
        Property VoucherDate As DateTime

    End Class
End Namespace