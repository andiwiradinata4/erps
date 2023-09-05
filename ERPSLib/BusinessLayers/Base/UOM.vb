Namespace BL
    Public Class UOM
        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UOM.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UOM.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.UOM) As VO.UOM
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then
                        clsData.ID = DL.UOM.GetMaxID(sqlCon, Nothing)
                        If DL.UOM.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        End If
                    End If

                    DL.UOM.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.UOM
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.UOM.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.UOM.GetIDStatus(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.UOM.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.UOM.DeleteDataAll()
        'End Sub

    End Class

End Namespace

