Public Class frmTraPurchaseOrderCuttingDetRemarkResult

#Region "Property"

    Private dtItem As New DataTable
    Private bolIsNew As Boolean
    Private drSelectedItem As DataRow
    Private strID As String = Guid.NewGuid.ToString
    Private intGroupID As Integer
    Private frmParent As frmTraPurchaseOrderCuttingDetItem

    Public WriteOnly Property pubDtItem As DataTable
        Set(value As DataTable)
            dtItem = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubDrSelected As DataRow
        Set(value As DataRow)
            drSelectedItem = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            Me.Cursor = Cursors.Default
            If Not bolIsNew Then
                strID = drSelectedItem.Item("ID")
                intGroupID = drSelectedItem.Item("GroupID")
                txtRemarks.Text = drSelectedItem.Item("Remarks")
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        If txtRemarks.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Keterangan tidak boleh kosong")
            txtRemarks.Focus()
            Exit Sub
        End If

        '# Item Handle
        If bolIsNew Then
            Dim drItem As DataRow = dtItem.NewRow
            With drItem
                .BeginEdit()
                .Item("ID") = Guid.NewGuid
                .Item("GroupID") = intGroupID
                .Item("POID") = ""
                .Item("Remarks") = txtRemarks.Text.Trim
                .EndEdit()
            End With
            dtItem.Rows.Add(drItem)
            prvClear()
        Else
            For Each dr As DataRow In dtItem.Rows
                With dr
                    If .Item("ID") = strID Then
                        .BeginEdit()
                        .Item("GroupID") = intGroupID
                        .Item("POID") = ""
                        .Item("Remarks") = txtRemarks.Text.Trim
                        .EndEdit()
                    End If
                End With
            Next
            Me.Close()
        End If
        dtItem.AcceptChanges()
        frmParent.grdRemarksResultView.BestFitColumns()
    End Sub

    Private Sub prvClear()
        strID = ""
        txtRemarks.Text = ""
    End Sub

#Region "Form Handle"

    Private Sub frmTraPurchaseOrderCuttingDetRemarkResult_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraPurchaseOrderCuttingDetRemarkResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cSave).Name : prvSave()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

#End Region
    
End Class