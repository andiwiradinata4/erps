﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTraARAPDetVer4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraARAPDetVer4))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
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
        Me.chkMaxQuantity = New System.Windows.Forms.CheckBox()
        Me.chkIsFullDP = New System.Windows.Forms.CheckBox()
        Me.txtGrandTotal = New ERPS.usNumeric()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtReferencesNumber = New ERPS.usTextBox()
        Me.btnReferences = New DevExpress.XtraEditors.SimpleButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBPCode = New ERPS.usTextBox()
        Me.txtBPName = New ERPS.usTextBox()
        Me.btnBP = New DevExpress.XtraEditors.SimpleButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDPAllocate = New ERPS.usNumeric()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalPPH = New ERPS.usNumeric()
        Me.txtARAPNumber = New ERPS.usTextBox()
        Me.txtTotalAmount = New ERPS.usNumeric()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCoACode = New ERPS.usTextBox()
        Me.txtTotalPPN = New ERPS.usNumeric()
        Me.btnCoAOfOutgoingPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.dtpARAPDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalDP = New ERPS.usNumeric()
        Me.cboStatus = New ERPS.usComboBox()
        Me.txtCoAName = New ERPS.usTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDueDateValue = New ERPS.usNumeric()
        Me.tpDownPayment = New System.Windows.Forms.TabPage()
        Me.grdDownPayment = New DevExpress.XtraGrid.GridControl()
        Me.grdDownPaymentView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiDPAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolBarDetail = New ERPS.usToolBar()
        Me.BarCheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarUncheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1Item = New System.Windows.Forms.ToolBarButton()
        Me.BarAllocateDP = New System.Windows.Forms.ToolBarButton()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip.SuspendLayout()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.txtRounding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDPAllocate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDownPayment.SuspendLayout()
        CType(Me.grdDownPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDownPaymentView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpiDPAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(904, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(904, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« "
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 587)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(904, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(781, 17)
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
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpDownPayment)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(904, 272)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        Me.tpMain.Controls.Add(Me.chkMaxQuantity)
        Me.tpMain.Controls.Add(Me.chkIsFullDP)
        Me.tpMain.Controls.Add(Me.txtGrandTotal)
        Me.tpMain.Controls.Add(Me.Label16)
        Me.tpMain.Controls.Add(Me.txtReferencesNumber)
        Me.tpMain.Controls.Add(Me.btnReferences)
        Me.tpMain.Controls.Add(Me.Label15)
        Me.tpMain.Controls.Add(Me.txtBPCode)
        Me.tpMain.Controls.Add(Me.txtBPName)
        Me.tpMain.Controls.Add(Me.btnBP)
        Me.tpMain.Controls.Add(Me.Label12)
        Me.tpMain.Controls.Add(Me.txtDPAllocate)
        Me.tpMain.Controls.Add(Me.Label1)
        Me.tpMain.Controls.Add(Me.Label8)
        Me.tpMain.Controls.Add(Me.txtTotalPPH)
        Me.tpMain.Controls.Add(Me.txtARAPNumber)
        Me.tpMain.Controls.Add(Me.txtTotalAmount)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.Label7)
        Me.tpMain.Controls.Add(Me.Label6)
        Me.tpMain.Controls.Add(Me.txtCoACode)
        Me.tpMain.Controls.Add(Me.txtTotalPPN)
        Me.tpMain.Controls.Add(Me.btnCoAOfOutgoingPayment)
        Me.tpMain.Controls.Add(Me.dtpARAPDate)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.Label11)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Controls.Add(Me.Label5)
        Me.tpMain.Controls.Add(Me.txtTotalDP)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.txtCoAName)
        Me.tpMain.Controls.Add(Me.Label10)
        Me.tpMain.Controls.Add(Me.Label9)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.txtDueDateValue)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(896, 243)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtRounding
        '
        Me.txtRounding.BackColor = System.Drawing.Color.White
        Me.txtRounding.DecimalPlaces = 2
        Me.txtRounding.Location = New System.Drawing.Point(617, 124)
        Me.txtRounding.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtRounding.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtRounding.Name = "txtRounding"
        Me.txtRounding.Size = New System.Drawing.Size(249, 21)
        Me.txtRounding.TabIndex = 21
        Me.txtRounding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRounding.ThousandsSeparator = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(502, 128)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 202
        Me.Label21.Text = "Pembulatan"
        '
        'txtBPBankAccountBank
        '
        Me.txtBPBankAccountBank.BackColor = System.Drawing.Color.Azure
        Me.txtBPBankAccountBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPBankAccountBank.Location = New System.Drawing.Point(134, 97)
        Me.txtBPBankAccountBank.MaxLength = 250
        Me.txtBPBankAccountBank.Name = "txtBPBankAccountBank"
        Me.txtBPBankAccountBank.ReadOnly = True
        Me.txtBPBankAccountBank.Size = New System.Drawing.Size(83, 21)
        Me.txtBPBankAccountBank.TabIndex = 7
        '
        'txtBPBankAccountNumber
        '
        Me.txtBPBankAccountNumber.BackColor = System.Drawing.Color.Azure
        Me.txtBPBankAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPBankAccountNumber.Location = New System.Drawing.Point(216, 97)
        Me.txtBPBankAccountNumber.MaxLength = 250
        Me.txtBPBankAccountNumber.Name = "txtBPBankAccountNumber"
        Me.txtBPBankAccountNumber.ReadOnly = True
        Me.txtBPBankAccountNumber.Size = New System.Drawing.Size(196, 21)
        Me.txtBPBankAccountNumber.TabIndex = 8
        '
        'btnBPBankAccount
        '
        Me.btnBPBankAccount.Image = CType(resources.GetObject("btnBPBankAccount.Image"), System.Drawing.Image)
        Me.btnBPBankAccount.Location = New System.Drawing.Point(419, 96)
        Me.btnBPBankAccount.Name = "btnBPBankAccount"
        Me.btnBPBankAccount.Size = New System.Drawing.Size(23, 23)
        Me.btnBPBankAccount.TabIndex = 9
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(21, 101)
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
        Me.Label17.Location = New System.Drawing.Point(21, 155)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 196
        Me.Label17.Text = "Nomor Invoice"
        '
        'txtInvoiceNumberBP
        '
        Me.txtInvoiceNumberBP.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNumberBP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumberBP.Location = New System.Drawing.Point(134, 151)
        Me.txtInvoiceNumberBP.MaxLength = 250
        Me.txtInvoiceNumberBP.Name = "txtInvoiceNumberBP"
        Me.txtInvoiceNumberBP.Size = New System.Drawing.Size(278, 21)
        Me.txtInvoiceNumberBP.TabIndex = 12
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(329, 178)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpInvoiceDate.TabIndex = 14
        Me.dtpInvoiceDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(240, 182)
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
        Me.dtpReceiveDate.Location = New System.Drawing.Point(134, 178)
        Me.dtpReceiveDate.Name = "dtpReceiveDate"
        Me.dtpReceiveDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpReceiveDate.TabIndex = 13
        Me.dtpReceiveDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(21, 182)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 194
        Me.Label19.Text = "Tanggal Terima"
        '
        'chkMaxQuantity
        '
        Me.chkMaxQuantity.AutoSize = True
        Me.chkMaxQuantity.Location = New System.Drawing.Point(294, 207)
        Me.chkMaxQuantity.Name = "chkMaxQuantity"
        Me.chkMaxQuantity.Size = New System.Drawing.Size(118, 17)
        Me.chkMaxQuantity.TabIndex = 16
        Me.chkMaxQuantity.Text = "Maksimal Quantity?"
        Me.chkMaxQuantity.UseVisualStyleBackColor = True
        '
        'chkIsFullDP
        '
        Me.chkIsFullDP.AutoSize = True
        Me.chkIsFullDP.Location = New System.Drawing.Point(346, 18)
        Me.chkIsFullDP.Name = "chkIsFullDP"
        Me.chkIsFullDP.Size = New System.Drawing.Size(66, 17)
        Me.chkIsFullDP.TabIndex = 1
        Me.chkIsFullDP.Text = "Full DP ?"
        Me.chkIsFullDP.UseVisualStyleBackColor = True
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotal.DecimalPlaces = 2
        Me.txtGrandTotal.Enabled = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(617, 151)
        Me.txtGrandTotal.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotal.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(249, 21)
        Me.txtGrandTotal.TabIndex = 22
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotal.ThousandsSeparator = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(502, 155)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Grand Total"
        '
        'txtReferencesNumber
        '
        Me.txtReferencesNumber.BackColor = System.Drawing.Color.Azure
        Me.txtReferencesNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencesNumber.Location = New System.Drawing.Point(134, 70)
        Me.txtReferencesNumber.MaxLength = 250
        Me.txtReferencesNumber.Name = "txtReferencesNumber"
        Me.txtReferencesNumber.ReadOnly = True
        Me.txtReferencesNumber.Size = New System.Drawing.Size(278, 21)
        Me.txtReferencesNumber.TabIndex = 5
        '
        'btnReferences
        '
        Me.btnReferences.Image = CType(resources.GetObject("btnReferences.Image"), System.Drawing.Image)
        Me.btnReferences.Location = New System.Drawing.Point(419, 69)
        Me.btnReferences.Name = "btnReferences"
        Me.btnReferences.Size = New System.Drawing.Size(23, 23)
        Me.btnReferences.TabIndex = 6
        Me.btnReferences.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(21, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 173
        Me.Label15.Text = "Nomor Referensi"
        '
        'txtBPCode
        '
        Me.txtBPCode.BackColor = System.Drawing.Color.Azure
        Me.txtBPCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPCode.Location = New System.Drawing.Point(134, 43)
        Me.txtBPCode.MaxLength = 250
        Me.txtBPCode.Name = "txtBPCode"
        Me.txtBPCode.ReadOnly = True
        Me.txtBPCode.Size = New System.Drawing.Size(83, 21)
        Me.txtBPCode.TabIndex = 2
        '
        'txtBPName
        '
        Me.txtBPName.BackColor = System.Drawing.Color.Azure
        Me.txtBPName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPName.Location = New System.Drawing.Point(216, 43)
        Me.txtBPName.MaxLength = 250
        Me.txtBPName.Name = "txtBPName"
        Me.txtBPName.ReadOnly = True
        Me.txtBPName.Size = New System.Drawing.Size(196, 21)
        Me.txtBPName.TabIndex = 3
        '
        'btnBP
        '
        Me.btnBP.Image = CType(resources.GetObject("btnBP.Image"), System.Drawing.Image)
        Me.btnBP.Location = New System.Drawing.Point(419, 42)
        Me.btnBP.Name = "btnBP"
        Me.btnBP.Size = New System.Drawing.Size(23, 23)
        Me.btnBP.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(21, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 170
        Me.Label12.Text = "Rekan Bisnis"
        '
        'txtDPAllocate
        '
        Me.txtDPAllocate.BackColor = System.Drawing.Color.LightYellow
        Me.txtDPAllocate.DecimalPlaces = 2
        Me.txtDPAllocate.Enabled = False
        Me.txtDPAllocate.Location = New System.Drawing.Point(617, 16)
        Me.txtDPAllocate.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtDPAllocate.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtDPAllocate.Name = "txtDPAllocate"
        Me.txtDPAllocate.Size = New System.Drawing.Size(249, 21)
        Me.txtDPAllocate.TabIndex = 17
        Me.txtDPAllocate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDPAllocate.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(502, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Total Alokasi Panjar"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(21, 20)
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
        Me.txtTotalPPH.Location = New System.Drawing.Point(617, 97)
        Me.txtTotalPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPH.Name = "txtTotalPPH"
        Me.txtTotalPPH.ReadOnly = True
        Me.txtTotalPPH.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPH.TabIndex = 20
        Me.txtTotalPPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPH.ThousandsSeparator = True
        '
        'txtARAPNumber
        '
        Me.txtARAPNumber.BackColor = System.Drawing.Color.White
        Me.txtARAPNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtARAPNumber.Location = New System.Drawing.Point(134, 16)
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
        Me.txtTotalAmount.Location = New System.Drawing.Point(617, 43)
        Me.txtTotalAmount.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalAmount.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalAmount.TabIndex = 18
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAmount.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(502, 101)
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
        Me.Label7.Location = New System.Drawing.Point(502, 47)
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
        Me.Label6.Location = New System.Drawing.Point(21, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Tanggal"
        '
        'txtCoACode
        '
        Me.txtCoACode.BackColor = System.Drawing.Color.Azure
        Me.txtCoACode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACode.Location = New System.Drawing.Point(134, 232)
        Me.txtCoACode.MaxLength = 250
        Me.txtCoACode.Name = "txtCoACode"
        Me.txtCoACode.ReadOnly = True
        Me.txtCoACode.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACode.TabIndex = 11
        Me.txtCoACode.Visible = False
        '
        'txtTotalPPN
        '
        Me.txtTotalPPN.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPN.DecimalPlaces = 2
        Me.txtTotalPPN.Enabled = False
        Me.txtTotalPPN.Location = New System.Drawing.Point(617, 70)
        Me.txtTotalPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPN.Name = "txtTotalPPN"
        Me.txtTotalPPN.ReadOnly = True
        Me.txtTotalPPN.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPN.TabIndex = 19
        Me.txtTotalPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPN.ThousandsSeparator = True
        '
        'btnCoAOfOutgoingPayment
        '
        Me.btnCoAOfOutgoingPayment.Image = CType(resources.GetObject("btnCoAOfOutgoingPayment.Image"), System.Drawing.Image)
        Me.btnCoAOfOutgoingPayment.Location = New System.Drawing.Point(419, 231)
        Me.btnCoAOfOutgoingPayment.Name = "btnCoAOfOutgoingPayment"
        Me.btnCoAOfOutgoingPayment.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfOutgoingPayment.TabIndex = 13
        Me.btnCoAOfOutgoingPayment.Visible = False
        '
        'dtpARAPDate
        '
        Me.dtpARAPDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpARAPDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpARAPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpARAPDate.Location = New System.Drawing.Point(134, 124)
        Me.dtpARAPDate.Name = "dtpARAPDate"
        Me.dtpARAPDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpARAPDate.TabIndex = 10
        Me.dtpARAPDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(502, 20)
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
        Me.Label11.Location = New System.Drawing.Point(502, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 163
        Me.Label11.Text = "Total PPN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Pilih Akun"
        Me.Label2.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(21, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Status"
        '
        'txtTotalDP
        '
        Me.txtTotalDP.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalDP.DecimalPlaces = 2
        Me.txtTotalDP.Enabled = False
        Me.txtTotalDP.Location = New System.Drawing.Point(617, 16)
        Me.txtTotalDP.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalDP.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalDP.Name = "txtTotalDP"
        Me.txtTotalDP.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalDP.TabIndex = 12
        Me.txtTotalDP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDP.ThousandsSeparator = True
        Me.txtTotalDP.Visible = False
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(134, 205)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(118, 21)
        Me.cboStatus.TabIndex = 15
        '
        'txtCoAName
        '
        Me.txtCoAName.BackColor = System.Drawing.Color.Azure
        Me.txtCoAName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoAName.Location = New System.Drawing.Point(216, 232)
        Me.txtCoAName.MaxLength = 250
        Me.txtCoAName.Name = "txtCoAName"
        Me.txtCoAName.ReadOnly = True
        Me.txtCoAName.Size = New System.Drawing.Size(196, 21)
        Me.txtCoAName.TabIndex = 12
        Me.txtCoAName.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(419, 128)
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
        Me.Label9.Location = New System.Drawing.Point(254, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "Jatuh Tempo"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(617, 178)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(502, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'txtDueDateValue
        '
        Me.txtDueDateValue.BackColor = System.Drawing.Color.White
        Me.txtDueDateValue.Location = New System.Drawing.Point(329, 124)
        Me.txtDueDateValue.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtDueDateValue.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtDueDateValue.Name = "txtDueDateValue"
        Me.txtDueDateValue.Size = New System.Drawing.Size(83, 21)
        Me.txtDueDateValue.TabIndex = 11
        Me.txtDueDateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDueDateValue.ThousandsSeparator = True
        '
        'tpDownPayment
        '
        Me.tpDownPayment.Controls.Add(Me.grdDownPayment)
        Me.tpDownPayment.Location = New System.Drawing.Point(4, 25)
        Me.tpDownPayment.Name = "tpDownPayment"
        Me.tpDownPayment.Size = New System.Drawing.Size(896, 243)
        Me.tpDownPayment.TabIndex = 2
        Me.tpDownPayment.Text = "Panjar - F2"
        Me.tpDownPayment.UseVisualStyleBackColor = True
        '
        'grdDownPayment
        '
        Me.grdDownPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdDownPayment.Location = New System.Drawing.Point(0, 0)
        Me.grdDownPayment.MainView = Me.grdDownPaymentView
        Me.grdDownPayment.Name = "grdDownPayment"
        Me.grdDownPayment.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiDPAmount})
        Me.grdDownPayment.Size = New System.Drawing.Size(896, 243)
        Me.grdDownPayment.TabIndex = 14
        Me.grdDownPayment.UseEmbeddedNavigator = True
        Me.grdDownPayment.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDownPaymentView})
        '
        'grdDownPaymentView
        '
        Me.grdDownPaymentView.GridControl = Me.grdDownPayment
        Me.grdDownPaymentView.Name = "grdDownPaymentView"
        Me.grdDownPaymentView.OptionsCustomization.AllowColumnMoving = False
        Me.grdDownPaymentView.OptionsCustomization.AllowGroup = False
        Me.grdDownPaymentView.OptionsView.ColumnAutoWidth = False
        Me.grdDownPaymentView.OptionsView.ShowGroupPanel = False
        '
        'rpiDPAmount
        '
        Me.rpiDPAmount.AutoHeight = False
        Me.rpiDPAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiDPAmount.Name = "rpiDPAmount"
        Me.rpiDPAmount.NullText = "0.00"
        '
        'tpHistory
        '
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Size = New System.Drawing.Size(896, 243)
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
        Me.grdStatus.Location = New System.Drawing.Point(0, 0)
        Me.grdStatus.MainView = Me.grdStatusView
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.Size = New System.Drawing.Size(896, 243)
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
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.CadetBlue
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 322)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(904, 22)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "« Item"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarCheckAll, Me.BarUncheckAll, Me.BarSep1Item, Me.BarAllocateDP})
        Me.ToolBarDetail.DropDownArrows = True
        Me.ToolBarDetail.Location = New System.Drawing.Point(0, 344)
        Me.ToolBarDetail.Name = "ToolBarDetail"
        Me.ToolBarDetail.ShowToolTips = True
        Me.ToolBarDetail.Size = New System.Drawing.Size(904, 28)
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
        'BarAllocateDP
        '
        Me.BarAllocateDP.Name = "BarAllocateDP"
        Me.BarAllocateDP.Tag = "Option"
        Me.BarAllocateDP.Text = "Alokasi Panjar"
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
        Me.grdItem.Location = New System.Drawing.Point(0, 372)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItem.Size = New System.Drawing.Size(904, 215)
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
        Me.grdItemView.OptionsView.ShowFooter = True
        Me.grdItemView.OptionsView.ShowGroupPanel = False
        '
        'rpiValue
        '
        Me.rpiValue.AutoHeight = False
        Me.rpiValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiValue.Name = "rpiValue"
        Me.rpiValue.NullText = "0.00"
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 609)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(904, 22)
        Me.pgMain.TabIndex = 7
        '
        'frmTraARAPDetVer4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 631)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.ToolBarDetail)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmTraARAPDetVer4"
        Me.Text = "frmTraARAPVer4"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.txtRounding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDPAllocate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDownPayment.ResumeLayout(False)
        CType(Me.grdDownPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDownPaymentView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiDPAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolBar As usToolBar
    Friend WithEvents BarRefresh As ToolBarButton
    Friend WithEvents BarClose As ToolBarButton
    Friend WithEvents lblInfo As Label
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripEmpty As ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As ToolStripStatusLabel
    Friend WithEvents tcHeader As TabControl
    Friend WithEvents tpMain As TabPage
    Friend WithEvents txtReferencesNumber As usTextBox
    Friend WithEvents btnReferences As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label15 As Label
    Friend WithEvents txtBPCode As usTextBox
    Friend WithEvents txtBPName As usTextBox
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label12 As Label
    Friend WithEvents txtDPAllocate As usNumeric
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTotalPPH As usNumeric
    Friend WithEvents txtARAPNumber As usTextBox
    Friend WithEvents txtTotalAmount As usNumeric
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTotalPPN As usNumeric
    Friend WithEvents dtpARAPDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalDP As usNumeric
    Friend WithEvents cboStatus As usComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtRemarks As usTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtDueDateValue As usNumeric
    Friend WithEvents tpDownPayment As TabPage
    Friend WithEvents grdDownPayment As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDownPaymentView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiDPAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents tpHistory As TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label14 As Label
    Friend WithEvents ToolBarDetail As usToolBar
    Friend WithEvents BarCheckAll As ToolBarButton
    Friend WithEvents BarUncheckAll As ToolBarButton
    Friend WithEvents BarSep1Item As ToolBarButton
    Friend WithEvents BarAllocateDP As ToolBarButton
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents pgMain As ProgressBar
    Friend WithEvents txtGrandTotal As usNumeric
    Friend WithEvents Label16 As Label
    Friend WithEvents chkIsFullDP As CheckBox
    Friend WithEvents chkMaxQuantity As System.Windows.Forms.CheckBox
    Friend WithEvents txtCoACode As ERPS.usTextBox
    Friend WithEvents btnCoAOfOutgoingPayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCoAName As ERPS.usTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumberBP As ERPS.usTextBox
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtBPBankAccountBank As ERPS.usTextBox
    Friend WithEvents txtBPBankAccountNumber As ERPS.usTextBox
    Friend WithEvents btnBPBankAccount As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtRounding As ERPS.usNumeric
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
