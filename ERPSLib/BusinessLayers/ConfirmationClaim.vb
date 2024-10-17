Namespace BL
 
    Public Class ConfirmationClaim
 
        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaim.ListData(sqlCon, Nothing) 
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew as Boolean, ByVal clsData As VO.ConfirmationClaim) As String
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                If bolNew Then 
                    clsData.ID = DL.ConfirmationClaim.GetMaxID(sqlCon, sqlTrans)

                End If 

                DL.ConfirmationClaim.SaveData(sqlCon, sqlTrans, bolNew, clsData) 

                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
                Throw ex 
            End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.ConfirmationClaim
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaim.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function 

        Public Shared Sub DeleteData(ByVal strID As String)
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                'If DL.ConfirmationClaim.XXX(sqlCon, sqlTransstrID) Then 
                '    Err.Raise(515,"","Cannot Delete. Data already used at XXX") 
                'End If 

                DL.ConfirmationClaim.DeleteData(sqlCon, sqlTrans, strID) 

                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
                Throw ex 
            End Try
            End Using
        End Sub

    End Class 

End Namespace

