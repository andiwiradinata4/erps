Namespace BL

    Public Class StockOut

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.StockOut.ListData(sqlCon, Nothing, intProgramID, intCompanyID)
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
                    'Dim clsExists As VO.StockOut = DL.StockOut.DataExists(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)
                    'Dim decTotalWeightDelivery As Decimal = DL.StockOut.GetTotalWeightStockOutDelivery(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)
                    'Dim decTotalWeightCutting As Decimal = DL.StockOut.GetTotalWeightStockOutCutting(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)
                    'Dim decOutTotalWeightProcess As Decimal = DL.StockIn.GetTotalWeightStockOutOrderRequest(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)
                    'Dim bolNew As Boolean = IIf(clsExists.ID = "", True, False)
                    'If bolNew Then
                    '    clsData.ID = Guid.NewGuid.ToString
                    'Else
                    '    clsData.ID = clsExists.ID
                    'End If

                    'clsData.TotalWeight = decTotalWeightDelivery + decTotalWeightCutting
                    'DL.StockOut.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    'DL.StockIn.CalculateStockOut(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, decOutTotalWeightProcess, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)

                    SaveData(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)

                    '# Recalculate Other CoAofStock Because Have Potention to change CoAofStock when Update Data Transaction
                    Dim dtStockOut As DataTable = DL.StockOut.ListData(sqlCon, sqlTrans, clsData.ProgramID, clsData.CompanyID, clsData.OrderNumberSupplier, clsData.ItemID)
                    For Each dr As DataRow In dtStockOut.Rows
                        If dr.Item("CoAofStock") <> clsData.CoAofStock Then SaveData(sqlCon, sqlTrans, dr.Item("OrderNumberSupplier"), dr.Item("ItemID"), dr.Item("ProgramID"), dr.Item("CompanyID"), dr.Item("CoAofStock"))
                    Next

                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal strOrderNumberSupplier As String, ByVal intItemID As Integer,
                                   ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                   ByVal intCoAofStock As Integer)
            Try
                Dim clsData As New VO.StockOut
                clsData.ProgramID = intProgramID
                clsData.CompanyID = intCompanyID
                clsData.ParentID = ""
                clsData.ParentDetailID = ""
                clsData.OrderNumberSupplier = strOrderNumberSupplier
                clsData.SourceData = ""
                clsData.ItemID = intItemID
                clsData.Quantity = 0
                clsData.Weight = 0
                clsData.TotalWeight = 0
                clsData.CoAofStock = intCoAofStock

                Dim clsExists As VO.StockOut = DL.StockOut.DataExists(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID, intProgramID, intCompanyID, intCoAofStock)
                Dim decTotalWeightDelivery As Decimal = DL.StockOut.GetTotalWeightStockOutDelivery(sqlCon, sqlTrans, strOrderNumberSupplier, intItemID, intProgramID, intCompanyID, intCoAofStock)
                Dim decTotalWeightCutting As Decimal = DL.StockOut.GetTotalWeightStockOutCutting(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)
                Dim decOutTotalWeightProcess As Decimal = DL.StockIn.GetTotalWeightStockOutOrderRequest(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)
                Dim bolNew As Boolean = IIf(clsExists.ID = "", True, False)
                If bolNew Then
                    clsData.ID = Guid.NewGuid.ToString
                Else
                    clsData.ID = clsExists.ID
                End If

                clsData.TotalWeight = decTotalWeightDelivery + decTotalWeightCutting
                DL.StockOut.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                DL.StockIn.CalculateStockOut(sqlCon, sqlTrans, clsData.OrderNumberSupplier, clsData.ItemID, decOutTotalWeightProcess, clsData.ProgramID, clsData.CompanyID, clsData.CoAofStock)
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

    End Class

End Namespace

