Namespace BL
    Public Class PaymentTypeCategory

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentTypeCategory.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentTypeCategory.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PaymentTypeCategory) As Integer
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then
                        clsData.ID = DL.PaymentTypeCategory.GetMaxID(sqlCon, Nothing)
                        If DL.PaymentTypeCategory.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        ElseIf DL.PaymentTypeCategory.DataExistsCode(sqlCon, Nothing, clsData.Code, clsData.ID) Then
                            Err.Raise(515, "", "Kode sudah ada sebelumnya")
                        ElseIf DL.PaymentTypeCategory.DataExistsName(sqlCon, Nothing, clsData.Name, clsData.ID) Then
                            Err.Raise(515, "", "Nama sudah ada sebelumnya")
                        End If
                    End If

                    DL.PaymentTypeCategory.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData.ID
            End Using

        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.PaymentTypeCategory
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentTypeCategory.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.PaymentTypeCategory.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.PaymentTypeCategory.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using

        End Sub

    End Class
End Namespace