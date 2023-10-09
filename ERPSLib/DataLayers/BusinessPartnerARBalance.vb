Namespace DL
    Public Class BusinessPartnerARBalance

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "    A.CompanyID, MC.Name AS CompanyName, A.ProgramID, MP.Name AS ProgramName, " & vbNewLine & _
                   "    A.ID, A.BPID, A.InvoiceNumber, A.InvoiceDate, A.TotalDPP,   " & vbNewLine & _
                   "    A.TotalPPN, A.TotalPPH, A.TotalPaymentDP, A.TotalPayment  " & vbNewLine & _
                   "FROM mstBusinessPartnerARBalance A " & vbNewLine & _
                   "INNER JOIN mstCompany MC ON " & vbNewLine & _
                   "    A.CompanyID=MC.ID " & vbNewLine & _
                   "INNER JOIN mstProgram MP ON " & vbNewLine & _
                   "    A.ProgramID=MP.ID " & vbNewLine & _
                   "WHERE  " & vbNewLine & _
                   "    A.BPID=@BPID " & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                   ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "    CAST(0 AS BIT) AS Pick, A.ID AS SalesID, A.InvoiceNumber, A.InvoiceDate, " & vbNewLine & _
                   "    A.TotalDPP+A.TotalPPN-A.TotalPPH AS SalesAmount, CAST(0 AS DECIMAL(18,2)) AS Amount, " & vbNewLine & _
                   "    A.TotalDPP+A.TotalPPN-A.TotalPPH-A.TotalPaymentDP-A.TotalPayment AS MaxPaymentAmount, " & vbNewLine & _
                   "    CAST('' AS VARCHAR(500)) AS Remarks " & vbNewLine & _
                   "FROM mstBusinessPartnerARBalance A " & vbNewLine & _
                   "INNER JOIN mstCompany MC ON " & vbNewLine & _
                   "    A.CompanyID=MC.ID " & vbNewLine & _
                   "INNER JOIN mstProgram MP ON " & vbNewLine & _
                   "    A.ProgramID=MP.ID " & vbNewLine & _
                   "WHERE  " & vbNewLine & _
                   "    A.BPID=@BPID " & vbNewLine & _
                   "    AND A.CompanyID=@CompanyID " & vbNewLine & _
                   "    AND A.ProgramID=@ProgramID " & vbNewLine & _
                   "    AND A.TotalDPP+A.TotalPPN-A.TotalPPH-A.TotalPaymentDP-A.TotalPayment>0 " & vbNewLine

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.BusinessPartnerARBalance)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                       "INSERT INTO mstBusinessPartnerARBalance " & vbNewLine & _
                       "    (CompanyID, ProgramID, ID, BPID, InvoiceNumber, InvoiceDate, TotalDPP,   " & vbNewLine & _
                       "      TotalPPN, TotalPPH, TotalPaymentDP, TotalPayment)   " & vbNewLine & _
                       "VALUES " & vbNewLine & _
                       "    (@CompanyID, @ProgramID, @ID, @BPID, @InvoiceNumber, @InvoiceDate, @TotalDPP,   " & vbNewLine & _
                       "      @TotalPPN, @TotalPPH, @TotalPaymentDP, @TotalPayment)  " & vbNewLine
                Else
                    .CommandText = _
                    "UPDATE mstBusinessPartnerARBalance SET " & vbNewLine & _
                    "    CompanyID=@CompanyID, " & vbNewLine & _
                    "    ProgramID=@ProgramID, " & vbNewLine & _
                    "    BPID=@BPID, " & vbNewLine & _
                    "    InvoiceNumber=@InvoiceNumber, " & vbNewLine & _
                    "    InvoiceDate=@InvoiceDate, " & vbNewLine & _
                    "    TotalDPP=@TotalDPP, " & vbNewLine & _
                    "    TotalPPN=@TotalPPN, " & vbNewLine & _
                    "    TotalPPH=@TotalPPH, " & vbNewLine & _
                    "    TotalPaymentDP=@TotalPaymentDP, " & vbNewLine & _
                    "    TotalPayment=@TotalPayment " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@InvoiceNumber", SqlDbType.VarChar, 100).Value = clsData.InvoiceNumber
                .Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = clsData.InvoiceDate
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@TotalPaymentDP", SqlDbType.Decimal).Value = clsData.TotalPaymentDP
                .Parameters.Add("@TotalPayment", SqlDbType.Decimal).Value = clsData.TotalPayment
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String) As VO.BusinessPartnerARBalance
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.BusinessPartnerARBalance
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                       "SELECT TOP 1 " & vbNewLine & _
                       "    A.CompanyID, A.ProgramID, A.ID, A.BPID, A.InvoiceNumber, A.InvoiceDate, A.TotalDPP,   " & vbNewLine & _
                       "    A.TotalPPN, A.TotalPPH, A.TotalPaymentDP, A.TotalPayment  " & vbNewLine & _
                       "FROM mstBusinessPartnerARBalance A " & vbNewLine & _
                       "WHERE " & vbNewLine & _
                       "    ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlcon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.ID = .Item("ID")
                        voReturn.BPID = .Item("BPID")
                        voReturn.InvoiceNumber = .Item("InvoiceNumber")
                        voReturn.InvoiceDate = .Item("InvoiceDate")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.TotalPaymentDP = .Item("TotalPaymentDP")
                        voReturn.TotalPayment = .Item("TotalPayment")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If sqlrdData IsNot Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM mstBusinessPartnerARBalance " & vbNewLine & _
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

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal intBPID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE FROM mstBusinessPartnerARBalance " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "   BPID=@BPID " & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
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
                        "   ID=ISNULL(RIGHT(ID,3),'000') " & vbNewLine & _
                        "FROM mstBusinessPartnerARBalance " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   LEFT(ID,@Length)=@ID " & vbNewLine & _
                        "ORDER BY " & vbNewLine & _
                        "   ID DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strID.Length).Value = strID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlcon, sqlCmdExecute)
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

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID " & vbNewLine & _
                        "FROM mstBusinessPartnerARBalance " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlcon, sqlCmdExecute)
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

        Public Shared Sub CalculateTotalUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE mstBusinessPartnerARBalance SET 	" & vbNewLine & _
                    "	TotalPayment=	" & vbNewLine & _
                    "	(	" & vbNewLine & _
                    "		SELECT	" & vbNewLine & _
                    "			ISNULL(SUM(ARD.Amount),0) TotalPayment		" & vbNewLine & _
                    "		FROM traAccountReceivableDet ARD 	" & vbNewLine & _
                    "		INNER JOIN traAccountReceivable ARH ON	" & vbNewLine & _
                    "			ARD.ARID=ARH.ID 	" & vbNewLine & _
                    "			AND ARH.Modules=@Modules " & vbNewLine & _
                    "		WHERE 	" & vbNewLine & _
                    "			ARD.SalesID=@ID 	" & vbNewLine & _
                    "			AND ARH.IsDeleted=0 	" & vbNewLine & _
                    "	) " & vbNewLine & _
                    "WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@Modules", SqlDbType.VarChar, 250).Value = "SB"
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
End Namespace