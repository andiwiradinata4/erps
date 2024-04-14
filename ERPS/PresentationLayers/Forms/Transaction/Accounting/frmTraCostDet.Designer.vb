<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraCostDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraCostDet))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.txtTotalAmount = New ERPS.usNumeric()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReferencesID = New ERPS.usTextBox()
        Me.txtCoACode = New ERPS.usTextBox()
        Me.btnCoA = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCoAName = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.cboStatus = New ERPS.usComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpCostDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCostNumber = New ERPS.usTextBox()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolBarDetail = New ERPS.usToolBar()
        Me.BarAdd = New System.Windows.Forms.ToolBarButton()
        Me.BarEdit = New System.Windows.Forms.ToolBarButton()
        Me.BarDelete = New System.Windows.Forms.ToolBarButton()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(859, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(859, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Pembayaran Biaya Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tcHeader.Size = New System.Drawing.Size(859, 172)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.txtTotalAmount)
        Me.tpMain.Controls.Add(Me.Label7)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.txtReferencesID)
        Me.tpMain.Controls.Add(Me.txtCoACode)
        Me.tpMain.Controls.Add(Me.btnCoA)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Controls.Add(Me.txtCoAName)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.Label5)
        Me.tpMain.Controls.Add(Me.dtpCostDate)
        Me.tpMain.Controls.Add(Me.Label6)
        Me.tpMain.Controls.Add(Me.Label8)
        Me.tpMain.Controls.Add(Me.txtCostNumber)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(851, 143)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalAmount.DecimalPlaces = 2
        Me.txtTotalAmount.Enabled = False
        Me.txtTotalAmount.Location = New System.Drawing.Point(132, 97)
        Me.txtTotalAmount.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalAmount.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(249, 21)
        Me.txtTotalAmount.TabIndex = 5
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "No. Referensi"
        '
        'txtReferencesID
        '
        Me.txtReferencesID.BackColor = System.Drawing.Color.White
        Me.txtReferencesID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencesID.Location = New System.Drawing.Point(132, 70)
        Me.txtReferencesID.MaxLength = 250
        Me.txtReferencesID.Name = "txtReferencesID"
        Me.txtReferencesID.Size = New System.Drawing.Size(249, 21)
        Me.txtReferencesID.TabIndex = 4
        '
        'txtCoACode
        '
        Me.txtCoACode.BackColor = System.Drawing.Color.Azure
        Me.txtCoACode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoACode.Location = New System.Drawing.Point(132, 43)
        Me.txtCoACode.MaxLength = 250
        Me.txtCoACode.Name = "txtCoACode"
        Me.txtCoACode.ReadOnly = True
        Me.txtCoACode.Size = New System.Drawing.Size(83, 21)
        Me.txtCoACode.TabIndex = 1
        '
        'btnCoA
        '
        Me.btnCoA.Image = CType(resources.GetObject("btnCoA.Image"), System.Drawing.Image)
        Me.btnCoA.Location = New System.Drawing.Point(387, 42)
        Me.btnCoA.Name = "btnCoA"
        Me.btnCoA.Size = New System.Drawing.Size(23, 23)
        Me.btnCoA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Dibayar Pakai Akun"
        '
        'txtCoAName
        '
        Me.txtCoAName.BackColor = System.Drawing.Color.Azure
        Me.txtCoAName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoAName.Location = New System.Drawing.Point(214, 43)
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
        Me.Label13.Location = New System.Drawing.Point(485, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(572, 70)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 8
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(572, 43)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(127, 21)
        Me.cboStatus.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(510, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Status"
        '
        'dtpCostDate
        '
        Me.dtpCostDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCostDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCostDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCostDate.Location = New System.Drawing.Point(572, 16)
        Me.dtpCostDate.Name = "dtpCostDate"
        Me.dtpCostDate.Size = New System.Drawing.Size(127, 21)
        Me.dtpCostDate.TabIndex = 6
        Me.dtpCostDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(503, 20)
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
        'txtCostNumber
        '
        Me.txtCostNumber.BackColor = System.Drawing.Color.White
        Me.txtCostNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCostNumber.Location = New System.Drawing.Point(132, 16)
        Me.txtCostNumber.MaxLength = 250
        Me.txtCostNumber.Name = "txtCostNumber"
        Me.txtCostNumber.Size = New System.Drawing.Size(167, 21)
        Me.txtCostNumber.TabIndex = 0
        '
        'tpHistory
        '
        Me.tpHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHistory.Size = New System.Drawing.Size(851, 143)
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
        Me.grdStatus.Size = New System.Drawing.Size(841, 133)
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
        Me.Label1.Location = New System.Drawing.Point(0, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(859, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "« Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 602)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(859, 23)
        Me.pgMain.TabIndex = 7
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 580)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(859, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(736, 17)
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
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAdd, Me.BarEdit, Me.BarDelete})
        Me.ToolBarDetail.DropDownArrows = True
        Me.ToolBarDetail.Location = New System.Drawing.Point(0, 244)
        Me.ToolBarDetail.Name = "ToolBarDetail"
        Me.ToolBarDetail.ShowToolTips = True
        Me.ToolBarDetail.Size = New System.Drawing.Size(859, 28)
        Me.ToolBarDetail.TabIndex = 4
        Me.ToolBarDetail.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAdd
        '
        Me.BarAdd.Name = "BarAdd"
        Me.BarAdd.Tag = "Add"
        Me.BarAdd.Text = "Tambah"
        '
        'BarEdit
        '
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.Tag = "Edit"
        Me.BarEdit.Text = "Edit"
        '
        'BarDelete
        '
        Me.BarDelete.Name = "BarDelete"
        Me.BarDelete.Tag = "Delete"
        Me.BarDelete.Text = "Hapus"
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
        Me.grdItem.Location = New System.Drawing.Point(0, 272)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItem.Size = New System.Drawing.Size(859, 308)
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
        'frmTraCostDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 625)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.ToolBarDetail)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraCostDet"
        Me.Text = "Pembayaran Biaya"
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tcHeader As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents txtTotalAmount As ERPS.usNumeric
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReferencesID As ERPS.usTextBox
    Friend WithEvents txtCoACode As ERPS.usTextBox
    Friend WithEvents btnCoA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCoAName As ERPS.usTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As ERPS.usTextBox
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpCostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCostNumber As ERPS.usTextBox
    Friend WithEvents tpHistory As System.Windows.Forms.TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolBarDetail As ERPS.usToolBar
    Friend WithEvents BarAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
