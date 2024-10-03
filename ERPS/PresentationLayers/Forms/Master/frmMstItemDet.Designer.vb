<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstItemDet
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
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtItemCodeExternal = New ERPS.usTextBox()
        Me.txtLength = New ERPS.usNumeric()
        Me.txtWidth = New ERPS.usNumeric()
        Me.txtThick = New ERPS.usNumeric()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBasePrice = New ERPS.usNumeric()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtWeight = New ERPS.usNumeric()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboItemSpecification = New ERPS.usComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboItemType = New ERPS.usComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemCode = New ERPS.usTextBox()
        Me.cboStatus = New ERPS.usComboBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtItemName = New ERPS.usTextBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLengthInitial = New ERPS.usTextBox()
        Me.cboUom = New ERPS.usComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.StatusStrip.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBasePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 362)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(624, 22)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(501, 17)
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
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(624, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Barang Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.cboUom)
        Me.pnlDetail.Controls.Add(Me.Label17)
        Me.pnlDetail.Controls.Add(Me.Label16)
        Me.pnlDetail.Controls.Add(Me.txtLengthInitial)
        Me.pnlDetail.Controls.Add(Me.Label15)
        Me.pnlDetail.Controls.Add(Me.txtItemCodeExternal)
        Me.pnlDetail.Controls.Add(Me.txtLength)
        Me.pnlDetail.Controls.Add(Me.txtWidth)
        Me.pnlDetail.Controls.Add(Me.txtThick)
        Me.pnlDetail.Controls.Add(Me.Label14)
        Me.pnlDetail.Controls.Add(Me.Label13)
        Me.pnlDetail.Controls.Add(Me.txtRemarks)
        Me.pnlDetail.Controls.Add(Me.Label12)
        Me.pnlDetail.Controls.Add(Me.Label11)
        Me.pnlDetail.Controls.Add(Me.txtBasePrice)
        Me.pnlDetail.Controls.Add(Me.Label10)
        Me.pnlDetail.Controls.Add(Me.Label9)
        Me.pnlDetail.Controls.Add(Me.Label8)
        Me.pnlDetail.Controls.Add(Me.Label7)
        Me.pnlDetail.Controls.Add(Me.txtWeight)
        Me.pnlDetail.Controls.Add(Me.Label6)
        Me.pnlDetail.Controls.Add(Me.Label5)
        Me.pnlDetail.Controls.Add(Me.Label4)
        Me.pnlDetail.Controls.Add(Me.cboItemSpecification)
        Me.pnlDetail.Controls.Add(Me.Label3)
        Me.pnlDetail.Controls.Add(Me.cboItemType)
        Me.pnlDetail.Controls.Add(Me.Label2)
        Me.pnlDetail.Controls.Add(Me.Label1)
        Me.pnlDetail.Controls.Add(Me.txtItemCode)
        Me.pnlDetail.Controls.Add(Me.cboStatus)
        Me.pnlDetail.Controls.Add(Me.lblName)
        Me.pnlDetail.Controls.Add(Me.txtItemName)
        Me.pnlDetail.Controls.Add(Me.lblStatusID)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(0, 50)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(624, 312)
        Me.pnlDetail.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(22, 259)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(115, 13)
        Me.Label15.TabIndex = 118
        Me.Label15.Text = "Kode Barang Eksternal"
        '
        'txtItemCodeExternal
        '
        Me.txtItemCodeExternal.BackColor = System.Drawing.Color.White
        Me.txtItemCodeExternal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCodeExternal.Location = New System.Drawing.Point(147, 255)
        Me.txtItemCodeExternal.MaxLength = 250
        Me.txtItemCodeExternal.Name = "txtItemCodeExternal"
        Me.txtItemCodeExternal.Size = New System.Drawing.Size(135, 21)
        Me.txtItemCodeExternal.TabIndex = 8
        '
        'txtLength
        '
        Me.txtLength.DecimalPlaces = 2
        Me.txtLength.Location = New System.Drawing.Point(147, 147)
        Me.txtLength.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLength.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(135, 21)
        Me.txtLength.TabIndex = 5
        Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLength.ThousandsSeparator = True
        '
        'txtWidth
        '
        Me.txtWidth.DecimalPlaces = 2
        Me.txtWidth.Location = New System.Drawing.Point(147, 120)
        Me.txtWidth.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidth.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(135, 21)
        Me.txtWidth.TabIndex = 4
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidth.ThousandsSeparator = True
        '
        'txtThick
        '
        Me.txtThick.DecimalPlaces = 2
        Me.txtThick.Location = New System.Drawing.Point(147, 93)
        Me.txtThick.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThick.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThick.Name = "txtThick"
        Me.txtThick.Size = New System.Drawing.Size(135, 21)
        Me.txtThick.TabIndex = 3
        Me.txtThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThick.ThousandsSeparator = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(577, 124)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 13)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "Kg"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(22, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "Keterangan"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(147, 201)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(423, 48)
        Me.txtRemarks.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(288, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 13)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "Kg"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(346, 124)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Harga"
        '
        'txtBasePrice
        '
        Me.txtBasePrice.DecimalPlaces = 2
        Me.txtBasePrice.Location = New System.Drawing.Point(435, 120)
        Me.txtBasePrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtBasePrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtBasePrice.Name = "txtBasePrice"
        Me.txtBasePrice.Size = New System.Drawing.Size(135, 21)
        Me.txtBasePrice.TabIndex = 10
        Me.txtBasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBasePrice.ThousandsSeparator = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(288, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "mm"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(288, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(288, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 108
        Me.Label8.Text = "mm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(22, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Berat"
        '
        'txtWeight
        '
        Me.txtWeight.DecimalPlaces = 4
        Me.txtWeight.Location = New System.Drawing.Point(147, 174)
        Me.txtWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(135, 21)
        Me.txtWeight.TabIndex = 6
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWeight.ThousandsSeparator = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(22, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Panjang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Lebar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(22, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Tebal"
        '
        'cboItemSpecification
        '
        Me.cboItemSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemSpecification.FormattingEnabled = True
        Me.cboItemSpecification.Location = New System.Drawing.Point(435, 93)
        Me.cboItemSpecification.Name = "cboItemSpecification"
        Me.cboItemSpecification.Size = New System.Drawing.Size(135, 21)
        Me.cboItemSpecification.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(346, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Spec"
        '
        'cboItemType
        '
        Me.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemType.FormattingEnabled = True
        Me.cboItemType.Location = New System.Drawing.Point(435, 12)
        Me.cboItemType.Name = "cboItemType"
        Me.cboItemType.Size = New System.Drawing.Size(135, 21)
        Me.cboItemType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(346, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Jenis"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(22, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Kode Barang"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.White
        Me.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCode.Location = New System.Drawing.Point(147, 12)
        Me.txtItemCode.MaxLength = 250
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(135, 21)
        Me.txtItemCode.TabIndex = 0
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(435, 147)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(135, 21)
        Me.cboStatus.TabIndex = 11
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(22, 42)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(71, 13)
        Me.lblName.TabIndex = 93
        Me.lblName.Text = "Nama Barang"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.White
        Me.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Location = New System.Drawing.Point(147, 39)
        Me.txtItemName.MaxLength = 250
        Me.txtItemName.Multiline = True
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(423, 48)
        Me.txtItemName.TabIndex = 2
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(346, 151)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusID.TabIndex = 93
        Me.lblStatusID.Text = "Status"
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(624, 28)
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(346, 259)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 120
        Me.Label16.Text = "Kode Panjang"
        '
        'txtLengthInitial
        '
        Me.txtLengthInitial.BackColor = System.Drawing.Color.White
        Me.txtLengthInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLengthInitial.Location = New System.Drawing.Point(435, 255)
        Me.txtLengthInitial.MaxLength = 250
        Me.txtLengthInitial.Name = "txtLengthInitial"
        Me.txtLengthInitial.Size = New System.Drawing.Size(135, 21)
        Me.txtLengthInitial.TabIndex = 13
        '
        'cboUom
        '
        Me.cboUom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUom.Enabled = False
        Me.cboUom.FormattingEnabled = True
        Me.cboUom.Location = New System.Drawing.Point(435, 174)
        Me.cboUom.Name = "cboUom"
        Me.cboUom.Size = New System.Drawing.Size(135, 21)
        Me.cboUom.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(346, 178)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 122
        Me.Label17.Text = "Satuan"
        '
        'frmMstItemDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 384)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMstItemDet"
        Me.Text = "Barang"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBasePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtItemName As ERPS.usTextBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As ERPS.usTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As ERPS.usTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBasePrice As ERPS.usNumeric
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As ERPS.usNumeric
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboItemSpecification As ERPS.usComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboItemType As ERPS.usComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLength As ERPS.usNumeric
    Friend WithEvents txtWidth As ERPS.usNumeric
    Friend WithEvents txtThick As ERPS.usNumeric
    Friend WithEvents Label15 As Label
    Friend WithEvents txtItemCodeExternal As usTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLengthInitial As ERPS.usTextBox
    Friend WithEvents cboUom As ERPS.usComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
