<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraPurchaseOrderCuttingDetItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraPurchaseOrderCuttingDetItem))
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPCNumber = New ERPS.usTextBox()
        Me.btnPC = New DevExpress.XtraEditors.SimpleButton()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTotalPrice = New ERPS.usNumeric()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtQuantity = New ERPS.usNumeric()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New ERPS.usNumeric()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalWeight = New ERPS.usNumeric()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboItemSpecification = New ERPS.usComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboItemType = New ERPS.usComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtItemCode = New ERPS.usTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtItemName = New ERPS.usTextBox()
        Me.txtLength = New ERPS.usNumeric()
        Me.txtWidth = New ERPS.usNumeric()
        Me.txtThick = New ERPS.usNumeric()
        Me.txtMaxTotalWeight = New ERPS.usNumeric()
        Me.txtWeight = New ERPS.usNumeric()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.pnlDetail.SuspendLayout()
        CType(Me.txtTotalPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxTotalWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(693, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Barang"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.Label4)
        Me.pnlDetail.Controls.Add(Me.txtPCNumber)
        Me.pnlDetail.Controls.Add(Me.btnPC)
        Me.pnlDetail.Controls.Add(Me.Label26)
        Me.pnlDetail.Controls.Add(Me.Label27)
        Me.pnlDetail.Controls.Add(Me.Label24)
        Me.pnlDetail.Controls.Add(Me.Label25)
        Me.pnlDetail.Controls.Add(Me.txtTotalPrice)
        Me.pnlDetail.Controls.Add(Me.Label23)
        Me.pnlDetail.Controls.Add(Me.txtQuantity)
        Me.pnlDetail.Controls.Add(Me.Label17)
        Me.pnlDetail.Controls.Add(Me.Label14)
        Me.pnlDetail.Controls.Add(Me.txtUnitPrice)
        Me.pnlDetail.Controls.Add(Me.Label15)
        Me.pnlDetail.Controls.Add(Me.Label16)
        Me.pnlDetail.Controls.Add(Me.txtTotalWeight)
        Me.pnlDetail.Controls.Add(Me.Label13)
        Me.pnlDetail.Controls.Add(Me.txtRemarks)
        Me.pnlDetail.Controls.Add(Me.Label12)
        Me.pnlDetail.Controls.Add(Me.Label10)
        Me.pnlDetail.Controls.Add(Me.Label9)
        Me.pnlDetail.Controls.Add(Me.Label8)
        Me.pnlDetail.Controls.Add(Me.Label7)
        Me.pnlDetail.Controls.Add(Me.Label6)
        Me.pnlDetail.Controls.Add(Me.Label1)
        Me.pnlDetail.Controls.Add(Me.Label2)
        Me.pnlDetail.Controls.Add(Me.cboItemSpecification)
        Me.pnlDetail.Controls.Add(Me.Label3)
        Me.pnlDetail.Controls.Add(Me.cboItemType)
        Me.pnlDetail.Controls.Add(Me.Label28)
        Me.pnlDetail.Controls.Add(Me.Label29)
        Me.pnlDetail.Controls.Add(Me.txtItemCode)
        Me.pnlDetail.Controls.Add(Me.lblName)
        Me.pnlDetail.Controls.Add(Me.txtItemName)
        Me.pnlDetail.Controls.Add(Me.txtLength)
        Me.pnlDetail.Controls.Add(Me.txtWidth)
        Me.pnlDetail.Controls.Add(Me.txtThick)
        Me.pnlDetail.Controls.Add(Me.txtMaxTotalWeight)
        Me.pnlDetail.Controls.Add(Me.txtWeight)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(0, 50)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(693, 345)
        Me.pnlDetail.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(31, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 189
        Me.Label4.Text = "Nomor Kontrak"
        '
        'txtPCNumber
        '
        Me.txtPCNumber.BackColor = System.Drawing.Color.Azure
        Me.txtPCNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPCNumber.Location = New System.Drawing.Point(166, 13)
        Me.txtPCNumber.MaxLength = 250
        Me.txtPCNumber.Name = "txtPCNumber"
        Me.txtPCNumber.ReadOnly = True
        Me.txtPCNumber.Size = New System.Drawing.Size(170, 21)
        Me.txtPCNumber.TabIndex = 0
        '
        'btnPC
        '
        Me.btnPC.Image = CType(resources.GetObject("btnPC.Image"), System.Drawing.Image)
        Me.btnPC.Location = New System.Drawing.Point(341, 12)
        Me.btnPC.Name = "btnPC"
        Me.btnPC.Size = New System.Drawing.Size(23, 23)
        Me.btnPC.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(341, 236)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 13)
        Me.Label26.TabIndex = 184
        Me.Label26.Text = "Kg"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(31, 236)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 13)
        Me.Label27.TabIndex = 183
        Me.Label27.Text = "Maks. Total Berat"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(641, 208)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(19, 13)
        Me.Label24.TabIndex = 182
        Me.Label24.Text = "Kg"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(398, 208)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 181
        Me.Label25.Text = "Total Harga"
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.BackColor = System.Drawing.Color.Azure
        Me.txtTotalPrice.DecimalPlaces = 2
        Me.txtTotalPrice.Enabled = False
        Me.txtTotalPrice.Location = New System.Drawing.Point(477, 204)
        Me.txtTotalPrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.Size = New System.Drawing.Size(160, 21)
        Me.txtTotalPrice.TabIndex = 14
        Me.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPrice.ThousandsSeparator = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(421, 154)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 180
        Me.Label23.Text = "Jumlah"
        '
        'txtQuantity
        '
        Me.txtQuantity.DecimalPlaces = 2
        Me.txtQuantity.Location = New System.Drawing.Point(477, 150)
        Me.txtQuantity.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtQuantity.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(160, 21)
        Me.txtQuantity.TabIndex = 12
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQuantity.ThousandsSeparator = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(643, 127)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 13)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Kg"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(425, 127)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 173
        Me.Label14.Text = "Harga"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.Color.White
        Me.txtUnitPrice.DecimalPlaces = 2
        Me.txtUnitPrice.Location = New System.Drawing.Point(477, 123)
        Me.txtUnitPrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(160, 21)
        Me.txtUnitPrice.TabIndex = 11
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPrice.ThousandsSeparator = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(641, 181)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 13)
        Me.Label15.TabIndex = 172
        Me.Label15.Text = "Kg"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(401, 181)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 171
        Me.Label16.Text = "Total Berat"
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BackColor = System.Drawing.Color.Azure
        Me.txtTotalWeight.DecimalPlaces = 2
        Me.txtTotalWeight.Enabled = False
        Me.txtTotalWeight.Location = New System.Drawing.Point(477, 177)
        Me.txtTotalWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.Size = New System.Drawing.Size(160, 21)
        Me.txtTotalWeight.TabIndex = 13
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalWeight.ThousandsSeparator = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(31, 262)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 170
        Me.Label13.Text = "Keterangan"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(166, 259)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(471, 48)
        Me.txtRemarks.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(341, 209)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 13)
        Me.Label12.TabIndex = 169
        Me.Label12.Text = "Kg"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(341, 181)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 167
        Me.Label10.Text = "mm"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(341, 154)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(341, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "mm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(31, 209)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 164
        Me.Label7.Text = "Berat"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(31, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Panjang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(31, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Lebar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Tebal"
        '
        'cboItemSpecification
        '
        Me.cboItemSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemSpecification.Enabled = False
        Me.cboItemSpecification.FormattingEnabled = True
        Me.cboItemSpecification.Location = New System.Drawing.Point(477, 41)
        Me.cboItemSpecification.Name = "cboItemSpecification"
        Me.cboItemSpecification.Size = New System.Drawing.Size(160, 21)
        Me.cboItemSpecification.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(431, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 160
        Me.Label3.Text = "Spec"
        '
        'cboItemType
        '
        Me.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemType.Enabled = False
        Me.cboItemType.FormattingEnabled = True
        Me.cboItemType.Location = New System.Drawing.Point(477, 14)
        Me.cboItemType.Name = "cboItemType"
        Me.cboItemType.Size = New System.Drawing.Size(160, 21)
        Me.cboItemType.TabIndex = 3
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(430, 18)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 13)
        Me.Label28.TabIndex = 159
        Me.Label28.Text = "Jenis"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(31, 44)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(68, 13)
        Me.Label29.TabIndex = 158
        Me.Label29.Text = "Kode Barang"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.Azure
        Me.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCode.Location = New System.Drawing.Point(166, 40)
        Me.txtItemCode.MaxLength = 250
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.ReadOnly = True
        Me.txtItemCode.Size = New System.Drawing.Size(170, 21)
        Me.txtItemCode.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(31, 72)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(71, 13)
        Me.lblName.TabIndex = 157
        Me.lblName.Text = "Nama Barang"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.Azure
        Me.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Location = New System.Drawing.Point(166, 69)
        Me.txtItemName.MaxLength = 250
        Me.txtItemName.Multiline = True
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(471, 48)
        Me.txtItemName.TabIndex = 5
        '
        'txtLength
        '
        Me.txtLength.BackColor = System.Drawing.Color.Azure
        Me.txtLength.DecimalPlaces = 2
        Me.txtLength.Enabled = False
        Me.txtLength.Location = New System.Drawing.Point(166, 177)
        Me.txtLength.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLength.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(170, 21)
        Me.txtLength.TabIndex = 8
        Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLength.ThousandsSeparator = True
        '
        'txtWidth
        '
        Me.txtWidth.BackColor = System.Drawing.Color.Azure
        Me.txtWidth.DecimalPlaces = 2
        Me.txtWidth.Enabled = False
        Me.txtWidth.Location = New System.Drawing.Point(166, 150)
        Me.txtWidth.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidth.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(170, 21)
        Me.txtWidth.TabIndex = 7
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidth.ThousandsSeparator = True
        '
        'txtThick
        '
        Me.txtThick.BackColor = System.Drawing.Color.Azure
        Me.txtThick.DecimalPlaces = 2
        Me.txtThick.Enabled = False
        Me.txtThick.Location = New System.Drawing.Point(166, 123)
        Me.txtThick.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThick.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThick.Name = "txtThick"
        Me.txtThick.Size = New System.Drawing.Size(170, 21)
        Me.txtThick.TabIndex = 6
        Me.txtThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThick.ThousandsSeparator = True
        '
        'txtMaxTotalWeight
        '
        Me.txtMaxTotalWeight.BackColor = System.Drawing.Color.Azure
        Me.txtMaxTotalWeight.DecimalPlaces = 2
        Me.txtMaxTotalWeight.Enabled = False
        Me.txtMaxTotalWeight.Location = New System.Drawing.Point(166, 232)
        Me.txtMaxTotalWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtMaxTotalWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtMaxTotalWeight.Name = "txtMaxTotalWeight"
        Me.txtMaxTotalWeight.Size = New System.Drawing.Size(170, 21)
        Me.txtMaxTotalWeight.TabIndex = 10
        Me.txtMaxTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxTotalWeight.ThousandsSeparator = True
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.Color.White
        Me.txtWeight.DecimalPlaces = 4
        Me.txtWeight.Location = New System.Drawing.Point(166, 205)
        Me.txtWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(170, 21)
        Me.txtWeight.TabIndex = 9
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWeight.ThousandsSeparator = True
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(693, 28)
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
        'frmTraPurchaseOrderCuttingDetItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 395)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraPurchaseOrderCuttingDetItem"
        Me.Text = "Barang"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.txtTotalPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxTotalWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPCNumber As ERPS.usTextBox
    Friend WithEvents btnPC As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As ERPS.usNumeric
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As ERPS.usNumeric
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As ERPS.usNumeric
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As ERPS.usNumeric
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As ERPS.usTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboItemSpecification As ERPS.usComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboItemType As ERPS.usComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As ERPS.usTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtItemName As ERPS.usTextBox
    Friend WithEvents txtLength As ERPS.usNumeric
    Friend WithEvents txtWidth As ERPS.usNumeric
    Friend WithEvents txtThick As ERPS.usNumeric
    Friend WithEvents txtMaxTotalWeight As ERPS.usNumeric
    Friend WithEvents txtWeight As ERPS.usNumeric
End Class
