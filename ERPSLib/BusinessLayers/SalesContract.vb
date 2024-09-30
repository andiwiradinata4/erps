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

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "SC" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.SalesContract.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function GetNewIDSubitem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strSCID As String) As String
            Dim strNewID As String = strSCID & "-"
            strNewID &= Format(DL.SalesContract.GetMaxIDDetail(sqlCon, sqlTrans, strNewID) + 1, "000")
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
                    ElseIf DL.SalesContract.IsAlreadyPayment(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dilanjutkan proses pengiriman")
                    End If

                    DL.SalesContract.Unapprove(sqlCon, sqlTrans, strID)

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
                    strPaymentTerms += CInt(dr.Item("Percentage")) & "% " & dr.Item("PaymentTypeName") & " BY " & dr.Item("PaymentModeName")
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
                For Each dr As DataRow In dtReturn.Rows
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
                dtReturn = DL.SalesContract.PrintSCCOVer00(sqlCon, Nothing, intProgramID, intCompanyID, strID, clsData.IsUseSubItem)

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
                For Each dr As DataRow In dtReturn.Rows
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
                    dr.Item("NumericToString") = SharedLib.Math.NumberToString(dr.Item("GrandTotal"))
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
                            Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses penerimaan")
                        Else
                            DL.SalesContract.DeleteDataDetailByID(sqlCon, sqlTrans, clsData.ID)
                        End If
                    End If

                    DL.SalesContract.SaveDataDetail(sqlCon, sqlTrans, clsData)
                    DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, clsData.PCDetailID)
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

        Public Shared Sub DeleteSubItem(ByVal strID As String, ByVal strSCID As String, ByVal strPCDetailID As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If DL.SalesContract.IsAlreadyReceiveSubitem(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses penerimaan")
                    ElseIf DL.SalesContract.IsAlreadyPaymentSubitem(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah diproses pembayaran")
                    End If

                    DL.SalesContract.DeleteDataDetailByID(sqlCon, sqlTrans, strID)
                    DL.PurchaseContract.CalculateSCTotalUsed(sqlCon, sqlTrans, strPCDetailID)

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

#End Region

#Region "Detail Confirmation Order"

        Public Shared Function ListDataDetailCO(ByVal strSCID As String, ByVal strParentID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesContract.ListDataDetailCO(sqlCon, Nothing, strSCID, strParentID)
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