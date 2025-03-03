<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraARAPDetVer3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraARAPDetVer3))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.txtTotalPPH = New ERPS.usNumeric()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalPPN = New ERPS.usNumeric()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkUsePercentage = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDueDateValue = New ERPS.usNumeric()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPercentage = New ERPS.usNumeric()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOutstandingPayment = New ERPS.usNumeric()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalPayment = New ERPS.usNumeric()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGrandTotalContract = New ERPS.usNumeric()
        Me.txtTotalAmount = New ERPS.usNumeric()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCoACode = New ERPS.usTextBox()
        Me.btnCoAOfOutgoingPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCoAName = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.cboStatus = New ERPS.usComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpDPDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDPNumber = New ERPS.usTextBox()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolBarDetail = New ERPS.usToolBar()
        Me.BarCheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarUncheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1Item = New System.Windows.Forms.ToolBarButton()
        Me.BarCalculate = New System.Windows.Forms.ToolBarButton()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tpHistoryReceive = New System.Windows.Forms.TabPage()
        Me.grdHistoryReceive = New DevExpress.XtraGrid.GridControl()
        Me.grdHistoryReceiveView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.StatusStrip.SuspendLayout()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutstandingPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalContract, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistoryReceive.SuspendLayout()
        CType(Me.grdHistoryReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHistoryReceiveView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(884, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(884, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Down Payment Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 638)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(884, 23)
        Me.pgMain.TabIndex = 5
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 616)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(884, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(761, 17)
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
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Controls.Add(Me.tpHistoryReceive)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(884, 255)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.txtTotalPPH)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.txtTotalPPN)
        Me.tpMain.Controls.Add(Me.Label11)
        Me.tpMain.Controls.Add(Me.chkUsePercentage)
        Me.tpMain.Controls.Add(Me.Label10)
        Me.tpMain.Controls.Add(Me.txtDueDateValue)
        Me.tpMain.Controls.Add(Me.Label9)
        Me.tpMain.Controls.Add(Me.txtPercentage)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.Label12)
        Me.tpMain.Controls.Add(Me.txtOutstandingPayment)
        Me.tpMain.Controls.Add(Me.Label1)
        Me.tpMain.Controls.Add(Me.txtTotalPayment)
        Me.tpMain.Controls.Add(Me.Label15)
        Me.tpMain.Controls.Add(Me.txtGrandTotalContract)
        Me.tpMain.Controls.Add(Me.txtTotalAmount)
        Me.tpMain.Controls.Add(Me.Label7)
        Me.tpMain.Controls.Add(Me.txtCoACode)
        Me.tpMain.Controls.Add(Me.btnCoAOfOutgoingPayment)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Controls.Add(Me.txtCoAName)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.Label5)
        Me.tpMain.Controls.Add(Me.dtpDPDate)
        Me.tpMain.Controls.Add(Me.Label6)
        Me.tpMain.Controls.Add(Me.Label8)
        Me.tpMain.Controls.Add(Me.txtDPNumber)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(876, 226)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtTotalPPH
        '
        Me.txtTotalPPH.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPH.DecimalPlaces = 2
        Me.txtTotalPPH.Enabled = False
        Me.txtTotalPPH.Location = New System.Drawing.Point(588, 97)
        Me.txtTotalPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPH.Name = "txtTotalPPH"
        Me.txtTotalPPH.ReadOnly = True
        Me.txtTotalPPH.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPH.TabIndex = 13
        Me.txtTotalPPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPH.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(470, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Total PPH Dibayar"
        '
        'txtTotalPPN
        '
        Me.txtTotalPPN.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPN.DecimalPlaces = 2
        Me.txtTotalPPN.Enabled = False
        Me.txtTotalPPN.Location = New System.Drawing.Point(588, 70)
        Me.txtTotalPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPN.Name = "txtTotalPPN"
        Me.txtTotalPPN.ReadOnly = True
        Me.txtTotalPPN.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPN.TabIndex = 12
        Me.txtTotalPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPN.ThousandsSeparator = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(470, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 13)
        Me.Label11.TabIndex = 163
        Me.Label11.Text = "Total PPN Dibayar"
        '
        'chkUsePercentage
        '
        Me.chkUsePercentage.AutoSize = True
        Me.chkUsePercentage.Location = New System.Drawing.Point(230, 72)
        Me.chkUsePercentage.Name = "chkUsePercentage"
        Me.chkUsePercentage.Size = New System.Drawing.Size(70, 17)
        Me.chkUsePercentage.TabIndex = 5
        Me.chkUsePercentage.Text = "Aktifkan?"
        Me.chkUsePercentage.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(230, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 159
        Me.Label10.Text = "Hari"
        '
        'txtDueDateValue
        '
        Me.txtDueDateValue.BackColor = System.Drawing.Color.White
        Me.txtDueDateValue.Location = New System.Drawing.Point(141, 151)
        Me.txtDueDateValue.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtDueDateValue.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtDueDateValue.Name = "txtDueDateValue"
        Me.txtDueDateValue.Size = New System.Drawing.Size(83, 21)
        Me.txtDueDateValue.TabIndex = 8
        Me.txtDueDateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDueDateValue.ThousandsSeparator = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(28, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "Jatuh Tempo"
        '
        'txtPercentage
        '
        Me.txtPercentage.BackColor = System.Drawing.Color.LightYellow
        Me.txtPercentage.DecimalPlaces = 2
        Me.txtPercentage.Enabled = False
        Me.txtPercentage.Location = New System.Drawing.Point(141, 70)
        Me.txtPercentage.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPercentage.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(83, 21)
        Me.txtPercentage.TabIndex = 4
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercentage.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Persentase"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(470, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 153
        Me.Label12.Text = "Sisa Bayar"
        '
        'txtOutstandingPayment
        '
        Me.txtOutstandingPayment.BackColor = System.Drawing.Color.LightYellow
        Me.txtOutstandingPayment.DecimalPlaces = 2
        Me.txtOutstandingPayment.Enabled = False
        Me.txtOutstandingPayment.Location = New System.Drawing.Point(588, 124)
        Me.txtOutstandingPayment.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtOutstandingPayment.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtOutstandingPayment.Name = "txtOutstandingPayment"
        Me.txtOutstandingPayment.Size = New System.Drawing.Size(249, 21)
        Me.txtOutstandingPayment.TabIndex = 14
        Me.txtOutstandingPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOutstandingPayment.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(470, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Total Bayar"
        '
        'txtTotalPayment
        '
        Me.txtTotalPayment.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPayment.DecimalPlaces = 2
        Me.txtTotalPayment.Enabled = False
        Me.txtTotalPayment.Location = New System.Drawing.Point(588, 43)
        Me.txtTotalPayment.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPayment.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPayment.Name = "txtTotalPayment"
        Me.txtTotalPayment.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPayment.TabIndex = 11
        Me.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPayment.ThousandsSeparator = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(470, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 13)
        Me.Label15.TabIndex = 149
        Me.Label15.Text = "Grand Total Kontrak"
        '
        'txtGrandTotalContract
        '
        Me.txtGrandTotalContract.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotalContract.DecimalPlaces = 2
        Me.txtGrandTotalContract.Enabled = False
        Me.txtGrandTotalContract.Location = New System.Drawing.Point(588, 16)
        Me.txtGrandTotalContract.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotalContract.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotalContract.Name = "txtGrandTotalContract"
        Me.txtGrandTotalContract.Size = New System.Drawing.Size(249, 21)
        Me.txtGrandTotalContract.TabIndex = 10
        Me.txtGrandTotalContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotalContract.ThousandsSeparator = True
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalAmount.DecimalPlaces = 2
        Me.txtTotalAmount.Enabled = False
        Me.txtTotalAmount.Location = New System.Drawing.Point(141, 97)
        Me.txtTotalAmount.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalAmount.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalAmount.TabIndex = 6
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAmount.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(28, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Total Bayar"
        '
        'txtCoACode
        '
        Me.txtCoACode.BackColor = System.Drawing.Color.Azure
        Me.txtCoACode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACode.Location = New System.Drawing.Point(141, 43)
        Me.txtCoACode.MaxLength = 250
        Me.txtCoACode.Name = "txtCoACode"
        Me.txtCoACode.ReadOnly = True
        Me.txtCoACode.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACode.TabIndex = 1
        '
        'btnCoAOfOutgoingPayment
        '
        Me.btnCoAOfOutgoingPayment.Enabled = False
        Me.btnCoAOfOutgoingPayment.Image = CType(resources.GetObject("btnCoAOfOutgoingPayment.Image"), System.Drawing.Image)
        Me.btnCoAOfOutgoingPayment.Location = New System.Drawing.Point(396, 42)
        Me.btnCoAOfOutgoingPayment.Name = "btnCoAOfOutgoingPayment"
        Me.btnCoAOfOutgoingPayment.Size = New System.Drawing.Size(23, 23)
        Me.btnCoAOfOutgoingPayment.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Pilih Akun"
        '
        'txtCoAName
        '
        Me.txtCoAName.BackColor = System.Drawing.Color.Azure
        Me.txtCoAName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoAName.Location = New System.Drawing.Point(223, 43)
        Me.txtCoAName.MaxLength = 250
        Me.txtCoAName.Name = "txtCoAName"
        Me.txtCoAName.ReadOnly = True
        Me.txtCoAName.Size = New System.Drawing.Size(167, 21)
        Me.txtCoAName.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(470, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(588, 151)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 15
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(141, 178)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(127, 21)
        Me.cboStatus.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Status"
        '
        'dtpDPDate
        '
        Me.dtpDPDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDPDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDPDate.Location = New System.Drawing.Point(141, 124)
        Me.dtpDPDate.Name = "dtpDPDate"
        Me.dtpDPDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpDPDate.TabIndex = 7
        Me.dtpDPDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(28, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Tanggal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(28, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Nomor"
        '
        'txtDPNumber
        '
        Me.txtDPNumber.BackColor = System.Drawing.Color.White
        Me.txtDPNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDPNumber.Location = New System.Drawing.Point(141, 16)
        Me.txtDPNumber.MaxLength = 250
        Me.txtDPNumber.Name = "txtDPNumber"
        Me.txtDPNumber.Size = New System.Drawing.Size(167, 21)
        Me.txtDPNumber.TabIndex = 0
        '
        'tpHistory
        '
        Me.tpHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHistory.Size = New System.Drawing.Size(876, 226)
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
        Me.grdStatus.Location = New System.Drawing.Point(3, 3)
        Me.grdStatus.MainView = Me.grdStatusView
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.Size = New System.Drawing.Size(866, 216)
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
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.CadetBlue
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 305)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(884, 22)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "« Item"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarCheckAll, Me.BarUncheckAll, Me.BarSep1Item, Me.BarCalculate})
        Me.ToolBarDetail.DropDownArrows = True
        Me.ToolBarDetail.Location = New System.Drawing.Point(0, 327)
        Me.ToolBarDetail.Name = "ToolBarDetail"
        Me.ToolBarDetail.ShowToolTips = True
        Me.ToolBarDetail.Size = New System.Drawing.Size(884, 28)
        Me.ToolBarDetail.TabIndex = 9
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
        Me.grdItem.Location = New System.Drawing.Point(0, 355)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItem.Size = New System.Drawing.Size(884, 261)
        Me.grdItem.TabIndex = 10
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
        'tpHistoryReceive
        '
        Me.tpHistoryReceive.Controls.Add(Me.grdHistoryReceive)
        Me.tpHistoryReceive.Location = New System.Drawing.Point(4, 25)
        Me.tpHistoryReceive.Name = "tpHistoryReceive"
        Me.tpHistoryReceive.Size = New System.Drawing.Size(876, 226)
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
        Me.grdHistoryReceive.Size = New System.Drawing.Size(876, 226)
        Me.grdHistoryReceive.TabIndex = 14
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
        'frmTraARAPDetVer3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 661)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.ToolBarDetail)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraARAPDetVer3"
        Me.Text = "Panjar"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutstandingPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalContract, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistoryReceive.ResumeLayout(False)
        CType(Me.grdHistoryReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHistoryReceiveView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolBar As usToolBar
    Friend WithEvents BarRefresh As ToolBarButton
    Friend WithEvents BarClose As ToolBarButton
    Friend WithEvents lblInfo As Label
    Friend WithEvents pgMain As ProgressBar
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripEmpty As ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As ToolStripStatusLabel
    Friend WithEvents tcHeader As TabControl
    Friend WithEvents tpMain As TabPage
    Friend WithEvents txtTotalPPH As usNumeric
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTotalPPN As usNumeric
    Friend WithEvents Label11 As Label
    Friend WithEvents chkUsePercentage As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDueDateValue As usNumeric
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPercentage As usNumeric
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtOutstandingPayment As usNumeric
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalPayment As usNumeric
    Friend WithEvents Label15 As Label
    Friend WithEvents txtGrandTotalContract As usNumeric
    Friend WithEvents txtTotalAmount As usNumeric
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCoACode As usTextBox
    Friend WithEvents btnCoAOfOutgoingPayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCoAName As usTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtRemarks As usTextBox
    Friend WithEvents cboStatus As usComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpDPDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDPNumber As usTextBox
    Friend WithEvents tpHistory As TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label14 As Label
    Friend WithEvents ToolBarDetail As usToolBar
    Friend WithEvents BarCheckAll As ToolBarButton
    Friend WithEvents BarUncheckAll As ToolBarButton
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarSep1Item As ToolBarButton
    Friend WithEvents BarCalculate As ToolBarButton
    Friend WithEvents tpHistoryReceive As TabPage
    Friend WithEvents grdHistoryReceive As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdHistoryReceiveView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
