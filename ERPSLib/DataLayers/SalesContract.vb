Namespace DL
    Public Class SalesContract

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SCNumber, A.SCDate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine &
                    "   A.DelegationSeller, A.DelegationPositionSeller, A.DelegationBuyer, A.DelegationPositionBuyer, A.PPN, A.PPH, A.TotalQuantity, " & vbNewLine &
                    "   A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.DPAmount, A.ReceiveAmount, (A.TotalDPP+A.RoundingManual)-(A.DPAmount+A.ReceiveAmount) AS OutstandingPayment, " & vbNewLine &
                    "   A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, " & vbNewLine &
                    "   StatusInfo=B.Name, A.BPLocationID, ISNULL(BPL.Address,'') AS BPLocationAddress, A.IsUseSubItem " & vbNewLine &
                    "FROM traSalesContract A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "LEFT JOIN mstBusinessPartnerLocation BPL ON " & vbNewLine &
                    "   A.BPLocationID=BPL.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.SCDate>=@DateFrom AND A.SCDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOustandingPOTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                             ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SCNumber, A.SCDate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine &
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine &
                    "FROM traSalesContract A " & vbNewLine &
                    "INNER JOIN traSalesContractDet A1 ON " & vbNewLine &
                    "   A.ID=A1.SCID " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.BPID=@BPID " & vbNewLine &
                    "   AND A1.Quantity-A1.POTransportQuantity>0" & vbNewLine &
                    "   AND A1.TotalWeight-A1.POTransportWeight>0" & vbNewLine &
                    "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOustandingDelivery(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                          ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, " & vbNewLine &
                    "   ARNumber=STUFF((SELECT DISTINCT '; ' + ARNumber FROM traAccountReceivable WHERE ReferencesID=A.ID AND IsDeleted=0 AND ApprovedBy<>'' FOR XML PATH('')),1,2,''), " & vbNewLine &
                    "   A.SCNumber, A.SCDate, A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine &
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.IsUseSubItem " & vbNewLine &
                    "FROM traSalesContract A " & vbNewLine &
                    "INNER JOIN traSalesContractDet A1 ON " & vbNewLine &
                    "   A.ID=A1.SCID " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.BPID=@BPID " & vbNewLine &
                    "   AND (A1.InvoiceTotalWeight-A1.DCWeight>0 OR A1.IsIgnoreValidationPayment=1) " & vbNewLine &
                    "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                   ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS SalesID, A.SCNumber AS InvoiceNumber, A.SCDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS SalesAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine &
                    "FROM traSalesContract A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataByPurchaseID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strPCID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT DISTINCT " & vbNewLine & _
