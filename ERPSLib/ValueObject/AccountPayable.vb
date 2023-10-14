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
        Property TotalAmount As Decimal
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
        Property Detail As New List(Of VO.AccountPayableDet)
        Property Save As VO.Save.Action

        Public Const PurchaseBalance As String = "PB"
        Public Const DownPaymentManual As String = "PDM"
        Public Const DownPayment As String = "PDP"
        Public Const ReceivePayment As String = "PI"

    End Class
End Namespace