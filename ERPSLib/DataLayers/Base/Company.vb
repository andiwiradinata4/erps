Namespace DL
    Public Class Company
        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "    A.ID AS CompanyID, A.Name AS CompanyName, A.Address, A.Country, A.Province, A.City, A.SubDistrict, A.Area, A.DirectorName, A.Warehouse, " & vbNewLine & _
                   "    A.PhoneNumber, A.CompanyInitial, A.StatusID, B.Name AS StatusInfo, A.CreatedBy,   " & vbNewLine & _
                   "    A.CreatedDate, A.LogBy, A.LogDate  " & vbNewLine & _
                   "FROM mstCompany A " & vbNewLine & _
                   "INNER JOIN mstStatus B ON " & vbNewLine & _
                   "    A.StatusID=B.ID " & vbNewLine

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function
        
        Public Shared Function ListDataForChooseDefault(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                   "SELECT " & vbNewLine & _
                   "    A.ID, A.Name, A.Address, A.Country, A.Province, A.City, A.SubDistrict, A.Area, A.DirectorName, A.Warehouse, A.PhoneNumber, A.CompanyInitial " & vbNewLine & _
                   "FROM mstCompany A " & vbNewLine & _
                   "WHERE " & vbNewLine & _
                   "    A.StatusID=@StatusID " & vbNewLine

                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Active
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.Company)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                       "INSERT INTO mstCompany " & vbNewLine & _
                       "    (ID, Name, Address, Country, Province, City, SubDistrict, Area, DirectorName, Warehouse, PhoneNumber, CompanyInitial, StatusID, CreatedBy,   " & vbNewLine & _
                       "      CreatedDate, LogBy, LogDate)   " & vbNewLine & _
                       "VALUES " & vbNewLine & _
                       "    (@ID, @Name, @Address, @Country, @Province, @City, @SubDistrict, @Area, @DirectorName, @Warehouse, @PhoneNumber, @CompanyInitial, @StatusID, @LogBy,   " & vbNewLine & _
                       "      GETDATE(), @LogBy, GETDATE())  " & vbNewLine
                Else
                    .CommandText = _
                        "UPDATE mstCompany SET " & vbNewLine & _
                        "    Name=@Name, " & vbNewLine & _
                        "    Address=@Address, " & vbNewLine & _
                        "    Country=@Country, " & vbNewLine & _
                        "    Province=@Province, " & vbNewLine & _
                        "    City=@City, " & vbNewLine & _
                        "    SubDistrict=@SubDistrict, " & vbNewLine & _
                        "    Area=@Area, " & vbNewLine & _
                        "    DirectorName=@DirectorName, " & vbNewLine & _
                        "    Warehouse=@Warehouse, " & vbNewLine & _
                        "    PhoneNumber=@PhoneNumber, " & vbNewLine & _
                        "    CompanyInitial=@CompanyInitial, " & vbNewLine & _
                        "    StatusID=@StatusID, " & vbNewLine & _
                        "    LogInc=LogInc+1, " & vbNewLine & _
                        "    LogBy=@LogBy, " & vbNewLine & _
                        "    LogDate=GETDATE() " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = clsData.Name
                .Parameters.Add("@Address", SqlDbType.VarChar, 250).Value = clsData.Address
                .Parameters.Add("@Country", SqlDbType.VarChar, 250).Value = clsData.Country
                .Parameters.Add("@Province", SqlDbType.VarChar, 250).Value = clsData.Province
                .Parameters.Add("@City", SqlDbType.VarChar, 250).Value = clsData.City
                .Parameters.Add("@SubDistrict", SqlDbType.VarChar, 250).Value = clsData.SubDistrict
                .Parameters.Add("@Area", SqlDbType.VarChar, 250).Value = clsData.Area
                .Parameters.Add("@DirectorName", SqlDbType.VarChar, 250).Value = clsData.DirectorName
                .Parameters.Add("@Warehouse", SqlDbType.VarChar, 250).Value = clsData.Warehouse
                .Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 250).Value = clsData.PhoneNumber
                .Parameters.Add("@CompanyInitial", SqlDbType.VarChar, 3).Value = clsData.CompanyInitial
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As VO.Company
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.Company
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                       "SELECT TOP 1 " & vbNewLine & _
                       "    A.ID, A.Name, A.Address, A.Country, A.Province, A.City, A.SubDistrict, A.Area, A.DirectorName, A.Warehouse, A.PhoneNumber, A.CompanyInitial, A.StatusID, A.LogBy,   " & vbNewLine & _
                       "    A.LogDate  " & vbNewLine & _
                       "FROM mstCompany A " & vbNewLine & _
                       "WHERE " & vbNewLine & _
                       "    ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.Name = .Item("Name")
                        voReturn.Address = .Item("Address")
                        voReturn.Country = .Item("Country")
                        voReturn.Province = .Item("Province")
                        voReturn.City = .Item("City")
                        voReturn.SubDistrict = .Item("SubDistrict")
                        voReturn.Area = .Item("Area")
                        voReturn.DirectorName = .Item("DirectorName")
                        voReturn.Warehouse = .Item("Warehouse")
                        voReturn.PhoneNumber = .Item("PhoneNumber")
                        voReturn.CompanyInitial = .Item("CompanyInitial")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE mstCompany " & vbNewLine & _
                    "SET StatusID=@StatusID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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

        Public Shared Sub DeleteDataAll(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "DELETE mstCompany " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine & _
                        "FROM mstCompany " & vbNewLine
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

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As Boolean
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
                        "FROM mstCompany " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
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

        Public Shared Function InitialExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strCompanyInitial As String, ByVal intID As Integer) As Boolean
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
                        "FROM mstCompany " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   CompanyInitial=@CompanyInitial " & vbNewLine & _
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@CompanyInitial", SqlDbType.VarChar, 3).Value = strCompanyInitial
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

        Public Shared Function GetStatusID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = VO.Status.Values.Active
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   StatusID " & vbNewLine & _
                        "FROM mstCompany " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
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

    End Class

End Namespace

