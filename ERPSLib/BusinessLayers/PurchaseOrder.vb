Namespace BL
    Public Class PurchaseOrder

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrder.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
            End Using
        End Function

        'Public Shared Function ListDataOutstandingForCutting(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
        '                                                     ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
        '                                                     ByVal intStatusID As Integer) As DataTable
        '    BL.Server.ServerDefault()
        '    Using sqlCon As SqlConnection = DL.SQL.OpenConnection
        '        Return DL.PurchaseOrder.ListDataOutstandingForCutting(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
        '    End Using
        'End Function

        'Public Shared Function ListDataOutstandingForTransport(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
        '                                                       ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
        '                                                       ByVal intStatusID As Integer) As DataTable
        '    BL.Server.ServerDefault()
        '    Using sqlCon As SqlConnection = DL.SQL.OpenConnection
        '        Return DL.PurchaseOrder.ListDataOutstandingForTransport(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID)
        '    End Using
        'End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer, ByVal intProgramID As Integer) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strNewID As String = "PO" & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & "A" & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.PurchaseOrder.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PurchaseOrder) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.PODate, clsData.CompanyID, clsData.ProgramID)
                        clsData.PONumber = clsData.ID
                    Else
                        DL.PurchaseOrder.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                        DL.PurchaseOrder.DeleteDataPaymentTerm(sqlCon, sqlTrans, clsData.ID)
                    End If

                    Dim intStatusID As Integer = DL.PurchaseOrder.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.PurchaseOrder.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.PurchaseOrder.DataExists(sqlCon, sqlTrans, clsData.PONumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.PONumber & " sudah ada.")
                    End If

                    DL.PurchaseOrder.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    '# Save Data Detail
                    Dim intCount As Integer = 1
                    For Each clsDet As VO.PurchaseOrderDet In clsData.Detail
                        clsDet.ID = clsData.ID & "-" & 1 & "-" & Format(intCount, "000")
                        clsDet.POID = clsData.ID
                        DL.PurchaseOrder.SaveDataDetail(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Payment Term
                    intCount = 1
                    For Each clsDet As VO.PurchaseOrderPaymentTerm In clsData.PaymentTerm
                        clsDet.ID = clsData.ID & "-" & Format(intCount, "000")
                        clsDet.POID = clsData.ID
                        DL.PurchaseOrder.SaveDataPaymentTerm(sqlCon, sqlTrans, clsDet)
                        intCount += 1
                    Next

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.PONumber
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.PurchaseOrder
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrder.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String, ByVal strRemarks As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.PurchaseOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di submit")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data telah di setujui")
                    ElseIf DL.PurchaseOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat dihapus. Dikarenakan data sudah pernah dihapus")
                    End If

                    DL.PurchaseOrder.DeleteData(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "HAPUS", ERPSLib.UI.usUserApp.UserID, strRemarks)
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
            Dim intStatusID As Integer = DL.PurchaseOrder.GetStatusID(sqlCon, sqlTrans, strID)
            If intStatusID = VO.Status.Values.Submit Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah SUBMIT")
            ElseIf intStatusID = VO.Status.Values.Approved Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan status data telah APPROVED")
            ElseIf DL.PurchaseOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                Err.Raise(515, "", "Data tidak dapat di submit. Dikarenakan data telah dihapus")
            End If

            DL.PurchaseOrder.Submit(sqlCon, sqlTrans, strID)

            '# Save Data Status
            BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)
        End Sub

        Public Shared Function Unsubmit(ByVal strID As String, ByVal strRemarks As String) As Boolean
            Dim bolReturn As Boolean = False
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim intStatusID As Integer = DL.PurchaseOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan status data telah APPROVED")
                    ElseIf DL.PurchaseOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di batal submit. Dikarenakan data telah dihapus")
                    End If

                    DL.PurchaseOrder.Unsubmit(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL SUBMIT", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                    Dim intStatusID As Integer = DL.PurchaseOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan status data telah APPROVED")
                    ElseIf DL.PurchaseOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.PurchaseOrder.Approve(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

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
                    Dim intStatusID As Integer = DL.PurchaseOrder.GetStatusID(sqlCon, sqlTrans, strID)
                    If intStatusID = VO.Status.Values.Draft Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data masih DRAFT")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan status data telah SUBMIT")
                    ElseIf DL.PurchaseOrder.IsDeleted(sqlCon, sqlTrans, strID) Then
                        Err.Raise(515, "", "Data tidak dapat di Batal Approve. Dikarenakan data telah dihapus")
                    End If

                    DL.PurchaseOrder.Unapprove(sqlCon, sqlTrans, strID)

                    '# Save Data Status
                    BL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, strID, "BATAL APPROVE", ERPSLib.UI.usUserApp.UserID, strRemarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return bolReturn
        End Function

        Public Shared Function Print(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                     ByVal strID As String) As DataTable
            BL.Server.ServerDefault()
            Dim dtReturn As New DataTable
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                '# Get Data
                dtReturn = DL.PurchaseOrder.Print(sqlCon, Nothing, strID)

                '# Combine Payment Terms
                Dim strPaymentTerms As String = ""
                Dim dtPaymentTerm As DataTable = DL.PurchaseOrder.ListDataPaymentTerm(sqlCon, Nothing, strID)
                For Each dr As DataRow In dtPaymentTerm.Rows
                    strPaymentTerms += CInt(dr.Item("Percentage")) & "% " & dr.Item("PaymentTypeName") & " WITH " & dr.Item("PaymentModeName") & vbCrLf
                Next

                '# Combine Delivery Period
                For Each dr As DataRow In dtReturn.Rows
                    dr.BeginEdit()
                    dr.Item("DeliveryPeriod") = Format(dr.Item("DeliveryPeriodFrom"), "MMMM") & " - " & Format(dr.Item("DeliveryPeriodTo"), "MMMM yyyy")
                    dr.Item("PODateAndCity") = dr.Item("CompanyCity") & ", " & Format(dr.Item("PODate"), "dd MMMM yyyy")
                    dr.Item("PaymentTerms") = strPaymentTerms
                    dr.EndEdit()
                Next
                dtReturn.AcceptChanges()
            End Using
            Return dtReturn
        End Function

