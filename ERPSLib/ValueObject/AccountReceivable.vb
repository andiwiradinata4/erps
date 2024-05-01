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
        Property Detail As New List(Of VO.AccountReceivableDet)
        Property ARAPDownPayment As New List(Of VO.ARAPDP)
        Property ARAPItem As New List(Of VO.ARAPItem)
        Property Save As VO.Save.Action

        Public Const All As String = "AR"
        Public Const SalesBalance As String = "SB"
        Public Const DownPaymentManual As String = "SDM"
        Public Const DownPayment As String = "SDP"
        Public Const ReceivePayment As String = "SI"
    End Class
End Namespace