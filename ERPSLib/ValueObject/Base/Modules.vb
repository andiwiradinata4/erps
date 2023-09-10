Namespace VO
    Public Class Modules
        Inherits Common
        Property ID As Integer
        Property Name As String
        Property Remarks As String

        Enum Values
            All = 0

            '# Master
            MasterProgram = 1
            MasterStatus = 2
            MasterModule = 3
            MasterAccess = 4
            MasterCompany = 5
            MasterUser = 6
            MasterUOM = 7
            MasterItemType = 8
            MasterItemSpecification = 9
            MasterItem = 10
            MasterBusinessPartner = 11
            MasterPaymentType = 12
            MasterPaymentTerm = 13

        End Enum

    End Class
End Namespace

