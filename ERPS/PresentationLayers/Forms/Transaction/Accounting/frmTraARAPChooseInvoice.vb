Public Class frmTraARAPChooseInvoice

#Region "Properties"

    Private strSelectedID As String = ""
    Private bolIsPreview As Boolean = False
    Private strParentID As String = ""

    Public ReadOnly Property pubSelectedID As String
        Get
            Return strSelectedID
        End Get
    End Property

    Public ReadOnly Property pubIsPreview As Boolean
        Get
            Return bolIsPreview
        End Get
    End Property

    Public WriteOnly Property pubParentID As String
        Set(value As String)
            strParentID = value
        End Set
    End Property

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillCombo()
        Try
            Dim dtData As DataTable = BL.ARAP.ListDataInvoice(strParentID)
            For Each dr As DataRow In dtData.Rows
                If dr.Item("IsDeleted") Then dr.Delete()
            Next
            dtData.AcceptChanges()
            UI.usForm.FillComboBox(cboInvoice, dtData, "ID", "InvoiceNumber")
            If dtData.Rows.Count > 0 Then cboInvoice.SelectedIndex = 0

            If dtData.Rows.Count = 1 Then prvPreview()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvPreview()
        If cboInvoice.SelectedIndex <= -1 Then
            UI.usForm.frmMessageBox("Pilih Nomor Invoice terlebih dahulu")
            cboInvoice.Focus()
            Exit Sub
        End If
        strSelectedID = cboInvoice.SelectedValue
        bolIsPreview = True
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPChooseInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraARAPChooseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillCombo()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvPreview()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

#End Region
    
End Class