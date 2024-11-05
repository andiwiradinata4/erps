<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraOrderRequestDetChangeItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraOrderRequestDetChangeItem))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnItem = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemCode = New ERPS.usTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtItemName = New ERPS.usTextBox()
        Me.gcNewItem = New DevExpress.XtraEditors.GroupControl()
        Me.txtLength = New ERPS.usNumeric()
        Me.txtWidth = New ERPS.usNumeric()
        Me.txtThick = New ERPS.usNumeric()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtLengthOld = New ERPS.usNumeric()
        Me.txtWidthOld = New ERPS.usNumeric()
        Me.txtThickOld = New ERPS.usNumeric()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtItemNameOld = New ERPS.usTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtItemCodeOld = New ERPS.usTextBox()
        CType(Me.gcNewItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcNewItem.SuspendLayout()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtLengthOld, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidthOld, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThickOld, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(702, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(702, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Barang Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnItem
        '
        Me.btnItem.Image = CType(resources.GetObject("btnItem.Image"), System.Drawing.Image)
        Me.btnItem.Location = New System.Drawing.Point(249, 33)
        Me.btnItem.Name = "btnItem"
        Me.btnItem.Size = New System.Drawing.Size(23, 23)
        Me.btnItem.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Kode Barang"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.Azure
        Me.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCode.Location = New System.Drawing.Point(108, 34)
        Me.txtItemCode.MaxLength = 250
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.ReadOnly = True
        Me.txtItemCode.Size = New System.Drawing.Size(135, 21)
        Me.txtItemCode.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(24, 65)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(71, 13)
        Me.lblName.TabIndex = 99
        Me.lblName.Text = "Nama Barang"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.Azure
        Me.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Location = New System.Drawing.Point(108, 62)
        Me.txtItemName.MaxLength = 250
        Me.txtItemName.Multiline = True
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(477, 48)
        Me.txtItemName.TabIndex = 2
        '
        'gcNewItem
        '
        Me.gcNewItem.Controls.Add(Me.txtLength)
        Me.gcNewItem.Controls.Add(Me.txtWidth)
        Me.gcNewItem.Controls.Add(Me.txtThick)
        Me.gcNewItem.Controls.Add(Me.Label10)
        Me.gcNewItem.Controls.Add(Me.Label9)
        Me.gcNewItem.Controls.Add(Me.Label8)
        Me.gcNewItem.Controls.Add(Me.Label6)
        Me.gcNewItem.Controls.Add(Me.Label5)
        Me.gcNewItem.Controls.Add(Me.Label4)
        Me.gcNewItem.Controls.Add(Me.Label1)
        Me.gcNewItem.Controls.Add(Me.btnItem)
        Me.gcNewItem.Controls.Add(Me.txtItemName)
        Me.gcNewItem.Controls.Add(Me.lblName)
        Me.gcNewItem.Controls.Add(Me.txtItemCode)
        Me.gcNewItem.Location = New System.Drawing.Point(24, 290)
        Me.gcNewItem.Name = "gcNewItem"
        Me.gcNewItem.Size = New System.Drawing.Size(646, 216)
        Me.gcNewItem.TabIndex = 3
        Me.gcNewItem.Text = "Baru"
        '
        'txtLength
        '
        Me.txtLength.BackColor = System.Drawing.Color.Azure
        Me.txtLength.DecimalPlaces = 2
        Me.txtLength.Enabled = False
        Me.txtLength.Location = New System.Drawing.Point(108, 170)
        Me.txtLength.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLength.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(135, 21)
        Me.txtLength.TabIndex = 5
        Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLength.ThousandsSeparator = True
        '
        'txtWidth
        '
        Me.txtWidth.BackColor = System.Drawing.Color.Azure
        Me.txtWidth.DecimalPlaces = 2
        Me.txtWidth.Enabled = False
        Me.txtWidth.Location = New System.Drawing.Point(108, 143)
        Me.txtWidth.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidth.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(135, 21)
        Me.txtWidth.TabIndex = 4
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidth.ThousandsSeparator = True
        '
        'txtThick
        '
        Me.txtThick.BackColor = System.Drawing.Color.Azure
        Me.txtThick.DecimalPlaces = 2
        Me.txtThick.Enabled = False
        Me.txtThick.Location = New System.Drawing.Point(108, 116)
        Me.txtThick.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThick.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThick.Name = "txtThick"
        Me.txtThick.Size = New System.Drawing.Size(135, 21)
        Me.txtThick.TabIndex = 3
        Me.txtThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThick.ThousandsSeparator = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(249, 174)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "mm"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(249, 147)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(249, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "mm"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(24, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Panjang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Lebar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(24, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "Tebal"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtLengthOld)
        Me.GroupControl1.Controls.Add(Me.txtWidthOld)
        Me.GroupControl1.Controls.Add(Me.txtThickOld)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.Label12)
        Me.GroupControl1.Controls.Add(Me.Label13)
        Me.GroupControl1.Controls.Add(Me.Label14)
        Me.GroupControl1.Controls.Add(Me.Label15)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.txtItemNameOld)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.txtItemCodeOld)
        Me.GroupControl1.Location = New System.Drawing.Point(24, 69)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(646, 210)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Saat ini"
        '
        'txtLengthOld
        '
        Me.txtLengthOld.BackColor = System.Drawing.Color.Azure
        Me.txtLengthOld.DecimalPlaces = 2
        Me.txtLengthOld.Enabled = False
        Me.txtLengthOld.Location = New System.Drawing.Point(108, 170)
        Me.txtLengthOld.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLengthOld.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLengthOld.Name = "txtLengthOld"
        Me.txtLengthOld.Size = New System.Drawing.Size(135, 21)
        Me.txtLengthOld.TabIndex = 4
        Me.txtLengthOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLengthOld.ThousandsSeparator = True
        '
        'txtWidthOld
        '
        Me.txtWidthOld.BackColor = System.Drawing.Color.Azure
        Me.txtWidthOld.DecimalPlaces = 2
        Me.txtWidthOld.Enabled = False
        Me.txtWidthOld.Location = New System.Drawing.Point(108, 143)
        Me.txtWidthOld.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidthOld.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidthOld.Name = "txtWidthOld"
        Me.txtWidthOld.Size = New System.Drawing.Size(135, 21)
        Me.txtWidthOld.TabIndex = 3
        Me.txtWidthOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidthOld.ThousandsSeparator = True
        '
        'txtThickOld
        '
        Me.txtThickOld.BackColor = System.Drawing.Color.Azure
        Me.txtThickOld.DecimalPlaces = 2
        Me.txtThickOld.Enabled = False
        Me.txtThickOld.Location = New System.Drawing.Point(108, 116)
        Me.txtThickOld.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThickOld.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThickOld.Name = "txtThickOld"
        Me.txtThickOld.Size = New System.Drawing.Size(135, 21)
        Me.txtThickOld.TabIndex = 2
        Me.txtThickOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThickOld.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(249, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "mm"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(249, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "mm"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(249, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "mm"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(24, 174)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "Panjang"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(24, 147)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Lebar"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(24, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "Tebal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Kode Barang"
        '
        'txtItemNameOld
        '
        Me.txtItemNameOld.BackColor = System.Drawing.Color.Azure
        Me.txtItemNameOld.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemNameOld.Location = New System.Drawing.Point(108, 62)
        Me.txtItemNameOld.MaxLength = 250
        Me.txtItemNameOld.Multiline = True
        Me.txtItemNameOld.Name = "txtItemNameOld"
        Me.txtItemNameOld.ReadOnly = True
        Me.txtItemNameOld.Size = New System.Drawing.Size(477, 48)
        Me.txtItemNameOld.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(24, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Nama Barang"
        '
        'txtItemCodeOld
        '
        Me.txtItemCodeOld.BackColor = System.Drawing.Color.Azure
        Me.txtItemCodeOld.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCodeOld.Location = New System.Drawing.Point(108, 34)
        Me.txtItemCodeOld.MaxLength = 250
        Me.txtItemCodeOld.Name = "txtItemCodeOld"
        Me.txtItemCodeOld.ReadOnly = True
        Me.txtItemCodeOld.Size = New System.Drawing.Size(135, 21)
        Me.txtItemCodeOld.TabIndex = 0
        '
        'frmTraOrderRequestDetChangeItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 524)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.gcNewItem)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraOrderRequestDetChangeItem"
        Me.Text = "Ubah Barang"
        CType(Me.gcNewItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcNewItem.ResumeLayout(False)
        Me.gcNewItem.PerformLayout()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtLengthOld, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidthOld, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThickOld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents btnItem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As ERPS.usTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtItemName As ERPS.usTextBox
    Friend WithEvents gcNewItem As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtItemNameOld As ERPS.usTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItemCodeOld As ERPS.usTextBox
    Friend WithEvents txtLength As ERPS.usNumeric
    Friend WithEvents txtWidth As ERPS.usNumeric
    Friend WithEvents txtThick As ERPS.usNumeric
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLengthOld As ERPS.usNumeric
    Friend WithEvents txtWidthOld As ERPS.usNumeric
    Friend WithEvents txtThickOld As ERPS.usNumeric
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
