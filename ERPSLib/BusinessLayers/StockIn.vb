Namespace BL

    Public Class StockIn

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.StockIn.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Sub SaveData(ByVal clsDataAll As List(Of VO.StockIn))
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
                                   ByVal clsDataAll As List(Of VO.StockIn))
            Try
                For Each clsData As VO.StockIn In clsDataAll
                    Dim decTotalWeight As Decimal = DL.StockIn.GetTotalWeightStockIn(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                    Dim clsExists As VO.StockIn = DL.StockIn.DataExists(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                    Dim bolNew As Boolean
                    If clsExists.ID = "" Then
                        bolNew = True
                        clsData.ID = Guid.NewGuid.ToString
                    Else
                        clsData.ID = clsExists.ID
                    End If

                    clsData.InTotalWeight = decTotalWeight
                    DL.StockIn.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    DL.StockIn.CalculateStockOut(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByVal strID As String) As VO.StockIn
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.StockIn.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal clsDataAll As List(Of VO.StockIn))
            Try
                For Each clsData As VO.StockIn In clsDataAll
                    DeleteData(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID)
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer)
            Try
                Dim clsExists As VO.StockIn = DL.StockIn.DataExists(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID)
                If clsExists.ID <> "" Then DL.StockIn.DeleteData(sqlCon, sqlTrans, clsExists.ID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
End Namespace