Namespace BL
    Public Class StatusModules

        Public Shared Function ListDataByStatusID(ByVal intStatusID As VO.Status.Values) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.StatusModules.ListDataByStatusID(sqlCon, Nothing, intStatusID)
            End Using
        End Function

        Public Shared Function ListDataByModulesID(ByVal intModulesID As VO.Modules.Values) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.StatusModules.ListDataByModulesID(sqlCon, Nothing, intModulesID)
            End Using
        End Function

        Public Shared Sub SaveDataByStatusID(ByVal clsDataAll() As VO.StatusModules)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.StatusModules.DeleteDataByStatusID(sqlCon, sqlTrans, clsDataAll(0).StatusID)

                    For Each clsItem As VO.StatusModules In clsDataAll
                        clsItem.ID = DL.StatusModules.GetMaxID(sqlCon, sqlTrans)
                        DL.StatusModules.SaveData(sqlCon, sqlTrans, clsItem)
                    Next

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub SaveDataByModulesID(ByVal clsDataAll() As VO.StatusModules)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.StatusModules.DeleteDataByModulesID(sqlCon, sqlTrans, clsDataAll(0).ModulesID)

                    For Each clsItem As VO.StatusModules In clsDataAll
                        clsItem.ID = DL.StatusModules.GetMaxID(sqlCon, sqlTrans)
                        DL.StatusModules.SaveData(sqlCon, sqlTrans, clsItem)
                    Next

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.StatusModules.DeleteDataAll()
        'End Sub

    End Class

End Namespace

