<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMstItem))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarGet = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.BarNew = New System.Windows.Forms.ToolBarButton()
        Me.BarDetail = New System.Windows.Forms.ToolBarButton()
        Me.BarDelete = New System.Windows.Forms.ToolBarButton()
        Me.BarSep2 = New System.Windows.Forms.ToolBarButton()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.chkShowAll = New DevExpress.XtraEditors.CheckEdit()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.cboItemSpecification = New ERPS.usComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboItemType = New ERPS.usComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grdView = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.chkShowAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarGet, Me.BarSep1, Me.BarNew, Me.BarDetail, Me.BarDelete, Me.BarSep2, Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(984, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarGet
        '
        Me.BarGet.Name = "BarGet"
        Me.BarGet.Tag = "Get"
        Me.BarGet.Text = "Ambil"
        '
        'BarSep1
        '
        Me.BarSep1.Name = "BarSep1"
        Me.BarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarNew
        '
        Me.BarNew.Name = "BarNew"
        Me.BarNew.Tag = "New"
        Me.BarNew.Text = "Baru"
        '
        'BarDetail
        '
        Me.BarDetail.Name = "BarDetail"
        Me.BarDetail.Tag = "Detail"
        Me.BarDetail.Text = "Edit"
        '
        'BarDelete
        '
        Me.BarDelete.Name = "BarDelete"
        Me.BarDelete.Tag = "Delete"
        Me.BarDelete.Text = "Hapus"
        '
        'BarSep2
        '
        Me.BarSep2.Name = "BarSep2"
        Me.BarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
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
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.chkShowAll)
        Me.PanelControl1.Controls.Add(Me.btnClear)
        Me.PanelControl1.Controls.Add(Me.btnExecute)
        Me.PanelControl1.Controls.Add(Me.cboItemSpecification)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.cboItemType)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 28)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(984, 119)
        Me.PanelControl1.TabIndex = 1
        '
        'chkShowAll
        '
        Me.chkShowAll.Location = New System.Drawing.Point(336, 41)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.Properties.Caption = "Tampilankan Semua"
        Me.chkShowAll.Size = New System.Drawing.Size(150, 19)
        Me.chkShowAll.TabIndex = 2
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(497, 67)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(151, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        '
        'btnExecute
        '
        Me.btnExecute.Image = CType(resources.GetObject("btnExecute.Image"), System.Drawing.Image)
        Me.btnExecute.Location = New System.Drawing.Point(335, 67)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(151, 23)
        Me.btnExecute.TabIndex = 3
        Me.btnExecute.Text = "Execute"
        '
        'cboItemSpecification
        '
        Me.cboItemSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemSpecification.Enabled = False
        Me.cboItemSpecification.FormattingEnabled = True
        Me.cboItemSpecification.Location = New System.Drawing.Point(109, 67)
        Me.cboItemSpecification.Name = "cboItemSpecification"
        Me.cboItemSpecification.Size = New System.Drawing.Size(201, 21)
        Me.cboItemSpecification.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(57, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Spec"
        '
        'cboItemType
        '
        Me.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemType.Enabled = False
        Me.cboItemType.FormattingEnabled = True
        Me.cboItemType.Location = New System.Drawing.Point(109, 40)
        Me.cboItemType.Name = "cboItemType"
        Me.cboItemType.Size = New System.Drawing.Size(201, 21)
        Me.cboItemType.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(57, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Tipe"
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
        Me.grdMain.Location = New System.Drawing.Point(0, 147)
        Me.grdMain.MainView = Me.grdView
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(984, 465)
        Me.grdMain.TabIndex = 2
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
        'frmMstItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Name = "frmMstItem"
        Me.Text = "Barang"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.chkShowAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarGet As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetail As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboItemType As ERPS.usComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkShowAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExecute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboItemSpecification As ERPS.usComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
