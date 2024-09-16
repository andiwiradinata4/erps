Imports DevExpress.XtraGrid.Columns
Public Class frmTraARAPDetVer4

#Region "Property"

    Private frmParent As frmTraARAP
    Private clsData As New VO.ARAP
    Private intBPID As Integer = 0,
        strBPCode As String = "", strBPName As String = ""
    Private intCoAID As Integer = 0
    Private strModules As String = ""
    Private intModuleID As Integer = 0
    Private enumARAPType As VO.ARAP.ARAPTypeValue
    Private strReferencesID As String = "",
        strReferencesNumber As String = ""
    Private strID As String = ""
    Private bolIsNew As Boolean = False
    Private clsCS As New VO.CS
    Private decPPN As Decimal = 0, decPPH As Decimal = 0
    Private dtItem As New DataTable
    Private bolIsLookup As Boolean = False
    Private bolValid As Boolean = True
    Private bolIsUseSubItem As Boolean = True

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

    Public WriteOnly Property pubBPCode As String
        Set(value As String)
            strBPCode = value
        End Set
    End Property

    Public WriteOnly Property pubBPName As String
        Set(value As String)
            strBPName = value
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

    Public WriteOnly Property pubReferencesNumber As String
        Set(value As String)
            strReferencesNumber = value
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

    Public WriteOnly Property pubIsLookup As Boolean
        Set(value As Boolean)
            bolIsLookup = value
        End Set
    End Property

    Public WriteOnly Property pubIsUseSubItem As Boolean
        Set(value As Boolean)
            bolIsUseSubItem = value
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
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesID", "ReferencesID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesDetailID", "ReferencesDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "InvoiceAmount", "InvoiceAmount", 250, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "Amount", "Total Tagihan", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "DPAmount", "Total Panjar", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPNPercent", "PPNPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPHPercent", "PPHPercent", 150, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "PPN", "PPN", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPH", "PPH", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "MaxPaymentAmount", "Total Maksimal Tagihan", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 250, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemName", "Nama Barang", 250, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesParentID", "ReferencesParentID", 100, UI.usDefGrid.gString, False)
        grdItemView.Columns("Amount").ColumnEdit = rpiValue
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
            If bolIsNew Then
                prvClear()
            Else
                clsData = New VO.ARAP
                clsData = BL.ARAP.GetDetail(strID, enumARAPType)
                txtARAPNumber.Text = clsData.TransNumber
                intCoAID = clsData.CoAID
                txtCoACode.Text = clsData.CoACode
                txtCoAName.Text = clsData.CoAName
                txtTotalDP.Value = clsData.Percentage
                strModules = clsData.Modules
                dtpARAPDate.Value = clsData.TransDate
                txtDueDateValue.Value = clsData.DueDateValue
                txtDPAllocate.Value = clsData.DPAmount
                txtTotalAmount.Value = clsData.TotalAmount
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                'dtpARAPDate.Enabled = False
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
        If Not bolValid Then Exit Sub
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
            'ElseIf txtCoACode.Text.Trim = "" Then
            '    UI.usForm.frmMessageBox("Pilih akun terlebih dahulu")
            '    tcHeader.SelectedTab = tpMain
            '    txtCoACode.Focus()
            '    Exit Sub
        ElseIf txtTotalAmount.Value + txtTotalDP.Value <= 0 Then
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
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Pilih item yang ingin di proses")
            tcHeader.SelectedTab = tpMain
            grdItemView.Focus()
            Exit Sub
        End If

        Dim decTotalDPUsed As Decimal = 0
        For i As Integer = 0 To grdItemView.RowCount - 1
            decTotalDPUsed += grdItemView.GetRowCellValue(i, "DPAmount")
        Next

        If txtTotalDP.Value <> decTotalDPUsed Then
            UI.usForm.frmMessageBox("Total Panjar dan Total Alokasi Panjar harus sesuai")
            grdItemView.Focus()
            Exit Sub
        End If

        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Amount") + .GetRowCellValue(i, "DPAmount") > .GetRowCellValue(i, "MaxPaymentAmount") Then
                    UI.usForm.frmMessageBox("Total Tagihan " & .GetRowCellValue(i, "OrderNumberSupplier") & " | " & .GetRowCellValue(i, "ItemName") & " tidak boleh melebihi nilai maksimal tagihan")
                    tcHeader.SelectedTab = tpMain
                    grdItem.Focus()
                    Exit Sub
                End If
            Next
        End With

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
                clsDetailItem.OrderNumberSupplier = dr.Item("OrderNumberSupplier")
                clsDetailItem.ItemID = dr.Item("ItemID")
                clsDetailItem.Amount = dr.Item("Amount")
                clsDetailItem.PPN = dr.Item("PPN")
                clsDetailItem.PPH = dr.Item("PPH")
                clsDetailItem.DPAmount = dr.Item("DPAmount")
                clsDetailItem.Rounding = dr.Item("Rounding")
                clsDetailItem.LevelItem = dr.Item("LevelItem")
                clsDetailItem.ReferencesParentID = dr.Item("ReferencesParentID")
                listDetailItem.Add(clsDetailItem)
            End If
        Next

        Dim dsHelper As New DataSetHelper
        Dim dtARAPDet As DataTable = dsHelper.SelectGroupByInto("ARAPDet", dtItem, "Pick, ReferencesID, SUM(Amount) Amount, SUM(PPN) PPN, SUM(PPH) PPH, SUM(DPAmount) DPAmount, LevelItem, ReferencesParentID", "Pick=True", "Pick, ReferencesID, LevelItem, ReferencesParentID")
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
                           .DPAmount = UCase(dr.Item("DPAmount")),
                           .LevelItem = dr.Item("LevelItem"),
                           .ReferencesParentID = dr.Item("ReferencesParentID")
                       })
        Next

        Dim listDownPayment As New List(Of VO.ARAPDP)
        For i As Integer = 0 To grdDownPaymentView.RowCount - 1
            If grdDownPaymentView.GetRowCellValue(i, "Pick") And grdDownPaymentView.GetRowCellValue(i, "DPAmount") > 0 Then
                listDownPayment.Add(New ERPSLib.VO.ARAPDP With
                                    {
                                        .ID = "",
                                        .ParentID = strID,
                                        .DPID = grdDownPaymentView.GetRowCellValue(i, "DPID"),
                                        .DPAmount = grdDownPaymentView.GetRowCellValue(i, "DPAmount")
                                    })
            End If
        Next

        clsData = New VO.ARAP
        clsData.ID = strID
        clsData.ProgramID = clsCS.ProgramID
        clsData.CompanyID = clsCS.CompanyID
        clsData.TransNumber = txtARAPNumber.Text.Trim
        clsData.BPID = intBPID
        clsData.CoAID = intCoAID
        clsData.ReferencesID = strReferencesID.Trim
        clsData.ReferencesNumber = txtReferencesNumber.Text.Trim
        clsData.ReferencesNote = txtReferencesNumber.Text.Trim
        clsData.TotalAmount = txtTotalAmount.Value
        clsData.TotalPPN = txtTotalPPN.Value
        clsData.TotalPPH = txtTotalPPH.Value
        clsData.TransDate = dtpARAPDate.Value.Date
        clsData.DueDateValue = txtDueDateValue.Value
        clsData.Modules = strModules
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.IsDP = False
        clsData.DPAmount = txtDPAllocate.Value
        clsData.ReceiveAmount = txtTotalAmount.Value
        clsData.IsUseSubItem = bolIsUseSubItem
        clsData.Detail = listDetail
        clsData.DetailItem = listDetailItem
        clsData.DownPayment = listDownPayment
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.ARAPType = enumARAPType
        clsData.Save = intSave

        pgMain.Value = 60

        Try
            Dim strARAPNumber As String = BL.ARAP.SaveDataVer3_ReceivePayment(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strARAPNumber)
            pgMain.Value = 80
            frmParent.pubRefresh(strARAPNumber)
            If bolIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryDP()
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
        If Not bolIsLookup Then intBPID = 0
        If Not bolIsLookup Then txtBPCode.Text = ""
        If Not bolIsLookup Then txtBPName.Text = ""
        If Not bolIsLookup Then strReferencesID = ""
        If Not bolIsLookup Then txtReferencesNumber.Text = ""
        intCoAID = 0
        txtCoACode.Text = ""
        txtCoAName.Text = ""
        dtpARAPDate.Value = Now
        txtDueDateValue.Value = 0
        cboStatus.SelectedValue = VO.Status.Values.Draft
        txtTotalDP.Value = 0
        txtDPAllocate.Value = 0
        txtTotalAmount.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtRemarks.Text = ""
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
                If intBPID <> .pubLUdtRow.Item("ID") Then
                    strReferencesID = ""
                    txtReferencesNumber.Text = ""
                End If

                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
                prvQueryDP()
                prvQueryItem()
                prvCalculate()
            End If
        End With
    End Sub

    Private Sub prvChooseReferences()

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
            .Buttons(cAllocateDP).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Try
            pgMain.Value = 30
            Me.Cursor = Cursors.WaitCursor
            If bolIsNew Then
                dtItem = BL.ARAP.ListDataDetailItemReceiveWithOutstandingVer2(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID, enumARAPType, strReferencesID)
            Else
                If clsData.IsDeleted Then
                    dtItem = BL.ARAP.ListDataDetailVer2(strID, enumARAPType)
                Else
                    dtItem = BL.ARAP.ListDataDetailItemReceiveWithOutstandingVer2(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID, enumARAPType, strReferencesID)
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
        Dim decDPAllocate As Decimal = 0, decAmount As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0

        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Amount") > 0 And .GetRowCellValue(i, "PPNPercent") > 0 Then .SetRowCellValue(i, "PPN", ERPSLib.SharedLib.Math.Round(.GetRowCellValue(i, "Amount") * .GetRowCellValue(i, "PPNPercent") / 100, 2)) Else .SetRowCellValue(i, "PPN", 0)
                If .GetRowCellValue(i, "Amount") > 0 And .GetRowCellValue(i, "PPHPercent") > 0 Then .SetRowCellValue(i, "PPH", ERPSLib.SharedLib.Math.Round(.GetRowCellValue(i, "Amount") * .GetRowCellValue(i, "PPHPercent") / 100, 2)) Else .SetRowCellValue(i, "PPH", 0)
                .UpdateCurrentRow()
            Next
        End With

        For Each dr As DataRow In dtItem.Rows
            decDPAllocate += dr.Item("DPAmount")
            decAmount += dr.Item("Amount")
            decPPN += dr.Item("PPN") 'ERPSLib.SharedLib.Math.Round(dr.Item("Amount") * dr.Item("PPNPercent") / 100, 2)
            decPPH += dr.Item("PPH") 'ERPSLib.SharedLib.Math.Round(dr.Item("Amount") * dr.Item("PPHPercent") / 100, 2)
        Next
        txtDPAllocate.Value = decDPAllocate
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

        Dim strDPModules As String = VO.AccountPayable.All
        If strModules.Trim = VO.AccountPayable.ReceivePayment Then strDPModules = VO.AccountPayable.DownPayment
        If strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then strDPModules = VO.AccountPayable.DownPaymentCutting
        If strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then strDPModules = VO.AccountPayable.DownPaymentTransport

        If strModules.Trim = VO.AccountReceivable.ReceivePayment Then strDPModules = VO.AccountReceivable.DownPayment
        If strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then strDPModules = VO.AccountReceivable.DownPaymentOrderRequest
        Try
            If clsData.IsDeleted Then
                grdDownPayment.DataSource = BL.ARAP.ListDataDownpayment(strID, enumARAPType)
            Else
                grdDownPayment.DataSource = BL.ARAP.ListDataDownPaymentWithOutstanding(clsCS.CompanyID, clsCS.ProgramID, intBPID, strDPModules, strID, enumARAPType, strReferencesID)
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
            End If
            prvCalculateDP()
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
        ToolBarDetail.Focus()
        Dim decOutstandingDP As Decimal = txtTotalDP.Value
        With grdItemView

            '# Reset Value
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "DPAmount", 0)
                .SetRowCellValue(i, "Amount", 0)
                .UpdateCurrentRow()
            Next

            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Pick") Then
                    If decOutstandingDP > 0 Then
                        If .GetRowCellValue(i, "MaxPaymentAmount") > decOutstandingDP Then
                            .SetRowCellValue(i, "DPAmount", decOutstandingDP)
                            .SetRowCellValue(i, "Amount", .GetRowCellValue(i, "MaxPaymentAmount") - decOutstandingDP)
                            decOutstandingDP = 0
                        Else
                            .SetRowCellValue(i, "DPAmount", .GetRowCellValue(i, "MaxPaymentAmount"))
                            .SetRowCellValue(i, "Amount", 0)
                            decOutstandingDP -= .GetRowCellValue(i, "MaxPaymentAmount")
                        End If
                    Else
                        .SetRowCellValue(i, "Amount", .GetRowCellValue(i, "MaxPaymentAmount"))
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

    Private Sub frmTraARAPVer4_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmTraARAPVer4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prvGetModuleID()
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryDP()
        prvQueryHistory()
        prvUserAccess()
        txtDueDateValue.Minimum = 0
        Me.Text += IIf(strReferencesID.Trim = "", "", " - ") & strReferencesID
        lblInfo.Text += VO.Common.GetPaymentText(strModules)
        btnCoAOfOutgoingPayment.Enabled = False
        If bolIsLookup Then
            btnBP.Enabled = False
            btnReferences.Enabled = False
            txtBPCode.Text = strBPCode
            txtBPName.Text = strBPName
            txtReferencesNumber.Text = strReferencesNumber
        End If
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
            Case "Alokasi Panjar" : prvAllocateDP()
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub btnReferences_Click(sender As Object, e As EventArgs) Handles btnReferences.Click
        prvChooseReferences()
    End Sub

    Private Sub btnCoAOfOutgoingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfOutgoingPayment.Click
        prvChooseCOA()
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
                .SetRowCellValue(intFocus, col.Name, e.Value)
                .UpdateCurrentRow()
                prvAllocateDP()
                prvCalculate()
            ElseIf col.Name = "DPAmount" Then
                Dim newValue As Decimal = IIf((e.Value = "") Or (e.Value.Equals(DBNull.Value) Or (e.Value = ".")), 0, e.Value)
                .SetRowCellValue(intFocus, col.Name, newValue)
                If decPPNPercent > 0 Then .SetRowCellValue(intFocus, "PPN", ERPSLib.SharedLib.Math.Round(newValue * decPPNPercent / 100, 2))
                If decPPHPercent > 0 Then .SetRowCellValue(intFocus, "PPH", ERPSLib.SharedLib.Math.Round(newValue * decPPHPercent / 100, 2))

                .UpdateCurrentRow()
                prvCalculate()
            End If
        End With
    End Sub

    Private Sub grdDownPaymentView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles grdDownPaymentView.ValidatingEditor
        With grdDownPaymentView
            bolValid = True
            Dim col As GridColumn = .FocusedColumn
            Dim intFocus As Integer = .FocusedRowHandle
            If col.Name = "Pick" Then
                If e.Value Then
                    .SetRowCellValue(intFocus, "DPAmount", .GetRowCellValue(intFocus, "MaxDPAmount"))
                Else
                    .SetRowCellValue(intFocus, "DPAmount", 0)
                End If
                .SetRowCellValue(intFocus, "Pick", e.Value)
                .UpdateCurrentRow()
                prvCalculateDP()
            ElseIf col.Name = "DPAmount" Then
                Dim oldValue As Decimal = IIf(.GetFocusedRowCellValue(col).Equals(DBNull.Value), 0, .GetFocusedRowCellValue(col))
                Dim newValue As Decimal = IIf((e.Value = "") Or (e.Value.Equals(DBNull.Value) Or (e.Value = ".")), 0, e.Value)

                Dim strErrorMessage As String = ""
                If newValue > 0 And newValue > .GetFocusedRowCellValue("MaxDPAmount") Then
                    bolValid = False
                    strErrorMessage = "Total panjar tidak boleh lebih besar dari total maksimal panjar"
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
                    prvCalculateDP()
                End If
            End If
        End With
    End Sub

#End Region

End Class