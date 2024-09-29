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
            Dim clsReferences As New Object
            Dim strReferencesNumber As String = ""
            Dim strARAPNumber As String = ""
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If clsDataARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                        If clsDataARAP.Modules = VO.AccountReceivable.DownPayment Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePayment Then
                            clsReferences = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.SCNumber
                        ElseIf clsDataARAP.Modules = VO.AccountReceivable.DownPaymentOrderRequest Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                            clsReferences = DL.OrderRequest.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.OrderNumber
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If

                        If clsReferences.StatusID <> VO.Status.Values.Approved And (clsDataARAP.Modules = VO.AccountReceivable.DownPayment Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePayment) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        ElseIf clsReferences.StatusID <> VO.Status.Values.Submit And (clsDataARAP.Modules = VO.AccountReceivable.DownPaymentOrderRequest Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePaymentOrderRequest) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Permintaan harus disubmit terlebih dahulu")
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
                        clsData.ReferencesNote = strReferencesNumber
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

        Public Shared Function SaveDataVer2(ByVal bolNew As Boolean, ByVal clsDataARAP As VO.ARAP) As String
            BL.Server.ServerDefault()
            Dim clsReferences As New Object
            Dim strReferencesNumber As String = ""
            Dim strARAPNumber As String = ""
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If clsDataARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                        If clsDataARAP.Modules = VO.AccountReceivable.DownPayment Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePayment Then
                            clsReferences = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.SCNumber
                        ElseIf clsDataARAP.Modules = VO.AccountReceivable.DownPaymentOrderRequest Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                            clsReferences = DL.OrderRequest.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.OrderNumber
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If

                        If clsReferences.StatusID <> VO.Status.Values.Approved And (clsDataARAP.Modules = VO.AccountReceivable.DownPayment Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePayment) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        ElseIf clsReferences.StatusID <> VO.Status.Values.Submit And (clsDataARAP.Modules = VO.AccountReceivable.DownPaymentOrderRequest Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePaymentOrderRequest) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Permintaan harus disubmit terlebih dahulu")
                        End If

                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountReceivableDet)
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
                                        .Rounding = cls.Rounding,
                                        .LevelItem = cls.LevelItem,
                                        .ReferencesParentID = cls.ReferencesParentID
                                    })
                        Next

                        '# Save Data Header
                        Dim clsData As New VO.AccountReceivable
                        clsData.ID = clsDataARAP.ID
                        clsData.ProgramID = clsDataARAP.ProgramID
                        clsData.CompanyID = clsDataARAP.CompanyID
                        clsData.ARNumber = clsDataARAP.TransNumber
                        clsData.BPID = clsDataARAP.BPID
                        clsData.CoAIDOfIncomePayment = clsDataARAP.CoAID
                        clsData.ReferencesID = clsDataARAP.ReferencesID
                        clsData.ReferencesNote = strReferencesNumber
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
                        clsData.ARAPItem = clsDataARAP.DetailItem
                        clsData.LogBy = clsDataARAP.LogBy
                        clsData.IsUseSubItem = clsDataARAP.IsUseSubItem
                        clsData.Save = clsDataARAP.Save
                        clsData.PPNPercentage = clsDataARAP.PPNPercentage
                        clsData.PPHPercentage = clsDataARAP.PPHPercentage

                        BL.AccountReceivable.SaveDataVer01(sqlCon, sqlTrans, bolNew, clsData)

                        clsReferences = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                        If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.TotalDPP Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi")
                        End If

                        strARAPNumber = clsData.ARNumber
                    Else
                        If clsDataARAP.Modules = VO.AccountPayable.DownPaymentCutting Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentCutting Then
                            clsReferences = DL.PurchaseOrderCutting.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPaymentTransport Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            clsReferences = DL.Delivery.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.DeliveryNumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPayment Or clsDataARAP.Modules = VO.AccountPayable.ReceivePayment Then
                            clsReferences = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PCNumber
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If
                        If clsReferences.StatusID <> VO.Status.Values.Approved And clsDataARAP.Modules <> VO.AccountPayable.ReceivePaymentTransport Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport And clsReferences.StatusID <> VO.Status.Values.Submit Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Pengiriman harus disubmit terlebih dahulu")
                        End If

                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountPayableDet)
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
                                            .Rounding = cls.Rounding,
                                            .LevelItem = cls.LevelItem,
                                            .ReferencesParentID = cls.ReferencesParentID
                                        })
                        Next

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
                        clsData.ARAPItem = clsDataARAP.DetailItem
                        clsData.LogBy = clsDataARAP.LogBy
                        clsData.IsUseSubItem = clsDataARAP.IsUseSubItem
                        clsData.Save = clsDataARAP.Save
                        clsData.PPNPercentage = clsDataARAP.PPNPercentage
                        clsData.PPHPercentage = clsDataARAP.PPHPercentage

                        BL.AccountPayable.SaveDataVer01(sqlCon, sqlTrans, bolNew, clsData)

                        If clsDataARAP.Modules = VO.AccountPayable.DownPaymentCutting Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentCutting Then
                            clsReferences = DL.PurchaseOrderCutting.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPaymentTransport Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            clsReferences = DL.Delivery.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.DeliveryNumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPayment Or clsDataARAP.Modules = VO.AccountPayable.ReceivePayment Then
                            clsReferences = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PCNumber
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If

                        If clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            If clsReferences.DPAmountTransport + clsReferences.TotalPaymentTransport > clsReferences.TotalDPPTransport Then
                                Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi Transporter")
                            End If
                        Else
                            If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.TotalDPP Then
                                Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi")
                            End If
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

        Public Shared Function SaveDataVer3_ReceivePayment(ByVal bolNew As Boolean, ByVal clsDataARAP As VO.ARAP) As String
            BL.Server.ServerDefault()
            Dim clsReferences As New Object
            Dim strReferencesNumber As String = ""
            Dim strARAPNumber As String = ""
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If clsDataARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                        If clsDataARAP.Modules = VO.AccountReceivable.DownPayment Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePayment Then
                            clsReferences = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.SCNumber
                        ElseIf clsDataARAP.Modules = VO.AccountReceivable.DownPaymentOrderRequest Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                            clsReferences = DL.OrderRequest.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.OrderNumber
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If

                        If clsReferences.StatusID <> VO.Status.Values.Approved And (clsDataARAP.Modules = VO.AccountReceivable.DownPayment Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePayment) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        ElseIf clsReferences.StatusID <> VO.Status.Values.Submit And (clsDataARAP.Modules = VO.AccountReceivable.DownPaymentOrderRequest Or clsDataARAP.Modules = VO.AccountReceivable.ReceivePaymentOrderRequest) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Permintaan harus disubmit terlebih dahulu")
                        End If

                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountReceivableDet)
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
                                        .Rounding = cls.Rounding,
                                        .LevelItem = cls.LevelItem,
                                        .ReferencesParentID = cls.ReferencesParentID,
                                        .Quantity = cls.Quantity,
                                        .Weight = cls.Weight,
                                        .TotalWeight = cls.TotalWeight
                                    })
                        Next

                        '# Save Data Header
                        Dim clsData As New VO.AccountReceivable
                        clsData.ID = clsDataARAP.ID
                        clsData.ProgramID = clsDataARAP.ProgramID
                        clsData.CompanyID = clsDataARAP.CompanyID
                        clsData.ARNumber = clsDataARAP.TransNumber
                        clsData.BPID = clsDataARAP.BPID
                        clsData.CoAIDOfIncomePayment = clsDataARAP.CoAID
                        clsData.ReferencesID = clsDataARAP.ReferencesID
                        clsData.ReferencesNote = strReferencesNumber
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
                        clsData.ARAPItem = clsDataARAP.DetailItem
                        clsData.LogBy = clsDataARAP.LogBy
                        clsData.IsUseSubItem = clsDataARAP.IsUseSubItem
                        clsData.Save = clsDataARAP.Save

                        BL.AccountReceivable.SaveDataVer02_ReceivePayment(sqlCon, sqlTrans, bolNew, clsData)

                        clsReferences = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                        If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.TotalDPP Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi")
                        End If

                        strARAPNumber = clsData.ARNumber
                    Else
                        If clsDataARAP.Modules = VO.AccountPayable.DownPaymentCutting Or
                            clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentCutting Then
                            clsReferences = DL.PurchaseOrderCutting.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPaymentTransport Or
                            clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            clsReferences = DL.Delivery.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.DeliveryNumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPayment Or
                            clsDataARAP.Modules = VO.AccountPayable.ReceivePayment Then
                            If clsDataARAP.PaymentTypeID = VO.PaymentType.Values.CBD Then
                                clsReferences = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                                strReferencesNumber = clsReferences.PCNumber
                            ElseIf clsDataARAP.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                                clsReferences = DL.Receive.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                                strReferencesNumber = clsReferences.ReceiveNumber
                            End If
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If
                        If clsReferences.StatusID <> VO.Status.Values.Approved And clsDataARAP.Modules = VO.AccountPayable.ReceivePayment And clsDataARAP.PaymentTypeID = VO.PaymentType.Values.CBD Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Kontrak harus disetujui terlebih dahulu")
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport And clsReferences.StatusID <> VO.Status.Values.Submit Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Data Pengiriman harus disubmit terlebih dahulu")
                        End If

                        '# Save Data Detail
                        Dim clsDet As New List(Of VO.AccountPayableDet)
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
                                            .Rounding = cls.Rounding,
                                            .LevelItem = cls.LevelItem,
                                            .ReferencesParentID = cls.ReferencesParentID,
                                            .Quantity = cls.Quantity,
                                            .Weight = cls.Weight,
                                            .TotalWeight = cls.TotalWeight
                                        })
                        Next

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
                        clsData.ARAPItem = clsDataARAP.DetailItem
                        clsData.LogBy = clsDataARAP.LogBy
                        clsData.IsUseSubItem = clsDataARAP.IsUseSubItem
                        clsData.Save = clsDataARAP.Save
                        clsData.PaymentTypeID = clsDataARAP.PaymentTypeID

                        BL.AccountPayable.SaveDataVer02_ReceivePayment(sqlCon, sqlTrans, bolNew, clsData)

                        If clsDataARAP.Modules = VO.AccountPayable.DownPaymentCutting Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentCutting Then
                            clsReferences = DL.PurchaseOrderCutting.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.PONumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPaymentTransport Or clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            clsReferences = DL.Delivery.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                            strReferencesNumber = clsReferences.DeliveryNumber
                        ElseIf clsDataARAP.Modules = VO.AccountPayable.DownPayment Or clsDataARAP.Modules = VO.AccountPayable.ReceivePayment Then
                            If clsDataARAP.PaymentTypeID = VO.PaymentType.Values.CBD Then
                                clsReferences = DL.PurchaseContract.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                                strReferencesNumber = clsReferences.PCNumber
                            ElseIf clsDataARAP.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                                clsReferences = DL.Receive.GetDetail(sqlCon, sqlTrans, clsDataARAP.ReferencesID)
                                strReferencesNumber = clsReferences.ReceiveNumber
                            End If
                        Else
                            Err.Raise(515, "", "Data tidak dapat disimpan. Modules tidak terdaftar")
                        End If

                        If clsDataARAP.Modules = VO.AccountPayable.ReceivePaymentTransport Then
                            If clsReferences.DPAmountTransport + clsReferences.TotalPaymentTransport > clsReferences.TotalDPPTransport Then
                                Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi Transporter")
                            End If
                        Else
                            '# TODO Check Max Amount base on Total Item
                            'If clsDataARAP.PaymentTypeID = VO.PaymentType.Values.CBD Then
                            '    If clsReferences.DPAmount + clsReferences.ReceiveAmount > clsReferences.TotalDPP Then
                            '        Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi")
                            '    End If
                            'ElseIf clsDataARAP.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                            '    If clsReferences.DPAmount + clsReferences.TotalPayment > clsReferences.TotalDPP Then
                            '        Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP Transaksi")
                            '    End If
                            'End If
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
                Return BL.ARAP.GetDetail(sqlCon, Nothing, strID, enumARAPType)
            End Using
        End Function

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String, ByVal enumARAPType As VO.ARAP.ARAPTypeValue) As VO.ARAP
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                Dim clsReturn As New VO.ARAP
                clsReturn.ARAPType = VO.ARAP.ARAPTypeValue.Sales
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
                clsReturn.PaymentTerm1 = clsData.PaymentTerm1
                clsReturn.PaymentTerm2 = clsData.PaymentTerm2
                clsReturn.PaymentTerm3 = clsData.PaymentTerm3
                clsReturn.PaymentTerm4 = clsData.PaymentTerm4
                clsReturn.PaymentTerm5 = clsData.PaymentTerm5
                clsReturn.PaymentTerm6 = clsData.PaymentTerm6
                clsReturn.PaymentTerm7 = clsData.PaymentTerm7
                clsReturn.PaymentTerm8 = clsData.PaymentTerm8
                clsReturn.PaymentTerm9 = clsData.PaymentTerm9
                clsReturn.PaymentTerm10 = clsData.PaymentTerm10
                clsReturn.PPNPercentage = clsData.PPNPercentage
                clsReturn.PPHPercentage = clsData.PPHPercentage
                clsReturn.TotalInvoiceAmount = clsData.TotalInvoiceAmount
                clsReturn.TotalDPPInvoiceAmount = clsData.TotalDPPInvoiceAmount
                clsReturn.TotalPPNInvoiceAmount = clsData.TotalPPNInvoiceAmount
                clsReturn.TotalPPHInvoiceAmount = clsData.TotalPPHInvoiceAmount
                Return clsReturn
            Else
                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                Dim clsReturn As New VO.ARAP
                clsReturn.ARAPType = VO.ARAP.ARAPTypeValue.Purchase
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
                clsReturn.PaymentTerm1 = clsData.PaymentTerm1
                clsReturn.PaymentTerm2 = clsData.PaymentTerm2
                clsReturn.PaymentTerm3 = clsData.PaymentTerm3
                clsReturn.PaymentTerm4 = clsData.PaymentTerm4
                clsReturn.PaymentTerm5 = clsData.PaymentTerm5
                clsReturn.PaymentTerm6 = clsData.PaymentTerm6
                clsReturn.PaymentTerm7 = clsData.PaymentTerm7
                clsReturn.PaymentTerm8 = clsData.PaymentTerm8
                clsReturn.PaymentTerm9 = clsData.PaymentTerm9
                clsReturn.PaymentTerm10 = clsData.PaymentTerm10
                clsReturn.PPNPercentage = clsData.PPNPercentage
                clsReturn.PPHPercentage = clsData.PPHPercentage
                clsReturn.TotalInvoiceAmount = clsData.TotalInvoiceAmount
                clsReturn.TotalDPPInvoiceAmount = clsData.TotalDPPInvoiceAmount
                clsReturn.TotalPPNInvoiceAmount = clsData.TotalPPNInvoiceAmount
                clsReturn.TotalPPHInvoiceAmount = clsData.TotalPPHInvoiceAmount
                Return clsReturn
            End If
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strModules As String,
                                     ByVal strRemarks As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue,
                                     ByVal intPaymentTypeID As Integer)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                        BL.AccountReceivable.DeleteDataVer02(sqlCon, sqlTrans, strID, strModules, strRemarks)
                    Else
                        BL.AccountPayable.DeleteDataVer02(sqlCon, sqlTrans, strID, strModules, strRemarks, intPaymentTypeID)
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
                                            ByVal intCoAID As Integer) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks, intCoAID)
                    Else
                        bolReturn = BL.AccountPayable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks, intCoAID)
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

        Public Shared Function UpdateInvoiceNumberSupplier(ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                           ByVal strRemarks As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                        bolReturn = BL.AccountReceivable.UpdateInvoiceNumberSupplier(sqlCon, sqlTrans, strID, strTaxInvoiceNumber, strRemarks)
                    Else
                        bolReturn = BL.AccountPayable.UpdateInvoiceNumberSupplier(sqlCon, sqlTrans, strID, strTaxInvoiceNumber, strRemarks)
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

        Public Shared Function PrintVer01(ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection

                dtReturn = DL.ARAP.PrintVer01(sqlCon, Nothing, intProgramID, intCompanyID, strID)
                Dim dtReferencesNumber As New DataTable
                Dim strPurchaseContractNumber As String = ""
                If dtReturn.Rows.Count > 0 Then dtReferencesNumber = DL.SalesContract.ListDataPurchaseContractNumber(sqlCon, Nothing, intProgramID, intCompanyID, dtReturn.Rows(0).Item("ReferencesID"))
                For Each dr As DataRow In dtReferencesNumber.Rows
                    strPurchaseContractNumber += IIf(strPurchaseContractNumber.Trim = "", "", ", ") & dr.Item("PCNumber")
                Next

                For Each dr As DataRow In dtReturn.Rows
                    dr.BeginEdit()
                    dr.Item("NumericToString") = IIf(dr.Item("IsDP"), SharedLib.Math.NumberToString(SharedLib.Math.Round(dr.Item("DPAmount"), 0)), SharedLib.Math.NumberToString(SharedLib.Math.Round(dr.Item("GrandTotal") - dr.Item("DPAmount"), 0)))
                    dr.Item("ContractNumber") = strPurchaseContractNumber
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

        Public Shared Function ListDataDetailVer2(ByVal strParentID As String, ByVal enumARAPType As VO.ARAP.ARAPTypeValue) As DataTable
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                Return BL.AccountReceivable.ListDataDetailRev02(strParentID)
            Else
                Return BL.AccountPayable.ListDataDetailRev02(strParentID)
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

        Public Shared Function ListDataDetailItemDPWithOutstandingVer2(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                       ByVal intBPID As Integer, ByVal strParentID As String,
                                                                       ByVal enumARAPType As VO.ARAP.ARAPTypeValue, ByVal strReferencesID As String,
                                                                       ByVal bolIsUseSubItem As Boolean) As DataTable
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                Return BL.AccountReceivable.ListDataDetailItemDPWithOutstandingRev02(intCompanyID, intProgramID, intBPID, strParentID, strReferencesID, bolIsUseSubItem)
            Else
                Return BL.AccountPayable.ListDataDetailItemDPWithOutstandingRev02(intCompanyID, intProgramID, intBPID, strParentID, strReferencesID, bolIsUseSubItem)
            End If
        End Function

        Public Shared Function ListDataDetailItemReceiveWithOutstandingVer2(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                            ByVal intBPID As Integer, ByVal strParentID As String,
                                                                            ByVal enumARAPType As VO.ARAP.ARAPTypeValue, ByVal strReferencesID As String,
                                                                            ByVal intPaymentTypeID As Integer, ByVal bolIsUseSubitem As Boolean) As DataTable
            If enumARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                Return BL.AccountReceivable.ListDataDetailItemReceiveWithOutstandingVer02(intCompanyID, intProgramID, intBPID, strParentID, strReferencesID)
            Else
                Return BL.AccountPayable.ListDataDetailItemReceiveWithOutstandingRev02(intCompanyID, intProgramID, intBPID, strParentID, strReferencesID, intPaymentTypeID, bolIsUseSubitem)
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

#Region "Invoice"

        Public Shared Function ListDataInvoice(ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ARAP.ListDataInvoice(sqlCon, Nothing, strParentID)
            End Using
        End Function

        Public Shared Function GetDetailInvoice(ByVal strID As String) As VO.ARAPInvoice
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.ARAP.GetDetailInvoice(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Function SaveDataInvoice(ByVal bolNew As Boolean, ByVal clsData As VO.ARAPInvoice) As String
            Dim strReturn As String = ""
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsARAP As VO.ARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Purchase)
                    If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Sales)

                    Dim decTotalInvoice, decTotalDPPInvoice, decTotalPPNInvoice, decTotalPPHInvoice As Decimal

                    If bolNew Then
                        clsData.ID = clsARAP.ID & "-" & Format(DL.ARAP.GetMaxIDInvoice(sqlCon, sqlTrans, clsARAP.ID & "-") + 1, "000")
                        If clsData.InvoiceNumber.Trim = "" Then clsData.InvoiceNumber = clsData.ID
                    End If

                    DL.ARAP.SaveDataInvoice(sqlCon, sqlTrans, bolNew, clsData)

                    '# Update Total Used ARAP
                    Dim dtInvoice As DataTable = DL.ARAP.ListDataInvoice(sqlCon, sqlTrans, clsARAP.ID)
                    Dim drValid() As DataRow = dtInvoice.Select("IsDeleted=0")
                    For Each dr As DataRow In drValid
                        decTotalInvoice += dr.Item("TotalAmount")
                        decTotalDPPInvoice += dr.Item("TotalDPP")
                        decTotalPPNInvoice += dr.Item("TotalPPN")
                        decTotalPPHInvoice += dr.Item("TotalPPH")
                    Next

                    Dim strTableName As String = "traAccountPayable"
                    If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then strTableName = "traAccountReceivable"
                    DL.ARAP.UpdateInvoiceAmount(sqlCon, sqlTrans, strTableName, clsARAP.ID, decTotalInvoice, decTotalDPPInvoice, decTotalPPNInvoice, decTotalPPHInvoice)

                    '# Alokasi selisih amount di akhir invoice
                    clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Purchase)
                    If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Sales)
                    If clsARAP.TotalAmount - decTotalDPPInvoice = 0 Then
                        If clsARAP.TotalPPN - decTotalPPNInvoice > 0 Then decTotalPPNInvoice += clsARAP.TotalPPN - decTotalPPNInvoice
                        If clsARAP.TotalPPH - decTotalPPHInvoice > 0 Then decTotalPPHInvoice += clsARAP.TotalPPH - decTotalPPHInvoice
                        DL.ARAP.UpdateInvoiceAmount(sqlCon, sqlTrans, strTableName, clsARAP.ID, decTotalInvoice, decTotalDPPInvoice, decTotalPPNInvoice, decTotalPPHInvoice)
                    End If

                    If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Purchase Then
                        DL.AccountPayable.SetupPayment(sqlCon, sqlTrans, clsARAP.ID, Now, 0)
                    ElseIf clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                        DL.AccountReceivable.SetupPayment(sqlCon, sqlTrans, clsARAP.ID, Now, 0)
                    End If

                    '# Validasi
                    If decTotalDPPInvoice > clsARAP.TotalAmount Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP PI")
                    End If
                    strReturn = clsData.InvoiceNumber
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return strReturn
        End Function

        Public Shared Function DeleteDataInvoice(ByVal clsData As VO.ARAPInvoice) As String
            Dim strReturn As String = ""
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim clsARAP As VO.ARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Purchase)
                    If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsData.ParentID, VO.ARAP.ARAPTypeValue.Sales)

                    Dim decTotalInvoice, decTotalDPPInvoice, decTotalPPNInvoice, decTotalPPHInvoice As Decimal

                    DL.ARAP.DeleteDataInvoice(sqlCon, sqlTrans, clsData.ID)

                    '# Update Total Used ARAP
                    Dim dtInvoice As DataTable = DL.ARAP.ListDataInvoice(sqlCon, sqlTrans, clsARAP.ID)
                    Dim drValid() As DataRow = dtInvoice.Select("IsDeleted=0")
                    For Each dr As DataRow In drValid
                        decTotalInvoice += dr.Item("TotalAmount")
                        decTotalDPPInvoice += dr.Item("TotalDPP")
                        decTotalPPNInvoice += dr.Item("TotalPPN")
                        decTotalPPHInvoice += dr.Item("TotalPPH")
                    Next

                    Dim strTableName As String = "traAccountPayable"
                    If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then strTableName = "traAccountReceivable"
                    DL.ARAP.UpdateInvoiceAmount(sqlCon, sqlTrans, strTableName, clsARAP.ID, decTotalInvoice, decTotalDPPInvoice, decTotalPPNInvoice, decTotalPPHInvoice)

                    If decTotalInvoice = 0 Then
                        If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Purchase Then
                            DL.AccountPayable.SetupCancelPayment(sqlCon, sqlTrans, clsARAP.ID)
                        ElseIf clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                            DL.AccountReceivable.SetupCancelPayment(sqlCon, sqlTrans, clsARAP.ID)
                        End If
                    End If

                    '# Validasi
                    If decTotalDPPInvoice > clsARAP.TotalAmount Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Total Pembayaran telah melebihi nilai Total DPP PI")
                    End If

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return strReturn
        End Function

        Public Shared Function SubmitInvoice(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = SubmitInvoice(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SubmitInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String, ByVal strRemarks As String)
            Dim bolReturn As Boolean = False
            Dim clsData As VO.ARAPInvoice = DL.ARAP.GetDetailInvoice(sqlCon, sqlTrans, strID)
            If clsData.StatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf clsData.StatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf clsData.IsDeleted Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.ARAP.SubmitInvoice(sqlCon, sqlTrans, strID)

            bolReturn = True
            Return bolReturn
        End Function

        Public Shared Function UnsubmitInvoice(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = UnsubmitInvoice(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UnsubmitInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False

            Try
                Dim clsData As VO.ARAPInvoice = DL.ARAP.GetDetailInvoice(sqlCon, sqlTrans, strID)
                If clsData.StatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                ElseIf clsData.StatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                ElseIf clsData.IsDeleted Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                End If

                DL.ARAP.UnsubmitInvoice(sqlCon, sqlTrans, strID)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function ApproveInvoice(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = ApproveInvoice(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function ApproveInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim clsData As VO.ARAPInvoice = DL.ARAP.GetDetailInvoice(sqlCon, sqlTrans, strID)
                If clsData.StatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                ElseIf clsData.StatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                ElseIf clsData.StatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf clsData.IsDeleted Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                End If

                DL.ARAP.ApproveInvoice(sqlCon, sqlTrans, strID)

                GenerateJournalInvoice(sqlCon, sqlTrans, strID)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function UnapproveInvoice(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    UnapproveInvoice(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UnapproveInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim clsData As VO.ARAPInvoice = DL.ARAP.GetDetailInvoice(sqlCon, sqlTrans, strID)
                If clsData.StatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                ElseIf clsData.StatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                ElseIf clsData.StatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf clsData.IsDeleted Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                End If

                '# Cancel Approve Journal
                BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                '# Cancel Submit Journal
                BL.Journal.Unsubmit(clsData.JournalID.Trim, "")

                '# Unapprove Account Receivable
                DL.ARAP.UnapproveInvoice(sqlCon, sqlTrans, strID)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Sub GenerateJournalInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String)
            Try
                Dim clsARAPInvoice As VO.ARAPInvoice = DL.ARAP.GetDetailInvoice(sqlCon, sqlTrans, strID)
                Dim clsARAP As VO.ARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsARAPInvoice.ParentID, VO.ARAP.ARAPTypeValue.Purchase)
                If clsARAP.ID Is Nothing Then clsARAP = BL.ARAP.GetDetail(sqlCon, sqlTrans, clsARAPInvoice.ParentID, VO.ARAP.ARAPTypeValue.Sales)

                '# Generate Journal
                Dim clsJournalDetail As New List(Of VO.JournalDet)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsARAPInvoice.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0
                Dim strJournalDetailRemarks As String = ""

                If clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Purchase Then
                    Dim intCoAofReceivePaymentAccountOutstandingPayment As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableOutstandingPayment
                    Dim intCoAofReceivePaymentAccount As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayable
                    Dim intCoAofDownPaymentAccount As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAdvancePayment

                    If clsARAP.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                        intCoAofReceivePaymentAccountOutstandingPayment = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableCuttingOutstandingPayment
                        intCoAofReceivePaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableCutting
                        intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeCutting
                    End If
                    If clsARAP.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        intCoAofReceivePaymentAccountOutstandingPayment = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableTransportOutstandingPayment
                        intCoAofReceivePaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableTransport
                        intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeTransport
                    End If

                    If clsARAP.IsDP Then
                        '# Akun Panjar Pembelian -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = intCoAofDownPaymentAccount,
                                                 .DebitAmount = clsARAPInvoice.TotalDPP,
                                                 .CreditAmount = 0,
                                                 .Remarks = strJournalDetailRemarks,
                                                 .GroupID = intGroupID,
                                                 .BPID = clsARAP.BPID
                                             })
                        decTotalAmount += clsARAPInvoice.TotalDPP

                        '# Akun PPN -> Debit
                        If clsARAPInvoice.TotalPPN > 0 Then
                            clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPurchaseTax,
                                                 .DebitAmount = clsARAPInvoice.TotalPPN,
                                                 .CreditAmount = 0,
                                                 .Remarks = strJournalDetailRemarks,
                                                 .GroupID = intGroupID,
                                                 .BPID = clsARAP.BPID
                                             })
                            decTotalAmount += clsARAPInvoice.TotalPPN
                        End If


                        '# Akun Kas / Bank -> Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = clsARAPInvoice.CoAID,
                                                 .DebitAmount = 0,
                                                 .CreditAmount = clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN,
                                                 .Remarks = strJournalDetailRemarks,
                                                 .GroupID = intGroupID,
                                                 .BPID = clsARAP.BPID
                                             })

                        '# Setup Akun PPH
                        If clsARAPInvoice.TotalPPH > 0 Then
                            intGroupID += 1

                            '# Akun Kas / Bank -> Debit
                            clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = clsARAPInvoice.CoAID,
                                                 .DebitAmount = clsARAPInvoice.TotalPPH,
                                                 .CreditAmount = 0,
                                                 .Remarks = strJournalDetailRemarks,
                                                 .GroupID = intGroupID,
                                                 .BPID = clsARAP.BPID
                                             })

                            '# Akun PPH -> Kredit
                            clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHPurchase,
                                                 .DebitAmount = 0,
                                                 .CreditAmount = clsARAPInvoice.TotalPPH,
                                                 .Remarks = strJournalDetailRemarks,
                                                 .GroupID = intGroupID,
                                                 .BPID = clsARAP.BPID
                                             })
                            decTotalAmount += clsARAPInvoice.TotalPPH
                        End If
                    Else
                        '# Akun Hutang Usaha -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = intCoAofReceivePaymentAccount,
                                             .DebitAmount = clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN,
                                             .CreditAmount = 0,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsARAP.BPID
                                         })

                        '# Akun Kas / Bank - Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = clsARAPInvoice.CoAID,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsARAP.BPID
                                         })
                        decTotalAmount += clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN

                        '# Setup Akun PPH
                        If clsARAPInvoice.TotalPPH > 0 Then
                            intGroupID += 1

                            '# Akun Kas / Bank -> Debit
                            clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = clsARAPInvoice.CoAID,
                                             .DebitAmount = clsARAPInvoice.TotalPPH,
                                             .CreditAmount = 0,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsARAP.BPID
                                         })

                            '# Akun PPH -> Kredit
                            clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHPurchase,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsARAPInvoice.TotalPPH,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsARAP.BPID
                                         })
                            decTotalAmount += clsARAPInvoice.TotalPPH
                        End If

                    End If

                ElseIf clsARAP.ARAPType = VO.ARAP.ARAPTypeValue.Sales Then
                    If clsARAP.IsDP Then
                        '# Akun Kas / Bank -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = clsARAPInvoice.CoAID,
                                             .DebitAmount = clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN,
                                             .CreditAmount = 0,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsARAP.BPID
                                         })

                        '# Akun Panjar Penjualan -> Kredit
                        If clsARAPInvoice.TotalPPN > 0 Then
                            clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncome,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsARAPInvoice.TotalDPP,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsARAP.BPID
                                         })
                        End If

                        '# Akun PPN -> Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofSalesTax,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsARAPInvoice.TotalPPN,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsARAP.BPID
                                         })
                        decTotalAmount += clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN

                        '# Setup Akun PPH
                        If clsARAPInvoice.TotalPPH > 0 Then
                            intGroupID += 1
                            '# Akun PPH -> Debit
                            clsJournalDetail.Add(New VO.JournalDet With
                                                 {
                                                     .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHSales,
                                                     .DebitAmount = clsARAPInvoice.TotalPPH,
                                                     .CreditAmount = 0,
                                                     .Remarks = "",
                                                     .GroupID = intGroupID,
                                                     .BPID = clsARAP.BPID
                                                 })

                            '# Akun Kas / Bank -> Kredit
                            clsJournalDetail.Add(New VO.JournalDet With
                                                 {
                                                     .CoAID = clsARAPInvoice.CoAID,
                                                     .DebitAmount = 0,
                                                     .CreditAmount = clsARAPInvoice.TotalPPH,
                                                     .Remarks = "",
                                                     .GroupID = intGroupID,
                                                     .BPID = clsARAP.BPID
                                                 })
                            decTotalAmount += clsARAPInvoice.TotalPPH
                        End If
                    Else
                        '# Akun Kas / Bank -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                                 {
                                                     .CoAID = clsARAPInvoice.CoAID,
                                                     .DebitAmount = clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN,
                                                     .CreditAmount = 0,
                                                     .Remarks = "",
                                                     .GroupID = intGroupID,
                                                     .BPID = clsARAP.BPID
                                                 })

                        '# Akun Piutang Usaha -> Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                                 {
                                                     .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivable,
                                                     .DebitAmount = 0,
                                                     .CreditAmount = clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN,
                                                     .Remarks = "",
                                                     .GroupID = intGroupID,
                                                     .BPID = clsARAP.BPID
                                                 })
                        decTotalAmount += clsARAPInvoice.TotalDPP + clsARAPInvoice.TotalPPN

                        '# Setup Akun PPH
                        If clsARAPInvoice.TotalPPH > 0 Then
                            intGroupID += 1

                            '# Akun PPH -> Debit
                            clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHSales,
                                                 .DebitAmount = clsARAPInvoice.TotalPPH,
                                                 .CreditAmount = 0,
                                                 .Remarks = "",
                                                 .GroupID = intGroupID,
                                                 .BPID = clsARAP.BPID
                                             })

                            '# Akun Kas / Bank -> Kredit
                            clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = clsARAPInvoice.CoAID,
                                                 .DebitAmount = 0,
                                                 .CreditAmount = clsARAPInvoice.TotalPPH,
                                                 .Remarks = "",
                                                 .GroupID = intGroupID,
                                                 .BPID = clsARAP.BPID
                                             })

                            decTotalAmount += clsARAPInvoice.TotalPPH
                        End If
                    End If
                End If

                Dim clsJournal As New VO.Journal With
                        {
                            .ProgramID = clsARAP.ProgramID,
                            .CompanyID = clsARAP.CompanyID,
                            .ID = PrevJournal.ID,
                            .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                            .ReferencesID = clsARAPInvoice.ID,
                            .JournalDate = clsARAPInvoice.InvoiceDate,
                            .TotalAmount = decTotalAmount,
                            .IsAutoGenerate = True,
                            .StatusID = VO.Status.Values.Draft,
                            .Remarks = clsARAPInvoice.Remarks,
                            .LogBy = ERPSLib.UI.usUserApp.UserID,
                            .Initial = "",
                            .ReferencesNo = clsARAPInvoice.InvoiceNumber,
                            .Detail = clsJournalDetail,
                            .Save = VO.Save.Action.SaveAndSubmit
                        }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Account Payable
                DL.ARAP.UpdateJournalIDInvoice(sqlCon, sqlTrans, clsARAPInvoice.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

    End Class
End Namespace