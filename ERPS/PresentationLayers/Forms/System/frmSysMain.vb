Public Class frmSysMain

    Dim bolLogOut As Boolean

    '# Master
    Dim frmMainMstProgram As frmMstProgram
    Dim frmMainMstStatus As frmMstStatus
    Dim frmMainMstModules As frmMstModules
    Dim frmMainMstAccess As frmMstAccess
    Dim frmMainMstCompany As frmMstCompany
    Dim frmMainMstUser As frmMstUser
    Dim frmMainMstUOM As frmMstUOM
    Dim frmMainMstChartOfAccountType As frmMstChartOfAccountType
    Dim frmMainMstChartOfAccountGroup As frmMstChartOfAccountGroup
    Dim frmMainMstChartOfAccount As frmMstChartOfAccount
    Dim frmMainMstItemType As frmMstItemType
    Dim frmMainMstItemSpecification As frmMstItemSpecification
    Dim frmMainMstItem As frmMstItem
    Dim frmMainMstStock As frmMstStock
    Dim frmMainBusinessPartner As frmMstBusinessPartner
    Dim frmMainMstCompanyBankAccount As frmMstCompanyBankAccount
    Dim frmMainMstPaymentTypeCategory As frmMstPaymentTypeCategory
    Dim frmMainMstPaymentMode As frmMstPaymentMode
    Dim frmMainMstPaymentType As frmMstPaymentType
    Dim frmMainMstDeliveryLocation As frmMstDeliveryLocation
    Dim frmMainMstTransporterPriceType As frmMstTransporterPriceType

    '# Transaction
    '## Sales
    'Dim frmMainTraOrderRequest As frmTraOrderRequest
    Dim frmMainTraOrderRequestVer2 As frmTraOrderRequestVer2
    Dim frmMainTraSalesContract As frmTraSalesContract
    Dim frmMainTraSalesConfirmationOrder As frmTraSalesConfirmationOrder
    Dim frmMainTraDelivery As frmTraDelivery
    Dim frmMainTraSalesReturn As frmTraSalesReturn
    Dim frmMainTraClaimSales As frmTraClaim
    Dim frmMainTraConfirmationClaimSales As frmTraConfirmationClaim

    '## Sales Stock
    'Dim frmMainTraOrderRequestStock As frmTraOrderRequest
    Dim frmMainTraDeliveryStock As frmTraDelivery

    '# Sales Service
    Dim frmMainTraSalesServiceTransport As frmTraSalesService


    '## Purchase
    Dim frmMainTraPurchaseOrder As frmTraPurchaseOrder
    Dim frmMainTraConfirmationOrder As frmTraConfirmationOrder
    Dim frmMainTraPurchaseContract As frmTraPurchaseContract
    Dim frmMainTraReceive As frmTraReceive
    Dim frmMainTraPurchaseOrderCutting As frmTraPurchaseOrderCutting
    Dim frmMainTraCutting As frmTraCutting
    'Dim frmMainTraPurchaseOrderTransport As frmTraPurchaseOrderTransport
    Dim frmMainTraClaimPurchase As frmTraClaim
    Dim frmMainTraConfirmationClaimPurchase As frmTraConfirmationClaim

    '## Pembukuan
    'Dim frmMainTraAccountReceivableSetupBalance As frmTraAccountReceivable
    'Dim frmMainTraAccountReceivableDPManual As frmTraAccountReceivable
    'Dim frmMainTraAccountReceivableDP As frmTraAccountReceivable
    'Dim frmMainTraAccountReceivable As frmTraAccountReceivable

    'Dim frmMainTraAccountPayableSetupBalance As frmTraAccountPayable
    'Dim frmMainTraAccountPayableDPManual As frmTraAccountPayable
    'Dim frmMainTraAccountPayableDP As frmTraAccountPayable
    'Dim frmMainTraAccountPayableReceivePayment As frmTraAccountPayable
    'Dim frmMainTraAccountPayableDPCutting As frmTraAccountPayable
    'Dim frmMainTraAccountPayableDPTransport As frmTraAccountPayable
    Dim frmMainTraAccountPayableReceivePaymentTransport As frmTraAPCost
    Dim frmMainTraAccountPayableReceivePaymentCutting As frmTraAPCost
    Dim frmMainTraARAPPayable As frmTraARAP
    Dim frmMainTraARAPReceivable As frmTraARAP

    'Dim frmMainTraAccountPayable As frmTraAccountPayable

    Dim frmMainTraCost As frmTraCost
    Dim frmMainTraARAPVoucher As frmTraARAPVoucher
    Dim frmMainTraJournal As frmTraJournal
    Dim frmMainTraJournalAutoGenerate As frmTraJournalAutoGenerate

    '# Laporan
    Dim frmMainRptMonitoringProductTransactionVer00 As frmRptMonitoringProductTransactionVer00
    Dim frmMainRptKartuHutangVer00 As frmRptKartuHutangVer00
    Dim frmMainRptKartuPiutangVer00 As frmRptKartuPiutangVer00
    Dim frmMainRptListPOCuttingVer00 As frmRptListPOCuttingVer00
    Dim frmMainRptPIWithSizeReportVer00 As frmRptPIWithSizeReportVer00
    Dim frmMainRptSalesConfirmationOrderReportVer00 As frmRptSalesConfirmationOrderReportVer00

    '## Pembukuan
    Dim frmMainRptBukuBesarVer00 As frmRptBukuBesarVer00
    Dim frmMainRptNeracaSaldoVer00 As frmRptNeracaSaldoVer00
    Dim frmMainRptLabaRugiVer00 As frmRptLabaRugiVer00
    Dim frmMainRptNeracaVer00 As frmRptNeracaVer00


    '# Setting
    Dim frmMainSysChangePassword As frmSysChangePassword
    Dim frmMainSysJournalPost As frmSysJournalPost
    Dim frmMainSysOutstandingARAP As frmSysOutstandingARAP


    Dim frmMainSysSetup As frmSysSetup


    Private Sub prvSetupStatusStrip()
        tssUserID.Text = ERPSLib.UI.usUserApp.UserID
        tssVersion.Text = "Versi: " & FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion
        tssProgram.Text = ERPSLib.UI.usUserApp.ProgramName
        tssCompany.Text = ERPSLib.UI.usUserApp.CompanyName
        tssServer.Text = ERPSLib.UI.usUserApp.ServerName
        ssBuildDate.Text = "Build : 30/03/2025 07:08"
    End Sub

    Private Sub prvUserAccess()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        '# Master
        mnuMasterProgram.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterProgram, VO.Access.Value.ViewAccess)
        mnuMasterStatus.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterStatus, VO.Access.Value.ViewAccess)
        mnuMasterModule.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterModule, VO.Access.Value.ViewAccess)
        mnuMasterAkses.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterAccess, VO.Access.Value.ViewAccess)
        mnuMasterPerusahaan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterCompany, VO.Access.Value.ViewAccess)
        mnuMasterKaryawan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterUser, VO.Access.Value.ViewAccess)
        mnuMasterSatuan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterUOM, VO.Access.Value.ViewAccess)
        mnuMasterTipeAkunPerkiraan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccountType, VO.Access.Value.ViewAccess)
        mnuMasterGroupAkunPerkiraan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccountGroup, VO.Access.Value.ViewAccess)
        mnuMasterAkunPerkiraan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterChartOfAccount, VO.Access.Value.ViewAccess)

        mnuMasterJenisBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterItemType, VO.Access.Value.ViewAccess)
        mnuMasterSpesifikasiBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterItemSpecification, VO.Access.Value.ViewAccess)
        mnuMasterBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterItem, VO.Access.Value.ViewAccess)
        '# Tidak bisa dipakai, ItemID Receive dengan ItemID Delivery berbeda sehingga tidak bisa cross total berat
        mnuMasterPersediaan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterStock, VO.Access.Value.ViewAccess)

        mnuMasterRekanBisnis.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterBusinessPartner, VO.Access.Value.ViewAccess)
        mnuMasterAkunBankPerusahaan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterCompanyBankAccount, VO.Access.Value.ViewAccess)
        mnuMasterPaymentTypeCategory.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterPaymentTypeCategory, VO.Access.Value.ViewAccess)
        mnuMasterMetodePembayaran.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterPaymentMethod, VO.Access.Value.ViewAccess)
        mnuMasterJenisPembayaran.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterPaymentType, VO.Access.Value.ViewAccess)

        mnuMasterLokasiPengiriman.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterDeliveryLocation, VO.Access.Value.ViewAccess)
        mnuMasterJenisBiayaTransportasi.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.MasterTransportCostType, VO.Access.Value.ViewAccess)

        pgMain.Value = 50

        '# Transaction
        '## Sales
        mnuTransaksiPenjualanPermintaanPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesOrderRequest, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanKonfirmasiPesanan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesConfirmationOrder, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanKontrakPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesSalesContract, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanPengirimanPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesDelivery, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanReturPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesSalesReturn, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanPengajuanKlaim.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesClaimRequest, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanKonfirmasiKlaim.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesClaimConfirmation, VO.Access.Value.ViewAccess)

        '## Sales Service
        mnuTransaksiPenjualanJasaPengiriman.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesServiceDelivery, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanJasaPelunasanPengiriman.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesServiceDeliveryReceivePayment, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanJasaProsesPotong.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesServiceCutting, VO.Access.Value.ViewAccess)
        mnuTransaksiPenjualanJasaPelunasanPemotongan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionSalesServiceCuttingReceivePayment, VO.Access.Value.ViewAccess)

        If Not mnuTransaksiPenjualanJasaPengiriman.Enabled And Not mnuTransaksiPenjualanJasaPelunasanPengiriman.Enabled And
            Not mnuTransaksiPenjualanJasaProsesPotong.Enabled And Not mnuTransaksiPenjualanJasaPelunasanPemotongan.Enabled Then
            mnuTransaksiPenjualanJasa.Visible = False
        End If

        '## Sales [Stock]
        mnuTransaksiPenjualanStock.Visible = False

        '## Purchase
        mnuTransaksiPembelianPesananPembelian.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchasePurchaseOrder, VO.Access.Value.ViewAccess)
        mnuTransaksiPembelianKonfirmasiPesanan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchaseConfirmationOrder, VO.Access.Value.ViewAccess)
        mnuTransaksiPembelianKontrakPembelian.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchasePurchaseContract, VO.Access.Value.ViewAccess)
        mnuTransaksiPembelianPenerimaanPembelian.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchaseReceive, VO.Access.Value.ViewAccess)

        mnuTransaksiPembelianSPKPotong.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchasePurchaseOrderCutting, VO.Access.Value.ViewAccess)
        mnuTransaksiPembelianProsesPemotongan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchaseCutting, VO.Access.Value.ViewAccess)
        mnuTransaksiPembelianPengajuanKlaim.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchaseClaimRequest, VO.Access.Value.ViewAccess)
        mnuTransaksiPembelianKonfirmasiKlaim.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Value.TransactionPurchaseClaimConfirmation, VO.Access.Value.ViewAccess)

        '## Pembukuan
        mnuTransaksiPembukuanPembayaran.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingAP, VO.Access.Value.ViewAccess)
        mnuTransaksiPembukuanPelunasan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingAR, VO.Access.Value.ViewAccess)
        mnuTransaksiPembukuanPembayaranBiaya.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingCost, VO.Access.Value.ViewAccess)
        mnuTransaksiPembukuanPembayaranBiayaTransportasi.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingTransportCost, VO.Access.Value.ViewAccess)
        mnuTransaksiPembukuanPembayaranBiayaPotong.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingCuttingCost, VO.Access.Value.ViewAccess)
        mnuTransaksiPembukuanKasBankVoucher.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingBankVoucher, VO.Access.Value.ViewAccess)
        mnuTransaksiPembukuanJurnalUmum.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingJournal, VO.Access.Value.ViewAccess)
        mnuTransaksiPembukuanJurnalUmumAutoGenerate.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.TransactionAccountingJournalAutoGenerate, VO.Access.Value.ViewAccess)

        '# Laporan
        mnuLaporanPembelianSPKPotong.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportPurchasePurchaseOrderCutting, VO.Access.Value.ViewAccess)
        mnuLaporanPenjualanKonfirmasiPesanan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportSalesConfirmationOrder, VO.Access.Value.ViewAccess)
        mnuLaporanTransaksiBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportItemTransaction, VO.Access.Value.ViewAccess)
        mnuLaporanPembukuanPIPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportAccountingAR, VO.Access.Value.ViewAccess)
        mnuLaporanPembukuanKartuHutang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportAccountingDebtCard, VO.Access.Value.ViewAccess)
        mnuLaporanPembukuanKartuPiutang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportAccountingReceivableCard, VO.Access.Value.ViewAccess)
        mnuLaporanPembukuanBukuBesar.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportAccountingGeneralLedger, VO.Access.Value.ViewAccess)
        mnuLaporanPembukuanNeracaSaldo.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportAccountingTrialBalance, VO.Access.Value.ViewAccess)
        mnuLaporanPembukuanLabaRugi.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportAccountingProfitAndLoss, VO.Access.Value.ViewAccess)
        mnuLaporanPembukuanNeraca.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.ReportAccountingBalanceSheet, VO.Access.Value.ViewAccess)

        '# Pengaturan
        mnuPengaturanSetupPostingJurnalTransaksi.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Value.SetupPostingJournalTransaction, VO.Access.Value.ViewAccess)

        Me.Cursor = Cursors.Default
        pgMain.Visible = False
    End Sub


