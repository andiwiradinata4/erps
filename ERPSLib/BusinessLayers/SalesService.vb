Namespace BL
 
    Public Class SalesService

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strSelectedItemType As VO.ServiceType.Value) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesService.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strSelectedItemType)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal intServiceType As VO.ServiceType.Value) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strServiceTypeInitial As String = "SS"
            If intServiceType = VO.ServiceType.Value.Transport Then strServiceTypeInitial = "SST"
            If intServiceType = VO.ServiceType.Value.Cutting Then strServiceTypeInitial = "SSC"
            Dim strNewID As String = strServiceTypeInitial & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.SalesService.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.SalesService) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.TransDate, clsData.CompanyID, clsData.ProgramID, clsData.ServiceType)
                        If clsData.TransNumber.Trim = "" Then clsData.TransNumber = clsData.ID
                    Else
                        DL.SalesService.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                    End If
                    Dim intStatusID As Integer = DL.SalesService.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.SalesService.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.SalesService.DataExists(sqlCon, sqlTrans, clsData.TransNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.TransNumber & " sudah ada.")
                    End If

                    DL.SalesService.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    Dim intCount As Integer = 1
                    For Each cls As VO.SalesServiceDet In clsData.Detail
                        cls.ParentID = clsData.ID
                        cls.ID = clsData.ID & Format(intCount, "000")
                        DL.SalesService.SaveDataDetail(sqlCon, sqlTrans, cls)
                        intCount += 1
                    Next

                    '# Save Data Status
                    BL.SalesService.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.SalesService
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesService.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesService.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf DL.SalesService.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    DL.SalesService.DeleteData(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesService.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
            Dim intStatusID As Integer = DL.SalesService.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf DL.SalesService.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.SalesService.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.SalesService.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

            GenerateJournal(sqlCon, sqlTrans, strID)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.SalesService = DL.SalesService.GetDetail(sqlCon, sqlTrans, strID)
                    clsData.LogBy = ERPSLib.UI.usUserApp.UserID
                    If clsData.StatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                    DL.SalesService.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesService.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                Dim clsData As VO.SalesService = DL.SalesService.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0
                If ERPSLib.UI.usUserApp.JournalPost.CoAofRevenueCutting < 0 Or ERPSLib.UI.usUserApp.JournalPost.CoAofRevenueTransport < 0 Then Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan Akun Pendapatan Jasa belum ditentukan")
                Dim intCoAofRevenue As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofRevenueTransport
                Dim intCoAofAccountReceivableOutstandingPayment As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivableOutstandingPaymentTransport
                If clsData.ServiceType = VO.ServiceType.Value.Cutting Then intCoAofRevenue = ERPSLib.UI.usUserApp.JournalPost.CoAofRevenueCutting
                If clsData.ServiceType = VO.ServiceType.Value.Cutting Then intCoAofAccountReceivableOutstandingPayment = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivableOutstandingPaymentCutting

                Dim clsJournalDetail As New List(Of VO.JournalDet)
                decTotalAmount += clsData.TotalDPP + clsData.RoundingManual

                '# Akun Piutang Usaha Belum ditagih -> Debit
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = intCoAofAccountReceivableOutstandingPayment,
                                         .DebitAmount = decTotalAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                '# Akun Penjualan -> Kredit
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = intCoAofRevenue,
                                         .DebitAmount = 0,
                                         .CreditAmount = decTotalAmount,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = IIf(bolNew, clsData.TransDate, PrevJournal.JournalDate),
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.TransNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Delivery
                DL.SalesService.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesService.ListDataDetail(sqlCon, Nothing, strParentID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesService.ListDataStatus(sqlCon, Nothing, strParentID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strParentID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strParentID & "-" & Format(DL.SalesService.GetMaxIDStatus(sqlCon, sqlTrans, strParentID) + 1, "000")
            Dim clsData As New VO.SalesServiceStatus With
                {
                    .ID = strNewID,
                    .ParentID = strParentID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.SalesService.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class 

End Namespace

