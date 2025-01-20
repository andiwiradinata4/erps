Namespace DL

    Public Class SalesConfirmationOrder

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
                    "SELECT  " & vbNewLine & _
                    "	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.CONumber, A.CODate, " & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP,  " & vbNewLine & _
                    "	A.TotalPPN, A.TotalPPH, A.RoundingManual, A.DelegationSeller, A.DelegationPositionSeller, A.DelegationBuyer,  A.DelegationPositionBuyer, A.IsDeleted, " & vbNewLine & _
                    "   A.Remarks, A.StatusID, StatusInfo=B.Name, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate,  " & vbNewLine & _
                    "	A.ApprovedBy, CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.CreatedBy, A.CreatedDate,  " & vbNewLine & _
                    "	A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traSalesConfirmationOrder A " & vbNewLine & _
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
                    "   AND A.SCDate>=@DateFrom AND A.SCDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine

                .CommandText += "ORDER BY A.SCDate, A.SCNumber "

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.SalesConfirmationOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traSalesConfirmationOrder " & vbNewLine & _
"	(ID, ProgramID, CompanyID, CONumber, CODate, BPID, DeliveryPeriodFrom,  " & vbNewLine & _
"	 DeliveryPeriodTo, PPN, PPH, TotalQuantity, TotalWeight, TotalDPP,  " & vbNewLine & _
"	 TotalPPN, TotalPPH, RoundingManual, DelegationSeller, DelegationPositionSeller, DelegationBuyer,  " & vbNewLine & _
"	 DelegationPositionBuyer, Remarks, StatusID, CreatedBy, LogBy) " & vbNewLine & _
"VALUES  " & vbNewLine & _
"	(@ID, @ProgramID, @CompanyID, @CONumber, @CODate, @BPID, @DeliveryPeriodFrom,  " & vbNewLine & _
"	 @DeliveryPeriodTo, @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP,  " & vbNewLine & _
"	 @TotalPPN, @TotalPPH, @RoundingManual, @DelegationSeller, @DelegationPositionSeller, @DelegationBuyer,  " & vbNewLine & _
"	 @DelegationPositionBuyer, @Remarks, @StatusID, @LogBy, @LogBy) " & vbNewLine
                Else
                    .CommandText =
