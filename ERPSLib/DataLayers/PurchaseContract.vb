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
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.PCNumber, A.PCDate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine &
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.DPAmount, A.ReceiveAmount, (A.TotalDPP+A.RoundingManual)-(A.DPAmount+A.ReceiveAmount) AS OutstandingPayment, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine &
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.IsAutoGenerate, " & vbNewLine &
                    "   A.IsUseSubItem, A.PaymentTypeID, ISNULL(MPT.Name, '') AS PaymentTypeName " & vbNewLine &
                    "FROM traPurchaseContract A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "LEFT JOIN mstPaymentType MPT ON " & vbNewLine &
                    "   A.PaymentTypeID=MPT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
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

        Public Shared Function ListDataOutstandingPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                          ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PCNumber AS InvoiceNumber, A.PCDate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH " & vbNewLine &
                    "FROM traPurchaseContract A " & vbNewLine &
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

        Public Shared Function ListDataOutstandingReceive(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                          ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.PCNumber, A.PCDate, A.BPID, MBP.Code AS BPCode, MBP.Name AS BPName, A.IsUseSubItem " & vbNewLine &
                    "FROM traPurchaseContract A " & vbNewLine &
                    "INNER JOIN traPurchaseContractDet PCD ON " & vbNewLine &
                    "   A.ID=PCD.PCID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner MBP ON " & vbNewLine &
                    "   A.BPID=MBP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND PCD.TotalWeight-PCD.DCWeight>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataFranco(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.Franco " & vbNewLine &
                    "FROM traPurchaseContract A " & vbNewLine

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
                    .CommandText =
                        "INSERT INTO traPurchaseContract " & vbNewLine &
                        "   (ID, ProgramID, CompanyID, PCNumber, PCDate, BPID, DeliveryPeriodFrom, DeliveryPeriodTo, AllowanceProduction, " & vbNewLine &
                        "    Franco, PPN, PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, Remarks, " & vbNewLine &
                        "    StatusID, CreatedBy, CreatedDate, LogBy, LogDate, IsAutoGenerate, IsUseSubItem, PaymentTypeID) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @PCNumber, @PCDate, @BPID, @DeliveryPeriodFrom, @DeliveryPeriodTo, @AllowanceProduction, " & vbNewLine &
                        "    @Franco, @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, @Remarks, " & vbNewLine &
                        "    @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), @IsAutoGenerate, @IsUseSubItem, @PaymentTypeID) " & vbNewLine
                Else
                    .CommandText =
                    "UPDATE traPurchaseContract SET " & vbNewLine &
                    "    ProgramID=@ProgramID, " & vbNewLine &
                    "    CompanyID=@CompanyID, " & vbNewLine &
                    "    PCNumber=@PCNumber, " & vbNewLine &
                    "    PCDate=@PCDate, " & vbNewLine &
                    "    BPID=@BPID, " & vbNewLine &
                    "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine &
                    "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine &
                    "    AllowanceProduction=@AllowanceProduction, " & vbNewLine &
                    "    Franco=@Franco, " & vbNewLine &
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
                    "    LogInc=LogInc+1, " & vbNewLine &
                    "    LogBy=@LogBy, " & vbNewLine &
                    "    LogDate=GETDATE(), " & vbNewLine &
                    "    IsUseSubItem=@IsUseSubItem, " & vbNewLine &
                    "    PaymentTypeID=@PaymentTypeID " & vbNewLine &
                    "WHERE   " & vbNewLine &
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
                .Parameters.Add("@IsAutogenerate", SqlDbType.Bit).Value = clsData.IsAutoGenerate
                .Parameters.Add("@IsUseSubItem", SqlDbType.Bit).Value = clsData.IsUseSubItem
                .Parameters.Add("@PaymentTypeID", SqlDbType.Int).Value = clsData.PaymentTypeID
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
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ProgramID, A.CompanyID, A.PCNumber, A.PCDate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.Franco, " & vbNewLine &
                        "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.JournalID, A.StatusID, A.SubmitBy, A.SubmitDate, A.ApproveL1, " & vbNewLine &
                        "   A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.ReceiveAmount, GrandTotal=A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual, A.IsAutoGenerate, A.IsUseSubItem, A.PaymentTypeID  " & vbNewLine &
                        "FROM traPurchaseContract A " & vbNewLine &
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine &
                        "   A.BPID=B.ID " & vbNewLine &
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
                        voReturn.GrandTotal = .Item("GrandTotal")
                        voReturn.IsAutoGenerate = .Item("IsAutoGenerate")
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
                        voReturn.PaymentTypeID = .Item("PaymentTypeID")
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
                    "UPDATE traPurchaseContract SET " & vbNewLine &
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

        Public Shared Sub DeleteDataPure(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traPurchaseContract " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
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
                        "FROM traPurchaseContract " & vbNewLine &
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

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strPCNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traPurchaseContract " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   PCNumber=@PCNumber " & vbNewLine &
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
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   StatusID " & vbNewLine &
                        "FROM traPurchaseContract " & vbNewLine &
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
                        "FROM traPurchaseContract " & vbNewLine &
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
                    "UPDATE traPurchaseContract SET " & vbNewLine &
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
                    "UPDATE traPurchaseContract SET " & vbNewLine &
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
                    "UPDATE traPurchaseContract SET " & vbNewLine &
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
                    "UPDATE traPurchaseContract SET " & vbNewLine &
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
                    "UPDATE traPurchaseContract SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.Amount),0) TotalPayment		" & vbNewLine &
                    "		FROM traAccountPayableDet APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.APID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.PurchaseID=@ID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedDownPaymentVer1(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContract SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.DPAmount),0) TotalDPAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet PCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.PCID=@ID " & vbNewLine &
                    "			AND PCD.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.DPAmountPPN),0) TotalDPAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet PCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.PCID=@ID " & vbNewLine &
                    "			AND PCD.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.DPAmountPPH),0) TotalDPAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet PCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.PCID=@ID " & vbNewLine &
                    "			AND PCD.ParentID='' " & vbNewLine &
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
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.Amount),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.ParentID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND APD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.PPN),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.ParentID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND APD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.PPH),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.ParentID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND APD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.DownPayment
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
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmount),0) TotalDPAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmountPPN),0) TotalDPAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmountPPH),0) TotalDPAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
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

        Public Shared Sub CalculateItemTotalUsedReceivePaymentParent(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                     ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	AllocateDPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.AllocateDPAmount),0) AllocateDPAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.InvoiceQuantity),0) InvoiceQuantity " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceTotalWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.InvoiceTotalWeight),0) InvoiceTotalWeight " & vbNewLine &
                    "		FROM traPurchaseContractDet APD 	" & vbNewLine &
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
                    "UPDATE traPurchaseContract SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVH.TotalPayment),0) ReceiveAmount " & vbNewLine &
                    "		FROM traReceive RVH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVH.PCID=@ID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVH.TotalPaymentPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traReceive RVH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVH.PCID=@ID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVH.TotalPaymentPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traReceive RVH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVH.PCID=@ID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 	" & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedReceivePaymentVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContract SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.PCID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID=''" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traPurchaseContractDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.PCID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID=''" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traPurchaseContractDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.PCID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID=''" & vbNewLine &
                    "	) " & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                    ByVal strDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.ReceiveAmountPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.ReceiveAmountPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
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
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	AllocateDPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.DPAmount),0) DPAmount " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountPayable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.Amount-TDD.DPAmount),0) + (SELECT ISNULL(SUM(DPAmount),0) AS DP FROM traARAPItem WHERE ReferencesDetailID=@ReferencesDetailID) ReceiveAmount " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountPayable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountPayable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountPayable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountPayable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountPayable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentTT30(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                   ByVal strPCDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@PCDetailID " & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@PCDetailID " & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@PCDetailID " & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.InvoiceQuantity),0) InvoiceQuantity " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@PCDetailID " & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	InvoiceTotalWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.InvoiceTotalWeight),0) InvoiceTotalWeight " & vbNewLine &
                    "		FROM traReceiveDet RVD " & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@PCDetailID " & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@PCDetailID " & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
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
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet PCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.ParentID=@DetailID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.ReceiveAmountPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet PCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.ParentID=@DetailID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.ReceiveAmountPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traPurchaseContractDet PCD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.ParentID=@DetailID " & vbNewLine &
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

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContract SET " & vbNewLine &
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
                        "FROM traPurchaseContract " & vbNewLine &
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

        Public Shared Sub UpdatePaymentType(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strID As String, ByVal intPaymentTypeID As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContract SET " & vbNewLine &
                    "    PaymentTypeID=@PaymentTypeID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@PaymentTypeID", SqlDbType.Int).Value = intPaymentTypeID
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
                    "UPDATE traPurchaseContract SET " & vbNewLine &
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

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strPCID As String, ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.PCID, A.CODetailID, A2.CONumber, A1.OrderNumberSupplier, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.PCWeight AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.LevelItem, A.ParentID, A.RoundingWeight, A.ReceiveAmount, A.DPAmount, A.InvoiceQuantity, A.InvoiceTotalWeight, A.DCWeight, " & vbNewLine &
                    "   OutstandingDeliveryWeight=A.TotalWeight-A.DCWeight, A.CuttingWeight " & vbNewLine &
                    "FROM traPurchaseContractDet A " & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet A1 ON " & vbNewLine &
                    "   A.CODetailID=A1.ID " & vbNewLine &
                    "INNER JOIN traConfirmationOrder A2 ON " & vbNewLine &
                    "   A1.COID=A2.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.PCID=@PCID " & vbNewLine &
                    "   And A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingReceive(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                ByVal intBPID As Integer, ByVal strPCID As String,
                                                                ByVal bolIsUseSubItem As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT   " & vbNewLine &
"    PCD.ID, PCD.PCID, PCH.PCNumber, COD.OrderNumberSupplier, PCD.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,   " & vbNewLine &
"    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,   " & vbNewLine &
"    PCD.Quantity-PCD.DCQuantity AS Quantity, PCD.Weight, PCD.TotalWeight-PCD.DCWeight AS TotalWeight, PCD.UnitPrice, PCD.TotalPrice, PCD.LevelItem, PCD.ParentID, PCD.RoundingWeight  " & vbNewLine &
"FROM traPurchaseContractDet PCD   " & vbNewLine &
"INNER JOIN traPurchaseContract PCH ON   " & vbNewLine &
"    PCD.PCID=PCH.ID   " & vbNewLine &
"INNER JOIN traConfirmationOrderDet COD ON  " & vbNewLine &
"	PCD.CODetailID=COD.ID  " & vbNewLine &
"INNER JOIN mstItem B ON   " & vbNewLine &
"    PCD.ItemID=B.ID   " & vbNewLine &
"INNER JOIN mstItemSpecification C ON   " & vbNewLine &
"    B.ItemSpecificationID=C.ID   " & vbNewLine &
"INNER JOIN mstItemType D ON   " & vbNewLine &
"    B.ItemTypeID=D.ID   " & vbNewLine &
"WHERE   " & vbNewLine &
"   PCH.IsDeleted=0  " & vbNewLine &
"	And PCH.ProgramID=@ProgramID  " & vbNewLine &
"	And PCH.CompanyID=@CompanyID  " & vbNewLine &
"   And PCH.StatusID=@StatusID   " & vbNewLine &
"	And PCH.BPID=@BPID  " & vbNewLine &
"   And PCD.TotalWeight+PCD.RoundingWeight-PCD.DCWeight>0  " & vbNewLine &
"   And PCD.PCID=@PCID  " & vbNewLine

                If bolIsUseSubItem Then .CommandText += "   And PCD.ParentID<>'' " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
                .Parameters.Add("@PCID", SqlDbType.VarChar).Value = strPCID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingCutting(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine &
"    PCD.ID, PCD.PCID, PCH.PCNumber, PCD.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length,  " & vbNewLine &
"    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName,  " & vbNewLine &
"    PCD.Quantity-PCD.CuttingQuantity AS Quantity, PCD.Weight, PCD.TotalWeight-PCD.CuttingWeight AS TotalWeight, PCD.UnitPrice, " & vbNewLine &
"    PCD.TotalPrice, COD.OrderNumberSupplier, PCD.RoundingWeight" & vbNewLine &
"FROM traPurchaseContractDet PCD  " & vbNewLine &
"INNER JOIN traConfirmationOrderDet COD ON  " & vbNewLine &
"    PCD.CODetailID=COD.ID  " & vbNewLine &
"INNER JOIN traConfirmationOrder COH ON  " & vbNewLine &
"    COD.COID=COH.ID  " & vbNewLine &
"INNER JOIN traPurchaseContract PCH ON  " & vbNewLine &
"    PCD.PCID=PCH.ID  " & vbNewLine &
"INNER JOIN mstItem B ON  " & vbNewLine &
"    PCD.ItemID=B.ID  " & vbNewLine &
"INNER JOIN mstItemSpecification C ON  " & vbNewLine &
"    B.ItemSpecificationID=C.ID  " & vbNewLine &
"INNER JOIN mstItemType D ON  " & vbNewLine &
"    B.ItemTypeID=D.ID  " & vbNewLine &
"WHERE  " & vbNewLine &
"   PCH.IsDeleted=0 " & vbNewLine &
"	AND PCH.ProgramID=@ProgramID " & vbNewLine &
"	AND PCH.CompanyID=@CompanyID " & vbNewLine &
"   AND PCH.StatusID=@StatusID  " & vbNewLine &
"   AND PCD.TotalWeight+PCD.RoundingWeight-PCD.CuttingWeight>0 " & vbNewLine &
"   AND COH.DoneBy=''" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingSC(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal strCODetailID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine & _
                    "	PCD.OrderNumberSupplier, PCD.UnitPrice, PCD.CODetailID, PCD.ItemID, MI.ItemCode, MI.ItemCodeExternal, MI.ItemName,  " & vbNewLine & _
                    "	MI.ItemTypeID, IT.Description AS ItemTypeName, MI.ItemSpecificationID, MIS.Description AS ItemSpecificationName,  " & vbNewLine & _
                    "	MI.Thick, MI.Width, MI.Length, PCD.Weight, PCD.Quantity, PCD.TotalWeight, PCD.Remarks, PCH.CreatedBy, PCH.CreatedDate, PCH.LogBy, " & vbNewLine & _
                    "	PCH.LogDate, PCH.LogInc, PCD.ID AS PCDetailID, MI.ItemCodeExternal, PCD.LevelItem " & vbNewLine & _
                    "FROM traPurchaseContract PCH " & vbNewLine & _
                    "INNER JOIN traPurchaseContractDet PCD ON " & vbNewLine & _
                    "	PCH.ID=PCD.PCID " & vbNewLine & _
                    "INNER JOIN traConfirmationOrderDet COD ON " & vbNewLine & _
                    "	PCD.CODetailID=COD.ID " & vbNewLine & _
                    "INNER JOIN mstItem MI ON " & vbNewLine & _
                    "	PCD.ItemID=MI.ID " & vbNewLine & _
                    "INNER JOIN mstItemType IT ON  " & vbNewLine & _
                    "    MI.ItemTypeID=IT.ID  " & vbNewLine & _
                    "INNER JOIN mstItemSpecification MIS ON  " & vbNewLine & _
                    "    MI.ItemSpecificationID=MIS.ID  " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "	PCD.CODetailID=@CODetailID" & vbNewLine & _
                    "	AND PCD.ParentID<>'' " & vbNewLine & _
                    "	AND PCD.TotalWeight-PCD.SCWeight>0 " & vbNewLine & _
                    "	AND PCD.ID NOT IN (SELECT SCD.PCDetailID FROM traSalesContractDetConfirmationOrder SCD INNER JOIN traSalesContract SCH ON SCD.SCID=SCH.ID WHERE SCH.IsDeleted=0 AND SCD.CODetailID<>'') " & vbNewLine

                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = strCODetailID
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
                .CommandText =
                    "INSERT INTO traPurchaseContractDet " & vbNewLine &
                    "   (ID, PCID, CODetailID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, LevelItem, ParentID, RoundingWeight, OrderNumberSupplier) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @PCID, @CODetailID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @LevelItem, @ParentID, @RoundingWeight, @OrderNumberSupplier) " & vbNewLine

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
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
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
                .CommandText =
                    "DELETE FROM traPurchaseContractDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
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
                .CommandText =
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	DCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.TotalWeight+RVD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traReceiveDet RVD 	" & vbNewLine &
                    "		INNER JOIN traReceive RVH ON	" & vbNewLine &
                    "			RVD.ReceiveID=RVH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@PCDetailID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	DCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traReceiveDet RVD 	" & vbNewLine &
                    "		INNER JOIN traReceive RVH ON	" & vbNewLine &
                    "			RVD.ReceiveID=RVH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.PCDetailID=@PCDetailID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@PCDetailID	" & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
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
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	DCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.TotalWeight+RVD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traReceiveDet RVD 	" & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.ParentID=@ParentID " & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	DCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(RVD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traReceiveDet RVD 	" & vbNewLine &
                    "		INNER JOIN traReceive RVH ON " & vbNewLine &
                    "		    RVD.ReceiveID=RVH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			RVD.ParentID=@ParentID 	" & vbNewLine &
                    "			AND RVH.IsDeleted=0 " & vbNewLine &
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

        Public Shared Sub CalculateCuttingTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strPCDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	CuttingWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(POD.TotalWeight+POD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet POD 	" & vbNewLine &
                    "		INNER JOIN traPurchaseOrderCutting POH ON	" & vbNewLine &
                    "			POD.POID=POH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			POD.PCDetailID=@PCDetailID 	" & vbNewLine &
                    "			AND POH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	CuttingQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(POD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet POD 	" & vbNewLine &
                    "		INNER JOIN traPurchaseOrderCutting POH ON	" & vbNewLine &
                    "			POD.POID=POH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			POD.PCDetailID=@PCDetailID 	" & vbNewLine &
                    "			AND POH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@PCDetailID	" & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateSCTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strCODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"UPDATE traPurchaseContractDet SET 	  " & vbNewLine &
"    SCWeight=	  " & vbNewLine &
"    (	  " & vbNewLine &
"       SELECT	  " & vbNewLine &
"           ISNULL(SUM(SCCO.TotalWeight+SCCO.RoundingWeight),0) TotalWeight  " & vbNewLine &
"       FROM traSalesContractDetConfirmationOrder SCCO " & vbNewLine &
"       INNER JOIN traSalesContract SCH ON  " & vbNewLine &
"       	SCCO.SCID=SCH.ID  " & vbNewLine &
"       	AND SCH.IsDeleted=0  " & vbNewLine &
"        WHERE 	  " & vbNewLine &
"           SCCO.CODetailID=@CODetailID " & vbNewLine &
"    ), 	  " & vbNewLine &
"    SCQuantity=	  " & vbNewLine &
"    (	  " & vbNewLine &
"       SELECT	  " & vbNewLine &
"           ISNULL(SUM(SCCO.Quantity),0) TotalQuantity   " & vbNewLine &
"       FROM traSalesContractDetConfirmationOrder SCCO " & vbNewLine &
"       INNER JOIN traSalesContract SCH ON  " & vbNewLine &
"           SCCO.SCID=SCH.ID  " & vbNewLine &
"           AND SCH.IsDeleted=0  " & vbNewLine &
"       WHERE 	  " & vbNewLine &
"           SCCO.CODetailID=@CODetailID " & vbNewLine &
"    ) 	  " & vbNewLine &
"WHERE " & vbNewLine &
"   CODetailID=@CODetailID  " & vbNewLine &
"   AND ParentID='' " & vbNewLine

                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = strCODetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateSCTotalUsedSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strPCDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseContractDet SET 	" & vbNewLine &
                    "	SCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traSalesContractDetConfirmationOrder SCD 	" & vbNewLine &
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
                    "			SCD.SCID=SCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.PCDetailID=@PCDetailID 	" & vbNewLine &
                    "			And SCH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	SCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traSalesContractDetConfirmationOrder SCD 	" & vbNewLine &
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
                    "			SCD.SCID=SCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.PCDetailID=@PCDetailID 	" & vbNewLine &
                    "			And SCH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@PCDetailID	" & vbNewLine

                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = strPCDetailID
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
                        "FROM traPurchaseContractDet " & vbNewLine &
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
                    "DELETE FROM traPurchaseContractDet     " & vbNewLine &
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
                        "FROM traPurchaseContractDet " & vbNewLine &
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
                        "FROM traPurchaseContractDet " & vbNewLine &
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

        Public Shared Function IsAlreadySCSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
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
                        "FROM traPurchaseContractDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine &
                        "   AND (SCWeight>0 OR SCQuantity>0) " & vbNewLine

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

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strPCID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.PCID, A.Percentage, A.PaymentTypeID, B.Code AS PaymentTypeCode, B.Name AS PaymentTypeName, " & vbNewLine &
                    "   A.PaymentModeID, C.Code AS PaymentModeCode, C.Name AS PaymentModeName, A.CreditTerm, A.Remarks " & vbNewLine &
                    "FROM traPurchaseContractPaymentTerm A " & vbNewLine &
                    "INNER JOIN mstPaymentType B ON " & vbNewLine &
                    "   A.PaymentTypeID=B.ID " & vbNewLine &
                    "INNER JOIN mstPaymentMode C ON " & vbNewLine &
                    "   A.PaymentModeID=C.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
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
                .CommandText =
                    "INSERT INTO traPurchaseContractPaymentTerm " & vbNewLine &
                    "   (ID, PCID, Percentage, PaymentTypeID, PaymentModeID, CreditTerm, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
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
                .CommandText =
                    "DELETE FROM traPurchaseContractPaymentTerm     " & vbNewLine &
                    "WHERE " & vbNewLine &
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
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.PCID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traPurchaseContractStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
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
                .CommandText =
                    "INSERT INTO traPurchaseContractStatus " & vbNewLine &
                    "   (ID, PCID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
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

        Public Shared Sub DeleteDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strPCID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traPurchaseContractStatus     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   PCID=@PCID" & vbNewLine

                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
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
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traPurchaseContractStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   PCID=@PCID " & vbNewLine &
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