Namespace BL
    Public Class BusinessPartner

#Region "Main"

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartner.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function GetNewBPCode(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strBPName As String) As String
            Dim strReturn As String = Left(strBPName, 1) & "-"
            strReturn &= Format(DL.BusinessPartner.GetMaxBPCode(sqlCon, sqlTrans, strReturn), "0000000")
            Return strReturn
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.BusinessPartner) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If bolNew Then clsData.ID = DL.BusinessPartner.GetMaxID(sqlCon, Nothing)
                    If bolNew And clsData.Code.Trim = "" Then clsData.Code = GetNewBPCode(sqlCon, Nothing, clsData.Name.Trim)
                    If DL.BusinessPartner.DataExistsName(sqlCon, Nothing, clsData.Name, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nama rekan bisnis sudah ada.")
                    End If

                    DL.BusinessPartner.SaveData(sqlCon, Nothing, bolNew, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
            Return clsData.Code
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
                    If DL.BusinessPartner.DataExistsBankAccount(sqlCon, Nothing, clsData.BankName, clsData.AccountNumber, clsData.ID) Then
                        Err.Raise(515, "", "Akun Bank dengan Nama Bank:" & clsData.BankName & " dan Nomor Rekening:" & clsData.AccountNumber & " telah ada")
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

#Region "Assign"

        Public Shared Function ListDataAssign(ByVal intCOAID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartner.ListDataAssign(sqlCon, Nothing, intCOAID)
            End Using
        End Function

        Public Shared Function SaveDataAssign(ByVal intCOAID As Integer, ByVal clsDataAll() As VO.BusinessPartnerAssign) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.BusinessPartner.DeleteDataAssign(sqlCon, sqlTrans, intCOAID)

                    For Each clsItem As VO.BusinessPartnerAssign In clsDataAll
                        clsItem.ID = DL.BusinessPartner.GetMaxIDAssign(sqlCon, sqlTrans)
                        DL.BusinessPartner.SaveDataAssign(sqlCon, sqlTrans, clsItem)
                    Next

                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub SaveDataAllAssign(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String, _
                                            ByVal clsData As VO.BusinessPartnerAssign)
            BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.BusinessPartner.SaveDataAssign(sqlCon, Nothing, clsData)
            End Using
        End Sub

        Public Shared Sub DeleteDataAllAssign(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
            BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.BusinessPartner.DeleteDataAllAssign(sqlCon, Nothing)
            End Using
        End Sub

#End Region

    End Class
End Namespace
