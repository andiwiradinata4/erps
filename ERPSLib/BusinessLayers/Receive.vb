﻿Namespace BL
    Public Class Receive

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Receive.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function ListDataOutstandingClaim(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                        ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Receive.ListDataOutstandingClaim(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "RCV" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.Receive.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.Receive) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Dim clsDataStockIN As New List(Of VO.StockIn)
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ReceiveDate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.ReceiveNumber.Trim = "" Then clsData.ReceiveNumber = clsData.ID
                    Else
                        Dim dtItem As DataTable = DL.Receive.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.Receive.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                        For Each dr As DataRow In dtItem.Rows
                            '# Revert DC Quantity
                            DL.PurchaseContract.CalculateDCTotalUsed(sqlCon, sqlTrans, dr.Item("PCDetailID"))

                            ''# Recalculate Stock In
                            'clsDataStockIN = New List(Of VO.StockIn)
                            'clsDataStockIN.Add(New VO.StockIn With
                            '                   {
                            '                       .ProgramID = clsData.ProgramID,
                            '                       .CompanyID = clsData.CompanyID,
                            '                       .ParentID = "",
                            '                       .ParentDetailID = "",
                            '                       .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                            '                       .SourceData = dr.Item("ID"),
                            '                       .ItemID = dr.Item("ItemID"),
                            '                       .InQuantity = 0,
                            '                       .InWeight = 0,
                            '                       .InTotalWeight = 0,
                            '                       .UnitPrice = dr.Item("UnitPrice"),
                            '                       .CoAofStock = dr.Item("CoAofStock")
                            '                   })
                        Next
                        'BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)

                        Dim clsHelper As New DataSetHelper
                        Dim dtParentID As DataTable = clsHelper.SelectGroupByInto("ParentID", dtItem, "ParentID", "", "ParentID")
                        For Each dr As DataRow In dtParentID.Rows
                            '# Revert Payment Item Parent Amount
                            If dr.Item("ParentID") <> "" Then DL.PurchaseContract.CalculateDCTotalUsedParent(sqlCon, sqlTrans, dr.Item("ParentID"))
                        Next

                        Dim clsExists As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, clsData.ID)
                        If clsExists.DPAmount > 0 Or clsExists.TotalPayment > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                        End If
                    End If

                    Dim intStatusID As Integer = DL.Receive.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.Receive.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.Receive.DataExists(sqlCon, sqlTrans, clsData.ReceiveNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.ReceiveNumber & " sudah ada.")
                    End If

                    DL.Receive.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    clsDataStockIN = New List(Of VO.StockIn)
                    For Each clsDet As VO.ReceiveDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.ReceiveID = clsData.ID
                        DL.Receive.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        'clsDataStockIN.Add(New VO.StockIn With
                        '                   {
                        '                       .ProgramID = clsData.ProgramID,
                        '                       .CompanyID = clsData.CompanyID,
                        '                       .ParentID = "",
                        '                       .ParentDetailID = "",
                        '                       .OrderNumberSupplier = clsDet.OrderNumberSupplier,
                        '                       .SourceData = clsDet.ID,
                        '                       .ItemID = clsDet.ItemID,
                        '                       .InQuantity = 0,
                        '                       .InWeight = 0,
                        '                       .InTotalWeight = 0,
                        '                       .UnitPrice = clsDet.UnitPrice,
                        '                       .CoAofStock = clsData.CoAofStock
                        '                   })
                    Next

                    '# Calculate DC Quantity
                    For Each clsDet As VO.ReceiveDet In clsData.Detail
                        DL.PurchaseContract.CalculateDCTotalUsed(sqlCon, sqlTrans, clsDet.PCDetailID)
                    Next

                    Dim strParentIDExists As String = ""
                    For Each clsDet As VO.ReceiveDet In clsData.Detail
                        If strParentIDExists <> clsDet.ParentID Then
                            If clsDet.ParentID <> "" Then DL.PurchaseContract.CalculateDCTotalUsedParent(sqlCon, sqlTrans, clsDet.ParentID)
                            strParentIDExists = clsDet.ParentID
                        End If
                    Next

                    '# Save Data Status
                    BL.Receive.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    ''# Save Data Stock IN
                    'BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ReceiveNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.Receive
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Receive.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            'Dim clsDataStockIN As New List(Of VO.StockIn)
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.Receive.ListDataDetail(sqlCon, sqlTrans, strID)
                    DL.Receive.DeleteData(sqlCon, sqlTrans, strID)

                    For Each dr As DataRow In dtItem.Rows
                        '# Revert DC Quantity
                        DL.PurchaseContract.CalculateDCTotalUsed(sqlCon, sqlTrans, dr.Item("PCDetailID"))

                        ''# Recalculate Stock In
                        'clsDataStockIN = New List(Of VO.StockIn)
                        'clsDataStockIN.Add(New VO.StockIn With
                        '                   {
                        '                       .ProgramID = clsData.ProgramID,
                        '                       .CompanyID = clsData.CompanyID,
                        '                       .ParentID = "",
                        '                       .ParentDetailID = "",
                        '                       .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                        '                       .SourceData = dr.Item("ID"),
                        '                       .ItemID = dr.Item("ItemID"),
                        '                       .InQuantity = 0,
                        '                       .InWeight = 0,
                        '                       .InTotalWeight = 0,
                        '                       .UnitPrice = dr.Item("UnitPrice")
                        '                   })
                        'BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)
                    Next

                    Dim clsHelper As New DataSetHelper
                    Dim dtParentID As DataTable = clsHelper.SelectGroupByInto("ParentID", dtItem, "ParentID", "", "ParentID")
                    For Each dr As DataRow In dtParentID.Rows
                        '# Revert Payment Item Parent Amount
                        If dr.Item("ParentID") <> "" Then DL.PurchaseContract.CalculateDCTotalUsedParent(sqlCon, sqlTrans, dr.Item("ParentID"))
                    Next

                    '# Save Data Status
                    BL.Receive.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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

        Public Shared Function Submit(ByVal strAllID As List(Of String), ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    For Each strID As String In strAllID
                        Submit(sqlCon, sqlTrans, strID, strRemarks)
                    Next
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
            Dim clsData As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, strID)
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If clsData.StatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf clsData.IsDeleted Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.Receive.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.Receive.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

            GenerateJournal(sqlCon, sqlTrans, strID)

            RecalculateStockIn(sqlCon, sqlTrans, clsData)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Unsubmit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unsubmit(ByVal strAllID As List(Of String), ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    For Each strID As String In strAllID
                        Unsubmit(sqlCon, sqlTrans, strID, strRemarks)
                    Next
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub Unsubmit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                   ByVal strID As String, ByVal strRemarks As String)
            Try
                Dim clsData As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, strID)
                clsData.LogBy = ERPSLib.UI.usUserApp.UserID
                If clsData.StatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                ElseIf clsData.IsDeleted Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                ElseIf clsData.DPAmount > 0 Or clsData.TotalPayment > 0 Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses pembayaran")
                ElseIf DL.Receive.IsAlreadyClaim(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses Klaim")
                End If

                Dim dtItem As DataTable = DL.Receive.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                For Each dr As DataRow In dtItem.Rows
                    If dr.Item("OutWeight") > 0 Then Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses Pesanan Pemotongan")
                Next

                '# Cancel Approve Journal
                BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                '# Cancel Submit Journal
                BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                DL.Receive.Unsubmit(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.Receive.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                RecalculateStockIn(sqlCon, sqlTrans, clsData)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                Dim clsData As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)

                GenerateJournal(sqlCon, sqlTrans, clsData, PrevJournal)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal clsData As VO.Receive, ByVal PrevJournal As VO.Journal)
            Try
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = clsData.TotalDPP + clsData.RoundingManual ' + clsData.TotalPPN - clsData.TotalPPH
                Dim clsJournalDetail As New List(Of VO.JournalDet) From {
                    New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAofStock,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     },
                    New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableOutstandingPayment,
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
                    .JournalDate = IIf(bolNew, clsData.ReceiveDate, PrevJournal.JournalDate),
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = IIf(clsData.ReferencesNumber.Trim = "", clsData.ReceiveNumber, clsData.ReferencesNumber),
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Purchase Contract
                DL.Receive.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub RecalculateStockIn(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.Receive)
            Dim dtItem As DataTable = DL.Receive.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
            Dim clsDataStockIN As New List(Of VO.StockIn)
            For Each dr As DataRow In dtItem.Rows
                clsDataStockIN.Add(New VO.StockIn With
                   {
                       .ProgramID = clsData.ProgramID,
                       .CompanyID = clsData.CompanyID,
                       .ParentID = "",
                       .ParentDetailID = "",
                       .OrderNumberSupplier = dr.Item("OrderNumberSupplier"),
                       .SourceData = "",
                       .ItemID = dr.Item("ItemID"),
                       .InQuantity = 0,
                       .InWeight = 0,
                       .InTotalWeight = 0,
                       .UnitPrice = dr.Item("UnitPrice"),
                       .CoAofStock = dr.Item("CoAofStock")
                   })
            Next
            BL.StockIn.SaveData(sqlCon, sqlTrans, clsDataStockIN)
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strReceiveID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Receive.ListDataDetail(sqlCon, Nothing, strReceiveID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingPOCutting(ByVal intProgramID As Integer, ByVal intCompanyID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Receive.ListDataDetailOutstandingPOCutting(sqlCon, Nothing, intProgramID, intCompanyID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingClaim(ByVal strReceiveID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Receive.ListDataDetailOutstandingClaim(sqlCon, Nothing, strReceiveID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strReceiveID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Receive.ListDataStatus(sqlCon, Nothing, strReceiveID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strReceiveID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strReceiveID & "-" & Format(DL.Receive.GetMaxIDStatus(sqlCon, sqlTrans, strReceiveID) + 1, "000")
            Dim clsData As New VO.ReceiveStatus With
                {
                    .ID = strNewID,
                    .ReceiveID = strReceiveID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.Receive.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class

End Namespace