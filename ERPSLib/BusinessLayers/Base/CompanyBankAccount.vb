Namespace BL

    Public Class CompanyBankAccount

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.CompanyBankAccount.ListData(sqlCon, Nothing)
            End Using
        End Function
        
        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.CompanyBankAccount) As Integer
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.CompanyBankAccount.GetMaxID(sqlCon, Nothing)
                    If DL.CompanyBankAccount.DataExists(sqlCon, Nothing, clsData.BankName, clsData.AccountNumber, clsData.ID) Then
                        Err.Raise(515, "", "Akun Bank dengan Nama Bank:" & clsData.BankName & " dan Nomor Rekening:" & clsData.AccountNumber & " telah ada")
                    End If

                    DL.CompanyBankAccount.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.CompanyBankAccount
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.CompanyBankAccount.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.CompanyBankAccount.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.CompanyBankAccount.DeleteData(sqlCon, Nothing, intID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

    End Class

End Namespace