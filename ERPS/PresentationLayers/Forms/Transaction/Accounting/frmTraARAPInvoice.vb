Imports DevExpress.XtraGrid
Imports ERPSLib.VO
Imports Microsoft.VisualBasic.Devices

Public Class frmTraARAPInvoice

#Region "Properties"

    Private strParentID As String = ""
    Private decPPNPercentage As Decimal = 0
    Private decPPHPercentage As Decimal = 0
    Private bolIsSave As Boolean = False
    Private intPos As Integer
    Private clsData As New ARAPInvoice

    Public WriteOnly Property pubParentID As String
        Set(value As String)
            strParentID = value
        End Set
    End Property

    Public ReadOnly Property pubIsSave As Boolean
        Get
            Return bolIsSave
        End Get
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

#End Region

    Private Const _
       cNew As Byte = 0, cDetail As Byte = 1, cDelete As Byte = 2, cSep1 As Byte = 3,
       cSubmit As Byte = 4, cCancelSubmit As Byte = 5, cApprove As Byte = 6, cCancelApprove As Byte = 7,
       cSep2 As Byte = 8, cSetTaxInvoiceNumber As Byte = 9, cSetInvoiceNumberBP As Byte = 10, cSep3 As Byte = 11,
       cPrint As Byte = 12, cExportExcel As Byte = 13, cSep4 As Byte = 14, cRefresh As Byte = 15, cClose As Byte = 16

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "Pick", "Pilih", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "InvoiceNumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "InvoiceDate", "Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "CoAID", "ID Akun", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "CoACode", "Kode Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CoAName", "Nama Akun", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PPN", "PPN [%]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "PPH", "PPH [%]", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalAmount", "Total Bayar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalDPP", "Total DPP Dibayar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPN", "Total PPN Dibayar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPPH", "Total PPH Dibayar", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TaxInvoiceNumber", "No. Faktur Pajak", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "InvoiceNumberExternal", "Nomor Invoice Eksternal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitBy", "Disubmit Oleh", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SubmitDate", "Tanggal Disubmit", 100, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ApprovedBy", "Diapprove Oleh", 100, UI.usDefGrid.gString)
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
            .Item(cSetTaxInvoiceNumber).Enabled = bolEnable
            .Item(cSetInvoiceNumberBP).Enabled = bolEnable
            .Item(cPrint).Enabled = bolEnable
            .Item(cExportExcel).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        Try
            grdMain.DataSource = BL.ARAP.ListDataInvoice(strParentID)
            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            prvSetButton()
        End Try
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "Total Bayar: {0:#,##0.00}")
        Dim SumTotalDPP As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDPP", "Total DPP Dibayar: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPN", "Total PPN Dibayar: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPPH", "Total PPH Dibayar: {0:#,##0.00}")

        If grdView.Columns("TotalAmount").SummaryText.Trim = "" Then
            grdView.Columns("TotalAmount").Summary.Add(SumTotalAmount)
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
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("InvoiceNumber")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "TransNumber", strSearch)
        End With
    End Sub

    Private Function prvGetData() As VO.ARAPInvoice
        Return New VO.ARAPInvoice With {
            .ID = grdView.GetRowCellValue(intPos, "ID"),
            .ParentID = strParentID,
            .InvoiceNumber = grdView.GetRowCellValue(intPos, "InvoiceNumber"),
            .InvoiceDate = grdView.GetRowCellValue(intPos, "InvoiceDate"),
            .CoAID = grdView.GetRowCellValue(intPos, "CoAID"),
            .CoACode = grdView.GetRowCellValue(intPos, "CoACode"),
            .CoAName = grdView.GetRowCellValue(intPos, "CoAName"),
            .PPN = grdView.GetRowCellValue(intPos, "PPN"),
            .PPH = grdView.GetRowCellValue(intPos, "PPH"),
            .TotalAmount = grdView.GetRowCellValue(intPos, "TotalAmount"),
            .TotalDPP = grdView.GetRowCellValue(intPos, "TotalDPP"),
            .TotalPPN = grdView.GetRowCellValue(intPos, "TotalPPN"),
            .TotalPPH = grdView.GetRowCellValue(intPos, "TotalPPH"),
            .TaxInvoiceNumber = grdView.GetRowCellValue(intPos, "TaxInvoiceNumber"),
            .InvoiceNumberExternal = grdView.GetRowCellValue(intPos, "InvoiceNumberExternal"),
            .SubmitBy = grdView.GetRowCellValue(intPos, "SubmitBy"),
            .ApprovedBy = grdView.GetRowCellValue(intPos, "ApprovedBy"),
            .IsDeleted = grdView.GetRowCellValue(intPos, "IsDeleted"),
            .Remarks = grdView.GetRowCellValue(intPos, "Remarks"),
            .StatusID = grdView.GetRowCellValue(intPos, "StatusID"),
            .CreatedBy = grdView.GetRowCellValue(intPos, "CreatedBy"),
            .CreatedDate = grdView.GetRowCellValue(intPos, "CreatedDate"),
            .LogBy = grdView.GetRowCellValue(intPos, "LogBy"),
            .LogDate = grdView.GetRowCellValue(intPos, "LogDate"),
            .LogInc = grdView.GetRowCellValue(intPos, "LogInc")
        }
    End Function

    Private Sub prvNew()
        Dim frmDetail As New frmTraARAPInvoiceDet
        With frmDetail
            .pubIsNew = True
            .pubPPNPercentage = decPPNPercentage
            .pubPPHPercentage = decPPHPercentage
            .pubParentID = strParentID
            .Text = Me.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        Dim frmDetail As New frmTraARAPInvoiceDet
        With frmDetail
            .pubID = clsData.ID
            .pubIsNew = False
            .pubPPNPercentage = decPPNPercentage
            .pubPPHPercentage = decPPHPercentage
            .pubParentID = strParentID
            .Text = Me.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID

        If Not UI.usForm.frmAskQuestion("Hapus Nomor " & clsData.InvoiceNumber & "?") Then Exit Sub

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
        Try
            BL.ARAP.DeleteDataInvoice(clsData)
            UI.usForm.frmMessageBox("Hapus data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "InvoiceNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Submit Nomor " & clsData.InvoiceNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Try
            BL.ARAP.SubmitInvoice(clsData.ID, "")
            UI.usForm.frmMessageBox("Submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "InvoiceNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvCancelSubmit()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Batal Submit Nomor " & clsData.InvoiceNumber & "?") Then Exit Sub

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
        Try
            BL.ARAP.UnsubmitInvoice(clsData.ID, clsData.Remarks)
            UI.usForm.frmMessageBox("Batal submit data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "InvoiceNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvApprove()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Approve Nomor " & clsData.InvoiceNumber & "?") Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Try
            BL.ARAP.ApproveInvoice(clsData.ID, "")
            UI.usForm.frmMessageBox("Approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "InvoiceNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvCancelApprove()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        clsData = prvGetData()
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        If Not UI.usForm.frmAskQuestion("Batal Approve Nomor " & clsData.InvoiceNumber & "?") Then Exit Sub

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
        Try
            BL.ARAP.UnapproveInvoice(clsData.ID, clsData.Remarks)
            UI.usForm.frmMessageBox("Batal approve data berhasil.")
            pubRefresh(grdView.GetRowCellValue(intPos, "InvoiceNumber"))
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvSetupTaxInvoiceNumber()
        'intPos = grdView.FocusedRowHandle
        'If intPos < 0 Then Exit Sub
        'clsData = prvGetData()

        'Dim frmDetail As New frmTraAccountSetTaxInvoiceNumber
        'With frmDetail
        '    .pubTaxInvoiceNumber = clsData.TaxInvoiceNumber
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If .pubIsSave Then
        '        clsData.TaxInvoiceNumber = .pubTaxInvoiceNumber
        '        clsData.Remarks = .pubRemarks
        '    Else
        '        Exit Sub
        '    End If
        'End With

        'Me.Cursor = Cursors.WaitCursor
        'pgMain.Value = 40

        'Try
        '    BL.ARAP.UpdateTaxInvoiceNumber(clsData.ID, clsData.TaxInvoiceNumber, clsData.Remarks, enumARAPType)
        '    pgMain.Value = 100
        '    UI.usForm.frmMessageBox("Update nomor faktur pajak berhasil.")
        '    pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'Finally
        '    Me.Cursor = Cursors.Default
        '    pgMain.Value = 100

        '    prvResetProgressBar()
        'End Try
    End Sub

    Private Sub prvSetupInvoiceNumberSupplier()
        'intPos = grdView.FocusedRowHandle
        'If intPos < 0 Then Exit Sub
        'clsData = prvGetData()

        'Dim frmDetail As New frmTraAccountSetInvoiceNumberBP
        'With frmDetail
        '    .pubInvoiceNumberSupplier = clsData.InvoiceNumberSupplier
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If .pubIsSave Then
        '        clsData.InvoiceNumberSupplier = .pubInvoiceNumberSupplier
        '        clsData.Remarks = .pubRemarks
        '    Else
        '        Exit Sub
        '    End If
        'End With

        'Me.Cursor = Cursors.WaitCursor
        'pgMain.Value = 40

        'Try
        '    BL.ARAP.UpdateInvoiceNumberSupplier(clsData.ID, clsData.InvoiceNumberSupplier, clsData.Remarks, enumARAPType)
        '    pgMain.Value = 100
        '    UI.usForm.frmMessageBox("Update nomor invoice pajak berhasil.")
        '    pubRefresh(grdView.GetRowCellValue(intPos, "TransNumber"))
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'Finally
        '    Me.Cursor = Cursors.Default
        '    pgMain.Value = 100

        '    prvResetProgressBar()
        'End Try
    End Sub

    Private Sub prvPrint()
        'intPos = grdView.FocusedRowHandle
        'If intPos < 0 Then Exit Sub
        'Dim strID As String = grdView.GetRowCellValue(intPos, "ID")
        'Me.Cursor = Cursors.WaitCursor
        'pgMain.Value = 40

        'prvGetCS()
        'clsData = prvGetData()
        Try
            '    If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
            '        Dim frmChooseBankAccount As New frmTraARAPChooseBankAccount
            '        With frmChooseBankAccount
            '            .pubID = strID
            '            .pubCompanyBankAccount1 = clsData.CompanyBankAccountID1
            '            .pubCompanyBankAccount2 = clsData.CompanyBankAccountID2
            '            .StartPosition = FormStartPosition.CenterParent
            '            .pubShowDialog(Me)
            '            If Not .pubIsSave Then Exit Sub
            '        End With
            '    End If

            '    Dim dtData As DataTable = BL.ARAP.PrintVer01(clsCS.ProgramID, intCompanyID, strID)
            '    Dim intStatusID As Integer = 0
            '    For Each dr As DataRow In dtData.Rows
            '        intStatusID = dr.Item("StatusID")
            '        Exit For
            '    Next

            '    Dim crReport As New rptProformaInvoice

            '    '# Setup Watermark Report
            '    If intStatusID <> VO.Status.Values.Approved And intStatusID <> VO.Status.Values.Payment Then
            '        crReport.Watermark.ShowBehind = False
            '        crReport.Watermark.Text = "DRAFT" & vbCrLf & "NOT OFFICIAL"
            '        crReport.Watermark.ForeColor = System.Drawing.Color.DimGray
            '        crReport.Watermark.Font = New System.Drawing.Font("Tahoma", 70.0!, System.Drawing.FontStyle.Bold)
            '        crReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal
            '        crReport.Watermark.TextTransparency = 150
            '    End If

            '    '# Set Default Value Payment
            '    crReport.InvoiceType.Value = VO.ARAP.GetPaymentTypeInitial(clsData.Modules)
            '    crReport.HeaderType.Value = IIf(clsData.PaymentBy.Trim <> "", "", "PERFORMA ") & "INVOICE"
            '    crReport.DescPayment1.Value = ""
            '    crReport.DescPayment2.Value = ""
            '    crReport.DescPayment3.Value = ""
            '    crReport.DescPayment4.Value = ""
            '    crReport.AmountPayment1.Value = 0
            '    crReport.AmountPayment2.Value = 0
            '    crReport.AmountPayment3.Value = 0
            '    crReport.AmountPayment4.Value = 0

            '    Dim dtPaymentHistory As DataTable = BL.ARAP.ListPaymentHistory(clsCS.ProgramID, intCompanyID, strReferencesID, clsData.TransDate.Date, clsData.ID)
            '    If dtPaymentHistory.Rows.Count = 0 Then
            '        Dim intValue As Decimal = CInt(dtData.Rows(0).Item("Percentage"))
            '        crReport.sbPayment1.Visible = True
            '        crReport.DescPayment1.Value = VO.ARAP.GetPaymentType(dtData.Rows(0).Item("Modules")) & " " & IIf(intValue = 0, "", intValue & "%")
            '        crReport.AmountPayment1.Value = IIf(clsData.IsDP, dtData.Rows(0).Item("DPAmount"), dtData.Rows(0).Item("GrandTotal") - dtData.Rows(0).Item("DPAmount"))
            '    End If

            '    If dtPaymentHistory.Rows.Count = 1 Then
            '        Dim intValue As Decimal = CInt(dtData.Rows(0).Item("Percentage"))
            '        crReport.sbPayment2.Visible = True
            '        crReport.DescPayment2.Value = VO.ARAP.GetPaymentType(dtData.Rows(0).Item("Modules")) & " " & IIf(intValue = 0, "", intValue & "%")
            '        crReport.AmountPayment2.Value = dtData.Rows(0).Item("GrandTotal") - dtData.Rows(0).Item("DPAmount")
            '    End If

            '    If dtPaymentHistory.Rows.Count = 2 Then
            '        Dim intValue As Decimal = CInt(dtData.Rows(0).Item("Percentage"))
            '        crReport.sbPayment3.Visible = True
            '        crReport.DescPayment3.Value = VO.ARAP.GetPaymentType(dtData.Rows(0).Item("Modules")) & " " & IIf(intValue = 0, "", intValue & "%")
            '        crReport.AmountPayment3.Value = dtData.Rows(0).Item("GrandTotal") - dtData.Rows(0).Item("DPAmount")
            '    End If

            '    If dtPaymentHistory.Rows.Count = 3 Then
            '        Dim intValue As Decimal = CInt(dtData.Rows(0).Item("Percentage"))
            '        crReport.sbPayment4.Visible = True
            '        crReport.DescPayment4.Value = VO.ARAP.GetPaymentType(dtData.Rows(0).Item("Modules")) & " " & IIf(intValue = 0, "", intValue & "%")
            '        crReport.AmountPayment4.Value = dtData.Rows(0).Item("GrandTotal") - dtData.Rows(0).Item("DPAmount")
            '    End If

            '    For i As Integer = 0 To dtPaymentHistory.Rows.Count - 1
            '        Dim strDescPayment As String = VO.Common.GetPaymentType(dtPaymentHistory.Rows(i).Item("Modules")) & IIf(dtPaymentHistory.Rows(i).Item("Percentage") > 0, " " & CInt(dtPaymentHistory.Rows(i).Item("Percentage")) & "%", "")
            '        Dim decAmountPayment As Decimal = dtData.Rows(i).Item("DPAmount")
            '        If i = 0 Then
            '            crReport.sbPayment1.Visible = True
            '            crReport.DescPayment1.Value = strDescPayment
            '            crReport.AmountPayment1.Value = decAmountPayment
            '        ElseIf i = 1 Then
            '            crReport.sbPayment2.Visible = True
            '            crReport.DescPayment2.Value = strDescPayment
            '            crReport.AmountPayment2.Value = decAmountPayment
            '        ElseIf i = 2 Then
            '            crReport.sbPayment3.Visible = True
            '            crReport.DescPayment3.Value = strDescPayment
            '            crReport.AmountPayment3.Value = decAmountPayment
            '        End If
            '    Next

            '    clsData = BL.ARAP.GetDetail(clsData.ID, enumARAPType)
            '    crReport.PaymentTerm1.Value = clsData.PaymentTerm1.Trim
            '    crReport.PaymentTerm2.Value = clsData.PaymentTerm2.Trim
            '    crReport.PaymentTerm3.Value = clsData.PaymentTerm3.Trim

            '    If clsData.PaymentTerm4.Trim <> "" Then
            '        crReport.sbPaymentTerm4.Visible = True
            '        crReport.PaymentTerm4.Value = clsData.PaymentTerm4.Trim
            '    End If

            '    If clsData.PaymentTerm5.Trim <> "" Then
            '        crReport.sbPaymentTerm5.Visible = True
            '        crReport.PaymentTerm5.Value = clsData.PaymentTerm5.Trim
            '    End If

            '    If clsData.PaymentTerm6.Trim <> "" Then
            '        crReport.sbPaymentTerm6.Visible = True
            '        crReport.PaymentTerm6.Value = clsData.PaymentTerm6.Trim
            '    End If

            '    If clsData.PaymentTerm7.Trim <> "" Then
            '        crReport.sbPaymentTerm7.Visible = True
            '        crReport.PaymentTerm7.Value = clsData.PaymentTerm7.Trim
            '    End If

            '    If clsData.PaymentTerm8.Trim <> "" Then
            '        crReport.sbPaymentTerm8.Visible = True
            '        crReport.PaymentTerm8.Value = clsData.PaymentTerm8.Trim
            '    End If

            '    If clsData.PaymentTerm9.Trim <> "" Then
            '        crReport.sbPaymentTerm9.Visible = True
            '        crReport.PaymentTerm9.Value = clsData.PaymentTerm9.Trim
            '    End If

            '    If clsData.PaymentTerm10.Trim <> "" Then
            '        crReport.sbPaymentTerm10.Visible = True
            '        crReport.PaymentTerm10.Value = clsData.PaymentTerm10.Trim
            '    End If

            '    For Each dr As DataRow In dtData.Rows
            '        If dr.Item("BankAccountName2") = "" Then crReport.sbCompanyBankAccount2.Visible = False
            '        Exit For
            '    Next

            '    crReport.DataSource = dtData
            '    crReport.CreateDocument(True)
            '    crReport.ShowPreviewMarginLines = False
            '    crReport.ShowPrintMarginsWarning = False

            '    Dim frmDetail As New frmReportPreview
            '    With frmDetail
            '        .docViewer.DocumentSource = crReport
            '        .pgExportButton.Enabled = bolExport
            '        .Text = Me.Text & " - " & VO.Reports.PrintOut
            '        .WindowState = FormWindowState.Maximized
            '        .Show()
            '    End With
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvExportExcel()
        Dim dxExporter As New DX.usDXHelper
        dxExporter.DevExport(Me, grdMain, Me.Text, Me.Text, DX.usDxExportFormat.fXls, True, True, DX.usDXExportType.etDefault)
    End Sub

#Region "Form Handle"

    Private Sub frmTraARAPInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetGrid()
        prvQuery()
        'prvUserAccess()
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
                Case ToolBar.Buttons(cSetTaxInvoiceNumber).Name : prvSetupTaxInvoiceNumber()
                Case ToolBar.Buttons(cSetInvoiceNumberBP).Name : prvSetupInvoiceNumberSupplier()
                Case ToolBar.Buttons(cPrint).Name : prvPrint()
                Case ToolBar.Buttons(cExportExcel).Name : prvExportExcel()
            End Select
        End If
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