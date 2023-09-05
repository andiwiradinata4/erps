Namespace BL
    Public Class PaymentReferences
        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentReferences.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentReferences.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PaymentReferences) As Integer
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then
                        clsData.ID = DL.PaymentReferences.GetMaxID(sqlCon, Nothing)
                        If DL.PaymentReferences.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        End If
                    End If

                    DL.PaymentReferences.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData.ID
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.PaymentReferences
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PaymentReferences.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.PaymentReferences.GetIDStatus(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.PaymentReferences.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using

        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.PaymentReferences.DeleteDataAll()
        'End Sub

    End Class

End Namespace

