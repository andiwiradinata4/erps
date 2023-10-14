Namespace BL
    Public Class ChartOfAccountAssign

        Public Shared Function ListData(ByVal intCOAID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ChartOfAccountAssign.ListData(sqlCon, Nothing, intCOAID)
            End Using
        End Function

        Public Shared Function SaveData(ByVal intCOAID As Integer, ByVal clsDataAll As List(Of VO.ChartOfAccountAssign)) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = SaveData(sqlCon, sqlTrans, intCOAID, clsDataAll)

                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intCOAID As Integer, ByVal clsDataAll As List(Of VO.ChartOfAccountAssign)) As Boolean
            Dim bolReturn As Boolean = False
            Try
                DL.ChartOfAccountAssign.DeleteData(sqlCon, sqlTrans, intCOAID)

                For Each clsItem As VO.ChartOfAccountAssign In clsDataAll
                    clsItem.ID = DL.ChartOfAccountAssign.GetMaxID(sqlCon, sqlTrans)
                    DL.ChartOfAccountAssign.SaveData(sqlCon, sqlTrans, clsItem)
                Next

                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Sub SaveDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String, _
                                      ByVal clsData As VO.ChartOfAccountAssign)
            BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.ChartOfAccountAssign.SaveData(sqlCon, Nothing, clsData)
            End Using
        End Sub

        Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
            BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.ChartOfAccountAssign.DeleteDataAll(sqlCon, Nothing)
            End Using
        End Sub

    End Class

End Namespace

