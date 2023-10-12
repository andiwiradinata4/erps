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
    Dim frmMainBusinessPartner As frmMstBusinessPartner
    Dim frmMainMstCompanyBankAccount As frmMstCompanyBankAccount
    Dim frmMainMstPaymentTypeCategory As frmMstPaymentTypeCategory
    Dim frmMainMstPaymentMode As frmMstPaymentMode
    Dim frmMainMstPaymentType As frmMstPaymentType

    '# Transaction
    '## Sales
    Dim frmMainTraOrderRequest As frmTraOrderRequest


    '## Purchase
    Dim frmMainTraPurchaseOrder As frmTraPurchaseOrder
    Dim frmMainTraPurchaseOrderCutting As frmTraPurchaseOrderCutting
    Dim frmMainTraConfirmationOrder As frmTraConfirmationOrder
    Dim frmMainTraPurchaseContract As frmTraPurchaseContract

    '## Pembukuan
    Dim frmMainTraJournal As frmTraJournal
    Dim frmMainTraAccountReceivable As frmTraAccountReceivable
    Dim frmMainTraAccountPayable As frmTraAccountPayable
    Dim frmMainTraCost As frmTraCost


    '# Laporan
    '## Pembukuan
    Dim frmMainRptBukuBesarVer00 As frmRptBukuBesarVer00


    '# Setting
    Dim frmMainSysChangePassword As frmSysChangePassword


    Private Sub prvSetupStatusStrip()
        tssUserID.Text = ERPSLib.UI.usUserApp.UserID
        tssVersion.Text = "Versi: " & FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion
        tssProgram.Text = ERPSLib.UI.usUserApp.ProgramName
        tssCompany.Text = ERPSLib.UI.usUserApp.CompanyName
        tssServer.Text = ERPSLib.UI.usUserApp.ServerName
    End Sub

    Private Sub prvUserAccess()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()

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

        mnuMasterAkunPerkiraan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterChartOfAccount, VO.Access.Values.ViewAccess)
        mnuMasterJenisBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItemType, VO.Access.Values.ViewAccess)
        mnuMasterSpesifikasiBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItemSpecification, VO.Access.Values.ViewAccess)
        mnuMasterBarang.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItem, VO.Access.Values.ViewAccess)
        mnuMasterRekanBisnis.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterBusinessPartner, VO.Access.Values.ViewAccess)
        mnuMasterAkunBankPerusahaan.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterCompanyBankAccount, VO.Access.Values.ViewAccess)

        pgMain.Value = 50
        Application.DoEvents()

        '# Transaction
        '## Sales
        mnuTransaksiPenjualanPermintaan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionOrderRequest, VO.Access.Values.ViewAccess)
        mnuTransaksiPenjualanKontrakPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.ViewAccess)
        mnuTransaksiPenjualanMemoPengambilan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPickupMemo, VO.Access.Values.ViewAccess)
        mnuTransaksiPenjualanPengirimanPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDelivery, VO.Access.Values.ViewAccess)

        '## Purchase
        mnuTransaksiPembelianPesananPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseOrder, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianPesananPemotongan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseOrderCutting, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianPesananPengiriman.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseOrderTransport, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianKontrakPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionPurchaseContract, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianInstruksi.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionInstructionLetter, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianKonfirmasiPesanan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionConfirmationOrder, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianKonfirmasiPengiriman.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionConfirmationDelivery, VO.Access.Values.ViewAccess)
        mnuTransaksiPembelianProsesPemotonganSPK.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCuttingProcess, VO.Access.Values.ViewAccess)

        '## Pembukuan
        mnuTransaksiPembukuanJurnalUmum.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionJournal, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPelunasanSaldoAwal.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountReceivable, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPembayaranSaldoAwal.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayable, VO.Access.Values.ViewAccess)
        mnuTransaksiPembukuanPembayaranBiaya.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCost, VO.Access.Values.ViewAccess)

        '# Laporan
        '## Pembukuan
        mnuLaporanPembukuanBukuBesar.Enabled = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, ERPSLib.VO.Modules.Values.ReportBukuBesar, VO.Access.Values.ViewAccess)


        'mnuTransaksiPenjualanPanjar.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDownPayment, VO.Access.Values.ViewAccess)
        'mnuTransaksiPenjualanPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSales, VO.Access.Values.ViewAccess)
        'mnuTransaksiPenjualanReturPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesReturn, VO.Access.Values.ViewAccess)
        'mnuTransaksiPenjualanPenagihan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountReceivable, VO.Access.Values.ViewAccess)
        'mnuTransactionPenjualanImportPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSales, VO.Access.Values.ImportData)

        'mnuTransaksiPenjualanJasaPanjar.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesDownPayment, VO.Access.Values.ViewAccess)
        'mnuTransaksiPenjualanJasaPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesService, VO.Access.Values.ViewAccess)
        'mnuTransaksiPenjualanJasaPenagihan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountReceivable, VO.Access.Values.ViewAccess)

        'mnuTransaksiPembelianPanjar.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceiveDownPayment, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembelianPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembelianReturPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceiveReturn, VO.Access.Values.ViewAccess)
        'mnuTransaksiPembelianPembayaran.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayable, VO.Access.Values.ViewAccess)
        'mnuTransactionSplitPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSplitReceive, VO.Access.Values.ViewAccess)

        'If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceiveDownPayment, VO.Access.Values.ViewAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.ViewAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceiveReturn, VO.Access.Values.ViewAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayable, VO.Access.Values.ViewAccess) = False Then
        '    mnuTransaksiPembelian.Visible = False
        'End If

        'mnuTransaksiBiaya.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCost, VO.Access.Values.ViewAccess)
        'mnuTransaksiJurnalUmum.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionJournal, VO.Access.Values.ViewAccess)

        'If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCost, VO.Access.Values.ViewAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionJournal, VO.Access.Values.ViewAccess) = False Then
        '    mnuTransaksiSep3.Visible = False
        'End If

        'pgMain.Value = 80
        'Application.DoEvents()

        ''# Reports
        'mnuLaporanLaporanPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSales, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanReturPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesReturn, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanRekapPenjualan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSales, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanPenjualanJasa.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesService, VO.Access.Values.PrintReportAccess)
        'mnuLaporanKartuPiutang.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportKartuPiutang, VO.Access.Values.PrintReportAccess)

        'If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.PrintReportAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceiveReturn, VO.Access.Values.PrintReportAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportKartuHutang, VO.Access.Values.PrintReportAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportKartuHutangHargaBeli2, VO.Access.Values.PrintReportAccess) = False Then
        '    mnuLaporanSep1.Visible = False
        'End If

        'mnuLaporanLaporanPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanRekapPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceive, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanReturPembelian.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionReceiveReturn, VO.Access.Values.PrintReportAccess)
        'mnuLaporanKartuHutang.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportKartuHutang, VO.Access.Values.PrintReportAccess)
        'mnuLaporanKartuHutangHargaBeli2.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportKartuHutangHargaBeli2, VO.Access.Values.PrintReportAccess)

        'If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountReceivable, VO.Access.Values.PrintReportAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayable, VO.Access.Values.PrintReportAccess) = False Then
        '    mnuLaporanSep2.Visible = False
        'End If

        'mnuLaporanLaporanTagihan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountReceivable, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanPembayaran.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionAccountPayable, VO.Access.Values.PrintReportAccess)

        'If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCost, VO.Access.Values.PrintReportAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionJournal, VO.Access.Values.PrintReportAccess) = False Then
        '    mnuLaporanSep3.Visible = False
        'End If

        'mnuLaporanLaporanBiaya.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCost, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanJurnalUmum.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionJournal, VO.Access.Values.PrintReportAccess)

        'If BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportProfitAndLoss, VO.Access.Values.PrintReportAccess) = False AndAlso _
        '    BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportBalanceSheet, VO.Access.Values.PrintReportAccess) = False Then
        '    mnuLaporanSep4.Visible = False
        'End If

        'mnuLaporanBukuBesar.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportBukuBesar, VO.Access.Values.PrintReportAccess)
        'mnuLaporanNeracaSaldo.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportNeracaSaldo, VO.Access.Values.PrintReportAccess)
        'mnuLaporanLaporanLabaRugi.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportProfitAndLoss, VO.Access.Values.ViewAccess)
        'mnuLaporanLaporanNeraca.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.ReportBalanceSheet, VO.Access.Values.ViewAccess)

        'pgMain.Value = 95
        'Application.DoEvents()

        ''# Settings
        'mnuSettingGenerateJurnal.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.SettingGenerateJurnal, VO.Access.Values.ViewAccess)
        'mnuSettingSetupPostingJurnalTransaksi.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, VO.Access.Values.ViewAccess)
        'mnuSettingBackupDatabase.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, -1)
        'mnuSettingSyncJurnalTransaksi.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, -1, -1)
        'mnuSettingPostingDataPajak.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.SettingPostingTax, VO.Access.Values.ViewAccess)

        Me.Cursor = Cursors.Default
        pgMain.Visible = False
    End Sub


