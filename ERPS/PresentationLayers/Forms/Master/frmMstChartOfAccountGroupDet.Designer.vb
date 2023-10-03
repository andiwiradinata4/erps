<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstChartOfAccountGroupDet
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
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboCOAType = New ERPS.usComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAliasName = New ERPS.usTextBox()
        Me.cboStatus = New ERPS.usComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New ERPS.usTextBox()
        Me.StatusStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.ToolBar.Size = New System.Drawing.Size(462, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(462, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Group Akun Perkiraan Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 207)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(462, 22)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(339, 17)
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cboCOAType)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtAliasName)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.lblStatusID)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(462, 157)
        Me.Panel1.TabIndex = 2
        '
        'cboCOAType
        '
        Me.cboCOAType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOAType.FormattingEnabled = True
        Me.cboCOAType.Location = New System.Drawing.Point(82, 72)
        Me.cboCOAType.Name = "cboCOAType"
        Me.cboCOAType.Size = New System.Drawing.Size(227, 21)
        Me.cboCOAType.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(24, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Tipe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Alias"
        '
        'txtAliasName
        '
        Me.txtAliasName.BackColor = System.Drawing.Color.White
        Me.txtAliasName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAliasName.Location = New System.Drawing.Point(82, 45)
        Me.txtAliasName.MaxLength = 250
        Me.txtAliasName.Name = "txtAliasName"
        Me.txtAliasName.Size = New System.Drawing.Size(227, 21)
        Me.txtAliasName.TabIndex = 1
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(82, 99)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(125, 21)
        Me.cboStatus.TabIndex = 3
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(24, 103)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusID.TabIndex = 101
        Me.lblStatusID.Text = "Status"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(24, 21)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(34, 13)
        Me.lblName.TabIndex = 99
        Me.lblName.Text = "Nama"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Location = New System.Drawing.Point(82, 18)
        Me.txtName.MaxLength = 250
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(354, 21)
        Me.txtName.TabIndex = 0
        '
        'frmMstChartOfAccountGroupDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 229)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMstChartOfAccountGroupDet"
        Me.Text = "Group Akun Perkiraan"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboCOAType As ERPS.usComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAliasName As ERPS.usTextBox
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As ERPS.usTextBox
End Class
