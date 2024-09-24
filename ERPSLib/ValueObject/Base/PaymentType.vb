Namespace VO
    Public Class PaymentType
        Inherits Common
        Property ID As Integer
        Property Code As String
        Property Name As String
        Property PaymentTypeCategoryID As Integer
        Property PaymentTypeCategoryName As String
        Property StatusID As Integer

        Enum Values
            CBD = 12
            TT30Days = 13
        End Enum

    End Class
End Namespace

