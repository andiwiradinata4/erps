Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns

Public Class frmTraARAPDetVer6

#Region "Property"

    Private frmParent As frmTraARAP
    Private clsData As New VO.ARAP
    Private intBPID As Integer = 0
    Private strModules As String = ""
    Private intModuleID As Integer = 0
    Private strID As String = ""
    Private bolIsNew As Boolean = False
    Private clsCS As New VO.CS
    Private decPPN As Decimal = 0, decPPH As Decimal = 0
    Private dtItem As New DataTable
    Private bolValid As Boolean = True
    Private decPPNPercentage As Decimal = 0
    Private decPPHPercentage As Decimal = 0

    Public WriteOnly Property pubModules As String
        Set(value As String)
            strModules = value
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
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1

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
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesID", "ReferencesID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesDetailID", "ReferencesDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "SourceID", "SourceID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "SourceName", "Asal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "DestinationID", "DestinationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "DestinationName", "Tujuan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ReferencesDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "PlatNumber", "Nomor Plat", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "DeliveryNumber", "Nomor Surat Jalan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Quantity", "Jumlah [Kg]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Price", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "PPNPercent", "PPN Percent", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPHPercent", "PPH Percent", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPN", "PPN", 100, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPH", "PPH", 100, UI.usDefGrid.gReal2Num, True, False)

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(intModuleID), "StatusID", "StatusName")
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
                clsData = BL.ARAP.GetDetail(strID, VO.ARAP.ARAPTypeValue.Sales)
                txtARAPNumber.Text = clsData.TransNumber
                strModules = clsData.Modules
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                dtpARAPDate.Value = clsData.TransDate
                txtDueDateValue.Value = clsData.DueDateValue
                txtTotalAmount.Value = clsData.TotalAmount
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)
                txtRounding.Value = clsData.Rounding
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
        ToolBar.Focus()
        grdItemView.ClearColumnsFilter()
        prvCalculate()

        If Not bolValid Then Exit Sub

        Dim drPick() As DataRow = dtItem.Select("Pick=True")
        If drPick.Count = 0 Then
            UI.usForm.frmMessageBox("Tidak ada item yang tercentang")
            Exit Sub
        End If
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf txtTotalAmount.Value <= 0 Then
            UI.usForm.frmMessageBox("Total Harga harus lebih besar dari 0")
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
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Pilih item yang ingin di proses")
            tcHeader.SelectedTab = tpMain
            grdItemView.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To grdItemView.RowCount - 1
            If grdItemView.GetRowCellValue(i, "Pick") And grdItemView.GetRowCellValue(i, "Amount") = 0 Then
                UI.usForm.frmMessageBox("Baris ke " & i + 1 & " tercentang namun nilai tagihan 0")
                grdItemView.FocusedRowHandle = i
                Exit Sub
            End If
        Next

        Dim decTotalDPUsed As Decimal = 0
        For i As Integer = 0 To grdItemView.RowCount - 1
            decTotalDPUsed += grdItemView.GetRowCellValue(i, "DPAmount")
        Next

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

        Dim listDetailItem As New List(Of VO.ARAPItem)
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("Pick") Then
                Dim clsDetailItem As New VO.ARAPItem
                clsDetailItem.ID = ""
                clsDetailItem.ParentID = strID
                clsDetailItem.ReferencesID = dr.Item("ReferencesID")
                clsDetailItem.ReferencesDetailID = dr.Item("ReferencesDetailID")
                clsDetailItem.OrderNumberSupplier = ""
                clsDetailItem.ItemID = 0
                clsDetailItem.Amount = dr.Item("TotalPrice")
                clsDetailItem.PPN = dr.Item("PPN")
                clsDetailItem.PPH = dr.Item("PPH")
                clsDetailItem.DPAmount = 0
                clsDetailItem.Rounding = 0
                clsDetailItem.LevelItem = 0
                clsDetailItem.ReferencesParentID = ""
                clsDetailItem.Quantity = 1
                clsDetailItem.Weight = dr.Item("Quantity")
                clsDetailItem.TotalWeight = dr.Item("Quantity")
                listDetailItem.Add(clsDetailItem)
            End If
        Next

        Dim dsHelper As New DataSetHelper
        Dim dtARAPDet As DataTable = dsHelper.SelectGroupByInto("ARAPDet", dtItem, "Pick, ReferencesID, SUM(Amount) Amount, SUM(PPN) PPN, SUM(PPH) PPH, SUM(Quantity) Quantity", "Pick=True", "Pick, ReferencesID")
        Dim listDetail As New List(Of VO.ARAPDet)
        For Each dr As DataRow In dtARAPDet.Rows
            listDetail.Add(New ERPSLib.VO.ARAPDet With
                       {
                           .ID = "",
                           .ARAPID = strID,
                           .InvoiceID = dr.Item("ReferencesID"),
                           .Amount = dr.Item("Amount"),
                           .PPN = dr.Item("PPN"),
                           .PPH = dr.Item("PPH"),
                           .Remarks = "",
                           .DPAmount = 0,
                           .LevelItem = 0,
                           .ReferencesParentID = "",
                           .Quantity = 1,
                           .Weight = dr.Item("Quantity"),
                           .TotalWeight = dr.Item("Quantity"),
                           .InvoiceNumberBP = "",
                           .ReceiveDate = "2000/01/01",
                           .InvoiceDate = "2000/01/01"
                       })
        Next

        clsData = New VO.ARAP
        clsData.ID = strID
        clsData.ProgramID = clsCS.ProgramID
        clsData.CompanyID = clsCS.CompanyID
        clsData.TransNumber = txtARAPNumber.Text.Trim
        clsData.BPID = intBPID
        clsData.BPCode = txtBPCode.Text.Trim
        clsData.BPName = txtBPName.Text.Trim
        clsData.BPBankAccountID = 0
        clsData.BPBankAccountBank = ""
        clsData.BPBankAccountNumber = ""
        clsData.CoAID = 0
        clsData.ReferencesID = ""
        clsData.ReferencesNote = ""
        clsData.TotalAmount = txtTotalAmount.Value
        clsData.TotalPPN = txtTotalPPN.Value
        clsData.TotalPPH = txtTotalPPH.Value
        clsData.TransDate = dtpARAPDate.Value.Date
        clsData.DueDateValue = txtDueDateValue.Value
        clsData.Modules = strModules
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.IsDP = False
        clsData.DPAmount = 0
        clsData.ReceiveAmount = txtTotalAmount.Value
        clsData.IsUseSubItem = 0
        clsData.Detail = listDetail
        clsData.DetailItem = listDetailItem
        clsData.DownPayment = New List(Of VO.ARAPDP)
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.ARAPType = VO.ARAP.ARAPTypeValue.Sales
        clsData.Save = intSave
        clsData.PaymentTypeID = 0
        clsData.PPNPercentage = decPPNPercentage
        clsData.PPHPercentage = decPPHPercentage
        clsData.IsFullDP = False
        clsData.InvoiceNumberBP = ""
        clsData.InvoiceDateBP = "2000/01/01"
        clsData.ReceiveDateInvoice = "2000/01/01"
        clsData.Rounding = txtRounding.Value
        pgMain.Value = 60

        Try
            '# Recalculate Sales Service Detail
            Dim strARAPNumber As String = BL.ARAP.SaveDataVer3_ReceivePayment(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strARAPNumber)
            pgMain.Value = 80
            frmParent.pubRefresh(strARAPNumber)
            If bolIsNew Then
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
        txtARAPNumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        dtpARAPDate.Value = Now
        txtDueDateValue.Value = 0
        cboStatus.SelectedValue = VO.Status.Values.Draft
        txtTotalAmount.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtRemarks.Text = ""
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
        txtRounding.Value = 0
        txtGrandTotal.Value = 0
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
                prvCalculate()
            End If
        End With
    End Sub

    Private Sub prvGetModuleID()
        intModuleID = VO.Common.GetModuleID(strModules)
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModuleID, IIf(bolIsNew, VO.Access.Value.NewAccess, VO.Access.Value.EditAccess))
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
            If bolIsNew Then
                dtItem = BL.ARAP.ListDataDetailItemReceiveWithOutstandingVer2(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID)
            Else
                If clsData.IsDeleted Then
                    dtItem = BL.ARAP.ListDataDetailItemReceiveWithOutstandingVer2(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID)
                    dtItem.Clear()
                Else
                    dtItem = BL.ARAP.ListDataDetailItemReceiveWithOutstandingVer2(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID)
                End If
            End If

            grdItem.DataSource = dtItem
            grdItemView.BestFitColumns()
            pgMain.Value = 100
            prvCalculate()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            prvSumGrid()
            prvSetButton()
            prvResetProgressBar()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvCalculate()
        Dim decTotalPrice As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0

        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Pick") Then
                    decTotalPrice += .GetRowCellValue(i, "TotalPrice")
                    decPPN += .GetRowCellValue(i, "PPN")
                    decPPH += .GetRowCellValue(i, "PPH")
                End If
            Next
            grdItemView.BestFitColumns()
        End With

        txtTotalAmount.Value = decTotalPrice
        txtTotalPPN.Value = decPPN
        txtTotalPPH.Value = decPPH
        txtGrandTotal.Value = decTotalPrice + decPPN - decPPH + txtRounding.Value
    End Sub

    Private Sub prvChangeCheckedValue(ByVal bolValue As Boolean)
        ToolBarDetail.Focus()
        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "Pick", bolValue)
                .UpdateCurrentRow()
            Next
            prvCalculate()
            .BestFitColumns()
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Item
        Dim SumTotalAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Tagihan: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PPN", "Total PPN: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PPH", "Total PPH: {0:#,##0.00}")
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.00}")

        If grdItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPrice").Summary.Add(SumTotalAmount)
        End If

        If grdItemView.Columns("PPN").SummaryText.Trim = "" Then
            grdItemView.Columns("PPN").Summary.Add(SumTotalPPN)
        End If

        If grdItemView.Columns("PPH").SummaryText.Trim = "" Then
            grdItemView.Columns("PPH").Summary.Add(SumTotalPPH)
        End If

        If grdItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdItemView.GroupCount > 0 Then grdItemView.ExpandAllGroups()
        grdItemView.BestFitColumns(True)
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            grdStatus.DataSource = BL.AccountReceivable.ListDataStatus(strID)
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

    Private Sub frmTraARAPDetVer6_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmTraARAPDetVer6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        lblInfo.Text += VO.Common.GetPaymentText(strModules)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub ToolBarDetail_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Centang Semua" : prvChangeCheckedValue(True)
            Case "Tidak Centang Semua" : prvChangeCheckedValue(False)
        End Select
    End Sub

    Private Sub grdItemView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles grdItemView.ValidatingEditor
        With grdItemView
            bolValid = True
            Dim col As GridColumn = .FocusedColumn
            Dim intFocus As Integer = .FocusedRowHandle
            If col.Name = "Pick" Then
                .SetRowCellValue(intFocus, col.Name, e.Value)
                .UpdateCurrentRow()
                prvCalculate()
            End If
        End With
    End Sub

#End Region
End Class