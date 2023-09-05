Namespace BL
    Public Class UserAccess

        Public Shared Function ListData(ByVal strUserID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserAccess.ListData(sqlCon, Nothing, strUserID)
            End Using
        End Function

        Public Shared Function ListDataByModulesIDAndProgramID(ByVal strUserID As String, ByVal intProgramID As Integer, ByVal intModulesID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim dtData As DataTable = DL.UserAccess.ListDataByModulesIDAndProgramID(sqlCon, Nothing, strUserID, intProgramID, intModulesID)
                dtData.Merge(DL.UserAccess.ListDataOutstandingByModulesIDAndProgramID(sqlCon, Nothing, strUserID, intProgramID, intModulesID))
                Return dtData
            End Using
        End Function

        Public Shared Function ListDataWithCompany(ByVal strUserID As String, ByVal intCompanyID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UserAccess.ListDataWithCompany(sqlCon, Nothing, strUserID, intCompanyID)
            End Using
        End Function

        Public Shared Function SaveData(ByVal clsDataAll() As VO.UserAccess, ByVal intProgramID As Integer, ByVal intModulesID As Integer, ByVal strUserID As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.UserAccess.DeleteDataByModulesIDAndProgramID(sqlCon, sqlTrans, intProgramID, intModulesID, strUserID)

                    For Each clsData As VO.UserAccess In clsDataAll
                        clsData.ID = DL.UserAccess.GetMaxID(sqlCon, sqlTrans)
                        DL.UserAccess.SaveData(sqlCon, sqlTrans, clsData)
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
        '    DL.UserAccess.DeleteDataAll()
        'End Sub

        Public Shared Function DuplicateUserAccess(ByVal strBaseUserID As String, ByVal strNewUserID As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtData As DataTable = DL.UserAccess.ListData(sqlCon, sqlTrans, strBaseUserID)

                    DL.UserAccess.DeleteDataByUserID(sqlCon, sqlTrans, strNewUserID)

                    Dim clsData As New VO.UserAccess
                    For Each dr As DataRow In dtData.Rows
                        clsData = New VO.UserAccess
                        clsData.ID = DL.UserAccess.GetMaxID(sqlCon, sqlTrans)
                        clsData.UserID = strNewUserID
                        clsData.ProgramID = dr.Item("ProgramID")
                        clsData.ModulesID = dr.Item("ModulesID")
                        clsData.AccessID = dr.Item("AccessID")
                        DL.UserAccess.SaveData(sqlCon, sqlTrans, clsData)
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

        Public Shared Function IsCanAccess(ByVal strUserID As String, ByVal intProgramID As Integer, ByVal intModulesID As Integer, ByVal intAccessID As Integer) As Boolean
            BL.Server.ServerDefault()
            Dim bolReturn As Boolean = False

            If UI.usUserApp.IsSuperUser Then
                bolReturn = True
            Else
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    bolReturn = DL.UserAccess.IsCanAccess(sqlCon, Nothing, strUserID, intProgramID, intModulesID, intAccessID)
                End Using
            End If

            Return bolReturn
        End Function

    End Class

End Namespace

