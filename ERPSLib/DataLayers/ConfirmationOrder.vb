Namespace DL
    Public Class ConfirmationOrder

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
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, " & vbNewLine & _
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, " & vbNewLine & _
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, A.IsDeleted, A.Remarks, A.StatusID, B.Name AS StatusInfo, " & vbNewLine & _
                    "   A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                    "FROM traConfirmationOrder A " & vbNewLine & _
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
                    "   AND A.CODate>=@DateFrom AND A.CODate<=@DateTo " & vbNewLine

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
                                   ByVal bolNew As Boolean, ByVal clsData As VO.ConfirmationOrder)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO traConfirmationOrder " & vbNewLine & _
                        "   (ID, ProgramID, CompanyID, CONumber, CODate, BPID, DeliveryPeriodFrom, DeliveryPeriodTo, " & vbNewLine & _
                        "    AllowanceProduction, PPN, PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, " & vbNewLine & _
                        "    RoundingManual, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "   (@ID, @ProgramID, @CompanyID, @CONumber, @CODate, @BPID, @DeliveryPeriodFrom, @DeliveryPeriodTo, " & vbNewLine & _
                        "    @AllowanceProduction, @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, " & vbNewLine & _
                        "    @RoundingManual, @Remarks, @StatusID, @LogBy, @GETDATE(), @LogBy, GETDATE()) " & vbNewLine


                Else
                    .CommandText = _
                        "UPDATE traConfirmationOrder SET " & vbNewLine & _
                        "    ProgramID=@ProgramID, " & vbNewLine & _
                        "    CompanyID=@CompanyID, " & vbNewLine & _
                        "    CONumber=@CONumber, " & vbNewLine & _
                        "    CODate=@CODate, " & vbNewLine & _
                        "    BPID=@BPID, " & vbNewLine & _
                        "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine & _
                        "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine & _
                        "    AllowanceProduction=@AllowanceProduction, " & vbNewLine & _
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
                .Parameters.Add("@CONumber", SqlDbType.VarChar, 100).Value = clsData.CONumber
                .Parameters.Add("@CODate", SqlDbType.DateTime).Value = clsData.CODate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@DeliveryPeriodFrom", SqlDbType.DateTime).Value = clsData.DeliveryPeriodFrom
                .Parameters.Add("@DeliveryPeriodTo", SqlDbType.DateTime).Value = clsData.DeliveryPeriodTo
                .Parameters.Add("@AllowanceProduction", SqlDbType.Decimal).Value = clsData.AllowanceProduction
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

        Public Shared Function GetDetail(ByVal strID) As VO.ConfirmationOrder
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim voReturn As New VO.ConfirmationOrder
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlCmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
 "     A.ID, A.ProgramID, A.CompanyID, A.CONumber, A.CODate, A.BPID, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
 "FROM traConfirmationOrder A " & vbNewLine & _
 "WHERE " & vbNewLine & _
 "    ID=@ID " & vbNewLine
                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans

                End With
                sqlrdData = sqlCmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.CONumber = .Item("CONumber")
                        voReturn.CODate = .Item("CODate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.DeliveryPeriodFrom = .Item("DeliveryPeriodFrom")
                        voReturn.DeliveryPeriodTo = .Item("DeliveryPeriodTo")
                        voReturn.AllowanceProduction = .Item("AllowanceProduction")
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

                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteData(ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .CommandText = _
                    "DELETE FROM traConfirmationOrder     " & vbNewLine & _
 "WHERE " & vbNewLine & _
 "      ID=@ID " & vbNewLine
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID

            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID() As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim intReturn As Integer = 0
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlCmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT ISNULL(MAX(ID),0) AS ID FROM traConfirmationOrder " & vbNewLine & _
 "    WHERE " & vbNewLine & _
 "        ID=@ID " & vbNewLine
                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlCmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return intReturn
        End Function

        Public Shared Function DataExists(ByVal intProgramID As String) As Boolean
            Dim bolDataExists As Boolean = False
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlCmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT  " & vbNewLine & _
                        "     COUNT(1) As Total      " & vbNewLine & _
                        "FROM traConfirmationOrder     " & vbNewLine & _
                        "WHERE      " & vbNewLine & _
                            "ProgramID=@ProgramID"
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlCmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        If .Item("Total") > 0 Then
                            bolDataExists = True
                        Else
                            bolDataExists = False
                        End If
                    Else
                        bolDataExists = False
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return bolDataExists
        End Function

#End Region

    End Class

End Namespace