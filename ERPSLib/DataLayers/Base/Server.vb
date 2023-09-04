Namespace DL
    Public Class Server
        Public Shared Function ServerList(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If VO.DefaultServer.ReportingServer = 0 Then
                    .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   Server, DBName, UserID, UserPassword " & vbNewLine & _
                    "FROM QMS_sysServerList " & vbNewLine & _
                    "WHERE IsActive = 1 " & vbNewLine & _
                    "GROUP BY " & vbNewLine & _
                    "   Server, DBName, UserID, UserPassword " & vbNewLine & _
                    "ORDER BY Server "
                Else
                    .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   ServerReport as Server, DBName, UserID, UserPassword " & vbNewLine & _
                    "FROM QMS_sysServerList " & vbNewLine & _
                    "WHERE IsActive = 1 " & vbNewLine & _
                    "AND ServerReport <> '' " & vbNewLine & _
                    "GROUP BY " & vbNewLine & _
                    "   ServerReport, DBName, UserID, UserPassword " & vbNewLine & _
                    "ORDER BY ServerReport "
                End If

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ServerCount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As Integer
            Dim intCount As Integer = 0
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    If VO.DefaultServer.ReportingServer = 0 Then
                        .CommandText = _
                        "SELECT COUNT(*) AS Total " & vbNewLine & _
                        "FROM " & vbNewLine & _
                        "   (SELECT Server, DBName " & vbNewLine & _
                        "   FROM QMS_sysServerList " & vbNewLine & _
                        "   GROUP BY Server, DBName) A "
                    Else
                        .CommandText = _
                        "SELECT COUNT(*) AS Total " & vbNewLine & _
                        "FROM " & vbNewLine & _
                        "   (SELECT ServerReport as Server, DBName " & vbNewLine & _
                        "   FROM QMS_sysServerList " & vbNewLine & _
                        "   WHERE IsActive = 1 " & vbNewLine & _
                        "   AND ServerReport <> '' " & vbNewLine & _
                        "   GROUP BY ServerReport, DBName) A "
                    End If
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intCount = .Item("Total")
                    End If
                    .Close()
                End With
            Catch ex As Exception
                Throw ex
            End Try
            Return intCount
        End Function

        Public Shared Function ServerAllCompanyList(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If VO.DefaultServer.ReportingServer = 0 Then
                    .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CompanyID, Server, DBName, UserID, UserPassword " & vbNewLine & _
                    "FROM QMS_sysServerList " & vbNewLine & _
                    "WHERE IsActive = 1 " & vbNewLine & _
                    "ORDER BY " & vbNewLine & _
                    "   CompanyID "
                Else
                    .CommandText = _
                    "SELECT " & vbNewLine & _
                    "   CompanyID, ServerReport as Server, DBName, UserID, UserPassword " & vbNewLine & _
                    "FROM QMS_sysServerList " & vbNewLine & _
                    "WHERE IsActive = 1 " & vbNewLine & _
                    "AND ServerReport <> '' " & vbNewLine & _
                    "ORDER BY " & vbNewLine & _
                    "   CompanyID "
                End If

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Function ServerByCompany(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strCompanyID As String) As VO.Server
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.Server
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    If VO.DefaultServer.ReportingServer = 0 Then
                        .CommandText = _
                        "SELECT TOP 1  " & vbNewLine & _
                        "   Server, DBName, UserID, UserPassword " & vbNewLine & _
                        "FROM QMS_sysServerList " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   CompanyID=@CompanyID "
                    Else
                        .CommandText = _
                        "SELECT TOP 1  " & vbNewLine & _
                        "   ServerReport as Server, DBName, UserID, UserPassword " & vbNewLine & _
                        "FROM QMS_sysServerList " & vbNewLine & _
                        "WHERE " & vbNewLine & _
                        "   CompanyID=@CompanyID "
                    End If

                    .Parameters.Add("@CompanyID", SqlDbType.VarChar, 10).Value = strCompanyID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.CompanyID = strCompanyID
                        clsReturn.Server = .Item("Server")
                        clsReturn.DBName = .Item("DBName")
                        clsReturn.UserID = .Item("UserID")
                        clsReturn.UserPassword = .Item("UserPassword")
                    End If
                    .Close()
                End With
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function
    End Class
End Namespace
