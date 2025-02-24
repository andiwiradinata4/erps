Imports DevExpress.XtraGrid
Public Class frmTraCuttingDet

#Region "Property"

    Private frmParent As frmTraCutting
    Private clsData As VO.Cutting
    Private intBPID As Integer = 0
    Private dtItem As New DataTable
    Private dtItemResult As New DataTable
    Private intPos As Integer = 0
    Private strPOID As String = ""
    Private intCoAIDofStock As Integer = 0
    Private intCustomerID As Integer
    Property pubID As String = ""
    Property pubIsNew As Boolean = False
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1, _
       cAddItem As Byte = 0, cEditItem As Byte = 1, cDeleteItem As Byte = 2

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
        '# Cutting Detail
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "CuttingID", "CuttingID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "PODetailID", "PODetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        'UI.usForm.SetGrid(grdItemView, "PONumber", "Nomor Pesanan", 100, UI.usDefGrid.gString)
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
        UI.usForm.SetGrid(grdItemView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "UnitPriceClaim", "Harga Customer", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPriceClaim", "Total Harga Customer", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "UnitPriceRawMaterial", "HPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "TotalPriceRawMaterial", "Total HPP", 100, UI.usDefGrid.gReal2Num)

        '# Cutting Detail Result
        UI.usForm.SetGrid(grdItemResultView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "CuttingID", "CuttingID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "OrderNumberSupplier", "OrderNumberSupplier", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "PODetailResultID", "PODetailResultID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemResultView, "GroupID", "Group ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemResultView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemResultView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemResultView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdItemResultView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemResultView, "UnitPriceHPP", "HPP", 300, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemResultView, "TotalPriceHPP", "Total HPP", 300, UI.usDefGrid.gReal2Num)
        grdItemResultView.Columns("GroupID").GroupIndex = 0

        '# History
        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "CuttingID", "CuttingID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionCuttingProcess), "StatusID", "StatusName")
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
                clsData = New VO.Cutting
                clsData = BL.Cutting.GetDetail(pubID)
                txtCuttingNumber.Text = clsData.CuttingNumber
                intBPID = clsData.BPID
                txtBPCode.Text = clsData.BPCode
                txtBPName.Text = clsData.BPName
                dtpCuttingDate.Value = clsData.CuttingDate
                strPOID = clsData.POID
                txtPONumber.Text = clsData.PONumber
                txtReferencesNumber.Text = clsData.ReferencesNumber
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                intCoAIDofStock = clsData.CoAIDofStock
                txtCoACodeOfStock.Text = clsData.CoACodeofStock
                txtCoANameOfStock.Text = clsData.CoANameofStock
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                intCustomerID = clsData.CustomerID
                txtCustomerCode.Text = clsData.CustomerCode
                txtCustomerName.Text = clsData.CustomerName

                dtpPickupDate.Value = clsData.PickupDate
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
        ElseIf txtCustomerCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCustomerCode.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            tcHeader.SelectedTab = tpMain
            cboStatus.Focus()
            Exit Sub
        ElseIf intCoAIDofStock = 0 Then
            UI.usForm.frmMessageBox("Pilih akun persediaan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCoACodeOfStock.Focus()
            Exit Sub
        ElseIf grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpItem
            grdItemView.Focus()
            Exit Sub
        ElseIf grdItemResultView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item kosong. Mohon untuk diinput item terlebih dahulu")
            tcDetail.SelectedTab = tpItemResult
            grdItemResultView.Focus()
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


        Dim listDetail As New List(Of VO.CuttingDet)
        For Each dr As DataRow In dtItem.Rows
            listDetail.Add(New ERPSLib.VO.CuttingDet With
                           {
                               .PODetailID = dr.Item("PODetailID"),
                               .GroupID = dr.Item("GroupID"),
                               .ItemID = dr.Item("ItemID"),
                               .Quantity = dr.Item("Quantity"),
                               .Weight = dr.Item("Weight"),
                               .TotalWeight = dr.Item("TotalWeight"),
                               .UnitPrice = dr.Item("UnitPrice"),
                               .TotalPrice = dr.Item("TotalPrice"),
                               .Remarks = dr.Item("Remarks"),
                               .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                               .UnitPriceRawMaterial = dr.Item("UnitPriceRawMaterial"),
                               .TotalPriceRawMaterial = dr.Item("TotalPriceRawMaterial"),
                               .UnitPriceClaim = dr.Item("UnitPriceClaim"),
                               .TotalPriceClaim = dr.Item("TotalPriceClaim")
                           })
        Next

        Dim listDetailResult As New List(Of VO.CuttingDetResult)
        For Each dr As DataRow In dtItemResult.Rows
            listDetailResult.Add(New ERPSLib.VO.CuttingDetResult With
                                {
                                    .GroupID = dr.Item("GroupID"),
                                    .ItemID = dr.Item("ItemID"),
                                    .Quantity = dr.Item("Quantity"),
                                    .Weight = dr.Item("Weight"),
                                    .TotalWeight = dr.Item("TotalWeight"),
                                    .Remarks = dr.Item("Remarks"),
                                    .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                                    .PODetailResultID = dr.Item("PODetailResultID"),
                                    .UnitPriceHPP = dr.Item("UnitPriceHPP"),
                                    .TotalPriceHPP = dr.Item("TotalPriceHPP"),
                                    .UnitPrice = dr.Item("UnitPrice"),
                                    .TotalPrice = dr.Item("TotalPrice"),
                                    .UnitPriceClaim = dr.Item("UnitPriceClaim"),
                                    .TotalPriceClaim = dr.Item("TotalPriceClaim")
                                })
        Next

        clsData = New VO.Cutting
        clsData.ID = pubID
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.CuttingNumber = txtCuttingNumber.Text.Trim
        clsData.CuttingDate = dtpCuttingDate.Value.Date
        clsData.BPID = intBPID
        clsData.ReferencesNumber = txtReferencesNumber.Text.Trim
        clsData.PPN = txtPPN.Value
        clsData.PPH = txtPPH.Value
        clsData.TotalQuantity = grdItemView.Columns("Quantity").SummaryItem.SummaryValue
        clsData.TotalWeight = grdItemView.Columns("TotalWeight").SummaryItem.SummaryValue
        clsData.TotalDPP = txtTotalDPP.Value
        clsData.TotalPPN = txtTotalPPN.Value
        clsData.TotalPPH = txtTotalPPH.Value
        clsData.RoundingManual = 0
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.POID = strPOID
        clsData.PONumber = txtPONumber.Text.Trim
        clsData.CoAIDofStock = intCoAIDofStock
        clsData.Detail = listDetail
        clsData.DetailResult = listDetailResult
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Save = intSave
        clsData.CustomerID = intCustomerID
        clsData.PickupDate = dtpPickupDate.Value.Date

        pgMain.Value = 60
        Try
            Dim strCuttingNumber As String = BL.Cutting.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strCuttingNumber)
            pgMain.Value = 80

            frmParent.pubRefresh(strCuttingNumber)
            If pubIsNew Then
                prvClear()
                prvQueryItem()
                prvQueryItemResult()
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
        txtCuttingNumber.Text = ""
        intBPID = 0
        txtBPCode.Text = ""
        txtBPName.Text = ""
        dtpCuttingDate.Value = Now
        strPOID = ""
        txtPONumber.Text = ""
        txtReferencesNumber.Text = ""
        txtPPN.Value = 0
        txtPPH.Value = 0
        txtTotalDPP.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtGrandTotal.Value = 0
        txtRemarks.Text = ""
        intCoAIDofStock = 0
        txtCoACodeOfStock.Text = ""
        txtCoANameOfStock.Text = ""
        cboStatus.SelectedValue = VO.Status.Values.Draft
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
        intCustomerID = 0
        txtCustomerCode.Text = ""
        txtCustomerName.Text = ""
        dtpPickupDate.Value = Now
    End Sub

    Private Sub prvChooseBP()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If intBPID <> .pubLUdtRow.Item("ID") Then
                    strPOID = ""
                    txtPONumber.Text = ""
                    prvClearItem()
                End If

                intBPID = .pubLUdtRow.Item("ID")
                txtBPCode.Text = .pubLUdtRow.Item("Code")
                txtBPName.Text = .pubLUdtRow.Item("Name")
                intCoAIDofStock = .pubLUdtRow.Item("CoAIDofStock")
                txtCoACodeOfStock.Text = .pubLUdtRow.Item("CoACodeofStock")
                txtCoANameOfStock.Text = .pubLUdtRow.Item("CoANameofStock")
            End If
        End With
    End Sub

    Private Sub prvChooseCustomer()
        Dim frmDetail As New frmMstBusinessPartner
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCustomerID = .pubLUdtRow.Item("ID")
                txtCustomerCode.Text = .pubLUdtRow.Item("Code")
                txtCustomerName.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Item
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
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
        grdItemView.BestFitColumns()

        '# Item Result
        Dim SumTotalQuantityResult As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeightResult As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")

        If grdItemResultView.Columns("Quantity").SummaryText.Trim = "" Then
            grdItemResultView.Columns("Quantity").Summary.Add(SumTotalQuantityResult)
        End If

        If grdItemResultView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdItemResultView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeightResult)
        End If
        grdItemResultView.BestFitColumns()
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
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCuttingProcess, IIf(pubIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
    End Sub

    Private Sub prvSetupTools()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, True, False)
        btnBP.Enabled = bolEnabled
        grdItemResultView.ExpandAllGroups()
    End Sub

    Private Sub prvChoosePO()
        If intBPID = 0 Or txtBPCode.Text.Trim = "" Or txtBPName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Pemasok terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf intCustomerID = 0 Or txtCustomerCode.Text.Trim = "" Or txtCustomerCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCustomerCode.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraCuttingDetOutstandingPO
        With frmDetail
            .pubBPID = intBPID
            .pubCustomerID = intCustomerID
            .pubCS = pubCS
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If strPOID.Trim <> .pubLUdtRow.Item("ID") Then
                    prvClearItem()
                    Dim clsPO As VO.PurchaseOrderCutting = BL.PurchaseOrderCutting.GetDetail(.pubLUdtRow.Item("ID"))
                    txtPPN.Value = clsPO.PPN
                    txtPPH.Value = clsPO.PPH
                End If
                strPOID = .pubLUdtRow.Item("ID")
                txtPONumber.Text = .pubLUdtRow.Item("PONumber")
            End If
        End With
    End Sub

