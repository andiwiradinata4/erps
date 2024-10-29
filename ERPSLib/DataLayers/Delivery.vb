Namespace DL
    Public Class Delivery

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal bolIsStock As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.DeliveryNumber, A.DeliveryDate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.SCID, ISNULL(A1.SCNumber,A2.OrderNumber) AS SCNumber, A.PlatNumber, A.Driver, A.ReferencesNumber, A.PPN, " & vbNewLine &
                    "   A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.TotalDPPTransport, A.TotalPPNTransport, A.TotalPPHTransport, A.TotalDPPTransport+TotalPPNTransport+A.TotalPPHTransport AS GrandTotalTransport, " & vbNewLine &
                    "   A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, " & vbNewLine &
                    "   A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, StatusInfo=B.Name, A.TransporterID, TP.Code AS TransporterCode, TP.Name AS TransporterName,  " & vbNewLine &
                    "   A.PPNTransport, A.PPHTransport, A.UnitPriceTransport, A.PPNTransport, A.PPHTransport, A.IsFreePPNTransport, A.IsFreePPHTransport, " & vbNewLine &
                    "   A.BPLocationID, BPLocationName=BPL.Address, A.CoAofStock, COA.Code AS CoACodeofStock, COA.Name AS CoANameofStock " & vbNewLine &
                    "FROM traDelivery A " & vbNewLine &
                    "LEFT JOIN traSalesContract A1 ON " & vbNewLine &
                    "   A.SCID=A1.ID " & vbNewLine &
                    "LEFT JOIN traOrderRequest A2 ON " & vbNewLine &
                    "   A.SCID=A2.ID " & vbNewLine &
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
                    "INNER JOIN mstBusinessPartnerLocation BPL ON " & vbNewLine &
                    "   A.BPLocationID=BPL.ID " & vbNewLine &
                    "INNER JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "   A.CoAofStock=COA.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.IsStock=@IsStock " & vbNewLine &
                    "   AND A.DeliveryDate>=@DateFrom AND A.DeliveryDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
                .Parameters.Add("@IsStock", SqlDbType.Bit).Value = bolIsStock
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstandingSalesReturn(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                              ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                              ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.DeliveryNumber, A.DeliveryDate, A.BPID, C.Code AS BPCode, " & vbNewLine &
                    "   C.Name AS BPName, A.TransporterID, TP.Code AS TransporterCode, TP.Name AS TransporterName, A.TotalQuantity, A.TotalWeight, A.PPN, A.PPH, A.TotalDPP, " & vbNewLine &
                    "   A.TotalPPN, A.TotalPPH, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, A.Remarks, A.StatusID, B.Name AS StatusInfo" & vbNewLine &
                    "FROM traDelivery A " & vbNewLine &
                    "INNER JOIN traDeliveryDet A1 ON " & vbNewLine &
                    "   A.ID=A1.DeliveryID " & vbNewLine &
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
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.StatusID=@StatusID " & vbNewLine &
                    "   AND A.BPID=@BPID " & vbNewLine &
                    "   AND A.IsDeleted=0 " & vbNewLine &
                    "   AND A1.TotalWeight-A1.RoundingWeight-A1.ReturnWeight>0 " & vbNewLine &
                    "   AND A.IsDeleted=0 " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.Delivery)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO traDelivery " & vbNewLine &
                        "   (ID, ProgramID, CompanyID, DeliveryNumber, DeliveryDate, BPID, SCID, PlatNumber, Driver, ReferencesNumber, " & vbNewLine &
                        "    PPN, PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, TotalDPPTransport, TotalPPNTransport, " & vbNewLine &
                        "    TotalPPHTransport, RoundingManual, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, TotalCostRawMaterial, " & vbNewLine &
                        "    TransporterID, UnitPriceTransport, PPNTransport, PPHTransport, IsFreePPNTransport, IsFreePPHTransport, IsUseSubItem, " & vbNewLine &
                        "    IsStock, BPLocationID, CoAofStock) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @DeliveryNumber, @DeliveryDate, @BPID, @SCID, @PlatNumber, @Driver, @ReferencesNumber, " & vbNewLine &
                        "    @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @TotalDPPTransport, @TotalPPNTransport, " & vbNewLine &
                        "    @TotalPPHTransport, @RoundingManual, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), @TotalCostRawMaterial, " & vbNewLine &
                        "    @TransporterID, @UnitPriceTransport, @PPNTransport, @PPHTransport, @IsFreePPNTransport, @IsFreePPHTransport, @IsUseSubItem, " & vbNewLine &
                        "    @IsStock, @BPLocationID, @CoAofStock) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE traDelivery SET " & vbNewLine &
                        "   ProgramID=@ProgramID, " & vbNewLine &
                        "   CompanyID=@CompanyID, " & vbNewLine &
                        "   DeliveryNumber=@DeliveryNumber, " & vbNewLine &
                        "   DeliveryDate=@DeliveryDate, " & vbNewLine &
                        "   BPID=@BPID, " & vbNewLine &
                        "   SCID=@SCID, " & vbNewLine &
                        "   PlatNumber=@PlatNumber, " & vbNewLine &
                        "   Driver=@Driver, " & vbNewLine &
                        "   ReferencesNumber=@ReferencesNumber, " & vbNewLine &
                        "   PPN=@PPN, " & vbNewLine &
                        "   PPH=@PPH, " & vbNewLine &
                        "   TotalQuantity=@TotalQuantity, " & vbNewLine &
                        "   TotalWeight=@TotalWeight, " & vbNewLine &
                        "   TotalDPP=@TotalDPP, " & vbNewLine &
                        "   TotalPPN=@TotalPPN, " & vbNewLine &
                        "   TotalPPH=@TotalPPH, " & vbNewLine &
                        "   TotalDPPTransport=@TotalDPPTransport, " & vbNewLine &
                        "   TotalPPNTransport=@TotalPPNTransport, " & vbNewLine &
                        "   TotalPPHTransport=@TotalPPHTransport, " & vbNewLine &
                        "   RoundingManual=@RoundingManual, " & vbNewLine &
                        "   Remarks=@Remarks, " & vbNewLine &
                        "   StatusID=@StatusID, " & vbNewLine &
                        "   LogInc=LogInc+1, " & vbNewLine &
                        "   LogBy=@LogBy, " & vbNewLine &
                        "   LogDate=GETDATE(), " & vbNewLine &
                        "   TotalCostRawMaterial=@TotalCostRawMaterial, " & vbNewLine &
                        "   TransporterID=@TransporterID, " & vbNewLine &
                        "   UnitPriceTransport=@UnitPriceTransport, " & vbNewLine &
                        "   PPNTransport=@PPNTransport, " & vbNewLine &
                        "   PPHTransport=@PPHTransport, " & vbNewLine &
                        "   IsFreePPNTransport=@IsFreePPNTransport, " & vbNewLine &
                        "   IsFreePPHTransport=@IsFreePPHTransport, " & vbNewLine &
                        "   IsUseSubItem=@IsUseSubItem, " & vbNewLine &
                        "   IsStock=@IsStock, " & vbNewLine &
                        "   BPLocationID=@BPLocationID, " & vbNewLine &
                        "   CoAofStock=@CoAofStock " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@DeliveryNumber", SqlDbType.VarChar, 100).Value = clsData.DeliveryNumber
                .Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = clsData.DeliveryDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@SCID", SqlDbType.VarChar, 100).Value = clsData.SCID
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
                .Parameters.Add("@TotalDPPTransport", SqlDbType.Decimal).Value = clsData.TotalDPPTransport
                .Parameters.Add("@TotalPPNTransport", SqlDbType.Decimal).Value = clsData.TotalPPNTransport
                .Parameters.Add("@TotalPPHTransport", SqlDbType.Decimal).Value = clsData.TotalPPHTransport
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@TotalCostRawMaterial", SqlDbType.Decimal).Value = clsData.TotalCostRawMaterial
                .Parameters.Add("@TransporterID", SqlDbType.Int).Value = clsData.TransporterID
                .Parameters.Add("@UnitPriceTransport", SqlDbType.Decimal).Value = clsData.UnitPriceTransport
                .Parameters.Add("@PPNTransport", SqlDbType.Decimal).Value = clsData.PPNTransport
                .Parameters.Add("@PPHTransport", SqlDbType.Decimal).Value = clsData.PPHTransport
                .Parameters.Add("@IsFreePPNTransport", SqlDbType.Bit).Value = clsData.IsFreePPNTransport
                .Parameters.Add("@IsFreePPHTransport", SqlDbType.Bit).Value = clsData.IsFreePPHTransport
                .Parameters.Add("@IsUseSubItem", SqlDbType.Bit).Value = clsData.IsUseSubItem
                .Parameters.Add("@IsStock", SqlDbType.Bit).Value = clsData.IsStock
                .Parameters.Add("@BPLocationID", SqlDbType.Int).Value = clsData.BPLocationID
                .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = clsData.CoAofStock
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.Delivery
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.Delivery
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ProgramID, A.CompanyID, A.DeliveryNumber, A.DeliveryDate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.SCID, " & vbNewLine &
                        "   ISNULL(A1.SCNumber,A2.OrderNumber) AS SCNumber, A.PlatNumber, A.Driver, A.ReferencesNumber, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, " & vbNewLine &
                        "   A.TotalPPN, A.TotalPPH, A.TotalDPPTransport, A.TotalPPNTransport, A.TotalPPHTransport, A.RoundingManual, A.IsDeleted, A.Remarks, " & vbNewLine &
                        "   A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment, " & vbNewLine &
                        "   A.JournalID, A.JournalIDTransport, A.TotalCostRawMaterial, A.TransporterID, TP.Code AS TransporterCode, TP.Name AS TransporterName, " & vbNewLine &
                        "   A.UnitPriceTransport, A.PPNTransport, A.PPHTransport, A.IsFreePPNTransport, A.IsFreePPHTransport, A.IsUseSubItem, A.IsStock, " & vbNewLine &
                        "   A.BPLocationID, BPLocationName=BPL.Address, A.CoAofStock, COA.Code AS CoACodeofStock, COA.Name AS CoANameofStock, A.DPAmountTransport, A.TotalPaymentTransport " & vbNewLine &
                        "FROM traDelivery A " & vbNewLine &
                        "LEFT JOIN traSalesContract A1 ON " & vbNewLine &
                        "   A.SCID=A1.ID " & vbNewLine &
                        "LEFT JOIN traOrderRequest A2 ON " & vbNewLine &
                        "   A.SCID=A2.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine &
                        "   A.BPID=B.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartner TP ON " & vbNewLine &
                        "   A.TransporterID=TP.ID " & vbNewLine &
                        "INNER JOIN mstBusinessPartnerLocation BPL ON " & vbNewLine &
                        "   A.BPLocationID=BPL.ID " & vbNewLine &
                        "INNER JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "   A.CoAofStock=COA.ID " & vbNewLine &
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
                        voReturn.DeliveryNumber = .Item("DeliveryNumber")
                        voReturn.DeliveryDate = .Item("DeliveryDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.SCID = .Item("SCID")
                        voReturn.SCNumber = .Item("SCNumber")
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
                        voReturn.TotalDPPTransport = .Item("TotalDPPTransport")
                        voReturn.TotalPPNTransport = .Item("TotalPPNTransport")
                        voReturn.TotalPPHTransport = .Item("TotalPPHTransport")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.IsDeleted = .Item("IsDeleted")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.SubmitBy = .Item("SubmitBy")
                        voReturn.SubmitDate = .Item("SubmitDate")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.TotalPayment = .Item("TotalPayment")
                        voReturn.JournalID = .Item("JournalID")
                        voReturn.JournalIDTransport = .Item("JournalIDTransport")
                        voReturn.TotalCostRawMaterial = .Item("TotalCostRawMaterial")
                        voReturn.TransporterID = .Item("TransporterID")
                        voReturn.TransporterCode = .Item("TransporterCode")
                        voReturn.TransporterName = .Item("TransporterName")
                        voReturn.UnitPriceTransport = .Item("UnitPriceTransport")
                        voReturn.PPNTransport = .Item("PPNTransport")
                        voReturn.PPHTransport = .Item("PPHTransport")
                        voReturn.IsFreePPNTransport = .Item("IsFreePPNTransport")
                        voReturn.IsFreePPHTransport = .Item("IsFreePPHTransport")
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
                        voReturn.IsStock = .Item("IsStock")
                        voReturn.BPLocationID = .Item("BPLocationID")
                        voReturn.BPLocationName = .Item("BPLocationName")
                        voReturn.CoAofStock = .Item("CoAofStock")
                        voReturn.CoACodeOfStock = .Item("CoACodeofStock")
                        voReturn.CoANameOfStock = .Item("CoANameOfStock")
                        voReturn.DPAmountTransport = .Item("DPAmountTransport")
                        voReturn.TotalPaymentTransport = .Item("TotalPaymentTransport")
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
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET " & vbNewLine &
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
                        "FROM traDelivery " & vbNewLine &
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
                                          ByVal strDeliveryNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traDelivery " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   DeliveryNumber=@DeliveryNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@DeliveryNumber", SqlDbType.VarChar, 100).Value = strDeliveryNumber
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
                        "FROM traDelivery " & vbNewLine &
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
                        "FROM traDelivery " & vbNewLine &
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
                    "UPDATE traDelivery SET " & vbNewLine &
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
                    "UPDATE traDelivery SET " & vbNewLine &
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

        Public Shared Function PrintVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                          ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText +=
                    "SELECT  " & vbNewLine &
                    "   DH.ID, DH.ProgramID, MP.Name AS ProgramName, DH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress, DH.DeliveryNumber AS TransNumber,  " & vbNewLine &
                    "   DH.DeliveryDate AS TransDate, DH.BPID, C.Code AS BPCode, C.Name AS BPName, BPL.Address AS BPAddress, SCH.SCNumber, DH.PlatNumber, DH.Driver, DH.ReferencesNumber, " & vbNewLine &
                    "   DH.TotalQuantity, DH.TotalWeight, DH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, CASE WHEN MI.ItemCodeExternal='' THEN IT.Description ELSE MI.ItemCodeExternal END AS ItemCodeExternal, MI.Thick AS ItemThick, MI.Width AS ItemWidth,  " & vbNewLine &
                    "   CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength, MI.Weight, DD.Quantity, DD.TotalWeight AS TotalWeightItem, DD.Remarks AS ItemRemarks, MU.Name AS CreatedBy " & vbNewLine &
                    "FROM traDelivery DH  " & vbNewLine &
                    "INNER JOIN traSalesContract SCH ON " & vbNewLine &
                    "	DH.SCID=SCH.ID " & vbNewLine &
                    "INNER JOIN traDeliveryDet DD ON  " & vbNewLine &
                    "    DH.ID=DD.DeliveryID " & vbNewLine &
                    "INNER JOIN mstStatus B ON  " & vbNewLine &
                    "    DH.StatusID=B.ID  " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON  " & vbNewLine &
                    "    DH.BPID=C.ID  " & vbNewLine &
                    "INNER JOIN mstCompany MC ON  " & vbNewLine &
                    "    DH.CompanyID=MC.ID  " & vbNewLine &
                    "INNER JOIN mstProgram MP ON  " & vbNewLine &
                    "    DH.ProgramID=MP.ID  " & vbNewLine &
                    "INNER JOIN mstItem MI ON 	   " & vbNewLine &
                    "    DD.ItemID=MI.ID 	   " & vbNewLine &
                    "INNER JOIN mstItemType IT ON 	 	   " & vbNewLine &
                    "    MI.ItemTypeID=IT.ID 	 	   " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON 	 	   " & vbNewLine &
                    "    MI.ItemSpecificationID=MIS.ID 	 	   " & vbNewLine &
                    "INNER JOIN mstBusinessPartnerLocation BPL ON 	 	   " & vbNewLine &
                    "    DH.BPLocationID=BPL.ID 	 	   " & vbNewLine &
                    "INNER JOIN mstUser MU ON 	 	   " & vbNewLine &
                    "    DH.CreatedBy=MU.ID 	 	   " & vbNewLine &
                    "WHERE 	 " & vbNewLine &
                    "    DH.ProgramID=@ProgramID  " & vbNewLine &
                    "    AND DH.CompanyID=@CompanyID  " & vbNewLine &
                    "    AND DH.ID=@ID" & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT  " & vbNewLine &
                    "   DH.ID, DH.ProgramID, MP.Name AS ProgramName, DH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress, DH.DeliveryNumber AS TransNumber,  " & vbNewLine &
                    "   DH.DeliveryDate AS TransDate, DH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ORH.OrderNumber AS SCNumber, DH.PlatNumber, DH.Driver, DH.ReferencesNumber, " & vbNewLine &
                    "   DH.TotalQuantity, DH.TotalWeight, DH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, IT.Description AS ItemCodeExternal, MI.Thick AS ItemThick, MI.Width AS ItemWidth,  " & vbNewLine &
                    "   CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength, MI.Weight, DD.Quantity, DD.TotalWeight AS TotalWeightItem, DD.Remarks AS ItemRemarks, DH.CreatedBy " & vbNewLine &
                    "FROM traDelivery DH  " & vbNewLine &
                    "INNER JOIN traOrderRequest ORH ON " & vbNewLine &
                    "	DH.SCID=ORH.ID " & vbNewLine &
                    "INNER JOIN traDeliveryDet DD ON  " & vbNewLine &
                    "    DH.ID=DD.DeliveryID " & vbNewLine &
                    "INNER JOIN mstStatus B ON  " & vbNewLine &
                    "    DH.StatusID=B.ID  " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON  " & vbNewLine &
                    "    DH.BPID=C.ID  " & vbNewLine &
                    "INNER JOIN mstCompany MC ON  " & vbNewLine &
                    "    DH.CompanyID=MC.ID  " & vbNewLine &
                    "INNER JOIN mstProgram MP ON  " & vbNewLine &
                    "    DH.ProgramID=MP.ID  " & vbNewLine &
                    "INNER JOIN mstItem MI ON 	   " & vbNewLine &
                    "    DD.ItemID=MI.ID 	   " & vbNewLine &
                    "INNER JOIN mstItemType IT ON 	 	   " & vbNewLine &
                    "    MI.ItemTypeID=IT.ID 	 	   " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON 	 	   " & vbNewLine &
                    "    MI.ItemSpecificationID=MIS.ID 	 	   " & vbNewLine &
                    "WHERE 	 " & vbNewLine &
                    "    DH.ProgramID=@ProgramID  " & vbNewLine &
                    "    AND DH.CompanyID=@CompanyID  " & vbNewLine &
                    "    AND DH.ID=@ID" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub CalculateTotalUsedReceivePayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal strID As String, ByVal strModules As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.DPAmount),0) DPAmount		" & vbNewLine &
                    "		FROM traAccountReceivableDet ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ARID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.SalesID=@ID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPayment=	" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = strModules
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceivePaymentVer1(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                               ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.DPAmount),0) DPAmount		" & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "			AND TDD.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPayment=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmount),0) DeliveryAmount		" & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "			AND TDD.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPN),0) DeliveryAmount		" & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "			AND TDD.ParentID='' " & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPH),0) DeliveryAmount		" & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "			AND TDD.ParentID='' " & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedReceivePaymentSubItemVer1(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                       ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.DPAmount),0) DPAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPayment=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmount),0) DeliveryAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPN),0) DeliveryAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPH),0) DeliveryAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedReceivePaymentTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                    ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET 	" & vbNewLine &
                    "	DPAmountTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmount),0) DPAmount		" & vbNewLine &
                    "		FROM traAccountPayableDet APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.APID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.PurchaseID=@ID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentTransport=	" & vbNewLine &
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
                    "	TotalPaymentPPNTransport=	" & vbNewLine &
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
                    "	TotalPaymentPPHTransport=	" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentTransport
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceivePaymentTransportVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                         ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET 	" & vbNewLine &
                    "	TotalPaymentTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountTransport),0) TotalPayment		" & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPNTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPNTransport),0) TotalPayment		" & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	TotalPaymentPPHTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPHTransport),0) TotalPayment		" & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.DeliveryID=@ID 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentTransport
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateItemTotalUsedReceivePayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                               ByVal strReferencesID As String, ByVal strReferencesDetailID As String,
                                                               ByVal strModules As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDeliveryDet SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.DPAmount),0) DPAmount" & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.Amount),0) TotalPayment " & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.PPN),0) TotalPayment " & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.PPH),0) TotalPayment " & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = strModules
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
                    "UPDATE traDeliveryDet SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.DPAmount),0) DPAmount" & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ID " & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmount),0) TotalPayment " & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ID " & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPN),0) TotalPayment " & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ID " & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPH),0) TotalPayment " & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.ParentID=@ID " & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	) " & vbNewLine &
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

        Public Shared Sub CalculateItemTotalUsedReceivePaymentTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                        ByVal strReferencesID As String, ByVal strReferencesDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDeliveryDet SET 	" & vbNewLine &
                    "	DPAmountTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.DPAmount),0) DPAmount" & vbNewLine &
                    "		FROM traARAPItem APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.ParentID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND APD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.Amount),0) TotalPayment " & vbNewLine &
                    "		FROM traARAPItem APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.ParentID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND APD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPNTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.PPN),0) TotalPayment " & vbNewLine &
                    "		FROM traARAPItem APD 	" & vbNewLine &
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine &
                    "			APD.ParentID=APH.ID 	" & vbNewLine &
                    "			AND APH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			APD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND APD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND APH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPHTransport=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(APD.PPH),0) TotalPayment " & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentTransport
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentTransportVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                             ByVal strDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDeliveryDet SET 	" & vbNewLine &
                    "	AllocateDPAmountTransport=	" & vbNewLine &
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
                    "	ReceiveAmountTransport=	" & vbNewLine &
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
                    "	ReceiveAmountPPNTransport=	" & vbNewLine &
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
                    "	ReceiveAmountPPHTransport=	" & vbNewLine &
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
                    "	InvoiceQuantityTransport=	" & vbNewLine &
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
                    "	InvoiceTotalWeightTransport=	" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountPayable.ReceivePaymentTransport
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String,
                                          ByVal decTotalCostRawMaterial As Decimal)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET " & vbNewLine &
                    "    JournalID=@JournalID, " & vbNewLine &
                    "    TotalCostRawMaterial=@TotalCostRawMaterial " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@JournalID", SqlDbType.VarChar, 100).Value = strJournalID
                .Parameters.Add("@TotalCostRawMaterial", SqlDbType.Decimal).Value = decTotalCostRawMaterial
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateJournalIDTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDelivery SET " & vbNewLine &
                    "    JournalIDTransport=@JournalID " & vbNewLine &
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

        Public Shared Sub UpdateJournalIDDeliveryTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDeliveryTransport SET " & vbNewLine &
                    "    JournalID=@JournalID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    DeliveryID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@JournalID", SqlDbType.VarChar, 100).Value = strJournalID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetTotalCostRawMaterial(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal strID As String) As Decimal
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Decimal = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT  " & vbNewLine &
                        "	ISNULL(SUM(DD.TotalWeight*ISNULL(SCD.UnitPriceHPP,ORD.UnitPriceHPP)),0) AS TotalCostRawMaterial " & vbNewLine &
                        "FROM traDeliveryDet DD  " & vbNewLine &
                        "LEFT JOIN traSalesContractDet SCD ON  " & vbNewLine &
                        "	DD.SCDetailID=SCD.ID  " & vbNewLine &
                        "LEFT JOIN traOrderRequestDet ORD ON  " & vbNewLine &
                        "	DD.SCDetailID=ORD.ID  " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   DD.DeliveryID=@DeliveryID " & vbNewLine

                    .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        decReturn = .Item("TotalCostRawMaterial")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return decReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strDeliveryID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.DeliveryID, A.SCDetailID, A2.SCNumber, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.DCWeight AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A3.CoAofStock " & vbNewLine &
                    "FROM traDeliveryDet A " & vbNewLine &
                    "INNER JOIN traSalesContractDet A1 ON " & vbNewLine &
                    "   A.SCDetailID=A1.ID " & vbNewLine &
                    "INNER JOIN traSalesContract A2 ON " & vbNewLine &
                    "   A1.SCID=A2.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "INNER JOIN traDelivery A3 ON " & vbNewLine &
                    "   A.DeliveryID=A3.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.DeliveryID=@DeliveryID " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   A.ID, A.DeliveryID, A.SCDetailID, A2.OrderNumber AS SCNumber, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.SCWeight AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A3.CoAofStock " & vbNewLine &
                    "FROM traDeliveryDet A " & vbNewLine &
                    "INNER JOIN traOrderRequestDet A1 ON " & vbNewLine &
                    "   A.SCDetailID=A1.ID " & vbNewLine &
                    "INNER JOIN traOrderRequest A2 ON " & vbNewLine &
                    "   A1.OrderRequestID=A2.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "INNER JOIN traDelivery A3 ON " & vbNewLine &
                    "   A.DeliveryID=A3.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.DeliveryID=@DeliveryID " & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingSalesReturnItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                        ByVal strDeliveryID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.DeliveryID, A1.DeliveryNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A.TotalWeight-A.ReturnWeight AS MaxTotalWeight, " & vbNewLine &
                    "   A.Remarks, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, SCD.UnitPriceHPP " & vbNewLine &
                    "FROM traDeliveryDet A " & vbNewLine &
                    "INNER JOIN traDelivery A1 ON " & vbNewLine &
                    "   A.DeliveryID=A1.ID " & vbNewLine &
                    "INNER JOIN traSalesContractDet SCD ON " & vbNewLine &
                    "   A.SCDetailID=SCD.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.DeliveryID=@DeliveryID " & vbNewLine &
                    "   AND A.TotalWeight-A.ReturnWeight>0 " & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailBySCDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal strSCDetailID As String, ByVal intItemID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID AS DeliveryDetailID " & vbNewLine &
                    "FROM traDeliveryDet A " & vbNewLine &
                    "INNER JOIN traDelivery A1 ON " & vbNewLine &
                    "   A.DeliveryID=A1.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.SCDetailID=@SCDetailID " & vbNewLine &
                    "   AND A.ItemID=@ItemID " & vbNewLine

                .Parameters.Add("@SCDetailID", SqlDbType.VarChar, 100).Value = strSCDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.DeliveryDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traDeliveryDet " & vbNewLine &
                    "   (ID, DeliveryID, SCDetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, OrderNumberSupplier, UnitPriceTransport, TotalPriceTransport, LevelItem, ParentID, RoundingWeight) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @DeliveryID, @SCDetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @OrderNumberSupplier, @UnitPriceTransport, @TotalPriceTransport, @LevelItem, @ParentID, @RoundingWeight) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = clsData.DeliveryID
                .Parameters.Add("@SCDetailID", SqlDbType.VarChar, 100).Value = clsData.SCDetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@UnitPriceTransport", SqlDbType.Decimal).Value = clsData.UnitPriceTransport
                .Parameters.Add("@TotalPriceTransport", SqlDbType.Decimal).Value = clsData.TotalPriceTransport
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strDeliveryID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traDeliveryDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   DeliveryID=@DeliveryID" & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateReturnTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strDeliveryDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traDeliveryDet SET 	" & vbNewLine &
                    "	ReturnWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SRD.TotalWeight+SRD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traSalesReturnDet SRD 	" & vbNewLine &
                    "		INNER JOIN traSalesReturn SRH ON	" & vbNewLine &
                    "			SRD.SalesReturnID=SRH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SRD.DeliveryDetailID=@DeliveryDetailID 	" & vbNewLine &
                    "			AND SRH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	ReturnQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SRD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traSalesReturnDet SRD 	" & vbNewLine &
                    "		INNER JOIN traSalesReturn SRH ON	" & vbNewLine &
                    "			SRD.SalesReturnID=SRH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SRD.DeliveryDetailID=@DeliveryDetailID 	" & vbNewLine &
                    "			AND SRH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@DeliveryDetailID	" & vbNewLine

                .Parameters.Add("@DeliveryDetailID", SqlDbType.VarChar, 100).Value = strDeliveryDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub ChangeItemIDDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strSCDetailID As String, ByVal intOldItemID As Integer, ByVal intNewItemID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traDeliveryDet SET  " & vbNewLine &
