Namespace DL
    Public Class Reports

#Region "Accounting"

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
            Dim decReturn As Decimal = 0
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
                .CommandText =
                    "SELECT 	" & vbNewLine &
                    "	BB.TransactionDate AS JournalDate, BB.ReferencesID AS JournalNo, COAG.COAType, COAP.Code AS GroupCode, COAP.Name AS GroupName, COAC.Code, COAC.Name, " & vbNewLine &
                    "	Remarks=COAC.Name + CASE WHEN BB.BPID=0 THEN '' ELSE ' - ' + ISNULL(BP.Name,'') END + CASE WHEN BB.ReferencesNo='' THEN '' ELSE ' - ' + BB.ReferencesNo END + CASE WHEN BB.Remarks='' THEN '' ELSE ' - ' + BB.Remarks END, " & vbNewLine &
                    "   BB.DebitAmount, BB.CreditAmount, FirstBalance=CAST(0 AS DECIMAL(18,2)), BalanceAmount=CAST(0 AS DECIMAL(18,2)), LastBalance=CAST(0 AS DECIMAL(18,2))	" & vbNewLine &
                    "FROM traBukuBesar BB 	" & vbNewLine &
                    "INNER JOIN mstChartOfAccount COAP ON 	" & vbNewLine &
                    "	BB.COAIDParent=COAP.ID 	" & vbNewLine &
                    "INNER JOIN mstChartOfAccount COAC ON 	" & vbNewLine &
                    "	BB.COAIDChild=COAC.ID 	" & vbNewLine &
                    "INNER JOIN mstChartOfAccountGroup COAG ON 	" & vbNewLine &
                    "	COAP.AccountGroupID=COAG.ID 	" & vbNewLine &
                    "LEFT JOIN mstBusinessPartner BP ON 	" & vbNewLine &
                    "	BB.BPID=BP.ID 	" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "	BB.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND BB.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND BB.TransactionDate>=@DateFrom AND BB.TransactionDate<=@DateTo	" & vbNewLine &
                    "	AND BB.COAIDParent=@COAID 	" & vbNewLine &
                    "ORDER BY BB.TransactionDate ASC	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@CoAID", SqlDbType.Int).Value = intCoAID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function KartuHutangVer01Report(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                      ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                      ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT 	" & vbNewLine &
                    "	BPS.Code, BPS.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,DP.APDate,112) AS TransactionDate, 'PANJAR PEMBELIAN' AS RemarksInfo, 	" & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, DP.TotalAmount AS DebitAmount, CAST(0 AS DECIMAL) AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traAccountPayable DP 	 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPS ON 	 	" & vbNewLine &
                    "	DP.BPID=BPS.ID 	 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	DP.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND DP.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND DP.APDate>=@DateFrom AND DP.APDate<=@DateTo 	" & vbNewLine &
                    "	AND DP.BPID=@BPID 	 	" & vbNewLine &
                    "	AND DP.IsDeleted=0 	 	" & vbNewLine &
                    "	AND DP.IsDP=1 	 	" & vbNewLine &
                    "	" & vbNewLine &
                    "UNION ALL /* Pembelian Barang */ " & vbNewLine &
                    "SELECT 	" & vbNewLine &
                    "	BPR.Code, BPR.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,TR.ReceiveDate,112) AS TransactionDate, 'PEMBELIAN ' + TR.ReceiveNumber AS RemarksInfo, " & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, CAST(0 AS DECIMAL) AS DebitAmount, TR.TotalDPP AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traReceive TR 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPR ON 	" & vbNewLine &
                    "	TR.BPID=BPR.ID 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	TR.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND TR.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND TR.ReceiveDate>=@DateFrom AND TR.ReceiveDate<=@DateTo 	" & vbNewLine &
                    "	AND TR.BPID=@BPID 	 	" & vbNewLine &
                    "	AND TR.IsDeleted=0 	 	" & vbNewLine &
                    "	" & vbNewLine &
                    "UNION ALL /* Pemotongan */ " & vbNewLine &
                    "SELECT 	" & vbNewLine &
                    "	BPR.Code, BPR.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,TC.CuttingDate,112) AS TransactionDate, 'PEMOTONGAN ' + TC.CuttingNumber AS RemarksInfo, " & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, CAST(0 AS DECIMAL) AS DebitAmount, TC.TotalDPP AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traCutting TC 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPR ON 	" & vbNewLine &
                    "	TC.BPID=BPR.ID 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	TC.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND TC.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND TC.CuttingDate>=@DateFrom AND TC.CuttingDate<=@DateTo 	" & vbNewLine &
                    "	AND TC.BPID=@BPID 	 	" & vbNewLine &
                    "	AND TC.IsDeleted=0 	 	" & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL /* Transport */ " & vbNewLine &
                    "SELECT 	" & vbNewLine &
                    "	BPR.Code, BPR.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,TD.DeliveryDate,112) AS TransactionDate, 'PENGIRIMAN ' + TD.DeliveryNumber AS RemarksInfo, " & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, CAST(0 AS DECIMAL) AS DebitAmount, TD.TotalDPPTransport AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traDelivery TD 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPR ON 	" & vbNewLine &
                    "	TD.BPID=BPR.ID 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	TD.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND TD.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND TD.DeliveryDate>=@DateFrom AND TD.DeliveryDate<=@DateTo 	" & vbNewLine &
                    "	AND TD.BPID=@BPID 	 	" & vbNewLine &
                    "	AND TD.IsDeleted=0 	 	" & vbNewLine &
                    "	" & vbNewLine &
                    "UNION ALL 	 	" & vbNewLine &
                    "SELECT 	 	" & vbNewLine &
                    "	BPR.Code, BPR.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,AP.APDate,112) AS TransactionDate, 'PEMBAYARAN PEMBELIAN' AS RemarksInfo, 	" & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, AP.TotalAmount AS DebitAmount, CAST(0 AS DECIMAL) AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traAccountPayable AP 	 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPR ON 	 	" & vbNewLine &
                    "	AP.BPID=BPR.ID 	 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	AP.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND AP.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND AP.APDate>=@DateFrom AND AP.APDate<=@DateTo 	" & vbNewLine &
                    "	AND AP.BPID=@BPID 	 	" & vbNewLine &
                    "	AND AP.IsDeleted=0 	 	" & vbNewLine &
                    "	AND AP.IsDP=0 	 	" & vbNewLine &
                    "	" & vbNewLine &
                    "ORDER BY TransactionDate, RemarksInfo ASC	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function KartuPiutangVer01Report(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                       ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                       ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT 	" & vbNewLine &
                    "	BPS.Code, BPS.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,DP.ARDate,112) AS TransactionDate, 'PANJAR PENJUALAN' AS RemarksInfo, 	" & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, DP.TotalAmount AS DebitAmount, CAST(0 AS DECIMAL) AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traAccountReceivable DP 	 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPS ON 	 	" & vbNewLine &
                    "	DP.BPID=BPS.ID 	 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	DP.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND DP.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND DP.ARDate>=@DateFrom AND DP.ARDate<=@DateTo 	" & vbNewLine &
                    "	AND DP.BPID=@BPID 	 	" & vbNewLine &
                    "	AND DP.IsDeleted=0 	 	" & vbNewLine &
                    "	AND DP.IsDP=1 	 	" & vbNewLine &
                    "	" & vbNewLine &
                    "UNION ALL 	 	" & vbNewLine &
                    "SELECT 	" & vbNewLine &
                    "	BPR.Code, BPR.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,TD.DeliveryDate,112) AS TransactionDate, TD.DeliveryNumber AS RemarksInfo, " & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, CAST(0 AS DECIMAL) AS DebitAmount, TD.TotalDPP AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traDelivery TD 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPR ON 	" & vbNewLine &
                    "	TD.BPID=BPR.ID 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	TD.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND TD.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND TD.DeliveryDate>=@DateFrom AND TD.DeliveryDate<=@DateTo 	" & vbNewLine &
                    "	AND TD.BPID=@BPID 	 	" & vbNewLine &
                    "	AND TD.IsDeleted=0 	 	" & vbNewLine &
                    "	" & vbNewLine &
                    "UNION ALL 	 	" & vbNewLine &
                    "SELECT 	 	" & vbNewLine &
                    "	BPR.Code, BPR.Name, 	" & vbNewLine &
                    "	CONVERT(DATE,AR.ARDate,112) AS TransactionDate, 'PELUNASAN PENJUALAN' AS RemarksInfo, 	" & vbNewLine &
                    "	CAST(0 AS DECIMAL) AS FirstBalance, AR.TotalAmount AS DebitAmount, CAST(0 AS DECIMAL) AS CreditAmount, CAST(0 AS DECIMAL) AS BalanceAmount	" & vbNewLine &
                    "FROM traAccountReceivable AR 	 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BPR ON 	 	" & vbNewLine &
                    "	AR.BPID=BPR.ID 	 	" & vbNewLine &
                    "WHERE 	 	" & vbNewLine &
                    "	AR.ProgramID=@ProgramID 	" & vbNewLine &
                    "	AND AR.CompanyID=@CompanyID 	" & vbNewLine &
                    "	AND AR.ARDate>=@DateFrom AND AR.ARDate<=@DateTo 	" & vbNewLine &
                    "	AND AR.BPID=@BPID 	 	" & vbNewLine &
                    "	AND AR.IsDeleted=0 	 	" & vbNewLine &
                    "	AND AR.IsDP=0 	 	" & vbNewLine &
                    "	" & vbNewLine &
                    "ORDER BY TransactionDate, RemarksInfo ASC	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function NeracaSaldoVer00Report(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                      ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "	COA.Code, COA.Name, ISNULL(FB.Amount,0) AS FirstBalance, ISNULL(BB.TotalDebit,0) AS TotalDebit, ISNULL(BB.TotalCredit,0) AS TotalCredit,	" & vbNewLine & _
                    "	LastBalance=ISNULL(FB.Amount,0)+ISNULL(CASE WHEN COAG.COAType=1 OR COAG.COAType=2 OR COAG.COAType=6 THEN BB.TotalDebit-BB.TotalCredit ELSE BB.TotalCredit-BB.TotalDebit END,0)	" & vbNewLine & _
                    "FROM mstChartOfAccount COA 	" & vbNewLine & _
                    "INNER JOIN mstChartOfAccountGroup COAG ON 	" & vbNewLine & _
                    "	COA.AccountGroupID=COAG.ID 	" & vbNewLine & _
                    "LEFT JOIN 	" & vbNewLine & _
                    "(	" & vbNewLine & _
                    "	SELECT 	" & vbNewLine & _
                    "		BB.COAIDParent, SUM(BB.DebitAmount) AS TotalDebit, SUM(BB.CreditAmount) AS TotalCredit 	" & vbNewLine & _
                    "	FROM traBukuBesar BB 	" & vbNewLine & _
                    "	INNER JOIN mstChartOfAccount COA ON 	" & vbNewLine & _
                    "		BB.COAIDParent=COA.ID 	" & vbNewLine & _
                    "	WHERE 	" & vbNewLine & _
                    "		BB.CompanyID=@CompanyID 	" & vbNewLine & _
                    "		AND BB.ProgramID=@ProgramID 	" & vbNewLine & _
                    "		AND BB.TransactionDate>=@DateFrom AND BB.TransactionDate<=@DateTo	" & vbNewLine & _
                    "	GROUP BY BB.COAIDParent 	" & vbNewLine & _
                    ") BB ON 	" & vbNewLine & _
                    "	COA.ID=BB.COAIDParent	" & vbNewLine & _
                    "LEFT JOIN 	" & vbNewLine & _
                    "(	" & vbNewLine & _
                    "	SELECT 	" & vbNewLine & _
                    "		BB.COAIDParent, 	" & vbNewLine & _
                    "		CASE WHEN COAG.COAType=1 OR COAG.COAType=2 OR COAG.COAType=6 THEN SUM(BB.DebitAmount)-SUM(BB.CreditAmount) ELSE SUM(BB.CreditAmount)-SUM(BB.DebitAmount) END AS Amount	" & vbNewLine & _
                    "	FROM traBukuBesar BB 	" & vbNewLine & _
                    "	INNER JOIN mstChartOfAccount COA ON 	" & vbNewLine & _
                    "		BB.COAIDParent=COA.ID 	" & vbNewLine & _
                    "	INNER JOIN mstChartOfAccountGroup COAG ON 	" & vbNewLine & _
                    "		COA.AccountGroupID=COAG.ID 	" & vbNewLine & _
                    "	WHERE 	" & vbNewLine & _
                    "		BB.CompanyID=@CompanyID 	" & vbNewLine & _
                    "		AND BB.ProgramID=@ProgramID 	" & vbNewLine & _
                    "		AND BB.TransactionDate<=DATEADD(DAY, -1, @DateFrom)+'23:59:59'	" & vbNewLine & _
                    "	GROUP BY BB.COAIDParent, COAG.COAType	" & vbNewLine & _
                    ") FB ON 	" & vbNewLine & _
                    "	COA.ID=FB.COAIDParent	" & vbNewLine & _
                    "ORDER BY COA.Code	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

#End Region

#Region "Profit and Loss"

        Public Shared Function ListDataPerCOATypeBaseOnBukuBesarReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                                       ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                       ByVal intCOAType As Integer, ByVal intCOAGroupID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT COAG.COAType, " & vbNewLine & _
                    "	COAG.Name AS COAGroupName, BB.COAIDParent, COA.Code AS COACode, COA.Name AS COAName,  " & vbNewLine & _
                    "   TotalAmount = " & vbNewLine & _
                    "	CASE WHEN COAG.COAType=1 OR COAG.COAType=2 OR COAG.COAType=6 THEN  " & vbNewLine & _
                    "		SUM(BB.DebitAmount)-SUM(BB.CreditAmount)  " & vbNewLine & _
                    "	ELSE  " & vbNewLine & _
                    "		SUM(BB.CreditAmount)-SUM(BB.DebitAmount)  " & vbNewLine & _
                    "   END " & vbNewLine & _
                    "FROM traBukuBesar BB  " & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON  " & vbNewLine & _
                    "   BB.COAIDParent = COA.ID " & vbNewLine & _
                    "INNER JOIN mstChartOfAccountGroup COAG ON  " & vbNewLine & _
                    "   COA.AccountGroupID = COAG.ID " & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "   BB.CompanyID=@CompanyID 	" & vbNewLine & _
                    "   AND BB.ProgramID=@ProgramID 	" & vbNewLine & _
                    "   AND COAG.COAType=@COAType " & vbNewLine & _
                    "   AND BB.TransactionDate>=@DateFrom AND BB.TransactionDate<=@DateTo" & vbNewLine

                If intCOAGroupID > 0 Then
                    .CommandText += "   AND COA.AccountGroupID=@AccountGroupID " & vbNewLine
                End If

                .CommandText += _
                    "GROUP BY " & vbNewLine & _
                    "	COAG.Name, BB.COAIDParent, COA.Code, COA.Name, COAG.COAType " & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@COAType", SqlDbType.Int).Value = intCOAType
                .Parameters.Add("@AccountGroupID", SqlDbType.Int).Value = intCOAGroupID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataPerCOATypeBaseOnChartOfAccountReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                            ByVal dtmDateTo As DateTime, ByVal intProgramID As Integer,
                                                                            ByVal intCompanyID As Integer, ByVal intCOAType As Integer,
                                                                            ByVal intCOAGroupID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "	COAT.ID AS TypeID, COAT.Name AS TypeName, COAG.ID AS GroupID, COAG.Name AS GroupName, COA.ID AS COAID, COA.Code AS COACode, " & vbNewLine & _
                    "	COA.Name AS COAName, TotalAmount=ISNULL(BB.TotalAmount,0) " & vbNewLine & _
                    "FROM mstChartOfAccount COA " & vbNewLine & _
                    "INNER JOIN mstChartOfAccountGroup COAG ON " & vbNewLine & _
                    "   COA.AccountGroupID = COAG.ID " & vbNewLine & _
                    "INNER JOIN mstChartOfAccountType COAT ON " & vbNewLine & _
                    "   COAG.COAType = COAT.ID " & vbNewLine & _
                    "LEFT JOIN " & vbNewLine & _
                    "( " & vbNewLine & _
                    "	SELECT " & vbNewLine & _
                    "		COA.ID AS COAID, " & vbNewLine & _
                    "		TotalAmount= " & vbNewLine & _
                    "		CASE WHEN COAG.COAType=1 OR COAG.COAType=2 OR COAG.COAType=6 THEN " & vbNewLine & _
                    "            SUM(BB.DebitAmount) - SUM(BB.CreditAmount) " & vbNewLine & _
                    "		ELSE " & vbNewLine & _
                    "            SUM(BB.CreditAmount) - SUM(BB.DebitAmount) " & vbNewLine & _
                    "       END " & vbNewLine & _
                    "	FROM traBukuBesar BB " & vbNewLine & _
                    "	INNER JOIN mstChartOfAccount COA ON " & vbNewLine & _
                    "       BB.COAIDParent = COA.ID " & vbNewLine & _
                    "	INNER JOIN mstChartOfAccountGroup COAG ON " & vbNewLine & _
                    "       COA.AccountGroupID = COAG.ID " & vbNewLine & _
                    "   WHERE " & vbNewLine & _
                    "       BB.CompanyID=@CompanyID 	" & vbNewLine & _
                    "       AND BB.ProgramID=@ProgramID 	" & vbNewLine & _
                    "		AND COAG.COAType=@COAType " & vbNewLine & _
                    "       AND BB.TransactionDate<=@DateTo" & vbNewLine

                If intCOAGroupID > 0 Then
                    .CommandText += "		AND COA.AccountGroupID=@AccountGroupID " & vbNewLine
                End If

                .CommandText += _
                    "	GROUP BY COA.ID, COAG.COAType " & vbNewLine & _
                    ") BB ON " & vbNewLine & _
                    "   COA.ID = BB.COAID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "	COAG.COAType=@COAType " & vbNewLine

                If intCOAGroupID > 0 Then
                    .CommandText += "   AND COA.AccountGroupID=@AccountGroupID " & vbNewLine
                End If

                .CommandText += "ORDER BY COAT.ID, COA.Code ASC " & vbNewLine

                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@COAType", SqlDbType.Int).Value = intCOAType
                .Parameters.Add("@AccountGroupID", SqlDbType.Int).Value = intCOAGroupID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function DiscountRevenueReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                     ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 		" & vbNewLine & _
                    "	COA.Name, SUM(JD.CreditAmount)-SUM(JD.DebitAmount) AS TotalAmount	" & vbNewLine & _
                    "FROM traJournalDet JD 		" & vbNewLine & _
                    "INNER JOIN traJournal JH ON 		" & vbNewLine & _
                    "	JD.JournalID=JH.ID 		" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON 	" & vbNewLine & _
                    "	JD.CoAID=COA.ID 	" & vbNewLine & _
                    "	AND COA.AccountGroupID=17	" & vbNewLine & _
                    "WHERE 		" & vbNewLine & _
                    "	JH.IsDeleted=0 	" & vbNewLine & _
                    "	AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 	" & vbNewLine & _
                    "	AND JH.JournalDate>=@DateFrom AND JH.JournalDate<=@DateTo 	" & vbNewLine & _
                    "GROUP BY COA.Name	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function FirstStockReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal dtmDateFrom As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 			" & vbNewLine & _
                    "	'PERSEDIAAN AWAL' AS Name, SUM(JD.DebitAmount)-SUM(JD.CreditAmount) AS TotalAmount		" & vbNewLine & _
                    "INTO #TFirstStock 	" & vbNewLine & _
                    "FROM traJournalDet JD 			" & vbNewLine & _
                    "INNER JOIN traJournal JH ON 			" & vbNewLine & _
                    "	JD.JournalID=JH.ID 			" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON 		" & vbNewLine & _
                    "	JD.CoAID=COA.ID 		" & vbNewLine & _
                    "	AND COA.AccountGroupID=3		" & vbNewLine & _
                    "WHERE 			" & vbNewLine & _
                    "	JH.IsDeleted=0 		" & vbNewLine & _
                    "	AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 		" & vbNewLine & _
                    "	AND JH.JournalDate<@DateFrom 		" & vbNewLine & _
                    "GROUP BY COA.Name		" & vbNewLine & _
                    "	" & vbNewLine & _
                    "	" & vbNewLine & _
                    "UNION ALL	" & vbNewLine & _
                    "SELECT 			" & vbNewLine & _
                    "	'PERSEDIAAN AWAL' AS Name, SUM(JD.DebitAmount)-SUM(JD.CreditAmount) AS TotalAmount		" & vbNewLine & _
                    "FROM traJournalDet JD 			" & vbNewLine & _
                    "INNER JOIN traJournal JH ON 			" & vbNewLine & _
                    "	JD.JournalID=JH.ID 			" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON 		" & vbNewLine & _
                    "	JD.CoAID=COA.ID 		" & vbNewLine & _
                    "	AND COA.AccountGroupID=18		" & vbNewLine & _
                    "WHERE 			" & vbNewLine & _
                    "	JH.IsDeleted=0 		" & vbNewLine & _
                    "	AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 		" & vbNewLine & _
                    "	AND JH.JournalDate<@DateFrom 		" & vbNewLine & _
                    "GROUP BY COA.Name		" & vbNewLine & _
                    "	" & vbNewLine & _
                    "SELECT 	" & vbNewLine & _
                    "	Name, SUM(TotalAmount) AS TotalAmount  	" & vbNewLine & _
                    "FROM #TFirstStock 	" & vbNewLine & _
                    "GROUP BY Name	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom.AddDays(-1)
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function PurchaseStockReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 			" & vbNewLine & _
                    "	'PEMBELIAN' AS Name, ISNULL(SUM(RH.GrandTotal),0) AS TotalAmount		" & vbNewLine & _
                    "INTO #T_PurchaseStock	" & vbNewLine & _
                    "FROM traReceive RH 			" & vbNewLine & _
                    "WHERE 			" & vbNewLine & _
                    "	RH.IsDeleted=0 		" & vbNewLine & _
                    "	AND RH.IsPostedGL=1		" & vbNewLine & _
                    "	AND RH.ReceiveDate>=@DateFrom AND RH.ReceiveDate<=@DateTo		" & vbNewLine & _
                    "		" & vbNewLine & _
                    "UNION ALL 	" & vbNewLine & _
                    "SELECT 			" & vbNewLine & _
                    "	'PEMBELIAN' AS Name, ISNULL(SUM(RH.GrandTotal),0)*-1 AS TotalAmount		" & vbNewLine & _
                    "FROM traReceiveReturn RH 			" & vbNewLine & _
                    "WHERE 			" & vbNewLine & _
                    "	RH.IsDeleted=0 		" & vbNewLine & _
                    "	AND RH.IsPostedGL=1		" & vbNewLine & _
                    "	AND RH.ReceiveReturnDate>=@DateFrom AND RH.ReceiveReturnDate<=@DateTo		" & vbNewLine & _
                    "	" & vbNewLine & _
                    "SELECT 	" & vbNewLine & _
                    "	Name, SUM(TotalAmount) AS TotalAmount	" & vbNewLine & _
                    "FROM #T_PurchaseStock	" & vbNewLine & _
                    "GROUP BY Name	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function LastStockReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 			" & vbNewLine & _
                    "	'PERSEDIAAN AKHIR' AS Name, SUM(JD.DebitAmount)-SUM(JD.CreditAmount) AS TotalAmount		" & vbNewLine & _
                    "INTO #TLastStock 	" & vbNewLine & _
                    "FROM traJournalDet JD 			" & vbNewLine & _
                    "INNER JOIN traJournal JH ON 			" & vbNewLine & _
                    "	JD.JournalID=JH.ID 			" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON 		" & vbNewLine & _
                    "	JD.CoAID=COA.ID 		" & vbNewLine & _
                    "	AND COA.AccountGroupID=3		" & vbNewLine & _
                    "WHERE 			" & vbNewLine & _
                    "	JH.IsDeleted=0 		" & vbNewLine & _
                    "	AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 		" & vbNewLine & _
                    "	AND JH.JournalDate>=@DateFrom AND JH.JournalDate<=@DateTo 		" & vbNewLine & _
                    "GROUP BY COA.Name		" & vbNewLine & _
                    "	" & vbNewLine & _
                    "	" & vbNewLine & _
                    "UNION ALL	" & vbNewLine & _
                    "SELECT 			" & vbNewLine & _
                    "	'PERSEDIAAN AKHIR' AS Name, SUM(JD.DebitAmount)-SUM(JD.CreditAmount) AS TotalAmount		" & vbNewLine & _
                    "FROM traJournalDet JD 			" & vbNewLine & _
                    "INNER JOIN traJournal JH ON 			" & vbNewLine & _
                    "	JD.JournalID=JH.ID 			" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON 		" & vbNewLine & _
                    "	JD.CoAID=COA.ID 		" & vbNewLine & _
                    "	AND COA.AccountGroupID=18		" & vbNewLine & _
                    "WHERE 			" & vbNewLine & _
                    "	JH.IsDeleted=0 		" & vbNewLine & _
                    "	AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 		" & vbNewLine & _
                    "	AND JH.JournalDate>=@DateFrom AND JH.JournalDate<=@DateTo 		" & vbNewLine & _
                    "GROUP BY COA.Name		" & vbNewLine & _
                    "	" & vbNewLine & _
                    "SELECT 	" & vbNewLine & _
                    "	Name, SUM(TotalAmount) AS TotalAmount  	" & vbNewLine & _
                    "FROM #TLastStock 	" & vbNewLine & _
                    "GROUP BY Name	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ExpensesReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 		" & vbNewLine & _
                    "	COA.Name, SUM(JD.DebitAmount)-SUM(JD.CreditAmount) AS TotalAmount	" & vbNewLine & _
                    "FROM traJournalDet JD 		" & vbNewLine & _
                    "INNER JOIN traJournal JH ON 		" & vbNewLine & _
                    "	JD.JournalID=JH.ID 		" & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON 	" & vbNewLine & _
                    "	JD.CoAID=COA.ID 	" & vbNewLine & _
                    "	AND COA.AccountGroupID IN (14,15)	" & vbNewLine & _
                    "WHERE 		" & vbNewLine & _
                    "	JH.IsDeleted=0 	" & vbNewLine & _
                    "	AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 	" & vbNewLine & _
                    "	AND JH.JournalDate>=@DateFrom AND JH.JournalDate<=@DateTo 	" & vbNewLine & _
                    "GROUP BY COA.Name	" & vbNewLine

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

#End Region

#Region "Balance Sheet"

        Public Shared Function BalanceSheetDebitReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "	COA.Code AS CoACode, COA.Name AS CoAName, 	" & vbNewLine & _
                    "	DebitAmount=ISNULL(	" & vbNewLine & _
                    "	COA.FirstBalance+	" & vbNewLine & _
                    "	CASE WHEN 	" & vbNewLine & _
                    "		COA.AccountGroupID=1 OR COA.AccountGroupID=2 OR COA.AccountGroupID=3 OR COA.AccountGroupID=4 	" & vbNewLine & _
                    "		OR COA.AccountGroupID=5 OR COA.AccountGroupID=6 OR COA.AccountGroupID=7 OR COA.AccountGroupID=17 	" & vbNewLine & _
                    "		OR COA.AccountGroupID=18 OR COA.AccountGroupID=13 OR COA.AccountGroupID=14 OR COA.AccountGroupID=15 OR COA.AccountGroupID=16 	" & vbNewLine & _
                    "	THEN ISNULL(JH.TotalDebit,0)-ISNULL(JH.TotalCredit,0) " & vbNewLine & _
                    "	ELSE ISNULL(JH.TotalCredit,0)-ISNULL(JH.TotalDebit,0) " & vbNewLine & _
                    "	END,0),	" & vbNewLine & _
                    "	CreditAmount=CAST(0 AS DECIMAL(18,2))" & vbNewLine & _
                    "FROM mstChartOfAccount COA 	" & vbNewLine & _
                    "INNER JOIN 	" & vbNewLine & _
                    "(	" & vbNewLine & _
                    "	SELECT 	" & vbNewLine & _
                    "		JD.CoAID, SUM(JD.DebitAmount) AS TotalDebit, SUM(JD.CreditAmount) AS TotalCredit	" & vbNewLine & _
                    "	FROM traJournalDet JD 	" & vbNewLine & _
                    "	INNER JOIN traJournal JH ON 	" & vbNewLine & _
                    "		JD.JournalID=JH.ID 	" & vbNewLine & _
                    "	WHERE 	" & vbNewLine & _
                    "		JH.IsDeleted=0 	" & vbNewLine & _
                    "	    AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 	" & vbNewLine & _
                    "	    AND JH.JournalDate<=@DateTo 	" & vbNewLine & _
                    "	GROUP BY JD.CoAID 	" & vbNewLine & _
                    ") JH ON COA.ID=JH.CoAID	" & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "    COA.AccountGroupID IN (1,2,4,5,6,7)" & vbNewLine & _
                    "ORDER BY " & vbNewLine & _
                    "    COA.Code ASC " & vbNewLine

                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function BalanceSheetCreditReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                        ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "	COA.Code AS CoACode, COA.Name AS CoAName, 	" & vbNewLine & _
                    "	DebitAmount=CAST(0 AS DECIMAL(18,2))," & vbNewLine & _
                    "	CreditAmount=ISNULL(	" & vbNewLine & _
                    "	COA.FirstBalance+	" & vbNewLine & _
                    "	CASE WHEN 	" & vbNewLine & _
                    "		COA.AccountGroupID=1 OR COA.AccountGroupID=2 OR COA.AccountGroupID=3 OR COA.AccountGroupID=4 	" & vbNewLine & _
                    "		OR COA.AccountGroupID=5 OR COA.AccountGroupID=6 OR COA.AccountGroupID=7 OR COA.AccountGroupID=17 	" & vbNewLine & _
                    "		OR COA.AccountGroupID=18 OR COA.AccountGroupID=13 OR COA.AccountGroupID=14 OR COA.AccountGroupID=15 OR COA.AccountGroupID=16 	" & vbNewLine & _
                    "	THEN ISNULL(JH.TotalDebit,0)-ISNULL(JH.TotalCredit,0) " & vbNewLine & _
                    "	ELSE ISNULL(JH.TotalCredit,0)-ISNULL(JH.TotalDebit,0) " & vbNewLine & _
                    "	END,0) " & vbNewLine & _
                    "FROM mstChartOfAccount COA 	" & vbNewLine & _
                    "INNER JOIN 	" & vbNewLine & _
                    "(	" & vbNewLine & _
                    "	SELECT 	" & vbNewLine & _
                    "		JD.CoAID, SUM(JD.DebitAmount) AS TotalDebit, SUM(JD.CreditAmount) AS TotalCredit	" & vbNewLine & _
                    "	FROM traJournalDet JD 	" & vbNewLine & _
                    "	INNER JOIN traJournal JH ON 	" & vbNewLine & _
                    "		JD.JournalID=JH.ID 	" & vbNewLine & _
                    "	WHERE 	" & vbNewLine & _
                    "		JH.IsDeleted=0 	" & vbNewLine & _
                    "	    AND ((JH.IsAutoGenerate=0 AND JH.IsPostedGL=1) OR (JH.IsAutoGenerate=1)) 	" & vbNewLine & _
                    "	    AND JH.JournalDate<=@DateTo 	" & vbNewLine & _
                    "	GROUP BY JD.CoAID 	" & vbNewLine & _
                    ") JH ON COA.ID=JH.CoAID	" & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "    COA.AccountGroupID IN (8,9,10,11)" & vbNewLine & _
                    "ORDER BY " & vbNewLine & _
                    "    COA.Code ASC " & vbNewLine

                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

#End Region

        Public Shared Function ListPOCutting(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                             ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                             ByVal intBPID As Integer, ByVal intItemTypeID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
"SELECT  " & vbNewLine & _
"	No=ROW_NUMBER() OVER(ORDER BY POH.PONumber, POD.ID ASC), ItemCode=CASE WHEN MI.ItemCodeExternal='' THEN POD.OrderNumberSupplier ELSE MI.ItemCodeExternal END,  " & vbNewLine & _
"	POH.PONumber, CustomerName=CP.Name, BPName=BP.Name, POD.TotalWeight, IT.Description AS ItemTypeName, POD.ID  " & vbNewLine & _
"FROM traPurchaseOrderCutting POH  " & vbNewLine & _
"INNER JOIN traPurchaseOrderCuttingDet POD ON  " & vbNewLine & _
"	POH.ID=POD.POID  " & vbNewLine & _
"INNER JOIN mstItem MI ON	 " & vbNewLine & _
"	POD.ItemID=MI.ID  " & vbNewLine & _
"INNER JOIN mstItemType IT ON  " & vbNewLine & _
"	MI.ItemTypeID=IT.ID  " & vbNewLine & _
"INNER JOIN mstBusinessPartner CP ON  " & vbNewLine & _
"	POH.CustomerID=CP.ID  " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON  " & vbNewLine & _
"	POH.BPID=BP.ID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	POH.ProgramID=@ProgramID  " & vbNewLine & _
"	AND POH.CompanyID=@CompanyID  " & vbNewLine & _
"	AND POH.PODate>=@DateFrom AND POH.PODate<=@DateTo  " & vbNewLine & _
"	AND POH.IsDeleted=0  " & vbNewLine & _
"	AND POH.ApprovedBy<>''  " & vbNewLine

                If intItemTypeID > 0 Then .CommandText += "	AND IT.ID=@ItemTypeID  " & vbNewLine
                If intBPID > 0 Then .CommandText += "	AND BP.ID=@BPID  " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = intItemTypeID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function MonitoringProductTransactionReportMainVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                       ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT " & vbNewLine & _
"	PC.PCDetailID, PC.CODetailID, PC.PCNumber, PC.PCDate, PC.OrderNumberSupplier, PC.ItemCode, PC.ItemType, PC.ItemSpec, PC.Thick, PC.Width, PC.Length, PC.PCQuantity, PC.PCTotalWeight, " & vbNewLine & _
"	SC.SCQuantity, SC.SCTotalWeight, RV.RVQuantity, RV.RVTotalWeight, RV.SPKQuantity, RV.SPKTotalWeight, RV.CUTQuantity, RV.CUTTotalWeight, " & vbNewLine & _
"	SC.DVQuantity, SC.DVTotalWeight, PC.PCTotalWeight-ISNULL(SC.SCTotalWeight,0) AS InventoryTotalWeight " & vbNewLine & _
"FROM " & vbNewLine & _
"(" & vbNewLine & _
"	SELECT " & vbNewLine & _
"		PCH.ProgramID, PCH.CompanyID, PCH.PCDate, PCD.ID AS PCDetailID, PCH.PCNumber, PCD.OrderNumberSupplier, MI.ItemCode, MIT.Description AS ItemType, " & vbNewLine & _
"		MIS.Description AS ItemSpec, PCD.CODetailID,	MI.Thick, MI.Width, CASE WHEN MI.Length=0 THEN MIT.LengthInitial ELSE CONVERT(VARCHAR(100),MI.Length) END Length, " & vbNewLine & _
"		PCD.Quantity AS PCQuantity, PCD.TotalWeight AS PCTotalWeight  " & vbNewLine & _
"	FROM traPurchaseContract PCH " & vbNewLine & _
"	INNER JOIN traPurchaseContractDet PCD ON " & vbNewLine & _
"		PCH.ID=PCD.PCID " & vbNewLine & _
"	INNER JOIN mstItem MI ON " & vbNewLine & _
"		PCD.ItemID=MI.ID " & vbNewLine & _
"	INNER JOIN mstItemType MIT ON " & vbNewLine & _
"		MI.ItemTypeID=MIT.ID " & vbNewLine & _
"	INNER JOIN mstItemSpecification MIS ON " & vbNewLine & _
"		MI.ItemSpecificationID=MIS.ID " & vbNewLine & _
"	WHERE " & vbNewLine & _
"		PCH.IsDeleted=0 " & vbNewLine & _
"		AND PCD.ParentID='' " & vbNewLine & _
") PC " & vbNewLine & _
"-- RECEIVE >> " & vbNewLine & _
"LEFT JOIN " & vbNewLine & _
"(" & vbNewLine & _
"	SELECT " & vbNewLine & _
"		RVD.PCDetailID, RVD.RVQuantity, RVD.RVTotalWeight, POC.SPKQuantity, POC.SPKTotalWeight, POC.CUTQuantity, POC.CUTTotalWeight  " & vbNewLine & _
"	FROM " & vbNewLine & _
"	(" & vbNewLine & _
"		SELECT " & vbNewLine & _
"			RVD.PCDetailID, SUM(RVD.Quantity) AS RVQuantity, SUM(RVD.TotalWeight) AS RVTotalWeight " & vbNewLine & _
"		FROM traReceive RVH " & vbNewLine & _
"		INNER JOIN traReceiveDet RVD ON " & vbNewLine & _
"			RVH.ID=RVD.ReceiveID " & vbNewLine & _
"		WHERE " & vbNewLine & _
"			RVH.IsDeleted=0 " & vbNewLine & _
"			AND ParentID='' " & vbNewLine & _
"		GROUP BY RVD.PCDetailID " & vbNewLine & _
"" & vbNewLine & _
"		UNION ALL " & vbNewLine & _
"		SELECT " & vbNewLine & _
"			RVD.ParentID AS PCDetailID, SUM(RVD.Quantity) RVQuantity, SUM(RVD.TotalWeight) RVTotalWeight " & vbNewLine & _
"		FROM traReceive RVH " & vbNewLine & _
"		INNER JOIN traReceiveDet RVD ON " & vbNewLine & _
"			RVH.ID=RVD.ReceiveID " & vbNewLine & _
"		WHERE " & vbNewLine & _
"			RVH.IsDeleted=0 " & vbNewLine & _
"			AND ParentID<>'' " & vbNewLine & _
"		GROUP BY RVD.ParentID" & vbNewLine & _
"	) RVD " & vbNewLine & _
"	LEFT JOIN " & vbNewLine & _
"	(" & vbNewLine & _
"		SELECT " & vbNewLine & _
"			RVD.PCDetailID, " & vbNewLine & _
"			SUM(POD.Quantity) SPKQuantity, SUM(POD.TotalWeight) AS SPKTotalWeight, " & vbNewLine & _
"			SUM(CUT.CUTQuantity) AS CUTQuantity, SUM(CUT.CUTTotalWeight) AS CUTTotalWeight " & vbNewLine & _
"		FROM traPurchaseOrderCutting POH " & vbNewLine & _
"		INNER JOIN traPurchaseOrderCuttingDet POD ON " & vbNewLine & _
"			POH.ID=POD.POID " & vbNewLine & _
"		INNER JOIN " & vbNewLine & _
"		(" & vbNewLine & _
"			SELECT " & vbNewLine & _
"				RVD.ID, CASE WHEN RVD.ParentID='' THEN RVD.PCDetailID ELSE RVD.ParentID END PCDetailID" & vbNewLine & _
"			FROM traReceive RV " & vbNewLine & _
"			INNER JOIN traReceiveDet RVD ON " & vbNewLine & _
"				RV.ID=RVD.ReceiveID " & vbNewLine & _
"			WHERE RV.IsDeleted=0 " & vbNewLine & _
"		) RVD ON POD.ReceiveDetailID=RVD.ID " & vbNewLine & _
"		LEFT JOIN " & vbNewLine & _
"		(" & vbNewLine & _
"			SELECT " & vbNewLine & _
"				CD.PODetailID, SUM(CD.Quantity) AS CUTQuantity, SUM(CD.TotalWeight) AS CUTTotalWeight " & vbNewLine & _
"			FROM traCutting CH " & vbNewLine & _
"			INNER JOIN traCuttingDet CD ON " & vbNewLine & _
"				CH.ID=CD.CuttingID " & vbNewLine & _
"			WHERE CH.IsDeleted=0 " & vbNewLine & _
"			GROUP BY CD.PODetailID " & vbNewLine & _
"		) CUT ON POD.ID=CUT.PODetailID 			" & vbNewLine & _
"		WHERE POH.IsDeleted=0 " & vbNewLine & _
"		GROUP BY RVD.PCDetailID" & vbNewLine & _
"	) POC ON " & vbNewLine & _
"		RVD.PCDetailID=POC.PCDetailID " & vbNewLine & _
") RV ON PC.PCDetailID=RV.PCDetailID " & vbNewLine & _
"-- SALES >> " & vbNewLine & _
"LEFT JOIN " & vbNewLine & _
"(" & vbNewLine & _
"	SELECT " & vbNewLine & _
"		SCDCO.CODetailID, SCD.OrderNumberSupplier, SUM(SCD.Quantity) SCQuantity, SUM(SCD.TotalWeight) AS SCTotalWeight, " & vbNewLine & _
"		SUM(TD.DVQuantity) AS DVQuantity, SUM(TD.DVTotalWeight) AS DVTotalWeight " & vbNewLine & _
"	FROM traSalesContract SCH " & vbNewLine & _
"	INNER JOIN traSalesContractDet SCD ON " & vbNewLine & _
"		SCH.ID=SCD.SCID" & vbNewLine & _
"		AND SCD.ParentID='' " & vbNewLine & _
"	INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON " & vbNewLine & _
"		SCD.SCID=SCDCO.SCID " & vbNewLine & _
"		AND SCD.GroupID=SCDCO.GroupID " & vbNewLine & _
"		AND SCDCO.ParentID='' " & vbNewLine & _
"	LEFT JOIN " & vbNewLine & _
"	(" & vbNewLine & _
"		SELECT TDD.SCDetailID, SUM(TDD.Quantity) DVQuantity, SUM(TDD.TotalWeight) DVTotalWeight  " & vbNewLine & _
"		FROM traDelivery TDH " & vbNewLine & _
"		INNER JOIN traDeliveryDet TDD ON " & vbNewLine & _
"			TDH.ID=TDD.DeliveryID " & vbNewLine & _
"			AND TDD.ParentID='' " & vbNewLine & _
"		WHERE TDH.IsDeleted=0 " & vbNewLine & _
"		GROUP BY TDD.SCDetailID " & vbNewLine & _
"" & vbNewLine & _
"		UNION ALL " & vbNewLine & _
"		SELECT TDD.ParentID AS SCDetailID, SUM(TDD.Quantity) DVQuantity, SUM(TDD.TotalWeight) DVTotalWeight  " & vbNewLine & _
"		FROM traDelivery TDH " & vbNewLine & _
"		INNER JOIN traDeliveryDet TDD ON " & vbNewLine & _
"			TDH.ID=TDD.DeliveryID " & vbNewLine & _
"			AND TDD.ParentID<>'' " & vbNewLine & _
"		WHERE TDH.IsDeleted=0 " & vbNewLine & _
"		GROUP BY TDD.ParentID " & vbNewLine & _
"	) TD ON " & vbNewLine & _
"		SCD.ID=TD.SCDetailID " & vbNewLine & _
"	WHERE SCH.IsDeleted=0 " & vbNewLine & _
"	GROUP BY SCDCO.CODetailID, SCD.OrderNumberSupplier " & vbNewLine & _
") SC ON " & vbNewLine & _
"	PC.CODetailID=SC.CODetailID" & vbNewLine & _
"WHERE " & vbNewLine & _
"	PC.ProgramID=@ProgramID " & vbNewLine & _
"	AND PC.CompanyID=@CompanyID " & vbNewLine & _
"	AND PC.PCDate>=@DateFrom AND PC.PCDate<=@DateTo" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function MonitoringProductTransactionReportSalesContractVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                                    ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                                    ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT " & vbNewLine &
"	ROW_NUMBER() OVER(ORDER BY PCD.ID) AS ID, PCD.ID AS PCDetailID, SC.SCNumber, SC.SCDate, SC.BPName, SC.SCQuantity, SC.SCTotalWeight, SC.DVQuantity, SC.DVTotalWeight  " & vbNewLine &
"FROM traPurchaseContract PC " & vbNewLine &
"INNER JOIN traPurchaseContractDet PCD ON " & vbNewLine &
"	PC.ID=PCD.PCID " & vbNewLine &
"	AND PC.IsDeleted=0 " & vbNewLine &
"   AND PCD.ParentID='' " & vbNewLine &
"INNER JOIN " & vbNewLine &
"(	" & vbNewLine &
"	SELECT " & vbNewLine &
"		SCDCO.CODetailID, SCH.SCNumber, SCH.SCDate, BP.Name AS BPName, SCD.OrderNumberSupplier, SUM(SCD.Quantity) SCQuantity, SUM(SCD.TotalWeight) AS SCTotalWeight, " & vbNewLine &
"		SUM(TD.DVQuantity) AS DVQuantity, SUM(TD.DVTotalWeight) AS DVTotalWeight " & vbNewLine &
"	FROM traSalesContract SCH " & vbNewLine &
"	INNER JOIN mstBusinessPartner BP ON " & vbNewLine &
"		SCH.BPID=BP.ID " & vbNewLine &
"	INNER JOIN traSalesContractDet SCD ON " & vbNewLine &
"		SCH.ID=SCD.SCID" & vbNewLine &
"		AND SCD.ParentID='' " & vbNewLine &
"	INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON " & vbNewLine &
"		SCD.SCID=SCDCO.SCID " & vbNewLine &
"		AND SCD.GroupID=SCDCO.GroupID " & vbNewLine &
"		AND SCDCO.ParentID='' " & vbNewLine &
"	LEFT JOIN " & vbNewLine &
"	(" & vbNewLine &
"		SELECT TDD.SCDetailID, SUM(TDD.Quantity) DVQuantity, SUM(TDD.TotalWeight) DVTotalWeight  " & vbNewLine &
"		FROM traDelivery TDH " & vbNewLine &
"		INNER JOIN traDeliveryDet TDD ON " & vbNewLine &
"			TDH.ID=TDD.DeliveryID " & vbNewLine &
"			AND TDD.ParentID='' " & vbNewLine &
"		WHERE TDH.IsDeleted=0 " & vbNewLine &
"		GROUP BY TDD.SCDetailID " & vbNewLine &
"" & vbNewLine &
"		UNION ALL " & vbNewLine &
"		SELECT TDD.ParentID AS SCDetailID, SUM(TDD.Quantity) DVQuantity, SUM(TDD.TotalWeight) DVTotalWeight  " & vbNewLine &
"		FROM traDelivery TDH " & vbNewLine &
"		INNER JOIN traDeliveryDet TDD ON " & vbNewLine &
"			TDH.ID=TDD.DeliveryID " & vbNewLine &
"			AND TDD.ParentID<>'' " & vbNewLine &
"		WHERE TDH.IsDeleted=0 " & vbNewLine &
"		GROUP BY TDD.ParentID " & vbNewLine &
"	) TD ON " & vbNewLine &
"		SCD.ID=TD.SCDetailID " & vbNewLine &
"	WHERE SCH.IsDeleted=0 " & vbNewLine &
"	GROUP BY SCDCO.CODetailID, SCH.SCNumber, SCH.SCDate, BP.Name, SCD.OrderNumberSupplier " & vbNewLine &
") SC ON " & vbNewLine &
"	PCD.CODetailID=SC.CODetailID " & vbNewLine &
"WHERE " & vbNewLine &
"	PC.ProgramID=@ProgramID " & vbNewLine &
"	AND PC.CompanyID=@CompanyID " & vbNewLine &
"	AND PC.PCDate>=@DateFrom AND PC.PCDate<=@DateTo" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function MonitoringProductTransactionReportPurchaseContractVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                                      ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                                      ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine & _
"	ROW_NUMBER() OVER(ORDER BY PCD.ID) AS ID, PCD.ParentID AS PCDetailID, MI.ItemCode, MI.ItemCodeExternal, MI.Thick, MI.Width, MI.Length, PCD.Quantity, PCD.TotalWeight, PCD.DCQuantity, PCD.DCWeight  " & vbNewLine & _
"FROM traPurchaseContractDet PCD  " & vbNewLine & _
"INNER JOIN traPurchaseContract PCH ON  " & vbNewLine & _
"	PCD.PCID=PCH.ID  " & vbNewLine & _
"	AND PCD.ParentID<>'' " & vbNewLine & _
"INNER JOIN mstItem MI ON  " & vbNewLine & _
"	PCD.ItemID=MI.ID  " & vbNewLine & _
" " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	PCH.IsDeleted=0  " & vbNewLine & _
"	AND PCH.ProgramID=@ProgramID  " & vbNewLine & _
"	AND PCH.CompanyID=@CompanyID  " & vbNewLine & _
"	AND PCH.PCDate>=@DateFrom AND PCH.PCDate<=@DateTo  " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function SalesPIReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                             ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                             ByVal intBPID As Integer, ByVal intItemTypeID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
"SELECT CAST(0 AS INT) AS No, " & vbNewLine & _
"	ARI.ID, ORH.OrderNumber, ARH.ARNumber, ARH.ARDate, ARI.OrderNumberSupplier,  " & vbNewLine & _
"	MIT.Description AS Item, MI.Thick, MI.Width, MI.Length, BP.Name AS BPName,  " & vbNewLine & _
"	ARI.TotalWeight, ARI.Amount+ARI.PPN AS TotalIncPPN, ARI.TotalInvoiceAmount,  " & vbNewLine & _
"	ARI.Amount+ARI.PPN-ARI.TotalInvoiceAmount AS OutstandingPaid " & vbNewLine & _
"FROM traSalesContractDet SCD  " & vbNewLine & _
"INNER JOIN traARAPItem ARI ON  " & vbNewLine & _
"	SCD.ID=ARI.ReferencesDetailID  " & vbNewLine & _
"INNER JOIN mstItem MI ON	 " & vbNewLine & _
"	ARI.ItemID=MI.ID  " & vbNewLine & _
"INNER JOIN mstItemType MIT ON  " & vbNewLine & _
"	MI.ItemTypeID=MIT.ID  " & vbNewLine & _
"INNER JOIN traAccountReceivable ARH ON  " & vbNewLine & _
"	ARI.ParentID=ARH.ID " & vbNewLine & _
"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine & _
"	SCD.ORDetailID=ORD.ID  " & vbNewLine & _
"INNER JOIN traOrderRequest ORH ON  " & vbNewLine & _
"	ORD.OrderRequestID=ORH.ID  " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON  " & vbNewLine & _
"	ARH.BPID=BP.ID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	ARH.ApprovedBy<>''  " & vbNewLine & _
"	AND ARH.ProgramID=@ProgramID  " & vbNewLine & _
"	AND ARH.CompanyID=@CompanyID  " & vbNewLine & _
"	AND ARH.ARDate>=@DateFrom AND ARH.ARDate<=@DateTo  " & vbNewLine

                If intItemTypeID > 0 Then .CommandText += "	AND MIT.ID=@ItemTypeID  " & vbNewLine
                If intBPID > 0 Then .CommandText += "	AND BP.ID=@BPID  " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = intItemTypeID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function SalesConfirmationReport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                       ByVal intBPID As Integer, ByVal intItemTypeID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
"SELECT CAST(0 AS INT) AS No, " & vbNewLine & _
"	SCO.CODate, POD.PONumber, ORD.OrderNumber, MIS.Description AS ItemSpec, MIT.Description AS ItemType,  " & vbNewLine & _
"	MI.Thick, MI.Width, MI.Length, SCOD.TotalWeight, SCOD.UnitPrice, SCOD.TotalPrice + (SCOD.TotalPrice*SCO.PPN/100) AS TotalIncPPN " & vbNewLine & _
"FROM traSalesConfirmationOrder SCO  " & vbNewLine & _
"INNER JOIN traSalesConfirmationOrderDet SCOD ON  " & vbNewLine & _
"	SCO.ID=SCOD.COID  " & vbNewLine & _
"INNER JOIN mstItem MI ON  " & vbNewLine & _
"	SCOD.ItemID=MI.ID  " & vbNewLine & _
"INNER JOIN mstItemSpecification MIS ON  " & vbNewLine & _
"	MI.ItemSpecificationID=MIS.ID  " & vbNewLine & _
"INNER JOIN mstItemType MIT ON  " & vbNewLine & _
"	MI.ItemTypeID=MIT.ID  " & vbNewLine & _
"INNER JOIN  " & vbNewLine & _
"( " & vbNewLine & _
"	SELECT DISTINCT  " & vbNewLine & _
"POD.ID, POH.PONumber  " & vbNewLine & _
"	FROM traPurchaseOrder POH  " & vbNewLine & _
"	INNER JOIN traPurchaseOrderDet POD ON  " & vbNewLine & _
"POH.ID=POD.POID  " & vbNewLine & _
"	WHERE  " & vbNewLine & _
"POH.ApprovedBy<>''  " & vbNewLine & _
") POD ON  " & vbNewLine & _
"	SCOD.PODetailID=POD.ID  " & vbNewLine & _
"INNER JOIN  " & vbNewLine & _
"( " & vbNewLine & _
"	SELECT DISTINCT  " & vbNewLine & _
"ORD.ID, ORH.OrderNumber " & vbNewLine & _
"	FROM traOrderRequest ORH  " & vbNewLine & _
"	INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine & _
"ORH.ID=ORD.OrderRequestID  " & vbNewLine & _
"	WHERE  " & vbNewLine & _
"ORH.SubmitBy<>''  " & vbNewLine & _
") ORD ON  " & vbNewLine & _
"	SCOD.ORDetailID=ORD.ID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	SCO.ApprovedBy<>''  " & vbNewLine & _
"	AND SCO.ProgramID=@ProgramID  " & vbNewLine & _
"	AND SCO.CompanyID=@CompanyID  " & vbNewLine & _
"	AND SCO.CODate>=@DateFrom AND SCO.CODate<=@DateTo  " & vbNewLine

                If intItemTypeID > 0 Then .CommandText += "	AND MIT.ID=@ItemTypeID  " & vbNewLine
                If intBPID > 0 Then .CommandText += "	AND SCO.BPID=@BPID  " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = intItemTypeID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

    End Class
End Namespace