<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraTransporterPriceListDetItem
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSource = New ERPS.usComboBoxEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDestination = New ERPS.usComboBoxEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UsNumeric1 = New ERPS.usNumeric()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.cboSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDestination.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsNumeric1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(501, 28)
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(501, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "« Lokasi Pengiriman"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSource
        '
        Me.cboSource.Location = New System.Drawing.Point(109, 76)
        Me.cboSource.Name = "cboSource"
        Me.cboSource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSource.Properties.PopupSizeable = True
        Me.cboSource.Size = New System.Drawing.Size(300, 20)
        Me.cboSource.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Lokasi Asal"
        '
        'cboDestination
        '
        Me.cboDestination.Location = New System.Drawing.Point(109, 102)
        Me.cboDestination.Name = "cboDestination"
        Me.cboDestination.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDestination.Properties.PopupSizeable = True
        Me.cboDestination.Size = New System.Drawing.Size(300, 20)
        Me.cboDestination.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Lokasi Tujuan"
        '
        'UsNumeric1
        '
        Me.UsNumeric1.Location = New System.Drawing.Point(109, 128)
        Me.UsNumeric1.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.UsNumeric1.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.UsNumeric1.Name = "UsNumeric1"
        Me.UsNumeric1.Size = New System.Drawing.Size(120, 21)
        Me.UsNumeric1.TabIndex = 4
        Me.UsNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.UsNumeric1.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(25, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "Harga Satuan"
        '
        'frmTraTransporterPriceListDetItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 178)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.UsNumeric1)
        Me.Controls.Add(Me.cboDestination)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraTransporterPriceListDetItem"
        Me.Text = "Lokasi Pengiriman"
        CType(Me.cboSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDestination.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsNumeric1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSource As ERPS.usComboBoxEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDestination As ERPS.usComboBoxEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UsNumeric1 As ERPS.usNumeric
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
