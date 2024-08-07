﻿Namespace BL
    Public Class PurchaseOrderTransport

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrderTransport.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function ListDataOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                   ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrderTransport.ListDataOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "PO" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & "C" & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.PurchaseOrderTransport.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PurchaseOrderTransport) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.PODate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.PONumber.Trim = "" Then clsData.PONumber = clsData.ID
                    Else
                        Dim dtItem As DataTable = DL.PurchaseOrderTransport.ListDataDetail(sqlCon, sqlTrans, clsData.ID)

                        DL.PurchaseOrderTransport.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.PurchaseOrder.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.ID)

                        '# Revert Transport Quantity
                        For Each dr As DataRow In dtItem.Rows
                            DL.SalesContract.CalculateTransportTotalUsed(sqlCon, sqlTrans, dr.Item("SCDetailID"))
                        Next

                        Dim clsExists As VO.PurchaseOrderTransport = DL.PurchaseOrderTransport.GetDetail(sqlCon, sqlTrans, clsData.ID)
                        If clsExists.DPAmount > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses panjar")
                        ElseIf clsExists.ReceiveAmount > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                        End If
                    End If

                    Dim intStatusID As Integer = DL.PurchaseOrderTransport.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.PurchaseOrderTransport.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.PurchaseOrderTransport.DataExists(sqlCon, sqlTrans, clsData.PONumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.PONumber & " sudah ada.")
                    End If

                    DL.PurchaseOrderTransport.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.PurchaseOrderTransportDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.POID = clsData.ID
                        DL.PurchaseOrderTransport.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Payment Term
                    intCount = 1
                    For Each clsDet As VO.PurchaseOrderPaymentTerm In clsData.PaymentTerm
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.POID = clsData.ID
                        DL.PurchaseOrder.SaveDataPaymentTerm(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Calculate Transport Quantity
                    For Each clsDet As VO.PurchaseOrderTransportDet In clsData.Detail
                        DL.SalesContract.CalculateTransportTotalUsed(sqlCon, sqlTrans, clsDet.SCDetailID)
                    Next

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.PONumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.PurchaseOrderTransport
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrderTransport.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.PurchaseOrderTransport.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.PurchaseOrderTransport.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    DL.PurchaseOrderTransport.DeleteData(sqlCon, sqlTrans, strID)

                    Dim dtItem As DataTable = DL.PurchaseOrderTransport.ListDataDetail(sqlCon, sqlTrans, strID)

                    '# Revert Transport Quantity
                    For Each dr As DataRow In dtItem.Rows
                        DL.SalesContract.CalculateTransportTotalUsed(sqlCon, sqlTrans, dr.Item("SCDetailID"))
                    Next

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
            Dim intStatusID As Integer = DL.PurchaseOrderTransport.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.PurchaseOrderTransport.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.PurchaseOrderTransport.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.PurchaseOrderTransport.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.PurchaseOrderTransport.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.PurchaseOrderTransport.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Approve(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.PurchaseOrderTransport.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf DL.PurchaseOrderTransport.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.PurchaseOrderTransport.Approve(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    'GenerateJournal(sqlCon, sqlTrans, strID)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unapprove(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.PurchaseOrderTransport.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.PurchaseOrderTransport.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    ElseIf DL.PurchaseOrderTransport.IsAlreadyDone(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dilanjutkan proses Pengiriman")
                    End If

                    'Dim clsData As VO.PurchaseOrderTransport = DL.PurchaseOrderTransport.GetDetail(sqlCon, sqlTrans, strID)

                    ''# Cancel Approve Journal
                    'BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    ''# Cancel Submit Journal
                    'BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                    DL.PurchaseOrderTransport.Unapprove(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Print(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                     ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                '# Get Data
                dtReturn = DL.PurchaseOrderTransport.Print(sqlCon, Nothing, strID)

                '# Combine Payment Terms
                Dim strPaymentTerms As String = ""
                Dim dtPaymentTerm As DataTable = DL.PurchaseOrder.ListDataPaymentTerm(sqlCon, Nothing, strID)
                For Each dr As DataRow In dtPaymentTerm.Rows
                    strPaymentTerms += CInt(dr.Item("Percentage")) & "% " & dr.Item("PaymentTypeName") & " BY: " & dr.Item("PaymentModeName") & vbCrLf
                Next

                '# Combine Delivery Period
                For Each dr As DataRow In dtReturn.Rows
                    dr.BeginEdit()
                    dr.Item("DeliveryPeriod") = Format(dr.Item("DeliveryPeriodFrom"), "MMMM") & " - " & Format(dr.Item("DeliveryPeriodTo"), "MMMM yyyy")
                    dr.Item("PODateAndCity") = dr.Item("CompanyCity") & ", " & Format(dr.Item("PODate"), "dd MMMM yyyy")
                    dr.Item("PaymentTerms") = strPaymentTerms
                    dr.EndEdit()
                Next
                dtReturn.AcceptChanges()
            End Using
            Return dtReturn
        End Function

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                Dim clsData As VO.PurchaseOrderTransport = DL.PurchaseOrderTransport.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim decTotalAmount As Decimal = clsData.TotalDPP + clsData.TotalPPN - clsData.TotalPPH + clsData.RoundingManual
                Dim clsJournalDetail As New List(Of VO.JournalDet) From {
                    New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofStock,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "PESANAN PEMBELIAN PENGIRIMAN - " & clsData.PONumber
                                     },
                    New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayable,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalAmount,
                                         .Remarks = "PESANAN PEMBELIAN PENGIRIMAN - " & clsData.PONumber
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
                        .Detail = clsJournalDetail,
                        .Save = VO.Save.Action.SaveAndSubmit
                    }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Purchase Order Transport
                DL.PurchaseOrderTransport.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strPOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrderTransport.ListDataDetail(sqlCon, Nothing, strPOID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingDelivery(ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal strSCDetailID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrderTransport.ListDataDetailOutstandingDelivery(sqlCon, Nothing, intProgramID, intCompanyID, strSCDetailID)
            End Using
        End Function

#End Region

    End Class
End Namespace