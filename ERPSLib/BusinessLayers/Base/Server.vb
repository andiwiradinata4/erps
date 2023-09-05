Namespace BL

    Public Class Server

        <System.Diagnostics.DebuggerStepThrough>
        Public Shared Sub ServerDefault()
            DL.SQL.strServer = VO.DefaultServer.Server
            DL.SQL.strDatabase = VO.DefaultServer.Database
            DL.SQL.strSAID = VO.DefaultServer.UserID
            DL.SQL.strSAPassword = VO.DefaultServer.Password
        End Sub

        <System.Diagnostics.DebuggerStepThrough>
        Public Shared Sub SetServer(ByVal strCompanyID As String)
            For Each dtRow As DataRow In VO.ServerList.ServerList.Rows
                If dtRow.Item("CompanyID") = strCompanyID Then
                    DL.SQL.strServer = dtRow.Item("Server")
                    DL.SQL.strDatabase = dtRow.Item("DBName")
                    DL.SQL.strSAID = dtRow.Item("UserID")
                    DL.SQL.strSAPassword = dtRow.Item("UserPassword")
                    Exit For
                End If
            Next
        End Sub

        <System.Diagnostics.DebuggerStepThrough>
        Public Shared Sub SetServer(ByVal strServer As String, ByVal strDBName As String, ByVal strUserID As String, ByVal strUserPassword As String)
            DL.SQL.strServer = strServer
            DL.SQL.strDatabase = strDBName
            DL.SQL.strSAID = strUserID
            DL.SQL.strSAPassword = strUserPassword
        End Sub

    End Class

End Namespace
