<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptMonitoringProductTransactionVer00
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptMonitoringProductTransactionVer00))
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCompany = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New ERPS.usTextBox()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grdView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.BarExportExcel = New System.Windows.Forms.ToolBarButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 589)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(984, 23)
        Me.pgMain.TabIndex = 3
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarExportExcel, Me.BarSep1, Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(984, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Tag = "Close"
        Me.BarClose.Text = "Tutup"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.dtpDateFrom)
        Me.PanelControl1.Controls.Add(Me.dtpDateTo)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.btnCompany)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.txtCompanyName)
        Me.PanelControl1.Controls.Add(Me.btnClear)
        Me.PanelControl1.Controls.Add(Me.btnExecute)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 28)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(984, 120)
        Me.PanelControl1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Tanggal"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(125, 70)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(101, 21)
        Me.dtpDateFrom.TabIndex = 2
        Me.dtpDateFrom.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(252, 70)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(101, 21)
        Me.dtpDateTo.TabIndex = 3
        Me.dtpDateTo.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(234, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "-"
        '
        'btnCompany
        '
        Me.btnCompany.Image = CType(resources.GetObject("btnCompany.Image"), System.Drawing.Image)
        Me.btnCompany.Location = New System.Drawing.Point(441, 42)
        Me.btnCompany.Name = "btnCompany"
        Me.btnCompany.Size = New System.Drawing.Size(23, 23)
        Me.btnCompany.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(53, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Perusahaan"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BackColor = System.Drawing.Color.Azure
        Me.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompanyName.Location = New System.Drawing.Point(125, 43)
        Me.txtCompanyName.MaxLength = 250
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.ReadOnly = True
        Me.txtCompanyName.Size = New System.Drawing.Size(310, 21)
        Me.txtCompanyName.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(725, 69)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(151, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        '
        'btnExecute
        '
        Me.btnExecute.Image = CType(resources.GetObject("btnExecute.Image"), System.Drawing.Image)
        Me.btnExecute.Location = New System.Drawing.Point(563, 69)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(151, 23)
        Me.btnExecute.TabIndex = 5
        Me.btnExecute.Text = "Execute"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(29, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Query berdasarkan:"
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
        Me.grdMain.Location = New System.Drawing.Point(0, 148)
        Me.grdMain.MainView = Me.grdView
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(984, 441)
        Me.grdMain.TabIndex = 5
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdView})
        '
        'grdView
        '
        Me.grdView.GridControl = Me.grdMain
        Me.grdView.Name = "grdView"
        Me.grdView.OptionsBehavior.AutoExpandAllGroups = True
        Me.grdView.OptionsView.ColumnAutoWidth = False
        Me.grdView.OptionsView.ShowAutoFilterRow = True
        Me.grdView.OptionsView.ShowFooter = True
        '
        'BarRefresh
        '
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.Tag = "Refresh"
        Me.BarRefresh.Text = "Refresh"
        '
        'BarSep1
        '
        Me.BarSep1.Name = "BarSep1"
        Me.BarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarExportExcel
        '
        Me.BarExportExcel.Name = "BarExportExcel"
        Me.BarExportExcel.Tag = "Excel"
        Me.BarExportExcel.Text = "Export Excel"
        '
        'frmRptMonitoringProductTransactionVer00
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmRptMonitoringProductTransactionVer00"
        Me.Text = "Laporan Transaksi Barang"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCompany As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCompanyName As usTextBox
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExecute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarExportExcel As ToolBarButton
    Friend WithEvents BarSep1 As ToolBarButton
    Friend WithEvents BarRefresh As ToolBarButton
End Class
