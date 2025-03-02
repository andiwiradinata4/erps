Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns

Public Class frmTraAPTransporterDet

#Region "Property"

    Private frmParent As frmTraAPCost
    Private clsData As VO.AccountPayable
    Private dtItem As New DataTable
    Private dtRemarks As New DataTable
    Private intPos As Integer = 0
    Private bolExport As Boolean = False
    Private strID As String = ""
    Private intBPID As Integer = 0
    Private intBPBankAccountID As Integer = 0
    Private bolValid As Boolean = True
    Property pubID As String
    Property pubIsNew As Boolean = False
    Property pubIsSave As Boolean = False
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1,
       cSave As Byte = 0, cClose As Byte = 1,
       cAdd As Byte = 0, cEdit As Byte = 1, cDelete As Byte = 2

    Private Sub prvSetTitleForm()
        If pubIsNew Then
            Me.Text += " [baru] "
        Else
            Me.Text += " [edit] "
        End If
    End Sub

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdItemView, "Pick", "Pick", 100, UI.usDefGrid.gBoolean, True, False)
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PurchaseID", "PurchaseID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PurchaseNumber", "Nomor Surat Jalan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Amount", "Total Tagihan", 180, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPN", "PPN", 180, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPH", "PPH", 180, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "GrandTotal", "GrandTotal", 180, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "InvoiceNumberBP", "Nomor Invoice", 100, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "ReceiveDate", "Tanggal Terima", 180, UI.usDefGrid.gSmallDate, True, False)
        UI.usForm.SetGrid(grdItemView, "InvoiceDate", "Tanggal Invoice", 180, UI.usDefGrid.gSmallDate, True, False)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 200, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "MaxAmount", "Maksimal Tagihan", 180, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxPPN", "Maksimal PPN", 180, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "MaxPPH", "Maksimal PPH", 180, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "MaxGrandTotal", "Maksimal GrandTotal", 180, UI.usDefGrid.gReal2Num)

        UI.usForm.SetGrid(grdRemarksView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdRemarksView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdRemarksView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionAccountPayable), "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvFillForm()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        prvFillCombo()
        Try
            If pubIsNew Then
                prvClear()
            Else
                clsData = New VO.AccountPayable
                clsData = BL.AccountPayable.GetDetail(pubID)
                strID = clsData.ID
                txtARAPNumber.Text = clsData.APNumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                intBPBankAccountID = clsData.BPBankAccountID
                txtBPBankAccountBank.Text = clsData.BPBankAccountBank
                txtBPBankAccountNumber.Text = clsData.BPBankAccountNumber
                dtpARAPDate.Value = clsData.APDate
                txtDueDateValue.Value = clsData.DueDateValue
                txtTotalAmount.Value = clsData.TotalAmount
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSetButton()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
            .Buttons(cCheckAll).Enabled = bolEnabled
            .Buttons(cUncheckAll).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Try
            pgMain.Value = 30
            Me.Cursor = Cursors.WaitCursor
            If pubIsNew Then
                dtItem = BL.AccountPayable.ListDataDetailTransportReceiveWithOutstandingVer00(pubCS.CompanyID, pubCS.ProgramID, intBPID, strID)
            Else
                If clsData.IsDeleted Then
                    dtItem = BL.AccountPayable.ListDataDetailTransportReceiveWithOutstandingVer00(pubCS.CompanyID, pubCS.ProgramID, intBPID, strID)
                    dtItem.Clear()
                Else
                    dtItem = BL.AccountPayable.ListDataDetailTransportReceiveWithOutstandingVer00(pubCS.CompanyID, pubCS.ProgramID, intBPID, strID)
                End If
            End If

            grdItem.DataSource = dtItem
            prvSumGrid()
            pgMain.Value = 100
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            prvSetButton()
            prvResetProgressBar()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        If Not bolValid Then Exit Sub
        grdItemView.ClearColumnsFilter()
        prvCalculate()
        If grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item belum diinput")
            grdItemView.Focus()
            Exit Sub
        ElseIf txtTotalAmount.Value <= 0 Then
            UI.usForm.frmMessageBox("Total Bayar harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf intBPBankAccountID = 0 Then
            UI.usForm.frmMessageBox("Pilih Akun Bank Rekan Bisnis terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPBankAccountBank.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            cboStatus.Focus()
            Exit Sub
        End If

        Dim drPick() As DataRow = dtItem.Select("Pick=True")
        If drPick.Count = 0 Then
            UI.usForm.frmMessageBox("Tidak ada item yang tercentang")
            Exit Sub
        End If

        Dim frmDetail As New usFormSave
        Dim intSave As VO.Save.Action
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then intSave = .pubValue
            If intSave = VO.Save.Action.CancelSave Then Exit Sub
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Dim clsDataDetailAll As New List(Of VO.AccountPayableDet)
        With dtItem
            For Each dr As DataRow In .Rows
                If Not dr.Item("Pick") Or dr.Item("Amount") = 0 Then Continue For
                clsDataDetailAll.Add(New VO.AccountPayableDet With
                                     {
                                         .APID = pubID,
                                         .PurchaseID = dr.Item("PurchaseID"),
                                         .Amount = dr.Item("Amount"),
                                         .PPN = dr.Item("PPN"),
                                         .PPH = dr.Item("PPH"),
                                         .Remarks = UCase(dr.Item("Remarks")),
                                         .InvoiceNumberBP = UCase(dr.Item("InvoiceNumberBP")),
                                         .ReceiveDate = dr.Item("ReceiveDate"),
                                         .InvoiceDate = dr.Item("InvoiceDate"),
                                         .ReferencesParentID = ""
                                    })
            Next
        End With

        Dim clsDataRemarksAll As New List(Of VO.ARAPRemarks)
        With dtRemarks
            For Each dr As DataRow In .Rows
                clsDataRemarksAll.Add(New VO.ARAPRemarks With
                                     {
                                         .ParentID = pubID,
                                         .Remarks = dr.Item("Remarks")
                                    })
            Next
        End With

        clsData = New VO.AccountPayable
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.ID = pubID
        clsData.APNumber = txtARAPNumber.Text.Trim
        clsData.Modules = VO.AccountPayable.ReceivePaymentTransport
        clsData.ReferencesID = ""
        clsData.ReferencesNote = ""
        clsData.BPID = intBPID
        clsData.BPCode = txtBPCode.Text.Trim
        clsData.BPName = txtBPName.Text.Trim
        clsData.BPBankAccountID = intBPBankAccountID
        clsData.BPBankAccountBank = txtBPBankAccountBank.Text.Trim
        clsData.BPBankAccountNumber = txtBPBankAccountNumber.Text.Trim
        clsData.APDate = dtpARAPDate.Value
        clsData.TotalAmount = txtTotalAmount.Value
        clsData.TotalPPN = txtTotalPPN.Value
        clsData.TotalPPH = txtTotalPPH.Value
        clsData.ReceiveAmount = txtTotalAmount.Value
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Remarks = ""
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Detail = clsDataDetailAll
        clsData.DetailRemarks = clsDataRemarksAll
        clsData.Save = intSave

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            Dim strID As String = BL.AccountPayable.SaveDataVer00_ReceivePaymentTransport(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strID)
            pgMain.Value = 80
            frmParent.pubRefresh(strID)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryHistory()
                prvQueryRemarks()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvClear()
        pubID = ""
        txtARAPNumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        intBPBankAccountID = 0
        txtBPBankAccountBank.Text = ""
        txtBPBankAccountNumber.Text = ""
        dtpARAPDate.Value = Today.Date
        txtDueDateValue.Value = 0
        txtTotalAmount.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        cboStatus.SelectedValue = VO.Status.Values.Draft
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvChooseBPBankAccount()
        If intBPID = 0 Then
            UI.usForm.frmMessageBox("Pilih rekan bisnis terlebih dahulu")
            Exit Sub
        End If
        Dim frmDetail As New frmMstBusinessPartnerBankAccount
        With frmDetail
            .pubIsLookUp = True
            .pubBPID = intBPID
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intBPBankAccountID = .pubLUdtRow.Item("ID")
                txtBPBankAccountBank.Text = .pubLUdtRow.Item("BankName")
                txtBPBankAccountNumber.Text = .pubLUdtRow.Item("AccountNumber")
                txtDueDateValue.Focus()
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Total Tagihan: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PPN", "PPN: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PPH", "PPH: {0:#,##0.00}")
        Dim SumGrandTotal As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", "Grand Total: {0:#,##0.00}")

        If grdItemView.Columns("Amount").SummaryText.Trim = "" Then
            grdItemView.Columns("Amount").Summary.Add(SumTotalAmount)
        End If

        If grdItemView.Columns("PPN").SummaryText.Trim = "" Then
            grdItemView.Columns("PPN").Summary.Add(SumTotalPPN)
        End If

        If grdItemView.Columns("PPH").SummaryText.Trim = "" Then
            grdItemView.Columns("PPH").Summary.Add(SumTotalPPH)
        End If

        If grdItemView.Columns("GrandTotal").SummaryText.Trim = "" Then
            grdItemView.Columns("GrandTotal").Summary.Add(SumGrandTotal)
        End If

        If grdItemView.GroupCount > 0 Then grdItemView.ExpandAllGroups()
        grdItemView.BestFitColumns()
    End Sub

    Private Sub prvChangeCheckedValue(ByVal bolValue As Boolean)
        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "Pick", bolValue)
                .UpdateCurrentRow()
            Next
            prvCalculate()
        End With
    End Sub

    Private Sub prvCalculate()
        Dim decAmount As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0

        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Pick") Then
                    decAmount += .GetRowCellValue(i, "Amount")
                    decPPN += .GetRowCellValue(i, "PPN")
                    decPPH += .GetRowCellValue(i, "PPH")
                End If
            Next
            grdItemView.BestFitColumns()
        End With
        txtTotalAmount.Value = decAmount
        txtTotalPPN.Value = decPPN
        txtTotalPPH.Value = decPPH
        txtGrandTotal.Value = decAmount + decPPN - decPPH
    End Sub

    Private Sub prvChooseBP()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If intBPID <> .pubLUdtRow.Item("ID") Then
                    intBPBankAccountID = 0
                    txtBPBankAccountBank.Text = ""
                    txtBPBankAccountNumber.Text = ""
                End If

                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
                prvQueryItem()
                prvCalculate()
            End If
        End With
    End Sub

#Region "History Handle"

    Private Sub prvQueryHistory()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            grdStatus.DataSource = BL.AccountPayable.ListDataStatus(pubID)
            grdStatusView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

#End Region

#Region "Remarks"

    Private Sub prvSetButtonRemarks()
        Dim bolEnabled As Boolean = IIf(grdRemarksView.RowCount = 0, False, True)
        With ToolBarRemarks
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryRemarks()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            dtRemarks = BL.ARAP.ListDataRemarks(pubID)
            grdRemarks.DataSource = dtRemarks
            grdRemarksView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
            prvSetButtonRemarks()
        End Try
    End Sub

    Private Sub prvAddRemarks()
        Dim frmDetail As New frmTraARAPItemRemarks
        With frmDetail
            .pubIsNew = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsSave Then
                Dim dr As DataRow = dtRemarks.NewRow
                dr.BeginEdit()
                dr.Item("ID") = Guid.NewGuid.ToString()
                dr.Item("Remarks") = .pubRemarks
                dr.EndEdit()
                dtRemarks.Rows.Add(dr)
                dtRemarks.AcceptChanges()
                grdRemarksView.BestFitColumns()
            End If
            prvSetButtonRemarks()
        End With
    End Sub

    Private Sub prvEditRemarks()
        intPos = grdRemarksView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraARAPItemRemarks
        With frmDetail
            .pubIsNew = False
            .pubRemarks = grdRemarksView.GetRowCellValue(intPos, "Remarks")
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsSave Then
                For Each dr As DataRow In dtRemarks.Rows
                    If dr.Item("ID") <> grdRemarksView.GetRowCellValue(intPos, "ID") Then Continue For
                    dr.BeginEdit()
                    dr.Item("ID") = Guid.NewGuid.ToString()
                    dr.Item("Remarks") = .pubRemarks
                    dr.EndEdit()
                    Exit For
                Next
                dtRemarks.AcceptChanges()
                grdRemarksView.BestFitColumns()
            End If
            prvSetButtonRemarks()
        End With
    End Sub

    Private Sub prvDeleteRemarks()
        intPos = grdRemarksView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdRemarksView.GetRowCellValue(intPos, "ID")
        For i As Integer = 0 To dtRemarks.Rows.Count - 1
            If dtRemarks.Rows(i).Item("ID") = strID Then
                dtRemarks.Rows(i).Delete()
                Exit For
            End If
        Next
        dtRemarks.AcceptChanges()
        grdRemarks.DataSource = dtRemarks
        prvSetButtonRemarks()
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraAPTransporterDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpRemarks
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraAPTransporterDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        ToolBarRemarks.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryHistory()
        prvQueryRemarks()
        'prvUserAccess()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarDetail_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Centang Semua" : prvChangeCheckedValue(True)
            Case "Tidak Centang Semua" : prvChangeCheckedValue(False)
        End Select
    End Sub

    Private Sub ToolBarRemarksResult_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarRemarks.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddRemarks()
            Case "Edit" : prvEditRemarks()
            Case "Hapus" : prvDeleteRemarks()
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub btnBPBankAccount_Click(sender As Object, e As EventArgs) Handles btnBPBankAccount.Click
        prvChooseBPBankAccount()
    End Sub

    Private Sub grdItemView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles grdItemView.ValidatingEditor
        With grdItemView
            bolValid = True
            Dim col As GridColumn = .FocusedColumn
            Dim intFocus As Integer = .FocusedRowHandle
            Dim decPPNPercent As Decimal = .GetFocusedRowCellValue("PPNPercent")
            Dim decPPHPercent As Decimal = .GetFocusedRowCellValue("PPHPercent")
            If col.Name = "Amount" Or col.Name = "PPN" Or col.Name = "PPH" Then
                Dim oldValue As Decimal = IIf(.GetFocusedRowCellValue(col).Equals(DBNull.Value), 0, .GetFocusedRowCellValue(col))
                Dim newValue As Decimal = IIf((e.Value = "") Or (e.Value.Equals(DBNull.Value) Or (e.Value = ".")), 0, e.Value)

                Dim strErrorMessage As String = ""
                If newValue > 0 And newValue > .GetFocusedRowCellValue("MaxAmount") Then
                    bolValid = False
                    If col.Name = "Amount" Then strErrorMessage = "Total tagihan tidak boleh lebih besar dari Maksimal Tagihan"
                    If col.Name = "PPN" Then strErrorMessage = "PPN tidak boleh lebih besar dari total Maksimal PPN"
                    If col.Name = "PPH" Then strErrorMessage = "PPH tidak boleh lebih besar dari total Maksimal PPH"
                    UI.usForm.frmMessageBox(strErrorMessage)
                End If

                If bolValid = False Then
                    e.Value = oldValue
                    e.Valid = False
                    e.ErrorText = strErrorMessage
                    .FocusedRowHandle = intFocus
                    .FocusedColumn = .Columns(col.Name)
                    .ShowEditor()
                    Exit Sub
                Else
                    .SetRowCellValue(intFocus, col.Name, newValue)
                    .UpdateCurrentRow()
                    .SetRowCellValue(intFocus, "GrandTotal", .GetRowCellValue(intPos, "Amount") + .GetRowCellValue(intPos, "PPN") - .GetRowCellValue(intPos, "PPH"))
                    .UpdateCurrentRow()
                    prvCalculate()
                End If
            ElseIf col.Name = "Pick" Then
                .SetRowCellValue(intFocus, col.Name, e.Value)
                .UpdateCurrentRow()
                prvCalculate()
            End If
        End With
    End Sub

#End Region

End Class