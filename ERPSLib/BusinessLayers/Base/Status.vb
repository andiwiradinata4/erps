Namespace BL
    Public Class Status

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Status.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Status) As Integer
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then
                        clsData.ID = DL.Status.GetMaxID(sqlCon, Nothing)
                        If DL.Status.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        End If
                    Else
                        If DL.Status.IsDeleted(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "Data tidak diedit. Data telah dihapus sebelumnya")
                        End If
                    End If

                    DL.Status.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData.ID
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.Status
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Status.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.Status.IsDeleted(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.Status.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.Status.DeleteDataAll()
        'End Sub

    End Class

End Namespace