#Region "Form Handle"

    Private Sub frmSysMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If ERPSLib.UI.usUserApp.IsSuperUser Then
            If e.KeyCode = Keys.F12 Then UI.usForm.frmOpen(frmMainSysSetup, "frmSysSetup", Me)
        End If
    End Sub

    Private Sub frmSysMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        bolLogOut = False
        prvSetupStatusStrip()
        prvUserAccess()
    End Sub

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bolLogOut Then
            If UI.usForm.frmAskQuestion("Keluar dari sistem ?") Then
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "Master"

    Private Sub mnuMasterProgram_Click(sender As Object, e As EventArgs) Handles mnuMasterProgram.Click
        UI.usForm.frmOpen(frmMainMstProgram, "frmMstProgram", Me)
    End Sub

    Private Sub mnuMasterStatus_Click(sender As Object, e As EventArgs) Handles mnuMasterStatus.Click
        UI.usForm.frmOpen(frmMainMstStatus, "frmMstStatus", Me)
    End Sub

    Private Sub mnuMasterModule_Click(sender As Object, e As EventArgs) Handles mnuMasterModule.Click
        UI.usForm.frmOpen(frmMainMstModules, "frmMstModules", Me)
    End Sub

    Private Sub mnuMasterAkses_Click(sender As Object, e As EventArgs) Handles mnuMasterAkses.Click
        UI.usForm.frmOpen(frmMainMstAccess, "frmMstAccess", Me)
    End Sub

    Private Sub mnuMasterPerusahaan_Click(sender As Object, e As EventArgs) Handles mnuMasterPerusahaan.Click
        UI.usForm.frmOpen(frmMainMstCompany, "frmMstCompany", Me)
    End Sub

    Private Sub mnuMasterPaymentTypeCategory_Click(sender As Object, e As EventArgs) Handles mnuMasterPaymentTypeCategory.Click
        UI.usForm.frmOpen(frmMainMstPaymentTypeCategory, "frmMstPaymentTypeCategory", Me)
    End Sub

    Private Sub mnuMasterKaryawan_Click(sender As Object, e As EventArgs) Handles mnuMasterKaryawan.Click
        UI.usForm.frmOpen(frmMainMstUser, "frmMstUser", Me)
    End Sub

    Private Sub mnuMasterSatuan_Click(sender As Object, e As EventArgs) Handles mnuMasterSatuan.Click
        UI.usForm.frmOpen(frmMainMstUOM, "frmMstUOM", Me)
    End Sub

    Private Sub mnuMasterTipeAkunPerkiraan_Click(sender As Object, e As EventArgs) Handles mnuMasterTipeAkunPerkiraan.Click
        UI.usForm.frmOpen(frmMainMstChartOfAccountType, "frmMstChartOfAccountType", Me)
    End Sub

    Private Sub mnuMasterGroupAkunPerkiraan_Click(sender As Object, e As EventArgs) Handles mnuMasterGroupAkunPerkiraan.Click
        UI.usForm.frmOpen(frmMainMstChartOfAccountGroup, "frmMstChartOfAccountGroup", Me)
    End Sub

    Private Sub mnuMasterAkunPerkiraan_Click(sender As Object, e As EventArgs) Handles mnuMasterAkunPerkiraan.Click
        UI.usForm.frmOpen(frmMainMstChartOfAccount, "frmMstChartOfAccount", Me)
    End Sub

    Private Sub mnuMasterJenisBarang_Click(sender As Object, e As EventArgs) Handles mnuMasterJenisBarang.Click
        UI.usForm.frmOpen(frmMainMstItemType, "frmMstItemType", Me)
    End Sub

    Private Sub mnuMasterSpesifikasiBarang_Click(sender As Object, e As EventArgs) Handles mnuMasterSpesifikasiBarang.Click
        UI.usForm.frmOpen(frmMainMstItemSpecification, "frmMstItemSpecification", Me)
    End Sub

    Private Sub mnuMasterBarang_Click(sender As Object, e As EventArgs) Handles mnuMasterBarang.Click
        UI.usForm.frmOpen(frmMainMstItem, "frmMstItem", Me)
    End Sub

    Private Sub mnuMasterPersediaan_Click(sender As Object, e As EventArgs) Handles mnuMasterPersediaan.Click
        UI.usForm.frmOpen(frmMainMstStock, "frmMstStock", Me)
    End Sub

    Private Sub mnuMasterRekanBisnis_Click(sender As Object, e As EventArgs) Handles mnuMasterRekanBisnis.Click
        UI.usForm.frmOpen(frmMainBusinessPartner, "frmMstBusinessPartner", Me)
    End Sub

    Private Sub mnuMasterAkunBankPerusahaan_Click(sender As Object, e As EventArgs) Handles mnuMasterAkunBankPerusahaan.Click
        UI.usForm.frmOpen(frmMainMstCompanyBankAccount, "frmMstCompanyBankAccount", Me)
    End Sub

    Private Sub mnuMasterMetodePembayaran_Click(sender As Object, e As EventArgs) Handles mnuMasterMetodePembayaran.Click
        UI.usForm.frmOpen(frmMainMstPaymentMode, "frmMstPaymentMode", Me)
    End Sub

    Private Sub mnuMasterJenisPembayaran_Click(sender As Object, e As EventArgs) Handles mnuMasterJenisPembayaran.Click
        UI.usForm.frmOpen(frmMainMstPaymentType, "frmMstPaymentType", Me)
    End Sub

    Private Sub mnuMasterLokasiPengiriman_Click(sender As Object, e As EventArgs) Handles mnuMasterLokasiPengiriman.Click
        UI.usForm.frmOpen(frmMainMstDeliveryLocation, "frmMstDeliveryLocation", Me)
    End Sub

    Private Sub mnuMasterJenisBiayaTransportasi_Click(sender As Object, e As EventArgs) Handles mnuMasterJenisBiayaTransportasi.Click
        UI.usForm.frmOpen(frmMainMstTransporterPriceType, "frmMstTransporterPriceType", Me)
    End Sub

