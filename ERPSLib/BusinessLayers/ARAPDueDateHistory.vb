Namespace BL

    Public Class ARAPDueDateHistory

        Public Shared Function ListData(ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ARAPDueDateHistory.ListData(sqlCon, Nothing, strParentID)
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.ARAPDueDateHistory) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    clsData.ID = SaveData(sqlCon, sqlTrans, bolNew, clsData, False)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal bolNew As Boolean, ByVal clsData As VO.ARAPDueDateHistory,
                                        ByVal bolIsApprove As Boolean) As String
            Try
                Dim strNewID As String = clsData.ParentID & "-"
                Dim clsARAP As VO.ARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Sales)
                If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Purchase)

                Dim dtData As DataTable = DL.ARAPDueDateHistory.ListData(sqlCon, sqlTrans, clsData.ParentID)
                If bolNew Then
                    clsData.ID = strNewID & Format(DL.ARAPDueDateHistory.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "000")
                    If dtData.Rows.Count > 0 Then If Format(dtData.Rows(dtData.Rows.Count - 1).Item("DueDate"), "yyyyMMdd") >= Format(clsData.DueDate, "yyyyMMdd") Then Err.Raise(515, "", "Data tidak dapat disimpan. Tanggal jatuh tempo harus lebih besar dari tanggal jatuh tempo sebelumnya")
                Else
                    If dtData.Rows.Count > 0 Then If dtData.Rows(dtData.Rows.Count - 1).Item("ID") <> clsData.ID Then Err.Raise(515, "", "Data tidak dapat disimpan. Hanya dapat mengedit data terakhir")
                End If

                DL.ARAPDueDateHistory.SaveData(sqlCon, sqlTrans, bolNew, clsData)


                If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                    DL.AccountReceivable.UpdateDueDate(sqlCon, sqlTrans, clsData.ParentID, clsData.DueDate)
                    If Not bolIsApprove Then BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, clsData.ParentID, "UPDATE TANGGAL JATUH TEMPO", clsData.LogBy, Format(clsARAP.DueDate, "dd MMMM yyyy") & " -> " & Format(clsData.DueDate, "dd MMMM yyyy"))
                Else
                    DL.AccountPayable.UpdateDueDate(sqlCon, sqlTrans, clsData.ParentID, clsData.DueDate)
                    If Not bolIsApprove Then BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, clsData.ParentID, "UPDATE TANGGAL JATUH TEMPO", clsData.LogBy, Format(clsARAP.DueDate, "dd MMMM yyyy") & " -> " & Format(clsData.DueDate, "dd MMMM yyyy"))
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.ARAPDueDateHistory
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ARAPDueDateHistory.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strParentID As String, ByVal strLogBy As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtData As DataTable = DL.ARAPDueDateHistory.ListData(sqlCon, sqlTrans, strParentID)
                    If dtData.Rows.Count > 0 Then
                        If dtData.Rows(dtData.Rows.Count - 1).Item("ID") <> strID Then
                            Err.Raise(515, "", "Data tidak dapat dihapus. Hapus data terakhir terlebih dahulu")
                        End If
                    End If

                    DL.ARAPDueDateHistory.DeleteData(sqlCon, sqlTrans, strID)

                    dtData = DL.ARAPDueDateHistory.ListData(sqlCon, sqlTrans, strParentID)
                    If dtData.Rows.Count > 0 Then
                        Dim clsARAP As VO.ARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, strParentID, VO.ARAP.ARAPTypeValue.Sales)
                        If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, strParentID, VO.ARAP.ARAPTypeValue.Purchase)
                        If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                            DL.AccountReceivable.UpdateDueDate(sqlCon, sqlTrans, strParentID, dtData.Rows(dtData.Rows.Count - 1).Item("DueDate"))
                            BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strParentID, "UPDATE TANGGAL JATUH TEMPO", strLogBy, Format(clsARAP.DueDate, "dd MMMM yyyy") & " -> " & Format(dtData.Rows(dtData.Rows.Count - 1).Item("DueDate"), "dd MMMM yyyy"))
                        Else
                            DL.AccountPayable.UpdateDueDate(sqlCon, sqlTrans, strParentID, dtData.Rows(dtData.Rows.Count - 1).Item("DueDate"))
                            BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strParentID, "UPDATE TANGGAL JATUH TEMPO", strLogBy, Format(clsARAP.DueDate, "dd MMMM yyyy") & " -> " & Format(dtData.Rows(dtData.Rows.Count - 1).Item("DueDate"), "dd MMMM yyyy"))
                        End If
                    End If

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

    End Class

End Namespace

