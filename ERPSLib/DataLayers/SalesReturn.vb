Namespace DL

    Public Class SalesReturn

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SalesReturnNumber, A.SalesReturnDate, " & vbNewLine &
"   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryID, A1.DeliveryNumber, A.PlatNumber, A.Driver, A.ReferencesNumber, " & vbNewLine &
"	A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal,  " & vbNewLine &
"   A.DPAmount, A.TotalPayment, A.RoundingManual, (A.TotalDPP+A.RoundingManual)-(A.DPAmount+A.TotalPayment) AS OutstandingPayment, A.PPNTransport, A.PPHTransport, " & vbNewLine &
"   A.IsFreePPNTransport, A.IsFreePPHTransport, A.UnitPriceTransport, A.TotalDPPTransport, A.TotalPPNTransport, A.TotalPPHTransport, A.RoundingManualTransport, " & vbNewLine &
"   A.IsDeleted, A.Remarks, A.StatusID, B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine &
"   A.TotalDPPTransport+A.TotalPPNTransport+A.TotalPPHTransport AS GrandTotalTransport, CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, " & vbNewLine &
"   A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.TransporterID, TP.Code AS TransporterCode, TP.Name AS TransporterName " & vbNewLine &
"FROM traSalesReturn A " & vbNewLine &
"INNER JOIN traDelivery A1 ON " & vbNewLine &
"   A.DeliveryID=A1.ID " & vbNewLine &
"INNER JOIN mstStatus B ON " & vbNewLine &
"   A.StatusID=B.ID " & vbNewLine &
"INNER JOIN mstBusinessPartner C ON " & vbNewLine &
"   A.BPID=C.ID " & vbNewLine &
"INNER JOIN mstBusinessPartner TP ON " & vbNewLine &
"   A.TransporterID=TP.ID " & vbNewLine &
"INNER JOIN mstCompany MC ON " & vbNewLine &
"   A.CompanyID=MC.ID " & vbNewLine &
"INNER JOIN mstProgram MP ON " & vbNewLine &
"   A.ProgramID=MP.ID " & vbNewLine &
"WHERE  " & vbNewLine &
"   A.ProgramID=@ProgramID " & vbNewLine &
"   AND A.CompanyID=@CompanyID " & vbNewLine &
"   AND A.SalesReturnDate>=@DateFrom AND A.SalesReturnDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.SalesReturn)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traSalesReturn " & vbNewLine & _
"	(ID, ProgramID, CompanyID, SalesReturnNumber, SalesReturnDate, BPID, DeliveryID, PlatNumber, Driver, ReferencesNumber, PPN, PPH, " & vbNewLine & _
"    TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, TotalDPPTransport, TotalPPNTransport, TotalPPHTransport, RoundingManualTransport, " & vbNewLine & _
"    Remarks, StatusID, CreatedBy, LogBy, CoAofStock, TransporterID, PPNTransport, PPHTransport, IsFreePPNTransport, IsFreePPHTransport, UnitPriceTransport, TotalCostRawMaterial) " & vbNewLine & _
"VALUES " & vbNewLine & _
"	(@ID, @ProgramID, @CompanyID, @SalesReturnNumber, @SalesReturnDate, @BPID, @DeliveryID, @PlatNumber, @Driver, @ReferencesNumber, @PPN, @PPH, " & vbNewLine & _
"    @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, @TotalDPPTransport, @TotalPPNTransport, @TotalPPHTransport, @RoundingManualTransport, " & vbNewLine & _
"    @Remarks, @StatusID, @LogBy, @LogBy, @CoAofStock, @TransporterID, @PPNTransport, @PPHTransport, @IsFreePPNTransport, @IsFreePPHTransport, @UnitPriceTransport, @TotalCostRawMaterial) " & vbNewLine
                Else
                    .CommandText =
