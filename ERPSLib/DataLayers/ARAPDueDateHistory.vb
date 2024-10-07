Namespace DL
 
    Public Class ARAPDueDateHistory
 
        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strParentID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT " & vbNewLine &
"	A.ID, A.ParentID, A.DueDate, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, " & vbNewLine &
"	A.LogDate, A.LogInc" & vbNewLine &
"FROM traARAPDueDateHistory A" & vbNewLine &
"WHERE " & vbNewLine &
"	ParentID=@ParentID " & vbNewLine &
"ORDER BY A.CreatedDate " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew as Boolean, ByVal clsData As VO.ARAPDueDateHistory)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traARAPDueDateHistory" & vbNewLine & _
"	(ID, ParentID, DueDate, Remarks, CreatedBy, CreatedDate, LogBy, " & vbNewLine & _
"	 LogDate)" & vbNewLine & _
"VALUES " & vbNewLine & _
"	(@ID, @ParentID, @DueDate, @Remarks, @LogBy, GETDATE(), @LogBy, " & vbNewLine & _
"	 GETDATE())" & vbNewLine
                Else
                    .CommandText =
"UPDATE traARAPDueDateHistory SET " & vbNewLine & _
"	ParentID=@ParentID, " & vbNewLine & _
"	DueDate=@DueDate, " & vbNewLine & _
"	Remarks=@Remarks, " & vbNewLine & _
"	LogBy=@LogBy, " & vbNewLine & _
"	LogDate=GETDATE(), " & vbNewLine & _
"	LogInc=LogInc+1" & vbNewLine & _
"WHERE" & vbNewLine & _
"	ID=@ID" & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.varchar, 100).Value = clsData.ParentID
                .Parameters.Add("@DueDate", SqlDbType.datetime).Value = clsData.DueDate
                .Parameters.Add("@Remarks", SqlDbType.varchar, 250).Value = clsData.Remarks
                .Parameters.Add("@LogBy", SqlDbType.varchar, 20).Value = clsData.LogBy

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.ARAPDueDateHistory
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ARAPDueDateHistory
            Try
                With sqlcmdExecute
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText =
"SELECT TOP 1 " & vbNewLine & _
"	A.ID, A.ParentID, A.DueDate, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, " & vbNewLine & _
"	A.LogDate, A.LogInc" & vbNewLine & _
"FROM traARAPDueDateHistory A" & vbNewLine & _
"WHERE" & vbNewLine & _
"	ID=@ID" & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID

                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        voReturn.ID = .Item("ID")
                        voReturn.ParentID = .Item("ParentID")
                        voReturn.DueDate = .Item("DueDate")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return voReturn 
        End Function 

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"DELETE FROM traARAPDueDateHistory" & vbNewLine & _
"WHERE" & vbNewLine & _
"	ID=@ID" & vbNewLine
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans) 
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strNewID As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 3),'000') AS ID " & vbNewLine &
                        "FROM traARAPDueDateHistory " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False 
            Try 
                With sqlcmdExecute 
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText =
"SELECT TOP 1" & vbNewLine & _
"	ID" & vbNewLine & _
"FROM traARAPDueDateHistory" & vbNewLine & _
"WHERE " & vbNewLine & _
"	ID=@ID" & vbNewLine
                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID

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
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return bolExists 
        End Function 

    End Class 

End Namespace

