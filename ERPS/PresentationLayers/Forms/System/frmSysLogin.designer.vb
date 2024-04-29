<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysLogin))
        Me.pnlLogin = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPassword = New ERPS.usTextBox()
        Me.txtUserID = New ERPS.usTextBox()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.tssVersion = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.pnlLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLogin.SuspendLayout()
        Me.ssMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLogin
        '
        Me.pnlLogin.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlLogin.Controls.Add(Me.LabelControl3)
        Me.pnlLogin.Controls.Add(Me.txtPassword)
        Me.pnlLogin.Controls.Add(Me.txtUserID)
        Me.pnlLogin.Controls.Add(Me.btnExit)
        Me.pnlLogin.Controls.Add(Me.labelControl1)
        Me.pnlLogin.Controls.Add(Me.btnLogin)
        Me.pnlLogin.Controls.Add(Me.labelControl2)
        Me.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLogin.Location = New System.Drawing.Point(0, 67)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(296, 199)
        Me.pnlLogin.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(118, 6)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(66, 24)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "LOGIN"
        '
        'txtPassword
        '
        Me.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPassword.Location = New System.Drawing.Point(21, 106)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(250, 21)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUserID
        '
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.Location = New System.Drawing.Point(21, 52)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(250, 21)
        Me.txtUserID.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(160, 149)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(111, 25)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        '
        'labelControl1
        '
        Me.labelControl1.Location = New System.Drawing.Point(21, 33)
        Me.labelControl1.Name = "labelControl1"
        Me.labelControl1.Size = New System.Drawing.Size(36, 13)
        Me.labelControl1.TabIndex = 4
        Me.labelControl1.Text = "User ID"
        '
        'btnLogin
        '
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnLogin.Location = New System.Drawing.Point(21, 149)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(111, 25)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(21, 87)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(46, 13)
        Me.labelControl2.TabIndex = 6
        Me.labelControl2.Text = "Password"
        '
        'simpleButton1
        '
        Me.simpleButton1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.simpleButton1.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.simpleButton1.Appearance.Options.UseBackColor = True
        Me.simpleButton1.Appearance.Options.UseFont = True
        Me.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.simpleButton1.Dock = System.Windows.Forms.DockStyle.Top
        Me.simpleButton1.Image = CType(resources.GetObject("simpleButton1.Image"), System.Drawing.Image)
        Me.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.simpleButton1.Location = New System.Drawing.Point(0, 0)
        Me.simpleButton1.Name = "simpleButton1"
        Me.simpleButton1.Size = New System.Drawing.Size(296, 67)
        Me.simpleButton1.TabIndex = 2
        Me.simpleButton1.TabStop = False
        '
        'ssMain
        '
        Me.ssMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssVersion})
        Me.ssMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ssMain.Location = New System.Drawing.Point(0, 266)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ssMain.Size = New System.Drawing.Size(296, 18)
        Me.ssMain.TabIndex = 8
        Me.ssMain.Text = "StatusStrip1"
        '
        'tssVersion
        '
        Me.tssVersion.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.tssVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssVersion.ForeColor = System.Drawing.Color.DimGray
        Me.tssVersion.Name = "tssVersion"
        Me.tssVersion.Size = New System.Drawing.Size(49, 17)
        Me.tssVersion.Text = "Version"
        '
        'frmSysLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 284)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.simpleButton1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSysLogin"
        Me.Opacity = 0.9R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TopMost = True
        CType(Me.pnlLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlLogin As DevExpress.XtraEditors.PanelControl
    Private WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Private WithEvents labelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As ERPS.usTextBox
    Friend WithEvents txtUserID As ERPS.usTextBox
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ssMain As StatusStrip
    Friend WithEvents tssVersion As ToolStripStatusLabel
End Class
