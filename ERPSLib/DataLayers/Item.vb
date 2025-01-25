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
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, ComboID=CAST(A.ID AS VARCHAR(100)), A.ID, A.ItemCode, A.ItemCodeExternal, A.ItemName, " & vbNewLine &
                    "   A.ItemTypeID, C.Description AS ItemTypeName, A.ItemSpecificationID, D.Description AS ItemSpecificationName, " & vbNewLine &
                    "   A.Thick, A.Width, A.Length, A.Weight, A.BasePrice, A.StatusID, B.Name AS StatusInfo, " & vbNewLine &
                    "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc, A.RefID " & vbNewLine &
                    "FROM mstItem A " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "   A.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstItemType C ON " & vbNewLine &
                    "   A.ItemTypeID=C.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification D ON " & vbNewLine &
                    "   A.ItemSpecificationID=D.ID " & vbNewLine &
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
                    .CommandText =
                        "INSERT INTO mstItem " & vbNewLine &
                        "     (ID, ItemCode, ItemCodeExternal, ItemName, ItemTypeID, ItemSpecificationID, Thick, Width, Length, Weight, BasePrice, StatusID, Remarks, CreatedBy, CreatedDate, LogBy, LogDate, UomID, LengthInitial, RefID) " & vbNewLine &
                        "VALUES " & vbNewLine &
                        "     (@ID, @ItemCode, @ItemCodeExternal, @ItemName, @ItemTypeID, @ItemSpecificationID, @Thick, @Width, @Length, @Weight, @BasePrice, @StatusID, @Remarks, @LogBy, GETDATE(), @LogBy, GETDATE(), @UomID, @LengthInitial, @RefID) " & vbNewLine

                Else
                    .CommandText =
                        "UPDATE mstItem SET " & vbNewLine &
                        "    ItemCode=@ItemCode, " & vbNewLine &
                        "    ItemCodeExternal=@ItemCodeExternal, " & vbNewLine &
                        "    ItemName=@ItemName, " & vbNewLine &
                        "    ItemTypeID=@ItemTypeID, " & vbNewLine &
                        "    ItemSpecificationID=@ItemSpecificationID, " & vbNewLine &
                        "    Thick=@Thick, " & vbNewLine &
                        "    Width=@Width, " & vbNewLine &
                        "    Length=@Length, " & vbNewLine &
                        "    Weight=@Weight, " & vbNewLine &
                        "    BasePrice=@BasePrice, " & vbNewLine &
                        "    StatusID=@StatusID, " & vbNewLine &
                        "    Remarks=@Remarks, " & vbNewLine &
                        "    LogBy=@LogBy, " & vbNewLine &
                        "    LogDate=GETDATE(), " & vbNewLine &
                        "    LogInc=LogInc+1, " & vbNewLine &
                        "    UomID=@UomID, " & vbNewLine &
                        "    LengthInitial=@LengthInitial " & vbNewLine &
                        "WHERE   " & vbNewLine &
                        "    ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.Int).Value = clsData.ID
                .Parameters.Add("@ItemCode", SqlDbType.VarChar, 100).Value = clsData.ItemCode
                .Parameters.Add("@ItemCodeExternal", SqlDbType.VarChar, 150).Value = clsData.ItemCodeExternal
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
                .Parameters.Add("@UomID", SqlDbType.Int).Value = clsData.UOMID
                .Parameters.Add("@LengthInitial", SqlDbType.VarChar, 100).Value = clsData.LengthInitial
                .Parameters.Add("@RefID", SqlDbType.Int).Value = clsData.RefID
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
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   A.ID, A.ItemCode, A.ItemCodeExternal, A.ItemName, A.ItemTypeID, A.ItemSpecificationID, " & vbNewLine &
                        "   A.Thick, A.Width, A.Length, A.Weight, A.BasePrice, A.StatusID, " & vbNewLine &
                        "   A.Remarks, A.CreatedBy, A.CreatedDate, A.LogBy, A.LogDate, A.LogInc, A.UomID, A.LengthInitial, A.RefID " & vbNewLine &
                        "FROM mstItem A " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   A.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.Int).Value = intID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ItemCode = .Item("ItemCode")
                        voReturn.ItemCodeExternal = .Item("ItemCodeExternal")
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
                        voReturn.UOMID = .Item("UomID")
                        voReturn.LengthInitial = .Item("LengthInitial")
                        voReturn.RefID = .Item("RefID")
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
                                          ByVal intID As Integer, ByVal strItemCodeExternal As String) As Boolean
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
                        "FROM mstItem " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ItemTypeID=@ItemTypeID " & vbNewLine &
                        "   AND ItemSpecificationID=@ItemSpecificationID " & vbNewLine &
                        "   AND Thick=@Thick " & vbNewLine &
                        "   AND Width=@Width " & vbNewLine &
                        "   AND Length=@Length " & vbNewLine &
                        "   AND ItemCodeExternal=@ItemCodeExternal " & vbNewLine &
                        "   AND ID<>@ID " & vbNewLine

                    .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = intItemTypeID
                    .Parameters.Add("@ItemSpecificationID", SqlDbType.Int).Value = intItemSpecificationID
                    .Parameters.Add("@Thick", SqlDbType.VarChar, 100).Value = strThick
                    .Parameters.Add("@Width", SqlDbType.VarChar, 100).Value = strWidth
                    .Parameters.Add("@Length", SqlDbType.VarChar, 100).Value = strLength
                    .Parameters.Add("@ItemCodeExternal", SqlDbType.VarChar, 150).Value = strItemCodeExternal
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
