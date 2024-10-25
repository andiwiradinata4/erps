Namespace VO
    Public Class ARAP
        Inherits Common
        Property ID As String
        Property TransNumber As String
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property CoAID As Integer
        Property CoACode As String
        Property CoAName As String
        Property Modules As String
        Property ReferencesID As String
        Property ReferencesNumber As String
        Property ReferencesNote As String
        Property TransDate As DateTime
        Property DueDateValue As Integer
        Property DueDate As DateTime
        Property Percentage As Decimal
        Property TotalAmount As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property PaymentBy As String
        Property PaymentDate As DateTime
        Property TaxInvoiceNumber As String
        Property IsClosedPeriod As Boolean
        Property ClosedPeriodBy As String
        Property ClosedPeriodDate As DateTime
        Property Remarks As String
        Property StatusID As Integer
        Property IsDP As Boolean
        Property DPAmount As Decimal
        Property ReceiveAmount As Decimal
        Property TotalAmountUsed As Decimal
        Property CompanyBankAccountID1 As Integer
        Property CompanyBankAccountID2 As Integer
        Property InvoiceNumberSupplier As String
        Property IsUseSubItem As Boolean
        Property Detail As New List(Of VO.ARAPDet)
        Property DownPayment As New List(Of VO.ARAPDP)
        Property DownPaymentDetail As New List(Of VO.ARAPDPDet)
        Property DetailItem As New List(Of VO.ARAPItem)
        Property Save As VO.Save.Action
        Property ARAPType As VO.ARAP.ARAPTypeValue
        Property PaymentTerm1 As String
        Property PaymentTerm2 As String
        Property PaymentTerm3 As String
        Property PaymentTerm4 As String
        Property PaymentTerm5 As String
        Property PaymentTerm6 As String
        Property PaymentTerm7 As String
        Property PaymentTerm8 As String
        Property PaymentTerm9 As String
        Property PaymentTerm10 As String
        Property PaymentTypeID As Integer
        Property PPNPercentage As Decimal
        Property PPHPercentage As Decimal
        Property TotalInvoiceAmount As Decimal
        Property TotalDPPInvoiceAmount As Decimal
        Property TotalPPNInvoiceAmount As Decimal
        Property TotalPPHInvoiceAmount As Decimal
        Property IsFullDP As Boolean
        Enum ARAPTypeValue
            All
            Sales
            Purchase
        End Enum

    End Class
End Namespace