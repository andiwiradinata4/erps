Namespace VO
    Public Class PurchaseOrderCuttingDet
        Property ID As String
        Property POID As String
        Property PCDetailID As String
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property DoneQuantity As Decimal
        Property DoneWeight As Decimal
        Property Remarks As String
        Property UnitPriceRawMaterial As Decimal
        Property TotalPriceRawMaterial As Decimal
        Property ReceiveAmount As Decimal
        Property DPAmount As Decimal
        Property OrderNumberSupplier As String
        Property GroupID As Integer
        Property RoundingWeight As Decimal
        Property LevelItem As Decimal
        Property ParentID As String = ""
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceivePPN As Decimal
        Property ReceivePPH As Decimal
        Property ReceiveDetailID As String
        Property ClaimDPAmount As Decimal
        Property ClaimDPAmountPPN As Decimal
        Property ClaimDPAmountPPH As Decimal
        Property ClaimReceiveAmount As Decimal
        Property ClaimReceivePPN As Decimal
        Property ClaimReceivePPH As Decimal
        Property ResultID As String
        Property IsShowCoil As Boolean
    End Class
End Namespace