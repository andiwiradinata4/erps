Imports DevExpress.XtraGrid.Columns
Public Class frmTraARAPDetVer2

#Region "Property"

    Private frmParent As frmTraARAP
    Private clsData As VO.ARAP
    Private intBPID As Integer = 0
    Private intCoAID As Integer = 0
    Private strModules As String = ""
    Private intModuleID As Integer = 0
    Private enumARAPType As VO.ARAP.ARAPTypeValue
    Private strReferencesID As String = ""
    Private strID As String = ""
    Private bolIsNew As Boolean = False
    Private clsCS As New VO.CS
    Private decPPN As Decimal = 0, decPPH As Decimal = 0
    Private dtItem As New DataTable, dtDP As New DataTable

    Public WriteOnly Property pubModules As String
        Set(value As String)
            strModules = value
        End Set
    End Property

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public WriteOnly Property pubARAPType As VO.ARAP.ARAPTypeValue
        Set(value As VO.ARAP.ARAPTypeValue)
            enumARAPType = value
        End Set
    End Property

    Public WriteOnly Property pubReferencesID As String
        Set(value As String)
            strReferencesID = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
        End Set
    End Property

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1, cSep1Item As Byte = 2, cAllocateDP As Byte = 3

    Private Sub prvSetTitleForm()
        If bolIsNew Then
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
        '# Item
        UI.usForm.SetGrid(grdItemView, "Pick", "Pilih", 80, UI.usDefGrid.gBoolean, True, False)
        UI.usForm.SetGrid(grdItemView, "PurchaseID", "PurchaseID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "InvoiceNumber", "Nomor Invoice", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "InvoiceDate", "Tanggal Invoice", 250, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "PurchaseAmount", "PurchaseAmount", 250, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "Amount", "Total Tagihan", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "DPAmount", "Total Panjar", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPNPercent", "PPNPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPHPercent", "PPHPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPN", "PPN", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPH", "PPH", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "MaxPaymentAmount", "Total Maksimal Tagihan", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 250, UI.usDefGrid.gString, True, False)
        grdItemView.Columns("Amount").ColumnEdit = rpiValue
        grdItemView.Columns("DPAmount").ColumnEdit = rpiValue
        grdItemView.Columns("PPN").ColumnEdit = rpiValue
        grdItemView.Columns("PPH").ColumnEdit = rpiValue

        '# Down Payment
        UI.usForm.SetGrid(grdDownPaymentView, "Pick", "Pilih", 80, UI.usDefGrid.gBoolean, True, False)
        UI.usForm.SetGrid(grdDownPaymentView, "DPID", "DPID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdDownPaymentView, "DPNumber", "Nomor Panjar", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdDownPaymentView, "DPDate", "Tanggal Panjar", 250, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdDownPaymentView, "DPAmount", "Total Panjar", 250, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdDownPaymentView, "MaxDPAmount", "Total Maksimal Panjar", 150, UI.usDefGrid.gReal2Num)
        grdItemView.Columns("DPAmount").ColumnEdit = rpiDPAmount

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionAccountPayableBalance), "StatusID", "StatusName")
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
            If bolIsNew Then
                prvClear()
            Else
                clsData = New VO.ARAP
                clsData = BL.ARAP.GetDetail(strID, enumARAPType)
                txtDPNumber.Text = clsData.TransNumber
                intCoAID = clsData.CoAID
                txtCoACode.Text = clsData.CoACode
                txtCoAName.Text = clsData.CoAName
                txtTotalDP.Value = clsData.Percentage
                strModules = clsData.Modules
                dtpDPDate.Value = clsData.TransDate
                txtDueDateValue.Value = clsData.DueDateValue
                txtTotalAmount.Value = clsData.TotalAmount
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                dtpDPDate.Enabled = False
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

    Private Sub prvSave()
        'ToolBar.Focus()
        'If txtBPCode.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
        '    tcHeader.SelectedTab = tpMain
        '    txtBPCode.Focus()
        '    Exit Sub
        'ElseIf txtCoACodeOfOutgoingPayment.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Pilih akun terlebih dahulu")
        '    tcHeader.SelectedTab = tpMain
        '    txtCoACodeOfOutgoingPayment.Focus()
        '    Exit Sub
        'ElseIf txtTotalAmount.Value <= 0 Then
        '    UI.usForm.frmMessageBox("Total Bayar harus lebih besar dari 0")
        '    tcHeader.SelectedTab = tpMain
        '    txtTotalAmount.Focus()
        '    Exit Sub
        'ElseIf txtDueDateValue.Value <= 0 Then
        '    UI.usForm.frmMessageBox("Jatuh Tempo harus lebih besar dari 0")
        '    tcHeader.SelectedTab = tpMain
        '    txtDueDateValue.Focus()
        '    Exit Sub
        'ElseIf cboStatus.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
        '    tcHeader.SelectedTab = tpMain
        '    cboStatus.Focus()
        '    Exit Sub
        'ElseIf grdItemView.RowCount = 0 And chkManual.Checked = False Then
        '    UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
        '    tcHeader.SelectedTab = tpMain
        '    grdItemView.Focus()
        '    Exit Sub
        'End If

        'Dim frmDetail As New usFormSave
        'Dim intSave As VO.Save.Action
        'With frmDetail
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If .pubIsSave Then intSave = .pubValue
        '    If intSave = VO.Save.Action.CancelSave Then Exit Sub
        'End With

        'Me.Cursor = Cursors.WaitCursor
        'pgMain.Value = 30
        'Application.DoEvents()

        'Dim listDetail As New List(Of VO.AccountPayableDet)
        'For Each dr As DataRow In dtItem.Rows
        '    If dr.Item("Pick") Then
        '        listDetail.Add(New ERPSLib.VO.AccountPayableDet With
        '                   {
        '                       .ID = "",
        '                       .APID = pubID,
        '                       .PurchaseID = dr.Item("PurchaseID"),
        '                       .Amount = dr.Item("Amount"),
        '                       .PPN = dr.Item("PPN"),
        '                       .PPH = dr.Item("PPH"),
        '                       .Remarks = UCase(dr.Item("Remarks"))
        '                   })
        '    End If
        'Next

        'clsData = New VO.AccountPayable
        'clsData.ID = pubID
        'clsData.ProgramID = pubCS.ProgramID
        'clsData.CompanyID = pubCS.CompanyID
        'clsData.APNumber = txtAPNumber.Text.Trim
        'clsData.BPID = intBPID
        'clsData.CoAIDOfOutgoingPayment = intCoAIDOfOutgoingPayment
        'clsData.ReferencesID = ""
        'clsData.ReferencesNote = txtReferencesNote.Text.Trim
        'clsData.TotalAmount = txtTotalAmount.Value
        'clsData.TotalPPN = txtTotalPPN.Value
        'clsData.TotalPPH = txtTotalPPH.Value
        'clsData.APDate = dtpAPDate.Value.Date
        'clsData.DueDateValue = txtDueDateValue.Value
        'clsData.Modules = strModules
        'clsData.Remarks = txtRemarks.Text.Trim
        'clsData.StatusID = cboStatus.SelectedValue
        'clsData.Detail = listDetail
        'clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        'clsData.Save = intSave

        'pgMain.Value = 60
        'Application.DoEvents()

        'Try
        '    Dim strAPNumber As String = BL.AccountPayable.SaveData(pubIsNew, clsData)
        '    UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strAPNumber)
        '    pgMain.Value = 80
        '    Application.DoEvents()
        '    frmParent.pubRefresh(strAPNumber)
        '    If pubIsNew Then
        '        prvClear()
        '        prvQueryItem()
        '        prvQueryHistory()
        '    Else
        '        Me.Close()
        '    End If
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'Finally
        '    pgMain.Value = 100
        '    Application.DoEvents()
        '    prvResetProgressBar()
        'End Try
    End Sub

    Private Sub prvClear()
        'tcHeader.SelectedTab = tpMain
        'pubID = ""
        'txtAPNumber.Text = ""
        'intBPID = 0
        'txtBPCode.Text = ""
        'txtBPName.Text = ""
        'intCoAIDOfOutgoingPayment = 0
        'txtCoACodeOfOutgoingPayment.Text = ""
        'txtCoANameOfOutgoingPayment.Text = ""
        'txtReferencesNote.Text = ""
        'dtpAPDate.Value = Now
        'txtDueDateValue.Value = 0
        'txtTotalAmount.Value = 0
        'txtTotalPPN.Value = 0
        'txtTotalPPH.Value = 0
        'txtRemarks.Text = ""
        'cboStatus.SelectedValue = VO.Status.Values.Draft
        'ToolStripLogInc.Text = "Jumlah Edit : -"
        'ToolStripLogBy.Text = "Dibuat Oleh : -"
        'ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvChooseCOA()
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = clsCS.CompanyID
            .pubProgramID = clsCS.ProgramID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.CashOrBank
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAID = .pubLUdtRow.Item("ID")
                txtCoACode.Text = .pubLUdtRow.Item("Code")
                txtCoAName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvGetModuleID()
        intModuleID = VO.Common.GetModuleID(strModules)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModuleID, IIf(bolIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

#Region "Item Handle"

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
            If strModules.Trim = VO.AccountPayable.DownPayment Or
                strModules.Trim = VO.AccountPayable.ReceivePayment Then
                If bolIsNew Then
                    dtItem = BL.ARAP.ListDataDetailWithOutstanding(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID, enumARAPType)
                Else
                    If clsData.IsDeleted Then
                        dtItem = BL.ARAP.ListDataDetail(strID, enumARAPType)
                    Else
                        dtItem = BL.ARAP.ListDataDetailWithOutstanding(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID, enumARAPType)
                    End If
                End If
                'ElseIf strModules.Trim = VO.AccountPayable.DownPaymentCutting Or
                '    strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                '    If bolIsNew Then
                '        dtItem = BL.PurchaseOrderCutting.ListDataOutstanding(clsCS.CompanyID, clsCS.ProgramID, intBPID)
                '    Else
                '        If clsData.IsDeleted Then
                '            dtItem = BL.AccountPayable.ListDataDetail(pubID)
                '        Else
                '            dtItem = BL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderCutting(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID)
                '        End If
                '    End If
                'ElseIf strModules.Trim = VO.AccountPayable.DownPaymentTransport Or
                '    strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                '    If bolIsNew Then
                '        dtItem = BL.PurchaseOrderTransport.ListDataOutstanding(clsCS.CompanyID, clsCS.ProgramID, intBPID)
                '    Else
                '        If clsData.IsDeleted Then
                '            dtItem = BL.AccountPayable.ListDataDetail(strID)
                '        Else
                '            dtItem = BL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderTransport(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID)
                '        End If
                '    End If
            End If
            grdItem.DataSource = dtItem
            grdItemView.BestFitColumns()
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

    Private Sub prvCalculate()
        Dim decDPAllocate As Decimal = 0, decAmount As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0

        For Each dr As DataRow In dtItem.Rows
            decDPAllocate += dr.Item("DPAmount")
            decAmount += dr.Item("Amount")
            decPPN += ERPSLib.SharedLib.Math.Round(dr.Item("Amount") * dr.Item("PPNPercent") / 100, 2)
            decPPH += ERPSLib.SharedLib.Math.Round(dr.Item("Amount") * dr.Item("PPHPercent") / 100, 2)
        Next

        txtTotalAmount.Value = decAmount
        txtTotalPPN.Value = decPPN
        txtTotalPPH.Value = decPPH
    End Sub

    Private Sub prvChangeCheckedValue(ByVal bolValue As Boolean)
        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "Pick", bolValue)
                If bolValue Then
                    Dim decAmount As Decimal = .GetRowCellValue(i, "MaxPaymentAmount") - .GetRowCellValue(i, "DPAmount")
                    Dim decPPNPercent As Decimal = .GetRowCellValue(i, "PPNPercent")
                    Dim decPPHPercent As Decimal = .GetRowCellValue(i, "PPHPercent")
                    .SetRowCellValue(i, "Amount", decAmount)
                    If decPPNPercent > 0 Then .SetRowCellValue(i, "PPN", ERPSLib.SharedLib.Math.Round(decAmount * decPPNPercent / 100, 2))
                    If decPPHPercent > 0 Then .SetRowCellValue(i, "PPH", ERPSLib.SharedLib.Math.Round(decAmount * decPPHPercent / 100, 2))
                Else
                    .SetRowCellValue(i, "Amount", 0)
                    .SetRowCellValue(i, "PPN", 0)
                    .SetRowCellValue(i, "PPH", 0)
                End If
                .UpdateCurrentRow()
            Next
            ToolBarDetail.Focus()
            prvAllocateDP()
            prvCalculate()
            .BestFitColumns()
        End With
    End Sub

