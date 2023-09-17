<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usFormSave
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
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.rdSaveAsDraft = New System.Windows.Forms.RadioButton()
        Me.rdSaveAndSubmit = New System.Windows.Forms.RadioButton()
        Me.rdCancelSave = New System.Windows.Forms.RadioButton()
        Me.gbPilihan = New System.Windows.Forms.GroupBox()
        Me.pnlDetail.SuspendLayout()
        Me.gbPilihan.SuspendLayout()
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
        Me.ToolBar.Size = New System.Drawing.Size(554, 28)
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
        Me.lblInfo.Size = New System.Drawing.Size(554, 22)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "« Simpan Data"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.gbPilihan)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(0, 50)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(554, 154)
        Me.pnlDetail.TabIndex = 2
        '
        'rdSaveAsDraft
        '
        Me.rdSaveAsDraft.AutoSize = True
        Me.rdSaveAsDraft.Location = New System.Drawing.Point(31, 32)
        Me.rdSaveAsDraft.Name = "rdSaveAsDraft"
        Me.rdSaveAsDraft.Size = New System.Drawing.Size(128, 17)
        Me.rdSaveAsDraft.TabIndex = 0
        Me.rdSaveAsDraft.TabStop = True
        Me.rdSaveAsDraft.Text = "Simpan Sebagai Draft"
        Me.rdSaveAsDraft.UseVisualStyleBackColor = True
        '
        'rdSaveAndSubmit
        '
        Me.rdSaveAndSubmit.AutoSize = True
        Me.rdSaveAndSubmit.Location = New System.Drawing.Point(183, 32)
        Me.rdSaveAndSubmit.Name = "rdSaveAndSubmit"
        Me.rdSaveAndSubmit.Size = New System.Drawing.Size(115, 17)
        Me.rdSaveAndSubmit.TabIndex = 1
        Me.rdSaveAndSubmit.TabStop = True
        Me.rdSaveAndSubmit.Text = "Simpan dan Submit"
        Me.rdSaveAndSubmit.UseVisualStyleBackColor = True
        '
        'rdCancelSave
        '
        Me.rdCancelSave.AutoSize = True
        Me.rdCancelSave.Location = New System.Drawing.Point(325, 32)
        Me.rdCancelSave.Name = "rdCancelSave"
        Me.rdCancelSave.Size = New System.Drawing.Size(86, 17)
        Me.rdCancelSave.TabIndex = 2
        Me.rdCancelSave.TabStop = True
        Me.rdCancelSave.Text = "Batal Simpan"
        Me.rdCancelSave.UseVisualStyleBackColor = True
        '
        'gbPilihan
        '
        Me.gbPilihan.Controls.Add(Me.rdSaveAsDraft)
        Me.gbPilihan.Controls.Add(Me.rdSaveAndSubmit)
        Me.gbPilihan.Controls.Add(Me.rdCancelSave)
        Me.gbPilihan.Location = New System.Drawing.Point(37, 26)
        Me.gbPilihan.Name = "gbPilihan"
        Me.gbPilihan.Size = New System.Drawing.Size(473, 78)
        Me.gbPilihan.TabIndex = 0
        Me.gbPilihan.TabStop = False
        Me.gbPilihan.Text = "Pilihan"
        '
        'usFormSave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 204)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "usFormSave"
        Me.Text = "Simpan Data"
        Me.pnlDetail.ResumeLayout(False)
        Me.gbPilihan.ResumeLayout(False)
        Me.gbPilihan.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As ERPS.usToolBar
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents rdCancelSave As System.Windows.Forms.RadioButton
    Friend WithEvents rdSaveAndSubmit As System.Windows.Forms.RadioButton
    Friend WithEvents rdSaveAsDraft As System.Windows.Forms.RadioButton
    Friend WithEvents gbPilihan As System.Windows.Forms.GroupBox
End Class
