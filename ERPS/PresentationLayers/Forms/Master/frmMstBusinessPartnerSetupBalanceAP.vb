Imports DevExpress.XtraGrid
Public Class frmMstBusinessPartnerSetupBalanceAP

#Region "Property"

    Private frmParent As frmMstBusinessPartner
    Private clsData As VO.BusinessPartner
    Private dtItem As New DataTable
    Private intPos As Integer

    Public WriteOnly Property pubClsData As VO.BusinessPartner
        Set(value As VO.BusinessPartner)
            clsData = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cAdd As Byte = 0, cEdit As Byte = 1, cDelete As Byte = 2

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Public Sub prvSetButton()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdItemView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ProgramName", "Program", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "CompanyName", "Perusahaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "InvoiceNumber", "No. Invoice", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "InvoiceDate", "Tanggal Invoice", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "TotalDPP", "Total Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPPN", "TotalPPN", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "TotalPPH", "TotalPPH", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "TotalPaymentDP", "TotalPaymentDP", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "TotalPayment", "TotalPayment", 100, UI.usDefGrid.gReal2Num, False)
    End Sub

    Private Sub prvFillForm()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            txtCode.Text = clsData.Code
            txtName.Text = clsData.Name

            dtItem = BL.BusinessPartnerAPBalance.ListData(clsData.ID)
            grdItem.DataSource = dtItem
            prvSumGrid()

        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSave()
        If grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Input saldo invoice terlebih dahulu")
            grdItemView.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Application.DoEvents()

        Dim clsDataDetailAll As New List(Of VO.BusinessPartnerAPBalance)
        For Each dr As DataRow In dtItem.Rows
            clsDataDetailAll.Add(New VO.BusinessPartnerAPBalance With
                                 {
                                     .CompanyID = dr.Item("CompanyID"),
                                     .ProgramID = dr.Item("ProgramID"),
                                     .ID = dr.Item("ID"),
                                     .BPID = clsData.ID,
                                     .InvoiceNumber = dr.Item("InvoiceNumber"),
                                     .InvoiceDate = dr.Item("InvoiceDate"),
                                     .TotalDPP = dr.Item("TotalDPP"),
                                     .TotalPPN = dr.Item("TotalPPN"),
                                     .TotalPPH = dr.Item("TotalPPH")
                                })
        Next

        Try
            BL.BusinessPartnerAPBalance.SaveData(clsDataDetailAll)
            UI.usForm.frmMessageBox("Data berhasil disimpan.")
            pgMain.Value = 80
            Application.DoEvents()
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            Application.DoEvents()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalDPP As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPP", "Total Invoice: {0:#,##0.00}")
        Dim SumTotalPayment As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPayment", "Total Pembayaran: {0:#,##0.00}")

        If grdItemView.Columns("TotalDPP").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalDPP").Summary.Add(SumTotalDPP)
        End If

        If grdItemView.Columns("TotalPayment").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPayment").Summary.Add(SumTotalPayment)
        End If

        grdItemView.BestFitColumns()
    End Sub

    Private Sub prvAdd()
        Dim frmDetail As New frmMstBusinessPartnerSetupBalanceAPDet
        With frmDetail
            .pubIsNew = True
            .pubDtItem = dtItem
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvEdit()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmMstBusinessPartnerSetupBalanceAPDet
        With frmDetail
            .pubIsNew = False
            .pubID = grdItemView.GetRowCellValue(intPos, "ID")
            .pubDtItem = dtItem
            .pubSelectedRow = grdItemView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("ID") = strID.Trim Then
                dr.Delete()
                dtItem.AcceptChanges()
                Exit For
            End If
        Next
    End Sub

#Region "Form Handle"

    Private Sub frmMstBusinessPartnerSetupBalanceAP_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmMstBusinessPartnerSetupBalanceAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetGrid()
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarDetail_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAdd()
            Case "Edit" : prvEdit()
            Case "Hapus" : prvDelete()
        End Select
    End Sub

#End Region

End Class