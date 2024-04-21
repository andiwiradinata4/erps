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
        Property Detail As New List(Of VO.AccountPayableDet)
        Property ARAPDownPayment As New List(Of VO.ARAPDP)
        Property ARAPDownPaymentDetail As New List(Of VO.ARAPDPDet)
        Property Save As VO.Save.Action

        Public Const All As String = "AP"
        Public Const PurchaseBalance As String = "PB"
        Public Const DownPaymentManual As String = "PDM"
        Public Const DownPayment As String = "PDP"
        Public Const ReceivePayment As String = "PI"
        Public Const DownPaymentCutting As String = "CDP"
        Public Const ReceivePaymentCutting As String = "CI"
        Public Const DownPaymentTransport As String = "TDP"
        Public Const ReceivePaymentTransport As String = "TI"
    End Class
End Namespace