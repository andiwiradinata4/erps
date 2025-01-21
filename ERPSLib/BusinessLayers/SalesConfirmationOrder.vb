Namespace BL
 
    Public Class SalesConfirmationOrder

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                    ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                    ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesConfirmationOrder.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "SCO" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.SalesConfirmationOrder.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function GetNewNo(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = Format(DL.SalesConfirmationOrder.GetMaxNo(sqlCon, sqlTrans, dtmTransDate.Year, intCompanyID, intProgramID) + 1, "000")
            strNewID &= "-" & clsCompany.CompanyInitial & "-" & Format(dtmTransDate.Month, "00") & "-" & Format(dtmTransDate, "yy")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.SalesConfirmationOrder) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.CODate, clsData.CompanyID, clsData.ProgramID)
                        If clsData.CONumber.Trim = "" Then clsData.CONumber = GetNewNo(sqlCon, sqlTrans, clsData.CODate, clsData.CompanyID, clsData.ProgramID)
                    Else
                        Dim dtItem As DataTable = DL.SalesConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, clsData.ID)

                        DL.SalesConfirmationOrder.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.SalesConfirmationOrder.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.ID)

                        '# Revert SCO Quantity in Order Request & Purchase Order
                        For Each dr As DataRow In dtItem.Rows
                            DL.OrderRequest.CalculateSCOTotalUsed(sqlCon, sqlTrans, dr.Item("ORDetailID"))
                            DL.PurchaseOrder.CalculateSCOTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                        Next
                    End If

                    Dim intStatusID As Integer = DL.SalesConfirmationOrder.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.SalesConfirmationOrder.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.SalesConfirmationOrder.DataExists(sqlCon, sqlTrans, clsData.CONumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.CONumber & " sudah ada.")
                    End If

                    DL.SalesConfirmationOrder.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.SalesConfirmationOrderDet In clsData.Detail
                        Dim prevID As String = clsDet.ID
                        clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                        clsDet.COID = clsData.ID
                        DL.SalesConfirmationOrder.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Payment Term
                    intCount = 1
                    For Each clsDet As VO.SalesConfirmationOrderPaymentTerm In clsData.PaymentTerm
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.COID = clsData.ID
                        DL.SalesConfirmationOrder.SaveDataPaymentTerm(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Calculate SCO Quantity in Order Request & Purchase Order
                    For Each clsDet As VO.SalesConfirmationOrderDet In clsData.Detail
                        DL.OrderRequest.CalculateSCOTotalUsed(sqlCon, sqlTrans, clsDet.ORDetailID)
                        DL.PurchaseOrder.CalculateSCOTotalUsed(sqlCon, sqlTrans, clsDet.PODetailID)
                    Next

                    '# Validate Over Weight


                    '# Save Data Status
                    BL.SalesConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.CONumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.SalesConfirmationOrder
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesConfirmationOrder.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.SalesConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    Dim dtItem As DataTable = DL.SalesConfirmationOrder.ListDataDetail(sqlCon, sqlTrans, strID)

                    DL.SalesConfirmationOrder.DeleteData(sqlCon, sqlTrans, strID)

                    '# Revert SCO Quantity in Order Request & Purchase Order
                    For Each dr As DataRow In dtItem.Rows
                        DL.OrderRequest.CalculateSCOTotalUsed(sqlCon, sqlTrans, dr.Item("ORDetailID"))
                        DL.PurchaseOrder.CalculateSCOTotalUsed(sqlCon, sqlTrans, dr.Item("PODetailID"))
                    Next

                    '# Save Data Status
                    BL.SalesConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.SalesConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.SalesConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.SalesConfirmationOrder.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.SalesConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.SalesConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.SalesConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesConfirmationOrder.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                    Dim intStatusID As Integer = DL.SalesConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf DL.SalesConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesConfirmationOrder.Approve(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                    Dim intStatusID As Integer = DL.SalesConfirmationOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.SalesConfirmationOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.SalesConfirmationOrder.Unapprove(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.SalesConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function PrintVer00(ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                dtReturn = DL.SalesConfirmationOrder.PrintVer00(sqlCon, Nothing, strID)
                Dim clsHelper As New DataSetHelper
                Dim dtItemTypeAndSpec As DataTable = clsHelper.SelectGroupByInto("ItemTypeAndSpec", dtReturn, "ItemSpec", "", "ItemSpec")

                '# Combine AllItemName
                Dim strItemTypeAndSpec As String = ""
                Dim strAllItemTypeAndSpec As String = ""
                For Each dr As DataRow In dtItemTypeAndSpec.Rows
                    If dr.Item("ItemSpec") <> strItemTypeAndSpec Then
                        strItemTypeAndSpec = dr.Item("ItemSpec")
                        If strAllItemTypeAndSpec.Trim <> "" Then strAllItemTypeAndSpec += ", "
                        strAllItemTypeAndSpec += strItemTypeAndSpec
                    End If
                Next

                '# Combine Payment Terms
                Dim strPaymentTerms As String = ""
                Dim dtPaymentTerm As DataTable = DL.SalesConfirmationOrder.ListDataPaymentTerm(sqlCon, Nothing, strID)
                Dim intMaxCreditTerms As Integer = 0
                For Each dr As DataRow In dtPaymentTerm.Rows
                    If strPaymentTerms.Trim <> "" Then strPaymentTerms += ", "
                    strPaymentTerms += CInt(dr.Item("Percentage")) & "% " & dr.Item("PaymentTypeName") '& " BY " & dr.Item("PaymentModeName")
                    If intMaxCreditTerms < dr.Item("CreditTerm") Then intMaxCreditTerms = dr.Item("CreditTerm")
                Next

                For Each dr As DataRow In dtReturn.Rows
                    dr.BeginEdit()
                    dr.Item("AllItemName") = strAllItemTypeAndSpec
                    dr.Item("PaymentTerms") = strPaymentTerms
                    dr.Item("DeliveryPeriod") = Format(dr.Item("DeliveryPeriodFrom"), "MMMM") & " - " & Format(dr.Item("DeliveryPeriodTo"), "MMMM yyyy")
                    dr.Item("NumericToString") = SharedLib.Math.NumberToString(dr.Item("GrandTotal"))
                    dr.EndEdit()
                Next
                dtReturn.AcceptChanges()
            End Using

            Return dtReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strCOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesConfirmationOrder.ListDataDetail(sqlCon, Nothing, strCOID)
            End Using
        End Function

#End Region

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByVal strCOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesConfirmationOrder.ListDataPaymentTerm(sqlCon, Nothing, strCOID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strCOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesConfirmationOrder.ListDataStatus(sqlCon, Nothing, strCOID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strSCID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strSCID & "-" & Format(DL.SalesConfirmationOrder.GetMaxIDStatus(sqlCon, sqlTrans, strSCID) + 1, "000")
            Dim clsData As New VO.SalesConfirmationOrderStatus With
                {
                    .ID = strNewID,
                    .COID = strSCID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.SalesConfirmationOrder.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class 

End Namespace

