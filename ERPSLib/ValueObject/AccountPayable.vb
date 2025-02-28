Namespace VO
    Public Class AccountPayable
        Inherits Common
        Property ID As String
        Property APNumber As String
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property CoAIDOfOutgoingPayment As Integer
        Property CoACodeOfOutgoingPayment As String
        Property CoANameOfOutgoingPayment As String
        Property Modules As String
        Property ReferencesID As String
        Property ReferencesNote As String
        Property APDate As DateTime
        Property DueDateValue As Integer
        Property DueDate As DateTime
        Property TotalAmount As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property Percentage As Decimal
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
        Property IsDP As Decimal
        Property DPAmount As Decimal
        Property ReceiveAmount As Decimal
        Property TotalAmountUsed As Decimal
        Property JournalIDInvoice As String
        Property CompanyBankAccount1 As Integer
        Property CompanyBankAccount2 As Integer
        Property OtherExpenses As Decimal
        Property InvoiceNumberBP As String
        Property IsUseSubItem As Boolean
        Property Detail As New List(Of VO.AccountPayableDet)
        Property DetailRemarks As New List(Of VO.ARAPRemarks)
        Property ARAPDownPayment As New List(Of VO.ARAPDP)
        Property ARAPDownPaymentDetail As New List(Of VO.ARAPDPDet)
        Property ARAPItem As New List(Of VO.ARAPItem)
        Property Save As VO.Save.Action
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
        Property ReferencesNumber As String
        Property IsFullDP As Boolean
        Property IsGenerate As Boolean
        Property BPBankAccountID As Integer
        Property BPBankAccountBank As String
        Property BPBankAccountNumber As String
        Property InvoiceDateBP As DateTime
        Property ReceiveDateInvoice As DateTime

        Public Const All As String = "AP"
        Public Const PurchaseBalance As String = "PB"
        Public Const DownPaymentManual As String = "PDM"
        Public Const DownPayment As String = "PDP"
        Public Const ReceivePayment As String = "PI"
        Public Const DownPaymentCutting As String = "CDP"
        Public Const ReceivePaymentCutting As String = "CI"
        Public Const DownPaymentTransport As String = "TDP"
        Public Const ReceivePaymentTransport As String = "TI"
        Public Const ReceivePaymentTransportSalesReturn As String = "TI2"
        Public Const ReceivePaymentClaimSales As String = "CS1"
    End Class
End Namespace