#End Region

#Region "Transaksi"

#Region "Sales"

    Private Sub mnuTransaksiPenjualanPermintaanPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanPermintaanPenjualan.Click
        'Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraOrderRequest"
        'Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(frmMainTraOrderRequest) Then
        '    If Not frmMainTraOrderRequest.IsDisposed Then
        '        frmMainTraOrderRequest.WindowState = FormWindowState.Normal
        '        frmMainTraOrderRequest.BringToFront()
        '        frmMainTraOrderRequest.WindowState = FormWindowState.Maximized
        '    Else
        '        frmMainTraOrderRequest = Activator.CreateInstance(Type.GetType(s_fT))
        '        frmMainTraOrderRequest.MdiParent = Me
        '        frmMainTraOrderRequest.pubIsStock = False
        '        frmMainTraOrderRequest.Show()
        '    End If
        'Else
        '    frmMainTraOrderRequest = Activator.CreateInstance(Type.GetType(s_fT))
        '    frmMainTraOrderRequest.MdiParent = Me
        '    frmMainTraOrderRequest.pubIsStock = False
        '    frmMainTraOrderRequest.Show()
        'End If
        'Me.Cursor = Cursors.Arrow

        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraOrderRequestVer2"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraOrderRequestVer2) Then
            If Not frmMainTraOrderRequestVer2.IsDisposed Then
                frmMainTraOrderRequestVer2.WindowState = FormWindowState.Normal
                frmMainTraOrderRequestVer2.BringToFront()
                frmMainTraOrderRequestVer2.WindowState = FormWindowState.Maximized
            Else
                frmMainTraOrderRequestVer2 = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraOrderRequestVer2.MdiParent = Me
                frmMainTraOrderRequestVer2.pubIsStock = False
                frmMainTraOrderRequestVer2.Show()
            End If
        Else
            frmMainTraOrderRequestVer2 = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraOrderRequestVer2.MdiParent = Me
            frmMainTraOrderRequestVer2.pubIsStock = False
            frmMainTraOrderRequestVer2.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPenjualanKonfirmasiPesanan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanKonfirmasiPesanan.Click
        UI.usForm.frmOpen(frmMainTraSalesConfirmationOrder, "frmTraSalesConfirmationOrder", Me)
    End Sub

    Private Sub mnuTransaksiPenjualanKontrakPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanKontrakPenjualan.Click
        UI.usForm.frmOpen(frmMainTraSalesContract, "frmTraSalesContract", Me)
    End Sub

    Private Sub mnuTransaksiPenjualanPengirimanPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanPengirimanPenjualan.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraDelivery"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraDelivery) Then
            If Not frmMainTraDelivery.IsDisposed Then
                frmMainTraDelivery.WindowState = FormWindowState.Normal
                frmMainTraDelivery.BringToFront()
                frmMainTraDelivery.WindowState = FormWindowState.Maximized
            Else
                frmMainTraDelivery = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraDelivery.MdiParent = Me
                frmMainTraDelivery.pubIsStock = False
                frmMainTraDelivery.Show()
            End If
        Else
            frmMainTraDelivery = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraDelivery.MdiParent = Me
            frmMainTraDelivery.pubIsStock = False
            frmMainTraDelivery.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPenjualanReturPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanReturPenjualan.Click
        UI.usForm.frmOpen(frmMainTraSalesReturn, "frmTraSalesReturn", Me)
    End Sub

    Private Sub mnuTransaksiPenjualanPengajuanKlaim_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanPengajuanKlaim.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraClaim"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraClaimSales) Then
            If Not frmMainTraClaimSales.IsDisposed Then
                frmMainTraClaimSales.WindowState = FormWindowState.Normal
                frmMainTraClaimSales.BringToFront()
                frmMainTraClaimSales.WindowState = FormWindowState.Maximized
                frmMainTraClaimSales.pubClaimType = VO.Claim.ClaimTypeValue.Sales
            Else
                frmMainTraClaimSales = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraClaimSales.MdiParent = Me
                frmMainTraClaimSales.pubClaimType = VO.Claim.ClaimTypeValue.Sales
                frmMainTraClaimSales.Show()
            End If
        Else
            frmMainTraClaimSales = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraClaimSales.MdiParent = Me
            frmMainTraClaimSales.pubClaimType = VO.Claim.ClaimTypeValue.Sales
            frmMainTraClaimSales.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPenjualanKonfirmasiKlaim_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanKonfirmasiKlaim.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraConfirmationClaim"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraConfirmationClaimSales) Then
            If Not frmMainTraConfirmationClaimSales.IsDisposed Then
                frmMainTraConfirmationClaimSales.WindowState = FormWindowState.Normal
                frmMainTraConfirmationClaimSales.BringToFront()
                frmMainTraConfirmationClaimSales.WindowState = FormWindowState.Maximized
                frmMainTraConfirmationClaimSales.pubClaimType = VO.Claim.ClaimTypeValue.Sales
            Else
                frmMainTraConfirmationClaimSales = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraConfirmationClaimSales.MdiParent = Me
                frmMainTraConfirmationClaimSales.pubClaimType = VO.Claim.ClaimTypeValue.Sales
                frmMainTraConfirmationClaimSales.Show()
            End If
        Else
            frmMainTraConfirmationClaimSales = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraConfirmationClaimSales.MdiParent = Me
            frmMainTraConfirmationClaimSales.pubClaimType = VO.Claim.ClaimTypeValue.Sales
            frmMainTraConfirmationClaimSales.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

