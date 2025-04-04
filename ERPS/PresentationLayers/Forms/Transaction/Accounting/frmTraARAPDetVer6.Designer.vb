<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraARAPDetVer6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraARAPDetVer6))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.txtRounding = New ERPS.usNumeric()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New ERPS.usNumeric()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBPCode = New ERPS.usTextBox()
        Me.txtBPName = New ERPS.usTextBox()
        Me.btnBP = New DevExpress.XtraEditors.SimpleButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalPPH = New ERPS.usNumeric()
        Me.txtARAPNumber = New ERPS.usTextBox()
        Me.txtTotalAmount = New ERPS.usNumeric()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalPPN = New ERPS.usNumeric()
        Me.dtpARAPDate = New System.Windows.Forms.DateTimePicker()
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolBarDetail = New ERPS.usToolBar()
        Me.BarCheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarUncheckAll = New System.Windows.Forms.ToolBarButton()
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
        CType(Me.txtRounding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 609)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(904, 22)
        Me.pgMain.TabIndex = 7
        '
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(904, 227)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.txtRounding)
        Me.tpMain.Controls.Add(Me.Label21)
        Me.tpMain.Controls.Add(Me.txtGrandTotal)
        Me.tpMain.Controls.Add(Me.Label16)
        Me.tpMain.Controls.Add(Me.txtBPCode)
        Me.tpMain.Controls.Add(Me.txtBPName)
        Me.tpMain.Controls.Add(Me.btnBP)
        Me.tpMain.Controls.Add(Me.Label12)
        Me.tpMain.Controls.Add(Me.Label8)
        Me.tpMain.Controls.Add(Me.txtTotalPPH)
        Me.tpMain.Controls.Add(Me.txtARAPNumber)
        Me.tpMain.Controls.Add(Me.txtTotalAmount)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.Label7)
        Me.tpMain.Controls.Add(Me.Label6)
        Me.tpMain.Controls.Add(Me.txtTotalPPN)
        Me.tpMain.Controls.Add(Me.dtpARAPDate)
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
        Me.tpMain.Size = New System.Drawing.Size(896, 198)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtRounding
        '
        Me.txtRounding.BackColor = System.Drawing.Color.White
        Me.txtRounding.DecimalPlaces = 2
        Me.txtRounding.Location = New System.Drawing.Point(617, 97)
        Me.txtRounding.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtRounding.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtRounding.Name = "txtRounding"
        Me.txtRounding.Size = New System.Drawing.Size(249, 21)
        Me.txtRounding.TabIndex = 11
        Me.txtRounding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRounding.ThousandsSeparator = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(502, 101)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 202
        Me.Label21.Text = "Pembulatan"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotal.DecimalPlaces = 2
        Me.txtGrandTotal.Enabled = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(617, 124)
        Me.txtGrandTotal.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotal.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(249, 21)
        Me.txtGrandTotal.TabIndex = 12
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotal.ThousandsSeparator = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(502, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Grand Total"
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
        Me.txtBPCode.TabIndex = 1
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
        Me.txtBPName.TabIndex = 2
        '
        'btnBP
        '
        Me.btnBP.ImageOptions.Image = CType(resources.GetObject("btnBP.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBP.Location = New System.Drawing.Point(419, 42)
        Me.btnBP.Name = "btnBP"
        Me.btnBP.Size = New System.Drawing.Size(23, 23)
        Me.btnBP.TabIndex = 3
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
        Me.txtTotalPPH.Location = New System.Drawing.Point(617, 70)
        Me.txtTotalPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPH.Name = "txtTotalPPH"
        Me.txtTotalPPH.ReadOnly = True
        Me.txtTotalPPH.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPH.TabIndex = 10
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
        Me.txtTotalAmount.Location = New System.Drawing.Point(617, 16)
        Me.txtTotalAmount.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalAmount.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalAmount.TabIndex = 8
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAmount.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(502, 74)
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
        Me.Label7.Location = New System.Drawing.Point(502, 20)
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
        Me.Label6.Location = New System.Drawing.Point(21, 74)
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
        Me.txtTotalPPN.Location = New System.Drawing.Point(617, 43)
        Me.txtTotalPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPN.Name = "txtTotalPPN"
        Me.txtTotalPPN.ReadOnly = True
        Me.txtTotalPPN.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPN.TabIndex = 9
        Me.txtTotalPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPN.ThousandsSeparator = True
        '
        'dtpARAPDate
        '
        Me.dtpARAPDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpARAPDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpARAPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpARAPDate.Location = New System.Drawing.Point(134, 70)
        Me.dtpARAPDate.Name = "dtpARAPDate"
        Me.dtpARAPDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpARAPDate.TabIndex = 4
        Me.dtpARAPDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(502, 47)
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
        Me.Label5.Location = New System.Drawing.Point(21, 101)
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
        Me.cboStatus.Location = New System.Drawing.Point(134, 97)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(118, 21)
        Me.cboStatus.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(419, 74)
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
        Me.Label9.Location = New System.Drawing.Point(254, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "Jatuh Tempo"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(134, 124)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(21, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'txtDueDateValue
        '
        Me.txtDueDateValue.BackColor = System.Drawing.Color.White
        Me.txtDueDateValue.Location = New System.Drawing.Point(329, 70)
        Me.txtDueDateValue.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtDueDateValue.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtDueDateValue.Name = "txtDueDateValue"
        Me.txtDueDateValue.Size = New System.Drawing.Size(83, 21)
        Me.txtDueDateValue.TabIndex = 5
        Me.txtDueDateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDueDateValue.ThousandsSeparator = True
        '
        'tpHistory
        '
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Size = New System.Drawing.Size(896, 198)
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
        Me.grdStatus.Size = New System.Drawing.Size(896, 198)
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
        Me.Label14.Location = New System.Drawing.Point(0, 277)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(904, 22)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "« Item"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarCheckAll, Me.BarUncheckAll})
        Me.ToolBarDetail.DropDownArrows = True
        Me.ToolBarDetail.Location = New System.Drawing.Point(0, 299)
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
        Me.grdItem.Location = New System.Drawing.Point(0, 327)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItem.Size = New System.Drawing.Size(904, 260)
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
        'frmTraARAPDetVer6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 631)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ToolBarDetail)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmTraARAPDetVer6"
        Me.Text = "frmTraARAPDetVer6"
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.txtRounding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
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
    Friend WithEvents pgMain As ProgressBar
    Friend WithEvents tcHeader As TabControl
    Friend WithEvents tpMain As TabPage
    Friend WithEvents txtRounding As usNumeric
    Friend WithEvents Label21 As Label
    Friend WithEvents txtGrandTotal As usNumeric
    Friend WithEvents Label16 As Label
    Friend WithEvents txtBPCode As usTextBox
    Friend WithEvents txtBPName As usTextBox
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label12 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTotalPPH As usNumeric
    Friend WithEvents txtARAPNumber As usTextBox
    Friend WithEvents txtTotalAmount As usNumeric
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTotalPPN As usNumeric
    Friend WithEvents dtpARAPDate As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboStatus As usComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtRemarks As usTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtDueDateValue As usNumeric
    Friend WithEvents tpHistory As TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label14 As Label
    Friend WithEvents ToolBarDetail As usToolBar
    Friend WithEvents BarCheckAll As ToolBarButton
    Friend WithEvents BarUncheckAll As ToolBarButton
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripEmpty As ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As ToolStripStatusLabel
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
