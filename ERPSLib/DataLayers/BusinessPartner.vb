Namespace DL
    Public Class BusinessPartner

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, A.ID, A.Code, A.Name, A.Address, A.PICName, A.PICPhoneNumber, A.Initial, A.APBalance, A.ARBalance, " & vbNewLine &
                    "   A.StatusID, B.Name AS StatusInfo, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc, " & vbNewLine &
                    "   A.CoAIDofStock, ISNULL(COA.Code,'') AS CoACodeofStock, ISNULL(COA.Name,'') AS CoANameofStock, A.NPWP,  " & vbNewLine &
                    "   A.PPN, A.IsFreePPN, A.PPH, A.IsFreePPH  " & vbNewLine &
                    "FROM mstBusinessPartner A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "   A.CoAIDofStock=COA.ID " & vbNewLine

            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.BusinessPartner)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO mstBusinessPartner " & vbNewLine &
                        "     (ID, Code, Name, Address, PICName, PICPhoneNumber, APBalance, ARBalance, Remarks, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, Initial, CoAIDofStock, NPWP, PPN, IsFreePPN, PPH, IsFreePPH) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "     (@ID, @Code, @Name, @Address, @PICName, @PICPhoneNumber, @APBalance, @ARBalance, @Remarks, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), @Initial, @CoAIDofStock, @NPWP, @PPN, @IsFreePPN, @PPH, @IsFreePPH) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE mstBusinessPartner SET " & vbNewLine &
                        "    Code=@Code, " & vbNewLine &
                        "    Name=@Name, " & vbNewLine &
                        "    Address=@Address, " & vbNewLine &
                        "    PICName=@PICName, " & vbNewLine &
                        "    PICPhoneNumber=@PICPhoneNumber, " & vbNewLine &
                        "    APBalance=@APBalance, " & vbNewLine &
                        "    ARBalance=@ARBalance, " & vbNewLine &
                        "    StatusID=@StatusID, " & vbNewLine &
                        "    Remarks=@Remarks, " & vbNewLine &
                        "    LogBy=@LogBy, " & vbNewLine &
                        "    LogDate=GETDATE(), " & vbNewLine &
                        "    LogInc=LogInc+1, " & vbNewLine &
                        "    Initial=@Initial, " & vbNewLine &
                        "    CoAIDofStock=@CoAIDofStock, " & vbNewLine &
                        "    NPWP=@NPWP, " & vbNewLine &
                        "    PPN=@PPN, " & vbNewLine &
                        "    IsFreePPN=@IsFreePPN, " & vbNewLine &
                        "    PPH=@PPH, " & vbNewLine &
                        "    IsFreePPH=@IsFreePPH " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = clsData.Code
                .Parameters.Add("@Name", SqlDbType.VarChar, 250).Value = clsData.Name
                .Parameters.Add("@Address", SqlDbType.VarChar, 500).Value = clsData.Address
                .Parameters.Add("@PICName", SqlDbType.VarChar, 150).Value = clsData.PICName
                .Parameters.Add("@PICPhoneNumber", SqlDbType.VarChar, 100).Value = clsData.PICPhoneNumber
                .Parameters.Add("@APBalance", SqlDbType.Decimal).Value = clsData.APBalance
                .Parameters.Add("@ARBalance", SqlDbType.Decimal).Value = clsData.ARBalance
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@Initial", SqlDbType.VarChar, 150).Value = clsData.Initial
                .Parameters.Add("@CoAIDofStock", SqlDbType.Int).Value = clsData.CoAIDofStock
                .Parameters.Add("@NPWP", SqlDbType.VarChar, 100).Value = clsData.NPWP
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@IsFreePPN", SqlDbType.Bit).Value = clsData.IsFreePPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@IsFreePPH", SqlDbType.Bit).Value = clsData.IsFreePPH
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal intID As Integer) As VO.BusinessPartner
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.BusinessPartner
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.Code, A.Name, A.Address, A.PICName, A.PICPhoneNumber, " & vbNewLine &
                        "   A.APBalance, A.ARBalance, A.StatusID, A.Remarks, A.CreatedBy, A.CreatedDate, " & vbNewLine &
                        "   A.LogBy, A.LogDate, A.LogInc, A.JournalIDForARBalance, A.JournalIDForAPBalance, A.Initial, A.CoAIDofStock, ISNULL(COA.Code,'') AS CoACodeofStock, " & vbNewLine &
                        "   ISNULL(COA.Name,'') AS CoANameofStock, A.NPWP, A.PPN, A.IsFreePPN, A.PPH, A.IsFreePPH   " & vbNewLine &
                        "FROM mstBusinessPartner A " & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "   A.CoAIDofStock=COA.ID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   A.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.Code = .Item("Code")
                        voReturn.Name = .Item("Name")
                        voReturn.Address = .Item("Address")
                        voReturn.PICName = .Item("PICName")
                        voReturn.PICPhoneNumber = .Item("PICPhoneNumber")
                        voReturn.APBalance = .Item("APBalance")
                        voReturn.ARBalance = .Item("ARBalance")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.JournalIDForARBalance = .Item("JournalIDForARBalance")
                        voReturn.JournalIDForAPBalance = .Item("JournalIDForAPBalance")
                        voReturn.Initial = .Item("Initial")
                        voReturn.CoAIDofStock = .Item("CoAIDofStock")
                        voReturn.CoACodeofStock = .Item("CoACodeofStock")
                        voReturn.CoANameofStock = .Item("CoANameofStock")
                        voReturn.NPWP = .Item("NPWP")
                        voReturn.PPN = .Item("PPN")
                        voReturn.IsFreePPN = .Item("IsFreePPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.IsFreePPH = .Item("IsFreePPH")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal intID As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE mstBusinessPartner " & vbNewLine &
                    "SET StatusID=@StatusID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.InActive
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE mstBusinessPartner " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine &
                        "FROM mstBusinessPartner " & vbNewLine
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
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

        Public Shared Function GetMaxBPCode(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strNewCode As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 1
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID=ISNULL(RIGHT(Code,7),'0000000') " & vbNewLine &
                        "FROM mstBusinessPartner " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(Code,@Length)=@Code " & vbNewLine &
                        "ORDER BY " & vbNewLine &
                        "   Code DESC " & vbNewLine

                    .Parameters.Add("@Code", SqlDbType.VarChar, strNewCode.Length).Value = strNewCode
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewCode.Length
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

        Public Shared Function DataExistsName(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strName As String, ByVal intID As Integer) As Boolean
            Dim bolDataExists As Boolean = False
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM mstBusinessPartner " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   Name=@Name " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@Name", SqlDbType.VarChar, 250).Value = strName
                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolDataExists = True
                    Else
                        bolDataExists = False
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolDataExists
        End Function

        Public Shared Function GetStatusID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = VO.Status.Values.Active
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   StatusID " & vbNewLine &
                        "FROM mstBusinessPartner " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("StatusID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Sub UpdateJournalIDForARBalance(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal intID As Integer, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE mstBusinessPartner " & vbNewLine &
                    "SET JournalIDForARBalance=@JournalID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.InActive
                .Parameters.Add("@JournalID", SqlDbType.VarChar, 100).Value = strJournalID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateJournalIDForAPBalance(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal intID As Integer, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE mstBusinessPartner " & vbNewLine &
                    "SET JournalIDForAPBalance=@JournalID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.InActive
                .Parameters.Add("@JournalID", SqlDbType.VarChar, 100).Value = strJournalID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Bank Account"

        Public Shared Function ListDataBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal intBPID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "     A.ID, A.BPID, A.AccountName, A.BankName, A.AccountNumber, A.Currency, A.StatusID, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine &
                    "FROM mstBusinessPartnerBankAccount A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "    BPID=@BPID " & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal bolNew As Boolean, ByVal clsData As VO.BusinessPartnerBankAccount)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                        "INSERT INTO mstBusinessPartnerBankAccount " & vbNewLine &
                        "     (ID, BPID, AccountName, BankName, AccountNumber, Currency, StatusID, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "     (@ID, @BPID, @AccountName, @BankName, @AccountNumber, @Currency, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine
                Else
                    .CommandText =
                        "UPDATE mstBusinessPartnerBankAccount SET " & vbNewLine &
                        "    BPID=@BPID, " & vbNewLine &
                        "    AccountName=@AccountName, " & vbNewLine &
                        "    BankName=@BankName, " & vbNewLine &
                        "    AccountNumber=@AccountNumber, " & vbNewLine &
                        "    Currency=@Currency, " & vbNewLine &
                        "    StatusID=@StatusID, " & vbNewLine &
                        "    Remarks=@Remarks, " & vbNewLine &
                        "    LogBy=@LogBy, " & vbNewLine &
                        "    LogDate=GETDATE(), " & vbNewLine &
                        "    LogInc=LogInc+1 " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@AccountName", SqlDbType.VarChar, 250).Value = clsData.AccountName
                .Parameters.Add("@BankName", SqlDbType.VarChar, 500).Value = clsData.BankName
                .Parameters.Add("@AccountNumber", SqlDbType.VarChar, 150).Value = clsData.AccountNumber
                .Parameters.Add("@Currency", SqlDbType.VarChar, 100).Value = clsData.Currency
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetailBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As VO.BusinessPartnerBankAccount
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.BusinessPartnerBankAccount
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "     A.ID, A.BPID, A.AccountName, A.BankName, A.AccountNumber, A.Currency, A.StatusID, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine &
                        "FROM mstBusinessPartnerBankAccount A " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.BPID = .Item("BPID")
                        voReturn.AccountName = .Item("AccountName")
                        voReturn.BankName = .Item("BankName")
                        voReturn.AccountNumber = .Item("AccountNumber")
                        voReturn.Currency = .Item("Currency")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteDataBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal intID As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE mstBusinessPartnerBankAccount " & vbNewLine &
                    "SET StatusID=@StatusID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.InActive
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine &
                        "FROM mstBusinessPartnerBankAccount " & vbNewLine
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
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

        Public Shared Function DataExistsBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                     ByVal strBankName As String, ByVal strAccountNumber As String,
                                                     ByVal intID As Integer) As Boolean
            Dim bolExists As Boolean = False
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM mstBusinessPartnerBankAccount " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   BankName=@BankName " & vbNewLine &
                        "   AND AccountNumber=@AccountNumber " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@BankName", SqlDbType.VarChar, 500).Value = strBankName
                    .Parameters.Add("@AccountNumber", SqlDbType.VarChar, 150).Value = strAccountNumber
                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolExists = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolExists
        End Function

        Public Shared Function GetStatusIDBankAccount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = VO.Status.Values.Active
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   StatusID " & vbNewLine &
                        "FROM mstBusinessPartnerBankAccount " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("StatusID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

#End Region

#Region "Assign"

        Public Shared Function ListDataAssign(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                   "SELECT " & vbNewLine &
                   "    CAST(A.ID AS VARCHAR(30)) AS ID, A.BPID, A.ProgramID, MP.Name AS ProgramName, " & vbNewLine &
                   "    A.CompanyID, MC.Name AS CompanyName, A.FirstBalance, A.FirstBalanceDate  " & vbNewLine &
                   "FROM mstBusinessPartnerAssign A " & vbNewLine &
                   "INNER JOIN mstProgram MP ON " & vbNewLine &
                   "    A.ProgramID=MP.ID " & vbNewLine &
                   "INNER JOIN mstCompany MC ON " & vbNewLine &
                   "    A.CompanyID=MC.ID " & vbNewLine &
                   "WHERE  " & vbNewLine &
                   "    A.BPID=@BPID" & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataAssign(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.BusinessPartnerAssign)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO mstBusinessPartnerAssign " & vbNewLine &
                    "    (ID, BPID, ProgramID, CompanyID, FirstBalance, FirstBalanceDate)   " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "    (@ID, @BPID, @ProgramID, @CompanyID, @FirstBalance, @FirstBalanceDate)  " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@FirstBalance", SqlDbType.Decimal).Value = clsData.FirstBalance
                .Parameters.Add("@FirstBalanceDate", SqlDbType.DateTime).Value = clsData.FirstBalanceDate
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataAssign(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal intBPID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE FROM mstBusinessPartnerAssign " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   BPID=@BPID " & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataAllAssign(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE mstBusinessPartnerAssign " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDAssign(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 1
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine &
                        "FROM mstBusinessPartnerAssign " & vbNewLine
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

        Public Shared Function DataExistsAssign(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal intID As Integer) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM mstBusinessPartnerAssign " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
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
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolExists
        End Function

#End Region

#Region "Location"

        Public Shared Function ListDataLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal intBPID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                   "SELECT " & vbNewLine &
                   "    A.ID, A.BPID, A.Address, A.IsDefault, A.StatusID, B.Name AS StatusInfo, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine &
                   "FROM mstBusinessPartnerLocation A " & vbNewLine &
                   "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                   "WHERE  " & vbNewLine &
                   "    A.BPID=@BPID" & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal bolNew As Boolean, ByVal clsData As VO.BusinessPartnerLocation)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                    "INSERT INTO mstBusinessPartnerLocation " & vbNewLine &
                    "    (ID, BPID, Address, IsDefault, StatusID, Remarks, LogBy, CreatedBy)   " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "    (@ID, @BPID, @Address, @IsDefault, @StatusID, @Remarks, @LogBy, @LogBy)  " & vbNewLine

                Else
                    .CommandText =
                    "UPDATE mstBusinessPartnerLocation SET " & vbNewLine &
                    "    Address=@Address," & vbNewLine &
                    "    IsDefault=@IsDefault," & vbNewLine &
                    "    StatusID=@StatusID," & vbNewLine &
                    "    Remarks=@Remarks," & vbNewLine &
                    "    LogBy=@LogBy," & vbNewLine &
                    "    LogInc=LogInc+1," & vbNewLine &
                    "    LogDate=GETDATE() " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@BPID", SqlDbType.Int).Value = clsData.BPID
                .Parameters.Add("@Address", SqlDbType.VarChar, 2000).Value = clsData.Address
                .Parameters.Add("@IsDefault", SqlDbType.Bit).Value = clsData.IsDefault
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal intID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE mstBusinessPartnerLocation SET " & vbNewLine &
                    "   StatusID=@StatusID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.InActive
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataAllLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE mstBusinessPartnerLocation " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 1
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine &
                        "FROM mstBusinessPartnerLocation " & vbNewLine
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

        Public Shared Function GetDetailLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal intID As Integer) As VO.BusinessPartnerLocation
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.BusinessPartnerLocation
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "     A.ID, A.BPID, A.Address, A.IsDefault, A.StatusID, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine &
                        "FROM mstBusinessPartnerLocation A " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "    ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.BPID = .Item("BPID")
                        voReturn.Address = .Item("Address")
                        voReturn.IsDefault = .Item("IsDefault")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Function GetDetailLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal intBPID As Integer, ByVal bolIsDefault As Boolean) As VO.BusinessPartnerLocation
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.BusinessPartnerLocation
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "     A.ID, A.BPID, A.Address, A.IsDefault, A.StatusID, A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine &
                        "FROM mstBusinessPartnerLocation A " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "    BPID=@BPID " & vbNewLine &
                        "    AND IsDefault=1 " & vbNewLine

                    .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.BPID = .Item("BPID")
                        voReturn.Address = .Item("Address")
                        voReturn.IsDefault = .Item("IsDefault")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Function DataExistsLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal intID As Integer) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ID " & vbNewLine &
                        "FROM mstBusinessPartnerLocation " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
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
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolExists
        End Function

        Public Shared Sub RevertIsDefaultLocation(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal intBPID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE mstBusinessPartnerLocation SET " & vbNewLine &
                    "   IsDefault=0 " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   BPID=@BPID " & vbNewLine &
                    "   AND IsDefault=1 " & vbNewLine

                .Parameters.Add("@BPID", SqlDbType.Int).Value = intBPID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

#End Region

    End Class

End Namespace
