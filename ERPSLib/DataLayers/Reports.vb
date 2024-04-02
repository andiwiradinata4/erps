Namespace DL
    Public Class Reports

        Public Shared Function MonitoringProductTransactionReportVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                       ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
"SELECT   " & vbNewLine & _
"	POD.ID, POH.PONumber, POH.PODate, POH.BPID, BP.Name AS SupplierName,   " & vbNewLine & _
"	POD.ItemID, MI.ItemName AS POItemName, POD.TotalWeight AS POItemWeight, POD.UnitPrice AS POItemUnitPrice, POD.TotalPrice AS POItemTotalPrice,   " & vbNewLine & _
"	(POD.TotalPrice*POH.PPN/100) AS POItemTotalPPN, POD.TotalPrice+(POD.TotalPrice*POH.PPN/100) AS POItemSubTotal,  " & vbNewLine & _
"	0 AS CategoryID, 'PEMBELIAN' AS CategoryName,   " & vbNewLine & _
"	PCD.CategoryNumber, PCD.CategoryDate, PCD.BPName, PCD.CategoryItemName, PCD.CategoryItemWeight, PCD.CategoryItemUnitPrice, PCD.CategoryItemTotalPrice,   " & vbNewLine & _
"	PCD.CategoryItemTotalPPN, PCD.CategoryItemSubTotal, PCD.CategoryDeliveryWeight, PCD.CategoryTotalPayment   " & vbNewLine & _
"FROM traPurchaseOrder POH   " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON   " & vbNewLine & _
"	POH.BPID=BP.ID   " & vbNewLine & _
"INNER JOIN traPurchaseOrderDet POD ON   " & vbNewLine & _
"	POH.ID=POD.POID   " & vbNewLine & _
"INNER JOIN mstItem MI ON  " & vbNewLine & _
"	POD.ItemID=MI.ID  " & vbNewLine & _
"INNER JOIN traConfirmationOrderDet COD ON   " & vbNewLine & _
"	POD.ID=COD.PODetailID   " & vbNewLine & _
"INNER JOIN traConfirmationOrder COH ON   " & vbNewLine & _
"	COD.COID=COH.ID   " & vbNewLine & _
"	AND COH.IsDeleted=0   " & vbNewLine & _
"INNER JOIN " & vbNewLine & _
"(" & vbNewLine & _
"	SELECT " & vbNewLine & _
"		PCD.CODetailID, PCH.PCNumber AS CategoryNumber, PCH.PCDate AS CategoryDate, BPC.Name AS BPName, " & vbNewLine & _
"		MIPC.ItemName AS CategoryItemName, PCD.TotalWeight AS CategoryItemWeight, PCD.UnitPrice AS CategoryItemUnitPrice, PCD.TotalPrice AS CategoryItemTotalPrice," & vbNewLine & _
"		(PCD.TotalPrice*PCH.PPN/100) AS CategoryItemTotalPPN, PCD.TotalPrice+(PCD.TotalPrice*PCH.PPN/100) AS CategoryItemSubTotal, " & vbNewLine & _
"		PCD.DCWeight AS CategoryDeliveryWeight, PCH.DPAmount+PCH.ReceiveAmount AS CategoryTotalPayment " & vbNewLine & _
"	FROM traPurchaseContractDet PCD " & vbNewLine & _
"	INNER JOIN mstItem MIPC ON  " & vbNewLine & _
"		PCD.ItemID=MIPC.ID  " & vbNewLine & _
"	INNER JOIN traPurchaseContract PCH ON   " & vbNewLine & _
"		PCD.PCID=PCH.ID   " & vbNewLine & _
"		AND PCH.IsDeleted=0   " & vbNewLine & _
"	INNER JOIN mstBusinessPartner BPC ON   " & vbNewLine & _
"		PCH.BPID=BPC.ID   " & vbNewLine & _
") PCD ON " & vbNewLine & _
"	COD.ID=PCD.CODetailID " & vbNewLine & _
"WHERE   " & vbNewLine & _
"	POH.IsDeleted=0   " & vbNewLine & _
"	AND POH.StatusID=@StatusID   " & vbNewLine & _
"	AND POH.ProgramID=@ProgramID   " & vbNewLine & _
"	AND POH.CompanyID=@CompanyID   " & vbNewLine & _
"	AND POH.PODate>=@DateFrom AND POH.PODate<=@DateTo   " & vbNewLine & _
"UNION ALL   " & vbNewLine & _
"SELECT   " & vbNewLine & _
"	POD.ID, POH.PONumber, POH.PODate, POH.BPID, BP.Name AS SupplierName,   " & vbNewLine & _
"	POD.ItemID, MI.ItemName AS POItemName, POD.TotalWeight AS POItemWeight, POD.UnitPrice AS POItemUnitPrice, POD.TotalPrice AS POItemTotalPrice,   " & vbNewLine & _
"	(POD.TotalPrice*POH.PPN/100) AS POItemTotalPPN, POD.TotalPrice+(POD.TotalPrice*POH.PPN/100) AS POItemSubTotal,  " & vbNewLine & _
"	1 AS CategoryID, 'PENJUALAN' AS CategoryName,   " & vbNewLine & _
"	SCD.CategoryNumber, SCD.CategoryDate, SCD.BPName, SCD.CategoryItemName, SCD.CategoryItemWeight, SCD.CategoryItemUnitPrice, SCD.CategoryItemTotalPrice,  " & vbNewLine & _
"	SCD.CategoryItemTotalPPN, SCD.CategoryItemSubTotal, SCD.CategoryDeliveryWeight, SCD.CategoryTotalPayment   " & vbNewLine & _
"FROM traPurchaseOrder POH   " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON   " & vbNewLine & _
"	POH.BPID=BP.ID   " & vbNewLine & _
"INNER JOIN traPurchaseOrderDet POD ON   " & vbNewLine & _
"	POH.ID=POD.POID   " & vbNewLine & _
"INNER JOIN mstItem MI ON  " & vbNewLine & _
"	POD.ItemID=MI.ID  " & vbNewLine & _
"INNER JOIN traConfirmationOrderDet COD ON   " & vbNewLine & _
"	POD.ID=COD.PODetailID   " & vbNewLine & _
"INNER JOIN   " & vbNewLine & _
"(  " & vbNewLine & _
"	SELECT   " & vbNewLine & _
"		SCDCO.CODetailID, SCH.SCNumber AS CategoryNumber, SCH.SCDate AS CategoryDate, BPC.Name AS BPName,   " & vbNewLine & _
"		MISC.ItemName AS CategoryItemName, SCD.TotalWeight AS CategoryItemWeight, SCD.UnitPrice AS CategoryItemUnitPrice, SCD.TotalPrice AS CategoryItemTotalPrice,   " & vbNewLine & _
"		(SCD.TotalPrice*SCH.PPN/100) AS CategoryItemTotalPPN, SCD.TotalPrice+(SCD.TotalPrice*SCH.PPN/100) AS CategoryItemSubTotal,  " & vbNewLine & _
"		SCD.DCWeight AS CategoryDeliveryWeight, SCH.DPAmount+SCH.ReceiveAmount AS CategoryTotalPayment   " & vbNewLine & _
"	FROM traSalesContractDetConfirmationOrder SCDCO   " & vbNewLine & _
"	INNER JOIN traSalesContractDet SCD ON   " & vbNewLine & _
"		SCDCO.SCID=SCD.SCID   " & vbNewLine & _
"		AND SCDCO.GroupID=SCD.GroupID   " & vbNewLine & _
"	INNER JOIN mstItem MISC ON  " & vbNewLine & _
"		SCD.ItemID=MISC.ID  " & vbNewLine & _
"	INNER JOIN traSalesContract SCH ON   " & vbNewLine & _
"		SCD.SCID=SCH.ID   " & vbNewLine & _
"	    AND SCH.IsDeleted=0   " & vbNewLine & _
"	INNER JOIN mstBusinessPartner BPC ON   " & vbNewLine & _
"		SCH.BPID=BPC.ID   " & vbNewLine & _
") SCD ON   " & vbNewLine & _
"	COD.ID=SCD.CODetailID   " & vbNewLine & _
"WHERE   " & vbNewLine & _
"	POH.IsDeleted=0   " & vbNewLine & _
"	AND POH.StatusID=@StatusID   " & vbNewLine & _
"	AND POH.ProgramID=@ProgramID   " & vbNewLine & _
"	AND POH.CompanyID=@CompanyID   " & vbNewLine & _
"	AND POH.PODate>=@DateFrom AND POH.PODate<=@DateTo   " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

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

    End Class
End Namespace