Namespace DL
    Public Class ChartOfAccount

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal enumFilterGroup As VO.ChartOfAccount.FilterGroup,
                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                        ByVal intStatusID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT CAST(0 AS BIT) AS Pick, " & vbNewLine & _
                    "	COA.ID, COA.AccountGroupID, COAG.Name AS AccountGroupName, COAG.AliasName + ' ' + COAG.Name AS GroupAccount, COAT.Name AS TypeAccount, COA.Code, COA.Name, 	" & vbNewLine & _
                    "	COA.FirstBalance AS Balance, COA.StatusID, MS.Name AS StatusInfo, COA.CreatedBy, COA.CreatedDate, COA.LogBy, COA.LogDate, COA.LogInc, COA.Initial" & vbNewLine & _
                    "FROM mstChartOfAccount COA 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccountGroup COAG ON  	" & vbNewLine & _
                    "    COA.AccountGroupID=COAG.ID 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccountType COAT ON  	" & vbNewLine & _
                    "    COAG.COAType=COAT.ID 	" & vbNewLine & _
                    "INNER JOIN mstStatus MS ON  	" & vbNewLine & _
                    "    COA.StatusID=MS.ID 	" & vbNewLine

                If intCompanyID <> 0 And intProgramID <> 0 Then
                    .CommandText += _
                        "INNER JOIN mstChartOfAccountAssign COAA ON  	" & vbNewLine & _
                        "    COA.ID=COAA.COAID " & vbNewLine & _
                        "    AND COAA.CompanyID=@CompanyID " & vbNewLine & _
                        "    AND COAA.ProgramID=@ProgramID " & vbNewLine
                End If
                .CommandText += "WHERE 1=1 " & vbNewLine

                If enumFilterGroup = VO.ChartOfAccount.FilterGroup.CashOrBank Then
                    .CommandText += "AND COAG.ID IN (1,2)" & vbNewLine
                ElseIf enumFilterGroup = VO.ChartOfAccount.FilterGroup.Expense Then
                    .CommandText += "AND COAT.ID=6 " & vbNewLine
                ElseIf enumFilterGroup = VO.ChartOfAccount.FilterGroup.Stock Then
                    .CommandText += "AND COAG.ID=4 " & vbNewLine
                End If

                If intStatusID > 0 Then
                    .CommandText += "AND COA.StatusID=@StatusID" & vbNewLine
                End If

                .CommandText += _
                    "ORDER BY " & vbNewLine & _
                    "    COAT.ID, COA.Code ASC " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = <a>
SELECT [ID]
      ,[AccountGroupID]
      ,[Code]
      ,[Name]
      ,[FirstBalance]
      ,[FirstBalanceDate]
      ,[StatusID]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[LogBy]
      ,[LogDate]
      ,[LogInc]
      ,[Initial]
