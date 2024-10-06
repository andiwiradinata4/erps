Namespace DL

    Public Class ItemResult

#Region "Main"

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal intItemID As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT " & vbNewLine & _
"	A.ProgramID, A.CompanyID, A.ID, A.ItemID, A.Name, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, " & vbNewLine & _
"	A.LogInc, A.StatusID, B.Name AS StatusInfo, A.Remarks " & vbNewLine & _
"FROM traItemResult A" & vbNewLine & _
"INNER JOIN mstStatus B ON " & vbNewLine & _
"   A.StatusID=B.ID " & vbNewLine & _
"WHERE " & vbNewLine & _
"	A.ProgramID=@ProgramID " & vbNewLine & _
"	AND A.CompanyID=@CompanyID " & vbNewLine & _
"	AND A.ItemID=@ItemID" & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.ItemResult)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText =
"INSERT INTO traItemResult" & vbNewLine & _
"	(ProgramID, CompanyID, ID, ItemID, Name, StatusID, CreatedBy, CreatedDate, LogBy, LogDate, Remarks)" & vbNewLine & _
"VALUES " & vbNewLine & _
"	(@ProgramID, @CompanyID, @ID, @ItemID, @Name, @StatusID, @LogBy, GETDATE(), @LogBy, GETDATE(), @Remarks)" & vbNewLine
                Else
                    .CommandText =
"UPDATE traItemResult SET " & vbNewLine & _
"	ProgramID=@ProgramID, " & vbNewLine & _
"	CompanyID=@CompanyID, " & vbNewLine & _
"	ItemID=@ItemID, " & vbNewLine & _
"	Name=@Name, " & vbNewLine & _
"	StatusID=@StatusID, " & vbNewLine & _
"	LogBy=@LogBy, " & vbNewLine & _
"	LogDate=GETDATE(), " & vbNewLine & _
"	LogInc=LogInc+1, " & vbNewLine & _
"	Remarks=@Remarks" & vbNewLine & _
"WHERE" & vbNewLine & _
"	ID=@ID" & vbNewLine
                End If

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@Name", SqlDbType.VarChar, 1000).Value = clsData.Name
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.ItemResult
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ItemResult
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
                    "SELECT TOP 1 " & vbNewLine & _
                    "	A.ProgramID, A.CompanyID, A.ID, A.ItemID, A.Name, A.StatusID, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, " & vbNewLine & _
                    "	A.LogInc, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, " & vbNewLine & _
                    "   D.ID AS ItemTypeID, D.Description AS ItemTypeName, A.Remarks " & vbNewLine & _
                    "FROM traItemResult A" & vbNewLine & _
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE" & vbNewLine & _
                    "	A.ID=@ID" & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.ID = .Item("ID")
                        voReturn.ItemID = .Item("ItemID")
                        voReturn.ItemCode = .Item("ItemCode")
                        voReturn.ItemName = .Item("ItemName")
                        voReturn.Thick = .Item("Thick")
                        voReturn.Width = .Item("Width")
                        voReturn.Length = .Item("Length")
                        voReturn.ItemSpecificationID = .Item("ItemSpecificationID")
                        voReturn.ItemSpecificationName = .Item("ItemSpecificationName")
                        voReturn.ItemTypeID = .Item("ItemTypeID")
                        voReturn.ItemTypeName = .Item("ItemTypeName")
                        voReturn.Name = .Item("Name")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
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
"UPDATE traItemResult SET " & vbNewLine & _
"   StatusID=@StatusID " & vbNewLine & _
"WHERE " & vbNewLine & _
"	ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.InActive
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strNewID As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 4),'0000') AS ID " & vbNewLine &
                        "FROM traItemResult " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY CreatedDate DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
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
                                          ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                          ByVal intItemID As Integer, ByVal strName As String,
                                          ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandText =
"SELECT TOP 1" & vbNewLine & _
"	ID" & vbNewLine & _
"FROM traItemResult" & vbNewLine & _
"WHERE " & vbNewLine & _
"	ProgramID=@ProgramID " & vbNewLine & _
"	AND CompanyID=@CompanyID " & vbNewLine & _
"	AND ItemID=@ItemID " & vbNewLine & _
"	AND Name=@Name " & vbNewLine & _
"	AND ID<>@ID" & vbNewLine

                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                    .Parameters.Add("@Name", SqlDbType.VarChar, 1000).Value = strName
                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
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

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strParentID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
                    "SELECT " & vbNewLine & _
                    "	A.ID, A.ItemID, B.ItemCode, B.ItemName, B.Thick, B.Width, B.Length, A.Multiple, " & vbNewLine & _
                    "   C.ID AS ItemSpecificationID, C.Description AS ItemSpecificationName, D.ID AS ItemTypeID, " & vbNewLine &
                    "   D.Description AS ItemTypeName, A.Remarks, B.Weight, TotalWeight=A.Multiple*B.Weight " & vbNewLine &
                    "FROM traItemResultDet A" & vbNewLine & _
                    "INNER JOIN mstItem B ON " & vbNewLine &
                    "   A.ItemID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification C ON " & vbNewLine &
                    "   B.ItemSpecificationID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemType D ON " & vbNewLine &
                    "   B.ItemTypeID=D.ID " & vbNewLine &
                    "WHERE " & vbNewLine & _
                    "	A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ItemResultDet)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"INSERT INTO traItemResultDet" & vbNewLine & _
"	(ID, ParentID, ItemID, Multiple, Remarks)" & vbNewLine & _
"VALUES " & vbNewLine & _
"	(@ID, @ParentID, @ItemID, @Multiple, @Remarks)" & vbNewLine


                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.BigInt).Value = clsData.ParentID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Multiple", SqlDbType.Decimal).Value = clsData.Multiple
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strParentID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"DELETE FROM traItemResultDet" & vbNewLine & _
"WHERE " & vbNewLine & _
"	ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ParentID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traItemResultStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal clsData As VO.ItemResultStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traItemResultStatus " & vbNewLine &
                    "   (ID, ParentID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@Status", SqlDbType.VarChar, 100).Value = clsData.Status
                .Parameters.Add("@StatusBy", SqlDbType.VarChar, 20).Value = clsData.StatusBy
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strParentID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traItemResultStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ParentID=@ParentID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
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

    End Class

End Namespace

