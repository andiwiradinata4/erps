﻿Imports DevExpress.XtraGrid.Columns
Public Class frmTraAccountPayableDet

#Region "Property"

    Private frmParent As frmTraAccountPayable
    Private clsData As VO.AccountPayable
    Private intBPID As Integer = 0
    Private intCoAIDOfOutgoingPayment As Integer = 0
    Private strModules As String = ""
    Private intModuleID As Integer = 0
    Private dtItem As New DataTable
    Private intPos As Integer = 0
    Private bolValid As Boolean = True
    Property pubID As String = ""
    Property pubIsNew As Boolean = False
    Property pubCS As New VO.CS

    Public WriteOnly Property pubModules As String
        Set(value As String)
            strModules = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, _
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1

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
        '# Item
        UI.usForm.SetGrid(grdItemView, "Pick", "Pilih", 80, UI.usDefGrid.gBoolean, True, False)
        UI.usForm.SetGrid(grdItemView, "PurchaseID", "PurchaseID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "InvoiceNumber", "Nomor Invoice", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "InvoiceDate", "Tanggal Invoice", 250, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "PurchaseAmount", "PurchaseAmount", 250, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "Amount", "Total Tagihan", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPNPercent", "PPNPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPHPercent", "PPHPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPN", "PPN", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPH", "PPH", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "MaxPaymentAmount", "Total Maksimal Tagihan", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 250, UI.usDefGrid.gString, True, False)
        grdItemView.Columns("Amount").ColumnEdit = rpiValue
        grdItemView.Columns("PPN").ColumnEdit = rpiValue
        grdItemView.Columns("PPH").ColumnEdit = rpiValue

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "APID", "APID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.TransactionAccountPayableBalance), "StatusID", "StatusName")
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
                txtAPNumber.Text = clsData.APNumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                intCoAIDOfOutgoingPayment = clsData.CoAIDOfOutgoingPayment
                txtCoACodeOfOutgoingPayment.Text = clsData.CoACodeOfOutgoingPayment
                txtCoANameOfOutgoingPayment.Text = clsData.CoANameOfOutgoingPayment
                strModules = clsData.Modules
                txtReferencesNote.Text = clsData.ReferencesNote
                dtpAPDate.Value = clsData.APDate
                txtDueDateValue.Value = clsData.DueDateValue
                txtTotalAmount.Value = clsData.TotalAmount
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                dtpAPDate.Enabled = False
            End If
            If strModules.Trim = VO.AccountPayable.DownPaymentManual Then chkManual.Checked = True Else chkManual.Checked = False
            txtTotalAmount.Enabled = chkManual.Checked
            txtTotalAmount.BackColor = Color.White
            ToolBarDetail.Enabled = Not chkManual.Checked
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
        ToolBar.Focus()
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf txtCoACodeOfOutgoingPayment.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih akun terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCoACodeOfOutgoingPayment.Focus()
            Exit Sub
        ElseIf txtTotalAmount.Value <= 0 Then
            UI.usForm.frmMessageBox("Total Bayar harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf txtDueDateValue.Value <= 0 Then
            UI.usForm.frmMessageBox("Jatuh Tempo harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtDueDateValue.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 And chkManual.Checked = False Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            grdItemView.Focus()
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
        

        Dim listDetail As New List(Of VO.AccountPayableDet)
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("Pick") Then
                listDetail.Add(New ERPSLib.VO.AccountPayableDet With
                           {
                               .ID = "",
                               .APID = pubID,
                               .PurchaseID = dr.Item("PurchaseID"),
                               .Amount = dr.Item("Amount"),
                               .PPN = dr.Item("PPN"),
                               .PPH = dr.Item("PPH"),
                               .Remarks = UCase(dr.Item("Remarks"))
                           })
            End If
        Next

        clsData = New VO.AccountPayable
        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.APNumber = txtAPNumber.Text.Trim
        clsData.BPID = intBPID
        clsData.CoAIDOfOutgoingPayment = intCoAIDOfOutgoingPayment
        clsData.ReferencesID = ""
        clsData.ReferencesNote = txtReferencesNote.Text.Trim
        clsData.TotalAmount = txtTotalAmount.Value
        clsData.TotalPPN = txtTotalPPN.Value
        clsData.TotalPPH = txtTotalPPH.Value
        clsData.APDate = dtpAPDate.Value.Date
        clsData.DueDateValue = txtDueDateValue.Value
        clsData.Modules = strModules
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Detail = listDetail
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave

        pgMain.Value = 60
        

        Try
            Dim strAPNumber As String = BL.AccountPayable.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strAPNumber)
            pgMain.Value = 80
            
            frmParent.pubRefresh(strAPNumber)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryHistory()
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
        tcHeader.SelectedTab = tpMain
        pubID = ""
        txtAPNumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        intCoAIDOfOutgoingPayment = 0
        txtCoACodeOfOutgoingPayment.Text = ""
        txtCoANameOfOutgoingPayment.Text = ""
        txtReferencesNote.Text = ""
        dtpAPDate.Value = Now
        txtDueDateValue.Value = 0
        txtTotalAmount.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtRemarks.Text = ""
        cboStatus.SelectedValue = VO.Status.Values.Draft
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
    End Sub

    Private Sub prvChooseBP()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
                prvQueryItem()
            End If
        End With
    End Sub

    Private Sub prvChooseCOA()
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = pubCS.CompanyID
            .pubProgramID = pubCS.ProgramID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.CashOrBank
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDOfOutgoingPayment = .pubLUdtRow.Item("ID")
                txtCoACodeOfOutgoingPayment.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfOutgoingPayment.Text = .pubLUdtRow.Item("Name")
                txtReferencesNote.Focus()
            End If
        End With
    End Sub

    Private Sub prvGetModuleID()
        intModuleID = VO.Common.GetModuleID(strModules)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModuleID, IIf(pubIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
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
            If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                If pubIsNew Then
                    dtItem = BL.BusinessPartnerAPBalance.ListDataOutstanding(pubCS.CompanyID, pubCS.ProgramID, intBPID)
                Else
                    If clsData.IsDeleted Then
                        dtItem = BL.AccountPayable.ListDataDetailForSetupBalance(pubID)
                    Else
                        dtItem = BL.AccountPayable.ListDataDetailForSetupBalanceWithOutstanding(pubCS.CompanyID, pubCS.ProgramID, intBPID, pubID)
                    End If
                End If
            ElseIf strModules.Trim = VO.AccountPayable.DownPayment Or
                strModules.Trim = VO.AccountPayable.ReceivePayment Then
                If pubIsNew Then
                    dtItem = BL.PurchaseContract.ListDataOutstandingPayment(pubCS.CompanyID, pubCS.ProgramID, intBPID)
                Else
                    If clsData.IsDeleted Then
                        dtItem = BL.AccountPayable.ListDataDetail(pubID)
                    Else
                        dtItem = BL.AccountPayable.ListDataDetailWithOutstanding(pubCS.CompanyID, pubCS.ProgramID, intBPID, pubID)
                    End If
                End If
            ElseIf strModules.Trim = VO.AccountPayable.DownPaymentCutting Or
                strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                If pubIsNew Then
                    dtItem = BL.PurchaseOrderCutting.ListDataOutstandingPayment(pubCS.CompanyID, pubCS.ProgramID, intBPID)
                Else
                    If clsData.IsDeleted Then
                        dtItem = BL.AccountPayable.ListDataDetail(pubID)
                    Else
                        dtItem = BL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderCutting(pubCS.CompanyID, pubCS.ProgramID, intBPID, pubID)
                    End If
                End If
            ElseIf strModules.Trim = VO.AccountPayable.DownPaymentTransport Or
                strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                If pubIsNew Then
                    dtItem = BL.PurchaseOrderTransport.ListDataOutstanding(pubCS.CompanyID, pubCS.ProgramID, intBPID)
                Else
                    If clsData.IsDeleted Then
                        dtItem = BL.AccountPayable.ListDataDetail(pubID)
                    Else
                        dtItem = BL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderTransport(pubCS.CompanyID, pubCS.ProgramID, intBPID, pubID)
                    End If
                End If
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
        Dim decAmount As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0

        For Each dr As DataRow In dtItem.Rows
            decAmount += dr.Item("Amount")
            decPPN += ERPSLib.SharedLib.Math.Round(dr.Item("PPN"), 2)
            decPPH += ERPSLib.SharedLib.Math.Round(dr.Item("PPH"), 2)
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
                    Dim decAmount As Decimal = .GetRowCellValue(i, "MaxPaymentAmount")
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

#Region "Form Handle"

    Private Sub frmTraAccountPayableDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraAccountPayableDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub btnCoAOfOutgoingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfOutgoingPayment.Click
        prvChooseCOA()
    End Sub

    Private Sub rpiValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rpiValue.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        If (e.KeyChar = ChrW(Asc(","))) Or (e.KeyChar = ChrW(Asc("."))) Then
            e.Handled = False
        End If
    End Sub

    Private Sub grdItemView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles grdItemView.ValidatingEditor
        With grdItemView
            bolValid = True
            Dim col As GridColumn = .FocusedColumn
            Dim intFocus As Integer = .FocusedRowHandle
            Dim decPPNPercent As Decimal = .GetFocusedRowCellValue("PPNPercent")
            Dim decPPHPercent As Decimal = .GetFocusedRowCellValue("PPHPercent")
            If col.Name = "Amount" Then
                Dim oldValue As Decimal = IIf(.GetFocusedRowCellValue(col).Equals(DBNull.Value), 0, .GetFocusedRowCellValue(col))
                Dim newValue As Decimal = IIf((e.Value = "") Or (e.Value.Equals(DBNull.Value) Or (e.Value = ".")), 0, e.Value)

                Dim strErrorMessage As String = ""
                If newValue > 0 And newValue > .GetFocusedRowCellValue("MaxPaymentAmount") Then
                    bolValid = False
                    strErrorMessage = "Total tagihan tidak boleh lebih besar dari total maksimal tagihan"
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
                    If decPPNPercent > 0 Then .SetRowCellValue(intFocus, "PPN", ERPSLib.SharedLib.Math.Round(newValue * decPPNPercent / 100, 2))
                    If decPPHPercent > 0 Then .SetRowCellValue(intFocus, "PPH", ERPSLib.SharedLib.Math.Round(newValue * decPPHPercent / 100, 2))

                    .UpdateCurrentRow()
                    prvCalculate()
                End If
            ElseIf col.Name = "Pick" Then
                If e.Value = True Then
                    Dim decMaxPaymentAmount As Decimal = .GetRowCellValue(intFocus, "MaxPaymentAmount")
                    .SetRowCellValue(intFocus, col.Name, e.Value)
                    .SetRowCellValue(intFocus, "Amount", decMaxPaymentAmount)
                    If decPPNPercent > 0 Then .SetRowCellValue(intFocus, "PPN", ERPSLib.SharedLib.Math.Round(decMaxPaymentAmount * decPPNPercent / 100, 2))
                    If decPPHPercent > 0 Then .SetRowCellValue(intFocus, "PPH", ERPSLib.SharedLib.Math.Round(decMaxPaymentAmount * decPPHPercent / 100, 2))
                ElseIf e.Value = False Then
                    .SetRowCellValue(intFocus, col.Name, e.Value)
                    .SetRowCellValue(intFocus, "Amount", 0)
                    .SetRowCellValue(intFocus, "PPN", 0)
                    .SetRowCellValue(intFocus, "PPH", 0)
                End If
                .UpdateCurrentRow()
                prvCalculate()
            End If
        End With
    End Sub
    'Rounding disemua kalkulasi PPN dan PPH
#End Region

End Class