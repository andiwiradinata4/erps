Namespace DL
    Public Class AccountPayable

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer, _
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String,
                                        ByVal intBPID As Integer, ByVal strReferencesID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.APNumber, A.BPID, " & vbNewLine & _
                    "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, COA.Code AS CoACodeOfOutgoingPayment, COA.Name AS CoANameOfOutgoingPayment, " & vbNewLine & _
                    "   A.Modules, A.ReferencesID, A.ReferencesNote, A.APDate, A.TotalAmount, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine & _
                    "   A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine & _
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine & _
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine & _
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine & _
                    "   A.LogInc, A.LogBy, A.LogDate, A.APNumber AS TransNumber, A.APDate AS TransDate, A.CoAIDOfOutgoingPayment AS CoAID, COA.Code AS CoACode, COA.Name AS CoAName " & vbNewLine & _
                    "FROM traAccountPayable A " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "   A.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "INNER JOIN mstChartOfAccount COA ON " & vbNewLine & _
                    "   A.CoAIDOfOutgoingPayment=COA.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.Modules=@Modules " & vbNewLine & _
                    "   AND A.APDate>=@DateFrom AND A.APDate<=@DateTo " & vbNewLine

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
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
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
                    .CommandText = _
                        "INSERT INTO traAccountPayable " & vbNewLine & _
                        "   (ID, CompanyID, ProgramID, APNumber, BPID, CoAIDOfOutgoingPayment, Modules, ReferencesID, ReferencesNote, " & vbNewLine & _
                        "    APDate, TotalAmount, Percentage, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "   (@ID, @CompanyID, @ProgramID, @APNumber, @BPID, @CoAIDOfOutgoingPayment, @Modules, @ReferencesID, @ReferencesNote, " & vbNewLine & _
                        "    @APDate, @TotalAmount, @Percentage, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine
                Else
                    .CommandText = _
                        "UPDATE traAccountPayable SET " & vbNewLine & _
                        "    CompanyID=@CompanyID, " & vbNewLine & _
                        "    ProgramID=@ProgramID, " & vbNewLine & _
                        "    APNumber=@APNumber, " & vbNewLine & _
                        "    BPID=@BPID, " & vbNewLine & _
                        "    CoAIDOfOutgoingPayment=@CoAIDOfOutgoingPayment, " & vbNewLine & _
                        "    Modules=@Modules, " & vbNewLine & _
                        "    ReferencesID=@ReferencesID, " & vbNewLine & _
                        "    ReferencesNote=@ReferencesNote, " & vbNewLine & _
                        "    APDate=@APDate, " & vbNewLine & _
                        "    TotalAmount=@TotalAmount, " & vbNewLine & _
                        "    Percentage=@Percentage, " & vbNewLine & _
                        "    Remarks=@Remarks, " & vbNewLine & _
                        "    StatusID=@StatusID, " & vbNewLine & _
                        "    LogInc=LogInc+1, " & vbNewLine & _
                        "    LogBy=@LogBy, " & vbNewLine & _
                        "    LogDate=GETDATE() " & vbNewLine & _
                        "WHERE   " & vbNewLine & _
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
                .Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = clsData.TotalAmount
                .Parameters.Add("@Percentage", SqlDbType.Decimal).Value = clsData.Percentage
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
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
                                         ByVal strID As String) As VO.AccountPayable
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.AccountPayable
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.APNumber, A.BPID, " & vbNewLine & _
                        "   C.Code AS BPCode, C.Name AS BPName, A.CoAIDOfOutgoingPayment, COA.Code AS CoACodeOfOutgoingPayment, COA.Name AS CoANameOfOutgoingPayment, " & vbNewLine & _
                        "   A.Modules, A.ReferencesID, A.ReferencesNote, A.APDate, A.TotalAmount, A.Percentage, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine & _
                        "   A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.PaymentBy, A.PaymentDate, A.TaxInvoiceNumber, " & vbNewLine & _
                        "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine & _
                        "   A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                        "FROM traAccountPayable A " & vbNewLine & _
                        "INNER JOIN mstStatus B ON " & vbNewLine & _
                        "   A.StatusID=B.ID " & vbNewLine & _
                        "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                        "   A.BPID=C.ID " & vbNewLine & _
                        "INNER JOIN mstCompany MC ON " & vbNewLine & _
                        "   A.CompanyID=MC.ID " & vbNewLine & _
                        "INNER JOIN mstProgram MP ON " & vbNewLine & _
                        "   A.ProgramID=MP.ID " & vbNewLine & _
                        "INNER JOIN mstChartOfAccount COA ON " & vbNewLine & _
                        "   A.CoAIDOfOutgoingPayment=COA.ID " & vbNewLine & _
                        "WHERE " & vbNewLine & _
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
                    "UPDATE traAccountPayable SET " & vbNewLine & _
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
                        "FROM traAccountPayable " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID " & vbNewLine & _
                        "FROM traAccountPayable " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   APNumber=@APNumber " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   StatusID " & vbNewLine & _
                        "FROM traAccountPayable " & vbNewLine & _
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
                        "FROM traAccountPayable " & vbNewLine & _
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
                    "UPDATE traAccountPayable SET " & vbNewLine & _
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
                    "UPDATE traAccountPayable SET " & vbNewLine & _
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
                    "UPDATE traAccountPayable SET " & vbNewLine & _
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
                    "UPDATE traAccountPayable SET " & vbNewLine & _
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

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traAccountPayable SET " & vbNewLine & _
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

        Public Shared Sub SetupPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strID As String, ByVal dtmPaymentDate As DateTime)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traAccountPayable SET " & vbNewLine & _
                    "    PaymentBy=@PaymentBy, " & vbNewLine & _
                    "    PaymentDate=@PaymentDate, " & vbNewLine & _
                    "    StatusID=@StatusID " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traAccountPayable SET " & vbNewLine & _
                    "    PaymentBy='', " & vbNewLine & _
                    "    StatusID=@StatusID " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traAccountPayable SET " & vbNewLine & _
                    "    TaxInvoiceNumber=@TaxInvoiceNumber " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.InvoiceNumber, B.InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH-B.TotalPaymentDP-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN mstBusinessPartnerAPBalance B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.InvoiceNumber, B.InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH-B.TotalPaymentDP-B.TotalPayment+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN mstBusinessPartnerAPBalance B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.APID=@APID " & vbNewLine

                .CommandText += _
                    "UNION ALL " & vbNewLine & _
                    "SELECT " & vbNewLine & _
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.InvoiceNumber, A.InvoiceDate, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH-A.TotalPaymentDP-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine & _
                    "   CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine & _
                    "FROM mstBusinessPartnerAPBalance A " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.BPID=@BPID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH-A.TotalPaymentDP-A.TotalPayment>0 " & vbNewLine & _
                    "   AND A.ID NOT IN " & vbNewLine & _
                    "       ( " & vbNewLine & _
                    "           SELECT ARD.PurchaseID 	" & vbNewLine & _
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine & _
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine & _
                    "	        ARD.APID=ARH.ID		" & vbNewLine & _
                    "           WHERE 	" & vbNewLine & _
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine & _
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine & _
                    "	            AND ARH.BPID=@BPID " & vbNewLine & _
                    "	            AND ARH.IsDeleted=0	" & vbNewLine & _
                    "	            AND ARH.ID=@APID " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PCNumber AS InvoiceNumber, B.PCDate AS InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseContract B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.APID=@APID " & vbNewLine

                .CommandText += _
                    "UNION ALL " & vbNewLine & _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseOrderCutting B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.APID=@APID " & vbNewLine

                .CommandText += _
                    "UNION ALL " & vbNewLine & _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseOrderTransport B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PCNumber AS InvoiceNumber, B.PCDate AS InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseContract B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.APID=@APID " & vbNewLine

                .CommandText += _
                    "UNION ALL " & vbNewLine & _
                    "SELECT " & vbNewLine & _
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PCNumber AS InvoiceNumber, A.PCDate AS InvoiceDate, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine & _
                    "   CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine & _
                    "FROM traPurchaseContract A " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.BPID=@BPID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.ApprovedBy<>'' " & vbNewLine & _
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine & _
                    "   AND A.ID NOT IN " & vbNewLine & _
                    "       ( " & vbNewLine & _
                    "           SELECT ARD.PurchaseID 	" & vbNewLine & _
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine & _
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine & _
                    "	        ARD.APID=ARH.ID		" & vbNewLine & _
                    "           WHERE 	" & vbNewLine & _
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine & _
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine & _
                    "	            AND ARH.BPID=@BPID " & vbNewLine & _
                    "	            AND ARH.IsDeleted=0	" & vbNewLine & _
                    "	            AND ARH.ID=@APID " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseOrderCutting B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.APID=@APID " & vbNewLine

                .CommandText += _
                    "UNION ALL " & vbNewLine & _
                    "SELECT " & vbNewLine & _
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PONumber AS InvoiceNumber, A.PODate AS InvoiceDate, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine & _
                    "   CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderCutting A " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.BPID=@BPID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.ApprovedBy<>'' " & vbNewLine & _
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine & _
                    "   AND A.ID NOT IN " & vbNewLine & _
                    "       ( " & vbNewLine & _
                    "           SELECT ARD.PurchaseID 	" & vbNewLine & _
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine & _
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine & _
                    "	        ARD.APID=ARH.ID		" & vbNewLine & _
                    "           WHERE 	" & vbNewLine & _
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine & _
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine & _
                    "	            AND ARH.BPID=@BPID " & vbNewLine & _
                    "	            AND ARH.IsDeleted=0	" & vbNewLine & _
                    "	            AND ARH.ID=@APID " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST (1 AS BIT) AS Pick, A.PurchaseID, B.PONumber AS InvoiceNumber, B.PODate AS InvoiceDate, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual AS PurchaseAmount, A.Amount, " & vbNewLine & _
                    "   B.TotalDPP+B.TotalPPN-B.TotalPPH+B.RoundingManual-B.DPAmount-B.ReceiveAmount+A.Amount AS MaxPaymentAmount, " & vbNewLine & _
                    "   A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseOrderTransport B ON " & vbNewLine & _
                    "   A.PurchaseID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.APID=@APID " & vbNewLine

                .CommandText += _
                    "UNION ALL " & vbNewLine & _
                    "SELECT " & vbNewLine & _
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PONumber AS InvoiceNumber, A.PODate AS InvoiceDate, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine & _
                    "   CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderTransport A " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.BPID=@BPID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.ApprovedBy<>'' " & vbNewLine & _
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine & _
                    "   AND A.ID NOT IN " & vbNewLine & _
                    "       ( " & vbNewLine & _
                    "           SELECT ARD.PurchaseID 	" & vbNewLine & _
                    "           FROM traAccountPayableDet ARD 	" & vbNewLine & _
                    "           INNER JOIN traAccountPayable ARH ON 	" & vbNewLine & _
                    "	        ARD.APID=ARH.ID		" & vbNewLine & _
                    "           WHERE 	" & vbNewLine & _
                    "               ARH.CompanyID=@CompanyID 	" & vbNewLine & _
                    "	            AND ARH.ProgramID=@ProgramID 	" & vbNewLine & _
                    "	            AND ARH.BPID=@BPID " & vbNewLine & _
                    "	            AND ARH.IsDeleted=0	" & vbNewLine & _
                    "	            AND ARH.ID=@APID " & vbNewLine & _
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
                .CommandText = _
                    "INSERT INTO traAccountPayableDet " & vbNewLine & _
                    "   (ID, APID, PurchaseID, Amount, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @APID, @PurchaseID, @Amount, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = clsData.APID
                .Parameters.Add("@PurchaseID", SqlDbType.VarChar, 100).Value = clsData.PurchaseID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
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
                .CommandText = _
                    "DELETE FROM traAccountPayableDet    " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   APID=@APID" & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
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
                                              ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.APID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine & _
                    "FROM traAccountPayableStatus A " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "INSERT INTO traAccountPayableStatus " & vbNewLine & _
                    "   (ID, APID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine & _
                        "FROM traAccountPayableStatus " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   APID=@APID " & vbNewLine & _
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

    End Class
End Namespace