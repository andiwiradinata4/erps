﻿Namespace BL
    Public Class BusinessPartnerARBalance

        Public Shared Function ListData(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                        ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartnerARBalance.ListData(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                   ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BusinessPartnerARBalance.ListDataOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal intBPID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strReturn As String = Format(intBPID, "0000000") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strReturn &= Format(DL.BusinessPartnerARBalance.GetMaxID(sqlCon, sqlTrans, strReturn), "000")
            Return strReturn
        End Function

        Public Shared Function SaveData(ByVal clsDataAll As List(Of VO.BusinessPartnerARBalance)) As Boolean
            BL.Server.ServerDefault()
            Dim bolReturn As Boolean = False
            Dim bolNew As Boolean = True
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Dim clsBusinessPartner As VO.BusinessPartner = DL.BusinessPartner.GetDetail(sqlCon, sqlTrans, clsDataAll.First.BPID)
                If clsBusinessPartner.JournalIDForARBalance.Trim <> "" Then bolNew = False

                Try
                    If Not bolNew Then
                        '# Delete Previous Data
                        DL.BusinessPartnerARBalance.DeleteData(sqlCon, sqlTrans, clsDataAll.First.BPID)

                        '# Cancel Approve Journal
                        BL.Journal.Unapprove(sqlCon, sqlTrans, clsBusinessPartner.JournalIDForARBalance.Trim, "")

                        '# Cancel Submit Journal
                        BL.Journal.Unsubmit(sqlCon, sqlTrans, clsBusinessPartner.JournalIDForARBalance.Trim, "")
                    End If

                    Dim decTotal As Decimal = 0, decAmount As Decimal = 0
                    Dim clsJournalDetail As New List(Of VO.JournalDet)
                    Dim strAllInvoiceNumber As String = ""
                    For Each clsData As VO.BusinessPartnerARBalance In clsDataAll
                        Dim bolNotyetPayment As Boolean = IIf(clsData.TotalPaymentDP + clsData.TotalPayment = 0, True, False)
                        If bolNotyetPayment Then clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ProgramID, clsData.CompanyID, clsData.BPID)
                        If DL.BusinessPartnerARBalance.DataExists(sqlCon, sqlTrans, clsData.ID) And bolNotyetPayment Then
                            Err.Raise(515, "", "Tidak dapat disimpan. ID " & clsData.ID & " telah digunakan")
                        End If

                        DL.BusinessPartnerARBalance.SaveData(sqlCon, sqlTrans, bolNotyetPayment, clsData)
                        decAmount = clsData.TotalDPP + clsData.TotalPPN - clsData.TotalPPH
                        decTotal += decAmount
                        clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivable,
                                                 .DebitAmount = decAmount,
                                                 .CreditAmount = 0,
                                                 .Remarks = "SETUP SALDO - " & clsData.InvoiceNumber
                                             })
                        strAllInvoiceNumber += clsData.InvoiceNumber & ", "
                    Next

                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofVentureCapital,
                                             .DebitAmount = 0,
                                             .CreditAmount = decTotal,
                                             .Remarks = "SETUP SALDO - " & strAllInvoiceNumber.Substring(0, strAllInvoiceNumber.Length - 2)
                                         })

                    Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsBusinessPartner.JournalIDForARBalance)
                    Dim clsJournal As New VO.Journal With
                        {
                            .ProgramID = clsDataAll.First.ProgramID,
                            .CompanyID = clsDataAll.First.CompanyID,
                            .ID = clsBusinessPartner.JournalIDForARBalance.Trim,
                            .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                            .ReferencesID = IIf(bolNew, "", PrevJournal.ReferencesID),
                            .JournalDate = IIf(bolNew, Now, PrevJournal.JournalDate),
                            .TotalAmount = decTotal,
                            .IsAutoGenerate = True,
                            .StatusID = VO.Status.Values.Draft,
                            .Remarks = "",
                            .LogBy = ERPSLib.UI.usUserApp.UserID,
                            .Initial = "",
                            .Detail = clsJournalDetail,
                            .Save = VO.Save.Action.SaveAndSubmit
                        }

                    '# Save Journal
                    Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                    '# Approve Journal
                    BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                    '# Update Journal ID in Business Partners
                    DL.BusinessPartner.UpdateJournalIDForARBalance(sqlCon, sqlTrans, clsDataAll.First.BPID, strJournalID)

                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

    End Class

End Namespace


