Namespace DL

    Friend Class SQL

        Protected Friend Shared sqlConn As SqlConnection
        Protected Friend Shared sqlTrans As SqlTransaction
        Protected Friend Shared strServer, strDatabase As String
        Protected Friend Shared strSAID As String = "", strSAPassword As String = ""
        Protected Friend Shared bolUseTrans As Boolean = False
        Protected Friend Shared strAplicationName As String = "ERPS"

        Public Shared Function GenerateCustomErrorMessage(strServername As String, strErrMessage As String) As String
            Return ("SERVER [" & strServername & "]" & vbCrLf & strErrMessage)
        End Function

        Public Shared Sub CheckingAppVersion(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim voAppVersion As VO.AppVersion = DL.AppVersion.GetDetail(sqlCon, sqlTrans)
            If ERPSLib.UI.usUserApp.AppVersion.Trim <> voAppVersion.Version.Trim Then
                Throw New Exception("Versi Program Anda tidak valid." & vbCrLf & "Pastikan Versi program Anda " & voAppVersion.Version.Trim & "." & vbCrLf & "Tutup dan masuk kembali program Anda untuk menggunakan versi terbaru")
            End If
        End Sub

#Region "Using Shared Connection"

        <System.Diagnostics.DebuggerStepThrough()>
        Protected Friend Shared Function CreateConnectionString() As String
            Dim strSqlConnect As String =
                "Server=" & strServer & ";" &
                "DataBase=" & strDatabase & ";" &
                "Application Name=" & strAplicationName & ";"

            If strServer.Trim.ToUpper = "LOCALHOST" Then
                strSqlConnect += "Trusted_Connection=SSPI;"
            Else
                strSqlConnect += "Trusted_Connection=FALSE;" & _
                    "User Id=" & ERPSLib.UI.usUserApp.UserID & ";" & _
                    "Password=" & strSAPassword & ";"

                '"User Id=" & MPSLib.UI.usUserApp.UserID & ";" & _
                '"User Id=" & strSAID & ";" & _

            End If
            'If strSAID = "" Then
            '    strSqlConnect += "Trusted_Connection=SSPI;"
            'Else
            '    strSqlConnect += "Trusted_Connection=FALSE;" &
            '                     "User Id=" & strSAID & ";" &
            '                     "Password=" & strSAPassword & ";"
            'End If

            Return strSqlConnect
        End Function

        <System.Diagnostics.DebuggerStepThrough()>
        Protected Friend Shared Function OpenConnection() As SqlConnection
            Dim connectionString As String = CreateConnectionString()
            Return OpenConnection(connectionString)
        End Function

        <System.Diagnostics.DebuggerStepThrough()>
        Protected Friend Shared Function OpenConnection(ByVal connectionString As String) As SqlConnection
            Dim sqlCon As New SqlConnection With {
                .ConnectionString = connectionString
            }
            Try
                sqlCon.Open()
            Catch ex As Exception
                Throw New Exception(GenerateCustomErrorMessage(sqlCon.DataSource, ex.Message))
            End Try
            Return sqlCon
        End Function

        <System.Diagnostics.DebuggerStepThrough()>
        Protected Friend Shared Sub CloseConnection(ByRef sqlCon As SqlConnection)
            If sqlCon.State <> ConnectionState.Closed Then sqlCon.Close()
        End Sub

#End Region

#Region "Self Setup Parameters"

        Protected Friend Shared Function CreateSqlParam(ByVal direction As System.Data.ParameterDirection, ByVal name As String, ByVal type As SqlDbType, ByVal value As Object) As SqlParameter
            Return CreateSqlParam(direction, name, type, 0, 0, 0, value)
        End Function

        Protected Friend Shared Function CreateSqlParam(ByVal direction As System.Data.ParameterDirection, ByVal name As String, ByVal type As SqlDbType, ByVal size As Integer, ByVal value As Object) As SqlParameter
            Return CreateSqlParam(direction, name, type, size, 0, 0, value)
        End Function

        Protected Friend Shared Function CreateSqlParam(ByVal direction As System.Data.ParameterDirection, ByVal name As String, ByVal type As SqlDbType, ByVal precision As Byte, ByVal scale As Byte, ByVal value As Object) As SqlParameter
            Return CreateSqlParam(direction, name, type, 0, precision, scale, value)
        End Function

        Protected Friend Shared Function CreateSqlParam(ByVal direction As System.Data.ParameterDirection, ByVal name As String, ByVal type As SqlDbType, ByVal size As Integer, ByVal precision As Byte, ByVal scale As Byte, ByVal value As Object) As SqlParameter
            Dim sqlParam As SqlParameter
            sqlParam = New SqlParameter(name, type) With {
                .Direction = direction
            }

            If (value IsNot Nothing) Then
                sqlParam.Value = value
            End If

            If (size > 0) Then
                sqlParam.Size = size
            End If

            If (precision > 0) Then
                sqlParam.Precision = precision
            End If

            If (scale > 0) Then
                sqlParam.Scale = scale
            End If

            Return sqlParam
        End Function

        Protected Friend Shared Sub SetOutputParametersValue(ByVal sqlCmd As SqlCommand, ByRef sqlParams As List(Of SqlParameter))
            For Each sqlParam As SqlParameter In sqlCmd.Parameters
                If (sqlParam.Direction = ParameterDirection.InputOutput Or sqlParam.Direction = ParameterDirection.Output) Then
                    'If sqlParams IsNot Nothing Then
                    '    sqlParams(FindSqlParameterIndex(sqlParam.ParameterName, sqlParams)).Value = sqlParam.Value
                    'Else
                    '    sqlParams(FindSqlParameterIndex(sqlParam.ParameterName, New List(Of SqlParameter))).Value = sqlParam.Value
                    'End If
                End If
            Next
        End Sub

        Protected Friend Shared Function FindSqlParameterIndex(ByVal paramName As String, ByVal sqlParams As List(Of SqlParameter)) As Integer
            Dim value As Integer = -1

            For i As Integer = 0 To sqlParams.Count - 1
                If (sqlParams(i).ParameterName = paramName) Then
                    value = i
                    Exit For
                End If
            Next

            Return value
        End Function

#End Region

#Region "Self Setup SqlCommand"

        Protected Friend Shared Function CreateCommand(ByRef sqlCon As SqlConnection, ByVal commandType As CommandType, ByVal commandText As String) As SqlCommand
            Return CreateCommand(sqlCon, commandType, commandText, Nothing, Nothing)
        End Function

        Protected Friend Shared Function CreateCommand(ByRef sqlCon As SqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByRef sqlParams As List(Of SqlParameter)) As SqlCommand
            Return CreateCommand(sqlCon, commandType, commandText, sqlParams, Nothing)
        End Function

        Protected Friend Shared Function CreateCommand(ByRef sqlCon As SqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByRef sqlParams As List(Of SqlParameter), ByRef sqlTran As SqlTransaction) As SqlCommand
            Dim sqlCmd As New SqlCommand With {
                .Connection = sqlCon,
                .Transaction = sqlTran,
                .CommandType = commandType,
                .CommandText = commandText,
                .CommandTimeout = 300
            }

            If (sqlParams IsNot Nothing) Then
                For Each sqlParam As SqlParameter In sqlParams
                    sqlCmd.Parameters.Add(CreateSqlParam(sqlParam.Direction, sqlParam.ParameterName, sqlParam.SqlDbType, sqlParam.Size, sqlParam.Precision, sqlParam.Scale, sqlParam.Value))
                Next
            End If

            Return sqlCmd
        End Function

#End Region

#Region "Self GetDataTable"

        Protected Friend Shared Function QueryDataTable(ByVal sqlCmd As SqlCommand, ByRef sqlTran As SqlTransaction, Optional ByVal intTimeout As Integer = 300) As DataTable
            Return QueryDataTable(sqlCmd, Nothing, sqlTran, intTimeout)
        End Function

        Protected Friend Shared Function QueryDataTable(ByVal sqlCmd As SqlCommand, ByRef sqlParams As List(Of SqlParameter), ByRef sqlTran As SqlTransaction, Optional ByVal intTimeout As Integer = 300) As DataTable
            Dim dt As DataTable = Nothing

            Dim sqlCon As SqlConnection
            If (sqlTran Is Nothing) Then
                sqlCon = OpenConnection()
            Else
                sqlCon = sqlTran.Connection
            End If

            If (sqlCon Is Nothing) Then
                GoTo returnValue
            End If

            Try
                sqlCmd.CommandTimeout = intTimeout
                Using sqlCmd
                    Using sqlDA As New SqlDataAdapter(sqlCmd)
                        dt = New DataTable
                        sqlDA.Fill(dt)
                    End Using

                    If (sqlParams IsNot Nothing) Then SetOutputParametersValue(sqlCmd, sqlParams)
                End Using

                If (sqlTran Is Nothing) Then
                    sqlCon.Close()
                End If
            Catch ex As Exception
                Throw New Exception(GenerateCustomErrorMessage(sqlCon.DataSource, ex.Message))
            End Try

returnValue:
            Return dt
        End Function

#End Region

#Region "Self ExecuteNonQuery"

        Public Shared Function ExecuteNonQuery(ByVal sqlCmd As SqlCommand, ByRef sqlTran As SqlTransaction) As Integer
            Return ExecuteNonQuery(sqlCmd, sqlTran, Nothing)
        End Function

        Public Shared Function ExecuteNonQuery(ByVal sqlCmd As SqlCommand, ByRef sqlTran As SqlTransaction, ByRef sqlParams As List(Of SqlParameter)) As Integer
            Dim rowsAffected As Integer = 0

            Dim sqlCon As SqlConnection
            If (sqlTran Is Nothing) Then
                sqlCon = DL.SQL.OpenConnection()
            Else
                sqlCon = sqlTran.Connection
            End If

            Try
                If (sqlCon Is Nothing) Then
                    GoTo returnValue
                End If

                CheckingAppVersion(sqlCon, sqlTran)

                sqlCmd.CommandTimeout = 300
                If (sqlParams IsNot Nothing) Then
                    For Each sqlParam As SqlParameter In sqlParams
                        sqlCmd.Parameters.Add(CreateSqlParam(sqlParam.Direction, sqlParam.ParameterName, sqlParam.SqlDbType, sqlParam.Size, sqlParam.Precision, sqlParam.Scale, sqlParam.Value))
                    Next
                End If

                Using sqlCmd
                    rowsAffected = sqlCmd.ExecuteNonQuery()
                    'SetOutputParametersValue(sqlCmd, sqlParams)
                End Using

                If (sqlTran Is Nothing) Then
                    sqlCon.Close()
                End If
returnValue:
            Catch ex As Exception
                Throw New Exception(GenerateCustomErrorMessage(sqlCon.DataSource, ex.Message))
            End Try

            Return rowsAffected
        End Function

#End Region

#Region "Self ExecuteScalar"

        Public Shared Function ExecuteReader(ByRef sqlCon As SqlConnection, ByVal sqlCmd As SqlCommand, Optional ByVal intTimeout As Integer = 300) As SqlDataReader
            Return ExecuteReader(sqlCon, sqlCmd, Nothing, intTimeout)
        End Function

        Public Shared Function ExecuteReader(ByRef sqlCon As SqlConnection, ByVal sqlCmd As SqlCommand, ByRef sqlParams As List(Of SqlParameter), Optional ByVal intTimeout As Integer = 300) As SqlDataReader
            If (sqlCon.State <> ConnectionState.Open) Then
                sqlCon.Open()
            End If

            sqlCmd.CommandTimeout = intTimeout

            If (sqlParams IsNot Nothing) Then
                For Each sqlParam As SqlParameter In sqlParams
                    sqlCmd.Parameters.Add(CreateSqlParam(sqlParam.Direction, sqlParam.ParameterName, sqlParam.SqlDbType, sqlParam.Size, sqlParam.Precision, sqlParam.Scale, sqlParam.Value))
                Next
            End If

            Dim sqlDR As SqlDataReader
            Try
                sqlDR = sqlCmd.ExecuteReader()
                sqlCmd.Dispose()
            Catch ex As Exception
                Throw New Exception(GenerateCustomErrorMessage(sqlCon.DataSource, ex.Message))
            End Try

            Return sqlDR
        End Function

        Protected Friend Shared Function ExecuteScalar(ByRef sqlCon As SqlConnection, ByVal sqlQuery As String, ByRef sqlParams As List(Of SqlParameter), Optional ByRef sqlTran As SqlTransaction = Nothing) As Object
            Dim value As Object = Nothing

            If (sqlCon.State = ConnectionState.Open) Then
                Dim sqlCmd As New SqlCommand(sqlQuery, sqlCon) With {
                    .Transaction = sqlTran,
                    .CommandType = CommandType.Text,
                    .CommandTimeout = 300,
                    .CommandText = sqlQuery
                }

                If (sqlParams IsNot Nothing) Then
                    For Each sqlParam As SqlParameter In sqlParams
                        sqlCmd.Parameters.Add(CreateSqlParam(sqlParam.Direction, sqlParam.ParameterName, sqlParam.SqlDbType, sqlParam.Size, sqlParam.Precision, sqlParam.Scale, sqlParam.Value))
                    Next
                End If

                Try
                    value = sqlCmd.ExecuteScalar()
                    sqlCmd.Dispose()
                Catch ex As Exception
                    Throw New Exception(GenerateCustomErrorMessage(sqlCon.DataSource, ex.Message))
                End Try
            End If

            Return value
        End Function

#End Region

    End Class

End Namespace