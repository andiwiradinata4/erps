<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraARAPDetVer5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraARAPDetVer5))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtOutstandingPayment = New ERPS.usNumeric()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalPayment = New ERPS.usNumeric()
        Me.chkUsePercentage = New System.Windows.Forms.CheckBox()
        Me.txtPercentage = New ERPS.usNumeric()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtRounding = New ERPS.usNumeric()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtBPBankAccountBank = New ERPS.usTextBox()
        Me.txtBPBankAccountNumber = New ERPS.usTextBox()
        Me.btnBPBankAccount = New DevExpress.XtraEditors.SimpleButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtInvoiceNumberBP = New ERPS.usTextBox()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpReceiveDate = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New ERPS.usNumeric()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtReferencesNumber = New ERPS.usTextBox()
        Me.btnReferences = New DevExpress.XtraEditors.SimpleButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBPCode = New ERPS.usTextBox()
        Me.txtBPName = New ERPS.usTextBox()
        Me.btnBP = New DevExpress.XtraEditors.SimpleButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtGrandTotalContract = New ERPS.usNumeric()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalPPH = New ERPS.usNumeric()
        Me.txtARAPNumber = New ERPS.usTextBox()
        Me.txtTotalAmount = New ERPS.usNumeric()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalPPN = New ERPS.usNumeric()
        Me.dtpARAPDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboStatus = New ERPS.usComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDueDateValue = New ERPS.usNumeric()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tpHistoryReceive = New System.Windows.Forms.TabPage()
        Me.grdHistoryReceive = New DevExpress.XtraGrid.GridControl()
        Me.grdHistoryReceiveView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolBarDetail = New ERPS.usToolBar()
        Me.BarCheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarUncheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1Item = New System.Windows.Forms.ToolBarButton()
        Me.BarCalculate = New System.Windows.Forms.ToolBarButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.txtOutstandingPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRounding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalContract, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistoryReceive.SuspendLayout()
        CType(Me.grdHistoryReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHistoryReceiveView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(998, 28)
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
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 683)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(998, 23)
        Me.pgMain.TabIndex = 7
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(998, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Down Payment Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Controls.Add(Me.tpHistoryReceive)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(998, 329)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.Label23)
        Me.tpMain.Controls.Add(Me.txtOutstandingPayment)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Controls.Add(Me.txtTotalPayment)
        Me.tpMain.Controls.Add(Me.chkUsePercentage)
        Me.tpMain.Controls.Add(Me.txtPercentage)
        Me.tpMain.Controls.Add(Me.Label22)
        Me.tpMain.Controls.Add(Me.txtRounding)
        Me.tpMain.Controls.Add(Me.Label21)
        Me.tpMain.Controls.Add(Me.txtBPBankAccountBank)
        Me.tpMain.Controls.Add(Me.txtBPBankAccountNumber)
        Me.tpMain.Controls.Add(Me.btnBPBankAccount)
        Me.tpMain.Controls.Add(Me.Label20)
        Me.tpMain.Controls.Add(Me.Label17)
        Me.tpMain.Controls.Add(Me.txtInvoiceNumberBP)
        Me.tpMain.Controls.Add(Me.dtpInvoiceDate)
        Me.tpMain.Controls.Add(Me.Label18)
        Me.tpMain.Controls.Add(Me.dtpReceiveDate)
        Me.tpMain.Controls.Add(Me.Label19)
        Me.tpMain.Controls.Add(Me.txtGrandTotal)
        Me.tpMain.Controls.Add(Me.Label16)
        Me.tpMain.Controls.Add(Me.txtReferencesNumber)
        Me.tpMain.Controls.Add(Me.btnReferences)
        Me.tpMain.Controls.Add(Me.Label15)
        Me.tpMain.Controls.Add(Me.txtBPCode)
        Me.tpMain.Controls.Add(Me.txtBPName)
        Me.tpMain.Controls.Add(Me.btnBP)
        Me.tpMain.Controls.Add(Me.Label12)
        Me.tpMain.Controls.Add(Me.txtGrandTotalContract)
        Me.tpMain.Controls.Add(Me.Label1)
        Me.tpMain.Controls.Add(Me.Label8)
        Me.tpMain.Controls.Add(Me.txtTotalPPH)
        Me.tpMain.Controls.Add(Me.txtARAPNumber)
        Me.tpMain.Controls.Add(Me.txtTotalAmount)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.Label7)
        Me.tpMain.Controls.Add(Me.Label6)
        Me.tpMain.Controls.Add(Me.txtTotalPPN)
        Me.tpMain.Controls.Add(Me.dtpARAPDate)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.Label11)
        Me.tpMain.Controls.Add(Me.Label5)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.Label10)
        Me.tpMain.Controls.Add(Me.Label9)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.txtDueDateValue)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(990, 300)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(497, 47)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(123, 13)
        Me.Label23.TabIndex = 209
        Me.Label23.Text = "Sisa yang belum dibayar"
        '
        'txtOutstandingPayment
        '
        Me.txtOutstandingPayment.BackColor = System.Drawing.Color.LightYellow
        Me.txtOutstandingPayment.DecimalPlaces = 2
        Me.txtOutstandingPayment.Enabled = False
        Me.txtOutstandingPayment.Location = New System.Drawing.Point(631, 43)
        Me.txtOutstandingPayment.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtOutstandingPayment.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtOutstandingPayment.Name = "txtOutstandingPayment"
        Me.txtOutstandingPayment.Size = New System.Drawing.Size(249, 21)
        Me.txtOutstandingPayment.TabIndex = 19
        Me.txtOutstandingPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOutstandingPayment.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(497, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 207
        Me.Label2.Text = "Total yang telah dibayar"
        '
        'txtTotalPayment
        '
        Me.txtTotalPayment.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPayment.DecimalPlaces = 2
        Me.txtTotalPayment.Enabled = False
        Me.txtTotalPayment.Location = New System.Drawing.Point(631, 16)
        Me.txtTotalPayment.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPayment.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPayment.Name = "txtTotalPayment"
        Me.txtTotalPayment.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPayment.TabIndex = 18
        Me.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPayment.ThousandsSeparator = True
        '
        'chkUsePercentage
        '
        Me.chkUsePercentage.AutoSize = True
        Me.chkUsePercentage.Location = New System.Drawing.Point(239, 153)
        Me.chkUsePercentage.Name = "chkUsePercentage"
        Me.chkUsePercentage.Size = New System.Drawing.Size(70, 17)
        Me.chkUsePercentage.TabIndex = 12
        Me.chkUsePercentage.Text = "Aktifkan?"
        Me.chkUsePercentage.UseVisualStyleBackColor = True
        '
        'txtPercentage
        '
        Me.txtPercentage.BackColor = System.Drawing.Color.LightYellow
        Me.txtPercentage.DecimalPlaces = 2
        Me.txtPercentage.Enabled = False
        Me.txtPercentage.Location = New System.Drawing.Point(150, 151)
        Me.txtPercentage.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPercentage.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(83, 21)
        Me.txtPercentage.TabIndex = 11
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercentage.ThousandsSeparator = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(16, 155)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 205
        Me.Label22.Text = "Persentase"
        '
        'txtRounding
        '
        Me.txtRounding.BackColor = System.Drawing.Color.White
        Me.txtRounding.DecimalPlaces = 2
        Me.txtRounding.Location = New System.Drawing.Point(631, 151)
        Me.txtRounding.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtRounding.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtRounding.Name = "txtRounding"
        Me.txtRounding.Size = New System.Drawing.Size(249, 21)
        Me.txtRounding.TabIndex = 23
        Me.txtRounding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRounding.ThousandsSeparator = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(497, 155)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 202
        Me.Label21.Text = "Pembulatan"
        '
        'txtBPBankAccountBank
        '
        Me.txtBPBankAccountBank.BackColor = System.Drawing.Color.Azure
        Me.txtBPBankAccountBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPBankAccountBank.Location = New System.Drawing.Point(150, 97)
        Me.txtBPBankAccountBank.MaxLength = 250
        Me.txtBPBankAccountBank.Name = "txtBPBankAccountBank"
        Me.txtBPBankAccountBank.ReadOnly = True
        Me.txtBPBankAccountBank.Size = New System.Drawing.Size(83, 21)
        Me.txtBPBankAccountBank.TabIndex = 6
        '
        'txtBPBankAccountNumber
        '
        Me.txtBPBankAccountNumber.BackColor = System.Drawing.Color.Azure
        Me.txtBPBankAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPBankAccountNumber.Location = New System.Drawing.Point(232, 97)
        Me.txtBPBankAccountNumber.MaxLength = 250
        Me.txtBPBankAccountNumber.Name = "txtBPBankAccountNumber"
        Me.txtBPBankAccountNumber.ReadOnly = True
        Me.txtBPBankAccountNumber.Size = New System.Drawing.Size(196, 21)
        Me.txtBPBankAccountNumber.TabIndex = 7
        '
        'btnBPBankAccount
        '
        Me.btnBPBankAccount.Image = CType(resources.GetObject("btnBPBankAccount.Image"), System.Drawing.Image)
        Me.btnBPBankAccount.Location = New System.Drawing.Point(435, 96)
        Me.btnBPBankAccount.Name = "btnBPBankAccount"
        Me.btnBPBankAccount.Size = New System.Drawing.Size(23, 23)
        Me.btnBPBankAccount.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(16, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 13)
        Me.Label20.TabIndex = 200
        Me.Label20.Text = "Akun Bank"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(16, 182)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 196
        Me.Label17.Text = "Nomor Invoice"
        '
        'txtInvoiceNumberBP
        '
        Me.txtInvoiceNumberBP.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNumberBP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumberBP.Location = New System.Drawing.Point(150, 178)
        Me.txtInvoiceNumberBP.MaxLength = 250
        Me.txtInvoiceNumberBP.Name = "txtInvoiceNumberBP"
        Me.txtInvoiceNumberBP.Size = New System.Drawing.Size(278, 21)
        Me.txtInvoiceNumberBP.TabIndex = 13
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(345, 205)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpInvoiceDate.TabIndex = 15
        Me.dtpInvoiceDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(256, 209)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 13)
        Me.Label18.TabIndex = 195
        Me.Label18.Text = "Tanggal Invoice"
        '
        'dtpReceiveDate
        '
        Me.dtpReceiveDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReceiveDate.Location = New System.Drawing.Point(150, 205)
        Me.dtpReceiveDate.Name = "dtpReceiveDate"
        Me.dtpReceiveDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpReceiveDate.TabIndex = 14
        Me.dtpReceiveDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(16, 209)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 194
        Me.Label19.Text = "Tanggal Terima"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotal.DecimalPlaces = 2
        Me.txtGrandTotal.Enabled = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(631, 178)
        Me.txtGrandTotal.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotal.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(249, 21)
        Me.txtGrandTotal.TabIndex = 24
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotal.ThousandsSeparator = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(497, 182)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Grand Total"
        '
        'txtReferencesNumber
        '
        Me.txtReferencesNumber.BackColor = System.Drawing.Color.Azure
        Me.txtReferencesNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencesNumber.Location = New System.Drawing.Point(150, 70)
        Me.txtReferencesNumber.MaxLength = 250
        Me.txtReferencesNumber.Name = "txtReferencesNumber"
        Me.txtReferencesNumber.ReadOnly = True
        Me.txtReferencesNumber.Size = New System.Drawing.Size(278, 21)
        Me.txtReferencesNumber.TabIndex = 4
        '
        'btnReferences
        '
        Me.btnReferences.Image = CType(resources.GetObject("btnReferences.Image"), System.Drawing.Image)
        Me.btnReferences.Location = New System.Drawing.Point(435, 69)
        Me.btnReferences.Name = "btnReferences"
        Me.btnReferences.Size = New System.Drawing.Size(23, 23)
        Me.btnReferences.TabIndex = 5
        Me.btnReferences.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(16, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 173
        Me.Label15.Text = "Nomor Referensi"
        '
        'txtBPCode
        '
        Me.txtBPCode.BackColor = System.Drawing.Color.Azure
        Me.txtBPCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPCode.Location = New System.Drawing.Point(150, 43)
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
        Me.txtBPName.Location = New System.Drawing.Point(232, 43)
        Me.txtBPName.MaxLength = 250
        Me.txtBPName.Name = "txtBPName"
        Me.txtBPName.ReadOnly = True
        Me.txtBPName.Size = New System.Drawing.Size(196, 21)
        Me.txtBPName.TabIndex = 2
        '
        'btnBP
        '
        Me.btnBP.Image = CType(resources.GetObject("btnBP.Image"), System.Drawing.Image)
        Me.btnBP.Location = New System.Drawing.Point(435, 42)
        Me.btnBP.Name = "btnBP"
        Me.btnBP.Size = New System.Drawing.Size(23, 23)
        Me.btnBP.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(16, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 170
        Me.Label12.Text = "Rekan Bisnis"
        '
        'txtGrandTotalContract
        '
        Me.txtGrandTotalContract.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotalContract.DecimalPlaces = 2
        Me.txtGrandTotalContract.Enabled = False
        Me.txtGrandTotalContract.Location = New System.Drawing.Point(150, 259)
        Me.txtGrandTotalContract.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotalContract.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotalContract.Name = "txtGrandTotalContract"
        Me.txtGrandTotalContract.Size = New System.Drawing.Size(278, 21)
        Me.txtGrandTotalContract.TabIndex = 17
        Me.txtGrandTotalContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotalContract.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Grand Total Kontrak"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Nomor"
        '
        'txtTotalPPH
        '
        Me.txtTotalPPH.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPH.DecimalPlaces = 2
        Me.txtTotalPPH.Enabled = False
        Me.txtTotalPPH.Location = New System.Drawing.Point(631, 124)
        Me.txtTotalPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPH.Name = "txtTotalPPH"
        Me.txtTotalPPH.ReadOnly = True
        Me.txtTotalPPH.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPH.TabIndex = 22
        Me.txtTotalPPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPH.ThousandsSeparator = True
        '
        'txtARAPNumber
        '
        Me.txtARAPNumber.BackColor = System.Drawing.Color.White
        Me.txtARAPNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtARAPNumber.Location = New System.Drawing.Point(150, 16)
        Me.txtARAPNumber.MaxLength = 250
        Me.txtARAPNumber.Name = "txtARAPNumber"
        Me.txtARAPNumber.Size = New System.Drawing.Size(206, 21)
        Me.txtARAPNumber.TabIndex = 0
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalAmount.DecimalPlaces = 2
        Me.txtTotalAmount.Enabled = False
        Me.txtTotalAmount.Location = New System.Drawing.Point(631, 70)
        Me.txtTotalAmount.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalAmount.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalAmount.TabIndex = 20
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAmount.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(497, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Total PPH"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(497, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Total Harga"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Tanggal"
        '
        'txtTotalPPN
        '
        Me.txtTotalPPN.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPN.DecimalPlaces = 2
        Me.txtTotalPPN.Enabled = False
        Me.txtTotalPPN.Location = New System.Drawing.Point(631, 97)
        Me.txtTotalPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPN.Name = "txtTotalPPN"
        Me.txtTotalPPN.ReadOnly = True
        Me.txtTotalPPN.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPN.TabIndex = 21
        Me.txtTotalPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPN.ThousandsSeparator = True
        '
        'dtpARAPDate
        '
        Me.dtpARAPDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpARAPDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpARAPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpARAPDate.Location = New System.Drawing.Point(150, 124)
        Me.dtpARAPDate.Name = "dtpARAPDate"
        Me.dtpARAPDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpARAPDate.TabIndex = 9
        Me.dtpARAPDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 263)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Total Panjar"
        Me.Label4.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(497, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 163
        Me.Label11.Text = "Total PPN"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(150, 232)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(278, 21)
        Me.cboStatus.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(435, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 159
        Me.Label10.Text = "Hari"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(270, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "Jatuh Tempo"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(631, 205)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(497, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'txtDueDateValue
        '
        Me.txtDueDateValue.BackColor = System.Drawing.Color.White
        Me.txtDueDateValue.Location = New System.Drawing.Point(345, 124)
        Me.txtDueDateValue.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtDueDateValue.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtDueDateValue.Name = "txtDueDateValue"
        Me.txtDueDateValue.Size = New System.Drawing.Size(83, 21)
        Me.txtDueDateValue.TabIndex = 10
        Me.txtDueDateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDueDateValue.ThousandsSeparator = True
        '
        'tpHistory
        '
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Size = New System.Drawing.Size(990, 300)
        Me.tpHistory.TabIndex = 1
        Me.tpHistory.Text = "History - F2"
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
        Me.grdStatus.Location = New System.Drawing.Point(0, 0)
        Me.grdStatus.MainView = Me.grdStatusView
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.Size = New System.Drawing.Size(990, 300)
        Me.grdStatus.TabIndex = 14
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
        'tpHistoryReceive
        '
        Me.tpHistoryReceive.Controls.Add(Me.grdHistoryReceive)
        Me.tpHistoryReceive.Location = New System.Drawing.Point(4, 25)
        Me.tpHistoryReceive.Name = "tpHistoryReceive"
        Me.tpHistoryReceive.Size = New System.Drawing.Size(990, 300)
        Me.tpHistoryReceive.TabIndex = 2
        Me.tpHistoryReceive.Text = "History Pelunasan - F3"
        Me.tpHistoryReceive.UseVisualStyleBackColor = True
        '
        'grdHistoryReceive
        '
        Me.grdHistoryReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdHistoryReceive.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdHistoryReceive.Location = New System.Drawing.Point(0, 0)
        Me.grdHistoryReceive.MainView = Me.grdHistoryReceiveView
        Me.grdHistoryReceive.Name = "grdHistoryReceive"
        Me.grdHistoryReceive.Size = New System.Drawing.Size(990, 300)
        Me.grdHistoryReceive.TabIndex = 15
        Me.grdHistoryReceive.UseEmbeddedNavigator = True
        Me.grdHistoryReceive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdHistoryReceiveView})
        '
        'grdHistoryReceiveView
        '
        Me.grdHistoryReceiveView.GridControl = Me.grdHistoryReceive
        Me.grdHistoryReceiveView.Name = "grdHistoryReceiveView"
        Me.grdHistoryReceiveView.OptionsCustomization.AllowColumnMoving = False
        Me.grdHistoryReceiveView.OptionsCustomization.AllowGroup = False
        Me.grdHistoryReceiveView.OptionsView.ColumnAutoWidth = False
        Me.grdHistoryReceiveView.OptionsView.ShowGroupPanel = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.CadetBlue
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 379)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(998, 22)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "« Item"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarCheckAll, Me.BarUncheckAll, Me.BarSep1Item, Me.BarCalculate})
        Me.ToolBarDetail.DropDownArrows = True
        Me.ToolBarDetail.Location = New System.Drawing.Point(0, 401)
        Me.ToolBarDetail.Name = "ToolBarDetail"
        Me.ToolBarDetail.ShowToolTips = True
        Me.ToolBarDetail.Size = New System.Drawing.Size(998, 28)
        Me.ToolBarDetail.TabIndex = 4
        Me.ToolBarDetail.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarCheckAll
        '
        Me.BarCheckAll.Name = "BarCheckAll"
        Me.BarCheckAll.Tag = "Checked"
        Me.BarCheckAll.Text = "Centang Semua"
        '
        'BarUncheckAll
        '
        Me.BarUncheckAll.Name = "BarUncheckAll"
        Me.BarUncheckAll.Tag = "Unapproved"
        Me.BarUncheckAll.Text = "Tidak Centang Semua"
        '
        'BarSep1Item
        '
        Me.BarSep1Item.Name = "BarSep1Item"
        Me.BarSep1Item.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarCalculate
        '
        Me.BarCalculate.Name = "BarCalculate"
        Me.BarCalculate.Tag = "Calculation"
        Me.BarCalculate.Text = "Kalkulasi"
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 661)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(998, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(875, 17)
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
        Me.grdItem.Location = New System.Drawing.Point(0, 429)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItem.Size = New System.Drawing.Size(998, 232)
        Me.grdItem.TabIndex = 5
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
        Me.grdItemView.OptionsView.ShowGroupPanel = False
        '
        'rpiValue
        '
        Me.rpiValue.AutoHeight = False
        Me.rpiValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiValue.Name = "rpiValue"
        Me.rpiValue.NullText = "0.00"
        '
        'frmTraARAPDetVer5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 706)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ToolBarDetail)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmTraARAPDetVer5"
        Me.Text = "Down Payment"
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.txtOutstandingPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRounding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalContract, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistoryReceive.ResumeLayout(False)
        CType(Me.grdHistoryReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHistoryReceiveView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tcHeader As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents txtRounding As ERPS.usNumeric
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtBPBankAccountBank As ERPS.usTextBox
    Friend WithEvents txtBPBankAccountNumber As ERPS.usTextBox
    Friend WithEvents btnBPBankAccount As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumberBP As ERPS.usTextBox
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotal As ERPS.usNumeric
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtReferencesNumber As ERPS.usTextBox
    Friend WithEvents btnReferences As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBPCode As ERPS.usTextBox
    Friend WithEvents txtBPName As ERPS.usTextBox
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotalContract As ERPS.usNumeric
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPH As ERPS.usNumeric
    Friend WithEvents txtARAPNumber As ERPS.usTextBox
    Friend WithEvents txtTotalAmount As ERPS.usNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPN As ERPS.usNumeric
    Friend WithEvents dtpARAPDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As ERPS.usTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDueDateValue As ERPS.usNumeric
    Friend WithEvents tpHistory As System.Windows.Forms.TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ToolBarDetail As ERPS.usToolBar
    Friend WithEvents BarCheckAll As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarUncheckAll As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep1Item As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarCalculate As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents tpHistoryReceive As System.Windows.Forms.TabPage
    Friend WithEvents grdHistoryReceive As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdHistoryReceiveView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkUsePercentage As System.Windows.Forms.CheckBox
    Friend WithEvents txtPercentage As ERPS.usNumeric
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPayment As ERPS.usNumeric
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtOutstandingPayment As ERPS.usNumeric
End Class
