Namespace DL
    Public Class Delivery

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
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.DeliveryNumber, A.DeliveryDate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.SCID, A1.SCNumber, A.PlatNumber, A.Driver, A.ReferencesNumber, A.PPN, " & vbNewLine &
                    "   A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.TotalDPPTransport, A.TotalPPNTransport, A.TotalPPHTransport, A.TotalDPPTransport+TotalPPNTransport+A.TotalPPHTransport AS GrandTotalTransport, " & vbNewLine &
                    "   A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, " & vbNewLine &
                    "   A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, StatusInfo=B.Name " & vbNewLine &
                    "FROM traDelivery A " & vbNewLine &
                    "INNER JOIN traSalesContract A1 ON " & vbNewLine &
                    "   A.SCID=A1.ID " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.DeliveryDate>=@DateFrom AND A.DeliveryDate<=@DateTo " & vbNewLine

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
                        "    TotalPPHTransport, RoundingManual, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @DeliveryNumber, @DeliveryDate, @BPID, @SCID, @PlatNumber, @Driver, @ReferencesNumber, " & vbNewLine &
                        "    @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @TotalDPPTransport, @TotalPPNTransport, " & vbNewLine &
                        "    @TotalPPHTransport, @RoundingManual, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine
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
                        "   LogDate=GETDATE() " & vbNewLine &
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
                        "   A.ID, A.ProgramID, A.CompanyID, A.DeliveryNumber, A.DeliveryDate, A.BPID, B.Code AS BPCode, B.Name AS BPName, " & vbNewLine &
                        "   A.SCID, A1.SCNumber, A.PlatNumber, A.Driver, A.ReferencesNumber, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, " & vbNewLine &
                        "   A.TotalPPN, A.TotalPPH, A.TotalDPPTransport, A.TotalPPNTransport, A.TotalPPHTransport, A.RoundingManual, A.IsDeleted, A.Remarks, " & vbNewLine &
                        "   A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment " & vbNewLine &
                        "FROM traDelivery A " & vbNewLine &
                        "INNER JOIN traSalesContract A1 ON " & vbNewLine &
                        "   A.SCID=A1.ID " & vbNewLine &
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
                .CommandText =
                    "SELECT  " & vbNewLine &
                    "   DH.ID, DH.ProgramID, MP.Name AS ProgramName, DH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress, DH.DeliveryNumber AS TransNumber,  " & vbNewLine &
                    "   DH.DeliveryDate AS TransDate, DH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, SCH.SCNumber, DH.PlatNumber, DH.Driver, DH.ReferencesNumber, " & vbNewLine &
                    "   DH.TotalQuantity, DH.TotalWeight, DH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, MI.ItemCodeExternal, MI.Thick AS ItemThick, MI.Width AS ItemWidth,  " & vbNewLine &
                    "   MI.Length AS ItemLength, MI.Weight, DD.Quantity, DD.TotalWeight AS TotalWeightItem, DD.Remarks AS ItemRemarks, DH.CreatedBy " & vbNewLine &
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
                    "INNER JOIN mstCompanyBankAccount MBC ON  " & vbNewLine &
                    "    SCH.CompanyBankAccountID=MBC.ID " & vbNewLine &
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
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.DCWeight AS MaxTotalWeight, A.Remarks " & vbNewLine &
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
                    "WHERE " & vbNewLine &
                    "   A.DeliveryID=@DeliveryID " & vbNewLine

                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = strDeliveryID
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
                    "   (ID, DeliveryID, SCDetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @DeliveryID, @SCDetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks) " & vbNewLine

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
                    "	A.ID, A.ProgramID, A.CompanyID, A.DeliveryID, A.POID, A.BPID, A.PPN,  " & vbNewLine & _
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
                    "	(ID, ProgramID, CompanyID, DeliveryID, POID, BPID, PPN,  " & vbNewLine & _
                    "	 PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH,  " & vbNewLine & _
                    "	 RoundingManual, Remarks, DPAmount, TotalPayment, JournalID) " & vbNewLine & _
                    "VALUES  " & vbNewLine & _
                    "	(@ID, @ProgramID, @CompanyID, @DeliveryID, @POID, @BPID, @PPN,  " & vbNewLine & _
                    "	 @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH,  " & vbNewLine & _
                    "	 @RoundingManual, @Remarks, @DPAmount, @TotalPayment, @JournalID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@DeliveryID", SqlDbType.VarChar, 100).Value = clsData.DeliveryID
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