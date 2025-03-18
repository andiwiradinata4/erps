Namespace BL
    Public Class UserConfig

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserConfig.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal clsData As VO.UserConfig) As Integer
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    Dim bolNew As Boolean = True
                    If DL.UserConfig.DataExists(sqlCon, Nothing, clsData.ID) Then bolNew = False
                    DL.UserConfig.SaveData(sqlCon, Nothing, bolNew, clsData)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.UserConfig
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserConfig.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Function GetDetailConfigData(ByVal intID As Integer) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.UserConfig = DL.UserConfig.GetDetail(sqlCon, Nothing, intID)
                Return clsData.ConfigData
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    DL.UserConfig.DeleteData(sqlCon, Nothing, intID)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
End Namespace