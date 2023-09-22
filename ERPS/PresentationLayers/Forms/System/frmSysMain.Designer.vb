<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.tssUserID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssProgram = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCompany = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssServer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterProgram = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterModule = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterAkses = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterPerusahaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterKaryawan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSatuan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterJenisBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSpesifikasiBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMasterRekanBisnis = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterAkunBankPerusahaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterJenisPembayaran = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanPermintaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanKontrakPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanMemoPengambilan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPenjualanPengirimanPenjualan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianPesananPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianPesananPemotongan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianPesananPengiriman = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianKonfirmasiPesanan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianKontrakPembelian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianInstruksi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianKonfirmasiPengiriman = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksiPembelianProsesPemotonganSPK = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaporan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPengaturan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettingUbahPassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTampilan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCloseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterPaymentTypeCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterMetodePembayaran = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssUserID, Me.tssProgram, Me.tssCompany, Me.tssVersion, Me.tssServer})
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
        Me.mnuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMasterProgram, Me.mnuMasterStatus, Me.mnuMasterModule, Me.mnuMasterAkses, Me.mnuMasterPerusahaan, Me.mnuMasterKaryawan, Me.mnuMasterSatuan, Me.mnuMasterJenisBarang, Me.mnuMasterSpesifikasiBarang, Me.mnuMasterBarang, Me.mnuMasterSep1, Me.mnuMasterRekanBisnis, Me.mnuMasterAkunBankPerusahaan, Me.mnuMasterPaymentTypeCategory, Me.mnuMasterMetodePembayaran, Me.mnuMasterJenisPembayaran})
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
        'mnuMasterSep1
        '
        Me.mnuMasterSep1.Name = "mnuMasterSep1"
        Me.mnuMasterSep1.Size = New System.Drawing.Size(196, 6)
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
        'mnuMasterJenisPembayaran
        '
        Me.mnuMasterJenisPembayaran.Name = "mnuMasterJenisPembayaran"
        Me.mnuMasterJenisPembayaran.Size = New System.Drawing.Size(199, 22)
        Me.mnuMasterJenisPembayaran.Text = "Jenis Pembayaran"
        '
        'mnuTransaksi
        '
        Me.mnuTransaksi.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPenjualan, Me.mnuTransaksiPembelian})
        Me.mnuTransaksi.Name = "mnuTransaksi"
        Me.mnuTransaksi.Size = New System.Drawing.Size(66, 20)
        Me.mnuTransaksi.Text = "&Transaksi"
        '
        'mnuTransaksiPenjualan
        '
        Me.mnuTransaksiPenjualan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPenjualanPermintaan, Me.mnuTransaksiPenjualanKontrakPenjualan, Me.mnuTransaksiPenjualanMemoPengambilan, Me.mnuTransaksiPenjualanPengirimanPenjualan})
        Me.mnuTransaksiPenjualan.Name = "mnuTransaksiPenjualan"
        Me.mnuTransaksiPenjualan.Size = New System.Drawing.Size(130, 22)
        Me.mnuTransaksiPenjualan.Text = "Penjualan"
        '
        'mnuTransaksiPenjualanPermintaan
        '
        Me.mnuTransaksiPenjualanPermintaan.Name = "mnuTransaksiPenjualanPermintaan"
        Me.mnuTransaksiPenjualanPermintaan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanPermintaan.Text = "Permintaan Penjualan"
        '
        'mnuTransaksiPenjualanKontrakPenjualan
        '
        Me.mnuTransaksiPenjualanKontrakPenjualan.Name = "mnuTransaksiPenjualanKontrakPenjualan"
        Me.mnuTransaksiPenjualanKontrakPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanKontrakPenjualan.Text = "Kontrak Penjualan"
        '
        'mnuTransaksiPenjualanMemoPengambilan
        '
        Me.mnuTransaksiPenjualanMemoPengambilan.Name = "mnuTransaksiPenjualanMemoPengambilan"
        Me.mnuTransaksiPenjualanMemoPengambilan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanMemoPengambilan.Text = "Memo Pengambilan"
        '
        'mnuTransaksiPenjualanPengirimanPenjualan
        '
        Me.mnuTransaksiPenjualanPengirimanPenjualan.Name = "mnuTransaksiPenjualanPengirimanPenjualan"
        Me.mnuTransaksiPenjualanPengirimanPenjualan.Size = New System.Drawing.Size(190, 22)
        Me.mnuTransaksiPenjualanPengirimanPenjualan.Text = "Pengiriman Penjualan"
        '
        'mnuTransaksiPembelian
        '
        Me.mnuTransaksiPembelian.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTransaksiPembelianPesananPembelian, Me.mnuTransaksiPembelianPesananPemotongan, Me.mnuTransaksiPembelianPesananPengiriman, Me.mnuTransaksiPembelianKonfirmasiPesanan, Me.mnuTransaksiPembelianKontrakPembelian, Me.mnuTransaksiPembelianInstruksi, Me.mnuTransaksiPembelianKonfirmasiPengiriman, Me.mnuTransaksiPembelianProsesPemotonganSPK})
        Me.mnuTransaksiPembelian.Name = "mnuTransaksiPembelian"
        Me.mnuTransaksiPembelian.Size = New System.Drawing.Size(130, 22)
        Me.mnuTransaksiPembelian.Text = "Pembelian"
        '
        'mnuTransaksiPembelianPesananPembelian
        '
        Me.mnuTransaksiPembelianPesananPembelian.Name = "mnuTransaksiPembelianPesananPembelian"
        Me.mnuTransaksiPembelianPesananPembelian.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianPesananPembelian.Text = "Pesanan Pembelian"
        '
        'mnuTransaksiPembelianPesananPemotongan
        '
        Me.mnuTransaksiPembelianPesananPemotongan.Name = "mnuTransaksiPembelianPesananPemotongan"
        Me.mnuTransaksiPembelianPesananPemotongan.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianPesananPemotongan.Text = "Pesanan Pemotongan"
        '
        'mnuTransaksiPembelianPesananPengiriman
        '
        Me.mnuTransaksiPembelianPesananPengiriman.Name = "mnuTransaksiPembelianPesananPengiriman"
        Me.mnuTransaksiPembelianPesananPengiriman.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianPesananPengiriman.Text = "Pesanan Pengiriman"
        '
        'mnuTransaksiPembelianKonfirmasiPesanan
        '
        Me.mnuTransaksiPembelianKonfirmasiPesanan.Name = "mnuTransaksiPembelianKonfirmasiPesanan"
        Me.mnuTransaksiPembelianKonfirmasiPesanan.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianKonfirmasiPesanan.Text = "Konfirmasi Pesanan"
        '
        'mnuTransaksiPembelianKontrakPembelian
        '
        Me.mnuTransaksiPembelianKontrakPembelian.Name = "mnuTransaksiPembelianKontrakPembelian"
        Me.mnuTransaksiPembelianKontrakPembelian.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianKontrakPembelian.Text = "Kontrak Pembelian"
        '
        'mnuTransaksiPembelianInstruksi
        '
        Me.mnuTransaksiPembelianInstruksi.Name = "mnuTransaksiPembelianInstruksi"
        Me.mnuTransaksiPembelianInstruksi.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianInstruksi.Text = "Instruksi"
        '
        'mnuTransaksiPembelianKonfirmasiPengiriman
        '
        Me.mnuTransaksiPembelianKonfirmasiPengiriman.Name = "mnuTransaksiPembelianKonfirmasiPengiriman"
        Me.mnuTransaksiPembelianKonfirmasiPengiriman.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianKonfirmasiPengiriman.Text = "Konfirmasi Pengiriman"
        '
        'mnuTransaksiPembelianProsesPemotonganSPK
        '
        Me.mnuTransaksiPembelianProsesPemotonganSPK.Name = "mnuTransaksiPembelianProsesPemotonganSPK"
        Me.mnuTransaksiPembelianProsesPemotonganSPK.Size = New System.Drawing.Size(211, 22)
        Me.mnuTransaksiPembelianProsesPemotonganSPK.Text = "Proses Pemotongan (SPK)"
        '
        'mnuLaporan
        '
        Me.mnuLaporan.Name = "mnuLaporan"
        Me.mnuLaporan.Size = New System.Drawing.Size(62, 20)
        Me.mnuLaporan.Text = "&Laporan"
        '
        'mnuPengaturan
        '
        Me.mnuPengaturan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingUbahPassword})
        Me.mnuPengaturan.Name = "mnuPengaturan"
        Me.mnuPengaturan.Size = New System.Drawing.Size(80, 20)
        Me.mnuPengaturan.Text = "&Pengaturan"
        '
        'mnuSettingUbahPassword
        '
        Me.mnuSettingUbahPassword.Name = "mnuSettingUbahPassword"
        Me.mnuSettingUbahPassword.Size = New System.Drawing.Size(155, 22)
        Me.mnuSettingUbahPassword.Text = "Ubah Password"
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
    Friend WithEvents mnuTransaksiPenjualanPermintaan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanKontrakPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanMemoPengambilan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPenjualanPengirimanPenjualan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianPesananPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianPesananPemotongan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianPesananPengiriman As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianKonfirmasiPesanan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianKontrakPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianInstruksi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianKonfirmasiPengiriman As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksiPembelianProsesPemotonganSPK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterPaymentTypeCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterMetodePembayaran As System.Windows.Forms.ToolStripMenuItem
End Class
