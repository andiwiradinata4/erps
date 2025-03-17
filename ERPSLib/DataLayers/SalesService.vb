Namespace DL
 
    Public Class SalesService

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal intServiceType As VO.ServiceType.Value) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.TransNumber, A.TransDate, A.BPID, C.Code AS BPCode, C.Name AS BPName, A.ServiceType,  " & vbNewLine &
"	A.PPN, A.PPH, A.TotalQuantity, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.DPAmount, A.DPAmountPPN, A.DPAmountPPH, A.ReceiveAmount, A.ReceiveAmountPPN,  " & vbNewLine &
"	A.ReceiveAmountPPH, A.StatusID, StatusInfo=B.Name, A.Remarks, A.IsDeleted, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc, " & vbNewLine &
"   CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.SubmitDate, A.JournalID " & vbNewLine &
"FROM traSalesService A " & vbNewLine &
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
"   AND A.TransDate>=@DateFrom AND A.TransDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   AND A.StatusID=@StatusID " & vbNewLine
                If intServiceType <> VO.ServiceType.Value.All Then .CommandText += "   AND A.ServiceType=@ServiceType " & vbNewLine

                .CommandText += "ORDER BY A.TransDate, A.TransNumber "

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
                .Parameters.Add("@ServiceType", SqlDbType.Int).Value = intServiceType
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.SalesService)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traSalesService " & vbNewLine &
"	(ID, ProgramID, CompanyID, TransNumber, TransDate, BPID, ServiceType,  " & vbNewLine &
"	 PPN, PPH, TotalQuantity, TotalDPP, TotalPPN, TotalPPH,  " & vbNewLine &
"	 RoundingManual, StatusID, Remarks, CreatedBy, LogBy) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ProgramID, @CompanyID, @TransNumber, @TransDate, @BPID, @ServiceType,  " & vbNewLine &
"	 @PPN, @PPH, @TotalQuantity, @TotalDPP, @TotalPPN, @TotalPPH,  " & vbNewLine &
"	 @RoundingManual, @StatusID, @Remarks, @LogBy, @LogBy) " & vbNewLine
                Else
                    .CommandText =
