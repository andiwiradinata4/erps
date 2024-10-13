Namespace DL
    Public Class StockIn

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	A.ID, A.ParentID, A.ParentDetailID, A.OrderNumberSupplier, A.SourceData, A.ItemID, A.InQuantity,  " & vbNewLine &
"	A.InWeight, A.InTotalWeight, A.OutQuantity, A.OutWeight, A.OutTotalWeight, A.OutTotalWeightProcess, A.OutTotalQuantityProcess " & vbNewLine &
"	A.OutTotalQuantityProcess, A.ProgramID, A.CompanyID, A.CoAofStock, A.UnitPrice " & vbNewLine &
"FROM traStockIn A " & vbNewLine &
"WHERE  " & vbNewLine &
"	A.ProgramID=@ProgramID  " & vbNewLine &
"	AND A.CompanyID=@CompanyID  " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	A.ID, A.ParentID, A.ParentDetailID, A.OrderNumberSupplier, A.SourceData, A.ItemID, A.InQuantity,  " & vbNewLine &
"	A.InWeight, A.InTotalWeight, A.OutQuantity, A.OutWeight, A.OutTotalWeight, A.OutTotalWeightProcess, " & vbNewLine &
"	A.OutTotalQuantityProcess, A.ProgramID, A.CompanyID, A.CoAofStock, A.UnitPrice " & vbNewLine &
"FROM traStockIn A " & vbNewLine &
"WHERE  " & vbNewLine &
"	A.ProgramID=@ProgramID  " & vbNewLine &
"	AND A.CompanyID=@CompanyID  " & vbNewLine &
"	AND A.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND A.ItemID=@ItemID " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew As Boolean, ByVal clsData As VO.StockIn)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traStockIn " & vbNewLine &
"	(ID, ParentID, ParentDetailID, OrderNumberSupplier, SourceData, ItemID, InQuantity,  " & vbNewLine &
"	 InWeight, InTotalWeight, OutQuantity, OutWeight, OutTotalWeight, OutTotalWeightProcess, " & vbNewLine &
"    OutTotalQuantityProcess, UnitPrice, ProgramID, CompanyID, CoAofStock) " & vbNewLine &
"VALUES  " & vbNewLine &
"	(@ID, @ParentID, @ParentDetailID, @OrderNumberSupplier, @SourceData, @ItemID, @InQuantity,  " & vbNewLine &
"	 @InWeight, @InTotalWeight, @OutQuantity, @OutWeight, @OutTotalWeight, @OutTotalWeightProcess, " & vbNewLine &
"    @OutTotalQuantityProcess, @UnitPrice, @ProgramID, @CompanyID, @CoAofStock) " & vbNewLine
                Else
                    .CommandText =
