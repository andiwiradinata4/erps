Namespace VO
    Public Class PaymentMode
        Inherits Common
        Property ID As Integer
        Property Code As String
        Property Name As String
        Property StatusID As Integer

        Enum Values
            All = 0
            BilyetGiro = 1
            BillPayment = 2
            Cash = 3
            Cheque = 4
            DocumentPresentationThroughBak = 5
            LetterOfCredit = 6
            TelegraphicTransfer = 7
        End Enum
    End Class
End Namespace