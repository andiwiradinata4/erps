Namespace VO
    Public Class ConfirmationClaim
        Inherits Common
        Property ID As String
        Property ClaimType As Integer
        Property ConfirmationClaimNumber As String
        Property ConfirmationClaimDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property ClaimID As String
        Property ReferencesNumber As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal
        Property TotalDPP As Decimal
        Property TotalPPN As Decimal
        Property TotalPPH As Decimal
        Property RoundingManual As Decimal
        Property Remarks As String
        Property StatusID As Integer
        Property SubmitBy As String
        Property SubmitDate As DateTime
        Property DPAmount As Decimal
        Property TotalPayment As Decimal
        Property IsUseSubItem As Boolean
        Property DPAmountPPN As Decimal
        Property DPAmountPPH As Decimal
        Property TotalPaymentPPN As Decimal
        Property TotalPaymentPPH As Decimal
        Property Detail As New List(Of VO.ConfirmationClaimDet)
        Property Save As VO.Save.Action

        Enum ClaimTypeValue
            All = 0
            Sales = 1
            Receive = 2
        End Enum

    End Class
End Namespace