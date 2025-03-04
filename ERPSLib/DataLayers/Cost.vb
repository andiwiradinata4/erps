Namespace DL
    Public Class Cost

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer, _
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intStatusID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.CostNumber, A.COAID, " & vbNewLine & _
                    "   ISNULL(C.Code,'') AS COACode, ISNULL(C.Name,'') AS COAName, A.ReferencesID, A.ReferencesNote, A.CostDate, A.TotalAmount, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine & _
                    "   A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine & _
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.PaymentBy, " & vbNewLine & _
                    "   CASE WHEN A.PaymentBy = '' THEN NULL ELSE A.PaymentDate END AS PaymentDate, A.TaxInvoiceNumber, " & vbNewLine & _
                    "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine & _
                    "   A.LogInc, A.LogBy, A.LogDate, A.TotalDPP, A.TotalPPN, A.TotalPPH " & vbNewLine & _
                    "FROM traCost A " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "LEFT JOIN mstChartOfAccount C ON " & vbNewLine & _
                    "   A.COAID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.CostDate>=@DateFrom AND A.CostDate<=@DateTo " & vbNewLine

                If intStatusID <> VO.Status.Values.All Then
                    .CommandText += "    AND A.StatusID=@StatusID" & vbNewLine
                End If

                .CommandText += "ORDER BY A.CostDate, A.ID ASC " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom.Date
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.Cost)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO traCost " & vbNewLine & _
                        "   (ID, CompanyID, ProgramID, CostNumber, COAID, ReferencesID, ReferencesNote, " & vbNewLine & _
                        "    CostDate, TotalAmount, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, PaidTo, PaidAccount, " & vbNewLine & _
                        "    TotalDPP, TotalPPN, TotalPPH) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "   (@ID, @CompanyID, @ProgramID, @CostNumber, @COAID, @ReferencesID, @ReferencesNote, " & vbNewLine & _
                        "    @CostDate, @TotalAmount, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), @PaidTo, @PaidAccount, " & vbNewLine & _
                        "    @TotalDPP, @TotalPPN, @TotalPPH) " & vbNewLine
                Else
                    .CommandText = _
                        "UPDATE traCost SET " & vbNewLine & _
                        "    CompanyID=@CompanyID, " & vbNewLine & _
                        "    ProgramID=@ProgramID, " & vbNewLine & _
                        "    CostNumber=@CostNumber, " & vbNewLine & _
                        "    COAID=@COAID, " & vbNewLine & _
                        "    ReferencesID=@ReferencesID, " & vbNewLine & _
                        "    ReferencesNote=@ReferencesNote, " & vbNewLine & _
                        "    CostDate=@CostDate, " & vbNewLine & _
                        "    TotalAmount=@TotalAmount, " & vbNewLine & _
                        "    Remarks=@Remarks, " & vbNewLine & _
                        "    StatusID=@StatusID, " & vbNewLine & _
                        "    LogInc=LogInc+1, " & vbNewLine & _
                        "    LogBy=@LogBy, " & vbNewLine & _
                        "    LogDate=GETDATE(), " & vbNewLine & _
                        "    PaidTo=@PaidTo, " & vbNewLine & _
                        "    PaidAccount=@PaidAccount, " & vbNewLine & _
                        "    TotalDPP=@TotalDPP, " & vbNewLine & _
                        "    TotalPPN=@TotalPPN, " & vbNewLine & _
                        "    TotalPPH=@TotalPPH " & vbNewLine & _
                        "WHERE   " & vbNewLine & _
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CostNumber", SqlDbType.VarChar, 100).Value = clsData.CostNumber
                .Parameters.Add("@COAID", SqlDbType.Int).Value = clsData.COAID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 250).Value = clsData.ReferencesID
                .Parameters.Add("@ReferencesNote", SqlDbType.VarChar, 250).Value = clsData.ReferencesNote
                .Parameters.Add("@CostDate", SqlDbType.DateTime).Value = clsData.CostDate
                .Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = clsData.TotalAmount
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@PaidTo", SqlDbType.VarChar, 250).Value = clsData.PaidTo
                .Parameters.Add("@PaidAccount", SqlDbType.VarChar, 250).Value = clsData.PaidAccount
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.Cost
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.Cost
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, A.CostNumber, A.COAID, " & vbNewLine & _
                        "   ISNULL(C.Code,'') AS COACode, ISNULL(C.Name,'') AS COAName, A.ReferencesID, A.ReferencesNote, A.CostDate, A.TotalAmount, A.JournalID, A.StatusID, B.Name AS StatusInfo, " & vbNewLine & _
                        "   A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.PaymentBy, A.PaymentDate, A.TaxInvoiceNumber, " & vbNewLine & _
                        "   A.IsClosedPeriod, A.ClosedPeriodBy, A.ClosedPeriodDate, A.IsDeleted, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine & _
                        "   A.LogInc, A.LogBy, A.LogDate, A.PaidTo, A.PaidAccount, A.TotalDPP, A.TotalPPN, A.TotalPPH " & vbNewLine & _
                        "FROM traCost A " & vbNewLine & _
                        "INNER JOIN mstStatus B ON " & vbNewLine & _
                        "   A.StatusID=B.ID " & vbNewLine & _
                        "LEFT JOIN mstChartOfAccount C ON " & vbNewLine & _
                        "   A.COAID=C.ID " & vbNewLine & _
                        "INNER JOIN mstCompany MC ON " & vbNewLine & _
                        "   A.CompanyID=MC.ID " & vbNewLine & _
                        "INNER JOIN mstProgram MP ON " & vbNewLine & _
                        "   A.ProgramID=MP.ID " & vbNewLine & _
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
                        voReturn.CostNumber = .Item("CostNumber")
                        voReturn.COAID = .Item("COAID")
                        voReturn.CoACode = .Item("COACode")
                        voReturn.CoAName = .Item("COAName")
                        voReturn.ReferencesID = .Item("ReferencesID")
                        voReturn.ReferencesNote = .Item("ReferencesNote")
                        voReturn.CostDate = .Item("CostDate")
                        voReturn.TotalAmount = .Item("TotalAmount")
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
                        voReturn.PaidTo = .Item("PaidTo")
                        voReturn.PaidAccount = .Item("PaidAccount")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
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
                    "UPDATE traCost SET " & vbNewLine & _
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
                        "FROM traCost " & vbNewLine & _
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

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strCostNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traCost " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   CostNumber=@CostNumber " & vbNewLine & _
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@CostNumber", SqlDbType.VarChar, 100).Value = strCostNumber
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
                        "FROM traCost " & vbNewLine & _
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
                        "FROM traCost " & vbNewLine & _
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
                    "UPDATE traCost SET " & vbNewLine & _
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
                    "UPDATE traCost SET " & vbNewLine & _
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
                                  ByVal strID As String, ByVal intCoAID As Integer, ByVal dtmPaymentDate As DateTime)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traCost SET " & vbNewLine & _
                    "    CoAID=@CoAID, " & vbNewLine & _
                    "    PaymentDate=@PaymentDate, " & vbNewLine & _
                    "    PaymentBy=@LogBy, " & vbNewLine & _
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
                .Parameters.Add("@CoAID", SqlDbType.Int).Value = intCoAID
                .Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = dtmPaymentDate

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
                    "UPDATE traCost SET " & vbNewLine & _
                    "    StatusID=@StatusID, " & vbNewLine & _
                    "    ApproveL1='', " & vbNewLine & _
                    "    ApprovedBy='', " & vbNewLine & _
                    "    PaymentBy='' " & vbNewLine & _
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
                    "UPDATE traCost SET " & vbNewLine & _
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
                    "UPDATE traCost SET " & vbNewLine & _
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
                    "UPDATE traCost SET " & vbNewLine & _
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
                    "UPDATE traCost SET " & vbNewLine & _
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

        Public Shared Function PrintCostBankOut(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
"SELECT    " & vbNewLine & _
"	CH.CostNumber AS TransNumber, CH.CostDate AS TransDate, MC.Name AS CompanyName, '' AS VoucherCode,    " & vbNewLine & _
"	CH.PaidTo, CH.PaidAccount, CH.TotalAmount, CASE WHEN COD.Remarks='' THEN CH.Remarks ELSE COD.Remarks END AS Remarks, MUC.Name AS CreatedBy, CH.CreatedDate, NULL AS CheckedDate,    " & vbNewLine & _
"	'' AS CheckedBy, MUP.Name AS PaidBy, CASE WHEN CH.PaymentBy='' THEN NULL ELSE CH.PaymentDate END AS PaidDate,   " & vbNewLine & _
"	MC.DirectorName AS ApprovedBy, NULL AS ApprovedDate, 'KETERANGAN' AS Description, ':' AS DescriptionSeparator   " & vbNewLine & _
"FROM traCost CH    " & vbNewLine & _
"INNER JOIN  " & vbNewLine & _
"( " & vbNewLine & _
"	SELECT DISTINCT COD.CostID, COD.Remarks  " & vbNewLine & _
"	FROM traCostDet COD " & vbNewLine & _
"	WHERE COD.CostID=@ID  " & vbNewLine & _
") COD ON  " & vbNewLine & _
"	CH.ID=COD.CostID  " & vbNewLine & _
"INNER JOIN mstCompany MC ON    " & vbNewLine & _
"	CH.CompanyID=MC.ID    " & vbNewLine & _
"INNER JOIN mstUser MUC ON    " & vbNewLine & _
"	CH.CreatedBy=MUC.ID    " & vbNewLine & _
"LEFT JOIN mstUser MUP ON    " & vbNewLine & _
"	CH.PaymentBy=MUP.ID    " & vbNewLine & _
"WHERE CH.ID=@ID    " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function PrintCostBankOutAttachment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"-- Others Expenses " & vbNewLine &
"SELECT  " & vbNewLine &
"	COD.ReceiveDate, COD.InvoiceDate, COD.InvoiceNumberBP, CAST(1 AS DECIMAL(18,4)) AS Quantity,  " & vbNewLine &
"	SUM(COD.Amount) AS Amount, SUM(COD.PPNAmount) AS PPNAmount, SUM(COD.PPHAmount) AS PPHAmount,  " & vbNewLine &
"	SUM(COD.Amount+COD.PPNAmount-COD.PPHAmount) AS GrandTotal " & vbNewLine &
"FROM traCostDet COD  " & vbNewLine &
"WHERE COD.CostID=@ParentID " & vbNewLine &
"GROUP BY COD.ReceiveDate, COD.InvoiceDate, COD.InvoiceNumberBP  " & vbNewLine &
" " & vbNewLine &
"-- Cutting " & vbNewLine &
"UNION ALL  " & vbNewLine &
"SELECT  " & vbNewLine &
"	COD.ReceiveDateInvoice AS ReceiveDate, COD.InvoiceDateBP AS InvoiceDate, COD.InvoiceNumberBP, CAST(1 AS DECIMAL(18,4)) AS Quantity,  " & vbNewLine &
"	SUM(COD.Amount) AS Amount, SUM(COD.PPN) AS PPNAmount, SUM(COD.PPH) AS PPHAmount,  " & vbNewLine &
"	SUM(COD.Amount+COD.PPN-COD.PPH) AS GrandTotal " & vbNewLine &
"FROM traARAPItem COD  " & vbNewLine &
"WHERE COD.ParentID=@ParentID " & vbNewLine &
"GROUP BY COD.ReceiveDateInvoice, COD.InvoiceDateBP, COD.InvoiceNumberBP  " & vbNewLine &
" " & vbNewLine &
"-- Delivery " & vbNewLine &
"UNION ALL  " & vbNewLine &
"SELECT  " & vbNewLine &
"	COD.ReceiveDate, COD.InvoiceDate, COD.InvoiceNumberBP, CAST(1 AS DECIMAL(18,4)) AS Quantity,  " & vbNewLine &
"	SUM(COD.Amount) AS Amount, SUM(COD.PPN) AS PPNAmount, SUM(COD.PPH) AS PPHAmount,  " & vbNewLine &
"	SUM(COD.Amount+COD.PPN-COD.PPH) AS GrandTotal " & vbNewLine &
"FROM traAccountPayableDet COD  " & vbNewLine &
"WHERE COD.APID=@ParentID " & vbNewLine &
"GROUP BY COD.ReceiveDate, COD.InvoiceDate, COD.InvoiceNumberBP  " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strCostID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.CostID, A.COAID, B.Code AS COACode, B.Name AS COAName, A.Amount, A.Remarks, " & vbNewLine & _
                    "   A.InvoiceNumberBP, A.ReceiveDate, A.InvoiceDate, A.PPNAmount, A.PPHAmount, A.Amount+A.PPNAmount-A.PPHAmount AS GrandTotal " & vbNewLine & _
                    "FROM traCostDet A " & vbNewLine & _
                    "INNER JOIN mstChartOfAccount B ON " & vbNewLine & _
                    "   A.COAID=B.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.CostID=@CostID " & vbNewLine

                .Parameters.Add("@CostID", SqlDbType.VarChar, 100).Value = strCostID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.CostDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traCostDet " & vbNewLine & _
                    "   (ID, CostID, COAID, Amount, Remarks, InvoiceNumberBP, ReceiveDate, InvoiceDate, PPNAmount, PPHAmount) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @CostID, @COAID, @Amount, @Remarks, @InvoiceNumberBP, @ReceiveDate, @InvoiceDate, @PPNAmount, @PPHAmount) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CostID", SqlDbType.VarChar, 100).Value = clsData.CostID
                .Parameters.Add("@COAID", SqlDbType.Int).Value = clsData.CoAID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@InvoiceNumberBP", SqlDbType.VarChar, 1000).Value = clsData.InvoiceNumberBP
                .Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = clsData.ReceiveDate
                .Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = clsData.InvoiceDate
                .Parameters.Add("@PPNAmount", SqlDbType.Decimal).Value = clsData.PPNAmount
                .Parameters.Add("@PPHAmount", SqlDbType.Decimal).Value = clsData.PPHAmount
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strCostID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traCostDet    " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   CostID=@CostID" & vbNewLine

                .Parameters.Add("@CostID", SqlDbType.VarChar, 100).Value = strCostID
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
                                              ByVal strCostID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.CostID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine & _
                    "FROM traCostStatus A " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.CostID=@CostID " & vbNewLine

                .Parameters.Add("@CostID", SqlDbType.VarChar, 100).Value = strCostID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.CostStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traCostStatus " & vbNewLine & _
                    "   (ID, CostID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @CostID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CostID", SqlDbType.VarChar, 100).Value = clsData.CostID
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
                                              ByVal strCostID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine & _
                        "FROM traCostStatus " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   CostID=@CostID " & vbNewLine & _
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@CostID", SqlDbType.VarChar, 100).Value = strCostID
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