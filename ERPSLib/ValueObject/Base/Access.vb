Namespace VO
    Public Class Access
        Inherits Common
        Property ID As Integer
        Property Name As String

        Enum Values
            All = 0
            ViewAccess = 1
            NewAccess = 2
            EditAccess = 3
            DeleteAccess = 4
            HistoryAccess = 5
            PrintReportAccess = 6
            ExportReportAccess = 7
            ChangePasswordAccess = 8
            ResetPasswordAccess = 9
            SetupUserAccessAccess = 10
            DuplicateUserAccessAccess = 11
            BankInfoAccess = 12
            SubmitAccess = 13
            CancelSubmitAccess = 14
            ApproveAccess = 15
            CancelApproveAccess = 16
            ExportExcelAccess = 17
            AssignAccess = 18
            PaymentAccess = 19
            TaxInvoiceNumberAccess = 20
            CancelPaymentAccess = 21
        End Enum

    End Class 
End Namespace

