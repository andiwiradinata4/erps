Namespace BL
    Public Class Journal

#Region "Main"

        Public Shared Function ListData(ByVal intCompanyID As Integer, ByVal intProgramID As Integer, _
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intIDStatus As Integer, _
                                        ByVal strInitial As String) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Journal.ListData(sqlCon, Nothing, intCompanyID, intProgramID, dtmDateFrom, dtmDateTo, intIDStatus, strInitial)
            End Using
        End Function

        Public Shared Function ListDataSyncJournal(ByVal intCompanyID As Integer, ByVal intProgramID As Integer, _
                                                   ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            dtmDateTo = dtmDateTo.AddHours(23).AddMinutes(59).AddSeconds(59)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Journal.ListDataSyncJournal(sqlCon, Nothing, intCompanyID, intProgramID, dtmDateFrom, dtmDateTo)
            End Using
        End Function

        Public Shared Function ListDataInitial(ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Journal.ListDataInitial(sqlCon, Nothing, intCompanyID, intProgramID)
            End Using
        End Function

        Private Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal intCompanyID As Integer, ByVal bolIsAutoGenerated As Boolean,
                                         ByVal intProgramID As Integer, ByVal dtmDate As DateTime)
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strReturn As String = IIf(bolIsAutoGenerated, "JA", "JT") & Format(dtmDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strReturn = strReturn & Format(DL.Journal.GetMaxID(sqlCon, sqlTrans, strReturn), "000")
            Return strReturn
        End Function

        Private Shared Function GetNewJournalNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal intCompanyID As Integer, ByVal dtmDate As DateTime,
                                                ByVal strInitial As String)
            If strInitial.Trim = "" Then
                Err.Raise(515, "", "Inisial kosong")
            End If
            Dim strReturn As String = strInitial & "-" & Format(dtmDate, "yyMM")
            strReturn = strReturn & Format(DL.Journal.GetMaxJournalNo(sqlCon, sqlTrans, strReturn), "0000")
            Return strReturn
        End Function

        Public Shared Function SaveDataDefault(ByVal bolNew As Boolean, ByVal clsData As VO.Journal) As String
            Dim strReturn As String = ""
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    strReturn = SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using

            Return strReturn
        End Function

        Public Shared Function SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal bolNew As Boolean, ByRef clsData As VO.Journal) As String
            If bolNew Then
                clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.CompanyID, clsData.IsAutoGenerate, clsData.ProgramID, clsData.JournalDate)
                clsData.JournalNo = clsData.ID
            Else
                DL.Journal.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
            End If

            Dim intStatusID As Integer = DL.Journal.GetStatusID(sqlCon, sqlTrans, clsData.ID)
            If intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
            ElseIf intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
            ElseIf DL.Journal.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
            ElseIf DL.Journal.IsClosedPeriod(sqlCon, sqlTrans, clsData.ID) Then
                Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses tutup periode")
            ElseIf DL.Journal.DataExistsNo(sqlCon, sqlTrans, clsData.JournalNo, clsData.ID) Then
                Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.JournalNo & " sudah ada.")
            End If

            DL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsData)

            '# Save Data Detail
            Dim intCount As Integer = 1
            For Each clsDetail As VO.JournalDet In clsData.Detail
                clsDetail.ID = clsData.ID & "-" & Format(intCount, "000")
                clsDetail.JournalID = clsData.ID
                DL.Journal.SaveDataDetail(sqlCon, sqlTrans, clsDetail)
                intCount += 1
            Next

            '# Save Data Status
            SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

            If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.Journal
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Journal.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteDataDefault(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DeleteData(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String, ByVal strRemarks As String)

            Dim intStatusID As Integer = DL.Journal.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
            ElseIf DL.Journal.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
            End If

            '# Delete Journal
            DL.Journal.DeleteData(sqlCon, sqlTrans, strID)

            '# Save Data Status
            SaveDataStatus(sqlCon, sqlTrans, strID, "DIHAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Sub DeleteDataPure(ByVal clsDataAll() As VO.Journal)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    For Each clsData In clsDataAll
                        DeleteDataPure(sqlCon, sqlTrans, clsData.ID)
                    Next
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub DeleteDataPure(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String)
            '# Delete Journal
            DL.Journal.DeleteDataPure(sqlCon, sqlTrans, strID)

            '# Delete Journal Detail
            DL.Journal.DeleteDataDetail(sqlCon, sqlTrans, strID)

            '# Delete Journal Status
            DL.Journal.DeleteDataStatus(sqlCon, sqlTrans, strID)
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
            Dim intStatusID As Integer = DL.Journal.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.Journal.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.Journal.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.Journal.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.Journal.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.Journal.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.Journal.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Journal.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                    Dim intStatusID As Integer = DL.Journal.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf DL.Journal.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.Journal.Approve(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Journal.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    '# Generate Buku Besar
                    Dim clsData As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, strID)
                    GenerateBukuBesar(sqlCon, sqlTrans, clsData)

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
                    Dim intStatusID As Integer = DL.Journal.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.Journal.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.Journal.Unapprove(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.Journal.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    '# Delete Buku Besar
                    DL.BukuBesar.DeleteDataByRefrencesID(sqlCon, sqlTrans, strID)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub GenerateBukuBesar(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal clsData As VO.Journal)
            Dim dtDetail As DataTable = DL.Journal.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
            Dim drParent() As DataRow = Nothing
            Dim drChild() As DataRow = Nothing
            Dim drDebit() As DataRow = dtDetail.Select("DebitAmount>0")
            Dim drCredit() As DataRow = dtDetail.Select("CreditAmount>0")
            If drDebit.Length = 1 Then
                drParent = drDebit
                drChild = drCredit
            Else
                drParent = drCredit
                drChild = drDebit
            End If

            '# Save Buku Besar
            Dim clsBukuBesarAll As New List(Of VO.BukuBesar)
            For Each drP As DataRow In drParent
                For Each drC As DataRow In drChild
                    '# Parent 
                    BL.BukuBesar.SaveData(sqlCon, sqlTrans, New VO.BukuBesar With
                        {
                            .CompanyID = clsData.CompanyID,
                            .ProgramID = clsData.ProgramID,
                            .ReferencesID = clsData.ID,
                            .TransactionDate = clsData.JournalDate,
                            .COAIDParent = drP.Item("CoAID"),
                            .COAIDChild = drC.Item("CoAID"),
                            .DebitAmount = drC.Item("CreditAmount"),
                            .CreditAmount = 0,
                            .Remarks = drC.Item("CoAName"),
                            .LogBy = ERPSLib.UI.usUserApp.UserID,
                            .ReferencesNo = drP.Item("JournalNo")
                        }
                    )

                    '# Child
                    BL.BukuBesar.SaveData(sqlCon, sqlTrans, New VO.BukuBesar With
                        {
                            .CompanyID = clsData.CompanyID,
                            .ProgramID = clsData.ProgramID,
                            .ReferencesID = clsData.ID,
                            .TransactionDate = clsData.JournalDate,
                            .COAIDParent = drC.Item("CoAID"),
                            .COAIDChild = drP.Item("CoAID"),
                            .DebitAmount = 0,
                            .CreditAmount = drC.Item("CreditAmount"),
                            .Remarks = drP.Item("CoAName"),
                            .LogBy = ERPSLib.UI.usUserApp.UserID,
                            .ReferencesNo = drC.Item("JournalNo")
                        }
                    )
                Next
            Next
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strJournalID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Journal.ListDataDetail(sqlCon, Nothing, strJournalID)
            End Using


        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strJournalID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.Journal.ListDataStatus(sqlCon, Nothing, strJournalID)
            End Using
        End Function

        Private Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strJournalID As String, ByVal strStatus As String,
                                          ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim clsData As New VO.JournalStatus
            clsData.ID = strJournalID & "-" & Format(DL.Journal.GetMaxIDStatus(sqlCon, sqlTrans, strJournalID), "000")
            clsData.JournalID = strJournalID
            clsData.Status = strStatus
            clsData.StatusBy = strStatusBy
            clsData.StatusDate = Now
            clsData.Remarks = strRemarks
            DL.Journal.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class

End Namespace