"	ItemID=@NewItemID " & vbNewLine &
"WHERE " & vbNewLine &
"	ItemID=@OldItemID " & vbNewLine &
"	AND SCDetailID=@SCDetailID " & vbNewLine

                .Parameters.Add("@SCDetailID", SqlDbType.VarChar, 100).Value = strSCDetailID
                .Parameters.Add("@OldItemID", SqlDbType.Int).Value = intOldItemID
                .Parameters.Add("@NewItemID", SqlDbType.Int).Value = intNewItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

#End Region

#Region "Delivery Transport"

        Public Shared Function ListDataDeliveryTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                         ByVal strDeliveryID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT  " & vbNewLine & _
                    "	A.ID, A.DeliveryID, A.DeliveryNumber, A.POID, A.BPID, A.PPN,  " & vbNewLine & _
                    "	A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH,  " & vbNewLine & _
                    "	A.RoundingManual, A.Remarks, A.DPAmount, A.TotalPayment, A.JournalID " & vbNewLine & _
                    "FROM traDeliveryTransport A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.DeliveryID=@DeliveryID " & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDeliveryTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal clsData As VO.DeliveryTransport)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traDeliveryTransport " & vbNewLine & _
                    "	(ID, DeliveryID, DeliveryNumber, POID, BPID, PPN,  " & vbNewLine & _
                    "	 PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH,  " & vbNewLine & _
                    "	 RoundingManual, Remarks, DPAmount, TotalPayment, JournalID) " & vbNewLine & _
                    "VALUES  " & vbNewLine & _
                    "	(@ID, @DeliveryID, @DeliveryNumber, @POID, @BPID, @PPN,  " & vbNewLine & _
                    "	 @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH,  " & vbNewLine & _
                    "	 @RoundingManual, @Remarks, @DPAmount, @TotalPayment, @JournalID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = clsData.DeliveryID
                .Parameters.Add("@DeliveryNumber", SqlDbType.VarChar, 100).Value = clsData.DeliveryNumber
                .Parameters.Add("@POID", SqlDbType.VarChar, 100).Value = clsData.POID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@TotalPayment", SqlDbType.Decimal).Value = clsData.TotalPayment
                .Parameters.Add("@JournalID", SqlDbType.VarChar, 100).Value = clsData.JournalID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDeliveryTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strDeliveryID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traDeliveryTransport     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   DeliveryID=@DeliveryID" & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail Transport"

        Public Shared Function ListDataDetailTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal strDeliveryID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.DeliveryID, A.PODetailID, A1.POID, A2.PONumber, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.DoneWeight AS MaxTotalWeight, A.Remarks, " & vbNewLine &
                    "   A2.BPID, A2.PPN, A2.PPH " & vbNewLine &
                    "FROM traDeliveryDetTransport A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderTransportDet A1 ON " & vbNewLine &
                    "   A.PODetailID=A1.ID " & vbNewLine &
                    "INNER JOIN traPurchaseOrderTransport A2 ON " & vbNewLine &
                    "   A1.POID=A2.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.DeliveryID=@DeliveryID " & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetailTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal clsData As VO.DeliveryDetTransport)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traDeliveryDetTransport " & vbNewLine &
                    "   (ID, DeliveryID, PODetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @DeliveryID, @PODetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = clsData.DeliveryID
                .Parameters.Add("@PODetailID", SqlDbType.VarChar, 100).Value = clsData.PODetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
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

        Public Shared Sub DeleteDataDetailTransport(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strDeliveryID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traDeliveryDetTransport     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   DeliveryID=@DeliveryID" & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
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
                                              ByVal strDeliveryID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.DeliveryID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traDeliveryStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.DeliveryID=@DeliveryID " & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.DeliveryStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traDeliveryStatus " & vbNewLine &
                    "   (ID, DeliveryID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @DeliveryID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = clsData.DeliveryID
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
                                              ByVal strDeliveryID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traDeliveryStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   DeliveryID=@DeliveryID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
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