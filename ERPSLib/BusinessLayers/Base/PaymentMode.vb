Namespace BL
    Public Class PaymentMode

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentMode.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentMode.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PaymentMode) As Integer
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then
                        clsData.ID = DL.PaymentMode.GetMaxID(sqlCon, Nothing)
                        If DL.PaymentMode.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        ElseIf DL.PaymentMode.DataExistsCode(sqlCon, Nothing, clsData.Code, clsData.ID) Then
                            Err.Raise(515, "", "Kode sudah ada sebelumnya")
                        ElseIf DL.PaymentMode.DataExistsName(sqlCon, Nothing, clsData.Name, clsData.ID) Then
                            Err.Raise(515, "", "Nama sudah ada sebelumnya")
                        End If
                    End If

                    DL.PaymentMode.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData.ID
            End Using

        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.PaymentMode
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentMode.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.PaymentMode.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.PaymentMode.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using

        End Sub

    End Class
End Namespace