Namespace DL
    Public Class TransporterPriceType

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "     A.ID, A.Description, A.StatusID, B.Name AS StatusInfo,  " & vbNewLine & _
                    "     A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine & _
                    "FROM mstTransporterPriceType A " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "    A.StatusID=B.ID " & vbNewLine

            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataForCombo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "     A.ID, A.Description " & vbNewLine & _
                   "FROM mstTransporterPriceType A " & vbNewLine & _
                   "WHERE A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Active
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.TransporterPriceType)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO mstTransporterPriceType " & vbNewLine & _
                        "     (ID, Description, StatusID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "     (@ID, @Description, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine


                Else
                    .CommandText = _
                        "UPDATE mstTransporterPriceType SET " & vbNewLine & _
                        "    Description=@Description, " & vbNewLine & _
                        "    StatusID=@StatusID, " & vbNewLine & _
                        "    LogBy=@LogBy, " & vbNewLine & _
                        "    LogDate=GETDATE(), " & vbNewLine & _
                        "    LogInc=LogInc+1 " & vbNewLine & _
                        "WHERE   " & vbNewLine & _
                        "    ID=@ID " & vbNewLine

                End If
                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = clsData.Description
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal intID As Integer) As VO.TransporterPriceType
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.TransporterPriceType
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "     A.ID, A.Description, A.StatusID, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine & _
                        "FROM mstTransporterPriceType A " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "    ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.Description = .Item("Description")
                        voReturn.StatusID = .Item("StatusID")
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
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE mstTransporterPriceType " & vbNewLine & _
                    "SET StatusID=@StatusID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.InActive
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
                    "DELETE mstTransporterPriceType " & vbNewLine

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
                        "FROM mstTransporterPriceType " & vbNewLine
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

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strDescription As String, ByVal intID As Integer) As Boolean
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
                        "FROM mstTransporterPriceType " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   Description=@Description " & vbNewLine & _
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = strDescription
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

        Public Shared Function GetStatusID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = VO.Status.Values.Active
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   StatusID " & vbNewLine & _
                        "FROM mstTransporterPriceType " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("StatusID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

    End Class
End Namespace