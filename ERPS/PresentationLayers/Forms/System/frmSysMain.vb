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

    '## Purchase
    Dim frmMainTraPurchaseOrder As frmTraPurchaseOrder
    Dim frmMainTraConfirmationOrder As frmTraConfirmationOrder
    Dim frmMainTraPurchaseContract As frmTraPurchaseContract
    Dim frmMainTraReceive As frmTraReceive
    Dim frmMainTraPurchaseOrderCutting As frmTraPurchaseOrderCutting
    Dim frmMainTraCutting As frmTraCutting
    Dim frmMainTraPurchaseOrderTransport As frmTraPurchaseOrderTransport
    Dim frmMainTraClaimPurchase As frmTraClaim
    Dim frmMainTraConfirmationClaimPurchase As frmTraConfirmationClaim

    '## Pembukuan
    Dim frmMainTraAccountReceivableSetupBalance As frmTraAccountReceivable
    Dim frmMainTraAccountReceivableDPManual As frmTraAccountReceivable
    Dim frmMainTraAccountReceivableDP As frmTraAccountReceivable
    Dim frmMainTraAccountReceivable As frmTraAccountReceivable

    Dim frmMainTraAccountPayableSetupBalance As frmTraAccountPayable
    Dim frmMainTraAccountPayableDPManual As frmTraAccountPayable
    Dim frmMainTraAccountPayableDP As frmTraAccountPayable
    Dim frmMainTraAccountPayableReceivePayment As frmTraAccountPayable
    Dim frmMainTraAccountPayableDPCutting As frmTraAccountPayable
    Dim frmMainTraAccountPayableDPTransport As frmTraAccountPayable
    Dim frmMainTraAccountPayableReceivePaymentTransport As frmTraAPCost
    Dim frmMainTraAccountPayableReceivePaymentCutting As frmTraAPCost
    Dim frmMainTraARAPPayable As frmTraARAP
    Dim frmMainTraARAPReceivable As frmTraARAP

    Dim frmMainTraAccountPayable As frmTraAccountPayable

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
        ssBuildDate.Text = "Build : 18/03/2025 18:18"
    End Sub

    Private Sub prvUserAccess()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        '# Master
        mnuMasterProgram.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterProgram, VO.Access.Values.ViewAccess)
        mnuMasterStatus.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterStatus, VO.Access.Values.ViewAccess)
        mnuMasterModule.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterModule, VO.Access.Values.ViewAccess)
        mnuMasterAkses.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterAccess, VO.Access.Values.ViewAccess)
        mnuMasterPerusahaan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterCompany, VO.Access.Values.ViewAccess)
        mnuMasterKaryawan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterUser, VO.Access.Values.ViewAccess)
        mnuMasterTipeAkunPerkiraan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterChartOfAccountType, VO.Access.Values.ViewAccess)
        mnuMasterGroupAkunPerkiraan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterChartOfAccountGroup, VO.Access.Values.ViewAccess)
        mnuMasterPaymentTypeCategory.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterPaymentTypeCategory, VO.Access.Values.ViewAccess)
        mnuMasterMetodePembayaran.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterPaymentMode, VO.Access.Values.ViewAccess)
        mnuMasterJenisPembayaran.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterPaymentType, VO.Access.Values.ViewAccess)
        mnuMasterSatuan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterUOM, VO.Access.Values.ViewAccess)

        mnuMasterAkunPerkiraan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterChartOfAccount, VO.Access.Values.ViewAccess)
        mnuMasterJenisBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItemType, VO.Access.Values.ViewAccess)
        mnuMasterSpesifikasiBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItemSpecification, VO.Access.Values.ViewAccess)
        mnuMasterBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItem, VO.Access.Values.ViewAccess)
        mnuMasterRekanBisnis.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterBusinessPartner, VO.Access.Values.ViewAccess)
        mnuMasterAkunBankPerusahaan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterCompanyBankAccount, VO.Access.Values.ViewAccess)

        pgMain.Value = 50


        '# Transaction
        '## Sales
        mnuTransaksiPenjualanPermintaanPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.ViewAccess)
        mnuTransaksiPenjualanKontrakPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.ViewAccess) 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.ViewAccess)
        mnuTransaksiPenjualanPengirimanPenjualan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.ViewAccess) 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.ViewAccess)

        'mnuTransaksiPenjualanMemoPengambilan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPickupMemo, VO.Access.Values.ViewAccess)

        '## Purchase
        mnuTransaksiPembelianPesananPembelian.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseOrder, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianKonfirmasiPesanan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionConfirmationOrder, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianKontrakPembelian.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseContract, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianPenerimaanPembelian.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembelianPesananPemotongan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, VO.Access.Values.ViewAccess) 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseOrderCutting, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembelianProsesPemotongan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, VO.Access.Values.ViewAccess) 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCuttingProcess, VO.Access.Values.ViewAccess)
        ''mnuTransaksiPembelianPesananPengiriman.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, VO.Access.Values.ViewAccess) 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseOrderTransport, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianPesananPengiriman.Visible = False
        'mnuTransaksiPembelianSep2.Visible = False

        'mnuTransaksiPembelianInstruksi.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionInstructionLetter, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembelianKonfirmasiPengiriman.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionConfirmationDelivery, VO.Access.Values.ViewAccess)

        '## Pembukuan
        mnuTransaksiPembukuanPelunasanSaldoAwal.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountReceivableBalance, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPembayaranSaldoAwal.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayableBalance, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanSep1.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayableBalance, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPanjarPenjualanManual.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDPManual, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPanjarPembelianManual.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseDPManual, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanSep2.Visible = False
        mnuTransaksiPembukuanPanjarPenjualan.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDP, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPanjarPembelian.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseDP, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanSep3.Visible = False
        mnuTransaksiPembukuanPelunasanPiutangPenjualan.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountReceivable, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPembayaranHutangPembelian.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayable, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanSep4.Visible = False
        mnuTransaksiPembukuanPanjarPesananPemotongan.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseDPCutting, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPembayaranHutangPesananPemotongan.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayableCutting, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanSep5.Visible = False
        mnuTransaksiPembukuanPanjarPesananPengiriman.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseDPTransport, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembukuanPembayaranBiayaTransportasi.Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayableTransport, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanSep6.Visible = False
        'mnuTransaksiPembukuanPembayaranBiaya.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCost, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembukuanJurnalUmum.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionJournal, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembukuanJurnalUmum.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionJournal, -1)

        '# Laporan
        mnuLaporanTransaksiBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Values.ReportTransaksiBarang, VO.Access.Values.ViewAccess)

        '## Pembukuan
        'mnuLaporanPembukuanBukuBesar.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Values.ReportBukuBesar, VO.Access.Values.ViewAccess)
        'mnuLaporanPembukuanNeracaSaldo.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Values.ReportNeracaSaldo, VO.Access.Values.ViewAccess)
        'mnuLaporanPembukuanLabaRugi.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Values.ReportProfitAndLoss, VO.Access.Values.ViewAccess)
        'mnuLaporanPembukuanNeraca.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Values.ReportBalanceSheet, VO.Access.Values.ViewAccess)

        '# Tidak bisa dipakai, ItemID Receive dengan ItemID Delivery berbeda sehingga tidak bisa cross total berat
        mnuMasterPersediaan.Visible = False
        'mnuTransaksiPembukuanPembayaranBiayaTransportasi.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, VO.Access.Values.ViewAccess)
        Me.Cursor = Cursors.Default
        pgMain.Visible = False
        mnuTransaksiPenjualanStock.Visible = False
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
        'UI.usForm.frmOpen(frmMainSysOutstandingARAP, "frmSysOutstandingARAP", Me)
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

    Private Sub mnuTransaksiPembelianPesananPengiriman_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianPesananPengiriman.Click
        UI.usForm.frmOpen(frmMainTraPurchaseOrderTransport, "frmTraPurchaseOrderTransport", Me)
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

    Private Sub mnuTransaksiPembukuanPelunasanSaldoAwal_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPelunasanSaldoAwal.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountReceivable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountReceivableSetupBalance) Then
            If Not frmMainTraAccountReceivableSetupBalance.IsDisposed Then
                frmMainTraAccountReceivableSetupBalance.WindowState = FormWindowState.Normal
                frmMainTraAccountReceivableSetupBalance.BringToFront()
                frmMainTraAccountReceivableSetupBalance.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountReceivableSetupBalance = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountReceivableSetupBalance.MdiParent = Me
                frmMainTraAccountReceivableSetupBalance.pubModules = "SB"
                frmMainTraAccountReceivableSetupBalance.Show()
            End If
        Else
            frmMainTraAccountReceivableSetupBalance = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountReceivableSetupBalance.MdiParent = Me
            frmMainTraAccountReceivableSetupBalance.pubModules = "SB"
            frmMainTraAccountReceivableSetupBalance.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranSaldoAwal_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranSaldoAwal.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableSetupBalance) Then
            If Not frmMainTraAccountPayableSetupBalance.IsDisposed Then
                frmMainTraAccountPayableSetupBalance.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableSetupBalance.BringToFront()
                frmMainTraAccountPayableSetupBalance.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableSetupBalance = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableSetupBalance.MdiParent = Me
                frmMainTraAccountPayableSetupBalance.pubModules = VO.AccountPayable.PurchaseBalance
                frmMainTraAccountPayableSetupBalance.Show()
            End If
        Else
            frmMainTraAccountPayableSetupBalance = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableSetupBalance.MdiParent = Me
            frmMainTraAccountPayableSetupBalance.pubModules = VO.AccountPayable.PurchaseBalance
            frmMainTraAccountPayableSetupBalance.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPanjarPenjualanManual_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPenjualanManual.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountReceivable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountReceivableDPManual) Then
            If Not frmMainTraAccountReceivableDPManual.IsDisposed Then
                frmMainTraAccountReceivableDPManual.WindowState = FormWindowState.Normal
                frmMainTraAccountReceivableDPManual.BringToFront()
                frmMainTraAccountReceivableDPManual.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountReceivableDPManual = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountReceivableDPManual.MdiParent = Me
                frmMainTraAccountReceivableDPManual.pubModules = "SDM"
                frmMainTraAccountReceivableDPManual.Show()
            End If
        Else
            frmMainTraAccountReceivableDPManual = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountReceivableDPManual.MdiParent = Me
            frmMainTraAccountReceivableDPManual.pubModules = "SDM"
            frmMainTraAccountReceivableDPManual.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPanjarPembelianManual_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPembelianManual.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableDPManual) Then
            If Not frmMainTraAccountPayableDPManual.IsDisposed Then
                frmMainTraAccountPayableDPManual.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableDPManual.BringToFront()
                frmMainTraAccountPayableDPManual.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableDPManual = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableDPManual.MdiParent = Me
                frmMainTraAccountPayableDPManual.pubModules = VO.AccountPayable.DownPaymentManual
                frmMainTraAccountPayableDPManual.Show()
            End If
        Else
            frmMainTraAccountPayableDPManual = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableDPManual.MdiParent = Me
            frmMainTraAccountPayableDPManual.pubModules = VO.AccountPayable.DownPaymentManual
            frmMainTraAccountPayableDPManual.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPanjarPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPenjualan.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountReceivable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountReceivableDP) Then
            If Not frmMainTraAccountReceivableDP.IsDisposed Then
                frmMainTraAccountReceivableDP.WindowState = FormWindowState.Normal
                frmMainTraAccountReceivableDP.BringToFront()
                frmMainTraAccountReceivableDP.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountReceivableDP = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountReceivableDP.MdiParent = Me
                frmMainTraAccountReceivableDP.pubModules = VO.AccountReceivable.DownPayment
                frmMainTraAccountReceivableDP.Show()
            End If
        Else
            frmMainTraAccountReceivableDP = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountReceivableDP.MdiParent = Me
            frmMainTraAccountReceivableDP.pubModules = VO.AccountReceivable.DownPayment
            frmMainTraAccountReceivableDP.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPanjarPembelian_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPembelian.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableDP) Then
            If Not frmMainTraAccountPayableDP.IsDisposed Then
                frmMainTraAccountPayableDP.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableDP.BringToFront()
                frmMainTraAccountPayableDP.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableDP = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableDP.MdiParent = Me
                frmMainTraAccountPayableDP.pubModules = VO.AccountPayable.DownPayment
                frmMainTraAccountPayableDP.Show()
            End If
        Else
            frmMainTraAccountPayableDP = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableDP.MdiParent = Me
            frmMainTraAccountPayableDP.pubModules = VO.AccountPayable.DownPayment
            frmMainTraAccountPayableDP.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPelunasanPiutangPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPelunasanPiutangPenjualan.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountReceivable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountReceivable) Then
            If Not frmMainTraAccountReceivable.IsDisposed Then
                frmMainTraAccountReceivable.WindowState = FormWindowState.Normal
                frmMainTraAccountReceivable.BringToFront()
                frmMainTraAccountReceivable.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountReceivable = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountReceivable.MdiParent = Me
                frmMainTraAccountReceivable.pubModules = VO.AccountReceivable.ReceivePayment
                frmMainTraAccountReceivable.Show()
            End If
        Else
            frmMainTraAccountReceivable = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountReceivable.MdiParent = Me
            frmMainTraAccountReceivable.pubModules = VO.AccountReceivable.ReceivePayment
            frmMainTraAccountReceivable.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranHutangPembelian_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranHutangPembelian.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableReceivePayment) Then
            If Not frmMainTraAccountPayableReceivePayment.IsDisposed Then
                frmMainTraAccountPayableReceivePayment.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableReceivePayment.BringToFront()
                frmMainTraAccountPayableReceivePayment.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableReceivePayment = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableReceivePayment.MdiParent = Me
                frmMainTraAccountPayableReceivePayment.pubModules = VO.AccountPayable.ReceivePayment
                frmMainTraAccountPayableReceivePayment.Show()
            End If
        Else
            frmMainTraAccountPayableReceivePayment = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableReceivePayment.MdiParent = Me
            frmMainTraAccountPayableReceivePayment.pubModules = VO.AccountPayable.ReceivePayment
            frmMainTraAccountPayableReceivePayment.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPanjarPesananPemotongan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPesananPemotongan.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableDPCutting) Then
            If Not frmMainTraAccountPayableDPCutting.IsDisposed Then
                frmMainTraAccountPayableDPCutting.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableDPCutting.BringToFront()
                frmMainTraAccountPayableDPCutting.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableDPCutting = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableDPCutting.MdiParent = Me
                frmMainTraAccountPayableDPCutting.pubModules = VO.AccountPayable.DownPaymentCutting
                frmMainTraAccountPayableDPCutting.Show()
            End If
        Else
            frmMainTraAccountPayableDPCutting = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableDPCutting.MdiParent = Me
            frmMainTraAccountPayableDPCutting.pubModules = VO.AccountPayable.DownPaymentCutting
            frmMainTraAccountPayableDPCutting.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranHutangPesananPemotongan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranHutangPesananPemotongan.Click
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

    Private Sub mnuTransaksiPembukuanPanjarPesananPengiriman_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPesananPengiriman.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayableDPTransport) Then
            If Not frmMainTraAccountPayableDPTransport.IsDisposed Then
                frmMainTraAccountPayableDPTransport.WindowState = FormWindowState.Normal
                frmMainTraAccountPayableDPTransport.BringToFront()
                frmMainTraAccountPayableDPTransport.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayableDPTransport = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayableDPTransport.MdiParent = Me
                frmMainTraAccountPayableDPTransport.pubModules = VO.AccountPayable.DownPaymentTransport
                frmMainTraAccountPayableDPTransport.Show()
            End If
        Else
            frmMainTraAccountPayableDPTransport = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayableDPTransport.MdiParent = Me
            frmMainTraAccountPayableDPTransport.pubModules = VO.AccountPayable.DownPaymentTransport
            frmMainTraAccountPayableDPTransport.Show()
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
        UI.usForm.frmOpen(frmMainRptListPOCuttingVer00, "frmRptListPOCutting", Me)
    End Sub

    Private Sub mnuLaporanPembukuanPIPenjualan_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanPIPenjualan.Click
        UI.usForm.frmOpen(frmMainRptPIWithSizeReportVer00, "frmRptPIWithSizeReport", Me)
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