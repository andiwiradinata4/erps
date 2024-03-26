Namespace BL

    Public Class Reports

        Public Shared Function MonitoringProductTransactionReportVer00(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.Reports.MonitoringProductTransactionReportVer00(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            End Using
            dtReturn.DefaultView.Sort = "PONumber, CategoryID, PODate ASC"
            dtReturn = dtReturn.DefaultView.ToTable
            Return dtReturn
        End Function

        Public Shared Function BukuBesarLastBalance(ByVal dtmDateFrom As DateTime, ByVal intCoAID As Integer, ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As Decimal
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.BukuBesarLastBalance(sqlCon, Nothing, dtmDateFrom, intCoAID, intProgramID, intCompanyID)
            End Using
        End Function

        Public Shared Function BukuBesarVer00Report(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intCoAID As Integer, ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.BukuBesarVer00Report(sqlCon, Nothing, dtmDateFrom, dtmDateTo, intCoAID, intProgramID, intCompanyID)
            End Using
        End Function

        Public Shared Function KartuHutangVer01Report(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal intBPID As Integer) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.KartuHutangVer01Report(sqlCon, Nothing, dtmDateFrom, dtmDateTo, intProgramID, intCompanyID, intBPID)
            End Using
        End Function

    End Class

End Namespace