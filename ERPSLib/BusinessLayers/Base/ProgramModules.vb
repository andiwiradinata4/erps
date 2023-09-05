Namespace BL
    Public Class ProgramModules

        Public Shared Function ListDataByProgramID(ByVal intProgramID As VO.Program.Values) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ProgramModules.ListDataByProgramID(sqlCon, Nothing, intProgramID)
            End Using
        End Function

        Public Shared Function ListDataByModulesID(ByVal intModulesID As VO.Modules.Values) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ProgramModules.ListDataByModulesID(sqlCon, Nothing, intModulesID)
            End Using
        End Function

        Public Shared Sub SaveDataByProgramID(ByVal clsDataAll() As VO.ProgramModules)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.ProgramModules.DeleteDataByProgramID(sqlCon, sqlTrans, clsDataAll(0).ProgramID)

                    For Each clsItem As VO.ProgramModules In clsDataAll
                        clsItem.ID = DL.ProgramModules.GetMaxID(sqlCon, sqlTrans)
                        DL.ProgramModules.SaveData(sqlCon, sqlTrans, clsItem)
                    Next

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub SaveDataByModulesID(ByVal clsDataAll() As VO.ProgramModules)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.ProgramModules.DeleteDataByModulesID(sqlCon, sqlTrans, clsDataAll(0).ModulesID)

                    For Each clsItem As VO.ProgramModules In clsDataAll
                        clsItem.ID = DL.ProgramModules.GetMaxID(sqlCon, sqlTrans)
                        DL.ProgramModules.SaveData(sqlCon, sqlTrans, clsItem)
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
        '    DL.ProgramModules.DeleteDataAll()
        'End Sub

    End Class

End Namespace

