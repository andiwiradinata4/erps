<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstCompanyDet
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
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.cboStatus = New ERPS.usComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New ERPS.usTextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New ERPS.usTextBox()
        Me.lblPhoneNumber = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New ERPS.usTextBox()
        Me.lblCompanyInitial = New System.Windows.Forms.Label()
        Me.txtCompanyInitial = New ERPS.usTextBox()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCountry = New ERPS.usTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProvince = New ERPS.usTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCity = New ERPS.usTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtWarehouse = New ERPS.usTextBox()
        Me.StatusStrip.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 467)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(484, 22)
        Me.StatusStrip.TabIndex = 0
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(361, 17)
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
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.Label4)
        Me.pnlDetail.Controls.Add(Me.txtWarehouse)
        Me.pnlDetail.Controls.Add(Me.Label3)
        Me.pnlDetail.Controls.Add(Me.txtCity)
        Me.pnlDetail.Controls.Add(Me.Label2)
        Me.pnlDetail.Controls.Add(Me.txtProvince)
        Me.pnlDetail.Controls.Add(Me.Label1)
        Me.pnlDetail.Controls.Add(Me.txtCountry)
        Me.pnlDetail.Controls.Add(Me.cboStatus)
        Me.pnlDetail.Controls.Add(Me.lblStatusID)
        Me.pnlDetail.Controls.Add(Me.lblName)
        Me.pnlDetail.Controls.Add(Me.txtName)
        Me.pnlDetail.Controls.Add(Me.lblAddress)
        Me.pnlDetail.Controls.Add(Me.txtAddress)
        Me.pnlDetail.Controls.Add(Me.lblPhoneNumber)
        Me.pnlDetail.Controls.Add(Me.txtPhoneNumber)
        Me.pnlDetail.Controls.Add(Me.lblCompanyInitial)
        Me.pnlDetail.Controls.Add(Me.txtCompanyInitial)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(0, 50)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(484, 417)
        Me.pnlDetail.TabIndex = 2
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(129, 355)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(160, 21)
        Me.cboStatus.TabIndex = 8
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(22, 358)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusID.TabIndex = 95
        Me.lblStatusID.Text = "Status"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(22, 18)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(34, 13)
        Me.lblName.TabIndex = 93
        Me.lblName.Text = "Nama"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Location = New System.Drawing.Point(129, 15)
        Me.txtName.MaxLength = 250
        Me.txtName.Multiline = True
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(300, 60)
        Me.txtName.TabIndex = 0
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(22, 88)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(40, 13)
        Me.lblAddress.TabIndex = 93
        Me.lblAddress.Text = "Alamat"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress.Location = New System.Drawing.Point(129, 85)
        Me.txtAddress.MaxLength = 250
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(300, 60)
        Me.txtAddress.TabIndex = 1
        '
        'lblPhoneNumber
        '
        Me.lblPhoneNumber.AutoSize = True
        Me.lblPhoneNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblPhoneNumber.ForeColor = System.Drawing.Color.Black
        Me.lblPhoneNumber.Location = New System.Drawing.Point(22, 301)
        Me.lblPhoneNumber.Name = "lblPhoneNumber"
        Me.lblPhoneNumber.Size = New System.Drawing.Size(79, 13)
        Me.lblPhoneNumber.TabIndex = 93
        Me.lblPhoneNumber.Text = "Nomor Telepon"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.BackColor = System.Drawing.Color.White
        Me.txtPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhoneNumber.Location = New System.Drawing.Point(129, 298)
        Me.txtPhoneNumber.MaxLength = 250
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(300, 21)
        Me.txtPhoneNumber.TabIndex = 6
        '
        'lblCompanyInitial
        '
        Me.lblCompanyInitial.AutoSize = True
        Me.lblCompanyInitial.BackColor = System.Drawing.Color.Transparent
        Me.lblCompanyInitial.ForeColor = System.Drawing.Color.Black
        Me.lblCompanyInitial.Location = New System.Drawing.Point(22, 328)
        Me.lblCompanyInitial.Name = "lblCompanyInitial"
        Me.lblCompanyInitial.Size = New System.Drawing.Size(94, 13)
        Me.lblCompanyInitial.TabIndex = 93
        Me.lblCompanyInitial.Text = "Inisial Perusahaan"
        '
        'txtCompanyInitial
        '
        Me.txtCompanyInitial.BackColor = System.Drawing.Color.White
        Me.txtCompanyInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompanyInitial.Location = New System.Drawing.Point(129, 325)
        Me.txtCompanyInitial.MaxLength = 250
        Me.txtCompanyInitial.Name = "txtCompanyInitial"
        Me.txtCompanyInitial.Size = New System.Drawing.Size(160, 21)
        Me.txtCompanyInitial.TabIndex = 7
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(484, 28)
        Me.ToolBar.TabIndex = 4
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
        Me.lblInfo.Size = New System.Drawing.Size(484, 22)
        Me.lblInfo.TabIndex = 5
        Me.lblInfo.Text = "« Perusahaan Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(22, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Negara"
        '
        'txtCountry
        '
        Me.txtCountry.BackColor = System.Drawing.Color.White
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.Location = New System.Drawing.Point(129, 151)
        Me.txtCountry.MaxLength = 250
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(300, 21)
        Me.txtCountry.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Provinsi"
        '
        'txtProvince
        '
        Me.txtProvince.BackColor = System.Drawing.Color.White
        Me.txtProvince.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvince.Location = New System.Drawing.Point(129, 178)
        Me.txtProvince.MaxLength = 250
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Size = New System.Drawing.Size(300, 21)
        Me.txtProvince.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Kota"
        '
        'txtCity
        '
        Me.txtCity.BackColor = System.Drawing.Color.White
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(129, 205)
        Me.txtCity.MaxLength = 250
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(300, 21)
        Me.txtCity.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(22, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Gudang"
        '
        'txtWarehouse
        '
        Me.txtWarehouse.BackColor = System.Drawing.Color.White
        Me.txtWarehouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWarehouse.Location = New System.Drawing.Point(129, 232)
        Me.txtWarehouse.MaxLength = 250
        Me.txtWarehouse.Multiline = True
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.Size = New System.Drawing.Size(300, 60)
        Me.txtWarehouse.TabIndex = 5
        '
        'frmMstCompanyDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 489)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMstCompanyDet"
        Me.Text = "Perusahaan"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As usTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As usTextBox
    Friend WithEvents lblPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents txtPhoneNumber As usTextBox
    Friend WithEvents lblCompanyInitial As System.Windows.Forms.Label
    Friend WithEvents txtCompanyInitial As usTextBox
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWarehouse As ERPS.usTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCity As ERPS.usTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProvince As ERPS.usTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCountry As ERPS.usTextBox
End Class


