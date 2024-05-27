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

        Public Shared Function ListDataOustandingDelivery(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                          ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.OrderRequest.ListDataOutstandingDelivery(sqlCon, Nothing, intProgramID, intCompanyID, intBPID)
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
                        DL.OrderRequest.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        '# Calculate Stock In
                        BL.StockIn.CalculateStockIn(sqlCon, sqlTrans, clsDet.OrderNumberSupplier, clsDet.ItemID)
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
                        BL.StockIn.CalculateStockIn(sqlCon, sqlTrans, dr.Item("OrderNumberSupplier"), dr.Item("ItemID"))
                    Next

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
