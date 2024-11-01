<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraDeliveryPrint
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
        Me.BarPreview = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.gboType = New System.Windows.Forms.GroupBox()
        Me.rdSKBDN = New System.Windows.Forms.RadioButton()
        Me.rdDefault = New System.Windows.Forms.RadioButton()
        Me.gboType.SuspendLayout()
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
        Me.ToolBar.Size = New System.Drawing.Size(295, 28)
        Me.ToolBar.TabIndex = 0
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
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(295, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Pengiriman"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gboType
        '
        Me.gboType.Controls.Add(Me.rdSKBDN)
        Me.gboType.Controls.Add(Me.rdDefault)
        Me.gboType.Location = New System.Drawing.Point(33, 67)
        Me.gboType.Name = "gboType"
        Me.gboType.Size = New System.Drawing.Size(203, 72)
        Me.gboType.TabIndex = 2
        Me.gboType.TabStop = False
        Me.gboType.Text = "Tipe"
        '
        'rdSKBDN
        '
        Me.rdSKBDN.AutoSize = True
        Me.rdSKBDN.Location = New System.Drawing.Point(105, 30)
        Me.rdSKBDN.Name = "rdSKBDN"
        Me.rdSKBDN.Size = New System.Drawing.Size(42, 17)
        Me.rdSKBDN.TabIndex = 1
        Me.rdSKBDN.Text = "Coil"
        Me.rdSKBDN.UseVisualStyleBackColor = True
        '
        'rdDefault
        '
        Me.rdDefault.AutoSize = True
        Me.rdDefault.Checked = True
        Me.rdDefault.Location = New System.Drawing.Point(33, 30)
        Me.rdDefault.Name = "rdDefault"
        Me.rdDefault.Size = New System.Drawing.Size(43, 17)
        Me.rdDefault.TabIndex = 0
        Me.rdDefault.TabStop = True
        Me.rdDefault.Text = "Plat"
        Me.rdDefault.UseVisualStyleBackColor = True
        '
        'frmTraDeliveryPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 174)
        Me.Controls.Add(Me.gboType)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraDeliveryPrint"
        Me.Text = "Cetak Pengiriman"
        Me.gboType.ResumeLayout(False)
        Me.gboType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarPreview As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents gboType As System.Windows.Forms.GroupBox
    Friend WithEvents rdSKBDN As System.Windows.Forms.RadioButton
    Friend WithEvents rdDefault As System.Windows.Forms.RadioButton
End Class
