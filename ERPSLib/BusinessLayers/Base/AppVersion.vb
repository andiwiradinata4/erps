Namespace BL
    Public Class AppVersion
        Public Shared Function GetDetail() As VO.AppVersion
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AppVersion.GetDetail(sqlCon, Nothing)
            End Using
        End Function
    End Class
End Namespace