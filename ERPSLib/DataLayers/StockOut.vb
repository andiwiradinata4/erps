Namespace DL

    Public Class StockOut

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	A.ID, A.ParentID, A.ParentDetailID, A.OrderNumberSupplier, A.SourceData, A.ItemID, A.Quantity,  " & vbNewLine &
"	A.Weight, A.TotalWeight " & vbNewLine &
"FROM traStockOut A " & vbNewLine &
"WHERE  " & vbNewLine &
"	1=1  " & vbNewLine

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.StockOut)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traStockOut " & vbNewLine &
"	(ID, ParentID, ParentDetailID, OrderNumberSupplier, SourceData, ItemID, Quantity,  " & vbNewLine &
"	 Weight, TotalWeight) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ParentID, @ParentDetailID, @OrderNumberSupplier, @SourceData, @ItemID, @Quantity,  " & vbNewLine &
"	 @Weight, @TotalWeight) " & vbNewLine
                Else
                    .CommandText =
"UPDATE traStockOut SET  " & vbNewLine &
"	ParentID=@ParentID,  " & vbNewLine &
"	ParentDetailID=@ParentDetailID,  " & vbNewLine &
"	OrderNumberSupplier=@OrderNumberSupplier,  " & vbNewLine &
"	SourceData=@SourceData,  " & vbNewLine &
"	ItemID=@ItemID,  " & vbNewLine &
"	Quantity=@Quantity,  " & vbNewLine &
"	Weight=@Weight,  " & vbNewLine &
"	TotalWeight=@TotalWeight " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@ParentDetailID", SqlDbType.VarChar, 100).Value = clsData.ParentDetailID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@SourceData", SqlDbType.VarChar, 100).Value = clsData.SourceData
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.StockOut
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.StockOut
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ParentID, A.ParentDetailID, A.OrderNumberSupplier, A.SourceData, A.ItemID, A.Quantity,  " & vbNewLine &
"	A.Weight, A.TotalWeight " & vbNewLine &
"FROM traStockOut A " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ParentID = .Item("ParentID")
                        voReturn.ParentDetailID = .Item("ParentDetailID")
                        voReturn.OrderNumberSupplier = .Item("OrderNumberSupplier")
                        voReturn.SourceData = .Item("SourceData")
                        voReturn.ItemID = .Item("ItemID")
                        voReturn.Quantity = .Item("Quantity")
                        voReturn.Weight = .Item("Weight")
                        voReturn.TotalWeight = .Item("TotalWeight")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer) As VO.StockOut
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.StockOut
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ParentID, A.ParentDetailID, A.OrderNumberSupplier, A.SourceData, A.ItemID, A.Quantity,  " & vbNewLine &
"	A.Weight, A.TotalWeight " & vbNewLine &
"FROM traStockOut A " & vbNewLine &
"WHERE " & vbNewLine &
"	A.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND A.ItemID=@ItemID " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.VarChar, 100).Value = intItemID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ParentID = .Item("ParentID")
                        voReturn.ParentDetailID = .Item("ParentDetailID")
                        voReturn.OrderNumberSupplier = .Item("OrderNumberSupplier")
                        voReturn.SourceData = .Item("SourceData")
                        voReturn.ItemID = .Item("ItemID")
                        voReturn.Quantity = .Item("Quantity")
                        voReturn.Weight = .Item("Weight")
                        voReturn.TotalWeight = .Item("TotalWeight")
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
"DELETE FROM traStockOut " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetTotalWeightStockOutDelivery(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                              ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer) As Decimal
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Decimal = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT SUM(TDD.TotalWeight) AS TotalWeight " & vbNewLine &
"FROM traDelivery TDH " & vbNewLine &
"INNER JOIN traDeliveryDet TDD ON " & vbNewLine &
"   TDH.ID=TDD.DeliveryID " & vbNewLine &
"WHERE " & vbNewLine &
"	TDD.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND TDD.ItemID=@ItemID " & vbNewLine &
"	AND TDH.IsDeleted=0 " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        decReturn = .Item("TotalWeight")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return decReturn
        End Function

        Public Shared Function GetTotalWeightStockOutCutting(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer) As Decimal
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Decimal = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT ISNULL(SUM(TCD.TotalWeight),0) AS TotalWeight " & vbNewLine &
"FROM traCutting TCH " & vbNewLine &
"INNER JOIN traCuttingDet TCD ON " & vbNewLine &
"   TCH.ID=TCD.CuttingID " & vbNewLine &
"WHERE " & vbNewLine &
"	TCD.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND TCD.ItemID=@ItemID " & vbNewLine &
"	AND TCH.IsDeleted=0 " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        decReturn = .Item("TotalWeight")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return decReturn
        End Function

        Public Shared Sub UpdateStockOutTotalWeight(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strID As String, ByVal decTotalWeight As Decimal)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traStockOut SET " & vbNewLine &
"   TotalWeight=@TotalWeight " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = decTotalWeight
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

    End Class
End Namespace