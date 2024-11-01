Namespace VO
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
        Property DPAmount As Decimal
        Property TotalPayment As Decimal
        Property RoundingManualTransport As Decimal
        Property DPAmountTransport As Decimal
        Property TotalPaymentTransport As Decimal
        Property JournalIDTransport As String
        Property TotalCostRawMaterial As Decimal
        Property TransporterID As Integer
        Property TransporterCode As String
        Property TransporterName As String
        Property UnitPriceTransport As Decimal
        Property PPNTransport As Decimal
        Property PPHTransport As Decimal
        Property IsFreePPNTransport As Decimal
        Property IsFreePPHTransport As Decimal
        Property IsUseSubItem As Boolean
        Property IsStock As Boolean
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property TotalPaymentPPN As Decimal
        Property TotalPaymentPPH As Decimal
        Property Detail As List(Of VO.DeliveryDet)
        Property DeliveryTransport As List(Of VO.DeliveryTransport)
        Property DetailTransport As List(Of VO.DeliveryDetTransport)
        Property Save As VO.Save.Action
        Property BPLocationID As Integer
        Property BPLocationName As String
        Property CoAofStock As Integer
        Property CoACodeOfStock As String
        Property CoANameOfStock As String

        Public Enum PrintType
            None
            Plat
            Coil
        End Enum

    End Class
End Namespace