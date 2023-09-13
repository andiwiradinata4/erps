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
    Dim frmMainMstItemType As frmMstItemType
    Dim frmMainMstItemSpecification As frmMstItemSpecification
    Dim frmMainMstItem As frmMstItem
    Dim frmMainBusinessPartner As frmMstBusinessPartner

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
        Me.Refresh()

        '# Master
        mnuMasterProgram.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterProgram, VO.Access.Values.ViewAccess)
        mnuMasterStatus.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterStatus, VO.Access.Values.ViewAccess)
        mnuMasterModule.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterModule, VO.Access.Values.ViewAccess)
        mnuMasterAkses.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterAccess, VO.Access.Values.ViewAccess)
        mnuMasterPerusahaan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterCompany, VO.Access.Values.ViewAccess)
        mnuMasterKaryawan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterUser, VO.Access.Values.ViewAccess)
        mnuMasterSatuan.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterUOM, VO.Access.Values.ViewAccess)
        mnuMasterJenisBarang.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItemType, VO.Access.Values.ViewAccess)
        mnuMasterSpesifikasiBarang.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItemSpecification, VO.Access.Values.ViewAccess)
        mnuMasterBarang.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterItem, VO.Access.Values.ViewAccess)
        mnuMasterRekanBisnis.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterBusinessPartner, VO.Access.Values.ViewAccess)
        mnuMasterJenisPembayaran.Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.MasterPaymentType, VO.Access.Values.ViewAccess)

        pgMain.Value = 50
        Me.Refresh()

        '# Transaction
        'If ERPSLib.UI.usUserApp.ProgramID = VO.Program.Values.TradingTBS Then
        '    mnuTransaksiPenjualanJasa.Visible = False
        'ElseIf ERPSLib.UI.usUserApp.ProgramID = VO.Program.Values.RentalAlatBerat Or ERPSLib.UI.usUserApp.ProgramID = VO.Program.Values.RentalTruk Then
        '    mnuTransaksiPenjualan.Visible = False
        '    mnuTransaksiPembelian.Visible = False
        'End If

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
        'Me.Refresh()

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
        'Me.Refresh()

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

    Private Sub mnuMasterKaryawan_Click(sender As Object, e As EventArgs) Handles mnuMasterKaryawan.Click
        UI.usForm.frmOpen(frmMainMstUser, "frmMstUser", Me)
    End Sub

    Private Sub mnuMasterSatuan_Click(sender As Object, e As EventArgs) Handles mnuMasterSatuan.Click
        UI.usForm.frmOpen(frmMainMstUOM, "frmMstUOM", Me)
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

    End Sub

    Private Sub mnuMasterJenisPembayaran_Click(sender As Object, e As EventArgs) Handles mnuMasterJenisPembayaran.Click

    End Sub

    Private Sub mnuMasterSyaratPembayaran_Click(sender As Object, e As EventArgs)

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