Namespace DL
    Public Class Migration

        Public Shared Function IsTableExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strTableName As String) As Boolean
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.Name " & vbNewLine &
                        "FROM sys.tables A " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   A.Name=@Name " & vbNewLine

                    .Parameters.Add("@Name", SqlDbType.VarChar).Value = strTableName
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolReturn = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolReturn
        End Function

        Public Shared Function IsColumnExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strTableName As String, ByVal strColumnName As String) As Boolean
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   C.Name " & vbNewLine &
                        "FROM sys.tables T " & vbNewLine &
                        "INNER JOIN sys.columns c ON " & vbNewLine &
                        "	T.object_id=C.object_id " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "	T.name=@TableName " & vbNewLine &
                        "	AND C.name=@ColumnName " & vbNewLine

                    .Parameters.Add("@TableName", SqlDbType.VarChar).Value = strTableName
                    .Parameters.Add("@ColumnName", SqlDbType.VarChar).Value = strColumnName
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolReturn = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolReturn
        End Function
        Public Shared Function IsIDExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal intID As Integer) As Boolean
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   Name " & vbNewLine &
                        "FROM sysMigration " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "	ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolReturn = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolReturn
        End Function

        Public Shared Function ExecuteScripts(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strSripts As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = strSripts
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal clsData As VO.Migration)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO sysMigration " & vbNewLine &
                    "	(ID, Name, Scripts, CreatedBy, LogBy)" & vbNewLine &
                    "VALUES " & vbNewLine &
                    "	(@ID, @Name, @Scripts, @LogBy, @LogBy)" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@Name", SqlDbType.VarChar).Value = clsData.Name
                .Parameters.Add("@Scripts", SqlDbType.VarChar).Value = clsData.Scripts
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

    End Class
End Namespace