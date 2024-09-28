<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraARAPInvoice
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
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grdView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarNew = New System.Windows.Forms.ToolBarButton()
        Me.BarDetail = New System.Windows.Forms.ToolBarButton()
        Me.BarDelete = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.BarSubmit = New System.Windows.Forms.ToolBarButton()
        Me.BarCancelSubmit = New System.Windows.Forms.ToolBarButton()
        Me.BarApprove = New System.Windows.Forms.ToolBarButton()
        Me.BarCancelApprove = New System.Windows.Forms.ToolBarButton()
        Me.BarSep2 = New System.Windows.Forms.ToolBarButton()
        Me.BarSetTaxInvoiceNumber = New System.Windows.Forms.ToolBarButton()
        Me.BarSetInvoiceNumberBP = New System.Windows.Forms.ToolBarButton()
        Me.BarSep3 = New System.Windows.Forms.ToolBarButton()
        Me.BarPrint = New System.Windows.Forms.ToolBarButton()
        Me.BarExportExcel = New System.Windows.Forms.ToolBarButton()
        Me.BarSep4 = New System.Windows.Forms.ToolBarButton()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grdMain.Location = New System.Drawing.Point(0, 72)
        Me.grdMain.MainView = Me.grdView
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(800, 378)
        Me.grdMain.TabIndex = 3
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
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarNew, Me.BarDetail, Me.BarDelete, Me.BarSep1, Me.BarSubmit, Me.BarCancelSubmit, Me.BarApprove, Me.BarCancelApprove, Me.BarSep2, Me.BarSetTaxInvoiceNumber, Me.BarSetInvoiceNumberBP, Me.BarSep3, Me.BarPrint, Me.BarExportExcel, Me.BarSep4, Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(800, 72)
        Me.ToolBar.TabIndex = 4
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
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
        'BarSep1
        '
        Me.BarSep1.Name = "BarSep1"
        Me.BarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarSubmit
        '
        Me.BarSubmit.Name = "BarSubmit"
        Me.BarSubmit.Tag = "Submit"
        Me.BarSubmit.Text = "Submit"
        '
        'BarCancelSubmit
        '
        Me.BarCancelSubmit.Name = "BarCancelSubmit"
        Me.BarCancelSubmit.Tag = "Cancel"
        Me.BarCancelSubmit.Text = "Batal Submit"
        '
        'BarApprove
        '
        Me.BarApprove.Name = "BarApprove"
        Me.BarApprove.Tag = "Approved"
        Me.BarApprove.Text = "Approve"
        '
        'BarCancelApprove
        '
        Me.BarCancelApprove.Name = "BarCancelApprove"
        Me.BarCancelApprove.Tag = "Cancel"
        Me.BarCancelApprove.Text = "Batal Approve"
        '
        'BarSep2
        '
        Me.BarSep2.Name = "BarSep2"
        Me.BarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarSetTaxInvoiceNumber
        '
        Me.BarSetTaxInvoiceNumber.Name = "BarSetTaxInvoiceNumber"
        Me.BarSetTaxInvoiceNumber.Tag = "Checked"
        Me.BarSetTaxInvoiceNumber.Text = "Set Nomor Faktur Pajak"
        '
        'BarSetInvoiceNumberBP
        '
        Me.BarSetInvoiceNumberBP.Name = "BarSetInvoiceNumberBP"
        Me.BarSetInvoiceNumberBP.Tag = "Sub"
        Me.BarSetInvoiceNumberBP.Text = "Set Nomor Invoice Pemasok"
        '
        'BarSep3
        '
        Me.BarSep3.Name = "BarSep3"
        Me.BarSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarPrint
        '
        Me.BarPrint.Name = "BarPrint"
        Me.BarPrint.Tag = "Print"
        Me.BarPrint.Text = "Print"
        '
        'BarExportExcel
        '
        Me.BarExportExcel.Name = "BarExportExcel"
        Me.BarExportExcel.Tag = "Excel"
        Me.BarExportExcel.Text = "Export Excel"
        '
        'BarSep4
        '
        Me.BarSep4.Name = "BarSep4"
        Me.BarSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
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
        'frmTraARAPInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmTraARAPInvoice"
        Me.Text = "Invoice"
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolBar As usToolBar
    Friend WithEvents BarNew As ToolBarButton
    Friend WithEvents BarDetail As ToolBarButton
    Friend WithEvents BarDelete As ToolBarButton
    Friend WithEvents BarSep1 As ToolBarButton
    Friend WithEvents BarSubmit As ToolBarButton
    Friend WithEvents BarCancelSubmit As ToolBarButton
    Friend WithEvents BarApprove As ToolBarButton
    Friend WithEvents BarCancelApprove As ToolBarButton
    Friend WithEvents BarSep2 As ToolBarButton
    Friend WithEvents BarSetTaxInvoiceNumber As ToolBarButton
    Friend WithEvents BarSetInvoiceNumberBP As ToolBarButton
    Friend WithEvents BarSep3 As ToolBarButton
    Friend WithEvents BarPrint As ToolBarButton
    Friend WithEvents BarExportExcel As ToolBarButton
    Friend WithEvents BarSep4 As ToolBarButton
    Friend WithEvents BarRefresh As ToolBarButton
    Friend WithEvents BarClose As ToolBarButton
End Class
