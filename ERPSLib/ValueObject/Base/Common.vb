Imports System.Runtime.Remoting.Messaging

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
                Return "Pembayaran Biaya Pemotongan"
            ElseIf strModules = VO.AccountPayable.DownPaymentTransport Then
                Return "Uang Muka Pesanan Pengiriman"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentTransport Then
                Return "Pembayaran Biaya Pengiriman"
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
            ElseIf strModules = VO.AccountReceivable.DownPaymentOrderRequest Then
                Return "Uang Muka Penjualan"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                Return "Pelunasan Piutang Penjualan [Stock]"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentOrderRequestVer2 Then
                Return "Pelunasan Piutang Penjualan"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentTransport Then
                Return "Pelunasan Piutang Pengiriman"
            ElseIf strModules = VO.AccountReceivable.All Then
                Return "Semua Daftar Pelunasan"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentSalesReturn Then
                Return "Pembayaran Retur Penjualan"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentTransportSalesReturn Then
                Return "Pembayaran Biaya Pengiriman Retur Penjualan"
            ElseIf strModules = VO.AccountPayable.ReceivePaymentClaimSales Then
                Return "Pembayaran Biaya Klaim"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentClaimPurchase Then
                Return "Pelunasan Biaya Kompensasi"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentClaimPOCutting Then
                Return "Pelunasan Biaya Pemotongan"
            End If
            Return ""
        End Function

        Public Shared Function GetModuleID(ByVal strModules As String) As Integer
            If strModules = VO.AccountPayable.PurchaseBalance Then
                Return 0 ' VO.Modules.Value.TransactionAccountPayableBalance
            ElseIf strModules = VO.AccountPayable.DownPaymentManual Then
                Return 0 'VO.Modules.Value.TransactionPurchaseDPManual
            ElseIf strModules = VO.AccountPayable.DownPayment Then
                Return VO.Modules.Value.TransactionPurchasePurchaseContractDownPayment
            ElseIf strModules = VO.AccountPayable.ReceivePayment Then
                Return VO.Modules.Value.TransactionPurchasePurchaseContractReceivePayment
            ElseIf strModules = VO.AccountPayable.DownPaymentCutting Then
                Return 0 'VO.Modules.Value.TransactionPurchasePurchaseOrderCutting
            ElseIf strModules = VO.AccountPayable.ReceivePaymentCutting Then
                Return VO.Modules.Value.TransactionAccountingCuttingCost
            ElseIf strModules = VO.AccountPayable.DownPaymentTransport Then
                Return 0 'VO.Modules.Value.TransactionPurchase
            ElseIf strModules = VO.AccountPayable.ReceivePaymentTransport Then
                Return VO.Modules.Value.TransactionAccountingTransportCost
            ElseIf strModules = VO.AccountReceivable.SalesBalance Then
                Return 0 'VO.Modules.Value.TransactionAccountReceivableBalance
            ElseIf strModules = VO.AccountReceivable.DownPaymentManual Then
                Return 0 'VO.Modules.Value.TransactionSalesDPManual
            ElseIf strModules = VO.AccountReceivable.DownPaymentOrderRequest Then
                Return VO.Modules.Value.TransactionSalesOrderRequestDownPayment
            ElseIf strModules = VO.AccountReceivable.DownPayment Then
                Return VO.Modules.Value.TransactionSalesSalesContractDownPayment
            ElseIf strModules = VO.AccountReceivable.ReceivePayment Then
                Return VO.Modules.Value.TransactionSalesSalesContractReceivePayment
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentClaimPOCutting Then
                Return 0 'VO.Modules.Value.TransactionAccountReceivable
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentTransport Then
                Return VO.Modules.Value.TransactionSalesServiceDeliveryReceivePayment
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
            ElseIf strModules = VO.AccountReceivable.DownPaymentOrderRequest Then
                Return "Down Payment"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                Return "Pelunasan"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentClaimPOCutting Then
                Return "Pelunasan"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentClaimPurchase Then
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
            ElseIf strModules = VO.AccountReceivable.DownPaymentOrderRequest Then
                Return "DP"
            ElseIf strModules = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                Return " "
            End If
            Return " "
        End Function

    End Class
End Namespace

