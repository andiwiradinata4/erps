﻿Imports DevExpress.XtraGrid

Public Class frmTraPurchaseContractDetVer1

#Region "Property"

    Private frmParent As frmTraPurchaseContract
    Private clsData As VO.PurchaseContract
    Private intBPID As Integer = 0
    Private dtItem As New DataTable
    Private dtSubItem As New DataTable
    Private dtPaymentTerm As New DataTable
    Private intPos As Integer = 0
    Property pubID As String = ""
    Property pubIsNew As Boolean = False
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cAddItem As Byte = 0, cEditItem As Byte = 1, cDeleteItem As Byte = 2, cSep1Item As Byte = 3, cHistoryItem As Byte = 4

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
        '# Detail
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PCID", "PCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Weight", "Weight", 100, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdItemView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "DCWeight", "Total Berat Diterima", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "OutstandingDeliveryWeight", "Sisa Berat Yang Belum Diterima", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)

        '# Sub Detail
        UI.usForm.SetGrid(grdSubItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "PCID", "PCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "CODetailID", "CODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "CONumber", "Nomor Konfirmasi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "ItemName", "Nama Barang", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "Thick", "Tebal", 70, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "Width", "Lebar", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemView, "Length", "Panjang", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ItemTypeName", "Tipe", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "Quantity", "Quantity", 150, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdSubItemView, "Weight", "Weight", 70, UI.usDefGrid.gReal1Num)
        UI.usForm.SetGrid(grdSubItemView, "TotalWeight", "Total Berat", 250, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdSubItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "TotalPrice", "Total Harga", 250, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdSubItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSubItemView, "LevelItem", "LevelItem", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSubItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "PCID", "PCID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)

        '# Sales Contract
        UI.usForm.SetGrid(grdSalesContractView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSalesContractView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSalesContractView, "ProgramName", "ProgramName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSalesContractView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSalesContractView, "CompanyName", "CompanyName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdSalesContractView, "SCNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSalesContractView, "SCDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdSalesContractView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdSalesContractView, "BPCode", "Kode Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdSalesContractView, "BPName", "Nama Pelanggan", 100, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.TransactionPurchasePurchaseContract), "StatusID", "StatusName")
            UI.usForm.FillComboBox(cboPaymentType, BL.PaymentType.ListDataForCombo("13,14"), "ID", "Name")
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
                clsData = New VO.PurchaseContract
                clsData = BL.PurchaseContract.GetDetail(pubID)
                txtPCNumber.Text = clsData.PCNumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                dtpPCDate.Value = clsData.PCDate
                dtpDeliveryPeriodFrom.EditValue = clsData.DeliveryPeriodFrom
                dtpDeliveryPeriodTo.EditValue = clsData.DeliveryPeriodTo
                txtFranco.Text = clsData.Franco
                txtAllowanceProduction.Text = clsData.AllowanceProduction
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)
                txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
                cboPaymentType.SelectedValue = clsData.PaymentTypeID
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
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pemasok terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf txtFranco.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Syarat penyerahan tidak boleh kosong")
            tcHeader.SelectedTab = tpMain
            txtFranco.Focus()
            Exit Sub
            'ElseIf txtAllowanceProduction.Value <= 0 Then
            '    UI.usForm.frmMessageBox("Allowance produksi harus lebih besar dari 0")
            '    tcHeader.SelectedTab = tpMain
            '    txtAllowanceProduction.Focus()
            '    Exit Sub
        ElseIf dtpDeliveryPeriodFrom.EditValue > dtpDeliveryPeriodTo.EditValue Then
            UI.usForm.frmMessageBox("Periode pengiriman tidak valid")
            tcHeader.SelectedTab = tpMain
            dtpDeliveryPeriodFrom.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpItem
            grdItemView.Focus()
            Exit Sub
            'ElseIf cboPaymentType.SelectedIndex = -1 Then
            '    UI.usForm.frmMessageBox("Pilih jenis pembayaran terlebih dahulu")
            '    tcHeader.SelectedTab = tpMain
            '    cboPaymentType.Focus()
            '    Exit Sub
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


        Dim listDetailOrder As New List(Of VO.PurchaseContractDet)
        For Each dr As DataRow In dtItem.Rows
            listDetailOrder.Add(New ERPSLib.VO.PurchaseContractDet With
                                {
                                    .ID = dr.Item("ID"),
                                    .CODetailID = dr.Item("CODetailID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks"),
                                    .LevelItem = dr.Item("LevelItem"),
                                    .ParentID = dr.Item("ParentID"),
                                    .OrderNumberSupplier = dr.Item("OrderNumberSupplier")
                                })
        Next

        For Each dr As DataRow In dtSubItem.Rows
            listDetailOrder.Add(New ERPSLib.VO.PurchaseContractDet With
                                {
                                    .ID = dr.Item("ID"),
                                    .CODetailID = dr.Item("CODetailID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks"),
                                    .LevelItem = dr.Item("LevelItem"),
                                    .ParentID = dr.Item("ParentID"),
                                    .OrderNumberSupplier = dr.Item("OrderNumberSupplier")
                                })
        Next

        Dim listPaymentTerm As New List(Of VO.PurchaseContractPaymentTerm)
        For Each dr As DataRow In dtPaymentTerm.Rows
            listPaymentTerm.Add(New VO.PurchaseContractPaymentTerm With
                                {
                                    .Percentage = dr.Item("Percentage"),
                                    .PaymentTypeID = dr.Item("PaymentTypeID"),
                                    .PaymentModeID = dr.Item("PaymentModeID"),
                                    .CreditTerm = dr.Item("CreditTerm"),
                                    .Remarks = dr.Item("Remarks")
                                })
        Next

        clsData = New VO.PurchaseContract With {
            .ID = pubID,
            .ProgramID = pubCS.ProgramID,
            .CompanyID = pubCS.CompanyID,
            .PCNumber = txtPCNumber.Text.Trim,
            .PCDate = dtpPCDate.Value.Date,
            .BPID = intBPID,
            .DeliveryPeriodFrom = dtpDeliveryPeriodFrom.EditValue,
            .DeliveryPeriodTo = dtpDeliveryPeriodTo.EditValue,
            .Franco = txtFranco.Text.Trim,
            .AllowanceProduction = txtAllowanceProduction.Value,
            .PPN = txtPPN.Value,
            .PPH = txtPPH.Value,
            .TotalQuantity = grdItemView.Columns("Quantity").SummaryItem.SummaryValue,
            .TotalWeight = grdItemView.Columns("TotalWeight").SummaryItem.SummaryValue,
            .TotalDPP = txtTotalDPP.Value,
            .TotalPPN = txtTotalPPN.Value,
            .TotalPPH = txtTotalPPH.Value,
            .RoundingManual = 0,
            .Remarks = txtRemarks.Text.Trim,
            .StatusID = cboStatus.SelectedValue,
            .Detail = listDetailOrder,
            .PaymentTerm = listPaymentTerm,
            .LogBy = ERPSLib.UI.usUserApp.UserID,
            .IsUseSubItem = IIf(dtSubItem.Rows.Count > 0, True, False),
            .Save = intSave,
            .PaymentTypeID = cboPaymentType.SelectedValue
        }

        pgMain.Value = 60
        Try
            Dim strPCNumber As String = BL.PurchaseContract.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strPCNumber)
            pgMain.Value = 80
            frmParent.pubRefresh(strPCNumber)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryHistory()
                prvSetupTools()
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
        txtBPCode.Focus()
        tcHeader.SelectedTab = tpMain
        pubID = ""
        txtPCNumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        dtpPCDate.Value = Now
        dtpDeliveryPeriodFrom.EditValue = New DateTime(Now.Year, Now.Month, 1)
        dtpDeliveryPeriodTo.EditValue = New DateTime(Now.Year, Now.Month, 1)
        txtAllowanceProduction.Value = 0
        txtFranco.Text = ""
        txtPPN.Value = 0
        txtPPH.Value = 0
        txtTotalDPP.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtGrandTotal.Value = 0
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
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Item
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumDCTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DCWeight", "Total Berat Diterima: {0:#,##0.00}")
        Dim SumOutstandingDCTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutstandingDeliveryWeight", "Total Berat Yang Belum Diterima: {0:#,##0.00}")
        Dim SumGrandTotalPrice As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If

        If grdItemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
        End If

        If grdItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdItemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPrice)
        End If

        If grdItemView.Columns("DCWeight").SummaryText.Trim = "" Then
            grdItemView.Columns("DCWeight").Summary.Add(SumDCTotalWeight)
        End If

        If grdItemView.Columns("OutstandingDeliveryWeight").SummaryText.Trim = "" Then
            grdItemView.Columns("OutstandingDeliveryWeight").Summary.Add(SumOutstandingDCTotalWeight)
        End If

        If grdItemView.GroupCount > 0 Then grdItemView.ExpandAllGroups()
        grdItemView.BestFitColumns(True)

        'For i As Integer = 0 To grdItemView.RowCount - 1
        '    grdItemView.ExpandMasterRow(i, "SubItem")
        'Next

        '# Sub Item
        Dim SumTotalQuantitySubItem As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0}")
        Dim SumGrandTotalWeightSubItem As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumGrandTotalPriceSubItem As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdSubItemView.Columns("Quantity").SummaryText.Trim = "" Then
            grdSubItemView.Columns("Quantity").Summary.Add(SumTotalQuantitySubItem)
        End If

        If grdSubItemView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdSubItemView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightSubItem)
        End If

        If grdSubItemView.Columns("TotalPrice").SummaryText.Trim = "" Then
            grdSubItemView.Columns("TotalPrice").Summary.Add(SumGrandTotalPriceSubItem)
        End If

        grdSubItemView.BestFitColumns(True)
    End Sub

    Private Sub prvCalculate()
        txtTotalDPP.Value = 0
        For Each dr As DataRow In dtItem.Rows
            txtTotalDPP.Value += dr.Item("TotalPrice")
        Next
        txtTotalPPN.Value = txtTotalDPP.Value * (txtPPN.Value / 100)
        txtTotalPPH.Value = txtTotalDPP.Value * (txtPPH.Value / 100)
        txtGrandTotal.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = False
    End Sub

    Private Sub prvSetupTools()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, True, False)
        btnBP.Enabled = bolEnabled
    End Sub

    Private Sub prvUpdateSubItem()
        ToolBar.Focus()
        If Not UI.usForm.frmAskQuestion("Update Subitem?") Then Exit Sub

        Dim listDetailOrder As New List(Of VO.PurchaseContractDet)
        For Each dr As DataRow In dtItem.Rows
            listDetailOrder.Add(New ERPSLib.VO.PurchaseContractDet With
                                {
                                    .ID = dr.Item("ID"),
                                    .CODetailID = dr.Item("CODetailID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks"),
                                    .LevelItem = dr.Item("LevelItem"),
                                    .ParentID = dr.Item("ParentID")
                                })
        Next

        For Each dr As DataRow In dtSubItem.Rows
            listDetailOrder.Add(New ERPSLib.VO.PurchaseContractDet With
                                {
                                    .ID = dr.Item("ID"),
                                    .CODetailID = dr.Item("CODetailID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .Remarks = dr.Item("Remarks"),
                                    .LevelItem = dr.Item("LevelItem"),
                                    .ParentID = dr.Item("ParentID")
                                })
        Next

        clsData = New VO.PurchaseContract With {
            .ID = pubID,
            .ProgramID = pubCS.ProgramID,
            .CompanyID = pubCS.CompanyID,
            .PCNumber = txtPCNumber.Text.Trim,
            .PCDate = dtpPCDate.Value.Date,
            .BPID = intBPID,
            .DeliveryPeriodFrom = dtpDeliveryPeriodFrom.EditValue,
            .DeliveryPeriodTo = dtpDeliveryPeriodTo.EditValue,
            .Franco = txtFranco.Text.Trim,
            .AllowanceProduction = txtAllowanceProduction.Value,
            .PPN = txtPPN.Value,
            .PPH = txtPPH.Value,
            .TotalQuantity = grdItemView.Columns("Quantity").SummaryItem.SummaryValue,
            .TotalWeight = grdItemView.Columns("TotalWeight").SummaryItem.SummaryValue,
            .TotalDPP = txtTotalDPP.Value,
            .TotalPPN = txtTotalPPN.Value,
            .TotalPPH = txtTotalPPH.Value,
            .RoundingManual = 0,
            .Remarks = txtRemarks.Text.Trim,
            .StatusID = cboStatus.SelectedValue,
            .Detail = listDetailOrder,
            .LogBy = ERPSLib.UI.usUserApp.UserID,
            .IsUseSubItem = IIf(dtSubItem.Rows.Count > 0, True, False),
            .PaymentTypeID = cboPaymentType.SelectedValue
        }
        Try
            Dim strPCNumber As String = BL.PurchaseContract.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strPCNumber)
            pgMain.Value = 80
            frmParent.pubRefresh(strPCNumber)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryHistory()
                prvSetupTools()
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

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarItem
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
            .Buttons(cHistoryItem).Enabled = IIf(pubIsNew, False, bolEnabled)
        End With
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            Dim dsMain As New DataSet
            dtItem = BL.PurchaseContract.ListDataDetail(pubID.Trim, "")
            dtSubItem = New DataTable
            If dtItem.Rows.Count = 0 Then dtSubItem = dtItem.Clone
            For Each dr As DataRow In dtItem.Rows
                dtSubItem.Merge(BL.PurchaseContract.ListDataDetail(pubID, dr.Item("ID")))
            Next

            ''# Remap ID using Guid
            'For Each dr As DataRow In dtItem.Rows
            '    Dim strPrevID As String = dr.Item("ID")
            '    Dim strNewID As String = Guid.NewGuid.ToString
            '    For Each drSub As DataRow In dtSubItem.Rows
            '        If drSub.Item("ParentID") = strPrevID Then
            '            drSub.BeginEdit()
            '            drSub.Item("ParentID") = strNewID
            '            drSub.EndEdit()
            '        End If
            '    Next
            '    dtSubItem.AcceptChanges()

            '    dr.BeginEdit()
            '    dr.Item("ID") = strNewID
            '    dr.EndEdit()
            'Next
            'dtItem.AcceptChanges()

            dsMain.Tables.Add(dtItem)
            dsMain.Tables.Add(dtSubItem)
            dsMain.Relations.Add("SubItem", dtItem.Columns.Item("ID"), dtSubItem.Columns.Item("ParentID"))
            grdItem.DataSource = dtItem
            grdItem.LevelTree.Nodes.Add("SubItem", grdSubItemView)
            grdItem.Refresh()
            prvSumGrid()
            prvSetupTools()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvSetButtonItem()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvAddItem()
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Pemasok terlebih dahulu")
            txtBPCode.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraPurchaseContractDetItemVer1
        With frmDetail
            .pubIsNew = True
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubTableParentItem = dtItem
            .pubTableParentSubItem = dtSubItem
            .pubPCID = pubID
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            prvSetupTools()
        End With
    End Sub

    Private Sub prvEditItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraPurchaseContractDetItemVer1
        With frmDetail
            .pubIsNew = False
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .pubTableParentItem = dtItem
            .pubTableParentSubItem = dtSubItem
            .pubPCID = pubID
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            prvSetupTools()
        End With
    End Sub

    Private Sub prvDeleteItem()
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = grdItem.FocusedView
        If view.Name <> "grdItemView" Then Exit Sub
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        For i As Integer = 0 To dtItem.Rows.Count - 1
            If dtItem.Rows(i).Item("ID") = strID Then
                dtItem.Rows(i).Delete()
                Exit For
            End If
        Next
        dtItem.AcceptChanges()
        dtSubItem.AcceptChanges()
        prvCalculate()
        prvSetButtonItem()
        prvSetupTools()

        For i As Integer = 0 To grdItemView.RowCount - 1
            grdItemView.ExpandMasterRow(i, "SubItem")
        Next
    End Sub

    Private Sub prvHistoryItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Try
            Dim frmDetail As New frmViewLookupHistory
            With frmDetail
                .pubDtData = BL.PurchaseContract.ListDataDetailHistorySCItem(grdItemView.GetRowCellValue(intPos, "CODetailID"), False)
                .Text += " Kontrak Penjualan"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            grdStatus.DataSource = BL.PurchaseContract.ListDataStatus(pubID.Trim)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

#End Region

#Region "Sales Contract Handle"

    Private Sub prvQuerySalesContract()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            grdSalesContract.DataSource = BL.SalesContract.ListDataByPurchaseID(pubID.Trim)
            grdSalesContractView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraPurchaseContractDetVer1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpAmount
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.F4 Then
            tcHeader.SelectedTab = tpSalesContract
        ElseIf e.KeyCode = Keys.F5 Then
            tcDetail.SelectedTab = tpItem
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraPurchaseContractDetVer1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItem.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryHistory()
        prvQuerySalesContract()
        prvUserAccess()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarItem.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAddItem()
            Case "Edit" : prvEditItem()
            Case "Hapus" : prvDeleteItem()
            Case "Histori" : prvHistoryItem()
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtPPN.ValueChanged, txtPPH.ValueChanged
        prvCalculate()
    End Sub

#End Region

End Class