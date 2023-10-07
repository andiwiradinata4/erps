<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstBusinessPartnerSetupBalanceARDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMstBusinessPartnerSetupBalanceARDet))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvoiceNumber = New ERPS.usTextBox()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.txtTotalDPP = New ERPS.usNumeric()
        Me.btnCompany = New DevExpress.XtraEditors.SimpleButton()
        Me.btnProgram = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtCompanyName = New ERPS.usTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProgramName = New ERPS.usTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.txtTotalDPP, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(574, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(574, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Item"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtInvoiceNumber)
        Me.Panel1.Controls.Add(Me.dtpInvoiceDate)
        Me.Panel1.Controls.Add(Me.txtTotalDPP)
        Me.Panel1.Controls.Add(Me.btnCompany)
        Me.Panel1.Controls.Add(Me.btnProgram)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblStatusID)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.txtCompanyName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtProgramName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(574, 148)
        Me.Panel1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "No. Invoice"
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(101, 71)
        Me.txtInvoiceNumber.MaxLength = 250
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(413, 21)
        Me.txtInvoiceNumber.TabIndex = 4
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(413, 98)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(101, 21)
        Me.dtpInvoiceDate.TabIndex = 6
        Me.dtpInvoiceDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'txtTotalDPP
        '
        Me.txtTotalDPP.DecimalPlaces = 2
        Me.txtTotalDPP.Location = New System.Drawing.Point(101, 98)
        Me.txtTotalDPP.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalDPP.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalDPP.Name = "txtTotalDPP"
        Me.txtTotalDPP.Size = New System.Drawing.Size(187, 21)
        Me.txtTotalDPP.TabIndex = 5
        Me.txtTotalDPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDPP.ThousandsSeparator = True
        '
        'btnCompany
        '
        Me.btnCompany.Image = CType(resources.GetObject("btnCompany.Image"), System.Drawing.Image)
        Me.btnCompany.Location = New System.Drawing.Point(521, 43)
        Me.btnCompany.Name = "btnCompany"
        Me.btnCompany.Size = New System.Drawing.Size(23, 23)
        Me.btnCompany.TabIndex = 3
        '
        'btnProgram
        '
        Me.btnProgram.Image = CType(resources.GetObject("btnProgram.Image"), System.Drawing.Image)
        Me.btnProgram.Location = New System.Drawing.Point(521, 16)
        Me.btnProgram.Name = "btnProgram"
        Me.btnProgram.Size = New System.Drawing.Size(23, 23)
        Me.btnProgram.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(323, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Tanggal Invoice"
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(18, 102)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(69, 13)
        Me.lblStatusID.TabIndex = 101
        Me.lblStatusID.Text = "Total Invoice"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(18, 48)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(64, 13)
        Me.lblName.TabIndex = 99
        Me.lblName.Text = "Perusahaan"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BackColor = System.Drawing.Color.LightYellow
        Me.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompanyName.Location = New System.Drawing.Point(101, 44)
        Me.txtCompanyName.MaxLength = 250
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.ReadOnly = True
        Me.txtCompanyName.Size = New System.Drawing.Size(413, 21)
        Me.txtCompanyName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Program"
        '
        'txtProgramName
        '
        Me.txtProgramName.BackColor = System.Drawing.Color.LightYellow
        Me.txtProgramName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProgramName.Location = New System.Drawing.Point(101, 17)
        Me.txtProgramName.MaxLength = 250
        Me.txtProgramName.Name = "txtProgramName"
        Me.txtProgramName.ReadOnly = True
        Me.txtProgramName.Size = New System.Drawing.Size(413, 21)
        Me.txtProgramName.TabIndex = 0
        '
        'frmMstBusinessPartnerSetupBalanceARDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 198)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMstBusinessPartnerSetupBalanceARDet"
        Me.Text = "Item"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtTotalDPP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTotalDPP As ERPS.usNumeric
    Friend WithEvents btnCompany As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnProgram As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As ERPS.usTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProgramName As ERPS.usTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumber As ERPS.usTextBox
End Class
