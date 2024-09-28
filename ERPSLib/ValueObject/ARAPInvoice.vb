Namespace VO
    Public Class ARAPInvoice
        Inherits Common
        Property ID As String
        Property ParentID As String
        Property InvoiceNumber As String
        Property InvoiceDate As DateTime
        Property CoAID As Integer
        Property CoACode As String
        Property CoAName As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalAmount As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property StatusID As Integer
        Property ReferencesNumber As String
        Property TaxInvoiceNumber As String
        Property InvoiceNumberExternal As String
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property Remarks As String
        Property Save As VO.Save.Action
    End Class
End Namespace
