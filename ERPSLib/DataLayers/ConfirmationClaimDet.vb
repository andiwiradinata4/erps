Namespace DL
 
    Public Class ConfirmationClaimDet
 
        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText = 
"
SELECT 
	A.ID, A.ConfirmationClaimID, A.ClaimDetailID, A.ItemID, A.Quantity, A.Weight, A.TotalWeight, 
	A.UnitPrice, A.TotalPrice, A.Remarks, A.UnitPriceProduct, A.TotalPriceProduct, A.DPAmount, 
	A.ReceiveAmount, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A.DPAmountPPN, 
	A.DPAmountPPH, A.ReceiveAmountPPN, A.ReceiveAmountPPH, A.InvoiceQuantity, A.InvoiceWeight, A.InvoiceTotalWeight, 
	A.AllocateDPAmount, A.ConfirmationQuantity, A.ConfirmationWeight
FROM traConfirmationClaimDet A
WHERE 
	1=1 
"

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew as Boolean, ByVal clsData As VO.ConfirmationClaimDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText = 
"
INSERT INTO traConfirmationClaimDet
	(ID, ConfirmationClaimID, ClaimDetailID, ItemID, Quantity, Weight, TotalWeight, 
	 UnitPrice, TotalPrice, Remarks, UnitPriceProduct, TotalPriceProduct, DPAmount, 
	 ReceiveAmount, OrderNumberSupplier, LevelItem, ParentID, RoundingWeight, DPAmountPPN, 
	 DPAmountPPH, ReceiveAmountPPN, ReceiveAmountPPH, InvoiceQuantity, InvoiceWeight, InvoiceTotalWeight, 
	 AllocateDPAmount, ConfirmationQuantity, ConfirmationWeight)
VALUES 
	(@ID, @ConfirmationClaimID, @ClaimDetailID, @ItemID, @Quantity, @Weight, @TotalWeight, 
	 @UnitPrice, @TotalPrice, @Remarks, @UnitPriceProduct, @TotalPriceProduct, @DPAmount, 
	 @ReceiveAmount, @OrderNumberSupplier, @LevelItem, @ParentID, @RoundingWeight, @DPAmountPPN, 
	 @DPAmountPPH, @ReceiveAmountPPN, @ReceiveAmountPPH, @InvoiceQuantity, @InvoiceWeight, @InvoiceTotalWeight, 
	 @AllocateDPAmount, @ConfirmationQuantity, @ConfirmationWeight)
"
                Else
                    .CommandText = 
"
UPDATE traConfirmationClaimDet SET 
	ConfirmationClaimID=@ConfirmationClaimID, 
	ClaimDetailID=@ClaimDetailID, 
	ItemID=@ItemID, 
	Quantity=@Quantity, 
	Weight=@Weight, 
	TotalWeight=@TotalWeight, 
	UnitPrice=@UnitPrice, 
	TotalPrice=@TotalPrice, 
	Remarks=@Remarks, 
	UnitPriceProduct=@UnitPriceProduct, 
	TotalPriceProduct=@TotalPriceProduct, 
	DPAmount=@DPAmount, 
	ReceiveAmount=@ReceiveAmount, 
	OrderNumberSupplier=@OrderNumberSupplier, 
	LevelItem=@LevelItem, 
	ParentID=@ParentID, 
	RoundingWeight=@RoundingWeight, 
	DPAmountPPN=@DPAmountPPN, 
	DPAmountPPH=@DPAmountPPH, 
	ReceiveAmountPPN=@ReceiveAmountPPN, 
	ReceiveAmountPPH=@ReceiveAmountPPH, 
	InvoiceQuantity=@InvoiceQuantity, 
	InvoiceWeight=@InvoiceWeight, 
	InvoiceTotalWeight=@InvoiceTotalWeight, 
	AllocateDPAmount=@AllocateDPAmount, 
	ConfirmationQuantity=@ConfirmationQuantity, 
	ConfirmationWeight=@ConfirmationWeight
WHERE
	ID=@ID
