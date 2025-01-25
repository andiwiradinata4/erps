<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraDeliveryDetMultiItemVer01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraDeliveryDetMultiItemVer01))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.btnItemCustom = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOrderNumberSupplier = New ERPS.usTextBox()
        Me.btnItem = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(602, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
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
        Me.lblInfo.Size = New System.Drawing.Size(602, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Pengiriman Penjualan"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.btnItemCustom)
        Me.pnlDetail.Controls.Add(Me.Label5)
        Me.pnlDetail.Controls.Add(Me.txtOrderNumberSupplier)
        Me.pnlDetail.Controls.Add(Me.btnItem)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(0, 50)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(602, 69)
        Me.pnlDetail.TabIndex = 2
        '
        'btnItemCustom
        '
        Me.btnItemCustom.Image = CType(resources.GetObject("btnItemCustom.Image"), System.Drawing.Image)
        Me.btnItemCustom.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnItemCustom.Location = New System.Drawing.Point(382, 15)
        Me.btnItemCustom.Name = "btnItemCustom"
        Me.btnItemCustom.Size = New System.Drawing.Size(190, 23)
        Me.btnItemCustom.TabIndex = 3
        Me.btnItemCustom.Text = "Pilih Barang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(27, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 195
        Me.Label5.Text = "Nomor Pesanan Pemasok"
        '
        'txtOrderNumberSupplier
        '
        Me.txtOrderNumberSupplier.BackColor = System.Drawing.Color.Azure
        Me.txtOrderNumberSupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderNumberSupplier.Location = New System.Drawing.Point(166, 17)
        Me.txtOrderNumberSupplier.MaxLength = 250
        Me.txtOrderNumberSupplier.Name = "txtOrderNumberSupplier"
        Me.txtOrderNumberSupplier.ReadOnly = True
        Me.txtOrderNumberSupplier.Size = New System.Drawing.Size(170, 21)
        Me.txtOrderNumberSupplier.TabIndex = 0
        '
        'btnItem
        '
        Me.btnItem.Image = CType(resources.GetObject("btnItem.Image"), System.Drawing.Image)
        Me.btnItem.Location = New System.Drawing.Point(341, 15)
        Me.btnItem.Name = "btnItem"
        Me.btnItem.Size = New System.Drawing.Size(23, 23)
        Me.btnItem.TabIndex = 1
        '
        'frmTraDeliveryDetMultiItemVer01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 119)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraDeliveryDetMultiItemVer01"
        Me.Text = "Pengiriman Penjualan"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents btnItemCustom As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNumberSupplier As ERPS.usTextBox
    Friend WithEvents btnItem As DevExpress.XtraEditors.SimpleButton
End Class