#Region "Sales Stock"

    Private Sub mnuTransaksiPenjualanStockPermintaanPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanStockPermintaanPenjualan.Click
        'Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraOrderRequest"
        'Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(frmMainTraOrderRequestStock) Then
        '    If Not frmMainTraOrderRequestStock.IsDisposed Then
        '        frmMainTraOrderRequestStock.WindowState = FormWindowState.Normal
        '        frmMainTraOrderRequestStock.BringToFront()
        '        frmMainTraOrderRequestStock.WindowState = FormWindowState.Maximized
        '    Else
        '        frmMainTraOrderRequestStock = Activator.CreateInstance(Type.GetType(s_fT))
        '        frmMainTraOrderRequestStock.MdiParent = Me
        '        frmMainTraOrderRequestStock.pubIsStock = True
        '        frmMainTraOrderRequestStock.Show()
        '    End If
        'Else
        '    frmMainTraOrderRequestStock = Activator.CreateInstance(Type.GetType(s_fT))
        '    frmMainTraOrderRequestStock.MdiParent = Me
        '    frmMainTraOrderRequestStock.pubIsStock = True
        '    frmMainTraOrderRequestStock.Show()
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPenjualanStockPengirimanPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanStockPengirimanPenjualan.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraDelivery"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraDeliveryStock) Then
            If Not frmMainTraDeliveryStock.IsDisposed Then
                frmMainTraDeliveryStock.WindowState = FormWindowState.Normal
                frmMainTraDeliveryStock.BringToFront()
                frmMainTraDeliveryStock.WindowState = FormWindowState.Maximized
            Else
                frmMainTraDeliveryStock = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraDeliveryStock.MdiParent = Me
                frmMainTraDeliveryStock.pubIsStock = True
                frmMainTraDeliveryStock.Show()
            End If
        Else
            frmMainTraDeliveryStock = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraDeliveryStock.MdiParent = Me
            frmMainTraDeliveryStock.pubIsStock = True
            frmMainTraDeliveryStock.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

