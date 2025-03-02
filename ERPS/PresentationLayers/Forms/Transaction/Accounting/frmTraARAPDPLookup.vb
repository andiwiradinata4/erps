Public Class frmTraARAPDPLookup

    Public pubLUdtRow As DataRow
    Public pubIsLookUpGet As Boolean = False
    Public pubListReferencesID As New List(Of String)
    Private intPos As Integer = 0
    Private dtData As New DataTable

    Private Const _
       cGet As Byte = 0, cRefresh As Byte = 1, cSep1 As Byte = 2, cClose As Byte = 3

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ProgramName", "Program", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyName", "Perusahaan", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ID", "Nomor", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "TransNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TransDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "ReferencesID", "No. Referensi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ReferencesNote", "Referensi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ReferencesNumber", "Purchase Number", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TotalAmount", "Total DPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPN", "Total PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPH", "Total PPH", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "GrandTotal", "Grand Total", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPPInvoiceAmount", "Total DPP Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPNInvoiceAmount", "Total PPN Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPHInvoiceAmount", "Total PPH Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalInvoiceAmount", "Grand Total Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "OutstandingInvoiceAmount", "Total yang belum dibayar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SubmitBy", "Disubmit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitDate", "Tanggal Disubmit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ApprovedBy", "Diapprove Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ApprovedDate", "Tanggal Approve", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "PaymentBy", "Dibayar Oleh", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "PaymentDate", "Tanggal Bayar", 100, UI.usDefGrid.gFullDate, False)
        UI.usForm.SetGrid(grdView, "TaxInvoiceNumber", "No. Faktur Pajak", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "InvoiceNumberBP", "Nomor Invoice", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "StatusID", "StatusID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Dibuat Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Tanggal Buat", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogBy", "Diedit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LogDate", "Tanggal Edit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogInc", "LogInc", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "StatusInfo", "Status", 100, UI.usDefGrid.gString)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cGet).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Try
            For Each Str As String In pubListReferencesID
                dtData.Merge(BL.ARAP.ListDataForLookupDP(Str))
            Next
            grdMain.DataSource = dtData
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("TransNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "TransNumber", strSearch)
        End With
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        If Not UI.usForm.frmAskQuestion("Ambil Data berdasarkan Nomor " & grdView.GetRowCellValue(intPos, "TransNumber") & " ? ") Then Exit Sub
        pubLUdtRow = grdView.GetDataRow(grdView.FocusedRowHandle)
        pubIsLookUpGet = True
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPDPLookup_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraARAPDPLookup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetGrid()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cGet).Name : prvGet()
            End Select
        End If
    End Sub

    Private Sub grdView_DoubleClick(sender As Object, e As EventArgs) Handles grdView.DoubleClick
        prvGet()
    End Sub

#End Region

End Class