"	SCH.ID, SCH.ProgramID, SCH.CompanyID, SCH.SCNumber, SCH.SCDate, SCH.BPID, BP.Code AS BPCode, BP.Name AS BPName   " & vbNewLine & _
"FROM traSalesContract SCH  " & vbNewLine & _
"INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON  " & vbNewLine & _
"	SCH.ID=SCDCO.SCID  " & vbNewLine & _
"INNER JOIN traPurchaseContractDet PCD ON  " & vbNewLine & _
"	SCDCO.CODetailID=PCD.CODetailID  " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON  " & vbNewLine & _
"	SCH.BPID=BP.ID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	SCH.IsDeleted=0  " & vbNewLine & _
"	AND PCD.PCID=@PCID  " & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataByOrderRequestID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                        ByVal strOrderRequestID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT DISTINCT " & vbNewLine & _
"	SCH.ID, SCH.ProgramID, SCH.CompanyID, SCH.SCNumber, SCH.SCDate, SCH.BPID, BP.Code AS BPCode, BP.Name AS BPName   " & vbNewLine & _
"FROM traSalesContract SCH  " & vbNewLine & _
"INNER JOIN traSalesContractDet SCD ON  " & vbNewLine & _
"	SCH.ID=SCD.SCID  " & vbNewLine & _
"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine & _
"	SCD.ORDetailID=ORD.ID  " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON  " & vbNewLine & _
"	SCH.BPID=BP.ID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	SCH.IsDeleted=0  " & vbNewLine & _
"	AND ORD.OrderRequestID=@OrderRequestID  " & vbNewLine

                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstandingClaim(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                        ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SCNumber AS TransactionNumber, CASE WHEN A.ReferencesNumber='' THEN A.SCNumber ELSE A.ReferencesNumber END AS ReferencesNumber, " & vbNewLine &
                    "   A.SCDate AS ReferencesDate, A.BPID, MBP.Code AS BPCode, MBP.Name AS BPName, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH AS GrandTotal, A.Remarks, A.PPN, A.PPH " & vbNewLine &
                    "FROM traSalesContract A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner MBP ON " & vbNewLine &
                    "   A.BPID=MBP.ID " & vbNewLine &
                    "INNER JOIN traSalesContractDet A1 ON " & vbNewLine &
                    "   A.ID=A1.SCID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A1.TotalWeight-A1.ClaimWeight>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDifferentTotalChild(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                           ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine & _
"	SCC.ProgramID, SCC.CompanyID, SCC.SCNumber, SCC.GroupID, SCC.TotalChild AS TotalChildSC, SCCO.TotalChild AS TotalChildCO, SCC.TotalChild-SCCO.TotalChild TotalDifferent  " & vbNewLine & _
"FROM  " & vbNewLine & _
"( " & vbNewLine & _
"	SELECT  " & vbNewLine & _
"       SCH.ProgramID, SCH.CompanyID, SCH.SCDate, SCH.SCNumber, SCD.SCID, SCD.GroupID, SUM(SCD.TotalWeight) TotalChild " & vbNewLine & _
"	FROM traSalesContractDet SCD  " & vbNewLine & _
"	INNER JOIN traSalesContract SCH ON  " & vbNewLine & _
"       SCD.SCID=SCH.ID  " & vbNewLine & _
"       AND SCD.ParentID<>''  " & vbNewLine & _
"       AND SCH.IsDeleted=0  " & vbNewLine & _
"	GROUP BY SCH.ProgramID, SCH.CompanyID, SCH.SCDate, SCH.SCNumber, SCD.SCID, SCD.GroupID " & vbNewLine & _
") SCC  " & vbNewLine & _
"INNER JOIN  " & vbNewLine & _
"( " & vbNewLine & _
"	SELECT SCD.SCID, SCD.GroupID, SUM(SCD.TotalWeight) TotalChild  " & vbNewLine & _
"	FROM traSalesContractDetConfirmationOrder SCD  " & vbNewLine & _
"	INNER JOIN traSalesContract SCH ON  " & vbNewLine & _
"       SCD.SCID=SCH.ID  " & vbNewLine & _
"       AND SCD.ParentID<>''  " & vbNewLine & _
"       AND SCH.IsDeleted=0  " & vbNewLine & _
"	GROUP BY SCD.SCID, SCD.GroupID " & vbNewLine & _
") SCCO ON  " & vbNewLine & _
"	SCC.SCID=SCCO.SCID  " & vbNewLine & _
"	AND SCC.GroupID=SCCO.GroupID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	SCC.ProgramID=@ProgramID  " & vbNewLine & _
"	AND SCC.CompanyID=@CompanyID  " & vbNewLine & _
"	AND SCC.SCDate>=@DateFrom AND SCC.SCDate<=@DateTo  " & vbNewLine & _
"	AND SCC.TotalChild<>SCCO.TotalChild  " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.SalesContract)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO traSalesContract " & vbNewLine &
                        "   (ID, ProgramID, CompanyID, SCNumber, SCDate, BPID, DeliveryPeriodFrom, DeliveryPeriodTo, AllowanceProduction, " & vbNewLine &
                        "    Franco, DelegationSeller, DelegationPositionSeller, DelegationBuyer, DelegationPositionBuyer, PPN, PPH, " & vbNewLine &
                        "    TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, Remarks, " & vbNewLine &
                        "    StatusID, CompanyBankAccountID, CreatedBy, CreatedDate, LogBy, LogDate, BPLocationID, IsUseSubItem) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @SCNumber, @SCDate, @BPID, @DeliveryPeriodFrom, @DeliveryPeriodTo, @AllowanceProduction, " & vbNewLine &
                        "    @Franco, @DelegationSeller, @DelegationPositionSeller, @DelegationBuyer, @DelegationPositionBuyer, @PPN, @PPH, " & vbNewLine &
                        "    @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, @Remarks, " & vbNewLine &
                        "    @StatusID, @CompanyBankAccountID, @LogBy, GETDATE(), @LogBy, GETDATE(), @BPLocationID, @IsUseSubItem) " & vbNewLine
                Else
                    .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    ProgramID=@ProgramID, " & vbNewLine &
                    "    CompanyID=@CompanyID, " & vbNewLine &
                    "    SCNumber=@SCNumber, " & vbNewLine &
                    "    SCDate=@SCDate, " & vbNewLine &
                    "    BPID=@BPID, " & vbNewLine &
                    "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine &
                    "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine &
                    "    AllowanceProduction=@AllowanceProduction, " & vbNewLine &
                    "    Franco=@Franco, " & vbNewLine &
                    "    DelegationSeller=@DelegationSeller, " & vbNewLine &
                    "    DelegationPositionSeller=@DelegationPositionSeller, " & vbNewLine &
                    "    DelegationBuyer=@DelegationBuyer, " & vbNewLine &
                    "    DelegationPositionBuyer=@DelegationPositionBuyer, " & vbNewLine &
                    "    PPN=@PPN, " & vbNewLine &
                    "    PPH=@PPH, " & vbNewLine &
                    "    TotalQuantity=@TotalQuantity, " & vbNewLine &
                    "    TotalWeight=@TotalWeight, " & vbNewLine &
                    "    TotalDPP=@TotalDPP, " & vbNewLine &
                    "    TotalPPN=@TotalPPN, " & vbNewLine &
                    "    TotalPPH=@TotalPPH, " & vbNewLine &
                    "    RoundingManual=@RoundingManual, " & vbNewLine &
                    "    Remarks=@Remarks, " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    CompanyBankAccountID=@CompanyBankAccountID, " & vbNewLine &
                    "    LogInc=LogInc+1, " & vbNewLine &
                    "    LogBy=@LogBy, " & vbNewLine &
                    "    LogDate=GETDATE(), " & vbNewLine &
                    "    BPLocationID=@BPLocationID, " & vbNewLine &
                    "    IsUseSubItem=@IsUseSubItem " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@SCNumber", SqlDbType.VarChar, 100).Value = clsData.SCNumber
                .Parameters.Add("@SCDate", SqlDbType.DateTime).Value = clsData.SCDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@DeliveryPeriodFrom", SqlDbType.DateTime).Value = clsData.DeliveryPeriodFrom
                .Parameters.Add("@DeliveryPeriodTo", SqlDbType.DateTime).Value = clsData.DeliveryPeriodTo
                .Parameters.Add("@AllowanceProduction", SqlDbType.Decimal).Value = clsData.AllowanceProduction
                .Parameters.Add("@Franco", SqlDbType.VarChar, 250).Value = clsData.Franco
                .Parameters.Add("@DelegationSeller", SqlDbType.VarChar, 250).Value = clsData.DelegationSeller
                .Parameters.Add("@DelegationPositionSeller", SqlDbType.VarChar, 250).Value = clsData.DelegationPositionSeller
                .Parameters.Add("@DelegationBuyer", SqlDbType.VarChar, 250).Value = clsData.DelegationBuyer
                .Parameters.Add("@DelegationPositionBuyer", SqlDbType.VarChar, 250).Value = clsData.DelegationPositionBuyer
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@CompanyBankAccountID", SqlDbType.Int).Value = clsData.CompanyBankAccountID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@BPLocationID", SqlDbType.Int).Value = clsData.BPLocationID
                .Parameters.Add("@IsUseSubItem", SqlDbType.Bit).Value = clsData.IsUseSubItem
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.SalesContract
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.SalesContract
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ProgramID, A.CompanyID, A.SCNumber, A.SCDate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine &
                        "   A.DelegationSeller, A.DelegationPositionSeller, A.DelegationBuyer, A.DelegationPositionBuyer, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, " & vbNewLine &
                        "   A.RoundingManual, A.IsDeleted, A.Remarks, A.JournalID, A.StatusID, A.CompanyBankAccountID, C.AccountName, C.BankName, C.AccountNumber, C.Currency AS CurrencyBank, A.SubmitBy, A.SubmitDate, " & vbNewLine &
                        "   A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.ReceiveAmount, GrandTotal=A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual, " & vbNewLine &
                        "   A.BPLocationID, ISNULL(BPL.Address,'') AS BPLocationAddress, A.IsUseSubItem, A.ReferencesNumber, A.AdditionalTerm1, A.AdditionalTerm2, A.AdditionalTerm3, A.AdditionalTerm4, A.AdditionalTerm5, A.AdditionalTerm6, " & vbNewLine &
                        "   A.AdditionalTerm7, A.AdditionalTerm8, A.AdditionalTerm9, A.AdditionalTerm10 " & vbNewLine &
                        "FROM traSalesContract A " & vbNewLine &
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine &
                        "   A.BPID=B.ID " & vbNewLine &
                        "INNER JOIN mstCompanyBankAccount C ON " & vbNewLine &
                        "   A.CompanyBankAccountID=C.ID " & vbNewLine &
                        "LEFT JOIN mstBusinessPartnerLocation BPL ON " & vbNewLine &
                        "   A.BPLocationID=BPL.ID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   A.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.SCNumber = .Item("SCNumber")
                        voReturn.SCDate = .Item("SCDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.DeliveryPeriodFrom = .Item("DeliveryPeriodFrom")
                        voReturn.DeliveryPeriodTo = .Item("DeliveryPeriodTo")
                        voReturn.AllowanceProduction = .Item("AllowanceProduction")
                        voReturn.Franco = .Item("Franco")
                        voReturn.DelegationSeller = .Item("DelegationSeller")
                        voReturn.DelegationPositionSeller = .Item("DelegationPositionSeller")
                        voReturn.DelegationBuyer = .Item("DelegationBuyer")
                        voReturn.DelegationPositionBuyer = .Item("DelegationPositionBuyer")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalQuantity = .Item("TotalQuantity")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.IsDeleted = .Item("IsDeleted")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.JournalID = .Item("JournalID")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.CompanyBankAccountID = .Item("CompanyBankAccountID")
                        voReturn.AccountName = .Item("AccountName")
                        voReturn.BankName = .Item("BankName")
                        voReturn.AccountNumber = .Item("AccountNumber")
                        voReturn.CurrencyBank = .Item("CurrencyBank")
                        voReturn.SubmitBy = .Item("SubmitBy")
                        voReturn.SubmitDate = .Item("SubmitDate")
                        voReturn.ApproveL1 = .Item("ApproveL1")
                        voReturn.ApproveL1Date = .Item("ApproveL1Date")
                        voReturn.ApprovedBy = .Item("ApprovedBy")
                        voReturn.ApprovedDate = .Item("ApprovedDate")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.ReceiveAmount = .Item("ReceiveAmount")
                        voReturn.GrandTotal = .Item("GrandTotal")
                        voReturn.BPLocationID = .Item("BPLocationID")
                        voReturn.BPLocationAddress = .Item("BPLocationAddress")
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
                        voReturn.ReferencesNumber = .Item("ReferencesNumber")
                        voReturn.AdditionalTerm1 = .Item("AdditionalTerm1")
                        voReturn.AdditionalTerm2 = .Item("AdditionalTerm2")
                        voReturn.AdditionalTerm3 = .Item("AdditionalTerm3")
                        voReturn.AdditionalTerm4 = .Item("AdditionalTerm4")
                        voReturn.AdditionalTerm5 = .Item("AdditionalTerm5")
                        voReturn.AdditionalTerm6 = .Item("AdditionalTerm6")
                        voReturn.AdditionalTerm7 = .Item("AdditionalTerm7")
                        voReturn.AdditionalTerm8 = .Item("AdditionalTerm8")
                        voReturn.AdditionalTerm9 = .Item("AdditionalTerm9")
                        voReturn.AdditionalTerm10 = .Item("AdditionalTerm10")
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
                                     ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "   StatusID=@StatusID, " & vbNewLine &
                    "   IsDeleted=1 " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Deleted
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 4),'0000') AS ID " & vbNewLine &
                        "FROM traSalesContract " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY CreatedDate DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Function GetMaxNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intYear As Integer, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT COUNT(*) AS Total " & vbNewLine &
                        "FROM traSalesContract " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   YEAR(SCDate)=@Year " & vbNewLine &
                        "   AND ProgramID=@ProgramID " & vbNewLine &
                        "   AND CompanyID=@CompanyID " & vbNewLine

                    .Parameters.Add("@Year", SqlDbType.Int).Value = intYear
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("Total")
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
                                          ByVal strSCNumber As String, ByVal strID As String) As Boolean
            Dim bolDataExists As Boolean = False
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM traSalesContract " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   SCNumber=@SCNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@SCNumber", SqlDbType.VarChar, 100).Value = strSCNumber
                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        bolDataExists = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolDataExists
        End Function

        Public Shared Function GetStatusID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   StatusID " & vbNewLine &
                        "FROM traSalesContract " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
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

        Public Shared Function IsDeleted(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   StatusID " & vbNewLine &
                        "FROM traSalesContract " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine &
                        "   AND IsDeleted=1 " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
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

        Public Shared Sub Submit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                 ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    SubmitBy=@LogBy, " & vbNewLine &
                    "    SubmitDate=GETDATE() " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = ERPSLib.UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub Unsubmit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    SubmitBy='' " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Draft
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub Approve(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                  ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    ApproveL1=@LogBy, " & vbNewLine &
                    "    ApproveL1Date=GETDATE(), " & vbNewLine &
                    "    ApprovedBy=@LogBy, " & vbNewLine &
                    "    ApprovedDate=GETDATE() " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = ERPSLib.UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub Unapprove(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                    ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    ApproveL1='', " & vbNewLine &
                    "    ApprovedBy='' " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedDownPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                        ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.Amount),0) TotalPayment		" & vbNewLine &
                    "		FROM traAccountReceivableDet ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ARID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.SalesID=@ID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.DownPayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedDownPaymentVer1(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.DPAmount),0) TotalDPAmount " & vbNewLine &
                    "		FROM traSalesContractDet SCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.SCID=@ID " & vbNewLine &
                    "			AND SCD.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.DPAmountPPN),0) TotalDPAmount " & vbNewLine &
                    "		FROM traSalesContractDet SCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.SCID=@ID " & vbNewLine &
                    "			AND SCD.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.DPAmountPPH),0) TotalDPAmount " & vbNewLine &
                    "		FROM traSalesContractDet SCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.SCID=@ID " & vbNewLine &
                    "			AND SCD.ParentID='' " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateItemTotalUsedDownPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal strReferencesID As String, ByVal strReferencesDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.Amount),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.PPN),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.PPH),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.DownPayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateItemTotalUsedDownPaymentParent(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmount),0) TotalDPAmount " & vbNewLine &
                    "		FROM traSalesContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmountPPN),0) TotalDPAmount " & vbNewLine &
                    "		FROM traSalesContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmountPPH),0) TotalDPAmount " & vbNewLine &
                    "		FROM traSalesContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.DownPayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceivePaymentVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.TotalPayment),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDelivery TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.TotalPaymentPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDelivery TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.TotalPaymentPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDelivery TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceivePaymentVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traSalesContractDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traSalesContractDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traSalesContractDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID='' " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                    ByVal strDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentParentVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                          ByVal strDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traSalesContractDet SCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.ParentID=@DetailID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.ReceiveAmountPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traSalesContractDet SCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.ParentID=@DetailID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.ReceiveAmountPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traSalesContractDet SCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.ParentID=@DetailID " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@DetailID " & vbNewLine

                .Parameters.Add("@DetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                    ByVal strDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	AllocateDPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.DPAmount),0) DPAmount " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.Amount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.PPN),0) PPN " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.PPH),0) PPH " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.Quantity),0) Quantity " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceTotalWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.TotalWeight),0) Weight " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentParentVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                          ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	AllocateDPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.AllocateDPAmount),0) DPAmount " & vbNewLine &
                    "		FROM traSalesContractDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ParentID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmount),0) AS ReceiveAmount " & vbNewLine &
                    "		FROM traSalesContractDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ParentID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traSalesContractDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ParentID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traSalesContractDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ParentID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.InvoiceQuantity),0) InvoiceQuantity " & vbNewLine &
                    "		FROM traSalesContractDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ParentID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceTotalWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.InvoiceTotalWeight),0) InvoiceTotalWeight " & vbNewLine &
                    "		FROM traSalesContractDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ParentID " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    JournalID=@JournalID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@JournalID", SqlDbType.VarChar, 100).Value = strJournalID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function IsAlreadyDelivery(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM traSalesContractDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   SCID=@SCID " & vbNewLine &
                        "   AND DCWeight>0 " & vbNewLine

                    .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
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

        Public Shared Function IsAlreadyPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM traSalesContract " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine &
                        "   AND DPAmount+ReceiveAmount>0 " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
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

        Public Shared Function PrintVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                          ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT 	" & vbNewLine &
                    "	SCH.CompanyID, MC.Name AS CompanyName, MC.Address AS CompanyAddress, MC.City AS CompanyCity, MC.Province AS CompanyProvince, MC.SubDistrict AS CompanySubDistrict, MC.DirectorName AS CompanyDirectorName, 	" & vbNewLine &
                    "	SCH.BPID, BP.Code AS BPCode, BP.Name AS BPName, SCH.SCDate, SCH.SCNumber, SCH.DelegationSeller, SCH.DelegationPositionSeller, 	" & vbNewLine &
                    "	CAST('' AS VARCHAR(1000)) AS SCDateAndSubDistrict, SCH.DelegationBuyer, SCH.DelegationPositionBuyer, CAST('' AS VARCHAR(1000)) AS AllItemName, SCH.TotalWeight, " & vbNewLine &
                    "	SCH.TotalQuantity, SCH.TotalDPP + SCH.TotalPPN - SCH.TotalPPH + SCH.RoundingManual AS GrandTotal, SCH.PPN, CAST('' AS VARCHAR(1000)) AS PaymentTerms, 	" & vbNewLine &
                    "	CAST('' AS VARCHAR(1000)) AS DeliveryPeriod, SCH.DeliveryPeriodFrom, SCH.DeliveryPeriodTo, SCH.Franco, ReferencesNumber=ORH.OrderNumber, 	" & vbNewLine &
                    "	CAST('' AS VARCHAR(1000)) AS AllReferencesNumber, SCH.AllowanceProduction, CAST(0 AS INT) AS MaxCreditTerms, BP.Address AS DeliveryAddress, 	" & vbNewLine &
                    "	SCDCO.GroupID, COD.OrderNumberSupplier, CAST('' AS VARCHAR(1000)) AS AllOrderNumberSupplier, SCD.ItemID, MIS.Description AS ItemTypeAndSpec, 	" & vbNewLine &
                    "	MIS.Description AS ItemSpec, MI.Thick, MI.Width, MI.Length, SCD.Weight, SCD.Quantity, SCD.TotalWeight, SCD.UnitPrice, SCD.TotalPrice, (SCD.TotalPrice*SCH.PPN/100) AS TotalPPNItem, 	" & vbNewLine &
                    "	SCD.TotalPrice + (SCD.TotalPrice*SCH.PPN/100) AS TotalPriceIncPPN, CAST('' AS VARCHAR(1000)) AS NumericToString, SCH.StatusID, UomInitial=CASE WHEN IT.LengthInitial='COIL' THEN 'LOT' ELSE 'PCS' END, " & vbNewLine &
                    "   SCH.AdditionalTerm1, SCH.AdditionalTerm2, SCH.AdditionalTerm3, SCH.AdditionalTerm4, SCH.AdditionalTerm5, SCH.AdditionalTerm6, SCH.AdditionalTerm7, SCH.AdditionalTerm8, SCH.AdditionalTerm9, SCH.AdditionalTerm10 " & vbNewLine &
                    "FROM traSalesContract SCH 	" & vbNewLine &
                    "INNER JOIN mstCompany MC ON 	" & vbNewLine &
                    "	SCH.CompanyID=MC.ID 	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner BP ON 	" & vbNewLine &
                    "	SCH.BPID=BP.ID 	" & vbNewLine &
                    "INNER JOIN traSalesContractDet SCD ON 	" & vbNewLine &
                    "	SCH.ID=SCD.SCID 	" & vbNewLine &
                    "INNER JOIN traOrderRequestDet ORD ON 	" & vbNewLine &
                    "	SCD.ORDetailID=ORD.ID 	" & vbNewLine &
                    "INNER JOIN traOrderRequest ORH ON 	" & vbNewLine &
                    "	ORD.OrderRequestID=ORH.ID 	" & vbNewLine &
                    "INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON 	" & vbNewLine &
                    "	SCD.SCID=SCDCO.SCID 	" & vbNewLine &
                    "	AND SCD.GroupID=SCDCO.GroupID 	" & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet COD ON 	" & vbNewLine &
                    "	SCDCO.CODetailID=COD.ID 	" & vbNewLine &
                    "INNER JOIN mstItem MI ON 	" & vbNewLine &
                    "	SCD.ItemID=MI.ID 	" & vbNewLine &
                    "INNER JOIN mstItemType IT ON 	 	" & vbNewLine &
                    "    MI.ItemTypeID=IT.ID 	 	" & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON 	 	" & vbNewLine &
                    "    MI.ItemSpecificationID=MIS.ID 	 	" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "	SCH.ProgramID=@ProgramID " & vbNewLine &
                    "	AND SCH.CompanyID=@CompanyID " & vbNewLine &
                    "	AND SCH.ID=@ID 	" & vbNewLine &
                    "ORDER BY 	" & vbNewLine &
                    "	COD.OrderNumberSupplier, ORH.OrderNumber, MI.Thick, MI.Width, MI.Length, SCD.Weight	" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function PrintSCCOVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                              ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "	BP.Name AS BPName, IT.Description AS ItemTypeName, SCH.SCNumber AS TransNumber, CAST('' AS VARCHAR(1000)) AS AllItemName, " & vbNewLine &
                    "	CAST('' AS VARCHAR(500)) AS AllOrderNumberSupplier, SCH.SCDate AS TransDate, BPL.Address AS DeliveryAddress, SCD.OrderNumberSupplier, " & vbNewLine &
                    "	MIS.Description AS ItemSpec, MI.Thick AS ItemThick, MI.Width AS ItemWidth, CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength, " & vbNewLine &
                    "   Weight=CASE WHEN IT.LengthInitial='COIL' THEN NULL ELSE SCD.Weight END, SCD.Quantity, SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, (SCD.TotalPrice*SCH.PPN/100) AS TotalPPNItem, " & vbNewLine &
                    "	SCD.TotalPrice + (SCD.TotalPrice*SCH.PPN/100) AS TotalPriceIncPPN, CAST('' AS VARCHAR(1000)) AS NumericToString, BP.PICName AS BPPIC, MC.DirectorName AS CompanyDirectorName, " & vbNewLine &
                    "   MBC.AccountName, MBC.BankName, MBC.AccountNumber, SCH.TotalDPP + SCH.TotalPPN - SCH.TotalPPH + SCH.RoundingManual AS GrandTotal, SCH.PPN, SCH.StatusID, SCH.DelegationSeller, " & vbNewLine &
                    "   SCH.DelegationPositionSeller, SCH.DelegationBuyer, SCH.DelegationPositionBuyer, MC.Name AS CompanyName, UomInitial=CASE WHEN IT.LengthInitial='COIL' THEN 'QTY' ELSE 'LBR' END " & vbNewLine &
                    "FROM traSalesContract SCH " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "	SCH.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstCompanyBankAccount MBC ON " & vbNewLine &
                    "	SCH.CompanyBankAccountID=MBC.ID " & vbNewLine &
                    "INNER JOIN traSalesContractDet SCD ON " & vbNewLine &
                    "	SCH.ID=SCD.SCID " & vbNewLine &
                    "	AND SCD.ParentID=''  " & vbNewLine &
                    "INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON " & vbNewLine &
                    "	SCD.SCID=SCDCO.SCID " & vbNewLine &
                    "	AND SCD.GroupID=SCDCO.GroupID " & vbNewLine &
                    "INNER JOIN mstItem MI ON 	 " & vbNewLine &
                    "    SCD.ItemID=MI.ID 	 " & vbNewLine &
                    "INNER JOIN mstItemType IT ON 	 	 " & vbNewLine &
                    "    MI.ItemTypeID=IT.ID 	 	 " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON 	 	 " & vbNewLine &
                    "    MI.ItemSpecificationID=MIS.ID 	 	 " & vbNewLine &
                    "INNER JOIN mstBusinessPartner BP ON	" & vbNewLine &
                    "	SCH.BPID=BP.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartnerLocation BPL ON	" & vbNewLine &
                    "	SCDCO.LocationID=BPL.ID " & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "	SCH.ProgramID=@ProgramID " & vbNewLine &
                    "	AND SCH.CompanyID=@CompanyID " & vbNewLine &
                    "	AND SCH.ID=@ID 	" & vbNewLine

                'If bolIsUseSubItem Then .CommandText += "   AND SCD.ParentID<>'' " & vbNewLine

                .CommandText +=
                    "ORDER BY 	" & vbNewLine &
                    "	SCD.OrderNumberSupplier, IT.Description " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub UpdateReferencesNumber(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String, ByVal strReferencesNumber As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    ReferencesNumber=@ReferencesNumber " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ReferencesNumber", SqlDbType.VarChar, 5000).Value = strReferencesNumber
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SetIsUseSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal bolValue As Boolean)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    IsUseSubItem=@Value " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Value", SqlDbType.Int).Value = bolValue
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateAdditionalTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal clsData As VO.SalesContract)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    AdditionalTerm1=@AdditionalTerm1, " & vbNewLine &
                    "    AdditionalTerm2=@AdditionalTerm2, " & vbNewLine &
                    "    AdditionalTerm3=@AdditionalTerm3, " & vbNewLine &
                    "    AdditionalTerm4=@AdditionalTerm4, " & vbNewLine &
                    "    AdditionalTerm5=@AdditionalTerm5, " & vbNewLine &
                    "    AdditionalTerm6=@AdditionalTerm6, " & vbNewLine &
                    "    AdditionalTerm7=@AdditionalTerm7, " & vbNewLine &
                    "    AdditionalTerm8=@AdditionalTerm8, " & vbNewLine &
                    "    AdditionalTerm9=@AdditionalTerm9, " & vbNewLine &
                    "    AdditionalTerm10=@AdditionalTerm10 " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@AdditionalTerm1", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm1
                .Parameters.Add("@AdditionalTerm2", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm2
                .Parameters.Add("@AdditionalTerm3", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm3
                .Parameters.Add("@AdditionalTerm4", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm4
                .Parameters.Add("@AdditionalTerm5", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm5
                .Parameters.Add("@AdditionalTerm6", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm6
                .Parameters.Add("@AdditionalTerm7", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm7
                .Parameters.Add("@AdditionalTerm8", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm8
                .Parameters.Add("@AdditionalTerm9", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm9
                .Parameters.Add("@AdditionalTerm10", SqlDbType.VarChar, 5000).Value = clsData.AdditionalTerm10
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function IsAlreadyClaim(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   SCD.ID " & vbNewLine &
                        "FROM traSalesContractDet SCD " & vbNewLine &
                        "INNER JOIN traSalesContract SCH ON " & vbNewLine &
                        "   SCD.SCID=SCH.ID " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   SCH.ID=@ID " & vbNewLine &
                        "   AND SCD.ClaimQuantity>0 OR SCD.ClaimWeight>0 " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
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

        Public Shared Sub UpdateDeleteDuplicate(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal clsData As VO.SalesContract)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContract SET " & vbNewLine &
                    "    TotalDPP=@TotalDPP, " & vbNewLine &
                    "    TotalPPN=@TotalPPN, " & vbNewLine &
                    "    TotalPPH=@TotalPPH, " & vbNewLine &
                    "    TotalQuantity=@TotalQuantity, " & vbNewLine &
                    "    TotalWeight=@TotalWeight " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strSCID As String, ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT	" & vbNewLine &
                    "   A.ID, A.SCID, A.ORDetailID, A3.OrderNumber AS RequestNumber, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.SCWeight AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.IsIgnoreValidationPayment, A.OrderNumberSupplier, A.RoundingWeight, A.LevelItem, A.ParentID, A.UnitPriceHPP, " & vbNewLine &
                    "   A.DCQuantity, A.DCWeight, A.CODetailID, A.PCDetailID " & vbNewLine &
                    "FROM traSalesContractDet A  	" & vbNewLine &
                    "INNER JOIN traOrderRequestDet A1 ON  	" & vbNewLine &
                    "    A.ORDetailID=A1.ID  	" & vbNewLine &
                    "INNER JOIN traOrderRequest A3 ON  	" & vbNewLine &
                    "    A1.OrderRequestID=A3.ID  	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "    A.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "    B.ItemTypeID=D.ID  	" & vbNewLine &
                    "WHERE  	" & vbNewLine &
                    "    A.SCID=@SCID	" & vbNewLine &
                    "    AND A.ParentID=@ParentID " & vbNewLine &
                    "ORDER BY A.GroupID " & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                  ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT	" & vbNewLine &
                    "   A.ID, A.SCID, A1.SCNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine &
                    "   A.Quantity-A.POTransportQuantity AS Quantity, A.Weight, A.TotalWeight-A.POTransportWeight AS TotalWeight, A.TotalWeight-A.POTransportWeight AS MaxTotalWeight, A.Remarks, A.RoundingWeight" & vbNewLine &
                    "FROM traSalesContractDet A  	" & vbNewLine &
                    "INNER JOIN traSalesContract A1 ON  	" & vbNewLine &
                    "   A.SCID=A1.ID  	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "   A.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "   B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "   B.ItemTypeID=D.ID  	" & vbNewLine &
                    "WHERE  	" & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   And A1.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.SCID=@SCID	" & vbNewLine &
                    "   And A.TotalWeight+A.RoundingWeight-A.POTransportWeight>0 " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingDelivery(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                 ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                 ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT	" & vbNewLine &
                    "   A.ID, A.SCID, A1.SCNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine &
                    "   A.UnitPrice, A.Quantity-A.DCQuantity AS Quantity, A.Weight, A.TotalWeight-A.DCWeight AS TotalWeight, A.TotalWeight-A.DCWeight AS MaxTotalWeight, A.Remarks, A.RoundingWeight " & vbNewLine &
                    "FROM traSalesContractDet A  	" & vbNewLine &
                    "INNER JOIN traSalesContract A1 ON  	" & vbNewLine &
                    "   A.SCID=A1.ID  	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "   A.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "   B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "   B.ItemTypeID=D.ID  	" & vbNewLine &
                    "WHERE  	" & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   And A1.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.SCID=@SCID	" & vbNewLine &
                    "   And A.TotalWeight+A.RoundingWeight-A.DCWeight>0 " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingDeliveryVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                      ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                      ByVal strSCID As String, ByVal bolIsUseSubItem As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT	" & vbNewLine &
                    "   A.ID, A.SCID, A1.SCNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine &
                    "   A.UnitPrice, CASE WHEN A.Quantity-A.DCQuantity <=0 THEN 1 ELSE A.Quantity-A.DCQuantity END AS Quantity, A.Weight, " & vbNewLine &
                    "   CASE WHEN A.IsIgnoreValidationPayment=1 THEN A.TotalWeight-A.DCWeight ELSE A.InvoiceTotalWeight-A.DCWeight END AS TotalWeight, " & vbNewLine &
                    "   CASE WHEN A.IsIgnoreValidationPayment=1 THEN A.TotalWeight-A.DCWeight ELSE A.InvoiceTotalWeight-A.DCWeight END AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight " & vbNewLine &
                    "FROM traSalesContractDet A  	" & vbNewLine &
                    "INNER JOIN traSalesContract A1 ON  	" & vbNewLine &
                    "   A.SCID=A1.ID  	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "   A.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "   B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "   B.ItemTypeID=D.ID  	" & vbNewLine &
                    "WHERE  	" & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   And A1.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.SCID=@SCID	" & vbNewLine &
                    "   And (A.InvoiceTotalWeight-A.DCWeight>0 OR A.IsIgnoreValidationPayment=1) " & vbNewLine

                If bolIsUseSubItem Then .CommandText += "   And A.ParentID<>'' " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingClaim(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                              ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine &
"	SCD.ID, SCD.SCID AS ParentID, SCH.SCNumber AS ParentNumber, SCD.OrderNumberSupplier, CASE WHEN SCH.ReferencesNumber='' THEN SCH.SCNumber ELSE SCH.ReferencesNumber END AS ReferencesNumber, " & vbNewLine &
"	SCD.ItemID, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName,  " & vbNewLine &
"	SCD.Quantity-SCD.ClaimQuantity AS Quantity, SCD.Weight, SCD.TotalWeight-SCD.ClaimWeight AS TotalWeight, SCD.UnitPrice,  " & vbNewLine &
"	SCD.TotalPrice, SCD.RoundingWeight, SCD.Remarks, SCD.TotalWeight-SCD.ClaimWeight AS MaxTotalWeight " & vbNewLine &
"FROM traSalesContractDet SCD  " & vbNewLine &
"INNER JOIN traSalesContract SCH ON  " & vbNewLine &
"	SCD.SCID=SCH.ID  " & vbNewLine &
"INNER JOIN mstItem MI ON    " & vbNewLine &
"    SCD.ItemID=MI.ID    " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON    " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID    " & vbNewLine &
"INNER JOIN mstItemType MIT ON    " & vbNewLine &
"    MI.ItemTypeID=MIT.ID    " & vbNewLine &
"WHERE  " & vbNewLine &
"	SCH.ID=@SCID  " & vbNewLine &
"	AND SCD.TotalWeight-SCD.ClaimWeight>0   " & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailByCODetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal strCODetailID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT	" & vbNewLine &
                    "   A.ID, A.SCID, A.ORDetailID, A3.OrderNumber AS RequestNumber, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.SCWeight AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.IsIgnoreValidationPayment, A.OrderNumberSupplier, A.RoundingWeight, A.LevelItem, A.ParentID, A.UnitPriceHPP, " & vbNewLine &
                    "   A.DCQuantity, A.DCWeight, A.CODetailID, A.PCDetailID " & vbNewLine &
                    "FROM traSalesContractDet A  	" & vbNewLine &
                    "INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON  	" & vbNewLine &
                    "    A.SCID=SCDCO.SCID " & vbNewLine &
                    "    AND A.GroupID=SCDCO.GroupID " & vbNewLine &
                    "INNER JOIN traOrderRequestDet A1 ON  	" & vbNewLine &
                    "    A.ORDetailID=A1.ID  	" & vbNewLine &
                    "INNER JOIN traOrderRequest A3 ON  	" & vbNewLine &
                    "    A1.OrderRequestID=A3.ID  	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "    A.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "    B.ItemTypeID=D.ID  	" & vbNewLine &
                    "WHERE  	" & vbNewLine &
                    "    SCDCO.CODetailID=@CODetailID	" & vbNewLine &
                    "ORDER BY A.GroupID " & vbNewLine

                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = strCODetailID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.SalesContractDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesContractDet " & vbNewLine &
                    "   ( ID, SCID, ORDetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, OrderNumberSupplier, RoundingWeight, LevelItem, ParentID, UnitPriceHPP) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   ( @ID, @SCID, @ORDetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @OrderNumberSupplier, @RoundingWeight, @LevelItem, @ParentID, @UnitPriceHPP) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = clsData.SCID
                .Parameters.Add("@ORDetailID", SqlDbType.VarChar, 100).Value = clsData.ORDetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@DCQuantity", SqlDbType.Decimal).Value = clsData.DCQuantity
                .Parameters.Add("@DCWeight", SqlDbType.Decimal).Value = clsData.DCWeight
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = clsData.UnitPriceHPP
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strSCID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traSalesContractDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   SCID=@SCID" & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTransportTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strSCDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	POTransportWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(POD.TotalWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traPurchaseOrderTransportDet POD 	" & vbNewLine &
                    "		INNER JOIN traPurchaseOrderTransport POH ON	" & vbNewLine &
                    "			POD.POID=POH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			POD.SCDetailID=@SCDetailID 	" & vbNewLine &
                    "			And POH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	POTransportQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(POD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traPurchaseOrderTransportDet POD 	" & vbNewLine &
                    "		INNER JOIN traPurchaseOrderTransport POH ON	" & vbNewLine &
                    "			POD.POID=POH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			POD.SCDetailID=@SCDetailID 	" & vbNewLine &
                    "			And POH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@SCDetailID	" & vbNewLine

                .Parameters.Add("@SCDetailID", SqlDbType.VarChar, 100).Value = strSCDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDCTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strSCDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	DCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(DD.TotalWeight+DD.RoundingWeight),0) TotalWeight   " & vbNewLine &
                    "		FROM traDeliveryDet DD 	" & vbNewLine &
                    "		INNER JOIN traDelivery DH ON	" & vbNewLine &
                    "			DD.DeliveryID=DH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			DD.SCDetailID=@SCDetailID 	" & vbNewLine &
                    "			And DH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	DCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(DD.Quantity),0) TotalQuantity    " & vbNewLine &
                    "		FROM traDeliveryDet DD 	" & vbNewLine &
                    "		INNER JOIN traDelivery DH ON	" & vbNewLine &
                    "			DD.DeliveryID=DH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			DD.SCDetailID=@SCDetailID 	" & vbNewLine &
                    "			And DH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@SCDetailID	" & vbNewLine

                .Parameters.Add("@SCDetailID", SqlDbType.VarChar, 100).Value = strSCDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDCTotalUsedParent(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                     ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	DCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(DD.TotalWeight+DD.RoundingWeight),0) TotalWeight   " & vbNewLine &
                    "		FROM traDeliveryDet DD 	" & vbNewLine &
                    "		INNER JOIN traDelivery DH ON	" & vbNewLine &
                    "			DD.DeliveryID=DH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			DD.ParentID=@ParentID 	" & vbNewLine &
                    "			And DH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	DCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(DD.Quantity),0) TotalQuantity    " & vbNewLine &
                    "		FROM traDeliveryDet DD 	" & vbNewLine &
                    "		INNER JOIN traDelivery DH ON	" & vbNewLine &
                    "			DD.DeliveryID=DH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			DD.ParentID=@ParentID 	" & vbNewLine &
                    "			And DH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@ParentID	" & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SetupIsIgnoreValidationPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                         ByVal strSCID As String, ByVal bolValue As Boolean)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	IsIgnoreValidationPayment=@Value " & vbNewLine &
                    "WHERE SCID=@SCID	" & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
                .Parameters.Add("@Value", SqlDbType.Bit).Value = bolValue
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 3),'000') AS ID " & vbNewLine &
                        "FROM traSalesContractDet " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Sub DeleteDataDetailByID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traSalesContractDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function IsAlreadyPaymentSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM traSalesContractDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine &
                        "   AND (DPAmount>0 OR ReceiveAmount>0 OR InvoiceQuantity>0 OR InvoiceTotalWeight>0) " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
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

        Public Shared Function IsAlreadyReceiveSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM traSalesContractDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine &
                        "   AND (DCWeight>0 OR DCQuantity>0) " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
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

        Public Shared Sub CalculateClaimTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strReferencesDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET 	" & vbNewLine &
                    "	ClaimWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(CD.TotalWeight+CD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traClaimDet CD 	" & vbNewLine &
                    "		INNER JOIN traClaim CH ON	" & vbNewLine &
                    "			CD.ClaimID=CH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			CD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND CH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	ClaimQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(CD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traClaimDet CD 	" & vbNewLine &
                    "		INNER JOIN traClaim CH ON	" & vbNewLine &
                    "			CD.ClaimID=CH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			CD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND CH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@ReferencesDetailID	" & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub ChangeItemIDDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String, ByVal intOldItemID As Integer, ByVal intNewItemID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traSalesContractDet SET  " & vbNewLine &
"	ItemID=@NewItemID " & vbNewLine &
"WHERE " & vbNewLine &
"	ItemID=@OldItemID " & vbNewLine &
"	AND ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@OldItemID", SqlDbType.Int).Value = intOldItemID
                .Parameters.Add("@NewItemID", SqlDbType.Int).Value = intNewItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub ChangeItemIDDetailCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strPCDetailID As String, ByVal intOldItemID As Integer, ByVal intNewItemID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traSalesContractDetConfirmationOrder SET  " & vbNewLine &
"	ItemID=@NewItemID " & vbNewLine &
"WHERE " & vbNewLine &
"	ItemID=@OldItemID " & vbNewLine &
"	AND PCDetailID=@PCDetailID " & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
                .Parameters.Add("@OldItemID", SqlDbType.Int).Value = intOldItemID
                .Parameters.Add("@NewItemID", SqlDbType.Int).Value = intNewItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateDetailItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strID As String, ByVal strOrderNumberSupplier As String,
                                           ByVal decUnitPriceHPP As Decimal)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET " & vbNewLine &
                    "   OrderNumberSupplier=@OrderNumberSupplier, UnitPriceHPP=@UnitPriceHPP " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = decUnitPriceHPP
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateDetailGroupID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strID As String, ByVal intGroupID As Integer,
                                              ByVal decUnitPriceHPP As Decimal)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDet SET " & vbNewLine &
                    "   GroupID=@GroupID, UnitPriceHPP=@UnitPriceHPP " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = intGroupID
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = decUnitPriceHPP
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail CO"

        Public Shared Function ListDataDetailCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strSCID As String, ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT	" & vbNewLine &
                    "   A.ID, A.SCID, A.CODetailID, A3.CONumber, A1.OrderNumberSupplier, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, A.Quantity, A.Weight, " & vbNewLine &
                    "   A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.SCWeight AS MaxTotalWeight, A.Remarks, A.RoundingWeight, A.LevelItem, A.ParentID, " & vbNewLine &
                    "   A.LocationID, BPL.Address AS DeliveryAddress, A.PCDetailID " & vbNewLine &
                    "FROM traSalesContractDetConfirmationOrder A  	" & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet A1 ON  	" & vbNewLine &
                    "    A.CODetailID=A1.ID  	" & vbNewLine &
                    "INNER JOIN traConfirmationOrder A3 ON  	" & vbNewLine &
                    "    A1.COID=A3.ID  	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "    A.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "    B.ItemTypeID=D.ID  	" & vbNewLine &
                    "INNER JOIN mstBusinessPartnerLocation BPL ON	" & vbNewLine &
                    "	A.LocationID=BPL.ID " & vbNewLine &
                    "WHERE  	" & vbNewLine &
                    "    A.SCID=@SCID	" & vbNewLine &
                    "    AND A.ParentID=@ParentID " & vbNewLine &
                    "ORDER BY A.GroupID " & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataByOrderRequestDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                              ByVal strOrderRequestDetailID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT DISTINCT " & vbNewLine &
"	SCD.ID AS SCDetailID " & vbNewLine &
"FROM traSalesContract SCH  " & vbNewLine &
"INNER JOIN traSalesContractDet SCD ON  " & vbNewLine &
"	SCH.ID=SCD.SCID  " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine &
"	SCD.ORDetailID=ORD.ID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	SCH.IsDeleted=0  " & vbNewLine &
"	AND ORD.ID=@OrderRequestDetailID  " & vbNewLine

                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = strOrderRequestDetailID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataByOrderRequestDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                              ByVal strOrderRequestDetailID As String, ByVal intItemID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT DISTINCT " & vbNewLine &
"	SCD.ID AS SCDetailID " & vbNewLine &
"FROM traSalesContract SCH  " & vbNewLine &
"INNER JOIN traSalesContractDet SCD ON  " & vbNewLine &
"	SCH.ID=SCD.SCID  " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine &
"	SCD.ORDetailID=ORD.ID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	SCH.IsDeleted=0  " & vbNewLine &
"	AND ORD.ID=@OrderRequestDetailID  " & vbNewLine &
"	AND SCD.ItemID=@ItemID  " & vbNewLine

                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = strOrderRequestDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataCOByPurchaseContractDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal strPCDetailID As String, ByVal intItemID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT DISTINCT " & vbNewLine &
"	SCD.ID AS SCDetailID " & vbNewLine &
"FROM traSalesContract SCH  " & vbNewLine &
"INNER JOIN traSalesContractDetCO SCD ON  " & vbNewLine &
"	SCH.ID=SCD.SCID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	SCH.IsDeleted=0  " & vbNewLine &
"	AND SCD.PCDetailID=@PCDetailID " & vbNewLine &
"	AND SCD.ItemID=@ItemID  " & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetailCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal clsData As VO.SalesContractDetConfirmationOrder)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesContractDetConfirmationOrder " & vbNewLine &
                    "   (ID, SCID, CODetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, RoundingWeight, LevelItem, ParentID, LocationID, PCDetailID) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @SCID, @CODetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @RoundingWeight, @LevelItem, @ParentID, @LocationID, @PCDetailID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = clsData.SCID
                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = clsData.CODetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@LocationID", SqlDbType.Int).Value = clsData.LocationID
                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = clsData.PCDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetailCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strSCID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traSalesContractDetConfirmationOrder     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   SCID=@SCID" & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ListDataPurchaseContractNumber(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                              ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                              ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT DISTINCT PCH.PCNumber  " & vbNewLine &
"FROM traSalesContractDetConfirmationOrder SCCO  " & vbNewLine &
"INNER JOIN traPurchaseContractDet PCD ON  " & vbNewLine &
"	SCCO.CODetailID=PCD.CODetailID  " & vbNewLine &
"INNER JOIN traPurchaseContract PCH ON  " & vbNewLine &
"	PCD.PCID=PCH.ID  " & vbNewLine &
"WHERE " & vbNewLine &
"   PCH.ProgramID=@ProgramID  " & vbNewLine &
"   And PCH.CompanyID=@CompanyID  " & vbNewLine &
"   And SCCO.SCID=@SCID  " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function GetMaxIDDetailCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 3),'000') AS ID " & vbNewLine &
                        "FROM traSalesContractDetConfirmationOrder " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Sub DeleteDataDetailCOByID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traSalesContractDetConfirmationOrder     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateDetailCOItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal clsData As VO.SalesContractDetConfirmationOrder)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesContractDetConfirmationOrder SET " & vbNewLine &
                    "   CODetailID=@CODetailID, ItemID=@ItemID, UnitPrice=@UnitPrice, TotalPrice=@TotalPrice " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = clsData.CODetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdatePriceItemByCODetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strCODetailID As String, ByVal decUnitPrice As Decimal)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText = _
