﻿Imports DevExpress.XtraGrid
Public Class frmTraPurchaseOrderCuttingDetItemOutstanding

#Region "Property"

    Private intPos As Integer = 0
    Private frmParent As frmTraPurchaseOrderCuttingDetItem
    Private clsCS As VO.CS
    Public pubLUdtRow As DataRow
    Public pubIsLookUpGet As Boolean = False
    Public pubParentItem As New DataTable

    Public WriteOnly Property pubCS As VO.CS
        Set(value As VO.CS)
            clsCS = value
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
        UI.usForm.SetGrid(grdView, "PCDetailID", "PCDetailID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ReceiveID", "ReceiveID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "ReceiveNumber", "Nomor Penerimaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ReferencesNumber", "Nomor Referensi", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "OrderNumberSupplier", "Nomor Pesanan Pemasok", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PCNumber", "Nomor Kontrak", 100, UI.usDefGrid.gString)
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
        UI.usForm.SetGrid(grdView, "TotalWeight", "Total Berat", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "TotalPrice", "Total Harga", 100, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "RoundingWeight", "RoundingWeight", 100, UI.usDefGrid.gReal2Num, False)
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
            Dim dtData As DataTable = BL.Receive.ListDataDetailOutstandingPOCutting(clsCS.ProgramID, clsCS.CompanyID)
            For Each drParent As DataRow In pubParentItem.Rows
                For Each dr As DataRow In dtData.Rows
                    If dr.Item("ID") = drParent.Item("ReceiveDetailID") Then dr.Delete()
                Next
                dtData.AcceptChanges()
            Next
            grdMain.DataSource = dtData
            prvSumGrid()
            grdView.BestFitColumns()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            Me.Close()
        Finally
            Me.Cursor = Cursors.Default
            prvSetButton()
        End Try
    End Sub

    Private Sub prvSumGrid()
        Dim SumTotalQuantity As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Total Quantity: {0:#,##0.0000}")
        Dim SumGrandTotalWeight As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "Total Berat Keseluruhan: {0:#,##0.00}")
        Dim SumTotalPrice As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Total Harga Keseluruhan: {0:#,##0.00}")

        If grdView.Columns("Quantity").SummaryText.Trim = "" Then grdView.Columns("Quantity").Summary.Add(SumTotalQuantity)
        If grdView.Columns("TotalWeight").SummaryText.Trim = "" Then grdView.Columns("TotalWeight").Summary.Add(SumGrandTotalWeight)
        If grdView.Columns("TotalPrice").SummaryText.Trim = "" Then grdView.Columns("TotalPrice").Summary.Add(SumTotalPrice)
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If intPos < 0 Then Exit Sub
        pubLUdtRow = grdView.GetDataRow(intPos)
        pubIsLookUpGet = True
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraPurchaseOrderCuttingDetItemOutstanding_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraPurchaseOrderCuttingDetItemOutstanding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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