"
                End If

                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = clsData.ID
                .Parameters.Add("@ConfirmationClaimID", SqlDbType.varchar, 100).Value = clsData.ConfirmationClaimID
                .Parameters.Add("@ClaimDetailID", SqlDbType.varchar, 100).Value = clsData.ClaimDetailID
                .Parameters.Add("@ItemID", SqlDbType.int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.decimal).Value = clsData.TotalWeight
                .Parameters.Add("@UnitPrice", SqlDbType.decimal).Value = clsData.UnitPrice
                .Parameters.Add("@TotalPrice", SqlDbType.decimal).Value = clsData.TotalPrice
                .Parameters.Add("@Remarks", SqlDbType.varchar, 250).Value = clsData.Remarks
                .Parameters.Add("@UnitPriceProduct", SqlDbType.decimal).Value = clsData.UnitPriceProduct
                .Parameters.Add("@TotalPriceProduct", SqlDbType.decimal).Value = clsData.TotalPriceProduct
                .Parameters.Add("@DPAmount", SqlDbType.decimal).Value = clsData.DPAmount
                .Parameters.Add("@ReceiveAmount", SqlDbType.decimal).Value = clsData.ReceiveAmount
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.varchar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@LevelItem", SqlDbType.int).Value = clsData.LevelItem
                .Parameters.Add("@ParentID", SqlDbType.varchar, 100).Value = clsData.ParentID
                .Parameters.Add("@RoundingWeight", SqlDbType.decimal).Value = clsData.RoundingWeight
                .Parameters.Add("@DPAmountPPN", SqlDbType.decimal).Value = clsData.DPAmountPPN
                .Parameters.Add("@DPAmountPPH", SqlDbType.decimal).Value = clsData.DPAmountPPH
                .Parameters.Add("@ReceiveAmountPPN", SqlDbType.decimal).Value = clsData.ReceiveAmountPPN
                .Parameters.Add("@ReceiveAmountPPH", SqlDbType.decimal).Value = clsData.ReceiveAmountPPH
                .Parameters.Add("@InvoiceQuantity", SqlDbType.decimal).Value = clsData.InvoiceQuantity
                .Parameters.Add("@InvoiceWeight", SqlDbType.decimal).Value = clsData.InvoiceWeight
                .Parameters.Add("@InvoiceTotalWeight", SqlDbType.decimal).Value = clsData.InvoiceTotalWeight
                .Parameters.Add("@AllocateDPAmount", SqlDbType.decimal).Value = clsData.AllocateDPAmount
                .Parameters.Add("@ConfirmationQuantity", SqlDbType.decimal).Value = clsData.ConfirmationQuantity
                .Parameters.Add("@ConfirmationWeight", SqlDbType.decimal).Value = clsData.ConfirmationWeight

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.ConfirmationClaimDet
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ConfirmationClaimDet
            Try
                With sqlcmdExecute
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText =  
"
SELECT TOP 1 
	A.ID, A.ConfirmationClaimID, A.ClaimDetailID, A.ItemID, A.Quantity, A.Weight, A.TotalWeight, 
	A.UnitPrice, A.TotalPrice, A.Remarks, A.UnitPriceProduct, A.TotalPriceProduct, A.DPAmount, 
	A.ReceiveAmount, A.OrderNumberSupplier, A.LevelItem, A.ParentID, A.RoundingWeight, A.DPAmountPPN, 
	A.DPAmountPPH, A.ReceiveAmountPPN, A.ReceiveAmountPPH, A.InvoiceQuantity, A.InvoiceWeight, A.InvoiceTotalWeight, 
	A.AllocateDPAmount, A.ConfirmationQuantity, A.ConfirmationWeight
FROM traConfirmationClaimDet A
WHERE
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        voReturn.ID = .Item("ID")
                        voReturn.ConfirmationClaimID = .Item("ConfirmationClaimID")
                        voReturn.ClaimDetailID = .Item("ClaimDetailID")
                        voReturn.ItemID = .Item("ItemID")
                        voReturn.Quantity = .Item("Quantity")
                        voReturn.Weight = .Item("Weight")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.UnitPrice = .Item("UnitPrice")
                        voReturn.TotalPrice = .Item("TotalPrice")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.UnitPriceProduct = .Item("UnitPriceProduct")
                        voReturn.TotalPriceProduct = .Item("TotalPriceProduct")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.ReceiveAmount = .Item("ReceiveAmount")
                        voReturn.OrderNumberSupplier = .Item("OrderNumberSupplier")
                        voReturn.LevelItem = .Item("LevelItem")
                        voReturn.ParentID = .Item("ParentID")
                        voReturn.RoundingWeight = .Item("RoundingWeight")
                        voReturn.DPAmountPPN = .Item("DPAmountPPN")
                        voReturn.DPAmountPPH = .Item("DPAmountPPH")
                        voReturn.ReceiveAmountPPN = .Item("ReceiveAmountPPN")
                        voReturn.ReceiveAmountPPH = .Item("ReceiveAmountPPH")
                        voReturn.InvoiceQuantity = .Item("InvoiceQuantity")
                        voReturn.InvoiceWeight = .Item("InvoiceWeight")
                        voReturn.InvoiceTotalWeight = .Item("InvoiceTotalWeight")
                        voReturn.AllocateDPAmount = .Item("AllocateDPAmount")
                        voReturn.ConfirmationQuantity = .Item("ConfirmationQuantity")
                        voReturn.ConfirmationWeight = .Item("ConfirmationWeight")
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return voReturn 
        End Function 

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText = 
"
DELETE FROM traConfirmationClaimDet
WHERE
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans) 
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) AS Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing 
            Dim intReturn As Integer = 0 
            Try 
                With sqlcmdExecute 
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText = 
"
SELECT TOP 1
	ID=ISNULL(MAX(ID),0)
FROM traConfirmationClaimDet
"
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        intReturn = .Item("ID") + 1
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return intReturn 
        End Function 

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False 
            Try 
                With sqlcmdExecute 
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText = 
"
SELECT TOP 1
	ID
FROM traConfirmationClaimDet
WHERE 
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

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
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return bolExists 
        End Function 

    End Class 

End Namespace

