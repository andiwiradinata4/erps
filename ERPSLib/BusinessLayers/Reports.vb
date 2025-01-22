Namespace BL

    Public Class Reports

#Region "Accounting"

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

        Public Shared Function KartuPiutangVer01Report(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal intBPID As Integer) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.KartuPiutangVer01Report(sqlCon, Nothing, dtmDateFrom, dtmDateTo, intProgramID, intCompanyID, intBPID)
            End Using
        End Function

        Public Shared Function NeracaSaldoVer00Report(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.NeracaSaldoVer00Report(sqlCon, Nothing, dtmDateFrom, dtmDateTo, intProgramID, intCompanyID)
            End Using
        End Function

#End Region

#Region "Profit and Loss"

        Public Shared Function ListDataPerCOATypeBaseOnBukuBesarReport(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal intCOAType As Integer, Optional ByVal intCOAGroupID As Integer = 0) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.ListDataPerCOATypeBaseOnBukuBesarReport(sqlCon, Nothing, dtmDateFrom, dtmDateTo, intProgramID, intCompanyID, intCOAType, intCOAGroupID)
            End Using
        End Function

        Public Shared Function DiscountRevenueReport(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.DiscountRevenueReport(sqlCon, Nothing, dtmDateFrom, dtmDateTo)
            End Using
        End Function

        Public Shared Function FirstStockReport(ByVal dtmDateFrom As DateTime) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.FirstStockReport(sqlCon, Nothing, dtmDateFrom)
            End Using
        End Function

        Public Shared Function PurchaseStockReport(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.PurchaseStockReport(sqlCon, Nothing, dtmDateFrom, dtmDateTo)
            End Using
        End Function

        Public Shared Function LastStockReport(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.LastStockReport(sqlCon, Nothing, dtmDateFrom, dtmDateTo)
            End Using
        End Function

        Public Shared Function ExpensesReport(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.ExpensesReport(sqlCon, Nothing, dtmDateFrom, dtmDateTo)
            End Using
        End Function

        Public Shared Function CalculateProfitAndLoss(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As Decimal
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Dim decSalesRevenue As Decimal = 0, decCOGS As Decimal = 0, decOperationalExpenses As Decimal = 0, decOthersRevenue As Decimal = 0, decOthersExpenses As Decimal = 0, decReturn As Decimal = 0
            Dim dtSalesAndRevenue As DataTable = BL.Reports.ListDataPerCOATypeBaseOnBukuBesarReport(dtmDateFrom, dtmDateTo, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, VO.ChartOfAccountType.Values.Pendapatan, VO.ChartOfAccountGroup.Values.PendapatanDanPenjualan)
            Dim dtCOGS As DataTable = BL.Reports.ListDataPerCOATypeBaseOnBukuBesarReport(dtmDateFrom, dtmDateTo, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, VO.ChartOfAccountType.Values.Beban, VO.ChartOfAccountGroup.Values.BebanHPP)
            Dim dtOperationalExpenses As DataTable = BL.Reports.ListDataPerCOATypeBaseOnBukuBesarReport(dtmDateFrom, dtmDateTo, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, VO.ChartOfAccountType.Values.Beban, VO.ChartOfAccountGroup.Values.BebanOperasional)
            Dim dtOthersRevenue As DataTable = BL.Reports.ListDataPerCOATypeBaseOnBukuBesarReport(dtmDateFrom, dtmDateTo, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, VO.ChartOfAccountType.Values.Pendapatan, VO.ChartOfAccountGroup.Values.PendapatanLainLain)
            Dim dtOthersExpenses As DataTable = BL.Reports.ListDataPerCOATypeBaseOnBukuBesarReport(dtmDateFrom, dtmDateTo, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.UI.usUserApp.CompanyID, VO.ChartOfAccountType.Values.Beban, VO.ChartOfAccountGroup.Values.BebanLainnya)

            '# Calculate Sales And Revenue
            For Each dr As DataRow In dtSalesAndRevenue.Rows
                decSalesRevenue += dr.Item("TotalAmount")
            Next
            '# End Of Calculate Sales And Revenue

            '# Calculate COGS
            For Each dr As DataRow In dtCOGS.Rows
                decCOGS += dr.Item("TotalAmount")
            Next
            '# End of Calculate COGS

            '# Calculate Operational Expenses
            For Each dr As DataRow In dtOperationalExpenses.Rows
                decOperationalExpenses += dr.Item("TotalAmount")
            Next
            '# End of Calculate Operational Expenses

            '# Calculate Others Revenue
            For Each dr As DataRow In dtOthersRevenue.Rows
                decOthersRevenue += dr.Item("TotalAmount")
            Next
            '# End of Calculate Others Revenue

            '# Calculate Others Expenses
            For Each dr As DataRow In dtOthersExpenses.Rows
                decOthersExpenses += dr.Item("TotalAmount")
            Next
            '# End of Calculate Others Expenses
            '# Return = (Sales Revenue - COGS) - Operational Expenses + (Others Revenue - Others Expenses)
            decReturn = (decSalesRevenue - decCOGS) - decOperationalExpenses + (decOthersRevenue - decOthersExpenses)
            Return decReturn
        End Function

#End Region

#Region "Balance Sheet"

        Public Shared Function ListDataPerCOATypeBaseOnChartOfAccountReport(ByVal dtmDateTo As DateTime, ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal intCOAType As Integer, Optional ByVal intCOAGroupID As Integer = 0) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.ListDataPerCOATypeBaseOnChartOfAccountReport(sqlCon, Nothing, dtmDateTo, intProgramID, intCompanyID, intCOAType, intCOAGroupID)
            End Using
        End Function

        Public Shared Function BalanceSheetReport(ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim dtDebit As DataTable = DL.Reports.BalanceSheetDebitReport(sqlCon, Nothing, dtmDateTo)
                Dim dtStock As DataTable = DL.Reports.LastStockReport(sqlCon, Nothing, "2000/01/01", dtmDateTo)
                Dim drDebit As DataRow
                If dtStock.Rows.Count = 0 Then
                    drDebit = dtDebit.NewRow
                    drDebit.BeginEdit()
                    drDebit.Item("CoACode") = "104"
                    drDebit.Item("CoAName") = "PERSEDIAAN"
                    drDebit.Item("DebitAmount") = 0
                    drDebit.Item("CreditAmount") = 0
                    drDebit.EndEdit()
                Else
                    drDebit = dtDebit.NewRow
                    drDebit.BeginEdit()
                    drDebit.Item("CoACode") = "101"
                    drDebit.Item("CoAName") = "PERSEDIAAN"
                    drDebit.Item("DebitAmount") = 0
                    For Each dr As DataRow In dtStock.Rows
                        drDebit.Item("DebitAmount") += dr.Item("TotalAmount")
                    Next
                    drDebit.Item("CreditAmount") = 0
                    drDebit.EndEdit()
                End If
                dtDebit.Rows.Add(drDebit)
                dtDebit.AcceptChanges()

                Dim dtCredit As DataTable = DL.Reports.BalanceSheetCreditReport(sqlCon, Nothing, dtmDateTo)
                Dim drCredit As DataRow
                Dim decProfitOrLoss As Decimal = CalculateProfitAndLoss("2000/01/01", dtmDateTo.Date)
                drCredit = dtCredit.NewRow
                drCredit.BeginEdit()
                drCredit.Item("CoACode") = "999"
                drCredit.Item("CoAName") = IIf(decProfitOrLoss > 0, "LABA", "RUGI") & " BULAN BERJALAN"
                drCredit.Item("DebitAmount") = 0
                drCredit.Item("CreditAmount") = decProfitOrLoss
                drCredit.EndEdit()
                dtCredit.Rows.Add(drCredit)
                dtCredit.AcceptChanges()

                Dim dtReturn As New DataTable
                dtReturn.Merge(dtDebit)
                dtReturn.Merge(dtCredit)
                dtReturn.DefaultView.Sort = "CoACode ASC"
                Return dtReturn
            End Using
        End Function

#End Region

        Public Shared Function ListPOCutting(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                             ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                             ByVal intBPID As Integer, ByVal intItemTypeID As Integer) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.ListPOCutting(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intBPID, intItemTypeID)
            End Using
        End Function

        Public Shared Function MonitoringProductTransactionReportMainVer00(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.Reports.MonitoringProductTransactionReportMainVer00(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            End Using
            dtReturn.DefaultView.Sort = "PCDate, PCNumber, OrderNumberSupplier ASC"
            dtReturn = dtReturn.DefaultView.ToTable
            Return dtReturn
        End Function

        Public Shared Function MonitoringProductTransactionReportSalesContractVer00(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.Reports.MonitoringProductTransactionReportSalesContractVer00(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            End Using
            dtReturn.DefaultView.Sort = "SCDate, SCNumber ASC"
            dtReturn = dtReturn.DefaultView.ToTable
            Return dtReturn
        End Function

        Public Shared Function SalesPIReport(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                             ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                             ByVal intBPID As Integer, ByVal intItemTypeID As Integer) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Reports.SalesPIReport(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intBPID, intItemTypeID)
            End Using
        End Function

    End Class

End Namespace