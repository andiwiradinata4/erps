﻿Namespace DL
    Public Class OrderRequest

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
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.OrderNumber, A.OrderDate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.PIC, A.ReferencesNumber, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine &
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc, " & vbNewLine &
                    "   A.LogBy, A.LogDate, A.DPAmount, A.ReceiveAmount, (A.TotalDPP+A.RoundingManual)-(A.DPAmount+A.ReceiveAmount) AS OutstandingPayment, " & vbNewLine &
                    "   A.CoAofStock, ISNULL(COA.Code,'') AS CoACodeofStock, ISNULL(COA.Name,'') AS CoANameofStock, A.PPN, A.PPH " & vbNewLine &
                    "FROM traOrderRequest A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "   A.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "   A.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "   A.ProgramID=MP.ID " & vbNewLine &
                    "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "   A.CoAofStock=COA.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.OrderDate>=@DateFrom AND A.OrderDate<=@DateTo " & vbNewLine &
                    "   AND A.IsStock=@IsStock " & vbNewLine

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

        Public Shared Function ListDataOutstandingDelivery(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                           ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.OrderNumber, A.OrderDate, A.BPID, C.Code AS BPCode, " & vbNewLine &
                    "   C.Name AS BPName, A.TotalQuantity, A.TotalWeight, A.PPN, A.PPH, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, " & vbNewLine &
                    "   A.Remarks, A.StatusID, B.Name AS StatusInfo" & vbNewLine &
                    "FROM traOrderRequest A  	" & vbNewLine &
                    "INNER JOIN traOrderRequestDet ORD ON 	" & vbNewLine &
                    "	A.ID=ORD.OrderRequestID 	" & vbNewLine &
                    "INNER JOIN mstStatus B ON  	" & vbNewLine &
                    "   A.StatusID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON  	" & vbNewLine &
                    "   A.BPID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstCompany MC ON  	" & vbNewLine &
                    "   A.CompanyID=MC.ID  	" & vbNewLine &
                    "INNER JOIN mstProgram MP ON  	" & vbNewLine &
                    "   A.ProgramID=MP.ID  	" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "   A.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A.StatusID=@StatusID " & vbNewLine &
                    "   AND A.BPID=@BPID " & vbNewLine &
                    "   AND A.IsStock=1 " & vbNewLine &
                    "	AND ORD.TotalWeight-ORD.RoundingWeight-ORD.SCWeight>0 	" & vbNewLine &
                    "	AND A.IsDeleted=0 	" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataMapCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT  " & vbNewLine & _
                    "	A.ID, A.ProgramID, A.CompanyID, A.OrderRequestID, A.TransactionNumber, A.Remarks, A.CreatedBy,  " & vbNewLine & _
                    "	A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine & _
                    "FROM traOrderRequestConfirmationOrder A " & vbNewLine & _
                    "WHERE " & vbNewLine &
                    "   A.OrderRequestID=@OrderRequestID " & vbNewLine

                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.OrderRequest)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO traOrderRequest " & vbNewLine &
                        "   (ID, ProgramID, CompanyID, BPID, OrderNumber, OrderDate, ReferencesNumber, PPN, PPH, " & vbNewLine &
                        "    TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, " & vbNewLine &
                        "    Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, IsStock, CoAofStock, PIC) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @BPID, @OrderNumber, @OrderDate, @ReferencesNumber, @PPN, @PPH, " & vbNewLine &
                        "    @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, " & vbNewLine &
                        "    @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), @IsStock, @CoAofStock, @PIC) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE traOrderRequest SET " & vbNewLine &
                        "    ProgramID=@ProgramID, " & vbNewLine &
                        "    CompanyID=@CompanyID, " & vbNewLine &
                        "    BPID=@BPID, " & vbNewLine &
                        "    OrderNumber=@OrderNumber, " & vbNewLine &
                        "    OrderDate=@OrderDate, " & vbNewLine &
                        "    ReferencesNumber=@ReferencesNumber, " & vbNewLine &
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
                        "    IsStock=@IsStock, " & vbNewLine &
                        "    CoAofStock=@CoAofStock, " & vbNewLine &
                        "    PIC=@PIC" & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@OrderNumber", SqlDbType.VarChar, 100).Value = clsData.OrderNumber
                .Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = clsData.OrderDate
                .Parameters.Add("@ReferencesNumber", SqlDbType.VarChar, 250).Value = clsData.ReferencesNumber
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
                .Parameters.Add("@IsStock", SqlDbType.Bit).Value = clsData.IsStock
                .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = clsData.CoAofStock
                .Parameters.Add("@PIC", SqlDbType.VarChar, 250).Value = clsData.PIC
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.OrderRequest
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.OrderRequest
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ProgramID, A.CompanyID, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.OrderNumber, A.OrderDate, A.ReferencesNumber, A.PPN, A.PPH, A.TotalQuantity, " & vbNewLine &
                        "   A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.IsStock, " & vbNewLine &
                        "   A.DPAmount, A.ReceiveAmount, A.CoAofStock, ISNULL(COA.Code,'') AS CoACodeofStock, ISNULL(COA.Name,'') AS CoANameofStock, A.PIC " & vbNewLine &
                        "FROM traOrderRequest A " & vbNewLine &
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine &
                        "   A.BPID=B.ID " & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "   A.CoAofStock=COA.ID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "    A.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.OrderNumber = .Item("OrderNumber")
                        voReturn.OrderDate = .Item("OrderDate")
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
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.IsStock = .Item("IsStock")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.ReceiveAmount = .Item("ReceiveAmount")
                        voReturn.CoAofStock = .Item("CoAofStock")
                        voReturn.CoACodeOfStock = .Item("CoACodeofStock")
                        voReturn.CoANameOfStock = .Item("CoANameOfStock")
                        voReturn.PIC = .Item("PIC")
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
                    "UPDATE traOrderRequest SET " & vbNewLine &
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

        Public Shared Sub DeleteDataMapCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traOrderRequestConfirmationOrder " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

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
                        "FROM traOrderRequest " & vbNewLine &
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
                                          ByVal strOrderNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traOrderRequest " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   OrderNumber=@OrderNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@OrderNumber", SqlDbType.VarChar, 100).Value = strOrderNumber
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
                        "FROM traOrderRequest " & vbNewLine &
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
                        "FROM traOrderRequest " & vbNewLine &
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
                    "UPDATE traOrderRequest SET " & vbNewLine &
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
                    "UPDATE traOrderRequest SET " & vbNewLine &
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

        Public Shared Function IsAlreadySalesContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strID As String) As Boolean
            Dim bolDataExists As Boolean = False
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT " & vbNewLine &
                        "   SUM(SCQuantity) AS SCQuantity, SUM(SCWeight) AS SCWeight " & vbNewLine &
                        "FROM traOrderRequestDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   OrderRequestID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        If .Item("SCQuantity") > 0 Or .Item("SCWeight") > 0 Then
                            bolDataExists = True
                        End If
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolDataExists
        End Function

        Public Shared Function IsAlreadyPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strID As String) As Boolean
            Dim bolDataExists As Boolean = False
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM traOrderRequestDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   OrderRequestID=@ID " & vbNewLine &
                        "   AND DPAmount+ReceiveAmount>0 "

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
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

        Public Shared Sub CalculateTotalUsedDownPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                        ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequest SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.DownPaymentOrderRequest
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
                    "UPDATE traOrderRequest SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.TotalPayment),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDelivery TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.TotalPaymentPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDelivery TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.TotalPaymentPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDelivery TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.SCID=@ID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePaymentOrderRequest
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
                    "UPDATE traOrderRequest SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traOrderRequestDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.OrderRequestID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPN),0) ReceiveAmountPPN " & vbNewLine &
                    "		FROM traOrderRequestDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.OrderRequestID=@ID 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDH.ReceiveAmountPPH),0) ReceiveAmountPPH " & vbNewLine &
                    "		FROM traOrderRequestDet TDH " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDH.OrderRequestID=@ID 	" & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePaymentOrderRequest
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
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.Amount),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.PPN),0) TotalPayment		" & vbNewLine &
                    "		FROM traARAPItem ARD 	" & vbNewLine &
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine &
                    "			ARD.ParentID=ARH.ID 	" & vbNewLine &
                    "			AND ARH.Modules=@Modules " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ARD.ReferencesID=@ReferencesID 	" & vbNewLine &
                    "			AND ARD.ReferencesDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND ARH.IsDeleted=0 	" & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ARD.PPH),0) TotalPayment		" & vbNewLine &
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
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.DownPaymentOrderRequest
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
                    "UPDATE traOrderRequest SET 	" & vbNewLine &
                    "	DPAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ORD.DPAmount),0) TotalDPAmount " & vbNewLine &
                    "		FROM traOrderRequestDet ORD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ORD.OrderRequestID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ORD.DPAmountPPN),0) TotalDPAmount " & vbNewLine &
                    "		FROM traOrderRequestDet ORD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ORD.OrderRequestID=@ID " & vbNewLine &
                    "	), " & vbNewLine &
                    "	DPAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ORD.DPAmountPPH),0) TotalDPAmount " & vbNewLine &
                    "		FROM traOrderRequestDet ORD " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ORD.OrderRequestID=@ID " & vbNewLine &
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

        Public Shared Sub CalculateTotalUsedReceiveItemPaymentVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                    ByVal strDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
                    "	ReceiveAmount=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmount),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPN=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPN),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	), " & vbNewLine &
                    "	ReceiveAmountPPH=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.ReceiveAmountPPH),0) ReceiveAmount " & vbNewLine &
                    "		FROM traDeliveryDet TDD " & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON " & vbNewLine &
                    "		    TDD.DeliveryID=TDH.ID " & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@ReferencesDetailID 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 " & vbNewLine &
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePaymentOrderRequest
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
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
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
                    "	) " & vbNewLine &
                    "WHERE ID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strDetailID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePaymentOrderRequest
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdatePrice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                      ByVal clsData As VO.OrderRequest)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                        "UPDATE traOrderRequest SET " & vbNewLine &
                        "    TotalDPP=@TotalDPP, " & vbNewLine &
                        "    TotalPPN=@TotalPPN, " & vbNewLine &
                        "    TotalPPH=@TotalPPH " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetReferencesNumberBySCID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As String
            Dim strReturn As String = ""
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ORH.OrderNumber AS ReferencesNumber " & vbNewLine &
                        "FROM traOrderRequest ORH " & vbNewLine &
                        "INNER JOIN traOrderRequestDet ORD ON " & vbNewLine &
                        "   ORH.ID=ORD.OrderRequestID " & vbNewLine &
                        "INNER JOIN traSalesContractDet SCD ON " & vbNewLine &
                        "   ORD.ID=SCD.ORDetailID " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   SCD.SCID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strReturn = .Item("ReferencesNumber")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return strReturn
        End Function

        Public Shared Sub UpdatePriceAndQuantiy(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal clsData As VO.OrderRequest)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequest SET " & vbNewLine &
                    "    TotalDPP=@TotalDPP, " & vbNewLine &
                    "    TotalPPN=@TotalPPN, " & vbNewLine &
                    "    TotalPPH=@TotalPPH, " & vbNewLine &
                    "    TotalQuantity=@TotalQuantity, " & vbNewLine &
                    "    TotalWeight=@TotalWeight " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
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
                                              ByVal strOrderRequestID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.OrderRequestID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, " & vbNewLine &
                    "   D.Description AS ItemTypeName, A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, " & vbNewLine &
                    "   A.Remarks, A.RoundingWeight, A.OrderNumberSupplier, A.UnitPriceHPP, A.IsIgnoreValidationPayment, " & vbNewLine &
                    "   A.SCQuantity, A.SCWeight, A.GroupID " & vbNewLine &
                    "FROM traOrderRequestDet A " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.OrderRequestID=@OrderRequestID " & vbNewLine

                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailByID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strORDetailID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.OrderRequestID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, " & vbNewLine &
                    "   D.Description AS ItemTypeName, A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, " & vbNewLine &
                    "   A.Remarks, A.RoundingWeight, A.OrderNumberSupplier, A.UnitPriceHPP, A.IsIgnoreValidationPayment, " & vbNewLine &
                    "   A.SCQuantity, A.SCWeight, A.GroupID " & vbNewLine &
                    "FROM traOrderRequestDet A " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ID=@ORDetailID " & vbNewLine

                .Parameters.Add("@ORDetailID", SqlDbType.VarChar, 100).Value = strORDetailID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                         ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                         ByVal intBPID As Integer, ByVal strOrderRequestID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.OrderRequestID, A1.OrderNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, " & vbNewLine &
                    "   D.Description AS ItemTypeName, A.UnitPrice, A.Quantity-A.SCQuantity AS Quantity, A.Weight, " & vbNewLine &
                    "   A.TotalWeight+A.RoundingWeight-A.SCWeight AS MaxTotalWeight, A.Remarks, A.RoundingWeight, A.OrderNumberSupplier, A.GroupID " & vbNewLine &
                    "FROM traOrderRequestDet A " & vbNewLine &
                    "INNER JOIN traOrderRequest A1 ON " & vbNewLine &
                    "   A.OrderRequestID=A1.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A1.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A1.IsDeleted=0 " & vbNewLine &
                    "   AND A1.StatusID=@StatusID " & vbNewLine &
                    "   AND A1.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalWeight+A.RoundingWeight-A.SCWeight>0 " & vbNewLine &
                    "   AND (((A.TotalPrice-A.ReceiveAmount-A.AllocateDPAmount<=0 Or A.IsIgnoreValidationPayment=1) AND A1.IsStock=1) OR A1.IsStock=0) " & vbNewLine

                If intBPID <> 0 Then .CommandText += "   AND A1.BPID=@BPID " & vbNewLine
                If strOrderRequestID.Trim <> "" Then .CommandText += "  AND A.OrderRequestID=@OrderRequestID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingMapConfirmationOrder(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                             ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                             ByVal strOrderRequestID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.OrderRequestID, A1.OrderNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, " & vbNewLine &
                    "   D.Description AS ItemTypeName, A.UnitPrice, A.Quantity-A.COWeight AS Quantity, A.Weight, " & vbNewLine &
                    "   A.TotalWeight+A.RoundingWeight-A.COWeight AS MaxTotalWeight, A.Remarks, A.RoundingWeight, A.OrderNumberSupplier " & vbNewLine &
                    "FROM traOrderRequestDet A " & vbNewLine &
                    "INNER JOIN traOrderRequest A1 ON " & vbNewLine &
                    "   A.OrderRequestID=A1.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A1.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A1.IsDeleted=0 " & vbNewLine &
                    "   AND A1.StatusID=@StatusID " & vbNewLine &
                    "   AND A1.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalWeight+A.RoundingWeight-A.COWeight>0 " & vbNewLine

                If strOrderRequestID.Trim <> "" Then .CommandText += "  AND A.OrderRequestID=@OrderRequestID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingSalesConfirmationOrder(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                               ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                               ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.OrderRequestID, A1.OrderNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, " & vbNewLine &
                    "   D.Description AS ItemTypeName, A.UnitPrice, A.Quantity-A.SCOQuantity AS Quantity, A.Weight, " & vbNewLine &
                    "   A.TotalWeight+A.RoundingWeight-A.SCOWeight AS MaxTotalWeight, A.Remarks, A.RoundingWeight, A.OrderNumberSupplier, A.GroupID " & vbNewLine &
                    "FROM traOrderRequestDet A " & vbNewLine &
                    "INNER JOIN traOrderRequest A1 ON " & vbNewLine &
                    "   A.OrderRequestID=A1.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A1.ProgramID=@ProgramID " & vbNewLine &
                    "   AND A1.CompanyID=@CompanyID " & vbNewLine &
                    "   AND A1.IsDeleted=0 " & vbNewLine &
                    "   AND A1.StatusID=@StatusID " & vbNewLine &
                    "   AND A1.SubmitBy<>'' " & vbNewLine &
                    "   AND A.TotalWeight+A.RoundingWeight-A.SCOWeight>0 " & vbNewLine

                If intBPID <> 0 Then .CommandText += "   AND A1.BPID=@BPID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function GetMaxIDMapCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strOrderRequestID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT " & vbNewLine &
                        "   COUNT(OrderRequestID) Total " & vbNewLine &
                        "FROM traOrderRequestConfirmationOrder " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   OrderRequestID=@OrderRequestID " & vbNewLine 

                    .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
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

        Public Shared Sub SaveDataMapCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.OrderRequestConfirmationOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traOrderRequestConfirmationOrder " & vbNewLine & _
