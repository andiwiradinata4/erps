Namespace VO
    Public Class CuttingDet
        Property ID As String
        Property CuttingID As String
        Property PODetailID As String
        Property GroupID As Integer
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property Remarks As String
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property ReceiveAmount As Decimal
        Property DPAmount As Decimal
        Property OrderNumberSupplier As String
        Property RoundingWeight As Decimal
        Property LevelItem As Integer
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceivePPN As Decimal
        Property ReceivePPH As Decimal
        Property ParentID As String = ""
        Property UnitPriceRawMaterial As Decimal = 0
        Property TotalPriceRawMaterial As Decimal = 0
        Property ClaimDPAmount As Decimal
        Property ClaimDPAmountPPN As Decimal
        Property ClaimDPAmountPPH As Decimal
        Property ClaimReceiveAmount As Decimal
        Property ClaimReceivePPN As Decimal
        Property ClaimReceivePPH As Decimal
        Property ClaimInvoiceQuantity As Decimal
        Property ClaimInvoiceWeight As Decimal
        Property ClaimInvoiceTotalWeight As Decimal
    End Class
End Namespace