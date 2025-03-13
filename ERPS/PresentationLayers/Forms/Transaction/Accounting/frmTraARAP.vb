Imports DevExpress.XtraGrid
Public Class frmTraARAP

#Region "Property"

    Private intPos As Integer = 0
    Private clsData As New VO.ARAP
    Private intCompanyID As Integer
    Private dtData As New DataTable
    Private strModules As String = ""
    Private enumARAPType As VO.ARAP.ARAPTypeValue
    Private intBPID As Integer = 0,
        strBPCode As String = "", strBPName As String = ""
    Private clsCS As New VO.CS
    Private strReferencesID As String = "",
        strReferencesNumber As String = ""
    Private bolExport As Boolean = True
    Private bolIsLookup As Boolean = False
    Private bolIsUseSubItem As Boolean = False
    Private intPaymentTypeID As Integer = 0
    Private decPPNPercentage As Decimal = 0
    Private decPPHPercentage As Decimal = 0
    Private bolIsControlARAP As Boolean = False
    Private intIsGenerate As Integer = -1

    Public WriteOnly Property pubModules As String
        Set(value As String)
            strModules = value
        End Set
    End Property

    Public WriteOnly Property pubARAPType As VO.ARAP.ARAPTypeValue
        Set(value As VO.ARAP.ARAPTypeValue)
            enumARAPType = value
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

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
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

    Public WriteOnly Property pubPaymentTypeID As Integer
        Set(value As Integer)
            intPaymentTypeID = value
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

    Public WriteOnly Property pubIsControlARAP As Boolean
        Set(value As Boolean)
            bolIsControlARAP = value
        End Set
    End Property

    Public WriteOnly Property pubIsGenerate As Integer
        Set(value As Integer)
            intIsGenerate = value
        End Set
    End Property

