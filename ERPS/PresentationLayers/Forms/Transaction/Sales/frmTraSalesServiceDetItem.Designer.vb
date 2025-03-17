<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSalesServiceDetItem
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
        Me.cboSource = New ERPS.usComboBoxEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDestination = New ERPS.usComboBoxEdit()
        Me.txtPlatNumber = New ERPS.usTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDeliveryNumber = New ERPS.usTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New ERPS.usNumeric()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UsNumeric1 = New ERPS.usNumeric()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.UsNumeric2 = New ERPS.usNumeric()
        CType(Me.cboSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDestination.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsNumeric1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsNumeric2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(464, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(464, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Informasi Pengiriman"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSource
        '
        Me.cboSource.Location = New System.Drawing.Point(126, 66)
        Me.cboSource.Name = "cboSource"
        Me.cboSource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSource.Properties.NullText = ""
        Me.cboSource.Size = New System.Drawing.Size(300, 20)
        Me.cboSource.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(25, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Asal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Tujuan"
        '
        'cboDestination
        '
        Me.cboDestination.Location = New System.Drawing.Point(126, 92)
        Me.cboDestination.Name = "cboDestination"
        Me.cboDestination.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDestination.Properties.NullText = ""
        Me.cboDestination.Size = New System.Drawing.Size(300, 20)
        Me.cboDestination.TabIndex = 3
        '
        'txtPlatNumber
        '
        Me.txtPlatNumber.BackColor = System.Drawing.Color.White
        Me.txtPlatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlatNumber.Location = New System.Drawing.Point(126, 118)
        Me.txtPlatNumber.MaxLength = 250
        Me.txtPlatNumber.Name = "txtPlatNumber"
        Me.txtPlatNumber.Size = New System.Drawing.Size(300, 21)
        Me.txtPlatNumber.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(25, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "No. Plat"
        '
        'txtDeliveryNumber
        '
        Me.txtDeliveryNumber.BackColor = System.Drawing.Color.White
        Me.txtDeliveryNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryNumber.Location = New System.Drawing.Point(126, 145)
        Me.txtDeliveryNumber.MaxLength = 250
        Me.txtDeliveryNumber.Name = "txtDeliveryNumber"
        Me.txtDeliveryNumber.Size = New System.Drawing.Size(300, 21)
        Me.txtDeliveryNumber.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Nomor Referensi"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(25, 176)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 176
        Me.Label14.Text = "Jumlah"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.Color.White
        Me.txtUnitPrice.DecimalPlaces = 2
        Me.txtUnitPrice.Location = New System.Drawing.Point(126, 172)
        Me.txtUnitPrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(160, 21)
        Me.txtUnitPrice.TabIndex = 6
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPrice.ThousandsSeparator = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(25, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 179
        Me.Label6.Text = "Harga"
        '
        'UsNumeric1
        '
        Me.UsNumeric1.BackColor = System.Drawing.Color.White
        Me.UsNumeric1.DecimalPlaces = 2
        Me.UsNumeric1.Location = New System.Drawing.Point(126, 199)
        Me.UsNumeric1.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.UsNumeric1.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.UsNumeric1.Name = "UsNumeric1"
        Me.UsNumeric1.Size = New System.Drawing.Size(160, 21)
        Me.UsNumeric1.TabIndex = 7
        Me.UsNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.UsNumeric1.ThousandsSeparator = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(25, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 182
        Me.Label8.Text = "Total Harga"
        '
        'UsNumeric2
        '
        Me.UsNumeric2.BackColor = System.Drawing.Color.Azure
        Me.UsNumeric2.DecimalPlaces = 2
        Me.UsNumeric2.Enabled = False
        Me.UsNumeric2.Location = New System.Drawing.Point(126, 226)
        Me.UsNumeric2.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.UsNumeric2.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.UsNumeric2.Name = "UsNumeric2"
        Me.UsNumeric2.Size = New System.Drawing.Size(160, 21)
        Me.UsNumeric2.TabIndex = 8
        Me.UsNumeric2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.UsNumeric2.ThousandsSeparator = True
        '
        'frmTraSalesServiceDetItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 276)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.UsNumeric2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.UsNumeric1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtUnitPrice)
        Me.Controls.Add(Me.txtDeliveryNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPlatNumber)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboDestination)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSource)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraSalesServiceDetItem"
        Me.Text = "Informasi Pengiriman"
        CType(Me.cboSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDestination.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsNumeric1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsNumeric2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents cboSource As ERPS.usComboBoxEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDestination As ERPS.usComboBoxEdit
    Friend WithEvents txtPlatNumber As ERPS.usTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryNumber As ERPS.usTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As ERPS.usNumeric
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UsNumeric1 As ERPS.usNumeric
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents UsNumeric2 As ERPS.usNumeric
End Class
