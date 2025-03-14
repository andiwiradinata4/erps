Namespace VO
    Public Class DeliveryLocation
        Inherits Common
        Property ID As Integer
        Property Description As String
        Property StatusID As Integer

        Public Overrides Function ToString() As String
            Return Description
        End Function
    End Class
End Namespace