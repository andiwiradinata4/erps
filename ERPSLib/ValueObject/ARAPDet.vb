Namespace VO
    Public Class ARAPDet
        Property ID As String
        Property ARAPID As String
        Property InvoiceID As String
        Property Amount As Decimal
        Property PPN As Decimal
        Property PPH As Decimal
        Property Remarks As String
        Property DPAmount As Decimal
        Property Rounding As Decimal
        Property LevelItem As Integer
        Property ReferencesParentID As String
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeight As Decimal
        Property ReceiveDate As DateTime = Today.Date
        Property InvoiceDate As DateTime = Today.Date
        Property InvoiceNumberBP As String = ""
    End Class
End Namespace