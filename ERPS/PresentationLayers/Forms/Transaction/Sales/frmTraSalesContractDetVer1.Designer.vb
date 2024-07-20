<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSalesContractDetVer1
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraSalesContractDetVer1))
        Me.grdSubItemCOView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdItemCO = New DevExpress.XtraGrid.GridControl()
        Me.grdItemCOView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.dtpDeliveryPeriodTo = New DevExpress.XtraEditors.DateEdit()
        Me.dtpDeliveryPeriodFrom = New DevExpress.XtraEditors.DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAllowanceProduction = New ERPS.usNumeric()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtFranco = New ERPS.usTextBox()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.txtBPCode = New ERPS.usTextBox()
        Me.txtBPName = New ERPS.usTextBox()
        Me.txtSCNumber = New ERPS.usTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboStatus = New ERPS.usComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.dtpSCDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBP = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpAmount = New System.Windows.Forms.TabPage()
        Me.gboCompanyBankAccount = New System.Windows.Forms.GroupBox()
        Me.txtCurrencyBank = New ERPS.usTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtBankName = New ERPS.usTextBox()
        Me.txtAccountNumber = New ERPS.usTextBox()
        Me.txtAccountName = New ERPS.usTextBox()
        Me.btnCompanyBankAccount = New DevExpress.XtraEditors.SimpleButton()
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
        Me.tpPaymentTerm = New System.Windows.Forms.TabPage()
        Me.grdPaymentTerm = New DevExpress.XtraGrid.GridControl()
        Me.grdPaymentTermView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarPaymentTerm = New ERPS.usToolBar()
        Me.BarAddPayment = New System.Windows.Forms.ToolBarButton()
        Me.BarEditPayment = New System.Windows.Forms.ToolBarButton()
        Me.BarDeletePayment = New System.Windows.Forms.ToolBarButton()
        Me.tpAdditionalInformation = New System.Windows.Forms.TabPage()
        Me.DelegationSeller = New System.Windows.Forms.GroupBox()
        Me.txtDelegationPositionSeller = New ERPS.usTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDelegationSeller = New ERPS.usTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gboDelegationBuyer = New System.Windows.Forms.GroupBox()
        Me.txtDelegationPositionBuyer = New ERPS.usTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDelegationBuyer = New ERPS.usTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.tpConfirmationOrder = New System.Windows.Forms.TabPage()
        CType(Me.grdSubItemCOView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemCOView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.dtpDeliveryPeriodTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDeliveryPeriodTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDeliveryPeriodFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDeliveryPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAllowanceProduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAmount.SuspendLayout()
        Me.gboCompanyBankAccount.SuspendLayout()
        Me.gboPesanan.SuspendLayout()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDPP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPaymentTerm.SuspendLayout()
        CType(Me.grdPaymentTerm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPaymentTermView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAdditionalInformation.SuspendLayout()
        Me.DelegationSeller.SuspendLayout()
        Me.gboDelegationBuyer.SuspendLayout()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcDetail.SuspendLayout()
        Me.tpItem.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.tpConfirmationOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdSubItemCOView
        '
        Me.grdSubItemCOView.GridControl = Me.grdItemCO
        Me.grdSubItemCOView.Name = "grdSubItemCOView"
        Me.grdSubItemCOView.OptionsCustomization.AllowGroup = False
        Me.grdSubItemCOView.OptionsView.ColumnAutoWidth = False
        Me.grdSubItemCOView.OptionsView.ShowFooter = True
        Me.grdSubItemCOView.OptionsView.ShowGroupPanel = False
        '
        'grdItemCO
        '
        Me.grdItemCO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdItemCO.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.grdSubItemCOView
        GridLevelNode1.RelationName = "SubView"
        Me.grdItemCO.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdItemCO.Location = New System.Drawing.Point(0, 0)
        Me.grdItemCO.MainView = Me.grdItemCOView
        Me.grdItemCO.Name = "grdItemCO"
        Me.grdItemCO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit3})
        Me.grdItemCO.Size = New System.Drawing.Size(917, 311)
        Me.grdItemCO.TabIndex = 2
        Me.grdItemCO.UseEmbeddedNavigator = True
        Me.grdItemCO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemCOView, Me.grdSubItemCOView})
        '
        'grdItemCOView
        '
        Me.grdItemCOView.GridControl = Me.grdItemCO
        Me.grdItemCOView.Name = "grdItemCOView"
        Me.grdItemCOView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemCOView.OptionsCustomization.AllowGroup = False
        Me.grdItemCOView.OptionsView.ColumnAutoWidth = False
        Me.grdItemCOView.OptionsView.ShowAutoFilterRow = True
        Me.grdItemCOView.OptionsView.ShowFooter = True
        Me.grdItemCOView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.NullText = "0.00"
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
        Me.lblInfo.Text = "« Kontrak Penjualan Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 638)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(925, 23)
        Me.pgMain.TabIndex = 5
        '
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpAmount)
        Me.tcHeader.Controls.Add(Me.tpPaymentTerm)
        Me.tcHeader.Controls.Add(Me.tpAdditionalInformation)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(925, 199)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.dtpDeliveryPeriodTo)
        Me.tpMain.Controls.Add(Me.dtpDeliveryPeriodFrom)
        Me.tpMain.Controls.Add(Me.Label9)
        Me.tpMain.Controls.Add(Me.txtAllowanceProduction)
        Me.tpMain.Controls.Add(Me.Label21)
        Me.tpMain.Controls.Add(Me.Label20)
        Me.tpMain.Controls.Add(Me.txtFranco)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.txtBPCode)
        Me.tpMain.Controls.Add(Me.txtBPName)
        Me.tpMain.Controls.Add(Me.txtSCNumber)
        Me.tpMain.Controls.Add(Me.Label19)
        Me.tpMain.Controls.Add(Me.Label5)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.lblStatusID)
        Me.tpMain.Controls.Add(Me.dtpSCDate)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.btnBP)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(917, 170)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'dtpDeliveryPeriodTo
        '
        Me.dtpDeliveryPeriodTo.EditValue = New Date(2024, 5, 31, 14, 21, 51, 3)
        Me.dtpDeliveryPeriodTo.Location = New System.Drawing.Point(278, 97)
        Me.dtpDeliveryPeriodTo.Name = "dtpDeliveryPeriodTo"
        Me.dtpDeliveryPeriodTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDeliveryPeriodTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDeliveryPeriodTo.Properties.DisplayFormat.FormatString = "MMMM yyyy"
        Me.dtpDeliveryPeriodTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtpDeliveryPeriodTo.Properties.EditFormat.FormatString = "MMMM yyyy"
        Me.dtpDeliveryPeriodTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtpDeliveryPeriodTo.Properties.Mask.EditMask = "y"
        Me.dtpDeliveryPeriodTo.Size = New System.Drawing.Size(116, 20)
        Me.dtpDeliveryPeriodTo.TabIndex = 6
        '
        'dtpDeliveryPeriodFrom
        '
        Me.dtpDeliveryPeriodFrom.EditValue = New Date(2024, 5, 31, 14, 21, 51, 3)
        Me.dtpDeliveryPeriodFrom.Location = New System.Drawing.Point(145, 97)
        Me.dtpDeliveryPeriodFrom.Name = "dtpDeliveryPeriodFrom"
        Me.dtpDeliveryPeriodFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDeliveryPeriodFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDeliveryPeriodFrom.Properties.DisplayFormat.FormatString = "MMMM yyyy"
        Me.dtpDeliveryPeriodFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtpDeliveryPeriodFrom.Properties.EditFormat.FormatString = "MMMM yyyy"
        Me.dtpDeliveryPeriodFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtpDeliveryPeriodFrom.Properties.Mask.EditMask = "y"
        Me.dtpDeliveryPeriodFrom.Size = New System.Drawing.Size(116, 20)
        Me.dtpDeliveryPeriodFrom.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(695, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 139
        Me.Label9.Text = "%"
        '
        'txtAllowanceProduction
        '
        Me.txtAllowanceProduction.DecimalPlaces = 2
        Me.txtAllowanceProduction.Location = New System.Drawing.Point(585, 16)
        Me.txtAllowanceProduction.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtAllowanceProduction.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtAllowanceProduction.Name = "txtAllowanceProduction"
        Me.txtAllowanceProduction.Size = New System.Drawing.Size(105, 21)
        Me.txtAllowanceProduction.TabIndex = 8
        Me.txtAllowanceProduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAllowanceProduction.ThousandsSeparator = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(265, 101)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 137
        Me.Label21.Text = "-"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(28, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 13)
        Me.Label20.TabIndex = 135
        Me.Label20.Text = "Periode Pengiriman"
        '
        'txtFranco
        '
        Me.txtFranco.BackColor = System.Drawing.Color.White
        Me.txtFranco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFranco.Location = New System.Drawing.Point(145, 124)
        Me.txtFranco.MaxLength = 250
        Me.txtFranco.Name = "txtFranco"
        Me.txtFranco.Size = New System.Drawing.Size(249, 21)
        Me.txtFranco.TabIndex = 7
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(585, 70)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(283, 48)
        Me.txtRemarks.TabIndex = 12
        '
        'txtBPCode
        '
        Me.txtBPCode.BackColor = System.Drawing.Color.Azure
        Me.txtBPCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPCode.Location = New System.Drawing.Point(145, 43)
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
        Me.txtBPName.Location = New System.Drawing.Point(227, 43)
        Me.txtBPName.MaxLength = 250
        Me.txtBPName.Name = "txtBPName"
        Me.txtBPName.ReadOnly = True
        Me.txtBPName.Size = New System.Drawing.Size(167, 21)
        Me.txtBPName.TabIndex = 2
        '
        'txtSCNumber
        '
        Me.txtSCNumber.BackColor = System.Drawing.Color.White
        Me.txtSCNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSCNumber.Location = New System.Drawing.Point(145, 16)
        Me.txtSCNumber.MaxLength = 250
        Me.txtSCNumber.Name = "txtSCNumber"
        Me.txtSCNumber.Size = New System.Drawing.Size(167, 21)
        Me.txtSCNumber.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(28, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 13)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "Syarat Penyerahan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(468, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Allowance Produksi"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(468, 74)
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
        Me.cboStatus.Location = New System.Drawing.Point(585, 43)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(105, 21)
        Me.cboStatus.TabIndex = 9
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(468, 47)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusID.TabIndex = 128
        Me.lblStatusID.Text = "Status"
        '
        'dtpSCDate
        '
        Me.dtpSCDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpSCDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSCDate.Location = New System.Drawing.Point(145, 70)
        Me.dtpSCDate.Name = "dtpSCDate"
        Me.dtpSCDate.Size = New System.Drawing.Size(105, 21)
        Me.dtpSCDate.TabIndex = 4
        Me.dtpSCDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
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
        Me.btnBP.Location = New System.Drawing.Point(400, 42)
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
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Pelanggan"
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
        'tpAmount
        '
        Me.tpAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpAmount.Controls.Add(Me.gboCompanyBankAccount)
        Me.tpAmount.Controls.Add(Me.gboPesanan)
        Me.tpAmount.Controls.Add(Me.Label7)
        Me.tpAmount.Controls.Add(Me.Label8)
        Me.tpAmount.Controls.Add(Me.txtPPH)
        Me.tpAmount.Controls.Add(Me.Label6)
        Me.tpAmount.Controls.Add(Me.Label11)
        Me.tpAmount.Controls.Add(Me.txtPPN)
        Me.tpAmount.Location = New System.Drawing.Point(4, 25)
        Me.tpAmount.Name = "tpAmount"
        Me.tpAmount.Size = New System.Drawing.Size(917, 170)
        Me.tpAmount.TabIndex = 2
        Me.tpAmount.Text = "Harga - F2"
        Me.tpAmount.UseVisualStyleBackColor = True
        '
        'gboCompanyBankAccount
        '
        Me.gboCompanyBankAccount.Controls.Add(Me.txtCurrencyBank)
        Me.gboCompanyBankAccount.Controls.Add(Me.Label27)
        Me.gboCompanyBankAccount.Controls.Add(Me.Label26)
        Me.gboCompanyBankAccount.Controls.Add(Me.Label25)
        Me.gboCompanyBankAccount.Controls.Add(Me.Label24)
        Me.gboCompanyBankAccount.Controls.Add(Me.txtBankName)
        Me.gboCompanyBankAccount.Controls.Add(Me.txtAccountNumber)
        Me.gboCompanyBankAccount.Controls.Add(Me.txtAccountName)
        Me.gboCompanyBankAccount.Controls.Add(Me.btnCompanyBankAccount)
        Me.gboCompanyBankAccount.Location = New System.Drawing.Point(508, 17)
        Me.gboCompanyBankAccount.Name = "gboCompanyBankAccount"
        Me.gboCompanyBankAccount.Size = New System.Drawing.Size(388, 139)
        Me.gboCompanyBankAccount.TabIndex = 3
        Me.gboCompanyBankAccount.TabStop = False
        Me.gboCompanyBankAccount.Text = "Akun Bank Perusahaan"
        '
        'txtCurrencyBank
        '
        Me.txtCurrencyBank.BackColor = System.Drawing.Color.Azure
        Me.txtCurrencyBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrencyBank.Location = New System.Drawing.Point(98, 107)
        Me.txtCurrencyBank.MaxLength = 250
        Me.txtCurrencyBank.Name = "txtCurrencyBank"
        Me.txtCurrencyBank.ReadOnly = True
        Me.txtCurrencyBank.Size = New System.Drawing.Size(198, 21)
        Me.txtCurrencyBank.TabIndex = 4
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(21, 111)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(59, 13)
        Me.Label27.TabIndex = 156
        Me.Label27.Text = "Mata Uang"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(21, 84)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(71, 13)
        Me.Label26.TabIndex = 155
        Me.Label26.Text = "No. Rekening"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(21, 57)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 13)
        Me.Label25.TabIndex = 154
        Me.Label25.Text = "Nama Bank"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(21, 30)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 153
        Me.Label24.Text = "Nama Akun"
        '
        'txtBankName
        '
        Me.txtBankName.BackColor = System.Drawing.Color.Azure
        Me.txtBankName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBankName.Location = New System.Drawing.Point(98, 53)
        Me.txtBankName.MaxLength = 250
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.ReadOnly = True
        Me.txtBankName.Size = New System.Drawing.Size(275, 21)
        Me.txtBankName.TabIndex = 2
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.BackColor = System.Drawing.Color.Azure
        Me.txtAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountNumber.Location = New System.Drawing.Point(98, 80)
        Me.txtAccountNumber.MaxLength = 250
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.ReadOnly = True
        Me.txtAccountNumber.Size = New System.Drawing.Size(275, 21)
        Me.txtAccountNumber.TabIndex = 3
        '
        'txtAccountName
        '
        Me.txtAccountName.BackColor = System.Drawing.Color.Azure
        Me.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountName.Location = New System.Drawing.Point(98, 26)
        Me.txtAccountName.MaxLength = 250
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.ReadOnly = True
        Me.txtAccountName.Size = New System.Drawing.Size(198, 21)
        Me.txtAccountName.TabIndex = 0
        '
        'btnCompanyBankAccount
        '
        Me.btnCompanyBankAccount.Image = CType(resources.GetObject("btnCompanyBankAccount.Image"), System.Drawing.Image)
        Me.btnCompanyBankAccount.Location = New System.Drawing.Point(302, 25)
        Me.btnCompanyBankAccount.Name = "btnCompanyBankAccount"
        Me.btnCompanyBankAccount.Size = New System.Drawing.Size(23, 23)
        Me.btnCompanyBankAccount.TabIndex = 1
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
        Me.gboPesanan.Location = New System.Drawing.Point(32, 17)
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
        Me.Label7.Location = New System.Drawing.Point(472, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 117
        Me.Label7.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(392, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "PPh"
        '
        'txtPPH
        '
        Me.txtPPH.DecimalPlaces = 2
        Me.txtPPH.Location = New System.Drawing.Point(392, 94)
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
        Me.Label6.Location = New System.Drawing.Point(472, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(392, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "PPN"
        '
        'txtPPN
        '
        Me.txtPPN.DecimalPlaces = 2
        Me.txtPPN.Location = New System.Drawing.Point(392, 40)
        Me.txtPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPPN.Name = "txtPPN"
        Me.txtPPN.Size = New System.Drawing.Size(77, 21)
        Me.txtPPN.TabIndex = 1
        Me.txtPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPPN.ThousandsSeparator = True
        '
        'tpPaymentTerm
        '
        Me.tpPaymentTerm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpPaymentTerm.Controls.Add(Me.grdPaymentTerm)
        Me.tpPaymentTerm.Controls.Add(Me.ToolBarPaymentTerm)
        Me.tpPaymentTerm.Location = New System.Drawing.Point(4, 25)
        Me.tpPaymentTerm.Name = "tpPaymentTerm"
        Me.tpPaymentTerm.Size = New System.Drawing.Size(917, 170)
        Me.tpPaymentTerm.TabIndex = 3
        Me.tpPaymentTerm.Text = "Syarat Pembayaran - F3"
        Me.tpPaymentTerm.UseVisualStyleBackColor = True
        '
        'grdPaymentTerm
        '
        Me.grdPaymentTerm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdPaymentTerm.Location = New System.Drawing.Point(0, 28)
        Me.grdPaymentTerm.MainView = Me.grdPaymentTermView
        Me.grdPaymentTerm.Name = "grdPaymentTerm"
        Me.grdPaymentTerm.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2})
        Me.grdPaymentTerm.Size = New System.Drawing.Size(913, 138)
        Me.grdPaymentTerm.TabIndex = 2
        Me.grdPaymentTerm.UseEmbeddedNavigator = True
        Me.grdPaymentTerm.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdPaymentTermView})
        '
        'grdPaymentTermView
        '
        Me.grdPaymentTermView.GridControl = Me.grdPaymentTerm
        Me.grdPaymentTermView.Name = "grdPaymentTermView"
        Me.grdPaymentTermView.OptionsCustomization.AllowColumnMoving = False
        Me.grdPaymentTermView.OptionsCustomization.AllowGroup = False
        Me.grdPaymentTermView.OptionsView.ColumnAutoWidth = False
        Me.grdPaymentTermView.OptionsView.ShowFooter = True
        Me.grdPaymentTermView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "0.00"
        '
        'ToolBarPaymentTerm
        '
        Me.ToolBarPaymentTerm.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarPaymentTerm.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddPayment, Me.BarEditPayment, Me.BarDeletePayment})
        Me.ToolBarPaymentTerm.DropDownArrows = True
        Me.ToolBarPaymentTerm.Location = New System.Drawing.Point(0, 0)
        Me.ToolBarPaymentTerm.Name = "ToolBarPaymentTerm"
        Me.ToolBarPaymentTerm.ShowToolTips = True
        Me.ToolBarPaymentTerm.Size = New System.Drawing.Size(913, 28)
        Me.ToolBarPaymentTerm.TabIndex = 1
        Me.ToolBarPaymentTerm.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAddPayment
        '
        Me.BarAddPayment.Name = "BarAddPayment"
        Me.BarAddPayment.Tag = "Add"
        Me.BarAddPayment.Text = "Tambah"
        '
        'BarEditPayment
        '
        Me.BarEditPayment.Name = "BarEditPayment"
        Me.BarEditPayment.Tag = "Edit"
        Me.BarEditPayment.Text = "Edit"
        '
        'BarDeletePayment
        '
        Me.BarDeletePayment.Name = "BarDeletePayment"
        Me.BarDeletePayment.Tag = "Delete"
        Me.BarDeletePayment.Text = "Hapus"
        '
        'tpAdditionalInformation
        '
        Me.tpAdditionalInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpAdditionalInformation.Controls.Add(Me.DelegationSeller)
        Me.tpAdditionalInformation.Controls.Add(Me.gboDelegationBuyer)
        Me.tpAdditionalInformation.Location = New System.Drawing.Point(4, 25)
        Me.tpAdditionalInformation.Name = "tpAdditionalInformation"
        Me.tpAdditionalInformation.Size = New System.Drawing.Size(917, 197)
        Me.tpAdditionalInformation.TabIndex = 4
        Me.tpAdditionalInformation.Text = "Informasi Tambahan - F4"
        Me.tpAdditionalInformation.UseVisualStyleBackColor = True
        '
        'DelegationSeller
        '
        Me.DelegationSeller.Controls.Add(Me.txtDelegationPositionSeller)
        Me.DelegationSeller.Controls.Add(Me.Label14)
        Me.DelegationSeller.Controls.Add(Me.txtDelegationSeller)
        Me.DelegationSeller.Controls.Add(Me.Label22)
        Me.DelegationSeller.Location = New System.Drawing.Point(317, 16)
        Me.DelegationSeller.Name = "DelegationSeller"
        Me.DelegationSeller.Size = New System.Drawing.Size(288, 102)
        Me.DelegationSeller.TabIndex = 1
        Me.DelegationSeller.TabStop = False
        Me.DelegationSeller.Text = "Pihak Penjual"
        '
        'txtDelegationPositionSeller
        '
        Me.txtDelegationPositionSeller.BackColor = System.Drawing.Color.White
        Me.txtDelegationPositionSeller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelegationPositionSeller.Location = New System.Drawing.Point(73, 55)
        Me.txtDelegationPositionSeller.MaxLength = 250
        Me.txtDelegationPositionSeller.Name = "txtDelegationPositionSeller"
        Me.txtDelegationPositionSeller.Size = New System.Drawing.Size(194, 21)
        Me.txtDelegationPositionSeller.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(19, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 136
        Me.Label14.Text = "Posisi"
        '
        'txtDelegationSeller
        '
        Me.txtDelegationSeller.BackColor = System.Drawing.Color.White
        Me.txtDelegationSeller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelegationSeller.Location = New System.Drawing.Point(73, 28)
        Me.txtDelegationSeller.MaxLength = 250
        Me.txtDelegationSeller.Name = "txtDelegationSeller"
        Me.txtDelegationSeller.Size = New System.Drawing.Size(194, 21)
        Me.txtDelegationSeller.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(19, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 134
        Me.Label22.Text = "Nama"
        '
        'gboDelegationBuyer
        '
        Me.gboDelegationBuyer.Controls.Add(Me.txtDelegationPositionBuyer)
        Me.gboDelegationBuyer.Controls.Add(Me.Label12)
        Me.gboDelegationBuyer.Controls.Add(Me.txtDelegationBuyer)
        Me.gboDelegationBuyer.Controls.Add(Me.Label10)
        Me.gboDelegationBuyer.Location = New System.Drawing.Point(17, 16)
        Me.gboDelegationBuyer.Name = "gboDelegationBuyer"
        Me.gboDelegationBuyer.Size = New System.Drawing.Size(288, 102)
        Me.gboDelegationBuyer.TabIndex = 0
        Me.gboDelegationBuyer.TabStop = False
        Me.gboDelegationBuyer.Text = "Pihak Pembeli"
        '
        'txtDelegationPositionBuyer
        '
        Me.txtDelegationPositionBuyer.BackColor = System.Drawing.Color.White
        Me.txtDelegationPositionBuyer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelegationPositionBuyer.Location = New System.Drawing.Point(73, 55)
        Me.txtDelegationPositionBuyer.MaxLength = 250
        Me.txtDelegationPositionBuyer.Name = "txtDelegationPositionBuyer"
        Me.txtDelegationPositionBuyer.Size = New System.Drawing.Size(194, 21)
        Me.txtDelegationPositionBuyer.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 136
        Me.Label12.Text = "Posisi"
        '
        'txtDelegationBuyer
        '
        Me.txtDelegationBuyer.BackColor = System.Drawing.Color.White
        Me.txtDelegationBuyer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelegationBuyer.Location = New System.Drawing.Point(73, 27)
        Me.txtDelegationBuyer.MaxLength = 250
        Me.txtDelegationBuyer.Name = "txtDelegationBuyer"
        Me.txtDelegationBuyer.Size = New System.Drawing.Size(194, 21)
        Me.txtDelegationBuyer.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 134
        Me.Label10.Text = "Nama"
        '
        'tpHistory
        '
        Me.tpHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHistory.Size = New System.Drawing.Size(917, 197)
        Me.tpHistory.TabIndex = 1
        Me.tpHistory.Text = "History - F5"
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
        Me.grdStatus.Size = New System.Drawing.Size(907, 187)
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
        Me.Label1.Location = New System.Drawing.Point(0, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(925, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "« Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcDetail
        '
        Me.tcDetail.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcDetail.Controls.Add(Me.tpItem)
        Me.tcDetail.Controls.Add(Me.tpConfirmationOrder)
        Me.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcDetail.Location = New System.Drawing.Point(0, 271)
        Me.tcDetail.Name = "tcDetail"
        Me.tcDetail.SelectedIndex = 0
        Me.tcDetail.Size = New System.Drawing.Size(925, 367)
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
        Me.tpItem.Size = New System.Drawing.Size(917, 338)
        Me.tpItem.TabIndex = 1
        Me.tpItem.Text = "Item - F6"
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
        Me.grdItem.Size = New System.Drawing.Size(911, 282)
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
        Me.StatusStrip.Location = New System.Drawing.Point(3, 313)
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
        'tpConfirmationOrder
        '
        Me.tpConfirmationOrder.Controls.Add(Me.grdItemCO)
        Me.tpConfirmationOrder.Location = New System.Drawing.Point(4, 25)
        Me.tpConfirmationOrder.Name = "tpConfirmationOrder"
        Me.tpConfirmationOrder.Size = New System.Drawing.Size(917, 311)
        Me.tpConfirmationOrder.TabIndex = 2
        Me.tpConfirmationOrder.Text = "Konfirmasi Pesanan - F7"
        Me.tpConfirmationOrder.UseVisualStyleBackColor = True
        '
        'frmTraSalesContractDetVer1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 661)
        Me.Controls.Add(Me.tcDetail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraSalesContractDetVer1"
        Me.Text = "Kontrak Penjualan"
        CType(Me.grdSubItemCOView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemCOView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.dtpDeliveryPeriodTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDeliveryPeriodTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDeliveryPeriodFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDeliveryPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAllowanceProduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAmount.ResumeLayout(False)
        Me.tpAmount.PerformLayout()
        Me.gboCompanyBankAccount.ResumeLayout(False)
        Me.gboCompanyBankAccount.PerformLayout()
        Me.gboPesanan.ResumeLayout(False)
        Me.gboPesanan.PerformLayout()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDPP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPaymentTerm.ResumeLayout(False)
        Me.tpPaymentTerm.PerformLayout()
        CType(Me.grdPaymentTerm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPaymentTermView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAdditionalInformation.ResumeLayout(False)
        Me.DelegationSeller.ResumeLayout(False)
        Me.DelegationSeller.PerformLayout()
        Me.gboDelegationBuyer.ResumeLayout(False)
        Me.gboDelegationBuyer.PerformLayout()
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
        Me.tpConfirmationOrder.ResumeLayout(False)
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
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAllowanceProduction As usNumeric
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtFranco As usTextBox
    Friend WithEvents txtRemarks As usTextBox
    Friend WithEvents txtBPCode As usTextBox
    Friend WithEvents txtBPName As usTextBox
    Friend WithEvents txtSCNumber As usTextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboStatus As usComboBox
    Friend WithEvents lblStatusID As Label
    Friend WithEvents dtpSCDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tpAmount As TabPage
    Friend WithEvents gboCompanyBankAccount As GroupBox
    Friend WithEvents txtCurrencyBank As usTextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtBankName As usTextBox
    Friend WithEvents txtAccountNumber As usTextBox
    Friend WithEvents txtAccountName As usTextBox
    Friend WithEvents btnCompanyBankAccount As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents tpPaymentTerm As TabPage
    Friend WithEvents grdPaymentTerm As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdPaymentTermView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ToolBarPaymentTerm As usToolBar
    Friend WithEvents BarAddPayment As ToolBarButton
    Friend WithEvents BarEditPayment As ToolBarButton
    Friend WithEvents BarDeletePayment As ToolBarButton
    Friend WithEvents tpAdditionalInformation As TabPage
    Friend WithEvents DelegationSeller As GroupBox
    Friend WithEvents txtDelegationPositionSeller As usTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtDelegationSeller As usTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents gboDelegationBuyer As GroupBox
    Friend WithEvents txtDelegationPositionBuyer As usTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtDelegationBuyer As usTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tpHistory As TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents tcDetail As TabControl
    Friend WithEvents tpItem As TabPage
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripEmpty As ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As ToolStripStatusLabel
    Friend WithEvents ToolBarItem As usToolBar
    Friend WithEvents BarAddItemOrder As ToolBarButton
    Friend WithEvents BarDetailItemOrder As ToolBarButton
    Friend WithEvents BarDeleteItemOrder As ToolBarButton
    Friend WithEvents tpConfirmationOrder As TabPage
    Friend WithEvents grdItemCO As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdSubItemCOView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdItemCOView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents dtpDeliveryPeriodTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtpDeliveryPeriodFrom As DevExpress.XtraEditors.DateEdit
End Class
