Namespace VO
    Public Class SalesService
        Inherits Common
        Property ID As String
        Property TransNumber As String
        Property TransDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property ServiceType As Integer
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property RoundingManual As Decimal
        Property DPAmount As Decimal
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceiveAmount As Decimal
        Property ReceiveAmountPPN As Decimal
        Property ReceiveAmountPPH As Decimal
        Property StatusID As Integer
        Property Remarks As String
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property Detail As New List(Of VO.SalesServiceDet)
        Property Save As VO.Save.Action
    End Class
End Namespace