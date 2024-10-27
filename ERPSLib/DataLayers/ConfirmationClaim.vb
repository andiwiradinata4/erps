Namespace DL

    Public Class ConfirmationClaim

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal intClaimType As VO.ConfirmationClaim.ClaimTypeValue) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText +=
                    "SELECT  " & vbNewLine &
                    "	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.ClaimType, A.ConfirmationClaimNumber, A.ConfirmationClaimDate, " & vbNewLine &
                    "	A.BPID, C.Code AS BPCode, C.Name AS BPName, A.ClaimID, A1.ClaimNumber, A.PPN, A.PPH,  " & vbNewLine &
                    "	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine &
                    "	StatusInfo=B.Name, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy,  " & vbNewLine &
                    "	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment, A.JournalID, A.IsUseSubItem, A.DPAmountPPN, " & vbNewLine &
                    "   A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH " & vbNewLine &
                    "FROM traConfirmationClaim A " & vbNewLine &
                    "INNER JOIN traClaim A1 ON " & vbNewLine &
                    "   A.ClaimID=A1.ID " & vbNewLine &
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
                    "   AND A.ConfirmationClaimDate>=@DateFrom AND A.ConfirmationClaimDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine
                If intClaimType <> VO.ConfirmationClaim.ClaimTypeValue.All Then .CommandText += "   AND A.ClaimType=@ClaimType " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
                .Parameters.Add("@ClaimType", SqlDbType.Int).Value = intClaimType
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.ConfirmationClaim)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traConfirmationClaim " & vbNewLine &
"	(ID, ProgramID, CompanyID, ClaimType, ConfirmationClaimNumber, ConfirmationClaimDate, BPID,  " & vbNewLine &
"	 ClaimID, ReferencesNumber, PPN, PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, " & vbNewLine &
"	 TotalPPH, RoundingManual, Remarks, StatusID, CreatedBy, LogBy, IsUseSubItem) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ProgramID, @CompanyID, @ClaimType, @ConfirmationClaimNumber, @ConfirmationClaimDate, @BPID,  " & vbNewLine &
"	 @ClaimID, @ReferencesNumber, @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, " & vbNewLine &
"    @TotalPPH, @RoundingManual, @Remarks, @StatusID, @LogBy, @LogBy, @IsUseSubItem) " & vbNewLine

                Else
                    .CommandText =
"UPDATE traConfirmationClaim SET  " & vbNewLine &
"	ProgramID=@ProgramID,  " & vbNewLine &
"	CompanyID=@CompanyID,  " & vbNewLine &
"	ClaimType=@ClaimType,  " & vbNewLine &
"	ConfirmationClaimNumber=@ConfirmationClaimNumber,  " & vbNewLine &
"	ConfirmationClaimDate=@ConfirmationClaimDate,  " & vbNewLine &
"	BPID=@BPID,  " & vbNewLine &
"	ClaimID=@ClaimID,  " & vbNewLine &
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
"	IsUseSubItem=@IsUseSubItem " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ClaimType", SqlDbType.Int).Value = clsData.ClaimType
                .Parameters.Add("@ConfirmationClaimNumber", SqlDbType.VarChar, 100).Value = clsData.ConfirmationClaimNumber
                .Parameters.Add("@ConfirmationClaimDate", SqlDbType.DateTime).Value = clsData.ConfirmationClaimDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@ClaimID", SqlDbType.VarChar, 100).Value = clsData.ClaimID
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
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.ConfirmationClaim
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ConfirmationClaim
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText +=
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.ClaimType, A.ConfirmationClaimNumber, A.ConfirmationClaimDate, A.BPID,  " & vbNewLine &
"	B.Code AS BPCode, B.Name AS BPName, A.ClaimID, A1.ClaimNumber AS ReferencesNumber, A.PPN, A.PPH,  " & vbNewLine &
"	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual,  " & vbNewLine &
"	A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy,  " & vbNewLine &
"	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment,  " & vbNewLine &
"	A.JournalID, A.IsUseSubItem, A.DPAmountPPN, A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH " & vbNewLine &
"FROM traConfirmationClaim A " & vbNewLine &
"INNER JOIN traClaim A1 ON " & vbNewLine &
"   A.ClaimID=A1.ID " & vbNewLine &
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
                        voReturn.ConfirmationClaimNumber = .Item("ConfirmationClaimNumber")
                        voReturn.ConfirmationClaimDate = .Item("ConfirmationClaimDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.ClaimID = .Item("ClaimID")
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
                    "UPDATE traConfirmationClaim SET " & vbNewLine &
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
                        "FROM traConfirmationClaim " & vbNewLine &
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
                                          ByVal strConfirmationClaimNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traConfirmationClaim " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ConfirmationClaimNumber=@ConfirmationClaimNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@ConfirmationClaimNumber", SqlDbType.VarChar, 100).Value = strConfirmationClaimNumber
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
                        "FROM traConfirmationClaim " & vbNewLine &
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
                        "FROM traConfirmationClaim " & vbNewLine &
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
                    "UPDATE traConfirmationClaim SET " & vbNewLine &
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
                    "UPDATE traConfirmationClaim SET " & vbNewLine &
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

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strConfirmationClaimID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText +=
"SELECT  " & vbNewLine &
"	A.ID, A.ConfirmationClaimID, A.ClaimDetailID, A2.ClaimNumber AS ClaimNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
"   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
"   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.ConfirmationWeight AS MaxTotalWeight, " & vbNewLine &
"   A.Remarks, A.UnitPriceProduct, A.TotalPriceProduct, A.DPAmount, A.ReceiveAmount, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A.DPAmountPPN,  " & vbNewLine &
"	A.DPAmountPPH, A.ReceiveAmountPPN, A.ReceiveAmountPPH, A.InvoiceQuantity, A.InvoiceWeight, A.InvoiceTotalWeight,  " & vbNewLine &
"	A.AllocateDPAmount " & vbNewLine &
"FROM traConfirmationClaimDet A " & vbNewLine &
"INNER JOIN traClaimDet A1 ON " & vbNewLine &
"   A.ClaimDetailID=A1.ID " & vbNewLine &
"INNER JOIN traClaim A2 ON " & vbNewLine &
"   A1.ClaimID=A2.ID " & vbNewLine &
"INNER JOIN mstItem B ON " & vbNewLine &
"   A.ItemID=B.ID " & vbNewLine &
"INNER JOIN mstItemSpecification C ON " & vbNewLine &
"   B.ItemSpecificationID=C.ID " & vbNewLine &
"INNER JOIN mstItemType D ON " & vbNewLine &
"   B.ItemTypeID=D.ID " & vbNewLine &
"WHERE  " & vbNewLine &
"	A.ConfirmationClaimID=@ConfirmationClaimID " & vbNewLine

                .Parameters.Add("@ConfirmationClaimID", SqlDbType.VarChar, 100).Value = strConfirmationClaimID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ConfirmationClaimDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText +=
