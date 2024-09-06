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
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.CONumber, A.CODate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, " & vbNewLine &
                    "   A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal, A.IsDeleted, A.Remarks, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                    "   A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.IsUseSubItem " & vbNewLine &
                    "FROM traConfirmationOrder A " & vbNewLine &
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
                    .CommandText =
                        "INSERT INTO traConfirmationOrder " & vbNewLine &
                        "   (ID, ProgramID, CompanyID, CONumber, CODate, BPID, DeliveryPeriodFrom, DeliveryPeriodTo, " & vbNewLine &
                        "    AllowanceProduction, PPN, PPH, TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, " & vbNewLine &
                        "    RoundingManual, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, IsUseSubItem) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @CONumber, @CODate, @BPID, @DeliveryPeriodFrom, @DeliveryPeriodTo, " & vbNewLine &
                        "    @AllowanceProduction, @PPN, @PPH, @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, " & vbNewLine &
                        "    @RoundingManual, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), @IsUseSubItem) " & vbNewLine


                Else
                    .CommandText =
                        "UPDATE traConfirmationOrder SET " & vbNewLine &
                        "    ProgramID=@ProgramID, " & vbNewLine &
                        "    CompanyID=@CompanyID, " & vbNewLine &
                        "    CONumber=@CONumber, " & vbNewLine &
                        "    CODate=@CODate, " & vbNewLine &
                        "    BPID=@BPID, " & vbNewLine &
                        "    DeliveryPeriodFrom=@DeliveryPeriodFrom, " & vbNewLine &
                        "    DeliveryPeriodTo=@DeliveryPeriodTo, " & vbNewLine &
                        "    AllowanceProduction=@AllowanceProduction, " & vbNewLine &
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
                        "    IsUseSubItem=@IsUseSubItem " & vbNewLine &
                        "WHERE   " & vbNewLine &
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
                .Parameters.Add("@IsUseSubItem", SqlDbType.Bit).Value = clsData.IsUseSubItem
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdatePCID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String, ByVal strPCID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traConfirmationOrder SET " & vbNewLine &
                    "    PCID=@PCID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@PCID", SqlDbType.VarChar, 100).Value = strPCID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.ConfirmationOrder
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ConfirmationOrder
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ProgramID, A.CompanyID, A.CONumber, A.CODate, A.BPID, B.Code AS BPCode, B.Name AS BPName, " & vbNewLine &
                        "   A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, " & vbNewLine &
                        "   A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                        "   A.LogInc, A.LogBy, A.LogDate, A.PCID, ISNULL(PC.PCNumber,'') AS PCNumber, ISNULL(PC.Franco,'') AS Franco, A.IsUseSubItem " & vbNewLine &
                        "FROM traConfirmationOrder A " & vbNewLine &
                        "INNER JOIN mstBusinessPartner B ON " & vbNewLine &
                        "   A.BPID=B.ID " & vbNewLine &
                        "LEFT JOIN traPurchaseContract PC ON " & vbNewLine &
                        "   A.PCID=PC.ID " & vbNewLine &
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
                        voReturn.CONumber = .Item("CONumber")
                        voReturn.CODate = .Item("CODate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
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
                        voReturn.PCID = .Item("PCID")
                        voReturn.PCNumber = .Item("PCNumber")
                        voReturn.Franco = .Item("Franco")
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
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
                    "UPDATE traConfirmationOrder SET " & vbNewLine &
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
                        "FROM traConfirmationOrder " & vbNewLine &
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
                                          ByVal strCONumber As String, ByVal strID As String) As Boolean
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
                        "FROM traConfirmationOrder " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   CONumber=@CONumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@CONumber", SqlDbType.VarChar, 100).Value = strCONumber
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
                        "FROM traConfirmationOrder " & vbNewLine &
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
                        "FROM traConfirmationOrder " & vbNewLine &
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

        Public Shared Function IsAlreadyPurchaseContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   SUM(PCQuantity) AS PCQuantity, SUM(PCWeight) AS PCWeight " & vbNewLine &
                        "FROM traConfirmationOrderDet " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   COID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        If .Item("PCQuantity") > 0 Or .Item("PCWeight") > 0 Then
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
                .CommandText =
                    "UPDATE traConfirmationOrder SET " & vbNewLine &
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
                    "UPDATE traConfirmationOrder SET " & vbNewLine &
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

        Public Shared Sub Done(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                 ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traConfirmationOrder SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    DoneBy=@LogBy, " & vbNewLine &
                    "    DoneDate=GETDATE() " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Done
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = ERPSLib.UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub Undone(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                 ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traConfirmationOrder SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    DoneBy='' " & vbNewLine &
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

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strCOID As String, ByVal strParentID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.COID, A2.PONumber, A.PODetailID, A.OrderNumberSupplier, A.DeliveryAddress, " & vbNewLine &
                    "   A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, C.ID AS ItemSpecificationID, " & vbNewLine &
                    "   C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, A.Quantity,   " & vbNewLine &
                    "   A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.COWeight AS MaxTotalWeight, A.PCQuantity, A.PCWeight,   " & vbNewLine &
                    "   A.DCQuantity, A.DCWeight, A.Remarks, A.LevelItem, A.ParentID, A.RoundingWeight " & vbNewLine &
                    "FROM traConfirmationOrderDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderDet A1 ON " & vbNewLine &
                    "   A.PODetailID=A1.ID " & vbNewLine &
                    "INNER JOIN traPurchaseOrder A2 ON " & vbNewLine &
                    "   A1.POID=A2.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "    A.COID=@COID" & vbNewLine &
                    "    AND A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingPurchaseContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                         ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                         ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "	COD.ID, COD.COID, COH.CONumber, COD.OrderNumberSupplier, COD.DeliveryAddress, COD.ItemID, MI.ItemCode, MI.ItemName, " & vbNewLine &
                    "   MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, " & vbNewLine &
                    "   MIT.Description AS ItemTypeName, COD.Quantity-COD.PCQuantity AS Quantity, COD.Weight, COD.TotalWeight-COD.PCWeight AS TotalWeight, " & vbNewLine &
                    "   COD.UnitPrice, COD.TotalPrice, POD.RoundingWeight 	" & vbNewLine &
                    "FROM traPurchaseOrderDet POD 	" & vbNewLine &
                    "INNER JOIN traPurchaseOrder POH ON 	" & vbNewLine &
                    "	POD.POID=POH.ID 	" & vbNewLine &
                    "INNER JOIN traConfirmationOrderDet COD ON 	" & vbNewLine &
                    "	POD.ID=COD.PODetailID 	" & vbNewLine &
                    "INNER JOIN traConfirmationOrder COH ON 	" & vbNewLine &
                    "	COD.COID=COH.ID 	" & vbNewLine &
                    "INNER JOIN mstItem MI ON 	" & vbNewLine &
                    "	COD.ItemID=MI.ID 	" & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON 	" & vbNewLine &
                    "	MI.ItemSpecificationID=MIS.ID 	" & vbNewLine &
                    "INNER JOIN mstItemType MIT ON 	" & vbNewLine &
                    "	MI.ItemTypeID=MIT.ID  	" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "	COH.IsDeleted=0 	" & vbNewLine &
                    "   And COH.ProgramID=@ProgramID " & vbNewLine &
                    "   And COH.CompanyID=@CompanyID " & vbNewLine &
                    "	And COH.StatusID=@StatusID 	" & vbNewLine &
                    "	And COH.BPID=@BPID " & vbNewLine &
                    "	And COD.TotalWeight+COD.RoundingWeight-COD.PCWeight>0 	" & vbNewLine


                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingSalesContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                      ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                      ByVal strParentID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT 	" & vbNewLine &
                    "   COD.ID, COD.COID, COH.CONumber, COD.OrderNumberSupplier, COD.ItemID, B.ItemCode, " & vbNewLine &
                    "	B.ItemName, B.Thick, B.Width, B.Length, C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, " & vbNewLine &
                    "	D.ID AS ItemTypeID, D.Description AS ItemTypeName, COD.Quantity-COD.SCQuantity AS Quantity, " & vbNewLine &
                    "   COD.Weight, COD.TotalWeight-COD.SCWeight AS TotalWeight, COD.UnitPrice, COD.TotalPrice, " & vbNewLine &
                    "   COD.TotalWeight+COD.RoundingWeight-COD.SCWeight AS MaxTotalWeight, COD.RoundingWeight, COD.LevelItem, COD.ParentID 	" & vbNewLine &
                    "FROM traConfirmationOrderDet COD 	" & vbNewLine &
                    "INNER JOIN traConfirmationOrder COH ON 	" & vbNewLine &
                    "	COD.COID=COH.ID 	" & vbNewLine &
                    "INNER JOIN mstItem B ON  	" & vbNewLine &
                    "    COD.ItemID=B.ID  	" & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine &
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine &
                    "INNER JOIN mstItemType D ON  	" & vbNewLine &
                    "    B.ItemTypeID=D.ID  	" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "   COH.ProgramID=@ProgramID " & vbNewLine &
                    "   And COH.CompanyID=@CompanyID " & vbNewLine &
                    "	And COH.SubmitBy<>''	" & vbNewLine &
                    "	AND COH.IsDeleted=0 	" & vbNewLine &
                    "	AND COH.IsDone=0 	" & vbNewLine &
                    "	AND COH.StatusID=@StatusID 	" & vbNewLine &
                    "	AND COD.TotalWeight+COD.RoundingWeight-COD.SCWeight>0	" & vbNewLine &
                    "	AND COD.PCWeight>0	" & vbNewLine &
                    "	AND COD.ParentID=@ParentID " & vbNewLine &
                    "	AND COH.DoneBy='' " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDeliveryAddressDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.DeliveryAddress " & vbNewLine &
                    "FROM traConfirmationOrderDet A " & vbNewLine

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ConfirmationOrderDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                   "INSERT INTO traConfirmationOrderDet " & vbNewLine &
                   "    (ID, COID, PODetailID, OrderNumberSupplier, DeliveryAddress, ItemID, Quantity,   " & vbNewLine &
                   "     Weight, TotalWeight, UnitPrice, TotalPrice, Remarks, LevelItem, ParentID, RoundingWeight)   " & vbNewLine &
                   "VALUES " & vbNewLine &
                   "    (@ID, @COID, @PODetailID, @OrderNumberSupplier, @DeliveryAddress, @ItemID, @Quantity,   " & vbNewLine &
                   "     @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks, @LevelItem, @ParentID, @RoundingWeight)  " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = clsData.COID
                .Parameters.Add("@PODetailID", SqlDbType.VarChar, 100).Value = clsData.PODetailID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@DeliveryAddress", SqlDbType.VarChar, 1000).Value = clsData.DeliveryAddress
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
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

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strCOID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traConfirmationOrderDet " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   COID=@COID " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function OrderNumberSupplierExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                         ByVal strID As String, ByVal strOrderNumberSupplier As String,
                                                         ByVal intItemID As Integer) As String
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim strReturn As String = ""
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   COH.CONumber " & vbNewLine &
                        "FROM traConfirmationOrderDet COD " & vbNewLine &
                        "INNER JOIN traConfirmationOrder COH ON " & vbNewLine &
                        "   COD.COID=COH.ID " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   COD.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
                        "   AND COD.ItemID=@ItemID " & vbNewLine &
                        "   AND COH.IsDeleted=0 " & vbNewLine &
                        "   AND COH.ID<>@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strReturn = .Item("CONumber")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return strReturn
        End Function

        Public Shared Sub CalculatePCTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strCODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traConfirmationOrderDet SET 	" & vbNewLine &
                    "	PCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.TotalWeight+PCD.RoundingWeight),0) TotalWeight		" & vbNewLine &
                    "		FROM traPurchaseContractDet PCD 	" & vbNewLine &
                    "		INNER JOIN traPurchaseContract PCH ON	" & vbNewLine &
                    "			PCD.PCID=PCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.CODetailID=@CODetailID 	" & vbNewLine &
                    "			AND PCH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	PCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(PCD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traPurchaseContractDet PCD 	" & vbNewLine &
                    "		INNER JOIN traPurchaseContract PCH ON	" & vbNewLine &
                    "			PCD.PCID=PCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			PCD.CODetailID=@CODetailID 	" & vbNewLine &
                    "			AND PCH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@CODetailID	" & vbNewLine

                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = strCODetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateSCTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strCODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traConfirmationOrderDet SET 	" & vbNewLine &
                    "	SCWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traSalesContractDetConfirmationOrder SCD 	" & vbNewLine &
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
                    "			SCD.SCID=SCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.CODetailID=@CODetailID 	" & vbNewLine &
                    "			AND SCH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	SCQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(SCD.Quantity),0) TotalQuantity " & vbNewLine &
                    "		FROM traSalesContractDetConfirmationOrder SCD 	" & vbNewLine &
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
                    "			SCD.SCID=SCH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			SCD.CODetailID=@CODetailID 	" & vbNewLine &
                    "			AND SCH.IsDeleted=0 	" & vbNewLine &
                    "	) 	" & vbNewLine &
                    "WHERE ID=@CODetailID	" & vbNewLine

                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = strCODetailID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateORTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strCODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traConfirmationOrderDet SET 	" & vbNewLine &
                    "	ORWeight=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ORD.TotalWeight+ORD.RoundingWeight),0) TotalWeight " & vbNewLine &
                    "		FROM traOrderRequestDetConfirmationOrder ORD 	" & vbNewLine &
                    "		INNER JOIN traOrderRequest ORH ON	" & vbNewLine &
                    "			ORD.SCID=ORH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ORD.CODetailID=@CODetailID 	" & vbNewLine &
                    "			AND ORH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "	ORQuantity=	" & vbNewLine &
                    "	(	" & vbNewLine &
                    "		SELECT	" & vbNewLine &
                    "			ISNULL(SUM(ORD.Quantity),0) TotalWeight " & vbNewLine &
                    "		FROM traOrderRequestDetConfirmationOrder ORD 	" & vbNewLine &
                    "		INNER JOIN traOrderRequest ORH ON	" & vbNewLine &
                    "			ORD.SCID=ORH.ID 	" & vbNewLine &
                    "		WHERE 	" & vbNewLine &
                    "			ORD.CODetailID=@CODetailID 	" & vbNewLine &
                    "			AND ORH.IsDeleted=0 	" & vbNewLine &
                    "	), 	" & vbNewLine &
                    "WHERE ID=@CODetailID	" & vbNewLine

                .Parameters.Add("@CODetailID", SqlDbType.VarChar, 100).Value = strCODetailID
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
                    "FROM traConfirmationOrderPaymentTerm A " & vbNewLine &
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
                                              ByVal clsData As VO.ConfirmationOrderPaymentTerm)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traConfirmationOrderPaymentTerm " & vbNewLine &
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
                    "DELETE FROM traConfirmationOrderPaymentTerm     " & vbNewLine &
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
                    "FROM traConfirmationOrderStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.COID=@COID " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ConfirmationOrderStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traConfirmationOrderStatus " & vbNewLine &
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
                        "FROM traConfirmationOrderStatus " & vbNewLine &
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