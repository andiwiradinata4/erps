Namespace BL
    Public Class Modules

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Modules.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Modules.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Modules) As Integer
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    If bolNew Then
                        clsData.ID = DL.Modules.GetMaxID(sqlCon, Nothing)
                        If DL.Modules.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        End If
                    Else
                        If DL.Modules.IsDeleted(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "Data tidak diedit. Data telah dihapus sebelumnya")
                        End If
                    End If

                    DL.Modules.SaveData(sqlCon, Nothing, bolNew, clsData)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.Modules
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Modules.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    If DL.Modules.IsDeleted(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.Modules.DeleteData(sqlCon, Nothing, intID)
                    End If
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.Modules.DeleteDataAll()
        'End Sub

    End Class 

End Namespace

