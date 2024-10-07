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
                    clsData.ID = SaveData(sqlCon, sqlTrans, bolNew, clsData)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal bolNew As Boolean, ByVal clsData As VO.ARAPDueDateHistory) As String
            Try
                Dim strNewID As String = clsData.ParentID & "-"
                'Dim dtData As DataTable = DL.ARAPDueDateHistory.ListData(sqlCon, sqlTrans, clsData.ParentID)
                'If dtData.Rows.Count = 0 Then
                '    Dim clsARAP As VO.ARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Sales)
                '    If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Purchase)
                '    Dim clsDataPrev As New VO.ARAPDueDateHistory
                '    clsDataPrev.ID = Format(DL.ARAPDueDateHistory.GetMaxID(sqlCon, sqlTrans, clsData.ParentID) + 1, "000")
                '    clsDataPrev.ParentID = clsData.ParentID
                '    clsDataPrev.DueDate = clsARAP.DueDate
                '    clsDataPrev.LogBy = clsData.LogBy

                '    DL.ARAPDueDateHistory.SaveData(sqlCon, sqlTrans, bolNew, clsData)
                'End If

                If bolNew Then
                    clsData.ID = Format(DL.ARAPDueDateHistory.GetMaxID(sqlCon, sqlTrans, clsData.ParentID) + 1, "000")
                Else

                End If
                DL.ARAPDueDateHistory.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                Dim clsARAP As VO.ARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Sales)
                If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Purchase)
                If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then '# TODO LIST

                End If

                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
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

        Public Shared Sub DeleteData(ByVal strID As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                    'If DL.ARAPDueDateHistory.XXX(sqlCon, sqlTransstrID) Then 
                    '    Err.Raise(515,"","Cannot Delete. Data already used at XXX") 
                    'End If 

                    DL.ARAPDueDateHistory.DeleteData(sqlCon, sqlTrans, strID)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

    End Class

End Namespace