"	(ID, ProgramID, CompanyID, OrderRequestID, TransactionNumber, Remarks, CreatedBy,  " & vbNewLine & _
"	 CreatedDate, LogBy, LogDate) " & vbNewLine & _
"VALUES " & vbNewLine & _
"	(@ID, @ProgramID, @CompanyID, @OrderRequestID, @TransactionNumber, @Remarks, @LogBy,  " & vbNewLine & _
"	 GETDATE(), @LogBy, GETDATE()) " & vbNewLine
                Else
                    .CommandText =
"UPDATE traOrderRequestConfirmationOrder SET  " & vbNewLine & _
"	ProgramID=@ProgramID,  " & vbNewLine & _
"	CompanyID=@CompanyID,  " & vbNewLine & _
"	OrderRequestID=@OrderRequestID,  " & vbNewLine & _
"	TransactionNumber=@TransactionNumber,  " & vbNewLine & _
"	Remarks=@Remarks,  " & vbNewLine & _
"	LogBy=@LogBy,  " & vbNewLine & _
"	LogDate=GETDATE(),  " & vbNewLine & _
"   LogInc = LogInc + 1 " & vbNewLine & _
"WHERE " & vbNewLine & _
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = clsData.OrderRequestID
                .Parameters.Add("@TransactionNumber", SqlDbType.VarChar, 100).Value = clsData.TransactionNumber
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.OrderRequestDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traOrderRequestDet " & vbNewLine &
                    "     (ID, OrderRequestID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, RoundingWeight, OrderNumberSupplier, UnitPriceHPP, GroupID) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "     (@ID, @OrderRequestID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @RoundingWeight, @OrderNumberSupplier, @UnitPriceHPP, @GroupID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = clsData.OrderRequestID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = clsData.UnitPriceHPP
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.OrderRequestDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traOrderRequestDet SET  " & vbNewLine & _
"	Quantity=@Quantity,  " & vbNewLine & _
"	Weight=@Weight,  " & vbNewLine & _
"	TotalWeight=@TotalWeight,  " & vbNewLine & _
"	UnitPrice=@UnitPrice,  " & vbNewLine & _
"	TotalPrice=@TotalPrice,  " & vbNewLine & _
"	RoundingWeight=@RoundingWeight,  " & vbNewLine & _
"	OrderNumberSupplier=@OrderNumberSupplier,  " & vbNewLine & _
"	UnitPriceHPP=@UnitPriceHPP  " & vbNewLine & _
"WHERE " & vbNewLine & _
"	ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = clsData.UnitPriceHPP
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strOrderRequestID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traOrderRequestDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   OrderRequestID=@OrderRequestID" & vbNewLine

                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strOrderRequestDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
                    "	SCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traSalesContractDet SCD 	" & vbNewLine &
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
                    "			SCD.SCID=SCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.ORDetailID=@OrderRequestDetailID 	" & vbNewLine &
                    "			AND SCD.ParentID='' 	" & vbNewLine &
                    "			AND SCH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	SCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traSalesContractDet SCD 	" & vbNewLine &
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
                    "			SCD.SCID=SCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.ORDetailID=@OrderRequestDetailID 	" & vbNewLine &
                    "			AND SCD.ParentID='' 	" & vbNewLine &
                    "			AND SCH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@OrderRequestDetailID	" & vbNewLine

                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = strOrderRequestDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDCTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strOrderRequestDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
                    "	SCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.TotalWeight+TDD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON	" & vbNewLine &
                    "			TDD.DeliveryID=TDH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@OrderRequestDetailID 	" & vbNewLine &
                    "			AND TDD.ParentID='' 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	SCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(TDD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traDeliveryDet TDD 	" & vbNewLine &
                    "		INNER JOIN traDelivery TDH ON	" & vbNewLine &
                    "			TDD.DeliveryID=TDH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			TDD.SCDetailID=@OrderRequestDetailID 	" & vbNewLine &
                    "			AND TDD.ParentID='' 	" & vbNewLine &
                    "			AND TDH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@OrderRequestDetailID	" & vbNewLine

                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = strOrderRequestDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateCOTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strOrderRequestDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
                    "	COWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ORCOD.TotalWeight+ORCOD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traOrderRequestConfirmationOrderDet ORCOD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ORCOD.ORDetailID=@OrderRequestDetailID 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	COQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ORCOD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traOrderRequestConfirmationOrderDet ORCOD 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ORCOD.ORDetailID=@OrderRequestDetailID 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@OrderRequestDetailID	" & vbNewLine

                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = strOrderRequestDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateSCOTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strOrderRequestDetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
                    "	SCOWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(COD.TotalWeight+COD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traSalesConfirmationOrderDet COD 	" & vbNewLine &
                    "		INNER JOIN traSalesConfirmationOrder COH ON	" & vbNewLine &
                    "			COD.COID=COH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			COD.ORDetailID=@OrderRequestDetailID " & vbNewLine &
                    "			AND COH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	SCOQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(COD.Quantity+COD.RoundingWeight),0) TotalQuantity " & vbNewLine &
                    "		FROM traSalesConfirmationOrderDet COD 	" & vbNewLine &
                    "		INNER JOIN traSalesConfirmationOrder COH ON	" & vbNewLine &
                    "			COD.COID=COH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			COD.ORDetailID=@OrderRequestDetailID " & vbNewLine &
                    "			AND COH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@OrderRequestDetailID	" & vbNewLine

                .Parameters.Add("@OrderRequestDetailID", SqlDbType.VarChar, 100).Value = strOrderRequestDetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SetupIsIgnoreValidationPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                         ByVal strOrderRequestID As String, ByVal bolValue As Boolean)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequestDet SET 	" & vbNewLine &
                    "	IsIgnoreValidationPayment=@Value " & vbNewLine &
                    "WHERE OrderRequestID=@OrderRequestID	" & vbNewLine

                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
                .Parameters.Add("@Value", SqlDbType.Bit).Value = bolValue
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub MapDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                    ByVal strID As String, ByVal strOrderNumberSupplier As String,
                                    ByVal decUnitPriceHPP As Decimal)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traOrderRequestDet SET " & vbNewLine &
                    "   OrderNumberSupplier=@OrderNumberSupplier, " & vbNewLine &
                    "   UnitPriceHPP=@UnitPriceHPP " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = decUnitPriceHPP
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub ChangeItemIDDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String, ByVal intNewItemID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traOrderRequestDet SET  " & vbNewLine &
"	ItemID=@NewItemID " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@NewItemID", SqlDbType.Decimal).Value = intNewItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetailItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.OrderRequestDet
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.OrderRequestDet
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1 " & vbNewLine & _
"	A.ID, A.OrderRequestID, A.ItemID, A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, " & vbNewLine & _
"	A.TotalPrice, A.SCQuantity, A.SCWeight, A.Remarks, A.RoundingWeight, A.OrderNumberSupplier, " & vbNewLine & _
"	A.UnitPriceHPP, A.DPAmount, A.ReceiveAmount, A.IsIgnoreValidationPayment, A.DPAmountPPN, A.DPAmountPPH, " & vbNewLine & _
"	A.ReceiveAmountPPN, A.ReceiveAmountPPH, A.COQuantity, A.COWeight, A.GroupID, A.AllocateDPAmount, " & vbNewLine & _
"   MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length " & vbNewLine & _
"" & vbNewLine & _
"FROM traOrderRequestDet A" & vbNewLine & _
"INNER JOIN mstItem MI ON " & vbNewLine & _
"   A.ItemID=MI.ID " & vbNewLine & _
"WHERE" & vbNewLine & _
"	A.ID=@ID" & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        voReturn.ID = .Item("ID")
                        voReturn.OrderRequestID = .Item("OrderRequestID")
                        voReturn.ItemID = .Item("ItemID")
                        voReturn.Quantity = .Item("Quantity")
                        voReturn.Weight = .Item("Weight")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.UnitPrice = .Item("UnitPrice")
                        voReturn.TotalPrice = .Item("TotalPrice")
                        voReturn.SCQuantity = .Item("SCQuantity")
                        voReturn.SCWeight = .Item("SCWeight")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.RoundingWeight = .Item("RoundingWeight")
                        voReturn.OrderNumberSupplier = .Item("OrderNumberSupplier")
                        voReturn.UnitPriceHPP = .Item("UnitPriceHPP")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.ReceiveAmount = .Item("ReceiveAmount")
                        voReturn.IsIgnoreValidationPayment = .Item("IsIgnoreValidationPayment")
                        voReturn.DPAmountPPN = .Item("DPAmountPPN")
                        voReturn.DPAmountPPH = .Item("DPAmountPPH")
                        voReturn.ReceiveAmountPPN = .Item("ReceiveAmountPPN")
                        voReturn.ReceiveAmountPPH = .Item("ReceiveAmountPPH")
                        voReturn.COQuantity = .Item("COQuantity")
                        voReturn.COWeight = .Item("COWeight")
                        voReturn.GroupID = .Item("GroupID")
                        voReturn.AllocateDPAmount = .Item("AllocateDPAmount")
                        voReturn.ItemCode = .Item("ItemCode")
                        voReturn.ItemName = .Item("ItemName")
                        voReturn.Thick = .Item("Thick")
                        voReturn.Width = .Item("Width")
                        voReturn.Length = .Item("Length")
                    End If
                End With
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try
            Return voReturn 
        End Function

        Public Shared Function ListDataDetailHistorySCItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal strReferencesDetailID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT DISTINCT  " & vbNewLine &
