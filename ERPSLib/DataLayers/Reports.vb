Namespace DL
    Public Class Reports

        Public Shared Function GetBukuBesarLastBalance(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal dtmDateFrom As DateTime, ByVal intCoAID As Integer,
                                                       ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT COAP.ID, 	" & vbNewLine & _
                    "    CASE WHEN COAG.COAType=1 OR COAG.COAType=2 OR COAG.COAType=6 THEN SUM(BB.DebitAmount)-SUM(BB.CreditAmount) ELSE SUM(BB.CreditAmount)-SUM(BB.DebitAmount) END AS Amount	 	" & vbNewLine & _
                    "FROM traBukuBesar BB 	 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COAP ON 	 	" & vbNewLine & _
                    "    BB.COAIDParent=COAP.ID 	 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COAC ON 	 	" & vbNewLine & _
                    "    BB.COAIDChild=COAC.ID 	 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccountGroup COAG ON 	 	" & vbNewLine & _
                    "    COAP.AccountGroupID=COAG.ID 	 	" & vbNewLine & _
                    "WHERE 	 	" & vbNewLine & _
                    "    BB.CompanyID=@CompanyID 	 	" & vbNewLine & _
                    "    AND BB.ProgramID=@ProgramID 	 	" & vbNewLine & _
                    "    AND BB.TransactionDate<=DATEADD(DAY, -1, @DateFrom)+'23:59:59'	 	" & vbNewLine & _
                    "" & vbNewLine

                If intCoAID > 0 Then .CommandText += "    AND BB.COAIDParent=@COAID " & vbNewLine

                .CommandText += _
                    "GROUP BY 	 	" & vbNewLine & _
                    "    COAP.ID, COAG.COAType	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@CoAID", SqlDbType.Int).Value = intCoAID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function BukuBesarLastBalance(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal dtmDateFrom As DateTime, ByVal intCoAID As Integer,
                                                    ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As Decimal
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT COAP.ID, 	" & vbNewLine & _
                        "   CASE WHEN COAG.COAType=1 OR COAG.COAType=2 OR COAG.COAType=6 THEN SUM(BB.DebitAmount)-SUM(BB.CreditAmount) ELSE SUM(BB.CreditAmount)-SUM(BB.DebitAmount) END AS Amount	 	" & vbNewLine & _
                        "FROM traBukuBesar BB 	 	" & vbNewLine & _
                        "INNER JOIN mstChartOfAccount COAP ON 	 	" & vbNewLine & _
                        "   BB.COAIDParent=COAP.ID 	 	" & vbNewLine & _
                        "INNER JOIN mstChartOfAccount COAC ON 	 	" & vbNewLine & _
                        "   BB.COAIDChild=COAC.ID 	 	" & vbNewLine & _
                        "INNER JOIN mstChartOfAccountGroup COAG ON 	 	" & vbNewLine & _
                        "   COAP.AccountGroupID=COAG.ID 	 	" & vbNewLine & _
                        "WHERE 	 	" & vbNewLine & _
                        "   BB.CompanyID=@CompanyID 	 	" & vbNewLine & _
                        "   AND BB.ProgramID=@ProgramID 	 	" & vbNewLine & _
                        "   AND BB.TransactionDate<=DATEADD(DAY, -1, @DateFrom)+'23:59:59'	 	" & vbNewLine & _
                        "   AND BB.COAIDParent=@COAID " & vbNewLine & _
                        "GROUP BY 	 	" & vbNewLine & _
                        "    COAP.ID, COAG.COAType	" & vbNewLine

                    .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                    .Parameters.Add("@CoAID", SqlDbType.Int).Value = intCoAID
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        decReturn = .Item("Amount")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return decReturn
        End Function

        Public Shared Function BukuBesarVer00Report(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                    ByVal intCoAID As Integer, ByVal intProgramID As Integer,
                                                    ByVal intCompanyID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "	BB.TransactionDate AS JournalDate, BB.ReferencesNo AS JournalNo, COAG.COAType, COAP.Code AS GroupCode, COAP.Name AS GroupName, 	" & vbNewLine & _
                    "	COAC.Code, COAC.Name, Remarks=CASE WHEN BB.Remarks='' THEN COAC.Name ELSE BB.Remarks END, BB.DebitAmount, BB.CreditAmount, 	" & vbNewLine & _
                    "	FirstBalance=CAST(0 AS DECIMAL(18,2)), BalanceAmount=CAST(0 AS DECIMAL(18,2)), LastBalance=CAST(0 AS DECIMAL(18,2))	" & vbNewLine & _
                    "FROM traBukuBesar BB 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COAP ON 	" & vbNewLine & _
                    "	BB.COAIDParent=COAP.ID 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COAC ON 	" & vbNewLine & _
                    "	BB.COAIDChild=COAC.ID 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccountGroup COAG ON 	" & vbNewLine & _
                    "	COAP.AccountGroupID=COAG.ID 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "	BB.CompanyID=@CompanyID 	" & vbNewLine & _
                    "	AND BB.ProgramID=@ProgramID 	" & vbNewLine & _
                    "	AND BB.TransactionDate>=@DateFrom AND BB.TransactionDate<=@DateTo	" & vbNewLine & _
                    "	AND BB.COAIDParent=@COAID 	" & vbNewLine & _
                    "ORDER BY BB.TransactionDate ASC	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@CoAID", SqlDbType.Int).Value = intCoAID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

    End Class
End Namespace