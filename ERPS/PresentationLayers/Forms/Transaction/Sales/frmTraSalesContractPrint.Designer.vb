<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSalesContractPrint
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
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.rdDefault = New System.Windows.Forms.RadioButton()
        Me.rdSKBDN = New System.Windows.Forms.RadioButton()
        Me.gboType = New System.Windows.Forms.GroupBox()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarPreview = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.gboAdditionalTerm = New System.Windows.Forms.GroupBox()
        Me.txtAdditionalTerm10 = New ERPS.usTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm9 = New ERPS.usTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm8 = New ERPS.usTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm7 = New ERPS.usTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm6 = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm5 = New ERPS.usTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm4 = New ERPS.usTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm3 = New ERPS.usTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm2 = New ERPS.usTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAdditionalTerm1 = New ERPS.usTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gboType.SuspendLayout()
        Me.gboAdditionalTerm.SuspendLayout()
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
        Me.lblInfo.Size = New System.Drawing.Size(960, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Kontrak Penjualan"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdDefault
        '
        Me.rdDefault.AutoSize = True
        Me.rdDefault.Checked = True
        Me.rdDefault.Location = New System.Drawing.Point(33, 30)
        Me.rdDefault.Name = "rdDefault"
        Me.rdDefault.Size = New System.Drawing.Size(60, 17)
        Me.rdDefault.TabIndex = 0
        Me.rdDefault.TabStop = True
        Me.rdDefault.Text = "Default"
        Me.rdDefault.UseVisualStyleBackColor = True
        '
        'rdSKBDN
        '
        Me.rdSKBDN.AutoSize = True
        Me.rdSKBDN.Location = New System.Drawing.Point(119, 30)
        Me.rdSKBDN.Name = "rdSKBDN"
        Me.rdSKBDN.Size = New System.Drawing.Size(57, 17)
        Me.rdSKBDN.TabIndex = 1
        Me.rdSKBDN.Text = "SKBDN"
        Me.rdSKBDN.UseVisualStyleBackColor = True
        '
        'gboType
        '
        Me.gboType.Controls.Add(Me.rdSKBDN)
        Me.gboType.Controls.Add(Me.rdDefault)
        Me.gboType.Location = New System.Drawing.Point(707, 72)
        Me.gboType.Name = "gboType"
        Me.gboType.Size = New System.Drawing.Size(218, 79)
        Me.gboType.TabIndex = 3
        Me.gboType.TabStop = False
        Me.gboType.Text = "Tipe"
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarPreview, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(960, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarPreview
        '
        Me.BarPreview.Name = "BarPreview"
        Me.BarPreview.Tag = "Print"
        Me.BarPreview.Text = "Print"
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Tag = "Close"
        Me.BarClose.Text = "Tutup"
        '
        'gboAdditionalTerm
        '
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm10)
        Me.gboAdditionalTerm.Controls.Add(Me.Label17)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm9)
        Me.gboAdditionalTerm.Controls.Add(Me.Label16)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm8)
        Me.gboAdditionalTerm.Controls.Add(Me.Label15)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm7)
        Me.gboAdditionalTerm.Controls.Add(Me.Label14)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm6)
        Me.gboAdditionalTerm.Controls.Add(Me.Label13)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm5)
        Me.gboAdditionalTerm.Controls.Add(Me.Label12)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm4)
        Me.gboAdditionalTerm.Controls.Add(Me.Label11)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm3)
        Me.gboAdditionalTerm.Controls.Add(Me.Label10)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm2)
        Me.gboAdditionalTerm.Controls.Add(Me.Label9)
        Me.gboAdditionalTerm.Controls.Add(Me.txtAdditionalTerm1)
        Me.gboAdditionalTerm.Controls.Add(Me.Label8)
        Me.gboAdditionalTerm.Location = New System.Drawing.Point(32, 72)
        Me.gboAdditionalTerm.Name = "gboAdditionalTerm"
        Me.gboAdditionalTerm.Size = New System.Drawing.Size(649, 300)
        Me.gboAdditionalTerm.TabIndex = 2
        Me.gboAdditionalTerm.TabStop = False
        Me.gboAdditionalTerm.Text = "Syarat Tambahan"
        '
        'txtAdditionalTerm10
        '
        Me.txtAdditionalTerm10.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm10.Location = New System.Drawing.Point(103, 263)
        Me.txtAdditionalTerm10.MaxLength = 250
        Me.txtAdditionalTerm10.Name = "txtAdditionalTerm10"
        Me.txtAdditionalTerm10.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm10.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(28, 267)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 148
        Me.Label17.Text = "Baris Ke 10"
        '
        'txtAdditionalTerm9
        '
        Me.txtAdditionalTerm9.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm9.Location = New System.Drawing.Point(103, 236)
        Me.txtAdditionalTerm9.MaxLength = 250
        Me.txtAdditionalTerm9.Name = "txtAdditionalTerm9"
        Me.txtAdditionalTerm9.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm9.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(28, 240)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 146
        Me.Label16.Text = "Baris Ke 9"
        '
        'txtAdditionalTerm8
        '
        Me.txtAdditionalTerm8.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm8.Location = New System.Drawing.Point(103, 209)
        Me.txtAdditionalTerm8.MaxLength = 250
        Me.txtAdditionalTerm8.Name = "txtAdditionalTerm8"
        Me.txtAdditionalTerm8.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm8.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(28, 213)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 144
        Me.Label15.Text = "Baris Ke 8"
        '
        'txtAdditionalTerm7
        '
        Me.txtAdditionalTerm7.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm7.Location = New System.Drawing.Point(103, 182)
        Me.txtAdditionalTerm7.MaxLength = 250
        Me.txtAdditionalTerm7.Name = "txtAdditionalTerm7"
        Me.txtAdditionalTerm7.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm7.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(28, 186)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 142
        Me.Label14.Text = "Baris Ke 7"
        '
        'txtAdditionalTerm6
        '
        Me.txtAdditionalTerm6.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm6.Location = New System.Drawing.Point(103, 155)
        Me.txtAdditionalTerm6.MaxLength = 250
        Me.txtAdditionalTerm6.Name = "txtAdditionalTerm6"
        Me.txtAdditionalTerm6.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm6.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(28, 159)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 140
        Me.Label13.Text = "Baris Ke 6"
        '
        'txtAdditionalTerm5
        '
        Me.txtAdditionalTerm5.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm5.Location = New System.Drawing.Point(103, 128)
        Me.txtAdditionalTerm5.MaxLength = 250
        Me.txtAdditionalTerm5.Name = "txtAdditionalTerm5"
        Me.txtAdditionalTerm5.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm5.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(28, 132)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 138
        Me.Label12.Text = "Baris Ke 5"
        '
        'txtAdditionalTerm4
        '
        Me.txtAdditionalTerm4.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm4.Location = New System.Drawing.Point(103, 101)
        Me.txtAdditionalTerm4.MaxLength = 250
        Me.txtAdditionalTerm4.Name = "txtAdditionalTerm4"
        Me.txtAdditionalTerm4.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm4.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(28, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 136
        Me.Label11.Text = "Baris Ke 4"
        '
        'txtAdditionalTerm3
        '
        Me.txtAdditionalTerm3.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm3.Location = New System.Drawing.Point(103, 74)
        Me.txtAdditionalTerm3.MaxLength = 250
        Me.txtAdditionalTerm3.Name = "txtAdditionalTerm3"
        Me.txtAdditionalTerm3.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm3.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(28, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 134
        Me.Label10.Text = "Baris Ke 3"
        '
        'txtAdditionalTerm2
        '
        Me.txtAdditionalTerm2.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm2.Location = New System.Drawing.Point(103, 47)
        Me.txtAdditionalTerm2.MaxLength = 250
        Me.txtAdditionalTerm2.Name = "txtAdditionalTerm2"
        Me.txtAdditionalTerm2.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm2.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(28, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = "Baris Ke 2"
        '
        'txtAdditionalTerm1
        '
        Me.txtAdditionalTerm1.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTerm1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalTerm1.Location = New System.Drawing.Point(103, 20)
        Me.txtAdditionalTerm1.MaxLength = 250
        Me.txtAdditionalTerm1.Name = "txtAdditionalTerm1"
        Me.txtAdditionalTerm1.Size = New System.Drawing.Size(527, 21)
        Me.txtAdditionalTerm1.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(28, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "Baris Ke 1"
        '
        'frmTraSalesContractPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 396)
        Me.Controls.Add(Me.gboAdditionalTerm)
        Me.Controls.Add(Me.gboType)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraSalesContractPrint"
        Me.Text = "Cetak Kontrak Penjualan"
        Me.gboType.ResumeLayout(False)
        Me.gboType.PerformLayout()
        Me.gboAdditionalTerm.ResumeLayout(False)
        Me.gboAdditionalTerm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarPreview As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents rdDefault As System.Windows.Forms.RadioButton
    Friend WithEvents rdSKBDN As System.Windows.Forms.RadioButton
    Friend WithEvents gboType As System.Windows.Forms.GroupBox
    Friend WithEvents gboAdditionalTerm As GroupBox
    Friend WithEvents txtAdditionalTerm10 As usTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtAdditionalTerm9 As usTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtAdditionalTerm8 As usTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtAdditionalTerm7 As usTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtAdditionalTerm6 As usTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtAdditionalTerm5 As usTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtAdditionalTerm4 As usTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtAdditionalTerm3 As usTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtAdditionalTerm2 As usTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAdditionalTerm1 As usTextBox
    Friend WithEvents Label8 As Label
End Class
