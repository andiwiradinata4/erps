Namespace BL
    Public Class User

        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.User.ListData(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataForCombo() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.User.ListDataForCombo(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataByUserIDAndPassword(ByVal strUserID As String, ByVal strPassword As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.User.ListDataByUserIDAndPassword(sqlCon, Nothing, strUserID, strPassword)
            End Using
        End Function

        Private Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim strReturn As String = "S" & Format(Now, "yyyyMMdd")
            strReturn = strReturn & Format(DL.User.GetMaxID(sqlCon, sqlTrans, strReturn), "000")
            Return strReturn
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.User, ByVal clsDataCompany() As VO.UserCompany) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.StaffID = GetNewID(sqlCon, sqlTrans)
                        If clsData.ID.Trim = "" Then clsData.ID = clsData.StaffID
                        If DL.User.DataExists(sqlCon, sqlTrans, clsData.ID) Then
                            Err.Raise(515, "", "User ID sudah ada sebelumnya")
                        End If
                    End If

                    DL.User.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save User Company
                    DL.UserCompany.DeleteDataByUserID(sqlCon, sqlTrans, clsData.ID)
                    For Each clsItem As VO.UserCompany In clsDataCompany
                        clsItem.ID = DL.UserCompany.GetMaxID(sqlCon, sqlTrans)
                        clsItem.UserID = clsData.ID
                        DL.UserCompany.SaveData(sqlCon, sqlTrans, clsItem)
                    Next

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
                Return clsData.ID
            End Using
            
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.User
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.User = DL.User.GetDetail(sqlCon, Nothing, strID)
                clsData.Password = Encryption.Decrypt(clsData.Password)
                Return clsData
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    If DL.User.GetStatusID(sqlCon, Nothing, strID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.User.DeleteData(sqlCon, Nothing, strID)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Sub

        'Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
        '    BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
        '    DL.User.DeleteDataAll()
        'End Sub

        Public Shared Function ValidateUser(ByVal strUserID As String, ByVal strPassword As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.User = DL.User.GetDetail(sqlCon, Nothing, strUserID)
                Dim strDecPassword As String = Encryption.Decrypt(clsData.Password)
                If strDecPassword = strPassword Then
                    bolReturn = True
                End If
            End Using
            Return bolReturn
        End Function

        Public Shared Function ChangePassword(ByVal clsData As VO.User, ByVal strOldPassword As String) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    Dim dtData As DataTable = DL.User.ListDataByUserIDAndPassword(sqlCon, Nothing, clsData.ID, Encryption.Encrypt(strOldPassword))
                    If dtData.Rows.Count = 0 Then
                        Err.Raise(515, "", "Password sebelumnya tidak valid")
                    End If

                    clsData.Password = Encryption.Encrypt(clsData.Password)
                    DL.User.ChangePassword(sqlCon, Nothing, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData.ID
            End Using
        End Function

        Public Shared Function ResetPassword(ByVal clsData As VO.User) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Try
                    clsData.Password = Encryption.Encrypt(clsData.Password)
                    DL.User.ChangePassword(sqlCon, Nothing, clsData)
                Catch ex As Exception
                    Throw ex
                End Try
                Return clsData.ID
            End Using
        End Function


    End Class

End Namespace

