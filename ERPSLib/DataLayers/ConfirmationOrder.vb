﻿Namespace DL
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
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.CONumber, A.CODate, " & vbNewLine & _
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
                        "    @RoundingManual, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine


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

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.ConfirmationOrder
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ConfirmationOrder
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.ProgramID, A.CompanyID, A.CONumber, A.CODate, A.BPID, B.Code AS BPCode, B.Name AS BPName, " & vbNewLine & _
                        "   A.DeliveryPeriodFrom, A.DeliveryPeriodTo, A.AllowanceProduction, A.PPN, A.PPH, A.TotalQuantity, A.TotalWeight, A.TotalDPP, " & vbNewLine & _
                        "   A.TotalPPN, A.TotalPPH, A.RoundingManual, A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy, A.CreatedDate, " & vbNewLine & _
                        "   A.LogInc, A.LogBy, A.LogDate " & vbNewLine & _
                        "FROM traConfirmationOrder A " & vbNewLine & _
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
                    "UPDATE traConfirmationOrder SET " & vbNewLine & _
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
                        "FROM traConfirmationOrder " & vbNewLine & _
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
                                          ByVal strCONumber As String, ByVal strID As String) As Boolean
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
                        "FROM traConfirmationOrder " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   CONumber=@CONumber " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   StatusID " & vbNewLine & _
                        "FROM traConfirmationOrder " & vbNewLine & _
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
                        "FROM traConfirmationOrder " & vbNewLine & _
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

        Public Shared Function IsAlreadyPurchaseContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   SUM(PCQuantity) AS PCQuantity, SUM(PCWeight) AS PCWeight " & vbNewLine & _
                        "FROM traConfirmationOrderDet " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traConfirmationOrder SET " & vbNewLine & _
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
                    "UPDATE traConfirmationOrder SET " & vbNewLine & _
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

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strCOID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.COID, A2.PONumber, A.PODetailID, A.OrderNumberSupplier, A.DeliveryAddress, " & vbNewLine & _
                    "   A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, C.ID AS ItemSpecificationID, " & vbNewLine & _
                    "   C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, A.Quantity,   " & vbNewLine & _
                    "   A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.TotalWeight+A.TotalWeight-A1.COWeight AS MaxTotalWeight, A.PCQuantity, A.PCWeight,   " & vbNewLine & _
                    "   A.DCQuantity, A.DCWeight, A.Remarks  " & vbNewLine & _
                    "FROM traConfirmationOrderDet A " & vbNewLine & _
                    "INNER JOIN traPurchaseOrderDet A1 ON " & vbNewLine & _
                    "   A.PODetailID=A1.ID " & vbNewLine & _
                    "INNER JOIN traPurchaseOrder A2 ON " & vbNewLine & _
                    "   A1.POID=A2.ID " & vbNewLine & _
                    "INNER JOIN mstItem B ON " & vbNewLine & _
                    "   A.ItemID=B.ID " & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine & _
                    "   B.ItemSpecificationID=C.ID " & vbNewLine & _
                    "INNER JOIN mstItemType D ON " & vbNewLine & _
                    "   B.ItemTypeID=D.ID " & vbNewLine & _
                    "WHERE  " & vbNewLine & _
                    "    A.COID=@COID" & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "	COD.ID, COD.COID, COH.CONumber, COD.OrderNumberSupplier, COD.DeliveryAddress, COD.ItemID, MI.ItemCode, MI.ItemName, " & vbNewLine & _
                    "   MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, " & vbNewLine & _
                    "   MIT.Description AS ItemTypeName, COD.Quantity-COD.PCQuantity AS Quantity, COD.Weight, COD.TotalWeight-COD.PCWeight AS TotalWeight, COD.UnitPrice, COD.TotalPrice 	" & vbNewLine & _
                    "FROM traPurchaseOrderDet POD 	" & vbNewLine & _
                    "INNER JOIN traPurchaseOrder POH ON 	" & vbNewLine & _
                    "	POD.POID=POH.ID 	" & vbNewLine & _
                    "INNER JOIN traConfirmationOrderDet COD ON 	" & vbNewLine & _
                    "	POD.ID=COD.PODetailID 	" & vbNewLine & _
                    "INNER JOIN traConfirmationOrder COH ON 	" & vbNewLine & _
                    "	COD.COID=COH.ID 	" & vbNewLine & _
                    "INNER JOIN mstItem MI ON 	" & vbNewLine & _
                    "	COD.ItemID=MI.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification MIS ON 	" & vbNewLine & _
                    "	MI.ItemSpecificationID=MIS.ID 	" & vbNewLine & _
                    "INNER JOIN mstItemType MIT ON 	" & vbNewLine & _
                    "	MI.ItemTypeID=MIT.ID  	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "	COH.IsDeleted=0 	" & vbNewLine & _
                    "   AND COH.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND COH.CompanyID=@CompanyID " & vbNewLine & _
                    "	AND COH.StatusID=@StatusID 	" & vbNewLine & _
                    "	AND COH.BPID=@BPID " & vbNewLine & _
                    "	AND COD.TotalWeight-COD.PCWeight>0 	" & vbNewLine & _
                    "	AND COD.Quantity-COD.PCQuantity>0	" & vbNewLine


                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataDetailOutstandingSalesContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                      ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT 	" & vbNewLine & _
                    "   COD.ID, COD.COID, COH.CONumber, COD.OrderNumberSupplier, COD.ItemID, B.ItemCode, " & vbNewLine & _
                    "	B.ItemName, B.Thick, B.Width, B.Length, C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, " & vbNewLine & _
                    "	D.ID AS ItemTypeID, D.Description AS ItemTypeName, COD.Quantity-COD.SCQuantity AS Quantity, " & vbNewLine & _
                    "   COD.Weight, COD.TotalWeight-COD.SCWeight AS TotalWeight, COD.UnitPrice, COD.TotalPrice, COD.TotalWeight-COD.SCWeight AS MaxTotalWeight 	" & vbNewLine & _
                    "FROM traConfirmationOrderDet COD 	" & vbNewLine & _
                    "INNER JOIN traConfirmationOrder COH ON 	" & vbNewLine & _
                    "	COD.COID=COH.ID 	" & vbNewLine & _
                    "INNER JOIN mstItem B ON  	" & vbNewLine & _
                    "    COD.ItemID=B.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemSpecification C ON  	" & vbNewLine & _
                    "    B.ItemSpecificationID=C.ID  	" & vbNewLine & _
                    "INNER JOIN mstItemType D ON  	" & vbNewLine & _
                    "    B.ItemTypeID=D.ID  	" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "   COH.ProgramID=@ProgramID " & vbNewLine & _
                    "   AND COH.CompanyID=@CompanyID " & vbNewLine & _
                    "	AND COH.SubmitBy<>''	" & vbNewLine & _
                    "	AND COH.IsDeleted=0 	" & vbNewLine & _
                    "	AND COH.StatusID=@StatusID 	" & vbNewLine & _
                    "	AND COD.TotalWeight-COD.SCWeight>0	" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
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
                .CommandText = _
                   "INSERT INTO traConfirmationOrderDet " & vbNewLine & _
                   "    (ID, COID, PODetailID, OrderNumberSupplier, DeliveryAddress, ItemID, Quantity,   " & vbNewLine & _
                   "     Weight, TotalWeight, UnitPrice, TotalPrice, Remarks)   " & vbNewLine & _
                   "VALUES " & vbNewLine & _
                   "    (@ID, @COID, @PODetailID, @OrderNumberSupplier, @DeliveryAddress, @ItemID, @Quantity,   " & vbNewLine & _
                   "     @Weight, @TotalWeight, @UnitPrice, @TotalPrice, @Remarks)  " & vbNewLine

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
                .CommandText = _
                    "DELETE FROM traConfirmationOrderDet " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   COID=@COID " & vbNewLine

                .Parameters.Add("@COID", SqlDbType.VarChar, 100).Value = strCOID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculatePCTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strCODetailID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traConfirmationOrderDet SET 	" & vbNewLine & _
                    "	PCWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(PCD.TotalWeight),0) TotalWeight		" & vbNewLine & _
                    "		FROM traPurchaseContractDet PCD 	" & vbNewLine & _
                    "		INNER JOIN traPurchaseContract PCH ON	" & vbNewLine & _
                    "			PCD.PCID=PCH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			PCD.CODetailID=@CODetailID 	" & vbNewLine & _
                    "			AND PCH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	PCQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(PCD.Quantity),0) TotalQuantity " & vbNewLine & _
                    "		FROM traPurchaseContractDet PCD 	" & vbNewLine & _
                    "		INNER JOIN traPurchaseContract PCH ON	" & vbNewLine & _
                    "			PCD.PCID=PCH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			PCD.CODetailID=@CODetailID 	" & vbNewLine & _
                    "			AND PCH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
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
                .CommandText = _
                    "UPDATE traConfirmationOrderDet SET 	" & vbNewLine & _
                    "	SCWeight=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(SCD.TotalWeight),0) TotalWeight " & vbNewLine & _
                    "		FROM traSalesContractDetConfirmationOrder SCD 	" & vbNewLine & _
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine & _
                    "			SCD.SCID=SCH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			SCD.CODetailID=@CODetailID 	" & vbNewLine & _
                    "			AND SCH.IsDeleted=0 	" & vbNewLine & _
                    "	), 	" & vbNewLine & _
                    "	SCQuantity=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(SCD.Quantity),0) TotalQuantity " & vbNewLine & _
                    "		FROM traSalesContractDetConfirmationOrder SCD 	" & vbNewLine & _
                    "		INNER JOIN traSalesContract SCH ON	" & vbNewLine & _
                    "			SCD.SCID=SCH.ID 	" & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			SCD.CODetailID=@CODetailID 	" & vbNewLine & _
                    "			AND SCH.IsDeleted=0 	" & vbNewLine & _
                    "	) 	" & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.COID, A.Percentage, A.PaymentTypeID, B.Code AS PaymentTypeCode, B.Name AS PaymentTypeName, " & vbNewLine & _
                    "   A.PaymentModeID, C.Code AS PaymentModeCode, C.Name AS PaymentModeName, A.CreditTerm, A.Remarks " & vbNewLine & _
                    "FROM traConfirmationOrderPaymentTerm A " & vbNewLine & _
                    "INNER JOIN mstPaymentType B ON " & vbNewLine & _
                    "   A.PaymentTypeID=B.ID " & vbNewLine & _
                    "INNER JOIN mstPaymentMode C ON " & vbNewLine & _
                    "   A.PaymentModeID=C.ID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "INSERT INTO traConfirmationOrderPaymentTerm " & vbNewLine & _
                    "   (ID, COID, Percentage, PaymentTypeID, PaymentModeID, CreditTerm, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
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
                .CommandText = _
                    "DELETE FROM traConfirmationOrderPaymentTerm     " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   A.ID, A.COID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine & _
                    "FROM traConfirmationOrderStatus A " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "INSERT INTO traConfirmationOrderStatus " & vbNewLine & _
                    "   (ID, COID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine & _
                    "VALUES " & vbNewLine & _
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
                    .CommandText = _
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine & _
                        "FROM traConfirmationOrderStatus " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   COID=@COID " & vbNewLine & _
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