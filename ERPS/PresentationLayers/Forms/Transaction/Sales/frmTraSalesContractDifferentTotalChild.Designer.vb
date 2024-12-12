<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSalesContractDifferentTotalChild
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
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpF1 = New System.Windows.Forms.TabPage()
        Me.grdMainF1 = New DevExpress.XtraGrid.GridControl()
        Me.grdViewF1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBarF1 = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.tpF2 = New System.Windows.Forms.TabPage()
        Me.grdMainF2 = New DevExpress.XtraGrid.GridControl()
        Me.grdViewF2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBarF2 = New ERPS.usToolBar()
        Me.BarRefreshF2 = New System.Windows.Forms.ToolBarButton()
        Me.BarCloseF2 = New System.Windows.Forms.ToolBarButton()
        Me.tpF3 = New System.Windows.Forms.TabPage()
        Me.grdMainF3 = New DevExpress.XtraGrid.GridControl()
        Me.grdViewF3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBarF3 = New ERPS.usToolBar()
        Me.BarRefreshF3 = New System.Windows.Forms.ToolBarButton()
        Me.BarCloseF3 = New System.Windows.Forms.ToolBarButton()
        Me.tcMain.SuspendLayout()
        Me.tpF1.SuspendLayout()
        CType(Me.grdMainF1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpF2.SuspendLayout()
        CType(Me.grdMainF2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewF2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpF3.SuspendLayout()
        CType(Me.grdMainF3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewF3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 584)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(1080, 23)
        Me.pgMain.TabIndex = 4
        '
        'tcMain
        '
        Me.tcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcMain.Controls.Add(Me.tpF1)
        Me.tcMain.Controls.Add(Me.tpF2)
        Me.tcMain.Controls.Add(Me.tpF3)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(1080, 584)
        Me.tcMain.TabIndex = 0
        '
        'tpF1
        '
        Me.tpF1.Controls.Add(Me.grdMainF1)
        Me.tpF1.Controls.Add(Me.ToolBarF1)
        Me.tpF1.Location = New System.Drawing.Point(4, 25)
        Me.tpF1.Name = "tpF1"
        Me.tpF1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpF1.Size = New System.Drawing.Size(1072, 555)
        Me.tpF1.TabIndex = 0
        Me.tpF1.Text = "Selisih Subcoil Kontrak vs Subcoil Konfirmasi Pesanan - F1"
        Me.tpF1.UseVisualStyleBackColor = True
        '
        'grdMainF1
        '
        Me.grdMainF1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMainF1.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdMainF1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdMainF1.Location = New System.Drawing.Point(3, 31)
        Me.grdMainF1.MainView = Me.grdViewF1
        Me.grdMainF1.Name = "grdMainF1"
        Me.grdMainF1.Size = New System.Drawing.Size(1066, 521)
        Me.grdMainF1.TabIndex = 2
        Me.grdMainF1.UseEmbeddedNavigator = True
        Me.grdMainF1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewF1})
        '
        'grdViewF1
        '
        Me.grdViewF1.GridControl = Me.grdMainF1
        Me.grdViewF1.Name = "grdViewF1"
        Me.grdViewF1.OptionsBehavior.AutoExpandAllGroups = True
        Me.grdViewF1.OptionsView.ColumnAutoWidth = False
        Me.grdViewF1.OptionsView.ShowAutoFilterRow = True
        Me.grdViewF1.OptionsView.ShowFooter = True
        '
        'ToolBarF1
        '
        Me.ToolBarF1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarF1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBarF1.DropDownArrows = True
        Me.ToolBarF1.Location = New System.Drawing.Point(3, 3)
        Me.ToolBarF1.Name = "ToolBarF1"
        Me.ToolBarF1.ShowToolTips = True
        Me.ToolBarF1.Size = New System.Drawing.Size(1066, 28)
        Me.ToolBarF1.TabIndex = 1
        Me.ToolBarF1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarRefresh
        '
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.Tag = "Refresh"
        Me.BarRefresh.Text = "Refresh"
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Tag = "Close"
        Me.BarClose.Text = "Tutup"
        '
        'tpF2
        '
        Me.tpF2.Controls.Add(Me.grdMainF2)
        Me.tpF2.Controls.Add(Me.ToolBarF2)
        Me.tpF2.Location = New System.Drawing.Point(4, 25)
        Me.tpF2.Name = "tpF2"
        Me.tpF2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpF2.Size = New System.Drawing.Size(1072, 555)
        Me.tpF2.TabIndex = 1
        Me.tpF2.Text = "Selisih Barang Utama vs Subcoil - F2"
        Me.tpF2.UseVisualStyleBackColor = True
        '
        'grdMainF2
        '
        Me.grdMainF2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMainF2.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdMainF2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdMainF2.Location = New System.Drawing.Point(3, 31)
        Me.grdMainF2.MainView = Me.grdViewF2
        Me.grdMainF2.Name = "grdMainF2"
        Me.grdMainF2.Size = New System.Drawing.Size(1066, 521)
        Me.grdMainF2.TabIndex = 3
        Me.grdMainF2.UseEmbeddedNavigator = True
        Me.grdMainF2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewF2})
        '
        'grdViewF2
        '
        Me.grdViewF2.GridControl = Me.grdMainF2
        Me.grdViewF2.Name = "grdViewF2"
        Me.grdViewF2.OptionsBehavior.AutoExpandAllGroups = True
        Me.grdViewF2.OptionsView.ColumnAutoWidth = False
        Me.grdViewF2.OptionsView.ShowAutoFilterRow = True
        Me.grdViewF2.OptionsView.ShowFooter = True
        '
        'ToolBarF2
        '
        Me.ToolBarF2.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarF2.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefreshF2, Me.BarCloseF2})
        Me.ToolBarF2.DropDownArrows = True
        Me.ToolBarF2.Location = New System.Drawing.Point(3, 3)
        Me.ToolBarF2.Name = "ToolBarF2"
        Me.ToolBarF2.ShowToolTips = True
        Me.ToolBarF2.Size = New System.Drawing.Size(1066, 28)
        Me.ToolBarF2.TabIndex = 2
        Me.ToolBarF2.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarRefreshF2
        '
        Me.BarRefreshF2.Name = "BarRefreshF2"
        Me.BarRefreshF2.Tag = "Refresh"
        Me.BarRefreshF2.Text = "Refresh"
        '
        'BarCloseF2
        '
        Me.BarCloseF2.Name = "BarCloseF2"
        Me.BarCloseF2.Tag = "Close"
        Me.BarCloseF2.Text = "Tutup"
        '
        'tpF3
        '
        Me.tpF3.Controls.Add(Me.grdMainF3)
        Me.tpF3.Controls.Add(Me.ToolBarF3)
        Me.tpF3.Location = New System.Drawing.Point(4, 25)
        Me.tpF3.Name = "tpF3"
        Me.tpF3.Padding = New System.Windows.Forms.Padding(3)
        Me.tpF3.Size = New System.Drawing.Size(1072, 555)
        Me.tpF3.TabIndex = 2
        Me.tpF3.Text = "Selisih Barang Utama vs Subcoil KO - F3"
        Me.tpF3.UseVisualStyleBackColor = True
        '
        'grdMainF3
        '
        Me.grdMainF3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMainF3.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdMainF3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdMainF3.Location = New System.Drawing.Point(3, 31)
        Me.grdMainF3.MainView = Me.grdViewF3
        Me.grdMainF3.Name = "grdMainF3"
        Me.grdMainF3.Size = New System.Drawing.Size(1066, 521)
        Me.grdMainF3.TabIndex = 1
        Me.grdMainF3.UseEmbeddedNavigator = True
        Me.grdMainF3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewF3})
        '
        'grdViewF3
        '
        Me.grdViewF3.GridControl = Me.grdMainF3
        Me.grdViewF3.Name = "grdViewF3"
        Me.grdViewF3.OptionsBehavior.AutoExpandAllGroups = True
        Me.grdViewF3.OptionsView.ColumnAutoWidth = False
        Me.grdViewF3.OptionsView.ShowAutoFilterRow = True
        Me.grdViewF3.OptionsView.ShowFooter = True
        '
        'ToolBarF3
        '
        Me.ToolBarF3.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarF3.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefreshF3, Me.BarCloseF3})
        Me.ToolBarF3.DropDownArrows = True
        Me.ToolBarF3.Location = New System.Drawing.Point(3, 3)
        Me.ToolBarF3.Name = "ToolBarF3"
        Me.ToolBarF3.ShowToolTips = True
        Me.ToolBarF3.Size = New System.Drawing.Size(1066, 28)
        Me.ToolBarF3.TabIndex = 0
        Me.ToolBarF3.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarRefreshF3
        '
        Me.BarRefreshF3.Name = "BarRefreshF3"
        Me.BarRefreshF3.Tag = "Refresh"
        Me.BarRefreshF3.Text = "Refresh"
        '
        'BarCloseF3
        '
        Me.BarCloseF3.Name = "BarCloseF3"
        Me.BarCloseF3.Tag = "Close"
        Me.BarCloseF3.Text = "Tutup"
        '
        'frmTraSalesContractDifferentTotalChild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 607)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.pgMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmTraSalesContractDifferentTotalChild"
        Me.Text = "List Data Selisih Subcoil Kontrak vs Subcoil Konfirmasi Pesanan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcMain.ResumeLayout(False)
        Me.tpF1.ResumeLayout(False)
        Me.tpF1.PerformLayout()
        CType(Me.grdMainF1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpF2.ResumeLayout(False)
        Me.tpF2.PerformLayout()
        CType(Me.grdMainF2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewF2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpF3.ResumeLayout(False)
        Me.tpF3.PerformLayout()
        CType(Me.grdMainF3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewF3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tpF1 As System.Windows.Forms.TabPage
    Friend WithEvents grdMainF1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewF1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolBarF1 As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents tpF2 As System.Windows.Forms.TabPage
    Friend WithEvents grdMainF2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewF2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolBarF2 As ERPS.usToolBar
    Friend WithEvents BarRefreshF2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarCloseF2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tpF3 As System.Windows.Forms.TabPage
    Friend WithEvents grdMainF3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewF3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolBarF3 As ERPS.usToolBar
    Friend WithEvents BarRefreshF3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarCloseF3 As System.Windows.Forms.ToolBarButton
End Class