#Region "Form Handle"

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

#End Region

#Region "Transaksi"

    Private Sub mnuTransaksiPenjualanPermintaan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanPermintaan.Click
        UI.usForm.frmOpen(frmMainTraOrderRequest, "frmTraOrderRequest", Me)
    End Sub

    Private Sub mnuTransaksiPembelianPesananPembelian_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianPesananPembelian.Click
        UI.usForm.frmOpen(frmMainTraPurchaseOrder, "frmTraPurchaseOrder", Me)
    End Sub

    Private Sub mnuTransaksiPembelianPesananPemotongan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianPesananPemotongan.Click
        UI.usForm.frmOpen(frmMainTraPurchaseOrderCutting, "frmTraPurchaseOrderCutting", Me)
    End Sub

    Private Sub mnuTransaksiPembelianKonfirmasiPesanan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianKonfirmasiPesanan.Click
        UI.usForm.frmOpen(frmMainTraConfirmationOrder, "frmTraConfirmationOrder", Me)
    End Sub

    Private Sub mnuTransaksiPembelianKontrakPembelian_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianKontrakPembelian.Click
        UI.usForm.frmOpen(frmMainTraPurchaseContract, "frmTraPurchaseContract", Me)
    End Sub

    Private Sub mnuTransaksiPembelianInstruksi_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianInstruksi.Click

    End Sub

    Private Sub mnuTransaksiPembelianKonfirmasiPengiriman_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianKonfirmasiPengiriman.Click

    End Sub

    Private Sub mnuTransaksiPembelianProsesPemotonganSPK_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembelianProsesPemotonganSPK.Click

    End Sub

    Private Sub mnuTransaksiPenjualanKontrakPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanKontrakPenjualan.Click

    End Sub

    Private Sub mnuTransaksiPenjualanMemoPengambilan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanMemoPengambilan.Click

    End Sub

    Private Sub mnuTransaksiPenjualanPengirimanPenjualan_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPenjualanPengirimanPenjualan.Click

    End Sub

