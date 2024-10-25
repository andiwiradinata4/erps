Namespace VO
    Public Class AccountReceivable
        Inherits Common
        Property ID As String
        Property ARNumber As String
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property CoAIDOfIncomePayment As Integer
        Property CoACodeOfIncomePayment As String
        Property CoANameOfIncomePayment As String
        Property Modules As String
        Property ReferencesID As String
        Property ReferencesNote As String
        Property ARDate As DateTime
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
        Property IsDP As Boolean
        Property DPAmount As Decimal
        Property ReceiveAmount As Decimal
        Property TotalAmountUsed As Decimal
        Property JournalIDInvoice As String
        Property CompanyBankAccount1 As Integer
        Property CompanyBankAccount2 As Integer
        Property OtherExpenses As Decimal
        Property InvoiceNumberBP As String
        Property CompanyBankAccountID1 As Integer
        Property CompanyBankAccountID2 As Integer
        Property IsUseSubItem As Boolean
        Property Detail As New List(Of VO.AccountReceivableDet)
        Property ARAPDownPayment As New List(Of VO.ARAPDP)
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
        Property PPNPercentage As Decimal
        Property PPHPercentage As Decimal
        Property TotalInvoiceAmount As Decimal
        Property TotalDPPInvoiceAmount As Decimal
        Property TotalPPNInvoiceAmount As Decimal
        Property TotalPPHInvoiceAmount As Decimal
        Property ReferencesNumber As String
        Property IsFullDP As Boolean

        Public Const All As String = "AR"
        Public Const SalesBalance As String = "SB"
        Public Const DownPaymentManual As String = "SDM"
        Public Const DownPayment As String = "SDP"
        Public Const ReceivePayment As String = "SI"
        Public Const DownPaymentOrderRequest As String = "ODP"
        Public Const DownPaymentOrderRequestVer2 As String = "DP2"
        Public Const ReceivePaymentOrderRequest As String = "SI2"
        Public Const ReceivePaymentOrderRequestVer2 As String = "PI2"
        Public Const ReceivePaymentSalesReturn As String = "SR"
        Public Const ReceivePaymentClaimPOCutting As String = "CPC"
    End Class
End Namespace