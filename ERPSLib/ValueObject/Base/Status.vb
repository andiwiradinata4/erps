Namespace VO
    Public Class Status
        Inherits Common
        Property ID As Integer
        Property Name As String

        Enum Values
            All = 0
            Active = 1
            InActive = 2
            Draft = 3
            Submit = 4
            Approved = 5
            Deleted = 6
            Payment = 7
        End Enum
    End Class
End Namespace

