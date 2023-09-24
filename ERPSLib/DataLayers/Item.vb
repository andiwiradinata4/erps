Namespace DL
    Public Class Item
        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intItemTypeID As Integer, ByVal intItemSpecificationID As Integer,
                                        ByVal bolShowAll As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   ComboID=CAST(A.ID AS VARCHAR(100)), A.ID, A.ItemCode, A.ItemName, " & vbNewLine & _
                    "   A.ItemTypeID, C.Description AS ItemTypeName, A.ItemSpecificationID, D.Description AS ItemSpecificationName, " & vbNewLine & _
                    "   A.Thick, A.Width, A.Length, A.Weight, A.BasePrice, A.StatusID, B.Name AS StatusInfo, " & vbNewLine & _
                    "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine & _
                    "FROM mstItem A " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "   A.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstItemType C ON " & vbNewLine & _
                    "   A.ItemTypeID=C.ID " & vbNewLine & _
                    "INNER JOIN mstItemSpecification D ON " & vbNewLine & _
                    "   A.ItemSpecificationID=D.ID " & vbNewLine & _
                    "WHERE 1=1" & vbNewLine

                If Not bolShowAll Then
                    If intItemTypeID > 0 Then
                        .CommandText += "   AND A.ItemTypeID=@ItemTypeID "
                        .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = intItemTypeID
                    End If

                    If intItemSpecificationID > 0 Then
                        .CommandText += "   AND A.ItemSpecificationID=@ItemSpecificationID "
                        .Parameters.Add("@ItemSpecificationID", SqlDbType.Int).Value = intItemSpecificationID
                    End If
                End If

            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal bolNew As Boolean, ByVal clsData As VO.Item)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO mstItem " & vbNewLine & _
                        "     (ID, ItemCode, ItemName, ItemTypeID, ItemSpecificationID, Thick, Width, Length, Weight, BasePrice, StatusID, Remarks, CreatedBy, CreatedDate, LogBy, LogDate) " & vbNewLine & _
                        "VALUES " & vbNewLine & _
                        "     (@ID, @ItemCode, @ItemName, @ItemTypeID, @ItemSpecificationID, @Thick, @Width, @Length, @Weight, @BasePrice, @StatusID, @Remarks, @LogBy, GETDATE(), @LogBy, GETDATE()) " & vbNewLine

                Else
                    .CommandText = _
                        "UPDATE mstItem SET " & vbNewLine & _
                        "    ItemCode=@ItemCode, " & vbNewLine & _
                        "    ItemName=@ItemName, " & vbNewLine & _
                        "    ItemTypeID=@ItemTypeID, " & vbNewLine & _
                        "    ItemSpecificationID=@ItemSpecificationID, " & vbNewLine & _
                        "    Thick=@Thick, " & vbNewLine & _
                        "    Width=@Width, " & vbNewLine & _
                        "    Length=@Length, " & vbNewLine & _
                        "    Weight=@Weight, " & vbNewLine & _
                        "    BasePrice=@BasePrice, " & vbNewLine & _
                        "    StatusID=@StatusID, " & vbNewLine & _
                        "    Remarks=@Remarks, " & vbNewLine & _
                        "    LogBy=@LogBy, " & vbNewLine & _
                        "    LogDate=GETDATE(), " & vbNewLine & _
                        "    LogInc=LogInc+1 " & vbNewLine & _
                        "WHERE   " & vbNewLine & _
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@ItemCode", SqlDbType.VarChar, 100).Value = clsData.ItemCode
                .Parameters.Add("@ItemName", SqlDbType.VarChar, 500).Value = clsData.ItemName
                .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = clsData.ItemTypeID
                .Parameters.Add("@ItemSpecificationID", SqlDbType.Int).Value = clsData.ItemSpecificationID
                .Parameters.Add("@Thick", SqlDbType.Decimal).Value = clsData.Thick
                .Parameters.Add("@Width", SqlDbType.Decimal).Value = clsData.Width
                .Parameters.Add("@Length", SqlDbType.Decimal).Value = clsData.Length
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@BasePrice", SqlDbType.Decimal).Value = clsData.BasePrice
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = clsData.Remarks
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal intID As Integer) As VO.Item
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.Item
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   A.ID, A.ItemCode, A.ItemName, A.ItemTypeID, A.ItemSpecificationID, " & vbNewLine & _
                        "   A.Thick, A.Width, A.Length, A.Weight, A.BasePrice, A.StatusID, " & vbNewLine & _
                        "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc " & vbNewLine & _
                        "FROM mstItem A " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ItemCode = .Item("ItemCode")
                        voReturn.ItemName = .Item("ItemName")
                        voReturn.ItemTypeID = .Item("ItemTypeID")
                        voReturn.ItemSpecificationID = .Item("ItemSpecificationID")
                        voReturn.Thick = .Item("Thick")
                        voReturn.Width = .Item("Width")
                        voReturn.Length = .Item("Length")
                        voReturn.Weight = .Item("Weight")
                        voReturn.BasePrice = .Item("BasePrice")
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

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal intID As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "UPDATE mstItem " & vbNewLine & _
                    "SET StatusID=@StatusID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
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
                .CommandText = _
                    "DELETE mstItem " & vbNewLine

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 1
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID=ISNULL(MAX(ID),0) " & vbNewLine & _
                        "FROM mstItem " & vbNewLine
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

        Public Shared Function GetMaxItemCode(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strNewItemCode As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 1
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText = _
                        "SELECT TOP 1 " & vbNewLine & _
                        "   ID=ISNULL(RIGHT(ItemCode,7),'0000000') " & vbNewLine & _
                        "FROM mstItem " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   LEFT(ItemCode,@Length)=@ItemCode " & vbNewLine & _
                        "ORDER BY " & vbNewLine & _
                        "   ItemCode DESC " & vbNewLine

                    .Parameters.Add("@ItemCode", SqlDbType.VarChar, strNewItemCode.Length).Value = strNewItemCode
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewItemCode.Length
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

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal intItemTypeID As Integer, ByVal intItemSpecificationID As Integer,
                                          ByVal strThick As String, ByVal strWidth As String, ByVal strLength As String,
                                          ByVal intID As Integer) As Boolean
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
                        "FROM mstItem " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
                        "   ItemTypeID=@ItemTypeID " & vbNewLine & _
                        "   AND ItemSpecificationID=@ItemSpecificationID " & vbNewLine & _
                        "   AND Thick=@Thick " & vbNewLine & _
                        "   AND Width=@Width " & vbNewLine & _
                        "   AND Length=@Length " & vbNewLine & _
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = intItemTypeID
                    .Parameters.Add("@ItemSpecificationID", SqlDbType.Int).Value = intItemSpecificationID
                    .Parameters.Add("@Thick", SqlDbType.VarChar, 100).Value = strThick
                    .Parameters.Add("@Width", SqlDbType.VarChar, 100).Value = strWidth
                    .Parameters.Add("@Length", SqlDbType.VarChar, 100).Value = strLength
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
                        "FROM mstItem " & vbNewLine & _
                        "WHERE  " & vbNewLine & _
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

    End Class

End Namespace
