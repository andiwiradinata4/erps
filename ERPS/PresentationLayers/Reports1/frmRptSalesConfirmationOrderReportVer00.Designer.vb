<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptSalesConfirmationOrderReportVer00
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptSalesConfirmationOrderReportVer00))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarPreview = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.chkIsShowSize = New DevExpress.XtraEditors.CheckEdit()
        Me.cboItemType = New ERPS.usComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtBPCode = New ERPS.usTextBox()
        Me.txtBPName = New ERPS.usTextBox()
        Me.btnBP = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        CType(Me.chkIsShowSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarPreview, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(500, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarPreview
        '
        Me.BarPreview.Name = "BarPreview"
        Me.BarPreview.Tag = "Print"
        Me.BarPreview.Text = "Lihat Laporan"
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
        Me.lblInfo.Size = New System.Drawing.Size(500, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Laporan PO"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 180)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(500, 23)
        Me.pgMain.TabIndex = 3
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMain.Controls.Add(Me.chkIsShowSize)
        Me.pnlMain.Controls.Add(Me.cboItemType)
        Me.pnlMain.Controls.Add(Me.Label28)
        Me.pnlMain.Controls.Add(Me.txtBPCode)
        Me.pnlMain.Controls.Add(Me.txtBPName)
        Me.pnlMain.Controls.Add(Me.btnBP)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.dtpDateTo)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.dtpDateFrom)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 50)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(500, 130)
        Me.pnlMain.TabIndex = 2
        '
        'chkIsShowSize
        '
        Me.chkIsShowSize.Location = New System.Drawing.Point(236, 46)
        Me.chkIsShowSize.Name = "chkIsShowSize"
        Me.chkIsShowSize.Properties.Caption = "Munculkan Ukuran?"
        Me.chkIsShowSize.Size = New System.Drawing.Size(133, 19)
        Me.chkIsShowSize.TabIndex = 3
        '
        'cboItemType
        '
        Me.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemType.FormattingEnabled = True
        Me.cboItemType.Location = New System.Drawing.Point(109, 44)
        Me.cboItemType.Name = "cboItemType"
        Me.cboItemType.Size = New System.Drawing.Size(101, 21)
        Me.cboItemType.TabIndex = 2
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(24, 48)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 13)
        Me.Label28.TabIndex = 161
        Me.Label28.Text = "Barang"
        '
        'txtBPCode
        '
        Me.txtBPCode.BackColor = System.Drawing.Color.Azure
        Me.txtBPCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPCode.Location = New System.Drawing.Point(109, 71)
        Me.txtBPCode.MaxLength = 250
        Me.txtBPCode.Name = "txtBPCode"
        Me.txtBPCode.ReadOnly = True
        Me.txtBPCode.Size = New System.Drawing.Size(83, 21)
        Me.txtBPCode.TabIndex = 4
        '
        'txtBPName
        '
        Me.txtBPName.BackColor = System.Drawing.Color.Azure
        Me.txtBPName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPName.Location = New System.Drawing.Point(191, 71)
        Me.txtBPName.MaxLength = 250
        Me.txtBPName.Name = "txtBPName"
        Me.txtBPName.ReadOnly = True
        Me.txtBPName.Size = New System.Drawing.Size(211, 21)
        Me.txtBPName.TabIndex = 5
        '
        'btnBP
        '
        Me.btnBP.ImageOptions.Image = CType(resources.GetObject("btnBP.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBP.Location = New System.Drawing.Point(408, 70)
        Me.btnBP.Name = "btnBP"
        Me.btnBP.Size = New System.Drawing.Size(23, 23)
        Me.btnBP.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Pelanggan"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(236, 17)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(101, 21)
        Me.dtpDateTo.TabIndex = 1
        Me.dtpDateTo.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tanggal"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(109, 17)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(101, 21)
        Me.dtpDateFrom.TabIndex = 0
        Me.dtpDateFrom.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "-"
        '
        'frmRptSalesConfirmationOrderReportVer00
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 203)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Name = "frmRptSalesConfirmationOrderReportVer00"
        Me.Text = "Laporan Konfirmasi Pesanan Penjualan"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.chkIsShowSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarPreview As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents chkIsShowSize As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboItemType As ERPS.usComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtBPCode As ERPS.usTextBox
    Friend WithEvents txtBPName As ERPS.usTextBox
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
