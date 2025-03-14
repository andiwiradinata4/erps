Namespace BL
    Public Class TransporterPriceType

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.TransporterPriceType.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.TransporterPriceType.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.TransporterPriceType) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.TransporterPriceType.GetMaxID(sqlCon, Nothing)
                    If DL.TransporterPriceType.DataExists(sqlCon, Nothing, clsData.Description, clsData.ID) Then
                        Err.Raise(515, "", "Deskripsi " & clsData.Description & " sudah ada")
                    End If

                    DL.TransporterPriceType.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return bolReturn
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.TransporterPriceType
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.TransporterPriceType.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.TransporterPriceType.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.TransporterPriceType.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

    End Class
End Namespace