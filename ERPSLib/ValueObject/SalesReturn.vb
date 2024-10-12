Namespace VO
    Public Class SalesReturn
        Inherits Common
        Property ID As String
        Property SalesReturnNumber As String
        Property SalesReturnDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property DeliveryID As String
        Property DeliveryNumber As String
        Property PlatNumber As String
        Property Driver As String
        Property ReferencesNumber As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property RoundingManual As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property TotalDPPTransport As Decimal
        Property TotalPPNTransport As Decimal
        Property TotalPPHTransport As Decimal
        Property RoundingManualTransport As Decimal
        Property GrandTotalTransport As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property DPAmount As Decimal
        Property TotalPayment As Decimal
        Property CoAofStock As Integer
        Property CoACodeOfStock As String
        Property CoANameOfStock As String
        Property IsUseSubItem As Boolean
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property TotalPaymentPPN As Decimal
        Property TotalPaymentPPH As Decimal
        Property TransporterID As Integer
        Property TransporterCode As String
        Property TransporterName As String
        Property PPNTransport As Decimal
        Property PPHTransport As Decimal
        Property IsFreePPNTransport As Boolean
        Property IsFreePPHTransport As Boolean
        Property UnitPriceTransport As Decimal
        Property DPAmountTransport As Decimal
        Property TotalPaymentTransport As Decimal
        Property DPAmountPPNTransport As Decimal
        Property DPAmountPPHTransport As Decimal
        Property TotalPaymentPPNTransport As Decimal
        Property TotalPaymentPPHTransport As Decimal
        Property Detail As List(Of VO.SalesReturnDet)
        Property Save As VO.Save.Action
    End Class
End Namespace