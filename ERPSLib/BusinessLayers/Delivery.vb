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
                        If clsData.DeliveryNumber.Trim = "" Then clsData.DeliveryNumber = clsData.ID
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

                        Dim dtDeliveryTransport As DataTable = DL.Delivery.ListDataDeliveryTransport(sqlCon, sqlTrans, clsData.ID)
                        For Each dr As DataRow In dtDeliveryTransport.Rows
                            If dr.Item("DPAmount") > 0 Or dr.Item("TotalPayment") > 0 Then
                                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data transport telah diproses pembayaran")
                            End If
                        Next

                        '# Delete Delivery Transport
                        DL.Delivery.DeleteDataDeliveryTransport(sqlCon, sqlTrans, clsData.ID)
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

                    '# Save Data Delivery Transport
                    intCount = 1
                    For Each clsDet As VO.DeliveryTransport In clsData.DeliveryTransport
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.DeliveryID = clsData.ID
                        clsDet.DeliveryNumber = clsData.DeliveryNumber
                        DL.Delivery.SaveDataDeliveryTransport(sqlCon, sqlTrans, clsDet)
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

            GenerateJournal(sqlCon, sqlTrans, strID)
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

                    Dim clsExists As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, strID)
                    If clsExists.DPAmount > 0 Or clsExists.TotalPayment > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses pembayaran")
                    End If

                    Dim dtDeliveryTransport As DataTable = DL.Delivery.ListDataDeliveryTransport(sqlCon, sqlTrans, strID)
                    For Each dr As DataRow In dtDeliveryTransport.Rows
                        If dr.Item("DPAmount") > 0 Or dr.Item("TotalPayment") > 0 Then
                            Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data transport telah diproses pembayaran")
                        End If
                    Next

                    '# Cancel Approve Journal Delivery
                    Dim clsData As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, strID)
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal Delivery
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                    '# Cancel Approve Journal Delivery Transport
                    'BL.Journal.Unapprove(clsData.JournalIDTransport.Trim, "")

                    ''# Cancel Submit Journal Delivery Transport
                    'BL.Journal.Unsubmit(clsData.JournalIDTransport.Trim, "")

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

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                Dim clsData As VO.Delivery = DL.Delivery.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = clsData.TotalDPP + clsData.RoundingManual ' + clsData.TotalPPN - clsData.TotalPPH 
                Dim clsJournalDetail As New List(Of VO.JournalDet) From {
                    New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivableOutstandingPayment,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     },
                    New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofRevenue,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalAmount,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     }
                }

                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = IIf(bolNew, Now, PrevJournal.JournalDate),
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.DeliveryNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Delivery
                DL.Delivery.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)

                ''# Delivery Transport
                'PrevJournal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalIDTransport)
                'bolNew = IIf(PrevJournal.ID = "", True, False)

                ''# Generate Journal
                'decTotalAmount = clsData.TotalDPPTransport + clsData.TotalPPNTransport - clsData.TotalPPHTransport + clsData.RoundingManualTransport
                'clsJournalDetail = New List(Of VO.JournalDet) From {
                '    New VO.JournalDet With
                '                     {
                '                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofStock,
                '                         .DebitAmount = decTotalAmount,
                '                         .CreditAmount = 0,
                '                         .Remarks = "TRANSPORT PENJUALAN - " & clsData.DeliveryNumber
                '                     },
                '    New VO.JournalDet With
                '                     {
                '                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayable,
                '                         .DebitAmount = 0,
                '                         .CreditAmount = decTotalAmount,
                '                         .Remarks = "TRANSPORT PENJUALAN - " & clsData.DeliveryNumber
                '                     }
                '}

                'clsJournal = New VO.Journal With
                '{
                '    .ProgramID = clsData.ProgramID,
                '    .CompanyID = clsData.CompanyID,
                '    .ID = PrevJournal.ID,
                '    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                '    .ReferencesID = clsData.ID,
                '    .JournalDate = IIf(bolNew, Now, PrevJournal.JournalDate),
                '    .TotalAmount = decTotalAmount,
                '    .IsAutoGenerate = True,
                '    .StatusID = VO.Status.Values.Draft,
                '    .Remarks = clsData.Remarks,
                '    .LogBy = ERPSLib.UI.usUserApp.UserID,
                '    .Initial = "",
                '    .Detail = clsJournalDetail,
                '    .Save = VO.Save.Action.SaveAndSubmit
                '}

                ''# Save Journal
                'strJournalID = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                ''# Approve Journal
                'BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                ''# Update Journal ID in Delivery
                'DL.Delivery.UpdateJournalIDTransport(sqlCon, sqlTrans, clsData.ID, strJournalID)
                'DL.Delivery.UpdateJournalIDDeliveryTransport(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDetail(sqlCon, Nothing, strDeliveryID)
            End Using
        End Function

#End Region

#Region "Delivery Transport"

        Public Shared Function ListDataDeliveryTransport(ByVal strDeliveryID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Delivery.ListDataDeliveryTransport(sqlCon, Nothing, strDeliveryID)
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