"UPDATE traSalesReturn SET  " & vbNewLine & _
"	ProgramID=@ProgramID,  " & vbNewLine & _
"	CompanyID=@CompanyID,  " & vbNewLine & _
"	SalesReturnNumber=@SalesReturnNumber,  " & vbNewLine & _
"	SalesReturnDate=@SalesReturnDate,  " & vbNewLine & _
"	BPID=@BPID,  " & vbNewLine & _
"	DeliveryID=@DeliveryID,  " & vbNewLine & _
"	PlatNumber=@PlatNumber,  " & vbNewLine & _
"	Driver=@Driver,  " & vbNewLine & _
"	ReferencesNumber=@ReferencesNumber,  " & vbNewLine & _
"	PPN=@PPN,  " & vbNewLine & _
"	PPH=@PPH,  " & vbNewLine & _
"	TotalQuantity=@TotalQuantity,  " & vbNewLine & _
"	TotalWeight=@TotalWeight,  " & vbNewLine & _
"	TotalDPP=@TotalDPP,  " & vbNewLine & _
"	TotalPPN=@TotalPPN,  " & vbNewLine & _
"	TotalPPH=@TotalPPH,  " & vbNewLine & _
"	RoundingManual=@RoundingManual,  " & vbNewLine & _
"	TotalDPPTransport=@TotalDPPTransport,  " & vbNewLine & _
"	TotalPPNTransport=@TotalPPNTransport,  " & vbNewLine & _
"	TotalPPHTransport=@TotalPPHTransport,  " & vbNewLine & _
"	RoundingManualTransport=@RoundingManualTransport,  " & vbNewLine & _
"	Remarks=@Remarks,  " & vbNewLine & _
"	StatusID=@StatusID,  " & vbNewLine & _
"	LogInc=LogInc+1,  " & vbNewLine & _
"	LogBy=@LogBy,  " & vbNewLine & _
"	LogDate=GETDATE(),  " & vbNewLine & _
"	CoAofStock=@CoAofStock,  " & vbNewLine & _
"	TransporterID=@TransporterID,  " & vbNewLine & _
"	PPNTransport=@PPNTransport,  " & vbNewLine & _
"	PPHTransport=@PPHTransport,  " & vbNewLine & _
"	IsFreePPNTransport=@IsFreePPNTransport,  " & vbNewLine & _
"	IsFreePPHTransport=@IsFreePPHTransport,  " & vbNewLine & _
"	UnitPriceTransport=@UnitPriceTransport,  " & vbNewLine & _
"	TotalCostRawMaterial=@TotalCostRawMaterial  " & vbNewLine & _
"WHERE " & vbNewLine & _
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@SalesReturnNumber", SqlDbType.VarChar, 100).Value = clsData.SalesReturnNumber
                .Parameters.Add("@SalesReturnDate", SqlDbType.DateTime).Value = clsData.SalesReturnDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = clsData.DeliveryID
                .Parameters.Add("@PlatNumber", SqlDbType.VarChar, 100).Value = clsData.PlatNumber
                .Parameters.Add("@Driver", SqlDbType.VarChar, 100).Value = clsData.Driver
                .Parameters.Add("@ReferencesNumber", SqlDbType.VarChar, 100).Value = clsData.ReferencesNumber
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
                .Parameters.Add("@TotalDPPTransport", SqlDbType.Decimal).Value = clsData.TotalDPPTransport
                .Parameters.Add("@TotalPPNTransport", SqlDbType.Decimal).Value = clsData.TotalPPNTransport
                .Parameters.Add("@TotalPPHTransport", SqlDbType.Decimal).Value = clsData.TotalPPHTransport
                .Parameters.Add("@RoundingManualTransport", SqlDbType.Decimal).Value = clsData.RoundingManualTransport
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = clsData.CoAofStock
                .Parameters.Add("@TransporterID", SqlDbType.Int).Value = clsData.TransporterID
                .Parameters.Add("@PPNTransport", SqlDbType.Decimal).Value = clsData.PPNTransport
                .Parameters.Add("@PPHTransport", SqlDbType.Decimal).Value = clsData.PPHTransport
                .Parameters.Add("@IsFreePPNTransport", SqlDbType.Bit).Value = clsData.IsFreePPNTransport
                .Parameters.Add("@IsFreePPHTransport", SqlDbType.Bit).Value = clsData.IsFreePPHTransport
                .Parameters.Add("@UnitPriceTransport", SqlDbType.Decimal).Value = clsData.UnitPriceTransport
                .Parameters.Add("@TotalCostRawMaterial", SqlDbType.Decimal).Value = clsData.TotalCostRawMaterial
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.SalesReturn
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.SalesReturn
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.SalesReturnNumber, A.SalesReturnDate, " & vbNewLine &
"   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryID, A1.DeliveryNumber, A.PlatNumber, A.Driver, A.ReferencesNumber, A.PPN, A.PPH, A.TotalQuantity,  " & vbNewLine &
"	A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.TotalDPPTransport, A.TotalPPNTransport, A.TotalPPHTransport, A.RoundingManualTransport, " & vbNewLine &
"   A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, " & vbNewLine &
"	A.LogBy, A.LogDate, A.JournalID, A.DPAmount, A.TotalPayment, A.CoAofStock, A.IsUseSubItem, A.DPAmountPPN, A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH, " & vbNewLine &
"	A.TransporterID, TP.Code AS TransporterCode, TP.Name AS TransporterName, A.PPNTransport, A.PPHTransport, A.IsFreePPNTransport, A.IsFreePPHTransport, A.UnitPriceTransport, A.DPAmountTransport, A.TotalPaymentTransport,  " & vbNewLine &
"	A.DPAmountPPNTransport, A.DPAmountPPHTransport, A.TotalPaymentPPNTransport, A.TotalPaymentPPHTransport, COA.Code AS CoACodeofStock, COA.Name AS CoANameofStock, A.TotalCostRawMaterial " & vbNewLine &
"FROM traSalesReturn A " & vbNewLine &
"INNER JOIN traDelivery A1 ON " & vbNewLine &
"   A.DeliveryID=A1.ID " & vbNewLine &
"INNER JOIN mstStatus B ON " & vbNewLine &
"   A.StatusID=B.ID " & vbNewLine &
"INNER JOIN mstBusinessPartner C ON " & vbNewLine &
"   A.BPID=C.ID " & vbNewLine &
"INNER JOIN mstBusinessPartner TP ON " & vbNewLine &
"   A.TransporterID=TP.ID " & vbNewLine &
"INNER JOIN mstCompany MC ON " & vbNewLine &
"   A.CompanyID=MC.ID " & vbNewLine &
"INNER JOIN mstProgram MP ON " & vbNewLine &
"   A.ProgramID=MP.ID " & vbNewLine &
"INNER JOIN mstChartOfAccount COA ON " & vbNewLine &
"   A.CoAofStock=COA.ID " & vbNewLine &
"WHERE " & vbNewLine &
"	A.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.ProgramName = .Item("ProgramName")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.CompanyName = .Item("CompanyName")
                        voReturn.SalesReturnNumber = .Item("SalesReturnNumber")
                        voReturn.SalesReturnDate = .Item("SalesReturnDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.DeliveryID = .Item("DeliveryID")
                        voReturn.DeliveryNumber = .Item("DeliveryNumber")
                        voReturn.PlatNumber = .Item("PlatNumber")
                        voReturn.Driver = .Item("Driver")
                        voReturn.ReferencesNumber = .Item("ReferencesNumber")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalQuantity = .Item("TotalQuantity")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.TotalDPPTransport = .Item("TotalDPPTransport")
                        voReturn.TotalPPNTransport = .Item("TotalPPNTransport")
                        voReturn.TotalPPHTransport = .Item("TotalPPHTransport")
                        voReturn.RoundingManual = .Item("RoundingManual")
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
                        voReturn.JournalID = .Item("JournalID")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.TotalPayment = .Item("TotalPayment")
                        voReturn.CoAofStock = .Item("CoAofStock")
                        voReturn.CoACodeOfStock = .Item("CoACodeofStock")
                        voReturn.CoANameOfStock = .Item("CoANameOfStock")
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
                        voReturn.DPAmountPPN = .Item("DPAmountPPN")
                        voReturn.DPAmountPPH = .Item("DPAmountPPH")
                        voReturn.TotalPaymentPPN = .Item("TotalPaymentPPN")
                        voReturn.TotalPaymentPPH = .Item("TotalPaymentPPH")
                        voReturn.TransporterID = .Item("TransporterID")
                        voReturn.TransporterCode = .Item("TransporterCode")
                        voReturn.TransporterName = .Item("TransporterName")
                        voReturn.PPNTransport = .Item("PPNTransport")
                        voReturn.PPHTransport = .Item("PPHTransport")
                        voReturn.IsFreePPNTransport = .Item("IsFreePPNTransport")
                        voReturn.IsFreePPHTransport = .Item("IsFreePPHTransport")
                        voReturn.UnitPriceTransport = .Item("UnitPriceTransport")
                        voReturn.DPAmountTransport = .Item("DPAmountTransport")
                        voReturn.TotalPaymentTransport = .Item("TotalPaymentTransport")
                        voReturn.DPAmountPPNTransport = .Item("DPAmountPPNTransport")
                        voReturn.DPAmountPPHTransport = .Item("DPAmountPPHTransport")
                        voReturn.TotalPaymentPPNTransport = .Item("TotalPaymentPPNTransport")
                        voReturn.TotalPaymentPPHTransport = .Item("TotalPaymentPPHTransport")
                        voReturn.TotalCostRawMaterial = .Item("TotalCostRawMaterial")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
                    "UPDATE traSalesReturn SET " & vbNewLine &
                    "   StatusID=@StatusID, " & vbNewLine &
                    "   IsDeleted=1 " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Deleted

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
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
                        "FROM traSalesReturn " & vbNewLine &
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
                                          ByVal strSalesReturnNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traSalesReturn " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   SalesReturnNumber=@SalesReturnNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@SalesReturnNumber", SqlDbType.VarChar, 100).Value = strSalesReturnNumber
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
                        "FROM traSalesReturn " & vbNewLine &
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
                        "FROM traSalesReturn " & vbNewLine &
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
                    "UPDATE traSalesReturn SET " & vbNewLine &
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
                    "UPDATE traSalesReturn SET " & vbNewLine &
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
                    "UPDATE traSalesReturn SET " & vbNewLine &
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
                    "UPDATE traSalesReturn SET " & vbNewLine &
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
                    "UPDATE traSalesReturn SET " & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                    ByVal strDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesReturnDet SET 	" & vbNewLine &
                    "	AllocateDPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.DPAmount),0) DPAmount " & vbNewLine &
                    "		FROM traARAPItem TDD " & vbNewLine &
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
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
                    "		INNER JOIN traAccountReceivable AR ON " & vbNewLine &
                    "		    TDD.ParentID=AR.ID  " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND AR.IsDeleted=0 " & vbNewLine &
                    "			AND AR.Modules=@Modules " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePaymentSalesReturn
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
                    "UPDATE traSalesReturn SET 	" & vbNewLine &
                    "	TotalPayment=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmount),0) TotalPayment		" & vbNewLine &
                    "		FROM traSalesReturnDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SalesReturnID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPN),0) TotalPayment		" & vbNewLine &
                    "		FROM traSalesReturnDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SalesReturnID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPH),0) TotalPayment		" & vbNewLine &
                    "		FROM traSalesReturnDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SalesReturnID=@ID 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePaymentSalesReturn
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
                                              ByVal strSalesReturnID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	A.ID, A.SalesReturnID, A.DeliveryDetailID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