#End Region

    Private Const _
       cImport As Byte = 0, cNew As Byte = 1, cDetail As Byte = 2, cDelete As Byte = 3, cSep1 As Byte = 4,
       cSubmit As Byte = 5, cCancelSubmit As Byte = 6, cApprove As Byte = 7, cCancelApprove As Byte = 8,
       cSep2 As Byte = 9, cSetPaymentDate As Byte = 10, cDeletePaymentDate As Byte = 11, cSetTaxInvoiceNumber As Byte = 12,
       cSetInvoiceNumberBP As Byte = 13, cInvoice As Byte = 14, cExtendDueDate As Byte = 15, cSep3 As Byte = 16, cPrintPI As Byte = 17,
       cPrintInvoice As Byte = 18, cPrintPaymentBank As Byte = 19, cExportExcel As Byte = 20, cSep4 As Byte = 21, cRefresh As Byte = 22, cClose As Byte = 23

    Private Sub prvResetProgressBar()
        pgMain.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "Pick", "Pilih", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ProgramID", "ProgramID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ProgramName", "Program", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CompanyID", "CompanyID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyName", "Perusahaan", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ID", "Nomor", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "TransNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TransDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "BPID", "BPID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "BPCode", "Kode Rekan Bisnis", 100, UI.usDefGrid.gString, bolIsControlARAP)
        UI.usForm.SetGrid(grdView, "BPName", "Nama Rekan Bisnis", 100, UI.usDefGrid.gString, bolIsControlARAP)
        UI.usForm.SetGrid(grdView, "DueDateValue", "Jatuh Tempo", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "DueDate", "Tanggal Jatuh Tempo", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "DueDateVSNowValue", "Jatuh Tempo", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "CoAID", "ID Akun", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CoACode", "Kode Akun", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "CoAName", "Nama Akun", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "Modules", "Modules", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ReferencesID", "No. Referensi", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ReferencesNote", "Referensi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ReferencesNumber", "Purchase Number", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TotalAmount", "Total DPP", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPN", "Total PPN", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPH", "Total PPH", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "Rounding", "Rounding", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "GrandTotal", "Grand Total", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPPInvoiceAmount", "Total DPP Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPNInvoiceAmount", "Total PPN Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPHInvoiceAmount", "Total PPH Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalInvoiceAmount", "Grand Total Invoice", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "OutstandingInvoiceAmount", "Total yang belum dibayar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PaymentBy", "Dibayar Oleh", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "PaymentDate", "Tanggal Bayar", 100, UI.usDefGrid.gFullDate, False)
        UI.usForm.SetGrid(grdView, "TaxInvoiceNumber", "No. Faktur Pajak", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "InvoiceNumberBP", "Nomor Invoice", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "SubmitBy", "Disubmit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitDate", "Tanggal Disubmit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ApprovedBy", "Diapprove Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ApproveL1", "ApproveL1", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ApprovedDate", "Tanggal Approve", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "IsDeleted", "IsDeleted", 100, UI.usDefGrid.gBoolean, False)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "StatusID", "StatusID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Dibuat Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Tanggal Buat", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogBy", "Diedit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LogDate", "Tanggal Edit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "LogInc", "LogInc", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "StatusInfo", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsDP", "IsDP", 100, UI.usDefGrid.gBoolean, False)
        UI.usForm.SetGrid(grdView, "CompanyBankAccountID1", "CompanyBankAccountID1", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CompanyBankAccountID2", "CompanyBankAccountID2", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm1", "PaymentTerm1", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm2", "PaymentTerm2", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm3", "PaymentTerm3", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm4", "PaymentTerm4", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm5", "PaymentTerm5", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm6", "PaymentTerm6", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm7", "PaymentTerm7", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm8", "PaymentTerm8", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm9", "PaymentTerm9", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PaymentTerm10", "PaymentTerm10", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "PPNPercentage", "PPNPercentage", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdView, "PPHPercentage", "PPHPercentage", 100, UI.usDefGrid.gReal2Num, False)
        UI.usForm.SetGrid(grdView, "IsFullDP", "Full DP ?", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdView, "IsGenerate", "Generate ?", 100, UI.usDefGrid.gBoolean)
        If bolIsControlARAP Then grdView.Columns("BPName").GroupIndex = 0
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
            .Item(cSetPaymentDate).Enabled = bolEnable
            .Item(cDeletePaymentDate).Enabled = bolEnable
            .Item(cSetTaxInvoiceNumber).Enabled = bolEnable
            .Item(cSetInvoiceNumberBP).Enabled = bolEnable
            .Item(cInvoice).Enabled = bolEnable
            .Item(cExtendDueDate).Enabled = bolEnable
            .Item(cPrintPI).Enabled = bolEnable
            .Item(cPrintInvoice).Enabled = bolEnable
            .Item(cExportExcel).Enabled = bolEnable
            .Item(cPrintPaymentBank).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvFillCombo()
        Try
            Dim dtData As DataTable = BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionAccountPayableBalance)
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
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvSetButton()
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvDefaultFilter()
        intCompanyID = ERPSLib.UI.usUserApp.CompanyID
        txtCompanyName.Text = ERPSLib.UI.usUserApp.CompanyName
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Try
            dtData = BL.ARAP.ListData(ERPSLib.UI.usUserApp.ProgramID, intCompanyID, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, cboStatus.SelectedValue, strModules, enumARAPType, intBPID, strReferencesID, intIsGenerate)
            grdMain.DataSource = dtData
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
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("TransNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "TransNumber", strSearch)
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

    Private Function prvGetData() As VO.ARAP
        Dim clsReturn As New VO.ARAP
        clsReturn.ProgramID = grdView.GetRowCellValue(intPos, "ProgramID")
        clsReturn.ProgramName = grdView.GetRowCellValue(intPos, "ProgramName")
        clsReturn.CompanyID = grdView.GetRowCellValue(intPos, "CompanyID")
        clsReturn.CompanyName = grdView.GetRowCellValue(intPos, "CompanyName")
        clsReturn.ID = grdView.GetRowCellValue(intPos, "ID")
        clsReturn.TransNumber = grdView.GetRowCellValue(intPos, "TransNumber")
        clsReturn.TransDate = grdView.GetRowCellValue(intPos, "TransDate")
        clsReturn.DueDateValue = grdView.GetRowCellValue(intPos, "DueDateValue")
        clsReturn.DueDate = grdView.GetRowCellValue(intPos, "DueDate")
        clsReturn.BPID = grdView.GetRowCellValue(intPos, "BPID")
        clsReturn.BPCode = grdView.GetRowCellValue(intPos, "BPCode")
        clsReturn.BPName = grdView.GetRowCellValue(intPos, "BPName")
        clsReturn.CoAID = grdView.GetRowCellValue(intPos, "CoAID")
        clsReturn.CoACode = grdView.GetRowCellValue(intPos, "CoACode")
        clsReturn.CoAName = grdView.GetRowCellValue(intPos, "CoAName")
        clsReturn.Modules = grdView.GetRowCellValue(intPos, "Modules")
        clsReturn.StatusID = grdView.GetRowCellValue(intPos, "StatusID")
        clsReturn.ReferencesID = grdView.GetRowCellValue(intPos, "ReferencesID")
        clsReturn.TotalAmount = grdView.GetRowCellValue(intPos, "TotalAmount")
        clsReturn.TotalPPN = grdView.GetRowCellValue(intPos, "TotalPPN")
        clsReturn.TotalPPH = grdView.GetRowCellValue(intPos, "TotalPPH")
        clsReturn.PaymentBy = grdView.GetRowCellValue(intPos, "PaymentBy")
        clsReturn.TaxInvoiceNumber = grdView.GetRowCellValue(intPos, "TaxInvoiceNumber")
        clsReturn.IsDP = grdView.GetRowCellValue(intPos, "IsDP")
        clsReturn.CompanyBankAccountID1 = grdView.GetRowCellValue(intPos, "CompanyBankAccountID1")
        clsReturn.CompanyBankAccountID2 = grdView.GetRowCellValue(intPos, "CompanyBankAccountID2")
        clsReturn.InvoiceNumberSupplier = grdView.GetRowCellValue(intPos, "InvoiceNumberBP")
        clsReturn.PaymentTerm1 = grdView.GetRowCellValue(intPos, "PaymentTerm1")
        clsReturn.PaymentTerm2 = grdView.GetRowCellValue(intPos, "PaymentTerm2")
        clsReturn.PaymentTerm3 = grdView.GetRowCellValue(intPos, "PaymentTerm3")
        clsReturn.PaymentTerm4 = grdView.GetRowCellValue(intPos, "PaymentTerm4")
        clsReturn.PaymentTerm5 = grdView.GetRowCellValue(intPos, "PaymentTerm5")
        clsReturn.PaymentTerm6 = grdView.GetRowCellValue(intPos, "PaymentTerm6")
        clsReturn.PaymentTerm7 = grdView.GetRowCellValue(intPos, "PaymentTerm7")
        clsReturn.PaymentTerm8 = grdView.GetRowCellValue(intPos, "PaymentTerm8")
        clsReturn.PaymentTerm9 = grdView.GetRowCellValue(intPos, "PaymentTerm9")
        clsReturn.PaymentTerm10 = grdView.GetRowCellValue(intPos, "PaymentTerm10")
        clsReturn.PPNPercentage = grdView.GetRowCellValue(intPos, "PPNPercentage")
        clsReturn.PPHPercentage = grdView.GetRowCellValue(intPos, "PPHPercentage")
        clsReturn.IsFullDP = grdView.GetRowCellValue(intPos, "IsFullDP")
        clsReturn.IsGenerate = grdView.GetRowCellValue(intPos, "IsGenerate")
        Return clsReturn
    End Function

    Private Sub prvNew()
        prvResetProgressBar()
        Dim frmDetail As Object
        If strModules = VO.AccountPayable.ReceivePaymentTransport Then
            frmDetail = New frmTraAPTransporterDet
            With frmDetail
                .pubIsNew = True
                .pubCS = prvGetCS()
                .Text = Me.Text
                .StartPosition = FormStartPosition.CenterScreen
                .pubShowDialog(Me)
            End With
        Else
            If strModules = VO.AccountPayable.DownPayment Or
                strModules = VO.AccountPayable.DownPaymentCutting Or
                strModules = VO.AccountPayable.DownPaymentTransport Or
                strModules = VO.AccountReceivable.DownPaymentOrderRequest Or
                strModules = VO.AccountReceivable.DownPaymentOrderRequestVer2 Or
                strModules = VO.AccountReceivable.DownPayment Then
                frmDetail = New frmTraARAPDetVer5
            Else
                '# Only for Receive Payment
                frmDetail = New frmTraARAPDetVer4
                frmDetail.pubPaymentTypeID = intPaymentTypeID
            End If

            With frmDetail
                .pubBPCode = strBPCode
                .pubBPName = strBPName
                .pubReferencesNumber = strReferencesNumber
                .pubIsLookup = True
                .pubIsNew = True
                .pubCS = prvGetCS()
                .pubModules = strModules
                .pubBPID = intBPID
                .pubARAPType = enumARAPType
                .pubReferencesID = strReferencesID
                .pubIsUseSubItem = bolIsUseSubItem
                .pubPPHPercentage = decPPHPercentage
                .pubPPNPercentage = decPPNPercentage
                .Text = Me.Text
                .StartPosition = FormStartPosition.CenterScreen
                .pubShowDialog(Me)
            End With
        End If

    End Sub

    Private Sub prvDetail()
        prvResetProgressBar()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As Object
        If strModules = VO.AccountPayable.ReceivePaymentTransport Then
            frmDetail = New frmTraAPTransporterDet
            With frmDetail
                .pubIsNew = False
                .pubID = clsData.ID
                .pubCS = prvGetCS()
                .Text = Me.Text
                .StartPosition = FormStartPosition.CenterScreen
                .pubShowDialog(Me)
            End With
        Else
            If clsData.Modules = VO.AccountPayable.DownPayment Or
               clsData.Modules = VO.AccountPayable.DownPaymentCutting Or
                clsData.Modules = VO.AccountPayable.DownPaymentTransport Or
                clsData.Modules = VO.AccountReceivable.DownPaymentOrderRequest Or
                clsData.Modules = VO.AccountReceivable.DownPayment Then
                frmDetail = New frmTraARAPDetVer5
            Else
                frmDetail = New frmTraARAPDetVer4
                frmDetail.pubPaymentTypeID = intPaymentTypeID
            End If

            With frmDetail
                .pubBPCode = strBPCode
                .pubBPName = strBPName
                .pubReferencesNumber = strReferencesNumber
                .pubIsLookup = True
                .pubIsNew = False
                .pubCS = prvGetCS()
                .pubID = clsData.ID
                .pubModules = strModules
                .pubBPID = intBPID
                .pubARAPType = enumARAPType
                .pubReferencesID = strReferencesID
                .pubIsUseSubItem = bolIsUseSubItem
                .pubPPHPercentage = decPPHPercentage
                .pubPPNPercentage = decPPNPercentage
                .Text = Me.Text
                .StartPosition = FormStartPosition.CenterScreen
                .pubShowDialog(Me)
            End With
        End If
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        If Not UI.usForm.frmAskQuestion("Hapus Nomor " & clsData.TransNumber & "?") Then Exit Sub

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
            BL.ARAP.DeleteData(clsData.ID, clsData.Modules, clsData.Remarks, enumARAPType, intPaymentTypeID)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
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
        If Not UI.usForm.frmAskQuestion("Submit Nomor " & clsData.TransNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.ARAP.Submit(clsData.ID, "", enumARAPType)
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
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
        If Not UI.usForm.frmAskQuestion("Batal Submit Nomor " & clsData.TransNumber & "?") Then Exit Sub

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
            BL.ARAP.Unsubmit(clsData.ID, clsData.Remarks, enumARAPType)
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Batal submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
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
        If Not UI.usForm.frmAskQuestion("Approve Nomor " & clsData.TransNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.ARAP.Approve(clsData.ID, "", enumARAPType)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
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
        If Not UI.usForm.frmAskQuestion("Batal Approve Nomor " & clsData.TransNumber & "?") Then Exit Sub

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
            BL.ARAP.Unapprove(clsData.ID, clsData.Remarks, enumARAPType)
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Batal approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSetupPaymentDate()
        'intPos = grdView.FocusedRowHandle
        'If intPos < 0 Then Exit Sub
        'clsData = prvGetData()

        'Dim frmDetail As New frmTraAccountSetPaymentDate
        'With frmDetail
        '    .pubChooseCoA = True 'IIf(clsData.IsDP, False, True)
        '    .pubCoAID = clsData.CoAID
        '    .pubCoACode = clsData.CoACode
        '    .pubCoAName = clsData.CoAName
        '    .pubCS = prvGetCS()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If .pubIsSave Then
        '        clsData.CoAID = .pubCoAID
        '        clsData.PaymentDate = .pubPaymentDate
        '        clsData.PaymentBy = ERPSLib.UI.usUserApp.UserID
        '        clsData.Remarks = .pubRemarks
        '    Else
        '        Exit Sub
        '    End If
        'End With

        'Me.Cursor = Cursors.WaitCursor
        'pgMain.Value = 40

        'Try
        '    BL.ARAP.SetupPayment(clsData.ID, clsData.PaymentDate, clsData.Remarks, enumARAPType, clsData.CoAID)
        '    pgMain.Value = 100

        '    UI.usForm.frmMessageBox("Setup tanggal pembayaran berhasil.")
        '    pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'Finally
        '    Me.Cursor = Cursors.Default
        '    pgMain.Value = 100

        '    prvResetProgressBar()
        'End Try
    End Sub

    Private Sub prvSetupCancelPaymentDate()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        If Not UI.usForm.frmAskQuestion("Hapus Tanggal Pembayaran Nomor " & clsData.TransNumber & "?") Then Exit Sub

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
            BL.ARAP.SetupCancelPayment(clsData.ID, clsData.Remarks, enumARAPType)
            pgMain.Value = 100

            UI.usForm.frmMessageBox("Hapus tanggal pembayaran berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSetupTaxInvoiceNumber()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        Dim frmDetail As New frmTraAccountSetTaxInvoiceNumber
        With frmDetail
            .pubTaxInvoiceNumber = clsData.TaxInvoiceNumber
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.TaxInvoiceNumber = .pubTaxInvoiceNumber
                clsData.Remarks = .pubRemarks
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.ARAP.UpdateTaxInvoiceNumber(clsData.ID, clsData.TaxInvoiceNumber, clsData.Remarks, enumARAPType)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Update nomor faktur pajak berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvSetupInvoiceNumberSupplier()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        Dim frmDetail As New frmTraAccountSetInvoiceNumberBP
        With frmDetail
            .pubInvoiceNumberSupplier = clsData.InvoiceNumberSupplier
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If .pubIsSave Then
                clsData.InvoiceNumberSupplier = .pubInvoiceNumberSupplier
                clsData.Remarks = .pubRemarks
            Else
                Exit Sub
            End If
        End With

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        Try
            BL.ARAP.UpdateInvoiceNumberSupplier(clsData.ID, clsData.InvoiceNumberSupplier, clsData.Remarks, enumARAPType)
            pgMain.Value = 100
            UI.usForm.frmMessageBox("Update nomor invoice pajak berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvPrintPI()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdView.GetRowCellValue(intPos, "ID")
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        If bolIsControlARAP Then clsCS = prvGetCS()
        clsData = prvGetData()
        Try
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                Dim frmChooseBankAccount As New frmTraARAPChooseBankAccount
                With frmChooseBankAccount
                    .pubID = strID
                    .pubCompanyID = clsData.CompanyID
                    .pubCompanyBankAccount1 = clsData.CompanyBankAccountID1
                    .pubCompanyBankAccount2 = clsData.CompanyBankAccountID2
                    .StartPosition = FormStartPosition.CenterParent
                    .pubShowDialog(Me)
                    If Not .pubIsSave Then Exit Sub
                End With
            End If


            Dim dtData As DataTable = BL.ARAP.PrintVer01(clsCS.ProgramID, intCompanyID, strID)
            Dim intStatusID As Integer = 0
            For Each dr As DataRow In dtData.Rows
                intStatusID = dr.Item("StatusID")
                Exit For
            Next

            Dim crReport As New rptProformaInvoice

            '# Setup Watermark Report
            If intStatusID <> VO.Status.Values.Approved And intStatusID <> VO.Status.Values.Payment Then
                crReport.Watermark.ShowBehind = False
                crReport.Watermark.Text = "DRAFT" & vbCrLf & "NOT OFFICIAL"
                crReport.Watermark.ForeColor = System.Drawing.Color.DimGray
                crReport.Watermark.Font = New System.Drawing.Font("Tahoma", 70.0!, System.Drawing.FontStyle.Bold)
                crReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal
                crReport.Watermark.TextTransparency = 150
            End If

            '# Set Default Value Payment
            crReport.InvoiceType.Value = VO.ARAP.GetPaymentTypeInitial(clsData.Modules)
            crReport.HeaderType.Value = "PERFORMA INVOICE"
            crReport.DescPayment1.Value = ""
            crReport.DescPayment2.Value = ""
            crReport.DescPayment3.Value = ""
            crReport.DescPayment4.Value = ""
            crReport.AmountPayment1.Value = 0
            crReport.AmountPayment2.Value = 0
            crReport.AmountPayment3.Value = 0
            crReport.AmountPayment4.Value = 0
            crReport.rhBPInfoInvoice.Visible = False
            Dim dtPaymentHistory As DataTable = BL.ARAP.ListPaymentHistoryVer02(clsCS.ProgramID, intCompanyID, clsData.ID, clsData.IsFullDP)
            For i As Integer = 0 To dtPaymentHistory.Rows.Count - 1
                Dim strDescPayment As String = VO.Common.GetPaymentType(dtPaymentHistory.Rows(i).Item("Modules")) & IIf(dtPaymentHistory.Rows(i).Item("Percentage") > 0, " " & CInt(dtPaymentHistory.Rows(i).Item("Percentage")) & "%", "")
                Dim decAmountPayment As Decimal = dtPaymentHistory.Rows(i).Item("Amount")
                If i = 0 Then
                    crReport.sbPayment1.Visible = True
                    crReport.DescPayment1.Value = strDescPayment
                    crReport.AmountPayment1.Value = decAmountPayment
                ElseIf i = 1 Then
                    crReport.sbPayment2.Visible = True
                    crReport.DescPayment2.Value = strDescPayment
                    crReport.AmountPayment2.Value = decAmountPayment
                ElseIf i = 2 Then
                    crReport.sbPayment3.Visible = True
                    crReport.DescPayment3.Value = strDescPayment
                    crReport.AmountPayment3.Value = decAmountPayment
                End If
            Next

            clsData = BL.ARAP.GetDetail(clsData.ID, enumARAPType)
            crReport.PaymentTerm1.Value = clsData.PaymentTerm1.Trim
            If clsData.PaymentTerm1.Trim = "" Then crReport.sbPaymentTerm1.Visible = False
            crReport.PaymentTerm2.Value = clsData.PaymentTerm2.Trim
            If clsData.PaymentTerm2.Trim = "" Then crReport.sbPaymentTerm2.Visible = False
            crReport.PaymentTerm3.Value = clsData.PaymentTerm3.Trim
            If clsData.PaymentTerm3.Trim = "" Then crReport.sbPaymentTerm3.Visible = False

            If clsData.PaymentTerm4.Trim <> "" Then
                crReport.sbPaymentTerm4.Visible = True
                crReport.PaymentTerm4.Value = clsData.PaymentTerm4.Trim
            End If

            If clsData.PaymentTerm5.Trim <> "" Then
                crReport.sbPaymentTerm5.Visible = True
                crReport.PaymentTerm5.Value = clsData.PaymentTerm5.Trim
            End If

            If clsData.PaymentTerm6.Trim <> "" Then
                crReport.sbPaymentTerm6.Visible = True
                crReport.PaymentTerm6.Value = clsData.PaymentTerm6.Trim
            End If

            If clsData.PaymentTerm7.Trim <> "" Then
                crReport.sbPaymentTerm7.Visible = True
                crReport.PaymentTerm7.Value = clsData.PaymentTerm7.Trim
            End If

            If clsData.PaymentTerm8.Trim <> "" Then
                crReport.sbPaymentTerm8.Visible = True
                crReport.PaymentTerm8.Value = clsData.PaymentTerm8.Trim
            End If

            If clsData.PaymentTerm9.Trim <> "" Then
                crReport.sbPaymentTerm9.Visible = True
                crReport.PaymentTerm9.Value = clsData.PaymentTerm9.Trim
            End If

            If clsData.PaymentTerm10.Trim <> "" Then
                crReport.sbPaymentTerm10.Visible = True
                crReport.PaymentTerm10.Value = clsData.PaymentTerm10.Trim
            End If

            For Each dr As DataRow In dtData.Rows
                If dr.Item("BankAccountName2") = "" Then
                    crReport.sbCompanyBankAccount2.Visible = False
                    crReport.xrBankAccountDescription2.Visible = False
                    crReport.xrLblBankAccountName2.Visible = False
                    crReport.xrLblBankName2.Visible = False
                    crReport.xrLblBankAccountNumber2.Visible = False

                    crReport.xrSepBankAccountName2.Visible = False
                    crReport.xrSepBankName2.Visible = False
                    crReport.xrSepBankAccountNumber2.Visible = False

                    crReport.xrTxtBankAccountName2.Visible = False
                    crReport.xrTxtBankName2.Visible = False
                    crReport.xrTxtBankAccountNumber2.Visible = False
                End If
                Exit For
            Next

            '# Setup Logo
            If clsData.CompanyID = VO.Company.Values.TBU Then
                crReport.sbLogoImage.Visible = True
            Else
                Dim img As Image = UI.usForm.GetLogoCompanyByInitial(ERPSLib.UI.usUserApp.CompanyInitial)
                crReport.sbLogoStandart.Visible = True
                crReport.xrLogo.Image = img
            End If

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
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvPrintInvoice()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdView.GetRowCellValue(intPos, "ID")
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40

        If bolIsControlARAP Then clsCS = prvGetCS()
        clsData = prvGetData()
        Dim strSelectedInvoiceID As String = ""
        Try
            If clsData.StatusID <> VO.Status.Values.Payment Then
                Throw New Exception("Data tidak dapat Print Invoice dikarenakan belum diproses Invoice.")
                Exit Sub
            End If

            Dim frmChooseInvoice As New frmTraARAPChooseInvoice
            With frmChooseInvoice
                .pubParentID = clsData.ID
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If .pubIsPreview Then
                    strSelectedInvoiceID = .pubSelectedID
                Else
                    Exit Sub
                End If
            End With

            Dim dtData As DataTable = BL.ARAP.PrintVer01(clsCS.ProgramID, intCompanyID, strID)
            Dim clsInvoice As VO.ARAPInvoice = BL.ARAP.GetDetailInvoice(strSelectedInvoiceID)
            Dim intStatusID As Integer = clsInvoice.StatusID
            For Each dr As DataRow In dtData.Rows
                dr.BeginEdit()
                dr.Item("TransNumber") = clsInvoice.InvoiceNumber
                dr.Item("TaxInvoiceNumber") = clsInvoice.TaxInvoiceNumber
                dr.Item("TransDate") = clsInvoice.InvoiceDate
                dr.EndEdit()
            Next
            dtData.AcceptChanges()

            Dim crReport As New rptProformaInvoice

            '# Setup Watermark Report
            If intStatusID = VO.Status.Values.Draft Then
                crReport.Watermark.ShowBehind = False
                crReport.Watermark.Text = "DRAFT" & vbCrLf & "NOT OFFICIAL"
                crReport.Watermark.ForeColor = System.Drawing.Color.DimGray
                crReport.Watermark.Font = New System.Drawing.Font("Tahoma", 70.0!, System.Drawing.FontStyle.Bold)
                crReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal
                crReport.Watermark.TextTransparency = 150
            End If

            '# Set Default Value Payment
            crReport.InvoiceType.Value = VO.ARAP.GetPaymentTypeInitial(clsData.Modules)
            crReport.HeaderType.Value = "INVOICE"
            crReport.DescPayment1.Value = ""
            crReport.DescPayment2.Value = ""
            crReport.DescPayment3.Value = ""
            crReport.DescPayment4.Value = ""
            crReport.AmountPayment1.Value = 0
            crReport.AmountPayment2.Value = 0
            crReport.AmountPayment3.Value = 0
            crReport.AmountPayment4.Value = 0
            crReport.rhBPInfo.Visible = False

            Dim dtPaymentHistory As DataTable = BL.ARAP.ListPaymentHistoryVer02(clsCS.ProgramID, intCompanyID, clsData.ID, clsData.IsFullDP)
            For i As Integer = 0 To dtPaymentHistory.Rows.Count - 1
                Dim strDescPayment As String = VO.Common.GetPaymentType(dtPaymentHistory.Rows(i).Item("Modules")) & IIf(dtPaymentHistory.Rows(i).Item("Percentage") > 0, " " & CInt(dtPaymentHistory.Rows(i).Item("Percentage")) & "%", "")
                Dim decAmountPayment As Decimal = dtPaymentHistory.Rows(i).Item("Amount")
                If i = 0 Then
                    crReport.sbPayment1.Visible = True
                    crReport.DescPayment1.Value = strDescPayment
                    crReport.AmountPayment1.Value = decAmountPayment
                ElseIf i = 1 Then
                    crReport.sbPayment2.Visible = True
                    crReport.DescPayment2.Value = strDescPayment
                    crReport.AmountPayment2.Value = decAmountPayment
                ElseIf i = 2 Then
                    crReport.sbPayment3.Visible = True
                    crReport.DescPayment3.Value = strDescPayment
                    crReport.AmountPayment3.Value = decAmountPayment
                End If
            Next

            '# Invoice Amount
            Dim dtInvoice As DataTable = BL.ARAP.ListDataInvoice(clsData.ID)
            Dim drInvoice() As DataRow = dtInvoice.Select("IsDeleted=0")
            Dim decAmountInvoice As Decimal = 0
            For i As Integer = 0 To drInvoice.Length - 1
                Dim strDescInvoice As String = "PAYMENT " & Format(drInvoice(i).Item("InvoiceDate"), "dd/MM")
                decAmountInvoice = drInvoice(i).Item("TotalAmount")
                If clsData.IsDP Or drInvoice.Length = 1 Then Continue For
                If i = 0 Then
                    crReport.sbInvoice1.Visible = True
                    crReport.DescInvoice1.Value = strDescInvoice
                    crReport.AmountInvoice1.Value = decAmountInvoice
                ElseIf i = 1 Then
                    crReport.sbInvoice2.Visible = True
                    crReport.DescInvoice2.Value = strDescInvoice
                    crReport.AmountInvoice2.Value = decAmountInvoice
                ElseIf i = 2 Then
                    crReport.sbInvoice3.Visible = True
                    crReport.DescInvoice3.Value = strDescInvoice
                    crReport.AmountInvoice3.Value = decAmountInvoice
                ElseIf i = 3 Then
                    crReport.sbInvoice4.Visible = True
                    crReport.DescInvoice4.Value = strDescInvoice
                    crReport.AmountInvoice4.Value = decAmountInvoice
                ElseIf i = 4 Then
                    crReport.sbInvoice5.Visible = True
                    crReport.DescInvoice5.Value = strDescInvoice
                    crReport.AmountInvoice5.Value = decAmountInvoice
                End If
            Next

            If decAmountInvoice > 0 Then
                For Each dr As DataRow In dtData.Rows
                    dr.Item("NumericToString") = ERPSLib.SharedLib.Math.NumberToString(ERPSLib.SharedLib.Math.Round(decAmountInvoice, 0))
                Next
                dtData.AcceptChanges()
            End If

            clsData = BL.ARAP.GetDetail(clsData.ID, enumARAPType)
            crReport.PaymentTerm1.Value = clsData.PaymentTerm1.Trim
            If clsData.PaymentTerm1.Trim = "" Then crReport.sbPaymentTerm1.Visible = False
            crReport.PaymentTerm2.Value = clsData.PaymentTerm2.Trim
            If clsData.PaymentTerm2.Trim = "" Then crReport.sbPaymentTerm2.Visible = False
            crReport.PaymentTerm3.Value = clsData.PaymentTerm3.Trim
            If clsData.PaymentTerm3.Trim = "" Then crReport.sbPaymentTerm3.Visible = False

            If clsData.PaymentTerm4.Trim <> "" Then
                crReport.sbPaymentTerm4.Visible = True
                crReport.PaymentTerm4.Value = clsData.PaymentTerm4.Trim
            End If

            If clsData.PaymentTerm5.Trim <> "" Then
                crReport.sbPaymentTerm5.Visible = True
                crReport.PaymentTerm5.Value = clsData.PaymentTerm5.Trim
            End If

            If clsData.PaymentTerm6.Trim <> "" Then
                crReport.sbPaymentTerm6.Visible = True
                crReport.PaymentTerm6.Value = clsData.PaymentTerm6.Trim
            End If

            If clsData.PaymentTerm7.Trim <> "" Then
                crReport.sbPaymentTerm7.Visible = True
                crReport.PaymentTerm7.Value = clsData.PaymentTerm7.Trim
            End If

            If clsData.PaymentTerm8.Trim <> "" Then
                crReport.sbPaymentTerm8.Visible = True
                crReport.PaymentTerm8.Value = clsData.PaymentTerm8.Trim
            End If

            If clsData.PaymentTerm9.Trim <> "" Then
                crReport.sbPaymentTerm9.Visible = True
                crReport.PaymentTerm9.Value = clsData.PaymentTerm9.Trim
            End If

            If clsData.PaymentTerm10.Trim <> "" Then
                crReport.sbPaymentTerm10.Visible = True
                crReport.PaymentTerm10.Value = clsData.PaymentTerm10.Trim
            End If

            For Each dr As DataRow In dtData.Rows
                If dr.Item("BankAccountName2") = "" Then
                    crReport.sbCompanyBankAccount2.Visible = False
                    crReport.xrBankAccountDescription2.Visible = False
                    crReport.xrLblBankAccountName2.Visible = False
                    crReport.xrLblBankName2.Visible = False
                    crReport.xrLblBankAccountNumber2.Visible = False

                    crReport.xrSepBankAccountName2.Visible = False
                    crReport.xrSepBankName2.Visible = False
                    crReport.xrSepBankAccountNumber2.Visible = False

                    crReport.xrTxtBankAccountName2.Visible = False
                    crReport.xrTxtBankName2.Visible = False
                    crReport.xrTxtBankAccountNumber2.Visible = False
                End If
                Exit For
            Next

            '# Setup Logo
            If clsData.CompanyID = VO.Company.Values.TBU Then
                crReport.sbLogoImage.Visible = True
            Else
                Dim img As Image = UI.usForm.GetLogoCompanyByInitial(ERPSLib.UI.usUserApp.CompanyInitial)
                crReport.sbLogoStandart.Visible = True
                crReport.xrLogo.Image = img
            End If

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
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100

            prvResetProgressBar()
        End Try
    End Sub

    Private Sub prvPrintBankOut()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim strID As String = grdView.GetRowCellValue(intPos, "ID")
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 40
        Try
            Dim sharedPrintout As New SharedLib.usSharedPrintout
            sharedPrintout.PrintCostBankOut(Me, strID, BL.AccountPayable.PrintCostBankOut(strID))

            'Dim crReport As New rptCostBankOutVer00
            'crReport.DataSource = BL.AccountPayable.PrintCostBankOut(strID)
            'crReport.CreateDocument(True)
            'crReport.ShowPreviewMarginLines = False
            'crReport.ShowPrintMarginsWarning = False

            'Dim frmDetail As New frmReportPreview
            'With frmDetail
            '    .docViewer.DocumentSource = crReport
            '    .pgExportButton.Enabled = True
            '    .Text = Me.Text & " - " & VO.Reports.PrintOut
            '    .WindowState = FormWindowState.Maximized
            '    .Show()
            'End With
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            pgMain.Value = 100
            Me.Cursor = Cursors.Default
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
        Dim SumTotalAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "Total DPP: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPN", "Total PPN: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPH", "Total PPH: {0:#,##0.00}")
        Dim SumGrandTotal As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", "Grand Total: {0:#,##0.00}")
        Dim SumTotalDPPInvoiceAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPPInvoiceAmount", "Total DPP Invoice: {0:#,##0.00}")
        Dim SumTotalPPNInvoiceAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPNInvoiceAmount", "Total PPN Invoice: {0:#,##0.00}")
        Dim SumTotalPPHInvoiceAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPHInvoiceAmount", "Total PPH Invoice: {0:#,##0.00}")
        Dim SumGrandTotalInvoiceAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInvoiceAmount", "Grand Total Invoice: {0:#,##0.00}")
        Dim SumOutstandingInvoiceAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutstandingInvoiceAmount", "Total yang belum dibayar: {0:#,##0.00}")

        Dim sumGroupTotalAmount As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", grdView.Columns("TotalAmount"), "Total DPP: {0:#,##0.00}")
        Dim sumGroupTotalPPN As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPN", grdView.Columns("TotalPPN"), "Total PPN: {0:#,##0.00}")
        Dim sumGroupTotalPPH As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPH", grdView.Columns("TotalPPH"), "Total PPH: {0:#,##0.00}")
        Dim sumGroupGrandTotal As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", grdView.Columns("GrandTotal"), "Grand Total: {0:#,##0.00}")
        Dim sumGroupTotalDPPInvoiceAmount As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPPInvoiceAmount", grdView.Columns("TotalDPPInvoiceAmount"), "Total DPP Invoice: {0:#,##0.00}")
        Dim sumGroupTotalPPNInvoiceAmount As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPNInvoiceAmount", grdView.Columns("TotalPPNInvoiceAmount"), "Total PPN Invoice: {0:#,##0.00}")
        Dim sumGroupTotalPPHInvoiceAmount As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPHInvoiceAmount", grdView.Columns("TotalPPHInvoiceAmount"), "Total PPH Invoice: {0:#,##0.00}")
        Dim sumGroupTotalInvoiceAmount As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInvoiceAmount", grdView.Columns("TotalInvoiceAmount"), "Grand Total Invoice: {0:#,##0.00}")
        Dim SumGroupOutstandingInvoiceAmount As New GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutstandingInvoiceAmount", grdView.Columns("OutstandingInvoiceAmount"), "Total yang belum dibayar: {0:#,##0.00}")

        If grdView.Columns("TotalAmount").SummaryText.Trim = "" Then
            grdView.Columns("TotalAmount").Summary.Add(SumTotalAmount)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupTotalAmount)
        End If

        If grdView.Columns("TotalPPN").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPN").Summary.Add(SumTotalPPN)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupTotalPPN)
        End If

        If grdView.Columns("TotalPPH").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPH").Summary.Add(SumTotalPPH)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupTotalPPH)
        End If

        If grdView.Columns("GrandTotal").SummaryText.Trim = "" Then
            grdView.Columns("GrandTotal").Summary.Add(SumGrandTotal)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupGrandTotal)
        End If

        If grdView.Columns("TotalDPPInvoiceAmount").SummaryText.Trim = "" Then
            grdView.Columns("TotalDPPInvoiceAmount").Summary.Add(SumTotalDPPInvoiceAmount)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupTotalDPPInvoiceAmount)
        End If

        If grdView.Columns("TotalPPNInvoiceAmount").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPNInvoiceAmount").Summary.Add(SumTotalPPNInvoiceAmount)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupTotalPPNInvoiceAmount)
        End If

        If grdView.Columns("TotalPPHInvoiceAmount").SummaryText.Trim = "" Then
            grdView.Columns("TotalPPHInvoiceAmount").Summary.Add(SumTotalPPHInvoiceAmount)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupTotalPPHInvoiceAmount)
        End If

        If grdView.Columns("TotalInvoiceAmount").SummaryText.Trim = "" Then
            grdView.Columns("TotalInvoiceAmount").Summary.Add(SumGrandTotalInvoiceAmount)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(sumGroupTotalInvoiceAmount)
        End If

        If grdView.Columns("OutstandingInvoiceAmount").SummaryText.Trim = "" Then
            grdView.Columns("OutstandingInvoiceAmount").Summary.Add(SumOutstandingInvoiceAmount)
            If grdView.GroupCount > 0 Then grdView.GroupSummary.Add(SumGroupOutstandingInvoiceAmount)
        End If

        If grdView.GroupCount > 0 Then grdView.ExpandAllGroups()
    End Sub

    Private Sub prvUserAccess()
        Dim intModules As Integer = VO.Common.GetModuleID(strModules)
        With ToolBar.Buttons
            .Item(cImport).Visible = strModules = VO.AccountReceivable.DownPayment

            If bolIsControlARAP Then
                .Item(cNew).Visible = False
                .Item(cDelete).Visible = False
                .Item(cSubmit).Visible = False
                .Item(cCancelSubmit).Visible = False
                .Item(cApprove).Visible = False
                .Item(cCancelApprove).Visible = False
            Else
                .Item(cNew).Visible = strModules <> VO.AccountReceivable.DownPayment

                '.Item(cNew).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.NewAccess)
                .Item(cDelete).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.DeleteAccess)
                .Item(cSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.SubmitAccess)
                .Item(cCancelSubmit).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.CancelSubmitAccess)
                .Item(cApprove).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.ApproveAccess)
                .Item(cCancelApprove).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.CancelApproveAccess)
            End If
            .Item(cSetPaymentDate).Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.PaymentAccess)
            .Item(cDeletePaymentDate).Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.CancelPaymentAccess)
            .Item(cSetTaxInvoiceNumber).Visible = False 'BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.TaxInvoiceNumberAccess)
            .Item(cSetInvoiceNumberBP).Visible = False 'enumARAPType = VO.ARAP.ARAPTypeValue.Purchase And BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, intModules, VO.Access.Values.InvoiceNumberBusinessPartner)
            .Item(cSep3).Visible = False
            If enumARAPType = VO.ARAP.ARAPTypeValue.Purchase Or (enumARAPType = VO.ARAP.ARAPTypeValue.Sales And strModules = VO.AccountReceivable.ReceivePaymentSalesReturn) Then .Item(cPrintPI).Visible = False : .Item(cPrintInvoice).Visible = False
            If enumARAPType = VO.ARAP.ARAPTypeValue.Purchase And strModules <> VO.AccountPayable.ReceivePaymentTransport Then .Item(cPrintPaymentBank).Visible = False
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then .Item(cPrintPaymentBank).Visible = False
            '.Item(cPrintPaymentBank).Visible = strModules = VO.AccountPayable.ReceivePayment Or strModules = VO.AccountPayable.DownPayment
        End With
    End Sub

    Private Sub prvInvoice()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()

        If clsData.StatusID <> VO.Status.Values.Approved And clsData.StatusID <> VO.Status.Values.Payment Then
            UI.usForm.frmMessageBox("Data harus di setujui terlebih dahulu")
            Exit Sub
        ElseIf clsData.IsGenerate Then
            UI.usForm.frmMessageBox("Data yang diimport tidak perlu dilakukan proses Invoice")
            Exit Sub
        End If

        Dim frmDetail As New frmTraARAPInvoice
        With frmDetail
            .pubParentID = clsData.ID
            .pubPPNPercentage = clsData.PPNPercentage
            .pubPPHPercentage = clsData.PPHPercentage
            .pubParentID = clsData.ID
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            pubRefresh()
        End With
    End Sub

    Private Sub prvExtendDueDate()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraARAPExtendDueDate
        With frmDetail
            .pubParentID = clsData.ID
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            pubRefresh()
        End With
    End Sub

    Private Sub prvImport()
        prvResetProgressBar()
        Try
            Dim frmLookup As New frmTraARAPDPLookup
            frmLookup.pubListReferencesID = BL.SalesContract.ListDataOrderRequest(strReferencesID)
            frmLookup.StartPosition = FormStartPosition.CenterParent
            frmLookup.ShowDialog()
            If frmLookup.pubIsLookUpGet Then
                Dim frmDetail As New frmTraARAPDetVer3Import
                With frmDetail
                    .pubIsNew = True
                    .pubIDLookup = frmLookup.pubLUdtRow("ID")
                    .pubCS = prvGetCS()
                    .pubModules = VO.AccountReceivable.DownPayment
                    .pubBPID = intBPID
                    .pubARAPType = enumARAPType
                    .pubReferencesID = strReferencesID
                    .pubIsUseSubItem = bolIsUseSubItem
                    .pubPPHPercentage = decPPHPercentage
                    .pubPPNPercentage = decPPNPercentage
                    .pubDtItemImport = BL.ARAP.ListDataDetailVer2(frmLookup.pubLUdtRow("ID"), enumARAPType)
                    .Text = Me.Text
                    .StartPosition = FormStartPosition.CenterScreen
                    .pubShowDialog(Me)
                End With
            Else : Exit Sub
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

#Region "Form Handle"

    Private Sub frmTraDownPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraDownPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.Text = VO.Common.GetPaymentText(strModules)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Name = ToolBar.Buttons(cNew).Name Then
            prvNew()
        ElseIf e.Button.Name = ToolBar.Buttons(cImport).Name Then
            prvImport()
        ElseIf e.Button.Name = ToolBar.Buttons(cRefresh).Name Then
            pubRefresh()
        ElseIf e.Button.Name = ToolBar.Buttons(cClose).Name Then
            Me.Close()
        ElseIf e.Button.Name = ToolBar.Buttons(cExportExcel).Name Then
            prvExportExcel()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Name
                Case ToolBar.Buttons(cDetail).Name : prvDetail()
                Case ToolBar.Buttons(cDelete).Name : prvDelete()
                Case ToolBar.Buttons(cSubmit).Name : prvSubmit()
                Case ToolBar.Buttons(cCancelSubmit).Name : prvCancelSubmit()
                Case ToolBar.Buttons(cApprove).Name : prvApprove()
                Case ToolBar.Buttons(cCancelApprove).Name : prvCancelApprove()
                Case ToolBar.Buttons(cSetPaymentDate).Name : prvSetupPaymentDate()
                Case ToolBar.Buttons(cDeletePaymentDate).Name : prvSetupCancelPaymentDate()
                Case ToolBar.Buttons(cSetTaxInvoiceNumber).Name : prvSetupTaxInvoiceNumber()
                Case ToolBar.Buttons(cSetInvoiceNumberBP).Name : prvSetupInvoiceNumberSupplier()
                Case ToolBar.Buttons(cInvoice).Name : prvInvoice()
                Case ToolBar.Buttons(cExtendDueDate).Name : prvExtendDueDate()
                Case ToolBar.Buttons(cPrintPI).Name : prvPrintPI()
                Case ToolBar.Buttons(cPrintInvoice).Name : prvPrintInvoice()
                Case ToolBar.Buttons(cPrintPaymentBank).Name : prvPrintBankOut()
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