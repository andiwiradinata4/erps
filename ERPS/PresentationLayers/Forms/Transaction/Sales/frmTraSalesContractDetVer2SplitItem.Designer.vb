<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSalesContractDetVer2SplitItem
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
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpSalesContract = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdSubitemSplit = New DevExpress.XtraGrid.GridControl()
        Me.grdSubitemSplitView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarItemSubitemSplit = New ERPS.usToolBar()
        Me.BarMoveSubItemSplit = New System.Windows.Forms.ToolBarButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUnitPriceHPPSplit = New ERPS.usNumeric()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtRequestNumberSplit = New ERPS.usTextBox()
        Me.txtLengthSplit = New ERPS.usNumeric()
        Me.txtWidthSplit = New ERPS.usNumeric()
        Me.txtThickSplit = New ERPS.usNumeric()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtMaxTotalWeightSplit = New ERPS.usNumeric()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtTotalPriceSplit = New ERPS.usNumeric()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtQuantitySplit = New ERPS.usNumeric()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtUnitPriceSplit = New ERPS.usNumeric()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtTotalWeightSplit = New ERPS.usNumeric()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtWeightSplit = New ERPS.usNumeric()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.cboItemSpecificationSplit = New ERPS.usComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cboItemTypeSplit = New ERPS.usComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtItemCodeSplit = New ERPS.usTextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtItemNameSplit = New ERPS.usTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdSubitem = New DevExpress.XtraGrid.GridControl()
        Me.grdSubitemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarItemSubitem = New ERPS.usToolBar()
        Me.BarMoveSubItem = New System.Windows.Forms.ToolBarButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtUnitPriceHPP = New ERPS.usNumeric()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRequestNumber = New ERPS.usTextBox()
        Me.txtLength = New ERPS.usNumeric()
        Me.txtWidth = New ERPS.usNumeric()
        Me.txtThick = New ERPS.usNumeric()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtMaxTotalWeight = New ERPS.usNumeric()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTotalPrice = New ERPS.usNumeric()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtQuantity = New ERPS.usNumeric()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New ERPS.usNumeric()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalWeight = New ERPS.usNumeric()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtWeight = New ERPS.usNumeric()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboItemSpecification = New ERPS.usComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboItemType = New ERPS.usComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtItemCode = New ERPS.usTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtItemName = New ERPS.usTextBox()
        Me.tpConfirmationOrder = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdSubItemCOSplit = New DevExpress.XtraGrid.GridControl()
        Me.grdSubItemCOSplitView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarItemCOSplit = New ERPS.usToolBar()
        Me.BarMoveItemOrderSplit = New System.Windows.Forms.ToolBarButton()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.txtOrderNumberSupplierCOSplit = New ERPS.usTextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.txtCONumberCOSplit = New ERPS.usTextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.txtTotalPriceCOSplit = New ERPS.usNumeric()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.txtQuantityCOSplit = New ERPS.usNumeric()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.txtUnitPriceCOSplit = New ERPS.usNumeric()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.txtTotalWeightCOSplit = New ERPS.usNumeric()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.cboItemSpecificationCOSplit = New ERPS.usComboBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.cboItemTypeCOSplit = New ERPS.usComboBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.txtItemCodeCOSplit = New ERPS.usTextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.txtItemNameCOSplit = New ERPS.usTextBox()
        Me.txtLengthCOSplit = New ERPS.usNumeric()
        Me.txtWidthCOSplit = New ERPS.usNumeric()
        Me.txtThickCOSplit = New ERPS.usNumeric()
        Me.txtMaxTotalWeightCOSplit = New ERPS.usNumeric()
        Me.txtWeightCOSplit = New ERPS.usNumeric()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdSubItemCO = New DevExpress.XtraGrid.GridControl()
        Me.grdSubItemCOView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarItemCO = New ERPS.usToolBar()
        Me.BarMoveItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtOrderNumberSupplierCO = New ERPS.usTextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtCONumberCO = New ERPS.usTextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtTotalPriceCO = New ERPS.usNumeric()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtQuantityCO = New ERPS.usNumeric()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtUnitPriceCO = New ERPS.usNumeric()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.txtTotalWeightCO = New ERPS.usNumeric()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.cboItemSpecificationCO = New ERPS.usComboBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.cboItemTypeCO = New ERPS.usComboBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.txtItemCodeCO = New ERPS.usTextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtItemNameCO = New ERPS.usTextBox()
        Me.txtLengthCO = New ERPS.usNumeric()
        Me.txtWidthCO = New ERPS.usNumeric()
        Me.txtThickCO = New ERPS.usNumeric()
        Me.txtMaxTotalWeightCO = New ERPS.usNumeric()
        Me.txtWeightCO = New ERPS.usNumeric()
        Me.tpDownPayment = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.grdDownPayment = New DevExpress.XtraGrid.GridControl()
        Me.grdDownPaymentView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarDP = New ERPS.usToolBar()
        Me.BarMoveDP = New System.Windows.Forms.ToolBarButton()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdDownPaymentSplit = New DevExpress.XtraGrid.GridControl()
        Me.grdDownPaymentSplitView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarDPSplit = New ERPS.usToolBar()
        Me.BarDeleteDPSplit = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tcHeader.SuspendLayout()
        Me.tpSalesContract.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdSubitemSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSubitemSplitView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.txtUnitPriceHPPSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLengthSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidthSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThickSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxTotalWeightSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPriceSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantitySplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUnitPriceSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalWeightSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeightSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdSubitem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSubitemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.txtUnitPriceHPP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxTotalWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpConfirmationOrder.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdSubItemCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSubItemCOSplitView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.txtTotalPriceCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantityCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUnitPriceCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalWeightCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLengthCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidthCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThickCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxTotalWeightCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeightCOSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.grdSubItemCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSubItemCOView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.txtTotalPriceCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantityCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUnitPriceCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalWeightCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLengthCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidthCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThickCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxTotalWeightCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeightCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDownPayment.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.grdDownPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDownPaymentView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        CType(Me.grdDownPaymentSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDownPaymentSplitView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(1164, 28)
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
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpSalesContract)
        Me.tcHeader.Controls.Add(Me.tpConfirmationOrder)
        Me.tcHeader.Controls.Add(Me.tpDownPayment)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(1164, 611)
        Me.tcHeader.TabIndex = 2
        '
        'tpSalesContract
        '
        Me.tpSalesContract.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpSalesContract.Controls.Add(Me.TableLayoutPanel1)
        Me.tpSalesContract.Location = New System.Drawing.Point(4, 25)
        Me.tpSalesContract.Name = "tpSalesContract"
        Me.tpSalesContract.Size = New System.Drawing.Size(1156, 582)
        Me.tpSalesContract.TabIndex = 0
        Me.tpSalesContract.Text = "Kontrak Penjualan - F1"
        Me.tpSalesContract.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1152, 578)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdSubitemSplit)
        Me.Panel2.Controls.Add(Me.ToolBarItemSubitemSplit)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(579, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(570, 572)
        Me.Panel2.TabIndex = 1
        '
        'grdSubitemSplit
        '
        Me.grdSubitemSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdSubitemSplit.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdSubitemSplit.Location = New System.Drawing.Point(0, 337)
        Me.grdSubitemSplit.MainView = Me.grdSubitemSplitView
        Me.grdSubitemSplit.Name = "grdSubitemSplit"
        Me.grdSubitemSplit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.grdSubitemSplit.Size = New System.Drawing.Size(570, 235)
        Me.grdSubitemSplit.TabIndex = 3
        Me.grdSubitemSplit.UseEmbeddedNavigator = True
        Me.grdSubitemSplit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdSubitemSplitView})
        '
        'grdSubitemSplitView
        '
        Me.grdSubitemSplitView.GridControl = Me.grdSubitemSplit
        Me.grdSubitemSplitView.Name = "grdSubitemSplitView"
        Me.grdSubitemSplitView.OptionsCustomization.AllowColumnMoving = False
        Me.grdSubitemSplitView.OptionsCustomization.AllowGroup = False
        Me.grdSubitemSplitView.OptionsView.ColumnAutoWidth = False
        Me.grdSubitemSplitView.OptionsView.ShowAutoFilterRow = True
        Me.grdSubitemSplitView.OptionsView.ShowFooter = True
        Me.grdSubitemSplitView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "0.00"
        '
        'ToolBarItemSubitemSplit
        '
        Me.ToolBarItemSubitemSplit.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItemSubitemSplit.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarMoveSubItemSplit})
        Me.ToolBarItemSubitemSplit.Divider = False
        Me.ToolBarItemSubitemSplit.DropDownArrows = True
        Me.ToolBarItemSubitemSplit.Location = New System.Drawing.Point(0, 311)
        Me.ToolBarItemSubitemSplit.Name = "ToolBarItemSubitemSplit"
        Me.ToolBarItemSubitemSplit.ShowToolTips = True
        Me.ToolBarItemSubitemSplit.Size = New System.Drawing.Size(570, 26)
        Me.ToolBarItemSubitemSplit.TabIndex = 2
        Me.ToolBarItemSubitemSplit.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarMoveSubItemSplit
        '
        Me.BarMoveSubItemSplit.Name = "BarMoveSubItemSplit"
        Me.BarMoveSubItemSplit.Tag = "Reject"
        Me.BarMoveSubItemSplit.Text = "Pindah"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.CadetBlue
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(0, 289)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(570, 22)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "« Subitem"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.txtUnitPriceHPPSplit)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.txtRequestNumberSplit)
        Me.Panel3.Controls.Add(Me.txtLengthSplit)
        Me.Panel3.Controls.Add(Me.txtWidthSplit)
        Me.Panel3.Controls.Add(Me.txtThickSplit)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.Label33)
        Me.Panel3.Controls.Add(Me.txtMaxTotalWeightSplit)
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Controls.Add(Me.Label35)
        Me.Panel3.Controls.Add(Me.txtTotalPriceSplit)
        Me.Panel3.Controls.Add(Me.Label36)
        Me.Panel3.Controls.Add(Me.txtQuantitySplit)
        Me.Panel3.Controls.Add(Me.Label37)
        Me.Panel3.Controls.Add(Me.Label38)
        Me.Panel3.Controls.Add(Me.txtUnitPriceSplit)
        Me.Panel3.Controls.Add(Me.Label39)
        Me.Panel3.Controls.Add(Me.Label40)
        Me.Panel3.Controls.Add(Me.txtTotalWeightSplit)
        Me.Panel3.Controls.Add(Me.Label42)
        Me.Panel3.Controls.Add(Me.Label43)
        Me.Panel3.Controls.Add(Me.Label44)
        Me.Panel3.Controls.Add(Me.Label45)
        Me.Panel3.Controls.Add(Me.Label46)
        Me.Panel3.Controls.Add(Me.txtWeightSplit)
        Me.Panel3.Controls.Add(Me.Label47)
        Me.Panel3.Controls.Add(Me.Label48)
        Me.Panel3.Controls.Add(Me.Label49)
        Me.Panel3.Controls.Add(Me.cboItemSpecificationSplit)
        Me.Panel3.Controls.Add(Me.Label50)
        Me.Panel3.Controls.Add(Me.cboItemTypeSplit)
        Me.Panel3.Controls.Add(Me.Label51)
        Me.Panel3.Controls.Add(Me.Label52)
        Me.Panel3.Controls.Add(Me.txtItemCodeSplit)
        Me.Panel3.Controls.Add(Me.Label53)
        Me.Panel3.Controls.Add(Me.txtItemNameSplit)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(570, 289)
        Me.Panel3.TabIndex = 0
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(11, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 14)
        Me.Label21.TabIndex = 190
        Me.Label21.Text = "Hasil Split"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(543, 253)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 13)
        Me.Label22.TabIndex = 189
        Me.Label22.Text = "Kg"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(311, 253)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 188
        Me.Label30.Text = "Harga Beli"
        '
        'txtUnitPriceHPPSplit
        '
        Me.txtUnitPriceHPPSplit.BackColor = System.Drawing.Color.Azure
        Me.txtUnitPriceHPPSplit.DecimalPlaces = 2
        Me.txtUnitPriceHPPSplit.Enabled = False
        Me.txtUnitPriceHPPSplit.Location = New System.Drawing.Point(379, 249)
        Me.txtUnitPriceHPPSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPriceHPPSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPriceHPPSplit.Name = "txtUnitPriceHPPSplit"
        Me.txtUnitPriceHPPSplit.Size = New System.Drawing.Size(160, 21)
        Me.txtUnitPriceHPPSplit.TabIndex = 17
        Me.txtUnitPriceHPPSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPriceHPPSplit.ThousandsSeparator = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(11, 36)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(81, 13)
        Me.Label31.TabIndex = 186
        Me.Label31.Text = "No. Permintaan"
        '
        'txtRequestNumberSplit
        '
        Me.txtRequestNumberSplit.BackColor = System.Drawing.Color.Azure
        Me.txtRequestNumberSplit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRequestNumberSplit.Location = New System.Drawing.Point(113, 32)
        Me.txtRequestNumberSplit.MaxLength = 250
        Me.txtRequestNumberSplit.Name = "txtRequestNumberSplit"
        Me.txtRequestNumberSplit.ReadOnly = True
        Me.txtRequestNumberSplit.Size = New System.Drawing.Size(135, 21)
        Me.txtRequestNumberSplit.TabIndex = 0
        '
        'txtLengthSplit
        '
        Me.txtLengthSplit.BackColor = System.Drawing.Color.Azure
        Me.txtLengthSplit.DecimalPlaces = 2
        Me.txtLengthSplit.Enabled = False
        Me.txtLengthSplit.Location = New System.Drawing.Point(113, 195)
        Me.txtLengthSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLengthSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLengthSplit.Name = "txtLengthSplit"
        Me.txtLengthSplit.Size = New System.Drawing.Size(135, 21)
        Me.txtLengthSplit.TabIndex = 7
        Me.txtLengthSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLengthSplit.ThousandsSeparator = True
        '
        'txtWidthSplit
        '
        Me.txtWidthSplit.BackColor = System.Drawing.Color.Azure
        Me.txtWidthSplit.DecimalPlaces = 2
        Me.txtWidthSplit.Enabled = False
        Me.txtWidthSplit.Location = New System.Drawing.Point(113, 168)
        Me.txtWidthSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidthSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidthSplit.Name = "txtWidthSplit"
        Me.txtWidthSplit.Size = New System.Drawing.Size(135, 21)
        Me.txtWidthSplit.TabIndex = 6
        Me.txtWidthSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidthSplit.ThousandsSeparator = True
        '
        'txtThickSplit
        '
        Me.txtThickSplit.BackColor = System.Drawing.Color.Azure
        Me.txtThickSplit.DecimalPlaces = 2
        Me.txtThickSplit.Enabled = False
        Me.txtThickSplit.Location = New System.Drawing.Point(113, 141)
        Me.txtThickSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThickSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThickSplit.Name = "txtThickSplit"
        Me.txtThickSplit.Size = New System.Drawing.Size(135, 21)
        Me.txtThickSplit.TabIndex = 5
        Me.txtThickSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThickSplit.ThousandsSeparator = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(254, 254)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(19, 13)
        Me.Label32.TabIndex = 184
        Me.Label32.Text = "Kg"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(11, 254)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(91, 13)
        Me.Label33.TabIndex = 183
        Me.Label33.Text = "Maks. Total Berat"
        '
        'txtMaxTotalWeightSplit
        '
        Me.txtMaxTotalWeightSplit.BackColor = System.Drawing.Color.Azure
        Me.txtMaxTotalWeightSplit.DecimalPlaces = 2
        Me.txtMaxTotalWeightSplit.Enabled = False
        Me.txtMaxTotalWeightSplit.Location = New System.Drawing.Point(113, 250)
        Me.txtMaxTotalWeightSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtMaxTotalWeightSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtMaxTotalWeightSplit.Name = "txtMaxTotalWeightSplit"
        Me.txtMaxTotalWeightSplit.Size = New System.Drawing.Size(135, 21)
        Me.txtMaxTotalWeightSplit.TabIndex = 9
        Me.txtMaxTotalWeightSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxTotalWeightSplit.ThousandsSeparator = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(543, 226)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(19, 13)
        Me.Label34.TabIndex = 182
        Me.Label34.Text = "Kg"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(303, 226)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(63, 13)
        Me.Label35.TabIndex = 181
        Me.Label35.Text = "Total Harga"
        '
        'txtTotalPriceSplit
        '
        Me.txtTotalPriceSplit.BackColor = System.Drawing.Color.Azure
        Me.txtTotalPriceSplit.DecimalPlaces = 2
        Me.txtTotalPriceSplit.Enabled = False
        Me.txtTotalPriceSplit.Location = New System.Drawing.Point(379, 222)
        Me.txtTotalPriceSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPriceSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPriceSplit.Name = "txtTotalPriceSplit"
        Me.txtTotalPriceSplit.Size = New System.Drawing.Size(160, 21)
        Me.txtTotalPriceSplit.TabIndex = 16
        Me.txtTotalPriceSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPriceSplit.ThousandsSeparator = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(326, 172)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(40, 13)
        Me.Label36.TabIndex = 180
        Me.Label36.Text = "Jumlah"
        '
        'txtQuantitySplit
        '
        Me.txtQuantitySplit.Location = New System.Drawing.Point(379, 168)
        Me.txtQuantitySplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtQuantitySplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtQuantitySplit.Name = "txtQuantitySplit"
        Me.txtQuantitySplit.Size = New System.Drawing.Size(160, 21)
        Me.txtQuantitySplit.TabIndex = 14
        Me.txtQuantitySplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQuantitySplit.ThousandsSeparator = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(543, 145)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(19, 13)
        Me.Label37.TabIndex = 174
        Me.Label37.Text = "Kg"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(330, 145)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(36, 13)
        Me.Label38.TabIndex = 173
        Me.Label38.Text = "Harga"
        '
        'txtUnitPriceSplit
        '
        Me.txtUnitPriceSplit.BackColor = System.Drawing.Color.Azure
        Me.txtUnitPriceSplit.DecimalPlaces = 2
        Me.txtUnitPriceSplit.Enabled = False
        Me.txtUnitPriceSplit.Location = New System.Drawing.Point(379, 141)
        Me.txtUnitPriceSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPriceSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPriceSplit.Name = "txtUnitPriceSplit"
        Me.txtUnitPriceSplit.Size = New System.Drawing.Size(160, 21)
        Me.txtUnitPriceSplit.TabIndex = 13
        Me.txtUnitPriceSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPriceSplit.ThousandsSeparator = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(543, 199)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(19, 13)
        Me.Label39.TabIndex = 172
        Me.Label39.Text = "Kg"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(306, 199)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(60, 13)
        Me.Label40.TabIndex = 171
        Me.Label40.Text = "Total Berat"
        '
        'txtTotalWeightSplit
        '
        Me.txtTotalWeightSplit.BackColor = System.Drawing.Color.Azure
        Me.txtTotalWeightSplit.DecimalPlaces = 2
        Me.txtTotalWeightSplit.Enabled = False
        Me.txtTotalWeightSplit.Location = New System.Drawing.Point(379, 195)
        Me.txtTotalWeightSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalWeightSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalWeightSplit.Name = "txtTotalWeightSplit"
        Me.txtTotalWeightSplit.Size = New System.Drawing.Size(160, 21)
        Me.txtTotalWeightSplit.TabIndex = 15
        Me.txtTotalWeightSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalWeightSplit.ThousandsSeparator = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(254, 227)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(19, 13)
        Me.Label42.TabIndex = 169
        Me.Label42.Text = "Kg"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(254, 199)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(23, 13)
        Me.Label43.TabIndex = 167
        Me.Label43.Text = "mm"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(254, 172)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(23, 13)
        Me.Label44.TabIndex = 166
        Me.Label44.Text = "mm"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(254, 145)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(23, 13)
        Me.Label45.TabIndex = 165
        Me.Label45.Text = "mm"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(11, 227)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(33, 13)
        Me.Label46.TabIndex = 164
        Me.Label46.Text = "Berat"
        '
        'txtWeightSplit
        '
        Me.txtWeightSplit.BackColor = System.Drawing.Color.White
        Me.txtWeightSplit.DecimalPlaces = 1
        Me.txtWeightSplit.Location = New System.Drawing.Point(113, 223)
        Me.txtWeightSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWeightSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWeightSplit.Name = "txtWeightSplit"
        Me.txtWeightSplit.Size = New System.Drawing.Size(135, 21)
        Me.txtWeightSplit.TabIndex = 8
        Me.txtWeightSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWeightSplit.ThousandsSeparator = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(11, 199)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(46, 13)
        Me.Label47.TabIndex = 163
        Me.Label47.Text = "Panjang"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(11, 172)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(34, 13)
        Me.Label48.TabIndex = 162
        Me.Label48.Text = "Lebar"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(11, 145)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(33, 13)
        Me.Label49.TabIndex = 161
        Me.Label49.Text = "Tebal"
        '
        'cboItemSpecificationSplit
        '
        Me.cboItemSpecificationSplit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemSpecificationSplit.Enabled = False
        Me.cboItemSpecificationSplit.FormattingEnabled = True
        Me.cboItemSpecificationSplit.Location = New System.Drawing.Point(379, 59)
        Me.cboItemSpecificationSplit.Name = "cboItemSpecificationSplit"
        Me.cboItemSpecificationSplit.Size = New System.Drawing.Size(160, 21)
        Me.cboItemSpecificationSplit.TabIndex = 3
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(336, 63)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(30, 13)
        Me.Label50.TabIndex = 160
        Me.Label50.Text = "Spec"
        '
        'cboItemTypeSplit
        '
        Me.cboItemTypeSplit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemTypeSplit.Enabled = False
        Me.cboItemTypeSplit.FormattingEnabled = True
        Me.cboItemTypeSplit.Location = New System.Drawing.Point(379, 32)
        Me.cboItemTypeSplit.Name = "cboItemTypeSplit"
        Me.cboItemTypeSplit.Size = New System.Drawing.Size(160, 21)
        Me.cboItemTypeSplit.TabIndex = 2
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(335, 36)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(31, 13)
        Me.Label51.TabIndex = 159
        Me.Label51.Text = "Jenis"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(11, 63)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(68, 13)
        Me.Label52.TabIndex = 158
        Me.Label52.Text = "Kode Barang"
        '
        'txtItemCodeSplit
        '
        Me.txtItemCodeSplit.BackColor = System.Drawing.Color.Azure
        Me.txtItemCodeSplit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCodeSplit.Location = New System.Drawing.Point(113, 59)
        Me.txtItemCodeSplit.MaxLength = 250
        Me.txtItemCodeSplit.Name = "txtItemCodeSplit"
        Me.txtItemCodeSplit.ReadOnly = True
        Me.txtItemCodeSplit.Size = New System.Drawing.Size(135, 21)
        Me.txtItemCodeSplit.TabIndex = 1
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(11, 90)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(71, 13)
        Me.Label53.TabIndex = 157
        Me.Label53.Text = "Nama Barang"
        '
        'txtItemNameSplit
        '
        Me.txtItemNameSplit.BackColor = System.Drawing.Color.Azure
        Me.txtItemNameSplit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemNameSplit.Location = New System.Drawing.Point(113, 87)
        Me.txtItemNameSplit.MaxLength = 250
        Me.txtItemNameSplit.Multiline = True
        Me.txtItemNameSplit.Name = "txtItemNameSplit"
        Me.txtItemNameSplit.ReadOnly = True
        Me.txtItemNameSplit.Size = New System.Drawing.Size(426, 48)
        Me.txtItemNameSplit.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdSubitem)
        Me.Panel1.Controls.Add(Me.ToolBarItemSubitem)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.pnlDetail)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(570, 572)
        Me.Panel1.TabIndex = 0
        '
        'grdSubitem
        '
        Me.grdSubitem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSubitem.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdSubitem.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdSubitem.Location = New System.Drawing.Point(0, 337)
        Me.grdSubitem.MainView = Me.grdSubitemView
        Me.grdSubitem.Name = "grdSubitem"
        Me.grdSubitem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2})
        Me.grdSubitem.Size = New System.Drawing.Size(570, 235)
        Me.grdSubitem.TabIndex = 3
        Me.grdSubitem.UseEmbeddedNavigator = True
        Me.grdSubitem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdSubitemView})
        '
        'grdSubitemView
        '
        Me.grdSubitemView.GridControl = Me.grdSubitem
        Me.grdSubitemView.Name = "grdSubitemView"
        Me.grdSubitemView.OptionsCustomization.AllowColumnMoving = False
        Me.grdSubitemView.OptionsCustomization.AllowGroup = False
        Me.grdSubitemView.OptionsView.ColumnAutoWidth = False
        Me.grdSubitemView.OptionsView.ShowAutoFilterRow = True
        Me.grdSubitemView.OptionsView.ShowFooter = True
        Me.grdSubitemView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "0.00"
        '
        'ToolBarItemSubitem
        '
        Me.ToolBarItemSubitem.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItemSubitem.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarMoveSubItem})
        Me.ToolBarItemSubitem.Divider = False
        Me.ToolBarItemSubitem.DropDownArrows = True
        Me.ToolBarItemSubitem.Location = New System.Drawing.Point(0, 311)
        Me.ToolBarItemSubitem.Name = "ToolBarItemSubitem"
        Me.ToolBarItemSubitem.ShowToolTips = True
        Me.ToolBarItemSubitem.Size = New System.Drawing.Size(570, 26)
        Me.ToolBarItemSubitem.TabIndex = 2
        Me.ToolBarItemSubitem.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarMoveSubItem
        '
        Me.BarMoveSubItem.Name = "BarMoveSubItem"
        Me.BarMoveSubItem.Tag = "Submit"
        Me.BarMoveSubItem.Text = "Pindah"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.CadetBlue
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(0, 289)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(570, 22)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "« Subitem"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.Label1)
        Me.pnlDetail.Controls.Add(Me.Label11)
        Me.pnlDetail.Controls.Add(Me.Label18)
        Me.pnlDetail.Controls.Add(Me.txtUnitPriceHPP)
        Me.pnlDetail.Controls.Add(Me.Label4)
        Me.pnlDetail.Controls.Add(Me.txtRequestNumber)
        Me.pnlDetail.Controls.Add(Me.txtLength)
        Me.pnlDetail.Controls.Add(Me.txtWidth)
        Me.pnlDetail.Controls.Add(Me.txtThick)
        Me.pnlDetail.Controls.Add(Me.Label26)
        Me.pnlDetail.Controls.Add(Me.Label27)
        Me.pnlDetail.Controls.Add(Me.txtMaxTotalWeight)
        Me.pnlDetail.Controls.Add(Me.Label24)
        Me.pnlDetail.Controls.Add(Me.Label25)
        Me.pnlDetail.Controls.Add(Me.txtTotalPrice)
        Me.pnlDetail.Controls.Add(Me.Label23)
        Me.pnlDetail.Controls.Add(Me.txtQuantity)
        Me.pnlDetail.Controls.Add(Me.Label17)
        Me.pnlDetail.Controls.Add(Me.Label14)
        Me.pnlDetail.Controls.Add(Me.txtUnitPrice)
        Me.pnlDetail.Controls.Add(Me.Label15)
        Me.pnlDetail.Controls.Add(Me.Label16)
        Me.pnlDetail.Controls.Add(Me.txtTotalWeight)
        Me.pnlDetail.Controls.Add(Me.Label12)
        Me.pnlDetail.Controls.Add(Me.Label10)
        Me.pnlDetail.Controls.Add(Me.Label9)
        Me.pnlDetail.Controls.Add(Me.Label8)
        Me.pnlDetail.Controls.Add(Me.Label7)
        Me.pnlDetail.Controls.Add(Me.txtWeight)
        Me.pnlDetail.Controls.Add(Me.Label6)
        Me.pnlDetail.Controls.Add(Me.Label2)
        Me.pnlDetail.Controls.Add(Me.Label3)
        Me.pnlDetail.Controls.Add(Me.cboItemSpecification)
        Me.pnlDetail.Controls.Add(Me.Label5)
        Me.pnlDetail.Controls.Add(Me.cboItemType)
        Me.pnlDetail.Controls.Add(Me.Label28)
        Me.pnlDetail.Controls.Add(Me.Label29)
        Me.pnlDetail.Controls.Add(Me.txtItemCode)
        Me.pnlDetail.Controls.Add(Me.lblName)
        Me.pnlDetail.Controls.Add(Me.txtItemName)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(570, 289)
        Me.pnlDetail.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 14)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Saat Ini"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(543, 253)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 13)
        Me.Label11.TabIndex = 189
        Me.Label11.Text = "Kg"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(311, 253)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 188
        Me.Label18.Text = "Harga Beli"
        '
        'txtUnitPriceHPP
        '
        Me.txtUnitPriceHPP.BackColor = System.Drawing.Color.Azure
        Me.txtUnitPriceHPP.DecimalPlaces = 2
        Me.txtUnitPriceHPP.Enabled = False
        Me.txtUnitPriceHPP.Location = New System.Drawing.Point(379, 249)
        Me.txtUnitPriceHPP.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPriceHPP.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPriceHPP.Name = "txtUnitPriceHPP"
        Me.txtUnitPriceHPP.Size = New System.Drawing.Size(160, 21)
        Me.txtUnitPriceHPP.TabIndex = 17
        Me.txtUnitPriceHPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPriceHPP.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(11, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "No. Permintaan"
        '
        'txtRequestNumber
        '
        Me.txtRequestNumber.BackColor = System.Drawing.Color.Azure
        Me.txtRequestNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRequestNumber.Location = New System.Drawing.Point(113, 32)
        Me.txtRequestNumber.MaxLength = 250
        Me.txtRequestNumber.Name = "txtRequestNumber"
        Me.txtRequestNumber.ReadOnly = True
        Me.txtRequestNumber.Size = New System.Drawing.Size(135, 21)
        Me.txtRequestNumber.TabIndex = 0
        '
        'txtLength
        '
        Me.txtLength.BackColor = System.Drawing.Color.Azure
        Me.txtLength.DecimalPlaces = 2
        Me.txtLength.Enabled = False
        Me.txtLength.Location = New System.Drawing.Point(113, 195)
        Me.txtLength.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLength.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(135, 21)
        Me.txtLength.TabIndex = 7
        Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLength.ThousandsSeparator = True
        '
        'txtWidth
        '
        Me.txtWidth.BackColor = System.Drawing.Color.Azure
        Me.txtWidth.DecimalPlaces = 2
        Me.txtWidth.Enabled = False
        Me.txtWidth.Location = New System.Drawing.Point(113, 168)
        Me.txtWidth.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidth.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(135, 21)
        Me.txtWidth.TabIndex = 6
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidth.ThousandsSeparator = True
        '
        'txtThick
        '
        Me.txtThick.BackColor = System.Drawing.Color.Azure
        Me.txtThick.DecimalPlaces = 2
        Me.txtThick.Enabled = False
        Me.txtThick.Location = New System.Drawing.Point(113, 141)
        Me.txtThick.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThick.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThick.Name = "txtThick"
        Me.txtThick.Size = New System.Drawing.Size(135, 21)
        Me.txtThick.TabIndex = 5
        Me.txtThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThick.ThousandsSeparator = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(254, 254)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 13)
        Me.Label26.TabIndex = 184
        Me.Label26.Text = "Kg"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(11, 254)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 13)
        Me.Label27.TabIndex = 183
        Me.Label27.Text = "Maks. Total Berat"
        '
        'txtMaxTotalWeight
        '
        Me.txtMaxTotalWeight.BackColor = System.Drawing.Color.Azure
        Me.txtMaxTotalWeight.DecimalPlaces = 2
        Me.txtMaxTotalWeight.Enabled = False
        Me.txtMaxTotalWeight.Location = New System.Drawing.Point(113, 250)
        Me.txtMaxTotalWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtMaxTotalWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtMaxTotalWeight.Name = "txtMaxTotalWeight"
        Me.txtMaxTotalWeight.Size = New System.Drawing.Size(135, 21)
        Me.txtMaxTotalWeight.TabIndex = 9
        Me.txtMaxTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxTotalWeight.ThousandsSeparator = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(543, 226)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(19, 13)
        Me.Label24.TabIndex = 182
        Me.Label24.Text = "Kg"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(303, 226)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 181
        Me.Label25.Text = "Total Harga"
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.BackColor = System.Drawing.Color.Azure
        Me.txtTotalPrice.DecimalPlaces = 2
        Me.txtTotalPrice.Enabled = False
        Me.txtTotalPrice.Location = New System.Drawing.Point(379, 222)
        Me.txtTotalPrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.Size = New System.Drawing.Size(160, 21)
        Me.txtTotalPrice.TabIndex = 16
        Me.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPrice.ThousandsSeparator = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(326, 172)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 180
        Me.Label23.Text = "Jumlah"
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.Azure
        Me.txtQuantity.Enabled = False
        Me.txtQuantity.Location = New System.Drawing.Point(379, 168)
        Me.txtQuantity.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtQuantity.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(160, 21)
        Me.txtQuantity.TabIndex = 14
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQuantity.ThousandsSeparator = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(543, 145)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 13)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Kg"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(330, 145)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 173
        Me.Label14.Text = "Harga"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.Color.Azure
        Me.txtUnitPrice.DecimalPlaces = 2
        Me.txtUnitPrice.Enabled = False
        Me.txtUnitPrice.Location = New System.Drawing.Point(379, 141)
        Me.txtUnitPrice.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPrice.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(160, 21)
        Me.txtUnitPrice.TabIndex = 13
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPrice.ThousandsSeparator = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(543, 199)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 13)
        Me.Label15.TabIndex = 172
        Me.Label15.Text = "Kg"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(306, 199)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 171
        Me.Label16.Text = "Total Berat"
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BackColor = System.Drawing.Color.Azure
        Me.txtTotalWeight.DecimalPlaces = 2
        Me.txtTotalWeight.Enabled = False
        Me.txtTotalWeight.Location = New System.Drawing.Point(379, 195)
        Me.txtTotalWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.Size = New System.Drawing.Size(160, 21)
        Me.txtTotalWeight.TabIndex = 15
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalWeight.ThousandsSeparator = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(254, 227)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 13)
        Me.Label12.TabIndex = 169
        Me.Label12.Text = "Kg"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(254, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 167
        Me.Label10.Text = "mm"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(254, 172)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(254, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "mm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(11, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 164
        Me.Label7.Text = "Berat"
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.Color.Azure
        Me.txtWeight.DecimalPlaces = 1
        Me.txtWeight.Enabled = False
        Me.txtWeight.Location = New System.Drawing.Point(113, 223)
        Me.txtWeight.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWeight.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(135, 21)
        Me.txtWeight.TabIndex = 8
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWeight.ThousandsSeparator = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Panjang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 162
        Me.Label2.Text = "Lebar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "Tebal"
        '
        'cboItemSpecification
        '
        Me.cboItemSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemSpecification.Enabled = False
        Me.cboItemSpecification.FormattingEnabled = True
        Me.cboItemSpecification.Location = New System.Drawing.Point(379, 59)
        Me.cboItemSpecification.Name = "cboItemSpecification"
        Me.cboItemSpecification.Size = New System.Drawing.Size(160, 21)
        Me.cboItemSpecification.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(336, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 160
        Me.Label5.Text = "Spec"
        '
        'cboItemType
        '
        Me.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemType.Enabled = False
        Me.cboItemType.FormattingEnabled = True
        Me.cboItemType.Location = New System.Drawing.Point(379, 32)
        Me.cboItemType.Name = "cboItemType"
        Me.cboItemType.Size = New System.Drawing.Size(160, 21)
        Me.cboItemType.TabIndex = 2
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(335, 36)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 13)
        Me.Label28.TabIndex = 159
        Me.Label28.Text = "Jenis"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(11, 63)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(68, 13)
        Me.Label29.TabIndex = 158
        Me.Label29.Text = "Kode Barang"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.Azure
        Me.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCode.Location = New System.Drawing.Point(113, 59)
        Me.txtItemCode.MaxLength = 250
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.ReadOnly = True
        Me.txtItemCode.Size = New System.Drawing.Size(135, 21)
        Me.txtItemCode.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(11, 90)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(71, 13)
        Me.lblName.TabIndex = 157
        Me.lblName.Text = "Nama Barang"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.Azure
        Me.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Location = New System.Drawing.Point(113, 87)
        Me.txtItemName.MaxLength = 250
        Me.txtItemName.Multiline = True
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(426, 48)
        Me.txtItemName.TabIndex = 4
        '
        'tpConfirmationOrder
        '
        Me.tpConfirmationOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpConfirmationOrder.Controls.Add(Me.TableLayoutPanel2)
        Me.tpConfirmationOrder.Location = New System.Drawing.Point(4, 25)
        Me.tpConfirmationOrder.Name = "tpConfirmationOrder"
        Me.tpConfirmationOrder.Size = New System.Drawing.Size(1156, 582)
        Me.tpConfirmationOrder.TabIndex = 1
        Me.tpConfirmationOrder.Text = "Konfirmasi Pesanan - F2"
        Me.tpConfirmationOrder.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1152, 578)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdSubItemCOSplit)
        Me.Panel5.Controls.Add(Me.ToolBarItemCOSplit)
        Me.Panel5.Controls.Add(Me.Label103)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(579, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(570, 572)
        Me.Panel5.TabIndex = 1
        '
        'grdSubItemCOSplit
        '
        Me.grdSubItemCOSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdSubItemCOSplit.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdSubItemCOSplit.Location = New System.Drawing.Point(0, 361)
        Me.grdSubItemCOSplit.MainView = Me.grdSubItemCOSplitView
        Me.grdSubItemCOSplit.Name = "grdSubItemCOSplit"
        Me.grdSubItemCOSplit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit4})
        Me.grdSubItemCOSplit.Size = New System.Drawing.Size(570, 211)
        Me.grdSubItemCOSplit.TabIndex = 3
        Me.grdSubItemCOSplit.UseEmbeddedNavigator = True
        Me.grdSubItemCOSplit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdSubItemCOSplitView})
        '
        'grdSubItemCOSplitView
        '
        Me.grdSubItemCOSplitView.GridControl = Me.grdSubItemCOSplit
        Me.grdSubItemCOSplitView.Name = "grdSubItemCOSplitView"
        Me.grdSubItemCOSplitView.OptionsCustomization.AllowColumnMoving = False
        Me.grdSubItemCOSplitView.OptionsCustomization.AllowGroup = False
        Me.grdSubItemCOSplitView.OptionsView.ColumnAutoWidth = False
        Me.grdSubItemCOSplitView.OptionsView.ShowAutoFilterRow = True
        Me.grdSubItemCOSplitView.OptionsView.ShowFooter = True
        Me.grdSubItemCOSplitView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        Me.RepositoryItemTextEdit4.NullText = "0.00"
        '
        'ToolBarItemCOSplit
        '
        Me.ToolBarItemCOSplit.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItemCOSplit.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarMoveItemOrderSplit})
        Me.ToolBarItemCOSplit.Divider = False
        Me.ToolBarItemCOSplit.DropDownArrows = True
        Me.ToolBarItemCOSplit.Location = New System.Drawing.Point(0, 335)
        Me.ToolBarItemCOSplit.Name = "ToolBarItemCOSplit"
        Me.ToolBarItemCOSplit.ShowToolTips = True
        Me.ToolBarItemCOSplit.Size = New System.Drawing.Size(570, 26)
        Me.ToolBarItemCOSplit.TabIndex = 2
        Me.ToolBarItemCOSplit.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarMoveItemOrderSplit
        '
        Me.BarMoveItemOrderSplit.Name = "BarMoveItemOrderSplit"
        Me.BarMoveItemOrderSplit.Tag = "Reject"
        Me.BarMoveItemOrderSplit.Text = "Pindah"
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.CadetBlue
        Me.Label103.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label103.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.White
        Me.Label103.Location = New System.Drawing.Point(0, 313)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(570, 22)
        Me.Label103.TabIndex = 1
        Me.Label103.Text = "« Subitem"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label67)
        Me.Panel7.Controls.Add(Me.Label80)
        Me.Panel7.Controls.Add(Me.txtOrderNumberSupplierCOSplit)
        Me.Panel7.Controls.Add(Me.Label81)
        Me.Panel7.Controls.Add(Me.txtCONumberCOSplit)
        Me.Panel7.Controls.Add(Me.Label82)
        Me.Panel7.Controls.Add(Me.Label83)
        Me.Panel7.Controls.Add(Me.Label84)
        Me.Panel7.Controls.Add(Me.Label85)
        Me.Panel7.Controls.Add(Me.txtTotalPriceCOSplit)
        Me.Panel7.Controls.Add(Me.Label86)
        Me.Panel7.Controls.Add(Me.txtQuantityCOSplit)
        Me.Panel7.Controls.Add(Me.Label87)
        Me.Panel7.Controls.Add(Me.Label88)
        Me.Panel7.Controls.Add(Me.txtUnitPriceCOSplit)
        Me.Panel7.Controls.Add(Me.Label89)
        Me.Panel7.Controls.Add(Me.Label90)
        Me.Panel7.Controls.Add(Me.txtTotalWeightCOSplit)
        Me.Panel7.Controls.Add(Me.Label91)
        Me.Panel7.Controls.Add(Me.Label92)
        Me.Panel7.Controls.Add(Me.Label93)
        Me.Panel7.Controls.Add(Me.Label94)
        Me.Panel7.Controls.Add(Me.Label95)
        Me.Panel7.Controls.Add(Me.Label96)
        Me.Panel7.Controls.Add(Me.Label97)
        Me.Panel7.Controls.Add(Me.Label98)
        Me.Panel7.Controls.Add(Me.cboItemSpecificationCOSplit)
        Me.Panel7.Controls.Add(Me.Label99)
        Me.Panel7.Controls.Add(Me.cboItemTypeCOSplit)
        Me.Panel7.Controls.Add(Me.Label100)
        Me.Panel7.Controls.Add(Me.Label101)
        Me.Panel7.Controls.Add(Me.txtItemCodeCOSplit)
        Me.Panel7.Controls.Add(Me.Label102)
        Me.Panel7.Controls.Add(Me.txtItemNameCOSplit)
        Me.Panel7.Controls.Add(Me.txtLengthCOSplit)
        Me.Panel7.Controls.Add(Me.txtWidthCOSplit)
        Me.Panel7.Controls.Add(Me.txtThickCOSplit)
        Me.Panel7.Controls.Add(Me.txtMaxTotalWeightCOSplit)
        Me.Panel7.Controls.Add(Me.txtWeightCOSplit)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(570, 313)
        Me.Panel7.TabIndex = 0
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label67.ForeColor = System.Drawing.Color.Black
        Me.Label67.Location = New System.Drawing.Point(14, 12)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(67, 14)
        Me.Label67.TabIndex = 192
        Me.Label67.Text = "Hasil Split"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.BackColor = System.Drawing.Color.Transparent
        Me.Label80.ForeColor = System.Drawing.Color.Black
        Me.Label80.Location = New System.Drawing.Point(14, 65)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(127, 13)
        Me.Label80.TabIndex = 191
        Me.Label80.Text = "Nomor Pesanan Pemasok"
        '
        'txtOrderNumberSupplierCOSplit
        '
        Me.txtOrderNumberSupplierCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtOrderNumberSupplierCOSplit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderNumberSupplierCOSplit.Location = New System.Drawing.Point(153, 61)
        Me.txtOrderNumberSupplierCOSplit.MaxLength = 250
        Me.txtOrderNumberSupplierCOSplit.Name = "txtOrderNumberSupplierCOSplit"
        Me.txtOrderNumberSupplierCOSplit.ReadOnly = True
        Me.txtOrderNumberSupplierCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtOrderNumberSupplierCOSplit.TabIndex = 1
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.ForeColor = System.Drawing.Color.Black
        Me.Label81.Location = New System.Drawing.Point(14, 38)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(90, 13)
        Me.Label81.TabIndex = 189
        Me.Label81.Text = "Nomor Konfirmasi"
        '
        'txtCONumberCOSplit
        '
        Me.txtCONumberCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtCONumberCOSplit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCONumberCOSplit.Location = New System.Drawing.Point(153, 34)
        Me.txtCONumberCOSplit.MaxLength = 250
        Me.txtCONumberCOSplit.Name = "txtCONumberCOSplit"
        Me.txtCONumberCOSplit.ReadOnly = True
        Me.txtCONumberCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtCONumberCOSplit.TabIndex = 0
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.ForeColor = System.Drawing.Color.Black
        Me.Label82.Location = New System.Drawing.Point(328, 283)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(19, 13)
        Me.Label82.TabIndex = 184
        Me.Label82.Text = "Kg"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.ForeColor = System.Drawing.Color.Black
        Me.Label83.Location = New System.Drawing.Point(14, 283)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(91, 13)
        Me.Label83.TabIndex = 183
        Me.Label83.Text = "Maks. Total Berat"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.BackColor = System.Drawing.Color.Transparent
        Me.Label84.ForeColor = System.Drawing.Color.Black
        Me.Label84.Location = New System.Drawing.Point(543, 255)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(19, 13)
        Me.Label84.TabIndex = 182
        Me.Label84.Text = "Kg"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.BackColor = System.Drawing.Color.Transparent
        Me.Label85.ForeColor = System.Drawing.Color.Black
        Me.Label85.Location = New System.Drawing.Point(362, 255)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(63, 13)
        Me.Label85.TabIndex = 181
        Me.Label85.Text = "Total Harga"
        '
        'txtTotalPriceCOSplit
        '
        Me.txtTotalPriceCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtTotalPriceCOSplit.DecimalPlaces = 2
        Me.txtTotalPriceCOSplit.Enabled = False
        Me.txtTotalPriceCOSplit.Location = New System.Drawing.Point(434, 251)
        Me.txtTotalPriceCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPriceCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPriceCOSplit.Name = "txtTotalPriceCOSplit"
        Me.txtTotalPriceCOSplit.Size = New System.Drawing.Size(104, 21)
        Me.txtTotalPriceCOSplit.TabIndex = 14
        Me.txtTotalPriceCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPriceCOSplit.ThousandsSeparator = True
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.BackColor = System.Drawing.Color.Transparent
        Me.Label86.ForeColor = System.Drawing.Color.Black
        Me.Label86.Location = New System.Drawing.Point(385, 201)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(40, 13)
        Me.Label86.TabIndex = 180
        Me.Label86.Text = "Jumlah"
        '
        'txtQuantityCOSplit
        '
        Me.txtQuantityCOSplit.Location = New System.Drawing.Point(434, 197)
        Me.txtQuantityCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtQuantityCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtQuantityCOSplit.Name = "txtQuantityCOSplit"
        Me.txtQuantityCOSplit.Size = New System.Drawing.Size(104, 21)
        Me.txtQuantityCOSplit.TabIndex = 12
        Me.txtQuantityCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQuantityCOSplit.ThousandsSeparator = True
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.ForeColor = System.Drawing.Color.Black
        Me.Label87.Location = New System.Drawing.Point(543, 174)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(19, 13)
        Me.Label87.TabIndex = 174
        Me.Label87.Text = "Kg"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.BackColor = System.Drawing.Color.Transparent
        Me.Label88.ForeColor = System.Drawing.Color.Black
        Me.Label88.Location = New System.Drawing.Point(389, 174)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(36, 13)
        Me.Label88.TabIndex = 173
        Me.Label88.Text = "Harga"
        '
        'txtUnitPriceCOSplit
        '
        Me.txtUnitPriceCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtUnitPriceCOSplit.DecimalPlaces = 2
        Me.txtUnitPriceCOSplit.Enabled = False
        Me.txtUnitPriceCOSplit.Location = New System.Drawing.Point(434, 170)
        Me.txtUnitPriceCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPriceCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPriceCOSplit.Name = "txtUnitPriceCOSplit"
        Me.txtUnitPriceCOSplit.Size = New System.Drawing.Size(104, 21)
        Me.txtUnitPriceCOSplit.TabIndex = 11
        Me.txtUnitPriceCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPriceCOSplit.ThousandsSeparator = True
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.BackColor = System.Drawing.Color.Transparent
        Me.Label89.ForeColor = System.Drawing.Color.Black
        Me.Label89.Location = New System.Drawing.Point(543, 228)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(19, 13)
        Me.Label89.TabIndex = 172
        Me.Label89.Text = "Kg"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.ForeColor = System.Drawing.Color.Black
        Me.Label90.Location = New System.Drawing.Point(365, 228)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(60, 13)
        Me.Label90.TabIndex = 171
        Me.Label90.Text = "Total Berat"
        '
        'txtTotalWeightCOSplit
        '
        Me.txtTotalWeightCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtTotalWeightCOSplit.DecimalPlaces = 2
        Me.txtTotalWeightCOSplit.Enabled = False
        Me.txtTotalWeightCOSplit.Location = New System.Drawing.Point(434, 224)
        Me.txtTotalWeightCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalWeightCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalWeightCOSplit.Name = "txtTotalWeightCOSplit"
        Me.txtTotalWeightCOSplit.Size = New System.Drawing.Size(104, 21)
        Me.txtTotalWeightCOSplit.TabIndex = 13
        Me.txtTotalWeightCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalWeightCOSplit.ThousandsSeparator = True
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.BackColor = System.Drawing.Color.Transparent
        Me.Label91.ForeColor = System.Drawing.Color.Black
        Me.Label91.Location = New System.Drawing.Point(328, 256)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(19, 13)
        Me.Label91.TabIndex = 169
        Me.Label91.Text = "Kg"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.BackColor = System.Drawing.Color.Transparent
        Me.Label92.ForeColor = System.Drawing.Color.Black
        Me.Label92.Location = New System.Drawing.Point(328, 228)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(23, 13)
        Me.Label92.TabIndex = 167
        Me.Label92.Text = "mm"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.BackColor = System.Drawing.Color.Transparent
        Me.Label93.ForeColor = System.Drawing.Color.Black
        Me.Label93.Location = New System.Drawing.Point(328, 201)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(23, 13)
        Me.Label93.TabIndex = 166
        Me.Label93.Text = "mm"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.BackColor = System.Drawing.Color.Transparent
        Me.Label94.ForeColor = System.Drawing.Color.Black
        Me.Label94.Location = New System.Drawing.Point(328, 174)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(23, 13)
        Me.Label94.TabIndex = 165
        Me.Label94.Text = "mm"
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.BackColor = System.Drawing.Color.Transparent
        Me.Label95.ForeColor = System.Drawing.Color.Black
        Me.Label95.Location = New System.Drawing.Point(14, 256)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(33, 13)
        Me.Label95.TabIndex = 164
        Me.Label95.Text = "Berat"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.BackColor = System.Drawing.Color.Transparent
        Me.Label96.ForeColor = System.Drawing.Color.Black
        Me.Label96.Location = New System.Drawing.Point(14, 228)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(46, 13)
        Me.Label96.TabIndex = 163
        Me.Label96.Text = "Panjang"
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.BackColor = System.Drawing.Color.Transparent
        Me.Label97.ForeColor = System.Drawing.Color.Black
        Me.Label97.Location = New System.Drawing.Point(14, 201)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(34, 13)
        Me.Label97.TabIndex = 162
        Me.Label97.Text = "Lebar"
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.BackColor = System.Drawing.Color.Transparent
        Me.Label98.ForeColor = System.Drawing.Color.Black
        Me.Label98.Location = New System.Drawing.Point(14, 174)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(33, 13)
        Me.Label98.TabIndex = 161
        Me.Label98.Text = "Tebal"
        '
        'cboItemSpecificationCOSplit
        '
        Me.cboItemSpecificationCOSplit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemSpecificationCOSplit.Enabled = False
        Me.cboItemSpecificationCOSplit.FormattingEnabled = True
        Me.cboItemSpecificationCOSplit.Location = New System.Drawing.Point(434, 88)
        Me.cboItemSpecificationCOSplit.Name = "cboItemSpecificationCOSplit"
        Me.cboItemSpecificationCOSplit.Size = New System.Drawing.Size(104, 21)
        Me.cboItemSpecificationCOSplit.TabIndex = 4
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.BackColor = System.Drawing.Color.Transparent
        Me.Label99.ForeColor = System.Drawing.Color.Black
        Me.Label99.Location = New System.Drawing.Point(395, 92)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(30, 13)
        Me.Label99.TabIndex = 160
        Me.Label99.Text = "Spec"
        '
        'cboItemTypeCOSplit
        '
        Me.cboItemTypeCOSplit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemTypeCOSplit.Enabled = False
        Me.cboItemTypeCOSplit.FormattingEnabled = True
        Me.cboItemTypeCOSplit.Location = New System.Drawing.Point(434, 61)
        Me.cboItemTypeCOSplit.Name = "cboItemTypeCOSplit"
        Me.cboItemTypeCOSplit.Size = New System.Drawing.Size(104, 21)
        Me.cboItemTypeCOSplit.TabIndex = 3
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.BackColor = System.Drawing.Color.Transparent
        Me.Label100.ForeColor = System.Drawing.Color.Black
        Me.Label100.Location = New System.Drawing.Point(394, 65)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(31, 13)
        Me.Label100.TabIndex = 159
        Me.Label100.Text = "Jenis"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.ForeColor = System.Drawing.Color.Black
        Me.Label101.Location = New System.Drawing.Point(14, 92)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(68, 13)
        Me.Label101.TabIndex = 158
        Me.Label101.Text = "Kode Barang"
        '
        'txtItemCodeCOSplit
        '
        Me.txtItemCodeCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtItemCodeCOSplit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCodeCOSplit.Location = New System.Drawing.Point(153, 88)
        Me.txtItemCodeCOSplit.MaxLength = 250
        Me.txtItemCodeCOSplit.Name = "txtItemCodeCOSplit"
        Me.txtItemCodeCOSplit.ReadOnly = True
        Me.txtItemCodeCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtItemCodeCOSplit.TabIndex = 2
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.BackColor = System.Drawing.Color.Transparent
        Me.Label102.ForeColor = System.Drawing.Color.Black
        Me.Label102.Location = New System.Drawing.Point(14, 119)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(71, 13)
        Me.Label102.TabIndex = 157
        Me.Label102.Text = "Nama Barang"
        '
        'txtItemNameCOSplit
        '
        Me.txtItemNameCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtItemNameCOSplit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemNameCOSplit.Location = New System.Drawing.Point(153, 116)
        Me.txtItemNameCOSplit.MaxLength = 250
        Me.txtItemNameCOSplit.Multiline = True
        Me.txtItemNameCOSplit.Name = "txtItemNameCOSplit"
        Me.txtItemNameCOSplit.ReadOnly = True
        Me.txtItemNameCOSplit.Size = New System.Drawing.Size(385, 48)
        Me.txtItemNameCOSplit.TabIndex = 5
        '
        'txtLengthCOSplit
        '
        Me.txtLengthCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtLengthCOSplit.DecimalPlaces = 2
        Me.txtLengthCOSplit.Enabled = False
        Me.txtLengthCOSplit.Location = New System.Drawing.Point(153, 224)
        Me.txtLengthCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLengthCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLengthCOSplit.Name = "txtLengthCOSplit"
        Me.txtLengthCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtLengthCOSplit.TabIndex = 8
        Me.txtLengthCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLengthCOSplit.ThousandsSeparator = True
        '
        'txtWidthCOSplit
        '
        Me.txtWidthCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtWidthCOSplit.DecimalPlaces = 2
        Me.txtWidthCOSplit.Enabled = False
        Me.txtWidthCOSplit.Location = New System.Drawing.Point(153, 197)
        Me.txtWidthCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidthCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidthCOSplit.Name = "txtWidthCOSplit"
        Me.txtWidthCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtWidthCOSplit.TabIndex = 7
        Me.txtWidthCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidthCOSplit.ThousandsSeparator = True
        '
        'txtThickCOSplit
        '
        Me.txtThickCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtThickCOSplit.DecimalPlaces = 2
        Me.txtThickCOSplit.Enabled = False
        Me.txtThickCOSplit.Location = New System.Drawing.Point(153, 170)
        Me.txtThickCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThickCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThickCOSplit.Name = "txtThickCOSplit"
        Me.txtThickCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtThickCOSplit.TabIndex = 6
        Me.txtThickCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThickCOSplit.ThousandsSeparator = True
        '
        'txtMaxTotalWeightCOSplit
        '
        Me.txtMaxTotalWeightCOSplit.BackColor = System.Drawing.Color.Azure
        Me.txtMaxTotalWeightCOSplit.DecimalPlaces = 2
        Me.txtMaxTotalWeightCOSplit.Enabled = False
        Me.txtMaxTotalWeightCOSplit.Location = New System.Drawing.Point(153, 279)
        Me.txtMaxTotalWeightCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtMaxTotalWeightCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtMaxTotalWeightCOSplit.Name = "txtMaxTotalWeightCOSplit"
        Me.txtMaxTotalWeightCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtMaxTotalWeightCOSplit.TabIndex = 10
        Me.txtMaxTotalWeightCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxTotalWeightCOSplit.ThousandsSeparator = True
        '
        'txtWeightCOSplit
        '
        Me.txtWeightCOSplit.BackColor = System.Drawing.Color.White
        Me.txtWeightCOSplit.DecimalPlaces = 2
        Me.txtWeightCOSplit.Location = New System.Drawing.Point(153, 252)
        Me.txtWeightCOSplit.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWeightCOSplit.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWeightCOSplit.Name = "txtWeightCOSplit"
        Me.txtWeightCOSplit.Size = New System.Drawing.Size(170, 21)
        Me.txtWeightCOSplit.TabIndex = 9
        Me.txtWeightCOSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWeightCOSplit.ThousandsSeparator = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdSubItemCO)
        Me.Panel4.Controls.Add(Me.ToolBarItemCO)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(570, 572)
        Me.Panel4.TabIndex = 0
        '
        'grdSubItemCO
        '
        Me.grdSubItemCO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdSubItemCO.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdSubItemCO.Location = New System.Drawing.Point(0, 361)
        Me.grdSubItemCO.MainView = Me.grdSubItemCOView
        Me.grdSubItemCO.Name = "grdSubItemCO"
        Me.grdSubItemCO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit3})
        Me.grdSubItemCO.Size = New System.Drawing.Size(570, 211)
        Me.grdSubItemCO.TabIndex = 3
        Me.grdSubItemCO.UseEmbeddedNavigator = True
        Me.grdSubItemCO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdSubItemCOView})
        '
        'grdSubItemCOView
        '
        Me.grdSubItemCOView.GridControl = Me.grdSubItemCO
        Me.grdSubItemCOView.Name = "grdSubItemCOView"
        Me.grdSubItemCOView.OptionsCustomization.AllowColumnMoving = False
        Me.grdSubItemCOView.OptionsCustomization.AllowGroup = False
        Me.grdSubItemCOView.OptionsView.ColumnAutoWidth = False
        Me.grdSubItemCOView.OptionsView.ShowAutoFilterRow = True
        Me.grdSubItemCOView.OptionsView.ShowFooter = True
        Me.grdSubItemCOView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.NullText = "0.00"
        '
        'ToolBarItemCO
        '
        Me.ToolBarItemCO.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItemCO.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarMoveItemOrder})
        Me.ToolBarItemCO.Divider = False
        Me.ToolBarItemCO.DropDownArrows = True
        Me.ToolBarItemCO.Location = New System.Drawing.Point(0, 335)
        Me.ToolBarItemCO.Name = "ToolBarItemCO"
        Me.ToolBarItemCO.ShowToolTips = True
        Me.ToolBarItemCO.Size = New System.Drawing.Size(570, 26)
        Me.ToolBarItemCO.TabIndex = 2
        Me.ToolBarItemCO.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarMoveItemOrder
        '
        Me.BarMoveItemOrder.Name = "BarMoveItemOrder"
        Me.BarMoveItemOrder.Tag = "Submit"
        Me.BarMoveItemOrder.Text = "Pindah"
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.CadetBlue
        Me.Label54.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label54.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.White
        Me.Label54.Location = New System.Drawing.Point(0, 313)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(570, 22)
        Me.Label54.TabIndex = 1
        Me.Label54.Text = "« Subitem"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label55)
        Me.Panel6.Controls.Add(Me.Label56)
        Me.Panel6.Controls.Add(Me.txtOrderNumberSupplierCO)
        Me.Panel6.Controls.Add(Me.Label57)
        Me.Panel6.Controls.Add(Me.txtCONumberCO)
        Me.Panel6.Controls.Add(Me.Label58)
        Me.Panel6.Controls.Add(Me.Label59)
        Me.Panel6.Controls.Add(Me.Label60)
        Me.Panel6.Controls.Add(Me.Label61)
        Me.Panel6.Controls.Add(Me.txtTotalPriceCO)
        Me.Panel6.Controls.Add(Me.Label62)
        Me.Panel6.Controls.Add(Me.txtQuantityCO)
        Me.Panel6.Controls.Add(Me.Label63)
        Me.Panel6.Controls.Add(Me.Label64)
        Me.Panel6.Controls.Add(Me.txtUnitPriceCO)
        Me.Panel6.Controls.Add(Me.Label65)
        Me.Panel6.Controls.Add(Me.Label66)
        Me.Panel6.Controls.Add(Me.txtTotalWeightCO)
        Me.Panel6.Controls.Add(Me.Label68)
        Me.Panel6.Controls.Add(Me.Label69)
        Me.Panel6.Controls.Add(Me.Label70)
        Me.Panel6.Controls.Add(Me.Label71)
        Me.Panel6.Controls.Add(Me.Label72)
        Me.Panel6.Controls.Add(Me.Label73)
        Me.Panel6.Controls.Add(Me.Label74)
        Me.Panel6.Controls.Add(Me.Label75)
        Me.Panel6.Controls.Add(Me.cboItemSpecificationCO)
        Me.Panel6.Controls.Add(Me.Label76)
        Me.Panel6.Controls.Add(Me.cboItemTypeCO)
        Me.Panel6.Controls.Add(Me.Label77)
        Me.Panel6.Controls.Add(Me.Label78)
        Me.Panel6.Controls.Add(Me.txtItemCodeCO)
        Me.Panel6.Controls.Add(Me.Label79)
        Me.Panel6.Controls.Add(Me.txtItemNameCO)
        Me.Panel6.Controls.Add(Me.txtLengthCO)
        Me.Panel6.Controls.Add(Me.txtWidthCO)
        Me.Panel6.Controls.Add(Me.txtThickCO)
        Me.Panel6.Controls.Add(Me.txtMaxTotalWeightCO)
        Me.Panel6.Controls.Add(Me.txtWeightCO)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(570, 313)
        Me.Panel6.TabIndex = 0
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(14, 12)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(55, 14)
        Me.Label55.TabIndex = 192
        Me.Label55.Text = "Saat Ini"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(14, 65)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(127, 13)
        Me.Label56.TabIndex = 191
        Me.Label56.Text = "Nomor Pesanan Pemasok"
        '
        'txtOrderNumberSupplierCO
        '
        Me.txtOrderNumberSupplierCO.BackColor = System.Drawing.Color.Azure
        Me.txtOrderNumberSupplierCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderNumberSupplierCO.Location = New System.Drawing.Point(153, 61)
        Me.txtOrderNumberSupplierCO.MaxLength = 250
        Me.txtOrderNumberSupplierCO.Name = "txtOrderNumberSupplierCO"
        Me.txtOrderNumberSupplierCO.ReadOnly = True
        Me.txtOrderNumberSupplierCO.Size = New System.Drawing.Size(170, 21)
        Me.txtOrderNumberSupplierCO.TabIndex = 1
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.ForeColor = System.Drawing.Color.Black
        Me.Label57.Location = New System.Drawing.Point(14, 38)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(90, 13)
        Me.Label57.TabIndex = 189
        Me.Label57.Text = "Nomor Konfirmasi"
        '
        'txtCONumberCO
        '
        Me.txtCONumberCO.BackColor = System.Drawing.Color.Azure
        Me.txtCONumberCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCONumberCO.Location = New System.Drawing.Point(153, 34)
        Me.txtCONumberCO.MaxLength = 250
        Me.txtCONumberCO.Name = "txtCONumberCO"
        Me.txtCONumberCO.ReadOnly = True
        Me.txtCONumberCO.Size = New System.Drawing.Size(170, 21)
        Me.txtCONumberCO.TabIndex = 0
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(328, 283)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(19, 13)
        Me.Label58.TabIndex = 184
        Me.Label58.Text = "Kg"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(14, 283)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(91, 13)
        Me.Label59.TabIndex = 183
        Me.Label59.Text = "Maks. Total Berat"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(543, 255)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(19, 13)
        Me.Label60.TabIndex = 182
        Me.Label60.Text = "Kg"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.ForeColor = System.Drawing.Color.Black
        Me.Label61.Location = New System.Drawing.Point(362, 255)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(63, 13)
        Me.Label61.TabIndex = 181
        Me.Label61.Text = "Total Harga"
        '
        'txtTotalPriceCO
        '
        Me.txtTotalPriceCO.BackColor = System.Drawing.Color.Azure
        Me.txtTotalPriceCO.DecimalPlaces = 2
        Me.txtTotalPriceCO.Enabled = False
        Me.txtTotalPriceCO.Location = New System.Drawing.Point(434, 251)
        Me.txtTotalPriceCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPriceCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPriceCO.Name = "txtTotalPriceCO"
        Me.txtTotalPriceCO.Size = New System.Drawing.Size(104, 21)
        Me.txtTotalPriceCO.TabIndex = 14
        Me.txtTotalPriceCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPriceCO.ThousandsSeparator = True
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.ForeColor = System.Drawing.Color.Black
        Me.Label62.Location = New System.Drawing.Point(385, 201)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(40, 13)
        Me.Label62.TabIndex = 180
        Me.Label62.Text = "Jumlah"
        '
        'txtQuantityCO
        '
        Me.txtQuantityCO.BackColor = System.Drawing.Color.Azure
        Me.txtQuantityCO.Enabled = False
        Me.txtQuantityCO.Location = New System.Drawing.Point(434, 197)
        Me.txtQuantityCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtQuantityCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtQuantityCO.Name = "txtQuantityCO"
        Me.txtQuantityCO.Size = New System.Drawing.Size(104, 21)
        Me.txtQuantityCO.TabIndex = 12
        Me.txtQuantityCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQuantityCO.ThousandsSeparator = True
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(543, 174)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(19, 13)
        Me.Label63.TabIndex = 174
        Me.Label63.Text = "Kg"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.ForeColor = System.Drawing.Color.Black
        Me.Label64.Location = New System.Drawing.Point(389, 174)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(36, 13)
        Me.Label64.TabIndex = 173
        Me.Label64.Text = "Harga"
        '
        'txtUnitPriceCO
        '
        Me.txtUnitPriceCO.BackColor = System.Drawing.Color.Azure
        Me.txtUnitPriceCO.DecimalPlaces = 2
        Me.txtUnitPriceCO.Enabled = False
        Me.txtUnitPriceCO.Location = New System.Drawing.Point(434, 170)
        Me.txtUnitPriceCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtUnitPriceCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtUnitPriceCO.Name = "txtUnitPriceCO"
        Me.txtUnitPriceCO.Size = New System.Drawing.Size(104, 21)
        Me.txtUnitPriceCO.TabIndex = 11
        Me.txtUnitPriceCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnitPriceCO.ThousandsSeparator = True
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.ForeColor = System.Drawing.Color.Black
        Me.Label65.Location = New System.Drawing.Point(543, 228)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(19, 13)
        Me.Label65.TabIndex = 172
        Me.Label65.Text = "Kg"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.ForeColor = System.Drawing.Color.Black
        Me.Label66.Location = New System.Drawing.Point(365, 228)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(60, 13)
        Me.Label66.TabIndex = 171
        Me.Label66.Text = "Total Berat"
        '
        'txtTotalWeightCO
        '
        Me.txtTotalWeightCO.BackColor = System.Drawing.Color.Azure
        Me.txtTotalWeightCO.DecimalPlaces = 2
        Me.txtTotalWeightCO.Enabled = False
        Me.txtTotalWeightCO.Location = New System.Drawing.Point(434, 224)
        Me.txtTotalWeightCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalWeightCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalWeightCO.Name = "txtTotalWeightCO"
        Me.txtTotalWeightCO.Size = New System.Drawing.Size(104, 21)
        Me.txtTotalWeightCO.TabIndex = 13
        Me.txtTotalWeightCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalWeightCO.ThousandsSeparator = True
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.ForeColor = System.Drawing.Color.Black
        Me.Label68.Location = New System.Drawing.Point(328, 256)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(19, 13)
        Me.Label68.TabIndex = 169
        Me.Label68.Text = "Kg"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.ForeColor = System.Drawing.Color.Black
        Me.Label69.Location = New System.Drawing.Point(328, 228)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(23, 13)
        Me.Label69.TabIndex = 167
        Me.Label69.Text = "mm"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.ForeColor = System.Drawing.Color.Black
        Me.Label70.Location = New System.Drawing.Point(328, 201)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(23, 13)
        Me.Label70.TabIndex = 166
        Me.Label70.Text = "mm"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.BackColor = System.Drawing.Color.Transparent
        Me.Label71.ForeColor = System.Drawing.Color.Black
        Me.Label71.Location = New System.Drawing.Point(328, 174)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(23, 13)
        Me.Label71.TabIndex = 165
        Me.Label71.Text = "mm"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.Color.Transparent
        Me.Label72.ForeColor = System.Drawing.Color.Black
        Me.Label72.Location = New System.Drawing.Point(14, 256)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(33, 13)
        Me.Label72.TabIndex = 164
        Me.Label72.Text = "Berat"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.ForeColor = System.Drawing.Color.Black
        Me.Label73.Location = New System.Drawing.Point(14, 228)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(46, 13)
        Me.Label73.TabIndex = 163
        Me.Label73.Text = "Panjang"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.BackColor = System.Drawing.Color.Transparent
        Me.Label74.ForeColor = System.Drawing.Color.Black
        Me.Label74.Location = New System.Drawing.Point(14, 201)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(34, 13)
        Me.Label74.TabIndex = 162
        Me.Label74.Text = "Lebar"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.BackColor = System.Drawing.Color.Transparent
        Me.Label75.ForeColor = System.Drawing.Color.Black
        Me.Label75.Location = New System.Drawing.Point(14, 174)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(33, 13)
        Me.Label75.TabIndex = 161
        Me.Label75.Text = "Tebal"
        '
        'cboItemSpecificationCO
        '
        Me.cboItemSpecificationCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemSpecificationCO.Enabled = False
        Me.cboItemSpecificationCO.FormattingEnabled = True
        Me.cboItemSpecificationCO.Location = New System.Drawing.Point(434, 88)
        Me.cboItemSpecificationCO.Name = "cboItemSpecificationCO"
        Me.cboItemSpecificationCO.Size = New System.Drawing.Size(104, 21)
        Me.cboItemSpecificationCO.TabIndex = 4
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.BackColor = System.Drawing.Color.Transparent
        Me.Label76.ForeColor = System.Drawing.Color.Black
        Me.Label76.Location = New System.Drawing.Point(395, 92)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(30, 13)
        Me.Label76.TabIndex = 160
        Me.Label76.Text = "Spec"
        '
        'cboItemTypeCO
        '
        Me.cboItemTypeCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemTypeCO.Enabled = False
        Me.cboItemTypeCO.FormattingEnabled = True
        Me.cboItemTypeCO.Location = New System.Drawing.Point(434, 61)
        Me.cboItemTypeCO.Name = "cboItemTypeCO"
        Me.cboItemTypeCO.Size = New System.Drawing.Size(104, 21)
        Me.cboItemTypeCO.TabIndex = 3
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.BackColor = System.Drawing.Color.Transparent
        Me.Label77.ForeColor = System.Drawing.Color.Black
        Me.Label77.Location = New System.Drawing.Point(394, 65)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(31, 13)
        Me.Label77.TabIndex = 159
        Me.Label77.Text = "Jenis"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.BackColor = System.Drawing.Color.Transparent
        Me.Label78.ForeColor = System.Drawing.Color.Black
        Me.Label78.Location = New System.Drawing.Point(14, 92)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(68, 13)
        Me.Label78.TabIndex = 158
        Me.Label78.Text = "Kode Barang"
        '
        'txtItemCodeCO
        '
        Me.txtItemCodeCO.BackColor = System.Drawing.Color.Azure
        Me.txtItemCodeCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCodeCO.Location = New System.Drawing.Point(153, 88)
        Me.txtItemCodeCO.MaxLength = 250
        Me.txtItemCodeCO.Name = "txtItemCodeCO"
        Me.txtItemCodeCO.ReadOnly = True
        Me.txtItemCodeCO.Size = New System.Drawing.Size(170, 21)
        Me.txtItemCodeCO.TabIndex = 2
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.BackColor = System.Drawing.Color.Transparent
        Me.Label79.ForeColor = System.Drawing.Color.Black
        Me.Label79.Location = New System.Drawing.Point(14, 119)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(71, 13)
        Me.Label79.TabIndex = 157
        Me.Label79.Text = "Nama Barang"
        '
        'txtItemNameCO
        '
        Me.txtItemNameCO.BackColor = System.Drawing.Color.Azure
        Me.txtItemNameCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemNameCO.Location = New System.Drawing.Point(153, 116)
        Me.txtItemNameCO.MaxLength = 250
        Me.txtItemNameCO.Multiline = True
        Me.txtItemNameCO.Name = "txtItemNameCO"
        Me.txtItemNameCO.ReadOnly = True
        Me.txtItemNameCO.Size = New System.Drawing.Size(385, 48)
        Me.txtItemNameCO.TabIndex = 5
        '
        'txtLengthCO
        '
        Me.txtLengthCO.BackColor = System.Drawing.Color.Azure
        Me.txtLengthCO.DecimalPlaces = 2
        Me.txtLengthCO.Enabled = False
        Me.txtLengthCO.Location = New System.Drawing.Point(153, 224)
        Me.txtLengthCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtLengthCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtLengthCO.Name = "txtLengthCO"
        Me.txtLengthCO.Size = New System.Drawing.Size(170, 21)
        Me.txtLengthCO.TabIndex = 8
        Me.txtLengthCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLengthCO.ThousandsSeparator = True
        '
        'txtWidthCO
        '
        Me.txtWidthCO.BackColor = System.Drawing.Color.Azure
        Me.txtWidthCO.DecimalPlaces = 2
        Me.txtWidthCO.Enabled = False
        Me.txtWidthCO.Location = New System.Drawing.Point(153, 197)
        Me.txtWidthCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWidthCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWidthCO.Name = "txtWidthCO"
        Me.txtWidthCO.Size = New System.Drawing.Size(170, 21)
        Me.txtWidthCO.TabIndex = 7
        Me.txtWidthCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidthCO.ThousandsSeparator = True
        '
        'txtThickCO
        '
        Me.txtThickCO.BackColor = System.Drawing.Color.Azure
        Me.txtThickCO.DecimalPlaces = 2
        Me.txtThickCO.Enabled = False
        Me.txtThickCO.Location = New System.Drawing.Point(153, 170)
        Me.txtThickCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtThickCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtThickCO.Name = "txtThickCO"
        Me.txtThickCO.Size = New System.Drawing.Size(170, 21)
        Me.txtThickCO.TabIndex = 6
        Me.txtThickCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThickCO.ThousandsSeparator = True
        '
        'txtMaxTotalWeightCO
        '
        Me.txtMaxTotalWeightCO.BackColor = System.Drawing.Color.Azure
        Me.txtMaxTotalWeightCO.DecimalPlaces = 2
        Me.txtMaxTotalWeightCO.Enabled = False
        Me.txtMaxTotalWeightCO.Location = New System.Drawing.Point(153, 279)
        Me.txtMaxTotalWeightCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtMaxTotalWeightCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtMaxTotalWeightCO.Name = "txtMaxTotalWeightCO"
        Me.txtMaxTotalWeightCO.Size = New System.Drawing.Size(170, 21)
        Me.txtMaxTotalWeightCO.TabIndex = 10
        Me.txtMaxTotalWeightCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxTotalWeightCO.ThousandsSeparator = True
        '
        'txtWeightCO
        '
        Me.txtWeightCO.BackColor = System.Drawing.Color.Azure
        Me.txtWeightCO.DecimalPlaces = 2
        Me.txtWeightCO.Enabled = False
        Me.txtWeightCO.Location = New System.Drawing.Point(153, 252)
        Me.txtWeightCO.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtWeightCO.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtWeightCO.Name = "txtWeightCO"
        Me.txtWeightCO.Size = New System.Drawing.Size(170, 21)
        Me.txtWeightCO.TabIndex = 9
        Me.txtWeightCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWeightCO.ThousandsSeparator = True
        '
        'tpDownPayment
        '
        Me.tpDownPayment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpDownPayment.Controls.Add(Me.TableLayoutPanel3)
        Me.tpDownPayment.Location = New System.Drawing.Point(4, 25)
        Me.tpDownPayment.Name = "tpDownPayment"
        Me.tpDownPayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDownPayment.Size = New System.Drawing.Size(1156, 582)
        Me.tpDownPayment.TabIndex = 2
        Me.tpDownPayment.Text = "Down Payment - F3"
        Me.tpDownPayment.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel9, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel8, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1146, 572)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.grdDownPayment)
        Me.Panel9.Controls.Add(Me.ToolBarDP)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(567, 566)
        Me.Panel9.TabIndex = 5
        '
        'grdDownPayment
        '
        Me.grdDownPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdDownPayment.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdDownPayment.Location = New System.Drawing.Point(0, 26)
        Me.grdDownPayment.MainView = Me.grdDownPaymentView
        Me.grdDownPayment.Name = "grdDownPayment"
        Me.grdDownPayment.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdDownPayment.Size = New System.Drawing.Size(567, 540)
        Me.grdDownPayment.TabIndex = 11
        Me.grdDownPayment.UseEmbeddedNavigator = True
        Me.grdDownPayment.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDownPaymentView})
        '
        'grdDownPaymentView
        '
        Me.grdDownPaymentView.GridControl = Me.grdDownPayment
        Me.grdDownPaymentView.Name = "grdDownPaymentView"
        Me.grdDownPaymentView.OptionsCustomization.AllowColumnMoving = False
        Me.grdDownPaymentView.OptionsCustomization.AllowGroup = False
        Me.grdDownPaymentView.OptionsView.ColumnAutoWidth = False
        Me.grdDownPaymentView.OptionsView.ShowAutoFilterRow = True
        Me.grdDownPaymentView.OptionsView.ShowGroupPanel = False
        '
        'rpiValue
        '
        Me.rpiValue.AutoHeight = False
        Me.rpiValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiValue.Name = "rpiValue"
        Me.rpiValue.NullText = "0.00"
        '
        'ToolBarDP
        '
        Me.ToolBarDP.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDP.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarMoveDP})
        Me.ToolBarDP.Divider = False
        Me.ToolBarDP.DropDownArrows = True
        Me.ToolBarDP.Location = New System.Drawing.Point(0, 0)
        Me.ToolBarDP.Name = "ToolBarDP"
        Me.ToolBarDP.ShowToolTips = True
        Me.ToolBarDP.Size = New System.Drawing.Size(567, 26)
        Me.ToolBarDP.TabIndex = 4
        Me.ToolBarDP.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarMoveDP
        '
        Me.BarMoveDP.Name = "BarMoveDP"
        Me.BarMoveDP.Tag = "Submit"
        Me.BarMoveDP.Text = "Pindah"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdDownPaymentSplit)
        Me.Panel8.Controls.Add(Me.ToolBarDPSplit)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(576, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(567, 566)
        Me.Panel8.TabIndex = 4
        '
        'grdDownPaymentSplit
        '
        Me.grdDownPaymentSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdDownPaymentSplit.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdDownPaymentSplit.Location = New System.Drawing.Point(0, 26)
        Me.grdDownPaymentSplit.MainView = Me.grdDownPaymentSplitView
        Me.grdDownPaymentSplit.Name = "grdDownPaymentSplit"
        Me.grdDownPaymentSplit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit5})
        Me.grdDownPaymentSplit.Size = New System.Drawing.Size(567, 540)
        Me.grdDownPaymentSplit.TabIndex = 11
        Me.grdDownPaymentSplit.UseEmbeddedNavigator = True
        Me.grdDownPaymentSplit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDownPaymentSplitView})
        '
        'grdDownPaymentSplitView
        '
        Me.grdDownPaymentSplitView.GridControl = Me.grdDownPaymentSplit
        Me.grdDownPaymentSplitView.Name = "grdDownPaymentSplitView"
        Me.grdDownPaymentSplitView.OptionsCustomization.AllowColumnMoving = False
        Me.grdDownPaymentSplitView.OptionsCustomization.AllowGroup = False
        Me.grdDownPaymentSplitView.OptionsView.ColumnAutoWidth = False
        Me.grdDownPaymentSplitView.OptionsView.ShowAutoFilterRow = True
        Me.grdDownPaymentSplitView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit5
        '
        Me.RepositoryItemTextEdit5.AutoHeight = False
        Me.RepositoryItemTextEdit5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5"
        Me.RepositoryItemTextEdit5.NullText = "0.00"
        '
        'ToolBarDPSplit
        '
        Me.ToolBarDPSplit.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDPSplit.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarDeleteDPSplit})
        Me.ToolBarDPSplit.Divider = False
        Me.ToolBarDPSplit.DropDownArrows = True
        Me.ToolBarDPSplit.Location = New System.Drawing.Point(0, 0)
        Me.ToolBarDPSplit.Name = "ToolBarDPSplit"
        Me.ToolBarDPSplit.ShowToolTips = True
        Me.ToolBarDPSplit.Size = New System.Drawing.Size(567, 26)
        Me.ToolBarDPSplit.TabIndex = 4
        Me.ToolBarDPSplit.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarDeleteDPSplit
        '
        Me.BarDeleteDPSplit.Name = "BarDeleteDPSplit"
        Me.BarDeleteDPSplit.Tag = "Delete"
        Me.BarDeleteDPSplit.Text = "Hapus"
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(1164, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Split Barang"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmTraSalesContractDetVer2SplitItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1164, 661)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmTraSalesContractDetVer2SplitItem"
        Me.Text = "Split"
        Me.tcHeader.ResumeLayout(False)
        Me.tpSalesContract.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdSubitemSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSubitemSplitView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txtUnitPriceHPPSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLengthSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidthSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThickSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxTotalWeightSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPriceSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantitySplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUnitPriceSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalWeightSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeightSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdSubitem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSubitemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.txtUnitPriceHPP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxTotalWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpConfirmationOrder.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.grdSubItemCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSubItemCOSplitView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.txtTotalPriceCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantityCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUnitPriceCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalWeightCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLengthCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidthCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThickCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxTotalWeightCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeightCOSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.grdSubItemCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSubItemCOView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.txtTotalPriceCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantityCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUnitPriceCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalWeightCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLengthCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidthCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThickCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxTotalWeightCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeightCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDownPayment.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.grdDownPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDownPaymentView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.grdDownPaymentSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDownPaymentSplitView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents tcHeader As System.Windows.Forms.TabControl
    Friend WithEvents tpSalesContract As System.Windows.Forms.TabPage
    Friend WithEvents tpConfirmationOrder As System.Windows.Forms.TabPage
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPriceHPP As ERPS.usNumeric
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRequestNumber As ERPS.usTextBox
    Friend WithEvents txtLength As ERPS.usNumeric
    Friend WithEvents txtWidth As ERPS.usNumeric
    Friend WithEvents txtThick As ERPS.usNumeric
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtMaxTotalWeight As ERPS.usNumeric
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As ERPS.usNumeric
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As ERPS.usNumeric
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As ERPS.usNumeric
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As ERPS.usNumeric
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As ERPS.usNumeric
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboItemSpecification As ERPS.usComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboItemType As ERPS.usComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As ERPS.usTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtItemName As ERPS.usTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ToolBarItemSubitem As ERPS.usToolBar
    Friend WithEvents grdSubitem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdSubitemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdSubitemSplit As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdSubitemSplitView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ToolBarItemSubitemSplit As ERPS.usToolBar
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPriceHPPSplit As ERPS.usNumeric
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtRequestNumberSplit As ERPS.usTextBox
    Friend WithEvents txtLengthSplit As ERPS.usNumeric
    Friend WithEvents txtWidthSplit As ERPS.usNumeric
    Friend WithEvents txtThickSplit As ERPS.usNumeric
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtMaxTotalWeightSplit As ERPS.usNumeric
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPriceSplit As ERPS.usNumeric
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtQuantitySplit As ERPS.usNumeric
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPriceSplit As ERPS.usNumeric
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeightSplit As ERPS.usNumeric
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtWeightSplit As ERPS.usNumeric
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents cboItemSpecificationSplit As ERPS.usComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cboItemTypeSplit As ERPS.usComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtItemCodeSplit As ERPS.usTextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtItemNameSplit As ERPS.usTextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ToolBarItemCOSplit As ERPS.usToolBar
    Friend WithEvents BarMoveItemOrderSplit As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarItemCO As ERPS.usToolBar
    Friend WithEvents BarMoveItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdSubItemCOSplit As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdSubItemCOSplitView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdSubItemCO As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdSubItemCOView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarMoveSubItemSplit As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarMoveSubItem As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNumberSupplierCO As ERPS.usTextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtCONumberCO As ERPS.usTextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPriceCO As ERPS.usNumeric
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents txtQuantityCO As ERPS.usNumeric
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPriceCO As ERPS.usNumeric
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeightCO As ERPS.usNumeric
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents cboItemSpecificationCO As ERPS.usComboBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents cboItemTypeCO As ERPS.usComboBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents txtItemCodeCO As ERPS.usTextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents txtItemNameCO As ERPS.usTextBox
    Friend WithEvents txtLengthCO As ERPS.usNumeric
    Friend WithEvents txtWidthCO As ERPS.usNumeric
    Friend WithEvents txtThickCO As ERPS.usNumeric
    Friend WithEvents txtMaxTotalWeightCO As ERPS.usNumeric
    Friend WithEvents txtWeightCO As ERPS.usNumeric
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNumberSupplierCOSplit As ERPS.usTextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents txtCONumberCOSplit As ERPS.usTextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPriceCOSplit As ERPS.usNumeric
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents txtQuantityCOSplit As ERPS.usNumeric
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPriceCOSplit As ERPS.usNumeric
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeightCOSplit As ERPS.usNumeric
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents cboItemSpecificationCOSplit As ERPS.usComboBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents cboItemTypeCOSplit As ERPS.usComboBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents txtItemCodeCOSplit As ERPS.usTextBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents txtItemNameCOSplit As ERPS.usTextBox
    Friend WithEvents txtLengthCOSplit As ERPS.usNumeric
    Friend WithEvents txtWidthCOSplit As ERPS.usNumeric
    Friend WithEvents txtThickCOSplit As ERPS.usNumeric
    Friend WithEvents txtMaxTotalWeightCOSplit As ERPS.usNumeric
    Friend WithEvents txtWeightCOSplit As ERPS.usNumeric
    Friend WithEvents tpDownPayment As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents ToolBarDP As ERPS.usToolBar
    Friend WithEvents BarMoveDP As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents ToolBarDPSplit As ERPS.usToolBar
    Friend WithEvents grdDownPayment As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDownPaymentView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdDownPaymentSplit As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDownPaymentSplitView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarDeleteDPSplit As System.Windows.Forms.ToolBarButton
End Class
