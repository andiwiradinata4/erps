﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstBusinessPartner
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
        Me.BarGet = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.BarNew = New System.Windows.Forms.ToolBarButton()
        Me.BarDetail = New System.Windows.Forms.ToolBarButton()
        Me.BarDelete = New System.Windows.Forms.ToolBarButton()
        Me.BarSep2 = New System.Windows.Forms.ToolBarButton()
        Me.BarBankAccount = New System.Windows.Forms.ToolBarButton()
        Me.BarAssign = New System.Windows.Forms.ToolBarButton()
        Me.BarLocation = New System.Windows.Forms.ToolBarButton()
        Me.BarSep3 = New System.Windows.Forms.ToolBarButton()
        Me.BarSetupARBalance = New System.Windows.Forms.ToolBarButton()
        Me.BarSetupAPBalance = New System.Windows.Forms.ToolBarButton()
        Me.BarSep4 = New System.Windows.Forms.ToolBarButton()
        Me.BarExportExcel = New System.Windows.Forms.ToolBarButton()
        Me.BarSep5 = New System.Windows.Forms.ToolBarButton()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grdView = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarGet, Me.BarSep1, Me.BarNew, Me.BarDetail, Me.BarDelete, Me.BarSep2, Me.BarBankAccount, Me.BarAssign, Me.BarLocation, Me.BarSep3, Me.BarSetupARBalance, Me.BarSetupAPBalance, Me.BarSep4, Me.BarExportExcel, Me.BarSep5, Me.BarRefresh, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(984, 28)
        Me.ToolBar.TabIndex = 1
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
        'BarBankAccount
        '
        Me.BarBankAccount.Name = "BarBankAccount"
        Me.BarBankAccount.Tag = "Approved"
        Me.BarBankAccount.Text = "Akun Bank"
        '
        'BarAssign
        '
        Me.BarAssign.Name = "BarAssign"
        Me.BarAssign.Tag = "Submit"
        Me.BarAssign.Text = "Assign"
        '
        'BarLocation
        '
        Me.BarLocation.Name = "BarLocation"
        Me.BarLocation.Tag = "Checked"
        Me.BarLocation.Text = "Lokasi"
        '
        'BarSep3
        '
        Me.BarSep3.Name = "BarSep3"
        Me.BarSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarSetupARBalance
        '
        Me.BarSetupARBalance.Name = "BarSetupARBalance"
        Me.BarSetupARBalance.Tag = "Invoice"
        Me.BarSetupARBalance.Text = "Setup Saldo Piutang"
        '
        'BarSetupAPBalance
        '
        Me.BarSetupAPBalance.Name = "BarSetupAPBalance"
        Me.BarSetupAPBalance.Tag = "Alt"
        Me.BarSetupAPBalance.Text = "Setup Saldo Hutang"
        '
        'BarSep4
        '
        Me.BarSep4.Name = "BarSep4"
        Me.BarSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarExportExcel
        '
        Me.BarExportExcel.Name = "BarExportExcel"
        Me.BarExportExcel.Tag = "Excel"
        Me.BarExportExcel.Text = "Export Excel"
        '
        'BarSep5
        '
        Me.BarSep5.Name = "BarSep5"
        Me.BarSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
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
        Me.grdMain.Location = New System.Drawing.Point(0, 28)
        Me.grdMain.MainView = Me.grdView
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(984, 584)
        Me.grdMain.TabIndex = 3
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
        'frmMstBusinessPartner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmMstBusinessPartner"
        Me.Text = "Rekan Bisnis"
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
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarBankAccount As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarAssign As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSetupARBalance As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSetupAPBalance As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarLocation As ToolBarButton
    Friend WithEvents BarExportExcel As ToolBarButton
    Friend WithEvents BarSep5 As ToolBarButton
End Class