FROM [dbo].[mstChartOfAccount]
                    </a>.Value
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataHistory(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                               ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                               ByVal intCOAID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   BB.ReferencesID, BB.TransactionDate, COAG.COAType, COAP.ID, COAP.Name, BB.DebitAmount, BB.CreditAmount, BB.Remarks 	" & vbNewLine & _
                    "FROM traBukuBesar BB 	 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COAP ON 	 	" & vbNewLine & _
                    "   BB.COAIDParent=COAP.ID 	 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccountGroup COAG ON 	 	" & vbNewLine & _
                    "   COAP.AccountGroupID=COAG.ID 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "	BB.ProgramID=@ProgramID 	" & vbNewLine & _
                    "	AND BB.CompanyID=@CompanyID 	" & vbNewLine & _
                    "	AND BB.TransactionDate>=@DateFrom AND BB.TransactionDate<=@DateTo " & vbNewLine & _
                    "	AND BB.COAIDParent=@COAID	" & vbNewLine & _
                    "ORDER BY BB.ReferencesID ASC	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom.Date
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
                .Parameters.Add("@COAID", SqlDbType.Int).Value = intCOAID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.ChartOfAccount)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                       "INSERT INTO mstChartOfAccount " & vbNewLine & _
                       "    (ID, AccountGroupID, Code, Name, FirstBalance, FirstBalanceDate, StatusID,   " & vbNewLine & _
                       "      CreatedBy, CreatedDate, LogBy, LogDate, Initial)   " & vbNewLine & _
                       "VALUES " & vbNewLine & _
                       "    (@ID, @AccountGroupID, @Code, @Name, @FirstBalance, @FirstBalanceDate, @StatusID,   " & vbNewLine & _
                       "      @LogBy, GETDATE(), @LogBy, GETDATE(), @Initial)  " & vbNewLine
                Else
                    .CommandText = _
                    "UPDATE mstChartOfAccount SET " & vbNewLine & _
                    "    AccountGroupID=@AccountGroupID, " & vbNewLine & _
                    "    Code=@Code, " & vbNewLine & _
                    "    Name=@Name, " & vbNewLine & _
                    "    FirstBalance=@FirstBalance, " & vbNewLine & _
                    "    FirstBalanceDate=@FirstBalanceDate, " & vbNewLine & _
                    "    StatusID=@StatusID, " & vbNewLine & _
                    "    LogInc=LogInc+1, " & vbNewLine & _
                    "    LogBy=@LogBy, " & vbNewLine & _
                    "    LogDate=GETDATE(), " & vbNewLine & _
                    "    Initial=@Initial " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@AccountGroupID", SqlDbType.Int).Value = clsData.AccountGroupID
                .Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = clsData.Code
                .Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = clsData.Name
                .Parameters.Add("@FirstBalance", SqlDbType.Decimal).Value = clsData.FirstBalance
                .Parameters.Add("@FirstBalanceDate", SqlDbType.DateTime).Value = clsData.FirstBalanceDate
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@Initial", SqlDbType.VarChar, 10).Value = clsData.Initial
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                      ByVal clsData As VO.ChartOfAccount)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "INSERT INTO mstChartOfAccount " & vbNewLine & _
                   "    (ID, AccountGroupID, Code, Name, FirstBalance, FirstBalanceDate, StatusID,   " & vbNewLine & _
                   "     CreatedBy, CreatedDate, LogBy, LogDate, LogInc, Initial)   " & vbNewLine & _
                   "VALUES " & vbNewLine & _
                   "    (@ID, @AccountGroupID, @Code, @Name, @FirstBalance, @FirstBalanceDate, @StatusID,   " & vbNewLine & _
                   "     @CreatedBy, @CreatedDate, @LogBy, @LogDate, @LogInc, @Initial)  " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@AccountGroupID", SqlDbType.Int).Value = clsData.AccountGroupID
                .Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = clsData.Code
                .Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = clsData.Name
                .Parameters.Add("@FirstBalance", SqlDbType.Decimal).Value = clsData.FirstBalance
                .Parameters.Add("@FirstBalanceDate", SqlDbType.DateTime).Value = clsData.FirstBalanceDate
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = clsData.CreatedBy
                .Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = clsData.CreatedDate
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@LogDate", SqlDbType.DateTime).Value = clsData.LogDate
                .Parameters.Add("@LogInc", SqlDbType.Int).Value = clsData.LogInc
                .Parameters.Add("@Initial", SqlDbType.VarChar, 10).Value = clsData.Initial
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal intID As Integer) As VO.ChartOfAccount
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ChartOfAccount
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                       "SELECT TOP 1 " & vbNewLine & _
                       "    A.ID, A.AccountGroupID, A.Code, A.Name, A.FirstBalance, A.FirstBalanceDate, A.StatusID,   " & vbNewLine & _
                       "    A.LogBy, A.LogDate, A.Initial  " & vbNewLine & _
                       "FROM mstChartOfAccount A " & vbNewLine & _
                       "WHERE " & vbNewLine & _
                       "    ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.AccountGroupID = .Item("AccountGroupID")
                        voReturn.Code = .Item("Code")
                        voReturn.Name = .Item("Name")
                        voReturn.FirstBalance = .Item("FirstBalance")
                        voReturn.FirstBalanceDate = .Item("FirstBalanceDate")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.Initial = .Item("Initial")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strCode As String) As VO.ChartOfAccount
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ChartOfAccount
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                       "SELECT TOP 1 " & vbNewLine & _
                       "    A.ID, A.AccountGroupID, A.Code, A.Name, A.FirstBalance, A.FirstBalanceDate, A.StatusID,   " & vbNewLine & _
                       "    A.LogBy, A.LogDate, A.Initial  " & vbNewLine & _
                       "FROM mstChartOfAccount A " & vbNewLine & _
                       "WHERE " & vbNewLine & _
                       "    Code=@Code " & vbNewLine

                    .Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = strCode
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.AccountGroupID = .Item("AccountGroupID")
                        voReturn.Code = .Item("Code")
                        voReturn.Name = .Item("Name")
                        voReturn.FirstBalance = .Item("FirstBalance")
                        voReturn.FirstBalanceDate = .Item("FirstBalanceDate")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.Initial = .Item("Initial")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal intID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE mstChartOfAccount " & vbNewLine & _
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
                    "DELETE mstChartOfAccount " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine & _
                        "FROM mstChartOfAccount " & vbNewLine

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
                                          ByVal intID As Integer) As Boolean
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
                        "FROM mstChartOfAccount " & vbNewLine & _
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

        Public Shared Function CodeExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strCode As String, ByVal intID As Integer) As Boolean
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
                        "FROM mstChartOfAccount " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   Code=@Code " & vbNewLine & _
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = strCode
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

        Public Shared Function GetStatusID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal intID As Integer) As Integer
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
                        "FROM mstChartOfAccount " & vbNewLine & _
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

