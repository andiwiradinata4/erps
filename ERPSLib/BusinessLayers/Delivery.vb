Namespace BL
    Public Class Delivery

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "SD" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.Delivery.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Delivery) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.DeliveryDate, clsData.CompanyID, clsData.ProgramID)
                        clsData.DeliveryNumber = clsData.ID
                    Else
                        Dim dtItem As DataTable = DL.Delivery.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        Dim dtItemTransport As DataTable = DL.Delivery.ListDataDetailTransport(sqlCon, sqlTrans, clsData.ID)

                        DL.Delivery.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.Delivery.DeleteDataDetailTransport(sqlCon, sqlTrans, clsData.ID)

                        '# Revert DC Quantity
                        For Each dr As DataRow In dtItem.Rows
                            DL.SalesContract.CalculateDCTotalUsed(sqlCon, sqlTrans, dr.Item("SCDetailID"))
                        Next

                        '# Revert Done Quantity
                        For Each dr As DataRow In dtItemTransport.Rows
                            DL.PurchaseOrderTransport.CalculateDoneTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                        Next

                        Dim clsExists As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, clsData.ID)
                        If clsExists.DPAmount > 0 Or clsExists.TotalPayment > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                        End If
                    End If

                    Dim intStatusID As Integer = DL.Delivery.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.Delivery.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.Delivery.DataExists(sqlCon, sqlTrans, clsData.DeliveryNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.DeliveryNumber & " sudah ada.")
                    End If

                    DL.Delivery.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.DeliveryDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.DeliveryID = clsData.ID
                        DL.Delivery.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Detail Transport
                    intCount = 1
                    For Each clsDet As VO.DeliveryDetTransport In clsData.DetailTransport
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.DeliveryID = clsData.ID
                        DL.Delivery.SaveDataDetailTransport(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Calculate DC Quantity
                    For Each clsDet As VO.DeliveryDet In clsData.Detail
                        DL.SalesContract.CalculateDCTotalUsed(sqlCon, sqlTrans, clsDet.SCDetailID)
                    Next

                    '# Calculate Done Quantity
                    For Each clsDet As VO.DeliveryDetTransport In clsData.DetailTransport
                        DL.PurchaseOrderTransport.CalculateDoneTotalUsed(sqlCon, sqlTrans, clsDet.PODetailID)
                    Next

                    '# Save Data Status
                    BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.DeliveryNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.Delivery
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Delivery.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf DL.Delivery.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.Delivery.ListDataDetail(sqlCon, sqlTrans, strID)
                    Dim dtItemTransport As DataTable = DL.Delivery.ListDataDetailTransport(sqlCon, sqlTrans, strID)

                    DL.Delivery.DeleteData(sqlCon, sqlTrans, strID)
                    DL.Delivery.DeleteDataDetailTransport(sqlCon, sqlTrans, strID)

                    '# Revert DC Quantity
                    For Each dr As DataRow In dtItem.Rows
                        DL.SalesContract.CalculateDCTotalUsed(sqlCon, sqlTrans, dr.Item("SCDetailID"))
                    Next

                    '# Revert Done Quantity
                    For Each dr As DataRow In dtItemTransport.Rows
                        DL.PurchaseOrderTransport.CalculateDoneTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                    Next

                    '# Save Data Status
                    BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.Delivery.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf DL.Delivery.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.Delivery.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Delivery.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf DL.Delivery.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.Delivery.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Delivery.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function PrintVer00(ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.Delivery.PrintVer00(sqlCon, Nothing, intProgramID, intCompanyID, strID)
            End Using
            Return dtReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDetail(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

#End Region

#Region "Detail Transport"

        Public Shared Function ListDataDetailTransport(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDetailTransport(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataStatus(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strDeliveryID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strDeliveryID & "-" & Format(DL.Delivery.GetMaxIDStatus(sqlCon, sqlTrans, strDeliveryID) + 1, "000")
            Dim clsData As New VO.DeliveryStatus With
                {
                    .ID = strNewID,
                    .DeliveryID = strDeliveryID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.Delivery.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace