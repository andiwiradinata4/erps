Namespace DL
 
    Public Class ConfirmationClaimStatus
 
        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText = 
"
SELECT 
	A.ID, A.ConfirmationClaimID, A.Status, A.StatusBy, A.StatusDate, A.Remarks
FROM traConfirmationClaimStatus A
WHERE 
	1=1 
"

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew as Boolean, ByVal clsData As VO.ConfirmationClaimStatus)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText = 
"
INSERT INTO traConfirmationClaimStatus
	(ID, ConfirmationClaimID, StatusBy, StatusDate, Remarks)
VALUES 
	(@ID, @ConfirmationClaimID, @LogBy, GETDATE(), @Remarks)
"
                Else
                    .CommandText = 
"
UPDATE traConfirmationClaimStatus SET 
	ConfirmationClaimID=@ConfirmationClaimID, 
	Status=@Status, 
	StatusBy=@StatusBy, 
	StatusDate=@StatusDate, 
	Remarks=@Remarks
WHERE
	ID=@ID
"
                End If

                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = clsData.ID
                .Parameters.Add("@ConfirmationClaimID", SqlDbType.varchar, 100).Value = clsData.ConfirmationClaimID
                .Parameters.Add("@Status", SqlDbType.varchar, 100).Value = clsData.Status
                .Parameters.Add("@StatusBy", SqlDbType.varchar, 20).Value = clsData.StatusBy
                .Parameters.Add("@StatusDate", SqlDbType.datetime).Value = clsData.StatusDate
                .Parameters.Add("@Remarks", SqlDbType.varchar, 250).Value = clsData.Remarks

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.ConfirmationClaimStatus
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ConfirmationClaimStatus
            Try
                With sqlcmdExecute
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText =  
"
SELECT TOP 1 
	A.ID, A.ConfirmationClaimID, A.Status, A.StatusBy, A.StatusDate, A.Remarks
FROM traConfirmationClaimStatus A
WHERE
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        voReturn.ID = .Item("ID")
                        voReturn.ConfirmationClaimID = .Item("ConfirmationClaimID")
                        voReturn.Status = .Item("Status")
                        voReturn.StatusBy = .Item("StatusBy")
                        voReturn.StatusDate = .Item("StatusDate")
                        voReturn.Remarks = .Item("Remarks")
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return voReturn 
        End Function 

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText = 
"
DELETE FROM traConfirmationClaimStatus
WHERE
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans) 
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) AS Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing 
            Dim intReturn As Integer = 0 
            Try 
                With sqlcmdExecute 
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText = 
"
SELECT TOP 1
	ID=ISNULL(MAX(ID),0)
FROM traConfirmationClaimStatus
"
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        intReturn = .Item("ID") + 1
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return intReturn 
        End Function 

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False 
            Try 
                With sqlcmdExecute 
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText = 
"
SELECT TOP 1
	ID
FROM traConfirmationClaimStatus
WHERE 
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        bolExists = True
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return bolExists 
        End Function 

    End Class 

End Namespace

