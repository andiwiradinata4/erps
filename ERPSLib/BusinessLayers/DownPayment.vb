Namespace BL
    Public Class DownPayment

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String,
                                        ByVal enumDPType As VO.DownPayment.DPTypeValue,
                                        ByVal intBPID As Integer, ByVal strReferencesID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                    Return DL.AccountReceivable.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strModules, intBPID, strReferencesID)
                Else
                    Return DL.AccountPayable.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strModules, intBPID, strReferencesID)
                End If
            End Using
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsDataDP As VO.DownPayment) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If clsDataDP.DPType = VO.DownPayment.DPTypeValue.Sales Then
                        Dim clsReferences As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataDP.ReferencesID)
                        If clsReferences.StatusID <> VO.Status.Values.Approved Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        End If
                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountReceivableDet)
                        clsDet.Add(New VO.AccountReceivableDet With
                                    {
                                        .ID = "",
                                        .ARID = "",
                                        .SalesID = clsDataDP.ReferencesID,
                                        .Amount = clsDataDP.TotalAmount,
                                        .Remarks = clsDataDP.Remarks
                                    })

                        '# Save Data Header
                        Dim clsData As New VO.AccountReceivable
                        clsData.ID = clsDataDP.ID
                        clsData.ProgramID = clsDataDP.ProgramID
                        clsData.CompanyID = clsDataDP.CompanyID
                        clsData.ARNumber = clsDataDP.DPNumber
                        clsData.BPID = clsDataDP.BPID
                        clsData.CoAIDOfIncomePayment = clsDataDP.CoAID
                        clsData.ReferencesID = clsReferences.SCNumber
                        clsData.ReferencesNote = ""
                        clsData.TotalAmount = clsDataDP.TotalAmount
                        clsData.Percentage = clsDataDP.Percentage
                        clsData.ARDate = clsDataDP.DPDate
                        clsData.Modules = clsDataDP.Modules
                        clsData.Remarks = clsDataDP.Remarks
                        clsData.StatusID = clsDataDP.StatusID
                        clsData.Detail = clsDet
                        clsData.LogBy = clsDataDP.LogBy
                        clsData.Save = clsDataDP.Save

                        BL.AccountReceivable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                        clsReferences = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataDP.ReferencesID)
                        If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.GrandTotal Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Grand Total Transaksi")
                        End If
                    Else
                        Dim clsReferences As VO.PurchaseContract = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataDP.ReferencesID)
                        If clsReferences.StatusID <> VO.Status.Values.Approved Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        End If
                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountPayableDet)
                        clsDet.Add(New VO.AccountPayableDet With
                                    {
                                        .ID = "",
                                        .APID = "",
                                        .PurchaseID = clsDataDP.ReferencesID,
                                        .Amount = clsDataDP.TotalAmount,
                                        .Remarks = clsDataDP.Remarks
                                    })

                        '# Save Data Header
                        Dim clsData As New VO.AccountPayable
                        clsData.ID = clsDataDP.ID
                        clsData.ProgramID = clsDataDP.ProgramID
                        clsData.CompanyID = clsDataDP.CompanyID
                        clsData.APNumber = clsDataDP.DPNumber
                        clsData.BPID = clsDataDP.BPID
                        clsData.CoAIDOfOutgoingPayment = clsDataDP.CoAID
                        clsData.ReferencesID = clsReferences.PCNumber
                        clsData.ReferencesNote = ""
                        clsData.TotalAmount = clsDataDP.TotalAmount
                        clsData.Percentage = clsDataDP.Percentage
                        clsData.APDate = clsDataDP.DPDate
                        clsData.Modules = clsDataDP.Modules
                        clsData.Remarks = clsDataDP.Remarks
                        clsData.StatusID = clsDataDP.StatusID
                        clsData.Detail = clsDet
                        clsData.LogBy = clsDataDP.LogBy
                        clsData.Save = clsDataDP.Save

                        BL.AccountPayable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                        clsReferences = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataDP.ReferencesID)
                        If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.GrandTotal Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Grand Total Transaksi")
                        End If
                    End If

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsDataDP.DPNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String, ByVal enumDPType As VO.DownPayment.DPTypeValue) As VO.DownPayment
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                    Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, Nothing, strID)
                    Dim clsReturn As New VO.DownPayment
                    clsReturn.ID = clsData.ID
                    clsReturn.CompanyID = clsData.CompanyID
                    clsReturn.ProgramID = clsData.ProgramID
                    clsReturn.DPNumber = clsData.ARNumber
                    clsReturn.BPID = clsData.BPID
                    clsReturn.BPCode = clsData.BPCode
                    clsReturn.BPName = clsData.BPName
                    clsReturn.CoAID = clsData.CoAIDOfIncomePayment
                    clsReturn.CoACode = clsData.CoACodeOfIncomePayment
                    clsReturn.CoAName = clsData.CoANameOfIncomePayment
                    clsReturn.Modules = clsData.Modules
                    clsReturn.ReferencesID = clsData.ReferencesID
                    clsReturn.ReferencesNote = clsData.ReferencesNote
                    clsReturn.DPDate = clsData.ARDate
                    clsReturn.TotalAmount = clsData.TotalAmount
                    clsReturn.Percentage = clsData.Percentage
                    clsReturn.JournalID = clsData.JournalID
                    clsReturn.SubmitBy = clsData.SubmitBy
                    clsReturn.SubmitDate = clsData.SubmitDate
                    clsReturn.ApproveL1 = clsData.ApproveL1
                    clsReturn.ApproveL1Date = clsData.ApproveL1Date
                    clsReturn.ApprovedBy = clsData.ApprovedBy
                    clsReturn.ApprovedDate = clsData.ApprovedDate
                    clsReturn.PaymentBy = clsData.PaymentBy
                    clsReturn.PaymentDate = clsData.PaymentDate
                    clsReturn.TaxInvoiceNumber = clsData.TaxInvoiceNumber
                    clsReturn.IsClosedPeriod = clsData.IsClosedPeriod
                    clsReturn.ClosedPeriodBy = clsData.ClosedPeriodBy
                    clsReturn.ClosedPeriodDate = clsData.ClosedPeriodDate
                    clsReturn.IsDeleted = clsData.IsDeleted
                    clsReturn.Remarks = clsData.Remarks
                    clsReturn.StatusID = clsData.StatusID
                    clsReturn.CreatedBy = clsData.CreatedBy
                    clsReturn.CreatedDate = clsData.CreatedDate
                    clsReturn.LogInc = clsData.LogInc
                    clsReturn.LogBy = clsData.LogBy
                    clsReturn.LogDate = clsData.LogDate
                    Return clsReturn
                Else
                    Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, Nothing, strID)
                    Dim clsReturn As New VO.DownPayment
                    clsReturn.ID = clsData.ID
                    clsReturn.CompanyID = clsData.CompanyID
                    clsReturn.ProgramID = clsData.ProgramID
                    clsReturn.DPNumber = clsData.APNumber
                    clsReturn.BPID = clsData.BPID
                    clsReturn.BPCode = clsData.BPCode
                    clsReturn.BPName = clsData.BPName
                    clsReturn.CoAID = clsData.CoAIDOfOutgoingPayment
                    clsReturn.CoACode = clsData.CoACodeOfOutgoingPayment
                    clsReturn.CoAName = clsData.CoANameOfOutgoingPayment
                    clsReturn.Modules = clsData.Modules
                    clsReturn.ReferencesID = clsData.ReferencesID
                    clsReturn.ReferencesNote = clsData.ReferencesNote
                    clsReturn.DPDate = clsData.APDate
                    clsReturn.TotalAmount = clsData.TotalAmount
                    clsReturn.Percentage = clsData.Percentage
                    clsReturn.JournalID = clsData.JournalID
                    clsReturn.SubmitBy = clsData.SubmitBy
                    clsReturn.SubmitDate = clsData.SubmitDate
                    clsReturn.ApproveL1 = clsData.ApproveL1
                    clsReturn.ApproveL1Date = clsData.ApproveL1Date
                    clsReturn.ApprovedBy = clsData.ApprovedBy
                    clsReturn.ApprovedDate = clsData.ApprovedDate
                    clsReturn.PaymentBy = clsData.PaymentBy
                    clsReturn.PaymentDate = clsData.PaymentDate
                    clsReturn.TaxInvoiceNumber = clsData.TaxInvoiceNumber
                    clsReturn.IsClosedPeriod = clsData.IsClosedPeriod
                    clsReturn.ClosedPeriodBy = clsData.ClosedPeriodBy
                    clsReturn.ClosedPeriodDate = clsData.ClosedPeriodDate
                    clsReturn.IsDeleted = clsData.IsDeleted
                    clsReturn.Remarks = clsData.Remarks
                    clsReturn.StatusID = clsData.StatusID
                    clsReturn.CreatedBy = clsData.CreatedBy
                    clsReturn.CreatedDate = clsData.CreatedDate
                    clsReturn.LogInc = clsData.LogInc
                    clsReturn.LogBy = clsData.LogBy
                    clsReturn.LogDate = clsData.LogDate
                    Return clsReturn
                End If
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strModules As String,
                                     ByVal strRemarks As String, ByVal enumDPType As VO.DownPayment.DPTypeValue)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        BL.AccountReceivable.DeleteData(sqlCon, sqlTrans, strID, strModules, strRemarks)
                    Else
                        BL.AccountPayable.DeleteData(sqlCon, sqlTrans, strID, strModules, strRemarks)
                    End If
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Function Submit(ByVal strID As String, ByVal strRemarks As String,
                                      ByVal enumDPType As VO.DownPayment.DPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.Submit(sqlCon, sqlTrans, strID, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.Submit(sqlCon, sqlTrans, strID, strRemarks)
                    End If
                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String,
                                        ByVal enumDPType As VO.DownPayment.DPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.Unsubmit(sqlCon, sqlTrans, strID, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.Unsubmit(sqlCon, sqlTrans, strID, strRemarks)
                    End If
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Approve(ByVal strID As String, ByVal strRemarks As String,
                                       ByVal enumDPType As VO.DownPayment.DPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.Approve(sqlCon, sqlTrans, strID, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.Approve(sqlCon, sqlTrans, strID, strRemarks)
                    End If
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unapprove(ByVal strID As String, ByVal strRemarks As String,
                                         ByVal enumDPType As VO.DownPayment.DPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.Unapprove(sqlCon, sqlTrans, strID, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.Unapprove(sqlCon, sqlTrans, strID, strRemarks)
                    End If
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupPayment(ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                            ByVal strRemarks As String, ByVal enumDPType As VO.DownPayment.DPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks)
                    End If
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupCancelPayment(ByVal strID As String, ByVal strRemarks As String,
                                                  ByVal enumDPType As VO.DownPayment.DPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.SetupCancelPayment(sqlCon, sqlTrans, strID, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.SetupCancelPayment(sqlCon, sqlTrans, strID, strRemarks)
                    End If
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UpdateTaxInvoiceNumber(ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                      ByVal strRemarks As String, ByVal enumDPType As VO.DownPayment.DPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.DownPayment.DPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber, strRemarks)
                    End If
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
                dtReturn = DL.DownPayment.PrintVer00(sqlCon, Nothing, intProgramID, intCompanyID, strID)
                For Each dr As DataRow In dtReturn.Rows
                    dr.BeginEdit()
                    dr.Item("NumericToString") = SharedLib.Math.NumberToString(dr.Item("TotalAmount"))
                    dr.EndEdit()
                Next
                dtReturn.AcceptChanges()
            End Using
            Return dtReturn
        End Function

        Public Shared Function ListPaymentHistory(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                  ByVal strReferencesID As String, ByVal dtmTransDate As DateTime,
                                                  ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.DownPayment.ListPaymentHistory(sqlCon, Nothing, intProgramID, intCompanyID, strReferencesID, dtmTransDate, strID)
            End Using
            Return dtReturn
        End Function

#End Region

    End Class
End Namespace