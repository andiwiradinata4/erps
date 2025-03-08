Namespace DL
    Public Class VoucherType

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.Name, A.Remarks, A.CreatedBy, A.CreatedDate " & vbNewLine &
                    "FROM mstVoucherType A " & vbNewLine
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal intID As Integer) As VO.VoucherType
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.VoucherType
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.Name, A.Initial, A.Remarks, A.CreatedBy, A.CreatedDate " & vbNewLine &
                        "FROM mstVoucherType A " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   A.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.Name = .Item("Name")
                        voReturn.Initial = .Item("Initial")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

    End Class
End Namespace