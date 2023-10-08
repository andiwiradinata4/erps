Namespace BL
    Public Class ChartOfAccount

        Public Shared Function ListData(ByVal enumFilterGroup As VO.ChartOfAccount.FilterGroup, ByVal intCompanyID As Integer, ByVal intProgramID As Integer, ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.ChartOfAccount.ListData(sqlCon, Nothing, enumFilterGroup, intCompanyID, intProgramID, intStatusID)

                '# Dont Get / Calculate Balance if for using View Lookup only
                If enumFilterGroup <> VO.ChartOfAccount.FilterGroup.ViewOnly Then
                    Dim dtLastBalance As DataTable = DL.Reports.GetBukuBesarLastBalance(sqlCon, Nothing, Now.AddMonths(12), 0, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID)

                    For Each dr As DataRow In dtReturn.Rows
                        For Each drBalance As DataRow In dtLastBalance.Rows
                            If dr.Item("ID") = drBalance.Item("ID") Then
                                dr.BeginEdit()
                                dr.Item("Balance") = drBalance.Item("Amount")
                                dr.EndEdit()
                                Exit For
                            End If
                        Next
                    Next
                    dtReturn.AcceptChanges()
                End If
            End Using
            Return dtReturn
        End Function

        Public Shared Function ListDataAll() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ChartOfAccount.ListDataAll(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function ListDataHistory(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                               ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                               ByVal intCOAID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ChartOfAccount.ListDataHistory(sqlCon, Nothing, intCompanyID, intProgramID, dtmDateFrom.Date, dtmDateTo.Date, intCOAID)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.ChartOfAccount) As Integer
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    If bolNew Then
                        clsData.ID = DL.ChartOfAccount.GetMaxID(sqlCon, Nothing)
                        If DL.ChartOfAccount.DataExists(sqlCon, Nothing, clsData.ID) Then
                            Err.Raise(515, "", "ID sudah ada sebelumnya")
                        End If
                    End If

                    If DL.ChartOfAccount.CodeExists(sqlCon, Nothing, clsData.Code, clsData.ID) Then
                        Err.Raise(515, "", "Kode akun sudah ada sebelumnya")
                    End If

                    DL.ChartOfAccount.SaveData(sqlCon, Nothing, bolNew, clsData)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ID
        End Function

        Public Shared Sub SaveDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String, _
                                      ByVal clsData As VO.ChartOfAccount)
            BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.ChartOfAccount.SaveDataAll(sqlCon, Nothing, clsData)
            End Using
        End Sub

        Public Shared Function GetDetail(ByVal intID As Integer) As VO.ChartOfAccount
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ChartOfAccount.GetDetail(sqlCon, Nothing, intID)
            End Using
        End Function

        Public Shared Function GetDetail(ByVal strCode As String) As VO.ChartOfAccount
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ChartOfAccount.GetDetail(sqlCon, Nothing, strCode)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal intID As Integer)
            BL.Server.ServerDefault()
            Try
                Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                    If DL.ChartOfAccount.GetStatusID(sqlCon, Nothing, intID) = VO.Status.Values.InActive Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah tidak aktif")
                    Else
                        DL.ChartOfAccount.DeleteData(sqlCon, Nothing, intID)
                    End If
                End Using
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Shared Sub DeleteDataAll(ByVal strServer As String, ByVal strDBMS As String, ByVal strUserID As String, ByVal strPassword As String)
            BL.Server.SetServer(strServer, strDBMS, strUserID, strPassword)
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.ChartOfAccount.DeleteDataAll(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub SyncFromVPS()
            BL.Server.SetServer(VO.DefaultServer.VPS, VO.DefaultServer.Database, UI.usUserApp.UserID, VO.DefaultServer.Password)
            Dim dtCOA As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtCOA = DL.ChartOfAccount.ListDataAll(sqlCon, Nothing)
            End Using

            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                DL.ChartOfAccount.DeleteDataAll(sqlCon, sqlTrans)
                Try
                    For Each dr As DataRow In dtCOA.Rows
                        DL.ChartOfAccount.SaveData(sqlCon, sqlTrans, True, New VO.ChartOfAccount With
                                                                           {
                                                                               .ID = dr.Item("ID"),
                                                                               .AccountGroupID = dr.Item("AccountGroupID"),
                                                                               .Code = dr.Item("Code"),
                                                                               .Name = dr.Item("Name"),
                                                                               .FirstBalance = dr.Item("FirstBalance"),
                                                                               .FirstBalanceDate = dr.Item("FirstBalanceDate"),
                                                                               .StatusID = dr.Item("StatusID"),
                                                                               .CreatedBy = dr.Item("CreatedBy"),
                                                                               .CreatedDate = dr.Item("CreatedDate"),
                                                                               .LogBy = dr.Item("LogBy"),
                                                                               .LogDate = dr.Item("LogDate"),
                                                                               .LogInc = dr.Item("LogInc"),
                                                                               .Initial = dr.Item("Initial")
                                                                           })
                    Next
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                End Try
            End Using
        End Sub


    End Class

End Namespace

