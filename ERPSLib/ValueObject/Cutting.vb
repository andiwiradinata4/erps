Namespace VO
    Public Class Cutting
        Inherits Common
        Property ID As String
        Property CuttingNumber As String
        Property CuttingDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property ReferencesNumber As String
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property RoundingManual As Decimal
        Property DPAmount As Decimal
        Property TotalPayment As Decimal
        Property POID As String
        Property PONumber As String
        Property CoAIDofStock As Integer
        Property CoACodeofStock As String
        Property CoANameofStock As String
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property TotalPaymentPPN As Decimal
        Property TotalPaymentPPH As Decimal
        Property Detail As List(Of VO.CuttingDet)
        Property DetailResult As List(Of VO.CuttingDetResult)
        Property Save As VO.Save.Action
        Property CustomerID As Integer
        Property CustomerCode As String
        Property CustomerName As String
        Property PickupDate As DateTime
        Property IsClaimCustomer As Boolean
        Property ClaimDPAmount As Decimal
        Property ClaimDPAmountPPN As Decimal
        Property ClaimDPAmountPPH As Decimal
        Property ClaimReceiveAmount As Decimal
        Property ClaimReceiveAmountPPN As Decimal
        Property ClaimReceiveAmountPPH As Decimal
    End Class
End Namespace