﻿Namespace VO
    Public Class rptClaim
        Inherits Common
        Property ID As String
        Property ClaimType As Integer
        Property ClaimNumber As String
        Property ClaimDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property ReferencesID As String
        Property PlatNumber As String
        Property Driver As String
        Property ReferencesNumber As String
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
        Property DPAmount As Decimal
        Property TotalPayment As Decimal
        Property IsUseSubItem As Boolean
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property TotalPaymentPPN As Decimal
        Property TotalPaymentPPH As Decimal
        Property ItemDescription As String
        Property Detail As New List(Of VO.ClaimDet)
    End Class
End Namespace