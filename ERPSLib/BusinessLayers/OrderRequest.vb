Namespace BL

    Public Class OrderRequest

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal bolIsStock As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, bolIsStock)
            End Using
        End Function

        Public Shared Function ListDataOutstandingDelivery(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                          ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataOutstandingDelivery(sqlCon, Nothing, intProgramID, intCompanyID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataMapCO(ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataMapCO(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "OR" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.OrderRequest.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.OrderRequest) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.OrderDate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.OrderNumber.Trim = "" Then clsData.OrderNumber = clsData.ID
                    Else
                        DL.OrderRequest.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                    End If

                    Dim intStatusID As Integer = DL.OrderRequest.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di setujui")
                    ElseIf DL.OrderRequest.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.OrderRequest.DataExists(sqlCon, sqlTrans, clsData.OrderNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.OrderNumber & " sudah ada.")
                    End If

                    DL.OrderRequest.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.OrderRequestDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.OrderRequestID = clsData.ID
                        clsDet.GroupID = intCount
                        DL.OrderRequest.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        '# Calculate Stock In
                        'BL.StockIn.CalculateStockIn(sqlCon, sqlTrans, clsDet.OrderNumberSupplier, clsDet.ItemID)
                        'BL.StockOut.CalculateStockOut(sqlCon, sqlTrans, clsDet.OrderNumberSupplier, clsDet.ItemID)
                    Next

                    '# Save Data Status
                    BL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.OrderNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.OrderRequest
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Function GetDetailCO(ByVal strID As String) As VO.OrderRequestConfirmationOrder
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.GetDetailCO(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.OrderRequest.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.OrderRequest.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    DL.OrderRequest.DeleteData(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    Dim dtItem As DataTable = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, strID)

                    '# Calculate Stock In
                    For Each dr As DataRow In dtItem.Rows
                        'BL.StockIn.CalculateStockIn(sqlCon, sqlTrans, dr.Item("OrderNumberSupplier"), dr.Item("ItemID"))
                    Next

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub DeleteDataMapCO(ByVal strID As String, ByVal strTransactionNumber As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtDetail As DataTable = DL.OrderRequest.ListDataDetailCODet(sqlCon, sqlTrans, strID)
                    Dim drNextProcess() As DataRow = dtDetail.Select("DPAmount>0 OR ReceiveAmount>0")
                    If drNextProcess.Count > 0 Then
                        For Each dr As DataRow In drNextProcess
                            If dr.Item("DPAmount") > 0 Then Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah dilakukan proses pembayaran Down Payment")
                            If dr.Item("ReceiveAmount") > 0 Then Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah dilakukan proses pelunasan")
                        Next
                    End If

                    DL.OrderRequest.DeleteDataMapCO(sqlCon, sqlTrans, strID)
                    DL.OrderRequest.DeleteDataDetailCODet(sqlCon, sqlTrans, strID)

                    '# Calculate OR Quantity in Confirmation Order Detail and in Order Request Detail
                    For Each dr As DataRow In dtDetail.Rows
                        DL.OrderRequest.CalculateCOTotalUsed(sqlCon, sqlTrans, dr.Item("ORDetailID"))
                        DL.ConfirmationOrder.CalculateORTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                    Next

                    '# Save Data Status
                    BL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS DATA MAPPING - " & strTransactionNumber, ERPSLib.UI.usUserApp.UserID, strRemarks)

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
            Dim bolReturn As Boolean = False
            Dim intStatusID As Integer = DL.OrderRequest.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.OrderRequest.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.OrderRequest.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.OrderRequest.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.OrderRequest.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    ElseIf DL.OrderRequest.IsAlreadySalesContract(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dilanjutkan proses Kontrak Penjualan")
                    ElseIf DL.OrderRequest.IsAlreadyPayment(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dilanjutkan proses pembayaran")
                    End If

                    DL.OrderRequest.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub SetupIsIgnoreValidationPayment(ByVal strID As String, ByVal bolValue As Boolean, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.OrderRequest = DL.OrderRequest.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID <> VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat " & IIf(bolValue = False, "batal ", "") & "set pengiriman. Status data harus SUBMIT terlebih dahulu")
                    ElseIf DL.OrderRequest.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat " & IIf(bolValue = False, "batal ", "") & "set pengiriman. Dikarenakan data telah dihapus")
                    End If

                    Dim dtDetail As DataTable = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, strID)
                    Dim drDelivery() As DataRow = dtDetail.Select("SCWeight>0")
                    If Not bolValue And drDelivery.Length > 0 Then Err.Raise(515, "", "Data tidak dapat " & IIf(bolValue = False, "batal ", "") & "set pengiriman. Dikarenakan data telah diproses pengiriman")

                    DL.OrderRequest.SetupIsIgnoreValidationPayment(sqlCon, sqlTrans, strID, bolValue)

                    '# Save Data Status
                    BL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, strID, IIf(bolValue = False, "BATAL ", "") & "SET PENGIRIMAN", ERPSLib.UI.usUserApp.UserID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Function MapConfirmationOrder(ByVal bolNew As Boolean, ByVal clsData As VO.OrderRequestConfirmationOrder) As Boolean
            BL.Server.ServerDefault()
            Dim bolSuccess As Boolean = False
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    '# Validation
                    Dim intStatusID As Integer = DL.OrderRequest.GetStatusID(sqlCon, sqlTrans, clsData.OrderRequestID)
                    If intStatusID <> VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Submit data terlebih dahulu")
                    ElseIf DL.OrderRequest.IsDeleted(sqlCon, sqlTrans, clsData.OrderRequestID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    End If

                    '# Save Data Order Request Confirmation Order Header
                    If bolNew Then
                        clsData.ID = clsData.OrderRequestID & "-" & Format(DL.OrderRequest.GetMaxIDMapCO(sqlCon, sqlTrans, clsData.OrderRequestID) + 1, "000")
                        If clsData.TransactionNumber.Trim = "" Then clsData.TransactionNumber = clsData.ID
                    End If

                    '# Delete Detail Confirmation Order
                    Dim dtItemCO As DataTable = DL.OrderRequest.ListDataDetailCODet(sqlCon, sqlTrans, clsData.ID)
                    DL.OrderRequest.DeleteDataDetailCODet(sqlCon, sqlTrans, clsData.ID)

                    '# Calculate OR Quantity in Confirmation Order Detail and in Order Request Detail
                    For Each dr As DataRow In dtItemCO.Rows
                        DL.OrderRequest.CalculateCOTotalUsed(sqlCon, sqlTrans, dr.Item("ORDetailID"))
                        DL.ConfirmationOrder.CalculateORTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                    Next

                    Dim dtORDetail As DataTable = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, clsData.OrderRequestID)

                    '# Save Data
                    DL.OrderRequest.SaveDataMapCO(sqlCon, sqlTrans, bolNew, clsData)

                    Dim intCount As Integer = 1
                    For Each cls As VO.OrderRequestConfirmationOrderDet In clsData.Detail
                        cls.ID = clsData.ID & "-" & Format(intCount, "000")
                        cls.ParentID = clsData.ID
                        DL.OrderRequest.SaveDataDetailCODet(sqlCon, sqlTrans, cls)

                        '# Calculate OR Quantity in Confirmation Order Detail and in Order Request Detail
                        DL.OrderRequest.CalculateCOTotalUsed(sqlCon, sqlTrans, cls.ORDetailID)
                        DL.ConfirmationOrder.CalculateORTotalUsed(sqlCon, sqlTrans, cls.CODetailID)

                        '# Update Order Request Detail
                        Dim drDetailSelected() As DataRow = dtORDetail.Select("ID='" & cls.ORDetailID & "'")
                        If drDetailSelected.Count > 0 Then
                            For Each dr As DataRow In drDetailSelected
                                Dim clsDetail As New VO.OrderRequestDet
                                clsDetail.ID = cls.ORDetailID
                                clsDetail.Quantity = dr.Item("Quantity")
                                clsDetail.Weight = dr.Item("Quantity")
                                clsDetail.TotalWeight = dr.Item("TotalWeight")
                                clsDetail.UnitPrice = cls.UnitPrice
                                clsDetail.TotalPrice = dr.Item("TotalWeight") * cls.UnitPrice
                                clsDetail.RoundingWeight = dr.Item("RoundingWeight")
                                clsDetail.OrderNumberSupplier = cls.OrderNumberSupplier
                                clsDetail.UnitPriceHPP = cls.UnitPriceHPP
                                DL.OrderRequest.UpdateDetail(sqlCon, sqlTrans, clsDetail)
                                Exit For
                            Next
                        End If

                        intCount += 1
                    Next

                    '# Update Price Order Request
                    dtORDetail = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, clsData.OrderRequestID)
                    Dim clsOR As VO.OrderRequest = DL.OrderRequest.GetDetail(sqlCon, sqlTrans, clsData.OrderRequestID)
                    clsOR.TotalDPP = 0
                    For Each dr As DataRow In dtORDetail.Rows
                        clsOR.TotalDPP += dr.Item("TotalPrice")
                    Next
                    clsOR.TotalPPN = SharedLib.Math.Round(clsOR.TotalDPP * (clsOR.PPN / 100), 2)
                    clsOR.TotalPPH = SharedLib.Math.Round(clsOR.TotalDPP * (clsOR.PPH / 100), 2)
                    DL.OrderRequest.UpdatePrice(sqlCon, sqlTrans, clsOR)

                    '# Save Data Status
                    BL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, clsData.OrderRequestID, IIf(bolNew, "TAMBAH", "EDIT") & " DATA MAPPING - " & clsData.TransactionNumber, ERPSLib.UI.usUserApp.UserID, "")

                    sqlTrans.Commit()
                    bolSuccess = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolSuccess
        End Function

        Public Shared Function GetReferencesNumberBySCID(ByVal strSCID As String) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.GetReferencesNumberBySCID(sqlCon, Nothing, strSCID)
            End Using
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strOrderRequestID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataDetail(sqlCon, Nothing, strOrderRequestID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstanding(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                         ByVal intBPID As Integer, ByVal strOrderRequestID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataDetailOutstanding(sqlCon, Nothing, intProgramID, intCompanyID, intBPID, strOrderRequestID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingMapConfirmationOrder(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                             ByVal strOrderRequestID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataDetailOutstandingMapConfirmationOrder(sqlCon, Nothing, intProgramID, intCompanyID, strOrderRequestID)
            End Using
        End Function

        Public Shared Function ChangeItemIDDetail(ByVal strID As String, ByVal bolIsStock As Boolean,
                                                  ByVal intOldItemID As Integer, ByVal intNewItemID As Integer) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtDeliveryDet As New DataTable
                    Dim dtARAPItem As New DataTable

                    '# Get SC Detail
                    Dim dtSalesContractDet As DataTable = DL.SalesContract.ListDataByOrderRequestDetailID(sqlCon, sqlTrans, strID, intOldItemID)

                    For Each dr As DataRow In dtSalesContractDet.Rows
                        '# Get All Delivery Detail By SCDetailID
                        dtDeliveryDet.Merge(DL.Delivery.ListDataDetailBySCDetailID(sqlCon, sqlTrans, dr.Item("SCDetailID"), intOldItemID))

                        '# Get ARAP Item Base on SalesID in Account Receivable Detail
                        dtARAPItem.Merge(DL.ARAP.ListDataByReferencesDetailID(sqlCon, sqlTrans, dr.Item("SCDetailID"), intOldItemID))

                        '# Update ItemID Delivery Detail
                        DL.Delivery.ChangeItemIDDetail(sqlCon, sqlTrans, dr.Item("SCDetailID"), intOldItemID, intNewItemID)

                        '# Update ItemID ARAP Item
                        DL.ARAP.ChangeItemIDItem(sqlCon, sqlTrans, dr.Item("SCDetailID"), intOldItemID, intNewItemID)
                    Next

                    '# Update ItemID Sales Contract Item
                    For Each dr As DataRow In dtSalesContractDet.Rows
                        DL.SalesContract.ChangeItemIDDetail(sqlCon, sqlTrans, dr.Item("SCDetailID"), intOldItemID, intNewItemID)
                    Next

                    '# Update ItemID Order Request Detail
                    DL.OrderRequest.ChangeItemIDDetail(sqlCon, sqlTrans, strID, intNewItemID)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using

            Return bolReturn
        End Function

#End Region

#Region "Detail CO"

        Public Shared Function ListDataDetailCO(ByVal strOrderRequestID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataDetailCODet(sqlCon, Nothing, strOrderRequestID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strOrderRequestID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataStatus(sqlCon, Nothing, strOrderRequestID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strOrderRequestID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strOrderRequestID & "-" & Format(DL.OrderRequest.GetMaxIDStatus(sqlCon, sqlTrans, strOrderRequestID) + 1, "000")
            Dim clsData As New VO.OrderRequestStatus With
                {
                    .ID = strNewID,
                    .OrderRequestID = strOrderRequestID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.OrderRequest.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub


#End Region

    End Class

End Namespace
