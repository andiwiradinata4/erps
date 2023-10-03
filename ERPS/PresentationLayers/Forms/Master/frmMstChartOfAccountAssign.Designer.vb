<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstChartOfAccountAssign
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New ERPS.usTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCode = New ERPS.usTextBox()
        Me.ToolBarDet = New ERPS.usToolBar()
        Me.BarAddItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDetailItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDeleteItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grdView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1.SuspendLayout()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(613, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(613, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Assign"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(613, 94)
        Me.Panel1.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(18, 47)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(61, 13)
        Me.lblName.TabIndex = 99
        Me.lblName.Text = "Nama Akun"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.LightYellow
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Location = New System.Drawing.Point(91, 44)
        Me.txtName.MaxLength = 250
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(474, 21)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Kode Akun"
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.LightYellow
        Me.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCode.Location = New System.Drawing.Point(91, 17)
        Me.txtCode.MaxLength = 250
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(110, 21)
        Me.txtCode.TabIndex = 0
        '
        'ToolBarDet
        '
        Me.ToolBarDet.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDet.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddItemOrder, Me.BarDetailItemOrder, Me.BarDeleteItemOrder})
        Me.ToolBarDet.DropDownArrows = True
        Me.ToolBarDet.Location = New System.Drawing.Point(0, 144)
        Me.ToolBarDet.Name = "ToolBarDet"
        Me.ToolBarDet.ShowToolTips = True
        Me.ToolBarDet.Size = New System.Drawing.Size(613, 28)
        Me.ToolBarDet.TabIndex = 3
        Me.ToolBarDet.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAddItemOrder
        '
        Me.BarAddItemOrder.Name = "BarAddItemOrder"
        Me.BarAddItemOrder.Tag = "Add"
        Me.BarAddItemOrder.Text = "Tambah"
        '
        'BarDetailItemOrder
        '
        Me.BarDetailItemOrder.Name = "BarDetailItemOrder"
        Me.BarDetailItemOrder.Tag = "Edit"
        Me.BarDetailItemOrder.Text = "Edit"
        '
        'BarDeleteItemOrder
        '
        Me.BarDeleteItemOrder.Name = "BarDeleteItemOrder"
        Me.BarDeleteItemOrder.Tag = "Delete"
        Me.BarDeleteItemOrder.Text = "Hapus"
        '
        'grdMain
        '
        Me.grdMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMain.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdMain.Location = New System.Drawing.Point(0, 172)
        Me.grdMain.MainView = Me.grdView
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(613, 227)
        Me.grdMain.TabIndex = 4
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdView})
        '
        'grdView
        '
        Me.grdView.GridControl = Me.grdMain
        Me.grdView.Name = "grdView"
        Me.grdView.OptionsCustomization.AllowColumnMoving = False
        Me.grdView.OptionsCustomization.AllowGroup = False
        Me.grdView.OptionsView.ColumnAutoWidth = False
        Me.grdView.OptionsView.ShowAutoFilterRow = True
        Me.grdView.OptionsView.ShowGroupPanel = False
        '
        'frmMstChartOfAccountAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 399)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.ToolBarDet)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMstChartOfAccountAssign"
        Me.Text = "Assign Akun Perkiraan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As ERPS.usTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCode As ERPS.usTextBox
    Friend WithEvents ToolBarDet As ERPS.usToolBar
    Friend WithEvents BarAddItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetailItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeleteItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
