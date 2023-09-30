Namespace DL
    Public Class PurchaseOrder

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
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.PONumber, A.PODate, A.OrderRequestID, ORH.OrderNumber, " & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.PersonInCharge, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.DeliveryAddress, " & vbNewLine & _
                    "   A.Validity, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalInternalQuantity, A.TotalInternalWeight, A.TotalDPP, A.TotalPPN, " & vbNewLine & _
                    "   A.TotalPPH, A.RoundingManual, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, A.TotalInternalDPP, A.TotalInternalPPN, " & vbNewLine & _
                    "   A.TotalInternalPPH, A.TotalInternalDPP+A.TotalInternalPPN-A.TotalInternalPPh AS GrandTotalInternal, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine & _
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine & _
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traPurchaseOrder A " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "   A.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "INNER JOIN traOrderRequest ORH ON " & vbNewLine & _
                    "   A.OrderRequestID=ORH.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
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

        Public Shared Function ListDataOutstandingForCutting(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                             ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                             ByVal intStatusID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT DISTINCT " & vbNewLine & _
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.PONumber, A.PODate,  	" & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.TotalQuantity, A.TotalWeight, A.IsDeleted, A.Remarks, A.StatusID,  	" & vbNewLine & _
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc,  	" & vbNewLine & _
                    "   A.LogBy, A.LogDate  	" & vbNewLine & _
                    "FROM traPurchaseOrder A  	" & vbNewLine & _
                    "INNER JOIN mstStatus B ON  	" & vbNewLine & _
                    "   A.StatusID=B.ID  	" & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON  	" & vbNewLine & _
                    "   A.BPID=C.ID  	" & vbNewLine & _
                    "INNER JOIN mstCompany MC ON  	" & vbNewLine & _
                    "   A.CompanyID=MC.ID  	" & vbNewLine & _
                    "INNER JOIN mstProgram MP ON  	" & vbNewLine & _
                    "   A.ProgramID=MP.ID  	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrderDet POD ON 	" & vbNewLine & _
                    "	A.ID=POD.POID 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "   A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.PODate>=@DateFrom AND A.PODate<=@DateTo " & vbNewLine & _
                    "	AND POD.TotalWeight-POD.CuttingWeight>0 	" & vbNewLine & _
                    "	AND A.IsDeleted=0 	" & vbNewLine & _
                    "	AND A.SubmitBy<>''	" & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstandingForTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                               ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                               ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                                               ByVal intStatusID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT DISTINCT " & vbNewLine & _
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.PONumber, A.PODate,  	" & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.TotalQuantity, A.TotalWeight, A.IsDeleted, A.Remarks, A.StatusID,  	" & vbNewLine & _
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc,  	" & vbNewLine & _
                    "   A.LogBy, A.LogDate  	" & vbNewLine & _
                    "FROM traPurchaseOrder A  	" & vbNewLine & _
                    "INNER JOIN mstStatus B ON  	" & vbNewLine & _
                    "   A.StatusID=B.ID  	" & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON  	" & vbNewLine & _
                    "   A.BPID=C.ID  	" & vbNewLine & _
                    "INNER JOIN mstCompany MC ON  	" & vbNewLine & _
                    "   A.CompanyID=MC.ID  	" & vbNewLine & _
                    "INNER JOIN mstProgram MP ON  	" & vbNewLine & _
                    "   A.ProgramID=MP.ID  	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrderDet ORD ON 	" & vbNewLine & _
                    "	A.ID=POD.POID 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "   A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.PODate>=@DateFrom AND A.PODate<=@DateTo " & vbNewLine & _
                    "	AND POD.TotalWeight-POD.TransportWeight>0 	" & vbNewLine & _
                    "	AND A.IsDeleted=0 	" & vbNewLine & _
                    "	AND A.SubmitBy<>''	" & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.PurchaseOrder)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO traPurchaseOrder " & vbNewLine & _
                        "   (ID, ProgramID, CompanyID, PONumber, PODate, OrderRequestID, BPID, PersonInCharge, " & vbNewLine & _
                        "    DeliveryPeriodFrom, DeliveryPeriodTo, DeliveryAddress, Validity, PPN, PPH, TotalQuantity, " & vbNewLine & _
                        "    TotalWeight, TotalInternalQuantity, TotalInternalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, " & vbNewLine & _
                        "    TotalInternalDPP, TotalInternalPPN, TotalInternalPPH, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "   (@ID, @ProgramID, @CompanyID, @PONumber, @PODate, @OrderRequestID, @BPID, @PersonInCharge, " & vbNewLine & _
                        "    @DeliveryPeriodFrom, @DeliveryPeriodTo, @DeliveryAddress, @Validity, @PPN, @PPH, @TotalQuantity, " & vbNewLine & _
                        "    @TotalWeight, @TotalInternalQuantity, @TotalInternalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, " & vbNewLine & _
                        "    @TotalInternalDPP, @TotalInternalPPN, @TotalInternalPPH, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine
                Else
                    .CommandText = _
                        "UPDATE traPurchaseOrder SET " & vbNewLine & _
                        "    ProgramID=@ProgramID, " & vbNewLine & _
                        "    CompanyID=@CompanyID, " & vbNewLine & _
                        "    PONumber=@PONumber, " & vbNewLine & _
                        "    PODate=@PODate, " & vbNewLine & _
                        "    OrderRequestID=@OrderRequestID, " & vbNewLine & _
                        "    BPID=@BPID, " & vbNewLine & _
                        "    PersonInCharge=@PersonInCharge, " & vbNewLine & _
                        "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine & _
                        "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine & _
                        "    DeliveryAddress=@DeliveryAddress, " & vbNewLine & _
                        "    Validity=@Validity, " & vbNewLine & _
                        "    PPN=@PPN, " & vbNewLine & _
                        "    PPH=@PPH, " & vbNewLine & _
                        "    TotalQuantity=@TotalQuantity, " & vbNewLine & _
                        "    TotalWeight=@TotalWeight, " & vbNewLine & _
                        "    TotalInternalQuantity=@TotalInternalQuantity, " & vbNewLine & _
                        "    TotalInternalWeight=@TotalInternalWeight, " & vbNewLine & _
                        "    TotalDPP=@TotalDPP, " & vbNewLine & _
                        "    TotalPPN=@TotalPPN, " & vbNewLine & _
                        "    TotalPPH=@TotalPPH, " & vbNewLine & _
                        "    RoundingManual=@RoundingManual, " & vbNewLine & _
                        "    TotalInternalDPP=@TotalInternalDPP, " & vbNewLine & _
                        "    TotalInternalPPN=@TotalInternalPPN, " & vbNewLine & _
                        "    TotalInternalPPH=@TotalInternalPPH, " & vbNewLine & _
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
                .Parameters.Add("@PONumber", SqlDbType.VarChar, 100).Value = clsData.PONumber
                .Parameters.Add("@PODate", SqlDbType.DateTime).Value = clsData.PODate
                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = clsData.OrderRequestID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@PersonInCharge", SqlDbType.VarChar, 100).Value = clsData.PersonInCharge
                .Parameters.Add("@DeliveryPeriodFrom", SqlDbType.DateTime).Value = clsData.DeliveryPeriodFrom
                .Parameters.Add("@DeliveryPeriodTo", SqlDbType.DateTime).Value = clsData.DeliveryPeriodTo
                .Parameters.Add("@DeliveryAddress", SqlDbType.VarChar, 250).Value = clsData.DeliveryAddress
                .Parameters.Add("@Validity", SqlDbType.VarChar, 250).Value = clsData.Validity
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalInternalQuantity", SqlDbType.Decimal).Value = clsData.TotalInternalQuantity
                .Parameters.Add("@TotalInternalWeight", SqlDbType.Decimal).Value = clsData.TotalInternalWeight
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
                .Parameters.Add("@TotalInternalDPP", SqlDbType.Decimal).Value = clsData.TotalInternalDPP
                .Parameters.Add("@TotalInternalPPN", SqlDbType.Decimal).Value = clsData.TotalInternalPPN
                .Parameters.Add("@TotalInternalPPH", SqlDbType.Decimal).Value = clsData.TotalInternalPPH
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
                                         ByVal strID As String) As VO.PurchaseOrder
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.PurchaseOrder
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.ProgramID, A.CompanyID, A.PONumber, A.PODate, A.OrderRequestID, C.OrderNumber, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.PersonInCharge, " & vbNewLine & _
                        "   A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.DeliveryAddress, A.Validity, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalInternalQuantity, " & vbNewLine & _
                        "   A.TotalInternalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalInternalDPP, A.TotalInternalPPN, A.TotalInternalPPH, A.IsDeleted, " & vbNewLine & _
                        "   A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                        "FROM traPurchaseOrder A " & vbNewLine & _
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine & _
                        "   A.BPID=B.ID " & vbNewLine & _
                        "INNER JOIN traOrderRequest C ON " & vbNewLine & _
                        "   A.OrderRequestID=C.ID " & vbNewLine & _
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
                        voReturn.PONumber = .Item("PONumber")
                        voReturn.PODate = .Item("PODate")
                        voReturn.OrderRequestID = .Item("OrderRequestID")
                        voReturn.OrderNumber = .Item("OrderNumber")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.PersonInCharge = .Item("PersonInCharge")
                        voReturn.DeliveryPeriodFrom = .Item("DeliveryPeriodFrom")
                        voReturn.DeliveryPeriodTo = .Item("DeliveryPeriodTo")
                        voReturn.DeliveryAddress = .Item("DeliveryAddress")
                        voReturn.Validity = .Item("Validity")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalQuantity = .Item("TotalQuantity")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.TotalInternalQuantity = .Item("TotalInternalQuantity")
                        voReturn.TotalInternalWeight = .Item("TotalInternalWeight")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.TotalInternalDPP = .Item("TotalInternalDPP")
                        voReturn.TotalInternalPPN = .Item("TotalInternalPPN")
                        voReturn.TotalInternalPPH = .Item("TotalInternalPPH")
                        voReturn.IsDeleted = .Item("IsDeleted")
                        voReturn.Remarks = .Item("Remarks")
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
                    "UPDATE traPurchaseOrder SET " & vbNewLine & _
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
                        "FROM traPurchaseOrder " & vbNewLine & _
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
                                          ByVal strPONumber As String, ByVal strID As String) As Boolean
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
                        "FROM traPurchaseOrder " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   PONumber=@PONumber " & vbNewLine & _
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@PONumber", SqlDbType.VarChar, 100).Value = strPONumber
                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = sqlCmdExecute.ExecuteReader(CommandBehavior.SingleRow)
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
                        "FROM traPurchaseOrder " & vbNewLine & _
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
                        "FROM traPurchaseOrder " & vbNewLine & _
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
                    "UPDATE traPurchaseOrder SET " & vbNewLine & _
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
                    "UPDATE traPurchaseOrder SET " & vbNewLine & _
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
                    "UPDATE traPurchaseOrder SET " & vbNewLine & _
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
                    "UPDATE traPurchaseOrder SET " & vbNewLine & _
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

        Public Shared Function Print(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "	POH.ID, POH.PONumber, POH.CompanyID, MC.Name AS CompanyName, MC.Address AS CompanyAddress, MC.City AS CompanyCity, POH.ProgramID, 	" & vbNewLine & _
                    "	MP.Name AS ProgramName, POH.PODate, POH.BPID, BP.Code AS BPCode, BP.Name AS BPName, 	" & vbNewLine & _
                    "	POH.PersonInCharge, CAST('' AS VARCHAR(100)) AS DeliveryPeriod, POH.DeliveryPeriodFrom, 	" & vbNewLine & _
                    "	POH.DeliveryPeriodTo, POH.DeliveryAddress, POH.Validity, POH.PPN, POH.PPH, POH.TotalWeight, POH.TotalDPP, 	" & vbNewLine & _
                    "	POH.TotalPPN, POH.TotalPPH, POH.TotalDPP+POH.TotalPPN-POH.TotalPPH AS GrandTotal, 	" & vbNewLine & _
                    "	POH.RoundingManual, POH.Remarks, CAST('' AS VARCHAR(300)) AS PaymentTerms, CAST('' AS VARCHAR(300)) AS PODateAndCity, 	" & vbNewLine & _
                    "	POD.ItemID, MI.ItemCode, MI.ItemName, MI.ItemTypeID, IT.Description ItemType, 	" & vbNewLine & _
                    "	MI.ItemSpecificationID, MIS.Description AS ItemSpec, MI.Thick AS ItemThick, 	" & vbNewLine & _
                    "	MI.Width AS ItemWidth, MI.Length AS ItemLength, POD.Quantity, POD.Weight, 	" & vbNewLine & _
                    "	POD.TotalWeight AS TotalWeightItem, POD.UnitPrice, POD.TotalPrice, POH.StatusID " & vbNewLine & _
                    "FROM traPurchaseOrder POH 	" & vbNewLine & _
                    "INNER JOIN mstCompany MC ON 	" & vbNewLine & _
                    "	POH.CompanyID=MC.ID 	" & vbNewLine & _
                    "INNER JOIN mstProgram MP ON 	" & vbNewLine & _
                    "	POH.ProgramID=MP.ID 	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrderDet POD ON 	" & vbNewLine & _
                    "	POH.ID=POD.POID 	" & vbNewLine & _
                    "INNER JOIN mstBusinessPartner BP ON	 	" & vbNewLine & _
                    "	POH.BPID=BP.ID 	" & vbNewLine & _
                    "INNER JOIN mstItem MI ON 	" & vbNewLine & _
                    "	POD.ItemID=MI.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemType IT ON 	" & vbNewLine & _
                    "	MI.ItemTypeID=IT.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification MIS ON 	" & vbNewLine & _
                    "	MI.ItemSpecificationID=MIS.ID 	" & vbNewLine & _
                    "WHERE POH.ID=@ID	" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.POID, A.OrderRequestDetailID, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine & _
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.CuttingPrice, A.TransportPrice, A.TotalPrice, A.CuttingQuantity, " & vbNewLine & _
                    "   A.CuttingWeight, A.TransportQuantity, A.TransportWeight, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderDet A " & vbNewLine & _
                    "INNER JOIN mstItem B ON " & vbNewLine & _
                    "   A.ItemID=B.ID " & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine & _
                    "   B.ItemSpecificationID=C.ID " & vbNewLine & _
                    "INNER JOIN mstItemType D ON " & vbNewLine & _
                    "   B.ItemTypeID=D.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.POID=@POID " & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingCuttingOrder(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                     ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "    A.ID, A.POID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, 	" & vbNewLine & _
                    "    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, 	" & vbNewLine & _
                    "    D.Description AS ItemTypeName, A.CuttingPrice AS UnitPrice, A.Quantity-A.CuttingQuantity AS Quantity, A.Weight, " & vbNewLine & _
                    "    A.TotalWeight-A.CuttingWeight AS TotalWeight, A.Remarks 	" & vbNewLine & _
                    "FROM traPurchaseOrderDet A 	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrder A1 ON 	" & vbNewLine & _
                    "    A.POID=A1.ID 	" & vbNewLine & _
                    "INNER JOIN mstItem B ON 	" & vbNewLine & _
                    "    A.ItemID=B.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON 	" & vbNewLine & _
                    "    B.ItemSpecificationID=C.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON 	" & vbNewLine & _
                    "    B.ItemTypeID=D.ID 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "    A.POID=@POID 	" & vbNewLine & _
                    "    AND A1.StatusID=@StatusID " & vbNewLine & _
                    "    AND A.Quantity-A.CuttingQuantity>0 " & vbNewLine & _
                    "    AND A.TotalWeight-A.CuttingWeight>0 " & vbNewLine

                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingConfirmationOrder(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                          ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "    A.ID, A.POID, A1.PONumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, 	" & vbNewLine & _
                    "    C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, 	" & vbNewLine & _
                    "    D.Description AS ItemTypeName, A.UnitPrice-A.CuttingPrice-A.TransportPrice AS UnitPrice, " & vbNewLine & _
                    "    A.Quantity-A.COQuantity AS Quantity, A.Weight, A.TotalWeight-A.COWeight AS TotalWeight, A.Remarks 	" & vbNewLine & _
                    "FROM traPurchaseOrderDet A 	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrder A1 ON 	" & vbNewLine & _
                    "    A.POID=A1.ID 	" & vbNewLine & _
                    "INNER JOIN mstItem B ON 	" & vbNewLine & _
                    "    A.ItemID=B.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON 	" & vbNewLine & _
                    "    B.ItemSpecificationID=C.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON 	" & vbNewLine & _
                    "    B.ItemTypeID=D.ID 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "    A1.IsDeleted=0 " & vbNewLine & _
                    "    AND A1.BPID=@BPID " & vbNewLine & _
                    "    AND A1.StatusID=@StatusID " & vbNewLine & _
                    "    AND A.Quantity-A.COQuantity>0	" & vbNewLine & _
                    "    AND A.TotalWeight-A.COWeight>0	" & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.PurchaseOrderDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traPurchaseOrderDet " & vbNewLine & _
                    "   (ID, POID, OrderRequestDetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, CuttingPrice, TransportPrice, TotalPrice, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @POID, @OrderRequestDetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @CuttingPrice, @TransportPrice, @TotalPrice, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = clsData.POID
                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = clsData.OrderRequestDetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@CuttingPrice", SqlDbType.Decimal).Value = clsData.CuttingPrice
                .Parameters.Add("@TransportPrice", SqlDbType.Decimal).Value = clsData.TransportPrice
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
                                           ByVal strPOID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traPurchaseOrderDet     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   POID=@POID" & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateCuttingTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strPODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseOrderDet SET 	" & vbNewLine & _
                    "	CuttingWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(POD.TotalWeight),0) TotalWeight		" & vbNewLine & _
                    "		FROM traPurchaseOrderCuttingDet POD 	" & vbNewLine & _
                    "		INNER JOIN traPurchaseOrderCutting POH ON	" & vbNewLine & _
                    "			POD.POID=POH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			POD.PODetailID=@PODetailID " & vbNewLine & _
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
                    "			POD.PODetailID=@PODetailID " & vbNewLine & _
                    "			AND POH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
                    "WHERE ID=@PODetailID	" & vbNewLine

                .Parameters.Add("@PODetailID", SqlDbType.VarChar, 100).Value = strPODetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateCOTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strPODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseOrderDet SET 	" & vbNewLine & _
                    "	COWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(COD.TotalWeight),0) TotalWeight		" & vbNewLine & _
                    "		FROM traConfirmationOrderDet COD 	" & vbNewLine & _
                    "		INNER JOIN traConfirmationOrder COH ON	" & vbNewLine & _
                    "			COD.COID=COH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			COD.PODetailID=@PODetailID " & vbNewLine & _
                    "			AND COH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	COQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(COD.Quantity),0) TotalQuantity " & vbNewLine & _
                    "		FROM traConfirmationOrderDet COD 	" & vbNewLine & _
                    "		INNER JOIN traConfirmationOrder COH ON	" & vbNewLine & _
                    "			COD.COID=COH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			COD.PODetailID=@PODetailID " & vbNewLine & _
                    "			AND COH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
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

#Region "Detail Internal"

        Public Shared Function ListDataDetailInternal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.POID, A.OrderRequestDetailID, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine & _
                    "   A.Quantity, A.Weight, A.TotalWeight, E.TotalWeight-E.POInternalWeight+A.TotalWeight AS MaxTotalWeight, A.UnitPrice, A.CuttingPrice, A.TransportPrice, A.TotalPrice, A.SalesContractQuantity, " & vbNewLine & _
                    "   A.SalesContractWeight, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderDetInternal A " & vbNewLine & _
                    "INNER JOIN mstItem B ON " & vbNewLine & _
                    "   A.ItemID=B.ID " & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine & _
                    "   B.ItemSpecificationID=C.ID " & vbNewLine & _
                    "INNER JOIN mstItemType D ON " & vbNewLine & _
                    "   B.ItemTypeID=D.ID " & vbNewLine & _
                    "INNER JOIN traOrderRequestDet E ON " & vbNewLine & _
                    "   A.OrderRequestDetailID=E.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.POID=@POID " & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetailInternal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal clsData As VO.PurchaseOrderDetInternal)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traPurchaseOrderDetInternal " & vbNewLine & _
                    "   (ID, POID, OrderRequestDetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, CuttingPrice, TransportPrice, TotalPrice, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @POID, @OrderRequestDetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @CuttingPrice, @TransportPrice, @TotalPrice, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = clsData.POID
                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = clsData.OrderRequestDetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@CuttingPrice", SqlDbType.Decimal).Value = clsData.CuttingPrice
                .Parameters.Add("@TransportPrice", SqlDbType.Decimal).Value = clsData.TransportPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetailInternal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strPOID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traPurchaseOrderDetInternal     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   POID=@POID" & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
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
                                                   ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.POID, A.Percentage, A.PaymentTypeID, B.Code AS PaymentTypeCode, B.Name AS PaymentTypeName, " & vbNewLine & _
                    "   A.PaymentModeID, C.Code AS PaymentModeCode, C.Name AS PaymentModeName, A.CreditTerm, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderPaymentTerm A " & vbNewLine & _
                    "INNER JOIN mstPaymentType B ON " & vbNewLine & _
                    "   A.PaymentTypeID=B.ID " & vbNewLine & _
                    "INNER JOIN mstPaymentMode C ON " & vbNewLine & _
                    "   A.PaymentModeID=C.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.POID=@POID " & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal clsData As VO.PurchaseOrderPaymentTerm)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traPurchaseOrderPaymentTerm " & vbNewLine & _
                    "   (ID, POID, Percentage, PaymentTypeID, PaymentModeID, CreditTerm, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @POID, @Percentage, @PaymentTypeID, @PaymentModeID, @CreditTerm, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = clsData.POID
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
                                                   ByVal strPOID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traPurchaseOrderPaymentTerm     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   POID=@POID" & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
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
                                              ByVal strPOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.POID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderStatus A " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   A.POID=@POID " & vbNewLine

                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.PurchaseOrderStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traPurchaseOrderStatus " & vbNewLine & _
                    "   (ID, POID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @POID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = clsData.POID
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
                                              ByVal strPOID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine & _
                        "FROM traPurchaseOrderStatus " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   POID=@POID " & vbNewLine & _
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = strPOID
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