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
        Property Detail As List(Of VO.CuttingDet)
        Property DetailResult As List(Of VO.CuttingDetResult)
        Property Save As VO.Save.Action
    End Class
End Namespace