<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usFormPaymentTerm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usFormPaymentTerm))
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPaymentMode = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPaymentType = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.txtCreditTerm = New ERPS.usNumeric()
        Me.txtPaymentModeCode = New ERPS.usTextBox()
        Me.txtPaymentModeName = New ERPS.usTextBox()
        Me.txtPaymentTypeCode = New ERPS.usTextBox()
        Me.txtPaymentTypeName = New ERPS.usTextBox()
        Me.txtPercentage = New ERPS.usNumeric()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.pnlMain.SuspendLayout()
        CType(Me.txtCreditTerm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblInfo.Size = New System.Drawing.Size(530, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Syarat Pembayaran"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMain.Controls.Add(Me.Label13)
        Me.pnlMain.Controls.Add(Me.txtRemarks)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtCreditTerm)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.txtPaymentModeCode)
        Me.pnlMain.Controls.Add(Me.btnPaymentMode)
        Me.pnlMain.Controls.Add(Me.txtPaymentModeName)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.txtPaymentTypeCode)
        Me.pnlMain.Controls.Add(Me.btnPaymentType)
        Me.pnlMain.Controls.Add(Me.txtPaymentTypeName)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.txtPercentage)
        Me.pnlMain.Controls.Add(Me.Label19)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 50)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(530, 208)
        Me.pnlMain.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(29, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 148
        Me.Label13.Text = "Keterangan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(241, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Hari"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(29, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "Jangka Waktu Kredit"
        '
        'btnPaymentMode
        '
        Me.btnPaymentMode.Image = CType(resources.GetObject("btnPaymentMode.Image"), System.Drawing.Image)
        Me.btnPaymentMode.Location = New System.Drawing.Point(478, 71)
        Me.btnPaymentMode.Name = "btnPaymentMode"
        Me.btnPaymentMode.Size = New System.Drawing.Size(23, 23)
        Me.btnPaymentMode.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(29, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Metode Pembayaran"
        '
        'btnPaymentType
        '
        Me.btnPaymentType.Image = CType(resources.GetObject("btnPaymentType.Image"), System.Drawing.Image)
        Me.btnPaymentType.Location = New System.Drawing.Point(478, 44)
        Me.btnPaymentType.Name = "btnPaymentType"
        Me.btnPaymentType.Size = New System.Drawing.Size(23, 23)
        Me.btnPaymentType.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Jenis Pembayaran"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(241, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "%"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(29, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 13)
        Me.Label19.TabIndex = 133
        Me.Label19.Text = "Persentase"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(154, 126)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(318, 48)
        Me.txtRemarks.TabIndex = 8
        '
        'txtCreditTerm
        '
        Me.txtCreditTerm.Location = New System.Drawing.Point(154, 99)
        Me.txtCreditTerm.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtCreditTerm.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtCreditTerm.Name = "txtCreditTerm"
        Me.txtCreditTerm.Size = New System.Drawing.Size(81, 21)
        Me.txtCreditTerm.TabIndex = 7
        Me.txtCreditTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCreditTerm.ThousandsSeparator = True
        '
        'txtPaymentModeCode
        '
        Me.txtPaymentModeCode.BackColor = System.Drawing.Color.Azure
        Me.txtPaymentModeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentModeCode.Location = New System.Drawing.Point(154, 72)
        Me.txtPaymentModeCode.MaxLength = 250
        Me.txtPaymentModeCode.Name = "txtPaymentModeCode"
        Me.txtPaymentModeCode.ReadOnly = True
        Me.txtPaymentModeCode.Size = New System.Drawing.Size(81, 21)
        Me.txtPaymentModeCode.TabIndex = 4
        '
        'txtPaymentModeName
        '
        Me.txtPaymentModeName.BackColor = System.Drawing.Color.Azure
        Me.txtPaymentModeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentModeName.Location = New System.Drawing.Point(234, 72)
        Me.txtPaymentModeName.MaxLength = 250
        Me.txtPaymentModeName.Name = "txtPaymentModeName"
        Me.txtPaymentModeName.ReadOnly = True
        Me.txtPaymentModeName.Size = New System.Drawing.Size(238, 21)
        Me.txtPaymentModeName.TabIndex = 5
        '
        'txtPaymentTypeCode
        '
        Me.txtPaymentTypeCode.BackColor = System.Drawing.Color.Azure
        Me.txtPaymentTypeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentTypeCode.Location = New System.Drawing.Point(154, 45)
        Me.txtPaymentTypeCode.MaxLength = 250
        Me.txtPaymentTypeCode.Name = "txtPaymentTypeCode"
        Me.txtPaymentTypeCode.ReadOnly = True
        Me.txtPaymentTypeCode.Size = New System.Drawing.Size(81, 21)
        Me.txtPaymentTypeCode.TabIndex = 1
        '
        'txtPaymentTypeName
        '
        Me.txtPaymentTypeName.BackColor = System.Drawing.Color.Azure
        Me.txtPaymentTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentTypeName.Location = New System.Drawing.Point(234, 45)
        Me.txtPaymentTypeName.MaxLength = 250
        Me.txtPaymentTypeName.Name = "txtPaymentTypeName"
        Me.txtPaymentTypeName.ReadOnly = True
        Me.txtPaymentTypeName.Size = New System.Drawing.Size(238, 21)
        Me.txtPaymentTypeName.TabIndex = 2
        '
        'txtPercentage
        '
        Me.txtPercentage.DecimalPlaces = 2
        Me.txtPercentage.Location = New System.Drawing.Point(154, 18)
        Me.txtPercentage.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPercentage.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(81, 21)
        Me.txtPercentage.TabIndex = 0
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercentage.ThousandsSeparator = True
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(530, 28)
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
        'usFormPaymentTerm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 258)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "usFormPaymentTerm"
        Me.Text = "Syarat Pembayaran"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.txtCreditTerm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPercentage As ERPS.usNumeric
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCreditTerm As ERPS.usNumeric
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentModeCode As ERPS.usTextBox
    Friend WithEvents btnPaymentMode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPaymentModeName As ERPS.usTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentTypeCode As ERPS.usTextBox
    Friend WithEvents btnPaymentType As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPaymentTypeName As ERPS.usTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As ERPS.usTextBox
End Class