"   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
"   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.ReturnWeight AS MaxTotalWeight, " & vbNewLine &
"   A.Remarks, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A2.CoAofStock, A.UnitPriceHPP, A.TotalPriceHPP " & vbNewLine &
"FROM traSalesReturnDet A " & vbNewLine &
"INNER JOIN traDeliveryDet A1 ON " & vbNewLine &
"   A.DeliveryDetailID=A1.ID " & vbNewLine &
"INNER JOIN mstItem B ON " & vbNewLine &
"   A.ItemID=B.ID " & vbNewLine &
"INNER JOIN mstItemSpecification C ON " & vbNewLine &
"   B.ItemSpecificationID=C.ID " & vbNewLine &
"INNER JOIN mstItemType D ON " & vbNewLine &
"   B.ItemTypeID=D.ID " & vbNewLine &
"INNER JOIN traSalesReturn A2 ON " & vbNewLine &
"   A.SalesReturnID=A2.ID " & vbNewLine &
"WHERE  " & vbNewLine &
"	A.SalesReturnID=@SalesReturnID  " & vbNewLine

                .Parameters.Add("@SalesReturnID", SqlDbType.VarChar, 100).Value = strSalesReturnID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal clsData As VO.SalesReturnDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"INSERT INTO traSalesReturnDet " & vbNewLine & _
