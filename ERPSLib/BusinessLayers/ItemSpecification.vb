Namespace BL
    Public Class ItemSpecification

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ItemSpecification.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ItemSpecification.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.ItemSpecification) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.ItemSpecification.GetMaxID(sqlCon, Nothing)
                    If DL.ItemSpecification.DataExists(sqlCon, Nothing, clsData.Description, clsData.ID) Then
                        Err.Raise(515, "", "Deskripsi " & clsData.Description & " sudah ada")
                    End If

                    DL.ItemSpecification.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return bolReturn
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.ItemSpecification
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ItemSpecification.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.ItemSpecification.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.ItemSpecification.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

    End Class
End Namespace