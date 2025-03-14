Namespace BL
    Public Class DeliveryLocation

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.DeliveryLocation.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo(Optional ByVal bolIsAddAll As Boolean = True) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim dtData As DataTable = DL.DeliveryLocation.ListData(sqlCon, Nothing)
                If bolIsAddAll Then
                    Dim dr As DataRow = dtData.NewRow
                    dr.BeginEdit()
                    dr.Item("ID") = 0
                    dr.Item("Description") = "ALL"
                    dr.Item("StatusID") = VO.Status.Values.Active
                    dr.EndEdit()
                    dtData.Rows.Add(dr)
                    dtData.AcceptChanges()
                End If
                Dim drValid() As DataRow = dtData.Select("StatusID=" & VO.Status.Values.Active, "ID")
                Return drValid.CopyToDataTable
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.DeliveryLocation) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.DeliveryLocation.GetMaxID(sqlCon, Nothing)
                    If DL.DeliveryLocation.DataExists(sqlCon, Nothing, clsData.Description, clsData.ID) Then
                        Err.Raise(515, "", "Deskripsi " & clsData.Description & " sudah ada")
                    End If

                    DL.DeliveryLocation.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return bolReturn
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.DeliveryLocation
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.DeliveryLocation.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.DeliveryLocation.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.DeliveryLocation.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

    End Class
End Namespace