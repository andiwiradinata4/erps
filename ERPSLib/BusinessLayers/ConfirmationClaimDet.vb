Namespace BL
 
    Public Class ConfirmationClaimDet
 
        Public Shared Function ListData() As DataTable
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaimDet.ListData(sqlCon, Nothing) 
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew as Boolean, ByVal clsData As VO.ConfirmationClaimDet) As String
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                If bolNew Then 
                    clsData.ID = DL.ConfirmationClaimDet.GetMaxID(sqlCon, sqlTrans)

                End If 

                DL.ConfirmationClaimDet.SaveData(sqlCon, sqlTrans, bolNew, clsData) 

                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
                Throw ex 
            End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.ConfirmationClaimDet
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaimDet.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function 

        Public Shared Sub DeleteData(ByVal strID As String)
            BL.Server.ServerDefault() 
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                'If DL.ConfirmationClaimDet.XXX(sqlCon, sqlTransstrID) Then 
                '    Err.Raise(515,"","Cannot Delete. Data already used at XXX") 
                'End If 

                DL.ConfirmationClaimDet.DeleteData(sqlCon, sqlTrans, strID) 

                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
                Throw ex 
            End Try
            End Using
        End Sub

    End Class 

End Namespace