"	SCH.SCNumber AS [Nomor KontraK Penjualan], SCD.GroupID, CAST(SCD.TotalWeight AS DECIMAL(18,2)) AS [Total Berat] " & vbNewLine &
"FROM traSalesContractDet SCD  " & vbNewLine &
"INNER JOIN traSalesContract SCH ON  " & vbNewLine &
"	SCD.SCID=SCH.ID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	SCH.IsDeleted=0  " & vbNewLine &
"	AND SCD.ORDetailID=@ReferencesDetailID " & vbNewLine &
"	AND SCD.ParentID='' " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Detail CO Detail"

        Public Shared Function GetDetailCO(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.OrderRequestConfirmationOrder
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.OrderRequestConfirmationOrder
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1  " & vbNewLine & _
"	A.ID, A.ProgramID, A.CompanyID, A.OrderRequestID, B.OrderNumber, A.TransactionNumber, A.Remarks, A.CreatedBy,  " & vbNewLine & _
"	A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine & _
"FROM traOrderRequestConfirmationOrder A " & vbNewLine & _
"INNER JOIN traOrderRequest B ON " & vbNewLine & _
"   A.OrderRequestID=B.ID " & vbNewLine & _
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
                        voReturn.OrderRequestID = .Item("OrderRequestID")
                        voReturn.TransactionNumber = .Item("TransactionNumber")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Function ListDataDetailCODet(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ParentID, A.ORDetailID, A.CODetailID, A.GroupID, F.CONumber, A.OrderNumberSupplier, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, A.Quantity, A.Weight, A.TotalWeight, " & vbNewLine &
                    "   0 AS MaxTotalWeight, A.UnitPrice, A.TotalPrice, A.Remarks, A.RoundingWeight, E.ItemID AS ItemIDCO, B.ItemCode AS ItemCodeCO, B.ItemName AS ItemNameCO, " & vbNewLine &
                    "   B.Thick AS ThickCO, B.Width AS WidthCO, B.Length AS LengthCO, CCO.ID AS ItemSpecificationIDCO, CCO.Description AS ItemSpecificationNameCO, DCO.ID AS ItemTypeIDCO, " & vbNewLine &
                    "   DCO.Description AS ItemTypeNameCO, A.QuantityCO, A.WeightCO, A.TotalWeightCO, A.UnitPriceCO, A.TotalPriceCO, A.RoundingWeightCO, " & vbNewLine &
                    "   A.LevelItem, A.LocationID, A.UnitPriceHPP, A.DPAmount, A.ReceiveAmount " & vbNewLine &
                    "FROM traOrderRequestConfirmationOrderDet A " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet E ON " & vbNewLine &
                    "   A.CODetailID=E.ID " & vbNewLine &
                    "INNER JOIN traConfirmationOrder F ON " & vbNewLine &
                    "   E.COID=F.ID " & vbNewLine &
                    "INNER JOIN mstItem BCO ON " & vbNewLine &
                    "   E.ItemID=BCO.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification CCO ON " & vbNewLine &
                    "   BCO.ItemSpecificationID=CCO.ID " & vbNewLine &
                    "INNER JOIN mstItemType DCO ON " & vbNewLine &
                    "   BCO.ItemTypeID=DCO.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetailCODet(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.OrderRequestConfirmationOrderDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"INSERT INTO traOrderRequestConfirmationOrderDet " & vbNewLine & _
"	(ID, ParentID, ORDetailID, CODetailID, GroupID, ItemID, Quantity,  " & vbNewLine & _
"	 Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, RoundingWeight,  " & vbNewLine & _
"	 QuantityCO, WeightCO, TotalWeightCO, UnitPriceCO, TotalPriceCO, RoundingWeightCO,  " & vbNewLine & _
"	 LevelItem, LocationID, OrderNumberSupplier, UnitPriceHPP) " & vbNewLine & _
"VALUES  " & vbNewLine & _
"	(@ID, @ParentID, @ORDetailID, @CODetailID, @GroupID, @ItemID, @Quantity,  " & vbNewLine & _
"	 @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @RoundingWeight,  " & vbNewLine & _
"	 @QuantityCO, @WeightCO, @TotalWeightCO, @UnitPriceCO, @TotalPriceCO, @RoundingWeightCO,  " & vbNewLine & _
"	 @LevelItem, @LocationID, @OrderNumberSupplier, @UnitPriceHPP) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@ORDetailID", SqlDbType.VarChar, 100).Value = clsData.ORDetailID
                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = clsData.CODetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@RoundingWeight", SqlDbType.Decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@QuantityCO", SqlDbType.Decimal).Value = clsData.QuantityCO
                .Parameters.Add("@WeightCO", SqlDbType.Decimal).Value = clsData.WeightCO
                .Parameters.Add("@TotalWeightCO", SqlDbType.Decimal).Value = clsData.TotalWeightCO
                .Parameters.Add("@UnitPriceCO", SqlDbType.Decimal).Value = clsData.UnitPriceCO
                .Parameters.Add("@TotalPriceCO", SqlDbType.Decimal).Value = clsData.TotalPriceCO
                .Parameters.Add("@RoundingWeightCO", SqlDbType.Decimal).Value = clsData.RoundingWeightCO
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@LocationID", SqlDbType.Int).Value = clsData.LocationID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@UnitPriceHPP", SqlDbType.Decimal).Value = clsData.UnitPriceHPP
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetailCODet(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traOrderRequestConfirmationOrderDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ParentID=@ParentID" & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
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
                                              ByVal strOrderRequestID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.OrderRequestID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traOrderRequestStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.OrderRequestID=@OrderRequestID " & vbNewLine

                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.OrderRequestStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traOrderRequestStatus " & vbNewLine &
                    "   (ID, OrderRequestID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @OrderRequestID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 30).Value = clsData.ID
                .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = clsData.OrderRequestID
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
                                              ByVal strOrderRequestID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traOrderRequestStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   OrderRequestID=@OrderRequestID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@OrderRequestID", SqlDbType.VarChar, 100).Value = strOrderRequestID
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