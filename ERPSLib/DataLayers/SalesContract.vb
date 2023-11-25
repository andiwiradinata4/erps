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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SCNumber, A.SCDate, " & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine & _
                    "   A.DelegationSeller, A.DelegationPositionSeller, A.DelegationBuyer, A.DelegationPositionBuyer, A.PPN, A.PPH, A.TotalQuantity, " & vbNewLine & _
                    "   A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine & _
                    "   A.DPAmount, A.ReceiveAmount, (A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual)-(A.DPAmount+A.ReceiveAmount) AS OutstandingPayment, " & vbNewLine & _
                    "   A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine & _
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traSalesContract A " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "   A.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
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
                .CommandText = _
                    "SELECT DISTINCT " & vbNewLine & _
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SCNumber, A.SCDate, " & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine & _
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine & _
                    "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traSalesContract A " & vbNewLine & _
                    "INNER JOIN traSalesContractDet A1 ON " & vbNewLine & _
                    "   A.ID=A1.SCID " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "   A.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.BPID=@BPID " & vbNewLine & _
                    "   AND A1.Quantity-A1.POTransportQuantity>0" & vbNewLine & _
                    "   AND A1.TotalWeight-A1.POTransportWeight>0" & vbNewLine & _
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
                .CommandText = _
                    "SELECT DISTINCT " & vbNewLine & _
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SCNumber, A.SCDate, " & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine & _
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine & _
                    "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traSalesContract A " & vbNewLine & _
                    "INNER JOIN traSalesContractDet A1 ON " & vbNewLine & _
                    "   A.ID=A1.SCID " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "   A.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.BPID=@BPID " & vbNewLine & _
                    "   AND A1.Quantity-A1.DCQuantity>0" & vbNewLine & _
                    "   AND A1.TotalWeight-A1.DCWeight>0" & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST(0 AS BIT) AS Pick, A.ID AS SalesID, A.SCNumber AS InvoiceNumber, A.SCDate AS InvoiceDate, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS SalesAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine & _
                    "   CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine & _
                    "FROM traSalesContract A " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.BPID=@BPID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.ApprovedBy<>'' " & vbNewLine & _
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.SalesContract)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO traSalesContract " & vbNewLine & _
                        "   (ID, ProgramID, CompanyID, SCNumber, SCDate, BPID, DeliveryPeriodFrom, DeliveryPeriodTo, AllowanceProduction, " & vbNewLine & _
                        "    Franco, DelegationSeller, DelegationPositionSeller, DelegationBuyer, DelegationPositionBuyer, PPN, PPH, " & vbNewLine & _
                        "    TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, Remarks, " & vbNewLine & _
                        "    StatusID, CompanyBankAccountID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "   (@ID, @ProgramID, @CompanyID, @SCNumber, @SCDate, @BPID, @DeliveryPeriodFrom, @DeliveryPeriodTo, @AllowanceProduction, " & vbNewLine & _
                        "    @Franco, @DelegationSeller, @DelegationPositionSeller, @DelegationBuyer, @DelegationPositionBuyer, @PPN, @PPH, " & vbNewLine & _
                        "    @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, @Remarks, " & vbNewLine & _
                        "    @StatusID, @CompanyBankAccountID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine
                Else
                    .CommandText = _
                    "UPDATE traSalesContract SET " & vbNewLine & _
                    "    ProgramID=@ProgramID, " & vbNewLine & _
                    "    CompanyID=@CompanyID, " & vbNewLine & _
                    "    SCNumber=@SCNumber, " & vbNewLine & _
                    "    SCDate=@SCDate, " & vbNewLine & _
                    "    BPID=@BPID, " & vbNewLine & _
                    "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine & _
                    "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine & _
                    "    AllowanceProduction=@AllowanceProduction, " & vbNewLine & _
                    "    Franco=@Franco, " & vbNewLine & _
                    "    DelegationSeller=@DelegationSeller, " & vbNewLine & _
                    "    DelegationPositionSeller=@DelegationPositionSeller, " & vbNewLine & _
                    "    DelegationBuyer=@DelegationBuyer, " & vbNewLine & _
                    "    DelegationPositionBuyer=@DelegationPositionBuyer, " & vbNewLine & _
                    "    PPN=@PPN, " & vbNewLine & _
                    "    PPH=@PPH, " & vbNewLine & _
                    "    TotalQuantity=@TotalQuantity, " & vbNewLine & _
                    "    TotalWeight=@TotalWeight, " & vbNewLine & _
                    "    TotalDPP=@TotalDPP, " & vbNewLine & _
                    "    TotalPPN=@TotalPPN, " & vbNewLine & _
                    "    TotalPPH=@TotalPPH, " & vbNewLine & _
                    "    RoundingManual=@RoundingManual, " & vbNewLine & _
                    "    Remarks=@Remarks, " & vbNewLine & _
                    "    StatusID=@StatusID, " & vbNewLine & _
                    "    CompanyBankAccountID=@CompanyBankAccountID, " & vbNewLine & _
                    "    LogInc=LogInc+1, " & vbNewLine & _
                    "    LogBy=@LogBy, " & vbNewLine & _
                    "    LogDate=GETDATE() " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.ProgramID, A.CompanyID, A.SCNumber, A.SCDate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine & _
                        "   A.DelegationSeller, A.DelegationPositionSeller, A.DelegationBuyer, A.DelegationPositionBuyer, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, " & vbNewLine & _
                        "   A.RoundingManual, A.IsDeleted, A.Remarks, A.JournalID, A.StatusID, A.CompanyBankAccountID, C.AccountName, C.BankName, C.AccountNumber, C.Currency AS CurrencyBank, A.SubmitBy, A.SubmitDate, " & vbNewLine & _
                        "   A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.ReceiveAmount " & vbNewLine & _
                        "FROM traSalesContract A " & vbNewLine & _
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine & _
                        "   A.BPID=B.ID " & vbNewLine & _
                        "INNER JOIN mstCompanyBankAccount C ON " & vbNewLine & _
                        "   A.CompanyBankAccountID=C.ID " & vbNewLine & _
                        "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContract SET " & vbNewLine & _
                    "   StatusID=@StatusID, " & vbNewLine & _
                    "   IsDeleted=1 " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ISNULL(RIGHT(ID, 4),'0000') AS ID " & vbNewLine & _
                        "FROM traSalesContract " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   LEFT(ID,@Length)=@ID " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID " & vbNewLine & _
                        "FROM traSalesContract " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   SCNumber=@SCNumber " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   StatusID " & vbNewLine & _
                        "FROM traSalesContract " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   StatusID " & vbNewLine & _
                        "FROM traSalesContract " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   ID=@ID " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContract SET " & vbNewLine & _
                    "    StatusID=@StatusID, " & vbNewLine & _
                    "    SubmitBy=@LogBy, " & vbNewLine & _
                    "    SubmitDate=GETDATE() " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContract SET " & vbNewLine & _
                    "    StatusID=@StatusID, " & vbNewLine & _
                    "    SubmitBy='' " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContract SET " & vbNewLine & _
                    "    StatusID=@StatusID, " & vbNewLine & _
                    "    ApproveL1=@LogBy, " & vbNewLine & _
                    "    ApproveL1Date=GETDATE(), " & vbNewLine & _
                    "    ApprovedBy=@LogBy, " & vbNewLine & _
                    "    ApprovedDate=GETDATE() " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContract SET " & vbNewLine & _
                    "    StatusID=@StatusID, " & vbNewLine & _
                    "    ApproveL1='', " & vbNewLine & _
                    "    ApprovedBy='' " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContract SET 	" & vbNewLine & _
                    "	DPAmount=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(ARD.Amount),0) TotalPayment		" & vbNewLine & _
                    "		FROM traAccountReceivableDet ARD 	" & vbNewLine & _
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine & _
                    "			ARD.ARID=ARH.ID 	" & vbNewLine & _
                    "			AND ARH.Modules=@Modules " & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			ARD.SalesID=@ID 	" & vbNewLine & _
                    "			AND ARH.IsDeleted=0 	" & vbNewLine & _
                    "	) " & vbNewLine & _
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

        Public Shared Sub CalculateTotalUsedReceivePayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traSalesContract SET 	" & vbNewLine & _
                    "	ReceiveAmount=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(ARD.Amount),0) TotalPayment		" & vbNewLine & _
                    "		FROM traAccountReceivableDet ARD 	" & vbNewLine & _
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine & _
                    "			ARD.ARID=ARH.ID 	" & vbNewLine & _
                    "			AND ARH.Modules=@Modules " & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			ARD.SalesID=@ID 	" & vbNewLine & _
                    "			AND ARH.IsDeleted=0 	" & vbNewLine & _
                    "	) " & vbNewLine & _
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

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traSalesContract SET " & vbNewLine & _
                    "    JournalID=@JournalID " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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

        Public Shared Function IsAlreadyPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID " & vbNewLine & _
                        "FROM traSalesContract " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   ID=@ID " & vbNewLine & _
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
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "	SCH.CompanyID, MC.Name AS CompanyName, MC.Address AS CompanyAddress, MC.City AS CompanyCity, MC.Province AS CompanyProvince, MC.SubDistrict AS CompanySubDistrict, MC.DirectorName AS CompanyDirectorName, 	" & vbNewLine & _
                    "	SCH.BPID, BP.Code AS BPCode, BP.Name AS BPName, SCH.SCDate, SCH.SCNumber, SCH.DelegationSeller, SCH.DelegationPositionSeller, 	" & vbNewLine & _
                    "	CAST('' AS VARCHAR(1000)) AS SCDateAndSubDistrict, SCH.DelegationBuyer, SCH.DelegationPositionBuyer, CAST('' AS VARCHAR(1000)) AS AllItemName, SCH.TotalWeight, " & vbNewLine & _
                    "	SCH.TotalQuantity, SCH.TotalDPP + SCH.TotalPPN - SCH.TotalPPH + SCH.RoundingManual AS GrandTotal, SCH.PPN, CAST('' AS VARCHAR(1000)) AS PaymentTerms, 	" & vbNewLine & _
                    "	CAST('' AS VARCHAR(1000)) AS DeliveryPeriod, SCH.DeliveryPeriodFrom, SCH.DeliveryPeriodTo, SCH.Franco, ORH.ReferencesNumber, 	" & vbNewLine & _
                    "	CAST('' AS VARCHAR(1000)) AS AllReferencesNumber, SCH.AllowanceProduction, CAST(0 AS INT) AS MaxCreditTerms, BP.Address AS DeliveryAddress, 	" & vbNewLine & _
                    "	SCDCO.GroupID, COD.OrderNumberSupplier, CAST('' AS VARCHAR(1000)) AS AllOrderNumberSupplier, SCD.ItemID, IT.Description + ' ' + MIS.Description AS ItemTypeAndSpec, 	" & vbNewLine & _
                    "	MIS.Description AS ItemSpec, MI.Thick, MI.Width, MI.Length, SCD.Weight, SCD.Quantity, SCD.TotalWeight, SCD.UnitPrice, SCD.TotalPrice, (SCD.TotalPrice*SCH.PPN/100) AS TotalPPNItem, 	" & vbNewLine & _
                    "	SCD.TotalPrice + (SCD.TotalPrice*SCH.PPN/100) AS TotalPriceIncPPN, CAST('' AS VARCHAR(1000)) AS NumericToString, SCH.StatusID " & vbNewLine & _
                    "FROM traSalesContract SCH 	" & vbNewLine & _
                    "INNER JOIN mstCompany MC ON 	" & vbNewLine & _
                    "	SCH.CompanyID=MC.ID 	" & vbNewLine & _
                    "INNER JOIN mstBusinessPartner BP ON 	" & vbNewLine & _
                    "	SCH.BPID=BP.ID 	" & vbNewLine & _
                    "INNER JOIN traSalesContractDet SCD ON 	" & vbNewLine & _
                    "	SCH.ID=SCD.SCID 	" & vbNewLine & _
                    "INNER JOIN traOrderRequestDet ORD ON 	" & vbNewLine & _
                    "	SCD.ORDetailID=ORD.ID 	" & vbNewLine & _
                    "INNER JOIN traOrderRequest ORH ON 	" & vbNewLine & _
                    "	ORD.OrderRequestID=ORH.ID 	" & vbNewLine & _
                    "INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON 	" & vbNewLine & _
                    "	SCD.SCID=SCDCO.SCID 	" & vbNewLine & _
                    "	AND SCD.GroupID=SCDCO.GroupID 	" & vbNewLine & _
                    "INNER JOIN traConfirmationOrderDet COD ON 	" & vbNewLine & _
                    "	SCDCO.CODetailID=COD.ID 	" & vbNewLine & _
                    "INNER JOIN mstItem MI ON 	" & vbNewLine & _
                    "	SCD.ItemID=MI.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemType IT ON 	 	" & vbNewLine & _
                    "    MI.ItemTypeID=IT.ID 	 	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification MIS ON 	 	" & vbNewLine & _
                    "    MI.ItemSpecificationID=MIS.ID 	 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "	SCH.ProgramID=@ProgramID " & vbNewLine & _
                    "	AND SCH.CompanyID=@CompanyID " & vbNewLine & _
                    "	AND SCH.ID=@ID 	" & vbNewLine & _
                    "ORDER BY 	" & vbNewLine & _
                    "	COD.OrderNumberSupplier, ORH.ReferencesNumber, MI.Thick, MI.Width, MI.Length, SCD.Weight	" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT	" & vbNewLine & _
                    "    A.ID, A.SCID, A.ORDetailID, A3.ID AS RequestNumber, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine & _
                    "    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine & _
                    "    A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.SCWeight AS MaxTotalWeight, A.Remarks  	" & vbNewLine & _
                    "FROM traSalesContractDet A  	" & vbNewLine & _
                    "INNER JOIN traOrderRequestDet A1 ON  	" & vbNewLine & _
                    "    A.ORDetailID=A1.ID  	" & vbNewLine & _
                    "INNER JOIN traOrderRequest A3 ON  	" & vbNewLine & _
                    "    A1.OrderRequestID=A3.ID  	" & vbNewLine & _
                    "INNER JOIN mstItem B ON  	" & vbNewLine & _
                    "    A.ItemID=B.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine & _
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON  	" & vbNewLine & _
                    "    B.ItemTypeID=D.ID  	" & vbNewLine & _
                    "WHERE  	" & vbNewLine & _
                    "    A.SCID=@SCID	" & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
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
                .CommandText = _
                    "SELECT	" & vbNewLine & _
                    "   A.ID, A.SCID, A1.SCNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine & _
                    "   A.Quantity, A.Weight, A.TotalWeight, A.TotalWeight-A.POTransportWeight AS MaxTotalWeight, A.Remarks  	" & vbNewLine & _
                    "FROM traSalesContractDet A  	" & vbNewLine & _
                    "INNER JOIN traSalesContract A1 ON  	" & vbNewLine & _
                    "   A.SCID=A1.ID  	" & vbNewLine & _
                    "INNER JOIN mstItem B ON  	" & vbNewLine & _
                    "   A.ItemID=B.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine & _
                    "   B.ItemSpecificationID=C.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON  	" & vbNewLine & _
                    "   B.ItemTypeID=D.ID  	" & vbNewLine & _
                    "WHERE  	" & vbNewLine & _
                    "   A1.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A1.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.SCID=@SCID	" & vbNewLine & _
                    "   AND A.Quantity-A.POTransportQuantity>0 " & vbNewLine & _
                    "   AND A.TotalWeight-A.POTransportWeight>0 " & vbNewLine

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
                .CommandText = _
                    "SELECT	" & vbNewLine & _
                    "   A.ID, A.SCID, A1.SCNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine & _
                    "   A.UnitPrice, A.Quantity, A.Weight, A.TotalWeight-A.DCWeight AS TotalWeight, A.TotalWeight-A.DCWeight AS MaxTotalWeight, A.Remarks  	" & vbNewLine & _
                    "FROM traSalesContractDet A  	" & vbNewLine & _
                    "INNER JOIN traSalesContract A1 ON  	" & vbNewLine & _
                    "   A.SCID=A1.ID  	" & vbNewLine & _
                    "INNER JOIN mstItem B ON  	" & vbNewLine & _
                    "   A.ItemID=B.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine & _
                    "   B.ItemSpecificationID=C.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON  	" & vbNewLine & _
                    "   B.ItemTypeID=D.ID  	" & vbNewLine & _
                    "WHERE  	" & vbNewLine & _
                    "   A1.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A1.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.SCID=@SCID	" & vbNewLine & _
                    "   AND A.Quantity-A.DCQuantity>0 " & vbNewLine & _
                    "   AND A.TotalWeight-A.DCWeight>0 " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
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
                .CommandText = _
                    "INSERT INTO traSalesContractDet " & vbNewLine & _
                    "   ( ID, SCID, ORDetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   ( @ID, @SCID, @ORDetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks) " & vbNewLine

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
                .CommandText = _
                    "DELETE FROM traSalesContractDet     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContractDet SET 	" & vbNewLine & _
                    "	POTransportWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(POD.TotalWeight),0) TotalWeight " & vbNewLine & _
                    "		FROM traPurchaseOrderTransportDet POD 	" & vbNewLine & _
                    "		INNER JOIN traPurchaseOrderTransport POH ON	" & vbNewLine & _
                    "			POD.POID=POH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			POD.SCDetailID=@SCDetailID 	" & vbNewLine & _
                    "			AND POH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	POTransportQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(POD.Quantity),0) TotalQuantity " & vbNewLine & _
                    "		FROM traPurchaseOrderTransportDet POD 	" & vbNewLine & _
                    "		INNER JOIN traPurchaseOrderTransport POH ON	" & vbNewLine & _
                    "			POD.POID=POH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			POD.SCDetailID=@SCDetailID 	" & vbNewLine & _
                    "			AND POH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traSalesContractDet SET 	" & vbNewLine & _
                    "	DCWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(DD.TotalWeight),0) TotalWeight   " & vbNewLine & _
                    "		FROM traDeliveryDet DD 	" & vbNewLine & _
                    "		INNER JOIN traDelivery DH ON	" & vbNewLine & _
                    "			DD.DeliveryID=DH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			DD.SCDetailID=@SCDetailID 	" & vbNewLine & _
                    "			AND DH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	DCQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(DD.Quantity),0) TotalQuantity    " & vbNewLine & _
                    "		FROM traDeliveryDet DD 	" & vbNewLine & _
                    "		INNER JOIN traDelivery DH ON	" & vbNewLine & _
                    "			DD.DeliveryID=DH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			DD.SCDetailID=@SCDetailID 	" & vbNewLine & _
                    "			AND DH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
                    "WHERE ID=@SCDetailID	" & vbNewLine

                .Parameters.Add("@SCDetailID", SqlDbType.VarChar, 100).Value = strSCDetailID
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
                                                ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT	" & vbNewLine & _
                    "    A.ID, A.SCID, A.CODetailID, A3.ID AS CONumber, A1.OrderNumberSupplier, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  	" & vbNewLine & _
                    "    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  	" & vbNewLine & _
                    "    A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.SCWeight AS MaxTotalWeight, A.Remarks  	" & vbNewLine & _
                    "FROM traSalesContractDetConfirmationOrder A  	" & vbNewLine & _
                    "INNER JOIN traConfirmationOrderDet A1 ON  	" & vbNewLine & _
                    "    A.CODetailID=A1.ID  	" & vbNewLine & _
                    "INNER JOIN traConfirmationOrder A3 ON  	" & vbNewLine & _
                    "    A1.COID=A3.ID  	" & vbNewLine & _
                    "INNER JOIN mstItem B ON  	" & vbNewLine & _
                    "    A.ItemID=B.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine & _
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON  	" & vbNewLine & _
                    "    B.ItemTypeID=D.ID  	" & vbNewLine & _
                    "WHERE  	" & vbNewLine & _
                    "    A.SCID=@SCID	" & vbNewLine

                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = strSCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetailCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal clsData As VO.SalesContractDetConfirmationOrder)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traSalesContractDetConfirmationOrder " & vbNewLine & _
                    "   (ID, SCID, CODetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @SCID, @CODetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks) " & vbNewLine

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
                .CommandText = _
                    "DELETE FROM traSalesContractDetConfirmationOrder     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strSCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.SCID, A.Percentage, A.PaymentTypeID, B.Code AS PaymentTypeCode, B.Name AS PaymentTypeName, " & vbNewLine & _
                    "   A.PaymentModeID, C.Code AS PaymentModeCode, C.Name AS PaymentModeName, A.CreditTerm, A.Remarks " & vbNewLine & _
                    "FROM traSalesContractPaymentTerm A " & vbNewLine & _
                    "INNER JOIN mstPaymentType B ON " & vbNewLine & _
                    "   A.PaymentTypeID=B.ID " & vbNewLine & _
                    "INNER JOIN mstPaymentMode C ON " & vbNewLine & _
                    "   A.PaymentModeID=C.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "INSERT INTO traSalesContractPaymentTerm " & vbNewLine & _
                    "   (ID, SCID, Percentage, PaymentTypeID, PaymentModeID, CreditTerm, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
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
                .CommandText = _
                    "DELETE FROM traSalesContractPaymentTerm     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.SCID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine & _
                    "FROM traSalesContractStatus A " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "INSERT INTO traSalesContractStatus " & vbNewLine & _
                    "   (ID, SCID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine & _
                        "FROM traSalesContractStatus " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   SCID=@SCID " & vbNewLine & _
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