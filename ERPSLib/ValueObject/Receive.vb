Namespace VO
    Public Class Receive
        Inherits Common
        Property ID As String
        Property ReceiveNumber As String
        Property ReceiveDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
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
        Property RoundingManual As Decimal
        Property GrandTotal As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property TotalPayment As Decimal
        Property DPAmount As Decimal
        Property PCID As String
        Property PCNumber As String
        Property CoAofStock As Integer
        Property CoACodeOfStock As String
        Property CoANameOfStock As String
        Property IsUseSubItem As Boolean
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property TotalPaymentPPN As Decimal
        Property TotalPaymentPPH As Decimal
        Property Detail As List(Of VO.ReceiveDet)
        Property Save As VO.Save.Action
        Property PaymentTypeID As Integer
    End Class
End Namespace