﻿Namespace VO
    Public Class Delivery
        Inherits Common
        Property ID As String
        Property DeliveryNumber As String
        Property DeliveryDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property SCID As String
        Property SCNumber As String
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
        Property TotalDPPTransport As Decimal
        Property TotalPPNTransport As Decimal
        Property TotalPPHTransport As Decimal
        Property GrandTotalTransport As Decimal
        Property RoundingManual As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property Detail As List(Of VO.DeliveryDet)
        Property DetailTransport As List(Of VO.DeliveryDetTransport)
        Property Save As VO.Save.Action
    End Class
End Namespace