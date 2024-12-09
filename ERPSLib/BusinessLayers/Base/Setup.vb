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

    End Class
End Namespace