Imports DevExpress.XtraGrid
Imports DevExpress.XtraReports.UI

Public Class frmTraSalesContract

    Private intPos As Integer = 0
    Private clsData As New VO.SalesContract
    Private intProgramID As Integer
    Private intCompanyID As Integer
    Private dtData As New DataTable
    Private bolExport As Boolean

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3,
       cSubmit As Byte = 4, cCancelSubmit As Byte = 5, cApprove As Byte = 6, cCancelApprove As Byte = 7,
       cSep2 As Byte = 8, cDownPayment As Byte = 9, cReceive As Byte = 10, cSetupDelivery As Byte = 11,
       cCancelSetupDelivery As Byte = 12, cSep3 As Byte = 13, cPrint As Byte = 14, cExportExcel As Byte = 15,
       cSep4 As Byte = 16, cRefresh As Byte = 17, cClose As Byte = 18

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ProgramName", "ProgramName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyName", "CompanyName", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "SCNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SCDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "BPCode", "Kode Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPName", "Nama Pelanggan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DeliveryPeriodFrom", "Periode Dari", 100, UI.usDefGrid.gDateMonthYear)
        UI.usForm.SetGrid(grdView, "DeliveryPeriodTo", "Periode Sampai", 100, UI.usDefGrid.gDateMonthYear)
        UI.usForm.SetGrid(grdView, "AllowanceProduction", "AllowanceProduction", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "Franco", "Franco", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TotalQuantity", "Total Quantity", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPN", "PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPH", "PPH", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPP", "Total DPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPN", "Total PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPH", "Total PPh", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "GrandTotal", "Grand Total", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "RoundingManual", "RoundingManual", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdView, "DPAmount", "Total Panjar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "ReceiveAmount", "Total Pelunasan", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "OutstandingPayment", "Sisa Piutang", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SubmitBy", "Disubmit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitDate", "Tanggal Disubmit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ApprovedBy", "Diapprove Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ApproveL1", "ApproveL1", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ApprovedDate", "Tanggal Approve", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "IsDeleted", "IsDeleted", 100, UI.usDefGrid.gBoolean, False)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DelegationSeller", "Nama Pihak Penjual", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DelegationPositionSeller", "Posisi Pihak Penjual", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DelegationBuyer", "Nama Pihak Pembeli", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DelegationPositionBuyer", "Posisi Pihak Pembeli", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "StatusID", "StatusID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Dibuat Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Tanggal Buat", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogBy", "Diedit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LogDate", "Tanggal Edit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogInc", "LogInc", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "StatusInfo", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsUseSubItem", "IsUseSubItem", 100, UI.usDefGrid.gBoolean, False)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cDetail).Enabled = bolEnable
            .Item(cDelete).Enabled = bolEnable
            .Item(cSubmit).Enabled = bolEnable
            .Item(cCancelSubmit).Enabled = bolEnable
            .Item(cApprove).Enabled = bolEnable
            .Item(cCancelApprove).Enabled = bolEnable
            .Item(cDownPayment).Enabled = bolEnable
            .Item(cReceive).Enabled = bolEnable
            .Item(cSetupDelivery).Enabled = bolEnable
            .Item(cCancelSetupDelivery).Enabled = bolEnable
            .Item(cPrint).Enabled = bolEnable
            .Item(cExportExcel).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtData As DataTable = BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionSalesContract)
            Dim dr As DataRow
            dr = dtData.NewRow
            With dr
                .BeginEdit()
                .Item("StatusID") = VO.Status.Values.All
                .Item("StatusName") = "SEMUA"
                .EndEdit()
            End With
            dtData.Rows.Add(dr)
            dtData.AcceptChanges()
            dtData.DefaultView.Sort = "StatusID ASC"
            dtData = dtData.DefaultView.ToTable

            UI.usForm.FillComboBox(cboStatus, dtData, "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvDefaultFilter()
        intProgramID = ERPSLib.UI.usUserApp.ProgramID
        intCompanyID = ERPSLib.UI.usUserApp.CompanyID
        txtCompanyName.Text = ERPSLib.UI.usUserApp.CompanyName
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30

        Try
            dtData = BL.SalesContract.ListData(intProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, cboStatus.SelectedValue)
            grdMain.DataSource = dtData
            pgMain.Value = 80

            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvSetButton()
            prvResetProgressBar()
        End Try
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("SCNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "SCNumber", strSearch)
        End With
    End Sub

    Private Function prvGetCS() As VO.CS
        Dim clsCS As New VO.CS
        clsCS.ProgramID = ERPSLib.UI.usUserApp.ProgramID
        clsCS.ProgramName = ERPSLib.UI.usUserApp.ProgramName
        clsCS.CompanyID = intCompanyID
        clsCS.CompanyName = txtCompanyName.Text.Trim
        Return clsCS
    End Function

    Private Function prvGetData() As VO.SalesContract
        Dim clsReturn As New VO.SalesContract
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.ProgramID = grdView.GetRowCellValue(intPos, "ProgramID")
        clsReturn.ProgramName = grdView.GetRowCellValue(intPos, "ProgramName")
        clsReturn.CompanyID = grdView.GetRowCellValue(intPos, "CompanyID")
        clsReturn.CompanyName = grdView.GetRowCellValue(intPos, "CompanyName")
        clsReturn.SCNumber = grdView.GetRowCellValue(intPos, "SCNumber")
        clsReturn.SCDate = grdView.GetRowCellValue(intPos, "SCDate")
        clsReturn.BPID = grdView.GetRowCellValue(intPos, "BPID")
        clsReturn.BPCode = grdView.GetRowCellValue(intPos, "BPCode")
        clsReturn.BPName = grdView.GetRowCellValue(intPos, "BPName")
        clsReturn.DeliveryPeriodFrom = grdView.GetRowCellValue(intPos, "DeliveryPeriodFrom")
        clsReturn.DeliveryPeriodTo = grdView.GetRowCellValue(intPos, "DeliveryPeriodTo")
        clsReturn.AllowanceProduction = grdView.GetRowCellValue(intPos, "AllowanceProduction")
        clsReturn.Franco = grdView.GetRowCellValue(intPos, "Franco")
        clsReturn.TotalQuantity = grdView.GetRowCellValue(intPos, "TotalQuantity")
        clsReturn.TotalWeight = grdView.GetRowCellValue(intPos, "TotalWeight")
        clsReturn.PPN = grdView.GetRowCellValue(intPos, "PPN")
        clsReturn.PPH = grdView.GetRowCellValue(intPos, "PPH")
        clsReturn.TotalDPP = grdView.GetRowCellValue(intPos, "TotalDPP")
        clsReturn.TotalPPN = grdView.GetRowCellValue(intPos, "TotalPPN")
        clsReturn.TotalPPH = grdView.GetRowCellValue(intPos, "TotalPPH")
        clsReturn.GrandTotal = grdView.GetRowCellValue(intPos, "GrandTotal")
        clsReturn.RoundingManual = grdView.GetRowCellValue(intPos, "RoundingManual")
        clsReturn.IsDeleted = grdView.GetRowCellValue(intPos, "IsDeleted")
        clsReturn.Remarks = grdView.GetRowCellValue(intPos, "Remarks")
        clsReturn.DelegationSeller = grdView.GetRowCellValue(intPos, "DelegationSeller")
        clsReturn.DelegationPositionSeller = grdView.GetRowCellValue(intPos, "DelegationPositionSeller")
        clsReturn.DelegationBuyer = grdView.GetRowCellValue(intPos, "DelegationBuyer")
        clsReturn.DelegationPositionBuyer = grdView.GetRowCellValue(intPos, "DelegationPositionBuyer")
        clsReturn.StatusID = grdView.GetRowCellValue(intPos, "StatusID")
        clsReturn.CreatedBy = grdView.GetRowCellValue(intPos, "CreatedBy")
        clsReturn.CreatedDate = grdView.GetRowCellValue(intPos, "CreatedDate")
        clsReturn.LogBy = grdView.GetRowCellValue(intPos, "LogBy")
        clsReturn.LogDate = grdView.GetRowCellValue(intPos, "LogDate")
        clsReturn.LogInc = grdView.GetRowCellValue(intPos, "LogInc")
        clsReturn.StatusInfo = grdView.GetRowCellValue(intPos, "StatusInfo")
        clsReturn.IsUseSubItem = grdView.GetRowCellValue(intPos, "IsUseSubItem")
        Return clsReturn
    End Function

    Private Sub prvNew()
        prvResetProgressBar()
        Dim frmDetail As New frmTraSalesContractDetVer2
        With frmDetail
            .pubIsNew = True
            .pubCS = prvGetCS()
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        prvResetProgressBar()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraSalesContractDetVer2
        With frmDetail
            .pubIsNew = False
            .pubCS = prvGetCS()
            .pubID = clsData.ID
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Hapus Nomor " & clsData.SCNumber & "?") Then Exit Sub

        Dim frmDetail As New usFormRemarks
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.Remarks = .pubValue
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.SalesContract.DeleteData(clsData.ID, clsData.Remarks)
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "SCNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Submit Nomor " & clsData.SCNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.SalesContract.Submit(clsData.ID, "")
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "SCNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvCancelSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Batal Submit Nomor " & clsData.SCNumber & "?") Then Exit Sub

        Dim frmDetail As New usFormRemarks
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.Remarks = .pubValue
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.SalesContract.Unsubmit(clsData.ID, clsData.Remarks)
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Batal submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "SCNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvApprove()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Approve Nomor " & clsData.SCNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.SalesContract.Approve(clsData.ID, "")
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "SCNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvCancelApprove()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Batal Approve Nomor " & clsData.SCNumber & "?") Then Exit Sub

        Dim frmDetail As New usFormRemarks
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.Remarks = .pubValue
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.SalesContract.Unapprove(clsData.ID, clsData.Remarks)
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Batal approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "SCNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvDownPayment()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        If clsData.StatusID <> VO.Status.Values.Approved Then
            UI.usForm.frmMessageBox("Status Data harus disetujui terlebih dahulu")
            Exit Sub
        End If

        Dim frmDetail As New frmTraARAP
        With frmDetail
            .pubModules = VO.AccountReceivable.DownPayment
            .pubARAPType = VO.ARAP.ARAPTypeValue.Sales
            .pubBPID = clsData.BPID
            .pubCS = prvGetCS()
            .pubReferencesID = clsData.ID
            .pubIsUseSubItem = clsData.IsUseSubItem
            .pubPPNPercentage = clsData.PPN
            .pubPPHPercentage = clsData.PPH
            .ShowDialog()
        End With
    End Sub

    Private Sub prvReceivePayment()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        If clsData.StatusID <> VO.Status.Values.Approved Then
            UI.usForm.frmMessageBox("Status Data harus disetujui terlebih dahulu")
            Exit Sub
        End If

        Dim frmDetail As New frmTraARAP
        With frmDetail
            .pubModules = VO.AccountReceivable.ReceivePayment
            .pubARAPType = VO.ARAP.ARAPTypeValue.Sales
            .pubBPID = clsData.BPID
            .pubBPCode = clsData.BPCode
            .pubBPName = clsData.BPName
            .pubCS = prvGetCS()
            .pubReferencesID = clsData.ID
            .pubReferencesNumber = clsData.SCNumber
            .pubPPNPercentage = clsData.PPN
            .pubPPHPercentage = clsData.PPH
            .ShowDialog()
        End With
    End Sub

    Private Sub prvSetupDelivery(ByVal bolValue As Boolean)
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion(IIf(bolValue = False, "Batal ", "") & "Set Pengiriman Nomor " & clsData.SCNumber & "?") Then Exit Sub

        Dim frmDetail As New usFormRemarks
        With frmDetail
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.Remarks = .pubValue
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.SalesContract.SetupIsIgnoreValidationPayment(clsData.ID, bolValue, clsData.Remarks)
            pgMain.Value = 100
            UI.usForm.frmMessageBox(IIf(bolValue = False, "Batal ", "") & "Set Pengiriman Nomor berhasil.")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvPrint()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim enumPrintType As VO.SalesContract.PrintType = VO.SalesContract.PrintType.None
        Using frmDetail As New frmTraSalesContractPrint
            frmDetail.pubID = clsData.ID
            frmDetail.StartPosition = FormStartPosition.CenterParent
            frmDetail.ShowDialog()
            If frmDetail.pubType = VO.SalesContract.PrintType.None Then Exit Sub
            enumPrintType = frmDetail.pubType
            clsData.AdditionalTerm1 = frmDetail.pubAdditionalTerm1
            clsData.AdditionalTerm2 = frmDetail.pubAdditionalTerm2
            clsData.AdditionalTerm3 = frmDetail.pubAdditionalTerm3
            clsData.AdditionalTerm4 = frmDetail.pubAdditionalTerm4
            clsData.AdditionalTerm5 = frmDetail.pubAdditionalTerm5
            clsData.AdditionalTerm6 = frmDetail.pubAdditionalTerm6
            clsData.AdditionalTerm7 = frmDetail.pubAdditionalTerm7
            clsData.AdditionalTerm8 = frmDetail.pubAdditionalTerm8
            clsData.AdditionalTerm9 = frmDetail.pubAdditionalTerm9
            clsData.AdditionalTerm10 = frmDetail.pubAdditionalTerm10

            Try
                BL.SalesContract.UpdateAdditinalTerm(clsData)
            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message)
            End Try
        End Using
        prvPrintSCCO()
        prvPrintSC(enumPrintType)
    End Sub

    Private Sub prvPrintSC(ByVal enumPrintType As VO.SalesContract.PrintType)
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdView.GetRowCellValue(intPos, "ID")
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            Dim crReport As New rptSalesContractVer00
            Dim dtData As DataTable = BL.SalesContract.PrintVer00(intProgramID, intCompanyID, strID)
            Dim intStatusID As Integer = 0
            Dim intCountTerm As Integer = 6
            Dim strUomInitial As String = "PCS"
            For Each dr As DataRow In dtData.Rows
                intStatusID = dr.Item("StatusID")
                strUomInitial = dr.Item("UomInitial")
                If dr.Item("AdditionalTerm1") <> "" Then crReport.shAdditionalTerm1.Visible = True : crReport.paramCountAdditionalTerm1.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm2") <> "" Then crReport.shAdditionalTerm2.Visible = True : crReport.paramCountAdditionalTerm2.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm3") <> "" Then crReport.shAdditionalTerm3.Visible = True : crReport.paramCountAdditionalTerm3.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm4") <> "" Then crReport.shAdditionalTerm4.Visible = True : crReport.paramCountAdditionalTerm4.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm5") <> "" Then crReport.shAdditionalTerm5.Visible = True : crReport.paramCountAdditionalTerm5.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm6") <> "" Then crReport.shAdditionalTerm6.Visible = True : crReport.paramCountAdditionalTerm6.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm7") <> "" Then crReport.shAdditionalTerm7.Visible = True : crReport.paramCountAdditionalTerm7.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm8") <> "" Then crReport.shAdditionalTerm8.Visible = True : crReport.paramCountAdditionalTerm8.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm9") <> "" Then crReport.shAdditionalTerm9.Visible = True : crReport.paramCountAdditionalTerm9.Value = intCountTerm & ")" : intCountTerm += 1
                If dr.Item("AdditionalTerm10") <> "" Then crReport.shAdditionalTerm10.Visible = True : crReport.paramCountAdditionalTerm10.Value = intCountTerm & ")" : intCountTerm += 1
                Exit For
            Next

            crReport.PaperKind = System.Drawing.Printing.PaperKind.Legal

            '# Setup Watermark Report
            If intStatusID <> VO.Status.Values.Approved Then
                crReport.Watermark.Text = "DRAFT" & vbCrLf & "NOT OFFICIAL"
                crReport.Watermark.ForeColor = System.Drawing.Color.DimGray
                crReport.Watermark.Font = New System.Drawing.Font("Tahoma", 70.0!, System.Drawing.FontStyle.Bold)
                crReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal
                crReport.Watermark.TextTransparency = 150
            End If

            '# Report Section Handle
            crReport.shTerm4SKBDN.Visible = IIf(enumPrintType = VO.SalesContract.PrintType.SKBDN, True, False)
            crReport.paramCountTerm4_0.Value = intCountTerm & ")"
            crReport.paramCountTerm4_1.Value = intCountTerm + 1 & ")"
            crReport.paramCountTerm4_2.Value = intCountTerm + 2 & ")"
            '# --------------------------------------------------------
            crReport.paramUom.Value = strUomInitial.Trim
            crReport.DataSource = dtData
            crReport.CreateDocument(True)
            crReport.ShowPreviewMarginLines = False
            crReport.ShowPrintMarginsWarning = False

            Dim frmDetail As New frmReportPreview
            With frmDetail
                .docViewer.DocumentSource = crReport
                .pgExportButton.Enabled = bolExport
                .Text = Me.Text & " - " & VO.Reports.PrintOut
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvPrintSCCO()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdView.GetRowCellValue(intPos, "ID")
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40


        Try
            Dim dtData As DataTable = BL.SalesContract.PrintSCCOVer00(intProgramID, intCompanyID, strID)
            Dim intStatusID As Integer = 0
            Dim strUomInitial As String = "LBR"
            For Each dr As DataRow In dtData.Rows
                intStatusID = dr.Item("StatusID")
                strUomInitial = dr.Item("UomInitial")
                Exit For
            Next

            Dim crReport As New rptConfirmationOrderVer00
            crReport.PaperKind = System.Drawing.Printing.PaperKind.Legal

            '# Setup Watermark Report
            If intStatusID <> VO.Status.Values.Approved Then
                crReport.Watermark.Text = "DRAFT" & vbCrLf & "NOT OFFICIAL"
                crReport.Watermark.ForeColor = System.Drawing.Color.DimGray
                crReport.Watermark.Font = New System.Drawing.Font("Tahoma", 70.0!, System.Drawing.FontStyle.Bold)
                crReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal
                crReport.Watermark.TextTransparency = 150
            End If

            crReport.paramUom.Value = strUomInitial.Trim
            crReport.DataSource = dtData
            crReport.CreateDocument(True)
            crReport.ShowPreviewMarginLines = False
            crReport.ShowPrintMarginsWarning = False

            If strUomInitial = "QTY" Then
                'crReport.CellHeaderWeighLbr.Text = ""
                'crReport.CellHeaderWeighLbr.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
                'crReport.CellDetailWeighLbr.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)

                crReport.ghColumnName.Visible = False
                crReport.sbDetail.Visible = False
                crReport.ghColumnNameCoil.Visible = True
                crReport.sbDetailCoil.Visible = True
            Else
                crReport.ghColumnName.Visible = True
                crReport.sbDetail.Visible = True
                crReport.ghColumnNameCoil.Visible = False
                crReport.sbDetailCoil.Visible = False
            End If

            Dim frmDetail As New frmReportPreview
            With frmDetail
                .docViewer.DocumentSource = crReport
                .pgExportButton.Enabled = bolExport
                .Text = Me.Text & " - " & VO.Reports.PrintOut
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvExportExcel()
        Dim dxExporter As New DX.usDXHelper
        dxExporter.DevExport(Me, grdMain, Me.Text, Me.Text, DX.usDxExportFormat.fXls, True, True, DX.usDXExportType.etDefault)
    End Sub

    Private Sub prvClear()
        grdMain.DataSource = Nothing
        grdView.Columns.Clear()
        prvSetGrid()
        prvSetButton()
    End Sub

    Private Sub prvChooseCompany()
        Dim frmDetail As New frmViewCompany
        With frmDetail
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                intCompanyID = .pubLUdtRow.Item("CompanyID")
                txtCompanyName.Text = .pubLUdtRow.Item("CompanyName")
                prvClear()
                btnExecute.Focus()
            End If
        End With
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalQuantity", "Total Quantity: {0:#,##0.00}")
        Dim SumTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat: {0:#,##0.00}")
        Dim SumTotalDPP As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPP", "Total DPP: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPN", "Total PPN: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPH", "Total PPh: {0:#,##0.00}")
        Dim SumGrandTotal As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", "Grand Total: {0:#,##0.00}")
        Dim SumDPAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DPAmount", "Total Panjar: {0:#,##0.00}")
        Dim SumReceiveAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ReceiveAmount", "Total Pembayaran: {0:#,##0.00}")
        Dim SumOutstandingPayment As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutstandingPayment", "Sisa Hutang: {0:#,##0.00}")

        If grdView.Columns("TotalQuantity").SummaryText.Trim = "" Then
            grdView.Columns("TotalQuantity").Summary.Add(SumTotalQuantity)
        End If

        If grdView.Columns("TotalWeight").SummaryText.Trim = "" Then
            grdView.Columns("TotalWeight").Summary.Add(SumTotalWeight)
        End If

        If grdView.Columns("TotalDPP").SummaryText.Trim = "" Then
            grdView.Columns("TotalDPP").Summary.Add(SumTotalDPP)
        End If

        If grdView.Columns("TotalPPN").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPN").Summary.Add(SumTotalPPN)
        End If

        If grdView.Columns("TotalPPH").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPH").Summary.Add(SumTotalPPH)
        End If

        If grdView.Columns("GrandTotal").SummaryText.Trim = "" Then
            grdView.Columns("GrandTotal").Summary.Add(SumGrandTotal)
        End If

        If grdView.Columns("DPAmount").SummaryText.Trim = "" Then
            grdView.Columns("DPAmount").Summary.Add(SumDPAmount)
        End If

        If grdView.Columns("ReceiveAmount").SummaryText.Trim = "" Then
            grdView.Columns("ReceiveAmount").Summary.Add(SumReceiveAmount)
        End If

        If grdView.Columns("OutstandingPayment").SummaryText.Trim = "" Then
            grdView.Columns("OutstandingPayment").Summary.Add(SumOutstandingPayment)
        End If
        grdView.BestFitColumns()
    End Sub

    Private Sub prvUserAccess()
        With ToolBar.Buttons
            .Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.NewAccess)
            .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.DeleteAccess)
            .Item(cSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.SubmitAccess)
            .Item(cCancelSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.CancelSubmitAccess)
            .Item(cApprove).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.ApproveAccess)
            .Item(cCancelApprove).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.CancelApproveAccess)
            .Item(cSetupDelivery).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.SetupDelivery)
            .Item(cCancelSetupDelivery).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.CancelSetupDelivery)
            .Item(cPrint).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.PrintReportAccess)
            .Item(cExportExcel).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.ExportExcelAccess)
            bolExport = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionSalesContract, VO.Access.Values.ExportReportAccess)
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContract_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraSalesContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvFillCombo()
        prvSetGrid()
        cboStatus.SelectedValue = VO.Status.Values.All
        dtpDateFrom.Value = Today.Date.AddDays(-7)
        dtpDateTo.Value = Today.Date
        prvDefaultFilter()
        prvQuery()
        prvUserAccess()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cNew).Name Then
            prvNew()
        ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cDetail).Name : prvDetail()
                Case ToolBar.Buttons(cDelete).Name : prvDelete()
                Case ToolBar.Buttons(cSubmit).Name : prvSubmit()
                Case ToolBar.Buttons(cCancelSubmit).Name : prvCancelSubmit()
                Case ToolBar.Buttons(cApprove).Name : prvApprove()
                Case ToolBar.Buttons(cCancelApprove).Name : prvCancelApprove()
                Case ToolBar.Buttons(cDownPayment).Name : prvDownPayment()
                Case ToolBar.Buttons(cReceive).Name : prvReceivePayment()
                Case ToolBar.Buttons(cSetupDelivery).Name : prvSetupDelivery(True)
                Case ToolBar.Buttons(cCancelSetupDelivery).Name : prvSetupDelivery(False)
                Case ToolBar.Buttons(cPrint).Name : prvPrint()
                Case ToolBar.Buttons(cExportExcel).Name : prvExportExcel()
            End Select
        End If
    End Sub

    Private Sub btnCompany_Click(sender As Object, e As EventArgs) Handles btnCompany.Click
        prvChooseCompany()
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        prvClear()
    End Sub

    Private Sub grdView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim bolIsDeleted As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("IsDeleted"))
            If bolIsDeleted = "Checked" And e.Appearance.BackColor <> Color.Salmon Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

#End Region

End Class