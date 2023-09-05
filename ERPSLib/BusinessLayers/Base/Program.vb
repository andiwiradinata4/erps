Namespace BL
    Public Class Program

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Program.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Program) As Integer
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then
                        clsData.ID = DL.Program.GetMaxID(sqlCon, Nothing)
                        If DL.Program.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        End If
                    Else
                        If DL.Program.IsDeleted(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "Data tidak diedit. Data telah dihapus sebelumnya")
                        End If
                    End If

                    DL.Program.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData.ID
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.Program
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Program.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.Program.IsDeleted(sqlCon, Nothing, intID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.Program.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.Program.DeleteDataAll()
        'End Sub

    End Class

End Namespace