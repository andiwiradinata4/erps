Namespace VO
    Public Class VoucherType
        Property ID As Integer
        Property Name As String
        Property Remarks As String
        Property CreatedBy As String
        Property CreatedDate As DateTime

        Public Enum Values
            All = 0
            BankIn = 1
            BankOut = 2
        End Enum
    End Class
End Namespace