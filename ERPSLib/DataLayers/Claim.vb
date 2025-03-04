Namespace DL

    Public Class Claim

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal intClaimType As VO.Claim.ClaimTypeValue) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText +=
                    "SELECT  " & vbNewLine &
                    "	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.ClaimType, A.ClaimNumber, A.ClaimDate, " & vbNewLine &
                    "	A.BPID, C.Code AS BPCode, C.Name AS BPName, A.ReferencesID, A.PlatNumber, A.Driver, A1.SCNumber AS ReferencesNumber, A.PPN, A.PPH,  " & vbNewLine &
                    "	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, GrandTotal=A.TotalDPP+A.TotalPPN-A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine &
                    "	StatusInfo=B.Name, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy,  " & vbNewLine &
                    "	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment, A.JournalID, A.IsUseSubItem, A.DPAmountPPN, " & vbNewLine &
                    "   A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH, A.ItemDescription " & vbNewLine &
                    "FROM traClaim A " & vbNewLine &
                    "INNER JOIN traSalesContract A1 ON " & vbNewLine &
                    "   A.ReferencesID=A1.ID " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ClaimDate>=@DateFrom AND A.ClaimDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine
                If intClaimType <> VO.Claim.ClaimTypeValue.All Then .CommandText += "   AND A.ClaimType=@ClaimType " & vbNewLine

                .CommandText +=
                    "UNION ALL " & vbNewLine &
                    "SELECT  " & vbNewLine &
                    "	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.ClaimType, A.ClaimNumber, A.ClaimDate, " & vbNewLine &
                    "	A.BPID, C.Code AS BPCode, C.Name AS BPName, A.ReferencesID, A.PlatNumber, A.Driver, A1.ReceiveNumber AS ReferencesNumber, A.PPN, A.PPH,  " & vbNewLine &
                    "	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, GrandTotal=A.TotalDPP+A.TotalPPN-A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine &
                    "	StatusInfo=B.Name, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy,  " & vbNewLine &
                    "	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment, A.JournalID, A.IsUseSubItem, A.DPAmountPPN, " & vbNewLine &
                    "   A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH, A.ItemDescription " & vbNewLine &
                    "FROM traClaim A " & vbNewLine &
                    "INNER JOIN traReceive A1 ON " & vbNewLine &
                    "   A.ReferencesID=A1.ID " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ClaimDate>=@DateFrom AND A.ClaimDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine
                If intClaimType <> VO.Claim.ClaimTypeValue.All Then .CommandText += "   AND A.ClaimType=@ClaimType " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
                .Parameters.Add("@ClaimType", SqlDbType.Int).Value = intClaimType
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstandingConfirmationClaim(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                    ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                    ByVal intBPID As Integer, ByVal intClaimType As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.ClaimNumber AS TransactionNumber, CASE WHEN A.ReferencesNumber='' THEN A.ClaimNumber ELSE A.ReferencesNumber END AS ReferencesNumber, " & vbNewLine &
                    "   A.ClaimDate AS ReferencesDate, A.BPID, MBP.Code AS BPCode, MBP.Name AS BPName, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH AS GrandTotal, A.Remarks, A.PPN, A.PPH " & vbNewLine &
                    "FROM traClaim A " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner MBP ON " & vbNewLine &
                    "   A.BPID=MBP.ID " & vbNewLine &
                    "INNER JOIN traClaimDet A1 ON " & vbNewLine &
                    "   A.ID=A1.ClaimID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.BPID=@BPID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.StatusID=@StatusID " & vbNewLine &
                    "   AND A.ClaimType=@ClaimType " & vbNewLine &
                    "   AND A1.TotalWeight-A1.ConfirmationWeight>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@ClaimType", SqlDbType.Int).Value = intClaimType
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.Claim)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traClaim " & vbNewLine &
"	(ID, ProgramID, CompanyID, ClaimType, ClaimNumber, ClaimDate, BPID,  " & vbNewLine &
"	 ReferencesID, PlatNumber, Driver, ReferencesNumber, PPN, PPH,  " & vbNewLine &
"	 TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual,  " & vbNewLine &
"	 Remarks, StatusID, CreatedBy, LogBy, IsUseSubItem, ItemDescription) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ProgramID, @CompanyID, @ClaimType, @ClaimNumber, @ClaimDate, @BPID,  " & vbNewLine &
"	 @ReferencesID, @PlatNumber, @Driver, @ReferencesNumber, @PPN, @PPH,  " & vbNewLine &
"	 @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual,  " & vbNewLine &
"	 @Remarks, @StatusID, @LogBy, @LogBy, @IsUseSubItem, @ItemDescription) " & vbNewLine

                Else
                    .CommandText =
