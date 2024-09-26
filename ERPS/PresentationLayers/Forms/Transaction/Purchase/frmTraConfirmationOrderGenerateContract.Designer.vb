<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTraConfirmationOrderGenerateContract
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraConfirmationOrderGenerateContract))
        Me.ToolBar = New ERPS.usToolBar()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pgMain = New System.Windows.Forms.ProgressBar()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnFranco = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFranco = New ERPS.usTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPCNumber = New ERPS.usTextBox()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        resources.ApplyResources(Me.ToolBar, "ToolBar")
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarRefresh, Me.BarClose})
        Me.ToolBar.Name = "ToolBar"
        '
        'BarRefresh
        '
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.Tag = "Save"
        resources.ApplyResources(Me.BarRefresh, "BarRefresh")
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Tag = "Close"
        resources.ApplyResources(Me.BarClose, "BarClose")
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.CadetBlue
        resources.ApplyResources(Me.lblInfo, "lblInfo")
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Name = "lblInfo"
        '
        'pgMain
        '
        resources.ApplyResources(Me.pgMain, "pgMain")
        Me.pgMain.Name = "pgMain"
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMain.Controls.Add(Me.btnFranco)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.txtFranco)
        Me.pnlMain.Controls.Add(Me.Label8)
        Me.pnlMain.Controls.Add(Me.txtPCNumber)
        resources.ApplyResources(Me.pnlMain, "pnlMain")
        Me.pnlMain.Name = "pnlMain"
        '
        'btnFranco
        '
        Me.btnFranco.Image = CType(resources.GetObject("btnFranco.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.btnFranco, "btnFranco")
        Me.btnFranco.Name = "btnFranco"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'txtFranco
        '
        Me.txtFranco.BackColor = System.Drawing.Color.White
        Me.txtFranco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtFranco, "txtFranco")
        Me.txtFranco.Name = "txtFranco"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Name = "Label8"
        '
        'txtPCNumber
        '
        Me.txtPCNumber.BackColor = System.Drawing.Color.White
        Me.txtPCNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtPCNumber, "txtPCNumber")
        Me.txtPCNumber.Name = "txtPCNumber"
        '
        'frmTraConfirmationOrderGenerateContract
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pgMain)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraConfirmationOrderGenerateContract"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolBar As usToolBar
    Friend WithEvents BarRefresh As ToolBarButton
    Friend WithEvents BarClose As ToolBarButton
    Friend WithEvents lblInfo As Label
    Friend WithEvents pgMain As ProgressBar
    Friend WithEvents pnlMain As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFranco As usTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPCNumber As usTextBox
    Friend WithEvents btnFranco As DevExpress.XtraEditors.SimpleButton
End Class
