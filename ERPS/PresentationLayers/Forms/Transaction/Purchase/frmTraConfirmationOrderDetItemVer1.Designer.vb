<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraConfirmationOrderDetItemVer1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraConfirmationOrderDetItemVer1))
        Me.grdSubItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.btnDeliveryAddress = New DevExpress.XtraEditors.SimpleButton()
        Me.txtOrderNumberSupplier = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDeliveryAddress = New ERPS.usTextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolBarItemOrder = New ERPS.usToolBar()
        Me.BarAddItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarEditItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDeleteItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.chkGenerate = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.grdSubItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.chkGenerate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdSubItemView
        '
        Me.grdSubItemView.GridControl = Me.grdItem
        Me.grdSubItemView.Name = "grdSubItemView"
        Me.grdSubItemView.OptionsCustomization.AllowGroup = False
        Me.grdSubItemView.OptionsView.ColumnAutoWidth = False
        Me.grdSubItemView.OptionsView.ShowFooter = True
        Me.grdSubItemView.OptionsView.ShowGroupPanel = False
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
        GridLevelNode1.LevelTemplate = Me.grdSubItemView
        GridLevelNode1.RelationName = "SubView"
        Me.grdItem.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdItem.Location = New System.Drawing.Point(0, 224)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.grdItem.Size = New System.Drawing.Size(734, 437)
        Me.grdItem.TabIndex = 5
        Me.grdItem.UseEmbeddedNavigator = True
        Me.grdItem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemView, Me.GridView1, Me.grdSubItemView})
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
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "0.00"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdItem
        Me.GridView1.Name = "GridView1"
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(734, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(734, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Konfirmasi Pesanan"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.chkGenerate)
        Me.pnlDetail.Controls.Add(Me.btnDeliveryAddress)
        Me.pnlDetail.Controls.Add(Me.txtOrderNumberSupplier)
        Me.pnlDetail.Controls.Add(Me.Label13)
        Me.pnlDetail.Controls.Add(Me.txtDeliveryAddress)
        Me.pnlDetail.Controls.Add(Me.Label29)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(0, 50)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(734, 124)
        Me.pnlDetail.TabIndex = 2
        '
        'btnDeliveryAddress
        '
        Me.btnDeliveryAddress.Image = CType(resources.GetObject("btnDeliveryAddress.Image"), System.Drawing.Image)
        Me.btnDeliveryAddress.Location = New System.Drawing.Point(635, 43)
        Me.btnDeliveryAddress.Name = "btnDeliveryAddress"
        Me.btnDeliveryAddress.Size = New System.Drawing.Size(23, 23)
        Me.btnDeliveryAddress.TabIndex = 3
        '
        'txtOrderNumberSupplier
        '
        Me.txtOrderNumberSupplier.BackColor = System.Drawing.Color.White
        Me.txtOrderNumberSupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderNumberSupplier.Location = New System.Drawing.Point(173, 16)
        Me.txtOrderNumberSupplier.MaxLength = 250
        Me.txtOrderNumberSupplier.Name = "txtOrderNumberSupplier"
        Me.txtOrderNumberSupplier.Size = New System.Drawing.Size(169, 21)
        Me.txtOrderNumberSupplier.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(31, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 170
        Me.Label13.Text = "Alamat Pengiriman"
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.BackColor = System.Drawing.Color.White
        Me.txtDeliveryAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(173, 43)
        Me.txtDeliveryAddress.MaxLength = 250
        Me.txtDeliveryAddress.Multiline = True
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(456, 48)
        Me.txtDeliveryAddress.TabIndex = 2
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(31, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(127, 13)
        Me.Label29.TabIndex = 158
        Me.Label29.Text = "Nomor Pesanan Pemasok"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.CadetBlue
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(734, 22)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "« Barang"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarItemOrder
        '
        Me.ToolBarItemOrder.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItemOrder.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddItemOrder, Me.BarEditItemOrder, Me.BarDeleteItemOrder})
        Me.ToolBarItemOrder.DropDownArrows = True
        Me.ToolBarItemOrder.Location = New System.Drawing.Point(0, 196)
        Me.ToolBarItemOrder.Name = "ToolBarItemOrder"
        Me.ToolBarItemOrder.ShowToolTips = True
        Me.ToolBarItemOrder.Size = New System.Drawing.Size(734, 28)
        Me.ToolBarItemOrder.TabIndex = 4
        Me.ToolBarItemOrder.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAddItemOrder
        '
        Me.BarAddItemOrder.Name = "BarAddItemOrder"
        Me.BarAddItemOrder.Tag = "Add"
        Me.BarAddItemOrder.Text = "Tambah"
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
        'chkGenerate
        '
        Me.chkGenerate.Location = New System.Drawing.Point(350, 17)
        Me.chkGenerate.Name = "chkGenerate"
        Me.chkGenerate.Properties.Caption = "Generate ?"
        Me.chkGenerate.Size = New System.Drawing.Size(75, 19)
        Me.chkGenerate.TabIndex = 1
        '
        'frmTraConfirmationOrderDetItemVer1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 661)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.ToolBarItemOrder)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraConfirmationOrderDetItemVer1"
        Me.Text = "Barang"
        CType(Me.grdSubItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.chkGenerate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryAddress As ERPS.usTextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolBarItemOrder As ERPS.usToolBar
    Friend WithEvents BarAddItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarEditItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeleteItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtOrderNumberSupplier As ERPS.usTextBox
    Friend WithEvents btnDeliveryAddress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdSubItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkGenerate As DevExpress.XtraEditors.CheckEdit
End Class