"INSERT INTO traConfirmationClaimDet " & vbNewLine &
"	(ID, ConfirmationClaimID, ClaimDetailID, ItemID, Quantity, Weight, TotalWeight,  " & vbNewLine &
"	 UnitPrice, TotalPrice, Remarks, UnitPriceProduct, TotalPriceProduct, OrderNumberSupplier, LevelItem, ParentID, RoundingWeight) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ConfirmationClaimID, @ClaimDetailID, @ItemID, @Quantity, @Weight, @TotalWeight,  " & vbNewLine &
"	 @UnitPrice, @TotalPrice, @Remarks, @UnitPriceProduct, @TotalPriceProduct, @OrderNumberSupplier, @LevelItem, @ParentID, @RoundingWeight) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ConfirmationClaimID", SqlDbType.VarChar, 100).Value = clsData.ConfirmationClaimID
                .Parameters.Add("@ClaimDetailID", SqlDbType.VarChar, 100).Value = clsData.ClaimDetailID
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

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strConfirmationClaimID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"DELETE FROM traConfirmationClaimDet " & vbNewLine &
"WHERE " & vbNewLine &
"	ConfirmationClaimID=@ConfirmationClaimID " & vbNewLine

                .Parameters.Add("@ConfirmationClaimID", SqlDbType.VarChar, 100).Value = strConfirmationClaimID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub


#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strConfirmationClaimID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ConfirmationClaimID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traConfirmationClaimStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ConfirmationClaimID=@ConfirmationClaimID " & vbNewLine

                .Parameters.Add("@ConfirmationClaimID", SqlDbType.VarChar, 100).Value = strConfirmationClaimID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ConfirmationClaimStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traConfirmationClaimStatus " & vbNewLine &
                    "   (ID, ConfirmationClaimID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ConfirmationClaimID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ConfirmationClaimID", SqlDbType.VarChar, 100).Value = clsData.ConfirmationClaimID
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
                                           ByVal strConfirmationClaimID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traConfirmationClaimStatus     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ConfirmationClaimID=@ConfirmationClaimID" & vbNewLine

                .Parameters.Add("@ConfirmationClaimID", SqlDbType.VarChar, 100).Value = strConfirmationClaimID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strConfirmationClaimID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traConfirmationClaimStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ConfirmationClaimID=@ConfirmationClaimID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ConfirmationClaimID", SqlDbType.VarChar, 100).Value = strConfirmationClaimID
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

