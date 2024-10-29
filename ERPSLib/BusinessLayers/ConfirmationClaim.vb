Namespace BL

    Public Class ConfirmationClaim

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal intClaimType As VO.ConfirmationClaim.ClaimTypeValue) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaim.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, intClaimType)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal intClaimType As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "CCP" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-" & Format(intClaimType, "00") & "-"
            strNewID &= Format(DL.ConfirmationClaim.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.ConfirmationClaim) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ConfirmationClaimDate, clsData.CompanyID, clsData.ProgramID, clsData.ClaimType)
                        If clsData.ConfirmationClaimNumber.Trim = "" Then clsData.ConfirmationClaimNumber = clsData.ID
                    Else
                        Dim dtDetail As DataTable = DL.ConfirmationClaim.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.ConfirmationClaim.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                        '# Calculate Total Used
                        For Each dr As DataRow In dtDetail.Rows
                            DL.Claim.CalculateClaimTotalUsed(sqlCon, sqlTrans, dr.Item("ClaimDetailID"))
                        Next
                    End If

                    Dim intStatusID As Integer = DL.ConfirmationClaim.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.ConfirmationClaim.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.ConfirmationClaim.DataExists(sqlCon, sqlTrans, clsData.ConfirmationClaimNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.ConfirmationClaimNumber & " sudah ada.")
                    End If

                    DL.ConfirmationClaim.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    Dim intCount As Integer = 1
                    For Each clsDet As VO.ConfirmationClaimDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.ConfirmationClaimID = clsData.ID
                        DL.ConfirmationClaim.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1

                        '# Calculate Total Used ConfirmationClaim
                        DL.Claim.CalculateClaimTotalUsed(sqlCon, sqlTrans, clsDet.ClaimDetailID)
                    Next

                    '# Save Data Status
                    BL.ConfirmationClaim.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.ConfirmationClaim
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaim.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.ConfirmationClaim = DL.ConfirmationClaim.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtDetail As DataTable = DL.ConfirmationClaim.ListDataDetail(sqlCon, sqlTrans, strID)

                    DL.ConfirmationClaim.DeleteData(sqlCon, sqlTrans, strID)

                    '# Calculate Total Used
                    For Each dr As DataRow In dtDetail.Rows
                        DL.Claim.CalculateClaimTotalUsed(sqlCon, sqlTrans, dr.Item("ClaimDetailID"))
                    Next

                    '# Save Data Status
                    BL.ConfirmationClaim.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
            Dim clsData As VO.ConfirmationClaim = DL.ConfirmationClaim.GetDetail(sqlCon, sqlTrans, strID)
            If clsData.StatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf clsData.IsDeleted Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.ConfirmationClaim.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.ConfirmationClaim.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsData As VO.ConfirmationClaim = DL.ConfirmationClaim.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf clsData.IsDeleted Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    If clsData.DPAmount > 0 Or clsData.TotalPayment > 0 Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah diproses pembayaran")
                    End If

                    DL.ConfirmationClaim.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.ConfirmationClaim.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                Dim clsData As VO.ConfirmationClaim = DL.ConfirmationClaim.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim decTotalAmount As Decimal = 0
                If ERPSLib.UI.usUserApp.JournalPost.CoAofCompensasionRevenue < 0 Then Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan Akun Pendapatan Kompensasi belum ditentukan")

                Dim clsJournalDetail As New List(Of VO.JournalDet)
                decTotalAmount += clsData.TotalDPP + clsData.RoundingManual

                If clsData.ClaimType = VO.Claim.ClaimTypeValue.Receive Then
                    '# Akun Piutang Usaha Belum ditagih -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivableOutstandingPayment,
                                             .DebitAmount = decTotalAmount,
                                             .CreditAmount = 0,
                                             .Remarks = "",
                                             .GroupID = 0,
                                             .BPID = clsData.BPID
                                         })

                    '# Akun Pendapatan Kompensasi -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofCompensasionRevenue,
                                             .DebitAmount = 0,
                                             .CreditAmount = decTotalAmount,
                                             .Remarks = "",
                                             .GroupID = 0,
                                             .BPID = clsData.BPID
                                         })
                ElseIf clsData.ClaimType = VO.Claim.ClaimTypeValue.Sales Then

                End If
                
                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = IIf(bolNew, clsData.ConfirmationClaimDate, PrevJournal.JournalDate),
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.ConfirmationClaimNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Delivery
                DL.ConfirmationClaim.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strConfirmationClaimID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaim.ListDataDetail(sqlCon, Nothing, strConfirmationClaimID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strConfirmationClaimID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ConfirmationClaim.ListDataStatus(sqlCon, Nothing, strConfirmationClaimID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strConfirmationClaimID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strConfirmationClaimID & "-" & Format(DL.ConfirmationClaim.GetMaxIDStatus(sqlCon, sqlTrans, strConfirmationClaimID) + 1, "000")
            Dim clsData As New VO.ConfirmationClaimStatus With
                {
                    .ID = strNewID,
                    .ConfirmationClaimID = strConfirmationClaimID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.ConfirmationClaim.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class

End Namespace

