<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraARAPChooseBankAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraARAPChooseBankAccount))
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.gboCompanyBankAccount2 = New System.Windows.Forms.GroupBox()
        Me.btnBankAccount2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gboCompanyBankAccount1 = New System.Windows.Forms.GroupBox()
        Me.btnBankAccount1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtAccountNumber2 = New ERPS.usTextBox()
        Me.txtCurrency2 = New ERPS.usTextBox()
        Me.txtAccountName2 = New ERPS.usTextBox()
        Me.txtBankName2 = New ERPS.usTextBox()
        Me.txtAccountNumber1 = New ERPS.usTextBox()
        Me.txtCurrency1 = New ERPS.usTextBox()
        Me.txtAccountName1 = New ERPS.usTextBox()
        Me.txtBankName1 = New ERPS.usTextBox()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.pnlMain.SuspendLayout()
        Me.gboCompanyBankAccount2.SuspendLayout()
        Me.gboCompanyBankAccount1.SuspendLayout()
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
        Me.lblInfo.Size = New System.Drawing.Size(591, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Pilih Akun Bank"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 409)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(591, 23)
        Me.pgMain.TabIndex = 3
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMain.Controls.Add(Me.gboCompanyBankAccount2)
        Me.pnlMain.Controls.Add(Me.gboCompanyBankAccount1)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 50)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(591, 359)
        Me.pnlMain.TabIndex = 2
        '
        'gboCompanyBankAccount2
        '
        Me.gboCompanyBankAccount2.Controls.Add(Me.btnBankAccount2)
        Me.gboCompanyBankAccount2.Controls.Add(Me.Label3)
        Me.gboCompanyBankAccount2.Controls.Add(Me.txtAccountNumber2)
        Me.gboCompanyBankAccount2.Controls.Add(Me.Label5)
        Me.gboCompanyBankAccount2.Controls.Add(Me.txtCurrency2)
        Me.gboCompanyBankAccount2.Controls.Add(Me.Label6)
        Me.gboCompanyBankAccount2.Controls.Add(Me.txtAccountName2)
        Me.gboCompanyBankAccount2.Controls.Add(Me.Label7)
        Me.gboCompanyBankAccount2.Controls.Add(Me.txtBankName2)
        Me.gboCompanyBankAccount2.Location = New System.Drawing.Point(32, 193)
        Me.gboCompanyBankAccount2.Name = "gboCompanyBankAccount2"
        Me.gboCompanyBankAccount2.Size = New System.Drawing.Size(516, 135)
        Me.gboCompanyBankAccount2.TabIndex = 1
        Me.gboCompanyBankAccount2.TabStop = False
        Me.gboCompanyBankAccount2.Text = "Akun Bank 2"
        '
        'btnBankAccount2
        '
        Me.btnBankAccount2.Image = CType(resources.GetObject("btnBankAccount2.Image"), System.Drawing.Image)
        Me.btnBankAccount2.Location = New System.Drawing.Point(452, 28)
        Me.btnBankAccount2.Name = "btnBankAccount2"
        Me.btnBankAccount2.Size = New System.Drawing.Size(23, 23)
        Me.btnBankAccount2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(30, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Nomor Rekening"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(321, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "Mata Uang"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(30, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Nama Akun"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(30, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Nama Bank"
        '
        'gboCompanyBankAccount1
        '
        Me.gboCompanyBankAccount1.Controls.Add(Me.btnBankAccount1)
        Me.gboCompanyBankAccount1.Controls.Add(Me.Label2)
        Me.gboCompanyBankAccount1.Controls.Add(Me.txtAccountNumber1)
        Me.gboCompanyBankAccount1.Controls.Add(Me.Label4)
        Me.gboCompanyBankAccount1.Controls.Add(Me.txtCurrency1)
        Me.gboCompanyBankAccount1.Controls.Add(Me.Label1)
        Me.gboCompanyBankAccount1.Controls.Add(Me.txtAccountName1)
        Me.gboCompanyBankAccount1.Controls.Add(Me.lblName)
        Me.gboCompanyBankAccount1.Controls.Add(Me.txtBankName1)
        Me.gboCompanyBankAccount1.Location = New System.Drawing.Point(32, 36)
        Me.gboCompanyBankAccount1.Name = "gboCompanyBankAccount1"
        Me.gboCompanyBankAccount1.Size = New System.Drawing.Size(516, 135)
        Me.gboCompanyBankAccount1.TabIndex = 0
        Me.gboCompanyBankAccount1.TabStop = False
        Me.gboCompanyBankAccount1.Text = "Akun Bank 1"
        '
        'btnBankAccount1
        '
        Me.btnBankAccount1.Image = CType(resources.GetObject("btnBankAccount1.Image"), System.Drawing.Image)
        Me.btnBankAccount1.Location = New System.Drawing.Point(452, 32)
        Me.btnBankAccount1.Name = "btnBankAccount1"
        Me.btnBankAccount1.Size = New System.Drawing.Size(23, 23)
        Me.btnBankAccount1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(30, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Nomor Rekening"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(321, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Mata Uang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(30, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Nama Akun"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(30, 64)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(60, 13)
        Me.lblName.TabIndex = 126
        Me.lblName.Text = "Nama Bank"
        '
        'txtAccountNumber2
        '
        Me.txtAccountNumber2.BackColor = System.Drawing.Color.Azure
        Me.txtAccountNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountNumber2.Location = New System.Drawing.Point(136, 84)
        Me.txtAccountNumber2.MaxLength = 250
        Me.txtAccountNumber2.Name = "txtAccountNumber2"
        Me.txtAccountNumber2.ReadOnly = True
        Me.txtAccountNumber2.Size = New System.Drawing.Size(160, 21)
        Me.txtAccountNumber2.TabIndex = 3
        '
        'txtCurrency2
        '
        Me.txtCurrency2.BackColor = System.Drawing.Color.Azure
        Me.txtCurrency2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrency2.Location = New System.Drawing.Point(393, 84)
        Me.txtCurrency2.MaxLength = 250
        Me.txtCurrency2.Name = "txtCurrency2"
        Me.txtCurrency2.ReadOnly = True
        Me.txtCurrency2.Size = New System.Drawing.Size(53, 21)
        Me.txtCurrency2.TabIndex = 4
        '
        'txtAccountName2
        '
        Me.txtAccountName2.BackColor = System.Drawing.Color.Azure
        Me.txtAccountName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountName2.Location = New System.Drawing.Point(136, 29)
        Me.txtAccountName2.MaxLength = 250
        Me.txtAccountName2.Name = "txtAccountName2"
        Me.txtAccountName2.ReadOnly = True
        Me.txtAccountName2.Size = New System.Drawing.Size(310, 21)
        Me.txtAccountName2.TabIndex = 0
        '
        'txtBankName2
        '
        Me.txtBankName2.BackColor = System.Drawing.Color.Azure
        Me.txtBankName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBankName2.Location = New System.Drawing.Point(136, 57)
        Me.txtBankName2.MaxLength = 250
        Me.txtBankName2.Name = "txtBankName2"
        Me.txtBankName2.ReadOnly = True
        Me.txtBankName2.Size = New System.Drawing.Size(310, 21)
        Me.txtBankName2.TabIndex = 2
        '
        'txtAccountNumber1
        '
        Me.txtAccountNumber1.BackColor = System.Drawing.Color.Azure
        Me.txtAccountNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountNumber1.Location = New System.Drawing.Point(136, 88)
        Me.txtAccountNumber1.MaxLength = 250
        Me.txtAccountNumber1.Name = "txtAccountNumber1"
        Me.txtAccountNumber1.ReadOnly = True
        Me.txtAccountNumber1.Size = New System.Drawing.Size(160, 21)
        Me.txtAccountNumber1.TabIndex = 3
        '
        'txtCurrency1
        '
        Me.txtCurrency1.BackColor = System.Drawing.Color.Azure
        Me.txtCurrency1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrency1.Location = New System.Drawing.Point(393, 88)
        Me.txtCurrency1.MaxLength = 250
        Me.txtCurrency1.Name = "txtCurrency1"
        Me.txtCurrency1.ReadOnly = True
        Me.txtCurrency1.Size = New System.Drawing.Size(53, 21)
        Me.txtCurrency1.TabIndex = 4
        '
        'txtAccountName1
        '
        Me.txtAccountName1.BackColor = System.Drawing.Color.Azure
        Me.txtAccountName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountName1.Location = New System.Drawing.Point(136, 33)
        Me.txtAccountName1.MaxLength = 250
        Me.txtAccountName1.Name = "txtAccountName1"
        Me.txtAccountName1.ReadOnly = True
        Me.txtAccountName1.Size = New System.Drawing.Size(310, 21)
        Me.txtAccountName1.TabIndex = 0
        '
        'txtBankName1
        '
        Me.txtBankName1.BackColor = System.Drawing.Color.Azure
        Me.txtBankName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBankName1.Location = New System.Drawing.Point(136, 61)
        Me.txtBankName1.MaxLength = 250
        Me.txtBankName1.Name = "txtBankName1"
        Me.txtBankName1.ReadOnly = True
        Me.txtBankName1.Size = New System.Drawing.Size(310, 21)
        Me.txtBankName1.TabIndex = 2
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(591, 28)
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
        'frmTraARAPChooseBankAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 432)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Name = "frmTraARAPChooseBankAccount"
        Me.Text = "Akun Bank"
        Me.pnlMain.ResumeLayout(False)
        Me.gboCompanyBankAccount2.ResumeLayout(False)
        Me.gboCompanyBankAccount2.PerformLayout()
        Me.gboCompanyBankAccount1.ResumeLayout(False)
        Me.gboCompanyBankAccount1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents gboCompanyBankAccount2 As System.Windows.Forms.GroupBox
    Friend WithEvents gboCompanyBankAccount1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBankAccount1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNumber1 As ERPS.usTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCurrency1 As ERPS.usTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccountName1 As ERPS.usTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtBankName1 As ERPS.usTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNumber2 As ERPS.usTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCurrency2 As ERPS.usTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAccountName2 As ERPS.usTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBankName2 As ERPS.usTextBox
    Friend WithEvents btnBankAccount2 As DevExpress.XtraEditors.SimpleButton
End Class
