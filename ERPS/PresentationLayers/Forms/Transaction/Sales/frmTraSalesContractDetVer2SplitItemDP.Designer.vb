<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSalesContractDetVer2SplitItemDP
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtUnitPrice = New ERPS.usNumeric()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPPH = New ERPS.usNumeric()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPPN = New ERPS.usNumeric()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New ERPS.usNumeric()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPercentage = New ERPS.usNumeric()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalWeight = New ERPS.usNumeric()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWeight = New ERPS.usNumeric()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuantity = New ERPS.usNumeric()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalPrice = New ERPS.usNumeric()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New ERPS.usNumeric()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(689, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(689, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Split Down Payment Item"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtGrandTotal)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtTotalPrice)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtUnitPrice)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtPPH)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtPPN)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtTotalAmount)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtPercentage)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtTotalWeight)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtWeight)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtQuantity)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(689, 180)
        Me.Panel1.TabIndex = 2
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.Color.Azure
        Me.txtUnitPrice.DecimalPlaces = 2
        Me.txtUnitPrice.Enabled = False
        Me.txtUnitPrice.Location = New System.Drawing.Point(116, 101)
        Me.txtUnitPrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(170, 21)
        Me.txtUnitPrice.TabIndex = 3
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPrice.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(34, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 174
        Me.Label7.Text = "Harga"
        '
        'txtPPH
        '
        Me.txtPPH.BackColor = System.Drawing.Color.White
        Me.txtPPH.DecimalPlaces = 2
        Me.txtPPH.Location = New System.Drawing.Point(441, 101)
        Me.txtPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPPH.Name = "txtPPH"
        Me.txtPPH.Size = New System.Drawing.Size(170, 21)
        Me.txtPPH.TabIndex = 8
        Me.txtPPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPPH.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(359, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "Total PPH"
        '
        'txtPPN
        '
        Me.txtPPN.BackColor = System.Drawing.Color.White
        Me.txtPPN.DecimalPlaces = 2
        Me.txtPPN.Location = New System.Drawing.Point(441, 74)
        Me.txtPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPPN.Name = "txtPPN"
        Me.txtPPN.Size = New System.Drawing.Size(170, 21)
        Me.txtPPN.TabIndex = 7
        Me.txtPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPPN.ThousandsSeparator = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(359, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Total PPN"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.White
        Me.txtTotalAmount.DecimalPlaces = 2
        Me.txtTotalAmount.Location = New System.Drawing.Point(441, 47)
        Me.txtTotalAmount.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalAmount.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(170, 21)
        Me.txtTotalAmount.TabIndex = 6
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAmount.ThousandsSeparator = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(359, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "Total DPP"
        '
        'txtPercentage
        '
        Me.txtPercentage.BackColor = System.Drawing.Color.Azure
        Me.txtPercentage.DecimalPlaces = 2
        Me.txtPercentage.Enabled = False
        Me.txtPercentage.Location = New System.Drawing.Point(441, 20)
        Me.txtPercentage.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPercentage.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(96, 21)
        Me.txtPercentage.TabIndex = 5
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercentage.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(359, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 166
        Me.Label3.Text = "Persentase"
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BackColor = System.Drawing.Color.Azure
        Me.txtTotalWeight.DecimalPlaces = 2
        Me.txtTotalWeight.Enabled = False
        Me.txtTotalWeight.Location = New System.Drawing.Point(116, 74)
        Me.txtTotalWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.Size = New System.Drawing.Size(170, 21)
        Me.txtTotalWeight.TabIndex = 2
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalWeight.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "Total Berat"
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.Color.White
        Me.txtWeight.DecimalPlaces = 2
        Me.txtWeight.Location = New System.Drawing.Point(116, 47)
        Me.txtWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(170, 21)
        Me.txtWeight.TabIndex = 1
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWeight.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Berat"
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.White
        Me.txtQuantity.Location = New System.Drawing.Point(116, 20)
        Me.txtQuantity.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtQuantity.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(170, 21)
        Me.txtQuantity.TabIndex = 0
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQuantity.ThousandsSeparator = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(34, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 160
        Me.Label9.Text = "Jumlah"
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.BackColor = System.Drawing.Color.Azure
        Me.txtTotalPrice.DecimalPlaces = 2
        Me.txtTotalPrice.Enabled = False
        Me.txtTotalPrice.Location = New System.Drawing.Point(116, 128)
        Me.txtTotalPrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.Size = New System.Drawing.Size(170, 21)
        Me.txtTotalPrice.TabIndex = 4
        Me.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPrice.ThousandsSeparator = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(34, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 176
        Me.Label8.Text = "Total Harga"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.Azure
        Me.txtGrandTotal.DecimalPlaces = 2
        Me.txtGrandTotal.Enabled = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(441, 128)
        Me.txtGrandTotal.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotal.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Size = New System.Drawing.Size(170, 21)
        Me.txtGrandTotal.TabIndex = 9
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotal.ThousandsSeparator = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(359, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 178
        Me.Label10.Text = "Total Tagihan"
        '
        'frmTraSalesContractDetVer2SplitItemDP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 230)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraSalesContractDetVer2SplitItemDP"
        Me.Text = "Split Down Payment Item"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtWeight As ERPS.usNumeric
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As ERPS.usNumeric
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As ERPS.usNumeric
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPercentage As ERPS.usNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPPH As ERPS.usNumeric
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPPN As ERPS.usNumeric
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As ERPS.usNumeric
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As ERPS.usNumeric
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As ERPS.usNumeric
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotal As ERPS.usNumeric
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
