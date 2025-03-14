Namespace BL
    Public Class Setup
        Public Shared Sub CalculateTotalSCWeightInPurchaseContract()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.CalculateTotalSCWeightInPurchaseContract(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub CalculateTotalSCWeightSubItemInPurchaseContract()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.CalculateTotalSCWeightSubItemInPurchaseContract(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub CalculateTotalTotalPaymentSalesContract()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.ResetTotalPaymentSalesContractItem(sqlCon, Nothing)
                DL.Setup.CalculateTotalTotalPaymentSalesContractItem(sqlCon, Nothing)
                DL.Setup.CalculateTotalTotalPaymentSalesContractParentItem(sqlCon, Nothing)
                DL.Setup.CalculateTotalTotalPaymentSalesContractHeader(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub CalculateTotalPriceSalesContractSubItem()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.CalculateTotalPriceSalesContractSubItem(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub CalculateTotalPricePurchaseContractSubItem()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.CalculateTotalPricePurchaseContractSubItem(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub CalculateSCWeightInSalesContract()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.ResetSCWeightConfirmationOrder(sqlCon, Nothing)
                DL.Setup.CalculateSCWeightInSalesContract(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub CalculateDPAmountOrderRequestInDPSalesContract()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.CalculateDPAmountOrderRequestInDPSalesContract(sqlCon, Nothing)
                DL.Setup.CalculateDPAmountOrderRequestInOrderRequestHeader(sqlCon, Nothing)
            End Using
        End Sub

        Public Shared Sub GenerateVoucher()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    Dim dtData As DataTable = DL.Setup.ListDataARAPForCreateVoucher(sqlCon, sqlTrans)
                    For Each dr As DataRow In dtData.Rows
                        Dim clsVourcher As VO.ARAPVoucher = BL.ARAP.GenerateVoucher(sqlCon, sqlTrans, dr.Item("ProgramID"), dr.Item("CompanyID"), dr.Item("TransDate"), dr.Item("VoucherType"), dr.Item("ParentID"), dr.Item("InvoiceNumber"), dr.Item("CoAID"), dr.Item("TotalAmount"), "", "SYSTEM")
                        If dr.Item("Trans") = "COST" Then DL.Cost.UpdateVoucherNumber(sqlCon, sqlTrans, dr.Item("ParentID"), clsVourcher.VoucherNumber, dr.Item("TransDate"))
                        If dr.Item("Trans") = "AP" Then DL.AccountPayable.UpdateVoucherNumber(sqlCon, sqlTrans, dr.Item("ParentID"), clsVourcher.VoucherNumber, dr.Item("TransDate"))
                        If dr.Item("Trans") = "ARAPINV" Then DL.ARAP.UpdateVoucherNumberInvoice(sqlCon, sqlTrans, dr.Item("ParentID"), clsVourcher.VoucherNumber, dr.Item("TransDate"))
                    Next
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Shared Sub CalculateUnitPriceHPPSalesContract()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                DL.Setup.CalculateUnitPriceHPPSalesContract(sqlCon, Nothing)
            End Using
        End Sub

    End Class
End Namespace