"	(ID, SalesReturnID, DeliveryDetailID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, " & vbNewLine & _
"	 Remarks, UnitPriceTransport, OrderNumberSupplier, TotalPriceTransport, LevelItem, ParentID, RoundingWeight, UnitPriceHPP, TotalPriceHPP) " & vbNewLine & _
"VALUES " & vbNewLine & _
"	(@ID, @SalesReturnID, @DeliveryDetailID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, " & vbNewLine & _
"    @Remarks, @UnitPriceTransport, @OrderNumberSupplier, @TotalPriceTransport, @LevelItem, @ParentID, @RoundingWeight, @UnitPriceHPP, @TotalPriceHPP) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@SalesReturnID", SqlDbType.VarChar, 100).Value = clsData.SalesReturnID
                .Parameters.Add("@DeliveryDetailID", SqlDbType.VarChar, 100).Value = clsData.DeliveryDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@UnitPriceTransport", SqlDbType.Decimal).Value = clsData.UnitPriceTransport
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@TotalPriceTransport", SqlDbType.Decimal).Value = clsData.TotalPriceTransport
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = clsData.UnitPriceHPP
                .Parameters.Add("@TotalPriceHPP", SqlDbType.Decimal).Value = clsData.TotalPriceHPP
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strSalesReturnID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"DELETE FROM traSalesReturnDet " & vbNewLine & _
"WHERE " & vbNewLine & _
"	SalesReturnID=@SalesReturnID " & vbNewLine

                .Parameters.Add("@SalesReturnID", SqlDbType.VarChar, 100).Value = strSalesReturnID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function IsAlreadyPaymentDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
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
                        "FROM traSalesReturnDet " & vbNewLine &
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

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strSalesReturnID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.SalesReturnID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traSalesReturnStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.SalesReturnID=@SalesReturnID " & vbNewLine

                .Parameters.Add("@SalesReturnID", SqlDbType.VarChar, 100).Value = strSalesReturnID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.SalesReturnStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesReturnStatus " & vbNewLine &
                    "   (ID, SalesReturnID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @SalesReturnID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@SalesReturnID", SqlDbType.VarChar, 100).Value = clsData.SalesReturnID
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
                                              ByVal strSalesReturnID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traSalesReturnStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   SalesReturnID=@SalesReturnID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@SalesReturnID", SqlDbType.VarChar, 100).Value = strSalesReturnID
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

