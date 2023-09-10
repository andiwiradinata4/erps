Namespace VO
    Public Class StatusModules
        Inherits Common
        Property ID As Integer
        Property ModulesID As Integer
        Property StatusID As Integer

        Enum FilterBy
            StatusID = 0
            ModulesID = 1
        End Enum
    End Class
End Namespace

