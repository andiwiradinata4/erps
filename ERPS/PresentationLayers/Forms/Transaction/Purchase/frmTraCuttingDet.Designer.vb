<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraCuttingDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraCuttingDet))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.txtCoACodeOfStock = New ERPS.usTextBox()
        Me.txtCoANameOfStock = New ERPS.usTextBox()
        Me.btnCoAOfStock = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPONumber = New ERPS.usTextBox()
        Me.btnPurchaseOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtReferencesNumber = New ERPS.usTextBox()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.txtBPCode = New ERPS.usTextBox()
        Me.txtBPName = New ERPS.usTextBox()
        Me.txtCuttingNumber = New ERPS.usTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboStatus = New ERPS.usComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.dtpCuttingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBP = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpPrice = New System.Windows.Forms.TabPage()
        Me.gboPesanan = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New ERPS.usNumeric()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalPPH = New ERPS.usNumeric()
        Me.txtTotalDPP = New ERPS.usNumeric()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotalPPN = New ERPS.usNumeric()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPPH = New ERPS.usNumeric()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPPN = New ERPS.usNumeric()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.tcDetail = New System.Windows.Forms.TabControl()
        Me.tpItem = New System.Windows.Forms.TabPage()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolBarItem = New ERPS.usToolBar()
        Me.BarAddItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDetailItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDeleteItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.tpItemResult = New System.Windows.Forms.TabPage()
        Me.grdItemResult = New DevExpress.XtraGrid.GridControl()
        Me.grdItemResultView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.tpPrice.SuspendLayout()
        Me.gboPesanan.SuspendLayout()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDPP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcDetail.SuspendLayout()
        Me.tpItem.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.tpItemResult.SuspendLayout()
        CType(Me.grdItemResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemResultView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(925, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarRefresh
        '
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.Tag = "Save"
        Me.BarRefresh.Text = "Simpan"
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Tag = "Close"
        Me.BarClose.Text = "Tutup"
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(925, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Proses Pemotongan Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpPrice)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(925, 200)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.txtCoACodeOfStock)
        Me.tpMain.Controls.Add(Me.txtCoANameOfStock)
        Me.tpMain.Controls.Add(Me.btnCoAOfStock)
        Me.tpMain.Controls.Add(Me.Label5)
        Me.tpMain.Controls.Add(Me.txtPONumber)
        Me.tpMain.Controls.Add(Me.btnPurchaseOrder)
        Me.tpMain.Controls.Add(Me.Label9)
        Me.tpMain.Controls.Add(Me.txtReferencesNumber)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.txtBPCode)
        Me.tpMain.Controls.Add(Me.txtBPName)
        Me.tpMain.Controls.Add(Me.txtCuttingNumber)
        Me.tpMain.Controls.Add(Me.Label19)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.lblStatusID)
        Me.tpMain.Controls.Add(Me.dtpCuttingDate)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.btnBP)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(917, 171)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtCoACodeOfStock
        '
        Me.txtCoACodeOfStock.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfStock.Location = New System.Drawing.Point(584, 16)
        Me.txtCoACodeOfStock.MaxLength = 250
        Me.txtCoACodeOfStock.Name = "txtCoACodeOfStock"
        Me.txtCoACodeOfStock.ReadOnly = True
        Me.txtCoACodeOfStock.Size = New System.Drawing.Size(59, 21)
        Me.txtCoACodeOfStock.TabIndex = 8
        '
        'txtCoANameOfStock
        '
        Me.txtCoANameOfStock.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfStock.Location = New System.Drawing.Point(642, 16)
        Me.txtCoANameOfStock.MaxLength = 250
        Me.txtCoANameOfStock.Name = "txtCoANameOfStock"
        Me.txtCoANameOfStock.ReadOnly = True
        Me.txtCoANameOfStock.Size = New System.Drawing.Size(191, 21)
        Me.txtCoANameOfStock.TabIndex = 9
        '
        'btnCoAOfStock
        '
        Me.btnCoAOfStock.Image = CType(resources.GetObject("btnCoAOfStock.Image"), System.Drawing.Image)
        Me.btnCoAOfStock.Location = New System.Drawing.Point(839, 15)
        Me.btnCoAOfStock.Name = "btnCoAOfStock"
        Me.btnCoAOfStock.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfStock.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(494, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 158
        Me.Label5.Text = "Persediaan"
        '
        'txtPONumber
        '
        Me.txtPONumber.BackColor = System.Drawing.Color.Azure
        Me.txtPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPONumber.Location = New System.Drawing.Point(126, 97)
        Me.txtPONumber.MaxLength = 250
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.ReadOnly = True
        Me.txtPONumber.Size = New System.Drawing.Size(249, 21)
        Me.txtPONumber.TabIndex = 5
        '
        'btnPurchaseOrder
        '
        Me.btnPurchaseOrder.Image = CType(resources.GetObject("btnPurchaseOrder.Image"), System.Drawing.Image)
        Me.btnPurchaseOrder.Location = New System.Drawing.Point(381, 96)
        Me.btnPurchaseOrder.Name = "btnPurchaseOrder"
        Me.btnPurchaseOrder.Size = New System.Drawing.Size(23, 23)
        Me.btnPurchaseOrder.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(28, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "Nomor Pesanan"
        '
        'txtReferencesNumber
        '
        Me.txtReferencesNumber.BackColor = System.Drawing.Color.White
        Me.txtReferencesNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencesNumber.Location = New System.Drawing.Point(126, 124)
        Me.txtReferencesNumber.MaxLength = 250
        Me.txtReferencesNumber.Name = "txtReferencesNumber"
        Me.txtReferencesNumber.Size = New System.Drawing.Size(249, 21)
        Me.txtReferencesNumber.TabIndex = 7
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(584, 70)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 12
        '
        'txtBPCode
        '
        Me.txtBPCode.BackColor = System.Drawing.Color.Azure
        Me.txtBPCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPCode.Location = New System.Drawing.Point(126, 43)
        Me.txtBPCode.MaxLength = 250
        Me.txtBPCode.Name = "txtBPCode"
        Me.txtBPCode.ReadOnly = True
        Me.txtBPCode.Size = New System.Drawing.Size(83, 21)
        Me.txtBPCode.TabIndex = 1
        '
        'txtBPName
        '
        Me.txtBPName.BackColor = System.Drawing.Color.Azure
        Me.txtBPName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPName.Location = New System.Drawing.Point(208, 43)
        Me.txtBPName.MaxLength = 250
        Me.txtBPName.Name = "txtBPName"
        Me.txtBPName.ReadOnly = True
        Me.txtBPName.Size = New System.Drawing.Size(167, 21)
        Me.txtBPName.TabIndex = 2
        '
        'txtCuttingNumber
        '
        Me.txtCuttingNumber.BackColor = System.Drawing.Color.White
        Me.txtCuttingNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuttingNumber.Location = New System.Drawing.Point(126, 16)
        Me.txtCuttingNumber.MaxLength = 250
        Me.txtCuttingNumber.Name = "txtCuttingNumber"
        Me.txtCuttingNumber.Size = New System.Drawing.Size(167, 21)
        Me.txtCuttingNumber.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(28, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "No. Referensi"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(494, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(584, 43)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(105, 21)
        Me.cboStatus.TabIndex = 11
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(494, 47)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusID.TabIndex = 128
        Me.lblStatusID.Text = "Status"
        '
        'dtpCuttingDate
        '
        Me.dtpCuttingDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCuttingDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCuttingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCuttingDate.Location = New System.Drawing.Point(126, 70)
        Me.dtpCuttingDate.Name = "dtpCuttingDate"
        Me.dtpCuttingDate.Size = New System.Drawing.Size(105, 21)
        Me.dtpCuttingDate.TabIndex = 4
        Me.dtpCuttingDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Tanggal"
        '
        'btnBP
        '
        Me.btnBP.Image = CType(resources.GetObject("btnBP.Image"), System.Drawing.Image)
        Me.btnBP.Location = New System.Drawing.Point(381, 42)
        Me.btnBP.Name = "btnBP"
        Me.btnBP.Size = New System.Drawing.Size(23, 23)
        Me.btnBP.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(28, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Pemasok"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Nomor"
        '
        'tpPrice
        '
        Me.tpPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpPrice.Controls.Add(Me.gboPesanan)
        Me.tpPrice.Controls.Add(Me.Label7)
        Me.tpPrice.Controls.Add(Me.Label8)
        Me.tpPrice.Controls.Add(Me.txtPPH)
        Me.tpPrice.Controls.Add(Me.Label6)
        Me.tpPrice.Controls.Add(Me.Label11)
        Me.tpPrice.Controls.Add(Me.txtPPN)
        Me.tpPrice.Location = New System.Drawing.Point(4, 25)
        Me.tpPrice.Name = "tpPrice"
        Me.tpPrice.Size = New System.Drawing.Size(917, 171)
        Me.tpPrice.TabIndex = 2
        Me.tpPrice.Text = "Harga- F2"
        Me.tpPrice.UseVisualStyleBackColor = True
        '
        'gboPesanan
        '
        Me.gboPesanan.Controls.Add(Me.Label15)
        Me.gboPesanan.Controls.Add(Me.txtGrandTotal)
        Me.gboPesanan.Controls.Add(Me.Label16)
        Me.gboPesanan.Controls.Add(Me.txtTotalPPH)
        Me.gboPesanan.Controls.Add(Me.txtTotalDPP)
        Me.gboPesanan.Controls.Add(Me.Label17)
        Me.gboPesanan.Controls.Add(Me.Label18)
        Me.gboPesanan.Controls.Add(Me.txtTotalPPN)
        Me.gboPesanan.Location = New System.Drawing.Point(27, 14)
        Me.gboPesanan.Name = "gboPesanan"
        Me.gboPesanan.Size = New System.Drawing.Size(334, 138)
        Me.gboPesanan.TabIndex = 0
        Me.gboPesanan.TabStop = False
        Me.gboPesanan.Text = "Total Harga"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(19, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "Grand Total"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotal.DecimalPlaces = 2
        Me.txtGrandTotal.Enabled = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(115, 104)
        Me.txtGrandTotal.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotal.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Size = New System.Drawing.Size(186, 21)
        Me.txtGrandTotal.TabIndex = 3
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotal.ThousandsSeparator = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(19, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 123
        Me.Label16.Text = "Total PPh"
        '
        'txtTotalPPH
        '
        Me.txtTotalPPH.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPH.DecimalPlaces = 2
        Me.txtTotalPPH.Enabled = False
        Me.txtTotalPPH.Location = New System.Drawing.Point(115, 77)
        Me.txtTotalPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPH.Name = "txtTotalPPH"
        Me.txtTotalPPH.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalPPH.TabIndex = 2
        Me.txtTotalPPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPH.ThousandsSeparator = True
        '
        'txtTotalDPP
        '
        Me.txtTotalDPP.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalDPP.DecimalPlaces = 2
        Me.txtTotalDPP.Enabled = False
        Me.txtTotalDPP.Location = New System.Drawing.Point(115, 23)
        Me.txtTotalDPP.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalDPP.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalDPP.Name = "txtTotalDPP"
        Me.txtTotalDPP.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalDPP.TabIndex = 0
        Me.txtTotalDPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDPP.ThousandsSeparator = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 121
        Me.Label17.Text = "Total PPN"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(19, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 119
        Me.Label18.Text = "Total DPP"
        '
        'txtTotalPPN
        '
        Me.txtTotalPPN.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPN.DecimalPlaces = 2
        Me.txtTotalPPN.Enabled = False
        Me.txtTotalPPN.Location = New System.Drawing.Point(115, 50)
        Me.txtTotalPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPN.Name = "txtTotalPPN"
        Me.txtTotalPPN.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalPPN.TabIndex = 1
        Me.txtTotalPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPN.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(475, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(395, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "PPh"
        '
        'txtPPH
        '
        Me.txtPPH.DecimalPlaces = 2
        Me.txtPPH.Location = New System.Drawing.Point(395, 91)
        Me.txtPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPPH.Name = "txtPPH"
        Me.txtPPH.Size = New System.Drawing.Size(77, 21)
        Me.txtPPH.TabIndex = 2
        Me.txtPPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPPH.ThousandsSeparator = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(475, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(395, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 121
        Me.Label11.Text = "PPN"
        '
        'txtPPN
        '
        Me.txtPPN.DecimalPlaces = 2
        Me.txtPPN.Location = New System.Drawing.Point(395, 37)
        Me.txtPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPPN.Name = "txtPPN"
        Me.txtPPN.Size = New System.Drawing.Size(77, 21)
        Me.txtPPN.TabIndex = 1
        Me.txtPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPPN.ThousandsSeparator = True
        '
        'tpHistory
        '
        Me.tpHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHistory.Size = New System.Drawing.Size(917, 171)
        Me.tpHistory.TabIndex = 1
        Me.tpHistory.Text = "History - F3"
        Me.tpHistory.UseVisualStyleBackColor = True
        '
        'grdStatus
        '
        Me.grdStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdStatus.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdStatus.Location = New System.Drawing.Point(3, 3)
        Me.grdStatus.MainView = Me.grdStatusView
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.Size = New System.Drawing.Size(907, 161)
        Me.grdStatus.TabIndex = 13
        Me.grdStatus.UseEmbeddedNavigator = True
        Me.grdStatus.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdStatusView})
        '
        'grdStatusView
        '
        Me.grdStatusView.GridControl = Me.grdStatus
        Me.grdStatusView.Name = "grdStatusView"
        Me.grdStatusView.OptionsCustomization.AllowColumnMoving = False
        Me.grdStatusView.OptionsCustomization.AllowGroup = False
        Me.grdStatusView.OptionsView.ColumnAutoWidth = False
        Me.grdStatusView.OptionsView.ShowGroupPanel = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 250)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(925, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "« Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 638)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(925, 23)
        Me.pgMain.TabIndex = 5
        '
        'tcDetail
        '
        Me.tcDetail.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcDetail.Controls.Add(Me.tpItem)
        Me.tcDetail.Controls.Add(Me.tpItemResult)
        Me.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcDetail.Location = New System.Drawing.Point(0, 272)
        Me.tcDetail.Name = "tcDetail"
        Me.tcDetail.SelectedIndex = 0
        Me.tcDetail.Size = New System.Drawing.Size(925, 366)
        Me.tcDetail.TabIndex = 4
        '
        'tpItem
        '
        Me.tpItem.Controls.Add(Me.grdItem)
        Me.tpItem.Controls.Add(Me.StatusStrip)
        Me.tpItem.Controls.Add(Me.ToolBarItem)
        Me.tpItem.Location = New System.Drawing.Point(4, 25)
        Me.tpItem.Name = "tpItem"
        Me.tpItem.Padding = New System.Windows.Forms.Padding(3)
        Me.tpItem.Size = New System.Drawing.Size(917, 337)
        Me.tpItem.TabIndex = 1
        Me.tpItem.Text = "Item PO - F4"
        Me.tpItem.UseVisualStyleBackColor = True
        '
        'grdItem
        '
        Me.grdItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdItem.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdItem.Location = New System.Drawing.Point(3, 31)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.grdItem.Size = New System.Drawing.Size(911, 281)
        Me.grdItem.TabIndex = 1
        Me.grdItem.UseEmbeddedNavigator = True
        Me.grdItem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemView})
        '
        'grdItemView
        '
        Me.grdItemView.GridControl = Me.grdItem
        Me.grdItemView.Name = "grdItemView"
        Me.grdItemView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemView.OptionsCustomization.AllowGroup = False
        Me.grdItemView.OptionsView.ColumnAutoWidth = False
        Me.grdItemView.OptionsView.ShowAutoFilterRow = True
        Me.grdItemView.OptionsView.ShowFooter = True
        Me.grdItemView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "0.00"
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(3, 312)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(911, 22)
        Me.StatusStrip.TabIndex = 2
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(788, 17)
        Me.ToolStripEmpty.Spring = True
        '
        'ToolStripLogInc
        '
        Me.ToolStripLogInc.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripLogInc.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripLogInc.Name = "ToolStripLogInc"
        Me.ToolStripLogInc.Size = New System.Drawing.Size(48, 17)
        Me.ToolStripLogInc.Text = "Log Inc : "
        '
        'ToolStripLogBy
        '
        Me.ToolStripLogBy.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripLogBy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripLogBy.Name = "ToolStripLogBy"
        Me.ToolStripLogBy.Size = New System.Drawing.Size(48, 17)
        Me.ToolStripLogBy.Text = "Last Log :"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripLogDate
        '
        Me.ToolStripLogDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripLogDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripLogDate.Name = "ToolStripLogDate"
        Me.ToolStripLogDate.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripLogDate.Text = "-"
        '
        'ToolBarItem
        '
        Me.ToolBarItem.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItem.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddItemOrder, Me.BarDetailItemOrder, Me.BarDeleteItemOrder})
        Me.ToolBarItem.DropDownArrows = True
        Me.ToolBarItem.Location = New System.Drawing.Point(3, 3)
        Me.ToolBarItem.Name = "ToolBarItem"
        Me.ToolBarItem.ShowToolTips = True
        Me.ToolBarItem.Size = New System.Drawing.Size(911, 28)
        Me.ToolBarItem.TabIndex = 0
        Me.ToolBarItem.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAddItemOrder
        '
        Me.BarAddItemOrder.Name = "BarAddItemOrder"
        Me.BarAddItemOrder.Tag = "Add"
        Me.BarAddItemOrder.Text = "Tambah"
        '
        'BarDetailItemOrder
        '
        Me.BarDetailItemOrder.Name = "BarDetailItemOrder"
        Me.BarDetailItemOrder.Tag = "Edit"
        Me.BarDetailItemOrder.Text = "Edit"
        '
        'BarDeleteItemOrder
        '
        Me.BarDeleteItemOrder.Name = "BarDeleteItemOrder"
        Me.BarDeleteItemOrder.Tag = "Delete"
        Me.BarDeleteItemOrder.Text = "Hapus"
        '
        'tpItemResult
        '
        Me.tpItemResult.Controls.Add(Me.grdItemResult)
        Me.tpItemResult.Location = New System.Drawing.Point(4, 25)
        Me.tpItemResult.Name = "tpItemResult"
        Me.tpItemResult.Size = New System.Drawing.Size(917, 337)
        Me.tpItemResult.TabIndex = 2
        Me.tpItemResult.Text = "Hasil - F5"
        Me.tpItemResult.UseVisualStyleBackColor = True
        '
        'grdItemResult
        '
        Me.grdItemResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdItemResult.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdItemResult.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdItemResult.Location = New System.Drawing.Point(0, 0)
        Me.grdItemResult.MainView = Me.grdItemResultView
        Me.grdItemResult.Name = "grdItemResult"
        Me.grdItemResult.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit3})
        Me.grdItemResult.Size = New System.Drawing.Size(917, 337)
        Me.grdItemResult.TabIndex = 2
        Me.grdItemResult.UseEmbeddedNavigator = True
        Me.grdItemResult.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemResultView})
        '
        'grdItemResultView
        '
        Me.grdItemResultView.GridControl = Me.grdItemResult
        Me.grdItemResultView.Name = "grdItemResultView"
        Me.grdItemResultView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemResultView.OptionsCustomization.AllowGroup = False
        Me.grdItemResultView.OptionsView.ColumnAutoWidth = False
        Me.grdItemResultView.OptionsView.ShowAutoFilterRow = True
        Me.grdItemResultView.OptionsView.ShowFooter = True
        Me.grdItemResultView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.NullText = "0.00"
        '
        'frmTraCuttingDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 661)
        Me.Controls.Add(Me.tcDetail)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraCuttingDet"
        Me.Text = "Proses Pemotongan"
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        Me.tpPrice.ResumeLayout(False)
        Me.tpPrice.PerformLayout()
        Me.gboPesanan.ResumeLayout(False)
        Me.gboPesanan.PerformLayout()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDPP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcDetail.ResumeLayout(False)
        Me.tpItem.ResumeLayout(False)
        Me.tpItem.PerformLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.tpItemResult.ResumeLayout(False)
        CType(Me.grdItemResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemResultView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tcHeader As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents txtReferencesNumber As ERPS.usTextBox
    Friend WithEvents txtRemarks As ERPS.usTextBox
    Friend WithEvents txtBPCode As ERPS.usTextBox
    Friend WithEvents txtBPName As ERPS.usTextBox
    Friend WithEvents txtCuttingNumber As ERPS.usTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents dtpCuttingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tpHistory As System.Windows.Forms.TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents tcDetail As System.Windows.Forms.TabControl
    Friend WithEvents tpItem As System.Windows.Forms.TabPage
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolBarItem As ERPS.usToolBar
    Friend WithEvents BarAddItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetailItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeleteItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents tpItemResult As System.Windows.Forms.TabPage
    Friend WithEvents grdItemResult As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemResultView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents tpPrice As TabPage
    Friend WithEvents gboPesanan As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtGrandTotal As usNumeric
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTotalPPH As usNumeric
    Friend WithEvents txtTotalDPP As usNumeric
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtTotalPPN As usNumeric
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPPH As usNumeric
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPPN As usNumeric
    Friend WithEvents txtPONumber As ERPS.usTextBox
    Friend WithEvents btnPurchaseOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfStock As ERPS.usTextBox
    Friend WithEvents txtCoANameOfStock As ERPS.usTextBox
    Friend WithEvents btnCoAOfStock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