"UPDATE traClaim SET  " & vbNewLine &
"	ProgramID=@ProgramID,  " & vbNewLine &
"	CompanyID=@CompanyID,  " & vbNewLine &
"	ClaimType=@ClaimType,  " & vbNewLine &
"	ClaimNumber=@ClaimNumber,  " & vbNewLine &
"	ClaimDate=@ClaimDate,  " & vbNewLine &
"	BPID=@BPID,  " & vbNewLine &
"	ReferencesID=@ReferencesID,  " & vbNewLine &
"	PlatNumber=@PlatNumber,  " & vbNewLine &
"	Driver=@Driver,  " & vbNewLine &
"	ReferencesNumber=@ReferencesNumber,  " & vbNewLine &
"	PPN=@PPN,  " & vbNewLine &
"	PPH=@PPH,  " & vbNewLine &
"	TotalQuantity=@TotalQuantity,  " & vbNewLine &
"	TotalWeight=@TotalWeight,  " & vbNewLine &
"	TotalDPP=@TotalDPP,  " & vbNewLine &
"	TotalPPN=@TotalPPN,  " & vbNewLine &
"	TotalPPH=@TotalPPH,  " & vbNewLine &
"	RoundingManual=@RoundingManual,  " & vbNewLine &
"	Remarks=@Remarks,  " & vbNewLine &
"	StatusID=@StatusID,  " & vbNewLine &
"	LogInc=LogInc+1,  " & vbNewLine &
"	LogBy=@LogBy,  " & vbNewLine &
"	LogDate=GETDATE(),  " & vbNewLine &
"	IsUseSubItem=@IsUseSubItem, " & vbNewLine &
"	ItemDescription=@ItemDescription " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ClaimType", SqlDbType.Int).Value = clsData.ClaimType
                .Parameters.Add("@ClaimNumber", SqlDbType.VarChar, 100).Value = clsData.ClaimNumber
                .Parameters.Add("@ClaimDate", SqlDbType.DateTime).Value = clsData.ClaimDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = clsData.ReferencesID
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
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@IsUseSubItem", SqlDbType.Bit).Value = clsData.IsUseSubItem
                .Parameters.Add("@ItemDescription", SqlDbType.VarChar, 5000).Value = clsData.ItemDescription
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.Claim
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.Claim
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText +=
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.ClaimType, A.ClaimNumber, A.ClaimDate, A.BPID,  " & vbNewLine &
"	B.Code AS BPCode, B.Name AS BPName, A.ReferencesID, A.PlatNumber, A.Driver, A1.SCNumber AS ReferencesNumber, A.PPN, A.PPH,  " & vbNewLine &
"	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual,  " & vbNewLine &
"	A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy,  " & vbNewLine &
"	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment,  " & vbNewLine &
"	A.JournalID, A.IsUseSubItem, A.DPAmountPPN, A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH, A.ItemDescription " & vbNewLine &
"FROM traClaim A " & vbNewLine &
"INNER JOIN traSalesContract A1 ON " & vbNewLine &
"   A.ReferencesID=A1.ID " & vbNewLine &
"INNER JOIN mstCompany MC ON " & vbNewLine &
"   A.CompanyID=MC.ID " & vbNewLine &
"INNER JOIN mstProgram MP ON " & vbNewLine &
"   A.ProgramID=MP.ID " & vbNewLine &
"INNER JOIN mstBusinessPartner B ON " & vbNewLine &
"   A.BPID=B.ID " & vbNewLine &
"WHERE " & vbNewLine &
"	A.ID=@ID " & vbNewLine

                    .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.ClaimType, A.ClaimNumber, A.ClaimDate, A.BPID,  " & vbNewLine &
