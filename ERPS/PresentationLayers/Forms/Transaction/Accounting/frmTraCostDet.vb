Imports DevExpress.XtraGrid
Public Class frmTraCostDet

#Region "Property"

    Private frmParent As frmTraCost
    Private clsData As VO.Cost
    Private dtItem As New DataTable
    Private intPos As Integer = 0
    Private bolExport As Boolean = False
    Private strID As String = ""
    Private intCoAID As Integer = 0
    Property pubID As String
    Property pubIsNew As Boolean = False
    Property pubIsSave As Boolean = False
    Property pubCS As New VO.CS

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cSave As Byte = 0, cClose As Byte = 1,
       cAdd As Byte = 0, cEdit As Byte = 1, cDelete As Byte = 2

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
        UI.usForm.SetGrid(grdItemView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "CostID", "CostID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "COAID", "CoAID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdItemView, "COACode", "Kode Akun", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "COAName", "Nama Akun", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Amount", "Harga", 180, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdItemView, "ReceiveDate", "Tanggal Terima", 180, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "InvoiceDate", "Tanggal Invoice", 180, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 200, UI.usDefGrid.gString)

        UI.usForm.SetGrid(grdStatusView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "CostID", "CostID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdStatusView, "Status", "Status", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusBy", "Oleh", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStatusView, "StatusDate", "Tanggal", 180, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStatusView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillCombo()
        Try
            UI.usForm.FillComboBox(cboStatus, BL.StatusModules.ListDataByModulesID(VO.Modules.Values.TransactionCost), "StatusID", "StatusName")
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
                clsData = New VO.Cost
                clsData = BL.Cost.GetDetail(pubID)
                strID = clsData.ID
                txtCostNumber.Text = clsData.CostNumber
                intCoAID = clsData.CoAID
                txtCoACode.Text = clsData.CoACode
                txtCoAName.Text = clsData.CoAName
                txtPaidTo.Text = clsData.PaidTo
                txtPaidAccount.Text = clsData.PaidAccount
                txtReferencesID.Text = clsData.ReferencesID
                dtpCostDate.Value = clsData.CostDate
                txtTotalAmount.Value = clsData.TotalAmount
                cboStatus.SelectedValue = clsData.StatusID
                txtRemarks.Text = clsData.Remarks
                ToolStripLogInc.Text = "Jumlah Edit : " & clsData.LogInc
                ToolStripLogBy.Text = "Dibuat Oleh : " & clsData.LogBy
                ToolStripLogDate.Text = Format(clsData.LogDate, UI.usDefCons.DateFull)

                'dtpCostDate.Enabled = False
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
        If grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Item belum diinput")
            grdItemView.Focus()
            Exit Sub
            'ElseIf txtCoACode.Text.Trim = "" Then
            '    UI.usForm.frmMessageBox("Pilih akun terlebih dahulu")
            '    tcHeader.SelectedTab = tpMain
            '    txtCoACode.Focus()
            '    Exit Sub
        ElseIf txtTotalAmount.Value <= 0 Then
            UI.usForm.frmMessageBox("Total Bayar harus lebih besar dari 0")
            tcHeader.SelectedTab = tpMain
            txtTotalAmount.Focus()
            Exit Sub
        ElseIf cboStatus.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Status kosong. Mohon untuk tutup form dan buka kembali")
            cboStatus.Focus()
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
        

        Dim clsDataDetailAll As New List(Of VO.CostDet)
        With dtItem
            For Each dr As DataRow In dtItem.Rows
                clsDataDetailAll.Add(New VO.CostDet With
                                     {
                                         .CostID = pubID,
                                         .CoAID = dr.Item("CoAID"),
                                         .Amount = dr.Item("Amount"),
                                         .Remarks = dr.Item("Remarks"),
                                         .ReceiveDate = dr.Item("ReceiveDate"),
                                         .InvoiceDate = dr.Item("InvoiceDate")
                                    })
            Next
        End With

        clsData = New VO.Cost
        clsData.ProgramID = pubCS.ProgramID
        clsData.CompanyID = pubCS.CompanyID
        clsData.ID = pubID
        clsData.CostNumber = txtCostNumber.Text.Trim
        clsData.CoAID = intCoAID
        clsData.ReferencesID = txtReferencesID.Text.Trim
        clsData.ReferencesNote = ""
        clsData.TotalAmount = txtTotalAmount.Value
        clsData.CostDate = dtpCostDate.Value
        clsData.PaidTo = txtPaidTo.Text.Trim
        clsData.PaidAccount = txtPaidAccount.Text.Trim
        clsData.StatusID = cboStatus.SelectedValue
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        clsData.Detail = clsDataDetailAll
        clsData.Save = intSave

        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        
        Try
            Dim strID As String = BL.Cost.SaveData(pubIsNew, clsData)
            UI.usForm.frmMessageBox("Data berhasil disimpan. " & vbCrLf & "Nomor : " & strID)
            pgMain.Value = 80
            frmParent.pubRefresh(strID)
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
        pubID = ""
        txtCostNumber.Text = ""
        intCoAID = 0
        txtCoACode.Text = ""
        txtCoAName.Text = ""
        txtReferencesID.Text = ""
        txtPaidTo.Text = ""
        txtPaidAccount.Text = ""
        txtTotalAmount.Value = 0
        dtpCostDate.Value = Now
        cboStatus.SelectedValue = VO.Status.Values.Draft
        txtRemarks.Text = ""
        ToolStripLogInc.Text = "Jumlah Edit : -"
        ToolStripLogBy.Text = "Dibuat Oleh : -"
        ToolStripLogDate.Text = Format(Now, UI.usDefCons.DateFull)
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
                intCoAID = .pubLUdtRow.Item("ID")
                txtCoACode.Text = .pubLUdtRow.Item("Code")
                txtCoAName.Text = .pubLUdtRow.Item("Name")
                txtReferencesID.Focus()
            End If
        End With
    End Sub

    Private Sub prvUserAccess()
        ToolBar.Buttons(cSave).Visible = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, pubCS.ProgramID, VO.Modules.Values.TransactionCost, IIf(pubIsNew, VO.Access.Values.NewAccess, VO.Access.Values.EditAccess))
        bolExport = BL.UserAccess.IsCanAccess(ERPSLib.UI.usUserApp.UserID, ERPSLib.UI.usUserApp.ProgramID, VO.Modules.Values.TransactionCost, VO.Access.Values.ExportReportAccess)
    End Sub

#Region "Item Handle"

    Private Sub prvSetButton()
        Dim bolEnabled As Boolean = IIf(grdItemView.RowCount = 0, False, True)
        With ToolBarDetail
            .Buttons(cEdit).Enabled = bolEnabled
            .Buttons(cDelete).Enabled = bolEnabled
        End With
    End Sub

    Private Sub prvQueryItem()
        Me.Cursor = Cursors.WaitCursor
        pgMain.Value = 30
        Try
            dtItem = BL.Cost.ListDataDetail(pubID)
            grdItem.DataSource = dtItem
            grdItemView.BestFitColumns()
            prvCalculate()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            pgMain.Value = 100
            prvResetProgressBar()
            prvSetButton()
        End Try
    End Sub

    Private Sub prvCalculate()
        Dim decAmount As Decimal = 0

        For Each dr As DataRow In dtItem.Rows
            decAmount += dr.Item("Amount")
        Next

        txtTotalAmount.Value = decAmount
    End Sub

    Private Sub prvAdd()
        Dim frmDetail As New frmTraCostDetItem
        With frmDetail
            .pubIsNew = True
            .pubCS = pubCS
            .pubTableParent = dtItem
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButton()
            prvCalculate()
        End With
    End Sub

    Private Sub prvEdit()
        intPos = grdItemView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        Dim frmDetail As New frmTraCostDetItem
        With frmDetail
            .pubIsNew = False
            .pubCS = pubCS
            .pubTableParent = dtItem
            .pubDatRowSelected = grdItemView.GetDataRow(intPos)
            .StartPosition = FormStartPosition.CenterScreen
            .pubShowDialog(Me)
            prvSetButton()
            prvCalculate()
        End With
    End Sub

    Private Sub prvDelete()
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
        grdItem.DataSource = dtItem
        prvCalculate()
        prvSetButton()
    End Sub

#End Region

#Region "History Handle"

    Private Sub prvQueryHistory()
        pgMain.Value = 30
        Me.Cursor = Cursors.WaitCursor
        Try
            grdStatus.DataSource = BL.Cost.ListDataStatus(pubID)
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

    Private Sub frmTraCostDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmTraCostDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        ToolBarDetail.SetIcon(Me)
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvQueryItem()
        prvQueryHistory()
        prvUserAccess()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Simpan" : prvSave()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

    Private Sub ToolBarItem_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Tambah" : prvAdd()
            Case "Edit" : prvEdit()
            Case "Hapus" : prvDelete()
        End Select
    End Sub

    Private Sub btnCoA_Click(sender As Object, e As EventArgs) Handles btnCoA.Click
        prvChooseCOA()
    End Sub

#End Region

End Class