Namespace VO
    Public Class ARAPItem
        Property ID As String
        Property ParentID As String
        Property ReferencesID As String
        Property ReferencesDetailID As String
        Property OrderNumberSupplier As String
        Property ItemID As Integer
        Property Amount As Decimal
        Property PPN As Decimal
        Property PPH As Decimal
        Property DPAmount As Decimal
        Property Rounding As Decimal
        Property LevelItem As Integer
        Property ReferencesParentID As String
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property InvoiceQuantity As Decimal
        Property InvoiceWeight As Decimal
        Property InvoiceTotalWeight As Decimal
        Property TotalInvoiceAmount As Decimal
        Property TotalDPPInvoiceAmount As Decimal
        Property TotalPPNInvoiceAmount As Decimal
        Property TotalPPHInvoiceAmount As Decimal
        Property Percentage As Decimal
        Property PPNPercentage As Decimal
        Property PPHPercentage As Decimal
        Property SplitFrom As String = ""
        Property ReceiveDate As DateTime = Today
        Property InvoiceDate As DateTime = Today
        Property InvoiceNumberBP As String = ""
    End Class
End Namespace