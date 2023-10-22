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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.PONumber, A.PODate, " & vbNewLine & _
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.PersonInCharge, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.DeliveryAddress, " & vbNewLine & _
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine & _
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.ApprovedBy, " & vbNewLine & _
                    "   CASE WHEN A.ApprovedBy = '' THEN NULL ELSE A.ApprovedDate END AS ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traPurchaseOrderCutting A " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "   A.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
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

        Public Shared Function ListDataOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                   ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CAST(0 AS BIT) AS Pick, A.ID AS PurchaseID, A.PONumber AS InvoiceNumber, A.PODate AS InvoiceDate, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual AS PurchaseAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount AS MaxPaymentAmount, " & vbNewLine & _
                    "   CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderCutting A " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "   A.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "   A.ProgramID=MP.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "   A.BPID=@BPID " & vbNewLine & _
                    "   AND A.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A.ApprovedBy<>'' " & vbNewLine & _
                    "   AND A.TotalDPP+A.TotalPPN-A.TotalPPH+A.RoundingManual-A.DPAmount-A.ReceiveAmount>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
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
                    .CommandText = _
                        "INSERT INTO traPurchaseOrderCutting " & vbNewLine & _
                        "   (ID, ProgramID, CompanyID, PONumber, PODate, BPID, PersonInCharge, " & vbNewLine & _
                        "    DeliveryPeriodFrom, DeliveryPeriodTo, DeliveryAddress, PPN, PPH, TotalQuantity, " & vbNewLine & _
                        "    TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, Remarks, StatusID, CreatedBy, " & vbNewLine & _
                        "    CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "   (@ID, @ProgramID, @CompanyID, @PONumber, @PODate, @BPID, @PersonInCharge, " & vbNewLine & _
                        "    @DeliveryPeriodFrom, @DeliveryPeriodTo, @DeliveryAddress, @PPN, @PPH, @TotalQuantity, " & vbNewLine & _
                        "    @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, @Remarks, @StatusID, @LogBy, " & vbNewLine & _
                        "    GETDATE(), @LogBy, GETDATE()) " & vbNewLine
                Else
                    .CommandText = _
                        "UPDATE traPurchaseOrderCutting SET " & vbNewLine & _
                        "    ProgramID=@ProgramID, " & vbNewLine & _
                        "    CompanyID=@CompanyID, " & vbNewLine & _
                        "    PONumber=@PONumber, " & vbNewLine & _
                        "    PODate=@PODate, " & vbNewLine & _
                        "    BPID=@BPID, " & vbNewLine & _
                        "    PersonInCharge=@PersonInCharge, " & vbNewLine & _
                        "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine & _
                        "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine & _
                        "    DeliveryAddress=@DeliveryAddress, " & vbNewLine & _
                        "    PPN=@PPN, " & vbNewLine & _
                        "    PPH=@PPH, " & vbNewLine & _
                        "    TotalQuantity=@TotalQuantity, " & vbNewLine & _
                        "    TotalWeight=@TotalWeight, " & vbNewLine & _
                        "    TotalDPP=@TotalDPP, " & vbNewLine & _
                        "    TotalPPN=@TotalPPN, " & vbNewLine & _
                        "    TotalPPH=@TotalPPH, " & vbNewLine & _
                        "    RoundingManual=@RoundingManual, " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.ProgramID, A.CompanyID, A.PONumber, A.PODate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.PersonInCharge, " & vbNewLine & _
                        "   A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.DeliveryAddress, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, " & vbNewLine & _
                        "   A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.JournalID, A.StatusID, A.SubmitBy, A.SubmitDate, " & vbNewLine & _
                        "   A.ApproveL1, A.ApproveL1Date, A.ApprovedBy, A.ApprovedDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                        "FROM traPurchaseOrderCutting A " & vbNewLine & _
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine & _
                        "   A.BPID=B.ID " & vbNewLine & _
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine & _
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
                        "FROM traPurchaseOrderCutting " & vbNewLine & _
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
                        "FROM traPurchaseOrderCutting " & vbNewLine & _
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
                        "FROM traPurchaseOrderCutting " & vbNewLine & _
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
                        "FROM traPurchaseOrderCutting " & vbNewLine & _
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

        Public Shared Function IsAlreadyDone(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   SUM(DoneQuantity) AS DoneQuantity, SUM(DoneWeight) AS DoneWeight " & vbNewLine & _
                        "FROM traPurchaseOrderCuttingDet " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
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

        Public Shared Sub Submit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                 ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine & _
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine & _
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine & _
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
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine & _
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

        Public Shared Sub CalculateTotalUsedDownPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                        ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseOrderCutting SET 	" & vbNewLine & _
                    "	DPAmount=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(APD.Amount),0) TotalPayment		" & vbNewLine & _
                    "		FROM traAccountPayableDet APD 	" & vbNewLine & _
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine & _
                    "			APD.APID=APH.ID 	" & vbNewLine & _
                    "			AND APH.Modules=@Modules " & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			APD.PurchaseID=@ID 	" & vbNewLine & _
                    "			AND APH.IsDeleted=0 	" & vbNewLine & _
                    "	) " & vbNewLine & _
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

        Public Shared Sub CalculateTotalUsedReceivePayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseOrderCutting SET 	" & vbNewLine & _
                    "	ReceiveAmount=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(APD.Amount),0) TotalPayment		" & vbNewLine & _
                    "		FROM traAccountPayableDet APD 	" & vbNewLine & _
                    "		INNER JOIN traAccountPayable APH ON	" & vbNewLine & _
                    "			APD.APID=APH.ID 	" & vbNewLine & _
                    "			AND APH.Modules=@Modules " & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			APD.PurchaseID=@ID 	" & vbNewLine & _
                    "			AND APH.IsDeleted=0 	" & vbNewLine & _
                    "	) " & vbNewLine & _
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
                    "FROM traPurchaseOrderCutting POH 	" & vbNewLine & _
                    "INNER JOIN mstCompany MC ON 	" & vbNewLine & _
                    "	POH.CompanyID=MC.ID 	" & vbNewLine & _
                    "INNER JOIN mstProgram MP ON 	" & vbNewLine & _
                    "	POH.ProgramID=MP.ID 	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrderCuttingDet POD ON 	" & vbNewLine & _
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

        Public Shared Sub UpdateJournalID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseOrderCutting SET " & vbNewLine & _
                    "    JournalID=@JournalID " & vbNewLine & _
                    "WHERE   " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.POID, A.PCDetailID, A2.PCNumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine & _
                    "   A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.CuttingWeight AS MaxTotalWeight, A.Remarks " & vbNewLine & _
                    "FROM traPurchaseOrderCuttingDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseContractDet A1 ON " & vbNewLine & _
                    "   A.PCDetailID=A1.ID " & vbNewLine & _
                    "INNER JOIN traPurchaseContract A2 ON " & vbNewLine & _
                    "   A1.PCID=A2.ID " & vbNewLine & _
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

        Public Shared Function ListDataDetailOutstandingDone(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                             ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "   A.ID, A.POID, A1.PONumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, 	" & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, 	" & vbNewLine & _
                    "   D.Description AS ItemTypeName, A.UnitPrice, A.Quantity-A.DoneQuantity AS Quantity, A.Weight, " & vbNewLine & _
                    "   A.TotalWeight-A.DoneWeight AS TotalWeight, A.TotalWeight-A.DoneWeight AS MaxTotalWeight, A.Remarks 	" & vbNewLine & _
                    "FROM traPurchaseOrderCuttingDet A 	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrderCutting A1 ON 	" & vbNewLine & _
                    "   A.POID=A1.ID 	" & vbNewLine & _
                    "INNER JOIN mstItem B ON 	" & vbNewLine & _
                    "   A.ItemID=B.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON 	" & vbNewLine & _
                    "   B.ItemSpecificationID=C.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON 	" & vbNewLine & _
                    "   B.ItemTypeID=D.ID 	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "   A1.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND A1.CompanyID=@CompanyID " & vbNewLine & _
                    "   AND A1.IsDeleted=0 " & vbNewLine & _
                    "   AND A1.BPID=@BPID " & vbNewLine & _
                    "   AND A1.StatusID=@StatusID " & vbNewLine & _
                    "   AND A1.ApprovedBy<>'' " & vbNewLine & _
                    "   AND A.Quantity-A.DoneQuantity>0	" & vbNewLine & _
                    "   AND A.TotalWeight-A.DoneWeight>0	" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
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
                .CommandText = _
                    "INSERT INTO traPurchaseOrderCuttingDet " & vbNewLine & _
                    "   (ID, POID, PCDetailID, ItemID, Quantity, Weight, TotalWeight, UnitPrice, TotalPrice, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "   (@ID, @POID, @PCDetailID, @ItemID, @Quantity, @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks) " & vbNewLine

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
                    "DELETE FROM traPurchaseOrderCuttingDet     " & vbNewLine & _
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

        Public Shared Sub CalculateDoneTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strPODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traPurchaseOrderCuttingDet SET 	" & vbNewLine & _
                    "	DoneWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(COD.TotalWeight),0) TotalWeight		" & vbNewLine & _
                    "		FROM traCuttingDet COD 	" & vbNewLine & _
                    "		INNER JOIN traCutting COH ON	" & vbNewLine & _
                    "			COD.CuttingID=COH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			COD.PODetailID=@PODetailID " & vbNewLine & _
                    "			AND COH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	DoneQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(COD.Quantity),0) TotalQuantity " & vbNewLine & _
                    "		FROM traCuttingDet COD 	" & vbNewLine & _
                    "		INNER JOIN traCutting COH ON	" & vbNewLine & _
                    "			COD.CuttingID=COH.ID 	" & vbNewLine & _
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

    End Class

End Namespace