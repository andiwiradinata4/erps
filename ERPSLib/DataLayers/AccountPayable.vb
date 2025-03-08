Namespace DL
    Public Class AccountPayable

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String,
                                        ByVal intBPID As Integer, ByVal strReferencesID As String,
                                        ByVal intIsGenerate As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.BPID, C.Code AS BPCode, C.Name AS BPName, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.APNumber, A.BPID, " & vbNewLine &
                    "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, ISNULL(COA.Code,'') AS CoACodeOfOutgoingPayment, ISNULL(COA.Name,'') AS CoANameOfOutgoingPayment, " & vbNewLine &
                    "   A.Modules, A.ReferencesID, A.ReferencesNote, A.APDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                    "   A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine &
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                    "   A.LogInc, A.LogBy, A.LogDate, A.APNumber AS TransNumber, A.APDate AS TransDate, A.CoAIDOfOutgoingPayment AS CoAID, " & vbNewLine &
                    "   ISNULL(COA.Code,'') AS CoACode, ISNULL(COA.Name,'') AS CoAName, A.TotalPPN, A.TotalPPH, A.DPAmount, A.ReceiveAmount, A.IsDP, A.InvoiceNumberBP, A.CompanyBankAccountID1, A.CompanyBankAccountID2, A.IsUseSubItem, " & vbNewLine &
                    "   A.PaymentTerm1, A.PaymentTerm2, A.PaymentTerm3, A.PaymentTerm4, A.PaymentTerm5, A.PaymentTerm6, A.PaymentTerm7, A.PaymentTerm8, A.PaymentTerm9, A.PaymentTerm10, A.PPNPercentage, A.PPHPercentage, " & vbNewLine &
                    "   A.Rounding, GrandTotal=A.TotalAmount+A.TotalPPN-A.TotalPPH+A.Rounding, A.TotalInvoiceAmount, A.TotalDPPInvoiceAmount, A.TotalPPNInvoiceAmount, A.TotalPPHInvoiceAmount, " & vbNewLine &
                    "   DueDateVSNowValue=DATEDIFF(DAY,DueDate, GETDATE()), A.ReferencesNumber, A.IsFullDP, OutstandingInvoiceAmount=(A.TotalAmount+A.TotalPPN-A.TotalPPH)-A.TotalInvoiceAmount, " & vbNewLine &
                    "   A.BPBankAccountID, ISNULL(BPBA.BankName,'') AS BPBankAccountBank, ISNULL(BPBA.AccountNumber,'') AS BPBankAccountNumber, A.IsGenerate " & vbNewLine &
                    "FROM traAccountPayable A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "   A.CoAIDOfOutgoingPayment=COA.ID " & vbNewLine &
                    "LEFT JOIN mstBusinessPartnerBankAccount BPBA ON " & vbNewLine &
                    "   A.BPBankAccountID=BPBA.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.APDate>=@DateFrom AND A.APDate<=@DateTo " & vbNewLine

                If strModules.Trim <> VO.AccountPayable.All Then .CommandText += "   AND A.Modules=@Modules " & vbNewLine

                If intStatusID <> VO.Status.Values.All Then .CommandText += "    AND A.StatusID=@StatusID" & vbNewLine

                If intBPID <> 0 Then .CommandText += "    AND A.BPID=@BPID " & vbNewLine

                If strReferencesID.Trim <> "" Then .CommandText += "   AND A.ReferencesID=@ReferencesID " & vbNewLine

                If intIsGenerate <> -1 Then .CommandText += "   AND A.IsGenerate=@IsGenerate " & vbNewLine

                .CommandText += "ORDER BY A.APDate, A.ID ASC " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = strModules
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@IsGenerate", SqlDbType.Int).Value = intIsGenerate
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstandingPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                          ByVal strModules As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.APNumber, A.BPID, " & vbNewLine &
                    "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, ISNULL(COA.Code,'') AS CoACodeOfOutgoingPayment, ISNULL(COA.Name,'') AS CoANameOfOutgoingPayment, " & vbNewLine &
                    "   A.Modules, MDARAP.Name AS ModulesName, A.ReferencesID, A.ReferencesNote, A.APDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.JournalID, A.StatusID, " & vbNewLine &
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine &
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                    "   A.LogInc, A.LogBy, A.LogDate, A.APNumber AS TransNumber, A.APDate AS TransDate, A.CoAIDOfOutgoingPayment AS CoAID, " & vbNewLine &
                    "   ISNULL(COA.Code,'') AS CoACode, ISNULL(COA.Name,'') AS CoAName, A.TotalPPN, A.TotalPPH, A.Rounding " & vbNewLine &
                    "FROM traAccountPayable A " & vbNewLine &
                    "INNER JOIN mstModuleIDARAP MDARAP ON " & vbNewLine &
                    "   A.Modules=MDARAP.Code " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "   A.CoAIDOfOutgoingPayment=COA.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.PaymentBy='' " & vbNewLine &
                    "   AND A.StatusID=@StatusID " & vbNewLine

                If strModules.Trim <> "" Then .CommandText += "   AND A.Modules=@Modules "

                .CommandText += "ORDER BY A.DueDate, A.APDate, A.ID ASC " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = strModules
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.AccountPayable)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO traAccountPayable " & vbNewLine &
                        "   (ID, CompanyID, ProgramID, APNumber, BPID, CoAIDOfOutgoingPayment, Modules, ReferencesID, ReferencesNote, " & vbNewLine &
                        "    APDate, DueDateValue, DueDate, TotalAmount, Percentage, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, " & vbNewLine &
                        "    TotalPPN, TotalPPH, IsDP, DPAmount, ReceiveAmount, IsUseSubItem, PPNPercentage, PPHPercentage, IsFullDP, BPBankAccountID, " & vbNewLine &
                        "    InvoiceNumberBP, InvoiceDateBP, ReceiveDateInvoice, IsGenerate, Rounding) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @CompanyID, @ProgramID, @APNumber, @BPID, @CoAIDOfOutgoingPayment, @Modules, @ReferencesID, @ReferencesNote, " & vbNewLine &
                        "    @APDate, @DueDateValue, @DueDate, @TotalAmount, @Percentage, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), " & vbNewLine &
                        "    @TotalPPN, @TotalPPH, @IsDP, @DPAmount, @ReceiveAmount, @IsUseSubItem, @PPNPercentage, @PPHPercentage, @IsFullDP, @BPBankAccountID, " & vbNewLine &
                        "    @InvoiceNumberBP, @InvoiceDateBP, @ReceiveDateInvoice, @IsGenerate, @Rounding) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE traAccountPayable SET " & vbNewLine &
                        "    CompanyID=@CompanyID, " & vbNewLine &
                        "    ProgramID=@ProgramID, " & vbNewLine &
                        "    APNumber=@APNumber, " & vbNewLine &
                        "    BPID=@BPID, " & vbNewLine &
                        "    CoAIDOfOutgoingPayment=@CoAIDOfOutgoingPayment, " & vbNewLine &
                        "    Modules=@Modules, " & vbNewLine &
                        "    ReferencesID=@ReferencesID, " & vbNewLine &
                        "    ReferencesNote=@ReferencesNote, " & vbNewLine &
                        "    APDate=@APDate, " & vbNewLine &
                        "    DueDateValue=@DueDateValue, " & vbNewLine &
                        "    DueDate=@DueDate, " & vbNewLine &
                        "    TotalAmount=@TotalAmount, " & vbNewLine &
                        "    Percentage=@Percentage, " & vbNewLine &
                        "    Remarks=@Remarks, " & vbNewLine &
                        "    StatusID=@StatusID, " & vbNewLine &
                        "    LogInc=LogInc+1, " & vbNewLine &
                        "    LogBy=@LogBy, " & vbNewLine &
                        "    LogDate=GETDATE(), " & vbNewLine &
                        "    TotalPPN=@TotalPPN, " & vbNewLine &
                        "    TotalPPH=@TotalPPH, " & vbNewLine &
                        "    IsDP=@IsDP, " & vbNewLine &
                        "    DPAmount=@DPAmount, " & vbNewLine &
                        "    ReceiveAmount=@ReceiveAmount, " & vbNewLine &
                        "    IsUseSubItem=@IsUseSubItem, " & vbNewLine &
                        "    PPNPercentage=@PPNPercentage, " & vbNewLine &
                        "    PPHPercentage=@PPHPercentage, " & vbNewLine &
                        "    IsFullDP=@IsFullDP, " & vbNewLine &
                        "    BPBankAccountID=@BPBankAccountID, " & vbNewLine &
                        "    InvoiceNumberBP=@InvoiceNumberBP, " & vbNewLine &
                        "    InvoiceDateBP=@InvoiceDateBP, " & vbNewLine &
                        "    ReceiveDateInvoice=@ReceiveDateInvoice, " & vbNewLine &
                        "    IsGenerate=@IsGenerate, " & vbNewLine &
                        "    Rounding=@Rounding " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@APNumber", SqlDbType.VarChar, 100).Value = clsData.APNumber
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@CoAIDOfOutgoingPayment", SqlDbType.Int).Value = clsData.CoAIDOfOutgoingPayment
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = clsData.Modules
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 250).Value = clsData.ReferencesID
                .Parameters.Add("@ReferencesNote", SqlDbType.VarChar, 250).Value = clsData.ReferencesNote
                .Parameters.Add("@APDate", SqlDbType.DateTime).Value = clsData.APDate
                .Parameters.Add("@DueDateValue", SqlDbType.Int).Value = clsData.DueDateValue
                .Parameters.Add("@DueDate", SqlDbType.DateTime).Value = clsData.DueDate
                .Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = clsData.TotalAmount
                .Parameters.Add("@Percentage", SqlDbType.Decimal).Value = clsData.Percentage
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@IsDP", SqlDbType.Decimal).Value = clsData.IsDP
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@ReceiveAmount", SqlDbType.Decimal).Value = clsData.ReceiveAmount
                .Parameters.Add("@IsUseSubItem", SqlDbType.Bit).Value = clsData.IsUseSubItem
                .Parameters.Add("@PPNPercentage", SqlDbType.Decimal).Value = clsData.PPNPercentage
                .Parameters.Add("@PPHPercentage", SqlDbType.Decimal).Value = clsData.PPHPercentage
                .Parameters.Add("@IsFullDP", SqlDbType.Bit).Value = clsData.IsFullDP
                .Parameters.Add("@BPBankAccountID", SqlDbType.Int).Value = clsData.BPBankAccountID
                .Parameters.Add("@InvoiceNumberBP", SqlDbType.VarChar, 1000).Value = clsData.InvoiceNumberBP
                .Parameters.Add("@InvoiceDateBP", SqlDbType.DateTime).Value = clsData.InvoiceDateBP
                .Parameters.Add("@ReceiveDateInvoice", SqlDbType.DateTime).Value = clsData.ReceiveDateInvoice
                .Parameters.Add("@IsGenerate", SqlDbType.Bit).Value = clsData.IsGenerate
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.AccountPayable
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.AccountPayable
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.APNumber, A.BPID, " & vbNewLine &
                        "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, ISNULL(COA.Code,'') AS CoACodeOfOutgoingPayment, ISNULL(COA.Name,'') AS CoANameOfOutgoingPayment, " & vbNewLine &
                        "   A.Modules, A.ReferencesID, A.ReferencesNote, A.APDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.Percentage, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                        "   A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.PaymentBy, A.PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                        "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                        "   A.LogInc, A.LogBy, A.LogDate, A.TotalPPN, A.TotalPPH, A.IsDP, A.DPAmount, A.ReceiveAmount, A.TotalAmountUsed, A.JournalIDInvoice, A.InvoiceNumberBP, A.IsUseSubItem, " & vbNewLine &
                        "   A.PaymentTerm1, A.PaymentTerm2, A.PaymentTerm3, A.PaymentTerm4, A.PaymentTerm5, A.PaymentTerm6, A.PaymentTerm7, A.PaymentTerm8, A.PaymentTerm9, A.PaymentTerm10, A.PPNPercentage, A.PPHPercentage, " & vbNewLine &
                        "   A.PPNPercentage, A.PPHPercentage, A.TotalInvoiceAmount, A.TotalDPPInvoiceAmount, A.TotalPPNInvoiceAmount, A.TotalPPHInvoiceAmount, A.ReferencesNumber, A.IsFullDP, A.IsGenerate, " & vbNewLine &
                        "   A.BPBankAccountID, ISNULL(BPBA.BankName,'') AS BPBankAccountBank, ISNULL(BPBA.AccountNumber,'') AS BPBankAccountNumber, A.InvoiceDateBP, A.ReceiveDateInvoice, A.Rounding " & vbNewLine &
                        "FROM traAccountPayable A " & vbNewLine &
                        "INNER JOIN mstStatus B ON " & vbNewLine &
                        "   A.StatusID=B.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                        "   A.BPID=C.ID " & vbNewLine &
                        "INNER JOIN mstCompany MC ON " & vbNewLine &
                        "   A.CompanyID=MC.ID " & vbNewLine &
                        "INNER JOIN mstProgram MP ON " & vbNewLine &
                        "   A.ProgramID=MP.ID " & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "   A.CoAIDOfOutgoingPayment=COA.ID " & vbNewLine &
                        "LEFT JOIN mstBusinessPartnerBankAccount BPBA ON " & vbNewLine &
                        "   A.BPBankAccountID=BPBA.ID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   A.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.APNumber = .Item("APNumber")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.CoAIDOfOutgoingPayment = .Item("CoAIDOfOutgoingPayment")
                        voReturn.CoACodeOfOutgoingPayment = .Item("CoACodeOfOutgoingPayment")
                        voReturn.CoANameOfOutgoingPayment = .Item("CoANameOfOutgoingPayment")
                        voReturn.Modules = .Item("Modules")
                        voReturn.ReferencesID = .Item("ReferencesID")
                        voReturn.ReferencesNote = .Item("ReferencesNote")
                        voReturn.APDate = .Item("APDate")
                        voReturn.DueDateValue = .Item("DueDateValue")
                        voReturn.DueDate = .Item("DueDate")
                        voReturn.TotalAmount = .Item("TotalAmount")
                        voReturn.Percentage = .Item("Percentage")
                        voReturn.JournalID = .Item("JournalID")
                        voReturn.SubmitBy = .Item("SubmitBy")
                        voReturn.SubmitDate = .Item("SubmitDate")
                        voReturn.ApproveL1 = .Item("ApproveL1")
                        voReturn.ApproveL1Date = .Item("ApproveL1Date")
                        voReturn.ApprovedBy = .Item("ApprovedBy")
                        voReturn.ApprovedDate = .Item("ApprovedDate")
                        voReturn.PaymentBy = .Item("PaymentBy")
                        voReturn.PaymentDate = .Item("PaymentDate")
                        voReturn.TaxInvoiceNumber = .Item("TaxInvoiceNumber")
                        voReturn.IsClosedPeriod = .Item("IsClosedPeriod")
                        voReturn.ClosedPeriodBy = .Item("ClosedPeriodBy")
                        voReturn.ClosedPeriodDate = .Item("ClosedPeriodDate")
                        voReturn.IsDeleted = .Item("IsDeleted")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.IsDP = .Item("IsDP")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.ReceiveAmount = .Item("ReceiveAmount")
                        voReturn.TotalAmountUsed = .Item("TotalAmountUsed")
                        voReturn.JournalIDInvoice = .Item("JournalIDInvoice")
                        voReturn.InvoiceNumberBP = .Item("InvoiceNumberBP")
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
                        voReturn.PaymentTerm1 = .Item("PaymentTerm1")
                        voReturn.PaymentTerm2 = .Item("PaymentTerm2")
                        voReturn.PaymentTerm3 = .Item("PaymentTerm3")
                        voReturn.PaymentTerm4 = .Item("PaymentTerm4")
                        voReturn.PaymentTerm5 = .Item("PaymentTerm5")
                        voReturn.PaymentTerm6 = .Item("PaymentTerm6")
                        voReturn.PaymentTerm7 = .Item("PaymentTerm7")
                        voReturn.PaymentTerm8 = .Item("PaymentTerm8")
                        voReturn.PaymentTerm9 = .Item("PaymentTerm9")
                        voReturn.PaymentTerm10 = .Item("PaymentTerm10")
                        voReturn.PPNPercentage = .Item("PPNPercentage")
                        voReturn.PPHPercentage = .Item("PPHPercentage")
                        voReturn.TotalInvoiceAmount = .Item("TotalInvoiceAmount")
                        voReturn.TotalDPPInvoiceAmount = .Item("TotalDPPInvoiceAmount")
                        voReturn.TotalPPNInvoiceAmount = .Item("TotalPPNInvoiceAmount")
                        voReturn.TotalPPHInvoiceAmount = .Item("TotalPPHInvoiceAmount")
                        voReturn.ReferencesNumber = .Item("ReferencesNumber")
                        voReturn.IsFullDP = .Item("IsFullDP")
                        voReturn.IsGenerate = .Item("IsGenerate")
                        voReturn.BPBankAccountID = .Item("BPBankAccountID")
                        voReturn.BPBankAccountBank = .Item("BPBankAccountBank")
                        voReturn.BPBankAccountNumber = .Item("BPBankAccountNumber")
                        voReturn.InvoiceDateBP = .Item("InvoiceDateBP")
                        voReturn.ReceiveDateInvoice = .Item("ReceiveDateInvoice")
                        voReturn.Rounding = .Item("Rounding")
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
                    "UPDATE traAccountPayable SET " & vbNewLine &
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
                        "FROM traAccountPayable " & vbNewLine &
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
                        "FROM traAccountPayable " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   YEAR(APDate)=@Year " & vbNewLine &
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

        Public Shared Function GetMaxNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(APNumber,4),'0000') APNumber " & vbNewLine &
                        "FROM traAccountPayable " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(APNumber,@Length)=@NewID " & vbNewLine &
                        "ORDER BY CreatedDate DESC " & vbNewLine

                    .Parameters.Add("@NewID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("APNumber")
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
                                          ByVal strAPNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traAccountPayable " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   APNumber=@APNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@APNumber", SqlDbType.VarChar, 100).Value = strAPNumber
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
                        "FROM traAccountPayable " & vbNewLine &
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
                        "FROM traAccountPayable " & vbNewLine &
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
                    "UPDATE traAccountPayable SET " & vbNewLine &
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
                    "UPDATE traAccountPayable SET " & vbNewLine &
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
                    "UPDATE traAccountPayable SET " & vbNewLine &
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
                    "UPDATE traAccountPayable SET " & vbNewLine &
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

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
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

        Public Shared Sub UpdateJournalIDInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
                    "    JournalIDInvoice=@JournalID " & vbNewLine &
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

        Public Shared Sub SetupPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                       ByVal intCoAIDOfOutgoingPayment As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
                    "    CoAIDOfOutgoingPayment=@CoAIDOfOutgoingPayment, " & vbNewLine &
                    "    PaymentBy=@PaymentBy, " & vbNewLine &
                    "    PaymentDate=@PaymentDate, " & vbNewLine &
                    "    StatusID=@StatusID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@CoAIDOfOutgoingPayment", SqlDbType.Int).Value = intCoAIDOfOutgoingPayment
                .Parameters.Add("@PaymentBy", SqlDbType.VarChar, 20).Value = UI.usUserApp.UserID
                .Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = dtmPaymentDate
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Payment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SetupCancelPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
                    "    CoAIDOfOutgoingPayment=CASE WHEN IsDP=1 THEN CoAIDOfOutgoingPayment ELSE 0 END, " & vbNewLine &
                    "    PaymentBy='', " & vbNewLine &
                    "    StatusID=@StatusID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateTaxInvoiceNumber(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String, ByVal strTaxInvoiceNumber As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
                    "    TaxInvoiceNumber=@TaxInvoiceNumber " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@TaxInvoiceNumber", SqlDbType.VarChar, 250).Value = strTaxInvoiceNumber
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateInvoiceNumberSupplier(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strID As String, ByVal strInvoiceNumberSupplier As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
                    "    InvoiceNumberBP=@InvoiceNumberBP " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@InvoiceNumberBP", SqlDbType.VarChar, 1000).Value = strInvoiceNumberSupplier
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateDueDate(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strID As String, ByVal dtmDueDate As DateTime)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
                    "    DueDate=@DueDate " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dtmDueDate
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function PrintCostBankOut(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT    " & vbNewLine &
"	CH.APNumber AS TransNumber, CH.APDate AS TransDate, MC.Name AS CompanyName, '' AS VoucherCode,    " & vbNewLine &
"	MBP.Name AS PaidTo, MBPBA.BankName + ' A/C ' + MBPBA.AccountNumber AS PaidAccount, CH.TotalAmount+CH.TotalPPN-CH.TotalPPH+CH.Rounding AS TotalAmount, ISNULL(ARR.Remarks,CH.Remarks) AS Remarks, MUC.Name AS CreatedBy, CH.CreatedDate, NULL AS CheckedDate,    " & vbNewLine &
"	'' AS CheckedBy, MUP.Name AS PaidBy, CASE WHEN CH.PaymentBy='' THEN NULL ELSE CH.PaymentDate END AS PaidDate, MC.DirectorName AS ApprovedBy, NULL AS ApprovedDate, 'KETERANGAN' AS Description, ':' AS DescriptionSeparator, CH.Rounding " & vbNewLine &
"FROM traAccountPayable CH    " & vbNewLine &
"INNER JOIN mstCompany MC ON    " & vbNewLine &
"	CH.CompanyID=MC.ID    " & vbNewLine &
"INNER JOIN mstBusinessPartner MBP ON    " & vbNewLine &
"	CH.BPID=MBP.ID    " & vbNewLine &
"INNER JOIN mstBusinessPartnerBankAccount MBPBA ON    " & vbNewLine &
"	CH.BPBankAccountID=MBPBA.ID    " & vbNewLine &
"INNER JOIN mstUser MUC ON    " & vbNewLine &
"	CH.CreatedBy=MUC.ID    " & vbNewLine &
"LEFT JOIN traARAPRemarks ARR ON  " & vbNewLine &
"	CH.ID=ARR.ParentID  " & vbNewLine &
"LEFT JOIN mstUser MUP ON    " & vbNewLine &
"	CH.PaymentBy=MUP.ID    " & vbNewLine &
"WHERE CH.ID=@ID    " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetailForSetupBalance(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.InvoiceNumber, B.InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH-B.TotalPaymentDP-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, CAST(0 AS DECIMAL) PPNPercent, CAST(0 AS DECIMAL) PPHPercent, A.PPN, A.PPH, " & vbNewLine &
                    "   A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN mstBusinessPartnerAPBalance B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailForSetupBalanceWithOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                            ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                            ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.InvoiceNumber, B.InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH-B.TotalPaymentDP-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, CAST(0 AS DECIMAL) PPNPercent, CAST(0 AS DECIMAL) PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN mstBusinessPartnerAPBalance B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.InvoiceNumber, A.InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH-A.TotalPaymentDP-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, " & vbNewLine &
                    "   CAST(0 AS DECIMAL) PPNPercent, CAST(0 AS DECIMAL) PPHPercent, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM mstBusinessPartnerAPBalance A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH-A.TotalPaymentDP-A.TotalPayment>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	        ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOnly(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.PurchaseID AS InvoiceID, A.Amount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.PCNumber AS InvoiceNumber, B.PCDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traPurchaseContract B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderTransport B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailWithOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                             ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PCNumber AS InvoiceNumber, B.PCDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traPurchaseContract B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PCNumber AS InvoiceNumber, A.PCDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM traPurchaseContract A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   And A.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.ProgramID=@ProgramID " & vbNewLine &
                    "   And A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	        ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailWithOutstandingPurchaseOrderCutting(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                                 ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                 ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PONumber AS InvoiceNumber, A.PODate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM traPurchaseOrderCutting A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   And A.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.ProgramID=@ProgramID " & vbNewLine &
                    "   And A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	        ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailWithOutstandingPurchaseOrderTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                                   ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                   ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderTransport B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PONumber AS InvoiceNumber, A.PODate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM traPurchaseOrderTransport A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   And A.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.ProgramID=@ProgramID " & vbNewLine &
                    "   And A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	        ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.AccountPayableDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traAccountPayableDet " & vbNewLine &
                    "   (ID, APID, PurchaseID, Amount, Remarks, PPN, PPH, DPAmount, Rounding, LevelItem, ReferencesParentID, Quantity, Weight, TotalWeight, ReceiveDate, InvoiceDate, InvoiceNumberBP) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @APID, @PurchaseID, @Amount, @Remarks, @PPN, @PPH, @DPAmount, @Rounding, @LevelItem, @ReferencesParentID, @Quantity, @Weight, @TotalWeight, @ReceiveDate, @InvoiceDate, @InvoiceNumberBP) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = clsData.APID
                .Parameters.Add("@PurchaseID", SqlDbType.VarChar, 100).Value = clsData.PurchaseID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ReferencesParentID", SqlDbType.VarChar, 100).Value = clsData.ReferencesParentID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = clsData.ReceiveDate
                .Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = clsData.InvoiceDate
                .Parameters.Add("@InvoiceNumberBP", SqlDbType.VarChar, 1000).Value = clsData.InvoiceNumberBP
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strAPID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traAccountPayableDet    " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   APID=@APID" & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ListDataDetailRev01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.ReceiveNumber AS InvoiceNumber, B.ReceiveDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traReceive B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.CuttingNumber AS InvoiceNumber, B.CuttingDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traCutting B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.DeliveryNumber AS InvoiceNumber, C.DeliveryDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traDeliveryTransport B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "INNER JOIN traDelivery C ON " & vbNewLine &
                    "   B.DeliveryID=C.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailRev02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                '# Receive
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseContractDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.PCID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traPurchaseContract C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traReceiveDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traReceive C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine

                '# Cutting
                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCuttingDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.POID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traCuttingDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traCutting C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine

                '# Transport
                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traDeliveryDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.DeliveryID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traDelivery C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.Receive+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseContractDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.PCID " & vbNewLine &
                    "INNER JOIN traPurchaseContract C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                '.CommandText +=
                '    "UNION ALL " & vbNewLine &
                '    "SELECT " & vbNewLine &
                '    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.CuttingNumber AS InvoiceNumber, B.CuttingDate AS InvoiceDate, " & vbNewLine &
                '    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                '    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                '    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                '    "FROM traAccountPayableDet A " & vbNewLine &
                '    "INNER JOIN traCutting B ON " & vbNewLine &
                '    "   A.PurchaseID=B.ID " & vbNewLine &
                '    "WHERE " & vbNewLine &
                '    "   A.APID=@APID " & vbNewLine

                '.CommandText +=
                '    "UNION ALL " & vbNewLine &
                '    "SELECT " & vbNewLine &
                '    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.DeliveryNumber AS InvoiceNumber, C.DeliveryDate AS InvoiceDate, " & vbNewLine &
                '    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                '    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                '    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                '    "FROM traAccountPayableDet A " & vbNewLine &
                '    "INNER JOIN traDeliveryTransport B ON " & vbNewLine &
                '    "   A.PurchaseID=B.ID " & vbNewLine &
                '    "INNER JOIN traDelivery C ON " & vbNewLine &
                '    "   B.DeliveryID=C.ID " & vbNewLine &
                '    "WHERE " & vbNewLine &
                '    "   A.APID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailWithOutstandingRev01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                      ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                      ByVal intBPID As Integer, ByVal strAPID As String,
                                                                      ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.ReceiveNumber AS InvoiceNumber, B.ReceiveDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traReceive B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.CuttingNumber AS InvoiceNumber, B.CuttingDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traCutting B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID AS InvoiceID, B.DeliveryNumber AS InvoiceNumber, C.DeliveryDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traDeliveryTransport B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "INNER JOIN traDelivery C ON " & vbNewLine &
                    "   B.DeliveryID=C.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS InvoiceID, A.ReceiveNumber AS InvoiceNumber, A.ReceiveDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM traReceive A " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.PCID=@ReferencesID " & vbNewLine &
                    "   AND A.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS InvoiceID, A.CuttingNumber AS InvoiceNumber, A.CuttingDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM traCutting A " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.POID=@ReferencesID " & vbNewLine &
                    "   AND A.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT DISTINCT  " & vbNewLine &
                    "	CAST(0 AS BIT) AS Pick, A.ID AS InvoiceID, A.DeliveryNumber AS InvoiceNumber, B.DeliveryDate AS InvoiceDate,   " & vbNewLine &
                    "	A.TotalDPP+A.RoundingManual AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount,   " & vbNewLine &
                    "	A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment AS MaxPaymentAmount,   " & vbNewLine &
                    "	CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN,   " & vbNewLine &
                    "	CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding   " & vbNewLine &
                    "FROM traDeliveryTransport A  " & vbNewLine &
                    "INNER JOIN traDelivery B ON  " & vbNewLine &
                    "	A.DeliveryID=B.ID  " & vbNewLine &
                    "INNER JOIN traPurchaseOrderTransport D ON  " & vbNewLine &
                    "	A.POID=D.ID  " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.POID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemDPWithOutstandingVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strAPID As String,
                                                                  ByVal strReferencesID As String, ByVal bolIsUseSubItem As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseContractDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.PCID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traPurchaseContract C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    "" & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.PCID AS ReferencesID, A.ID AS ReferencesDetailID, C.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, " & vbNewLine &
                    "   A.LevelItem, A.ParentID AS ReferencesParentID " & vbNewLine &
                    "FROM traPurchaseContractDet A " & vbNewLine &
                    "INNER JOIN traPurchaseContract B ON " & vbNewLine &
                    "   A.PCID=B.ID " & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet C ON " & vbNewLine &
                    "   A.CODetailID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   And B.CompanyID=@CompanyID " & vbNewLine &
                    "   And B.ProgramID=@ProgramID " & vbNewLine &
                    "   And A.PCID=@ReferencesID " & vbNewLine &
                    "   And B.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine

                If bolIsUseSubItem Then .CommandText += "   AND A.ParentID<>'' " & vbNewLine

                .CommandText +=
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCuttingDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.POID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    "" & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.POID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, " & vbNewLine &
                    "   CAST(0 AS INT) AS LevelItem, CAST('' AS VARCHAR(100)) AS ReferencesParentID " & vbNewLine &
                    "FROM traPurchaseOrderCuttingDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting B ON " & vbNewLine &
                    "   A.POID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.POID=@ReferencesID " & vbNewLine &
                    "   AND B.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemDPWithOutstandingVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strAPID As String,
                                                                  ByVal strReferencesID As String, ByVal bolIsUseSubItem As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   CASE WHEN B.AllocateDPAmount>0 THEN B.TotalPrice-B.AllocateDPAmount-B.ReceiveAmount+A.Amount ELSE B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount END AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, B.UnitPrice " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseContractDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.PCID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traPurchaseContract C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.PCID AS ReferencesID, A.ID AS ReferencesDetailID, C.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, " & vbNewLine &
                    "   A.LevelItem, A.ParentID AS ReferencesParentID, A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice " & vbNewLine &
                    "FROM traPurchaseContractDet A " & vbNewLine &
                    "INNER JOIN traPurchaseContract B ON " & vbNewLine &
                    "   A.PCID=B.ID " & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet C ON " & vbNewLine &
                    "   A.CODetailID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   And B.CompanyID=@CompanyID " & vbNewLine &
                    "   And B.ProgramID=@ProgramID " & vbNewLine &
                    "   And A.PCID=@ReferencesID " & vbNewLine &
                    "   And B.ApprovedBy<>'' " & vbNewLine &
                    "   And A.ParentID='' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.TotalWeight-A.DCWeight>0 " & vbNewLine

                'If bolIsUseSubItem Then .CommandText += "   AND A.ParentID<>'' " & vbNewLine

                .CommandText +=
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   CASE WHEN B.AllocateDPAmount>0 THEN B.TotalPrice-B.AllocateDPAmount-B.ReceiveAmount+A.Amount ELSE B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount END AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, A.Quantity, A.Weight, A.TotalWeight, B.UnitPrice " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCuttingDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.POID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.POID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, " & vbNewLine &
                    "   CAST(0 AS INT) AS LevelItem, CAST('' AS VARCHAR(100)) AS ReferencesParentID, A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice " & vbNewLine &
                    "FROM traPurchaseOrderCuttingDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting B ON " & vbNewLine &
                    "   A.POID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.POID=@ReferencesID " & vbNewLine &
                    "   AND B.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemReceiveWithOutstandingVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                              ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                              ByVal intBPID As Integer, ByVal strAPID As String,
                                                                              ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text

                '# Receive
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traReceiveDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traReceive C ON " & vbNewLine &
                    "   B.ReceiveID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.ReceiveID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID " & vbNewLine &
                    "FROM traReceiveDet A " & vbNewLine &
                    "INNER JOIN traReceive B ON " & vbNewLine &
                    "   A.ReceiveID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND B.PCID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                '# Cutting
                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID  " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traCuttingDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traCutting C ON " & vbNewLine &
                    "   B.CuttingID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.CuttingID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, CAST(0 AS INT) AS LevelItem, CAST('' AS VARCHAR(100)) AS ReferencesParentID  " & vbNewLine &
                    "FROM traCuttingDet A " & vbNewLine &
                    "INNER JOIN traCutting B ON " & vbNewLine &
                    "   A.CuttingID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND B.POID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                '# Transport
                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPriceTransport AS InvoiceAmount, A.Amount, A.DPAmount, C.PPNTransport AS PPNPercent, C.PPHTransport AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPriceTransport-B.DPAmountTransport-B.ReceiveAmountTransport+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID  " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traDeliveryDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traDelivery C ON " & vbNewLine &
                    "   B.DeliveryID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.DeliveryID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPriceTransport AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPNTransport AS PPNPercent, B.PPHTransport AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPriceTransport-A.DPAmountTransport-A.ReceiveAmountTransport AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID  " & vbNewLine &
                    "FROM traDeliveryDet A " & vbNewLine &
                    "INNER JOIN traDelivery B ON " & vbNewLine &
                    "   A.DeliveryID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.TransporterID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.DeliveryID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPriceTransport-A.DPAmountTransport-A.ReceiveAmountTransport>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemReceiveWithOutstandingVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                             ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                             ByVal intBPID As Integer, ByVal strAPID As String,
                                                                             ByVal strReferencesID As String, ByVal intPaymentTypeID As Integer,
                                                                             ByVal bolIsUseSubitem As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                '# Receive CBD
                If intPaymentTypeID = VO.PaymentType.Values.CBD Or intPaymentTypeID = 0 Then
                    .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, D.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Quantity, A.Weight, A.TotalWeight, MaxTotalWeight=B.TotalWeight-B.InvoiceTotalWeight+A.TotalWeight, " & vbNewLine &
                    "   B.UnitPrice, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.ReceiveAmount+A.Amount-B.AllocateDPAmount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN B.Quantity-B.InvoiceQuantity<=0 THEN 1 ELSE B.Quantity-B.InvoiceQuantity+A.Quantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traPurchaseContractDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traPurchaseContract C ON " & vbNewLine &
                    "   B.PCID=C.ID " & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet D ON " & vbNewLine &
                    "   B.CODetailID=D.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.PCID AS ReferencesID, A.ID AS ReferencesDetailID, C.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, CAST(0 AS DECIMAL(18,4)) AS Quantity, A.Weight, CAST(0 AS DECIMAL(18,4)) AS TotalWeight, MaxTotalWeight=A.TotalWeight-A.InvoiceTotalWeight, " & vbNewLine &
                    "   A.UnitPrice, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.AllocateDPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN A.Quantity-A.InvoiceQuantity<=0 THEN 1 ELSE A.Quantity-A.InvoiceQuantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traPurchaseContractDet A " & vbNewLine &
                    "INNER JOIN traPurchaseContract B ON " & vbNewLine &
                    "   A.PCID=B.ID " & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet C ON " & vbNewLine &
                    "   A.CODetailID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   And B.CompanyID=@CompanyID " & vbNewLine &
                    "   And B.ProgramID=@ProgramID " & vbNewLine &
                    "   And B.ID=@ReferencesID " & vbNewLine &
                    "   And B.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.AllocateDPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.TotalWeight-A.InvoiceTotalWeight>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                    If bolIsUseSubitem Then .CommandText += "   AND A.ParentID<>'' " & vbNewLine

                ElseIf intPaymentTypeID = VO.PaymentType.Values.TT30Days Then
                    .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, B.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Quantity, A.Weight, A.TotalWeight, MaxTotalWeight=B.TotalWeight-B.InvoiceTotalWeight+A.TotalWeight, " & vbNewLine &
                    "   B.UnitPrice, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN B.Quantity-B.InvoiceQuantity<=0 THEN 1 ELSE B.Quantity-B.InvoiceQuantity+A.Quantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traReceiveDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traReceive C ON " & vbNewLine &
                    "   B.ReceiveID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.ReceiveID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, Quantity=CASE WHEN A.Quantity-A.InvoiceQuantity<0 THEN CAST(0 AS DECIMAL(18,4)) ELSE A.Quantity-A.InvoiceQuantity END, A.Weight, CAST(0 AS DECIMAL(18,4)) AS TotalWeight, MaxTotalWeight=A.TotalWeight-A.InvoiceTotalWeight, " & vbNewLine &
                    "   A.UnitPrice, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN A.Quantity-A.InvoiceQuantity<=0 THEN 1 ELSE B.Quantity-B.InvoiceQuantity+A.Quantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traReceiveDet A " & vbNewLine &
                    "INNER JOIN traReceive B ON " & vbNewLine &
                    "   A.ReceiveID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   And B.CompanyID=@CompanyID " & vbNewLine &
                    "   And B.ProgramID=@ProgramID " & vbNewLine &
                    "   And B.ID=@ReferencesID " & vbNewLine &
                    "   And B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                    If bolIsUseSubitem Then .CommandText += "   AND A.ParentID<>'' " & vbNewLine
                End If

                '# Cutting
                If .CommandText.Trim <> "" Then .CommandText += "UNION ALL " & vbNewLine
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Quantity, A.Weight, A.TotalWeight, MaxTotalWeight=B.TotalWeight-B.InvoiceTotalWeight+A.TotalWeight, " & vbNewLine &
                    "   B.UnitPrice, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID,  " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN B.Quantity-B.InvoiceQuantity<=0 THEN 1 ELSE B.Quantity-B.InvoiceQuantity+A.Quantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traCuttingDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traCutting C ON " & vbNewLine &
                    "   B.CuttingID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.CuttingID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, Quantity=CASE WHEN A.Quantity-A.InvoiceQuantity < 0 THEN CAST(0 AS DECIMAL(18,4)) ELSE A.Quantity-A.InvoiceQuantity END, A.Weight, CAST(0 AS DECIMAL(18,4)) AS TotalWeight, MaxTotalWeight=A.TotalWeight-A.InvoiceTotalWeight, " & vbNewLine &
                    "   A.UnitPrice, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID,  " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN A.Quantity-A.InvoiceQuantity<=0 THEN 1 ELSE A.Quantity-A.InvoiceQuantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traCuttingDet A " & vbNewLine &
                    "INNER JOIN traCutting B ON " & vbNewLine &
                    "   A.CuttingID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CuttingID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.TotalWeight-A.InvoiceTotalWeight>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                '# Transport
                If .CommandText.Trim <> "" Then .CommandText += "UNION ALL " & vbNewLine
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Quantity, A.Weight, A.TotalWeight, MaxTotalWeight=B.TotalWeight-B.InvoiceTotalWeightTransport+A.TotalWeight, " & vbNewLine &
                    "   UnitPrice=C.UnitPriceTransport, B.TotalPriceTransport AS InvoiceAmount, A.Amount, A.DPAmount, C.PPNTransport AS PPNPercent, C.PPHTransport AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPriceTransport-B.ReceiveAmountTransport+A.Amount-B.AllocateDPAmountTransport+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN B.Quantity-B.InvoiceQuantityTransport<=0 THEN 1 ELSE B.Quantity-B.InvoiceQuantityTransport+A.Quantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traDeliveryDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traDelivery C ON " & vbNewLine &
                    "   B.DeliveryID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.DeliveryID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, Quantity=CASE WHEN A.Quantity-A.InvoiceQuantityTransport < 0 THEN CAST(0 AS DECIMAL(18,4)) ELSE A.Quantity-A.InvoiceQuantityTransport END, A.Weight, CAST(0 AS DECIMAL(18,4)) AS TotalWeight, MaxTotalWeight=A.TotalWeight-A.InvoiceTotalWeight, " & vbNewLine &
                    "   UnitPrice=B.UnitPriceTransport, A.TotalPriceTransport AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPNTransport AS PPNPercent, B.PPHTransport AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPriceTransport-A.AllocateDPAmountTransport-A.ReceiveAmountTransport AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID , " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN A.Quantity-A.InvoiceQuantityTransport<=0 THEN 1 ELSE A.Quantity-A.InvoiceQuantityTransport END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traDeliveryDet A " & vbNewLine &
                    "INNER JOIN traDelivery B ON " & vbNewLine &
                    "   A.DeliveryID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.TransporterID=@BPID " & vbNewLine &
                    "   And B.CompanyID=@CompanyID " & vbNewLine &
                    "   And B.ProgramID=@ProgramID " & vbNewLine &
                    "   And B.ID=@ReferencesID " & vbNewLine &
                    "   And B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPriceTransport-A.AllocateDPAmountTransport-A.ReceiveAmountTransport>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                '# Transport
                If .CommandText.Trim <> "" Then .CommandText += "UNION ALL " & vbNewLine
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Quantity, A.Weight, A.TotalWeight, MaxTotalWeight=B.TotalWeight-B.InvoiceTotalWeightTransport+A.TotalWeight, " & vbNewLine &
                    "   UnitPrice=C.UnitPriceTransport, B.TotalPriceTransport AS InvoiceAmount, A.Amount, A.DPAmount, C.PPNTransport AS PPNPercent, C.PPHTransport AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPriceTransport-B.ReceiveAmountTransport+A.Amount-B.AllocateDPAmountTransport+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN B.Quantity-B.InvoiceQuantityTransport<=0 THEN 1 ELSE B.Quantity-B.InvoiceQuantityTransport+A.Quantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traSalesReturnDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traSalesReturn C ON " & vbNewLine &
                    "   B.SalesReturnID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.SalesReturnID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, Quantity=CASE WHEN A.Quantity-A.InvoiceQuantityTransport < 0 THEN CAST(0 AS DECIMAL(18,4)) ELSE A.Quantity-A.InvoiceQuantityTransport END, A.Weight, CAST(0 AS DECIMAL(18,4)) AS TotalWeight, MaxTotalWeight=A.TotalWeight-A.InvoiceTotalWeight, " & vbNewLine &
                    "   UnitPrice=B.UnitPriceTransport, A.TotalPriceTransport AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPNTransport AS PPNPercent, B.PPHTransport AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPriceTransport-A.AllocateDPAmountTransport-A.ReceiveAmountTransport AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID , " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN A.Quantity-A.InvoiceQuantityTransport<=0 THEN 1 ELSE A.Quantity-A.InvoiceQuantityTransport END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traSalesReturnDet A " & vbNewLine &
                    "INNER JOIN traSalesReturn B ON " & vbNewLine &
                    "   A.SalesReturnID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.TransporterID=@BPID " & vbNewLine &
                    "   And B.CompanyID=@CompanyID " & vbNewLine &
                    "   And B.ProgramID=@ProgramID " & vbNewLine &
                    "   And B.ID=@ReferencesID " & vbNewLine &
                    "   And B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPriceTransport-A.AllocateDPAmountTransport-A.ReceiveAmountTransport>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                '# Confirmation Claim
                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Quantity, A.Weight, A.TotalWeight, MaxTotalWeight=B.TotalWeight-B.InvoiceTotalWeight+A.TotalWeight, " & vbNewLine &
                    "   B.UnitPrice, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.ReceiveAmount+A.Amount-B.AllocateDPAmount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN B.Quantity-B.InvoiceQuantity<=0 THEN 1 ELSE B.Quantity-B.InvoiceQuantity+A.Quantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traConfirmationClaimDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.ConfirmationClaimID " & vbNewLine &
                    "   And A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traConfirmationClaim C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    "" & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.ConfirmationClaimID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, CASE WHEN A.Quantity-A.InvoiceQuantity<=0 THEN 1 ELSE A.Quantity-A.InvoiceQuantity END AS Quantity, A.Weight, CAST(0 AS DECIMAL(18,4)) AS TotalWeight, MaxTotalWeight=A.TotalWeight-A.InvoiceTotalWeight, " & vbNewLine &
                    "   A.UnitPrice, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.AllocateDPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID, " & vbNewLine &
                    "   MaxTotalQuantity=CASE WHEN A.Quantity-A.InvoiceQuantity<=0 THEN 1 ELSE A.Quantity-A.InvoiceQuantity END, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traConfirmationClaimDet A " & vbNewLine &
                    "INNER JOIN traConfirmationClaim B ON " & vbNewLine &
                    "   A.ConfirmationClaimID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   And B.CompanyID=@CompanyID " & vbNewLine &
                    "   And B.ProgramID=@ProgramID " & vbNewLine &
                    "   And B.ID=@ReferencesID " & vbNewLine &
                    "   And B.SubmitBy<>'' " & vbNewLine &
                    "   And B.ClaimType=@ClaimType " & vbNewLine &
                    "   AND A.TotalPrice-A.AllocateDPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine &
                    "" & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@ClaimType", SqlDbType.Int).Value = VO.Claim.ClaimTypeValue.Sales
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailTransportReceiveWithOutstandingVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                                  ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                  ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                '# Delivery Transport
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.DeliveryNumber AS PurchaseNumber, A.Amount, A.PPN, A.PPH, GrandTotal=A.Amount+A.PPN-A.PPH, " & vbNewLine &
                    "   MaxAmount=B.TotalDPPTransport-B.DPAmountTransport+A.Amount-B.TotalPaymentTransport, MaxPPN=B.TotalPPNTransport-B.DPAmountPPNTransport+A.PPN-B.TotalPaymentPPNTransport, " & vbNewLine &
                    "   MaxPPH=B.TotalPPHTransport-B.DPAmountPPHTransport+A.PPH-B.TotalPaymentPPHTransport, A.InvoiceNumberBP, A.ReceiveDate, A.InvoiceDate, A.Remarks, " & vbNewLine &
                    "   MaxGrandTotal=(B.TotalDPPTransport-B.DPAmountTransport+A.Amount-B.TotalPaymentTransport)+(B.TotalPPNTransport-B.DPAmountPPNTransport+A.PPN-B.TotalPaymentPPNTransport)-(B.TotalPPHTransport-B.DPAmountPPHTransport+A.PPH-B.TotalPaymentPPHTransport) " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traDelivery B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.DeliveryNumber AS PurchaseNumber, A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport AS Amount, A.TotalPPNTransport-A.DPAmountPPNTransport-A.TotalPaymentPPNTransport AS PPN, A.TotalPPHTransport-A.DPAmountPPHTransport-A.TotalPaymentPPHTransport AS PPH, GrandTotal=(A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport)+(A.TotalPPNTransport-A.DPAmountPPNTransport-A.TotalPaymentPPNTransport)-(A.TotalPPHTransport-A.DPAmountPPHTransport-A.TotalPaymentPPHTransport), " & vbNewLine &
                    "   MaxAmount=A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport, MaxPPN=A.TotalPPNTransport-A.DPAmountPPNTransport-A.TotalPaymentPPNTransport, MaxPPH=A.TotalPPHTransport-A.DPAmountPPHTransport-A.TotalPaymentPPHTransport, " & vbNewLine &
                    "   CAST('' AS VARCHAR(1000)) AS InvoiceNumberBP, GETDATE() AS ReceiveDate, GETDATE() AS InvoiceDate, CAST('' AS VARCHAR(250)) AS Remarks, " & vbNewLine &
                    "   MaxGrandTotal=(A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport)+(A.TotalPPNTransport-A.DPAmountPPNTransport-A.TotalPaymentPPNTransport)-(A.TotalPPHTransport-A.DPAmountPPHTransport-A.TotalPaymentPPHTransport) " & vbNewLine &
                    "FROM traDelivery A " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.TransporterID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "	            AND ARH.Modules=@ModulesTransport" & vbNewLine &
                    "       ) " & vbNewLine

                '# Sales Return Transport
                If .CommandText.Trim <> "" Then .CommandText += "UNION ALL " & vbNewLine
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.SalesReturnNumber AS PurchaseNumber, A.Amount, A.PPN, A.PPH, GrandTotal=A.Amount+A.PPN-A.PPH, " & vbNewLine &
                    "   MaxAmount=B.TotalDPPTransport-B.DPAmountTransport+A.Amount-B.TotalPaymentTransport, MaxPPN=B.TotalPPNTransport-B.DPAmountPPNTransport+A.PPN-B.TotalPaymentPPNTransport, " & vbNewLine &
                    "   MaxPPH=B.TotalPPHTransport-B.DPAmountPPHTransport+A.PPH-B.TotalPaymentPPHTransport, A.InvoiceNumberBP, A.ReceiveDate, A.InvoiceDate, A.Remarks, " & vbNewLine &
                    "   MaxGrandTotal=(B.TotalDPPTransport-B.DPAmountTransport+A.Amount-B.TotalPaymentTransport)+(B.TotalPPNTransport-B.DPAmountPPNTransport+A.PPN-B.TotalPaymentPPNTransport)-(B.TotalPPHTransport-B.DPAmountPPHTransport+A.PPH-B.TotalPaymentPPHTransport) " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traSalesReturn B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.SalesReturnNumber AS PurchaseNumber, A.TotalDPPTransport AS Amount, A.TotalPPNTransport AS PPN, A.TotalPPHTransport AS PPH, GrandTotal=(A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport)+(A.TotalPPNTransport-A.DPAmountPPNTransport-A.TotalPaymentPPNTransport)-(A.TotalPPHTransport-A.DPAmountPPHTransport-A.TotalPaymentPPHTransport), " & vbNewLine &
                    "   MaxAmount=A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport, MaxPPN=A.TotalPPNTransport-A.DPAmountPPNTransport-A.TotalPaymentPPNTransport, MaxPPH=A.TotalPPHTransport-A.DPAmountPPHTransport-A.TotalPaymentPPHTransport, " & vbNewLine &
                    "   CAST('' AS VARCHAR(1000)) AS InvoiceNumberBP, GETDATE() AS ReceiveDate, GETDATE() AS InvoiceDate, CAST('' AS VARCHAR(250)) AS Remarks, " & vbNewLine &
                    "   MaxGrandTotal=(A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport)+(A.TotalPPNTransport-A.DPAmountPPNTransport-A.TotalPaymentPPNTransport)-(A.TotalPPHTransport-A.DPAmountPPHTransport-A.TotalPaymentPPHTransport) " & vbNewLine &
                    "FROM traSalesReturn A " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.TransporterID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalDPPTransport-A.DPAmountTransport-A.TotalPaymentTransport>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.PurchaseID 	" & vbNewLine &
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.APID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "	            AND ARH.Modules=@ModulesTransport" & vbNewLine &
                    "       ) " & vbNewLine


                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ModulesTransport", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentTransport
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemCuttingReceiveWithOutstandingVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                                    ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                    ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.PPN, A.PPH, A.Rounding, B.TotalPrice-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, " & vbNewLine &
                    "   MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, MI.ItemCodeExternal, A.InvoiceNumberBP, A.ReceiveDateInvoice AS ReceiveDate, A.InvoiceDateBP AS InvoiceDate, CAST('' AS VARCHAR(250)) AS Remarks " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traCuttingDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traCutting C ON " & vbNewLine &
                    "   B.CuttingID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.CuttingID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, A.TotalPrice-A.ReceiveAmount AS Amount, CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, " & vbNewLine &
                    "   MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID, MI.ItemCodeExternal, CAST('' AS VARCHAR(1000)) AS InvoiceNumberBP, GETDATE() AS ReceiveDate, GETDATE() AS InvoiceDate, " & vbNewLine &
                    "   CAST('' AS VARCHAR(250)) AS Remarks " & vbNewLine &
                    "FROM traCuttingDet A " & vbNewLine &
                    "INNER JOIN traCutting B ON " & vbNewLine &
                    "   A.CuttingID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   B.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.TotalWeight-A.InvoiceTotalWeight>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@APID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.APID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traAccountPayableStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.AccountPayableStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traAccountPayableStatus " & vbNewLine &
                    "   (ID, APID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @APID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = clsData.APID
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
                                              ByVal strAPID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traAccountPayableStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   APID=@APID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
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

#Region "Down Payment"

        Public Shared Function ListDataDownPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST(1 AS BIT) AS Pick, A.DPID, B.APNumber AS DPNumber, B.APDate AS DPDate, A.DPAmount, MaxDPAmount=B.TotalAmount-B.TotalAmountUsed+A.DPAmount " & vbNewLine &
                    "FROM traARAPDP A " & vbNewLine &
                    "INNER JOIN traAccountPayable B ON " & vbNewLine &
                    "   A.DPID=B.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDownPaymentWithOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strModules As String,
                                                                  ByVal strParentID As String, ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST(1 AS BIT) AS Pick, A.DPID, B.APNumber AS DPNumber, B.APDate AS DPDate, A.DPAmount, MaxDPAmount=B.TotalAmount-B.TotalAmountUsed+A.DPAmount, " & vbNewLine &
                    "   B.Percentage, B.ReferencesNumber " & vbNewLine &
                    "FROM traARAPDP A " & vbNewLine &
                    "INNER JOIN traAccountPayable B ON " & vbNewLine &
                    "   A.DPID=B.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine &
                    "   AND B.ReferencesID=@ReferencesID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS DPID, A.APNumber AS DPNumber, A.APDate AS DPDate, A.TotalAmount, MaxDPAmount=A.TotalAmount-A.TotalAmountUsed, " & vbNewLine &
                    "   A.Percentage, A.ReferencesNumber " & vbNewLine &
                    "FROM traAccountPayable A " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.IsDP=1 " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalAmount-A.TotalAmountUsed>0 " & vbNewLine &
                    "   AND A.ReferencesID=@ReferencesID " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARAPDP.DPID 	" & vbNewLine &
                    "           FROM traARAPDP ARAPDP 	" & vbNewLine &
                    "           INNER JOIN traAccountPayable APH ON 	" & vbNewLine &
                    "	            ARAPDP.DPID=APH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               APH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND APH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND APH.BPID=@BPID " & vbNewLine &
                    "	            AND APH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARAPDP.ParentID=@ParentID " & vbNewLine &
                    "       ) " & vbNewLine


                If strModules.Trim <> VO.AccountPayable.All Then
                    .CommandText += "   AND A.Modules=@Modules " & vbNewLine
                End If

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = strModules
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 250).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

    End Class
End Namespace