"UPDATE traSalesService SET  " & vbNewLine &
"	ProgramID=@ProgramID,  " & vbNewLine &
"	CompanyID=@CompanyID,  " & vbNewLine &
"	TransNumber=@TransNumber,  " & vbNewLine &
"	TransDate=@TransDate,  " & vbNewLine &
"	BPID=@BPID,  " & vbNewLine &
"	ServiceType=@ServiceType,  " & vbNewLine &
"	PPN=@PPN,  " & vbNewLine &
"	PPH=@PPH,  " & vbNewLine &
"	TotalQuantity=@TotalQuantity,  " & vbNewLine &
"	TotalDPP=@TotalDPP,  " & vbNewLine &
"	TotalPPN=@TotalPPN,  " & vbNewLine &
"	TotalPPH=@TotalPPH,  " & vbNewLine &
"	RoundingManual=@RoundingManual,  " & vbNewLine &
"	StatusID=@StatusID,  " & vbNewLine &
"	Remarks=@Remarks,  " & vbNewLine &
"	LogBy=@LogBy,  " & vbNewLine &
"	LogDate=GETDATE(),  " & vbNewLine &
"	LogInc=LogInc+1 " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@TransNumber", SqlDbType.VarChar, 100).Value = clsData.TransNumber
                .Parameters.Add("@TransDate", SqlDbType.DateTime).Value = clsData.TransDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@ServiceType", SqlDbType.Int).Value = clsData.ServiceType
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.SalesService
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.SalesService
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.TransNumber, A.TransDate, A.BPID, C.Code AS BPCode, C.Name AS BPName, A.ServiceType,  " & vbNewLine &
"	A.PPN, A.PPH, A.TotalQuantity, A.TotalDPP, A.TotalPPN, A.TotalPPH,  " & vbNewLine &
"	A.RoundingManual, A.DPAmount, A.DPAmountPPN, A.DPAmountPPH, A.ReceiveAmount, A.ReceiveAmountPPN,  " & vbNewLine &
"	A.ReceiveAmountPPH, A.StatusID, A.Remarks, A.IsDeleted, A.CreatedBy, A.CreatedDate,  " & vbNewLine &
"	A.LogBy, A.LogDate, A.LogInc, A.SubmitBy, A.SubmitDate, A.JournalID " & vbNewLine &
"FROM traSalesService A " & vbNewLine &
"INNER JOIN mstStatus B ON " & vbNewLine &
"   A.StatusID=B.ID " & vbNewLine &
"INNER JOIN mstBusinessPartner C ON " & vbNewLine &
"   A.BPID=C.ID " & vbNewLine &
"INNER JOIN mstCompany MC ON " & vbNewLine &
"   A.CompanyID=MC.ID " & vbNewLine &
"INNER JOIN mstProgram MP ON " & vbNewLine &
"   A.ProgramID=MP.ID " & vbNewLine &
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
                        voReturn.TransNumber = .Item("TransNumber")
                        voReturn.TransDate = .Item("TransDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.ServiceType = .Item("ServiceType")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalQuantity = .Item("TotalQuantity")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.DPAmountPPN = .Item("DPAmountPPN")
                        voReturn.DPAmountPPH = .Item("DPAmountPPH")
                        voReturn.ReceiveAmount = .Item("ReceiveAmount")
                        voReturn.ReceiveAmountPPN = .Item("ReceiveAmountPPN")
                        voReturn.ReceiveAmountPPH = .Item("ReceiveAmountPPH")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.IsDeleted = .Item("IsDeleted")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.SubmitBy = .Item("SubmitBy")
                        voReturn.SubmitDate = .Item("SubmitDate")
                        voReturn.JournalID = .Item("JournalID")
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
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traSalesService SET " & vbNewLine &
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
                        "FROM traSalesService " & vbNewLine &
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
                                          ByVal strTransNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traSalesService " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   TransNumber=@TransNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@TransNumber", SqlDbType.VarChar, 100).Value = strTransNumber
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
                        "FROM traSalesService " & vbNewLine &
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
                        "FROM traSalesService " & vbNewLine &
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
                    "UPDATE traSalesService SET " & vbNewLine &
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
                    "UPDATE traSalesService SET " & vbNewLine &
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
                                              ByVal strParentID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	A.ID, A.ParentID, A.SourceID, MLS.Description AS SourceName, A.DestinationID, MLD.Description AS DestinationName, A.PlatNumber, A.DeliveryNumber, A.Quantity,  " & vbNewLine &
"	A.Price, A.TotalPrice, A.Rounding, A.DPAmount, A.DPAmountPPN, A.DPAmountPPH, A.ReceiveAmount, A.ReceiveAmountPPN, A.ReceiveAmountPPH, A.AllocateDPAmount, A.InvoiceQuantity " & vbNewLine &
"FROM traSalesServiceDet A  " & vbNewLine &
"INNER JOIN mstDeliveryLocation MLS ON  " & vbNewLine &
"    A.SourceID=MLS.ID  " & vbNewLine &
"INNER JOIN mstDeliveryLocation MLD ON  " & vbNewLine &
"    A.DestinationID=MLS.ID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	A.ParentID=@ParentID  " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.SalesServiceDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"INSERT INTO traSalesServiceDet " & vbNewLine &
"	(ID, ParentID, SourceID, DestinationID, PlatNumber, DeliveryNumber, Quantity, Price, TotalPrice, Rounding) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ParentID, @SourceID, @DestinationID, @PlatNumber, @DeliveryNumber, @Quantity, @Price, @TotalPrice, @Rounding) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@SourceID", SqlDbType.Int).Value = clsData.SourceID
                .Parameters.Add("@DestinationID", SqlDbType.Int).Value = clsData.DestinationID
                .Parameters.Add("@PlatNumber", SqlDbType.VarChar, 100).Value = clsData.PlatNumber
                .Parameters.Add("@DeliveryNumber", SqlDbType.VarChar, 100).Value = clsData.DeliveryNumber
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Price", SqlDbType.Decimal).Value = clsData.Price
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strParentID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"DELETE FROM traSalesServiceDet " & vbNewLine & _
"WHERE " & vbNewLine & _
"	ParentID=@ParentID  " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
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
                                              ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ParentID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traSalesServiceStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.SalesServiceStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traSalesServiceStatus " & vbNewLine &
                    "   (ID, ParentID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
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
                                              ByVal strParentID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traSalesServiceStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ParentID=@ParentID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
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

