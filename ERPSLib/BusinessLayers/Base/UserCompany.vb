Namespace BL
    Public Class UserCompany

        Public Shared Function ListData(ByVal intID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserCompany.ListData(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Function ListDataByUserID(ByVal strUserID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserCompany.ListDataByUserID(sqlCon, Nothing, strUserID)
            End Using
        End Function

        Public Shared Function SaveData(ByVal strUserID As String, ByVal clsDataAll() As VO.UserCompany) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.UserCompany.DeleteDataByUserID(sqlCon, sqlTrans, strUserID)

                    For Each clsItem As VO.UserCompany In clsDataAll
                        clsItem.ID = DL.UserCompany.GetMaxID(sqlCon, sqlTrans)
                        DL.UserCompany.SaveData(sqlCon, sqlTrans, clsItem)
                    Next

                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            
            Return bolReturn
        End Function

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.UserCompany.DeleteDataAll()
        'End Sub

    End Class

End Namespace

