Namespace VO
    Public Class SalesContractDet
        Property ID As String
        Property SCID As String
        Property ORDetailID As String
        Property GroupID As Integer
        Property ItemID As Integer
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property DCQuantity As Decimal
        Property DCWeight As Decimal
        Property POTransportQuantity As Decimal
        Property POTransportWeight As Decimal
        Property Remarks As String
        Property ReceiveAmount As Decimal
        Property DPAmount As Decimal
        Property OrderNumberSupplier As String
        Property IsIgnoreValidationPayment As Boolean
        Property LevelItem As Integer
        Property ParentID As String = ""
        Property RoundingWeight As Decimal
        Property UnitPriceHPP As Decimal
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceiveAmountPPN As Decimal
        Property ReceiveAmountPPH As Decimal
        Property ReceivePPN As Decimal
        Property ReceivePPH As Decimal
        Property AllocateDPAmount As Decimal
        Property InvoiceQuantity As Decimal
        Property InvoiceWeight As Decimal
        Property InvoiceTotalWeight As Decimal
        Property CODetailID As String = ""
        Property PCDetailID As String = ""
        Property ClaimQuantity As Decimal
        Property ClaimWeight As Decimal
        Property RequestNumber As String = ""
        Property ItemCode As String = ""
        Property ItemName As String = ""
        Property Thick As Decimal
        Property Width As Decimal
        Property Length As Decimal
        Property ItemSpecificationID As Integer
        Property ItemSpecificationName As String = ""
        Property ItemTypeID As Integer
        Property ItemTypeName As String = ""
        Property MaxTotalWeight As Decimal
    End Class
End Namespace