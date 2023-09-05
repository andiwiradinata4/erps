Namespace BL
    Public Class Access

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Access.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Access) As Integer
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    If bolNew Then
                        clsData.ID = DL.Access.GetMaxID(sqlCon, Nothing)
                        If DL.Access.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        End If
                    Else
                        If DL.Access.IsDeleted(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "Data tidak diedit. Data telah dihapus sebelumnya")
                        End If
                    End If

                    DL.Access.SaveData(sqlCon, Nothing, bolNew, clsData)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ID
        End Function

        'Public Shared Sub SaveDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
        '                              ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String, _
        '                              ByVal clsData As VO.Access)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.Access.SaveDataAll(clsData)
        'End Sub

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.Access
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Access.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    If DL.Access.IsDeleted(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.Access.DeleteData(sqlCon, Nothing, intID)
                    End If
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.Access.DeleteDataAll()
        'End Sub

    End Class 

End Namespace

