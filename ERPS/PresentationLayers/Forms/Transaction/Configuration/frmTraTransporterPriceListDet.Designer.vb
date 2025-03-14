<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraTransporterPriceListDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraTransporterPriceListDet))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.txtTransporterCode = New ERPS.usTextBox()
        Me.txtTransporterName = New ERPS.usTextBox()
        Me.btnTransporter = New DevExpress.XtraEditors.SimpleButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.txtDeliveryNumber = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboStatus = New ERPS.usComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolBarItem = New ERPS.usToolBar()
        Me.grdItem = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.cboTransporterPriceType = New ERPS.usComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BarAdd = New System.Windows.Forms.ToolBarButton()
        Me.BarEdit = New System.Windows.Forms.ToolBarButton()
        Me.BarDelete = New System.Windows.Forms.ToolBarButton()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(914, 28)
        Me.ToolBar.TabIndex = 1
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
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 638)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(914, 23)
        Me.pgMain.TabIndex = 6
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Location = New System.Drawing.Point(0, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(914, 22)
        Me.lblInfo.TabIndex = 7
        Me.lblInfo.Text = "« Price List Transportasi Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(914, 164)
        Me.tcHeader.TabIndex = 8
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.cboTransporterPriceType)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.txtTransporterCode)
        Me.tpMain.Controls.Add(Me.txtTransporterName)
        Me.tpMain.Controls.Add(Me.btnTransporter)
        Me.tpMain.Controls.Add(Me.Label22)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.txtDeliveryNumber)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.lblStatusID)
        Me.tpMain.Controls.Add(Me.dtpDeliveryDate)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(906, 135)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtTransporterCode
        '
        Me.txtTransporterCode.BackColor = System.Drawing.Color.Azure
        Me.txtTransporterCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransporterCode.Location = New System.Drawing.Point(159, 38)
        Me.txtTransporterCode.MaxLength = 250
        Me.txtTransporterCode.Name = "txtTransporterCode"
        Me.txtTransporterCode.ReadOnly = True
        Me.txtTransporterCode.Size = New System.Drawing.Size(83, 21)
        Me.txtTransporterCode.TabIndex = 4
        '
        'txtTransporterName
        '
        Me.txtTransporterName.BackColor = System.Drawing.Color.Azure
        Me.txtTransporterName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransporterName.Location = New System.Drawing.Point(241, 38)
        Me.txtTransporterName.MaxLength = 250
        Me.txtTransporterName.Name = "txtTransporterName"
        Me.txtTransporterName.ReadOnly = True
        Me.txtTransporterName.Size = New System.Drawing.Size(167, 21)
        Me.txtTransporterName.TabIndex = 5
        '
        'btnTransporter
        '
        Me.btnTransporter.Image = CType(resources.GetObject("btnTransporter.Image"), System.Drawing.Image)
        Me.btnTransporter.Location = New System.Drawing.Point(414, 37)
        Me.btnTransporter.Name = "btnTransporter"
        Me.btnTransporter.Size = New System.Drawing.Size(23, 23)
        Me.btnTransporter.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(28, 42)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 13)
        Me.Label22.TabIndex = 199
        Me.Label22.Text = "Transporter"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(619, 38)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 19
        '
        'txtDeliveryNumber
        '
        Me.txtDeliveryNumber.BackColor = System.Drawing.Color.White
        Me.txtDeliveryNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryNumber.Location = New System.Drawing.Point(159, 11)
        Me.txtDeliveryNumber.MaxLength = 250
        Me.txtDeliveryNumber.Name = "txtDeliveryNumber"
        Me.txtDeliveryNumber.Size = New System.Drawing.Size(167, 21)
        Me.txtDeliveryNumber.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(506, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(619, 11)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(249, 21)
        Me.cboStatus.TabIndex = 18
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(506, 15)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusID.TabIndex = 128
        Me.lblStatusID.Text = "Status"
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDeliveryDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(159, 65)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(83, 21)
        Me.dtpDeliveryDate.TabIndex = 9
        Me.dtpDeliveryDate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Tanggal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Nomor"
        '
        'tpHistory
        '
        Me.tpHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHistory.Size = New System.Drawing.Size(906, 236)
        Me.tpHistory.TabIndex = 1
        Me.tpHistory.Text = "History - F2"
        Me.tpHistory.UseVisualStyleBackColor = True
        '
        'grdStatus
        '
        Me.grdStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdStatus.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdStatus.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdStatus.Location = New System.Drawing.Point(3, 3)
        Me.grdStatus.MainView = Me.grdStatusView
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.Size = New System.Drawing.Size(896, 226)
        Me.grdStatus.TabIndex = 13
        Me.grdStatus.UseEmbeddedNavigator = True
        Me.grdStatus.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdStatusView})
        '
        'grdStatusView
        '
        Me.grdStatusView.GridControl = Me.grdStatus
        Me.grdStatusView.Name = "grdStatusView"
        Me.grdStatusView.OptionsCustomization.AllowColumnMoving = False
        Me.grdStatusView.OptionsCustomization.AllowGroup = False
        Me.grdStatusView.OptionsView.ColumnAutoWidth = False
        Me.grdStatusView.OptionsView.ShowGroupPanel = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(914, 22)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "« Lokasi Pengiriman"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBarItem
        '
        Me.ToolBarItem.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarItem.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAdd, Me.BarEdit, Me.BarDelete})
        Me.ToolBarItem.DropDownArrows = True
        Me.ToolBarItem.Location = New System.Drawing.Point(0, 236)
        Me.ToolBarItem.Name = "ToolBarItem"
        Me.ToolBarItem.ShowToolTips = True
        Me.ToolBarItem.Size = New System.Drawing.Size(914, 28)
        Me.ToolBarItem.TabIndex = 10
        Me.ToolBarItem.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
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
        Me.grdItem.Location = New System.Drawing.Point(0, 264)
        Me.grdItem.MainView = Me.grdItemView
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.grdItem.Size = New System.Drawing.Size(914, 374)
        Me.grdItem.TabIndex = 11
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
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "0.00"
        '
        'cboTransporterPriceType
        '
        Me.cboTransporterPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransporterPriceType.FormattingEnabled = True
        Me.cboTransporterPriceType.Location = New System.Drawing.Point(159, 92)
        Me.cboTransporterPriceType.Name = "cboTransporterPriceType"
        Me.cboTransporterPriceType.Size = New System.Drawing.Size(249, 21)
        Me.cboTransporterPriceType.TabIndex = 207
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(28, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 208
        Me.Label3.Text = "Jenis Harga"
        '
        'BarAdd
        '
        Me.BarAdd.Name = "BarAdd"
        Me.BarAdd.Tag = "Add"
        Me.BarAdd.Text = "Tambah"
        '
        'BarEdit
        '
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.Tag = "Edit"
        Me.BarEdit.Text = "Edit"
        '
        'BarDelete
        '
        Me.BarDelete.Name = "BarDelete"
        Me.BarDelete.Tag = "Delete"
        Me.BarDelete.Text = "Hapus"
        '
        'frmTraTransporterPriceListDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 661)
        Me.Controls.Add(Me.grdItem)
        Me.Controls.Add(Me.ToolBarItem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraTransporterPriceListDet"
        Me.Text = "Price List Transportasi"
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tcHeader As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents txtTransporterCode As ERPS.usTextBox
    Friend WithEvents txtTransporterName As ERPS.usTextBox
    Friend WithEvents btnTransporter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As ERPS.usTextBox
    Friend WithEvents txtDeliveryNumber As ERPS.usTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tpHistory As System.Windows.Forms.TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolBarItem As ERPS.usToolBar
    Friend WithEvents grdItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cboTransporterPriceType As ERPS.usComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BarAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDelete As System.Windows.Forms.ToolBarButton
End Class
