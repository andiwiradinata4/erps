<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraAPTransporterDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraAPTransporterDet))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
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
        Me.txtDueDateValue = New ERPS.usNumeric()
        Me.tpRemarks = New System.Windows.Forms.TabPage()
        Me.grdRemarks = New DevExpress.XtraGrid.GridControl()
        Me.grdRemarksView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBarRemarksResult = New ERPS.usToolBar()
        Me.BarAddRemarksResult = New System.Windows.Forms.ToolBarButton()
        Me.BarEditRemarksResult = New System.Windows.Forms.ToolBarButton()
        Me.BarDeleteRemarksResult = New System.Windows.Forms.ToolBarButton()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolBarDetail = New ERPS.usToolBar()
        Me.BarCheckAll = New System.Windows.Forms.ToolBarButton()
        Me.BarUncheckAll = New System.Windows.Forms.ToolBarButton()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpRemarks.SuspendLayout()
        CType(Me.grdRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRemarksView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblInfo.Text = "« Pembayaran Biaya Transporter"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpRemarks)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(884, 200)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        Me.tpMain.Controls.Add(Me.txtDueDateValue)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(876, 171)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotal.DecimalPlaces = 2
        Me.txtGrandTotal.Enabled = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(578, 98)
        Me.txtGrandTotal.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotal.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(249, 21)
        Me.txtGrandTotal.TabIndex = 10
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotal.ThousandsSeparator = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(463, 102)
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
        Me.txtBPName.Size = New System.Drawing.Size(167, 21)
        Me.txtBPName.TabIndex = 2
        '
        'btnBP
        '
        Me.btnBP.Image = CType(resources.GetObject("btnBP.Image"), System.Drawing.Image)
        Me.btnBP.Location = New System.Drawing.Point(389, 42)
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
        Me.txtTotalPPH.Location = New System.Drawing.Point(578, 71)
        Me.txtTotalPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPH.Name = "txtTotalPPH"
        Me.txtTotalPPH.ReadOnly = True
        Me.txtTotalPPH.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPH.TabIndex = 9
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
        Me.txtARAPNumber.Size = New System.Drawing.Size(167, 21)
        Me.txtARAPNumber.TabIndex = 0
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalAmount.DecimalPlaces = 2
        Me.txtTotalAmount.Enabled = False
        Me.txtTotalAmount.Location = New System.Drawing.Point(578, 17)
        Me.txtTotalAmount.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalAmount.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalAmount.TabIndex = 7
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAmount.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(463, 75)
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
        Me.Label7.Location = New System.Drawing.Point(463, 21)
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
        Me.txtTotalPPN.Location = New System.Drawing.Point(578, 44)
        Me.txtTotalPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPN.Name = "txtTotalPPN"
        Me.txtTotalPPN.ReadOnly = True
        Me.txtTotalPPN.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalPPN.TabIndex = 8
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
        Me.Label11.Location = New System.Drawing.Point(463, 48)
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
        Me.Label5.Location = New System.Drawing.Point(21, 129)
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
        Me.cboStatus.Location = New System.Drawing.Point(134, 125)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(118, 21)
        Me.cboStatus.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(226, 101)
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
        Me.Label9.Location = New System.Drawing.Point(21, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "Jatuh Tempo"
        '
        'txtDueDateValue
        '
        Me.txtDueDateValue.BackColor = System.Drawing.Color.White
        Me.txtDueDateValue.Location = New System.Drawing.Point(134, 97)
        Me.txtDueDateValue.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtDueDateValue.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtDueDateValue.Name = "txtDueDateValue"
        Me.txtDueDateValue.Size = New System.Drawing.Size(83, 21)
        Me.txtDueDateValue.TabIndex = 5
        Me.txtDueDateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDueDateValue.ThousandsSeparator = True
        '
        'tpRemarks
        '
        Me.tpRemarks.Controls.Add(Me.grdRemarks)
        Me.tpRemarks.Controls.Add(Me.ToolBarRemarksResult)
        Me.tpRemarks.Location = New System.Drawing.Point(4, 25)
        Me.tpRemarks.Name = "tpRemarks"
        Me.tpRemarks.Size = New System.Drawing.Size(876, 171)
        Me.tpRemarks.TabIndex = 2
        Me.tpRemarks.Text = "Keterangan - F2"
        Me.tpRemarks.UseVisualStyleBackColor = True
        '
        'grdRemarks
        '
        Me.grdRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdRemarks.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdRemarks.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdRemarks.Location = New System.Drawing.Point(0, 28)
        Me.grdRemarks.MainView = Me.grdRemarksView
        Me.grdRemarks.Name = "grdRemarks"
        Me.grdRemarks.Size = New System.Drawing.Size(876, 143)
        Me.grdRemarks.TabIndex = 19
        Me.grdRemarks.UseEmbeddedNavigator = True
        Me.grdRemarks.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdRemarksView})
        '
        'grdRemarksView
        '
        Me.grdRemarksView.GridControl = Me.grdRemarks
        Me.grdRemarksView.Name = "grdRemarksView"
        Me.grdRemarksView.OptionsCustomization.AllowColumnMoving = False
        Me.grdRemarksView.OptionsCustomization.AllowGroup = False
        Me.grdRemarksView.OptionsView.ColumnAutoWidth = False
        Me.grdRemarksView.OptionsView.ShowGroupPanel = False
        '
        'ToolBarRemarksResult
        '
        Me.ToolBarRemarksResult.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarRemarksResult.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddRemarksResult, Me.BarEditRemarksResult, Me.BarDeleteRemarksResult})
        Me.ToolBarRemarksResult.DropDownArrows = True
        Me.ToolBarRemarksResult.Location = New System.Drawing.Point(0, 0)
        Me.ToolBarRemarksResult.Name = "ToolBarRemarksResult"
        Me.ToolBarRemarksResult.ShowToolTips = True
        Me.ToolBarRemarksResult.Size = New System.Drawing.Size(876, 28)
        Me.ToolBarRemarksResult.TabIndex = 18
        Me.ToolBarRemarksResult.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAddRemarksResult
        '
        Me.BarAddRemarksResult.Name = "BarAddRemarksResult"
        Me.BarAddRemarksResult.Tag = "Add"
        Me.BarAddRemarksResult.Text = "Tambah"
        '
        'BarEditRemarksResult
        '
        Me.BarEditRemarksResult.Name = "BarEditRemarksResult"
        Me.BarEditRemarksResult.Tag = "Edit"
        Me.BarEditRemarksResult.Text = "Edit"
        '
        'BarDeleteRemarksResult
        '
        Me.BarDeleteRemarksResult.Name = "BarDeleteRemarksResult"
        Me.BarDeleteRemarksResult.Tag = "Delete"
        Me.BarDeleteRemarksResult.Text = "Hapus"
        '
        'tpHistory
        '
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Size = New System.Drawing.Size(876, 171)
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
        Me.grdStatus.Size = New System.Drawing.Size(876, 171)
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
        Me.Label14.Location = New System.Drawing.Point(0, 250)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(884, 22)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "« Item"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarCheckAll, Me.BarUncheckAll})
        Me.ToolBarDetail.DropDownArrows = True
        Me.ToolBarDetail.Location = New System.Drawing.Point(0, 272)
        Me.ToolBarDetail.Name = "ToolBarDetail"
        Me.ToolBarDetail.ShowToolTips = True
        Me.ToolBarDetail.Size = New System.Drawing.Size(884, 28)
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
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 609)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(884, 22)
        Me.pgMain.TabIndex = 6
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
        Me.grdItem.Location = New System.Drawing.Point(0, 300)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItem.Size = New System.Drawing.Size(884, 309)
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
        'frmTraAPTransporterDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 631)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.ToolBarDetail)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmTraAPTransporterDet"
        Me.Text = "Pembayaran Biaya Transporter"
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDateValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpRemarks.ResumeLayout(False)
        Me.tpRemarks.PerformLayout()
        CType(Me.grdRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRemarksView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tcHeader As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents txtGrandTotal As ERPS.usNumeric
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBPCode As ERPS.usTextBox
    Friend WithEvents txtBPName As ERPS.usTextBox
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPH As ERPS.usNumeric
    Friend WithEvents txtARAPNumber As ERPS.usTextBox
    Friend WithEvents txtTotalAmount As ERPS.usNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPN As ERPS.usNumeric
    Friend WithEvents dtpARAPDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDueDateValue As ERPS.usNumeric
    Friend WithEvents tpHistory As System.Windows.Forms.TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ToolBarDetail As ERPS.usToolBar
    Friend WithEvents BarCheckAll As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarUncheckAll As System.Windows.Forms.ToolBarButton
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents tpRemarks As System.Windows.Forms.TabPage
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ToolBarRemarksResult As ERPS.usToolBar
    Friend WithEvents BarAddRemarksResult As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarEditRemarksResult As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeleteRemarksResult As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdRemarks As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdRemarksView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
