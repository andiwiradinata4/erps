Namespace BL
    Public Class JournalPost

        Public Shared Function ListDataAll() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.JournalPost.ListDataAll(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal clsData As VO.JournalPost) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    DL.JournalPost.SaveData(sqlCon, Nothing, Not DL.JournalPost.DataExists(sqlCon, Nothing), clsData)
                End Using
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function GetDetail(ByVal intProgramID As Integer) As VO.JournalPost
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.JournalPost.GetDetail(sqlCon, Nothing, intProgramID)
            End Using
        End Function

        'Public Shared Sub SaveDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String, _
        '                              ByVal clsData As VO.JournalPost)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.JournalPost.SaveDataAll(clsData)
        'End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.JournalPost.DeleteDataAll()
        'End Sub

    End Class

End Namespace

