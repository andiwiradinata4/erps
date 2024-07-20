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
        Me.gboType.SuspendLayout()
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
        Me.lblInfo.Size = New System.Drawing.Size(321, 22)
        Me.lblInfo.TabIndex = 2
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
        Me.rdDefault.TabIndex = 3
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
        Me.rdSKBDN.TabIndex = 4
        Me.rdSKBDN.Text = "SKBDN"
        Me.rdSKBDN.UseVisualStyleBackColor = True
        '
        'gboType
        '
        Me.gboType.Controls.Add(Me.rdSKBDN)
        Me.gboType.Controls.Add(Me.rdDefault)
        Me.gboType.Location = New System.Drawing.Point(43, 64)
        Me.gboType.Name = "gboType"
        Me.gboType.Size = New System.Drawing.Size(218, 79)
        Me.gboType.TabIndex = 5
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
        Me.ToolBar.Size = New System.Drawing.Size(321, 28)
        Me.ToolBar.TabIndex = 1
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
        'frmTraSalesContractPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 167)
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
End Class
