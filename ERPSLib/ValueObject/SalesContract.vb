Namespace VO
    Public Class SalesContract
        Inherits Common
        Property ID As String
        Property SCNumber As String
        Property SCDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property DeliveryPeriodFrom As DateTime
        Property DeliveryPeriodTo As DateTime
        Property AllowanceProduction As Decimal
        Property Franco As String
        Property DelegationSeller As String
        Property DelegationPositionSeller As String
        Property DelegationBuyer As String
        Property DelegationPositionBuyer As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property GrandTotal As Decimal
        Property RoundingManual As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property CompanyBankAccountID As Integer
        Property AccountName As String
        Property BankName As String
        Property AccountNumber As String
        Property CurrencyBank As String
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property ApproveL1 As String
        Property ApproveL1Date As DateTime
        Property ApprovedBy As String
        Property ApprovedDate As DateTime
        Property DPAmount As Decimal
        Property ReceiveAmount As Decimal
        Property BPLocationID As Integer
        Property BPLocationAddress As String
        Property IsUseSubItem As Boolean
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property ReceiveAmountPPN As Decimal
        Property ReceiveAmountPPH As Decimal
        Property Detail As List(Of VO.SalesContractDet)
        Property DetailConfirmationOrder As List(Of VO.SalesContractDetConfirmationOrder)
        Property PaymentTerm As List(Of VO.SalesContractPaymentTerm)
        Property Save As VO.Save.Action
    End Class
End Namespace