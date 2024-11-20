Namespace BL
    Public Class ConfirmationOrder

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "CO" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.ConfirmationOrder.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.ConfirmationOrder) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.CODate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.CONumber.Trim = "" Then clsData.CONumber = clsData.ID
                    Else
                        Dim dtSubItem As New DataTable
                        Dim dtItem As DataTable = DL.ConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, clsData.ID, "")
                        For Each dr As DataRow In dtItem.Rows
                            dtSubItem.Merge(DL.ConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, clsData.ID, dr.Item("ID")))
                        Next

                        DL.ConfirmationOrder.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.ConfirmationOrder.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.ID)

                        '# Revert CO Quantity
                        For Each dr As DataRow In dtItem.Rows
                            DL.PurchaseOrder.CalculateCOTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                        Next
                    End If

                    Dim intStatusID As Integer = DL.ConfirmationOrder.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.ConfirmationOrder.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.ConfirmationOrder.DataExists(sqlCon, sqlTrans, clsData.CONumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.CONumber & " sudah ada.")
                    End If

                    For Each clsDet As VO.ConfirmationOrderDet In clsData.Detail
                        Dim strValue As String = DL.ConfirmationOrder.OrderNumberSupplierExists(sqlCon, sqlTrans, clsData.ID, clsDet.OrderNumberSupplier, clsDet.ItemID)
                        If strValue.Trim <> "" Then Err.Raise(515, "", "Tidak dapat disimpan. Nomor Pesanan Pemasok " & clsDet.OrderNumberSupplier & " sudah dipakai di Nomor " & strValue & ".")
                    Next

                    DL.ConfirmationOrder.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.ConfirmationOrderDet In clsData.Detail
                        Dim prevID As String = clsDet.ID
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")

                        For Each clsDetChild As VO.ConfirmationOrderDet In clsData.Detail
                            If clsDetChild.ParentID = prevID Then clsDetChild.ParentID = clsDet.ID
                        Next

                        clsDet.COID = clsData.ID
                        DL.ConfirmationOrder.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Payment Term
                    intCount = 1
                    For Each clsDet As VO.ConfirmationOrderPaymentTerm In clsData.PaymentTerm
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.COID = clsData.ID
                        DL.ConfirmationOrder.SaveDataPaymentTerm(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Calculate CO Quantity
                    For Each clsDet As VO.ConfirmationOrderDet In clsData.Detail
                        If clsDet.ParentID = "" Then DL.PurchaseOrder.CalculateCOTotalUsed(sqlCon, sqlTrans, clsDet.PODetailID)
                    Next

                    '# Save Data Status
                    BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)
                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.CONumber
        End Function

        Public Shared Function GeneratePurchaseContract(ByVal strID As String, ByVal strContractNumber As String,
                                                        ByVal strFranco As String) As Boolean
            Dim bolReturn As Boolean
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    BL.ConfirmationOrder.GeneratePurchaseContract(sqlCon, sqlTrans, strID, strContractNumber, strFranco)
                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
                Return bolReturn
            End Using
        End Function

        Public Shared Sub GeneratePurchaseContract(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strID As String, ByVal strContractNumber As String,
                                                   ByVal strFranco As String)
            Try
                Dim dtSubItem As New DataTable
                Dim clsData As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, strID)
                Dim dtItem As DataTable = DL.ConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, strID, "")
                For Each dr As DataRow In dtItem.Rows
                    dtSubItem.Merge(DL.ConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, strID, dr.Item("ID")))
                Next

                Dim dtPaymentTerm As DataTable = DL.ConfirmationOrder.ListDataPaymentTerm(sqlCon, sqlTrans, strID)
                Dim bolNew As Boolean = IIf(clsData.PCID.Trim = "", True, False)
                Dim strPCID As String = clsData.PCID
                If bolNew Then strPCID = BL.PurchaseContract.GetNewID(sqlCon, sqlTrans, clsData.CODate, clsData.CompanyID, clsData.ProgramID)

                Dim listDetailOrder As New List(Of VO.PurchaseContractDet)
                For Each dr As DataRow In dtItem.Rows
                    listDetailOrder.Add(New ERPSLib.VO.PurchaseContractDet With
                    {
                        .ID = dr.Item("ID"),
                        .CODetailID = dr.Item("ID"),
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
                        .CODetailID = dr.Item("ID"),
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

                Dim clsContract As New VO.PurchaseContract
                clsContract = New VO.PurchaseContract With {
                    .ID = strPCID,
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .PCNumber = strContractNumber,
                    .PCDate = clsData.CODate,
                    .BPID = clsData.BPID,
                    .DeliveryPeriodFrom = clsData.DeliveryPeriodFrom,
                    .DeliveryPeriodTo = clsData.DeliveryPeriodTo,
                    .Franco = strFranco,
                    .AllowanceProduction = clsData.AllowanceProduction,
                    .PPN = clsData.PPN,
                    .PPH = clsData.PPH,
                    .TotalQuantity = clsData.TotalQuantity,
                    .TotalWeight = clsData.TotalWeight,
                    .TotalDPP = clsData.TotalDPP,
                    .TotalPPN = clsData.TotalPPN,
                    .TotalPPH = clsData.TotalPPH,
                    .RoundingManual = clsData.RoundingManual,
                    .Remarks = clsData.Remarks,
                    .StatusID = VO.Status.Values.Draft,
                    .IsAutoGenerate = True,
                    .Detail = listDetailOrder,
                    .PaymentTerm = listPaymentTerm,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .IsUseSubItem = clsData.IsUseSubItem,
                    .Save = VO.Save.Action.SaveAndSubmit,
                    .PaymentTypeID = clsData.PaymentTypeID
                }

                '# Save and Submit Purchase Contract
                BL.PurchaseContract.SaveData(sqlCon, sqlTrans, bolNew, clsContract)

                '# Approve Purchase Contract
                BL.PurchaseContract.Approve(sqlCon, sqlTrans, strPCID, clsData.Remarks)

                If bolNew Then DL.ConfirmationOrder.UpdatePCID(sqlCon, sqlTrans, clsData.ID, strPCID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByVal strID As String) As VO.ConfirmationOrder
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.ConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf DL.ConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtSubItem As New DataTable
                    Dim dtItem As DataTable = DL.ConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, strID, "")

                    DL.ConfirmationOrder.DeleteData(sqlCon, sqlTrans, strID)

                    '# Revert CO Quantity
                    For Each dr As DataRow In dtItem.Rows
                        DL.PurchaseOrder.CalculateCOTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                    Next

                    '# Save Data Status
                    BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    '# Delete Pure Contract
                    Dim clsData As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, strID)
                    DL.PurchaseContract.DeleteDataStatus(sqlCon, sqlTrans, clsData.PCID)
                    DL.PurchaseContract.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.PCID)
                    DL.PurchaseContract.DeleteDataDetail(sqlCon, sqlTrans, clsData.PCID)
                    DL.PurchaseContract.DeleteDataPure(sqlCon, sqlTrans, clsData.PCID)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Function Submit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Submit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub Submit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                 ByVal strID As String, ByVal strRemarks As String)

            Dim clsData As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, strID)
            Dim intStatusID As Integer = DL.ConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf DL.ConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.ConfirmationOrder.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

            '# Re-Generate Purchase Contract
            If clsData.PCID.Trim <> "" Then BL.ConfirmationOrder.GeneratePurchaseContract(sqlCon, sqlTrans, clsData.ID, clsData.PCNumber, clsData.Franco)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, strID)
                    Dim clsContract As VO.PurchaseContract = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsData.PCID)

                    Dim intStatusID As Integer = DL.ConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf DL.ConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    ElseIf DL.ConfirmationOrder.IsAlreadyPurchaseContract(sqlCon, sqlTrans, strID) And Not clsContract.IsAutoGenerate Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dilanjutkan proses Kontrak Pembelian")
                    ElseIf DL.ConfirmationOrder.IsAlreadySalesContract(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dilanjutkan proses Kontrak Penjualan")
                    ElseIf clsContract.DPAmount > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data Kontrak terkait sudah melakukan pembayaran DP")
                    End If

                    DL.ConfirmationOrder.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    '# Update Purchase Contract
                    If clsData.PCID <> "" Then
                        BL.PurchaseContract.Unapprove(sqlCon, sqlTrans, clsContract.ID, strRemarks)
                        BL.PurchaseContract.Unsubmit(sqlCon, sqlTrans, clsContract.ID, strRemarks)
                    End If
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Done(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, strID)
                    Dim intStatusID As Integer = DL.ConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Done Then
                        Err.Raise(515, "", "Data tidak dapat di proses Selesai. Dikarenakan status data telah SELESAI")
                    ElseIf DL.ConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
                    End If

                    DL.ConfirmationOrder.Done(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "SELESAI", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Undone(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, strID)

                    Dim intStatusID As Integer = DL.ConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di batal selesai. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.ConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.ConfirmationOrder.Undone(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SELESAI", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UpdatePaymentType(ByVal strID As String, ByVal intPaymentTypeID As Integer) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, strID)
                    Dim intStatusID As Integer = DL.ConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Done Then
                        Err.Raise(515, "", "Data tidak dapat di proses Selesai. Dikarenakan status data telah SELESAI")
                    ElseIf DL.ConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
                    End If

                    DL.ConfirmationOrder.UpdatePaymentType(sqlCon, sqlTrans, strID, intPaymentTypeID)

                    '# Save Data Status
                    BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE JENIS PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, "")

                    DL.PurchaseContract.UpdatePaymentType(sqlCon, sqlTrans, clsData.PCID, intPaymentTypeID)

                    '# Save Data Status
                    BL.PurchaseContract.SaveDataStatus(sqlCon, sqlTrans, clsData.PCID, "UPDATE JENIS PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, "")

                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strCOID As String, ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListDataDetail(sqlCon, Nothing, strCOID, strParentID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingPurchaseContract(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                         ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListDataDetailOutstandingPurchaseContract(sqlCon, Nothing, intProgramID, intCompanyID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingSalesContract(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                      ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListDataDetailOutstandingSalesContract(sqlCon, Nothing, intProgramID, intCompanyID, strParentID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingOrderRequest(ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListDataDetailOutstandingOrderRequest(sqlCon, Nothing, intProgramID, intCompanyID)
            End Using
        End Function

        Public Shared Function ListDataDeliveryAddressDetail() As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListDataDeliveryAddressDetail(sqlCon, Nothing)
            End Using
        End Function

        Public Shared Function GetDetailItem(ByVal strID As String) As VO.ConfirmationOrderDet
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.GetDetailItem(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Function UpdatePriceItem(ByVal clsData As VO.ConfirmationOrderDet) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim strReceiveNumber As String = DL.ConfirmationOrder.GetReceiveNumberByCODetailID(sqlCon, sqlTrans, clsData.ID)
                    If strReceiveNumber.Trim <> "" Then Err.Raise(515, "", "Data tidak dapat di simpan. Dikarenakan data telah diproses penerimaan nomor " & strReceiveNumber)
                    Dim strDeliveryNumber As String = DL.ConfirmationOrder.GetDeliveryNumberByCODetailID(sqlCon, sqlTrans, clsData.ID)
                    If strDeliveryNumber.Trim <> "" Then Err.Raise(515, "", "Data tidak dapat di simpan. Dikarenakan data telah diproses pengiriman nomor " & strDeliveryNumber)

                    Dim clsHelper As New DataSetHelper
                    Dim decTotalDPP As Decimal = 0
                    Dim decTotalPPN As Decimal = 0
                    Dim decTotalPPH As Decimal = 0

                    '# Update Purchase Contract Detail
                    DL.PurchaseContract.UpdatePriceItemByCODetailID(sqlCon, sqlTrans, clsData.ID, clsData.UnitPrice)
                    
                    '# Update Purchase Contract Header                    
                    Dim dtPurchaseContractDet As DataTable = DL.PurchaseContract.ListDataDetailByCODetailID(sqlCon, sqlTrans, clsData.ID)
                    Dim dtPurchaseContract As DataTable = clsHelper.SelectGroupByInto("PurchaseContract", dtPurchaseContractDet, "PCID", "", "PCID")
                    For Each dr As DataRow In dtPurchaseContract.Rows
                        Dim clsPurchaseContract As VO.PurchaseContract = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, dr.Item("PCID"))
                        Dim dtData As DataTable = DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, dr.Item("PCID"), "")
                        decTotalDPP = 0
                        decTotalPPN = 0
                        decTotalPPH = 0
                        For Each drPC As DataRow In dtData.Rows
                            decTotalDPP += drPC.Item("TotalPrice")
                        Next
                        decTotalPPN = decTotalDPP * (clsPurchaseContract.PPN / 100)
                        decTotalPPH = decTotalDPP * (clsPurchaseContract.PPH / 100)
                        DL.PurchaseContract.UpdateAmount(sqlCon, sqlTrans, dr.Item("PCID"), decTotalDPP, decTotalPPN, decTotalPPH)
                    Next

                    '# Update Sales Contract Detail
                    DL.SalesContract.UpdatePriceItemByCODetailID(sqlCon, sqlTrans, clsData.ID, clsData.UnitPrice)
                    Dim dtSalesContractDet As DataTable = DL.SalesContract.ListDataDetailByCODetailID(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtSalesContractDet.Rows
                        DL.SalesContract.UpdateDetailGroupID(sqlCon, sqlTrans, dr.Item("ID"), dr.Item("GroupID"), clsData.UnitPrice)
                    Next

                    '# Update Confirmation Order
                    DL.ConfirmationOrder.UpdatePriceItem(sqlCon, sqlTrans, clsData.ID, clsData.UnitPrice)
                    Dim clsCO As VO.ConfirmationOrder = DL.ConfirmationOrder.GetDetail(sqlCon, sqlTrans, clsData.COID)
                    Dim dtCODetail As DataTable = DL.ConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, clsData.COID, "")
                    decTotalDPP = 0
                    decTotalPPN = 0
                    decTotalPPH = 0
                    For Each dr As DataRow In dtCODetail.Rows
                        decTotalDPP += dr.Item("TotalPrice")
                    Next
                    decTotalPPN = decTotalDPP * (clsCO.PPN / 100)
                    decTotalPPH = decTotalDPP * (clsCO.PPH / 100)

                    DL.ConfirmationOrder.UpdateAmount(sqlCon, sqlTrans, clsData.COID, decTotalDPP, decTotalPPN, decTotalPPH)

                    '# Save Data Status
                    BL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, clsData.COID, "UBAH HARGA", ERPSLib.UI.usUserApp.UserID, "")

                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

#End Region

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByVal strCOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListDataPaymentTerm(sqlCon, Nothing, strCOID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strCOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationOrder.ListDataStatus(sqlCon, Nothing, strCOID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strCOID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strCOID & "-" & Format(DL.ConfirmationOrder.GetMaxIDStatus(sqlCon, sqlTrans, strCOID) + 1, "000")
            Dim clsData As New VO.ConfirmationOrderStatus With
                {
                    .ID = strNewID,
                    .COID = strCOID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.ConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace
