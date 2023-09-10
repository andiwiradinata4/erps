Namespace VO
    Public Class PaymentReferences
        Inherits Common
        Property ID As Integer
        Property Name As String
        Property StatusID As Integer

        Enum Values
            All = 0
            Cash = 1
            TransferBank = 2
            Giro = 3
        End Enum
    End Class 
End Namespace