#Region "Sales Service"

    Private Sub mnuTransaksiPenjualanJasaPengiriman_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanJasaPengiriman.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraSalesService"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraSalesServiceTransport) Then
            If Not frmMainTraSalesServiceTransport.IsDisposed Then
                frmMainTraSalesServiceTransport.WindowState = FormWindowState.Normal
                frmMainTraSalesServiceTransport.BringToFront()
                frmMainTraSalesServiceTransport.WindowState = FormWindowState.Maximized
            Else
                frmMainTraSalesServiceTransport = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraSalesServiceTransport.MdiParent = Me
                frmMainTraSalesServiceTransport.pubServiceType = VO.ServiceType.Value.Transport
                frmMainTraSalesServiceTransport.Show()
            End If
        Else
            frmMainTraSalesServiceTransport = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraSalesServiceTransport.MdiParent = Me
            frmMainTraSalesServiceTransport.pubServiceType = VO.ServiceType.Value.Transport
            frmMainTraSalesServiceTransport.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

#Region "Purchase"

    Private Sub mnuTransaksiPembelianPesananPembelian_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianPesananPembelian.Click
        UI.usForm.frmOpen(frmMainTraPurchaseOrder, "frmTraPurchaseOrder", Me)
    End Sub

    Private Sub mnuTransaksiPembelianKonfirmasiPesanan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianKonfirmasiPesanan.Click
        UI.usForm.frmOpen(frmMainTraConfirmationOrder, "frmTraConfirmationOrder", Me)
    End Sub

    Private Sub mnuTransaksiPembelianKontrakPembelian_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianKontrakPembelian.Click
        UI.usForm.frmOpen(frmMainTraPurchaseContract, "frmTraPurchaseContract", Me)
    End Sub

    Private Sub mnuTransaksiPembelianPenerimaanPembelian_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianPenerimaanPembelian.Click
        UI.usForm.frmOpen(frmMainTraReceive, "frmTraReceive", Me)
    End Sub

    Private Sub mnuTransaksiPembelianSPKPotong_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianSPKPotong.Click
        UI.usForm.frmOpen(frmMainTraPurchaseOrderCutting, "frmTraPurchaseOrderCutting", Me)
    End Sub

    Private Sub mnuTransaksiPembelianProsesPemotongan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianProsesPemotongan.Click
        UI.usForm.frmOpen(frmMainTraCutting, "frmTraCutting", Me)
    End Sub

    Private Sub mnuTransaksiPembelianPengajuanKlaim_Click_1(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianPengajuanKlaim.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraClaim"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraClaimPurchase) Then
            If Not frmMainTraClaimPurchase.IsDisposed Then
                frmMainTraClaimPurchase.WindowState = FormWindowState.Normal
                frmMainTraClaimPurchase.BringToFront()
                frmMainTraClaimPurchase.WindowState = FormWindowState.Maximized
                frmMainTraClaimPurchase.pubClaimType = VO.Claim.ClaimTypeValue.Receive
            Else
                frmMainTraClaimPurchase = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraClaimPurchase.MdiParent = Me
                frmMainTraClaimPurchase.pubClaimType = VO.Claim.ClaimTypeValue.Receive
                frmMainTraClaimPurchase.Show()
            End If
        Else
            frmMainTraClaimPurchase = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraClaimPurchase.MdiParent = Me
            frmMainTraClaimPurchase.pubClaimType = VO.Claim.ClaimTypeValue.Receive
            frmMainTraClaimPurchase.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembelianKonfirmasiKlaim_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianKonfirmasiKlaim.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraConfirmationClaim"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraConfirmationClaimPurchase) Then
            If Not frmMainTraConfirmationClaimPurchase.IsDisposed Then
                frmMainTraConfirmationClaimPurchase.WindowState = FormWindowState.Normal
                frmMainTraConfirmationClaimPurchase.BringToFront()
                frmMainTraConfirmationClaimPurchase.WindowState = FormWindowState.Maximized
                frmMainTraConfirmationClaimPurchase.pubClaimType = VO.Claim.ClaimTypeValue.Receive
            Else
                frmMainTraConfirmationClaimPurchase = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraConfirmationClaimPurchase.MdiParent = Me
                frmMainTraConfirmationClaimPurchase.pubClaimType = VO.Claim.ClaimTypeValue.Receive
                frmMainTraConfirmationClaimPurchase.Show()
            End If
        Else
            frmMainTraConfirmationClaimPurchase = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraConfirmationClaimPurchase.MdiParent = Me
            frmMainTraConfirmationClaimPurchase.pubClaimType = VO.Claim.ClaimTypeValue.Receive
            frmMainTraConfirmationClaimPurchase.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

#Region "Pembukuan"

    Private Sub mnuTransaksiPembukuanPembayaranHutangPesananPemotongan_Click(sender As Object, e As EventArgs)
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableReceivePaymentCutting) Then
            If Not frmMainTraAccountPayableReceivePaymentCutting.IsDisposed Then
                frmMainTraAccountPayableReceivePaymentCutting.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableReceivePaymentCutting.BringToFront()
                frmMainTraAccountPayableReceivePaymentCutting.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableReceivePaymentCutting = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableReceivePaymentCutting.MdiParent = Me
                frmMainTraAccountPayableReceivePaymentCutting.pubModules = VO.AccountPayable.ReceivePaymentCutting
                frmMainTraAccountPayableReceivePaymentCutting.Show()
            End If
        Else
            frmMainTraAccountPayableReceivePaymentCutting = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableReceivePaymentCutting.MdiParent = Me
            frmMainTraAccountPayableReceivePaymentCutting.pubModules = VO.AccountPayable.ReceivePaymentCutting
            frmMainTraAccountPayableReceivePaymentCutting.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranHutangPesananPengiriman_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranBiayaTransportasi.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAPCost"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableReceivePaymentTransport) Then
            If Not frmMainTraAccountPayableReceivePaymentTransport.IsDisposed Then
                frmMainTraAccountPayableReceivePaymentTransport.pubModules = VO.AccountPayable.ReceivePaymentTransport
                frmMainTraAccountPayableReceivePaymentTransport.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableReceivePaymentTransport.BringToFront()
                frmMainTraAccountPayableReceivePaymentTransport.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableReceivePaymentTransport = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableReceivePaymentTransport.MdiParent = Me
                frmMainTraAccountPayableReceivePaymentTransport.pubModules = VO.AccountPayable.ReceivePaymentTransport
                frmMainTraAccountPayableReceivePaymentTransport.Show()
            End If
        Else
            frmMainTraAccountPayableReceivePaymentTransport = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableReceivePaymentTransport.MdiParent = Me
            frmMainTraAccountPayableReceivePaymentTransport.pubModules = VO.AccountPayable.ReceivePaymentTransport
            frmMainTraAccountPayableReceivePaymentTransport.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranBiayaPotong_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranBiayaPotong.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAPCost"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableReceivePaymentCutting) Then
            If Not frmMainTraAccountPayableReceivePaymentCutting.IsDisposed Then
                frmMainTraAccountPayableReceivePaymentCutting.pubModules = VO.AccountPayable.ReceivePaymentCutting
                frmMainTraAccountPayableReceivePaymentCutting.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableReceivePaymentCutting.BringToFront()
                frmMainTraAccountPayableReceivePaymentCutting.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableReceivePaymentCutting = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableReceivePaymentCutting.MdiParent = Me
                frmMainTraAccountPayableReceivePaymentCutting.pubModules = VO.AccountPayable.ReceivePaymentCutting
                frmMainTraAccountPayableReceivePaymentCutting.Show()
            End If
        Else
            frmMainTraAccountPayableReceivePaymentCutting = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableReceivePaymentCutting.MdiParent = Me
            frmMainTraAccountPayableReceivePaymentCutting.pubModules = VO.AccountPayable.ReceivePaymentCutting
            frmMainTraAccountPayableReceivePaymentCutting.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaran_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaran.Click
        'UI.usForm.frmOpen(frmMainTraAccountPayable, "frmTraAccountPayable", Me)
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraARAP"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraARAPPayable) Then
            If Not frmMainTraARAPPayable.IsDisposed Then
                frmMainTraARAPPayable.pubARAPType = VO.ARAP.ARAPTypeValue.Purchase
                frmMainTraARAPPayable.pubModules = VO.AccountPayable.All
                frmMainTraARAPPayable.pubIsControlARAP = True
                frmMainTraARAPReceivable.pubIsGenerate = 0
                frmMainTraARAPPayable.WindowState = FormWindowState.Normal
                frmMainTraARAPPayable.BringToFront()
                frmMainTraARAPPayable.WindowState = FormWindowState.Maximized
            Else
                frmMainTraARAPPayable = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraARAPPayable.MdiParent = Me
                frmMainTraARAPPayable.pubARAPType = VO.ARAP.ARAPTypeValue.Purchase
                frmMainTraARAPPayable.pubModules = VO.AccountPayable.All
                frmMainTraARAPPayable.pubIsControlARAP = True
                frmMainTraARAPReceivable.pubIsGenerate = 0
                frmMainTraARAPPayable.Show()
            End If
        Else
            frmMainTraARAPPayable = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraARAPPayable.MdiParent = Me
            frmMainTraARAPPayable.pubARAPType = VO.ARAP.ARAPTypeValue.Purchase
            frmMainTraARAPPayable.pubModules = VO.AccountPayable.All
            frmMainTraARAPPayable.pubIsControlARAP = True
            frmMainTraARAPPayable.pubIsGenerate = 0
            frmMainTraARAPPayable.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPelunasan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPelunasan.Click
        'UI.usForm.frmOpen(frmMainTraAccountReceivable, "frmTraAccountReceivable", Me)
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraARAP"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraARAPReceivable) Then
            If Not frmMainTraARAPReceivable.IsDisposed Then
                frmMainTraARAPReceivable.pubARAPType = VO.ARAP.ARAPTypeValue.Sales
                frmMainTraARAPReceivable.pubModules = VO.AccountReceivable.All
                frmMainTraARAPReceivable.pubIsControlARAP = True
                frmMainTraARAPReceivable.pubIsGenerate = 0
                frmMainTraARAPReceivable.WindowState = FormWindowState.Normal
                frmMainTraARAPReceivable.BringToFront()
                frmMainTraARAPReceivable.WindowState = FormWindowState.Maximized
            Else
                frmMainTraARAPReceivable = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraARAPReceivable.MdiParent = Me
                frmMainTraARAPReceivable.pubARAPType = VO.ARAP.ARAPTypeValue.Sales
                frmMainTraARAPReceivable.pubModules = VO.AccountReceivable.All
                frmMainTraARAPReceivable.pubIsControlARAP = True
                frmMainTraARAPReceivable.pubIsGenerate = 0
                frmMainTraARAPReceivable.Show()
            End If
        Else
            frmMainTraARAPReceivable = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraARAPReceivable.MdiParent = Me
            frmMainTraARAPReceivable.pubARAPType = VO.ARAP.ARAPTypeValue.Sales
            frmMainTraARAPReceivable.pubModules = VO.AccountReceivable.All
            frmMainTraARAPReceivable.pubIsControlARAP = True
            frmMainTraARAPReceivable.pubIsGenerate = 0
            frmMainTraARAPReceivable.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranBiaya_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranBiaya.Click
        UI.usForm.frmOpen(frmMainTraCost, "frmTraCost", Me)
    End Sub

    Private Sub mnuTransaksiPembukuanKasBankVoucher_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanKasBankVoucher.Click
        UI.usForm.frmOpen(frmMainTraARAPVoucher, "frmTraARAPVoucher", Me)
    End Sub

    Private Sub mnuTransaksiPembukuanJurnalUmum_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanJurnalUmum.Click
        UI.usForm.frmOpen(frmMainTraJournal, "frmTraJournal", Me)
    End Sub

    Private Sub mnuTransaksiPembukuanJurnalUmumAutoGenerate_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanJurnalUmumAutoGenerate.Click
        UI.usForm.frmOpen(frmMainTraJournalAutoGenerate, "frmTraJournalAutoGenerate", Me)
    End Sub

