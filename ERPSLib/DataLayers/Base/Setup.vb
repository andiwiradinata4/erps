Namespace DL
    Public Class Setup

        Public Shared Sub CalculateTotalSCWeightInPurchaseContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DECLARE @PCDetailID VARCHAR(100) " & vbNewLine & _
"DECLARE db_cursor CURSOR FOR " & vbNewLine & _
"SELECT DISTINCT PCD.ID  " & vbNewLine & _
"FROM traPurchaseContractDet PCD  " & vbNewLine & _
"INNER JOIN traPurchaseContract PCH ON  " & vbNewLine & _
"	PCD.PCID=PCH.ID  " & vbNewLine & _
"WHERE PCH.IsDeleted=0 AND PCD.ParentID=''  " & vbNewLine & _
"OPEN db_cursor; " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine & _
"WHILE @@FETCH_STATUS = 0 " & vbNewLine & _
"BEGIN " & vbNewLine & _
" " & vbNewLine & _
"UPDATE traPurchaseContractDet SET 	  " & vbNewLine & _
"    SCWeight=	  " & vbNewLine & _
"    (	  " & vbNewLine & _
"        SELECT	  " & vbNewLine & _
"            ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight  " & vbNewLine & _
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine & _
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine & _
"            SCD.SCID=SCH.ID 	  " & vbNewLine & _
"        WHERE 	  " & vbNewLine & _
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine & _
"            And SCH.IsDeleted=0 	  " & vbNewLine & _
"    ), 	  " & vbNewLine & _
"    SCQuantity=	  " & vbNewLine & _
"    (	  " & vbNewLine & _
"        SELECT	  " & vbNewLine & _
"            ISNULL(SUM(SCD.Quantity),0) TotalQuantity   " & vbNewLine & _
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine & _
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine & _
"            SCD.SCID=SCH.ID 	  " & vbNewLine & _
"        WHERE 	  " & vbNewLine & _
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine & _
"            And SCH.IsDeleted=0 	  " & vbNewLine & _
"    ) 	  " & vbNewLine & _
"WHERE ID=@PCDetailID	  " & vbNewLine & _
" " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine & _
"END " & vbNewLine & _
" " & vbNewLine & _
"CLOSE db_cursor; " & vbNewLine & _
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
"DECLARE @PCDetailID VARCHAR(100) " & vbNewLine & _
"DECLARE db_cursor CURSOR FOR " & vbNewLine & _
"SELECT DISTINCT PCD.ID  " & vbNewLine & _
"FROM traPurchaseContractDet PCD  " & vbNewLine & _
"INNER JOIN traPurchaseContract PCH ON  " & vbNewLine & _
"	PCD.PCID=PCH.ID  " & vbNewLine & _
"WHERE PCH.IsDeleted=0 AND PCD.ParentID<>''  " & vbNewLine & _
"OPEN db_cursor; " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine & _
"WHILE @@FETCH_STATUS = 0 " & vbNewLine & _
"BEGIN " & vbNewLine & _
" " & vbNewLine & _
"UPDATE traPurchaseContractDet SET 	  " & vbNewLine & _
"    SCWeight=	  " & vbNewLine & _
"    (	  " & vbNewLine & _
"        SELECT	  " & vbNewLine & _
"            ISNULL(SUM(SCD.TotalWeight+SCD.RoundingWeight),0) TotalWeight  " & vbNewLine & _
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine & _
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine & _
"            SCD.SCID=SCH.ID 	  " & vbNewLine & _
"        WHERE 	  " & vbNewLine & _
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine & _
"            And SCH.IsDeleted=0 	  " & vbNewLine & _
"    ), 	  " & vbNewLine & _
"    SCQuantity=	  " & vbNewLine & _
"    (	  " & vbNewLine & _
"        SELECT	  " & vbNewLine & _
"            ISNULL(SUM(SCD.Quantity),0) TotalQuantity   " & vbNewLine & _
"        FROM traSalesContractDetConfirmationOrder SCD 	  " & vbNewLine & _
"        INNER JOIN traSalesContract SCH ON	  " & vbNewLine & _
"            SCD.SCID=SCH.ID 	  " & vbNewLine & _
"        WHERE 	  " & vbNewLine & _
"            SCD.PCDetailID=@PCDetailID 	  " & vbNewLine & _
"            And SCH.IsDeleted=0 	  " & vbNewLine & _
"    ) 	  " & vbNewLine & _
"WHERE ID=@PCDetailID	  " & vbNewLine & _
" " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @PCDetailID; " & vbNewLine & _
"END " & vbNewLine & _
" " & vbNewLine & _
"CLOSE db_cursor; " & vbNewLine & _
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
"DECLARE @ID VARCHAR(100) " & vbNewLine & _
"DECLARE db_cursor CURSOR FOR " & vbNewLine & _
"SELECT DISTINCT SCH.ID  " & vbNewLine & _
"FROM traSalesContract SCH  " & vbNewLine & _
"WHERE SCH.IsDeleted=0 AND SCH.StatusID=@StatusID " & vbNewLine & _
"OPEN db_cursor; " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @ID; " & vbNewLine & _
"WHILE @@FETCH_STATUS = 0 " & vbNewLine & _
"BEGIN " & vbNewLine & _
" " & vbNewLine & _
"UPDATE traSalesContract SET 	  " & vbNewLine & _
"	ReceiveAmount=	  " & vbNewLine & _
"	(	  " & vbNewLine & _
"SELECT	  " & vbNewLine & _
"	ISNULL(SUM(TDH.ReceiveAmount),0) ReceiveAmount   " & vbNewLine & _
"FROM traSalesContractDet TDH   " & vbNewLine & _
"WHERE 	  " & vbNewLine & _
"	TDH.SCID=@ID 	  " & vbNewLine & _
"	AND TDH.ParentID=''   " & vbNewLine & _
"	),   " & vbNewLine & _
"	ReceiveAmountPPN=	  " & vbNewLine & _
"	(	  " & vbNewLine & _
"SELECT	  " & vbNewLine & _
"	ISNULL(SUM(TDH.ReceiveAmountPPN),0) ReceiveAmountPPN   " & vbNewLine & _
"FROM traSalesContractDet TDH   " & vbNewLine & _
"WHERE 	  " & vbNewLine & _
"	TDH.SCID=@ID 	  " & vbNewLine & _
"	AND TDH.ParentID=''   " & vbNewLine & _
"	),   " & vbNewLine & _
"	ReceiveAmountPPH=	  " & vbNewLine & _
"	(	  " & vbNewLine & _
"SELECT	  " & vbNewLine & _
"	ISNULL(SUM(TDH.ReceiveAmountPPH),0) ReceiveAmountPPH   " & vbNewLine & _
"FROM traSalesContractDet TDH   " & vbNewLine & _
"WHERE 	  " & vbNewLine & _
"	TDH.SCID=@ID 	  " & vbNewLine & _
"	AND TDH.ParentID=''   " & vbNewLine & _
"	)   " & vbNewLine & _
"WHERE ID=@ID   " & vbNewLine & _
" " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @ID; " & vbNewLine & _
"END " & vbNewLine & _
" " & vbNewLine & _
"CLOSE db_cursor; " & vbNewLine & _
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
"DECLARE @ReferencesDetailID VARCHAR(100) " & vbNewLine & _
"DECLARE db_cursor CURSOR FOR " & vbNewLine & _
"SELECT DISTINCT SCD.ID  " & vbNewLine & _
"FROM traSalesContractDet SCD  " & vbNewLine & _
"INNER JOIN traSalesContract SCH ON  " & vbNewLine & _
"	SCD.SCID=SCH.ID  " & vbNewLine & _
"WHERE SCH.IsDeleted=0 AND SCH.StatusID=@StatusID AND SCD.ParentID='' AND SCD.ReceiveAmount<=0 " & vbNewLine & _
"OPEN db_cursor; " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @ReferencesDetailID; " & vbNewLine & _
"WHILE @@FETCH_STATUS = 0 " & vbNewLine & _
"BEGIN " & vbNewLine & _
" " & vbNewLine & _
"UPDATE traSalesContractDet SET 	  " & vbNewLine & _
"AllocateDPAmount=	  " & vbNewLine & _
"(	  " & vbNewLine & _
"    SELECT	  " & vbNewLine & _
"        ISNULL(SUM(TDD.AllocateDPAmount),0) DPAmount   " & vbNewLine & _
"    FROM traSalesContractDet TDD " & vbNewLine & _
"    WHERE 	  " & vbNewLine & _
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine & _
"),   " & vbNewLine & _
"ReceiveAmount=	  " & vbNewLine & _
"(	  " & vbNewLine & _
"    SELECT	  " & vbNewLine & _
"        ISNULL(SUM(TDD.ReceiveAmount),0) ReceiveAmount   " & vbNewLine & _
"    FROM traSalesContractDet TDD " & vbNewLine & _
"    WHERE 	  " & vbNewLine & _
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine & _
"),   " & vbNewLine & _
"ReceiveAmountPPN=	  " & vbNewLine & _
"(	  " & vbNewLine & _
"    SELECT	  " & vbNewLine & _
"        ISNULL(SUM(TDD.ReceiveAmountPPN),0) PPN   " & vbNewLine & _
"    FROM traSalesContractDet TDD " & vbNewLine & _
"    WHERE 	  " & vbNewLine & _
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine & _
"),   " & vbNewLine & _
"ReceiveAmountPPH=	  " & vbNewLine & _
"(	  " & vbNewLine & _
"    SELECT	  " & vbNewLine & _
"        ISNULL(SUM(TDD.ReceiveAmountPPH),0) PPH   " & vbNewLine & _
"    FROM traSalesContractDet TDD " & vbNewLine & _
"    WHERE 	  " & vbNewLine & _
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine & _
"),   " & vbNewLine & _
"InvoiceQuantity=	  " & vbNewLine & _
"(	  " & vbNewLine & _
"    SELECT	  " & vbNewLine & _
"        ISNULL(SUM(TDD.InvoiceQuantity),0) Quantity   " & vbNewLine & _
"    FROM traSalesContractDet TDD " & vbNewLine & _
"    WHERE 	  " & vbNewLine & _
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine & _
"),   " & vbNewLine & _
"InvoiceTotalWeight=	  " & vbNewLine & _
"(	  " & vbNewLine & _
"    SELECT	  " & vbNewLine & _
"        ISNULL(SUM(TDD.InvoiceTotalWeight),0) Weight   " & vbNewLine & _
"    FROM traSalesContractDet TDD " & vbNewLine & _
"    WHERE 	  " & vbNewLine & _
"        TDD.ParentID=@ReferencesDetailID 	  " & vbNewLine & _
")   " & vbNewLine & _
"WHERE ID=@ReferencesDetailID   " & vbNewLine & _
" " & vbNewLine & _
" " & vbNewLine & _
"FETCH NEXT FROM db_cursor INTO @ReferencesDetailID; " & vbNewLine & _
"END " & vbNewLine & _
" " & vbNewLine & _
"CLOSE db_cursor; " & vbNewLine & _
"DEALLOCATE db_cursor; " & vbNewLine & _
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

    End Class
End Namespace
