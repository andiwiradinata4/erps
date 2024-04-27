Namespace DL
    Public Class ARAP

#Region "Main"

        Public Shared Function PrintVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                  ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                  ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress, ARH.ARNumber AS TransNumber, " & vbNewLine & _
                    "   ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote, SCH.PPN, SCH.PPH, SCH.TotalDPP, " & vbNewLine & _
                    "	SCH.TotalPPN, SCH.TotalPPH, GrandTotal=SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH+SCH.RoundingManual, MC.DirectorName AS CompanyDirectorName, " & vbNewLine & _
                    "	MBC.AccountName, MBC.BankName, MBC.AccountNumber, ARH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, " & vbNewLine & _
                    "	MI.Length AS ItemLength, MI.Weight, SCD.Quantity, SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, ARH.TotalAmount, ARH.Percentage,  " & vbNewLine & _
                    "   CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate " & vbNewLine & _
                    "FROM traAccountReceivable ARH " & vbNewLine & _
                    "INNER JOIN traAccountReceivableDet ARD ON " & vbNewLine & _
                    "	ARH.ID=ARD.ARID " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "    ARH.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "    ARH.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "    ARH.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "    ARH.ProgramID=MP.ID " & vbNewLine & _
                    "INNER JOIN traSalesContract SCH ON " & vbNewLine & _
                    "	ARD.SalesID=SCH.ID " & vbNewLine & _
                    "INNER JOIN traSalesContractDet SCD ON " & vbNewLine & _
                    "	SCH.ID=SCD.SCID " & vbNewLine & _
                    "INNER JOIN mstItem MI ON 	  " & vbNewLine & _
                    "    SCD.ItemID=MI.ID 	  " & vbNewLine & _
                    "INNER JOIN mstItemType IT ON 	 	  " & vbNewLine & _
                    "    MI.ItemTypeID=IT.ID 	 	  " & vbNewLine & _
                    "INNER JOIN mstItemSpecification MIS ON 	 	  " & vbNewLine & _
                    "    MI.ItemSpecificationID=MIS.ID 	 	  " & vbNewLine & _
                    "INNER JOIN mstCompanyBankAccount MBC ON " & vbNewLine & _
                    "	SCH.CompanyBankAccountID=MBC.ID" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "	ARH.ProgramID=@ProgramID " & vbNewLine & _
                    "	AND ARH.CompanyID=@CompanyID " & vbNewLine & _
                    "	AND ARH.ID=@ID 	" & vbNewLine

                .CommandText +=
                    "UNION ALL  " & vbNewLine & _
                    "SELECT  " & vbNewLine & _
                    "	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress, ARH.ARNumber AS TransNumber,  " & vbNewLine & _
                    "	ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote, SCH.PPN, SCH.PPH, SCH.TotalDPP,  " & vbNewLine & _
                    "	SCH.TotalPPN, SCH.TotalPPH, GrandTotal=SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH+SCH.RoundingManual, MC.DirectorName AS CompanyDirectorName,  " & vbNewLine & _
                    "	MBC.AccountName, MBC.BankName, MBC.AccountNumber, ARH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth,  " & vbNewLine & _
                    "	MI.Length AS ItemLength, MI.Weight, SCD.Quantity, SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, ARH.TotalAmount, ARH.Percentage,   " & vbNewLine & _
                    "   CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate  " & vbNewLine & _
                    "FROM traAccountReceivable ARH  " & vbNewLine & _
                    "INNER JOIN traAccountReceivableDet ARD ON  " & vbNewLine & _
                    "	ARH.ID=ARD.ARID  " & vbNewLine & _
                    "INNER JOIN mstStatus B ON  " & vbNewLine & _
                    "    ARH.StatusID=B.ID  " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON  " & vbNewLine & _
                    "    ARH.BPID=C.ID  " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON  " & vbNewLine & _
                    "    ARH.CompanyID=MC.ID  " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON  " & vbNewLine & _
                    "    ARH.ProgramID=MP.ID  " & vbNewLine & _
                    "INNER JOIN traDelivery TDH ON  " & vbNewLine & _
                    "	ARD.SalesID=TDH.ID  " & vbNewLine & _
                    "INNER JOIN traSalesContract SCH ON  " & vbNewLine & _
                    "	TDH.SCID=SCH.ID  " & vbNewLine & _
                    "INNER JOIN traSalesContractDet SCD ON  " & vbNewLine & _
                    "	SCH.ID=SCD.SCID  " & vbNewLine & _
                    "INNER JOIN mstItem MI ON 	   " & vbNewLine & _
                    "    SCD.ItemID=MI.ID 	   " & vbNewLine & _
                    "INNER JOIN mstItemType IT ON 	 	   " & vbNewLine & _
                    "    MI.ItemTypeID=IT.ID 	 	   " & vbNewLine & _
                    "INNER JOIN mstItemSpecification MIS ON 	 	   " & vbNewLine & _
                    "    MI.ItemSpecificationID=MIS.ID 	 	   " & vbNewLine & _
                    "INNER JOIN mstCompanyBankAccount MBC ON  " & vbNewLine & _
                    "	SCH.CompanyBankAccountID=MBC.ID " & vbNewLine & _
                    "WHERE 	 " & vbNewLine & _
                    "	ARH.ProgramID=@ProgramID  " & vbNewLine & _
                    "	AND ARH.CompanyID=@CompanyID  " & vbNewLine & _
                    "	AND ARH.ID=@ID 	 " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListPaymentHistory(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                  ByVal strReferencesID As String, ByVal dtmTransDate As DateTime,
                                                  ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "	ARD.Amount, ARH.Modules, ARH.Percentage, ARH.ARDate, ARH.CreatedDate  " & vbNewLine & _
                    "FROM traAccountReceivable ARH " & vbNewLine & _
                    "INNER JOIN traAccountReceivableDet ARD ON " & vbNewLine & _
                    "	ARH.ID=ARD.ARID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "	ARD.SalesID=@ReferencesID " & vbNewLine & _
                    "	AND ARH.ProgramID=@ProgramID" & vbNewLine & _
                    "	AND ARH.CompanyID=@CompanyID " & vbNewLine & _
                    "	AND ARH.ARDate<=@TransDate " & vbNewLine & _
                    "	AND ARH.ID<>@ID " & vbNewLine & _
                    "	AND ARH.IsDeleted=0" & vbNewLine & _
                    "ORDER BY ARH.ARDate, ARH.CreatedDate "

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@TransDate", SqlDbType.DateTime).Value = dtmTransDate
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Down Payment"

        Public Shared Sub SaveDataDP(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal clsData As VO.ARAPDP)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPDP " & vbNewLine &
                    "   (ID, ParentID, DPID, DPAmount) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @DPID, @DPAmount) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@DPID", SqlDbType.VarChar, 100).Value = clsData.DPID
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDP(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPDP  " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalAmountUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strID As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If enumDPType = VO.ARAP.ARAPTypeValue.Purchase Then
                    .CommandText =
                        "UPDATE traAccountPayable SET 	" & vbNewLine &
                        "	TotalAmountUsed=	" & vbNewLine &
                        "	(	" & vbNewLine &
                        "		SELECT	" & vbNewLine &
                        "			ISNULL(SUM(DP.DPAmount),0) DPAmount " & vbNewLine &
                        "		FROM traARAPDP DP " & vbNewLine &
                        "		WHERE 	" & vbNewLine &
                        "			DP.DPID=@ID " & vbNewLine &
                        "	) " & vbNewLine &
                        "WHERE ID=@ID " & vbNewLine
                ElseIf enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                    .CommandText =
                        "UPDATE traAccountReceivable SET 	" & vbNewLine &
                        "	TotalAmountUsed=	" & vbNewLine &
                        "	(	" & vbNewLine &
                        "		SELECT	" & vbNewLine &
                        "			ISNULL(SUM(DP.DPAmount),0) DPAmount " & vbNewLine &
                        "		FROM traARAPDP DP " & vbNewLine &
                        "		WHERE 	" & vbNewLine &
                        "			DP.DPID=@ID " & vbNewLine &
                        "	) " & vbNewLine &
                        "WHERE ID=@ID " & vbNewLine
                End If
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Item"

        Public Shared Sub SaveDataItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal clsData As VO.ARAPItem)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPItem " & vbNewLine &
                    "   (ID, ParentID, ReferencesID, ReferencesDetailID, OrderNumberSupplier, ItemID, Amount, PPN, PPH, DPAmount, Rounding) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @ReferencesID, @ReferencesDetailID, @OrderNumberSupplier, @ItemID, @Amount, @PPN, @PPH, @DPAmount, @Rounding) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = clsData.ReferencesID
                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = clsData.ReferencesDetailID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPItem  " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
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