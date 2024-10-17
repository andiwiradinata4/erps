Namespace BL
 
    Public Class ConfirmationClaimStatus
 
        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaimStatus.ListData(sqlCon, Nothing) 
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew as Boolean, ByVal clsData As VO.ConfirmationClaimStatus) As String
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                If bolNew Then 
                    clsData.ID = DL.ConfirmationClaimStatus.GetMaxID(sqlCon, sqlTrans)

                End If 

                DL.ConfirmationClaimStatus.SaveData(sqlCon, sqlTrans, bolNew, clsData) 

                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
                Throw ex 
            End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.ConfirmationClaimStatus
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaimStatus.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function 

        Public Shared Sub DeleteData(ByVal strID As String)
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                'If DL.ConfirmationClaimStatus.XXX(sqlCon, sqlTransstrID) Then 
                '    Err.Raise(515,"","Cannot Delete. Data already used at XXX") 
                'End If 

                DL.ConfirmationClaimStatus.DeleteData(sqlCon, sqlTrans, strID) 

                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
                Throw ex 
            End Try
            End Using
        End Sub

    End Class 

End Namespace

