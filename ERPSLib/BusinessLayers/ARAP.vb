Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Namespace BL
    Public Class ARAP

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String,
                                        ByVal enumDPType As VO.ARAP.ARAPTypeValue,
                                        ByVal intBPID As Integer, ByVal strReferencesID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                    Return DL.AccountReceivable.ListData(sqlCon, Nothing, intCompanyID, intProgramID, dtmDateFrom, dtmDateTo, intStatusID, strModules, intBPID, strReferencesID)
                Else
                    Return DL.AccountPayable.ListData(sqlCon, Nothing, intCompanyID, intProgramID, dtmDateFrom, dtmDateTo, intStatusID, strModules, intBPID, strReferencesID)
                End If
            End Using
        End Function

        Public Shared Function ListDataOutstandingPayment(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                          ByVal strModules As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue) As DataTable
            BL.Server.ServerDefault()
            Dim dtData As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                    dtData = DL.AccountReceivable.ListDataOutstandingPayment(sqlCon, Nothing, intCompanyID, intProgramID, strModules)
                ElseIf enumDPType = VO.ARAP.ARAPTypeValue.Purchase Then
                    dtData = DL.AccountPayable.ListDataOutstandingPayment(sqlCon, Nothing, intCompanyID, intProgramID, strModules)
                Else
                    dtData = DL.AccountReceivable.ListDataOutstandingPayment(sqlCon, Nothing, intCompanyID, intProgramID, strModules)
                    dtData.Merge(DL.AccountPayable.ListDataOutstandingPayment(sqlCon, Nothing, intCompanyID, intProgramID, strModules))
                    dtData.DefaultView.Sort = "DueDate, ARDate, ID ASC"
                    dtData = dtData.DefaultView.ToTable
                End If
            End Using
            Return dtData
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsDataARAP As VO.ARAP) As String
            BL.Server.ServerDefault()
            Dim strARAPNumber As String = ""
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If clsDataARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                        Dim clsReferences As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                        If clsReferences.StatusID <> VO.Status.Values.Approved Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        End If

                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountReceivableDet)
                        If clsDataARAP.Modules = VO.AccountReceivable.ReceivePayment Then
                            For Each cls As VO.ARAPDet In clsDataARAP.Detail
                                clsDet.Add(New VO.AccountReceivableDet With
                                        {
                                            .ID = "",
                                            .ARID = "",
                                            .SalesID = cls.InvoiceID,
                                            .Amount = cls.Amount,
                                            .PPN = cls.PPN,
                                            .PPH = cls.PPH,
                                            .Remarks = cls.Remarks,
                                            .DPAmount = cls.DPAmount,
                                            .Rounding = cls.Rounding
                                        })
                            Next
                        Else
                            clsDet.Add(New VO.AccountReceivableDet With
                                     {
                                         .ID = "",
                                         .ARID = "",
                                         .SalesID = clsDataARAP.ReferencesID,
                                         .Amount = clsDataARAP.TotalAmount,
                                         .PPN = clsDataARAP.TotalPPN,
                                         .PPH = clsDataARAP.TotalPPN,
                                         .Remarks = clsDataARAP.Remarks
                                     })
                        End If

                        '# Save Data Header
                        Dim clsData As New VO.AccountReceivable
                        clsData.ID = clsDataARAP.ID
                        clsData.ProgramID = clsDataARAP.ProgramID
                        clsData.CompanyID = clsDataARAP.CompanyID
                        clsData.ARNumber = clsDataARAP.TransNumber
                        clsData.BPID = clsDataARAP.BPID
                        clsData.CoAIDOfIncomePayment = clsDataARAP.CoAID
                        clsData.ReferencesID = clsDataARAP.ReferencesID
                        clsData.ReferencesNote = clsReferences.SCNumber
                        clsData.TotalAmount = clsDataARAP.TotalAmount
                        clsData.TotalPPN = clsDataARAP.TotalPPN
                        clsData.TotalPPH = clsDataARAP.TotalPPH
                        clsData.Percentage = clsDataARAP.Percentage
                        clsData.ARDate = clsDataARAP.TransDate
                        clsData.DueDateValue = clsDataARAP.DueDateValue
                        clsData.Modules = clsDataARAP.Modules
                        clsData.Remarks = clsDataARAP.Remarks
                        clsData.StatusID = clsDataARAP.StatusID
                        clsData.IsDP = clsDataARAP.IsDP
                        clsData.DPAmount = clsDataARAP.DPAmount
                        clsData.ReceiveAmount = clsDataARAP.ReceiveAmount
                        clsData.Detail = clsDet
                        clsData.ARAPDownPayment = clsDataARAP.DownPayment
                        clsData.LogBy = clsDataARAP.LogBy
                        clsData.Save = clsDataARAP.Save

                        BL.AccountReceivable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                        clsReferences = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                        If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.TotalDPP Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi")
                        End If

                        strARAPNumber = clsData.ARNumber
                    Else
                        Dim clsReferences As New Object
                        Dim strReferencesNumber As String = ""
                        If clsDataARAP.Modules = VO.AccountPayable.DownPaymentCutting Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentCutting Then
                            clsReferences = DL.PurchaseOrderCutting.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPaymentTransport Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            clsReferences = DL.PurchaseOrderTransport.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPayment Or clsDataARAP.Modules = VO.AccountPayable.ReceivePayment Then
                            clsReferences = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PCNumber
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If
                        If clsReferences.StatusID <> VO.Status.Values.Approved Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        End If

                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountPayableDet)
                        If clsDataARAP.Modules = VO.AccountPayable.ReceivePayment Or
                            clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentCutting Or
                            clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            For Each cls As VO.ARAPDet In clsDataARAP.Detail
                                clsDet.Add(New VO.AccountPayableDet With
                                        {
                                            .ID = "",
                                            .APID = "",
                                            .PurchaseID = cls.InvoiceID,
                                            .Amount = cls.Amount,
                                            .PPN = cls.PPN,
                                            .PPH = cls.PPH,
                                            .Remarks = cls.Remarks,
                                            .DPAmount = cls.DPAmount,
                                            .Rounding = cls.Rounding
                                        })
                            Next
                        Else
                            clsDet.Add(New VO.AccountPayableDet With
                                        {
                                            .ID = "",
                                            .APID = "",
                                            .PurchaseID = clsDataARAP.ReferencesID,
                                            .Amount = clsDataARAP.TotalAmount,
                                            .PPN = clsDataARAP.TotalPPN,
                                            .PPH = clsDataARAP.TotalPPH,
                                            .Remarks = clsDataARAP.Remarks
                                        })
                        End If


                        '# Save Data Header
                        Dim clsData As New VO.AccountPayable
                        clsData.ID = clsDataARAP.ID
                        clsData.ProgramID = clsDataARAP.ProgramID
                        clsData.CompanyID = clsDataARAP.CompanyID
                        clsData.APNumber = clsDataARAP.TransNumber
                        clsData.BPID = clsDataARAP.BPID
                        clsData.CoAIDOfOutgoingPayment = clsDataARAP.CoAID
                        clsData.ReferencesID = clsDataARAP.ReferencesID
                        clsData.ReferencesNote = strReferencesNumber
                        clsData.TotalAmount = clsDataARAP.TotalAmount
                        clsData.TotalPPN = clsDataARAP.TotalPPN
                        clsData.TotalPPH = clsDataARAP.TotalPPH
                        clsData.Percentage = clsDataARAP.Percentage
                        clsData.APDate = clsDataARAP.TransDate
                        clsData.DueDateValue = clsDataARAP.DueDateValue
                        clsData.Modules = clsDataARAP.Modules
                        clsData.Remarks = clsDataARAP.Remarks
                        clsData.StatusID = clsDataARAP.StatusID
                        clsData.IsDP = clsDataARAP.IsDP
                        clsData.DPAmount = clsDataARAP.DPAmount
                        clsData.ReceiveAmount = clsDataARAP.ReceiveAmount
                        clsData.Detail = clsDet
                        clsData.ARAPDownPayment = clsDataARAP.DownPayment
                        clsData.LogBy = clsDataARAP.LogBy
                        clsData.Save = clsDataARAP.Save

                        BL.AccountPayable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                        If clsDataARAP.Modules = VO.AccountPayable.DownPaymentCutting Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentCutting Then
                            clsReferences = DL.PurchaseOrderCutting.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPaymentTransport Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            clsReferences = DL.PurchaseOrderTransport.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPayment Or clsDataARAP.Modules = VO.AccountPayable.ReceivePayment Then
                            clsReferences = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PCNumber
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If
                        If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.TotalDPP Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi")
                        End If
                        strARAPNumber = clsData.APNumber
                    End If

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return strARAPNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String, ByVal enumARAPType As VO.ARAP.ARAPTypeValue) As VO.ARAP
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                    Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, Nothing, strID)
                    Dim clsReturn As New VO.ARAP
                    clsReturn.ID = clsData.ID
                    clsReturn.CompanyID = clsData.CompanyID
                    clsReturn.ProgramID = clsData.ProgramID
                    clsReturn.TransNumber = clsData.ARNumber
                    clsReturn.BPID = clsData.BPID
                    clsReturn.BPCode = clsData.BPCode
                    clsReturn.BPName = clsData.BPName
                    clsReturn.CoAID = clsData.CoAIDOfIncomePayment
                    clsReturn.CoACode = clsData.CoACodeOfIncomePayment
                    clsReturn.CoAName = clsData.CoANameOfIncomePayment
                    clsReturn.Modules = clsData.Modules
                    clsReturn.ReferencesID = clsData.ReferencesID
                    clsReturn.ReferencesNote = clsData.ReferencesNote
                    clsReturn.TransDate = clsData.ARDate
                    clsReturn.DueDateValue = clsData.DueDateValue
                    clsReturn.TotalAmount = clsData.TotalAmount
                    clsReturn.TotalPPN = clsData.TotalPPN
                    clsReturn.TotalPPH = clsData.TotalPPH
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
                    clsReturn.TotalPPN = clsData.TotalPPN
                    clsReturn.TotalPPH = clsData.TotalPPH
                    clsReturn.IsDP = clsData.IsDP
                    clsReturn.DPAmount = clsData.DPAmount
                    clsReturn.ReceiveAmount = clsData.ReceiveAmount
                    clsReturn.TotalAmountUsed = clsData.TotalAmountUsed
                    Return clsReturn
                Else
                    Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, Nothing, strID)
                    Dim clsReturn As New VO.ARAP
                    clsReturn.ID = clsData.ID
                    clsReturn.CompanyID = clsData.CompanyID
                    clsReturn.ProgramID = clsData.ProgramID
                    clsReturn.TransNumber = clsData.APNumber
                    clsReturn.BPID = clsData.BPID
                    clsReturn.BPCode = clsData.BPCode
                    clsReturn.BPName = clsData.BPName
                    clsReturn.CoAID = clsData.CoAIDOfOutgoingPayment
                    clsReturn.CoACode = clsData.CoACodeOfOutgoingPayment
                    clsReturn.CoAName = clsData.CoANameOfOutgoingPayment
                    clsReturn.Modules = clsData.Modules
                    clsReturn.ReferencesID = clsData.ReferencesID
                    clsReturn.ReferencesNote = clsData.ReferencesNote
                    clsReturn.TransDate = clsData.APDate
                    clsReturn.DueDateValue = clsData.DueDateValue
                    clsReturn.TotalAmount = clsData.TotalAmount
                    clsReturn.TotalPPN = clsData.TotalPPN
                    clsReturn.TotalPPH = clsData.TotalPPH
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
                    clsReturn.TotalPPN = clsData.TotalPPN
                    clsReturn.TotalPPH = clsData.TotalPPH
                    clsReturn.IsDP = clsData.IsDP
                    clsReturn.DPAmount = clsData.DPAmount
                    clsReturn.ReceiveAmount = clsData.ReceiveAmount
                    clsReturn.TotalAmountUsed = clsData.TotalAmountUsed
                    Return clsReturn
                End If
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strModules As String,
                                     ByVal strRemarks As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
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
                                      ByVal enumDPType As VO.ARAP.ARAPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
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
                                        ByVal enumDPType As VO.ARAP.ARAPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
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
                                       ByVal enumDPType As VO.ARAP.ARAPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
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
                                         ByVal enumDPType As VO.ARAP.ARAPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
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
                                            ByVal strRemarks As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue,
                                            ByVal intCoAIDOfOutgoingPayment As Integer) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks, intCoAIDOfOutgoingPayment)
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
                                                  ByVal enumDPType As VO.ARAP.ARAPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
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
                                                      ByVal strRemarks As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
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
                dtReturn = DL.ARAP.PrintVer00(sqlCon, Nothing, intProgramID, intCompanyID, strID)
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
                dtReturn = DL.ARAP.ListPaymentHistory(sqlCon, Nothing, intProgramID, intCompanyID, strReferencesID, dtmTransDate, strID)
            End Using
            Return dtReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strParentID As String, ByVal enumARAPType As VO.ARAP.ARAPTypeValue) As DataTable
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                Return New DataTable
            Else
                Return BL.AccountPayable.ListDataDetailRev01(strParentID)
            End If
        End Function

        Public Shared Function ListDataDetailWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                             ByVal intBPID As Integer, ByVal strParentID As String,
                                                             ByVal enumARAPType As VO.ARAP.ARAPTypeValue, ByVal strReferencesID As String) As DataTable
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                Return BL.AccountReceivable.ListDataDetailWithOutstandingRev01(intCompanyID, intProgramID, intBPID, strParentID, strReferencesID)
            Else
                Return BL.AccountPayable.ListDataDetailWithOutstandingRev01(intCompanyID, intProgramID, intBPID, strParentID, strReferencesID)
            End If

        End Function

#End Region

#Region "Down Payment"

        Public Shared Function ListDataDownpayment(ByVal strParentID As String, ByVal enumARAPType As VO.ARAP.ARAPTypeValue) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                    Return DL.AccountReceivable.ListDataDownPayment(sqlCon, Nothing, strParentID)
                Else
                    Return DL.AccountPayable.ListDataDownPayment(sqlCon, Nothing, strParentID)
                End If
            End Using
        End Function

        Public Shared Function ListDataDownPaymentWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strModules As String,
                                                                  ByVal strParentID As String, ByVal enumARAPType As VO.ARAP.ARAPTypeValue,
                                                                  ByVal strReferencesID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                    Return DL.AccountReceivable.ListDataDownPaymentWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strModules, strParentID, strReferencesID)
                Else
                    Return DL.AccountPayable.ListDataDownPaymentWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strModules, strParentID, strReferencesID)
                End If
            End Using
        End Function

#End Region

    End Class
End Namespace