#Region "Item Handle"

    Private Sub prvSetButtonItem()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarItem
            .Buttons(cEditItem).Enabled = bolEnabled
            .Buttons(cDeleteItem).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvClearItem()
        dtItem.Clear()
        dtItem.AcceptChanges()
        grdItem.DataSource = dtItem

        dtItemResult.Clear()
        dtItemResult.AcceptChanges()
        grdItemResult.DataSource = dtItemResult
        prvCalculate()
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Try
            dtItem = BL.Cutting.ListDataDetail(pubID.Trim)
            grdItem.DataSource = dtItem
            prvSumGrid()
            grdItemView.BestFitColumns()
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
            UI.usForm.frmMessageBox("Pilih Cutting Center terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf txtCustomerCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCustomerCode.Focus()
            Exit Sub
        ElseIf strPOID.Trim = "" Or txtPONumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Nomor SPK terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtPONumber.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmTraCuttingDetItem
        With frmDetail
            .pubIsNew = True
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubTableItem = dtItem
            .pubTableItemResultParent = dtItemResult
            .pubPOID = strPOID
            .pubIsAutoSearch = True
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            prvSetupTools()
        End With
    End Sub

    Private Sub prvEditItem()
        If txtBPCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Cutting Center terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtBPCode.Focus()
            Exit Sub
        ElseIf txtCustomerCode.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Pelanggan terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtCustomerCode.Focus()
            Exit Sub
        ElseIf strPOID.Trim = "" Or txtPONumber.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih Nomor SPK terlebih dahulu")
            tcHeader.SelectedTab = tpMain
            txtPONumber.Focus()
            Exit Sub
        End If
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraCuttingDetItem
        With frmDetail
            .pubIsNew = False
            .pubCS = pubCS
            .pubBPID = intBPID
            .pubTableItem = dtItem
            .pubTableItemResultParent = dtItemResult
            .pubDataRowSelected = grdItemView.GetDataRow(intPos)
            .pubPOID = strPOID
            .StartPosition = FormStartPosition.CenterParent
            .pubShowDialog(Me)
            prvSetButtonItem()
            prvCalculate()
            prvSetupTools()
        End With
    End Sub

    Private Sub prvDeleteItem()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdItemView.GetRowCellValue(intPos, "ID")
        Dim intGroupID As Integer = grdItemView.GetRowCellValue(intPos, "GroupID")

        '# Delete Item
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("ID") = strID Then dr.Delete() : Exit For
        Next
        dtItem.AcceptChanges()
        prvCalculate()

        '# Delete Item Result
        For Each dr As DataRow In dtItemResult.Rows
            If dr.Item("GroupID") = intGroupID Then dr.Delete()
        Next
        dtItemResult.AcceptChanges()

        '# Update Group ID Item
        For Each dr As DataRow In dtItem.Rows
            If dr.Item("GroupID") > intGroupID Then
                dr.BeginEdit()
                dr.Item("GroupID") = dr.Item("GroupID") - 1
                dr.EndEdit()
            End If
        Next
        dtItem.AcceptChanges()

        '# Update Group ID Result
        For Each dr As DataRow In dtItemResult.Rows
            If dr.Item("GroupID") > intGroupID Then
                dr.BeginEdit()
                dr.Item("GroupID") = dr.Item("GroupID") - 1
                dr.EndEdit()
            End If
        Next
        dtItemResult.AcceptChanges()
        prvSetButtonItem()
        prvSetupTools()
    End Sub

#End Region

#Region "Item Result Handle"

    Private Sub prvQueryItemResult()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtItemResult = BL.Cutting.ListDataDetailResult(pubID.Trim)
            grdItemResult.DataSource = dtItemResult
            prvSumGrid()
            grdItemView.BestFitColumns()
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

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            grdStatus.DataSource = BL.Cutting.ListDataStatus(pubID.Trim)
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

    Private Sub frmTraCuttingDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            tcHeader.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcHeader.SelectedTab = tpPrice
        ElseIf e.KeyCode = Keys.F3 Then
            tcHeader.SelectedTab = tpHistory
        ElseIf e.KeyCode = Keys.F4 Then
            tcDetail.SelectedTab = tpItem
        ElseIf e.KeyCode = Keys.F5 Then
            tcDetail.SelectedTab = tpItemResult
        ElseIf e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraCuttingDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarItem.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryItemResult()
        prvQueryHistory()
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
        End Select
    End Sub

    Private Sub btnBP_Click(sender As Object, e As EventArgs) Handles btnBP.Click
        prvChooseBP()
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        prvChooseCustomer()
    End Sub

    Private Sub btnPurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnPurchaseOrder.Click
        prvChoosePO()
    End Sub

    Private Sub txtPrice_ValueChanged(sender As Object, e As EventArgs) Handles txtPPN.ValueChanged, txtPPH.ValueChanged
        prvCalculate()
    End Sub

    Private Sub btnCoAOfStock_Click(sender As Object, e As EventArgs) Handles btnCoAOfStock.Click
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = pubCS.CompanyID
            .pubProgramID = pubCS.ProgramID
            .pubFilterGroup = VO.ChartOfAccount.FilterGroup.Stock
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCoAIDofStock = .pubLUdtRow.Item("ID")
                txtCoACodeOfStock.Text = .pubLUdtRow.Item("Code")
                txtCoANameOfStock.Text = .pubLUdtRow.Item("Name")
            End If
        End With
    End Sub

#End Region

End Class