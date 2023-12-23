<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysJournalPost
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysJournalPost))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.txtCoACodeOfPurchaseTax = New ERPS.usTextBox()
        Me.txtCoANameOfPurchaseTax = New ERPS.usTextBox()
        Me.btnCoAOfPurchaseTax = New DevExpress.XtraEditors.SimpleButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfAdvancePayment = New ERPS.usTextBox()
        Me.txtCoANameOfAdvancePayment = New ERPS.usTextBox()
        Me.btnCoAOfAdvancePayment = New DevExpress.XtraEditors.SimpleButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfEquipments = New ERPS.usTextBox()
        Me.txtCoACodeOfSalesTax = New ERPS.usTextBox()
        Me.txtCoANameOfEquipments = New ERPS.usTextBox()
        Me.btnCoAOfEquipments = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCoANameOfSalesTax = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCoAOfSalesTax = New DevExpress.XtraEditors.SimpleButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfPurchaseDiscount = New ERPS.usTextBox()
        Me.txtCoANameOfPurchaseDiscount = New ERPS.usTextBox()
        Me.btnCoAOfPurchaseDiscount = New DevExpress.XtraEditors.SimpleButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfAccountPayable = New ERPS.usTextBox()
        Me.txtCoANameOfAccountPayable = New ERPS.usTextBox()
        Me.btnCoAOfAccountPayable = New DevExpress.XtraEditors.SimpleButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfCashOrBank = New ERPS.usTextBox()
        Me.txtCoANameOfCashOrBank = New ERPS.usTextBox()
        Me.btnCoAOfCashOrBank = New DevExpress.XtraEditors.SimpleButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfStock = New ERPS.usTextBox()
        Me.txtCoANameOfStock = New ERPS.usTextBox()
        Me.btnCoAOfStock = New DevExpress.XtraEditors.SimpleButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfCOGS = New ERPS.usTextBox()
        Me.txtCoANameOfCOGS = New ERPS.usTextBox()
        Me.btnCoAOfCOGS = New DevExpress.XtraEditors.SimpleButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfPrepaidIncome = New ERPS.usTextBox()
        Me.txtCoANameOfPrepaidIncome = New ERPS.usTextBox()
        Me.btnCoAOfPrepaidIncome = New DevExpress.XtraEditors.SimpleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfSalesDiscount = New ERPS.usTextBox()
        Me.txtCoANameOfSalesDiscount = New ERPS.usTextBox()
        Me.btnCoAOfSalesDiscount = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfAccountReceivable = New ERPS.usTextBox()
        Me.txtCoANameOfAccountReceivable = New ERPS.usTextBox()
        Me.btnCoAOfAccountReceivable = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCoACodeOfRevenue = New ERPS.usTextBox()
        Me.txtCoANameOfRevenue = New ERPS.usTextBox()
        Me.btnCoAOfRevenue = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtCoACodeofVentureCapital = New ERPS.usTextBox()
        Me.txtCoANameofVentureCapital = New ERPS.usTextBox()
        Me.btnCoAofVentureCapital = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
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
        Me.ToolBar.Size = New System.Drawing.Size(644, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(644, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Posting Jurnal Transaksi"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMain.Controls.Add(Me.txtCoACodeofVentureCapital)
        Me.pnlMain.Controls.Add(Me.txtCoANameofVentureCapital)
        Me.pnlMain.Controls.Add(Me.btnCoAofVentureCapital)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfPurchaseTax)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfPurchaseTax)
        Me.pnlMain.Controls.Add(Me.btnCoAOfPurchaseTax)
        Me.pnlMain.Controls.Add(Me.Label15)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfAdvancePayment)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfAdvancePayment)
        Me.pnlMain.Controls.Add(Me.btnCoAOfAdvancePayment)
        Me.pnlMain.Controls.Add(Me.Label14)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfEquipments)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfSalesTax)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfEquipments)
        Me.pnlMain.Controls.Add(Me.btnCoAOfEquipments)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfSalesTax)
        Me.pnlMain.Controls.Add(Me.Label13)
        Me.pnlMain.Controls.Add(Me.btnCoAOfSalesTax)
        Me.pnlMain.Controls.Add(Me.Label12)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfPurchaseDiscount)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfPurchaseDiscount)
        Me.pnlMain.Controls.Add(Me.btnCoAOfPurchaseDiscount)
        Me.pnlMain.Controls.Add(Me.Label11)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfAccountPayable)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfAccountPayable)
        Me.pnlMain.Controls.Add(Me.btnCoAOfAccountPayable)
        Me.pnlMain.Controls.Add(Me.Label10)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfCashOrBank)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfCashOrBank)
        Me.pnlMain.Controls.Add(Me.btnCoAOfCashOrBank)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfStock)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfStock)
        Me.pnlMain.Controls.Add(Me.btnCoAOfStock)
        Me.pnlMain.Controls.Add(Me.Label8)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfCOGS)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfCOGS)
        Me.pnlMain.Controls.Add(Me.btnCoAOfCOGS)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfPrepaidIncome)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfPrepaidIncome)
        Me.pnlMain.Controls.Add(Me.btnCoAOfPrepaidIncome)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfSalesDiscount)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfSalesDiscount)
        Me.pnlMain.Controls.Add(Me.btnCoAOfSalesDiscount)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfAccountReceivable)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfAccountReceivable)
        Me.pnlMain.Controls.Add(Me.btnCoAOfAccountReceivable)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.txtCoACodeOfRevenue)
        Me.pnlMain.Controls.Add(Me.txtCoANameOfRevenue)
        Me.pnlMain.Controls.Add(Me.btnCoAOfRevenue)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 50)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(644, 417)
        Me.pnlMain.TabIndex = 2
        '
        'txtCoACodeOfPurchaseTax
        '
        Me.txtCoACodeOfPurchaseTax.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfPurchaseTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfPurchaseTax.Location = New System.Drawing.Point(189, 337)
        Me.txtCoACodeOfPurchaseTax.MaxLength = 250
        Me.txtCoACodeOfPurchaseTax.Name = "txtCoACodeOfPurchaseTax"
        Me.txtCoACodeOfPurchaseTax.ReadOnly = True
        Me.txtCoACodeOfPurchaseTax.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfPurchaseTax.TabIndex = 36
        '
        'txtCoANameOfPurchaseTax
        '
        Me.txtCoANameOfPurchaseTax.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfPurchaseTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfPurchaseTax.Location = New System.Drawing.Point(271, 337)
        Me.txtCoANameOfPurchaseTax.MaxLength = 250
        Me.txtCoANameOfPurchaseTax.Name = "txtCoANameOfPurchaseTax"
        Me.txtCoANameOfPurchaseTax.ReadOnly = True
        Me.txtCoANameOfPurchaseTax.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfPurchaseTax.TabIndex = 37
        '
        'btnCoAOfPurchaseTax
        '
        Me.btnCoAOfPurchaseTax.Image = CType(resources.GetObject("btnCoAOfPurchaseTax.Image"), System.Drawing.Image)
        Me.btnCoAOfPurchaseTax.Location = New System.Drawing.Point(597, 335)
        Me.btnCoAOfPurchaseTax.Name = "btnCoAOfPurchaseTax"
        Me.btnCoAOfPurchaseTax.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfPurchaseTax.TabIndex = 38
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(33, 341)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 178
        Me.Label15.Text = "Pajak Pembelian"
        '
        'txtCoACodeOfAdvancePayment
        '
        Me.txtCoACodeOfAdvancePayment.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfAdvancePayment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfAdvancePayment.Location = New System.Drawing.Point(189, 283)
        Me.txtCoACodeOfAdvancePayment.MaxLength = 250
        Me.txtCoACodeOfAdvancePayment.Name = "txtCoACodeOfAdvancePayment"
        Me.txtCoACodeOfAdvancePayment.ReadOnly = True
        Me.txtCoACodeOfAdvancePayment.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfAdvancePayment.TabIndex = 30
        '
        'txtCoANameOfAdvancePayment
        '
        Me.txtCoANameOfAdvancePayment.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfAdvancePayment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfAdvancePayment.Location = New System.Drawing.Point(271, 283)
        Me.txtCoANameOfAdvancePayment.MaxLength = 250
        Me.txtCoANameOfAdvancePayment.Name = "txtCoANameOfAdvancePayment"
        Me.txtCoANameOfAdvancePayment.ReadOnly = True
        Me.txtCoANameOfAdvancePayment.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfAdvancePayment.TabIndex = 31
        '
        'btnCoAOfAdvancePayment
        '
        Me.btnCoAOfAdvancePayment.Image = CType(resources.GetObject("btnCoAOfAdvancePayment.Image"), System.Drawing.Image)
        Me.btnCoAOfAdvancePayment.Location = New System.Drawing.Point(597, 281)
        Me.btnCoAOfAdvancePayment.Name = "btnCoAOfAdvancePayment"
        Me.btnCoAOfAdvancePayment.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfAdvancePayment.TabIndex = 32
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(33, 287)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 13)
        Me.Label14.TabIndex = 174
        Me.Label14.Text = "Pembayaran Dimuka"
        '
        'txtCoACodeOfEquipments
        '
        Me.txtCoACodeOfEquipments.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfEquipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfEquipments.Location = New System.Drawing.Point(189, 256)
        Me.txtCoACodeOfEquipments.MaxLength = 250
        Me.txtCoACodeOfEquipments.Name = "txtCoACodeOfEquipments"
        Me.txtCoACodeOfEquipments.ReadOnly = True
        Me.txtCoACodeOfEquipments.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfEquipments.TabIndex = 27
        '
        'txtCoACodeOfSalesTax
        '
        Me.txtCoACodeOfSalesTax.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfSalesTax.Location = New System.Drawing.Point(189, 310)
        Me.txtCoACodeOfSalesTax.MaxLength = 250
        Me.txtCoACodeOfSalesTax.Name = "txtCoACodeOfSalesTax"
        Me.txtCoACodeOfSalesTax.ReadOnly = True
        Me.txtCoACodeOfSalesTax.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfSalesTax.TabIndex = 33
        '
        'txtCoANameOfEquipments
        '
        Me.txtCoANameOfEquipments.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfEquipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfEquipments.Location = New System.Drawing.Point(271, 256)
        Me.txtCoANameOfEquipments.MaxLength = 250
        Me.txtCoANameOfEquipments.Name = "txtCoANameOfEquipments"
        Me.txtCoANameOfEquipments.ReadOnly = True
        Me.txtCoANameOfEquipments.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfEquipments.TabIndex = 28
        '
        'btnCoAOfEquipments
        '
        Me.btnCoAOfEquipments.Image = CType(resources.GetObject("btnCoAOfEquipments.Image"), System.Drawing.Image)
        Me.btnCoAOfEquipments.Location = New System.Drawing.Point(597, 254)
        Me.btnCoAOfEquipments.Name = "btnCoAOfEquipments"
        Me.btnCoAOfEquipments.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfEquipments.TabIndex = 29
        '
        'txtCoANameOfSalesTax
        '
        Me.txtCoANameOfSalesTax.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfSalesTax.Location = New System.Drawing.Point(271, 310)
        Me.txtCoANameOfSalesTax.MaxLength = 250
        Me.txtCoANameOfSalesTax.Name = "txtCoANameOfSalesTax"
        Me.txtCoANameOfSalesTax.ReadOnly = True
        Me.txtCoANameOfSalesTax.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfSalesTax.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(35, 260)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 170
        Me.Label13.Text = "Peralatan"
        '
        'btnCoAOfSalesTax
        '
        Me.btnCoAOfSalesTax.Image = CType(resources.GetObject("btnCoAOfSalesTax.Image"), System.Drawing.Image)
        Me.btnCoAOfSalesTax.Location = New System.Drawing.Point(597, 308)
        Me.btnCoAOfSalesTax.Name = "btnCoAOfSalesTax"
        Me.btnCoAOfSalesTax.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfSalesTax.TabIndex = 35
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(33, 314)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 13)
        Me.Label12.TabIndex = 170
        Me.Label12.Text = "Pajak Penjualan"
        '
        'txtCoACodeOfPurchaseDiscount
        '
        Me.txtCoACodeOfPurchaseDiscount.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfPurchaseDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfPurchaseDiscount.Location = New System.Drawing.Point(189, 229)
        Me.txtCoACodeOfPurchaseDiscount.MaxLength = 250
        Me.txtCoACodeOfPurchaseDiscount.Name = "txtCoACodeOfPurchaseDiscount"
        Me.txtCoACodeOfPurchaseDiscount.ReadOnly = True
        Me.txtCoACodeOfPurchaseDiscount.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfPurchaseDiscount.TabIndex = 24
        '
        'txtCoANameOfPurchaseDiscount
        '
        Me.txtCoANameOfPurchaseDiscount.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfPurchaseDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfPurchaseDiscount.Location = New System.Drawing.Point(271, 229)
        Me.txtCoANameOfPurchaseDiscount.MaxLength = 250
        Me.txtCoANameOfPurchaseDiscount.Name = "txtCoANameOfPurchaseDiscount"
        Me.txtCoANameOfPurchaseDiscount.ReadOnly = True
        Me.txtCoANameOfPurchaseDiscount.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfPurchaseDiscount.TabIndex = 25
        '
        'btnCoAOfPurchaseDiscount
        '
        Me.btnCoAOfPurchaseDiscount.Image = CType(resources.GetObject("btnCoAOfPurchaseDiscount.Image"), System.Drawing.Image)
        Me.btnCoAOfPurchaseDiscount.Location = New System.Drawing.Point(597, 227)
        Me.btnCoAOfPurchaseDiscount.Name = "btnCoAOfPurchaseDiscount"
        Me.btnCoAOfPurchaseDiscount.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfPurchaseDiscount.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(33, 233)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "Potongan Pembelian"
        '
        'txtCoACodeOfAccountPayable
        '
        Me.txtCoACodeOfAccountPayable.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfAccountPayable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfAccountPayable.Location = New System.Drawing.Point(189, 202)
        Me.txtCoACodeOfAccountPayable.MaxLength = 250
        Me.txtCoACodeOfAccountPayable.Name = "txtCoACodeOfAccountPayable"
        Me.txtCoACodeOfAccountPayable.ReadOnly = True
        Me.txtCoACodeOfAccountPayable.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfAccountPayable.TabIndex = 21
        '
        'txtCoANameOfAccountPayable
        '
        Me.txtCoANameOfAccountPayable.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfAccountPayable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfAccountPayable.Location = New System.Drawing.Point(271, 202)
        Me.txtCoANameOfAccountPayable.MaxLength = 250
        Me.txtCoANameOfAccountPayable.Name = "txtCoANameOfAccountPayable"
        Me.txtCoANameOfAccountPayable.ReadOnly = True
        Me.txtCoANameOfAccountPayable.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfAccountPayable.TabIndex = 22
        '
        'btnCoAOfAccountPayable
        '
        Me.btnCoAOfAccountPayable.Image = CType(resources.GetObject("btnCoAOfAccountPayable.Image"), System.Drawing.Image)
        Me.btnCoAOfAccountPayable.Location = New System.Drawing.Point(597, 200)
        Me.btnCoAOfAccountPayable.Name = "btnCoAOfAccountPayable"
        Me.btnCoAOfAccountPayable.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfAccountPayable.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(33, 206)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 162
        Me.Label10.Text = "Hutang Usaha"
        '
        'txtCoACodeOfCashOrBank
        '
        Me.txtCoACodeOfCashOrBank.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfCashOrBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfCashOrBank.Location = New System.Drawing.Point(189, 175)
        Me.txtCoACodeOfCashOrBank.MaxLength = 250
        Me.txtCoACodeOfCashOrBank.Name = "txtCoACodeOfCashOrBank"
        Me.txtCoACodeOfCashOrBank.ReadOnly = True
        Me.txtCoACodeOfCashOrBank.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfCashOrBank.TabIndex = 18
        '
        'txtCoANameOfCashOrBank
        '
        Me.txtCoANameOfCashOrBank.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfCashOrBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfCashOrBank.Location = New System.Drawing.Point(271, 175)
        Me.txtCoANameOfCashOrBank.MaxLength = 250
        Me.txtCoANameOfCashOrBank.Name = "txtCoANameOfCashOrBank"
        Me.txtCoANameOfCashOrBank.ReadOnly = True
        Me.txtCoANameOfCashOrBank.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfCashOrBank.TabIndex = 19
        '
        'btnCoAOfCashOrBank
        '
        Me.btnCoAOfCashOrBank.Image = CType(resources.GetObject("btnCoAOfCashOrBank.Image"), System.Drawing.Image)
        Me.btnCoAOfCashOrBank.Location = New System.Drawing.Point(597, 173)
        Me.btnCoAOfCashOrBank.Name = "btnCoAOfCashOrBank"
        Me.btnCoAOfCashOrBank.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfCashOrBank.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(33, 179)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "Kas / bank"
        '
        'txtCoACodeOfStock
        '
        Me.txtCoACodeOfStock.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfStock.Location = New System.Drawing.Point(189, 148)
        Me.txtCoACodeOfStock.MaxLength = 250
        Me.txtCoACodeOfStock.Name = "txtCoACodeOfStock"
        Me.txtCoACodeOfStock.ReadOnly = True
        Me.txtCoACodeOfStock.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfStock.TabIndex = 15
        '
        'txtCoANameOfStock
        '
        Me.txtCoANameOfStock.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfStock.Location = New System.Drawing.Point(271, 148)
        Me.txtCoANameOfStock.MaxLength = 250
        Me.txtCoANameOfStock.Name = "txtCoANameOfStock"
        Me.txtCoANameOfStock.ReadOnly = True
        Me.txtCoANameOfStock.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfStock.TabIndex = 16
        '
        'btnCoAOfStock
        '
        Me.btnCoAOfStock.Image = CType(resources.GetObject("btnCoAOfStock.Image"), System.Drawing.Image)
        Me.btnCoAOfStock.Location = New System.Drawing.Point(597, 146)
        Me.btnCoAOfStock.Name = "btnCoAOfStock"
        Me.btnCoAOfStock.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfStock.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(33, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "Persediaan"
        '
        'txtCoACodeOfCOGS
        '
        Me.txtCoACodeOfCOGS.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfCOGS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfCOGS.Location = New System.Drawing.Point(189, 121)
        Me.txtCoACodeOfCOGS.MaxLength = 250
        Me.txtCoACodeOfCOGS.Name = "txtCoACodeOfCOGS"
        Me.txtCoACodeOfCOGS.ReadOnly = True
        Me.txtCoACodeOfCOGS.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfCOGS.TabIndex = 12
        '
        'txtCoANameOfCOGS
        '
        Me.txtCoANameOfCOGS.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfCOGS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfCOGS.Location = New System.Drawing.Point(271, 121)
        Me.txtCoANameOfCOGS.MaxLength = 250
        Me.txtCoANameOfCOGS.Name = "txtCoANameOfCOGS"
        Me.txtCoANameOfCOGS.ReadOnly = True
        Me.txtCoANameOfCOGS.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfCOGS.TabIndex = 13
        '
        'btnCoAOfCOGS
        '
        Me.btnCoAOfCOGS.Image = CType(resources.GetObject("btnCoAOfCOGS.Image"), System.Drawing.Image)
        Me.btnCoAOfCOGS.Location = New System.Drawing.Point(597, 119)
        Me.btnCoAOfCOGS.Name = "btnCoAOfCOGS"
        Me.btnCoAOfCOGS.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfCOGS.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(33, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 13)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Harga Pokok Penjualan"
        '
        'txtCoACodeOfPrepaidIncome
        '
        Me.txtCoACodeOfPrepaidIncome.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfPrepaidIncome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfPrepaidIncome.Location = New System.Drawing.Point(189, 94)
        Me.txtCoACodeOfPrepaidIncome.MaxLength = 250
        Me.txtCoACodeOfPrepaidIncome.Name = "txtCoACodeOfPrepaidIncome"
        Me.txtCoACodeOfPrepaidIncome.ReadOnly = True
        Me.txtCoACodeOfPrepaidIncome.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfPrepaidIncome.TabIndex = 9
        '
        'txtCoANameOfPrepaidIncome
        '
        Me.txtCoANameOfPrepaidIncome.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfPrepaidIncome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfPrepaidIncome.Location = New System.Drawing.Point(271, 94)
        Me.txtCoANameOfPrepaidIncome.MaxLength = 250
        Me.txtCoANameOfPrepaidIncome.Name = "txtCoANameOfPrepaidIncome"
        Me.txtCoANameOfPrepaidIncome.ReadOnly = True
        Me.txtCoANameOfPrepaidIncome.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfPrepaidIncome.TabIndex = 10
        '
        'btnCoAOfPrepaidIncome
        '
        Me.btnCoAOfPrepaidIncome.Image = CType(resources.GetObject("btnCoAOfPrepaidIncome.Image"), System.Drawing.Image)
        Me.btnCoAOfPrepaidIncome.Location = New System.Drawing.Point(597, 92)
        Me.btnCoAOfPrepaidIncome.Name = "btnCoAOfPrepaidIncome"
        Me.btnCoAOfPrepaidIncome.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfPrepaidIncome.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(33, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 13)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "Pendapatan Diterima Dimuka"
        '
        'txtCoACodeOfSalesDiscount
        '
        Me.txtCoACodeOfSalesDiscount.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfSalesDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfSalesDiscount.Location = New System.Drawing.Point(189, 67)
        Me.txtCoACodeOfSalesDiscount.MaxLength = 250
        Me.txtCoACodeOfSalesDiscount.Name = "txtCoACodeOfSalesDiscount"
        Me.txtCoACodeOfSalesDiscount.ReadOnly = True
        Me.txtCoACodeOfSalesDiscount.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfSalesDiscount.TabIndex = 6
        '
        'txtCoANameOfSalesDiscount
        '
        Me.txtCoANameOfSalesDiscount.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfSalesDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfSalesDiscount.Location = New System.Drawing.Point(271, 67)
        Me.txtCoANameOfSalesDiscount.MaxLength = 250
        Me.txtCoANameOfSalesDiscount.Name = "txtCoANameOfSalesDiscount"
        Me.txtCoANameOfSalesDiscount.ReadOnly = True
        Me.txtCoANameOfSalesDiscount.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfSalesDiscount.TabIndex = 7
        '
        'btnCoAOfSalesDiscount
        '
        Me.btnCoAOfSalesDiscount.Image = CType(resources.GetObject("btnCoAOfSalesDiscount.Image"), System.Drawing.Image)
        Me.btnCoAOfSalesDiscount.Location = New System.Drawing.Point(597, 65)
        Me.btnCoAOfSalesDiscount.Name = "btnCoAOfSalesDiscount"
        Me.btnCoAOfSalesDiscount.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfSalesDiscount.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(33, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 142
        Me.Label5.Text = "Potongan Penjualan"
        '
        'txtCoACodeOfAccountReceivable
        '
        Me.txtCoACodeOfAccountReceivable.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfAccountReceivable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfAccountReceivable.Location = New System.Drawing.Point(189, 40)
        Me.txtCoACodeOfAccountReceivable.MaxLength = 250
        Me.txtCoACodeOfAccountReceivable.Name = "txtCoACodeOfAccountReceivable"
        Me.txtCoACodeOfAccountReceivable.ReadOnly = True
        Me.txtCoACodeOfAccountReceivable.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfAccountReceivable.TabIndex = 3
        '
        'txtCoANameOfAccountReceivable
        '
        Me.txtCoANameOfAccountReceivable.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfAccountReceivable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfAccountReceivable.Location = New System.Drawing.Point(271, 40)
        Me.txtCoANameOfAccountReceivable.MaxLength = 250
        Me.txtCoANameOfAccountReceivable.Name = "txtCoANameOfAccountReceivable"
        Me.txtCoANameOfAccountReceivable.ReadOnly = True
        Me.txtCoANameOfAccountReceivable.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfAccountReceivable.TabIndex = 4
        '
        'btnCoAOfAccountReceivable
        '
        Me.btnCoAOfAccountReceivable.Image = CType(resources.GetObject("btnCoAOfAccountReceivable.Image"), System.Drawing.Image)
        Me.btnCoAOfAccountReceivable.Location = New System.Drawing.Point(597, 38)
        Me.btnCoAOfAccountReceivable.Name = "btnCoAOfAccountReceivable"
        Me.btnCoAOfAccountReceivable.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfAccountReceivable.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(33, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Piutang Usaha"
        '
        'txtCoACodeOfRevenue
        '
        Me.txtCoACodeOfRevenue.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeOfRevenue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeOfRevenue.Location = New System.Drawing.Point(189, 13)
        Me.txtCoACodeOfRevenue.MaxLength = 250
        Me.txtCoACodeOfRevenue.Name = "txtCoACodeOfRevenue"
        Me.txtCoACodeOfRevenue.ReadOnly = True
        Me.txtCoACodeOfRevenue.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeOfRevenue.TabIndex = 0
        '
        'txtCoANameOfRevenue
        '
        Me.txtCoANameOfRevenue.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameOfRevenue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameOfRevenue.Location = New System.Drawing.Point(271, 13)
        Me.txtCoANameOfRevenue.MaxLength = 250
        Me.txtCoANameOfRevenue.Name = "txtCoANameOfRevenue"
        Me.txtCoANameOfRevenue.ReadOnly = True
        Me.txtCoANameOfRevenue.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameOfRevenue.TabIndex = 1
        '
        'btnCoAOfRevenue
        '
        Me.btnCoAOfRevenue.Image = CType(resources.GetObject("btnCoAOfRevenue.Image"), System.Drawing.Image)
        Me.btnCoAOfRevenue.Location = New System.Drawing.Point(597, 11)
        Me.btnCoAOfRevenue.Name = "btnCoAOfRevenue"
        Me.btnCoAOfRevenue.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfRevenue.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(33, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Pendapatan"
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 489)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(644, 23)
        Me.pgMain.TabIndex = 4
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 467)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(644, 22)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(521, 17)
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
        'txtCoACodeofVentureCapital
        '
        Me.txtCoACodeofVentureCapital.BackColor = System.Drawing.Color.Azure
        Me.txtCoACodeofVentureCapital.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACodeofVentureCapital.Location = New System.Drawing.Point(189, 364)
        Me.txtCoACodeofVentureCapital.MaxLength = 250
        Me.txtCoACodeofVentureCapital.Name = "txtCoACodeofVentureCapital"
        Me.txtCoACodeofVentureCapital.ReadOnly = True
        Me.txtCoACodeofVentureCapital.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACodeofVentureCapital.TabIndex = 179
        '
        'txtCoANameofVentureCapital
        '
        Me.txtCoANameofVentureCapital.BackColor = System.Drawing.Color.Azure
        Me.txtCoANameofVentureCapital.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoANameofVentureCapital.Location = New System.Drawing.Point(271, 364)
        Me.txtCoANameofVentureCapital.MaxLength = 250
        Me.txtCoANameofVentureCapital.Name = "txtCoANameofVentureCapital"
        Me.txtCoANameofVentureCapital.ReadOnly = True
        Me.txtCoANameofVentureCapital.Size = New System.Drawing.Size(320, 21)
        Me.txtCoANameofVentureCapital.TabIndex = 180
        '
        'btnCoAofVentureCapital
        '
        Me.btnCoAofVentureCapital.Image = CType(resources.GetObject("btnCoAofVentureCapital.Image"), System.Drawing.Image)
        Me.btnCoAofVentureCapital.Location = New System.Drawing.Point(597, 362)
        Me.btnCoAofVentureCapital.Name = "btnCoAofVentureCapital"
        Me.btnCoAofVentureCapital.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAofVentureCapital.TabIndex = 181
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(33, 368)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "Modal Usaha"
        '
        'frmSysJournalPost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 512)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmSysJournalPost"
        Me.Text = "Setup Posting Jurnal Transaksi"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtCoACodeOfPurchaseTax As ERPS.usTextBox
    Friend WithEvents txtCoANameOfPurchaseTax As ERPS.usTextBox
    Friend WithEvents btnCoAOfPurchaseTax As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfAdvancePayment As ERPS.usTextBox
    Friend WithEvents txtCoANameOfAdvancePayment As ERPS.usTextBox
    Friend WithEvents btnCoAOfAdvancePayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfEquipments As ERPS.usTextBox
    Friend WithEvents txtCoACodeOfSalesTax As ERPS.usTextBox
    Friend WithEvents txtCoANameOfEquipments As ERPS.usTextBox
    Friend WithEvents btnCoAOfEquipments As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCoANameOfSalesTax As ERPS.usTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCoAOfSalesTax As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfPurchaseDiscount As ERPS.usTextBox
    Friend WithEvents txtCoANameOfPurchaseDiscount As ERPS.usTextBox
    Friend WithEvents btnCoAOfPurchaseDiscount As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfAccountPayable As ERPS.usTextBox
    Friend WithEvents txtCoANameOfAccountPayable As ERPS.usTextBox
    Friend WithEvents btnCoAOfAccountPayable As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfCashOrBank As ERPS.usTextBox
    Friend WithEvents txtCoANameOfCashOrBank As ERPS.usTextBox
    Friend WithEvents btnCoAOfCashOrBank As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfStock As ERPS.usTextBox
    Friend WithEvents txtCoANameOfStock As ERPS.usTextBox
    Friend WithEvents btnCoAOfStock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfCOGS As ERPS.usTextBox
    Friend WithEvents txtCoANameOfCOGS As ERPS.usTextBox
    Friend WithEvents btnCoAOfCOGS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfPrepaidIncome As ERPS.usTextBox
    Friend WithEvents txtCoANameOfPrepaidIncome As ERPS.usTextBox
    Friend WithEvents btnCoAOfPrepaidIncome As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfSalesDiscount As ERPS.usTextBox
    Friend WithEvents txtCoANameOfSalesDiscount As ERPS.usTextBox
    Friend WithEvents btnCoAOfSalesDiscount As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfAccountReceivable As ERPS.usTextBox
    Friend WithEvents txtCoANameOfAccountReceivable As ERPS.usTextBox
    Friend WithEvents btnCoAOfAccountReceivable As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeOfRevenue As ERPS.usTextBox
    Friend WithEvents txtCoANameOfRevenue As ERPS.usTextBox
    Friend WithEvents btnCoAOfRevenue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCoACodeofVentureCapital As ERPS.usTextBox
    Friend WithEvents txtCoANameofVentureCapital As ERPS.usTextBox
    Friend WithEvents btnCoAofVentureCapital As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
