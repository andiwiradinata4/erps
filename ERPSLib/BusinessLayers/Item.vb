Namespace BL
    Public Class Item

        Public Shared Function ListData(ByVal intItemTypeID As Integer, ByVal intItemSpecificationID As Integer,
                                        ByVal bolShowAll As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Item.ListData(sqlCon, Nothing, intItemTypeID, intItemSpecificationID, bolShowAll)
            End Using
        End Function

        Public Shared Function GetNewItemCode(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal intItemType As Integer, ByVal intItemSpecification As Integer) As String
            Dim strReturn As String = Format(intItemType, "000") & "." & Format(intItemSpecification, "000") & "-"
            strReturn &= Format(DL.Item.GetMaxItemCode(sqlCon, sqlTrans, strReturn), "0000000")
            Return strReturn
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Item) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.Item.GetMaxID(sqlCon, Nothing)
                    If bolNew And clsData.ItemCode.Trim = "" Then clsData.ItemCode = GetNewItemCode(sqlCon, Nothing, clsData.ItemTypeID, clsData.ItemSpecificationID)
                    If DL.Item.DataExists(sqlCon, Nothing, clsData.ItemTypeID, clsData.ItemSpecificationID, clsData.Thick, clsData.Width, clsData.Length, clsData.ID) Then
                        Err.Raise(515, "", "Barang dengan tipe, spec dan ukuran yang diinput sudah ada")
                    End If

                    DL.Item.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return bolReturn
            End Using
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.Item
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Item.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.Item.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.Item.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

    End Class

End Namespace
