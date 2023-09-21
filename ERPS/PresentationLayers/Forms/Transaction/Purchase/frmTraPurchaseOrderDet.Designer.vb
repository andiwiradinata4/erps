<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraPurchaseOrderDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraPurchaseOrderDet))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tcHeader = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.txtValidity = New ERPS.usTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtDeliveryAddress = New ERPS.usTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpDeliveryPeriodTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDeliveryPeriodFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPersonInCharge = New ERPS.usTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnPermintaan = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOrderNumber = New ERPS.usTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRemarks = New ERPS.usTextBox()
        Me.cboStatus = New ERPS.usComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.dtpPODate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBPCode = New ERPS.usTextBox()
        Me.btnBP = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBPName = New ERPS.usTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPONumber = New ERPS.usTextBox()
        Me.tpAmount = New System.Windows.Forms.TabPage()
        Me.gboPesanan = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGrandTotalOrder = New ERPS.usNumeric()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalPPHOrder = New ERPS.usNumeric()
        Me.txtTotalDPPOrder = New ERPS.usNumeric()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotalPPNOrder = New ERPS.usNumeric()
        Me.Permintaan = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGrandTotalRequest = New ERPS.usNumeric()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalPPHRequest = New ERPS.usNumeric()
        Me.txtTotalDPPRequest = New ERPS.usNumeric()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalPPNRequest = New ERPS.usNumeric()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPPH = New ERPS.usNumeric()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPPN = New ERPS.usNumeric()
        Me.tpPaymentTerm = New System.Windows.Forms.TabPage()
        Me.grdPaymentTerm = New DevExpress.XtraGrid.GridControl()
        Me.grdPaymentTermView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarPaymentTerm = New ERPS.usToolBar()
        Me.BarAddPayment = New System.Windows.Forms.ToolBarButton()
        Me.BarEditPayment = New System.Windows.Forms.ToolBarButton()
        Me.BarDeletePayment = New System.Windows.Forms.ToolBarButton()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.grdStatus = New DevExpress.XtraGrid.GridControl()
        Me.grdStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogInc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLogDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tcDetail = New System.Windows.Forms.TabControl()
        Me.tpRequest = New System.Windows.Forms.TabPage()
        Me.grdItemRequest = New DevExpress.XtraGrid.GridControl()
        Me.grdItemRequestView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rpiValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarDetailRequest = New ERPS.usToolBar()
        Me.BarAddItemRequest = New System.Windows.Forms.ToolBarButton()
        Me.BarDetailItemRequest = New System.Windows.Forms.ToolBarButton()
        Me.BarDeleteItemRequest = New System.Windows.Forms.ToolBarButton()
        Me.tpOrder = New System.Windows.Forms.TabPage()
        Me.grdItemOrder = New DevExpress.XtraGrid.GridControl()
        Me.grdItemOrderView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBarDetailOrder = New ERPS.usToolBar()
        Me.BarAddItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDetailItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.BarDeleteItemOrder = New System.Windows.Forms.ToolBarButton()
        Me.tcHeader.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.tpAmount.SuspendLayout()
        Me.gboPesanan.SuspendLayout()
        CType(Me.txtGrandTotalOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPHOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDPPOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPNOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Permintaan.SuspendLayout()
        CType(Me.txtGrandTotalRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPHRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDPPRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPNRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPaymentTerm.SuspendLayout()
        CType(Me.grdPaymentTerm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPaymentTermView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistory.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.tcDetail.SuspendLayout()
        Me.tpRequest.SuspendLayout()
        CType(Me.grdItemRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemRequestView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpOrder.SuspendLayout()
        CType(Me.grdItemOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemOrderView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar.Size = New System.Drawing.Size(884, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(884, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Pesanan Pembelian Detail"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcHeader
        '
        Me.tcHeader.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcHeader.Controls.Add(Me.tpMain)
        Me.tcHeader.Controls.Add(Me.tpAmount)
        Me.tcHeader.Controls.Add(Me.tpPaymentTerm)
        Me.tcHeader.Controls.Add(Me.tpHistory)
        Me.tcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcHeader.Location = New System.Drawing.Point(0, 50)
        Me.tcHeader.Name = "tcHeader"
        Me.tcHeader.SelectedIndex = 0
        Me.tcHeader.Size = New System.Drawing.Size(884, 231)
        Me.tcHeader.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpMain.Controls.Add(Me.txtValidity)
        Me.tpMain.Controls.Add(Me.Label23)
        Me.tpMain.Controls.Add(Me.txtDeliveryAddress)
        Me.tpMain.Controls.Add(Me.Label22)
        Me.tpMain.Controls.Add(Me.Label21)
        Me.tpMain.Controls.Add(Me.dtpDeliveryPeriodTo)
        Me.tpMain.Controls.Add(Me.dtpDeliveryPeriodFrom)
        Me.tpMain.Controls.Add(Me.Label20)
        Me.tpMain.Controls.Add(Me.txtPersonInCharge)
        Me.tpMain.Controls.Add(Me.Label19)
        Me.tpMain.Controls.Add(Me.btnPermintaan)
        Me.tpMain.Controls.Add(Me.Label5)
        Me.tpMain.Controls.Add(Me.txtOrderNumber)
        Me.tpMain.Controls.Add(Me.Label13)
        Me.tpMain.Controls.Add(Me.txtRemarks)
        Me.tpMain.Controls.Add(Me.cboStatus)
        Me.tpMain.Controls.Add(Me.lblStatusID)
        Me.tpMain.Controls.Add(Me.dtpPODate)
        Me.tpMain.Controls.Add(Me.Label4)
        Me.tpMain.Controls.Add(Me.txtBPCode)
        Me.tpMain.Controls.Add(Me.btnBP)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.txtBPName)
        Me.tpMain.Controls.Add(Me.Label2)
        Me.tpMain.Controls.Add(Me.txtPONumber)
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(876, 202)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main - F1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'txtValidity
        '
        Me.txtValidity.BackColor = System.Drawing.Color.White
        Me.txtValidity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValidity.Location = New System.Drawing.Point(572, 70)
        Me.txtValidity.MaxLength = 250
        Me.txtValidity.Name = "txtValidity"
        Me.txtValidity.Size = New System.Drawing.Size(249, 21)
        Me.txtValidity.TabIndex = 11
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(459, 74)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 13)
        Me.Label23.TabIndex = 140
        Me.Label23.Text = "Validity"
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.BackColor = System.Drawing.Color.White
        Me.txtDeliveryAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(572, 43)
        Me.txtDeliveryAddress.MaxLength = 250
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(249, 21)
        Me.txtDeliveryAddress.TabIndex = 10
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(459, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 13)
        Me.Label22.TabIndex = 138
        Me.Label22.Text = "Alamat Pengiriman"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(687, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 137
        Me.Label21.Text = "-"
        '
        'dtpDeliveryPeriodTo
        '
        Me.dtpDeliveryPeriodTo.CustomFormat = "MMMM yyyy"
        Me.dtpDeliveryPeriodTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDeliveryPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliveryPeriodTo.Location = New System.Drawing.Point(712, 16)
        Me.dtpDeliveryPeriodTo.Name = "dtpDeliveryPeriodTo"
        Me.dtpDeliveryPeriodTo.ShowUpDown = True
        Me.dtpDeliveryPeriodTo.Size = New System.Drawing.Size(109, 21)
        Me.dtpDeliveryPeriodTo.TabIndex = 9
        Me.dtpDeliveryPeriodTo.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'dtpDeliveryPeriodFrom
        '
        Me.dtpDeliveryPeriodFrom.CustomFormat = "MMMM yyyy"
        Me.dtpDeliveryPeriodFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDeliveryPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliveryPeriodFrom.Location = New System.Drawing.Point(572, 16)
        Me.dtpDeliveryPeriodFrom.Name = "dtpDeliveryPeriodFrom"
        Me.dtpDeliveryPeriodFrom.ShowUpDown = True
        Me.dtpDeliveryPeriodFrom.Size = New System.Drawing.Size(109, 21)
        Me.dtpDeliveryPeriodFrom.TabIndex = 8
        Me.dtpDeliveryPeriodFrom.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(459, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 13)
        Me.Label20.TabIndex = 135
        Me.Label20.Text = "Periode Pengiriman"
        '
        'txtPersonInCharge
        '
        Me.txtPersonInCharge.BackColor = System.Drawing.Color.White
        Me.txtPersonInCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonInCharge.Location = New System.Drawing.Point(141, 124)
        Me.txtPersonInCharge.MaxLength = 250
        Me.txtPersonInCharge.Name = "txtPersonInCharge"
        Me.txtPersonInCharge.Size = New System.Drawing.Size(249, 21)
        Me.txtPersonInCharge.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(28, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(24, 13)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "PIC"
        '
        'btnPermintaan
        '
        Me.btnPermintaan.Image = CType(resources.GetObject("btnPermintaan.Image"), System.Drawing.Image)
        Me.btnPermintaan.Location = New System.Drawing.Point(396, 96)
        Me.btnPermintaan.Name = "btnPermintaan"
        Me.btnPermintaan.Size = New System.Drawing.Size(23, 23)
        Me.btnPermintaan.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "No. Permintaan"
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.BackColor = System.Drawing.Color.Azure
        Me.txtOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderNumber.Location = New System.Drawing.Point(141, 97)
        Me.txtOrderNumber.MaxLength = 250
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.ReadOnly = True
        Me.txtOrderNumber.Size = New System.Drawing.Size(249, 21)
        Me.txtOrderNumber.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(459, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Keterangan"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(572, 124)
        Me.txtRemarks.MaxLength = 250
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 48)
        Me.txtRemarks.TabIndex = 13
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(572, 97)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(124, 21)
        Me.cboStatus.TabIndex = 12
        '
        'lblStatusID
        '
        Me.lblStatusID.AutoSize = True
        Me.lblStatusID.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusID.ForeColor = System.Drawing.Color.Black
        Me.lblStatusID.Location = New System.Drawing.Point(459, 101)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusID.TabIndex = 128
        Me.lblStatusID.Text = "Status"
        '
        'dtpPODate
        '
        Me.dtpPODate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPODate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPODate.Location = New System.Drawing.Point(141, 70)
        Me.dtpPODate.Name = "dtpPODate"
        Me.dtpPODate.Size = New System.Drawing.Size(105, 21)
        Me.dtpPODate.TabIndex = 4
        Me.dtpPODate.Value = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Tanggal"
        '
        'txtBPCode
        '
        Me.txtBPCode.BackColor = System.Drawing.Color.Azure
        Me.txtBPCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPCode.Location = New System.Drawing.Point(141, 43)
        Me.txtBPCode.MaxLength = 250
        Me.txtBPCode.Name = "txtBPCode"
        Me.txtBPCode.ReadOnly = True
        Me.txtBPCode.Size = New System.Drawing.Size(83, 21)
        Me.txtBPCode.TabIndex = 1
        '
        'btnBP
        '
        Me.btnBP.Image = CType(resources.GetObject("btnBP.Image"), System.Drawing.Image)
        Me.btnBP.Location = New System.Drawing.Point(396, 42)
        Me.btnBP.Name = "btnBP"
        Me.btnBP.Size = New System.Drawing.Size(23, 23)
        Me.btnBP.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(28, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Pemasok"
        '
        'txtBPName
        '
        Me.txtBPName.BackColor = System.Drawing.Color.Azure
        Me.txtBPName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBPName.Location = New System.Drawing.Point(223, 43)
        Me.txtBPName.MaxLength = 250
        Me.txtBPName.Name = "txtBPName"
        Me.txtBPName.ReadOnly = True
        Me.txtBPName.Size = New System.Drawing.Size(167, 21)
        Me.txtBPName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Nomor"
        '
        'txtPONumber
        '
        Me.txtPONumber.BackColor = System.Drawing.Color.LightYellow
        Me.txtPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPONumber.Location = New System.Drawing.Point(141, 16)
        Me.txtPONumber.MaxLength = 250
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.ReadOnly = True
        Me.txtPONumber.Size = New System.Drawing.Size(167, 21)
        Me.txtPONumber.TabIndex = 0
        '
        'tpAmount
        '
        Me.tpAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpAmount.Controls.Add(Me.gboPesanan)
        Me.tpAmount.Controls.Add(Me.Permintaan)
        Me.tpAmount.Controls.Add(Me.Label7)
        Me.tpAmount.Controls.Add(Me.Label8)
        Me.tpAmount.Controls.Add(Me.txtPPH)
        Me.tpAmount.Controls.Add(Me.Label6)
        Me.tpAmount.Controls.Add(Me.Label11)
        Me.tpAmount.Controls.Add(Me.txtPPN)
        Me.tpAmount.Location = New System.Drawing.Point(4, 25)
        Me.tpAmount.Name = "tpAmount"
        Me.tpAmount.Size = New System.Drawing.Size(876, 202)
        Me.tpAmount.TabIndex = 2
        Me.tpAmount.Text = "Harga - F2"
        Me.tpAmount.UseVisualStyleBackColor = True
        '
        'gboPesanan
        '
        Me.gboPesanan.Controls.Add(Me.Label15)
        Me.gboPesanan.Controls.Add(Me.txtGrandTotalOrder)
        Me.gboPesanan.Controls.Add(Me.Label16)
        Me.gboPesanan.Controls.Add(Me.txtTotalPPHOrder)
        Me.gboPesanan.Controls.Add(Me.txtTotalDPPOrder)
        Me.gboPesanan.Controls.Add(Me.Label17)
        Me.gboPesanan.Controls.Add(Me.Label18)
        Me.gboPesanan.Controls.Add(Me.txtTotalPPNOrder)
        Me.gboPesanan.Location = New System.Drawing.Point(381, 13)
        Me.gboPesanan.Name = "gboPesanan"
        Me.gboPesanan.Size = New System.Drawing.Size(334, 138)
        Me.gboPesanan.TabIndex = 1
        Me.gboPesanan.TabStop = False
        Me.gboPesanan.Text = "Pesanan"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(19, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "Grand Total"
        '
        'txtGrandTotalOrder
        '
        Me.txtGrandTotalOrder.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotalOrder.DecimalPlaces = 2
        Me.txtGrandTotalOrder.Enabled = False
        Me.txtGrandTotalOrder.Location = New System.Drawing.Point(115, 104)
        Me.txtGrandTotalOrder.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotalOrder.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotalOrder.Name = "txtGrandTotalOrder"
        Me.txtGrandTotalOrder.Size = New System.Drawing.Size(186, 21)
        Me.txtGrandTotalOrder.TabIndex = 3
        Me.txtGrandTotalOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotalOrder.ThousandsSeparator = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(19, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 123
        Me.Label16.Text = "Total PPh"
        '
        'txtTotalPPHOrder
        '
        Me.txtTotalPPHOrder.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPHOrder.DecimalPlaces = 2
        Me.txtTotalPPHOrder.Enabled = False
        Me.txtTotalPPHOrder.Location = New System.Drawing.Point(115, 77)
        Me.txtTotalPPHOrder.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPHOrder.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPHOrder.Name = "txtTotalPPHOrder"
        Me.txtTotalPPHOrder.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalPPHOrder.TabIndex = 2
        Me.txtTotalPPHOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPHOrder.ThousandsSeparator = True
        '
        'txtTotalDPPOrder
        '
        Me.txtTotalDPPOrder.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalDPPOrder.DecimalPlaces = 2
        Me.txtTotalDPPOrder.Enabled = False
        Me.txtTotalDPPOrder.Location = New System.Drawing.Point(115, 23)
        Me.txtTotalDPPOrder.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalDPPOrder.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalDPPOrder.Name = "txtTotalDPPOrder"
        Me.txtTotalDPPOrder.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalDPPOrder.TabIndex = 0
        Me.txtTotalDPPOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDPPOrder.ThousandsSeparator = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 121
        Me.Label17.Text = "Total PPN"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(19, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 119
        Me.Label18.Text = "Total DPP"
        '
        'txtTotalPPNOrder
        '
        Me.txtTotalPPNOrder.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPNOrder.DecimalPlaces = 2
        Me.txtTotalPPNOrder.Enabled = False
        Me.txtTotalPPNOrder.Location = New System.Drawing.Point(115, 50)
        Me.txtTotalPPNOrder.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPNOrder.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPNOrder.Name = "txtTotalPPNOrder"
        Me.txtTotalPPNOrder.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalPPNOrder.TabIndex = 1
        Me.txtTotalPPNOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPNOrder.ThousandsSeparator = True
        '
        'Permintaan
        '
        Me.Permintaan.Controls.Add(Me.Label14)
        Me.Permintaan.Controls.Add(Me.txtGrandTotalRequest)
        Me.Permintaan.Controls.Add(Me.Label12)
        Me.Permintaan.Controls.Add(Me.txtTotalPPHRequest)
        Me.Permintaan.Controls.Add(Me.txtTotalDPPRequest)
        Me.Permintaan.Controls.Add(Me.Label10)
        Me.Permintaan.Controls.Add(Me.Label9)
        Me.Permintaan.Controls.Add(Me.txtTotalPPNRequest)
        Me.Permintaan.Location = New System.Drawing.Point(23, 13)
        Me.Permintaan.Name = "Permintaan"
        Me.Permintaan.Size = New System.Drawing.Size(334, 138)
        Me.Permintaan.TabIndex = 0
        Me.Permintaan.TabStop = False
        Me.Permintaan.Text = "Permintaan"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(19, 108)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "Grand Total"
        '
        'txtGrandTotalRequest
        '
        Me.txtGrandTotalRequest.BackColor = System.Drawing.Color.LightYellow
        Me.txtGrandTotalRequest.DecimalPlaces = 2
        Me.txtGrandTotalRequest.Enabled = False
        Me.txtGrandTotalRequest.Location = New System.Drawing.Point(115, 104)
        Me.txtGrandTotalRequest.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtGrandTotalRequest.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtGrandTotalRequest.Name = "txtGrandTotalRequest"
        Me.txtGrandTotalRequest.Size = New System.Drawing.Size(186, 21)
        Me.txtGrandTotalRequest.TabIndex = 3
        Me.txtGrandTotalRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotalRequest.ThousandsSeparator = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 123
        Me.Label12.Text = "Total PPh"
        '
        'txtTotalPPHRequest
        '
        Me.txtTotalPPHRequest.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPHRequest.DecimalPlaces = 2
        Me.txtTotalPPHRequest.Enabled = False
        Me.txtTotalPPHRequest.Location = New System.Drawing.Point(115, 77)
        Me.txtTotalPPHRequest.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPHRequest.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPHRequest.Name = "txtTotalPPHRequest"
        Me.txtTotalPPHRequest.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalPPHRequest.TabIndex = 2
        Me.txtTotalPPHRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPHRequest.ThousandsSeparator = True
        '
        'txtTotalDPPRequest
        '
        Me.txtTotalDPPRequest.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalDPPRequest.DecimalPlaces = 2
        Me.txtTotalDPPRequest.Enabled = False
        Me.txtTotalDPPRequest.Location = New System.Drawing.Point(115, 23)
        Me.txtTotalDPPRequest.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalDPPRequest.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalDPPRequest.Name = "txtTotalDPPRequest"
        Me.txtTotalDPPRequest.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalDPPRequest.TabIndex = 0
        Me.txtTotalDPPRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDPPRequest.ThousandsSeparator = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Total PPN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Total DPP"
        '
        'txtTotalPPNRequest
        '
        Me.txtTotalPPNRequest.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalPPNRequest.DecimalPlaces = 2
        Me.txtTotalPPNRequest.Enabled = False
        Me.txtTotalPPNRequest.Location = New System.Drawing.Point(115, 50)
        Me.txtTotalPPNRequest.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtTotalPPNRequest.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtTotalPPNRequest.Name = "txtTotalPPNRequest"
        Me.txtTotalPPNRequest.Size = New System.Drawing.Size(186, 21)
        Me.txtTotalPPNRequest.TabIndex = 1
        Me.txtTotalPPNRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPPNRequest.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(815, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 117
        Me.Label7.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(735, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "PPh"
        '
        'txtPPH
        '
        Me.txtPPH.DecimalPlaces = 2
        Me.txtPPH.Location = New System.Drawing.Point(735, 90)
        Me.txtPPH.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPPH.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPPH.Name = "txtPPH"
        Me.txtPPH.Size = New System.Drawing.Size(77, 21)
        Me.txtPPH.TabIndex = 3
        Me.txtPPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPPH.ThousandsSeparator = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(815, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(735, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "PPN"
        '
        'txtPPN
        '
        Me.txtPPN.DecimalPlaces = 2
        Me.txtPPN.Location = New System.Drawing.Point(735, 36)
        Me.txtPPN.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.txtPPN.Minimum = New Decimal(New Integer() {-1, -1, -1, -2147483648})
        Me.txtPPN.Name = "txtPPN"
        Me.txtPPN.Size = New System.Drawing.Size(77, 21)
        Me.txtPPN.TabIndex = 2
        Me.txtPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPPN.ThousandsSeparator = True
        '
        'tpPaymentTerm
        '
        Me.tpPaymentTerm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpPaymentTerm.Controls.Add(Me.grdPaymentTerm)
        Me.tpPaymentTerm.Controls.Add(Me.ToolBarPaymentTerm)
        Me.tpPaymentTerm.Location = New System.Drawing.Point(4, 25)
        Me.tpPaymentTerm.Name = "tpPaymentTerm"
        Me.tpPaymentTerm.Size = New System.Drawing.Size(876, 202)
        Me.tpPaymentTerm.TabIndex = 3
        Me.tpPaymentTerm.Text = "Metode Pembayaran - F3"
        Me.tpPaymentTerm.UseVisualStyleBackColor = True
        '
        'grdPaymentTerm
        '
        Me.grdPaymentTerm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdPaymentTerm.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdPaymentTerm.Location = New System.Drawing.Point(0, 28)
        Me.grdPaymentTerm.MainView = Me.grdPaymentTermView
        Me.grdPaymentTerm.Name = "grdPaymentTerm"
        Me.grdPaymentTerm.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2})
        Me.grdPaymentTerm.Size = New System.Drawing.Size(872, 170)
        Me.grdPaymentTerm.TabIndex = 2
        Me.grdPaymentTerm.UseEmbeddedNavigator = True
        Me.grdPaymentTerm.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdPaymentTermView})
        '
        'grdPaymentTermView
        '
        Me.grdPaymentTermView.GridControl = Me.grdPaymentTerm
        Me.grdPaymentTermView.Name = "grdPaymentTermView"
        Me.grdPaymentTermView.OptionsCustomization.AllowColumnMoving = False
        Me.grdPaymentTermView.OptionsCustomization.AllowGroup = False
        Me.grdPaymentTermView.OptionsView.ColumnAutoWidth = False
        Me.grdPaymentTermView.OptionsView.ShowFooter = True
        Me.grdPaymentTermView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "0.00"
        '
        'ToolBarPaymentTerm
        '
        Me.ToolBarPaymentTerm.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarPaymentTerm.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddPayment, Me.BarEditPayment, Me.BarDeletePayment})
        Me.ToolBarPaymentTerm.DropDownArrows = True
        Me.ToolBarPaymentTerm.Location = New System.Drawing.Point(0, 0)
        Me.ToolBarPaymentTerm.Name = "ToolBarPaymentTerm"
        Me.ToolBarPaymentTerm.ShowToolTips = True
        Me.ToolBarPaymentTerm.Size = New System.Drawing.Size(872, 28)
        Me.ToolBarPaymentTerm.TabIndex = 1
        Me.ToolBarPaymentTerm.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAddPayment
        '
        Me.BarAddPayment.Name = "BarAddPayment"
        Me.BarAddPayment.Tag = "Add"
        Me.BarAddPayment.Text = "Tambah"
        '
        'BarEditPayment
        '
        Me.BarEditPayment.Name = "BarEditPayment"
        Me.BarEditPayment.Tag = "Edit"
        Me.BarEditPayment.Text = "Edit"
        '
        'BarDeletePayment
        '
        Me.BarDeletePayment.Name = "BarDeletePayment"
        Me.BarDeletePayment.Tag = "Delete"
        Me.BarDeletePayment.Text = "Hapus"
        '
        'tpHistory
        '
        Me.tpHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpHistory.Controls.Add(Me.grdStatus)
        Me.tpHistory.Location = New System.Drawing.Point(4, 25)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHistory.Size = New System.Drawing.Size(876, 202)
        Me.tpHistory.TabIndex = 1
        Me.tpHistory.Text = "History - F4"
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
        Me.grdStatus.Size = New System.Drawing.Size(866, 192)
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
        Me.Label1.Location = New System.Drawing.Point(0, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(884, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "« Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgMain
        '
        Me.pgMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgMain.Location = New System.Drawing.Point(0, 638)
        Me.pgMain.Name = "pgMain"
        Me.pgMain.Size = New System.Drawing.Size(884, 23)
        Me.pgMain.TabIndex = 6
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripLogInc, Me.ToolStripLogBy, Me.ToolStripStatusLabel1, Me.ToolStripLogDate})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 616)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(884, 22)
        Me.StatusStrip.TabIndex = 5
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(761, 17)
        Me.ToolStripEmpty.Spring = True
        '
        'ToolStripLogInc
        '
        Me.ToolStripLogInc.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripLogInc.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripLogInc.Name = "ToolStripLogInc"
        Me.ToolStripLogInc.Size = New System.Drawing.Size(48, 17)
        Me.ToolStripLogInc.Text = "Log Inc : "
        '
        'ToolStripLogBy
        '
        Me.ToolStripLogBy.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripLogBy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripLogBy.Name = "ToolStripLogBy"
        Me.ToolStripLogBy.Size = New System.Drawing.Size(48, 17)
        Me.ToolStripLogBy.Text = "Last Log :"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripLogDate
        '
        Me.ToolStripLogDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripLogDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripLogDate.Name = "ToolStripLogDate"
        Me.ToolStripLogDate.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripLogDate.Text = "-"
        '
        'tcDetail
        '
        Me.tcDetail.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcDetail.Controls.Add(Me.tpRequest)
        Me.tcDetail.Controls.Add(Me.tpOrder)
        Me.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcDetail.Location = New System.Drawing.Point(0, 303)
        Me.tcDetail.Name = "tcDetail"
        Me.tcDetail.SelectedIndex = 0
        Me.tcDetail.Size = New System.Drawing.Size(884, 313)
        Me.tcDetail.TabIndex = 4
        '
        'tpRequest
        '
        Me.tpRequest.Controls.Add(Me.grdItemRequest)
        Me.tpRequest.Controls.Add(Me.ToolBarDetailRequest)
        Me.tpRequest.Location = New System.Drawing.Point(4, 25)
        Me.tpRequest.Name = "tpRequest"
        Me.tpRequest.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRequest.Size = New System.Drawing.Size(876, 284)
        Me.tpRequest.TabIndex = 0
        Me.tpRequest.Text = "Permintaan - F5"
        Me.tpRequest.UseVisualStyleBackColor = True
        '
        'grdItemRequest
        '
        Me.grdItemRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdItemRequest.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdItemRequest.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdItemRequest.Location = New System.Drawing.Point(3, 31)
        Me.grdItemRequest.MainView = Me.grdItemRequestView
        Me.grdItemRequest.Name = "grdItemRequest"
        Me.grdItemRequest.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpiValue})
        Me.grdItemRequest.Size = New System.Drawing.Size(870, 250)
        Me.grdItemRequest.TabIndex = 1
        Me.grdItemRequest.UseEmbeddedNavigator = True
        Me.grdItemRequest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemRequestView})
        '
        'grdItemRequestView
        '
        Me.grdItemRequestView.GridControl = Me.grdItemRequest
        Me.grdItemRequestView.Name = "grdItemRequestView"
        Me.grdItemRequestView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemRequestView.OptionsCustomization.AllowGroup = False
        Me.grdItemRequestView.OptionsView.ColumnAutoWidth = False
        Me.grdItemRequestView.OptionsView.ShowAutoFilterRow = True
        Me.grdItemRequestView.OptionsView.ShowFooter = True
        Me.grdItemRequestView.OptionsView.ShowGroupPanel = False
        '
        'rpiValue
        '
        Me.rpiValue.AutoHeight = False
        Me.rpiValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiValue.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rpiValue.Name = "rpiValue"
        Me.rpiValue.NullText = "0.00"
        '
        'ToolBarDetailRequest
        '
        Me.ToolBarDetailRequest.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetailRequest.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddItemRequest, Me.BarDetailItemRequest, Me.BarDeleteItemRequest})
        Me.ToolBarDetailRequest.DropDownArrows = True
        Me.ToolBarDetailRequest.Location = New System.Drawing.Point(3, 3)
        Me.ToolBarDetailRequest.Name = "ToolBarDetailRequest"
        Me.ToolBarDetailRequest.ShowToolTips = True
        Me.ToolBarDetailRequest.Size = New System.Drawing.Size(870, 28)
        Me.ToolBarDetailRequest.TabIndex = 0
        Me.ToolBarDetailRequest.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarAddItemRequest
        '
        Me.BarAddItemRequest.Name = "BarAddItemRequest"
        Me.BarAddItemRequest.Tag = "Add"
        Me.BarAddItemRequest.Text = "Tambah"
        '
        'BarDetailItemRequest
        '
        Me.BarDetailItemRequest.Name = "BarDetailItemRequest"
        Me.BarDetailItemRequest.Tag = "Edit"
        Me.BarDetailItemRequest.Text = "Edit"
        '
        'BarDeleteItemRequest
        '
        Me.BarDeleteItemRequest.Name = "BarDeleteItemRequest"
        Me.BarDeleteItemRequest.Tag = "Delete"
        Me.BarDeleteItemRequest.Text = "Hapus"
        '
        'tpOrder
        '
        Me.tpOrder.Controls.Add(Me.grdItemOrder)
        Me.tpOrder.Controls.Add(Me.ToolBarDetailOrder)
        Me.tpOrder.Location = New System.Drawing.Point(4, 25)
        Me.tpOrder.Name = "tpOrder"
        Me.tpOrder.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrder.Size = New System.Drawing.Size(876, 284)
        Me.tpOrder.TabIndex = 1
        Me.tpOrder.Text = "Pesanan - F6"
        Me.tpOrder.UseVisualStyleBackColor = True
        '
        'grdItemOrder
        '
        Me.grdItemOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdItemOrder.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdItemOrder.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdItemOrder.Location = New System.Drawing.Point(3, 31)
        Me.grdItemOrder.MainView = Me.grdItemOrderView
        Me.grdItemOrder.Name = "grdItemOrder"
        Me.grdItemOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.grdItemOrder.Size = New System.Drawing.Size(870, 250)
        Me.grdItemOrder.TabIndex = 9
        Me.grdItemOrder.UseEmbeddedNavigator = True
        Me.grdItemOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemOrderView})
        '
        'grdItemOrderView
        '
        Me.grdItemOrderView.GridControl = Me.grdItemOrder
        Me.grdItemOrderView.Name = "grdItemOrderView"
        Me.grdItemOrderView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemOrderView.OptionsCustomization.AllowGroup = False
        Me.grdItemOrderView.OptionsView.ColumnAutoWidth = False
        Me.grdItemOrderView.OptionsView.ShowAutoFilterRow = True
        Me.grdItemOrderView.OptionsView.ShowFooter = True
        Me.grdItemOrderView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "0.00"
        '
        'ToolBarDetailOrder
        '
        Me.ToolBarDetailOrder.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetailOrder.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarAddItemOrder, Me.BarDetailItemOrder, Me.BarDeleteItemOrder})
        Me.ToolBarDetailOrder.DropDownArrows = True
        Me.ToolBarDetailOrder.Location = New System.Drawing.Point(3, 3)
        Me.ToolBarDetailOrder.Name = "ToolBarDetailOrder"
        Me.ToolBarDetailOrder.ShowToolTips = True
        Me.ToolBarDetailOrder.Size = New System.Drawing.Size(870, 28)
        Me.ToolBarDetailOrder.TabIndex = 8
        Me.ToolBarDetailOrder.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
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
        'frmTraPurchaseOrderDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 661)
        Me.Controls.Add(Me.tcDetail)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tcHeader)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraPurchaseOrderDet"
        Me.Text = "Pesanan Pembelian"
        Me.tcHeader.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        Me.tpAmount.ResumeLayout(False)
        Me.tpAmount.PerformLayout()
        Me.gboPesanan.ResumeLayout(False)
        Me.gboPesanan.PerformLayout()
        CType(Me.txtGrandTotalOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPHOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDPPOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPNOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Permintaan.ResumeLayout(False)
        Me.Permintaan.PerformLayout()
        CType(Me.txtGrandTotalRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPHRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDPPRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPNRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPaymentTerm.ResumeLayout(False)
        Me.tpPaymentTerm.PerformLayout()
        CType(Me.grdPaymentTerm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPaymentTermView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.tcDetail.ResumeLayout(False)
        Me.tpRequest.ResumeLayout(False)
        Me.tpRequest.PerformLayout()
        CType(Me.grdItemRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemRequestView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpOrder.ResumeLayout(False)
        Me.tpOrder.PerformLayout()
        CType(Me.grdItemOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemOrderView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tcHeader As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNumber As ERPS.usTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As ERPS.usTextBox
    Friend WithEvents cboStatus As ERPS.usComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents dtpPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBPCode As ERPS.usTextBox
    Friend WithEvents btnBP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBPName As ERPS.usTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPONumber As ERPS.usTextBox
    Friend WithEvents tpHistory As System.Windows.Forms.TabPage
    Friend WithEvents grdStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pgMain As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogInc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLogDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnPermintaan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tcDetail As System.Windows.Forms.TabControl
    Friend WithEvents tpRequest As System.Windows.Forms.TabPage
    Friend WithEvents tpOrder As System.Windows.Forms.TabPage
    Friend WithEvents tpAmount As System.Windows.Forms.TabPage
    Friend WithEvents grdItemRequest As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemRequestView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rpiValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdItemOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemOrderView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txtPPN As ERPS.usNumeric
    Friend WithEvents gboPesanan As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotalOrder As ERPS.usNumeric
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPHOrder As ERPS.usNumeric
    Friend WithEvents txtTotalDPPOrder As ERPS.usNumeric
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPNOrder As ERPS.usNumeric
    Friend WithEvents Permintaan As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotalRequest As ERPS.usNumeric
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPHRequest As ERPS.usNumeric
    Friend WithEvents txtTotalDPPRequest As ERPS.usNumeric
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPPNRequest As ERPS.usNumeric
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPPH As ERPS.usNumeric
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tpPaymentTerm As System.Windows.Forms.TabPage
    Friend WithEvents grdPaymentTerm As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdPaymentTermView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ToolBarPaymentTerm As ERPS.usToolBar
    Friend WithEvents BarAddPayment As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarEditPayment As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeletePayment As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtPersonInCharge As ERPS.usTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtValidity As ERPS.usTextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryAddress As ERPS.usTextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryPeriodTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDeliveryPeriodFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ToolBarDetailRequest As ERPS.usToolBar
    Friend WithEvents BarAddItemRequest As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetailItemRequest As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeleteItemRequest As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarDetailOrder As ERPS.usToolBar
    Friend WithEvents BarAddItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetailItemOrder As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDeleteItemOrder As System.Windows.Forms.ToolBarButton
End Class