"UPDATE traStockIn SET  " & vbNewLine &
"	InQuantity=@InQuantity,  " & vbNewLine &
"	InWeight=@InWeight,  " & vbNewLine &
"	InTotalWeight=@InTotalWeight,  " & vbNewLine &
"	UnitPrice=@UnitPrice " & vbNewLine &
"WHERE " & vbNewLine &
"	ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@ParentDetailID", SqlDbType.VarChar, 100).Value = clsData.ParentDetailID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@SourceData", SqlDbType.VarChar, 100).Value = clsData.SourceData
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@InQuantity", SqlDbType.Decimal).Value = clsData.InQuantity
                .Parameters.Add("@InWeight", SqlDbType.Decimal).Value = clsData.InWeight
                .Parameters.Add("@InTotalWeight", SqlDbType.Decimal).Value = clsData.InTotalWeight
                .Parameters.Add("@OutQuantity", SqlDbType.Decimal).Value = clsData.OutQuantity
                .Parameters.Add("@OutWeight", SqlDbType.Decimal).Value = clsData.OutWeight
                .Parameters.Add("@OutTotalWeight", SqlDbType.Decimal).Value = clsData.OutTotalWeight
                .Parameters.Add("@OutTotalWeightProcess", SqlDbType.Decimal).Value = clsData.OutTotalWeightProcess
                .Parameters.Add("@OutTotalQuantityProcess", SqlDbType.Decimal).Value = clsData.OutTotalQuantityProcess
                .Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = clsData.UnitPrice
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = clsData.CoAofStock
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.StockIn
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.StockIn
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ParentID, A.ParentDetailID, A.OrderNumberSupplier, A.SourceData, A.ItemID, A.InQuantity,  " & vbNewLine &
"	A.InWeight, A.InTotalWeight, A.OutQuantity, A.OutWeight, A.OutTotalWeight, A.OutTotalWeightProcess, " & vbNewLine &
"   A.OutTotalQuantityProcess, A.UnitPrice, A.ProgramID, A.CompanyID, A.CoAofStock " & vbNewLine &
"FROM traStockIn A " & vbNewLine &
"WHERE " & vbNewLine &
"	A.ID=@ID " & vbNewLine

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
                        voReturn.InQuantity = .Item("InQuantity")
                        voReturn.InWeight = .Item("InWeight")
                        voReturn.InTotalWeight = .Item("InTotalWeight")
                        voReturn.OutQuantity = .Item("OutQuantity")
                        voReturn.OutWeight = .Item("OutWeight")
                        voReturn.OutTotalWeight = .Item("OutTotalWeight")
                        voReturn.OutTotalWeightProcess = .Item("OutTotalWeightProcess")
                        voReturn.OutTotalQuantityProcess = .Item("OutTotalQuantityProcess")
                        voReturn.UnitPrice = .Item("UnitPrice")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.CoAofStock = .Item("CoAofStock")
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
                                          ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer,
                                          ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                          ByVal intCoAofStock As Integer) As VO.StockIn
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.StockIn
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1  " & vbNewLine &
"	A.ID, A.ParentID, A.ParentDetailID, A.OrderNumberSupplier, A.SourceData, A.ItemID, A.InQuantity,  " & vbNewLine &
"	A.InWeight, A.InTotalWeight, A.OutQuantity, A.OutWeight, A.OutTotalWeight, A.OutTotalWeightProcess, " & vbNewLine &
"   A.OutTotalQuantityProcess, A.UnitPrice, A.ProgramID, A.CompanyID, A.CoAofStock " & vbNewLine &
"FROM traStockIn A " & vbNewLine &
"WHERE " & vbNewLine &
"	A.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND A.ItemID=@ItemID " & vbNewLine &
"	AND A.ProgramID=@ProgramID " & vbNewLine &
"	AND A.CompanyID=@CompanyID " & vbNewLine &
"	AND A.CoAofStock=@CoAofStock " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = intCoAofStock
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
                        voReturn.InQuantity = .Item("InQuantity")
                        voReturn.InWeight = .Item("InWeight")
                        voReturn.InTotalWeight = .Item("InTotalWeight")
                        voReturn.OutQuantity = .Item("OutQuantity")
                        voReturn.OutWeight = .Item("OutWeight")
                        voReturn.OutTotalWeight = .Item("OutTotalWeight")
                        voReturn.OutTotalWeightProcess = .Item("OutTotalWeightProcess")
                        voReturn.OutTotalQuantityProcess = .Item("OutTotalQuantityProcess")
                        voReturn.UnitPrice = .Item("UnitPrice")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.CoAofStock = .Item("CoAofStock")
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
"DELETE FROM traStockIn " & vbNewLine &
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

        Public Shared Function GetTotalWeightStockInReceive(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer,
                                                            ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                            ByVal intCoAofStock As Integer) As Decimal
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Decimal = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT ISNULL(SUM(TRD.TotalWeight+TRD.RoundingWeight),0) AS TotalWeight " & vbNewLine &
"FROM traReceive TRH " & vbNewLine &
"INNER JOIN traReceiveDet TRD ON " & vbNewLine &
"   TRH.ID=TRD.ReceiveID " & vbNewLine &
"WHERE " & vbNewLine &
"	TRD.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND TRD.ItemID=@ItemID " & vbNewLine &
"	AND TRH.IsDeleted=0 " & vbNewLine &
"	AND TRH.StatusID=@StatusID " & vbNewLine &
"	AND TRH.ProgramID=@ProgramID " & vbNewLine &
"	AND TRH.CompanyID=@CompanyID " & vbNewLine &
"	AND TRH.CoAofStock=@CoAofStock " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = intCoAofStock
                    .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
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

        Public Shared Function GetTotalWeightStockInCuttingResult(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer,
                                                                  ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                  ByVal intCoAIDofStock As Integer) As Decimal
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Decimal = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT ISNULL(SUM(TCD.TotalWeight+TCD.RoundingWeight),0) AS TotalWeight " & vbNewLine &
"FROM traCutting TCH " & vbNewLine &
"INNER JOIN traCuttingDetResult TCD ON " & vbNewLine &
"   TCH.ID=TCD.CuttingID " & vbNewLine &
"WHERE " & vbNewLine &
"	TCD.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND TCD.ItemID=@ItemID " & vbNewLine &
"	AND TCH.IsDeleted=0 " & vbNewLine &
"	AND TCH.StatusID=@StatusID " & vbNewLine &
"	AND TCH.ProgramID=@ProgramID " & vbNewLine &
"	AND TCH.CompanyID=@CompanyID " & vbNewLine &
"	AND TCH.CoAIDofStock=@CoAIDofStock " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@CoAIDofStock", SqlDbType.Int).Value = intCoAIDofStock
                    .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
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

        Public Shared Function GetTotalWeightStockInSalesReturn(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer,
                                                                ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                ByVal intCoAofStock As Integer) As Decimal
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Decimal = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT ISNULL(SUM(SRD.TotalWeight+SRD.RoundingWeight),0) AS TotalWeight " & vbNewLine &
"FROM traSalesReturn SRH " & vbNewLine &
"INNER JOIN traSalesReturnDet SRD ON " & vbNewLine &
"   SRH.ID=SRD.SalesReturnID " & vbNewLine &
"WHERE " & vbNewLine &
"	SRD.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND SRD.ItemID=@ItemID " & vbNewLine &
"	AND SRH.IsDeleted=0 " & vbNewLine &
"	AND SRH.StatusID=@StatusID " & vbNewLine &
"	AND SRH.ProgramID=@ProgramID " & vbNewLine &
"	AND SRH.CompanyID=@CompanyID " & vbNewLine &
"	AND SRH.CoAofStock=@CoAofStock " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = intCoAofStock
                    .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
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

        Public Shared Function GetTotalWeightStockOutOrderRequest(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer,
                                                                  ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                  ByVal intCoAofStock As Integer) As Decimal
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim decReturn As Decimal = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT ISNULL(SUM(ORD.TotalWeight+ORD.RoundingWeight-ORD.SCWeight),0) AS TotalWeight " & vbNewLine &
"FROM traOrderRequest ORH " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON " & vbNewLine &
"   ORH.ID=ORD.OrderRequestID " & vbNewLine &
"WHERE " & vbNewLine &
"	ORD.OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"	AND ORD.ItemID=@ItemID " & vbNewLine &
"	AND ORH.IsStock=1 " & vbNewLine &
"	AND ORH.IsDeleted=0 " & vbNewLine &
"	AND ORH.StatusID=@StatusID " & vbNewLine &
"	AND ORH.ProgramID=@ProgramID " & vbNewLine &
"	AND ORH.CompanyID=@CompanyID " & vbNewLine &
"	AND ORH.CoAofStock=@CoAofStock " & vbNewLine

                    .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = intCoAofStock
                    .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
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

        Public Shared Sub CalculateStockOut(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer,
                                            ByVal decOutTotalWeightProcess As Decimal, ByVal intProgramID As Integer,
                                            ByVal intCompanyID As Integer, ByVal intCoAofStock As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traStockIn SET    " & vbNewLine & _
"	OutQuantity= " & vbNewLine & _
"	( " & vbNewLine & _
"       SELECT  " & vbNewLine & _
"	        ISNULL(SUM(Quantity),0) AS TotalQuantity  " & vbNewLine & _
"       FROM traStockOut  " & vbNewLine & _
"       WHERE  " & vbNewLine & _
"	        OrderNumberSupplier=@OrderNumberSupplier  " & vbNewLine & _
"	        AND ItemID=@ItemID  " & vbNewLine & _
"	        AND CoAofStock=@CoAofStock  " & vbNewLine & _
"	        AND ProgramID=@ProgramID  " & vbNewLine & _
"	        AND CompanyID=@CompanyID " & vbNewLine & _
"	),    " & vbNewLine & _
"	OutTotalWeight= " & vbNewLine & _
"	( " & vbNewLine & _
"       SELECT  " & vbNewLine & _
"       	ISNULL(SUM(TotalWeight),0) AS TotalQuantity  " & vbNewLine & _
"       FROM traStockOut  " & vbNewLine & _
"       WHERE  " & vbNewLine & _
"       	OrderNumberSupplier=@OrderNumberSupplier  " & vbNewLine & _
"       	AND ItemID=@ItemID  " & vbNewLine & _
"       	AND CoAofStock=@CoAofStock  " & vbNewLine & _
"       	AND ProgramID=@ProgramID  " & vbNewLine & _
"       	AND CompanyID=@CompanyID " & vbNewLine & _
"	),    " & vbNewLine & _
"	OutTotalWeightProcess=@OutTotalWeightProcess    " & vbNewLine & _
"WHERE    " & vbNewLine & _
"	OrderNumberSupplier=@OrderNumberSupplier    " & vbNewLine & _
"	AND ItemID=@ItemID    " & vbNewLine & _
"	AND ProgramID=@ProgramID    " & vbNewLine & _
"	AND CompanyID=@CompanyID    " & vbNewLine & _
"	AND CoAofStock=@CoAofStock   " & vbNewLine

                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                .Parameters.Add("@OutTotalWeightProcess", SqlDbType.Decimal).Value = decOutTotalWeightProcess
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@CoAofStock", SqlDbType.Int).Value = intCoAofStock
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateStockInTotalWeight(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strID As String, ByVal decTotalWeight As Decimal)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traStockIn SET " & vbNewLine &
"   InTotalWeight=@TotalWeight " & vbNewLine &
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