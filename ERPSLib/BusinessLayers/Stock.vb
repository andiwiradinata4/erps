Namespace BL
    Public Class Stock
        Public Shared Function ListData(ByVal intItemTypeID As Integer, ByVal intItemSpecificationID As Integer,
                                        ByVal bolShowAll As Boolean, ByVal bolIsLookup As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Stock.ListData(sqlCon, Nothing, intItemTypeID, intItemSpecificationID, bolShowAll, bolIsLookup)
            End Using
        End Function
    End Class
End Namespace