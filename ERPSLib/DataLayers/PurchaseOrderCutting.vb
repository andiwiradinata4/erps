Namespace DL
    Public Class PurchaseOrderCutting

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
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.PONumber, A.PODate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.PersonInCharge, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.DeliveryAddress, " & vbNewLine &
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.DPAmount, A.ReceiveAmount, (A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual)-(A.DPAmount+A.ReceiveAmount) AS OutstandingPayment, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine &
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, " & vbNewLine &
                    "   A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.TotalDPPRawMaterial, A.CustomerID, C1.Code AS CustomerCode, C1.Name AS CustomerName, A.IsClaimCustomer, A.PickupDate, A.RemarksResult " & vbNewLine &
                    "FROM traPurchaseOrderCutting A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C1 ON " & vbNewLine &
                    "   A.CustomerID=C1.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.PODate>=@DateFrom AND A.PODate<=@DateTo " & vbNewLine

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
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PONumber AS InvoiceNumber, A.PODate AS InvoiceDate, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine &
                    "   A.TotalDPP+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine &
                    "   CAST('' AS VARCHAR(500)) AS Remarks, A.PPN AS PPNPercent, A.PPH AS PPHPercent, CAST(0 AS DECIMAL(18,2)) AS PPN, " & vbNewLine &
                    "   CAST(0 AS DECIMAL(18,2)) AS PPH " & vbNewLine &
                    "FROM traPurchaseOrderCutting A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalDPP+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstandingCutting(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                          ByVal intBPID As Integer, ByVal intCustomerID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.PONumber, A.PODate, A.BPID, MBP.Code AS BPCode, MBP.Name AS BPName, A.CustomerID, MCustomer.Code AS CustomerCode, MCustomer.Name AS CustomerName " & vbNewLine &
                    "FROM traPurchaseOrderCutting A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCuttingDet POD ON " & vbNewLine &
                    "   A.ID=POD.POID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner MBP ON " & vbNewLine &
                    "   A.BPID=MBP.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner MCP ON " & vbNewLine &
                    "   A.CustomerID=MCP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CustomerID=@CustomerID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.ApprovedBy<>'' " & vbNewLine &
                    "   AND POD.TotalWeight-POD.DoneWeight>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@CustomerID", SqlDbType.Int).Value = intCustomerID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.PurchaseOrderCutting)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO traPurchaseOrderCutting " & vbNewLine &
                        "   (ID, ProgramID, CompanyID, PONumber, PODate, BPID, PersonInCharge, " & vbNewLine &
                        "    DeliveryPeriodFrom, DeliveryPeriodTo, DeliveryAddress, PPN, PPH, TotalQuantity, " & vbNewLine &
                        "    TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, Remarks, StatusID, CreatedBy, " & vbNewLine &
                        "    CreatedDate, LogBy, LogDate, TotalDPPRawMaterial, CustomerID, IsClaimCustomer, PickupDate, RemarksResult) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @PONumber, @PODate, @BPID, @PersonInCharge, " & vbNewLine &
                        "    @DeliveryPeriodFrom, @DeliveryPeriodTo, @DeliveryAddress, @PPN, @PPH, @TotalQuantity, " & vbNewLine &
                        "    @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, @Remarks, @StatusID, @LogBy, " & vbNewLine &
                        "    GETDATE(), @LogBy, GETDATE(), @TotalDPPRawMaterial, @CustomerID, @IsClaimCustomer, @PickupDate, @RemarksResult) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE traPurchaseOrderCutting SET " & vbNewLine &
                        "    ProgramID=@ProgramID, " & vbNewLine &
                        "    CompanyID=@CompanyID, " & vbNewLine &
                        "    PONumber=@PONumber, " & vbNewLine &
                        "    PODate=@PODate, " & vbNewLine &
                        "    BPID=@BPID, " & vbNewLine &
                        "    PersonInCharge=@PersonInCharge, " & vbNewLine &
                        "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine &
                        "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine &
                        "    DeliveryAddress=@DeliveryAddress, " & vbNewLine &
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
                        "    TotalDPPRawMaterial=@TotalDPPRawMaterial, " & vbNewLine &
                        "    CustomerID=@CustomerID, " & vbNewLine &
                        "    IsClaimCustomer=@IsClaimCustomer, " & vbNewLine &
                        "    PickupDate=@PickupDate, " & vbNewLine &
                        "    RemarksResult=@RemarksResult " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@PONumber", SqlDbType.VarChar, 100).Value = clsData.PONumber
                .Parameters.Add("@PODate", SqlDbType.DateTime).Value = clsData.PODate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@PersonInCharge", SqlDbType.VarChar, 100).Value = clsData.PersonInCharge
                .Parameters.Add("@DeliveryPeriodFrom", SqlDbType.DateTime).Value = clsData.DeliveryPeriodFrom
                .Parameters.Add("@DeliveryPeriodTo", SqlDbType.DateTime).Value = clsData.DeliveryPeriodTo
                .Parameters.Add("@DeliveryAddress", SqlDbType.VarChar, 250).Value = clsData.DeliveryAddress
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
                .Parameters.Add("@TotalDPPRawMaterial", SqlDbType.Decimal).Value = clsData.TotalDPPRawMaterial
                .Parameters.Add("@CustomerID", SqlDbType.Int).Value = clsData.CustomerID
                .Parameters.Add("@IsClaimCustomer", SqlDbType.Bit).Value = clsData.IsClaimCustomer
                .Parameters.Add("@PickupDate", SqlDbType.DateTime).Value = clsData.PickupDate
                .Parameters.Add("@RemarksResult", SqlDbType.VarChar, 1000).Value = clsData.RemarksResult
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.PurchaseOrderCutting
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.PurchaseOrderCutting
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ProgramID, A.CompanyID, A.PONumber, A.PODate, A.BPID, BP.Code AS BPCode, BP.Name AS BPName, A.PersonInCharge, " & vbNewLine &
                        "   A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.DeliveryAddress, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, " & vbNewLine &
                        "   A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.JournalID, A.StatusID, A.SubmitBy, A.SubmitDate, " & vbNewLine &
                        "   A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, " & vbNewLine &
                        "   A.ReceiveAmount, GrandTotal=A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual, A.TotalDPPRawMaterial, A.CustomerID, CP.Code AS CustomerCode, CP.Name AS CustomerName, " & vbNewLine &
                        "   A.IsClaimCustomer, A.PickupDate, A.RemarksResult " & vbNewLine &
                        "FROM traPurchaseOrderCutting A " & vbNewLine &
                        "INNER JOIN mstBusinessPartner BP ON " & vbNewLine &
                        "   A.BPID=BP.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartner CP ON " & vbNewLine &
                        "   A.CustomerID=CP.ID " & vbNewLine &
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
                        voReturn.PONumber = .Item("PONumber")
                        voReturn.PODate = .Item("PODate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.PersonInCharge = .Item("PersonInCharge")
                        voReturn.DeliveryPeriodFrom = .Item("DeliveryPeriodFrom")
                        voReturn.DeliveryPeriodTo = .Item("DeliveryPeriodTo")
                        voReturn.DeliveryAddress = .Item("DeliveryAddress")
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
                        voReturn.TotalDPPRawMaterial = .Item("TotalDPPRawMaterial")
                        voReturn.CustomerID = .Item("CustomerID")
                        voReturn.CustomerCode = .Item("CustomerCode")
                        voReturn.CustomerName = .Item("CustomerName")
                        voReturn.IsClaimCustomer = .Item("IsClaimCustomer")
                        voReturn.PickupDate = .Item("PickupDate")
                        voReturn.RemarksResult = .Item("RemarksResult")
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine &
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
                        "FROM traPurchaseOrderCutting " & vbNewLine &
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
                                          ByVal strPONumber As String, ByVal strID As String) As Boolean
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
                        "FROM traPurchaseOrderCutting " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   PONumber=@PONumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@PONumber", SqlDbType.VarChar, 100).Value = strPONumber
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
                        "FROM traPurchaseOrderCutting " & vbNewLine &
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
                        "FROM traPurchaseOrderCutting " & vbNewLine &
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

        Public Shared Function IsAlreadyDone(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   SUM(DoneQuantity) AS DoneQuantity, SUM(DoneWeight) AS DoneWeight " & vbNewLine &
                        "FROM traPurchaseOrderCuttingDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   POID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        If .Item("DoneQuantity") > 0 Or .Item("DoneWeight") > 0 Then
                            bolReturn = True
                        End If
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolReturn
        End Function

        Public Shared Function IsAlreadyDownPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
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
                        "FROM traPurchaseOrderCutting " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine &
                        "   AND DPAmount>0 " & vbNewLine

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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine &
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine &
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine &
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine &
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
                    "UPDATE traPurchaseOrderCutting SET 	" & vbNewLine &
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
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.PPN),0) TotalPayment		" & vbNewLine &
                    "		FROM traAccountPayableDet APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.APID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.PurchaseID=@ID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.PPH),0) TotalPayment		" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.DownPaymentCutting
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
                    "UPDATE traPurchaseOrderCuttingDet SET 	" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.DownPaymentCutting
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
                    "UPDATE traPurchaseOrderCutting SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentCutting
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
                    "UPDATE traPurchaseOrderCutting SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APH.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traAccountPayable APH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APH.ReferencesID=@ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APH.TotalPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traAccountPayable APH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APH.ReferencesID=@ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APH.TotalPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traAccountPayable APH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APH.ReferencesID=@ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentCutting
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
                    "UPDATE traPurchaseOrderCutting SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.POID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID=''" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.POID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID=''" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.POID=@ID 	" & vbNewLine &
                    "			AND TDH.ParentID=''" & vbNewLine &
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
                    "UPDATE traPurchaseOrderCuttingDet SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traCuttingDet APD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.PODetailID=@ReferencesDetailID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmountPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traCuttingDet APD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.PODetailID=@ReferencesDetailID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmountPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traCuttingDet APD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.PODetailID=@ReferencesDetailID 	" & vbNewLine &
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
                    "UPDATE traPurchaseOrderCuttingDet SET 	" & vbNewLine &
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
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentCutting
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
                    "UPDATE traPurchaseOrderCuttingDet SET 	" & vbNewLine &
                    "	AllocateDPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.AllocateDPAmount),0) AllocateDPAmount " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet APD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ParentID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traPurchaseOrderCuttingDet APD 	" & vbNewLine &
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

        Public Shared Function Print(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine &
"	LocationAndDate=CAST('' AS VARCHAR(100)), MC.City, POH.PODate,  POH.PickupDate, " & vbNewLine &
"	BP.Name AS BPName, 	POH.PONumber, MI.ItemCodeExternal, MI.Thick, MI.Width,  " & vbNewLine &
"	CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS Length,  " & vbNewLine &
"	POD.TotalWeight, POH.RemarksResult, POH.Remarks, CP.Name AS CustomerName, POH.IsClaimCustomer, POH.StatusID, " & vbNewLine &
"   CompanyName=MC.Name, CompanyAddress=MC.Address " & vbNewLine &
"FROM traPurchaseOrderCutting POH  " & vbNewLine &
"INNER JOIN traPurchaseOrderCuttingDet POD ON  " & vbNewLine &
"	POH.ID=POD.POID  " & vbNewLine &
"INNER JOIN mstCompany MC ON  " & vbNewLine &
"	POH.CompanyID=MC.ID  " & vbNewLine &
"INNER JOIN mstBusinessPartner BP ON  " & vbNewLine &
"	POH.BPID=BP.ID  " & vbNewLine &
"INNER JOIN mstItem MI ON  " & vbNewLine &
"	POD.ItemID=MI.ID  " & vbNewLine &
"INNER JOIN mstItemType IT ON  " & vbNewLine &
"	MI.ItemTypeID=IT.ID  " & vbNewLine &
"INNER JOIN mstBusinessPartner CP ON  " & vbNewLine &
"	POH.CustomerID=CP.ID  " & vbNewLine &
"WHERE POH.ID=@ID	" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine &
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

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.POID, A.PCDetailID, A2.PCNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.CuttingWeight AS MaxTotalWeight, A.Remarks, " & vbNewLine &
                    "   A.UnitPriceRawMaterial, A.TotalPriceRawMaterial, A.OrderNumberSupplier, A.GroupID, A.RoundingWeight, A.LevelItem, A.ParentID, A.ReceiveDetailID, " & vbNewLine &
                    "   A.ResultID " & vbNewLine &
                    "FROM traPurchaseOrderCuttingDet A " & vbNewLine &
                    "INNER JOIN traPurchaseContractDet A1 ON " & vbNewLine &
                    "   A.PCDetailID=A1.ID " & vbNewLine &
                    "INNER JOIN traPurchaseContract A2 ON " & vbNewLine &
                    "   A1.PCID=A2.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.POID=@POID " & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingDone(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                             ByVal intBPID As Integer, ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT 	" & vbNewLine &
                    "   A.ID, A.POID, A1.PONumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, 	" & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, 	" & vbNewLine &
                    "   D.Description AS ItemTypeName, A.UnitPrice, A.Quantity-A.DoneQuantity AS Quantity, A.Weight, " & vbNewLine &
                    "   A.TotalWeight-A.DoneWeight AS TotalWeight, A.TotalWeight-A.DoneWeight AS MaxTotalWeight, A.Remarks, " & vbNewLine &
                    "   A.OrderNumberSupplier, A.RoundingWeight, A.LevelItem, A.ParentID, A.UnitPriceRawMaterial " & vbNewLine &
                    "FROM traPurchaseOrderCuttingDet A 	" & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting A1 ON 	" & vbNewLine &
                    "   A.POID=A1.ID 	" & vbNewLine &
                    "INNER JOIN mstItem B ON 	" & vbNewLine &
                    "   A.ItemID=B.ID 	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON 	" & vbNewLine &
                    "   B.ItemSpecificationID=C.ID 	" & vbNewLine &
                    "INNER JOIN mstItemType D ON 	" & vbNewLine &
                    "   B.ItemTypeID=D.ID 	" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A1.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A1.IsDeleted=0 " & vbNewLine &
                    "   AND A1.BPID=@BPID " & vbNewLine &
                    "   AND A1.StatusID=@StatusID " & vbNewLine &
                    "   AND A1.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalWeight+A.RoundingWeight-A.DoneWeight>0	" & vbNewLine &
                    "   AND A.POID=@POID" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingDoneResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                   ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                   ByVal intBPID As Integer, ByVal strPODetailID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT 	" & vbNewLine &
                    "   A.ID, A.POID, A.ID AS PODetailResultID, A1.PONumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, 	" & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity-A.DoneQuantity AS Quantity, A.Weight, A.TotalWeight-A.DoneWeight AS TotalWeight, A.TotalWeight-A.DoneWeight AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.OrderNumberSupplier, A.RoundingWeight, A.LevelItem, A.ParentID, A.UnitPriceRawMaterial " & vbNewLine &
                    "FROM traPurchaseOrderCuttingDetResult A 	" & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting A1 ON 	" & vbNewLine &
                    "   A.POID=A1.ID 	" & vbNewLine &
                    "INNER JOIN traPurchaseOrderCuttingDet A3 ON 	" & vbNewLine &
                    "   A.POID=A3.POID 	" & vbNewLine &
                    "   And A.GroupID=A3.GroupID 	" & vbNewLine &
                    "INNER JOIN mstItem B ON 	" & vbNewLine &
                    "   A.ItemID=B.ID 	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON 	" & vbNewLine &
                    "   B.ItemSpecificationID=C.ID 	" & vbNewLine &
                    "INNER JOIN mstItemType D ON 	" & vbNewLine &
                    "   B.ItemTypeID=D.ID 	" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   And A1.CompanyID=@CompanyID " & vbNewLine &
                    "   And A1.IsDeleted=0 " & vbNewLine &
                    "   And A1.BPID=@BPID " & vbNewLine &
                    "   And A1.StatusID=@StatusID " & vbNewLine &
                    "   And A1.ApprovedBy<>'' " & vbNewLine &
                    "   AND A.TotalWeight+A.RoundingWeight-A.DoneWeight>0	" & vbNewLine &
                    "   AND A3.ID=@PODetailID" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
                .Parameters.Add("@PODetailID", SqlDbType.VarChar, 100).Value = strPODetailID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.PurchaseOrderCuttingDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traPurchaseOrderCuttingDet " & vbNewLine &
                    "   (ID, POID, PCDetailID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, UnitPriceRawMaterial, TotalPriceRawMaterial, GroupID, OrderNumberSupplier, RoundingWeight, LevelItem, ParentID, ReceiveDetailID, ResultID) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @POID, @PCDetailID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @UnitPriceRawMaterial, @TotalPriceRawMaterial, @GroupID, @OrderNumberSupplier, @RoundingWeight, @LevelItem, @ParentID, @ReceiveDetailID, @ResultID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = clsData.POID
                .Parameters.Add("@PCDetailID", SqlDbType.VarChar, 100).Value = clsData.PCDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@UnitPriceRawMaterial", SqlDbType.Decimal).Value = clsData.UnitPriceRawMaterial
                .Parameters.Add("@TotalPriceRawMaterial", SqlDbType.Decimal).Value = clsData.TotalPriceRawMaterial
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@ReceiveDetailID", SqlDbType.VarChar, 100).Value = clsData.ReceiveDetailID
                .Parameters.Add("@ResultID", SqlDbType.VarChar, 100).Value = clsData.ResultID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strPOID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traPurchaseOrderCuttingDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   POID=@POID" & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDoneTotalUsedDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal strPODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseOrderCuttingDet SET 	" & vbNewLine &
                    "	DoneWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(COD.TotalWeight+COD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traCuttingDet COD 	" & vbNewLine &
                    "		INNER JOIN traCutting COH ON	" & vbNewLine &
                    "			COD.CuttingID=COH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			COD.PODetailID=@PODetailID " & vbNewLine &
                    "			AND COH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	DoneQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(COD.Quantity+COD.RoundingWeight),0) TotalQuantity " & vbNewLine &
                    "		FROM traCuttingDet COD 	" & vbNewLine &
                    "		INNER JOIN traCutting COH ON	" & vbNewLine &
                    "			COD.CuttingID=COH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			COD.PODetailID=@PODetailID " & vbNewLine &
                    "			AND COH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@PODetailID	" & vbNewLine

                .Parameters.Add("@PODetailID", SqlDbType.VarChar, 100).Value = strPODetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail Result"

        Public Shared Function ListDataDetailResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.POID, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.OrderNumberSupplier, A.Remarks, A.RoundingWeight, A.LevelItem, A.ParentID, A.UnitPriceRawMaterial, " & vbNewLine &
                    "   A.TotalPriceRawMaterial, A.ResultID " & vbNewLine &
                    "FROM traPurchaseOrderCuttingDetResult A " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.POID=@POID " & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetailResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal clsData As VO.PurchaseOrderCuttingDetResult)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traPurchaseOrderCuttingDetResult " & vbNewLine &
                    "   (ID, POID, GroupID, ItemID, Quantity, Weight, TotalWeight, OrderNumberSupplier, Remarks, RoundingWeight, LevelItem, ParentID, UnitPriceRawMaterial, TotalPriceRawMaterial, ResultID) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @POID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @OrderNumberSupplier, @Remarks, @RoundingWeight, @LevelItem, @ParentID, @UnitPriceRawMaterial, @TotalPriceRawMaterial, @ResultID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = clsData.POID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@UnitPriceRawMaterial", SqlDbType.Decimal).Value = clsData.UnitPriceRawMaterial
                .Parameters.Add("@TotalPriceRawMaterial", SqlDbType.Decimal).Value = clsData.TotalPriceRawMaterial
                .Parameters.Add("@ResultID", SqlDbType.VarChar, 100).Value = clsData.ResultID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetailResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strPOID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traPurchaseOrderCuttingDetResult     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   POID=@POID" & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDoneTotalUsedDetailResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal strPODetailResultID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traPurchaseOrderCuttingDetResult SET 	" & vbNewLine &
                    "	DoneWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(COD.TotalWeight+COD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traCuttingDetResult COD 	" & vbNewLine &
                    "		INNER JOIN traCutting COH ON	" & vbNewLine &
                    "			COD.CuttingID=COH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			COD.PODetailResultID=@PODetailResultID " & vbNewLine &
                    "			AND COH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	DoneQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(COD.Quantity+COD.RoundingWeight),0) TotalQuantity " & vbNewLine &
                    "		FROM traCuttingDetResult COD 	" & vbNewLine &
                    "		INNER JOIN traCutting COH ON	" & vbNewLine &
                    "			COD.CuttingID=COH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			COD.PODetailResultID=@PODetailResultID " & vbNewLine &
                    "			AND COH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@PODetailResultID	" & vbNewLine

                .Parameters.Add("@PODetailResultID", SqlDbType.VarChar, 100).Value = strPODetailResultID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

    End Class

End Namespace