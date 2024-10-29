Namespace DL

    Public Class JournalPost

        Public Shared Function ListDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = <a>
SELECT [ProgramID]
      ,[CoAofRevenue]
      ,[CoAofAccountReceivable]
      ,[CoAofSalesDisc]
      ,[CoAofPrepaidIncome]
      ,[CoAofCOGS]
      ,[CoAofStock]
      ,[CoAofCash]
      ,[CoAofAccountPayable]
      ,[CoAofPurchaseDisc]
      ,[CoAofPurchaseEquipments]
      ,[CoAofAdvancePayment]
      ,[CoAofSalesTax]
      ,[CoAofPurchaseTax]
      ,[Remarks]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[LogInc]
      ,[LogBy]
      ,[LogDate]
      ,[CoAofVentureCapital]
      ,[CoAOfPPHSales]
      ,[CoAOfPPHPurchase]
      ,[CoAofPrepaidIncomeCutting]
      ,[CoAofPrepaidIncomeTransport]
      ,[CoAofStockCutting]
      ,[CoAofStockCutting2]
      ,[CoAofStockCutting3]
      ,[CoAofStockTransport]
      ,[CoAofAccountPayableCutting]
      ,[CoAofAccountPayableCutting2]
      ,[CoAofAccountPayableCutting3]
      ,[CoAofAccountPayableTransport]
      ,[CoAofAccountReceivableOutstandingPayment]
      ,[CoAofAccountPayableOutstandingPayment]
      ,[CoAofAccountPayableCuttingOutstandingPayment]
      ,[CoAofAccountPayableTransportOutstandingPayment]
      ,[CoAOfCutting]
      ,[CoAOfTransport]
      ,[CoAOfCostRawMaterial]
      ,[CoAOfSalesReturn]
  FROM [dbo].[sysJournalPost]
                    </a>.Value
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.JournalPost)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                       "INSERT INTO sysJournalPost " & vbNewLine &
                       "    (ProgramID, CoAofRevenue, CoAofAccountReceivable, CoAofSalesDisc, CoAofPrepaidIncome, CoAofCOGS, CoAofStock, CoAofCash, CoAofAccountPayable,   " & vbNewLine &
                       "     CoAofPurchaseDisc, CoAofPurchaseEquipments, CoAofAdvancePayment, CoAofSalesTax, CoAofPurchaseTax, Remarks, CreatedBy, CreatedDate, LogBy, LogDate, " & vbNewLine &
                       "     CoAofVentureCapital, CoAOfPPHSales, CoAOfPPHPurchase, CoAofPrepaidIncomeCutting, CoAofPrepaidIncomeTransport, CoAofStockCutting, CoAofStockCutting2, " & vbNewLine &
                       "     CoAofStockCutting3, CoAofStockTransport, CoAofAccountPayableCutting, CoAofAccountPayableCutting2, CoAofAccountPayableCutting3, CoAofAccountPayableTransport, " & vbNewLine &
                       "     CoAofAccountReceivableOutstandingPayment, CoAofAccountPayableOutstandingPayment, CoAofAccountPayableCuttingOutstandingPayment, CoAofAccountPayableTransportOutstandingPayment, " & vbNewLine &
                       "     CoAOfCutting, CoAOfTransport, CoAOfCostRawMaterial, CoAOfSalesReturn, CoAofCompensasionRevenue, CoAofClaimCost)   " & vbNewLine &
                       "VALUES " & vbNewLine &
                       "    (@ProgramID, @CoAofRevenue, @CoAofAccountReceivable, @CoAofSalesDisc, @CoAofPrepaidIncome, @CoAofCOGS, @CoAofStock, @CoAofCash, @CoAofAccountPayable,   " & vbNewLine &
                       "     @CoAofPurchaseDisc, @CoAofPurchaseEquipments, @CoAofAdvancePayment, @CoAofSalesTax, @CoAofPurchaseTax, @Remarks, @LogBy, GETDATE(), @LogBy, GETDATE(), " & vbNewLine &
                       "     @CoAofVentureCapital, @CoAOfPPHSales, @CoAOfPPHPurchase, @CoAofPrepaidIncomeCutting, @CoAofPrepaidIncomeTransport, @CoAofStockCutting, @CoAofStockCutting2, " & vbNewLine &
                       "     @CoAofStockCutting3, @CoAofStockTransport, @CoAofAccountPayableCutting, @CoAofAccountPayableCutting2, @CoAofAccountPayableCutting3, @CoAofAccountPayableTransport, " & vbNewLine &
                       "     @CoAofAccountReceivableOutstandingPayment, @CoAofAccountPayableOutstandingPayment, @CoAofAccountPayableCuttingOutstandingPayment, @CoAofAccountPayableTransportOutstandingPayment, " & vbNewLine &
                       "     @CoAOfCutting, @CoAOfTransport, @CoAOfCostRawMaterial, @CoAOfSalesReturn, @CoAofCompensasionRevenue, @CoAofClaimCost)   " & vbNewLine
                Else
                    .CommandText =
                    "UPDATE sysJournalPost SET " & vbNewLine &
                    "    CoAofRevenue=@CoAofRevenue, " & vbNewLine &
                    "    CoAofAccountReceivable=@CoAofAccountReceivable, " & vbNewLine &
                    "    CoAofSalesDisc=@CoAofSalesDisc, " & vbNewLine &
                    "    CoAofPrepaidIncome=@CoAofPrepaidIncome, " & vbNewLine &
                    "    CoAofCOGS=@CoAofCOGS, " & vbNewLine &
                    "    CoAofStock=@CoAofStock, " & vbNewLine &
                    "    CoAofCash=@CoAofCash, " & vbNewLine &
                    "    CoAofAccountPayable=@CoAofAccountPayable, " & vbNewLine &
                    "    CoAofPurchaseDisc=@CoAofPurchaseDisc, " & vbNewLine &
                    "    CoAofPurchaseEquipments=@CoAofPurchaseEquipments, " & vbNewLine &
                    "    CoAofAdvancePayment=@CoAofAdvancePayment, " & vbNewLine &
                    "    CoAofSalesTax=@CoAofSalesTax, " & vbNewLine &
                    "    CoAofPurchaseTax=@CoAofPurchaseTax, " & vbNewLine &
                    "    Remarks=@Remarks, " & vbNewLine &
                    "    LogInc=LogInc+1, " & vbNewLine &
                    "    LogBy=@LogBy, " & vbNewLine &
                    "    LogDate=GETDATE(), " & vbNewLine &
                    "    CoAofVentureCapital=@CoAofVentureCapital, " & vbNewLine &
                    "    CoAOfPPHSales=@CoAOfPPHSales, " & vbNewLine &
                    "    CoAOfPPHPurchase=@CoAOfPPHPurchase, " & vbNewLine &
                    "    CoAofPrepaidIncomeCutting=@CoAofPrepaidIncomeCutting, " & vbNewLine &
                    "    CoAofPrepaidIncomeTransport=@CoAofPrepaidIncomeTransport, " & vbNewLine &
                    "    CoAofStockCutting=@CoAofStockCutting, " & vbNewLine &
                    "    CoAofStockCutting2=@CoAofStockCutting2, " & vbNewLine &
                    "    CoAofStockCutting3=@CoAofStockCutting3, " & vbNewLine &
                    "    CoAofStockTransport=@CoAofStockTransport, " & vbNewLine &
                    "    CoAofAccountPayableCutting=@CoAofAccountPayableCutting, " & vbNewLine &
                    "    CoAofAccountPayableCutting2=@CoAofAccountPayableCutting2, " & vbNewLine &
                    "    CoAofAccountPayableCutting3=@CoAofAccountPayableCutting3, " & vbNewLine &
                    "    CoAofAccountPayableTransport=@CoAofAccountPayableTransport, " & vbNewLine &
                    "    CoAofAccountReceivableOutstandingPayment=@CoAofAccountReceivableOutstandingPayment, " & vbNewLine &
                    "    CoAofAccountPayableOutstandingPayment=@CoAofAccountPayableOutstandingPayment, " & vbNewLine &
                    "    CoAofAccountPayableCuttingOutstandingPayment=@CoAofAccountPayableCuttingOutstandingPayment, " & vbNewLine &
                    "    CoAofAccountPayableTransportOutstandingPayment=@CoAofAccountPayableTransportOutstandingPayment, " & vbNewLine &
                    "    CoAOfCutting=@CoAOfCutting, " & vbNewLine &
                    "    CoAOfTransport=@CoAOfTransport, " & vbNewLine &
                    "    CoAOfCostRawMaterial=@CoAOfCostRawMaterial, " & vbNewLine &
                    "    CoAOfSalesReturn=@CoAOfSalesReturn, " & vbNewLine &
                    "    CoAofCompensasionRevenue=@CoAofCompensasionRevenue, " & vbNewLine &
                    "    CoAofClaimCost=@CoAofClaimCost " & vbNewLine &
                    "WHERE ProgramID=@ProgramID " & vbNewLine
                End If

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CoAofRevenue", SqlDbType.Int).Value = clsData.CoAofRevenue
                .Parameters.Add("@CoAofAccountReceivable", SqlDbType.Int).Value = clsData.CoAofAccountReceivable
                .Parameters.Add("@CoAofSalesDisc", SqlDbType.Int).Value = clsData.CoAofSalesDisc
                .Parameters.Add("@CoAofPrepaidIncome", SqlDbType.Int).Value = clsData.CoAofPrepaidIncome
                .Parameters.Add("@CoAofCOGS", SqlDbType.Int).Value = clsData.CoAofCOGS
                .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = clsData.CoAofStock
                .Parameters.Add("@CoAofCash", SqlDbType.Int).Value = clsData.CoAofCash
                .Parameters.Add("@CoAofAccountPayable", SqlDbType.Int).Value = clsData.CoAofAccountPayable
                .Parameters.Add("@CoAofPurchaseDisc", SqlDbType.Int).Value = clsData.CoAofPurchaseDisc
                .Parameters.Add("@CoAofPurchaseEquipments", SqlDbType.Int).Value = clsData.CoAofPurchaseEquipments
                .Parameters.Add("@CoAofAdvancePayment", SqlDbType.Int).Value = clsData.CoAofAdvancePayment
                .Parameters.Add("@CoAofSalesTax", SqlDbType.Int).Value = clsData.CoAofSalesTax
                .Parameters.Add("@CoAofPurchaseTax", SqlDbType.Int).Value = clsData.CoAofPurchaseTax
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@CoAofVentureCapital", SqlDbType.Int).Value = clsData.CoAofVentureCapital
                .Parameters.Add("@CoAOfPPHSales", SqlDbType.Int).Value = clsData.CoAofPPHSales
                .Parameters.Add("@CoAOfPPHPurchase", SqlDbType.Int).Value = clsData.CoAofPPHPurchase
                .Parameters.Add("@CoAofPrepaidIncomeCutting", SqlDbType.Int).Value = clsData.CoAofPrepaidIncomeCutting
                .Parameters.Add("@CoAofPrepaidIncomeTransport", SqlDbType.Int).Value = clsData.CoAofPrepaidIncomeTransport
                .Parameters.Add("@CoAofStockCutting", SqlDbType.Int).Value = clsData.CoAofStockCutting
                .Parameters.Add("@CoAofStockCutting2", SqlDbType.Int).Value = clsData.CoAofStockCutting2
                .Parameters.Add("@CoAofStockCutting3", SqlDbType.Int).Value = clsData.CoAofStockCutting3
                .Parameters.Add("@CoAofStockTransport", SqlDbType.Int).Value = clsData.CoAofStockTransport
                .Parameters.Add("@CoAofAccountPayableCutting", SqlDbType.Int).Value = clsData.CoAofAccountPayableCutting
                .Parameters.Add("@CoAofAccountPayableCutting2", SqlDbType.Int).Value = clsData.CoAofAccountPayableCutting2
                .Parameters.Add("@CoAofAccountPayableCutting3", SqlDbType.Int).Value = clsData.CoAofAccountPayableCutting3
                .Parameters.Add("@CoAofAccountPayableTransport", SqlDbType.Int).Value = clsData.CoAofAccountPayableTransport
                .Parameters.Add("@CoAofAccountReceivableOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountReceivableOutstandingPayment
                .Parameters.Add("@CoAofAccountPayableOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountPayableOutstandingPayment
                .Parameters.Add("@CoAofAccountPayableCuttingOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountPayableCuttingOutstandingPayment
                .Parameters.Add("@CoAofAccountPayableTransportOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountPayableTransportOutstandingPayment
                .Parameters.Add("@CoAOfCutting", SqlDbType.Int).Value = clsData.CoAOfCutting
                .Parameters.Add("@CoAOfTransport", SqlDbType.Int).Value = clsData.CoAOfTransport
                .Parameters.Add("@CoAOfCostRawMaterial", SqlDbType.Int).Value = clsData.CoAOfCostRawMaterial
                .Parameters.Add("@CoAOfSalesReturn", SqlDbType.Int).Value = clsData.CoAofSalesReturn
                .Parameters.Add("@CoAofCompensasionRevenue", SqlDbType.Int).Value = clsData.CoAofCompensasionRevenue
                .Parameters.Add("@CoAofClaimCost", SqlDbType.Int).Value = clsData.CoAofClaimCost
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.JournalPost)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO sysJournalPost " & vbNewLine &
                    "    (ProgramID, CoAofRevenue, CoAofAccountReceivable, CoAofSalesDisc, CoAofPrepaidIncome, CoAofCOGS, CoAofStock, CoAofCash, CoAofAccountPayable,   " & vbNewLine &
                    "     CoAofPurchaseDisc, CoAofPurchaseEquipments, CoAofAdvancePayment, CoAofSalesTax, CoAofPurchaseTax, Remarks, CreatedBy, CreatedDate, LogBy, LogDate, " & vbNewLine &
                    "     CoAofVentureCapital, CoAOfPPHSales, CoAOfPPHPurchase, CoAofPrepaidIncomeCutting, CoAofPrepaidIncomeTransport, CoAofStockCutting, CoAofStockCutting2, " & vbNewLine &
                    "     CoAofStockCutting3, CoAofStockTransport, CoAofAccountPayableCutting, CoAofAccountPayableCutting2, CoAofAccountPayableCutting3, CoAofAccountPayableTransport, " & vbNewLine &
                    "     CoAofAccountReceivableOutstandingPayment, CoAofAccountPayableOutstandingPayment, CoAofAccountPayableCuttingOutstandingPayment, CoAofAccountPayableTransportOutstandingPayment, " & vbNewLine &
                    "     CoAOfCutting, CoAOfTransport, CoAOfCostRawMaterial, CoAOfSalesReturn, CoAofCompensasionRevenue, CoAofClaimCost)   " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "    (@ProgramID, @CoAofRevenue, @CoAofAccountReceivable, @CoAofSalesDisc, @CoAofPrepaidIncome, @CoAofCOGS, @CoAofStock, @CoAofCash, @CoAofAccountPayable,   " & vbNewLine &
                    "     @CoAofPurchaseDisc, @CoAofPurchaseEquipments, @CoAofAdvancePayment, @CoAofSalesTax, @CoAofPurchaseTax, @Remarks, @LogBy, GETDATE(), @LogBy, GETDATE(), " & vbNewLine &
                    "     @CoAofVentureCapital, @CoAOfPPHSales, @CoAOfPPHPurchase, @CoAofPrepaidIncomeCutting, @CoAofPrepaidIncomeTransport, @CoAofStockCutting, @CoAofStockCutting2, " & vbNewLine &
                    "     @CoAofStockCutting3, @CoAofStockTransport, @CoAofAccountPayableCutting, @CoAofAccountPayableCutting2, @CoAofAccountPayableCutting3, @CoAofAccountPayableTransport, " & vbNewLine &
                    "     @CoAofAccountReceivableOutstandingPayment, @CoAofAccountPayableOutstandingPayment, @CoAofAccountPayableCuttingOutstandingPayment, @CoAofAccountPayableTransportOutstandingPayment, " & vbNewLine &
                    "     @CoAOfCutting, @CoAOfTransport, @CoAOfCostRawMaterial, @CoAOfSalesReturn, @CoAofCompensasionRevenue, @CoAofClaimCost)   " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CoAofRevenue", SqlDbType.Int).Value = clsData.CoAofRevenue
                .Parameters.Add("@CoAofAccountReceivable", SqlDbType.Int).Value = clsData.CoAofAccountReceivable
                .Parameters.Add("@CoAofSalesDisc", SqlDbType.Int).Value = clsData.CoAofSalesDisc
                .Parameters.Add("@CoAofPrepaidIncome", SqlDbType.Int).Value = clsData.CoAofPrepaidIncome
                .Parameters.Add("@CoAofCOGS", SqlDbType.Int).Value = clsData.CoAofCOGS
                .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = clsData.CoAofStock
                .Parameters.Add("@CoAofCash", SqlDbType.Int).Value = clsData.CoAofCash
                .Parameters.Add("@CoAofAccountPayable", SqlDbType.Int).Value = clsData.CoAofAccountPayable
                .Parameters.Add("@CoAofPurchaseDisc", SqlDbType.Int).Value = clsData.CoAofPurchaseDisc
                .Parameters.Add("@CoAofPurchaseEquipments", SqlDbType.Int).Value = clsData.CoAofPurchaseEquipments
                .Parameters.Add("@CoAofAdvancePayment", SqlDbType.Int).Value = clsData.CoAofAdvancePayment
                .Parameters.Add("@CoAofSalesTax", SqlDbType.Int).Value = clsData.CoAofSalesTax
                .Parameters.Add("@CoAofPurchaseTax", SqlDbType.Int).Value = clsData.CoAofPurchaseTax
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = clsData.CreatedBy
                .Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = clsData.CreatedDate
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@LogDate", SqlDbType.DateTime).Value = clsData.LogDate
                .Parameters.Add("@LogInc", SqlDbType.Int).Value = clsData.LogInc
                .Parameters.Add("@CoAofVentureCapital", SqlDbType.Int).Value = clsData.CoAofVentureCapital
                .Parameters.Add("@CoAOfPPHSales", SqlDbType.Int).Value = clsData.CoAofPPHSales
                .Parameters.Add("@CoAOfPPHPurchase", SqlDbType.Int).Value = clsData.CoAofPPHPurchase
                .Parameters.Add("@CoAofPrepaidIncomeCutting", SqlDbType.Int).Value = clsData.CoAofPrepaidIncomeCutting
                .Parameters.Add("@CoAofPrepaidIncomeTransport", SqlDbType.Int).Value = clsData.CoAofPrepaidIncomeTransport
                .Parameters.Add("@CoAofStockCutting", SqlDbType.Int).Value = clsData.CoAofStockCutting
                .Parameters.Add("@CoAofStockCutting2", SqlDbType.Int).Value = clsData.CoAofStockCutting2
                .Parameters.Add("@CoAofStockCutting3", SqlDbType.Int).Value = clsData.CoAofStockCutting3
                .Parameters.Add("@CoAofStockTransport", SqlDbType.Int).Value = clsData.CoAofStockTransport
                .Parameters.Add("@CoAofAccountPayableCutting", SqlDbType.Int).Value = clsData.CoAofAccountPayableCutting
                .Parameters.Add("@CoAofAccountPayableCutting2", SqlDbType.Int).Value = clsData.CoAofAccountPayableCutting2
                .Parameters.Add("@CoAofAccountPayableCutting3", SqlDbType.Int).Value = clsData.CoAofAccountPayableCutting3
                .Parameters.Add("@CoAofAccountPayableTransport", SqlDbType.Int).Value = clsData.CoAofAccountPayableTransport
                .Parameters.Add("@CoAofAccountReceivableOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountReceivableOutstandingPayment
                .Parameters.Add("@CoAofAccountPayableOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountPayableOutstandingPayment
                .Parameters.Add("@CoAofAccountPayableCuttingOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountPayableCuttingOutstandingPayment
                .Parameters.Add("@CoAofAccountPayableTransportOutstandingPayment", SqlDbType.Int).Value = clsData.CoAofAccountPayableTransportOutstandingPayment
                .Parameters.Add("@CoAOfCutting", SqlDbType.Int).Value = clsData.CoAOfCutting
                .Parameters.Add("@CoAOfTransport", SqlDbType.Int).Value = clsData.CoAOfTransport
                .Parameters.Add("@CoAOfCostRawMaterial", SqlDbType.Int).Value = clsData.CoAOfCostRawMaterial
                .Parameters.Add("@CoAOfSalesReturn", SqlDbType.Int).Value = clsData.CoAofSalesReturn
                .Parameters.Add("@CoAofCompensasionRevenue", SqlDbType.Int).Value = clsData.CoAofCompensasionRevenue
                .Parameters.Add("@CoAofClaimCost", SqlDbType.Int).Value = clsData.CoAofClaimCost
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intProgramID As Integer) As VO.JournalPost
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.JournalPost
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 	" & vbNewLine &
                        "   A.CoAofRevenue, ISNULL(CR.Code,'') AS CoACodeofRevenue, ISNULL(CR.Name,'') AS CoANameofRevenue, 	" & vbNewLine &
                        "	A.CoAofAccountReceivable, ISNULL(CAR.Code,'') AS CoACodeofAccountReceivable, ISNULL(CAR.Name,'') AS CoANameofAccountReceivable, 	" & vbNewLine &
                        "	A.CoAofSalesDisc, ISNULL(CSD.Code,'') AS CoACodeofSalesDisc, ISNULL(CSD.Name,'') AS CoANameofSalesDisc, 	" & vbNewLine &
                        "	A.CoAofPrepaidIncome, ISNULL(CPI.Code,'') AS CoACodeofPrepaidIncome, ISNULL(CPI.Name,'') AS CoANameofPrepaidIncome, 	" & vbNewLine &
                        "	A.CoAofCOGS, ISNULL(CCOGS.Code,'') AS CoACodeofCOGS, ISNULL(CCOGS.Name,'') AS CoANameofCOGS, 	" & vbNewLine &
                        "	A.CoAofStock, ISNULL(CST.Code,'') AS CoACodeofStock, ISNULL(CST.Name,'') AS CoANameofStock, 	" & vbNewLine &
                        "	A.CoAofCash, ISNULL(CCASH.Code,'') AS CoACodeofCash, ISNULL(CCASH.Name,'') AS CoANameofCash, 	" & vbNewLine &
                        "	A.CoAofAccountPayable, ISNULL(CAP.Code,'') AS CoACodeofAccountPayable, ISNULL(CAP.Name,'') AS CoANameofAccountPayable, 	" & vbNewLine &
                        "   A.CoAofPurchaseDisc, ISNULL(CPD.Code,'') AS CoACodeofPurchaseDisc, ISNULL(CPD.Name,'') AS CoANameofPurchaseDisc, 	" & vbNewLine &
                        "	A.CoAofPurchaseEquipments, ISNULL(CPE.Code,'') AS CoACodeofPurchaseEquipments, ISNULL(CPE.Name,'') AS CoANameofPurchaseEquipments, 	" & vbNewLine &
                        "	A.CoAofAdvancePayment, ISNULL(CAPP.Code,'') AS CoACodeofAdvancePayment, ISNULL(CAPP.Name,'') AS CoANameofAdvancePayment, 	" & vbNewLine &
                        "	A.CoAofSalesTax, ISNULL(CSTX.Code,'') AS CoACodeofSalesTax, ISNULL(CSTX.Name,'') AS CoANameofSalesTax, 	" & vbNewLine &
                        "	A.CoAofPurchaseTax, ISNULL(CPTX.Code,'') AS CoACodeofPurchaseTax, ISNULL(CPTX.Name,'') AS CoANameofPurchaseTax, 	" & vbNewLine &
                        "	A.CoAofVentureCapital, ISNULL(CVC.Code,'') AS CoACodeofVentureCapital, ISNULL(CVC.Name,'') AS CoANameofVentureCapital, 	" & vbNewLine &
                        "	A.CoAOfPPHSales, ISNULL(PPHS.Code,'') AS CoACodeofPPHSales, ISNULL(PPHS.Name,'') AS CoANameofPPHSales, 	" & vbNewLine &
                        "	A.CoAOfPPHPurchase, ISNULL(PPHP.Code,'') AS CoACodeofPPHPurchase, ISNULL(PPHP.Name,'') AS CoANameofPPHPurchase, 	" & vbNewLine &
                        "	A.CoAofPrepaidIncomeCutting, ISNULL(PIC.Code,'') AS CoACodeofPrepaidIncomeCutting, ISNULL(PIC.Name,'') AS CoANameofPrepaidIncomeCutting, 	" & vbNewLine &
                        "	A.CoAofPrepaidIncomeTransport, ISNULL(PIT.Code,'') AS CoACodeofPrepaidIncomeTransport, ISNULL(PIT.Name,'') AS CoANameofPrepaidIncomeTransport, 	" & vbNewLine &
                        "	A.CoAofStockCutting, ISNULL(CSC.Code,'') AS CoACodeofStockCutting, ISNULL(CSC.Name,'') AS CoANameofStockCutting, 	" & vbNewLine &
                        "	A.CoAofStockCutting2, ISNULL(CSC2.Code,'') AS CoACodeofStockCutting2, ISNULL(CSC2.Name,'') AS CoANameofStockCutting2, 	" & vbNewLine &
                        "	A.CoAofStockCutting3, ISNULL(CSC3.Code,'') AS CoACodeofStockCutting3, ISNULL(CSC3.Name,'') AS CoANameofStockCutting3, 	" & vbNewLine &
                        "	A.CoAofStockTransport, ISNULL(CSTP.Code,'') AS CoACodeofStockTransport, ISNULL(CSTP.Name,'') AS CoANameofStockTransport, 	" & vbNewLine &
                        "	A.CoAofAccountPayableCutting, ISNULL(APC.Code,'') AS CoACodeofAccountPayableCutting, ISNULL(APC.Name,'') AS CoANameofAccountPayableCutting, 	" & vbNewLine &
                        "	A.CoAofAccountPayableCutting2, ISNULL(APC2.Code,'') AS CoACodeofAccountPayableCutting2, ISNULL(APC2.Name,'') AS CoANameofAccountPayableCutting2, 	" & vbNewLine &
                        "	A.CoAofAccountPayableCutting3, ISNULL(APC3.Code,'') AS CoACodeofAccountPayableCutting3, ISNULL(APC3.Name,'') AS CoANameofAccountPayableCutting3, 	" & vbNewLine &
                        "	A.CoAofAccountPayableTransport, ISNULL(APT.Code,'') AS CoACodeofAccountPayableTransport, ISNULL(APT.Name,'') AS CoANameofAccountPayableTransport, 	" & vbNewLine &
                        "	A.CoAofAccountReceivableOutstandingPayment, ISNULL(AROP.Code,'') AS CoACodeofAccountReceivableOutstandingPayment, ISNULL(AROP.Name,'') AS CoANameofAccountReceivableOutstandingPayment, 	" & vbNewLine &
                        "	A.CoAofAccountPayableOutstandingPayment, ISNULL(APOP.Code,'') AS CoACodeofAccountPayableOutstandingPayment, ISNULL(APOP.Name,'') AS CoANameofAccountPayableOutstandingPayment, 	" & vbNewLine &
                        "	A.CoAofAccountPayableCuttingOutstandingPayment, ISNULL(APCOP.Code,'') AS CoACodeofAccountPayableCuttingOutstandingPayment, ISNULL(APCOP.Name,'') AS CoANameofAccountPayableCuttingOutstandingPayment, 	" & vbNewLine &
                        "	A.CoAofAccountPayableTransportOutstandingPayment, ISNULL(APTOP.Code,'') AS CoACodeofAccountPayableTransportOutstandingPayment, ISNULL(APTOP.Name,'') AS CoANameofAccountPayableTransportOutstandingPayment, 	" & vbNewLine &
                        "	A.CoAOfCutting, ISNULL(COC.Code,'') AS CoACodeofCutting, ISNULL(COC.Name,'') AS CoANameofCutting, " & vbNewLine &
                        "	A.CoAofTransport, ISNULL(COT.Code,'') AS CoACodeofTransport, ISNULL(COT.Name,'') AS CoANameofTransport, " & vbNewLine &
                        "	A.CoAOfCostRawMaterial, ISNULL(CORM.Code,'') AS CoACodeofCostRawMaterial, ISNULL(CORM.Name,'') AS CoANameofCostRawMaterial, " & vbNewLine &
                        "	A.Remarks, A.LogBy, A.LogDate, A.LogInc, " & vbNewLine &
                        "	A.CoAOfSalesReturn, ISNULL(COSR.Code,'') AS CoACodeofSalesReturn, ISNULL(COSR.Name,'') AS CoANameofSalesReturn, " & vbNewLine &
                        "	A.CoAofCompensasionRevenue, ISNULL(COCR.Code,'') AS CoACodeofCompensasionRevenue, ISNULL(COCR.Name,'') AS CoANameofCompensasionRevenue, " & vbNewLine &
                        "	A.CoAofClaimCost, ISNULL(COCC.Code,'') AS CoACodeofClaimCost, ISNULL(COCC.Name,'') AS CoANameofClaimCost " & vbNewLine &
                        "FROM sysJournalPost A 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CR ON 	" & vbNewLine &
                        "	A.CoAofRevenue=CR.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CAR ON 	" & vbNewLine &
                        "	A.CoAofAccountReceivable=CAR.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CSD ON 	" & vbNewLine &
                        "	A.CoAofSalesDisc=CSD.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CPI ON 	" & vbNewLine &
                        "	A.CoAofPrepaidIncome=CPI.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CCOGS ON 	" & vbNewLine &
                        "	A.CoAofCOGS=CCOGS.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CST ON 	" & vbNewLine &
                        "	A.CoAofStock=CST.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CCASH ON 	" & vbNewLine &
                        "	A.CoAofCash=CCASH.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CAP ON 	" & vbNewLine &
                        "	A.CoAofAccountPayable=CAP.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CPD ON 	" & vbNewLine &
                        "	A.CoAofPurchaseDisc=CPD.ID 	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CPE ON 	" & vbNewLine &
                        "	A.CoAofPurchaseEquipments=CPE.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CAPP ON 	" & vbNewLine &
                        "	A.CoAofAdvancePayment=CAPP.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CSTX ON 	" & vbNewLine &
                        "	A.CoAofSalesTax=CSTX.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CPTX ON 	" & vbNewLine &
                        "	A.CoAofPurchaseTax=CPTX.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CVC ON 	" & vbNewLine &
                        "	A.CoAofVentureCapital=CVC.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount PPHS ON 	" & vbNewLine &
                        "	A.CoAofPPHSales=PPHS.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount PPHP ON 	" & vbNewLine &
                        "	A.CoAofPPHPurchase=PPHP.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount PIC ON 	" & vbNewLine &
                        "	A.CoAofPrepaidIncomeCutting=PIC.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount PIT ON 	" & vbNewLine &
                        "	A.CoAofPrepaidIncomeTransport=PIT.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CSC ON 	" & vbNewLine &
                        "	A.CoAofStockCutting=CSC.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CSC2 ON 	" & vbNewLine &
                        "	A.CoAofStockCutting2=CSC2.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CSC3 ON 	" & vbNewLine &
                        "	A.CoAofStockCutting3=CSC3.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CSTP ON 	" & vbNewLine &
                        "	A.CoAofStockTransport=CSTP.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount APC ON 	" & vbNewLine &
                        "	A.CoAofAccountPayableCutting=APC.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount APC2 ON 	" & vbNewLine &
                        "	A.CoAofAccountPayableCutting2=APC2.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount APC3 ON 	" & vbNewLine &
                        "	A.CoAofAccountPayableCutting3=APC3.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount APT ON 	" & vbNewLine &
                        "	A.CoAofAccountPayableTransport=APT.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount AROP ON 	" & vbNewLine &
                        "	A.CoAofAccountReceivableOutstandingPayment=AROP.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount APOP ON 	" & vbNewLine &
                        "	A.CoAofAccountPayableOutstandingPayment=APOP.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount APCOP ON 	" & vbNewLine &
                        "	A.CoAofAccountPayableCuttingOutstandingPayment=APCOP.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount APTOP ON 	" & vbNewLine &
                        "	A.CoAofAccountPayableTransportOutstandingPayment=APTOP.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COC ON 	" & vbNewLine &
                        "	A.CoAOfCutting=COC.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COT ON 	" & vbNewLine &
                        "	A.CoAOfTransport=COT.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount CORM ON 	" & vbNewLine &
                        "	A.CoAOfCostRawMaterial=CORM.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COSR ON 	" & vbNewLine &
                        "	A.CoAOfSalesReturn=COSR.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COCR ON 	" & vbNewLine &
                        "	A.CoAofCompensasionRevenue=COCR.ID	" & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COCC ON 	" & vbNewLine &
                        "	A.CoAofClaimCost=COCC.ID	" & vbNewLine &
                        "WHERE " & vbNewLine &
                        "	A.ProgramID=@ProgramID " & vbNewLine

                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.CoAofRevenue = .Item("CoAofRevenue")
                        voReturn.CoACodeofRevenue = .Item("CoACodeofRevenue")
                        voReturn.CoANameofRevenue = .Item("CoANameofRevenue")

                        voReturn.CoAofAccountReceivable = .Item("CoAofAccountReceivable")
                        voReturn.CoACodeofAccountReceivable = .Item("CoACodeofAccountReceivable")
                        voReturn.CoANameofAccountReceivable = .Item("CoANameofAccountReceivable")

                        voReturn.CoAofSalesDisc = .Item("CoAofSalesDisc")
                        voReturn.CoACodeofSalesDisc = .Item("CoACodeofSalesDisc")
                        voReturn.CoANameofSalesDisc = .Item("CoANameofSalesDisc")

                        voReturn.CoAofPrepaidIncome = .Item("CoAofPrepaidIncome")
                        voReturn.CoACodeofPrepaidIncome = .Item("CoACodeofPrepaidIncome")
                        voReturn.CoANameofPrepaidIncome = .Item("CoANameofPrepaidIncome")

                        voReturn.CoAofCOGS = .Item("CoAofCOGS")
                        voReturn.CoACodeofCOGS = .Item("CoACodeofCOGS")
                        voReturn.CoANameofCOGS = .Item("CoANameofCOGS")

                        voReturn.CoAofStock = .Item("CoAofStock")
                        voReturn.CoACodeofStock = .Item("CoACodeofStock")
                        voReturn.CoANameofStock = .Item("CoANameofStock")

                        voReturn.CoAofCash = .Item("CoAofCash")
                        voReturn.CoACodeofCash = .Item("CoACodeofCash")
                        voReturn.CoANameofCash = .Item("CoANameofCash")

                        voReturn.CoAofAccountPayable = .Item("CoAofAccountPayable")
                        voReturn.CoACodeofAccountPayable = .Item("CoACodeofAccountPayable")
                        voReturn.CoANameofAccountPayable = .Item("CoANameofAccountPayable")

                        voReturn.CoAofPurchaseDisc = .Item("CoAofPurchaseDisc")
                        voReturn.CoACodeofPurchaseDisc = .Item("CoACodeofPurchaseDisc")
                        voReturn.CoANameofPurchaseDisc = .Item("CoANameofPurchaseDisc")

                        voReturn.CoAofPurchaseEquipments = .Item("CoAofPurchaseEquipments")
                        voReturn.CoACodeofPurchaseEquipments = .Item("CoACodeofPurchaseEquipments")
                        voReturn.CoANameofPurchaseEquipments = .Item("CoANameofPurchaseEquipments")

                        voReturn.CoAofAdvancePayment = .Item("CoAofAdvancePayment")
                        voReturn.CoACodeofAdvancePayment = .Item("CoACodeofAdvancePayment")
                        voReturn.CoANameofAdvancePayment = .Item("CoANameofAdvancePayment")

                        voReturn.CoAofSalesTax = .Item("CoAofSalesTax")
                        voReturn.CoACodeofSalesTax = .Item("CoACodeofSalesTax")
                        voReturn.CoANameofSalesTax = .Item("CoANameofSalesTax")

                        voReturn.CoAofPurchaseTax = .Item("CoAofPurchaseTax")
                        voReturn.CoACodeofPurchaseTax = .Item("CoACodeofPurchaseTax")
                        voReturn.CoANameofPurchaseTax = .Item("CoANameofPurchaseTax")

                        voReturn.CoAofVentureCapital = .Item("CoAofVentureCapital")
                        voReturn.CoACodeofVentureCapital = .Item("CoACodeofVentureCapital")
                        voReturn.CoANameofVentureCapital = .Item("CoANameofVentureCapital")

                        voReturn.CoAofPPHSales = .Item("CoAOfPPHSales")
                        voReturn.CoACodeofPPHSales = .Item("CoACodeofPPHSales")
                        voReturn.CoANameofPPHSales = .Item("CoANameofPPHSales")

                        voReturn.CoAofPPHPurchase = .Item("CoAOfPPHPurchase")
                        voReturn.CoACodeofPPHPurchase = .Item("CoACodeofPPHPurchase")
                        voReturn.CoANameofPPHPurchase = .Item("CoANameofPPHPurchase")

                        voReturn.CoAofPrepaidIncomeCutting = .Item("CoAofPrepaidIncomeCutting")
                        voReturn.CoACodeofPrepaidIncomeCutting = .Item("CoACodeofPrepaidIncomeCutting")
                        voReturn.CoANameofPrepaidIncomeCutting = .Item("CoANameofPrepaidIncomeCutting")

                        voReturn.CoAofPrepaidIncomeTransport = .Item("CoAofPrepaidIncomeTransport")
                        voReturn.CoACodeofPrepaidIncomeTransport = .Item("CoACodeofPrepaidIncomeTransport")
                        voReturn.CoANameofPrepaidIncomeTransport = .Item("CoANameofPrepaidIncomeTransport")

                        voReturn.CoAofStockCutting = .Item("CoAofStockCutting")
                        voReturn.CoACodeofStockCutting = .Item("CoACodeofStockCutting")
                        voReturn.CoANameofStockCutting = .Item("CoANameofStockCutting")

                        voReturn.CoAofStockCutting2 = .Item("CoAofStockCutting2")
                        voReturn.CoACodeofStockCutting2 = .Item("CoACodeofStockCutting2")
                        voReturn.CoANameofStockCutting2 = .Item("CoANameofStockCutting2")

                        voReturn.CoAofStockCutting3 = .Item("CoAofStockCutting3")
                        voReturn.CoACodeofStockCutting3 = .Item("CoACodeofStockCutting3")
                        voReturn.CoANameofStockCutting3 = .Item("CoANameofStockCutting3")

                        voReturn.CoAofStockTransport = .Item("CoAofStockTransport")
                        voReturn.CoACodeofStockTransport = .Item("CoACodeofStockTransport")
                        voReturn.CoANameofStockTransport = .Item("CoANameofStockTransport")

                        voReturn.CoAofAccountPayableCutting = .Item("CoAofAccountPayableCutting")
                        voReturn.CoACodeofAccountPayableCutting = .Item("CoACodeofAccountPayableCutting")
                        voReturn.CoANameofAccountPayableCutting = .Item("CoANameofAccountPayableCutting")

                        voReturn.CoAofAccountPayableCutting2 = .Item("CoAofAccountPayableCutting2")
                        voReturn.CoACodeofAccountPayableCutting2 = .Item("CoACodeofAccountPayableCutting2")
                        voReturn.CoANameofAccountPayableCutting2 = .Item("CoANameofAccountPayableCutting2")

                        voReturn.CoAofAccountPayableCutting3 = .Item("CoAofAccountPayableCutting3")
                        voReturn.CoACodeofAccountPayableCutting3 = .Item("CoACodeofAccountPayableCutting3")
                        voReturn.CoANameofAccountPayableCutting3 = .Item("CoANameofAccountPayableCutting3")

                        voReturn.CoAofAccountPayableTransport = .Item("CoAofAccountPayableTransport")
                        voReturn.CoACodeofAccountPayableTransport = .Item("CoACodeofAccountPayableTransport")
                        voReturn.CoANameofAccountPayableTransport = .Item("CoANameofAccountPayableTransport")

                        voReturn.CoAofAccountReceivableOutstandingPayment = .Item("CoAofAccountReceivableOutstandingPayment")
                        voReturn.CoACodeofAccountReceivableOutstandingPayment = .Item("CoACodeofAccountReceivableOutstandingPayment")
                        voReturn.CoANameofAccountReceivableOutstandingPayment = .Item("CoANameofAccountReceivableOutstandingPayment")

                        voReturn.CoAofAccountPayableOutstandingPayment = .Item("CoAofAccountPayableOutstandingPayment")
                        voReturn.CoACodeofAccountPayableOutstandingPayment = .Item("CoACodeofAccountPayableOutstandingPayment")
                        voReturn.CoANameofAccountPayableOutstandingPayment = .Item("CoANameofAccountPayableOutstandingPayment")

                        voReturn.CoAofAccountPayableCuttingOutstandingPayment = .Item("CoAofAccountPayableCuttingOutstandingPayment")
                        voReturn.CoACodeofAccountPayableCuttingOutstandingPayment = .Item("CoACodeofAccountPayableCuttingOutstandingPayment")
                        voReturn.CoANameofAccountPayableCuttingOutstandingPayment = .Item("CoANameofAccountPayableCuttingOutstandingPayment")

                        voReturn.CoAofAccountPayableTransportOutstandingPayment = .Item("CoAofAccountPayableTransportOutstandingPayment")
                        voReturn.CoACodeofAccountPayableTransportOutstandingPayment = .Item("CoACodeofAccountPayableTransportOutstandingPayment")
                        voReturn.CoANameofAccountPayableTransportOutstandingPayment = .Item("CoANameofAccountPayableTransportOutstandingPayment")

                        voReturn.CoAOfCutting = .Item("CoAOfCutting")
                        voReturn.CoACodeofCutting = .Item("CoACodeofCutting")
                        voReturn.CoANameofCutting = .Item("CoANameofCutting")

                        voReturn.CoAOfTransport = .Item("CoAofTransport")
                        voReturn.CoACodeofTransport = .Item("CoACodeofTransport")
                        voReturn.CoANameofTransport = .Item("CoANameofTransport")

                        voReturn.CoAOfCostRawMaterial = .Item("CoAOfCostRawMaterial")
                        voReturn.CoACodeofCostRawMaterial = .Item("CoACodeofCostRawMaterial")
                        voReturn.CoANameofCostRawMaterial = .Item("CoANameofCostRawMaterial")

                        voReturn.Remarks = .Item("Remarks")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")

                        voReturn.CoAofSalesReturn = .Item("CoAOfSalesReturn")
                        voReturn.CoACodeofSalesReturn = .Item("CoACodeofSalesReturn")
                        voReturn.CoANameofSalesReturn = .Item("CoANameofSalesReturn")

                        voReturn.CoAofCompensasionRevenue = .Item("CoAofCompensasionRevenue")
                        voReturn.CoACodeofCompensasionRevenue = .Item("CoACodeofCompensasionRevenue")
                        voReturn.CoANameofCompensasionRevenue = .Item("CoANameofCompensasionRevenue")

                        voReturn.CoAofClaimCost = .Item("CoAofClaimCost")
                        voReturn.CoACodeofClaimCost = .Item("CoACodeofClaimCost")
                        voReturn.CoANameofClaimCost = .Item("CoANameofClaimCost")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   CoAofRevenue " & vbNewLine &
                        "FROM sysJournalPost " & vbNewLine &
                        "WHERE ProgramID=@ProgramID " & vbNewLine

                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = UI.usUserApp.ProgramID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolExists = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolExists
        End Function

        Public Shared Sub DeleteDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                   "DELETE sysJournalPost " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

    End Class

End Namespace

