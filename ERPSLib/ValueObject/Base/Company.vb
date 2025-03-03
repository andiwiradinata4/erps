Namespace VO
    Public Class Company
        Inherits Common
        Property ID As Integer
        Property Name As String
        Property Address As String
        Property Address2 As String
        Property Country As String
        Property Province As String
        Property City As String
        Property SubDistrict As String
        Property Area As String
        Property DirectorName As String
        Property Warehouse As String
        Property PhoneNumber As String
        Property CompanyInitial As String
        Property StatusID As Integer
        Property NPWP As String

        Public Enum Values
            TBU = 1
            OKS = 2
        End Enum
    End Class
End Namespace

