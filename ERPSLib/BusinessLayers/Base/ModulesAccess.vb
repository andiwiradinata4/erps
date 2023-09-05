Namespace BL
    Public Class ModulesAccess
        
        Public Shared Function ListDataByAccessID(ByVal intAccessID As VO.Access.Values) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ModulesAccess.ListDataByAccessID(sqlCon, Nothing, intAccessID)
            End Using
        End Function

        Public Shared Function ListDataByModulesID(ByVal intModulesID As VO.Modules.Values) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ModulesAccess.ListDataByModulesID(sqlCon, Nothing, intModulesID)
            End Using
        End Function

        Public Shared Sub SaveDataByAccessID(ByVal clsDataAll() As VO.ModulesAccess)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.ModulesAccess.DeleteDataByAccessID(sqlCon, sqlTrans, clsDataAll(0).AccessID)

                    For Each clsItem As VO.ModulesAccess In clsDataAll
                        clsItem.ID = DL.ModulesAccess.GetMaxID(sqlCon, sqlTrans)
                        DL.ModulesAccess.SaveData(sqlCon, sqlTrans, clsItem)
                    Next
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub SaveDataByModulesID(ByVal clsDataAll() As VO.ModulesAccess)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.ModulesAccess.DeleteDataByModulesID(sqlCon, sqlTrans, clsDataAll(0).ModulesID)

                    For Each clsItem As VO.ModulesAccess In clsDataAll
                        clsItem.ID = DL.ModulesAccess.GetMaxID(sqlCon, sqlTrans)
                        DL.ModulesAccess.SaveData(sqlCon, sqlTrans, clsItem)
                    Next

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub
        
        'Public Shared Sub SaveDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String, _
        '                              ByVal clsData As VO.ModulesAccess)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.ModulesAccess.SaveData(clsData)
        'End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.ModulesAccess.DeleteDataAll()
        'End Sub

    End Class 

End Namespace