#End Region

#End Region

#Region "Laporan"

    Private Sub mnuLaporanTransaksiBarang_Click(sender As Object, e As EventArgs) Handles mnuLaporanTransaksiBarang.Click
        UI.usForm.frmOpen(frmMainRptMonitoringProductTransactionVer00, "frmRptMonitoringProductTransactionVer00", Me)
    End Sub

    Private Sub mnuLaporanPembukuanKartuHutang_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanKartuHutang.Click
        UI.usForm.frmOpen(frmMainRptKartuHutangVer00, "frmRptKartuHutangVer00", Me)
    End Sub

    Private Sub mnuLaporanPembukuanKartuPiutang_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanKartuPiutang.Click
        UI.usForm.frmOpen(frmMainRptKartuPiutangVer00, "frmRptKartuPiutangVer00", Me)
    End Sub

    Private Sub mnuLaporanPembukuanBukuBesar_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanBukuBesar.Click
        UI.usForm.frmOpen(frmMainRptBukuBesarVer00, "frmRptBukuBesarVer00", Me)
    End Sub

    Private Sub mnuLaporanPembukuanNeracaSaldo_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanNeracaSaldo.Click
        UI.usForm.frmOpen(frmMainRptNeracaSaldoVer00, "frmRptNeracaSaldoVer00", Me)
    End Sub

    Private Sub mnuLaporanPembukuanLabaRugi_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanLabaRugi.Click
        UI.usForm.frmOpen(frmMainRptLabaRugiVer00, "frmRptLabaRugiVer00", Me)
    End Sub

    Private Sub mnuLaporanPembukuanNeraca_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanNeraca.Click
        UI.usForm.frmOpen(frmMainRptNeracaVer00, "frmRptNeracaVer00", Me)
    End Sub

    Private Sub mnuLaporanPembelianSPKPotong_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembelianSPKPotong.Click
        UI.usForm.frmOpen(frmMainRptListPOCuttingVer00, "frmRptListPOCuttingVer00", Me)
    End Sub

    Private Sub mnuLaporanPembukuanPIPenjualan_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanPIPenjualan.Click
        UI.usForm.frmOpen(frmMainRptPIWithSizeReportVer00, "frmRptPIWithSizeReportVer00", Me)
    End Sub

    Private Sub mnuLaporanPenjualanKonfirmasiPesanan_Click(sender As Object, e As EventArgs) Handles mnuLaporanPenjualanKonfirmasiPesanan.Click
        UI.usForm.frmOpen(frmMainRptSalesConfirmationOrderReportVer00, "frmRptSalesConfirmationOrderReportVer00", Me)
    End Sub

