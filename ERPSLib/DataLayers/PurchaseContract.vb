Namespace DL
    Public Class PurchaseContract

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
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.PCNumber, A.PCDate, " & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine & _
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine & _
                    "   A.DPAmount, A.ReceiveAmount, (A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual)-(A.DPAmount+A.ReceiveAmount) AS OutstandingPayment, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine & _
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine & _
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traPurchaseContract A " & vbNewLine & _
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
                    "   AND A.PCDate>=@DateFrom AND A.PCDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
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
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.PurchaseContract)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO traPurchaseContract " & vbNewLine & _
                        "   (ID, ProgramID, CompanyID, PCNumber, PCDate, BPID, DeliveryPeriodFrom, DeliveryPeriodTo, AllowanceProduction, " & vbNewLine & _
                        "    Franco, PPN, PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, Remarks, " & vbNewLine & _
                        "    StatusID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "   (@ID, @ProgramID, @CompanyID, @PCNumber, @PCDate, @BPID, @DeliveryPeriodFrom, @DeliveryPeriodTo, @AllowanceProduction, " & vbNewLine & _
                        "    @Franco, @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, @Remarks, " & vbNewLine & _
                        "    @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine
                Else
                    .CommandText = _
                    "UPDATE traPurchaseContract SET " & vbNewLine & _
                    "    ProgramID=@ProgramID, " & vbNewLine & _
                    "    CompanyID=@CompanyID, " & vbNewLine & _
                    "    PCNumber=@PCNumber, " & vbNewLine & _
                    "    PCDate=@PCDate, " & vbNewLine & _
                    "    BPID=@BPID, " & vbNewLine & _
                    "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine & _
                    "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine & _
                    "    AllowanceProduction=@AllowanceProduction, " & vbNewLine & _
                    "    Franco=@Franco, " & vbNewLine & _
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
                    "    LogInc=LogInc+1, " & vbNewLine & _
                    "    LogBy=@LogBy, " & vbNewLine & _
                    "    LogDate=GETDATE() " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
                    "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@PCNumber", SqlDbType.VarChar, 100).Value = clsData.PCNumber
                .Parameters.Add("@PCDate", SqlDbType.DateTime).Value = clsData.PCDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@DeliveryPeriodFrom", SqlDbType.DateTime).Value = clsData.DeliveryPeriodFrom
                .Parameters.Add("@DeliveryPeriodTo", SqlDbType.DateTime).Value = clsData.DeliveryPeriodTo
                .Parameters.Add("@AllowanceProduction", SqlDbType.Decimal).Value = clsData.AllowanceProduction
                .Parameters.Add("@Franco", SqlDbType.VarChar, 250).Value = clsData.Franco
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
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.PurchaseContract
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.PurchaseContract
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.ProgramID, A.CompanyID, A.PCNumber, A.PCDate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine & _
                        "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.JournalID, A.StatusID, A.SubmitBy, A.SubmitDate, A.ApproveL1, " & vbNewLine & _
                        "   A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.ReceiveAmount " & vbNewLine & _
                        "FROM traPurchaseContract A " & vbNewLine & _
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine & _
                        "   A.BPID=B.ID " & vbNewLine & _
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
                        voReturn.PCNumber = .Item("PCNumber")
                        voReturn.PCDate = .Item("PCDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.DeliveryPeriodFrom = .Item("DeliveryPeriodFrom")
                        voReturn.DeliveryPeriodTo = .Item("DeliveryPeriodTo")
                        voReturn.AllowanceProduction = .Item("AllowanceProduction")
                        voReturn.Franco = .Item("Franco")
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
                    "UPDATE traPurchaseContract SET " & vbNewLine & _
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
                        "FROM traPurchaseContract " & vbNewLine & _
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
                                          ByVal strPCNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traPurchaseContract " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   PCNumber=@PCNumber " & vbNewLine & _
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@PCNumber", SqlDbType.VarChar, 100).Value = strPCNumber
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
                        "FROM traPurchaseContract " & vbNewLine & _
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
                        "FROM traPurchaseContract " & vbNewLine & _
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
                    "UPDATE traPurchaseContract SET " & vbNewLine & _
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
                    "UPDATE traPurchaseContract SET " & vbNewLine & _
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
                    "UPDATE traPurchaseContract SET " & vbNewLine & _
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
                    "UPDATE traPurchaseContract SET " & vbNewLine & _
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
                    "UPDATE traPurchaseContract SET 	" & vbNewLine & _
                    "	DPAmount=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(APD.Amount),0) TotalPayment		" & vbNewLine & _
                    "		FROM traAccountPayableDet APD 	" & vbNewLine & _
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine & _
                    "			APD.APID=APH.ID 	" & vbNewLine & _
                    "			AND APH.Modules=@Modules " & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			APD.PurchaseID=@ID 	" & vbNewLine & _
                    "			AND APH.IsDeleted=0 	" & vbNewLine & _
                    "	) " & vbNewLine & _
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.DownPayment
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
                    "UPDATE traPurchaseContract SET 	" & vbNewLine & _
                    "	ReceiveAmount=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(APD.Amount),0) TotalPayment		" & vbNewLine & _
                    "		FROM traAccountPayableDet APD 	" & vbNewLine & _
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine & _
                    "			APD.APID=APH.ID 	" & vbNewLine & _
                    "			AND APH.Modules=@Modules " & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			APD.PurchaseID=@ID 	" & vbNewLine & _
                    "			AND APH.IsDeleted=0 	" & vbNewLine & _
                    "	) " & vbNewLine & _
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePayment
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
                    "UPDATE traPurchaseContract SET " & vbNewLine & _
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
                        "FROM traPurchaseContract " & vbNewLine & _
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

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strPCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.PCID, A.CODetailID, A2.CONumber, A1.OrderNumberSupplier, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine & _
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.PCWeight AS MaxTotalWeight, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseContractDet A " & vbNewLine & _
                    "INNER JOIN traConfirmationOrderDet A1 ON " & vbNewLine & _
                    "   A.CODetailID=A1.ID " & vbNewLine & _
                    "INNER JOIN traConfirmationOrder A2 ON " & vbNewLine & _
                    "   A1.COID=A2.ID " & vbNewLine & _
                    "INNER JOIN mstItem B ON " & vbNewLine & _
                    "   A.ItemID=B.ID " & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine & _
                    "   B.ItemSpecificationID=C.ID " & vbNewLine & _
                    "INNER JOIN mstItemType D ON " & vbNewLine & _
                    "   B.ItemTypeID=D.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.PCID=@PCID " & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingReceive(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = <a>
SELECT  
    PCD.ID, PCD.PCID, PCH.PCNumber, PCD.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  
    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  
    PCD.Quantity-PCD.DCQuantity AS Quantity, PCD.Weight, PCD.TotalWeight-PCD.DCWeight AS TotalWeight, PCD.UnitPrice, PCD.TotalPrice 
FROM traPurchaseContractDet PCD  
INNER JOIN traPurchaseContract PCH ON  
    PCD.PCID=PCH.ID  
INNER JOIN mstItem B ON  
    PCD.ItemID=B.ID  
INNER JOIN mstItemSpecification C ON  
    B.ItemSpecificationID=C.ID  
INNER JOIN mstItemType D ON  
    B.ItemTypeID=D.ID  
WHERE  
    PCH.IsDeleted=0 
	AND PCH.ProgramID=@ProgramID 
	AND PCH.CompanyID=@CompanyID 
    AND PCH.StatusID=@StatusID  
	AND PCH.BPID=@BPID 
    AND PCD.TotalWeight-PCD.DCWeight>0
    AND PCD.Quantity-PCD.DCQuantity>0
</a>.Value

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingCutting(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = <a>
SELECT  
    PCD.ID, PCD.PCID, PCH.PCNumber, PCD.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  
    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  
    PCD.Quantity-PCD.CuttingQuantity AS Quantity, PCD.Weight, PCD.TotalWeight-PCD.CuttingWeight AS TotalWeight, PCD.UnitPrice, PCD.TotalPrice 
FROM traPurchaseContractDet PCD  
INNER JOIN traPurchaseContract PCH ON  
    PCD.PCID=PCH.ID  
INNER JOIN mstItem B ON  
    PCD.ItemID=B.ID  
INNER JOIN mstItemSpecification C ON  
    B.ItemSpecificationID=C.ID  
INNER JOIN mstItemType D ON  
    B.ItemTypeID=D.ID  
WHERE  
    PCH.IsDeleted=0 
	AND PCH.ProgramID=@ProgramID 
	AND PCH.CompanyID=@CompanyID 
    AND PCH.StatusID=@StatusID  
    AND PCD.TotalWeight-PCD.CuttingWeight>0
    AND PCD.Quantity-PCD.CuttingQuantity>0
</a>.Value

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.PurchaseContractDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traPurchaseContractDet " & vbNewLine & _
                    "   (ID, PCID, CODetailID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @PCID, @CODetailID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = clsData.PCID
                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = clsData.CODetailID
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

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strPCID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traPurchaseContractDet     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   PCID=@PCID" & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDCTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strPCDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine & _
                    "	DCWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(RVD.TotalWeight),0) TotalWeight		" & vbNewLine & _
                    "		FROM traReceiveDet RVD 	" & vbNewLine & _
                    "		INNER JOIN traReceive RVH ON	" & vbNewLine & _
                    "			RVD.ReceiveID=RVH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			RVD.PCDetailID=@PCDetailID 	" & vbNewLine & _
                    "			AND RVH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	DCQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(RVD.Quantity),0) TotalQuantity " & vbNewLine & _
                    "		FROM traReceiveDet RVD 	" & vbNewLine & _
                    "		INNER JOIN traReceive RVH ON	" & vbNewLine & _
                    "			RVD.ReceiveID=RVH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			RVD.PCDetailID=@PCDetailID 	" & vbNewLine & _
                    "			AND RVH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
                    "WHERE ID=@PCDetailID	" & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateCuttingTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strPCDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine & _
                    "	CuttingWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(POD.TotalWeight),0) TotalWeight " & vbNewLine & _
                    "		FROM traPurchaseOrderCuttingDet POD 	" & vbNewLine & _
                    "		INNER JOIN traPurchaseOrderCutting POH ON	" & vbNewLine & _
                    "			POD.POID=POH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			POD.PCDetailID=@PCDetailID 	" & vbNewLine & _
                    "			AND POH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	CuttingQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(POD.Quantity),0) TotalQuantity " & vbNewLine & _
                    "		FROM traPurchaseOrderCuttingDet POD 	" & vbNewLine & _
                    "		INNER JOIN traPurchaseOrderCutting POH ON	" & vbNewLine & _
                    "			POD.POID=POH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			POD.PCDetailID=@PCDetailID 	" & vbNewLine & _
                    "			AND POH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
                    "WHERE ID=@PCDetailID	" & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
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
                                                   ByVal strPCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.PCID, A.Percentage, A.PaymentTypeID, B.Code AS PaymentTypeCode, B.Name AS PaymentTypeName, " & vbNewLine & _
                    "   A.PaymentModeID, C.Code AS PaymentModeCode, C.Name AS PaymentModeName, A.CreditTerm, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseContractPaymentTerm A " & vbNewLine & _
                    "INNER JOIN mstPaymentType B ON " & vbNewLine & _
                    "   A.PaymentTypeID=B.ID " & vbNewLine & _
                    "INNER JOIN mstPaymentMode C ON " & vbNewLine & _
                    "   A.PaymentModeID=C.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.PCID=@PCID " & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal clsData As VO.PurchaseContractPaymentTerm)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traPurchaseContractPaymentTerm " & vbNewLine & _
                    "   (ID, PCID, Percentage, PaymentTypeID, PaymentModeID, CreditTerm, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @PCID, @Percentage, @PaymentTypeID, @PaymentModeID, @CreditTerm, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = clsData.PCID
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
                                                   ByVal strPCID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traPurchaseContractPaymentTerm     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   PCID=@PCID" & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
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
                                              ByVal strPCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.PCID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseContractStatus A " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.PCID=@PCID " & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.PurchaseContractStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traPurchaseContractStatus " & vbNewLine & _
                    "   (ID, PCID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @PCID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = clsData.PCID
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
                                              ByVal strPCID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine & _
                        "FROM traPurchaseContractStatus " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   PCID=@PCID " & vbNewLine & _
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
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