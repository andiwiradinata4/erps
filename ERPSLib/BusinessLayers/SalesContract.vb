Imports ERPSLib.VO

Namespace BL
    Public Class SalesContract

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function ListDataOustandingPOTransport(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                             ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataOustandingPOTransport(sqlCon, Nothing, intProgramID, intCompanyID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataOustandingDelivery(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                             ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataOustandingDelivery(sqlCon, Nothing, intProgramID, intCompanyID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataOutstanding(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                   ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataOutstanding(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataByPurchaseID(ByVal strPCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataByPurchaseID(sqlCon, Nothing, strPCID)
            End Using
        End Function

        Public Shared Function ListDataByOrderRequestID(ByVal strOrderRequestID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataByOrderRequestID(sqlCon, Nothing, strOrderRequestID)
            End Using
        End Function

        Public Shared Function ListDataOutstandingClaim(ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                                        ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataOutstandingClaim(sqlCon, Nothing, intCompanyID, intProgramID, intBPID)
            End Using
        End Function

        Public Shared Function ListDataDifferentTotalChild(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                           ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDifferentTotalChild(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "SC" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.SalesContract.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function GetNewIDSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strSCID As String) As String
            Dim strNewID As String = strSCID & "-" & 1 & "-"
            strNewID &= Format(DL.SalesContract.GetMaxIDDetail(sqlCon, sqlTrans, strNewID) + 1, "000")
            Return strNewID
        End Function

        Public Shared Function GetNewIDDetailCOItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                    ByVal strSCID As String) As String
            Dim strNewID As String = strSCID & "-" & 2 & "-"
            strNewID &= Format(DL.SalesContract.GetMaxIDDetailCO(sqlCon, sqlTrans, strNewID) + 1, "000")
            Return strNewID
        End Function

        Public Shared Function GetNewIDDetailCOSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal strSCCOID As String) As String
            Dim strNewID As String = strSCCOID & "-"
            strNewID &= Format(DL.SalesContract.GetMaxIDDetailCO(sqlCon, sqlTrans, strNewID) + 1, "000")
            Return strNewID
        End Function

        Public Shared Function GetNewNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intBPID As Integer,
                                        ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim clsBP As VO.BusinessPartner = DL.BusinessPartner.GetDetail(sqlCon, sqlTrans, intBPID)
            If clsBP.Initial.Trim = "" Then
                Err.Raise(515, "", "Inisial Rekan Bisnis tidak boleh kosong. Mohon ditentukan Inisial Rekan Bisnis terlebih dahulu")
            End If
            Dim strNewID As String = Format(DL.SalesContract.GetMaxNo(sqlCon, sqlTrans, dtmTransDate.Year, intCompanyID, intProgramID) + 1, "000")
            strNewID &= "/" & clsCompany.CompanyInitial & "/"
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
            strNewID &= "/" & Format(dtmTransDate, "yy") & "/" & clsBP.Initial
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.SalesContract) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.SCDate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.SCNumber.Trim = "" Then clsData.SCNumber = GetNewNo(sqlCon, sqlTrans, clsData.SCDate, clsData.BPID, clsData.CompanyID, clsData.ProgramID)
                    Else
                        Dim dtSubItem As New DataTable
                        Dim dtItem As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.ID, "")
                        For Each dr As DataRow In dtItem.Rows
                            dtSubItem.Merge(DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.ID, dr.Item("ID")))
                        Next

                        Dim dtSubItemCO As New DataTable
                        Dim dtItemCO As DataTable = DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsData.ID, "")
                        For Each dr As DataRow In dtItemCO.Rows
                            dtSubItemCO.Merge(DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsData.ID, dr.Item("ID")))
                        Next

                        DL.SalesContract.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.SalesContract.DeleteDataDetailCO(sqlCon, sqlTrans, clsData.ID)
                        DL.SalesContract.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.ID)

                        '# Revert SC Quantity in Order Request
                        For Each dr As DataRow In dtItem.Rows
                            DL.OrderRequest.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("ORDetailID"))
                        Next

                        '# Revert SC Quantity in Confirmation Order
                        For Each dr As DataRow In dtItemCO.Rows
                            DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                            DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                        Next
                        For Each dr As DataRow In dtSubItemCO.Rows
                            DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                        Next

                        Dim clsExists As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsData.ID)
                        If clsExists.DPAmount > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses panjar")
                        ElseIf clsExists.ReceiveAmount > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                        End If

                        Dim drDCWeight() As DataRow = dtItem.Select("DCWeight>0")
                        If drDCWeight.Count > 0 Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pengiriman")
                        End If
                    End If

                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.SalesContract.DataExists(sqlCon, sqlTrans, clsData.SCNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.SCNumber & " sudah ada.")
                    End If

                    DL.SalesContract.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.SalesContractDet In clsData.Detail
                        Dim prevID As String = clsDet.ID
                        clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")

                        For Each clsDetChild As VO.SalesContractDet In clsData.Detail
                            If clsDetChild.ParentID = prevID Then clsDetChild.ParentID = clsDet.ID
                        Next

                        clsDet.SCID = clsData.ID
                        DL.SalesContract.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Detail Confirmation Order
                    intCount = 1
                    For Each clsDet As VO.SalesContractDetConfirmationOrder In clsData.DetailConfirmationOrder
                        Dim prevID As String = clsDet.ID
                        clsDet.ID = clsData.ID & "-" & 2 & "-" & Format(intCount, "000")

                        For Each clsDetChild As VO.SalesContractDetConfirmationOrder In clsData.DetailConfirmationOrder
                            If clsDetChild.ParentID = prevID Then clsDetChild.ParentID = clsDet.ID
                        Next

                        clsDet.SCID = clsData.ID
                        DL.SalesContract.SaveDataDetailCO(sqlCon, sqlTrans, clsDet)
                        DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, clsDet.CODetailID)
                        intCount += 1
                    Next

                    '# Save Data Payment Term
                    intCount = 1
                    For Each clsDet As VO.SalesContractPaymentTerm In clsData.PaymentTerm
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.SCID = clsData.ID
                        DL.SalesContract.SaveDataPaymentTerm(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Calculate SC Quantity in Order Request
                    For Each clsDet As VO.SalesContractDet In clsData.Detail
                        DL.OrderRequest.CalculateTotalUsed(sqlCon, sqlTrans, clsDet.ORDetailID)
                    Next

                    '# Calculate SC Quantity in Confirmation Order
                    For Each clsDet As VO.SalesContractDetConfirmationOrder In clsData.DetailConfirmationOrder
                        DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, clsDet.CODetailID)
                    Next

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.SCNumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.SalesContract
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, Nothing, strID)
                If clsData.ReferencesNumber.Trim = "" Then clsData.ReferencesNumber = DL.OrderRequest.GetReferencesNumberBySCID(sqlCon, Nothing, strID)
                Return clsData
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, strID, "")
                    Dim dtItemCO As DataTable = DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, strID, "")
                    Dim dtSubItemCO As New DataTable
                    For Each dr As DataRow In dtItemCO.Rows
                        dtSubItemCO.Merge(DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, strID, dr.Item("ID")))
                    Next

                    DL.SalesContract.DeleteData(sqlCon, sqlTrans, strID)

                    '# Revert SC Quantity in Order Request
                    Dim clsHelper As New DataSetHelper
                    Dim dtItemGroup As DataTable = clsHelper.SelectGroupByInto("ItemGroup", dtItem, "ORDetailID", "", "ORDetailID")
                    For Each dr As DataRow In dtItemGroup.Rows
                        DL.OrderRequest.CalculateTotalUsed(sqlCon, sqlTrans, dr.Item("ORDetailID"))
                    Next

                    '# Revert SC Quantity in Confirmation Order
                    dtItemCO.Merge(dtSubItemCO)
                    For Each dr As DataRow In dtItemCO.Rows
                        DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                        DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                    Next

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.SalesContract.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesContract.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesContract.Approve(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    'GenerateJournal(sqlCon, sqlTrans, strID)
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
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    ElseIf DL.SalesContract.IsAlreadyPayment(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dilanjutkan proses pembayaran")
                    ElseIf DL.SalesContract.IsAlreadyDelivery(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dilanjutkan proses pengiriman")
                    ElseIf DL.SalesContract.IsAlreadyClaim(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dilanjutkan proses Klaim")
                    End If

                    DL.SalesContract.Unapprove(sqlCon, sqlTrans, strID)

                    DL.SalesContract.DeleteDataSplitItemBySCID(sqlCon, sqlTrans, strID)
                    DL.SalesContract.DeleteDataSplitItemCOBySCID(sqlCon, sqlTrans, strID)
                    DL.ARAP.DeleteDataSplitItemByReferencesID(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                dtReturn = DL.SalesContract.PrintVer00(sqlCon, Nothing, intProgramID, intCompanyID, strID)
                Dim clsHelper As New DataSetHelper
                Dim dtItemTypeAndSpec As DataTable = clsHelper.SelectGroupByInto("ItemTypeAndSpec", dtReturn, "ItemTypeAndSpec", "", "ItemTypeAndSpec")

                '# Combine AllItemName
                Dim strItemTypeAndSpec As String = ""
                Dim strAllItemTypeAndSpec As String = ""
                For Each dr As DataRow In dtItemTypeAndSpec.Rows
                    If dr.Item("ItemTypeAndSpec") <> strItemTypeAndSpec Then
                        strItemTypeAndSpec = dr.Item("ItemTypeAndSpec")
                        If strAllItemTypeAndSpec.Trim <> "" Then strAllItemTypeAndSpec += ", "
                        strAllItemTypeAndSpec += strItemTypeAndSpec
                    End If
                Next

                '# Combine Payment Terms
                Dim strPaymentTerms As String = ""
                Dim dtPaymentTerm As DataTable = DL.SalesContract.ListDataPaymentTerm(sqlCon, Nothing, strID)
                Dim intMaxCreditTerms As Integer = 0
                For Each dr As DataRow In dtPaymentTerm.Rows
                    If strPaymentTerms.Trim <> "" Then strPaymentTerms += ", "
                    strPaymentTerms += CInt(dr.Item("Percentage")) & "% " & dr.Item("PaymentTypeName") '& " BY " & dr.Item("PaymentModeName")
                    If intMaxCreditTerms < dr.Item("CreditTerm") Then intMaxCreditTerms = dr.Item("CreditTerm")
                Next

                '# Combine All References Number
                Dim strReferencesNumber As String = ""
                Dim strAllReferencesNumber As String = ""
                For Each dr As DataRow In dtReturn.Rows
                    If dr.Item("ReferencesNumber") <> strReferencesNumber Then
                        strReferencesNumber = dr.Item("ReferencesNumber")
                        If strAllReferencesNumber.Trim <> "" Then strAllReferencesNumber += ", "
                        strAllReferencesNumber += strReferencesNumber
                    End If
                Next

                '# Combine All References Number
                Dim strOrderNumberSupplier As String = ""
                Dim strAllOrderNumberSupplier As String = ""
                clsHelper = New DataSetHelper
                Dim dtOrderNumberSupplier As DataTable = clsHelper.SelectGroupByInto("OrderNumberSupplier", dtReturn, "OrderNumberSupplier", "", "OrderNumberSupplier")
                For Each dr As DataRow In dtOrderNumberSupplier.Rows
                    If dr.Item("OrderNumberSupplier") <> strOrderNumberSupplier Then
                        strOrderNumberSupplier = dr.Item("OrderNumberSupplier")
                        If strAllOrderNumberSupplier.Trim <> "" Then strAllOrderNumberSupplier += ", "
                        strAllOrderNumberSupplier += strOrderNumberSupplier
                    End If
                Next

                For Each dr As DataRow In dtReturn.Rows
                    dr.BeginEdit()
                    dr.Item("SCDateAndSubDistrict") = dr.Item("CompanySubDistrict") & ", " & Format(dr.Item("SCDate"), "dd MMMM yyyy")
                    dr.Item("AllItemName") = strAllItemTypeAndSpec
                    dr.Item("PaymentTerms") = strPaymentTerms
                    dr.Item("DeliveryPeriod") = Format(dr.Item("DeliveryPeriodFrom"), "MMMM") & " - " & Format(dr.Item("DeliveryPeriodTo"), "MMMM yyyy")
                    dr.Item("AllReferencesNumber") = strAllReferencesNumber
                    dr.Item("MaxCreditTerms") = intMaxCreditTerms
                    dr.Item("AllOrderNumberSupplier") = strAllOrderNumberSupplier
                    dr.Item("NumericToString") = SharedLib.Math.NumberToString(dr.Item("GrandTotal"))
                    dr.EndEdit()
                Next
                dtReturn.AcceptChanges()
            End Using

            Return dtReturn
        End Function

        Public Shared Function PrintSCCOVer00(ByVal intProgramID As Integer, ByVal intCompanyID As Integer, ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, Nothing, strID)
                dtReturn = DL.SalesContract.PrintSCCOVer00(sqlCon, Nothing, intProgramID, intCompanyID, strID)

                '# Combine AllItemName
                Dim strItemType As String = ""
                Dim strAllItemType As String = ""
                For Each dr As DataRow In dtReturn.Rows
                    If dr.Item("ItemTypeName") <> strItemType Then
                        strItemType = dr.Item("ItemTypeName")
                        If strAllItemType.Trim <> "" Then strAllItemType += ", "
                        strAllItemType = strItemType
                    End If
                Next

                '# Combine All References Number
                Dim strOrderNumberSupplier As String = ""
                Dim strAllOrderNumberSupplier As String = ""
                Dim clsHelper As New DataSetHelper
                Dim dtOrderNumberSupplier As DataTable = clsHelper.SelectGroupByInto("OrderNumberSupplier", dtReturn, "OrderNumberSupplier", "", "OrderNumberSupplier")
                For Each dr As DataRow In dtOrderNumberSupplier.Rows
                    If dr.Item("OrderNumberSupplier") <> strOrderNumberSupplier Then
                        strOrderNumberSupplier = dr.Item("OrderNumberSupplier")
                        If strAllOrderNumberSupplier.Trim <> "" Then strAllOrderNumberSupplier += ", "
                        strAllOrderNumberSupplier += strOrderNumberSupplier
                    End If
                Next

                For Each dr As DataRow In dtReturn.Rows
                    dr.BeginEdit()
                    dr.Item("AllItemName") = strAllItemType
                    dr.Item("AllOrderNumberSupplier") = strAllOrderNumberSupplier
                    dr.Item("NumericToString") = SharedLib.Math.NumberToString(SharedLib.Math.Round(dr.Item("GrandTotal"), 0))

                    If IsNumeric(dr.Item("ItemLength")) Then
                        Dim decValue As Decimal = Convert.ToDecimal(dr.Item("ItemLength"))
                        dr.Item("ItemLength") = Format(decValue / 100, "#,##0")
                    End If

                    dr.EndEdit()
                Next
                dtReturn.AcceptChanges()
            End Using

            Return dtReturn
        End Function

        Public Shared Sub GenerateJournal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Try

                Dim clsData As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, strID)
                Dim PrevJournal As VO.Journal = DL.Journal.GetDetail(sqlCon, sqlTrans, clsData.JournalID)
                Dim bolNew As Boolean = IIf(PrevJournal.ID = "", True, False)

                '# Generate Journal
                Dim decTotalAmount As Decimal = clsData.TotalDPP + clsData.TotalPPN - clsData.TotalPPH + clsData.RoundingManual
                Dim clsJournalDetail As New List(Of VO.JournalDet) From {
                        New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofAccountReceivable,
                                             .DebitAmount = decTotalAmount,
                                             .CreditAmount = 0,
                                             .Remarks = "KONTRAK PENJUALAN - " & clsData.SCNumber
                                         },
                        New VO.JournalDet With
                                         {
                                             .CoAID = ERPSLib.UI.usUserApp.JournalPost.CoAofRevenue,
                                             .DebitAmount = 0,
                                             .CreditAmount = decTotalAmount,
                                             .Remarks = "KONTRAK PENJUALAN - " & clsData.SCNumber
                                         }
                    }

                Dim clsJournal As New VO.Journal With
                        {
                            .ProgramID = clsData.ProgramID,
                            .CompanyID = clsData.CompanyID,
                            .ID = PrevJournal.ID,
                            .JournalNo = IIf(bolNew, "", PrevJournal.JournalNo),
                            .ReferencesID = clsData.ID,
                            .JournalDate = IIf(bolNew, Now, PrevJournal.JournalDate),
                            .TotalAmount = decTotalAmount,
                            .IsAutoGenerate = True,
                            .StatusID = VO.Status.Values.Draft,
                            .Remarks = clsData.Remarks,
                            .LogBy = ERPSLib.UI.usUserApp.UserID,
                            .Initial = "",
                            .Detail = clsJournalDetail,
                            .Save = VO.Save.Action.SaveAndSubmit
                        }

                '# Save Journal
                Dim strJournalID As String = BL.Journal.SaveData(sqlCon, sqlTrans, bolNew, clsJournal)

                '# Approve Journal
                BL.Journal.Approve(sqlCon, sqlTrans, strJournalID, "")

                '# Update Journal ID in Purchase Contract
                DL.SalesContract.UpdateJournalID(sqlCon, sqlTrans, clsData.ID, strJournalID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SetupIsIgnoreValidationPayment(ByVal strID As String, ByVal bolValue As Boolean, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                    Dim clsData As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, strID)
                    If clsData.StatusID <> VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat " & IIf(bolValue = False, "batal ", "") & "set pengiriman. Status data harus APPROVED terlebih dahulu")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat " & IIf(bolValue = False, "batal ", "") & "set pengiriman. Dikarenakan data telah dihapus")
                    End If

                    Dim dtDetail As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, strID, "")
                    Dim drDelivery() As DataRow = dtDetail.Select("DCWeight>0")
                    If Not bolValue And drDelivery.Length > 0 Then Err.Raise(515, "", "Data tidak dapat " & IIf(bolValue = False, "batal ", "") & "set pengiriman. Dikarenakan data telah diproses pengiriman")

                    DL.SalesContract.SetupIsIgnoreValidationPayment(sqlCon, sqlTrans, strID, bolValue)

                    '# Save Data Status
                    BL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, strID, IIf(bolValue = False, "BATAL ", "") & "SET PENGIRIMAN", ERPSLib.UI.usUserApp.UserID, strRemarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub UpdateAdditinalTerm(ByVal clsData As VO.SalesContract)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DL.SalesContract.UpdateAdditionalTerm(sqlCon, sqlTrans, clsData)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strSCID As String, ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetail(sqlCon, Nothing, strSCID, strParentID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingTransport(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                  ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetailOutstandingTransport(sqlCon, Nothing, intProgramID, intCompanyID, strSCID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingDelivery(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                 ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetailOutstandingDelivery(sqlCon, Nothing, intProgramID, intCompanyID, strSCID)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingDeliveryVer01(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                                      ByVal strSCID As String, ByVal bolIsUseSubItem As Boolean) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetailOutstandingDeliveryVer01(sqlCon, Nothing, intProgramID, intCompanyID, strSCID, bolIsUseSubItem)
            End Using
        End Function

        Public Shared Function ListDataDetailOutstandingClaim(ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetailOutstandingClaim(sqlCon, Nothing, strSCID)
            End Using
        End Function

        Public Shared Function SaveDataSubitem(ByVal bolNew As Boolean, ByVal strSCID As String,
                                               ByVal clsData As VO.SalesContractDet) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        If clsData.ID.Trim = "" Then clsData.ID = GetNewIDSubitem(sqlCon, sqlTrans, strSCID)
                    Else
                        Dim clsSC As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, strSCID)
                        If clsSC.StatusID <> VO.Status.Values.Approved Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data belum di approve")
                        ElseIf clsSC.IsDeleted Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                        ElseIf DL.SalesContract.IsAlreadyPaymentSubitem(sqlCon, sqlTrans, clsData.ID) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                        ElseIf DL.SalesContract.IsAlreadyReceiveSubitem(sqlCon, sqlTrans, clsData.ID) Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pengiriman")
                        Else
                            DL.SalesContract.DeleteDataDetailByID(sqlCon, sqlTrans, clsData.ID)
                        End If
                    End If

                    If DL.SalesContract.IsAlreadyReceiveSubitem(sqlCon, sqlTrans, clsData.ParentID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data induk telah diproses penerimaan")
                    End If

                    DL.SalesContract.SaveDataDetail(sqlCon, sqlTrans, clsData)
                    DL.SalesContract.SetIsUseSubitem(sqlCon, sqlTrans, strSCID, True)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function IsAlreadyPaymentSubitem(ByVal strID As String) As Boolean
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.IsAlreadyPaymentSubitem(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Function IsAlreadyReceiveSubitem(ByVal strID As String) As Boolean
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.IsAlreadyReceiveSubitem(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteSubItem(ByVal strID As String, ByVal strSCID As String, ByVal strPCDetailID As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If DL.SalesContract.IsAlreadyReceiveSubitem(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pengiriman")
                    ElseIf DL.SalesContract.IsAlreadyPaymentSubitem(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                    End If

                    DL.SalesContract.DeleteDataDetailByID(sqlCon, sqlTrans, strID)

                    Dim bolIsSubitem As Boolean = False
                    Dim dtDetail As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, strSCID, "")
                    Dim dtSubitem As New DataTable
                    For Each dr As DataRow In dtDetail.Rows
                        dtSubitem.Merge(DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, strSCID, dr.Item("ID")))
                        If dtSubitem.Rows.Count > 0 Then bolIsSubitem = True : Exit For
                    Next

                    DL.SalesContract.SetIsUseSubitem(sqlCon, sqlTrans, strSCID, bolIsSubitem)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try

            End Using
        End Sub

        Public Shared Function RemapSCDetailItem(ByVal clsSCDetOld As VO.SalesContractDet, ByVal clsSCDetNew As VO.SalesContractDet,
                                                 ByVal clsSCCOOld As VO.SalesContractDetConfirmationOrder, ByVal clsSCCONew As VO.SalesContractDetConfirmationOrder) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtSCCODetail As DataTable = DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsSCDetOld.SCID, "")
                    Dim drSelectedDetailCO() As DataRow = dtSCCODetail.Select("GroupID=" & clsSCDetOld.GroupID)
                    Dim dtSCDetail As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsSCDetOld.SCID, "")
                    Dim drSelectedDetail() As DataRow = dtSCDetail.Select("GroupID=" & clsSCDetOld.GroupID)
                    Dim dtSCDetailSub As New DataTable
                    For Each dr As DataRow In drSelectedDetail
                        dtSCDetailSub.Merge(DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsSCDetOld.SCID, dr.Item("ID")))
                    Next

                    If drSelectedDetail.Count = 1 Then
                        'Err.Raise(515, "", "Data tidak dapat disimpan. Gunakan fitur ubah item pada Kontrak Penjualan -> Konfirmasi Pesanan")
                        Dim dtSCDetailCOSubItem As New DataTable
                        For Each dr As DataRow In drSelectedDetailCO
                            dtSCDetailCOSubItem.Merge(DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsSCDetOld.SCID, dr.Item("ID")))
                        Next

                        '# Delete All Sub Item CO and Recalculate Total Used
                        For Each dr As DataRow In dtSCDetailCOSubItem.Rows
                            DeleteDetailCOItem(sqlCon, sqlTrans, dr.Item("ID"), dr.Item("PCDetailID"))
                        Next

                        '# Delete Existing Sales Contract CO Item
                        DL.SalesContract.DeleteDataDetailCOByID(sqlCon, sqlTrans, clsSCCOOld.ID)
                        DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, clsSCCOOld.CODetailID)
                        DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, clsSCCOOld.CODetailID)
                    End If

                    '# Update Group ID SC Detail
                    DL.SalesContract.UpdateDetailGroupID(sqlCon, sqlTrans, clsSCDetNew.ID, clsSCDetNew.GroupID, clsSCDetNew.UnitPriceHPP)
                    For Each dr As DataRow In dtSCDetailSub.Rows
                        DL.SalesContract.UpdateDetailGroupID(sqlCon, sqlTrans, dr.Item("ID"), clsSCDetNew.GroupID, clsSCDetNew.UnitPriceHPP)
                    Next

                    '# Save new Sales Contract CO Item
                    clsSCCONew.ID = GetNewIDDetailCOItem(sqlCon, sqlTrans, clsSCCONew.SCID)
                    DL.SalesContract.SaveDataDetailCO(sqlCon, sqlTrans, clsSCCONew)
                    DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, clsSCCONew.CODetailID)
                    DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, clsSCCONew.CODetailID)

                    If clsSCDetOld.OrderNumberSupplier <> clsSCDetNew.OrderNumberSupplier Then ChangeCODetailItem(sqlCon, sqlTrans, clsSCCONew)

                    bolReturn = True
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function DeleteDuplicateSCItem(ByVal clsData As VO.SalesContractDet) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtSCDetOld As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.SCID, "")
                    Dim dtSubItem As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.SCID, clsData.ID)
                    Dim dtARAPItem As New DataTable
                    dtARAPItem.Merge(DL.ARAP.ListDataByReferencesDetailID(sqlCon, sqlTrans, clsData.ID, clsData.ItemID))
                    For Each dr As DataRow In dtSubItem.Rows
                        dtARAPItem.Merge(DL.ARAP.ListDataByReferencesDetailID(sqlCon, sqlTrans, dr.Item("ID"), dr.Item("ItemID")))
                    Next

                    If dtARAPItem.Rows.Count > 0 Then Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah diproses Pembayaran DP / Pelunasan.")

                    Dim dtDeliveryDet As New DataTable
                    dtDeliveryDet.Merge(DL.Delivery.ListDataDetailBySCDetailID(sqlCon, sqlTrans, clsData.ID, clsData.ItemID))
                    For Each dr As DataRow In dtSubItem.Rows
                        dtDeliveryDet.Merge(DL.Delivery.ListDataDetailBySCDetailID(sqlCon, sqlTrans, dr.Item("ID"), dr.Item("ItemID")))
                    Next

                    If dtARAPItem.Rows.Count > 0 Then Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah diproses Pengiriman.")

                    DL.SalesContract.DeleteDataDetailByID(sqlCon, sqlTrans, clsData.ID)
                    DL.OrderRequest.CalculateTotalUsed(sqlCon, sqlTrans, clsData.ORDetailID)

                    '# Update Total SC
                    Dim clsSC As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, clsData.SCID)
                    Dim dtSCDet As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.SCID, "")
                    Dim decTotalDPP As Decimal = 0, decTotalQuantity As Decimal = 0, decTotalWeight As Decimal = 0
                    For Each dr As DataRow In dtSCDet.Rows
                        decTotalDPP += dr.Item("TotalPrice")
                        decTotalQuantity += dr.Item("Quantity")
                        decTotalWeight += dr.Item("TotalWeight")
                    Next

                    clsSC.TotalDPP = decTotalDPP
                    clsSC.TotalPPN = decTotalDPP * (clsSC.PPN / 100)
                    clsSC.TotalPPH = decTotalDPP * (clsSC.PPH / 100)
                    clsSC.GrandTotal = decTotalDPP + clsSC.TotalPPN - clsSC.TotalPPH
                    clsSC.TotalQuantity = decTotalQuantity
                    clsSC.TotalWeight = decTotalWeight
                    DL.SalesContract.UpdatePrice(sqlCon, sqlTrans, clsSC)

                    '# Delete Sales Contract CO
                    Dim drSelected() As DataRow = dtSCDetOld.Select("GroupID=" & clsData.GroupID)
                    If drSelected.Count = 1 Then
                        Dim dtSCCO As DataTable = DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsData.SCID, "")
                        For Each dr As DataRow In dtSCCO.Rows
                            dtSCCO.Merge(DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsData.SCID, dr.Item("ID")))
                        Next

                        Dim drSelectedCO() As DataRow = dtSCCO.Select("GroupID=" & clsData.GroupID)
                        For Each dr As DataRow In drSelectedCO
                            DL.SalesContract.DeleteDataDetailCOByID(sqlCon, sqlTrans, dr.Item("ID"))

                            DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                            DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                        Next
                    End If

                    bolReturn = True
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function GetDetailItem(ByVal strID As String) As VO.SalesContractDet
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.SalesContractDet = DL.SalesContract.GetDetailItem(sqlCon, Nothing, strID)
                Return clsData
            End Using
        End Function

        Public Shared Function SplitItem(ByVal clsSCDetMain As VO.SalesContractDet, ByVal clsSCDetSplit As VO.SalesContractDet,
                                         ByVal clsSCCOMain As VO.SalesContractDetConfirmationOrder, ByVal clsSCCOSplit As VO.SalesContractDetConfirmationOrder) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    '# Backup Split SC Item
                    If Not DL.SalesContract.IsExistsSplit(sqlCon, sqlTrans, clsSCDetMain.ID) Then DL.SalesContract.SaveDataSplitItem(sqlCon, sqlTrans, clsSCDetMain.ID)
                    For Each cls As VO.SalesContractDet In clsSCDetMain.SubItem
                        If Not DL.SalesContract.IsExistsSplit(sqlCon, sqlTrans, cls.ID) Then DL.SalesContract.SaveDataSplitItem(sqlCon, sqlTrans, cls.ID)
                    Next
                    For Each cls As VO.SalesContractDet In clsSCDetSplit.SubItem
                        If Not DL.SalesContract.IsExistsSplit(sqlCon, sqlTrans, cls.ID) Then DL.SalesContract.SaveDataSplitItem(sqlCon, sqlTrans, cls.ID)
                    Next
                    '# --------------------------------------------------------------------------------------------

                    '# Backup Split SC Item Confirmation Order
                    If Not DL.SalesContract.IsExistsSplitCO(sqlCon, sqlTrans, clsSCCOMain.ID) Then DL.SalesContract.SaveDataSplitItemCO(sqlCon, sqlTrans, clsSCCOMain.ID)
                    For Each cls As VO.SalesContractDetConfirmationOrder In clsSCCOMain.SubItem
                        If Not DL.SalesContract.IsExistsSplitCO(sqlCon, sqlTrans, cls.ID) Then DL.SalesContract.SaveDataSplitItemCO(sqlCon, sqlTrans, cls.ID)
                    Next
                    For Each cls As VO.SalesContractDetConfirmationOrder In clsSCCOSplit.SubItem
                        If Not DL.SalesContract.IsExistsSplitCO(sqlCon, sqlTrans, cls.ID) Then DL.SalesContract.SaveDataSplitItemCO(sqlCon, sqlTrans, cls.ID)
                    Next
                    '# --------------------------------------------------------------------------------------------

                    '# Backup ARAP Item
                    For Each cls As VO.ARAPItem In clsSCDetMain.DPItem
                        If Not DL.ARAP.IsExistsSplit(sqlCon, sqlTrans, cls.ID) Then DL.ARAP.SaveDataSplitItem(sqlCon, sqlTrans, cls.ID)
                    Next

                    For Each cls As VO.ARAPItem In clsSCDetSplit.DPItem
                        If Not DL.ARAP.IsExistsSplit(sqlCon, sqlTrans, cls.ID) Then DL.ARAP.SaveDataSplitItem(sqlCon, sqlTrans, cls.ID)
                    Next
                    '# --------------------------------------------------------------------------------------------

                    '# SC Item
                    Dim clsSCExists As VO.SalesContractDet = DL.SalesContract.GetDetailItem(sqlCon, sqlTrans, clsSCCOMain.ID)
                    If clsSCExists.ReceiveAmount > 0 Then Err.Raise(515, "", "Data tidak dapat displit. Dikarenakan data telah diproses Pelunasan.")

                    '# Process Split SC Item
                    clsSCDetSplit.ID = GetNewIDSubitem(sqlCon, sqlTrans, clsSCDetMain.SCID)
                    clsSCDetSplit.GroupID = DL.SalesContract.GetMaxGroupIDItem(sqlCon, sqlTrans, clsSCDetMain.SCID)
                    DL.SalesContract.SaveDataDetail(sqlCon, sqlTrans, clsSCDetSplit)

                    '# Move Existing Sub Item to New SC Item
                    For Each cls As VO.SalesContractDet In clsSCDetSplit.SubItem
                        cls.GroupID = clsSCDetSplit.GroupID
                        cls.ParentID = clsSCDetSplit.ID
                        DL.SalesContract.MoveDetailItem(sqlCon, sqlTrans, cls.ID, cls.GroupID, cls.ParentID, cls.SplitFrom)
                    Next

                    '# Update Existing SC Item
                    DL.SalesContract.UpdateSplitItem(sqlCon, sqlTrans, clsSCDetMain)
                    '# --------------------------------------------------------------------------------------------

                    '# SC CO Item
                    DL.SalesContract.UpdateSplitDetailCO(sqlCon, sqlTrans, clsSCCOMain)
                    Dim clsSCCO As VO.SalesContractDetConfirmationOrder = DL.SalesContract.GetDetailCOItem(sqlCon, sqlTrans, clsSCCOSplit.SCID, clsSCCOSplit.GroupID)
                    Dim strNewSCCOID As String = clsSCDetSplit.SCID & "-" & 2 & "-"
                    clsSCCO.ID = strNewSCCOID & Format(DL.SalesContract.GetMaxIDDetailCO(sqlCon, sqlTrans, strNewSCCOID) + 1, "000")
                    clsSCCO.GroupID = clsSCDetSplit.GroupID
                    clsSCCO.Weight = clsSCCOSplit.Weight
                    clsSCCO.Quantity = clsSCCOSplit.Quantity
                    clsSCCO.TotalWeight = clsSCCOSplit.TotalWeight
                    clsSCCO.TotalPrice = clsSCCOSplit.TotalPrice
                    DL.SalesContract.SaveDataDetailCO(sqlCon, sqlTrans, clsSCCO)

                    '# Move Existing Sub Item to New SC CO Item
                    For Each cls As VO.SalesContractDetConfirmationOrder In clsSCCOSplit.SubItem
                        cls.GroupID = clsSCDetSplit.GroupID
                        cls.ParentID = clsSCCO.ID
                        DL.SalesContract.MoveDetailItemCO(sqlCon, sqlTrans, cls.ID, cls.GroupID, cls.ParentID, cls.SplitFrom)
                    Next
                    '# --------------------------------------------------------------------------------------------

                    '# Down Payment Item
                    '# Insert new Down Payment Item
                    For Each cls As VO.ARAPItem In clsSCDetSplit.DPItem
                        Dim clsExists As VO.ARAPItem = DL.ARAP.GetDetailIItem(sqlCon, sqlTrans, cls.ID)
                        Dim strNewID As String = clsExists.ParentID & "-" & 2 & "-"
                        clsExists.ID = strNewID & Format(DL.ARAP.GetMaxIDARAPItem(sqlCon, sqlTrans, strNewID) + 1, "000")
                        clsExists.ReferencesDetailID = clsSCDetSplit.ID
                        clsExists.Quantity = cls.Quantity
                        clsExists.Weight = cls.Weight
                        clsExists.TotalWeight = cls.TotalWeight
                        clsExists.Amount = cls.Amount
                        clsExists.PPN = cls.PPN
                        clsExists.PPH = cls.PPH
                        DL.ARAP.SaveDataItem(sqlCon, sqlTrans, clsExists)
                        DL.SalesContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, cls.ReferencesID, clsExists.ReferencesDetailID)
                    Next

                    '# Update Existing Down Payment
                    For Each cls As VO.ARAPItem In clsSCDetMain.DPItem
                        DL.ARAP.UpdateSplitItem(sqlCon, sqlTrans, cls)
                    Next
                    '# --------------------------------------------------------------------------------------------

                    '# Recalculate SC Item DP Amount
                    DL.SalesContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, clsSCCOSplit.SCID, clsSCDetSplit.ID)
                    DL.SalesContract.CalculateItemTotalUsedDownPayment(sqlCon, sqlTrans, clsSCCOMain.SCID, clsSCDetMain.ID)
                    '# --------------------------------------------------------------------------------------------

                    bolReturn = True
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function UnSplitItem(ByVal strSCDetailID As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    '# Delete SC Item and Sub Item then Insert All Old Data from Table Split
                    Dim clsSCDetailSplit As VO.SalesContractDet = DL.SalesContract.GetDetailItem(sqlCon, sqlTrans, strSCDetailID)
                    If clsSCDetailSplit.SplitFrom.Trim = "" Then Err.Raise(515, "", "Data tidak dapat di batal split. Dikarenakan data bukan dari hasil split.")
                    If clsSCDetailSplit.ReceiveAmount > 0 Then Err.Raise(515, "", "Data tidak dapat di batal split. Dikarenakan data telah diproses Pelunasan.")
                    Dim clsSCDetailMain As VO.SalesContractDet = DL.SalesContract.GetDetailItem(sqlCon, sqlTrans, clsSCDetailSplit.SplitFrom)

                    Dim dtSCDetailItem As DataTable = DL.SalesContract.ListDataDetailByIDOrParentID(sqlCon, sqlTrans, clsSCDetailSplit.ID)
                    dtSCDetailItem.Merge(DL.SalesContract.ListDataDetailByIDOrParentID(sqlCon, sqlTrans, clsSCDetailSplit.SplitFrom))

                    Dim clsHelper As New DataSetHelper
                    Dim dtGroupSCDetailItem As DataTable = clsHelper.SelectGroupByInto("GroupSCDetailItem", dtSCDetailItem, "ID", "", "ID")

                    DL.SalesContract.DeleteDataSplitItemFrom(sqlCon, sqlTrans, clsSCDetailSplit.SplitFrom)
                    DL.SalesContract.DeleteDataDetailByID(sqlCon, sqlTrans, clsSCDetailSplit.SplitFrom)
                    DL.SalesContract.DeleteDataDetailByParentID(sqlCon, sqlTrans, clsSCDetailSplit.SplitFrom)
                    For Each dr As DataRow In dtGroupSCDetailItem.Rows
                        DL.SalesContract.RevertDataSplitItem(sqlCon, sqlTrans, dr.Item("ID"))
                    Next
                    '# --------------------------------------------------------------------------------------------

                    '# Delete SC Item CO and Sub Item then Insert All Old Data from Table Split
                    Dim dtSCDetailCO As DataTable = DL.SalesContract.ListDataSplitCO(sqlCon, sqlTrans, clsSCDetailMain.SCID, clsSCDetailMain.GroupID)
                    dtSCDetailCO.Merge(DL.SalesContract.ListDataSplitCOParent(sqlCon, sqlTrans, clsSCDetailSplit.SCID, clsSCDetailSplit.GroupID))
                    DL.SalesContract.DeleteDataSplitItemCOFrom(sqlCon, sqlTrans, clsSCDetailSplit.SplitFrom)
                    clsHelper = New DataSetHelper
                    Dim dtGroupSCCOItem As DataTable = clsHelper.SelectGroupByInto("GroupSCCOItem", dtSCDetailCO, "ID", "", "ID")
                    For Each dr As DataRow In dtGroupSCCOItem.Rows
                        DL.SalesContract.DeleteDataDetailCOByID(sqlCon, sqlTrans, dr.Item("ID"))
                    Next
                    For Each dr As DataRow In dtGroupSCCOItem.Rows
                        DL.SalesContract.RevertDataSplitItemCO(sqlCon, sqlTrans, dr.Item("ID"))
                    Next
                    '# --------------------------------------------------------------------------------------------

                    '# Delete SC Item CO and Sub Item then Insert All Old Data from Table Split
                    Dim dtARAPItem As DataTable = DL.SalesContract.ListDataDownPaymentBySCDetailID(sqlCon, sqlTrans, clsSCDetailMain.ID)
                    dtARAPItem.Merge(DL.SalesContract.ListDataDownPaymentBySCDetailID(sqlCon, sqlTrans, clsSCDetailSplit.ID))
                    DL.ARAP.DeleteDataSplitItemFrom(sqlCon, sqlTrans, clsSCDetailSplit.SplitFrom)
                    clsHelper = New DataSetHelper
                    Dim dtGroupARAPItem As DataTable = clsHelper.SelectGroupByInto("GroupARAPItem", dtSCDetailItem, "ID", "", "ID")
                    For Each dr As DataRow In dtGroupARAPItem.Rows
                        DL.ARAP.DeleteDataItemByID(sqlCon, sqlTrans, dr.Item("ID"))
                    Next
                    For Each dr As DataRow In dtGroupARAPItem.Rows
                        DL.ARAP.RevertDataSplitItem(sqlCon, sqlTrans, dr.Item("ID"))
                    Next
                    '# --------------------------------------------------------------------------------------------

                    bolReturn = True
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function ListDataDownPaymentBySCDetailID(ByVal strSCDetailID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDownPaymentBySCDetailID(sqlCon, Nothing, strSCDetailID)
            End Using
        End Function

#End Region

#Region "Detail Confirmation Order"

        Public Shared Function ListDataDetailCO(ByVal strSCID As String, ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetailCO(sqlCon, Nothing, strSCID, strParentID)
            End Using
        End Function

        Public Shared Function SaveDataDetailCOSubitem(ByVal bolNew As Boolean, ByVal strSCID As String,
                                                       ByVal clsData As VO.SalesContractDetConfirmationOrder) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        If clsData.ID.Trim = "" Then clsData.ID = GetNewIDDetailCOSubitem(sqlCon, sqlTrans, clsData.ParentID)
                    Else
                        Dim clsSC As VO.SalesContract = DL.SalesContract.GetDetail(sqlCon, sqlTrans, strSCID)
                        If clsSC.StatusID <> VO.Status.Values.Approved Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data belum di approve")
                        ElseIf clsSC.IsDeleted Then
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                        Else
                            DL.SalesContract.DeleteDataDetailCOByID(sqlCon, sqlTrans, clsData.ID)
                            DL.PurchaseContract.CalculateSCTotalUsedSubitem(sqlCon, sqlTrans, clsData.PCDetailID)
                        End If
                    End If

                    DL.SalesContract.SaveDataDetailCO(sqlCon, sqlTrans, clsData)
                    DL.PurchaseContract.CalculateSCTotalUsedSubitem(sqlCon, sqlTrans, clsData.PCDetailID)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Sub DeleteDetailCOSubItem(ByVal strID As String, ByVal strPCDetailID As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    DeleteDetailCOItem(sqlCon, sqlTrans, strID, strPCDetailID)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub DeleteDetailCOItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strID As String, ByVal strPCDetailID As String)
            DL.SalesContract.DeleteDataDetailCOByID(sqlCon, sqlTrans, strID)
            DL.PurchaseContract.CalculateSCTotalUsedSubitem(sqlCon, sqlTrans, strPCDetailID)
        End Sub

        Public Shared Function ChangeCODetailItem(ByVal clsData As VO.SalesContractDetConfirmationOrder) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    bolReturn = ChangeCODetailItem(sqlCon, sqlTrans, clsData)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Private Shared Function ChangeCODetailItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.SalesContractDetConfirmationOrder) As Boolean
            Dim dtSCDetail As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.SCID, "")
            Dim dtSCCODetail As DataTable = DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsData.SCID, "")
            Dim drSelectedDetail() As DataRow = dtSCDetail.Select("GroupID=" & clsData.GroupID)
            Dim drSelectedDetailCO() As DataRow = dtSCCODetail.Select("ID='" & clsData.ID & "'")
            Dim drDCWeight() As DataRow = dtSCDetail.Select("DCWeight>0 AND GroupID=" & clsData.GroupID)
            If drDCWeight.Count > 0 Then Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pengiriman")

            Dim dtSCDetailCOSubItem As New DataTable
            For Each dr As DataRow In drSelectedDetailCO
                dtSCDetailCOSubItem.Merge(DL.SalesContract.ListDataDetailCO(sqlCon, sqlTrans, clsData.SCID, dr.Item("ID")))
            Next

            If dtSCDetailCOSubItem.Rows.Count > 0 Then Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah memiliki Subitem. Hapus Subitem pada Item ini terlebih dahulu / Hubungi IT Support Anda.")

            '# Change Order Number Supplier ARAP Item
            For Each dr As DataRow In drSelectedDetail
                DL.ARAP.ChangeOrderNumberSupplierDetail(sqlCon, sqlTrans, dr.Item("ID"), dr.Item("OrderNumberSupplier"), clsData.OrderNumberSupplier)
                DL.SalesContract.UpdateDetailItem(sqlCon, sqlTrans, dr.Item("ID"), clsData.OrderNumberSupplier, clsData.UnitPrice)
            Next

            DL.SalesContract.UpdateDetailCOItem(sqlCon, sqlTrans, clsData)

            '# Recalculate SC Quantity in Confirmation Order
            For Each dr As DataRow In drSelectedDetailCO
                DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
                DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, dr.Item("CODetailID"))
            Next

            DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, clsData.CODetailID)
            DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, clsData.CODetailID)
            Return True
        End Function

        Public Shared Function AddAdditionalCOItem(ByVal clsData As VO.SalesContractDetConfirmationOrder) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtSCDet As DataTable = DL.SalesContract.ListDataDetail(sqlCon, sqlTrans, clsData.SCID, "")
                    Dim drSelected() As DataRow = dtSCDet.Select("GroupID=" & clsData.GroupID)
                    For Each dr As DataRow In drSelected
                        DL.SalesContract.UpdateDetailGroupID(sqlCon, sqlTrans, dr.Item("ID"), clsData.GroupID, clsData.UnitPrice)
                    Next

                    clsData.ID = GetNewIDDetailCOItem(sqlCon, sqlTrans, clsData.SCID)
                    DL.SalesContract.SaveDataDetailCO(sqlCon, sqlTrans, clsData)
                    DL.ConfirmationOrder.CalculateSCTotalUsed(sqlCon, sqlTrans, clsData.CODetailID)
                    DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, clsData.CODetailID)

                    bolReturn = True
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function GetDetailCOItem(ByVal strID As String) As VO.SalesContractDetConfirmationOrder
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim clsData As VO.SalesContractDetConfirmationOrder = DL.SalesContract.GetDetailCOItem(sqlCon, Nothing, strID)
                Return clsData
            End Using
        End Function

#End Region

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataPaymentTerm(sqlCon, Nothing, strSCID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strSCID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataStatus(sqlCon, Nothing, strSCID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strSCID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strSCID & "-" & Format(DL.SalesContract.GetMaxIDStatus(sqlCon, sqlTrans, strSCID) + 1, "000")
            Dim clsData As New VO.SalesContractStatus With
                {
                    .ID = strNewID,
                    .SCID = strSCID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.SalesContract.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace