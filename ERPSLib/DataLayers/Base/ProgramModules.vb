Namespace DL

    Public Class ProgramModules

        Public Shared Function ListDataByProgramID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intProgramID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "     A.ID, A.ModulesID, A.ProgramID, B.Name AS ModulesName " & vbNewLine & _
                   "FROM mstProgramModules A " & vbNewLine & _
                   "INNER JOIN mstModules B ON " & vbNewLine & _
                   "    A.ModulesID=B.ID " & vbNewLine & _
                   "WHERE  " & vbNewLine & _
                    "    A.ProgramID=@ProgramID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataByModulesID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intModulesID As VO.Modules.Values) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "     A.ID, A.ModulesID, A.ProgramID, B.Name AS ProgramName  " & vbNewLine & _
                   "FROM mstProgramModules A " & vbNewLine & _
                   "INNER JOIN mstProgram B ON " & vbNewLine & _
                   "    A.ProgramID=B.ID " & vbNewLine & _
                   "WHERE  " & vbNewLine & _
                   "    A.ModulesID=@ModulesID "

                .Parameters.Add("@ModulesID", SqlDbType.Int).Value = intModulesID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.ProgramModules)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "INSERT INTO mstProgramModules " & vbNewLine & _
                   "    (ID, ModulesID, ProgramID)   " & vbNewLine & _
                   "VALUES " & vbNewLine & _
                   "    (@ID, @ModulesID, @ProgramID)  " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@ModulesID", SqlDbType.Int).Value = clsData.ModulesID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As VO.ProgramModules
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ProgramModules
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                       "SELECT TOP 1 " & vbNewLine & _
                       "    A.ID, A.ModulesID, A.ProgramID  " & vbNewLine & _
                       "FROM mstProgramModules A " & vbNewLine & _
                       "WHERE " & vbNewLine & _
                       "    ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ModulesID = .Item("ModulesID")
                        voReturn.ProgramID = .Item("ProgramID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteDataByProgramID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intProgramID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM mstProgramModules " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   ProgramID=@ProgramID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataByModulesID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intModulesID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM mstProgramModules " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   ModulesID=@ModulesID " & vbNewLine

                .Parameters.Add("@ModulesID", SqlDbType.Int).Value = intModulesID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE mstProgramModules " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 1
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine & _
                        "FROM mstProgramModules " & vbNewLine
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID") + 1
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID " & vbNewLine & _
                        "FROM mstProgramModules " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolExists = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolExists
        End Function

    End Class

End Namespace

