﻿Namespace DL
    Public Class AccountPayable

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
                    "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.APNumber, A.BPID, " & vbNewLine &
                    "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, COA.Code AS CoACodeOfOutgoingPayment, COA.Name AS CoANameOfOutgoingPayment, " & vbNewLine &
                    "   A.Modules, A.ReferencesID, A.ReferencesNote, A.APDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                    "   A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine &
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                    "   A.LogInc, A.LogBy, A.LogDate, A.APNumber AS TransNumber, A.APDate AS TransDate, A.CoAIDOfOutgoingPayment AS CoAID, COA.Code AS CoACode, COA.Name AS CoAName, " & vbNewLine &
                    "   A.TotalPPN, A.TotalPPH, A.DPAmount, A.ReceiveAmount  " & vbNewLine &
                    "FROM traAccountPayable A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "INNER JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "   A.CoAIDOfOutgoingPayment=COA.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.APDate>=@DateFrom AND A.APDate<=@DateTo " & vbNewLine

                If strModules.Trim <> VO.AccountPayable.All Then
                    .CommandText += "   AND A.Modules=@Modules " & vbNewLine
                End If

                If intStatusID <> VO.Status.Values.All Then
                    .CommandText += "    AND A.StatusID=@StatusID" & vbNewLine
                End If

                If intBPID <> 0 Then
                    .CommandText += "    AND A.BPID=@BPID " & vbNewLine
                End If

                If strReferencesID.Trim <> "" Then
                    .CommandText += "   AND A.ID IN (SELECT APID FROM traAccountPayableDet WHERE PurchaseID=@ReferencesID)"
                End If

                .CommandText += "ORDER BY A.APDate, A.ID ASC " & vbNewLine

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
                    "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.APNumber, A.BPID, " & vbNewLine &
                    "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, COA.Code AS CoACodeOfOutgoingPayment, COA.Name AS CoANameOfOutgoingPayment, " & vbNewLine &
                    "   A.Modules, MDARAP.Name AS ModulesName, A.ReferencesID, A.ReferencesNote, A.APDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.JournalID, A.StatusID, " & vbNewLine &
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine &
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                    "   A.LogInc, A.LogBy, A.LogDate, A.APNumber AS TransNumber, A.APDate AS TransDate, A.CoAIDOfOutgoingPayment AS CoAID, COA.Code AS CoACode, COA.Name AS CoAName, " & vbNewLine &
                    "   A.TotalPPN, A.TotalPPH " & vbNewLine &
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
                    "INNER JOIN mstChartOfAccount COA ON " & vbNewLine &
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
                        "    TotalPPN, TotalPPH, IsDP, DPAmount, ReceiveAmount) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @CompanyID, @ProgramID, @APNumber, @BPID, @CoAIDOfOutgoingPayment, @Modules, @ReferencesID, @ReferencesNote, " & vbNewLine &
                        "    @APDate, @DueDateValue, @DueDate, @TotalAmount, @Percentage, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), " & vbNewLine &
                        "    @TotalPPN, @TotalPPH, @IsDP, @DPAmount, @ReceiveAmount) " & vbNewLine
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
                        "    ReceiveAmount=@ReceiveAmount " & vbNewLine &
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
                        "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, COA.Code AS CoACodeOfOutgoingPayment, COA.Name AS CoANameOfOutgoingPayment, " & vbNewLine &
                        "   A.Modules, A.ReferencesID, A.ReferencesNote, A.APDate, A.DueDateValue, A.DueDate, A.TotalAmount, A.Percentage, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                        "   A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.PaymentBy, A.PaymentDate, A.TaxInvoiceNumber, " & vbNewLine &
                        "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                        "   A.LogInc, A.LogBy, A.LogDate, A.TotalPPN, A.TotalPPH, A.IsDP, A.DPAmount, A.ReceiveAmount, A.TotalAmountUsed " & vbNewLine &
                        "FROM traAccountPayable A " & vbNewLine &
                        "INNER JOIN mstStatus B ON " & vbNewLine &
                        "   A.StatusID=B.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                        "   A.BPID=C.ID " & vbNewLine &
                        "INNER JOIN mstCompany MC ON " & vbNewLine &
                        "   A.CompanyID=MC.ID " & vbNewLine &
                        "INNER JOIN mstProgram MP ON " & vbNewLine &
                        "   A.ProgramID=MP.ID " & vbNewLine &
                        "INNER JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "   A.CoAIDOfOutgoingPayment=COA.ID " & vbNewLine &
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

        Public Shared Sub SetupPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strID As String, ByVal dtmPaymentDate As DateTime)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traAccountPayable SET " & vbNewLine &
                    "    PaymentBy=@PaymentBy, " & vbNewLine &
                    "    PaymentDate=@PaymentDate, " & vbNewLine &
                    "    StatusID=@StatusID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
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

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strAPID As String) As DataTable
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
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine &
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
                    "   (ID, APID, PurchaseID, Amount, Remarks, PPN, PPH, DPAmount, Rounding) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @APID, @PurchaseID, @Amount, @Remarks, @PPN, @PPH, @DPAmount, @Rounding) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = clsData.APID
                .Parameters.Add("@PurchaseID", SqlDbType.VarChar, 100).Value = clsData.PurchaseID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
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
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.ReceiveNumber AS InvoiceNumber, B.ReceiveDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traReceive B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                '.CommandText +=
                '    "UNION ALL " & vbNewLine &
                '    "SELECT " & vbNewLine &
                '    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine &
                '    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                '    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                '    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                '    "FROM traAccountPayableDet A " & vbNewLine &
                '    "INNER JOIN traPurchaseOrderCutting B ON " & vbNewLine &
                '    "   A.PurchaseID=B.ID " & vbNewLine &
                '    "WHERE " & vbNewLine &
                '    "   A.APID=@APID " & vbNewLine

                '.CommandText +=
                '    "UNION ALL " & vbNewLine &
                '    "SELECT " & vbNewLine &
                '    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine &
                '    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                '    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                '    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                '    "FROM traAccountPayableDet A " & vbNewLine &
                '    "INNER JOIN traPurchaseOrderTransport B ON " & vbNewLine &
                '    "   A.PurchaseID=B.ID " & vbNewLine &
                '    "WHERE " & vbNewLine &
                '    "   A.APID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailWithOutstandingRev01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.ReceiveNumber AS InvoiceNumber, B.ReceiveDate AS InvoiceDate, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine &
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine &
                    "   A.Remarks, B.PPN AS PPNPercent, B.PPH AS PPHPercent, A.PPN, A.PPH, A.DPAmount, A.Rounding " & vbNewLine &
                    "FROM traAccountPayableDet A " & vbNewLine &
                    "INNER JOIN traReceive B ON " & vbNewLine &
                    "   A.PurchaseID=B.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.APID=@APID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.ReceiveNumber AS InvoiceNumber, A.ReceiveDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH, CAST(0 AS DECIMAL(18,2)) AS DPAmount, CAST(0 AS DECIMAL(18,2)) AS Rounding " & vbNewLine &
                    "FROM traReceive A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   And A.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.ProgramID=@ProgramID " & vbNewLine &
                    "   And A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.TotalPayment>0 " & vbNewLine &
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

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS DPID, A.APNumber AS DPNumber, A.APDate AS DPDate, A.TotalAmount, MaxDPAmount=A.TotalAmount-A.TotalAmountUsed " & vbNewLine &
                    "FROM traAccountPayable A " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.IsDP=1 " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalAmount-A.TotalAmountUsed>0 " & vbNewLine &
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
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

    End Class
End Namespace