#End Region

#Region "Down Payment"

    Private Sub prvCalculateDP()
        txtTotalDP.Value = 0
        With grdDownPaymentView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Pick") Then txtTotalDP.Value += .GetRowCellValue(i, "DPAmount")
            Next
        End With
    End Sub

    Private Sub prvQueryDP()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            If clsData.IsDeleted Then
                grdDownPayment.DataSource = BL.ARAP.ListDataDownpayment(strID, enumARAPType)
            Else
                grdDownPayment.DataSource = BL.ARAP.ListDataDownPaymentWithOutstanding(clsCS.CompanyID, clsCS.ProgramID, intBPID, strModules, strID, enumARAPType)
            End If
            grdDownPaymentView.BestFitColumns()

            If bolIsNew Then
                With grdDownPaymentView
                    For i As Integer = 0 To .RowCount - 1
                        .SetRowCellValue(i, "Pick", True)
                        .SetRowCellValue(i, "DPAmount", .GetRowCellValue(i, "MaxDPAmount"))
                    Next
                    .UpdateCurrentRow()
                End With
                ToolBarDetail.Focus()
                prvCalculateDP()
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

    Private Sub prvAllocateDP()
        If txtTotalDP.Value <= 0 Then Exit Sub
        Dim decOutstandingDP As Decimal = txtTotalDP.Value
        'For Each dr As DataRow In dtItem.Rows
        '    If decOutstandingDP > 0 And dr.Item("Pick") Then
        '        dr.BeginEdit()
        '        If dr.Item("MaxPaymentAmount") > decOutstandingDP Then
        '            dr.Item("DPAmount") = decOutstandingDP
        '            dr.Item("Amount") = dr.Item("MaxPaymentAmount") - decOutstandingDP
        '            decOutstandingDP = 0
        '        Else
        '            dr.Item("DPAmount") = dr.Item("MaxPaymentAmount")
        '            dr.Item("Amount") = 0
        '            decOutstandingDP -= dr.Item("MaxPaymentAmount")
        '        End If
        '        dr.EndEdit()
        '    End If
        'Next
        'dtItem.AcceptChanges()

        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Pick") And decOutstandingDP > 0 Then
                    If .GetRowCellValue(i, "MaxPaymentAmount") > decOutstandingDP Then
                        .SetRowCellValue(i, "DPAmount", decOutstandingDP)
                        .SetRowCellValue(i, "Amount", .GetRowCellValue(i, "MaxPaymentAmount") - decOutstandingDP)
                        decOutstandingDP = 0
                    Else
                        .SetRowCellValue(i, "DPAmount", .GetRowCellValue(i, "MaxPaymentAmount"))
                        .SetRowCellValue(i, "Amount", 0)
                        decOutstandingDP -= .GetRowCellValue(i, "MaxPaymentAmount")
                    End If
                End If
                .UpdateCurrentRow()
            Next
            ToolBarDetail.Focus()
            prvCalculate()
            .BestFitColumns()
        End With
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                grdStatus.DataSource = BL.AccountReceivable.ListDataStatus(strID)
            Else
                grdStatus.DataSource = BL.AccountPayable.ListDataStatus(strID)
            End If
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

#Region "Form Handle"

    Private Sub frmTraARAPDetVer2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpDownPayment
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraARAPDetVer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prvGetModuleID()
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryHistory()
        prvUserAccess()
        txtDueDateValue.Minimum = 0
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

#End Region

End Class