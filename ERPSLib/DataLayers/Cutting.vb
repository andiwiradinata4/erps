﻿Namespace DL
    Public Class Cutting

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
                    "   A.ID, A.ProgramID, MP.Name AS ProgramName, A.CompanyID, MC.Name AS CompanyName, A.CuttingNumber, A.CuttingDate, " & vbNewLine &
                    "   A.BPID, C.Code AS BPCode, C.Name AS BPName, A.ReferencesNumber, A.TotalQuantity, A.TotalWeight, A.IsDeleted, A.Remarks, A.StatusID, " & vbNewLine &
                    "   B.Name AS StatusInfo, A.SubmitBy, CASE WHEN A.SubmitBy='' THEN NULL ELSE A.SubmitDate END AS SubmitDate, A.CreatedBy, " & vbNewLine &
                    "   A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.PPN, A.PPH, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, A.DPAmount, A.TotalPayment, " & vbNewLine &
                    "   A.TotalDPP+A.TotalPPN-A.TotalPPh+A.RoundingManual AS GrandTotal " & vbNewLine &
                    "FROM traCutting A " & vbNewLine &
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
                    "   And A.CompanyID=@CompanyID " & vbNewLine &
                    "   And A.CuttingDate>=@DateFrom And A.CuttingDate<=@DateTo " & vbNewLine

                If intStatusID > 0 Then .CommandText += "   And A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = intStatusID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.Cutting)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO traCutting " & vbNewLine &
                        "   (ID, ProgramID, CompanyID, CuttingNumber, CuttingDate, BPID, ReferencesNumber, TotalQuantity, TotalWeight, Remarks, StatusID, CreatedBy, " & vbNewLine &
                        "    CreatedDate, LogBy, LogDate, PPN, PPH, TotalDPP, TotalPPN, TotalPPH, RoundingManual) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "   (@ID, @ProgramID, @CompanyID, @CuttingNumber, @CuttingDate, @BPID, @ReferencesNumber, @TotalQuantity, @TotalWeight, @Remarks, @StatusID, @LogBy, " & vbNewLine &
                        "    GETDATE(), @LogBy, GETDATE(), @PPN, @PPH, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE traCutting SET " & vbNewLine &
                        "   ProgramID=@ProgramID, " & vbNewLine &
                        "   CompanyID=@CompanyID, " & vbNewLine &
                        "   CuttingNumber=@CuttingNumber, " & vbNewLine &
                        "   CuttingDate=@CuttingDate, " & vbNewLine &
                        "   BPID=@BPID, " & vbNewLine &
                        "   ReferencesNumber=@ReferencesNumber, " & vbNewLine &
                        "   TotalQuantity=@TotalQuantity, " & vbNewLine &
                        "   TotalWeight=@TotalWeight, " & vbNewLine &
                        "   Remarks=@Remarks, " & vbNewLine &
                        "   LogInc=LogInc+1, " & vbNewLine &
                        "   LogBy=@LogBy, " & vbNewLine &
                        "   LogDate=GETDATE(), " & vbNewLine &
                        "   PPN=@PPN, " & vbNewLine &
                        "   PPH=@PPH, " & vbNewLine &
                        "   TotalDPP=@TotalDPP, " & vbNewLine &
                        "   TotalPPN=@TotalPPN, " & vbNewLine &
                        "   TotalPPH=@TotalPPH, " & vbNewLine &
                        "   RoundingManual=@RoundingManual " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "   ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@CuttingNumber", SqlDbType.VarChar, 100).Value = clsData.CuttingNumber
                .Parameters.Add("@CuttingDate", SqlDbType.DateTime).Value = clsData.CuttingDate
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@ReferencesNumber", SqlDbType.VarChar, 250).Value = clsData.ReferencesNumber
                .Parameters.Add("@TotalQuantity", SqlDbType.Decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.Decimal).Value = clsData.RoundingManual
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.Cutting
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.Cutting
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ProgramID, A.CompanyID, A.CuttingNumber, A.CuttingDate, A.BPID, B.Code AS BPCode, B.Name AS BPName, A.ReferencesNumber, A.TotalQuantity, A.TotalWeight, " & vbNewLine &
                        "   A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy, A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.PPN, A.PPH, A.TotalDPP, A.TotalPPN, " & vbNewLine &
                        "   A.TotalPPH, A.RoundingManual, A.DPAmount, A.TotalPayment, A.JournalID " & vbNewLine &
                        "FROM traCutting A " & vbNewLine &
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
                        voReturn.CuttingNumber = .Item("CuttingNumber")
                        voReturn.CuttingDate = .Item("CuttingDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.BPCode = .Item("BPCode")
                        voReturn.BPName = .Item("BPName")
                        voReturn.ReferencesNumber = .Item("ReferencesNumber")
                        voReturn.TotalQuantity = .Item("TotalQuantity")
                        voReturn.TotalWeight = .Item("TotalWeight")
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
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.TotalPayment = .Item("TotalPayment")
                        voReturn.JournalID = .Item("JournalID")
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
                    "UPDATE traCutting SET " & vbNewLine &
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
                        "FROM traCutting " & vbNewLine &
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
                                          ByVal strCuttingNumber As String, ByVal strID As String) As Boolean
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
                        "FROM traCutting " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   CuttingNumber=@CuttingNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@CuttingNumber", SqlDbType.VarChar, 100).Value = strCuttingNumber
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
                        "FROM traCutting " & vbNewLine &
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
                        "FROM traCutting " & vbNewLine &
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
                    "UPDATE traCutting SET " & vbNewLine &
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
                    "UPDATE traCutting SET " & vbNewLine &
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
                                              ByVal strCuttingID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.CuttingID, A.PODetailID, A.GroupID, A2.PONumber, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A1.TotalWeight+A.TotalWeight-A1.DoneWeight AS MaxTotalWeight, A.Remarks, A.UnitPrice, A.TotalPrice " & vbNewLine &
                    "FROM traCuttingDet A " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCuttingDet A1 ON " & vbNewLine &
                    "   A.PODetailID=A1.ID " & vbNewLine &
                    "INNER JOIN traPurchaseOrderCutting A2 ON " & vbNewLine &
                    "   A1.POID=A2.ID " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.CuttingID=@CuttingID " & vbNewLine

                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = strCuttingID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.CuttingDet)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traCuttingDet " & vbNewLine &
                    "   (ID, CuttingID, PODetailID, GroupID, ItemID, Quantity, Weight, TotalWeight, Remarks, UnitPrice, TotalPrice) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @CuttingID, @PODetailID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @Remarks, @UnitPrice, @TotalPrice) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = clsData.CuttingID
                .Parameters.Add("@PODetailID", SqlDbType.VarChar, 100).Value = clsData.PODetailID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = clsData.TotalPrice
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strCuttingID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traCuttingDet     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   CuttingID=@CuttingID" & vbNewLine

                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = strCuttingID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail Result"

        Public Shared Function ListDataDetailResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strCuttingID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.CuttingID, A.GroupID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, " & vbNewLine &
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, D.Description AS ItemTypeName, " & vbNewLine &
                    "   A.Quantity, A.Weight, A.TotalWeight, A.Remarks " & vbNewLine &
                    "FROM traCuttingDetResult A " & vbNewLine &
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.CuttingID=@CuttingID " & vbNewLine

                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = strCuttingID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetailResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal clsData As VO.CuttingDetResult)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traCuttingDetResult " & vbNewLine &
                    "   (ID, CuttingID, GroupID, ItemID, Quantity, Weight, TotalWeight, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @CuttingID, @GroupID, @ItemID, @Quantity, @Weight, @TotalWeight, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = clsData.CuttingID
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = clsData.GroupID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetailResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strCuttingID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM traCuttingDetResult     " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   CuttingID=@CuttingID" & vbNewLine

                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = strCuttingID
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
                                              ByVal strCuttingID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.CuttingID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traCuttingStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.CuttingID=@CuttingID " & vbNewLine

                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = strCuttingID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.CuttingStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traCuttingStatus " & vbNewLine &
                    "   (ID, CuttingID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @CuttingID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = clsData.CuttingID
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
                                              ByVal strCuttingID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traCuttingStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   CuttingID=@CuttingID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@CuttingID", SqlDbType.VarChar, 100).Value = strCuttingID
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