#End Region

#Region "Detail"

        Public Shared Function ListDataDetail(ByVal strPOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrder.ListDataDetail(sqlCon, Nothing, strPOID)
            End Using
        End Function

        'Public Shared Function ListDataDetailOutstandingCuttingOrder(ByVal strPOID As String) As DataTable
        '    BL.Server.ServerDefault()
        '    Using sqlCon As SqlConnection = DL.SQL.OpenConnection
        '        Return DL.PurchaseOrder.ListDataDetailOutstandingCuttingOrder(sqlCon, Nothing, strPOID)
        '    End Using
        'End Function

        Public Shared Function ListDataDetailOutstandingConfirmationOrder(ByVal intBPID As Integer) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrder.ListDataDetailOutstandingConfirmationOrder(sqlCon, Nothing, intBPID)
            End Using
        End Function

#End Region

        '#Region "Detail Internal"

        '        Public Shared Function ListDataDetailInternal(ByVal strPOID As String) As DataTable
        '            BL.Server.ServerDefault()
        '            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
        '                Return DL.PurchaseOrder.ListDataDetailInternal(sqlCon, Nothing, strPOID)
        '            End Using
        '        End Function

        '#End Region

#Region "Payment Term"

        Public Shared Function ListDataPaymentTerm(ByVal strPOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrder.ListDataPaymentTerm(sqlCon, Nothing, strPOID)
            End Using
        End Function

#End Region

#Region "Status"

        Public Shared Function ListDataStatus(ByVal strPOID As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.PurchaseOrder.ListDataStatus(sqlCon, Nothing, strPOID)
            End Using
        End Function

        Public Shared Sub SaveDataStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strPOID As String, ByVal strStatus As String,
                                         ByVal strStatusBy As String, ByVal strRemarks As String)
            Dim strNewID As String = strPOID & "-" & Format(DL.PurchaseOrder.GetMaxIDStatus(sqlCon, sqlTrans, strPOID) + 1, "000")
            Dim clsData As New VO.PurchaseOrderStatus With
                {
                    .ID = strNewID,
                    .POID = strPOID,
                    .Status = strStatus,
                    .StatusBy = strStatusBy,
                    .Remarks = strRemarks
                }
            DL.PurchaseOrder.SaveDataStatus(sqlCon, sqlTrans, clsData)
        End Sub

#End Region

    End Class
End Namespace