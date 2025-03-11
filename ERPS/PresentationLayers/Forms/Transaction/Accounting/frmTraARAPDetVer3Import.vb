Imports DevExpress.XtraGrid.Columns
Public Class frmTraARAPDetVer3Import

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
    Private dtItem As New DataTable
    Private bolValid As Boolean = True
    Private bolIsUseSubItem As Boolean
    Private decPPNPercentage As Decimal = 0
    Private decPPHPercentage As Decimal = 0
    Private decTotalDPPImport As Decimal = 0
    Private decTotalPPNImport As Decimal = 0
    Private decTotalPPHImport As Decimal = 0
    Private dtItemImport As New DataTable
    Property pubIDLookup As String = ""

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

    Public WriteOnly Property pubIsUseSubItem As Boolean
        Set(value As Boolean)
            bolIsUseSubItem = value
        End Set
    End Property

    Public WriteOnly Property pubPPNPercentage As Decimal
        Set(value As Decimal)
            decPPNPercentage = value
        End Set
    End Property

    Public WriteOnly Property pubPPHPercentage As Decimal
        Set(value As Decimal)
            decPPHPercentage = value
        End Set
    End Property

    Public WriteOnly Property pubTotalDPPImport As Decimal
        Set(value As Decimal)
            decTotalDPPImport = value
        End Set
    End Property

    Public WriteOnly Property pubTotalPPNImport As Decimal
        Set(value As Decimal)
            decTotalPPNImport = value
        End Set
    End Property

    Public WriteOnly Property pubTotalPPHImport As Decimal
        Set(value As Decimal)
            decTotalPPHImport = value
        End Set
    End Property

    Public WriteOnly Property pubDtItemImport As DataTable
        Set(value As DataTable)
            dtItemImport = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1, cCalculate As Byte = 2

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
        UI.usForm.SetGrid(grdItemView, "Quantity", "Jumlah", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "Weight", "Berat", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "Amount", "Total Tagihan", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "DPAmount", "Total Panjar", 150, UI.usDefGrid.gReal2Num, False)
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
                clsData = New VO.ARAP
                clsData = BL.ARAP.GetDetail(pubIDLookup, enumARAPType)
                txtDPNumber.Text = clsData.TransNumber
                intCoAID = clsData.CoAID
                txtCoACode.Text = clsData.CoACode
                txtCoAName.Text = clsData.CoAName
                txtPercentage.Value = clsData.Percentage
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

                If txtPercentage.Value > 0 Then
                    chkUsePercentage.Checked = True
                    txtPercentage.Enabled = True
                    txtPercentage.BackColor = Color.White

                    txtTotalAmount.Enabled = False
                    txtTotalAmount.BackColor = Color.LightYellow
                End If
            End If
            prvGetAmount()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvGetAmount()
        Dim clsReferences As New Object
        If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
            If strModules = VO.AccountReceivable.DownPaymentOrderRequest Or strModules = VO.AccountReceivable.DownPaymentOrderRequestVer2 Then
                clsReferences = BL.OrderRequest.GetDetail(strReferencesID)
            ElseIf strModules = VO.AccountReceivable.DownPayment Then
                clsReferences = BL.SalesContract.GetDetail(strReferencesID)
            End If

            txtGrandTotalContract.Value = clsReferences.TotalDPP
            txtTotalPayment.Value = clsReferences.DPAmount + clsReferences.ReceiveAmount - txtTotalAmount.Value
            decPPN = clsReferences.PPN
            decPPH = clsReferences.PPH
        Else
            If strModules = VO.AccountPayable.DownPaymentCutting Or strModules = VO.AccountPayable.ReceivePaymentCutting Then
                clsReferences = BL.PurchaseOrderCutting.GetDetail(strReferencesID)
            ElseIf strModules = VO.AccountPayable.DownPaymentTransport Or strModules = VO.AccountPayable.ReceivePaymentTransport Then
                clsReferences = BL.PurchaseOrderTransport.GetDetail(strReferencesID)
            ElseIf strModules = VO.AccountPayable.DownPayment Or strModules = VO.AccountPayable.ReceivePayment Then
                clsReferences = BL.PurchaseContract.GetDetail(strReferencesID)
            Else
                Exit Sub
            End If
            txtGrandTotalContract.Value = clsReferences.TotalDPP
            txtTotalPayment.Value = clsReferences.DPAmount + clsReferences.ReceiveAmount - txtTotalAmount.Value
            decPPN = clsReferences.PPN
            decPPH = clsReferences.PPH
        End If
        txtOutstandingPayment.Value = txtGrandTotalContract.Value - txtTotalPayment.Value
    End Sub

    Private Sub prvSave()
        ToolBar.Focus()
        'If txtCoACode.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Pilih akun terlebih dahulu")
        '    tcHeader.SelectedTab = tpMain
        '    txtCoACode.Focus()
        '    Exit Sub
        If txtTotalAmount.Value <= 0 Then
            UI.usForm.frmMessageBox("Total Bayar harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf txtDueDateValue.Value <= 0 Then
            UI.usForm.frmMessageBox("Jatuh Tempo harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtDueDateValue.Focus()
            Exit Sub
        ElseIf txtTotalAmount.Value > txtOutstandingPayment.Value Then
            UI.usForm.frmMessageBox("Total Bayar harus lebih kecil atau sama dengan nilai Sisa Bayar")
            tcHeader.SelectedTab = tpMain
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To grdItemView.RowCount - 1
            If grdItemView.GetRowCellValue(i, "Pick") And grdItemView.GetRowCellValue(i, "Amount") = 0 Then
                UI.usForm.frmMessageBox("Baris ke " & i + 1 & " tercentang namun nilai tagihan 0")
                grdItemView.FocusedRowHandle = i
                Exit Sub
            End If
        Next

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

        If Not prvCheckIsValidItem() Then Exit Sub

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
        Dim listDetail As New List(Of VO.ARAPDet)
        Dim clsDetail As New VO.ARAPDet
        clsDetail.ID = ""
        clsDetail.ARAPID = strID
        clsDetail.InvoiceID = strReferencesID
        clsDetail.Amount = txtTotalAmount.Value
        clsDetail.PPN = txtTotalPPN.Value
        clsDetail.PPH = txtTotalPPH.Value
        clsDetail.Remarks = txtRemarks.Text.Trim
        clsDetail.DPAmount = 0
        clsDetail.LevelItem = 0
        clsDetail.ReferencesParentID = ""
        listDetail.Add(clsDetail)

        Dim listDetailItem As New List(Of VO.ARAPItem)
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("Pick") Then
                Dim clsDetailItem As New VO.ARAPItem
                clsDetailItem.ID = ""
                clsDetailItem.ParentID = strID
                clsDetailItem.ReferencesID = strReferencesID
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
                clsDetailItem.Quantity = dr.Item("Quantity")
                clsDetailItem.Weight = dr.Item("Weight")
                clsDetailItem.TotalWeight = dr.Item("TotalWeight")
                listDetailItem.Add(clsDetailItem)
            End If
        Next

        clsData = New VO.ARAP
        clsData.ID = strID
        clsData.ProgramID = clsCS.ProgramID
        clsData.CompanyID = clsCS.CompanyID
        clsData.TransNumber = txtDPNumber.Text.Trim
        clsData.BPID = intBPID
        clsData.CoAID = intCoAID
        clsData.ReferencesID = strReferencesID
        clsData.ReferencesNote = ""
        clsData.TotalAmount = txtTotalAmount.Value
        clsData.Percentage = txtPercentage.Value
        clsData.TotalPPN = txtTotalPPN.Value
        clsData.TotalPPH = txtTotalPPH.Value
        clsData.TransDate = dtpDPDate.Value.Date
        clsData.DueDateValue = txtDueDateValue.Value
        clsData.Modules = strModules
        clsData.ARAPType = enumARAPType
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = VO.Status.Values.Draft
        clsData.IsDP = True
        clsData.Detail = listDetail
        clsData.DetailItem = listDetailItem
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.IsUseSubItem = bolIsUseSubItem
        clsData.PPNPercentage = decPPNPercentage
        clsData.PPHPercentage = decPPHPercentage
        clsData.IsGenerate = True
        clsData.Save = intSave

        pgMain.Value = 60
        Try
            Dim strARAPNumber As String = BL.ARAP.SaveDataVer2(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strARAPNumber)
            pgMain.Value = 80
            frmParent.pubRefresh(strARAPNumber)
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
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
                txtPercentage.Focus()
            End If
        End With
    End Sub

    Private Sub prvGetModuleID()
        intModuleID = VO.Common.GetModuleID(strModules)
    End Sub

    Private Sub prvCalculate()
        Dim decAmount As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0
        For Each dr As DataRow In dtItem.Rows
            decAmount += dr.Item("Amount")
            decPPN += dr.Item("PPN") 'ERPSLib.SharedLib.Math.Round(dr.Item("Amount") * dr.Item("PPNPercent") / 100, 2)
            decPPH += dr.Item("PPH") 'ERPSLib.SharedLib.Math.Round(dr.Item("Amount") * dr.Item("PPHPercent") / 100, 2)
        Next
        txtTotalAmount.Value = decAmount
        txtTotalPPN.Value = decPPN
        txtTotalPPH.Value = decPPH
    End Sub

#Region "Item Handle"

    Private Sub prvSetButton()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
            .Buttons(cCheckAll).Enabled = bolEnabled
            .Buttons(cUncheckAll).Enabled = bolEnabled
            .Buttons(cCalculate).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Try
            pgMain.Value = 30
            Me.Cursor = Cursors.WaitCursor
            If bolIsNew Then
                dtItem = BL.ARAP.ListDataDetailItemDPWithOutstandingVer2(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID, enumARAPType, strReferencesID, bolIsUseSubItem)
            Else
                If clsData.IsDeleted Then
                    dtItem = BL.ARAP.ListDataDetailVer2(strID, enumARAPType)
                Else
                    dtItem = BL.ARAP.ListDataDetailItemDPWithOutstandingVer2(clsCS.CompanyID, clsCS.ProgramID, intBPID, strID, enumARAPType, strReferencesID, bolIsUseSubItem)
                End If
            End If
            grdItem.DataSource = dtItem

            '# Marking Exists Item
            With grdItemView
                For i As Integer = 0 To .RowCount - 1
                    Dim drExists() As DataRow = dtItemImport.Select("ItemID=" & .GetRowCellValue(i, "ItemID"))
                    If drExists.Length > 0 Then
                        .SetRowCellValue(i, "Pick", True)
                        .UpdateCurrentRow()
                        prvSetAmount(i)
                        .UpdateCurrentRow()
                    End If
                Next
            End With
            grdItemView.BestFitColumns()
            prvCalculateItem()
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

    Private Sub prvSetAmount(ByVal intPos As Integer)
        Dim decMaxAmount As Decimal = grdItemView.GetRowCellValue(intPos, "MaxPaymentAmount")
        Dim decUnitPrice As Decimal = grdItemView.GetRowCellValue(intPos, "UnitPrice")
        Dim decTotalWeight As Decimal = grdItemView.GetRowCellValue(intPos, "TotalWeight")
        Dim decAmount As Decimal = IIf(grdItemView.GetRowCellValue(intPos, "Pick") = 0, 0, decUnitPrice * decTotalWeight)
        If chkUsePercentage.Checked And txtPercentage.Value > 0 And decAmount > 0 Then
            decAmount = ERPSLib.SharedLib.Math.Round(decAmount * txtPercentage.Value / 100, 2)
        End If
        If decAmount > decMaxAmount Then
            UI.usForm.frmMessageBox("Total tagihan baris ke " & intPos + 1 & " tidak boleh lebih besar dari total maksimal tagihan")
            Exit Sub
        End If

        grdItemView.SetRowCellValue(intPos, "Amount", decAmount)
    End Sub

    Private Function prvCheckIsValidItem() As Boolean
        For i As Integer = 0 To grdItemView.RowCount - 1
            Dim decMaxAmount As Decimal = grdItemView.GetRowCellValue(i, "MaxPaymentAmount")
            Dim decUnitPrice As Decimal = grdItemView.GetRowCellValue(i, "UnitPrice")
            Dim decTotalWeight As Decimal = grdItemView.GetRowCellValue(i, "TotalWeight")
            Dim decAmount As Decimal = IIf(grdItemView.GetRowCellValue(i, "Pick") = 0, 0, decUnitPrice * decTotalWeight)
            If chkUsePercentage.Checked And txtPercentage.Value > 0 And decAmount > 0 Then
                decAmount = ERPSLib.SharedLib.Math.Round(decAmount * txtPercentage.Value / 100, 2)
            End If
            If decAmount > decMaxAmount Then
                UI.usForm.frmMessageBox("Total tagihan baris ke " & i + 1 & " tidak boleh lebih besar dari total maksimal tagihan")
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub prvSetTotalWeight(ByVal intPos As Integer)
        Dim decAllocateTotalWeight As Decimal = grdItemView.GetRowCellValue(intPos, "Quantity") * grdItemView.GetRowCellValue(intPos, "Weight")
        grdItemView.SetRowCellValue(intPos, "TotalWeight", decAllocateTotalWeight)
        grdItemView.UpdateCurrentRow()
    End Sub

    Private Sub prvCalculateItem()
        Dim decAmount As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0
        For Each dr As DataRow In dtItem.Rows
            Dim decValue As Decimal = 0
            If dr.Item("Pick") Then
                If chkUsePercentage.Checked And txtPercentage.Value > 0 Then
                    decValue = dr.Item("Amount")
                Else
                    decAmount = dr.Item("MaxPaymentAmount")
                End If
            End If

            dr.BeginEdit()
            dr.Item("Amount") = decValue
            dr.Item("PPN") = IIf(decValue = 0, 0, ERPSLib.SharedLib.Math.Round(decValue * dr.Item("PPNPercent") / 100, 2))
            dr.Item("PPH") = IIf(decValue = 0, 0, ERPSLib.SharedLib.Math.Round(decValue * dr.Item("PPHPercent") / 100, 2))
            dr.EndEdit()
            dr.AcceptChanges()
        Next
        grdItem.DataSource = dtItem
        grdItemView.BestFitColumns()

        prvCalculate()
    End Sub

    Private Sub prvChangeCheckedValue(ByVal bolValue As Boolean)
        For Each dr As DataRow In dtItem.Rows
            dr.BeginEdit()
            dr.Item("Pick") = bolValue
            dr.EndEdit()
            dr.AcceptChanges()
        Next
        For i As Integer = 0 To grdItemView.RowCount - 1
            prvSetAmount(i)
        Next
        prvCalculateItem()
        ToolBarDetail.Focus()
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

    Private Sub frmTraARAPDetVer3Import_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmTraARAPDetVer3Import_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prvGetModuleID()
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryHistory()
        txtDueDateValue.Minimum = 0
        txtPercentage.Maximum = 100
        AddHandler txtPercentage.ValueChanged, AddressOf txtPercentage_ValueChanged
        AddHandler chkUsePercentage.CheckedChanged, AddressOf chkUsePercentage_CheckedChanged
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
            Case "Kalkulasi" : prvCalculateItem()
        End Select
    End Sub

    Private Sub btnCoAOfOutgoingPayment_Click(sender As Object, e As EventArgs) Handles btnCoAOfOutgoingPayment.Click
        prvChooseCOA()
    End Sub

    Private Sub txtPercentage_ValueChanged(sender As Object, e As EventArgs)
        For i As Integer = 0 To grdItemView.RowCount - 1
            prvSetAmount(i)
        Next
        prvCalculateItem()
    End Sub

    Private Sub chkUsePercentage_CheckedChanged(sender As Object, e As EventArgs)
        If chkUsePercentage.Checked Then
            txtPercentage.Enabled = True
            txtPercentage.BackColor = Color.White
            txtTotalAmount.Value = 0
            'txtTotalAmount.Enabled = False
            'txtTotalAmount.BackColor = Color.LightYellow
        Else
            txtPercentage.Value = 0
            txtPercentage.Enabled = False
            txtPercentage.BackColor = Color.LightYellow
            'txtTotalAmount.Enabled = True
            'txtTotalAmount.BackColor = Color.White
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
                    .BestFitColumns()
                    prvCalculate()
                End If
            ElseIf col.Name = "Pick" Then
                .SetRowCellValue(intFocus, col.Name, e.Value)
                .UpdateCurrentRow()
                prvSetAmount(intFocus)
                prvCalculateItem()
            ElseIf col.Name = "TotalWeight" Then
                .SetRowCellValue(intFocus, col.Name, e.Value)
                prvSetAmount(intFocus)
                .UpdateCurrentRow()
                prvCalculateItem()
            ElseIf col.Name = "Quantity" Then
                .SetRowCellValue(intFocus, col.Name, e.Value)
                prvSetTotalWeight(intFocus)
                prvSetAmount(intFocus)
                .UpdateCurrentRow()
                prvCalculateItem()
            End If
        End With
    End Sub

#End Region

End Class