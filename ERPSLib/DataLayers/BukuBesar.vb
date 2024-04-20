Namespace DL
    Public Class BukuBesar
        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        Optional ByVal intCOAIDParent As Integer = 0) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "     A.CompanyID, A.ProgramID, A.ID, A.TransactionDate, A.ReferencesID, A.COAIDParent, COAP.Code AS COAParentCode, COAP.Name AS COAParentName, " & vbNewLine & _
                   "     A.COAIDChild, COAC.Code AS COACodeChild, COAC.Name AS COANameChild, A.DebitAmount, A.CreditAmount,   " & vbNewLine & _
                   "     A.Balance, A.Remarks, A.CreatedBy, A.CreatedDate, RemarksInfo=CASE WHEN A.Remarks='' THEN COAC.Name ELSE A.Remarks END, A.ReferencesNo, A.BPID " & vbNewLine & _
                   "FROM traBukuBesar A " & vbNewLine & _
                   "INNER JOIN mstChartOfAccount COAP ON " & vbNewLine & _
                   "    A.COAIDParent=COAP.ID " & vbNewLine & _
                   "INNER JOIN mstChartOfAccount COAC ON " & vbNewLine & _
                   "    A.COAIDChild=COAC.ID " & vbNewLine & _
                   "WHERE  " & vbNewLine & _
                   "    A.CompanyID=@CompanyID" & vbNewLine & _
                   "    AND A.ProgramID=@ProgramID" & vbNewLine & _
                   "    AND A.TransactionDate>=@DateFrom AND A.TransactionDate<=@DateTo " & vbNewLine

                If intCOAIDParent <> 0 Then
                    .CommandText += "    AND A.COAIDParent=@COAIDParent" & vbNewLine
                End If

                .CommandText += "ORDER BY A.TransactionDate, A.COAIDParent ASC " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@COAIDParent", SqlDbType.Int).Value = intCOAIDParent
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal clsData As VO.BukuBesar)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "INSERT INTO traBukuBesar " & vbNewLine & _
                    "    (CompanyID, ProgramID, ID, TransactionDate, ReferencesID, COAIDParent, COAIDChild, DebitAmount, CreditAmount,   " & vbNewLine & _
                    "     Remarks, CreatedBy, CreatedDate, ReferencesNo, BPID)   " & vbNewLine & _
                    "VALUES " & vbNewLine & _
                    "    (@CompanyID, @ProgramID, @ID, @TransactionDate, @ReferencesID, @COAIDParent, @COAIDChild, @DebitAmount, @CreditAmount,   " & vbNewLine & _
                    "     @Remarks, @LogBy, GETDATE(), @ReferencesNo, @BPID)  " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@TransactionDate", SqlDbType.DateTime).Value = clsData.TransactionDate
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = clsData.ReferencesID
                .Parameters.Add("@COAIDParent", SqlDbType.Int).Value = clsData.COAIDParent
                .Parameters.Add("@COAIDChild", SqlDbType.Int).Value = clsData.COAIDChild
                .Parameters.Add("@DebitAmount", SqlDbType.Decimal).Value = clsData.DebitAmount
                .Parameters.Add("@CreditAmount", SqlDbType.Decimal).Value = clsData.CreditAmount
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@ReferencesNo", SqlDbType.VarChar, 100).Value = clsData.ReferencesNo
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traBukuBesar " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataByRefrencesID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strReferencesID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traBukuBesar " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   ReferencesID=@ReferencesID " & vbNewLine

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                     ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM traBukuBesar " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "    CompanyID=@CompanyID" & vbNewLine & _
                    "    AND ProgramID=@ProgramID" & vbNewLine & _
                    "    AND TransactionDate>=@DateFrom AND TransactionDate<=@DateTo " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strID As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 1
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID=ISNULL(RIGHT(MAX(ID),5),0) " & vbNewLine & _
                        "FROM traBukuBesar " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   LEFT(ID,@Length)=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strID.Length).Value = strID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strID.Length
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
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Sub SwitchCompanyByReferencesID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal intCompanyID As Integer, ByVal strReferencesID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE traBukuBesar " & vbNewLine & _
                    "SET CompanyID=@CompanyID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   ReferencesID=@ReferencesID " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

    End Class

End Namespace