#Region "Pembukuan"

    Private Sub mnuTransaksiPembukuanPelunasanSaldoAwal_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPelunasanSaldoAwal.Click
        'UI.usForm.frmOpen(frmMainTraAccountReceivable, "frmTraAccountReceivable", Me)
        'frmMainTraAccountReceivable = New frmTraAccountReceivable
        'frmMainTraAccountReceivable.pubModules = "SB"
        'frmMainTraAccountReceivable.Show()
        'frmMainTraAccountReceivable.MdiParent = Me

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
                frmMainTraAccountReceivable.pubModules = "SB"
                frmMainTraAccountReceivable.Show()
            End If
        Else
            frmMainTraAccountReceivable = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountReceivable.MdiParent = Me
            frmMainTraAccountReceivable.pubModules = "SB"
            frmMainTraAccountReceivable.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranSaldoAwal_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranSaldoAwal.Click
        'UI.usForm.frmOpen(frmMainTraAccountPayable, "frmTraAccountPayable", Me)
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayable) Then
            If Not frmMainTraAccountPayable.IsDisposed Then
                frmMainTraAccountPayable.WindowState = FormWindowState.Normal
                frmMainTraAccountPayable.BringToFront()
                frmMainTraAccountPayable.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayable = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayable.MdiParent = Me
                frmMainTraAccountPayable.pubModules = "SB"
                frmMainTraAccountPayable.Show()
            End If
        Else
            frmMainTraAccountPayable = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayable.MdiParent = Me
            frmMainTraAccountPayable.pubModules = "SB"
            frmMainTraAccountPayable.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPanjarPenjualanManual_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPenjualanManual.Click
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
                frmMainTraAccountReceivable.pubModules = "SDM"
                frmMainTraAccountReceivable.Show()
            End If
        Else
            frmMainTraAccountReceivable = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountReceivable.MdiParent = Me
            frmMainTraAccountReceivable.pubModules = "SDM"
            frmMainTraAccountReceivable.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPanjarPembelianManual_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPanjarPembelianManual.Click
        Dim s_fT As String = Me.GetType.Namespace & "." & "frmTraAccountPayable"
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(frmMainTraAccountPayable) Then
            If Not frmMainTraAccountPayable.IsDisposed Then
                frmMainTraAccountPayable.WindowState = FormWindowState.Normal
                frmMainTraAccountPayable.BringToFront()
                frmMainTraAccountPayable.WindowState = FormWindowState.Maximized
            Else
                frmMainTraAccountPayable = Activator.CreateInstance(Type.GetType(s_fT))
                frmMainTraAccountPayable.MdiParent = Me
                frmMainTraAccountPayable.pubModules = "PDM"
                frmMainTraAccountPayable.Show()
            End If
        Else
            frmMainTraAccountPayable = Activator.CreateInstance(Type.GetType(s_fT))
            frmMainTraAccountPayable.MdiParent = Me
            frmMainTraAccountPayable.pubModules = "PDM"
            frmMainTraAccountPayable.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub mnuTransaksiPembukuanPembayaranBiaya_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanPembayaranBiaya.Click
        UI.usForm.frmOpen(frmMainTraCost, "frmTraCost", Me)
    End Sub

    Private Sub mnuTransaksiPembukuanJurnalUmum_Click(sender As Object, e As EventArgs) Handles mnuTransaksiPembukuanJurnalUmum.Click
        UI.usForm.frmOpen(frmMainTraJournal, "frmTraJournal", Me)
    End Sub

#End Region

#End Region

#Region "Laporan"

    Private Sub mnuLaporanPembukuanBukuBesar_Click(sender As Object, e As EventArgs) Handles mnuLaporanPembukuanBukuBesar.Click
        UI.usForm.frmOpen(frmMainRptBukuBesarVer00, "frmRptBukuBesarVer00", Me)
    End Sub

#End Region

#Region "Setting"

    Private Sub mnuSettingUbahPassword_Click(sender As Object, e As EventArgs) Handles mnuSettingUbahPassword.Click
        UI.usForm.frmOpen(frmMainSysChangePassword, "frmSysChangePassword", Me)
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