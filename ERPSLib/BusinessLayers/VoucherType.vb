Namespace BL
    Public Class VoucherType

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.VoucherType.ListData(sqlCon, Nothing)
            End Using
        End Function

    End Class
End Namespace