Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns

Public Class frmTraARAPInvoiceDet

#Region "Properties"

    Private bolIsNew As Boolean
    Private strID As String = ""
    Private bolIsSave As Boolean
    Private decPPNPercentage As Decimal = 0
    Private decPPHPercentage As Decimal = 0
    Private intCoAID As Integer = 0
    Private clsData As New VO.ARAPInvoice
    Private strParentID As String = ""
    Private dtItem As New DataTable
    Private bolValid As Boolean = True

    Public WriteOnly Property pubIsNew As Boolean
        Set(value As Boolean)
            bolIsNew = value
        End Set
    End Property

    Public WriteOnly Property pubID As String
        Set(value As String)
            strID = value
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

    Public WriteOnly Property pubParentID As String
        Set(value As String)
            strParentID = value
        End Set
    End Property


#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cCheckAll As Byte = 0, cUncheckAll As Byte = 1

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Value.TransactionAccountingARAPInvoice), "StatusID", "StatusName")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub prvSetGrid()
        '# Item
        UI.usForm.SetGrid(grdItemView, "Pick", "Pilih", 80, UI.usDefGrid.gBoolean, True, False)
        UI.usForm.SetGrid(grdItemView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesID", "ReferencesID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ReferencesDetailID", "ReferencesDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ItemCodeExternal", "Kode Barang Eksternal", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Amount", "Total Tagihan", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPN", "PPN", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "PPH", "PPH", 150, UI.usDefGrid.gReal2Num, True, False)
        UI.usForm.SetGrid(grdItemView, "MaxPaymentAmount", "Total Maksimal Invoice", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxPPNAmount", "Total Maksimal PPN", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "MaxPPHAmount", "Total Maksimal PPH", 150, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 250, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ItemName", "Nama Barang", 250, UI.usDefGrid.gString, False)
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
        UI.usForm.SetGrid(grdStatusView, "ParentID", "ParentID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillForm()
        Me.Cursor = Cursors.WaitCursor
        prvFillCombo()
        Try
            If bolIsNew Then
                prvClear()
            Else
                clsData = New VO.ARAPInvoice
                clsData = BL.ARAP.GetDetailInvoice(strID)
                txtInvoiceNumber.Text = clsData.InvoiceNumber
                dtpInvoiceDate.Value = clsData.InvoiceDate
                intCoAID = clsData.CoAID
                txtCoACode.Text = clsData.CoACode
                txtCoAName.Text = clsData.CoAName
                txtTotalDPP.Value = clsData.TotalDPP
                txtTotalPPN.Value = clsData.TotalPPN
                txtTotalPPH.Value = clsData.TotalPPH
                txtTotalAmount.Value = clsData.TotalAmount
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                txtPPN.Value = clsData.PPN
                txtPPH.Value = clsData.PPH
                txtRounding.Value = clsData.Rounding
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvClear()
        pubID = ""
        txtInvoiceNumber.Text = ""
        dtpInvoiceDate.Value = Now
        intCoAID = 0
        txtCoACode.Text = ""
        txtCoAName.Text = ""
        txtTotalDPP.Value = 0
        txtTotalPPN.Value = 0
        txtTotalPPH.Value = 0
        txtRounding.Value = 0
        txtTotalAmount.Value = 0
        cboStatus.SelectedValue = VO.Status.Values.Draft
        txtRemarks.Text = ""
        txtPPN.Value = decPPNPercentage
        txtPPH.Value = decPPHPercentage
        txtRounding.Value = 0
    End Sub

    Private Sub prvChooseCOA()
        Dim frmDetail As New frmMstChartOfAccount
        With frmDetail
            .pubIsLookUp = True
            .pubCompanyID = ERPSLib.UI.usUserApp.CompanyID
            .pubProgramID = ERPSLib.UI.usUserApp.CompanyID
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

    Private Sub prvSave()
        ToolBar.Focus()
        If Not bolValid Then Exit Sub
        If txtTotalDPP.Value <= 0 Then
            txtTotalDPP.Focus()
            UI.usForm.frmMessageBox("Total DPP harus lebih besar dari 0")
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Simpan data?") Then Exit Sub
        Dim listItem As New List(Of VO.ARAPInvoiceItem)
        For i As Integer = 0 To grdItemView.RowCount - 1
            If Not grdItemView.GetRowCellValue(i, "Pick") Then Continue For
            listItem.Add(New VO.ARAPInvoiceItem With
                         {
                             .ReferencesDetailID = grdItemView.GetRowCellValue(i, "ReferencesDetailID"),
                             .OrderNumberSupplier = grdItemView.GetRowCellValue(i, "OrderNumberSupplier"),
                             .ItemID = grdItemView.GetRowCellValue(i, "ItemID"),
                             .Amount = grdItemView.GetRowCellValue(i, "Amount"),
                             .PPN = grdItemView.GetRowCellValue(i, "PPN"),
                             .PPH = grdItemView.GetRowCellValue(i, "PPH"),
                             .Rounding = grdItemView.GetRowCellValue(i, "Rounding"),
                             .LevelItem = grdItemView.GetRowCellValue(i, "LevelItem"),
                             .ReferencesParentID = grdItemView.GetRowCellValue(i, "ReferencesParentID")
                         })
        Next
        clsData = New VO.ARAPInvoice With
            {
                .ID = strID,
                .ParentID = strParentID,
                .InvoiceNumber = txtInvoiceNumber.Text.Trim,
                .TotalDPP = txtTotalDPP.Value,
                .TotalPPN = txtTotalPPN.Value,
                .TotalPPH = txtTotalPPH.Value,
                .TotalAmount = txtTotalAmount.Value,
                .InvoiceDate = dtpInvoiceDate.Value,
                .CoAID = intCoAID,
                .PPN = txtPPN.Value,
                .PPH = txtPPH.Value,
                .Remarks = txtRemarks.Text.Trim,
                .StatusID = cboStatus.SelectedValue,
                .ReferencesNumber = "",
                .Item = listItem,
                .LogBy = ERPSLib.UI.usUserApp.UserID,
                .Rounding = txtRounding.Value
            }

        Try
            Dim strInvoiceNumber As String = BL.ARAP.SaveDataInvoice(bolIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. Nomor Invoice " & strInvoiceNumber.Trim)
            bolIsSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
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
            Me.Cursor = Cursors.WaitCursor
            If bolIsNew Then
                dtItem = BL.ARAP.ListDataInvoiceItemWithOutstanding(strID, strParentID)
            Else
                If clsData.IsDeleted Then
                    dtItem = BL.ARAP.ListDataInvoiceItem(strID)
                Else
                    dtItem = BL.ARAP.ListDataInvoiceItemWithOutstanding(strID, strParentID)
                End If
            End If

            grdItem.DataSource = dtItem
            grdItemView.BestFitColumns()
            prvCalculate()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            prvSumGrid()
            prvSetButton()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub prvCalculate()
        Dim decDPAllocate As Decimal = 0, decAmount As Decimal = 0, decPPN As Decimal = 0, decPPH As Decimal = 0

        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Pick") Then
                    decAmount += .GetRowCellValue(i, "Amount")
                    decPPN += .GetRowCellValue(i, "PPN")
                    decPPH += .GetRowCellValue(i, "PPH")
                End If
            Next
        End With

        txtTotalDPP.Value = decAmount
        txtTotalPPN.Value = decPPN
        txtTotalPPH.Value = decPPH
        txtTotalAmount.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value + txtRounding.Value
    End Sub

    Private Sub prvChangeCheckedValue(ByVal bolValue As Boolean)
        With grdItemView
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "Pick", bolValue)
                .UpdateCurrentRow()
            Next
            .BestFitColumns()
            prvCalculate()
        End With
    End Sub

    Private Sub prvSumGrid()
        '# Item
        Dim SumTotalAmount As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Total Tagihan: {0:#,##0.00}")
        Dim SumTotalPPN As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PPN", "Total PPN: {0:#,##0.00}")
        Dim SumTotalPPH As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PPH", "Total PPH: {0:#,##0.00}")

        If grdItemView.Columns("Amount").SummaryText.Trim = "" Then
            grdItemView.Columns("Amount").Summary.Add(SumTotalAmount)
        End If

        If grdItemView.Columns("PPN").SummaryText.Trim = "" Then
            grdItemView.Columns("PPN").Summary.Add(SumTotalPPN)
        End If

        If grdItemView.Columns("PPH").SummaryText.Trim = "" Then
            grdItemView.Columns("PPH").Summary.Add(SumTotalPPH)
        End If

        If grdItemView.GroupCount > 0 Then grdItemView.ExpandAllGroups()
        grdItemView.BestFitColumns(True)
    End Sub

    Private Sub prvSetAmount(ByVal intPos As Integer)
        grdItemView.SetRowCellValue(intPos, "Amount", grdItemView.GetRowCellValue(intPos, "MaxPaymentAmount"))
        grdItemView.UpdateCurrentRow()
        prvSetPPNPPH(intPos)
    End Sub

    Private Sub prvSetPPNPPH(ByVal intPos As Integer)
        Dim decPPN As Decimal = 0, decPPH As Decimal = 0
        If grdItemView.GetRowCellValue(intPos, "Amount") > 0 And txtPPN.Value > 0 Then decPPN = ERPSLib.SharedLib.Math.Round(grdItemView.GetRowCellValue(intPos, "Amount") * txtPPN.Value / 100, 2)
        If grdItemView.GetRowCellValue(intPos, "Amount") > 0 And txtPPH.Value > 0 Then decPPN = ERPSLib.SharedLib.Math.Round(grdItemView.GetRowCellValue(intPos, "Amount") * txtPPH.Value / 100, 2)
        grdItemView.SetRowCellValue(intPos, "PPN", IIf(decPPN > grdItemView.GetRowCellValue(intPos, "MaxPPNAmount"), grdItemView.GetRowCellValue(intPos, "MaxPPNAmount"), decPPN))
        grdItemView.SetRowCellValue(intPos, "PPH", IIf(decPPH > grdItemView.GetRowCellValue(intPos, "MaxPPHAmount"), grdItemView.GetRowCellValue(intPos, "MaxPPHAmount"), decPPH))
        grdItemView.UpdateCurrentRow()
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        Me.Cursor = Cursors.WaitCursor
        Try
            grdStatus.DataSource = BL.ARAP.ListDataInvoiceStatus(strID)
            grdStatusView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub frmTraARAPInvoiceDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            tcMain.SelectedTab = tpMain
        ElseIf e.KeyCode = Keys.F2 Then
            tcMain.SelectedTab = tpHistory
        ElseIf (e.Control And e.KeyCode = Keys.S) Then
            prvSave()
        End If
    End Sub

    Private Sub frmTraARAPInvoiceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvFillForm()
        prvSetGrid()
        prvQueryItem()
        prvQueryHistory()
        AddHandler txtTotalAmount.ValueChanged, AddressOf txtTotalAmount_ValueChanged
        AddHandler txtTotalDPP.ValueChanged, AddressOf txtTotalDPP_ValueChanged
        AddHandler txtTotalPPN.ValueChanged, AddressOf txtTotalPPN_ValueChanged
        AddHandler txtTotalPPH.ValueChanged, AddressOf txtTotalPPH_ValueChanged
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

    Private Sub btnCoA_Click(sender As Object, e As EventArgs) Handles btnCoA.Click
        prvChooseCOA()
    End Sub

    Private Sub txtTotalAmount_ValueChanged(sender As Object, e As EventArgs)
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then Exit Sub
        'If txtPPN.Value > 0 Then
        '    txtTotalDPP.Value = txtTotalAmount.Value / (1 + (txtPPN.Value / 100))
        '    txtTotalPPN.Value = txtTotalDPP.Value * txtPPN.Value / 100
        'Else
        '    txtTotalDPP.Value = txtTotalAmount.Value
        '    txtTotalPPN.Value = 0
        'End If
    End Sub

    Private Sub txtTotalDPP_ValueChanged(sender As Object, e As EventArgs)
        If Not chkChangeTotalDPP.Checked Then Exit Sub
        prvCalculate()
    End Sub

    Private Sub txtTotalPPN_ValueChanged(sender As Object, e As EventArgs)
        If Not chkChangeTotalPPN.Checked Then Exit Sub
        prvCalculate()
    End Sub

    Private Sub txtTotalPPH_ValueChanged(sender As Object, e As EventArgs)
        If Not chkChangeTotalPPH.Checked Then Exit Sub
        prvCalculate()
    End Sub

    Private Sub chkChangeTotalDPP_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeTotalDPP.CheckedChanged
        If chkChangeTotalDPP.Checked Then
            txtTotalDPP.BackColor = System.Drawing.Color.White
            txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Else
            txtTotalDPP.BackColor = System.Drawing.Color.LightYellow
            txtTotalAmount.BackColor = System.Drawing.Color.White
        End If
        txtTotalDPP.Enabled = chkChangeTotalDPP.Checked
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then txtTotalAmount.Enabled = False Else txtTotalAmount.Enabled = True
    End Sub

    Private Sub chkChangeTotalPPN_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeTotalPPN.CheckedChanged
        If chkChangeTotalPPN.Checked Then
            txtTotalPPN.BackColor = System.Drawing.Color.White
            txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Else
            txtTotalPPN.BackColor = System.Drawing.Color.LightYellow
            txtTotalAmount.BackColor = System.Drawing.Color.White
        End If
        txtTotalPPN.Enabled = chkChangeTotalPPN.Checked
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then txtTotalAmount.Enabled = False Else txtTotalAmount.Enabled = True
    End Sub

    Private Sub chkChangeTotalPPH_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeTotalPPH.CheckedChanged
        If chkChangeTotalPPH.Checked Then
            txtTotalPPH.BackColor = System.Drawing.Color.White
            txtTotalAmount.BackColor = System.Drawing.Color.LightYellow
        Else
            txtTotalPPH.BackColor = System.Drawing.Color.LightYellow
            txtTotalAmount.BackColor = System.Drawing.Color.White
        End If
        txtTotalPPH.Enabled = chkChangeTotalPPH.Checked
        If chkChangeTotalDPP.Checked Or chkChangeTotalPPN.Checked Or chkChangeTotalPPH.Checked Then txtTotalAmount.Enabled = False Else txtTotalAmount.Enabled = True
    End Sub

    Private Sub grdItemView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles grdItemView.ValidatingEditor
        With grdItemView
            bolValid = True
            Dim col As GridColumn = .FocusedColumn
            Dim intFocus As Integer = .FocusedRowHandle
            If col.Name = "Amount" Or col.Name = "PPN" Or col.Name = "PPH" Then
                Dim oldValue As Decimal = IIf(.GetFocusedRowCellValue(col).Equals(DBNull.Value), 0, .GetFocusedRowCellValue(col))
                Dim newValue As Decimal = IIf((e.Value = "") Or (e.Value.Equals(DBNull.Value) Or (e.Value = ".")), 0, e.Value)

                Dim strErrorMessage As String = ""
                If newValue > 0 And newValue > .GetFocusedRowCellValue("MaxPaymentAmount") And col.Name = "Amount" Then
                    bolValid = False
                    strErrorMessage = "Total invoice tidak boleh lebih besar dari total maksimal invoice"
                    UI.usForm.frmMessageBox(strErrorMessage)
                ElseIf newValue > 0 And newValue > .GetFocusedRowCellValue("MaxPPNAmount") And col.Name = "PPN" Then
                    bolValid = False
                    strErrorMessage = "Total PPN tidak boleh lebih besar dari total maksimal PPN"
                    UI.usForm.frmMessageBox(strErrorMessage)
                ElseIf newValue > 0 And newValue > .GetFocusedRowCellValue("MaxPPHAmount") And col.Name = "PPH" Then
                    bolValid = False
                    strErrorMessage = "Total PPH tidak boleh lebih besar dari total maksimal PPH"
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
                    If col.Name = "Amount" Then prvSetPPNPPH(intFocus)
                    prvCalculate()
                End If
            ElseIf col.Name = "Pick" Then
                .SetRowCellValue(intFocus, col.Name, e.Value)
                .UpdateCurrentRow()
                prvSetAmount(intFocus)
                prvCalculate()
            End If
        End With
    End Sub

    Private Sub txtRounding_ValueChanged(sender As Object, e As EventArgs) Handles txtRounding.ValueChanged
        txtTotalAmount.Value = txtTotalDPP.Value + txtTotalPPN.Value - txtTotalPPH.Value + txtRounding.Value
    End Sub

#End Region

End Class