"UPDATE traSalesContractDetConfirmationOrder SET " & vbNewLine & _
"	UnitPrice=@UnitPrice, " & vbNewLine & _
"	TotalPrice=@UnitPrice * (TotalWeight + RoundingWeight) " & vbNewLine & _
"WHERE" & vbNewLine & _
"	CODetailID=@CODetailID " & vbNewLine

                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = strCODetailID
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = decUnitPrice
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub
#End Region

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.SCID, A.Percentage, A.PaymentTypeID, B.Code AS PaymentTypeCode, B.Name AS PaymentTypeName, " & vbNewLine &
                    "   A.PaymentModeID, C.Code AS PaymentModeCode, C.Name AS PaymentModeName, A.CreditTerm, A.Remarks " & vbNewLine &
                    "FROM traSalesContractPaymentTerm A " & vbNewLine &
                    "INNER JOIN mstPaymentType B ON " & vbNewLine &
                    "   A.PaymentTypeID=B.ID " & vbNewLine &
                    "INNER JOIN mstPaymentMode C ON " & vbNewLine &
                    "   A.PaymentModeID=C.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.SCID=@SCID " & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal clsData As VO.SalesContractPaymentTerm)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesContractPaymentTerm " & vbNewLine &
                    "   (ID, SCID, Percentage, PaymentTypeID, PaymentModeID, CreditTerm, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @SCID, @Percentage, @PaymentTypeID, @PaymentModeID, @CreditTerm, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = clsData.SCID
                .Parameters.Add("@Percentage", SqlDbType.Decimal).Value = clsData.Percentage
                .Parameters.Add("@PaymentTypeID", SqlDbType.Int).Value = clsData.PaymentTypeID
                .Parameters.Add("@PaymentModeID", SqlDbType.Int).Value = clsData.PaymentModeID
                .Parameters.Add("@CreditTerm", SqlDbType.Int).Value = clsData.CreditTerm
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strSCID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traSalesContractPaymentTerm     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   SCID=@SCID" & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.SCID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traSalesContractStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.SCID=@SCID " & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.SalesContractStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesContractStatus " & vbNewLine &
                    "   (ID, SCID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @SCID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = clsData.SCID
                .Parameters.Add("@Status", SqlDbType.VarChar, 100).Value = clsData.Status
                .Parameters.Add("@StatusBy", SqlDbType.VarChar, 20).Value = clsData.StatusBy
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strSCID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traSalesContractStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   SCID=@SCID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

#End Region

    End Class
End Namespace