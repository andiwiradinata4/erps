﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSysMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.tssUserID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssProgram = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCompany = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssServer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ssBuildDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterProgram = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterModule = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterAkses = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterPerusahaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterKaryawan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSatuan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterTipeAkunPerkiraan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterGroupAkunPerkiraan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterAkunPerkiraan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMasterJenisBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSpesifikasiBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterPersediaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMasterRekanBisnis = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterAkunBankPerusahaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterPaymentTypeCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterMetodePembayaran = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterJenisPembayaran = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMasterLokasiPengiriman = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterJenisBiayaTransportasi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanPermintaanPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanKonfirmasiPesanan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanKontrakPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanPengirimanPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTransaksiPenjualanReturPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTransaksiPenjualanPengajuanKlaim = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanKonfirmasiKlaim = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanJasa = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanJasaPengiriman = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanJasaPelunasanPengiriman = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanJasaSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTransaksiPenjualanJasaProsesPotong = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanJasaPelunasanPemotongan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanStock = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanStockPermintaanPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanStockPengirimanPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianPesananPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianKonfirmasiPesanan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianKontrakPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianPenerimaanPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTransaksiPembelianSPKPotong = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianProsesPemotongan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTransaksiPembelianPengajuanKlaim = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianKonfirmasiKlaim = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanPembayaran = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanPelunasan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTransaksiPembukuanPembayaranBiaya = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanPembayaranBiayaTransportasi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanPembayaranBiayaPotong = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanKasBankVoucher = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTransaksiPembukuanJurnalUmum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembukuanJurnalUmumAutoGenerate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembelianSPKPotong = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPenjualanKonfirmasiPesanan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanTransaksiBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembukuan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembukuanPIPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLaporanPembukuanKartuHutang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembukuanKartuPiutang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembukuanBukuBesar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembukuanNeracaSaldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembukuanLabaRugi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporanPembukuanNeraca = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPengaturan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettingUbahPassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPengaturanSetupPostingJurnalTransaksi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTampilan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCloseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssMain.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 561)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(883, 23)
        Me.pgMain.TabIndex = 6
        '
        'ssMain
        '
        Me.ssMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssUserID, Me.tssProgram, Me.tssCompany, Me.tssVersion, Me.tssServer, Me.ssBuildDate})
        Me.ssMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ssMain.Location = New System.Drawing.Point(0, 539)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.ssMain.Size = New System.Drawing.Size(883, 22)
        Me.ssMain.TabIndex = 7
        Me.ssMain.Text = "StatusStrip1"
        '
        'tssUserID
        '
        Me.tssUserID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssUserID.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tssUserID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssUserID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tssUserID.ForeColor = System.Drawing.Color.DimGray
        Me.tssUserID.Name = "tssUserID"
        Me.tssUserID.Size = New System.Drawing.Size(50, 17)
        Me.tssUserID.Text = "UserID"
        '
        'tssProgram
        '
        Me.tssProgram.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssProgram.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tssProgram.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssProgram.ForeColor = System.Drawing.Color.DimGray
        Me.tssProgram.Name = "tssProgram"
        Me.tssProgram.Size = New System.Drawing.Size(60, 17)
        Me.tssProgram.Text = "Program"
        '
        'tssCompany
        '
        Me.tssCompany.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssCompany.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tssCompany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssCompany.ForeColor = System.Drawing.Color.DimGray
        Me.tssCompany.Name = "tssCompany"
        Me.tssCompany.Size = New System.Drawing.Size(64, 17)
        Me.tssCompany.Text = "Company"
        '
        'tssVersion
        '
        Me.tssVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssVersion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tssVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssVersion.ForeColor = System.Drawing.Color.DimGray
        Me.tssVersion.Name = "tssVersion"
        Me.tssVersion.Size = New System.Drawing.Size(53, 17)
        Me.tssVersion.Text = "Version"
        '
        'tssServer
        '
        Me.tssServer.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssServer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tssServer.ForeColor = System.Drawing.Color.DimGray
        Me.tssServer.Name = "tssServer"
        Me.tssServer.Size = New System.Drawing.Size(49, 17)
        Me.tssServer.Text = "Server"
        '
        'ssBuildDate
        '
        Me.ssBuildDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssBuildDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ssBuildDate.ForeColor = System.Drawing.Color.DimGray
        Me.ssBuildDate.Name = "ssBuildDate"
        Me.ssBuildDate.Size = New System.Drawing.Size(68, 17)
        Me.ssBuildDate.Text = "Build Date"
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaster, Me.mnuTransaksi, Me.mnuLaporan, Me.mnuPengaturan, Me.mnuTampilan, Me.mnuLogout})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.MdiWindowListItem = Me.mnuTampilan
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(883, 24)
        Me.mnuMain.TabIndex = 8
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuMaster
        '
        Me.mnuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMasterProgram, Me.mnuMasterStatus, Me.mnuMasterModule, Me.mnuMasterAkses, Me.mnuMasterPerusahaan, Me.mnuMasterKaryawan, Me.mnuMasterSatuan, Me.mnuMasterTipeAkunPerkiraan, Me.mnuMasterGroupAkunPerkiraan, Me.mnuMasterAkunPerkiraan, Me.mnuMasterSep1, Me.mnuMasterJenisBarang, Me.mnuMasterSpesifikasiBarang, Me.mnuMasterBarang, Me.mnuMasterPersediaan, Me.mnuMasterSep2, Me.mnuMasterRekanBisnis, Me.mnuMasterAkunBankPerusahaan, Me.mnuMasterPaymentTypeCategory, Me.mnuMasterMetodePembayaran, Me.mnuMasterJenisPembayaran, Me.mnuMasterSep3, Me.mnuMasterLokasiPengiriman, Me.mnuMasterJenisBiayaTransportasi})
        Me.mnuMaster.Name = "mnuMaster"
        Me.mnuMaster.Size = New System.Drawing.Size(55, 20)
        Me.mnuMaster.Text = "&Master"
        '
        'mnuMasterProgram
        '
        Me.mnuMasterProgram.Name = "mnuMasterProgram"
        Me.mnuMasterProgram.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterProgram.Text = "Program"
        '
        'mnuMasterStatus
        '
        Me.mnuMasterStatus.Name = "mnuMasterStatus"
        Me.mnuMasterStatus.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterStatus.Text = "Status"
        '
        'mnuMasterModule
        '
        Me.mnuMasterModule.Name = "mnuMasterModule"
        Me.mnuMasterModule.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterModule.Text = "Module"
        '
        'mnuMasterAkses
        '
        Me.mnuMasterAkses.Name = "mnuMasterAkses"
        Me.mnuMasterAkses.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterAkses.Text = "Akses"
        '
        'mnuMasterPerusahaan
        '
        Me.mnuMasterPerusahaan.Name = "mnuMasterPerusahaan"
        Me.mnuMasterPerusahaan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterPerusahaan.Text = "Perusahaan"
        '
        'mnuMasterKaryawan
        '
        Me.mnuMasterKaryawan.Name = "mnuMasterKaryawan"
        Me.mnuMasterKaryawan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterKaryawan.Text = "Karyawan"
        '
        'mnuMasterSatuan
        '
        Me.mnuMasterSatuan.Name = "mnuMasterSatuan"
        Me.mnuMasterSatuan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterSatuan.Text = "Satuan"
        '
        'mnuMasterTipeAkunPerkiraan
        '
        Me.mnuMasterTipeAkunPerkiraan.Name = "mnuMasterTipeAkunPerkiraan"
        Me.mnuMasterTipeAkunPerkiraan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterTipeAkunPerkiraan.Text = "Tipe Akun Perkiraan"
        '
        'mnuMasterGroupAkunPerkiraan
        '
        Me.mnuMasterGroupAkunPerkiraan.Name = "mnuMasterGroupAkunPerkiraan"
        Me.mnuMasterGroupAkunPerkiraan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterGroupAkunPerkiraan.Text = "Group Akun Perkiraan"
        '
        'mnuMasterAkunPerkiraan
        '
        Me.mnuMasterAkunPerkiraan.Name = "mnuMasterAkunPerkiraan"
        Me.mnuMasterAkunPerkiraan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterAkunPerkiraan.Text = "Akun Perkiraan"
        '
        'mnuMasterSep1
        '
        Me.mnuMasterSep1.Name = "mnuMasterSep1"
        Me.mnuMasterSep1.Size = New System.Drawing.Size(196, 6)
        '
        'mnuMasterJenisBarang
        '
        Me.mnuMasterJenisBarang.Name = "mnuMasterJenisBarang"
        Me.mnuMasterJenisBarang.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterJenisBarang.Text = "Jenis Barang"
        '
        'mnuMasterSpesifikasiBarang
        '
        Me.mnuMasterSpesifikasiBarang.Name = "mnuMasterSpesifikasiBarang"
        Me.mnuMasterSpesifikasiBarang.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterSpesifikasiBarang.Text = "Spesifikasi Barang"
        '
        'mnuMasterBarang
        '
        Me.mnuMasterBarang.Name = "mnuMasterBarang"
        Me.mnuMasterBarang.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterBarang.Text = "Barang"
        '
        'mnuMasterPersediaan
        '
        Me.mnuMasterPersediaan.Name = "mnuMasterPersediaan"
        Me.mnuMasterPersediaan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterPersediaan.Text = "Persediaan"
        '
        'mnuMasterSep2
        '
        Me.mnuMasterSep2.Name = "mnuMasterSep2"
        Me.mnuMasterSep2.Size = New System.Drawing.Size(196, 6)
        '
        'mnuMasterRekanBisnis
        '
        Me.mnuMasterRekanBisnis.Name = "mnuMasterRekanBisnis"
        Me.mnuMasterRekanBisnis.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterRekanBisnis.Text = "Rekan Bisnis"
        '
        'mnuMasterAkunBankPerusahaan
        '
        Me.mnuMasterAkunBankPerusahaan.Name = "mnuMasterAkunBankPerusahaan"
        Me.mnuMasterAkunBankPerusahaan.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterAkunBankPerusahaan.Text = "Akun Bank Perusahaan"
        '
        'mnuMasterPaymentTypeCategory
        '
        Me.mnuMasterPaymentTypeCategory.Name = "mnuMasterPaymentTypeCategory"
        Me.mnuMasterPaymentTypeCategory.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterPaymentTypeCategory.Text = "Payment Type Category"
        '
        'mnuMasterMetodePembayaran
        '
        Me.mnuMasterMetodePembayaran.Name = "mnuMasterMetodePembayaran"
        Me.mnuMasterMetodePembayaran.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterMetodePembayaran.Text = "Metode Pembayaran"
        '
        'mnuMasterJenisPembayaran
        '
        Me.mnuMasterJenisPembayaran.Name = "mnuMasterJenisPembayaran"
        Me.mnuMasterJenisPembayaran.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterJenisPembayaran.Text = "Jenis Pembayaran"
        '
        'mnuMasterSep3
        '
        Me.mnuMasterSep3.Name = "mnuMasterSep3"
        Me.mnuMasterSep3.Size = New System.Drawing.Size(196, 6)
        '
        'mnuMasterLokasiPengiriman
        '
        Me.mnuMasterLokasiPengiriman.Name = "mnuMasterLokasiPengiriman"
        Me.mnuMasterLokasiPengiriman.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterLokasiPengiriman.Text = "Lokasi Pengiriman"
        '
        'mnuMasterJenisBiayaTransportasi
        '
        Me.mnuMasterJenisBiayaTransportasi.Name = "mnuMasterJenisBiayaTransportasi"
        Me.mnuMasterJenisBiayaTransportasi.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterJenisBiayaTransportasi.Text = "Jenis Biaya Transportasi"
        '
        'mnuTransaksi
        '
        Me.mnuTransaksi.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPenjualan, Me.mnuTransaksiPenjualanJasa, Me.mnuTransaksiPenjualanStock, Me.mnuTransaksiPembelian, Me.mnuTransaksiPembukuan})
        Me.mnuTransaksi.Name = "mnuTransaksi"
        Me.mnuTransaksi.Size = New System.Drawing.Size(66, 20)
        Me.mnuTransaksi.Text = "&Transaksi"
        '
        'mnuTransaksiPenjualan
        '
        Me.mnuTransaksiPenjualan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPenjualanPermintaanPenjualan, Me.mnuTransaksiPenjualanKonfirmasiPesanan, Me.mnuTransaksiPenjualanKontrakPenjualan, Me.mnuTransaksiPenjualanPengirimanPenjualan, Me.mnuTransaksiPenjualanSep1, Me.mnuTransaksiPenjualanReturPenjualan, Me.mnuTransaksiPenjualanSep2, Me.mnuTransaksiPenjualanPengajuanKlaim, Me.mnuTransaksiPenjualanKonfirmasiKlaim})
        Me.mnuTransaksiPenjualan.Name = "mnuTransaksiPenjualan"
        Me.mnuTransaksiPenjualan.Size = New System.Drawing.Size(180, 22)
        Me.mnuTransaksiPenjualan.Text = "Penjualan"
        '
        'mnuTransaksiPenjualanPermintaanPenjualan
        '
        Me.mnuTransaksiPenjualanPermintaanPenjualan.Name = "mnuTransaksiPenjualanPermintaanPenjualan"
        Me.mnuTransaksiPenjualanPermintaanPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanPermintaanPenjualan.Text = "Permintaan Penjualan"
        '
        'mnuTransaksiPenjualanKonfirmasiPesanan
        '
        Me.mnuTransaksiPenjualanKonfirmasiPesanan.Name = "mnuTransaksiPenjualanKonfirmasiPesanan"
        Me.mnuTransaksiPenjualanKonfirmasiPesanan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanKonfirmasiPesanan.Text = "Konfirmasi Pesanan"
        '
        'mnuTransaksiPenjualanKontrakPenjualan
        '
        Me.mnuTransaksiPenjualanKontrakPenjualan.Name = "mnuTransaksiPenjualanKontrakPenjualan"
        Me.mnuTransaksiPenjualanKontrakPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanKontrakPenjualan.Text = "Kontrak Penjualan"
        '
        'mnuTransaksiPenjualanPengirimanPenjualan
        '
        Me.mnuTransaksiPenjualanPengirimanPenjualan.Name = "mnuTransaksiPenjualanPengirimanPenjualan"
        Me.mnuTransaksiPenjualanPengirimanPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanPengirimanPenjualan.Text = "Pengiriman Penjualan"
        '
        'mnuTransaksiPenjualanSep1
        '
        Me.mnuTransaksiPenjualanSep1.Name = "mnuTransaksiPenjualanSep1"
        Me.mnuTransaksiPenjualanSep1.Size = New System.Drawing.Size(187, 6)
        '
        'mnuTransaksiPenjualanReturPenjualan
        '
        Me.mnuTransaksiPenjualanReturPenjualan.Name = "mnuTransaksiPenjualanReturPenjualan"
        Me.mnuTransaksiPenjualanReturPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanReturPenjualan.Text = "Retur Penjualan"
        '
        'mnuTransaksiPenjualanSep2
        '
        Me.mnuTransaksiPenjualanSep2.Name = "mnuTransaksiPenjualanSep2"
        Me.mnuTransaksiPenjualanSep2.Size = New System.Drawing.Size(187, 6)
        '
        'mnuTransaksiPenjualanPengajuanKlaim
        '
        Me.mnuTransaksiPenjualanPengajuanKlaim.Name = "mnuTransaksiPenjualanPengajuanKlaim"
        Me.mnuTransaksiPenjualanPengajuanKlaim.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanPengajuanKlaim.Text = "Pengajuan Klaim"
        '
        'mnuTransaksiPenjualanKonfirmasiKlaim
        '
        Me.mnuTransaksiPenjualanKonfirmasiKlaim.Name = "mnuTransaksiPenjualanKonfirmasiKlaim"
        Me.mnuTransaksiPenjualanKonfirmasiKlaim.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanKonfirmasiKlaim.Text = "Konfirmasi Klaim"
        '
        'mnuTransaksiPenjualanJasa
        '
        Me.mnuTransaksiPenjualanJasa.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPenjualanJasaPengiriman, Me.mnuTransaksiPenjualanJasaPelunasanPengiriman, Me.mnuTransaksiPenjualanJasaSep1, Me.mnuTransaksiPenjualanJasaProsesPotong, Me.mnuTransaksiPenjualanJasaPelunasanPemotongan})
        Me.mnuTransaksiPenjualanJasa.Name = "mnuTransaksiPenjualanJasa"
        Me.mnuTransaksiPenjualanJasa.Size = New System.Drawing.Size(180, 22)
        Me.mnuTransaksiPenjualanJasa.Text = "Penjualan Jasa"
        '
        'mnuTransaksiPenjualanJasaPengiriman
        '
        Me.mnuTransaksiPenjualanJasaPengiriman.Name = "mnuTransaksiPenjualanJasaPengiriman"
        Me.mnuTransaksiPenjualanJasaPengiriman.Size = New System.Drawing.Size(200, 22)
        Me.mnuTransaksiPenjualanJasaPengiriman.Text = "Pengiriman"
        '
        'mnuTransaksiPenjualanJasaPelunasanPengiriman
        '
        Me.mnuTransaksiPenjualanJasaPelunasanPengiriman.Name = "mnuTransaksiPenjualanJasaPelunasanPengiriman"
        Me.mnuTransaksiPenjualanJasaPelunasanPengiriman.Size = New System.Drawing.Size(200, 22)
        Me.mnuTransaksiPenjualanJasaPelunasanPengiriman.Text = "Pelunasan Pengiriman"
        '
        'mnuTransaksiPenjualanJasaSep1
        '
        Me.mnuTransaksiPenjualanJasaSep1.Name = "mnuTransaksiPenjualanJasaSep1"
        Me.mnuTransaksiPenjualanJasaSep1.Size = New System.Drawing.Size(197, 6)
        '
        'mnuTransaksiPenjualanJasaProsesPotong
        '
        Me.mnuTransaksiPenjualanJasaProsesPotong.Name = "mnuTransaksiPenjualanJasaProsesPotong"
        Me.mnuTransaksiPenjualanJasaProsesPotong.Size = New System.Drawing.Size(200, 22)
        Me.mnuTransaksiPenjualanJasaProsesPotong.Text = "Proses Potong"
        '
        'mnuTransaksiPenjualanJasaPelunasanPemotongan
        '
        Me.mnuTransaksiPenjualanJasaPelunasanPemotongan.Name = "mnuTransaksiPenjualanJasaPelunasanPemotongan"
        Me.mnuTransaksiPenjualanJasaPelunasanPemotongan.Size = New System.Drawing.Size(200, 22)
        Me.mnuTransaksiPenjualanJasaPelunasanPemotongan.Text = "Pelunasan Pemotongan"
        '
        'mnuTransaksiPenjualanStock
        '
        Me.mnuTransaksiPenjualanStock.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPenjualanStockPermintaanPenjualan, Me.mnuTransaksiPenjualanStockPengirimanPenjualan})
        Me.mnuTransaksiPenjualanStock.Name = "mnuTransaksiPenjualanStock"
        Me.mnuTransaksiPenjualanStock.Size = New System.Drawing.Size(180, 22)
        Me.mnuTransaksiPenjualanStock.Text = "Penjualan [Stock]"
        '
        'mnuTransaksiPenjualanStockPermintaanPenjualan
        '
        Me.mnuTransaksiPenjualanStockPermintaanPenjualan.Name = "mnuTransaksiPenjualanStockPermintaanPenjualan"
        Me.mnuTransaksiPenjualanStockPermintaanPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanStockPermintaanPenjualan.Text = "Permintaan Penjualan"
        '
        'mnuTransaksiPenjualanStockPengirimanPenjualan
        '
        Me.mnuTransaksiPenjualanStockPengirimanPenjualan.Name = "mnuTransaksiPenjualanStockPengirimanPenjualan"
        Me.mnuTransaksiPenjualanStockPengirimanPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanStockPengirimanPenjualan.Text = "Pengiriman Penjualan"
        '
        'mnuTransaksiPembelian
        '
        Me.mnuTransaksiPembelian.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPembelianPesananPembelian, Me.mnuTransaksiPembelianKonfirmasiPesanan, Me.mnuTransaksiPembelianKontrakPembelian, Me.mnuTransaksiPembelianPenerimaanPembelian, Me.mnuTransaksiPembelianSep1, Me.mnuTransaksiPembelianSPKPotong, Me.mnuTransaksiPembelianProsesPemotongan, Me.mnuTransaksiPembelianSep2, Me.mnuTransaksiPembelianPengajuanKlaim, Me.mnuTransaksiPembelianKonfirmasiKlaim})
        Me.mnuTransaksiPembelian.Name = "mnuTransaksiPembelian"
        Me.mnuTransaksiPembelian.Size = New System.Drawing.Size(180, 22)
        Me.mnuTransaksiPembelian.Text = "Pembelian"
        '
        'mnuTransaksiPembelianPesananPembelian
        '
        Me.mnuTransaksiPembelianPesananPembelian.Name = "mnuTransaksiPembelianPesananPembelian"
        Me.mnuTransaksiPembelianPesananPembelian.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianPesananPembelian.Text = "Pesanan Pembelian"
        '
        'mnuTransaksiPembelianKonfirmasiPesanan
        '
        Me.mnuTransaksiPembelianKonfirmasiPesanan.Name = "mnuTransaksiPembelianKonfirmasiPesanan"
        Me.mnuTransaksiPembelianKonfirmasiPesanan.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianKonfirmasiPesanan.Text = "Konfirmasi Pesanan"
        '
        'mnuTransaksiPembelianKontrakPembelian
        '
        Me.mnuTransaksiPembelianKontrakPembelian.Name = "mnuTransaksiPembelianKontrakPembelian"
        Me.mnuTransaksiPembelianKontrakPembelian.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianKontrakPembelian.Text = "Kontrak Pembelian"
        '
        'mnuTransaksiPembelianPenerimaanPembelian
        '
        Me.mnuTransaksiPembelianPenerimaanPembelian.Name = "mnuTransaksiPembelianPenerimaanPembelian"
        Me.mnuTransaksiPembelianPenerimaanPembelian.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianPenerimaanPembelian.Text = "Penerimaan Pembelian"
        '
        'mnuTransaksiPembelianSep1
        '
        Me.mnuTransaksiPembelianSep1.Name = "mnuTransaksiPembelianSep1"
        Me.mnuTransaksiPembelianSep1.Size = New System.Drawing.Size(193, 6)
        '
        'mnuTransaksiPembelianSPKPotong
        '
        Me.mnuTransaksiPembelianSPKPotong.Name = "mnuTransaksiPembelianSPKPotong"
        Me.mnuTransaksiPembelianSPKPotong.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianSPKPotong.Text = "SPK Potong"
        '
        'mnuTransaksiPembelianProsesPemotongan
        '
        Me.mnuTransaksiPembelianProsesPemotongan.Name = "mnuTransaksiPembelianProsesPemotongan"
        Me.mnuTransaksiPembelianProsesPemotongan.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianProsesPemotongan.Text = "Proses Pemotongan"
        '
        'mnuTransaksiPembelianSep2
        '
        Me.mnuTransaksiPembelianSep2.Name = "mnuTransaksiPembelianSep2"
        Me.mnuTransaksiPembelianSep2.Size = New System.Drawing.Size(193, 6)
        '
        'mnuTransaksiPembelianPengajuanKlaim
        '
        Me.mnuTransaksiPembelianPengajuanKlaim.Name = "mnuTransaksiPembelianPengajuanKlaim"
        Me.mnuTransaksiPembelianPengajuanKlaim.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianPengajuanKlaim.Text = "Pengajuan Klaim"
        '
        'mnuTransaksiPembelianKonfirmasiKlaim
        '
        Me.mnuTransaksiPembelianKonfirmasiKlaim.Name = "mnuTransaksiPembelianKonfirmasiKlaim"
        Me.mnuTransaksiPembelianKonfirmasiKlaim.Size = New System.Drawing.Size(196, 22)
        Me.mnuTransaksiPembelianKonfirmasiKlaim.Text = "Konfirmasi Klaim"
        '
        'mnuTransaksiPembukuan
        '
        Me.mnuTransaksiPembukuan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPembukuanPembayaran, Me.mnuTransaksiPembukuanPelunasan, Me.mnuTransaksiPembukuanSep1, Me.mnuTransaksiPembukuanPembayaranBiaya, Me.mnuTransaksiPembukuanPembayaranBiayaTransportasi, Me.mnuTransaksiPembukuanPembayaranBiayaPotong, Me.mnuTransaksiPembukuanKasBankVoucher, Me.mnuTransaksiPembukuanSep2, Me.mnuTransaksiPembukuanJurnalUmum, Me.mnuTransaksiPembukuanJurnalUmumAutoGenerate})
        Me.mnuTransaksiPembukuan.Name = "mnuTransaksiPembukuan"
        Me.mnuTransaksiPembukuan.Size = New System.Drawing.Size(180, 22)
        Me.mnuTransaksiPembukuan.Text = "Pembukuan"
        '
        'mnuTransaksiPembukuanPembayaran
        '
        Me.mnuTransaksiPembukuanPembayaran.Name = "mnuTransaksiPembukuanPembayaran"
        Me.mnuTransaksiPembukuanPembayaran.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanPembayaran.Text = "Semua Daftar Pembayaran"
        '
        'mnuTransaksiPembukuanPelunasan
        '
        Me.mnuTransaksiPembukuanPelunasan.Name = "mnuTransaksiPembukuanPelunasan"
        Me.mnuTransaksiPembukuanPelunasan.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanPelunasan.Text = "Semua Daftar Pelunasan"
        '
        'mnuTransaksiPembukuanSep1
        '
        Me.mnuTransaksiPembukuanSep1.Name = "mnuTransaksiPembukuanSep1"
        Me.mnuTransaksiPembukuanSep1.Size = New System.Drawing.Size(234, 6)
        '
        'mnuTransaksiPembukuanPembayaranBiaya
        '
        Me.mnuTransaksiPembukuanPembayaranBiaya.Name = "mnuTransaksiPembukuanPembayaranBiaya"
        Me.mnuTransaksiPembukuanPembayaranBiaya.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanPembayaranBiaya.Text = "Pembayaran Biaya"
        '
        'mnuTransaksiPembukuanPembayaranBiayaTransportasi
        '
        Me.mnuTransaksiPembukuanPembayaranBiayaTransportasi.Name = "mnuTransaksiPembukuanPembayaranBiayaTransportasi"
        Me.mnuTransaksiPembukuanPembayaranBiayaTransportasi.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanPembayaranBiayaTransportasi.Text = "Pembayaran Biaya Transportasi"
        '
        'mnuTransaksiPembukuanPembayaranBiayaPotong
        '
        Me.mnuTransaksiPembukuanPembayaranBiayaPotong.Name = "mnuTransaksiPembukuanPembayaranBiayaPotong"
        Me.mnuTransaksiPembukuanPembayaranBiayaPotong.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanPembayaranBiayaPotong.Text = "Pembayaran Biaya Potong"
        '
        'mnuTransaksiPembukuanKasBankVoucher
        '
        Me.mnuTransaksiPembukuanKasBankVoucher.Name = "mnuTransaksiPembukuanKasBankVoucher"
        Me.mnuTransaksiPembukuanKasBankVoucher.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanKasBankVoucher.Text = "Kas / Bank Voucher"
        '
        'mnuTransaksiPembukuanSep2
        '
        Me.mnuTransaksiPembukuanSep2.Name = "mnuTransaksiPembukuanSep2"
        Me.mnuTransaksiPembukuanSep2.Size = New System.Drawing.Size(234, 6)
        '
        'mnuTransaksiPembukuanJurnalUmum
        '
        Me.mnuTransaksiPembukuanJurnalUmum.Name = "mnuTransaksiPembukuanJurnalUmum"
        Me.mnuTransaksiPembukuanJurnalUmum.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanJurnalUmum.Text = "Jurnal Umum"
        '
        'mnuTransaksiPembukuanJurnalUmumAutoGenerate
        '
        Me.mnuTransaksiPembukuanJurnalUmumAutoGenerate.Name = "mnuTransaksiPembukuanJurnalUmumAutoGenerate"
        Me.mnuTransaksiPembukuanJurnalUmumAutoGenerate.Size = New System.Drawing.Size(237, 22)
        Me.mnuTransaksiPembukuanJurnalUmumAutoGenerate.Text = "Jurnal Umum Auto Generate"
        '
        'mnuLaporan
        '
        Me.mnuLaporan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLaporanPembelian, Me.mnuLaporanPenjualan, Me.mnuLaporanTransaksiBarang, Me.mnuLaporanPembukuan})
        Me.mnuLaporan.Name = "mnuLaporan"
        Me.mnuLaporan.Size = New System.Drawing.Size(62, 20)
        Me.mnuLaporan.Text = "&Laporan"
        '
        'mnuLaporanPembelian
        '
        Me.mnuLaporanPembelian.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLaporanPembelianSPKPotong})
        Me.mnuLaporanPembelian.Name = "mnuLaporanPembelian"
        Me.mnuLaporanPembelian.Size = New System.Drawing.Size(180, 22)
        Me.mnuLaporanPembelian.Text = "Pembelian"
        '
        'mnuLaporanPembelianSPKPotong
        '
        Me.mnuLaporanPembelianSPKPotong.Name = "mnuLaporanPembelianSPKPotong"
        Me.mnuLaporanPembelianSPKPotong.Size = New System.Drawing.Size(136, 22)
        Me.mnuLaporanPembelianSPKPotong.Text = "SPK Potong"
        '
        'mnuLaporanPenjualan
        '
        Me.mnuLaporanPenjualan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLaporanPenjualanKonfirmasiPesanan})
        Me.mnuLaporanPenjualan.Name = "mnuLaporanPenjualan"
        Me.mnuLaporanPenjualan.Size = New System.Drawing.Size(180, 22)
        Me.mnuLaporanPenjualan.Text = "Penjualan"
        '
        'mnuLaporanPenjualanKonfirmasiPesanan
        '
        Me.mnuLaporanPenjualanKonfirmasiPesanan.Name = "mnuLaporanPenjualanKonfirmasiPesanan"
        Me.mnuLaporanPenjualanKonfirmasiPesanan.Size = New System.Drawing.Size(178, 22)
        Me.mnuLaporanPenjualanKonfirmasiPesanan.Text = "Konfirmasi Pesanan"
        '
        'mnuLaporanTransaksiBarang
        '
        Me.mnuLaporanTransaksiBarang.Name = "mnuLaporanTransaksiBarang"
        Me.mnuLaporanTransaksiBarang.Size = New System.Drawing.Size(180, 22)
        Me.mnuLaporanTransaksiBarang.Text = "Transaksi Barang"
        '
        'mnuLaporanPembukuan
        '
        Me.mnuLaporanPembukuan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLaporanPembukuanPIPenjualan, Me.ToolStripSeparator1, Me.mnuLaporanPembukuanKartuHutang, Me.mnuLaporanPembukuanKartuPiutang, Me.mnuLaporanPembukuanBukuBesar, Me.mnuLaporanPembukuanNeracaSaldo, Me.mnuLaporanPembukuanLabaRugi, Me.mnuLaporanPembukuanNeraca})
        Me.mnuLaporanPembukuan.Name = "mnuLaporanPembukuan"
        Me.mnuLaporanPembukuan.Size = New System.Drawing.Size(180, 22)
        Me.mnuLaporanPembukuan.Text = "Pembukuan"
        '
        'mnuLaporanPembukuanPIPenjualan
        '
        Me.mnuLaporanPembukuanPIPenjualan.Name = "mnuLaporanPembukuanPIPenjualan"
        Me.mnuLaporanPembukuanPIPenjualan.Size = New System.Drawing.Size(146, 22)
        Me.mnuLaporanPembukuanPIPenjualan.Text = "PI Penjualan"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'mnuLaporanPembukuanKartuHutang
        '
        Me.mnuLaporanPembukuanKartuHutang.Name = "mnuLaporanPembukuanKartuHutang"
        Me.mnuLaporanPembukuanKartuHutang.Size = New System.Drawing.Size(146, 22)
        Me.mnuLaporanPembukuanKartuHutang.Text = "Kartu Hutang"
        '
        'mnuLaporanPembukuanKartuPiutang
        '
        Me.mnuLaporanPembukuanKartuPiutang.Name = "mnuLaporanPembukuanKartuPiutang"
        Me.mnuLaporanPembukuanKartuPiutang.Size = New System.Drawing.Size(146, 22)
        Me.mnuLaporanPembukuanKartuPiutang.Text = "Kartu Piutang"
        '
        'mnuLaporanPembukuanBukuBesar
        '
        Me.mnuLaporanPembukuanBukuBesar.Name = "mnuLaporanPembukuanBukuBesar"
        Me.mnuLaporanPembukuanBukuBesar.Size = New System.Drawing.Size(146, 22)
        Me.mnuLaporanPembukuanBukuBesar.Text = "Buku Besar"
        '
        'mnuLaporanPembukuanNeracaSaldo
        '
        Me.mnuLaporanPembukuanNeracaSaldo.Name = "mnuLaporanPembukuanNeracaSaldo"
        Me.mnuLaporanPembukuanNeracaSaldo.Size = New System.Drawing.Size(146, 22)
        Me.mnuLaporanPembukuanNeracaSaldo.Text = "Neraca Saldo"
        '
        'mnuLaporanPembukuanLabaRugi
        '
        Me.mnuLaporanPembukuanLabaRugi.Name = "mnuLaporanPembukuanLabaRugi"
        Me.mnuLaporanPembukuanLabaRugi.Size = New System.Drawing.Size(146, 22)
        Me.mnuLaporanPembukuanLabaRugi.Text = "Laba Rugi"
        '
        'mnuLaporanPembukuanNeraca
        '
        Me.mnuLaporanPembukuanNeraca.Name = "mnuLaporanPembukuanNeraca"
        Me.mnuLaporanPembukuanNeraca.Size = New System.Drawing.Size(146, 22)
        Me.mnuLaporanPembukuanNeraca.Text = "Neraca"
        '
        'mnuPengaturan
        '
        Me.mnuPengaturan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingUbahPassword, Me.mnuPengaturanSetupPostingJurnalTransaksi})
        Me.mnuPengaturan.Name = "mnuPengaturan"
        Me.mnuPengaturan.Size = New System.Drawing.Size(80, 20)
        Me.mnuPengaturan.Text = "&Pengaturan"
        '
        'mnuSettingUbahPassword
        '
        Me.mnuSettingUbahPassword.Name = "mnuSettingUbahPassword"
        Me.mnuSettingUbahPassword.Size = New System.Drawing.Size(231, 22)
        Me.mnuSettingUbahPassword.Text = "Ubah Password"
        '
        'mnuPengaturanSetupPostingJurnalTransaksi
        '
        Me.mnuPengaturanSetupPostingJurnalTransaksi.Name = "mnuPengaturanSetupPostingJurnalTransaksi"
        Me.mnuPengaturanSetupPostingJurnalTransaksi.Size = New System.Drawing.Size(231, 22)
        Me.mnuPengaturanSetupPostingJurnalTransaksi.Text = "Setup Posting Jurnal Transaksi"
        '
        'mnuTampilan
        '
        Me.mnuTampilan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindowsVertical, Me.mnuWindowsHorizontal, Me.mnuWindowsCascade, Me.mnuWindowsCloseAll})
        Me.mnuTampilan.Name = "mnuTampilan"
        Me.mnuTampilan.Size = New System.Drawing.Size(67, 20)
        Me.mnuTampilan.Text = "&Tampilan"
        '
        'mnuWindowsVertical
        '
        Me.mnuWindowsVertical.Name = "mnuWindowsVertical"
        Me.mnuWindowsVertical.Size = New System.Drawing.Size(129, 22)
        Me.mnuWindowsVertical.Text = "Vertical"
        '
        'mnuWindowsHorizontal
        '
        Me.mnuWindowsHorizontal.Name = "mnuWindowsHorizontal"
        Me.mnuWindowsHorizontal.Size = New System.Drawing.Size(129, 22)
        Me.mnuWindowsHorizontal.Text = "Horizontal"
        '
        'mnuWindowsCascade
        '
        Me.mnuWindowsCascade.Name = "mnuWindowsCascade"
        Me.mnuWindowsCascade.Size = New System.Drawing.Size(129, 22)
        Me.mnuWindowsCascade.Text = "Cascade"
        '
        'mnuWindowsCloseAll
        '
        Me.mnuWindowsCloseAll.Name = "mnuWindowsCloseAll"
        Me.mnuWindowsCloseAll.Size = New System.Drawing.Size(129, 22)
        Me.mnuWindowsCloseAll.Text = "Close All"
        '
        'mnuLogout
        '
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(57, 20)
        Me.mnuLogout.Text = "L&ogout"
        '
        'frmSysMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 584)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.mnuMain)
        Me.Controls.Add(Me.pgMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmSysMain"
        Me.Text = "Enterprise Resource Planning System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tssUserID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssProgram As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssCompany As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssServer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPengaturan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTampilan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterStatus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterModule As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterAkses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterPerusahaan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterSatuan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterJenisBarang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterSpesifikasiBarang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterBarang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMasterKaryawan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterRekanBisnis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterJenisPembayaran As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsCascade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsCloseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSettingUbahPassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterAkunBankPerusahaan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanPermintaanPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanKontrakPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanPengirimanPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianPesananPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianSPKPotong As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianKonfirmasiPesanan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianKontrakPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianProsesPemotongan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterPaymentTypeCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterMetodePembayaran As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterTipeAkunPerkiraan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterGroupAkunPerkiraan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterAkunPerkiraan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTransaksiPembukuan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembukuanJurnalUmum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuanBukuBesar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembukuanPembayaranBiaya As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTransaksiPembelianPenerimaanPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTransaksiPembukuanPembayaranBiayaTransportasi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanTransaksiBarang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPengaturanSetupPostingJurnalTransaksi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembukuanPembayaran As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembukuanSep1 As ToolStripSeparator
    Friend WithEvents mnuTransaksiPembukuanPelunasan As ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuanKartuPiutang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuanKartuHutang As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembukuanJurnalUmumAutoGenerate As ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuanNeracaSaldo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuanNeraca As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuanLabaRugi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterPersediaan As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanStock As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanStockPermintaanPenjualan As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanStockPengirimanPenjualan As ToolStripMenuItem
    Friend WithEvents mnuLaporanPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPembelianSPKPotong As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanSep1 As ToolStripSeparator
    Friend WithEvents mnuTransaksiPenjualanReturPenjualan As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanPengajuanKlaim As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanKonfirmasiKlaim As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianPengajuanKlaim As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianKonfirmasiKlaim As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTransaksiPenjualanKonfirmasiPesanan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPembukuanPIPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLaporanPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLaporanPenjualanKonfirmasiPesanan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembukuanPembayaranBiayaPotong As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBuildDate As ToolStripStatusLabel
    Friend WithEvents mnuTransaksiPembukuanKasBankVoucher As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembukuanSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMasterSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMasterLokasiPengiriman As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterJenisBiayaTransportasi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanJasa As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanJasaPengiriman As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanJasaProsesPotong As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanJasaPelunasanPengiriman As ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanJasaSep1 As ToolStripSeparator
    Friend WithEvents mnuTransaksiPenjualanJasaPelunasanPemotongan As ToolStripMenuItem
End Class
