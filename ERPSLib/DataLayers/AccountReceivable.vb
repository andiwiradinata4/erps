Namespace DL
    Public Class AccountReceivable

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String,
                                        ByVal intBPID As Integer, ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.ARNumber, A.BPID, " & vbNewLine &
                    "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfIncomePayment, ISNULL(COA.Code,'') AS CoACodeOfIncomePayment, ISNULL(COA.Name,'') AS CoANameOfIncomePayment, " & vbNewLine &
                    "   A.Modules, A.ReferencesID, A.ReferencesNote, A.ARDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                    "   A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine &
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                    "   A.LogInc, A.LogBy, A.LogDate, A.ARNumber AS TransNumber, A.ARDate AS TransDate, A.CoAIDOfIncomePayment AS CoAID, ISNULL(COA.Code,'') AS CoACode, ISNULL(COA.Name,'') AS CoAName,  " & vbNewLine &
                    "   A.TotalPPN, A.TotalPPH, A.DPAmount, A.ReceiveAmount, A.IsDP, A.InvoiceNumberBP, A.CompanyBankAccountID1, A.CompanyBankAccountID2, A.IsUseSubItem " & vbNewLine &
                    "FROM traAccountReceivable A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "   A.CoAIDOfIncomePayment=COA.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.ARDate>=@DateFrom AND A.ARDate<=@DateTo " & vbNewLine

                If strModules.Trim <> VO.AccountReceivable.All Then .CommandText += "   AND A.Modules=@Modules " & vbNewLine

                If intStatusID <> VO.Status.Values.All Then .CommandText += "    AND A.StatusID=@StatusID" & vbNewLine

                If intBPID <> 0 Then .CommandText += "    AND A.BPID=@BPID " & vbNewLine

                If strReferencesID.Trim <> "" Then .CommandText += "   AND A.ReferencesID=@ReferencesID " & vbNewLine

                .CommandText += "ORDER BY A.ARDate, A.ID ASC " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = strModules
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
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
                    "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.ARNumber, A.BPID, " & vbNewLine &
                    "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfIncomePayment, ISNULL(COA.Code,'') AS CoACodeOfIncomePayment, ISNULL(COA.Name,'') AS CoANameOfIncomePayment, " & vbNewLine &
                    "   A.Modules, MDARAP.Name AS ModulesName, A.ReferencesID, A.ReferencesNote, A.ARDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.JournalID, A.StatusID, " & vbNewLine &
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine &
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                    "   A.LogInc, A.LogBy, A.LogDate, A.ARNumber AS TransNumber, A.ARDate AS TransDate, A.CoAIDOfIncomePayment AS CoAID, " & vbNewLine &
                    "   ISNULL(COA.Code,'') AS CoACode, ISNULL(COA.Name,'') AS CoAName, A.TotalPPN, A.TotalPPH  " & vbNewLine &
                    "FROM traAccountReceivable A " & vbNewLine &
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
                    "   A.CoAIDOfIncomePayment=COA.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.PaymentBy='' " & vbNewLine &
                    "   AND A.StatusID=@StatusID " & vbNewLine

                If strModules.Trim <> "" Then .CommandText += "   AND A.Modules=@Modules "

                .CommandText += "ORDER BY A.DueDate, A.ARDate, A.ID ASC " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = strModules
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.AccountReceivable)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO traAccountReceivable " & vbNewLine &
                        "   (ID, CompanyID, ProgramID, ARNumber, BPID, CoAIDOfIncomePayment, Modules, ReferencesID, ReferencesNote, " & vbNewLine &
                        "    ARDate, DueDateValue, DueDate, TotalAmount, Percentage, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, " & vbNewLine &
                        "    TotalPPN, TotalPPH, IsDP, DPAmount, ReceiveAmount, IsUseSubItem) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @CompanyID, @ProgramID, @ARNumber, @BPID, @CoAIDOfIncomePayment, @Modules, @ReferencesID, @ReferencesNote, " & vbNewLine &
                        "    @ARDate, @DueDateValue, @DueDate, @TotalAmount, @Percentage, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), " & vbNewLine &
                        "    @TotalPPN, @TotalPPH, @IsDP, @DPAmount, @ReceiveAmount, @IsUseSubItem) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE traAccountReceivable SET " & vbNewLine &
                        "    CompanyID=@CompanyID, " & vbNewLine &
                        "    ProgramID=@ProgramID, " & vbNewLine &
                        "    ARNumber=@ARNumber, " & vbNewLine &
                        "    BPID=@BPID, " & vbNewLine &
                        "    CoAIDOfIncomePayment=@CoAIDOfIncomePayment, " & vbNewLine &
                        "    Modules=@Modules, " & vbNewLine &
                        "    ReferencesID=@ReferencesID, " & vbNewLine &
                        "    ReferencesNote=@ReferencesNote, " & vbNewLine &
                        "    ARDate=@ARDate, " & vbNewLine &
                        "    DueDateValue=@DueDateValue, " & vbNewLine &
                        "    DueDate=@DueDate, " & vbNewLine &
                        "    TotalAmount=@TotalAmount, " & vbNewLine &
                        "    TotalPPN=@TotalPPN, " & vbNewLine &
                        "    TotalPPH=@TotalPPH, " & vbNewLine &
                        "    Percentage=@Percentage, " & vbNewLine &
                        "    Remarks=@Remarks, " & vbNewLine &
                        "    StatusID=@StatusID, " & vbNewLine &
                        "    LogInc=LogInc+1, " & vbNewLine &
                        "    LogBy=@LogBy, " & vbNewLine &
                        "    LogDate=GETDATE(), " & vbNewLine &
                        "    IsDP=@IsDP, " & vbNewLine &
                        "    DPAmount=@DPAmount, " & vbNewLine &
                        "    ReceiveAmount=@ReceiveAmount, " & vbNewLine &
                        "    IsUseSubItem=@IsUseSubItem " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@ARNumber", SqlDbType.VarChar, 100).Value = clsData.ARNumber
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@CoAIDOfIncomePayment", SqlDbType.Int).Value = clsData.CoAIDOfIncomePayment
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = clsData.Modules
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 250).Value = clsData.ReferencesID
                .Parameters.Add("@ReferencesNote", SqlDbType.VarChar, 250).Value = clsData.ReferencesNote
                .Parameters.Add("@ARDate", SqlDbType.DateTime).Value = clsData.ARDate
                .Parameters.Add("@DueDateValue", SqlDbType.Int).Value = clsData.DueDateValue
                .Parameters.Add("@DueDate", SqlDbType.DateTime).Value = clsData.DueDate
                .Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = clsData.TotalAmount
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@Percentage", SqlDbType.Decimal).Value = clsData.Percentage
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@IsDP", SqlDbType.Bit).Value = clsData.IsDP
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@ReceiveAmount", SqlDbType.Decimal).Value = clsData.ReceiveAmount
                .Parameters.Add("@IsUseSubItem", SqlDbType.Bit).Value = clsData.IsUseSubItem
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.AccountReceivable
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.AccountReceivable
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.ARNumber, A.BPID, " & vbNewLine &
                        "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfIncomePayment, ISNULL(COA.Code,'') AS CoACodeOfIncomePayment, ISNULL(COA.Name,'') AS CoANameOfIncomePayment, " & vbNewLine &
                        "   A.Modules, A.ReferencesID, A.ReferencesNote, A.ARDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.Percentage, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                        "   A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.PaymentBy, A.PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                        "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                        "   A.LogInc, A.LogBy, A.LogDate, A.TotalPPN, A.TotalPPH, A.IsDP, A.DPAmount, A.ReceiveAmount, A.TotalAmountUsed, A.JournalIDInvoice, A.InvoiceNumberBP " & vbNewLine &
                        "FROM traAccountReceivable A " & vbNewLine &
                        "INNER JOIN mstStatus B ON " & vbNewLine &
                        "   A.StatusID=B.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                        "   A.BPID=C.ID " & vbNewLine &
                        "INNER JOIN mstCompany MC ON " & vbNewLine &
                        "   A.CompanyID=MC.ID " & vbNewLine &
                        "INNER JOIN mstProgram MP ON " & vbNewLine &
                        "   A.ProgramID=MP.ID " & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "   A.CoAIDOfIncomePayment=COA.ID " & vbNewLine &
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
                        voReturn.ARNumber = .Item("ARNumber")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.CoAIDOfIncomePayment = .Item("CoAIDOfIncomePayment")
                        voReturn.CoACodeOfIncomePayment = .Item("CoACodeOfIncomePayment")
                        voReturn.CoANameOfIncomePayment = .Item("CoANameOfIncomePayment")
                        voReturn.Modules = .Item("Modules")
                        voReturn.ReferencesID = .Item("ReferencesID")
                        voReturn.ReferencesNote = .Item("ReferencesNote")
                        voReturn.ARDate = .Item("ARDate")
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
                                         ByVal intCompanyID As String, ByVal intProgramID As Integer,
                                         ByVal intBPID As Integer, ByVal strID As String) As VO.AccountReceivable
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.AccountReceivable
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.ARNumber, A.BPID, " & vbNewLine &
                        "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfIncomePayment, ISNULL(COA.Code,'') AS CoACodeOfIncomePayment, ISNULL(COA.Name,'') AS CoANameOfIncomePayment, " & vbNewLine &
                        "   A.Modules, A.ReferencesID, A.ReferencesNote, A.ARDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.Percentage, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                        "   A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.PaymentBy, A.PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                        "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.TotalPPN, " & vbNewLine &
                        "   A.TotalPPH, A.IsDP, A.DPAmount, A.ReceiveAmount, A.TotalAmountUsed, A.JournalIDInvoice, A.InvoiceNumberBP, A.CompanyBankAccountID1, A.CompanyBankAccountID2 " & vbNewLine &
                        "FROM traAccountReceivable A " & vbNewLine &
                        "INNER JOIN mstStatus B ON " & vbNewLine &
                        "   A.StatusID=B.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                        "   A.BPID=C.ID " & vbNewLine &
                        "INNER JOIN mstCompany MC ON " & vbNewLine &
                        "   A.CompanyID=MC.ID " & vbNewLine &
                        "INNER JOIN mstProgram MP ON " & vbNewLine &
                        "   A.ProgramID=MP.ID " & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "   A.CoAIDOfIncomePayment=COA.ID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   A.CompanyID=@CompanyID " & vbNewLine &
                        "   AND A.ProgramID=@ProgramID " & vbNewLine &
                        "   AND A.BPID=@BPID " & vbNewLine &
                        "   AND A.ID<>@ID " & vbNewLine &
                        "ORDER BY A.ARDate DESC "

                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.ARNumber = .Item("ARNumber")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.CoAIDOfIncomePayment = .Item("CoAIDOfIncomePayment")
                        voReturn.CoACodeOfIncomePayment = .Item("CoACodeOfIncomePayment")
                        voReturn.CoANameOfIncomePayment = .Item("CoANameOfIncomePayment")
                        voReturn.Modules = .Item("Modules")
                        voReturn.ReferencesID = .Item("ReferencesID")
                        voReturn.ReferencesNote = .Item("ReferencesNote")
                        voReturn.ARDate = .Item("ARDate")
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
                        voReturn.CompanyBankAccountID1 = .Item("CompanyBankAccountID1")
                        voReturn.CompanyBankAccountID2 = .Item("CompanyBankAccountID2")
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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
                        "FROM traAccountReceivable " & vbNewLine &
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
                        "FROM traAccountReceivable " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   YEAR(ARDate)=@Year " & vbNewLine &
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
                                          ByVal strARNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traAccountReceivable " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ARNumber=@ARNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@ARNumber", SqlDbType.VarChar, 100).Value = strARNumber
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
                        "FROM traAccountReceivable " & vbNewLine &
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
                        "FROM traAccountReceivable " & vbNewLine &
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedReceivePayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
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
                .CommandText =
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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
                                       ByVal intCoAIDOfIncomePayment As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountReceivable SET " & vbNewLine &
                    "    CoAIDOfIncomePayment=@CoAIDOfIncomePayment, " & vbNewLine &
                    "    PaymentBy=@PaymentBy, " & vbNewLine &
                    "    PaymentDate=@PaymentDate, " & vbNewLine &
                    "    StatusID=@StatusID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@CoAIDOfIncomePayment", SqlDbType.Int).Value = intCoAIDOfIncomePayment
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
                    "    CoAIDOfIncomePayment=CASE WHEN IsDP=1 THEN CoAIDOfIncomePayment ELSE 0 END, " & vbNewLine &
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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
                    "UPDATE traAccountReceivable SET " & vbNewLine &
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

        Public Shared Sub UpdateCompanyBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strID As String, ByVal intCompanyBankAccountID1 As Integer,
                                                   ByVal intCompanyBankAccountID2 As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountReceivable SET " & vbNewLine &
                    "   CompanyBankAccountID1=@CompanyBankAccountID1, " & vbNewLine &
                    "   CompanyBankAccountID2=@CompanyBankAccountID2 " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@CompanyBankAccountID1", SqlDbType.Int).Value = intCompanyBankAccountID1
                .Parameters.Add("@CompanyBankAccountID2", SqlDbType.Int).Value = intCompanyBankAccountID2
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetailForSetupBalance(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID, B.InvoiceNumber, B.InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH AS SalesAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH-B.TotalPaymentDP-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN mstBusinessPartnerARBalance B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailForSetupBalanceWithOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                            ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                            ByVal intBPID As Integer, ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID, B.InvoiceNumber, B.InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH AS SalesAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH-B.TotalPaymentDP-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN mstBusinessPartnerARBalance B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS SalesID, A.InvoiceNumber, A.InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH AS SalesAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH-A.TotalPaymentDP-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM mstBusinessPartnerARBalance A " & vbNewLine &
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
                    "           SELECT ARD.SalesID 	" & vbNewLine &
                    "           FROM traAccountReceivableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountReceivable ARH ON 	" & vbNewLine &
                    "	        ARD.ARID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@ARID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID AS InvoiceID, B.SCNumber AS InvoiceNumber, B.SCDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS SalesAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN traSalesContract B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID AS InvoiceID, B.OrderNumber AS InvoiceNumber, B.OrderDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS SalesAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN traOrderRequest B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOnly(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.SalesID AS InvoiceID, A.Amount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailWithOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                             ByVal intBPID As Integer, ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID, B.SCNumber AS InvoiceNumber, B.SCDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS SalesAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN traSalesContract B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS SalesID, A.SCNumber AS InvoiceNumber, A.SCDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS SalesAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
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
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.SalesID 	" & vbNewLine &
                    "           FROM traAccountReceivableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountReceivable ARH ON 	" & vbNewLine &
                    "	        ARD.ARID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@ARID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.AccountReceivableDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traAccountReceivableDet " & vbNewLine &
                    "   (ID, ARID, SalesID, Amount, Remarks, PPN, PPH, DPAmount, Rounding, LevelItem, ReferencesParentID) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ARID, @SalesID, @Amount, @Remarks, @PPN, @PPH, @DPAmount, @Rounding, @LevelItem, @ReferencesParentID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = clsData.ARID
                .Parameters.Add("@SalesID", SqlDbType.VarChar, 100).Value = clsData.SalesID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ReferencesParentID", SqlDbType.VarChar, 100).Value = clsData.ReferencesParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strARID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traAccountReceivableDet    " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ARID=@ARID" & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ListDataDetailRev01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID AS InvoiceID, B.SCNumber AS InvoiceNumber, B.SCDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN traSalesContract B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID AS InvoiceID, B.OrderNumber AS InvoiceNumber, B.OrderDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN traOrderRequest B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailRev02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traSalesContractDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.SCID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traSalesContract C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ARID " & vbNewLine &
                    " " & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traDeliveryDet B ON " & vbNewLine &
                    "   A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traDelivery C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ARID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traOrderRequestDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.OrderRequestID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traOrderRequest C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ARID " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailWithOutstandingRev01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strARID As String,
                                                                  ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.SalesID AS InvoiceID, B.DeliveryNumber AS InvoiceNumber, B.DeliveryDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual AS InvoiceAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountReceivableDet A " & vbNewLine &
                    "INNER JOIN traDelivery B ON " & vbNewLine &
                    "   A.SalesID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS InvoiceID, A.DeliveryNumber AS InvoiceNumber, A.DeliveryDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM traDelivery A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.SCID=@ReferencesID " & vbNewLine &
                    "   AND A.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.RoundingManual-A.DPAmount-A.TotalPayment>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.SalesID 	" & vbNewLine &
                    "           FROM traAccountReceivableDet ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountReceivable ARH ON 	" & vbNewLine &
                    "	        ARD.ARID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@ARID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemDPWithOutstandingVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                        ByVal intBPID As Integer, ByVal strARID As String,
                                                                        ByVal strReferencesID As String, ByVal bolIsUseSubItem As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traSalesContractDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.SCID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traSalesContract C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ARID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.SCID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID " & vbNewLine &
                    "FROM traSalesContractDet A " & vbNewLine &
                    "INNER JOIN traSalesContract B ON " & vbNewLine &
                    "   A.SCID=B.ID " & vbNewLine &
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
                    "   AND A.SCID=@ReferencesID " & vbNewLine &
                    "   AND B.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.TotalWeight-A.DCWeight>0 " & vbNewLine

                If bolIsUseSubItem Then .CommandText += "   AND A.ParentID<>'' " & vbNewLine

                .CommandText +=
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountReceivable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@ARID " & vbNewLine &
                    "       ) " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traOrderRequestDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.OrderRequestID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traOrderRequest C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ARID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.OrderRequestID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, CAST(0 AS INT) AS LevelItem, CAST('' AS VARCHAR(100)) AS ReferencesParentID " & vbNewLine &
                    "FROM traOrderRequestDet A " & vbNewLine &
                    "INNER JOIN traOrderRequest B ON " & vbNewLine &
                    "   A.OrderRequestID=B.ID " & vbNewLine &
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
                    "   AND A.OrderRequestID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.TotalWeight-A.SCWeight>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountReceivable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@ARID " & vbNewLine &
                    "       ) " & vbNewLine


                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemReceiveWithOutstandingVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                             ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                             ByVal intBPID As Integer, ByVal strARID As String,
                                                                             ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID  " & vbNewLine &
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
                    "   A.ParentID=@ARID " & vbNewLine &
                    "" & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.DeliveryID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID " & vbNewLine &
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
                    "   B.BPID=@BPID " & vbNewLine &
                    "   AND B.CompanyID=@CompanyID " & vbNewLine &
                    "   AND B.ProgramID=@ProgramID " & vbNewLine &
                    "   AND B.SCID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountReceivable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@ARID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailItemReceiveWithOutstandingVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                             ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                             ByVal intBPID As Integer, ByVal strARID As String,
                                                                             ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, B.TotalPrice AS InvoiceAmount, A.Amount, A.DPAmount, C.PPN AS PPNPercent, C.PPH AS PPHPercent, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.TotalPrice-B.DPAmount-B.ReceiveAmount+A.Amount+A.DPAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID  " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN traSalesContractDet B ON " & vbNewLine &
                    "   A.ReferencesID=B.SCID " & vbNewLine &
                    "   AND A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN traSalesContract C ON " & vbNewLine &
                    "   A.ReferencesID=C.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ARID " & vbNewLine &
                    "" & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.SCID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.TotalPrice AS InvoiceAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, CAST(0 AS DECIMAL(18,2)) AS DPAmount, B.PPN AS PPNPercent, B.PPH AS PPHPercent, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPN, CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS Rounding, " & vbNewLine &
                    "   A.TotalPrice-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
                    "   MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName, A.LevelItem, A.ParentID AS ReferencesParentID " & vbNewLine &
                    "FROM traSalesContractDet A " & vbNewLine &
                    "INNER JOIN traSalesContract B ON " & vbNewLine &
                    "   A.SCID=B.ID " & vbNewLine &
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
                    "   AND B.ID=@ReferencesID " & vbNewLine &
                    "   AND B.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalPrice-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine &
                    "   AND A.ID NOT IN " & vbNewLine &
                    "       ( " & vbNewLine &
                    "           SELECT ARD.ReferencesDetailID 	" & vbNewLine &
                    "           FROM traARAPItem ARD 	" & vbNewLine &
                    "           INNER JOIN traAccountReceivable ARH ON 	" & vbNewLine &
                    "	            ARD.ParentID=ARH.ID		" & vbNewLine &
                    "           WHERE 	" & vbNewLine &
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine &
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine &
                    "	            AND ARH.BPID=@BPID " & vbNewLine &
                    "	            AND ARH.IsDeleted=0	" & vbNewLine &
                    "	            AND ARH.ID=@ARID " & vbNewLine &
                    "       ) " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strARID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ARID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traAccountReceivableStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ARID=@ARID " & vbNewLine

                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.AccountReceivableStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traAccountReceivableStatus " & vbNewLine &
                    "   (ID, ARID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ARID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = clsData.ARID
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
                                              ByVal strARID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traAccountReceivableStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ARID=@ARID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ARID", SqlDbType.VarChar, 100).Value = strARID
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
                    "   CAST(1 AS BIT) AS Pick, A.DPID, B.ARNumber AS DPNumber, B.ARDate AS DPDate, A.DPAmount, MaxDPAmount=B.TotalAmount-B.TotalAmountUsed+A.DPAmount " & vbNewLine &
                    "FROM traARAPDP A " & vbNewLine &
                    "INNER JOIN traAccountReceivable B ON " & vbNewLine &
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
                    "   CAST(1 AS BIT) AS Pick, A.DPID, B.ARNumber AS DPNumber, B.ARDate AS DPDate, A.DPAmount, MaxDPAmount=B.TotalAmount-B.TotalAmountUsed+A.DPAmount " & vbNewLine &
                    "FROM traARAPDP A " & vbNewLine &
                    "INNER JOIN traAccountReceivable B ON " & vbNewLine &
                    "   A.DPID=B.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine &
                    "   AND B.ReferencesID=@ReferencesID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS DPID, A.ARNumber AS DPNumber, A.ARDate AS DPDate, A.TotalAmount, MaxDPAmount=A.TotalAmount-A.TotalAmountUsed " & vbNewLine &
                    "FROM traAccountReceivable A " & vbNewLine &
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
                    "           INNER JOIN traAccountReceivable APH ON 	" & vbNewLine &
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