#End Region

#Region "Setting"

    Private Sub mnuSettingUbahPassword_Click(sender As Object, e As EventArgs) Handles mnuSettingUbahPassword.Click
        UI.usForm.frmOpen(frmMainSysChangePassword, "frmSysChangePassword", Me)
    End Sub

    Private Sub mnuPengaturanSetupPostingJurnalTransaksi_Click(sender As Object, e As EventArgs) Handles mnuPengaturanSetupPostingJurnalTransaksi.Click
        UI.usForm.frmOpen(frmMainSysJournalPost, "frmSysJournalPost", Me)
    End Sub

#End Region

#Region "Windows"

    Private Sub mnuWindowsVertical_Click(sender As Object, e As EventArgs) Handles mnuWindowsVertical.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuWindowsHorizontal_Click(sender As Object, e As EventArgs) Handles mnuWindowsHorizontal.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuWindowsCascade_Click(sender As Object, e As EventArgs) Handles mnuWindowsCascade.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuWindowsCloseAll_Click(sender As Object, e As EventArgs) Handles mnuWindowsCloseAll.Click
        For Each Form As Form In Me.MdiChildren
            Form.Close()
        Next
    End Sub

#End Region

    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        If Not UI.usForm.frmAskQuestion("Keluar dari program?") Then Exit Sub
        Application.Exit()
    End Sub

End Class