"	B.Code AS BPCode, B.Name AS BPName, A.ReferencesID, A.PlatNumber, A.Driver, A1.ReceiveNumber AS ReferencesNumber, A.PPN, A.PPH,  " & vbNewLine &
"	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual,  " & vbNewLine &
"	A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy,  " & vbNewLine &
"	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment,  " & vbNewLine &
"	A.JournalID, A.IsUseSubItem, A.DPAmountPPN, A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH, A.ItemDescription " & vbNewLine &
"FROM traClaim A " & vbNewLine &
"INNER JOIN traReceive A1 ON " & vbNewLine &
"   A.ReferencesID=A1.ID " & vbNewLine &
"INNER JOIN mstCompany MC ON " & vbNewLine &
"   A.CompanyID=MC.ID " & vbNewLine &
"INNER JOIN mstProgram MP ON " & vbNewLine &
"   A.ProgramID=MP.ID " & vbNewLine &
"INNER JOIN mstBusinessPartner B ON " & vbNewLine &
"   A.BPID=B.ID " & vbNewLine &
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
                        voReturn.ClaimType = .Item("ClaimType")
                        voReturn.ClaimNumber = .Item("ClaimNumber")
                        voReturn.ClaimDate = .Item("ClaimDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.ReferencesID = .Item("ReferencesID")
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
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
                        voReturn.DPAmountPPN = .Item("DPAmountPPN")
                        voReturn.DPAmountPPH = .Item("DPAmountPPH")
                        voReturn.TotalPaymentPPN = .Item("TotalPaymentPPN")
                        voReturn.TotalPaymentPPH = .Item("TotalPaymentPPH")
                        voReturn.ItemDescription = .Item("ItemDescription")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
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
                    "UPDATE traClaim SET " & vbNewLine &
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
                        "FROM traClaim " & vbNewLine &
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
                                          ByVal strClaimNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traClaim " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ClaimNumber=@ClaimNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@ClaimNumber", SqlDbType.VarChar, 100).Value = strClaimNumber
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
                        "FROM traClaim " & vbNewLine &
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
                        "FROM traClaim " & vbNewLine &
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
                    "UPDATE traClaim SET " & vbNewLine &
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
                    "UPDATE traClaim SET " & vbNewLine &
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

        Public Shared Function IsConfirmation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   CH.ID " & vbNewLine &
                        "FROM traClaim CH " & vbNewLine &
                        "INNER JOIN traClaimDet CD ON " & vbNewLine &
                        "   CH.ID=CD.ClaimID " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   CH.ID=@ID " & vbNewLine &
                        "   AND (CD.ConfirmationQuantity>0 OR CD.ConfirmationWeight>0) " & vbNewLine

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
                                              ByVal strClaimID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText +=
"SELECT  " & vbNewLine &
"	A.ID, A.ClaimID, A.ReferencesDetailID, A2.ReferencesNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
"   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
"   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.ClaimWeight AS MaxTotalWeight, " & vbNewLine &
"   A.Remarks, A.UnitPriceProduct, A.TotalPriceProduct, A.DPAmount, A.ReceiveAmount, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A.DPAmountPPN,  " & vbNewLine &
"	A.DPAmountPPH, A.ReceiveAmountPPN, A.ReceiveAmountPPH, A.InvoiceQuantity, A.InvoiceWeight, A.InvoiceTotalWeight,  " & vbNewLine &
"	A.AllocateDPAmount, A.ConfirmationQuantity, A.ConfirmationWeight " & vbNewLine &
"FROM traClaimDet A " & vbNewLine &
"INNER JOIN traSalesContractDet A1 ON " & vbNewLine &
"   A.ReferencesDetailID=A1.ID " & vbNewLine &
"INNER JOIN traSalesContract A2 ON " & vbNewLine &
"   A1.SCID=A2.ID " & vbNewLine &
"INNER JOIN mstItem B ON " & vbNewLine &
"   A.ItemID=B.ID " & vbNewLine &
"INNER JOIN mstItemSpecification C ON " & vbNewLine &
"   B.ItemSpecificationID=C.ID " & vbNewLine &
"INNER JOIN mstItemType D ON " & vbNewLine &
"   B.ItemTypeID=D.ID " & vbNewLine &
"WHERE  " & vbNewLine &
"	A.ClaimID=@ClaimID " & vbNewLine

                .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT  " & vbNewLine &
