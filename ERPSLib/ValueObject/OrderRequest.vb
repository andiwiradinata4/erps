Namespace VO
    Public Class OrderRequest
        Inherits Common
        Property ID As String
        Property OrderNumber As String
        Property OrderDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
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
        Property IsStock As Boolean
        Property IsDoneBy As Boolean
        Property DoneBy As String
        Property DoneDate As DateTime
        Property DPAmount As Decimal
        Property ReceiveAmount As Decimal
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceiveAmountPPN As Decimal
        Property ReceiveAmountPPH As Decimal
        Property Detail As List(Of VO.OrderRequestDet)
        Property Save As VO.Save.Action
        Property CoAofStock As Integer
        Property CoACodeOfStock As String
        Property CoANameOfStock As String
    End Class
End Namespace