"UPDATE traSalesConfirmationOrder SET  " & vbNewLine & _
"	ProgramID=@ProgramID,  " & vbNewLine & _
"	CompanyID=@CompanyID,  " & vbNewLine & _
"	CONumber=@CONumber,  " & vbNewLine & _
"	CODate=@CODate,  " & vbNewLine & _
"	BPID=@BPID,  " & vbNewLine & _
"	DeliveryPeriodFrom=@DeliveryPeriodFrom,  " & vbNewLine & _
"	DeliveryPeriodTo=@DeliveryPeriodTo,  " & vbNewLine & _
"	PPN=@PPN,  " & vbNewLine & _
"	PPH=@PPH,  " & vbNewLine & _
"	TotalQuantity=@TotalQuantity,  " & vbNewLine & _
"	TotalWeight=@TotalWeight,  " & vbNewLine & _
"	TotalDPP=@TotalDPP,  " & vbNewLine & _
"	TotalPPN=@TotalPPN,  " & vbNewLine & _
"	TotalPPH=@TotalPPH,  " & vbNewLine & _
"	RoundingManual=@RoundingManual,  " & vbNewLine & _
"	DelegationSeller=@DelegationSeller,  " & vbNewLine & _
"	DelegationPositionSeller=@DelegationPositionSeller,  " & vbNewLine & _
"	DelegationBuyer=@DelegationBuyer,  " & vbNewLine & _
"	DelegationPositionBuyer=@DelegationPositionBuyer,  " & vbNewLine & _
"	Remarks=@Remarks,  " & vbNewLine & _
"	StatusID=@StatusID,  " & vbNewLine & _
"	LogInc=LogInc+1,  " & vbNewLine & _
"	LogBy=@LogBy,  " & vbNewLine & _
"	LogDate=GETDATE()  " & vbNewLine & _
"WHERE " & vbNewLine & _
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@CONumber", SqlDbType.VarChar, 100).Value = clsData.CONumber
                .Parameters.Add("@CODate", SqlDbType.DateTime).Value = clsData.CODate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@DeliveryPeriodFrom", SqlDbType.DateTime).Value = clsData.DeliveryPeriodFrom
                .Parameters.Add("@DeliveryPeriodTo", SqlDbType.DateTime).Value = clsData.DeliveryPeriodTo
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
                .Parameters.Add("@DelegationSeller", SqlDbType.VarChar, 250).Value = clsData.DelegationSeller
                .Parameters.Add("@DelegationPositionSeller", SqlDbType.VarChar, 250).Value = clsData.DelegationPositionSeller
                .Parameters.Add("@DelegationBuyer", SqlDbType.VarChar, 250).Value = clsData.DelegationBuyer
                .Parameters.Add("@DelegationPositionBuyer", SqlDbType.VarChar, 250).Value = clsData.DelegationPositionBuyer
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.SalesConfirmationOrder
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.SalesConfirmationOrder
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
                        "SELECT TOP 1  " & vbNewLine & _
                        "	A.ID, A.ProgramID, A.CompanyID, A.CONumber, A.CODate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.DeliveryPeriodFrom,  " & vbNewLine & _
                        "	A.DeliveryPeriodTo, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP,  " & vbNewLine & _
                        "	A.TotalPPN, A.TotalPPH, A.RoundingManual, A.DelegationSeller, A.DelegationPositionSeller, A.DelegationBuyer,  " & vbNewLine & _
                        "	A.DelegationPositionBuyer, A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate,  " & vbNewLine & _
                        "	A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate,  " & vbNewLine & _
                        "	A.LogInc, A.LogBy, A.LogDate, A.IsDone, A.DoneBy, A.DoneDate " & vbNewLine & _
                        "	 " & vbNewLine & _
                        "FROM traSalesConfirmationOrder A " & vbNewLine & _
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine &
                        "   A.BPID=B.ID " & vbNewLine &
                        "WHERE " & vbNewLine & _
                        "	A.ID=@ID " & vbNewLine
                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID

                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.CONumber = .Item("CONumber")
                        voReturn.CODate = .Item("CODate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.DeliveryPeriodFrom = .Item("DeliveryPeriodFrom")
                        voReturn.DeliveryPeriodTo = .Item("DeliveryPeriodTo")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalQuantity = .Item("TotalQuantity")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.DelegationSeller = .Item("DelegationSeller")
                        voReturn.DelegationPositionSeller = .Item("DelegationPositionSeller")
                        voReturn.DelegationBuyer = .Item("DelegationBuyer")
                        voReturn.DelegationPositionBuyer = .Item("DelegationPositionBuyer")
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
                        voReturn.IsDone = .Item("IsDone")
                        voReturn.DoneBy = .Item("DoneBy")
                        voReturn.DoneDate = .Item("DoneDate")
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
                    "UPDATE traSalesConfirmationOrder SET " & vbNewLine &
                    "   StatusID=@StatusID, " & vbNewLine &
                    "   IsDeleted=1 " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strNewID As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 4),'0000') AS ID " & vbNewLine &
                        "FROM traSalesConfirmationOrder " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY CreatedDate DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID") + 1
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Function GetMaxNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intYear As Integer, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT COUNT(*) AS Total " & vbNewLine &
                        "FROM traSalesConfirmationOrder " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   YEAR(SCDate)=@Year " & vbNewLine &
                        "   AND ProgramID=@ProgramID " & vbNewLine &
                        "   AND CompanyID=@CompanyID " & vbNewLine

                    .Parameters.Add("@Year", SqlDbType.Int).Value = intYear
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("Total")
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
                                          ByVal strSCNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traSalesConfirmationOrder " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   SCNumber=@SCNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@SCNumber", SqlDbType.VarChar, 100).Value = strSCNumber
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
                        "FROM traSalesConfirmationOrder " & vbNewLine &
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
                        "FROM traSalesConfirmationOrder " & vbNewLine &
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
                    "UPDATE traSalesConfirmationOrder SET " & vbNewLine &
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
                    "UPDATE traSalesConfirmationOrder SET " & vbNewLine &
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
                    "UPDATE traSalesConfirmationOrder SET " & vbNewLine &
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
                    "UPDATE traSalesConfirmationOrder SET " & vbNewLine &
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

        Public Shared Function PrintVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine & _
