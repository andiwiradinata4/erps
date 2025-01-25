Public Class frmTraDeliveryDetMultiItemVer01

#Region "Property"

    Private frmParent As frmTraDeliveryDet
    Private bolIsNew As Boolean = False
    Private strID As String = ""
    Private strSCDetailID As String = ""
    Private strSCID As String = ""
    Private intGroupID As Integer = 0
    Private clsCS As VO.CS
    Private dtItem As New DataTable
    Private drSelectedItem As DataRow
    Private bolIsAutoSearch As Boolean
    Private bolIsUseSubItem As Boolean
    Private intLevelItem As Integer
    Private strParentID As String
    Private bolIsStock As Boolean
    Private decUnitPrice As Decimal

    Public WriteOnly Property pubSCID As String
        Set(value As String)
            strSCID = value
        End Set
    End Property

    Public WriteOnly Property pubTableItem As DataTable
        Set(value As DataTable)
            dtItem = value
        End Set
    End Property

    Public WriteOnly Property pubDataRowSelected As DataRow
        Set(value As DataRow)
            drSelectedItem = value
        End Set
    End Property

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

    Public WriteOnly Property pubIsAutoSearch As Boolean
        Set(value As Boolean)
            bolIsAutoSearch = value
        End Set
    End Property

    Public WriteOnly Property pubIsStock As Boolean
        Set(value As Boolean)
            bolIsStock = value
        End Set
    End Property

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

#End Region

    Private Const cSave As Byte = 0, cClose As Byte = 1

    Private Sub prvChooseItem()
        If bolIsStock Then
            Dim frmDetail As New frmTraOrderRequestOutstandingDeliveryItemVer01
            With frmDetail
                .pubParentItem = dtItem
                .pubOrderRequestID = strSCID
                .pubCS = clsCS
                .StartPosition = FormStartPosition.CenterParent
                .pubShowDialog(Me)
                If .pubIsLookupGet Then
                    strSCDetailID = .pubLUdtRow.Item("ID")
                    txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                    intLevelItem = 0
                    strParentID = ""
                    decUnitPrice = .pubLUdtRow.Item("UnitPrice")
                    bolIsAutoSearch = False
                Else
                    If bolIsAutoSearch Then Me.Close()
                End If
            End With
        Else
            Dim frmDetail As New frmTraSalesContractOutstandingDeliveryItemVer01
            With frmDetail
                .pubParentItem = dtItem
                .pubSCID = strSCID
                .pubCS = clsCS
                .pubIsUseSubItem = bolIsUseSubItem
                .StartPosition = FormStartPosition.CenterParent
                .pubShowDialog(Me)
                If .pubIsLookupGet Then
                    strSCDetailID = .pubLUdtRow.Item("ID")
                    txtOrderNumberSupplier.Text = .pubLUdtRow.Item("OrderNumberSupplier")
                    intLevelItem = .pubLUdtRow.Item("LevelItem")
                    strParentID = .pubLUdtRow.Item("ParentID")
                    decUnitPrice = .pubLUdtRow.Item("UnitPrice")
                    bolIsAutoSearch = False
                Else
                    If bolIsAutoSearch Then Me.Close()
                End If
            End With
        End If
    End Sub

    Private Sub prvChooseItemCustom()
        If txtOrderNumberSupplier.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pilih nomor pesanan pemasok terlebih dahulu")
            txtOrderNumberSupplier.Focus()
            Exit Sub
        End If
        Dim frmDetail As New frmMstItem
        With frmDetail
            .pubIsLookUp = True
            .pubIsMultiselect = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                If Not UI.usForm.frmAskQuestion("Tambah barang yang sudah dipilih?") Then Exit Sub
                For Each dr As DataRow In .pubLUdtRowMulti
                    Dim drItem As DataRow = dtItem.NewRow
                    intGroupID = dtItem.Rows.Count + 1
                    With drItem
                        .BeginEdit()
                        .Item("ID") = Guid.NewGuid
                        .Item("SCDetailID") = strSCDetailID
                        .Item("OrderNumberSupplier") = txtOrderNumberSupplier.Text.Trim
                        .Item("SCNumber") = ""
                        .Item("GroupID") = intGroupID
                        .Item("ItemID") = dr.Item("ID")
                        .Item("ItemCode") = dr.Item("ItemCode")
                        .Item("ItemName") = dr.Item("ItemName")
                        .Item("Thick") = dr.Item("Thick")
                        .Item("Width") = dr.Item("Width")
                        .Item("Length") = dr.Item("Length")
                        .Item("ItemSpecificationID") = dr.Item("ItemSpecificationID")
                        .Item("ItemSpecificationName") = dr.Item("ItemSpecificationName")
                        .Item("ItemTypeID") = dr.Item("ItemTypeID")
                        .Item("ItemTypeName") = dr.Item("ItemTypeName")
                        .Item("Quantity") = 1
                        .Item("Weight") = dr.Item("Weight")
                        .Item("TotalWeight") = dr.Item("TotalWeight")
                        .Item("RoundingWeight") = 0
                        .Item("MaxTotalWeight") = dr.Item("TotalWeight")
                        .Item("UnitPrice") = decUnitPrice
                        .Item("TotalPrice") = decUnitPrice * dr.Item("TotalWeight")
                        .Item("Remarks") = ""
                        .Item("LevelItem") = intLevelItem
                        .Item("ParentID") = strParentID
                        .EndEdit()
                    End With
                    dtItem.Rows.Add(drItem)
                Next
            End If
        End With
    End Sub

#Region "Form Handle"

    Private Sub frmTraDeliveryDetMultiItemVer01_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Tutup form?") Then Me.Close()
        End If
    End Sub

    Private Sub frmTraDeliveryDetMultiItemVer01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
        If bolIsAutoSearch Then prvChooseItem()
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Name
            Case ToolBar.Buttons(cClose).Name : Me.Close()
        End Select
    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        prvChooseItem()
    End Sub

    Private Sub btnItemCustom_Click(sender As Object, e As EventArgs) Handles btnItemCustom.Click
        prvChooseItemCustom()
    End Sub

#End Region

End Class