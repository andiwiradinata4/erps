Namespace BL

    Public Class BusinessPartner

#Region "Main"

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartner.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.BusinessPartner) As Integer
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.BusinessPartner.GetMaxID(sqlCon, Nothing)
                    If DL.BusinessPartner.DataExistsName(sqlCon, Nothing, clsData.Name, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nama rekan bisnis sudah ada.")
                    End If

                    DL.BusinessPartner.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.BusinessPartner
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartner.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.BusinessPartner.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.BusinessPartner.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

#End Region

#Region "Bank Account"

        Public Shared Function ListDataBankAccount(ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartner.ListDataBankAccount(sqlCon, Nothing, intBPID)
            End Using
        End Function
        
        Public Shared Function SaveDataBankAccount(ByVal bolNew As Boolean, ByVal clsData As VO.BusinessPartnerBankAccount) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.BusinessPartner.GetMaxIDBankAccount(sqlCon, Nothing)
                    If DL.BusinessPartner.DataExistsBankAccountBankName(sqlCon, Nothing, clsData.BankName, clsData.AccountNumber, clsData.ID) Then
                        Err.Raise(515, "", "Barang dengan tipe, spec dan ukuran yang diinput sudah ada")
                    End If

                    DL.BusinessPartner.SaveDataBankAccount(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return bolReturn
            End Using
        End Function

        Public Shared Function GetDetailBankAccount(ByVal intID As Integer) As VO.BusinessPartnerBankAccount
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartner.GetDetailBankAccount(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteDataBankAccount(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.BusinessPartner.GetStatusIDBankAccount(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.BusinessPartner.DeleteDataBankAccount(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

#End Region

    End Class

End Namespace
