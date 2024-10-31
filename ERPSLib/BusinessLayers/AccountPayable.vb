Imports System.Diagnostics.Contracts
Imports ERPSLib.VO

Namespace BL
    Public Class AccountPayable

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strModules As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strModules, 0, "")
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal strModules As String) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "AP" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-" & strModules & "-"
            strNewID &= Format(DL.AccountPayable.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
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
            strNewID &= Format(DL.AccountPayable.GetMaxNo(sqlCon, sqlTrans, dtmTransDate.Year, intCompanyID, intProgramID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.AccountPayable) As String
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
                                        ByVal bolNew As Boolean, ByVal clsData As VO.AccountPayable) As String
            Try
                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    clsData.APNumber = GetNewNo(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtDetail As New DataTable

                    If clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                        dtDetail = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Or
                        clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
                        clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        dtDetail = DL.AccountPayable.ListDataDetail(sqlCon, sqlTrans, clsData.ID)
                        dtDetail.Merge(DL.AccountPayable.ListDataDetailRev01(sqlCon, sqlTrans, clsData.ID))
                    End If

                    DL.AccountPayable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)

                    '# Revert Payment Amount
                    For Each dr As DataRow In dtDetail.Rows
                        If clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                            DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Then
                            DL.PurchaseContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                            DL.Receive.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then
                            DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                            DL.Cutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                            DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                            DL.Delivery.CalculateTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        End If
                    Next

                    '# Revert Down Payment
                    Dim dtDownPayment As DataTable = DL.AccountPayable.ListDataDownPayment(sqlCon, sqlTrans, clsData.ID)
                    DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDownPayment.Rows
                        DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Purchase)
                    Next

                    Dim clsExists As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, clsData.ID)
                    If clsExists.TotalAmountUsed > 0 Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                    End If
                End If

                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountPayable.DataExists(sqlCon, sqlTrans, clsData.APNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.APNumber & " sudah ada.")
                End If

                clsData.DueDate = clsData.APDate.AddDays(clsData.DueDateValue)
                DL.AccountPayable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountPayableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.APID = clsData.ID
                    DL.AccountPayable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Save Data Down Payment
                intCount = 1
                For Each clsDet As VO.ARAPDP In clsData.ARAPDownPayment
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ParentID = clsData.ID
                    DL.ARAP.SaveDataDP(sqlCon, sqlTrans, clsDet)
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, clsDet.DPID, VO.ARAP.ARAPTypeValue.Purchase)
                    intCount += 1
                Next

                '# Allocate DP Amount to Each Receive
                '# On Progress

                '# Calculate Payment Amount
                For Each clsDet As VO.AccountPayableDet In clsData.Detail
                    If clsData.Modules = VO.AccountPayable.PurchaseBalance Then
                        DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Then
                        DL.PurchaseContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                        DL.Receive.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                        DL.Cutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                        DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        DL.Delivery.CalculateTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, clsDet.PurchaseID)
                    End If
                Next

                '# Add Validation, if DP Amount or Receive Amount more than Total Transaction Amount
                '# Add Validation, if Total DP Amount Used more than Total DP on going to Save.

                '# Calculate Purchase Contract / Purchase Order
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.PurchaseOrderTransport.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.APNumber
        End Function

        Public Shared Function SaveDataVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal bolNew As Boolean, ByVal clsData As VO.AccountPayable) As String
            Try
                Dim clsHelper As New DataSetHelper
                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                    dtReferencesItem = DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, "")
                    For Each dr As DataRow In dtReferencesItem.Rows
                        dtReferencesSubItem.Merge(DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, dr.Item("ID")))
                    Next
                End If

                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    clsData.APNumber = GetNewNo(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtDetail As New DataTable
                    Dim dtDetailItem As New DataTable
                    If clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                        dtDetail = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Or
                        clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
                        clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then

                        dtDetail = DL.AccountPayable.ListDataDetailOnly(sqlCon, sqlTrans, clsData.ID)
                        dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, clsData.ID)
                    End If

                    DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDetailItem.Rows
                        '# Revert Payment Item Amount
                        If clsData.Modules.Trim = VO.AccountPayable.DownPayment Then DL.PurchaseContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then DL.Receive.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then DL.PurchaseOrderCutting.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.Cutting.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateItemTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))

                        If clsData.Modules = VO.AccountPayable.PurchaseBalance Then
                            'DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.PurchaseID)
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                            'DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                        End If
                    Next

                    clsHelper = New DataSetHelper
                    Dim dtReferencesParentID As DataTable = clsHelper.SelectGroupByInto("ReferencesParentID", dtDetailItem, "ReferencesParentID", "", "ReferencesParentID")
                    For Each dr As DataRow In dtReferencesParentID.Rows
                        '# Revert Payment Item Parent Amount
                        If clsData.Modules.Trim = VO.AccountPayable.DownPayment And dr.Item("ReferencesParentID") <> "" Then DL.PurchaseContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And dr.Item("ReferencesParentID") <> "" Then DL.Receive.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    Next

                    '# Revert Payment Amount
                    DL.AccountPayable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDetail.Rows
                        If clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                            DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPayment Then
                            DL.PurchaseContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                            DL.Receive.CalculateTotalUsedReceivePaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then
                            DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                            DL.Cutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                            DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                            DL.Delivery.CalculateTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        End If
                    Next

                    '# Revert Purchase Contract Detail Receive Amount
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                        '# Calculate Sub Item if Exists
                        For Each dr As DataRow In dtReferencesSubItem.Rows
                            DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next

                        '# Calculate Item
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next

                        If dtReferencesSubItem.Rows.Count > 0 Then
                            'Calculate Header
                            Dim strPrevPurchaseID As String = ""
                            For Each clsDet As VO.AccountPayableDet In clsData.Detail
                                If strPrevPurchaseID <> clsDet.PurchaseID Then
                                    DL.Receive.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, clsDet.PurchaseID)
                                    strPrevPurchaseID = clsDet.PurchaseID
                                End If
                            Next

                            '# Calculate Purchase Detail Item Parent
                            For Each dr As DataRow In dtReferencesItem.Rows
                                DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                            Next
                        End If

                        '# Calculate Purchase Contract Header
                        DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                    End If
                    '# -------------------

                    '# Revert Down Payment
                    Dim dtDownPayment As DataTable = DL.AccountPayable.ListDataDownPayment(sqlCon, sqlTrans, clsData.ID)
                    DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDownPayment.Rows
                        DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Purchase)
                    Next

                    Dim clsExists As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, clsData.ID)
                    If clsExists.TotalAmountUsed > 0 Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                    End If
                End If

                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountPayable.DataExists(sqlCon, sqlTrans, clsData.APNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.APNumber & " sudah ada.")
                End If

                clsData.DueDate = clsData.APDate.AddDays(clsData.DueDateValue)
                DL.AccountPayable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountPayableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.APID = clsData.ID
                    DL.AccountPayable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Save Data Detail Item
                intCount = 1
                For Each clsItem As VO.ARAPItem In clsData.ARAPItem
                    clsItem.ID = clsData.ID & "-" & 2 & "-" & Format(intCount, "000")
                    clsItem.ParentID = clsData.ID
                    DL.ARAP.SaveDataItem(sqlCon, sqlTrans, clsItem)

                    '# Calculate Payment Amount Item
                    If clsData.Modules.Trim = VO.AccountPayable.DownPayment Then DL.PurchaseContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then DL.Receive.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then DL.PurchaseOrderCutting.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.Cutting.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateItemTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, clsItem.ReferencesID, clsItem.ReferencesDetailID)
                    intCount += 1
                Next

                Dim strReferencesParentIDExists As String = ""
                For Each clsItem As VO.ARAPItem In clsData.ARAPItem
                    If strReferencesParentIDExists <> clsItem.ReferencesParentID Then
                        If clsData.Modules.Trim = VO.AccountPayable.DownPayment And clsItem.ReferencesParentID.Trim <> "" Then DL.PurchaseContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsItem.ReferencesParentID.Trim <> "" Then DL.Receive.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                        strReferencesParentIDExists = clsItem.ReferencesParentID
                    End If
                Next

                '# Save Data Down Payment
                intCount = 1
                For Each clsDet As VO.ARAPDP In clsData.ARAPDownPayment
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ParentID = clsData.ID
                    DL.ARAP.SaveDataDP(sqlCon, sqlTrans, clsDet)
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, clsDet.DPID, VO.ARAP.ARAPTypeValue.Purchase)
                    intCount += 1
                Next

                '# Calculate Payment Amount
                For Each clsDet As VO.AccountPayableDet In clsData.Detail
                    If clsData.Modules.Trim = VO.AccountPayable.DownPayment Then DL.PurchaseContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, clsDet.PurchaseID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then DL.Receive.CalculateTotalUsedReceivePaymentVer1(sqlCon, sqlTrans, clsDet.PurchaseID)
                    If clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.Cutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, clsDet.PurchaseID)

                    'If clsData.Modules = VO.AccountPayable.PurchaseBalance Then
                    '    DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.PurchaseID)
                    'ElseIf clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then
                    '    DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    'End If
                Next

                '# Add Validation, if DP Amount or Receive Amount more than Total Transaction Amount
                '# Add Validation, if Total DP Amount Used more than Total DP on going to Save.

                If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then

                    '# Calculate Sub Item if Exists
                    For Each dr As DataRow In dtReferencesSubItem.Rows
                        DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    '# Calculate Item
                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    If dtReferencesSubItem.Rows.Count > 0 Then
                        'Calculate Header
                        For Each clsDet As VO.AccountPayableDet In clsData.Detail
                            DL.Receive.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, clsDet.PurchaseID)
                        Next

                        '# Calculate Purchase Detail Item Parent
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next

                    End If

                    '# Calculate Purchase Contract Header
                    DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                    '# Calculate Purchase Order
                    DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                    dtReferencesItem = DL.PurchaseOrderCutting.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID)
                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.PurchaseOrderCutting.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next
                End If

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.APNumber
        End Function

        Public Shared Function SaveDataVer02_ReceivePayment(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal bolNew As Boolean, ByVal clsData As VO.AccountPayable) As String
            Try
                Dim clsHelper As New DataSetHelper
                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Then
                    If clsData.PaymentTypeID = VO.PaymentType.Values.CBD Then
                        dtReferencesItem = DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, "")
                        For Each dr As DataRow In dtReferencesItem.Rows
                            dtReferencesSubItem.Merge(DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID, dr.Item("ID")))
                        Next
                    ElseIf clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                        dtReferencesItem = DL.Receive.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID)
                    End If

                End If

                If bolNew Then
                    clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID, clsData.Modules)
                    If clsData.APNumber = "" Then clsData.APNumber = GetNewNo(sqlCon, sqlTrans, clsData.APDate, clsData.CompanyID, clsData.ProgramID)
                Else
                    Dim dtDetail As New DataTable
                    Dim dtDetailItem As New DataTable
                    If clsData.Modules.Trim = VO.AccountPayable.PurchaseBalance Then
                        dtDetail = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, clsData.ID)
                    ElseIf clsData.Modules.Trim = VO.AccountPayable.ReceivePayment Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Or
                        clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentClaimSales Then

                        dtDetail = DL.AccountPayable.ListDataDetailOnly(sqlCon, sqlTrans, clsData.ID)
                        dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, clsData.ID)
                    End If

                    DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, clsData.ID)
                    Dim dtPurchaseContract As New DataTable
                    For Each dr As DataRow In dtDetailItem.Rows
                        '# Revert Payment Item Amount / Transaction Detail Item
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.CBD Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                            DL.Receive.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                            Dim strPCDetailID As String = DL.Receive.GetPCDetailID(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                            If strPCDetailID.Trim <> "" Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentTT30(sqlCon, sqlTrans, strPCDetailID)
                        End If
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateTotalUsedReceiveItemPaymentTransportVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentClaimSales Then DL.ConfirmationClaim.CalculateTotalUsedReceiveItemPaymentSalesVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                    Next

                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentTT30(sqlCon, sqlTrans, dr.Item("PCDetailID"))
                        Next
                    End If

                    clsHelper = New DataSetHelper
                    Dim dtReferencesParentID As DataTable = clsHelper.SelectGroupByInto("ReferencesParentID", dtDetailItem, "ReferencesParentID", "", "ReferencesParentID")
                    For Each dr As DataRow In dtReferencesParentID.Rows
                        '# Revert Payment Item Parent Amount | TODO Cutting and Sales Return
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.CBD And dr.Item("ReferencesParentID") <> "" Then DL.PurchaseContract.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days And dr.Item("ReferencesParentID") <> "" Then
                            DL.Receive.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                            Dim strPCDetailID As String = DL.Receive.GetPCDetailID(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                            If strPCDetailID.Trim <> "" Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentTT30(sqlCon, sqlTrans, strPCDetailID)
                        End If
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting And dr.Item("ReferencesParentID") <> "" Then DL.PurchaseOrderCutting.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    Next

                    '# Revert Payment Amount
                    DL.AccountPayable.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDetail.Rows
                        '# Calculate Header
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.CBD Then DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                            DL.Receive.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                            Dim clsReceive As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                            If clsReceive.PCID IsNot Nothing Then DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsReceive.PCID)
                        End If
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateTotalUsedReceivePaymentTransportVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentClaimSales Then DL.ConfirmationClaim.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    Next

                    '# Revert Down Payment
                    Dim dtDownPayment As DataTable = DL.AccountPayable.ListDataDownPayment(sqlCon, sqlTrans, clsData.ID)
                    DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, clsData.ID)
                    For Each dr As DataRow In dtDownPayment.Rows
                        DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Purchase)
                    Next

                    Dim clsExists As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, clsData.ID)
                    If clsExists.TotalAmountUsed > 0 Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah dipakai ditransaksi lain")
                    End If
                End If

                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                If intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                ElseIf intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                ElseIf DL.AccountPayable.DataExists(sqlCon, sqlTrans, clsData.APNumber, clsData.ID) Then
                    Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.APNumber & " sudah ada.")
                End If

                clsData.DueDate = clsData.APDate.AddDays(clsData.DueDateValue)
                DL.AccountPayable.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                '# Save Data Detail
                Dim intCount As Integer = 1
                For Each clsDet As VO.AccountPayableDet In clsData.Detail
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.APID = clsData.ID
                    DL.AccountPayable.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                    intCount += 1
                Next

                '# Save Data Detail Item
                intCount = 1
                For Each clsItem As VO.ARAPItem In clsData.ARAPItem
                    clsItem.ID = clsData.ID & "-" & 2 & "-" & Format(intCount, "000")
                    clsItem.ParentID = clsData.ID
                    DL.ARAP.SaveDataItem(sqlCon, sqlTrans, clsItem)

                    '# Calculate Payment Item Amount / Transaction Detail Item
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.CBD Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                        DL.Receive.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                        Dim strPCDetailID As String = DL.Receive.GetPCDetailID(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                        If strPCDetailID.Trim <> "" Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentTT30(sqlCon, sqlTrans, strPCDetailID)
                    End If
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateTotalUsedReceiveItemPaymentTransportVer02(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentClaimSales Then DL.ConfirmationClaim.CalculateTotalUsedReceiveItemPaymentSalesVer02(sqlCon, sqlTrans, clsItem.ReferencesDetailID)
                    intCount += 1
                Next

                '# Calculate Parent Item / Parent Sub Item
                Dim strReferencesParentIDExists As String = ""
                For Each clsItem As VO.ARAPItem In clsData.ARAPItem
                    If strReferencesParentIDExists <> clsItem.ReferencesParentID Then
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.CBD And clsItem.ReferencesParentID.Trim <> "" Then DL.PurchaseContract.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days And clsItem.ReferencesParentID.Trim <> "" Then
                            DL.Receive.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                            Dim strPCDetailID As String = DL.Receive.GetPCDetailID(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                            If strPCDetailID.Trim <> "" Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentTT30(sqlCon, sqlTrans, strPCDetailID)
                        End If
                        If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting And clsItem.ReferencesParentID.Trim <> "" Then DL.PurchaseOrderCutting.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, clsItem.ReferencesParentID)
                        strReferencesParentIDExists = clsItem.ReferencesParentID
                    End If
                Next

                '# Save Data Down Payment
                intCount = 1
                For Each clsDet As VO.ARAPDP In clsData.ARAPDownPayment
                    clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                    clsDet.ParentID = clsData.ID
                    DL.ARAP.SaveDataDP(sqlCon, sqlTrans, clsDet)
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, clsDet.DPID, VO.ARAP.ARAPTypeValue.Purchase)
                    intCount += 1
                Next

                '# Add Validation, if DP Amount or Receive Amount more than Total Transaction Amount
                '# Add Validation, if Total DP Amount Used more than Total DP on going to Save.

                '# Calculate Transaction Header
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.CBD Then DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePayment And clsData.PaymentTypeID = VO.PaymentType.Values.TT30Days Then
                    DL.Receive.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)
                    Dim clsReceive As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, clsData.ReferencesID)
                    If clsReceive.PCID IsNot Nothing Then DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsReceive.PCID)
                End If
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateTotalUsedReceivePaymentTransportVer02(sqlCon, sqlTrans, clsData.ReferencesID)
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentClaimSales Then DL.ConfirmationClaim.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsData.ReferencesID)

                'If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                '    '# Calculate Purchase Order
                '    DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsData.ReferencesID)

                '    dtReferencesItem = DL.PurchaseOrderCutting.ListDataDetail(sqlCon, sqlTrans, clsData.ReferencesID)
                '    For Each dr As DataRow In dtReferencesItem.Rows
                '        DL.PurchaseOrderCutting.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                '    Next
                'End If

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
            Catch ex As Exception
                Throw ex
            End Try
            Return clsData.APNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.AccountPayable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DeleteDataVer01(sqlCon, sqlTrans, strID, strModules, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        'Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
        '                             ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
        '    Try
        '        Dim clsExists As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
        '        Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
        '        If intStatusID = VO.Status.Values.Submit Then
        '            Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
        '        ElseIf intStatusID = VO.Status.Values.Approved Then
        '            Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
        '        ElseIf intStatusID = VO.Status.Values.Payment Then
        '            Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
        '        ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
        '            Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
        '        ElseIf clsExists.TotalAmountUsed > 0 Then
        '            Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah dipakai ditransaksi lain")
        '        End If

        '        Dim dtDetail As New DataTable
        '        If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
        '            dtDetail = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
        '        ElseIf strModules.Trim = VO.AccountPayable.DownPayment Or
        '            strModules.Trim = VO.AccountPayable.ReceivePayment Or
        '            strModules.Trim = VO.AccountPayable.DownPaymentCutting Or
        '            strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
        '            strModules.Trim = VO.AccountPayable.DownPaymentTransport Or
        '            strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
        '            dtDetail = DL.AccountPayable.ListDataDetail(sqlCon, sqlTrans, strID)
        '            dtDetail.Merge(DL.AccountPayable.ListDataDetailRev01(sqlCon, sqlTrans, strID))
        '        End If

        '        DL.AccountPayable.DeleteData(sqlCon, sqlTrans, strID)

        '        '# Revert Payment Amount
        '        For Each dr As DataRow In dtDetail.Rows
        '            If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
        '                DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
        '            ElseIf strModules.Trim = VO.AccountPayable.DownPayment Then
        '                DL.PurchaseContract.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
        '            ElseIf strModules.Trim = VO.AccountPayable.ReceivePayment Then
        '                DL.Receive.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
        '            ElseIf strModules.Trim = VO.AccountPayable.DownPaymentCutting Then
        '                DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
        '            ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
        '                DL.Cutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
        '            ElseIf strModules.Trim = VO.AccountPayable.DownPaymentTransport Then
        '                DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
        '            ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
        '                DL.Delivery.CalculateTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, dr.Item("InvoiceID"))
        '            End If
        '        Next

        '        '# Revert Down Payment
        '        Dim dtDownPayment As DataTable = DL.AccountPayable.ListDataDownPayment(sqlCon, sqlTrans, strID)
        '        DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, strID)
        '        For Each dr As DataRow In dtDownPayment.Rows
        '            DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Purchase)
        '        Next

        '        '# Calculate Purchase Contract / Purchase Order
        '        If strModules.Trim = VO.AccountPayable.ReceivePayment Then DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)
        '        If strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)
        '        If strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.PurchaseOrderTransport.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)

        '        '# Save Data Status
        '        BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub

        Public Shared Sub DeleteDataVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strModules As String, ByVal strRemarks As String)
            Try
                Dim clsExists As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                ElseIf clsExists.TotalAmountUsed > 0 Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah dipakai ditransaksi lain")
                End If

                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                Dim dtDetail As New DataTable
                Dim dtDetailItem As New DataTable
                If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                    dtDetail = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
                ElseIf strModules.Trim = VO.AccountPayable.DownPayment Or
                    strModules.Trim = VO.AccountPayable.ReceivePayment Or
                    strModules.Trim = VO.AccountPayable.DownPaymentCutting Or
                    strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
                    strModules.Trim = VO.AccountPayable.DownPaymentTransport Or
                    strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then

                    dtDetail = DL.AccountPayable.ListDataDetailOnly(sqlCon, sqlTrans, strID)
                    dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, strID)

                    dtReferencesItem = DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, "")
                    For Each dr As DataRow In dtReferencesItem.Rows
                        dtReferencesSubItem.Merge(DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, dr.Item("ID")))
                    Next
                End If

                DL.AccountPayable.DeleteData(sqlCon, sqlTrans, strID)
                DL.AccountPayable.DeleteDataDetail(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)

                '# Revert Payment Item Amount
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDetailItem.Rows
                    If strModules.Trim = VO.AccountPayable.DownPayment Then DL.PurchaseContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePayment Then DL.Receive.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.DownPaymentCutting Then DL.PurchaseOrderCutting.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.Cutting.CalculateItemTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateItemTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))

                    'If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                    '    'DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.PurchaseID)
                    'ElseIf strModules.Trim = VO.AccountPayable.DownPaymentTransport Then
                    '    'DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, clsDet.PurchaseID)
                    'End If
                Next

                Dim clsHelper As New DataSetHelper
                Dim dtReferencesParentID As DataTable = clsHelper.SelectGroupByInto("ReferencesParentID", dtDetailItem, "ReferencesParentID", "", "ReferencesParentID")
                For Each dr As DataRow In dtReferencesParentID.Rows
                    '# Revert Payment Item Parent Amount
                    If strModules.Trim = VO.AccountPayable.DownPayment And dr.Item("ReferencesParentID") <> "" Then DL.PurchaseContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePayment And dr.Item("ReferencesParentID") <> "" Then DL.Receive.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))

                Next

                '# Revert Payment Amount
                For Each dr As DataRow In dtDetail.Rows
                    If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                        DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPayment Then
                        DL.PurchaseContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePayment Then
                        DL.Receive.CalculateTotalUsedReceivePaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                        DL.Cutting.CalculateTotalUsedReceivePayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPaymentTransport Then
                        DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        DL.Delivery.CalculateTotalUsedReceivePaymentTransport(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    End If
                Next

                '# Revert Down Payment
                Dim dtDownPayment As DataTable = DL.AccountPayable.ListDataDownPayment(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDownPayment.Rows
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Purchase)
                Next

                If strModules.Trim = VO.AccountPayable.ReceivePayment Then

                    '# Calculate Sub Item if Exists
                    For Each dr As DataRow In dtReferencesSubItem.Rows
                        DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next

                    If dtReferencesSubItem.Rows.Count > 0 Then
                        'Calculate Header
                        Dim strInvoiceID As String = ""
                        For Each dr As DataRow In dtDetail.Rows
                            If strInvoiceID <> dr.Item("InvoiceID") Then
                                DL.Receive.CalculateTotalUsedReceivePaymentSubItemVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                                strInvoiceID = dr.Item("InvoiceID")
                            End If
                        Next

                        '# Calculate Purchase Detail Item Parent
                        For Each dr As DataRow In dtReferencesItem.Rows
                            DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentParentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                        Next
                    End If

                    '# Calculate Purchase Contract
                    DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)

                ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                    '# Calculate Purchase Contract / Purchase Order
                    DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer01(sqlCon, sqlTrans, clsExists.ReferencesID)
                    dtReferencesItem = DL.PurchaseOrderCutting.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID)
                    For Each dr As DataRow In dtReferencesItem.Rows
                        DL.PurchaseOrderCutting.CalculateTotalUsedReceiveItemPaymentVer01(sqlCon, sqlTrans, dr.Item("ID"))
                    Next
                End If

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String, ByVal strModules As String,
                                          ByVal strRemarks As String, ByVal intPaymentTypeID As Integer)
            Try
                Dim clsExists As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Submit Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                ElseIf clsExists.TotalAmountUsed > 0 Then
                    Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah dipakai ditransaksi lain")
                End If

                Dim dtReferencesItem As New DataTable
                Dim dtReferencesSubItem As New DataTable
                Dim dtDetail As New DataTable
                Dim dtDetailItem As New DataTable
                If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                    dtDetail = DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, sqlTrans, strID)
                ElseIf strModules.Trim = VO.AccountPayable.DownPayment Or
                    strModules.Trim = VO.AccountPayable.ReceivePayment Or
                    strModules.Trim = VO.AccountPayable.DownPaymentCutting Or
                    strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Or
                    strModules.Trim = VO.AccountPayable.DownPaymentTransport Or
                    strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then

                    dtDetail = DL.AccountPayable.ListDataDetailOnly(sqlCon, sqlTrans, strID)
                    dtDetailItem = DL.ARAP.ListDataDetailItemOnly(sqlCon, sqlTrans, strID)
                    If intPaymentTypeID = VO.PaymentType.Values.CBD Then
                        dtReferencesItem = DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, "")
                        For Each dr As DataRow In dtReferencesItem.Rows
                            dtReferencesSubItem.Merge(DL.PurchaseContract.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID, dr.Item("ID")))
                        Next
                    ElseIf intPaymentTypeID = VO.PaymentType.Values.TT30Days Then
                        dtReferencesItem = DL.Receive.ListDataDetail(sqlCon, sqlTrans, clsExists.ReferencesID)
                    End If
                End If

                DL.AccountPayable.DeleteData(sqlCon, sqlTrans, strID)
                DL.AccountPayable.DeleteDataDetail(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)

                '# Revert Payment Item Amount
                DL.ARAP.DeleteDataItem(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDetailItem.Rows
                    If strModules.Trim = VO.AccountPayable.DownPayment Then DL.PurchaseContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePayment And intPaymentTypeID = VO.PaymentType.Values.CBD Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePayment And intPaymentTypeID = VO.PaymentType.Values.TT30Days Then
                        DL.Receive.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        Dim strPCDetailID As String = DL.Receive.GetPCDetailID(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                        If strPCDetailID.Trim <> "" Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentTT30(sqlCon, sqlTrans, strPCDetailID)
                    End If
                    If strModules.Trim = VO.AccountPayable.DownPaymentCutting Then DL.PurchaseOrderCutting.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("ReferencesID"), dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then DL.PurchaseOrderCutting.CalculateTotalUsedReceiveItemPaymentVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then DL.Delivery.CalculateTotalUsedReceiveItemPaymentTransportVer02(sqlCon, sqlTrans, dr.Item("ReferencesDetailID"))
                Next

                Dim clsHelper As New DataSetHelper
                Dim dtReferencesParentID As DataTable = clsHelper.SelectGroupByInto("ReferencesParentID", dtDetailItem, "ReferencesParentID", "", "ReferencesParentID")
                For Each dr As DataRow In dtReferencesParentID.Rows
                    '# Revert Payment Item Parent Amount
                    If strModules.Trim = VO.AccountPayable.DownPayment And dr.Item("ReferencesParentID") <> "" Then DL.PurchaseContract.CalculateItemTotalUsedDownPaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePayment And intPaymentTypeID = VO.PaymentType.Values.CBD And dr.Item("ReferencesParentID") <> "" Then DL.PurchaseContract.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                    If strModules.Trim = VO.AccountPayable.ReceivePayment And intPaymentTypeID = VO.PaymentType.Values.TT30Days And dr.Item("ReferencesParentID") <> "" Then
                        DL.Receive.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                        Dim strPCDetailID As String = DL.Receive.GetPCDetailID(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                        If strPCDetailID.Trim <> "" Then DL.PurchaseContract.CalculateTotalUsedReceiveItemPaymentTT30(sqlCon, sqlTrans, strPCDetailID)
                    End If
                    If strModules.Trim = VO.AccountPayable.ReceivePaymentCutting And dr.Item("ReferencesParentID") <> "" Then DL.PurchaseOrderCutting.CalculateItemTotalUsedReceivePaymentParent(sqlCon, sqlTrans, dr.Item("ReferencesParentID"))
                Next

                '# Revert Payment Amount
                For Each dr As DataRow In dtDetail.Rows
                    If strModules.Trim = VO.AccountPayable.PurchaseBalance Then
                        DL.BusinessPartnerAPBalance.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPayment Then
                        DL.PurchaseContract.CalculateTotalUsedDownPaymentVer1(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePayment And intPaymentTypeID = VO.PaymentType.Values.CBD Then
                        DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePayment And intPaymentTypeID = VO.PaymentType.Values.TT30Days Then
                        DL.Receive.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        Dim clsReceive As VO.Receive = DL.Receive.GetDetail(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                        If clsReceive.PCID IsNot Nothing Then DL.PurchaseContract.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, clsReceive.PCID)
                    ElseIf strModules.Trim = VO.AccountPayable.DownPaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                        DL.PurchaseOrderCutting.CalculateTotalUsedReceivePaymentVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.DownPaymentTransport Then
                        DL.PurchaseOrderTransport.CalculateTotalUsedDownPayment(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    ElseIf strModules.Trim = VO.AccountPayable.ReceivePaymentTransport Then
                        DL.Delivery.CalculateTotalUsedReceivePaymentTransportVer02(sqlCon, sqlTrans, dr.Item("InvoiceID"))
                    End If
                Next

                '# Revert Down Payment
                Dim dtDownPayment As DataTable = DL.AccountPayable.ListDataDownPayment(sqlCon, sqlTrans, strID)
                DL.ARAP.DeleteDataDP(sqlCon, sqlTrans, strID)
                For Each dr As DataRow In dtDownPayment.Rows
                    DL.ARAP.CalculateTotalAmountUsed(sqlCon, sqlTrans, dr.Item("DPID"), VO.ARAP.ARAPTypeValue.Purchase)
                Next

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf intStatusID = VO.Status.Values.Payment Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah DIBAYAR")
            ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.AccountPayable.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If intStatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                ElseIf intStatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Batal submit. Dikarenakan status data telah DIBAYAR")
                ElseIf DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                End If

                DL.AccountPayable.Unsubmit(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                If clsData.StatusID = VO.Status.Values.Draft Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                ElseIf clsData.StatusID = VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                ElseIf clsData.StatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah DIBAYAR")
                ElseIf clsData.IsDeleted Then
                    Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                End If

                DL.AccountPayable.Approve(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                If Not clsData.IsDP And clsData.Modules.Trim <> VO.AccountPayable.ReceivePaymentClaimSales Then GenerateJournal(sqlCon, sqlTrans, strID)
                bolReturn = True
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
                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
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
                If Not clsData.IsDP And clsData.Modules.Trim <> VO.AccountPayable.ReceivePaymentClaimSales Then
                    BL.Journal.Unapprove(clsData.JournalID.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(clsData.JournalID.Trim, "")
                End If

                '# Unapprove Account Receivable
                DL.AccountPayable.Unapprove(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)
                bolReturn = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolReturn
        End Function

        Public Shared Function SetupPayment(ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                            ByVal strRemarks As String, ByVal intCoAIDOfOutgoingPayment As Integer) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, strRemarks, intCoAIDOfOutgoingPayment)
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
                                            ByVal strRemarks As String, ByVal intCoAIDOfOutgoingPayment As Integer) As Boolean
            Dim bolReturn As Boolean = False
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID = VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data telah DIBAYAR")
                ElseIf intStatusID <> VO.Status.Values.Approved Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Pembayaran. Dikarenakan status data harus disetujui terlebih dahulu")
                End If

                DL.AccountPayable.SetupPayment(sqlCon, sqlTrans, strID, dtmPaymentDate, intCoAIDOfOutgoingPayment)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)

                '# Generate Journal
                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                If Not clsData.IsDP Then GenerateJournalInvoice(sqlCon, sqlTrans, strID)
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
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data telah dihapus")
                ElseIf intStatusID <> VO.Status.Values.Payment Then
                    Err.Raise(515, "", "Data tidak dapat di Proses Batal Pembayaran. Dikarenakan data belum pernah diproses BAYAR")
                End If

                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                If Not clsData.IsDP Then
                    '# Cancel Approve Journal
                    BL.Journal.Unapprove(sqlCon, sqlTrans, clsData.JournalIDInvoice.Trim, "")

                    '# Cancel Submit Journal
                    BL.Journal.Unsubmit(sqlCon, sqlTrans, clsData.JournalIDInvoice.Trim, "")
                End If

                DL.AccountPayable.SetupCancelPayment(sqlCon, sqlTrans, strID)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL PROSES PEMBAYARAN", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
            Dim bolReturn As Boolean
            Try
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data telah dihapus")
                End If

                DL.AccountPayable.UpdateTaxInvoiceNumber(sqlCon, sqlTrans, strID, strTaxInvoiceNumber)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE NOMOR FAKTUR PAJAK", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim intStatusID As Integer = DL.AccountPayable.GetStatusID(sqlCon, sqlTrans, strID)
                If DL.AccountPayable.IsDeleted(sqlCon, sqlTrans, strID) Then
                    Err.Raise(515, "", "Data tidak dapat di Proses. Dikarenakan data telah dihapus")
                End If

                DL.AccountPayable.UpdateInvoiceNumberSupplier(sqlCon, sqlTrans, strID, strInvoiceNumberSupplier)

                '# Save Data Status
                BL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, strID, "UPDATE NOMOR INVOICE SUPPLIER", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0

                Dim clsJournalDetail As New List(Of VO.JournalDet)
                Dim strJournalDetailRemarks As String = "" 'clsData.APNumber

                If clsData.IsDP Then '# Pembayaran DP
                    Dim intCoAofDownPaymentAccount As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAdvancePayment
                    If clsData.Modules.Trim = VO.AccountPayable.DownPaymentCutting Then intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeCutting
                    If clsData.Modules.Trim = VO.AccountPayable.DownPaymentTransport Then intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeTransport

                    '# Akun Panjar Pembelian -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = intCoAofDownPaymentAccount,
                                             .DebitAmount = clsData.TotalAmount,
                                             .CreditAmount = 0,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })
                    decTotalAmount += clsData.TotalAmount

                    '# Akun PPN -> Debit
                    If clsData.TotalPPN > 0 Then
                        clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPurchaseTax,
                                             .DebitAmount = clsData.TotalPPN,
                                             .CreditAmount = 0,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })
                        decTotalAmount += clsData.TotalPPN
                    End If


                    '# Akun Kas / Bank -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = clsData.CoAIDOfOutgoingPayment,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsData.TotalAmount + clsData.TotalPPN,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })

                    '# Setup Akun PPH
                    If clsData.TotalPPH > 0 Then
                        intGroupID += 1

                        '# Akun Kas / Bank -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = clsData.CoAIDOfOutgoingPayment,
                                             .DebitAmount = clsData.TotalPPH,
                                             .CreditAmount = 0,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })

                        '# Akun PPH -> Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHPurchase,
                                             .DebitAmount = 0,
                                             .CreditAmount = clsData.TotalPPH,
                                             .Remarks = strJournalDetailRemarks,
                                             .GroupID = intGroupID,
                                             .BPID = clsData.BPID
                                         })
                        decTotalAmount += clsData.TotalPPH
                    End If
                Else
                    Dim intCoAofReceivePaymentAccountOutstandingPayment As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableOutstandingPayment
                    Dim intCoAofReceivePaymentAccount As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayable
                    Dim intCoAofDownPaymentAccount As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAdvancePayment

                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                        intCoAofReceivePaymentAccountOutstandingPayment = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableCuttingOutstandingPayment
                        intCoAofReceivePaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableCutting
                        intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeCutting
                    End If
                    If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Or clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransportSalesReturn Then
                        intCoAofReceivePaymentAccountOutstandingPayment = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableTransportOutstandingPayment
                        intCoAofReceivePaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableTransport
                        intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeTransport
                    End If

                    '# Akun Hutang Belum Ditagih -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = intCoAofReceivePaymentAccountOutstandingPayment,
                                         .DebitAmount = clsData.ReceiveAmount + clsData.DPAmount,
                                         .CreditAmount = 0,
                                         .Remarks = strJournalDetailRemarks,
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    '# Akun PPN -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPurchaseTax,
                                         .DebitAmount = clsData.TotalPPN,
                                         .CreditAmount = 0,
                                         .Remarks = strJournalDetailRemarks,
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    '# Akun Hutang Usaha -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = intCoAofReceivePaymentAccount,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.ReceiveAmount + clsData.DPAmount + clsData.TotalPPN,
                                         .Remarks = strJournalDetailRemarks,
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })
                    decTotalAmount += clsData.ReceiveAmount + clsData.DPAmount + clsData.TotalPPN

                    '# Setup / Cross Akun DP
                    If clsData.DPAmount > 0 Then
                        intGroupID += 1

                        '# Akun Hutang Usaha -> Debit
                        clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = intCoAofReceivePaymentAccount,
                                         .DebitAmount = clsData.DPAmount,
                                         .CreditAmount = 0,
                                         .Remarks = strJournalDetailRemarks,
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                        '# Akun Uang Muka Pembelian -> Kredit
                        clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = intCoAofDownPaymentAccount,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.DPAmount,
                                         .Remarks = strJournalDetailRemarks,
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
                        .JournalDate = clsData.APDate,
                        .TotalAmount = decTotalAmount,
                        .IsAutoGenerate = True,
                        .StatusID = VO.Status.Values.Draft,
                        .Remarks = clsData.Remarks,
                        .LogBy = ERPSLib.UI.usUserApp.UserID,
                        .Initial = "",
                        .ReferencesNo = clsData.APNumber,
                        .Detail = clsJournalDetail,
                        .Save = VO.Save.Action.SaveAndSubmit
                    }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Account Payable
                DL.AccountPayable.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub GenerateJournalInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String)
            Try
                '# Generate Journal
                Dim clsData As VO.AccountPayable = DL.AccountPayable.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalIDInvoice)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)
                Dim intGroupID As Integer = 1
                Dim decTotalAmount As Decimal = 0

                Dim clsJournalDetail As New List(Of VO.JournalDet)
                Dim strJournalDetailRemarks As String = ""
                Dim intCoAofReceivePaymentAccountOutstandingPayment As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableOutstandingPayment
                Dim intCoAofReceivePaymentAccount As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayable
                Dim intCoAofDownPaymentAccount As Integer = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncome

                If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentCutting Then
                    intCoAofReceivePaymentAccountOutstandingPayment = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableCuttingOutstandingPayment
                    intCoAofReceivePaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableCutting
                    intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeCutting
                End If
                If clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransport Or clsData.Modules.Trim = VO.AccountPayable.ReceivePaymentTransportSalesReturn Then
                    intCoAofReceivePaymentAccountOutstandingPayment = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableTransportOutstandingPayment
                    intCoAofReceivePaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountPayableTransport
                    intCoAofDownPaymentAccount = ERPSLib.UI.usUserApp.JournalPost.CoAofPrepaidIncomeTransport
                End If

                '# Akun Hutang Usaha -> Debit
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = intCoAofReceivePaymentAccount,
                                         .DebitAmount = clsData.ReceiveAmount + clsData.TotalPPN,
                                         .CreditAmount = 0,
                                         .Remarks = strJournalDetailRemarks,
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                '# Akun Kas / Bank - Kredit
                clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAIDOfOutgoingPayment,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.ReceiveAmount + clsData.TotalPPN,
                                         .Remarks = strJournalDetailRemarks,
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })
                decTotalAmount += clsData.TotalAmount + clsData.TotalPPN

                '# Setup Akun PPH
                If clsData.TotalPPH > 0 Then
                    intGroupID += 1

                    '# Akun Kas / Bank -> Debit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = clsData.CoAIDOfOutgoingPayment,
                                         .DebitAmount = clsData.TotalPPH,
                                         .CreditAmount = 0,
                                         .Remarks = strJournalDetailRemarks,
                                         .GroupID = intGroupID,
                                         .BPID = clsData.BPID
                                     })

                    '# Akun PPH -> Kredit
                    clsJournalDetail.Add(New VO.JournalDet With
                                     {
                                         .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofPPHPurchase,
                                         .DebitAmount = 0,
                                         .CreditAmount = clsData.TotalPPH,
                                         .Remarks = strJournalDetailRemarks,
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
                        .ReferencesNo = clsData.APNumber,
                        .Detail = clsJournalDetail,
                        .Save = VO.Save.Action.SaveAndSubmit
                    }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Account Payable
                DL.AccountPayable.UpdateJournalIDInvoice(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetailForSetupBalance(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailForSetupBalance(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailForSetupBalanceWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                            ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailForSetupBalanceWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetail(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetail(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                             ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailWithOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstandingPurchaseOrderCutting(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                 ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderCutting(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstandingPurchaseOrderTransport(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                                   ByVal intBPID As Integer, ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailWithOutstandingPurchaseOrderTransport(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailRev01(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailRev01(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailRev02(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailRev02(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Function ListDataDetailWithOutstandingRev01(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                  ByVal intBPID As Integer, ByVal strAPID As String,
                                                                  ByVal strReferencesID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailWithOutstandingRev01(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID)
            End Using
        End Function

        Public Shared Function ListDataDetailItemDPWithOutstandingRev02(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                        ByVal intBPID As Integer, ByVal strAPID As String,
                                                                        ByVal strReferencesID As String, ByVal bolIsUseSubItem As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailItemDPWithOutstandingVer02(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID, bolIsUseSubItem)
                'Return DL.AccountPayable.ListDataDetailItemDPWithOutstandingVer01(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID, bolIsUseSubItem)
            End Using
        End Function

        Public Shared Function ListDataDetailItemReceiveWithOutstandingRev02(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                                             ByVal intBPID As Integer, ByVal strAPID As String,
                                                                             ByVal strReferencesID As String, ByVal intPaymentTypeID As Integer,
                                                                             ByVal bolIsUseSubitem As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataDetailItemReceiveWithOutstandingVer02(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID, intPaymentTypeID, bolIsUseSubitem)
                'Return DL.AccountPayable.ListDataDetailItemReceiveWithOutstandingVer01(sqlCon, Nothing, intCompanyID, intProgramID, intBPID, strAPID, strReferencesID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strAPID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.AccountPayable.ListDataStatus(sqlCon, Nothing, strAPID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strAPID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strAPID & "-" & Format(DL.AccountPayable.GetMaxIDStatus(sqlCon, sqlTrans, strAPID) + 1, "000")
            Dim clsData As New VO.AccountPayableStatus With
                {
                    .ID = strNewID,
                    .APID = strAPID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.AccountPayable.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace