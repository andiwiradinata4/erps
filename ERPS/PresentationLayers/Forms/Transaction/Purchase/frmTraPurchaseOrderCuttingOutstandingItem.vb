Imports DevExpress.XtraGrid
Public Class frmTraPurchaseOrderCuttingOutstandingItem

#Region "Properties"

    Private frmParent As frmTraCuttingDetItem
    Private intPos As Integer = 0
    Private clsCS As VO.CS
    Private intBPID As Integer
    Private dtData As New DataTable
    Private drLookupGet As DataRow
    Private bolIsLookupGet As Boolean = False
    Private dtParent As New DataTable
    Private strPOID As String = ""

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
        End Set
    End Property

    Public WriteOnly Property pubBPID As Integer
        Set(value As Integer)
            intBPID = value
        End Set
    End Property

    Public ReadOnly Property pubLUdtRow As DataRow
        Get
            Return drLookupGet
        End Get
    End Property

    Public ReadOnly Property pubIsLookupGet As Boolean
        Get
            Return bolIsLookupGet
        End Get
    End Property

    Public WriteOnly Property pubParentItem As DataTable
        Set(value As DataTable)
            dtParent = value
        End Set
    End Property

    Public WriteOnly Property pubPOID As String
        Set(value As String)
            strPOID = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const _
       cGet As Byte = 0, cClose As Byte = 1

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ID", "ID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "POID", "POID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "PONumber", "Nomor", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemID", "ItemID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ItemCode", "Kode Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemName", "Nama Barang", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Thick", "Tebal", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "Width", "Lebar", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "Length", "Panjang", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "ItemSpecificationID", "ItemSpecificationID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ItemSpecificationName", "Spec", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemTypeID", "ItemTypeID", 100, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "ItemTypeName", "Tipe", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "UnitPrice", "Harga", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdView, "Quantity", "Quantity", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdView, "Weight", "Weight", 100, UI.usDefGrid.gReal4Num)
        UI.usForm.SetGrid(grdView, "MaxTotalWeight", "Maks. Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "Remarks", "Keterangan", 300, UI.usDefGrid.gString)
    End Sub

    Private Sub prvSetButton()
        Dim bolEnable As Boolean = IIf(grdView.RowCount > 0, True, False)
        With ToolBar.Buttons
            .Item(cGet).Enabled = bolEnable
        End With
    End Sub

    Private Sub prvQuery()
        Me.Cursor = Cursors.WaitCursor
        Try
            dtData = BL.PurchaseOrderCutting.ListDataDetailOutstandingDone(clsCS.ProgramID, clsCS.CompanyID, intBPID, strPOID)
            For Each drParent As DataRow In dtParent.Rows
                For Each dr As DataRow In dtData.Rows
                    If drParent.Item("PODetailID") = dr.Item("ID") Then dr.Delete()
                Next
                dtData.AcceptChanges()
            Next
            grdMain.DataSource = dtData
            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            prvSetButton()
        End Try
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        drLookupGet = grdView.GetDataRow(intPos)
        bolIsLookupGet = True
        Me.Close()
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.00}")
        Dim SumTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat: {0:#,##0.00}")

        If grdView.Columns("Quantity").SummaryText.Trim = "" Then
            grdView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        End If
    End Sub

#Region "Form Handle"

    Private Sub frmTraPurchaseOrderCuttingOutstandingItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraPurchaseOrderCuttingOutstandingItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        prvSetGrid()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cGet).Name : prvGet()
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub grdView_DoubleClick(sender As Object, e As EventArgs) Handles grdView.DoubleClick
        prvGet()
    End Sub

#End Region

End Class