Namespace BL
    Public Class AccountReceivable

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strModules, 0, "")
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal strModules As String) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "AR" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-" & strModules & "-"
            strNewID &= Format(DL.AccountReceivable.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function GetNewNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim strNewID As String = Format(dtmTransDate, "yy") & "/"
            Select Case dtmTransDate.Month
                Case 1 : strNewID &= "I"
                Case 2 : strNewID &= "II"
                Case 3 : strNewID &= "III"
                Case 4 : strNewID &= "IV"
                Case 5 : strNewID &= "V"
                Case 6 : strNewID &= "VI"
                Case 7 : strNewID &= "VII"
                Case 8 : strNewID &= "VIII"
                Case 9 : strNewID &= "IX"
                Case 10 : strNewID &= "X"
                Case 11 : strNewID &= "XI"
                Case 12 : strNewID &= "XII"
            End Select
            strNewID &= "/"
            strNewID &= Format(DL.AccountReceivable.GetMaxNo(sqlCon, sqlTrans, dtmTransDate.Year, intCompanyID, intProgramID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.AccountReceivable) As String
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
                                        ByVal bolNew As Boolean, ByVal clsData As VO.AccountReceivable) As String
            Try
                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    clsData.ARNumber = GetNewNo(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtItem As New DataTable

                    If clsData.Modules.Trim = VO.AccountReceivable.SalesBalance Then
                        dtItem = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPayment Or
                        clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Or
                        clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Or
                        clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                        dtItem = DL.AccountReceivable.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        dtItem.Merge(DL.AccountReceivable.ListDataDetailRev01(sqlCon, sqlTrans, clsData.ID))
                    End If

                    DL.AccountReceivable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                    '# Revert Payment Amount
                    For Each dr As DataRow In dtItem.Rows
                        If clsData.Modules.Trim = VO.AccountReceivable.SalesBalance Then
                            DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then
                            DL.SalesContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                            DL.Delivery.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"), clsData.Modules)
                        ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then
                            DL.OrderRequest.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        End If
                    Next

                    '# Revert Down Payment
                    Dim dtDownPayment As DataTable = DL.AccountReceivable.ListDataDownPayment(sqlCon, sqlTrans, clsData.ID)
                    DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDownPayment.Rows
                        DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Sales)
                    Next

                    Dim clsExists As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, clsData.ID)
                    If clsExists.TotalAmountUsed > 0 Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                    End If
                End If

                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountReceivable.DataExists(sqlCon, sqlTrans, clsData.ARNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.ARNumber & " sudah ada.")
                End If

                clsData.DueDate = clsData.ARDate.AddDays(clsData.DueDateValue)
                DL.AccountReceivable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ARID = clsData.ID
                    DL.AccountReceivable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Save Data Down Payment
                intCount = 1
                For Each clsDet As VO.ARAPDP In clsData.ARAPDownPayment
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ParentID = clsData.ID
                    DL.ARAP.SaveDataDP(sqlCon, sqlTrans, clsDet)
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, clsDet.DPID, VO.ARAP.ARAPTypeValue.Sales)
                    intCount += 1
                Next

                '# Calculate Payment Amount
                For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    If clsData.Modules = VO.AccountReceivable.SalesBalance Then
                        DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.SalesID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then
                        DL.SalesContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.SalesID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                        DL.Delivery.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.SalesID, clsData.Modules)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then
                        DL.OrderRequest.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.SalesID)
                    End If
                Next

                '# Calculate Sales Contract
                If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then DL.SalesContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)
                '# Calculate Order Request
                If clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.OrderRequest.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ARNumber
        End Function

        Public Shared Function SaveDataVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal bolNew As Boolean, ByVal clsData As VO.AccountReceivable) As String
            Try
                Dim clsHelper As New DataSetHelper
                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                    dtReferencesItem = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, "")
                    For Each dr As DataRow In dtReferencesItem.Rows
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then dtReferencesSubItem.Merge(DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, dr.Item("ID")))
                    Next
                ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                    dtReferencesItem = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID)
                End If

                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    If clsData.ARNumber.Trim = "" Then clsData.ARNumber = GetNewNo(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtItem As New DataTable
                    Dim dtDetailItem As New DataTable
                    If clsData.Modules.Trim = VO.AccountReceivable.SalesBalance Then
                        dtItem = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.DownPayment Or
                        clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Or
                        clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Or
                        clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then

                        dtItem = DL.AccountReceivable.ListDataDetailOnly(sqlCon, sqlTrans, clsData.ID)
                        dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, clsData.ID)
                    End If

                    DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDetailItem.Rows
                        '# Revert Payment Item Amount
                        If clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then DL.SalesContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Or clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.Delivery.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"), clsData.Modules.Trim)
                        If clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then DL.OrderRequest.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    Next

                    clsHelper = New DataSetHelper
                    Dim dtReferencesParentID As DataTable = clsHelper.SelectGroupByInto("ReferencesParentID", dtDetailItem, "ReferencesParentID", "", "ReferencesParentID")
                    For Each dr As DataRow In dtReferencesParentID.Rows
                        '# Revert Payment Item Parent Amount
                        If clsData.Modules.Trim = VO.AccountReceivable.DownPayment And dr.Item("ReferencesParentID") <> "" Then DL.SalesContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment And dr.Item("ReferencesParentID") <> "" Then DL.Delivery.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    Next

                    '# Revert Payment Amount
                    DL.AccountReceivable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtItem.Rows
                        If clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then DL.SalesContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Or clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.Delivery.CalculateTotalUsedReceivePaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        If clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then DL.OrderRequest.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))

                        If clsData.Modules.Trim = VO.AccountReceivable.SalesBalance Then
                            DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        End If
                    Next

                    '# Revert Sales Contract Detail Receive Amount
                    If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                        '# Calculate Sub Item if Exists
                        For Each dr As DataRow In dtReferencesSubItem.Rows
                            DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next

                        '# Calculate Item
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next

                        If dtReferencesSubItem.Rows.Count > 0 Then
                            'Calculate Header
                            Dim strPrevSalesID As String = ""
                            For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                                If strPrevSalesID <> clsDet.SalesID Then
                                    DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, clsDet.SalesID)
                                    strPrevSalesID = clsDet.SalesID
                                End If
                            Next

                            '# Calculate Sales Detail Item Parent
                            For Each dr As DataRow In dtReferencesItem.Rows
                                DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                            Next
                        End If

                        '# Calculate Sales Contract Header
                        DL.SalesContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                        ''# Calculate Sub Item if Exists
                        'For Each dr As DataRow In dtReferencesSubItem.Rows
                        '    DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        'Next

                        '# Calculate Item
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next

                        'If dtReferencesSubItem.Rows.Count > 0 Then
                        '    'Calculate Header
                        '    Dim strPrevSalesID As String = ""
                        '    For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                        '        If strPrevSalesID <> clsDet.SalesID Then
                        '            DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, clsDet.SalesID)
                        '            strPrevSalesID = clsDet.SalesID
                        '        End If
                        '    Next

                        '    '# Calculate Sales Detail Item Parent
                        '    For Each dr As DataRow In dtReferencesItem.Rows
                        '        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        '    Next
                        'End If

                        '# Calculate Order Request Header
                        DL.OrderRequest.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                    End If
                    '# -------------------

                    '# Revert Down Payment
                    Dim dtDownPayment As DataTable = DL.AccountReceivable.ListDataDownPayment(sqlCon, sqlTrans, clsData.ID)
                    DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDownPayment.Rows
                        DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Sales)
                    Next

                    Dim clsExists As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, clsData.ID)
                    If clsExists.TotalAmountUsed > 0 Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                    End If
                End If

                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountReceivable.DataExists(sqlCon, sqlTrans, clsData.ARNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.ARNumber & " sudah ada.")
                End If

                clsData.DueDate = clsData.ARDate.AddDays(clsData.DueDateValue)
                DL.AccountReceivable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ARID = clsData.ID
                    DL.AccountReceivable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Save Data Detail Item
                intCount = 1
                For Each clsItem As VO.ARAPItem In clsData.ARAPItem
                    clsItem.ID = clsData.ID & "-" & 2 & "-" & Format(intCount, "000")
                    clsItem.ParentID = clsData.ID
                    DL.ARAP.SaveDataItem(sqlCon, sqlTrans, clsItem)

                    '# Calculate Payment Amount Item
                    If clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then DL.SalesContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Or clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.Delivery.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID, clsData.Modules.Trim)
                    If clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then DL.OrderRequest.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID)

                    intCount += 1
                Next

                Dim strReferencesParentIDExists As String = ""
                For Each clsItem As VO.ARAPItem In clsData.ARAPItem
                    If strReferencesParentIDExists <> clsItem.ReferencesParentID Then
                        If clsData.Modules.Trim = VO.AccountReceivable.DownPayment And clsItem.ReferencesParentID.Trim <> "" Then DL.SalesContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment And clsItem.ReferencesParentID.Trim <> "" Then DL.Delivery.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                        strReferencesParentIDExists = clsItem.ReferencesParentID
                    End If
                Next

                '# Save Data Down Payment
                intCount = 1
                For Each clsDet As VO.ARAPDP In clsData.ARAPDownPayment
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ParentID = clsData.ID
                    DL.ARAP.SaveDataDP(sqlCon, sqlTrans, clsDet)
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, clsDet.DPID, VO.ARAP.ARAPTypeValue.Sales)
                    intCount += 1
                Next

                '# Calculate Payment Amount
                For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    'If clsData.Modules = VO.AccountReceivable.SalesBalance Then DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.SalesID)
                    If clsData.Modules.Trim = VO.AccountReceivable.DownPayment Then DL.SalesContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, clsDet.SalesID)
                    If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Or clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.Delivery.CalculateTotalUsedReceivePaymentVer1(sqlCon, sqlTrans, clsDet.SalesID)
                    If clsData.Modules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then DL.OrderRequest.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, clsDet.SalesID)

                Next

                '# Calculate Sales Contract
                If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then

                    '# Calculate Sub Item if Exists
                    For Each dr As DataRow In dtReferencesSubItem.Rows
                        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    '# Calculate Item
                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    If dtReferencesSubItem.Rows.Count > 0 Then
                        'Calculate Header
                        For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                            DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, clsDet.SalesID)
                        Next

                        '# Calculate Sales Detail Item Parent
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next
                    End If

                    '# Calculate Sales Contract Header
                    DL.SalesContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then

                    ''# Calculate Sub Item if Exists
                    'For Each dr As DataRow In dtReferencesSubItem.Rows
                    '    DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    'Next

                    '# Calculate Item
                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    'If dtReferencesSubItem.Rows.Count > 0 Then
                    '    'Calculate Header
                    '    For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    '        DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, clsDet.SalesID)
                    '    Next

                    '    '# Calculate Purchase Detail Item Parent
                    '    For Each dr As DataRow In dtReferencesItem.Rows
                    '        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    '    Next
                    'End If

                    '# Calculate Order Request Header
                    DL.OrderRequest.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                End If

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ARNumber
        End Function

        Public Shared Function SaveDataVer02_ReceivePayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal bolNew As Boolean, ByVal clsData As VO.AccountReceivable) As String
            Try
                Dim clsHelper As New DataSetHelper
                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                    dtReferencesItem = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, "")
                    For Each dr As DataRow In dtReferencesItem.Rows
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then dtReferencesSubItem.Merge(DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, dr.Item("ID")))
                    Next
                ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                    dtReferencesItem = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID)
                End If

                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    If clsData.ARNumber = "" Then clsData.ARNumber = GetNewNo(sqlCon, sqlTrans, clsData.ARDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtItem As New DataTable
                    Dim dtDetailItem As New DataTable
                    If clsData.Modules.Trim = VO.AccountReceivable.SalesBalance Then
                        dtItem = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Or
                        clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then

                        dtItem = DL.AccountReceivable.ListDataDetailOnly(sqlCon, sqlTrans, clsData.ID)
                        dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, clsData.ID)
                    End If

                    DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDetailItem.Rows
                        '# Revert Payment Item Amount / Transaction Detail Item
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                    Next

                    DL.AccountReceivable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                    '# Revert Sales Contract Detail Receive Amount
                    If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then
                        '# Calculate Sales Contract Header
                        DL.SalesContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)
                    ElseIf clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                        '# Calculate Order Request Header
                        DL.OrderRequest.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)
                    End If
                    '# -------------------

                    '# Revert Down Payment
                    Dim dtDownPayment As DataTable = DL.AccountReceivable.ListDataDownPayment(sqlCon, sqlTrans, clsData.ID)
                    DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDownPayment.Rows
                        DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Sales)
                    Next

                    Dim clsExists As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, clsData.ID)
                    If clsExists.TotalAmountUsed > 0 Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                    End If
                End If

                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountReceivable.DataExists(sqlCon, sqlTrans, clsData.ARNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.ARNumber & " sudah ada.")
                End If

                clsData.DueDate = clsData.ARDate.AddDays(clsData.DueDateValue)
                DL.AccountReceivable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountReceivableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ARID = clsData.ID
                    DL.AccountReceivable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Save Data Detail Item
                intCount = 1
                For Each clsItem As VO.ARAPItem In clsData.ARAPItem
                    clsItem.ID = clsData.ID & "-" & 2 & "-" & Format(intCount, "000")
                    clsItem.ParentID = clsData.ID
                    DL.ARAP.SaveDataItem(sqlCon, sqlTrans, clsItem)

                    '# Calculate Payment Item Amount / Transaction Detail Item
                    If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                    intCount += 1
                Next

                '# Calculate Transaction Header
                If clsData.Modules.Trim = VO.AccountReceivable.ReceivePayment Then DL.SalesContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)
                If clsData.Modules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.OrderRequest.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)

                '# Save Data Down Payment
                intCount = 1
                For Each clsDet As VO.ARAPDP In clsData.ARAPDownPayment
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ParentID = clsData.ID
                    DL.ARAP.SaveDataDP(sqlCon, sqlTrans, clsDet)
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, clsDet.DPID, VO.ARAP.ARAPTypeValue.Sales)
                    intCount += 1
                Next

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.ARNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.AccountReceivable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DeleteData(sqlCon, sqlTrans, strID, strModules, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            Try
                Dim clsExists As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                ElseIf clsExists.TotalAmountUsed > 0 Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                End If

                Dim dtItem As New DataTable
                If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                    dtItem = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
                ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Or
                    strModules.Trim = VO.AccountReceivable.ReceivePayment Then
                    dtItem = DL.AccountReceivable.ListDataDetail(sqlCon, sqlTrans, strID)
                    dtItem.Merge(DL.AccountReceivable.ListDataDetailRev01(sqlCon, sqlTrans, strID))
                End If

                DL.AccountReceivable.DeleteData(sqlCon, sqlTrans, strID)

                '# Revert Payment Amount
                For Each dr As DataRow In dtItem.Rows
                    If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                        DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Then
                        DL.SalesContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.ReceivePayment Then
                        DL.Delivery.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"), strModules)
                    End If
                Next

                '# Revert Down Payment
                Dim dtDownPayment As DataTable = DL.AccountReceivable.ListDataDownPayment(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDownPayment.Rows
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Sales)
                Next

                '# Calculate Sales Contract
                If strModules.Trim = VO.AccountReceivable.ReceivePayment Then DL.SalesContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            Try
                Dim clsExists As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                ElseIf clsExists.TotalAmountUsed > 0 Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                End If

                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                Dim dtDetail As New DataTable
                Dim dtDetailItem As New DataTable
                If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                    dtDetail = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
                ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Or
                    strModules.Trim = VO.AccountReceivable.ReceivePayment Or
                    strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Or
                    strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                    dtDetail = DL.AccountReceivable.ListDataDetailOnly(sqlCon, sqlTrans, strID)
                    dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, strID)

                    If strModules.Trim = VO.AccountReceivable.DownPayment Or strModules.Trim = VO.AccountReceivable.ReceivePayment Then dtReferencesItem = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, "")
                    If strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Or strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then dtReferencesItem = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID)

                    For Each dr As DataRow In dtReferencesItem.Rows
                        If strModules.Trim = VO.AccountReceivable.DownPayment Or strModules.Trim = VO.AccountReceivable.ReceivePayment Then dtReferencesSubItem.Merge(DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, dr.Item("ID")))
                    Next
                End If

                DL.AccountReceivable.DeleteData(sqlCon, sqlTrans, strID)
                DL.AccountReceivable.DeleteDataDetail(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)

                '# Revert Payment Item Amount
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDetailItem.Rows
                    If strModules.Trim = VO.AccountReceivable.DownPayment Then DL.SalesContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountReceivable.ReceivePayment Then DL.Delivery.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"), strModules.Trim)
                    If strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then DL.OrderRequest.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                Next

                Dim clsHelper As New DataSetHelper
                Dim dtReferencesParentID As DataTable = clsHelper.SelectGroupByInto("ReferencesParentID", dtDetailItem, "ReferencesParentID", "", "ReferencesParentID")
                For Each dr As DataRow In dtReferencesParentID.Rows
                    '# Revert Payment Item Parent Amount
                    If strModules.Trim = VO.AccountReceivable.DownPayment And dr.Item("ReferencesParentID") <> "" Then DL.SalesContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    If strModules.Trim = VO.AccountReceivable.ReceivePayment And dr.Item("ReferencesParentID") <> "" Then DL.Delivery.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))

                Next

                '# Revert Payment Amount
                For Each dr As DataRow In dtDetail.Rows
                    If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                        DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Then
                        DL.SalesContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.ReceivePayment Then
                        DL.Delivery.CalculateTotalUsedReceivePaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then
                        DL.OrderRequest.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    End If
                Next

                '# Revert Down Payment
                Dim dtDownPayment As DataTable = DL.AccountReceivable.ListDataDownPayment(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDownPayment.Rows
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Sales)
                Next

                '# Calculate Sales Contract
                If strModules.Trim = VO.AccountReceivable.ReceivePayment Then

                    '# Calculate Sub Item if Exists
                    For Each dr As DataRow In dtReferencesSubItem.Rows
                        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    If dtReferencesSubItem.Rows.Count > 0 Then
                        'Calculate Header
                        Dim strInvoiceID As String = ""
                        For Each dr As DataRow In dtDetail.Rows
                            If strInvoiceID <> dr.Item("InvoiceID") Then
                                DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                                strInvoiceID = dr.Item("InvoiceID")
                            End If
                        Next

                        '# Calculate Sales Detail Item Parent
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next
                    End If

                    '# Calculate Sales Contract
                    DL.SalesContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)

                ElseIf strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then

                    ''# Calculate Sub Item if Exists
                    'For Each dr As DataRow In dtReferencesSubItem.Rows
                    '    DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    'Next

                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    'If dtReferencesSubItem.Rows.Count > 0 Then
                    '    'Calculate Header
                    '    Dim strInvoiceID As String = ""
                    '    For Each dr As DataRow In dtDetail.Rows
                    '        If strInvoiceID <> dr.Item("InvoiceID") Then
                    '            DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    '            strInvoiceID = dr.Item("InvoiceID")
                    '        End If
                    '    Next

                    '    '# Calculate Sales Detail Item Parent
                    '    For Each dr As DataRow In dtReferencesItem.Rows
                    '        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    '    Next
                    'End If

                    '# Calculate Order Request
                    DL.OrderRequest.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)

                End If

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            Try
                Dim clsExists As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                ElseIf clsExists.TotalAmountUsed > 0 Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                End If

                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                Dim dtDetail As New DataTable
                Dim dtDetailItem As New DataTable
                If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                    dtDetail = DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
                ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Or
                    strModules.Trim = VO.AccountReceivable.ReceivePayment Or
                    strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Or
                    strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                    dtDetail = DL.AccountReceivable.ListDataDetailOnly(sqlCon, sqlTrans, strID)
                    dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, strID)

                    If strModules.Trim = VO.AccountReceivable.DownPayment Or strModules.Trim = VO.AccountReceivable.ReceivePayment Then dtReferencesItem = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, "")
                    If strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Or strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then dtReferencesItem = DL.OrderRequest.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID)

                    For Each dr As DataRow In dtReferencesItem.Rows
                        If strModules.Trim = VO.AccountReceivable.DownPayment Or strModules.Trim = VO.AccountReceivable.ReceivePayment Then dtReferencesSubItem.Merge(DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, dr.Item("ID")))
                    Next
                End If

                DL.AccountReceivable.DeleteData(sqlCon, sqlTrans, strID)
                DL.AccountReceivable.DeleteDataDetail(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)

                '# Revert Payment Item Amount
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDetailItem.Rows
                    If strModules.Trim = VO.AccountReceivable.DownPayment Then DL.SalesContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountReceivable.ReceivePayment Then DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then DL.OrderRequest.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                Next

                Dim clsHelper As New DataSetHelper
                Dim dtReferencesParentID As DataTable = clsHelper.SelectGroupByInto("ReferencesParentID", dtDetailItem, "ReferencesParentID", "", "ReferencesParentID")
                For Each dr As DataRow In dtReferencesParentID.Rows
                    '# Revert Payment Item Parent Amount
                    If strModules.Trim = VO.AccountReceivable.DownPayment And dr.Item("ReferencesParentID") <> "" Then DL.SalesContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    'If strModules.Trim = VO.AccountReceivable.ReceivePayment And dr.Item("ReferencesParentID") <> "" Then DL.Delivery.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))

                Next

                '# Revert Payment Amount
                For Each dr As DataRow In dtDetail.Rows
                    If strModules.Trim = VO.AccountReceivable.SalesBalance Then
                        DL.BusinessPartnerARBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.DownPayment Then
                        DL.SalesContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.ReceivePayment Then
                        DL.SalesContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.DownPaymentOrderRequest Then
                        DL.OrderRequest.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then
                        DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    End If
                Next

                '# Revert Down Payment
                Dim dtDownPayment As DataTable = DL.AccountReceivable.ListDataDownPayment(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDownPayment.Rows
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Sales)
                Next

                '# Calculate Sales Contract
                If strModules.Trim = VO.AccountReceivable.ReceivePayment Then

                    ''# Calculate Sub Item if Exists
                    'For Each dr As DataRow In dtReferencesSubItem.Rows
                    '    DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ID"))
                    'Next

                    'For Each dr As DataRow In dtReferencesItem.Rows
                    '    DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ID"))
                    'Next

                    'If dtReferencesSubItem.Rows.Count > 0 Then
                    '    'Calculate Header
                    '    Dim strInvoiceID As String = ""
                    '    For Each dr As DataRow In dtDetail.Rows
                    '        If strInvoiceID <> dr.Item("InvoiceID") Then
                    '            DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    '            strInvoiceID = dr.Item("InvoiceID")
                    '        End If
                    '    Next

                    '    '# Calculate Sales Detail Item Parent
                    '    For Each dr As DataRow In dtReferencesItem.Rows
                    '        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    '    Next
                    'End If

                    '# Calculate Sales Contract
                    DL.SalesContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsExists.ReferencesID)

                ElseIf strModules.Trim = VO.AccountReceivable.ReceivePaymentOrderRequest Then

                    ''# Calculate Sub Item if Exists
                    'For Each dr As DataRow In dtReferencesSubItem.Rows
                    '    DL.SalesContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    'Next

                    'For Each dr As DataRow In dtReferencesItem.Rows
                    '    DL.OrderRequest.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    'Next

                    'If dtReferencesSubItem.Rows.Count > 0 Then
                    '    'Calculate Header
                    '    Dim strInvoiceID As String = ""
                    '    For Each dr As DataRow In dtDetail.Rows
                    '        If strInvoiceID <> dr.Item("InvoiceID") Then
                    '            DL.Delivery.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    '            strInvoiceID = dr.Item("InvoiceID")
                    '        End If
                    '    Next

                    '    '# Calculate Sales Detail Item Parent
                    '    For Each dr As DataRow In dtReferencesItem.Rows
                    '        DL.SalesContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    '    Next
                    'End If

                    '# Calculate Order Request
                    DL.OrderRequest.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsExists.ReferencesID)

                End If

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function Submit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = Submit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                    bolReturn = True
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Submit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                 ByVal strID As String, ByVal strRemarks As String)
            Dim bolReturn As Boolean = False
            Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf intStatusID = VO.Status.Values.Payment Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah DIBAYAR")
            ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.AccountReceivable.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
            bolReturn = True
            Return bolReturn
        End Function

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = Unsubmit(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unsubmit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal submit. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                End If

                DL.AccountReceivable.Unsubmit(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function Approve(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = Approve(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Approve(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                If clsData.StatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                ElseIf clsData.StatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                ElseIf clsData.StatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf clsData.IsDeleted Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                End If

                DL.AccountReceivable.Approve(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                If Not clsData.IsDP Then GenerateJournal(sqlCon, sqlTrans, strID)
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function Unapprove(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Unapprove(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Unapprove(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                If clsData.StatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                ElseIf clsData.StatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                ElseIf clsData.StatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf clsData.IsDeleted Then
                    Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                End If

                If Not clsData.IsDP Then
                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")
                End If

                '# Unapprove Account Receivable
                DL.AccountReceivable.Unapprove(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function SetupPayment(ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                            ByVal strRemarks As String, ByVal intCoAIDOfIncomePayment As Integer) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks, intCoAIDOfIncomePayment)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                            ByVal strRemarks As String, ByVal intCoAIDOfIncomePayment As Integer) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data telah DIBAYAR")
                ElseIf intStatusID <> VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data harus disetujui terlebih dahulu")
                End If

                DL.AccountReceivable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, intCoAIDOfIncomePayment)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)

                '# Generate Journal
                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                If clsData.IsDP Then
                    GenerateJournal(sqlCon, sqlTrans, strID)
                Else
                    GenerateJournalInvoice(sqlCon, sqlTrans, strID)
                End If
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function SetupCancelPayment(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = SetupCancelPayment(sqlCon, sqlTrans, strID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function SetupCancelPayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean
            Try
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID <> VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data belum pernah diproses BAYAR")
                End If

                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                If clsData.IsDP Then
                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(sqlCon, sqlTrans, clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(sqlCon, sqlTrans, clsData.JournalID.Trim, "")
                Else
                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(sqlCon, sqlTrans, clsData.JournalIDInvoice.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(sqlCon, sqlTrans, clsData.JournalIDInvoice.Trim, "")
                End If

                DL.AccountReceivable.SetupCancelPayment(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function UpdateTaxInvoiceNumber(ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                      ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UpdateTaxInvoiceNumber(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                      ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data telah dihapus")
                End If

                DL.AccountReceivable.UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE NOMOR FAKTUR PAJAK", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function UpdateInvoiceNumberSupplier(ByVal strID As String, ByVal strInvoiceNumberSupplier As String,
                                                           ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = UpdateInvoiceNumberSupplier(sqlCon, sqlTrans, strID, strInvoiceNumberSupplier, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UpdateInvoiceNumberSupplier(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                           ByVal strID As String, ByVal strInvoiceNumberSupplier As String,
                                                           ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean
            Try
                Dim intStatusID As Integer = DL.AccountReceivable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountReceivable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data telah dihapus")
                End If

                DL.AccountReceivable.UpdateInvoiceNumberSupplier(sqlCon, sqlTrans, strID, strInvoiceNumberSupplier)

                '# Save Data Status
                BL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE NOMOR FAKTUR PAJAK", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try
                '# Generate Journal
                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0
                Dim clsJournalDetail As New List(Of VO.JournalDet)
                If clsData.IsDP Then '# Pembayaran DP
                    '# Akun Kas / Bank -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAIDOfIncomePayment,
                                         .DebitAmount = clsData.TotalAmount + clsData.TotalPPN,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    '# Akun Panjar Penjualan -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncome,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.TotalAmount,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    '# Akun PPN -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofSalesTax,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.TotalPPN,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })
                    decTotalAmount += clsData.TotalAmount + clsData.TotalPPN

                    '# Setup Akun PPH
                    If clsData.TotalPPH > 0 Then
                        intGroupID += 1
                        '# Akun PPH -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHSales,
                                                 .DebitAmount = clsData.TotalPPH,
                                                 .CreditAmount = 0,
                                                 .Remarks = "",
                                                 .GroupID = intGroupID,
                                                 .BPID = clsData.BPID
                                             })

                        '# Akun Kas / Bank -> Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                             {
                                                 .CoAID = clsData.CoAIDOfIncomePayment,
                                                 .DebitAmount = 0,
                                                 .CreditAmount = clsData.TotalPPH,
                                                 .Remarks = "",
                                                 .GroupID = intGroupID,
                                                 .BPID = clsData.BPID
                                             })
                        decTotalAmount += clsData.TotalPPH
                    End If
                Else
                    '# Akun Piutang -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivable,
                                             .DebitAmount = clsData.ReceiveAmount + clsData.DPAmount + clsData.TotalPPN,
                                             .CreditAmount = 0,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })

                    '# Akun Piutang Belum Ditagih -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivableOutstandingPayment,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsData.ReceiveAmount + clsData.DPAmount,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })

                    '# Akun PPN -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofSalesTax,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsData.TotalPPN,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })
                    decTotalAmount += clsData.ReceiveAmount + clsData.DPAmount + clsData.TotalPPN

                    '# Setup / Cross Akun DP
                    If clsData.DPAmount > 0 Then
                        intGroupID += 1

                        '# Akun Uang Muka Penjualan -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncome,
                                         .DebitAmount = clsData.DPAmount,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                        '# Akun Piutang Usaha -> Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivable,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.DPAmount,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                        decTotalAmount += clsData.DPAmount
                    End If
                End If

                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = clsData.ARDate,
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.ARNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Account Receivable
                DL.AccountReceivable.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub GenerateJournalInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String)
            Try
                '# Generate Journal
                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalIDInvoice)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0
                Dim clsJournalDetail As New List(Of VO.JournalDet)

                '# Akun Kas / Bank -> Debit
                clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = clsData.CoAIDOfIncomePayment,
                                             .DebitAmount = clsData.ReceiveAmount + clsData.TotalPPN,
                                             .CreditAmount = 0,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })

                '# Akun Piutang Usaha -> Kredit
                clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivable,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsData.ReceiveAmount + clsData.TotalPPN,
                                             .Remarks = "",
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })
                decTotalAmount += clsData.ReceiveAmount + clsData.TotalPPN

                '# Setup Akun PPH
                If clsData.TotalPPH > 0 Then
                    intGroupID += 1

                    '# Akun PPH -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHSales,
                                         .DebitAmount = clsData.TotalPPH,
                                         .CreditAmount = 0,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    '# Akun Kas / Bank -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAIDOfIncomePayment,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.TotalPPH,
                                         .Remarks = "",
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    decTotalAmount += clsData.TotalPPH
                End If

                Dim clsJournal As New VO.Journal With
                {
                    .ProgramID = clsData.ProgramID,
                    .CompanyID = clsData.CompanyID,
                    .ID = PrevJournal.ID,
                    .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                    .ReferencesID = clsData.ID,
                    .JournalDate = clsData.PaymentDate,
                    .TotalAmount = decTotalAmount,
                    .IsAutoGenerate = True,
                    .StatusID = VO.Status.Values.Draft,
                    .Remarks = clsData.Remarks,
                    .LogBy = ERPSLib.UI.usUserApp.UserID,
                    .Initial = "",
                    .ReferencesNo = clsData.ARNumber,
                    .Detail = clsJournalDetail,
                    .Save = VO.Save.Action.SaveAndSubmit
                }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Account Receivable
                DL.AccountReceivable.UpdateJournalIDInvoice(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateCompanyBankAccount(ByVal strID As String, ByVal intCompanyBankAccountID1 As Integer,
                                                   ByVal intCompanyBankAccountID2 As Integer, ByVal strPaymentTerm1 As String,
                                                   ByVal strPaymentTerm2 As String, ByVal strPaymentTerm3 As String,
                                                   ByVal strPaymentTerm4 As String, ByVal strPaymentTerm5 As String,
                                                   ByVal strPaymentTerm6 As String, ByVal strPaymentTerm7 As String,
                                                   ByVal strPaymentTerm8 As String, ByVal strPaymentTerm9 As String,
                                                   ByVal strPaymentTerm10 As String, ByVal strSCID As String, ByVal strReferencesNumber As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.AccountReceivable.UpdateCompanyBankAccount(sqlCon, sqlTrans, strID, intCompanyBankAccountID1, intCompanyBankAccountID2,
                                                                  strPaymentTerm1, strPaymentTerm2, strPaymentTerm3, strPaymentTerm4, strPaymentTerm5,
                                                                  strPaymentTerm6, strPaymentTerm7, strPaymentTerm8, strPaymentTerm9, strPaymentTerm10)

                    DL.SalesContract.UpdateReferencesNumber(sqlCon, sqlTrans, strSCID, strReferencesNumber)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Function GetLastBankAccount(ByVal strID As String) As VO.AccountReceivable

            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.AccountReceivable = DL.AccountReceivable.GetDetail(sqlCon, Nothing, strID)
                Return DL.AccountReceivable.GetDetail(sqlCon, Nothing, clsData.CompanyID, clsData.ProgramID, clsData.BPID, strID)
            End Using
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetailForSetupBalance(ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailForSetupBalance(sqlCon, Nothing, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetailForSetupBalanceWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                            ByVal intBPID As Integer, ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailForSetupBalanceWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetail(ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetail(sqlCon, Nothing, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                             ByVal intBPID As Integer, ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetailRev01(ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailRev01(sqlCon, Nothing, strARID)
            End Using
        End Function

        Public Shared Function ListDataDetailRev02(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailRev02(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstandingRev01(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strARID As String,
                                                                  ByVal strReferencesID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailWithOutstandingRev01(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strARID, strReferencesID)
            End Using
        End Function

        Public Shared Function ListDataDetailItemDPWithOutstandingRev02(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                        ByVal intBPID As Integer, ByVal strAPID As String,
                                                                        ByVal strReferencesID As String, ByVal bolIsUseSubItem As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailItemDPWithOutstandingVer02(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID, bolIsUseSubItem)
                'Return DL.AccountReceivable.ListDataDetailItemDPWithOutstandingVer01(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID, bolIsUseSubItem)
            End Using
        End Function

        Public Shared Function ListDataDetailItemReceiveWithOutstandingVer02(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                             ByVal intBPID As Integer, ByVal strAPID As String,
                                                                             ByVal strReferencesID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataDetailItemReceiveWithOutstandingVer02(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID)
                'Return DL.AccountReceivable.ListDataDetailItemReceiveWithOutstandingVer01(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strARID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountReceivable.ListDataStatus(sqlCon, Nothing, strARID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strARID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strARID & "-" & Format(DL.AccountReceivable.GetMaxIDStatus(sqlCon, sqlTrans, strARID) + 1, "000")
            Dim clsData As New VO.AccountReceivableStatus With
                {
                    .ID = strNewID,
                    .ARID = strARID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.AccountReceivable.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace