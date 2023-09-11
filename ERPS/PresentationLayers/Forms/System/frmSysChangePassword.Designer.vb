<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysChangePassword
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
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.lblOldPassword = New System.Windows.Forms.Label()
        Me.txtUserID = New ERPS.usTextBox()
        Me.txtOldPassword = New ERPS.usTextBox()
        Me.txtNewPassword = New ERPS.usTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New ERPS.usTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkShowOldPassword = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowNewPassword = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowConfirmPassword = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.chkShowOldPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowNewPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(483, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(483, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Ubah Password"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.chkShowConfirmPassword)
        Me.pnlDetail.Controls.Add(Me.chkShowNewPassword)
        Me.pnlDetail.Controls.Add(Me.chkShowOldPassword)
        Me.pnlDetail.Controls.Add(Me.txtConfirmPassword)
        Me.pnlDetail.Controls.Add(Me.Label2)
        Me.pnlDetail.Controls.Add(Me.txtNewPassword)
        Me.pnlDetail.Controls.Add(Me.Label1)
        Me.pnlDetail.Controls.Add(Me.txtOldPassword)
        Me.pnlDetail.Controls.Add(Me.lblUserID)
        Me.pnlDetail.Controls.Add(Me.txtUserID)
        Me.pnlDetail.Controls.Add(Me.lblOldPassword)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(0, 50)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(483, 147)
        Me.pnlDetail.TabIndex = 2
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.BackColor = System.Drawing.Color.Transparent
        Me.lblUserID.ForeColor = System.Drawing.Color.Black
        Me.lblUserID.Location = New System.Drawing.Point(29, 17)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(43, 13)
        Me.lblUserID.TabIndex = 93
        Me.lblUserID.Text = "User ID"
        '
        'lblOldPassword
        '
        Me.lblOldPassword.AutoSize = True
        Me.lblOldPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblOldPassword.ForeColor = System.Drawing.Color.Black
        Me.lblOldPassword.Location = New System.Drawing.Point(29, 44)
        Me.lblOldPassword.Name = "lblOldPassword"
        Me.lblOldPassword.Size = New System.Drawing.Size(81, 13)
        Me.lblOldPassword.TabIndex = 93
        Me.lblOldPassword.Text = "Password Lama"
        '
        'txtUserID
        '
        Me.txtUserID.BackColor = System.Drawing.Color.LightYellow
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.Location = New System.Drawing.Point(154, 13)
        Me.txtUserID.MaxLength = 250
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(160, 21)
        Me.txtUserID.TabIndex = 0
        '
        'txtOldPassword
        '
        Me.txtOldPassword.BackColor = System.Drawing.Color.White
        Me.txtOldPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldPassword.Location = New System.Drawing.Point(154, 40)
        Me.txtOldPassword.MaxLength = 250
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.Size = New System.Drawing.Size(216, 21)
        Me.txtOldPassword.TabIndex = 1
        Me.txtOldPassword.UseSystemPasswordChar = True
        '
        'txtNewPassword
        '
        Me.txtNewPassword.BackColor = System.Drawing.Color.White
        Me.txtNewPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewPassword.Location = New System.Drawing.Point(154, 67)
        Me.txtNewPassword.MaxLength = 250
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(216, 21)
        Me.txtNewPassword.TabIndex = 3
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Password Baru"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BackColor = System.Drawing.Color.White
        Me.txtConfirmPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfirmPassword.Location = New System.Drawing.Point(154, 94)
        Me.txtConfirmPassword.MaxLength = 250
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(216, 21)
        Me.txtConfirmPassword.TabIndex = 5
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Konfirmasi Password"
        '
        'chkShowOldPassword
        '
        Me.chkShowOldPassword.Location = New System.Drawing.Point(376, 41)
        Me.chkShowOldPassword.Name = "chkShowOldPassword"
        Me.chkShowOldPassword.Properties.Caption = "Lihat"
        Me.chkShowOldPassword.Size = New System.Drawing.Size(58, 19)
        Me.chkShowOldPassword.TabIndex = 2
        '
        'chkShowNewPassword
        '
        Me.chkShowNewPassword.Location = New System.Drawing.Point(376, 68)
        Me.chkShowNewPassword.Name = "chkShowNewPassword"
        Me.chkShowNewPassword.Properties.Caption = "Lihat"
        Me.chkShowNewPassword.Size = New System.Drawing.Size(58, 19)
        Me.chkShowNewPassword.TabIndex = 4
        '
        'chkShowConfirmPassword
        '
        Me.chkShowConfirmPassword.Location = New System.Drawing.Point(376, 95)
        Me.chkShowConfirmPassword.Name = "chkShowConfirmPassword"
        Me.chkShowConfirmPassword.Properties.Caption = "Lihat"
        Me.chkShowConfirmPassword.Size = New System.Drawing.Size(58, 19)
        Me.chkShowConfirmPassword.TabIndex = 6
        '
        'frmSysChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 197)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Name = "frmSysChangePassword"
        Me.Text = "Ubah Password"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.chkShowOldPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowNewPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents txtUserID As ERPS.usTextBox
    Friend WithEvents lblOldPassword As System.Windows.Forms.Label
    Friend WithEvents txtOldPassword As ERPS.usTextBox
    Friend WithEvents chkShowOldPassword As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtConfirmPassword As ERPS.usTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As ERPS.usTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkShowConfirmPassword As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowNewPassword As DevExpress.XtraEditors.CheckEdit
End Class