"	A.ID, A.ClaimID, A.ReferencesDetailID, A2.ReferencesNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
"   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
"   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.ClaimWeight AS MaxTotalWeight, " & vbNewLine &
"   A.Remarks, A.UnitPriceProduct, A.TotalPriceProduct, A.DPAmount, A.ReceiveAmount, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A.DPAmountPPN,  " & vbNewLine &
"	A.DPAmountPPH, A.ReceiveAmountPPN, A.ReceiveAmountPPH, A.InvoiceQuantity, A.InvoiceWeight, A.InvoiceTotalWeight,  " & vbNewLine &
"	A.AllocateDPAmount, A.ConfirmationQuantity, A.ConfirmationWeight " & vbNewLine &
"FROM traClaimDet A " & vbNewLine &
"INNER JOIN traReceiveDet A1 ON " & vbNewLine &
"   A.ReferencesDetailID=A1.ID " & vbNewLine &
"INNER JOIN traReceive A2 ON " & vbNewLine &
"   A1.ReceiveID=A2.ID " & vbNewLine &
"INNER JOIN mstItem B ON " & vbNewLine &
"   A.ItemID=B.ID " & vbNewLine &
"INNER JOIN mstItemSpecification C ON " & vbNewLine &
"   B.ItemSpecificationID=C.ID " & vbNewLine &
"INNER JOIN mstItemType D ON " & vbNewLine &
"   B.ItemTypeID=D.ID " & vbNewLine &
"WHERE  " & vbNewLine &
"	A.ClaimID=@ClaimID " & vbNewLine

                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = strClaimID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function
        
        Public Shared Function ListDataDetailOutstandingConfirmationClaim(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                          ByVal strClaimID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine &
"	TCD.ID, TCD.ClaimID AS ParentID, TCH.ClaimNumber AS ParentNumber, TCD.OrderNumberSupplier, TCH.ReferencesNumber, TCD.ItemID, MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length,  " & vbNewLine &
"	MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, MIT.Description AS ItemTypeName,  " & vbNewLine &
"	TCD.Quantity-TCD.ConfirmationQuantity AS Quantity, TCD.Weight, TCD.TotalWeight-TCD.ConfirmationWeight AS TotalWeight, TCD.UnitPrice, TCD.UnitPriceProduct, TCD.TotalPriceProduct, " & vbNewLine &
"	TCD.TotalPrice, TCD.RoundingWeight, TCD.Remarks, TCD.TotalWeight-TCD.ConfirmationWeight AS MaxTotalWeight " & vbNewLine &
"FROM traClaimDet TCD  " & vbNewLine &
"INNER JOIN traClaim TCH ON  " & vbNewLine &
"	TCD.ClaimID=TCH.ID  " & vbNewLine &
"INNER JOIN mstItem MI ON    " & vbNewLine &
"    TCD.ItemID=MI.ID    " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON    " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID    " & vbNewLine &
"INNER JOIN mstItemType MIT ON    " & vbNewLine &
"    MI.ItemTypeID=MIT.ID    " & vbNewLine &
"WHERE  " & vbNewLine &
"	TCH.ID=@ClaimID  " & vbNewLine &
"	AND TCD.TotalWeight-TCD.ConfirmationWeight>0   " & vbNewLine

                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = strClaimID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ClaimDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText +=
"INSERT INTO traClaimDet " & vbNewLine &
"	(ID, ClaimID, ReferencesDetailID, ItemID, Quantity, Weight, TotalWeight,  " & vbNewLine &
"	 UnitPrice, TotalPrice, Remarks, UnitPriceProduct, TotalPriceProduct, OrderNumberSupplier, LevelItem, ParentID, RoundingWeight) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ClaimID, @ReferencesDetailID, @ItemID, @Quantity, @Weight, @TotalWeight,  " & vbNewLine &
"	 @UnitPrice, @TotalPrice, @Remarks, @UnitPriceProduct, @TotalPriceProduct, @OrderNumberSupplier, @LevelItem, @ParentID, @RoundingWeight) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = clsData.ClaimID
                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = clsData.ReferencesDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@UnitPriceProduct", SqlDbType.Decimal).Value = clsData.UnitPriceProduct
                .Parameters.Add("@TotalPriceProduct", SqlDbType.Decimal).Value = clsData.TotalPriceProduct
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strClaimID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"DELETE FROM traClaimDet " & vbNewLine &
"WHERE " & vbNewLine &
"	ClaimID=@ClaimID " & vbNewLine

                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = strClaimID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateClaimTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strClaimDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traClaimDet SET 	" & vbNewLine &
                    "	ConfirmationWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(CD.TotalWeight+CD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traConfirmationClaimDet CD 	" & vbNewLine &
                    "		INNER JOIN traConfirmationClaim CH ON	" & vbNewLine &
                    "			CD.ConfirmationClaimID=CH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			CD.ClaimDetailID=@ClaimDetailID " & vbNewLine &
                    "			AND CH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	ConfirmationQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(CD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traConfirmationClaimDet CD 	" & vbNewLine &
                    "		INNER JOIN traConfirmationClaim CH ON	" & vbNewLine &
                    "			CD.ConfirmationClaimID=CH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			CD.ClaimDetailID=@ClaimDetailID " & vbNewLine &
                    "			AND CH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@ClaimDetailID	" & vbNewLine

                .Parameters.Add("@ClaimDetailID", SqlDbType.VarChar, 100).Value = strClaimDetailID
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
                                              ByVal strClaimID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ClaimID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traClaimStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ClaimID=@ClaimID " & vbNewLine

                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = strClaimID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ClaimStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traClaimStatus " & vbNewLine &
                    "   (ID, ClaimID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ClaimID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = clsData.ClaimID
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
                                           ByVal strClaimID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traClaimStatus     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ClaimID=@ClaimID" & vbNewLine

                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = strClaimID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strClaimID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traClaimStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ClaimID=@ClaimID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = strClaimID
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

