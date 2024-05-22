Namespace BL

    Public Class StockOut

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.StockOut.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Sub SaveData(ByVal clsDataAll As List(Of VO.StockOut))
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    SaveData(sqlCon, sqlTrans, clsDataAll)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal clsDataAll As List(Of VO.StockOut))
            Try
                For Each clsData As VO.StockOut In clsDataAll
                    Dim decTotalWeightDelivery As Decimal = DL.StockOut.GetTotalWeightStockOutDelivery(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                    Dim decTotalWeightCutting As Decimal = DL.StockOut.GetTotalWeightStockOutCutting(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                    Dim decOutTotalWeightProcess As Decimal = DL.StockIn.GetTotalWeightStockOutOrderRequest(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                    Dim clsExists As VO.StockOut = DL.StockOut.DataExists(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                    Dim bolNew As Boolean
                    If clsExists.ID = "" Then
                        bolNew = True
                        clsData.ID = Guid.NewGuid.ToString
                    Else
                        clsData.ID = clsExists.ID
                    End If

                    clsData.TotalWeight = decTotalWeightDelivery + decTotalWeightCutting
                    DL.StockOut.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    DL.StockIn.CalculateStockOut(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, decOutTotalWeightProcess)
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateStockOut(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer)
            Try
                Dim decTotalWeightDelivery As Decimal = DL.StockOut.GetTotalWeightStockOutDelivery(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID)
                Dim decTotalWeightCutting As Decimal = DL.StockOut.GetTotalWeightStockOutCutting(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID)
                Dim decOutTotalWeightProcess As Decimal = DL.StockIn.GetTotalWeightStockOutOrderRequest(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID)
                Dim clsExists As VO.StockIn = DL.StockIn.DataExists(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID)
                If clsExists.ID <> "" Then
                    DL.StockOut.UpdateStockOutTotalWeight(sqlCon, sqlTrans, clsExists.ID, decTotalWeightDelivery + decTotalWeightCutting)
                End If

                DL.StockIn.CalculateStockOut(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID, decOutTotalWeightProcess)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByVal strID As String) As VO.StockOut
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.StockOut.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal clsDataAll As List(Of VO.StockOut))
            Try
                For Each clsData As VO.StockOut In clsDataAll
                    DeleteData(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer)
            Try
                Dim clsExists As VO.StockOut = DL.StockOut.DataExists(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID)
                If clsExists.ID <> "" Then DL.StockOut.DeleteData(sqlCon, sqlTrans, clsExists.ID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class

End Namespace

