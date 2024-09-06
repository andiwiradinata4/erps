<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraOrderRequestMapConfirmationOrder
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.grdSubItemCOView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdItemCO = New DevExpress.XtraGrid.GridControl()
        Me.grdItemCOView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarItemOrderRequest = New ERPS.usToolBar()
        Me.BarMap = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolBarItemCO = New ERPS.usToolBar()
        Me.BarEditItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDeleteItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        CType(Me.grdSubItemCOView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemCOView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdSubItemCOView
        '
        Me.grdSubItemCOView.GridControl = Me.grdItemCO
        Me.grdSubItemCOView.Name = "grdSubItemCOView"
        Me.grdSubItemCOView.OptionsCustomization.AllowGroup = False
        Me.grdSubItemCOView.OptionsView.ColumnAutoWidth = False
        Me.grdSubItemCOView.OptionsView.ShowFooter = True
        Me.grdSubItemCOView.OptionsView.ShowGroupPanel = False
        '
        'grdItemCO
        '
        Me.grdItemCO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdItemCO.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdItemCO.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.grdSubItemCOView
        GridLevelNode1.RelationName = "SubView"
        Me.grdItemCO.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdItemCO.Location = New System.Drawing.Point(607, 76)
        Me.grdItemCO.MainView = Me.grdItemCOView
        Me.grdItemCO.Name = "grdItemCO"
        Me.grdItemCO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.grdItemCO.Size = New System.Drawing.Size(642, 316)
        Me.grdItemCO.TabIndex = 3
        Me.grdItemCO.UseEmbeddedNavigator = True
        Me.grdItemCO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemCOView, Me.grdSubItemCOView})
        '
        'grdItemCOView
        '
        Me.grdItemCOView.GridControl = Me.grdItemCO
        Me.grdItemCOView.Name = "grdItemCOView"
        Me.grdItemCOView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemCOView.OptionsCustomization.AllowGroup = False
        Me.grdItemCOView.OptionsView.ColumnAutoWidth = False
        Me.grdItemCOView.OptionsView.ShowAutoFilterRow = True
        Me.grdItemCOView.OptionsView.ShowFooter = True
        Me.grdItemCOView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "0.00"
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(1249, 28)
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
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grdItem)
        Me.pnlDetail.Controls.Add(Me.ToolBarItemOrderRequest)
        Me.pnlDetail.Controls.Add(Me.lblInfo)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDetail.Location = New System.Drawing.Point(0, 28)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(607, 364)
        Me.pnlDetail.TabIndex = 2
        '
        'grdItem
        '
        Me.grdItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdItem.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdItem.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdItem.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdItem.Location = New System.Drawing.Point(0, 48)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItem.Size = New System.Drawing.Size(607, 316)
        Me.grdItem.TabIndex = 2
        Me.grdItem.UseEmbeddedNavigator = True
        Me.grdItem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemView})
        '
        'grdItemView
        '
        Me.grdItemView.GridControl = Me.grdItem
        Me.grdItemView.Name = "grdItemView"
        Me.grdItemView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemView.OptionsCustomization.AllowGroup = False
        Me.grdItemView.OptionsView.ColumnAutoWidth = False
        Me.grdItemView.OptionsView.ShowAutoFilterRow = True
        Me.grdItemView.OptionsView.ShowFooter = True
        Me.grdItemView.OptionsView.ShowGroupPanel = False
        '
        'rpiValue
        '
        Me.rpiValue.AutoHeight = False
        Me.rpiValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiValue.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiValue.Name = "rpiValue"
        Me.rpiValue.NullText = "0.00"
        '
        'ToolBarItemOrderRequest
        '
        Me.ToolBarItemOrderRequest.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItemOrderRequest.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarMap})
        Me.ToolBarItemOrderRequest.Divider = False
        Me.ToolBarItemOrderRequest.DropDownArrows = True
        Me.ToolBarItemOrderRequest.Location = New System.Drawing.Point(0, 22)
        Me.ToolBarItemOrderRequest.Name = "ToolBarItemOrderRequest"
        Me.ToolBarItemOrderRequest.ShowToolTips = True
        Me.ToolBarItemOrderRequest.Size = New System.Drawing.Size(607, 26)
        Me.ToolBarItemOrderRequest.TabIndex = 1
        Me.ToolBarItemOrderRequest.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarMap
        '
        Me.BarMap.Name = "BarMap"
        Me.BarMap.Tag = "Approved"
        Me.BarMap.Text = "Map Konfirmasi Pesanan"
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(607, 22)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "« Permintaan Penjualan"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.CadetBlue
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(607, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(642, 22)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "« Konfirmasi Pesanan"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarItemCO
        '
        Me.ToolBarItemCO.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItemCO.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarEditItemOrder, Me.BarDeleteItemOrder})
        Me.ToolBarItemCO.Divider = False
        Me.ToolBarItemCO.DropDownArrows = True
        Me.ToolBarItemCO.Location = New System.Drawing.Point(607, 50)
        Me.ToolBarItemCO.Name = "ToolBarItemCO"
        Me.ToolBarItemCO.ShowToolTips = True
        Me.ToolBarItemCO.Size = New System.Drawing.Size(642, 26)
        Me.ToolBarItemCO.TabIndex = 2
        Me.ToolBarItemCO.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarEditItemOrder
        '
        Me.BarEditItemOrder.Name = "BarEditItemOrder"
        Me.BarEditItemOrder.Tag = "Edit"
        Me.BarEditItemOrder.Text = "Edit"
        '
        'BarDeleteItemOrder
        '
        Me.BarDeleteItemOrder.Name = "BarDeleteItemOrder"
        Me.BarDeleteItemOrder.Tag = "Delete"
        Me.BarDeleteItemOrder.Text = "Hapus"
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 392)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(1249, 23)
        Me.pgMain.TabIndex = 8
        '
        'frmTraOrderRequestMapConfirmationOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1249, 415)
        Me.Controls.Add(Me.grdItemCO)
        Me.Controls.Add(Me.ToolBarItemCO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Controls.Add(Me.pgMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraOrderRequestMapConfirmationOrder"
        Me.Text = "Permintaan Penjualan"
        CType(Me.grdSubItemCOView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemCOView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolBarItemCO As ERPS.usToolBar
    Friend WithEvents BarEditItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeleteItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdItemCO As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdSubItemCOView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdItemCOView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ToolBarItemOrderRequest As ERPS.usToolBar
    Friend WithEvents BarMap As System.Windows.Forms.ToolBarButton
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
End Class