"	BP.Name AS BPName, IT.Description AS ItemTypeName, SCO.CONumber AS TransNumber, CAST('' AS VARCHAR(1000)) AS AllItemName,     " & vbNewLine & _
"    SCO.CODate AS TransDate, BPL.Address AS DeliveryAddress, MIS.Description AS ItemTypeAndSpec, MI.Thick AS ItemThick,  " & vbNewLine & _
"	MI.Width AS ItemWidth, CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength,  " & vbNewLine & _
"	Weight=CASE WHEN IT.LengthInitial='COIL' THEN NULL ELSE SCOD.Weight END, SCOD.Quantity, SCOD.TotalWeight AS TotalWeightItem,  " & vbNewLine & _
"	SCOD.UnitPrice, SCOD.TotalPrice, (SCOD.TotalPrice*SCO.PPN/100) AS TotalPPNItem, SCOD.TotalPrice + (SCOD.TotalPrice*SCO.PPN/100) AS TotalPriceIncPPN,  " & vbNewLine & _
"	CAST('' AS VARCHAR(1000)) AS NumericToString, BP.PICName AS BPPIC, MC.DirectorName AS CompanyDirectorName,    " & vbNewLine & _
"    SCO.TotalDPP + SCO.TotalPPN - SCO.TotalPPH + SCO.RoundingManual AS GrandTotal, SCO.PPN, SCO.StatusID, SCO.DelegationSeller,    " & vbNewLine & _
"    SCO.DelegationPositionSeller, SCO.DelegationBuyer, SCO.DelegationPositionBuyer, MC.Name AS CompanyName,  " & vbNewLine & _
"	UomInitial=CASE WHEN IT.LengthInitial='COIL' THEN 'QTY' ELSE 'LBR' END, SCOD.ItemMin, SCOD.ItemMax, SCOD.ItemTolerances,  " & vbNewLine & _
"	CAST('' AS VARCHAR(1000)) AS PaymentTerms  " & vbNewLine & _
"FROM traSalesConfirmationOrder SCO  " & vbNewLine & _
"INNER JOIN mstCompany MC ON    " & vbNewLine & _
"    SCO.CompanyID=MC.ID    " & vbNewLine & _
"INNER JOIN traSalesConfirmationOrderDet SCOD ON  " & vbNewLine & _
"	SCO.ID=SCOD.COID  " & vbNewLine & _
"INNER JOIN mstItem MI ON 	    " & vbNewLine & _
"    SCOD.ItemID=MI.ID 	    " & vbNewLine & _
"INNER JOIN mstItemType IT ON 	 	    " & vbNewLine & _
"    MI.ItemTypeID=IT.ID 	 	    " & vbNewLine & _
"INNER JOIN mstItemSpecification MIS ON 	 	    " & vbNewLine & _
"    MI.ItemSpecificationID=MIS.ID 	 	    " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON	   " & vbNewLine & _
"    SCO.BPID=BP.ID    " & vbNewLine & _
"INNER JOIN mstBusinessPartnerLocation BPL ON	   " & vbNewLine & _
"    SCOD.LocationID=BPL.ID    " & vbNewLine & _
"WHERE SCO.ID=@ID  " & vbNewLine & _
"ORDER BY SCOD.LocationID ASC  " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strCOID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
                    "SELECT  " & vbNewLine & _
                    "	A.ID, A.COID, A.ORDetailID, A.PODetailID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, A.Quantity, A.Weight,  " & vbNewLine & _
                    "	C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, A.TotalWeight, " & vbNewLine & _
                    "   A.UnitPrice, A.TotalPrice, A.Remarks, A.RoundingWeight, A.LocationID, A1.TotalWeight+A.TotalWeight-A1.SCOWeight AS MaxTotalWeightOR, " & vbNewLine & _
                    "   A2.TotalWeight+A.TotalWeight-A2.SCOWeight AS MaxTotalWeightPO, A.ItemMin, A.ItemMax, A.ItemTolerances " & vbNewLine & _
                    "FROM traSalesConfirmationOrderDet A " & vbNewLine & _
                    "INNER JOIN traOrderRequestDet A1 ON  	" & vbNewLine &
                    "    A.ORDetailID=A1.ID  	" & vbNewLine &
                    "INNER JOIN traOrderRequestDet A2 ON  	" & vbNewLine &
                    "    A.PODetailID=A2.ID  	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "    A.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "    B.ItemTypeID=D.ID  	" & vbNewLine &
                    "WHERE  " & vbNewLine & _
                    "	A.COID=@COID  " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.SalesConfirmationOrderDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
                    "INSERT INTO traSalesConfirmationOrderDet " & vbNewLine & _
                    "	(ID, COID, ORDetailID, PODetailID, ItemID, Quantity, Weight,  " & vbNewLine & _
                    "	 TotalWeight, UnitPrice, TotalPrice, Remarks, RoundingWeight, LocationID, " & vbNewLine & _
                    "    ItemMin, ItemMax, ItemTolerances) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "	(@ID, @COID, @ORDetailID, @PODetailID, @ItemID, @Quantity, @Weight,  " & vbNewLine & _
                    "	 @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @RoundingWeight, @LocationID, " & vbNewLine & _
                    "    @ItemMin, @ItemMax, @ItemTolerances) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = clsData.COID
                .Parameters.Add("@ORDetailID", SqlDbType.VarChar, 100).Value = clsData.ORDetailID
                .Parameters.Add("@PODetailID", SqlDbType.VarChar, 100).Value = clsData.PODetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@LocationID", SqlDbType.Int).Value = clsData.LocationID
                .Parameters.Add("@ItemMin", SqlDbType.Decimal).Value = clsData.ItemMin
                .Parameters.Add("@ItemMax", SqlDbType.Decimal).Value = clsData.ItemMax
                .Parameters.Add("@ItemTolerances", SqlDbType.Decimal).Value = clsData.ItemTolerances
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub
        
        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strCOID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traSalesConfirmationOrderDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   COID=@COID " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
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
                                                   ByVal strCOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.COID, A.Percentage, A.PaymentTypeID, B.Code AS PaymentTypeCode, B.Name AS PaymentTypeName, " & vbNewLine &
                    "   A.PaymentModeID, C.Code AS PaymentModeCode, C.Name AS PaymentModeName, A.CreditTerm, A.Remarks " & vbNewLine &
                    "FROM traSalesConfirmationOrderPaymentTerm A " & vbNewLine &
                    "INNER JOIN mstPaymentType B ON " & vbNewLine &
                    "   A.PaymentTypeID=B.ID " & vbNewLine &
                    "INNER JOIN mstPaymentMode C ON " & vbNewLine &
                    "   A.PaymentModeID=C.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.COID=@COID " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataPaymentTerm(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal clsData As VO.SalesConfirmationOrderPaymentTerm)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesConfirmationOrderPaymentTerm " & vbNewLine &
                    "   (ID, COID, Percentage, PaymentTypeID, PaymentModeID, CreditTerm, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @COID, @Percentage, @PaymentTypeID, @PaymentModeID, @CreditTerm, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = clsData.COID
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
                                                   ByVal strCOID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traSalesConfirmationOrderPaymentTerm     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   COID=@COID" & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
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
                                              ByVal strCOID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.COID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traSalesConfirmationOrderStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.COID=@COID " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.SalesConfirmationOrderStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesConfirmationOrderStatus " & vbNewLine &
                    "   (ID, COID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @COID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = clsData.COID
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
                                              ByVal strCOID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traSalesConfirmationOrderStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   COID=@COID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
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