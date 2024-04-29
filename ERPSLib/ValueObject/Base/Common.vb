Namespace VO
    Public Class Common
        Property ProgramID As Integer
        Property ProgramName As String
        Property CompanyID As Integer
        Property CompanyName As String
        Property CompanyAddress As String
        Property CompanyCountry As String
        Property CompanyProvince As String
        Property CompanyCity As String
        Property CompanyWarehouse As String
        Property StatusInfo As String
        Property CreatedBy As String
        Property CreatedDate As DateTime
        Property LogInc As Integer
        Property LogBy As String
        Property LogDate As DateTime
        Property IsDeleted As Boolean
        Property JournalID As String

        Public Shared Function GetPaymentText(ByVal strModules As String) As String
            If strModules = VO.AccountPayable.PurchaseBalance Then
                Return "Pembayaran Saldo"
            ElseIf strModules = VO.AccountPayable.DownPaymentManual Then
                Return "Uang Muka Pembelian [Manual]"
            ElseIf strModules = VO.AccountPayable.DownPayment Then
                Return "Uang Muka Pembelian"
            ElseIf strModules = VO.AccountPayable.ReceivePayment Then
                Return "Pembayaran Hutang Pembelian"
            ElseIf strModules = VO.AccountPayable.DownPaymentCutting Then
                Return "Uang Muka Pesanan Pemotongan"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentCutting Then
                Return "Pembayaran Hutang Pesanan Pemotongan"
            ElseIf strModules = VO.AccountPayable.DownPaymentTransport Then
                Return "Uang Muka Pesanan Pengiriman"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentTransport Then
                Return "Pembayaran Hutang Pesanan Pengiriman"
            ElseIf strModules = VO.AccountPayable.All Then
                Return "Semua Daftar Pembayaran"
            ElseIf strModules = VO.AccountReceivable.SalesBalance Then
                Return "Pelunasan Saldo"
            ElseIf strModules = VO.AccountReceivable.DownPaymentManual Then
                Return "Uang Muka Penjualan [Manual]"
            ElseIf strModules = VO.AccountReceivable.DownPayment Then
                Return "Uang Muka Penjualan"
            ElseIf strModules = VO.AccountReceivable.ReceivePayment Then
                Return "Pelunasan Piutang Penjualan"
            ElseIf strModules = VO.AccountReceivable.All Then
                Return "Semua Daftar Pelunasan"
            End If
            Return ""
        End Function

        Public Shared Function GetModuleID(ByVal strModules As String) As Integer
            If strModules = VO.AccountPayable.PurchaseBalance Then
                Return VO.Modules.Values.TransactionAccountPayableBalance
            ElseIf strModules = VO.AccountPayable.DownPaymentManual Then
                Return VO.Modules.Values.TransactionPurchaseDPManual
            ElseIf strModules = VO.AccountPayable.DownPayment Then
                Return VO.Modules.Values.TransactionPurchaseDP
            ElseIf strModules = VO.AccountPayable.ReceivePayment Then
                Return VO.Modules.Values.TransactionAccountPayable
            ElseIf strModules = VO.AccountPayable.DownPaymentCutting Then
                Return VO.Modules.Values.TransactionPurchaseDPCutting
            ElseIf strModules = VO.AccountPayable.ReceivePaymentCutting Then
                Return VO.Modules.Values.TransactionAccountPayableCutting
            ElseIf strModules = VO.AccountPayable.DownPaymentTransport Then
                Return VO.Modules.Values.TransactionPurchaseDPTransport
            ElseIf strModules = VO.AccountPayable.ReceivePaymentTransport Then
                Return VO.Modules.Values.TransactionAccountPayableTransport
            ElseIf strModules = VO.AccountReceivable.SalesBalance Then
                Return VO.Modules.Values.TransactionAccountReceivableBalance
            ElseIf strModules = VO.AccountReceivable.DownPaymentManual Then
                Return VO.Modules.Values.TransactionSalesDPManual
            ElseIf strModules = VO.AccountReceivable.DownPayment Then
                Return VO.Modules.Values.TransactionSalesDP
            ElseIf strModules = VO.AccountReceivable.ReceivePayment Then
                Return VO.Modules.Values.TransactionAccountReceivable
            End If
            Return 0
        End Function

        Public Shared Function GetPaymentType(ByVal strModules As String) As String
            If strModules = VO.AccountPayable.PurchaseBalance Then
                Return "Pembayaran"
            ElseIf strModules = VO.AccountPayable.DownPaymentManual Then
                Return "Down Payment"
            ElseIf strModules = VO.AccountPayable.DownPayment Then
                Return "Down Payment"
            ElseIf strModules = VO.AccountPayable.ReceivePayment Then
                Return "Pembayaran"
            ElseIf strModules = VO.AccountPayable.DownPaymentCutting Then
                Return "Down Payment"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentCutting Then
                Return "Pembayaran"
            ElseIf strModules = VO.AccountPayable.DownPaymentTransport Then
                Return "Down Payment"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentTransport Then
                Return "Pembayaran"
            ElseIf strModules = VO.AccountReceivable.SalesBalance Then
                Return "Pelunasan"
            ElseIf strModules = VO.AccountReceivable.DownPaymentManual Then
                Return "Down Payment"
            ElseIf strModules = VO.AccountReceivable.DownPayment Then
                Return "Down Payment"
            ElseIf strModules = VO.AccountReceivable.ReceivePayment Then
                Return "Pelunasan"
            End If
            Return ""
        End Function

        Public Shared Function GetPaymentTypeInitial(ByVal strModules As String) As String
            If strModules = VO.AccountPayable.PurchaseBalance Then
                Return " "
            ElseIf strModules = VO.AccountPayable.DownPaymentManual Then
                Return "DP"
            ElseIf strModules = VO.AccountPayable.DownPayment Then
                Return "DP"
            ElseIf strModules = VO.AccountPayable.ReceivePayment Then
                Return " "
            ElseIf strModules = VO.AccountPayable.DownPaymentCutting Then
                Return "DP"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentCutting Then
                Return " "
            ElseIf strModules = VO.AccountPayable.DownPaymentTransport Then
                Return "DP"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentTransport Then
                Return " "
            ElseIf strModules = VO.AccountReceivable.SalesBalance Then
                Return " "
            ElseIf strModules = VO.AccountReceivable.DownPaymentManual Then
                Return "DP"
            ElseIf strModules = VO.AccountReceivable.DownPayment Then
                Return "DP"
            ElseIf strModules = VO.AccountReceivable.ReceivePayment Then
                Return " "
            End If
            Return " "
        End Function

    End Class
End Namespace

