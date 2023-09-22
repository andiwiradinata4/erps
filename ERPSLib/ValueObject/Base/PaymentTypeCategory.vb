Namespace VO
    Public Class PaymentTypeCategory
        Inherits Common
        Property ID As Integer
        Property Code As String
        Property Name As String
        Property StatusID As Integer

        Enum Values
            All = 0
            DP = 1
            Receive = 2
            Retention = 3
        End Enum
    End Class
End Namespace