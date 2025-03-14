Namespace DL
    Public Class Setup

        Public Shared Sub CalculateTotalSCWeightInPurchaseContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @PCDetailID VARCHAR(100) " & vbNewLine &
"DECLARE db_cursor CURSOR FOR " & vbNewLine &
"SELECT DISTINCT PCD.ID  " & vbNewLine &
"FROM traPurchaseContractDet PCD  " & vbNewLine &
"INNER JOIN traPurchaseContract PCH ON  " & vbNewLine &
"	PCD.PCID=PCH.ID  " & vbNewLine &
"WHERE PCH.IsDeleted=0 AND PCD.ParentID=''  " & vbNewLine &
"OPEN db_cursor; " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine &
"WHILE @@FETCH_STATUS = 0 " & vbNewLine &
"BEGIN " & vbNewLine &
" " & vbNewLine &
"UPDATE traPurchaseContractDet SET 	  " & vbNewLine &
"    SCWeight=	  " & vbNewLine &
"    (	  " & vbNewLine &
"        SELECT	  " & vbNewLine &
"            ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight  " & vbNewLine &
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine &
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine &
"            SCD.SCID=SCH.ID 	  " & vbNewLine &
"        WHERE 	  " & vbNewLine &
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine &
"            And SCH.IsDeleted=0 	  " & vbNewLine &
"    ), 	  " & vbNewLine &
"    SCQuantity=	  " & vbNewLine &
"    (	  " & vbNewLine &
"        SELECT	  " & vbNewLine &
"            ISNULL(SUM(SCD.Quantity),0) TotalQuantity   " & vbNewLine &
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine &
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine &
"            SCD.SCID=SCH.ID 	  " & vbNewLine &
"        WHERE 	  " & vbNewLine &
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine &
"            And SCH.IsDeleted=0 	  " & vbNewLine &
"    ) 	  " & vbNewLine &
"WHERE ID=@PCDetailID	  " & vbNewLine &
" " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine &
"END " & vbNewLine &
" " & vbNewLine &
"CLOSE db_cursor; " & vbNewLine &
"DEALLOCATE db_cursor; " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalSCWeightSubItemInPurchaseContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @PCDetailID VARCHAR(100) " & vbNewLine &
"DECLARE db_cursor CURSOR FOR " & vbNewLine &
"SELECT DISTINCT PCD.ID  " & vbNewLine &
"FROM traPurchaseContractDet PCD  " & vbNewLine &
"INNER JOIN traPurchaseContract PCH ON  " & vbNewLine &
"	PCD.PCID=PCH.ID  " & vbNewLine &
"WHERE PCH.IsDeleted=0 AND PCD.ParentID<>''  " & vbNewLine &
"OPEN db_cursor; " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine &
"WHILE @@FETCH_STATUS = 0 " & vbNewLine &
"BEGIN " & vbNewLine &
" " & vbNewLine &
"UPDATE traPurchaseContractDet SET 	  " & vbNewLine &
"    SCWeight=	  " & vbNewLine &
"    (	  " & vbNewLine &
"        SELECT	  " & vbNewLine &
"            ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight  " & vbNewLine &
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine &
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine &
"            SCD.SCID=SCH.ID 	  " & vbNewLine &
"        WHERE 	  " & vbNewLine &
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine &
"            And SCH.IsDeleted=0 	  " & vbNewLine &
"    ), 	  " & vbNewLine &
"    SCQuantity=	  " & vbNewLine &
"    (	  " & vbNewLine &
"        SELECT	  " & vbNewLine &
"            ISNULL(SUM(SCD.Quantity),0) TotalQuantity   " & vbNewLine &
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine &
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine &
"            SCD.SCID=SCH.ID 	  " & vbNewLine &
"        WHERE 	  " & vbNewLine &
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine &
"            And SCH.IsDeleted=0 	  " & vbNewLine &
"    ) 	  " & vbNewLine &
"WHERE ID=@PCDetailID	  " & vbNewLine &
" " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine &
"END " & vbNewLine &
" " & vbNewLine &
"CLOSE db_cursor; " & vbNewLine &
"DEALLOCATE db_cursor; " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalTotalPaymentSalesContractHeader(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @ID VARCHAR(100) " & vbNewLine &
"DECLARE db_cursor CURSOR FOR " & vbNewLine &
"SELECT DISTINCT SCH.ID  " & vbNewLine &
"FROM traSalesContract SCH  " & vbNewLine &
"WHERE SCH.IsDeleted=0 AND SCH.StatusID=@StatusID " & vbNewLine &
"OPEN db_cursor; " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ID; " & vbNewLine &
"WHILE @@FETCH_STATUS = 0 " & vbNewLine &
"BEGIN " & vbNewLine &
" " & vbNewLine &
"UPDATE traSalesContract SET 	  " & vbNewLine &
"	ReceiveAmount=	  " & vbNewLine &
"	(	  " & vbNewLine &
"SELECT	  " & vbNewLine &
"	ISNULL(SUM(TDH.ReceiveAmount),0) ReceiveAmount   " & vbNewLine &
"FROM traSalesContractDet TDH   " & vbNewLine &
"WHERE 	  " & vbNewLine &
"	TDH.SCID=@ID 	  " & vbNewLine &
"	AND TDH.ParentID=''   " & vbNewLine &
"	),   " & vbNewLine &
"	ReceiveAmountPPN=	  " & vbNewLine &
"	(	  " & vbNewLine &
"SELECT	  " & vbNewLine &
"	ISNULL(SUM(TDH.ReceiveAmountPPN),0) ReceiveAmountPPN   " & vbNewLine &
"FROM traSalesContractDet TDH   " & vbNewLine &
"WHERE 	  " & vbNewLine &
"	TDH.SCID=@ID 	  " & vbNewLine &
"	AND TDH.ParentID=''   " & vbNewLine &
"	),   " & vbNewLine &
"	ReceiveAmountPPH=	  " & vbNewLine &
"	(	  " & vbNewLine &
"SELECT	  " & vbNewLine &
"	ISNULL(SUM(TDH.ReceiveAmountPPH),0) ReceiveAmountPPH   " & vbNewLine &
"FROM traSalesContractDet TDH   " & vbNewLine &
"WHERE 	  " & vbNewLine &
"	TDH.SCID=@ID 	  " & vbNewLine &
"	AND TDH.ParentID=''   " & vbNewLine &
"	)   " & vbNewLine &
"WHERE ID=@ID   " & vbNewLine &
" " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ID; " & vbNewLine &
"END " & vbNewLine &
" " & vbNewLine &
"CLOSE db_cursor; " & vbNewLine &
"DEALLOCATE db_cursor; " & vbNewLine

                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePayment
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalTotalPaymentSalesContractParentItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @ReferencesDetailID VARCHAR(100) " & vbNewLine &
"DECLARE db_cursor CURSOR FOR " & vbNewLine &
"SELECT DISTINCT SCD.ID  " & vbNewLine &
"FROM traSalesContractDet SCD  " & vbNewLine &
"INNER JOIN traSalesContract SCH ON  " & vbNewLine &
"	SCD.SCID=SCH.ID  " & vbNewLine &
"WHERE SCH.IsDeleted=0 AND SCH.StatusID=@StatusID AND SCD.ParentID='' AND SCD.ReceiveAmount<=0 " & vbNewLine &
"OPEN db_cursor; " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ReferencesDetailID; " & vbNewLine &
"WHILE @@FETCH_STATUS = 0 " & vbNewLine &
"BEGIN " & vbNewLine &
" " & vbNewLine &
"UPDATE traSalesContractDet SET 	  " & vbNewLine &
"AllocateDPAmount=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.AllocateDPAmount),0) DPAmount   " & vbNewLine &
"    FROM traSalesContractDet TDD " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine &
"),   " & vbNewLine &
"ReceiveAmount=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.ReceiveAmount),0) ReceiveAmount   " & vbNewLine &
"    FROM traSalesContractDet TDD " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine &
"),   " & vbNewLine &
"ReceiveAmountPPN=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.ReceiveAmountPPN),0) PPN   " & vbNewLine &
"    FROM traSalesContractDet TDD " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine &
"),   " & vbNewLine &
"ReceiveAmountPPH=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.ReceiveAmountPPH),0) PPH   " & vbNewLine &
"    FROM traSalesContractDet TDD " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine &
"),   " & vbNewLine &
"InvoiceQuantity=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.InvoiceQuantity),0) Quantity   " & vbNewLine &
"    FROM traSalesContractDet TDD " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine &
"),   " & vbNewLine &
"InvoiceTotalWeight=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.InvoiceTotalWeight),0) Weight   " & vbNewLine &
"    FROM traSalesContractDet TDD " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine &
")   " & vbNewLine &
"WHERE ID=@ReferencesDetailID   " & vbNewLine &
" " & vbNewLine &
" " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ReferencesDetailID; " & vbNewLine &
"END " & vbNewLine &
" " & vbNewLine &
"CLOSE db_cursor; " & vbNewLine &
"DEALLOCATE db_cursor; " & vbNewLine &
" " & vbNewLine
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePayment
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub ResetTotalPaymentSalesContractItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = "UPDATE traSalesContractDet SET AllocateDPAmount=0, ReceiveAmount=0, ReceiveAmountPPN=0, ReceiveAmountPPH=0, InvoiceQuantity=0, InvoiceTotalWeight=0 " & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalTotalPaymentSalesContractItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @ReferencesDetailID VARCHAR(100) " & vbNewLine &
"DECLARE db_cursor CURSOR FOR " & vbNewLine &
"SELECT DISTINCT SCD.ID  " & vbNewLine &
"FROM traSalesContractDet SCD  " & vbNewLine &
"INNER JOIN traSalesContract SCH ON  " & vbNewLine &
"	SCD.SCID=SCH.ID  " & vbNewLine &
"WHERE SCH.IsDeleted=0 AND SCH.StatusID=@StatusID " & vbNewLine &
"OPEN db_cursor; " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ReferencesDetailID; " & vbNewLine &
"WHILE @@FETCH_STATUS = 0 " & vbNewLine &
"BEGIN " & vbNewLine &
" " & vbNewLine &
"UPDATE traSalesContractDet SET 	  " & vbNewLine &
"AllocateDPAmount=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.DPAmount),0) DPAmount   " & vbNewLine &
"    FROM traARAPItem TDD   " & vbNewLine &
"    INNER JOIN traAccountReceivable AR ON   " & vbNewLine &
"        TDD.ParentID=AR.ID    " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ReferencesDetailID=@ReferencesDetailID 	  " & vbNewLine &
"        AND AR.IsDeleted=0   " & vbNewLine &
"        AND AR.Modules=@Modules   " & vbNewLine &
"),   " & vbNewLine &
"ReceiveAmount=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.Amount),0) ReceiveAmount   " & vbNewLine &
"    FROM traARAPItem TDD   " & vbNewLine &
"    INNER JOIN traAccountReceivable AR ON   " & vbNewLine &
"        TDD.ParentID=AR.ID    " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ReferencesDetailID=@ReferencesDetailID 	  " & vbNewLine &
"        AND AR.IsDeleted=0   " & vbNewLine &
"        AND AR.Modules=@Modules   " & vbNewLine &
"),   " & vbNewLine &
"ReceiveAmountPPN=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.PPN),0) PPN   " & vbNewLine &
"    FROM traARAPItem TDD   " & vbNewLine &
"    INNER JOIN traAccountReceivable AR ON   " & vbNewLine &
"        TDD.ParentID=AR.ID    " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ReferencesDetailID=@ReferencesDetailID 	  " & vbNewLine &
"        AND AR.IsDeleted=0   " & vbNewLine &
"        AND AR.Modules=@Modules   " & vbNewLine &
"),   " & vbNewLine &
"ReceiveAmountPPH=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.PPH),0) PPH   " & vbNewLine &
"    FROM traARAPItem TDD   " & vbNewLine &
"    INNER JOIN traAccountReceivable AR ON   " & vbNewLine &
"        TDD.ParentID=AR.ID    " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ReferencesDetailID=@ReferencesDetailID 	  " & vbNewLine &
"        AND AR.IsDeleted=0   " & vbNewLine &
"        AND AR.Modules=@Modules   " & vbNewLine &
"),   " & vbNewLine &
"InvoiceQuantity=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.Quantity),0) Quantity   " & vbNewLine &
"    FROM traARAPItem TDD   " & vbNewLine &
"    INNER JOIN traAccountReceivable AR ON   " & vbNewLine &
"        TDD.ParentID=AR.ID    " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ReferencesDetailID=@ReferencesDetailID 	  " & vbNewLine &
"        AND AR.IsDeleted=0   " & vbNewLine &
"        AND AR.Modules=@Modules   " & vbNewLine &
"),   " & vbNewLine &
"InvoiceTotalWeight=	  " & vbNewLine &
"(	  " & vbNewLine &
"    SELECT	  " & vbNewLine &
"        ISNULL(SUM(TDD.TotalWeight),0) Weight   " & vbNewLine &
"    FROM traARAPItem TDD   " & vbNewLine &
"    INNER JOIN traAccountReceivable AR ON   " & vbNewLine &
"        TDD.ParentID=AR.ID    " & vbNewLine &
"    WHERE 	  " & vbNewLine &
"        TDD.ReferencesDetailID=@ReferencesDetailID 	  " & vbNewLine &
"        AND AR.IsDeleted=0   " & vbNewLine &
"        AND AR.Modules=@Modules   " & vbNewLine &
")   " & vbNewLine &
"WHERE ID=@ReferencesDetailID   " & vbNewLine &
" " & vbNewLine &
" " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ReferencesDetailID; " & vbNewLine &
"END " & vbNewLine &
" " & vbNewLine &
"CLOSE db_cursor; " & vbNewLine &
"DEALLOCATE db_cursor; " & vbNewLine &
" " & vbNewLine
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = VO.AccountReceivable.ReceivePayment
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalPriceSalesContractSubItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = "UPDATE traSalesContractDet SET TotalPrice=TotalWeight*UnitPrice WHERE ParentID<>''  " & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalPricePurchaseContractSubItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = "UPDATE traPurchaseContractDet SET TotalPrice=TotalWeight*UnitPrice WHERE ParentID<>''  " & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub ResetSCWeightConfirmationOrder(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = "UPDATE traConfirmationOrderDet SET SCWeight=0, SCQuantity=0  " & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateSCWeightInSalesContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @CODetailID VARCHAR(100)  " & vbNewLine &
"DECLARE db_cursor CURSOR FOR  " & vbNewLine &
"" & vbNewLine &
"SELECT DISTINCT COD.ID   " & vbNewLine &
"FROM traConfirmationOrderDet COD   " & vbNewLine &
"INNER JOIN traConfirmationOrder COH ON   " & vbNewLine &
"	COD.COID=COH.ID   " & vbNewLine &
"WHERE COH.IsDeleted=0 AND COD.ParentID='' " & vbNewLine &
"" & vbNewLine &
"OPEN db_cursor;  " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @CODetailID;  " & vbNewLine &
"WHILE @@FETCH_STATUS = 0  " & vbNewLine &
"BEGIN  " & vbNewLine &
"" & vbNewLine &
"UPDATE traConfirmationOrderDet SET 	 " & vbNewLine &
"    SCWeight=	 " & vbNewLine &
"    (	 " & vbNewLine &
"        SELECT	 " & vbNewLine &
"            ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight  " & vbNewLine &
"        FROM traSalesContractDetConfirmationOrder SCD 	 " & vbNewLine &
"        INNER JOIN traSalesContract SCH ON	 " & vbNewLine &
"            SCD.SCID=SCH.ID 	 " & vbNewLine &
"        WHERE 	 " & vbNewLine &
"            SCD.CODetailID=@CODetailID 	 " & vbNewLine &
"            AND SCD.ParentID='' " & vbNewLine &
"            AND SCH.IsDeleted=0 	 " & vbNewLine &
"    ), 	 " & vbNewLine &
"    SCQuantity=	 " & vbNewLine &
"    (	 " & vbNewLine &
"        SELECT	 " & vbNewLine &
"            ISNULL(SUM(SCD.Quantity),0) TotalQuantity  " & vbNewLine &
"        FROM traSalesContractDetConfirmationOrder SCD 	 " & vbNewLine &
"        INNER JOIN traSalesContract SCH ON	 " & vbNewLine &
"            SCD.SCID=SCH.ID 	 " & vbNewLine &
"        WHERE 	 " & vbNewLine &
"            SCD.CODetailID=@CODetailID 	 " & vbNewLine &
"            AND SCD.ParentID='' " & vbNewLine &
"            AND SCH.IsDeleted=0 	 " & vbNewLine &
"    ) 	 " & vbNewLine &
"WHERE ID=@CODetailID	 " & vbNewLine &
"  " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @CODetailID;  " & vbNewLine &
"END  " & vbNewLine &
"  " & vbNewLine &
"CLOSE db_cursor;  " & vbNewLine &
"DEALLOCATE db_cursor;" & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDPAmountOrderRequestInDPSalesContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @ORDetailID VARCHAR(100)  " & vbNewLine &
"DECLARE db_cursor CURSOR FOR  " & vbNewLine &
"" & vbNewLine &
"SELECT DISTINCT ORD.ID   " & vbNewLine &
"FROM traOrderRequestDet ORD " & vbNewLine &
"INNER JOIN traOrderRequest ORH ON   " & vbNewLine &
"	ORD.OrderRequestID=ORH.ID   " & vbNewLine &
"WHERE ORH.IsDeleted=0 AND ORD.DPAmount=0 " & vbNewLine &
"" & vbNewLine &
"OPEN db_cursor;  " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ORDetailID;  " & vbNewLine &
"WHILE @@FETCH_STATUS = 0  " & vbNewLine &
"BEGIN  " & vbNewLine &
"" & vbNewLine &
"UPDATE traOrderRequestDet SET 	" & vbNewLine &
"	DPAmount=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(SCD.DPAmount),0) TotalPayment		" & vbNewLine &
"		FROM traSalesContractDet SCD 	" & vbNewLine &
"		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
"			SCD.SCID=SCH.ID 	" & vbNewLine &
"		WHERE 	" & vbNewLine &
"			SCD.ORDetailID=@ORDetailID " & vbNewLine &
"			AND SCD.ParentID='' " & vbNewLine &
"			AND SCH.IsDeleted=0 " & vbNewLine &
"	), " & vbNewLine &
"	DPAmountPPN=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(SCD.DPAmountPPN),0) TotalPayment		" & vbNewLine &
"		FROM traSalesContractDet SCD 	" & vbNewLine &
"		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
"			SCD.SCID=SCH.ID 	" & vbNewLine &
"		WHERE 	" & vbNewLine &
"			SCD.ORDetailID=@ORDetailID " & vbNewLine &
"			AND SCD.ParentID='' " & vbNewLine &
"			AND SCH.IsDeleted=0 " & vbNewLine &
"	), " & vbNewLine &
"	DPAmountPPH=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(SCD.DPAmountPPH),0) TotalPayment		" & vbNewLine &
"		FROM traSalesContractDet SCD 	" & vbNewLine &
"		INNER JOIN traSalesContract SCH ON	" & vbNewLine &
"			SCD.SCID=SCH.ID 	" & vbNewLine &
"		WHERE 	" & vbNewLine &
"			SCD.ORDetailID=@ORDetailID " & vbNewLine &
"			AND SCD.ParentID='' " & vbNewLine &
"			AND SCH.IsDeleted=0 " & vbNewLine &
"	) " & vbNewLine &
"WHERE " & vbNewLine &
"   ID=@ORDetailID " & vbNewLine &
"  " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @ORDetailID;  " & vbNewLine &
"END  " & vbNewLine &
"  " & vbNewLine &
"CLOSE db_cursor;  " & vbNewLine &
"DEALLOCATE db_cursor;" & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateDPAmountOrderRequestInOrderRequestHeader(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @OrderRequestID VARCHAR(100)  " & vbNewLine &
"DECLARE db_cursor CURSOR FOR  " & vbNewLine &
"" & vbNewLine &
"SELECT DISTINCT ORH.ID   " & vbNewLine &
"FROM traOrderRequest ORH " & vbNewLine &
"WHERE ORH.IsDeleted=0 AND ORH.DPAmount=0 " & vbNewLine &
"" & vbNewLine &
"OPEN db_cursor;  " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @OrderRequestID;  " & vbNewLine &
"WHILE @@FETCH_STATUS = 0  " & vbNewLine &
"BEGIN  " & vbNewLine &
"" & vbNewLine &
"UPDATE traOrderRequest SET 	" & vbNewLine &
"	DPAmount=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(ORD.DPAmount),0) TotalPayment		" & vbNewLine &
"		FROM traOrderRequestDet ORD " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			ORD.OrderRequestID=@OrderRequestID " & vbNewLine &
"			AND ORD.ParentID='' " & vbNewLine &
"	), " & vbNewLine &
"	DPAmountPPN=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(ORD.DPAmountPPN),0) TotalPayment		" & vbNewLine &
"		FROM traOrderRequestDet ORD " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			ORD.OrderRequestID=@OrderRequestID " & vbNewLine &
"			AND ORD.ParentID='' " & vbNewLine &
"	), " & vbNewLine &
"	DPAmountPPH=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(ORD.DPAmountPPH),0) TotalPayment		" & vbNewLine &
"		FROM traOrderRequestDet ORD " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			ORD.OrderRequestID=@OrderRequestID " & vbNewLine &
"			AND ORD.ParentID='' " & vbNewLine &
"	) " & vbNewLine &
"WHERE " & vbNewLine &
"   ID=@OrderRequestID " & vbNewLine &
"  " & vbNewLine &
"FETCH NEXT FROM db_cursor INTO @OrderRequestID;  " & vbNewLine &
"END  " & vbNewLine &
"  " & vbNewLine &
"CLOSE db_cursor;  " & vbNewLine &
"DEALLOCATE db_cursor;" & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ListDataARAPForCreateVoucher(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT 'COST' AS Trans, " & vbNewLine & _
"	ARAP.PaymentDate AS TransDate, 2 AS VoucherType, ARAP.ID ParentID, ARAP.CostNumber AS InvoiceNumber, ARAP.CoAID,  " & vbNewLine & _
"	ARAP.TotalAmount, ARAP.ProgramID, ARAP.CompanyID  " & vbNewLine & _
"FROM traCost ARAP  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	ARAP.ApprovedBy<>'' " & vbNewLine & _
" " & vbNewLine & _
"UNION ALL  " & vbNewLine & _
"SELECT 'AP' AS Trans, " & vbNewLine & _
"	ARAP.PaymentDate AS TransDate, 2 AS VoucherType, ARAP.ID ParentID, ARAP.APNumber AS InvoiceNumber, ARAP.CoAIDOfOutgoingPayment AS CoAID,  " & vbNewLine & _
"	ARAP.TotalAmount+ARAP.TotalPPN-ARAP.TotalPPH+ARAP.Rounding AS TotalAmount,  " & vbNewLine & _
"	ARAP.ProgramID, ARAP.CompanyID  " & vbNewLine & _
"FROM traAccountPayable ARAP  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	ARAP.PaymentBy<>''  " & vbNewLine & _
"   AND ARAP.CoAIDOfOutgoingPayment<>0 " & vbNewLine & _
"" & vbNewLine & _
"UNION ALL  " & vbNewLine & _
"SELECT 'ARAPINV' AS Trans, " & vbNewLine & _
"	INV.PaymentDate AS TransDate, 2 AS VoucherType, INV.ID AS ParentID, INV.InvoiceNumber, INV.CoAID, INV.TotalDPP+INV.TotalPPN-INV.TotalPPH+INV.Rounding AS TotalAmount,  " & vbNewLine & _
"	ARAP.ProgramID, ARAP.CompanyID  " & vbNewLine & _
"FROM traARAPInvoice INV  " & vbNewLine & _
"INNER JOIN traAccountPayable ARAP ON  " & vbNewLine & _
"	INV.ParentID=ARAP.ID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	INV.ApprovedBy<>''  " & vbNewLine & _
" " & vbNewLine & _
"UNION ALL " & vbNewLine & _
"SELECT 'ARAPINV' AS Trans, " & vbNewLine & _
"	INV.PaymentDate AS TransDate, 1 AS VoucherType, INV.ID AS ParentID, INV.InvoiceNumber, INV.CoAID, INV.TotalDPP+INV.TotalPPN-INV.TotalPPH+INV.Rounding AS TotalAmount,  " & vbNewLine & _
"	ARAP.ProgramID, ARAP.CompanyID  " & vbNewLine & _
"FROM traARAPInvoice INV  " & vbNewLine & _
"INNER JOIN traAccountReceivable ARAP ON  " & vbNewLine & _
"	INV.ParentID=ARAP.ID  " & vbNewLine & _
"WHERE  " & vbNewLine & _
"	INV.ApprovedBy<>''  " & vbNewLine & _
"	AND ARAP.IsGenerate=0  " & vbNewLine & _
"ORDER BY CoAID, ParentID  " & vbNewLine
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub CalculateUnitPriceHPPSalesContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @SCID VARCHAR(100)   " & vbNewLine & _
"DECLARE @SCDetailID VARCHAR(100)   " & vbNewLine & _
"DECLARE @GroupID INT  " & vbNewLine & _
"DECLARE @UnitPrice DECIMAL(18,4) " & vbNewLine & _
"DECLARE db_cursor CURSOR FOR   " & vbNewLine & _
" " & vbNewLine & _
"SELECT DISTINCT SCD.SCID, SCD.GroupID, COD.UnitPrice, SCD.ID  " & vbNewLine & _
"FROM traSalesContractDet SCD    " & vbNewLine & _
"INNER JOIN traSalesContract SCH ON    " & vbNewLine & _
"	SCD.SCID=SCH.ID    " & vbNewLine & _
"INNER JOIN traSalesContractDetConfirmationOrder SCDCO ON    " & vbNewLine & _
"	SCD.SCID=SCDCO.SCID  " & vbNewLine & _
"	AND SCD.GroupID=SCDCO.GroupID  " & vbNewLine & _
"INNER JOIN traConfirmationOrderDet COD ON  " & vbNewLine & _
"	SCDCO.CODetailID=COD.ID  " & vbNewLine & _
"WHERE SCH.IsDeleted=0 AND SCD.UnitPriceHPP<>COD.UnitPrice AND COD.UnitPrice>0  " & vbNewLine & _
" " & vbNewLine & _
"OPEN db_cursor;   " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @SCID, @GroupID, @UnitPrice, @SCDetailID;   " & vbNewLine & _
"WHILE @@FETCH_STATUS = 0   " & vbNewLine & _
"BEGIN   " & vbNewLine & _
"  UPDATE traSalesContractDet SET UnitPriceHPP=@UnitPrice WHERE ID=@SCDetailID  " & vbNewLine & _
" " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @SCID, @GroupID, @UnitPrice, @SCDetailID;   " & vbNewLine & _
"END   " & vbNewLine & _
"   " & vbNewLine & _
"CLOSE db_cursor;   " & vbNewLine & _
"DEALLOCATE db_cursor;   " & vbNewLine
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
End Namespace
