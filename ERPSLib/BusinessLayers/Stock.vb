Namespace BL
    Public Class Stock
        Public Shared Function ListData(ByVal intItemTypeID As Integer, ByVal intItemSpecificationID As Integer,
                                        ByVal bolShowAll As Boolean, ByVal bolIsLookup As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Stock.ListData(sqlCon, Nothing, intItemTypeID, intItemSpecificationID, bolShowAll, bolIsLookup)
            End Using
        End Function

        Public Shared Function ListDataHistory(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                               ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                               ByVal intItemID As Integer, ByVal strOrderNumberSupplier As String,
                                               ByVal enumHistory As VO.Stock.History) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Stock.ListDataHistory(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intItemID, strOrderNumberSupplier, enumHistory)
            End Using
        End Function

    End Class
End Namespace