Namespace BL
    Public Class UserConfig

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserConfig.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal clsData As VO.UserConfig) As String
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

        Public Shared Function GetDetail(ByVal strID As String) As VO.UserConfig
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserConfig.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Function GetDetailConfigData(ByVal strID As String) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.UserConfig = DL.UserConfig.GetDetail(sqlCon, Nothing, strID)
                Return IIf(clsData.ConfigData Is Nothing, "", clsData.ConfigData)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String)
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    DL.UserConfig.DeleteData(sqlCon, Nothing, strID)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
End Namespace