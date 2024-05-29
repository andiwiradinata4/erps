Namespace DL
    Public Class Stock

        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal intItemTypeID As Integer, ByVal intItemSpecificationID As Integer,
                                        ByVal bolShowAll As Boolean, ByVal bolIsLookup As Boolean) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"SELECT  " & vbNewLine &
"	MI.ID, MI.ItemCode, MI.ItemName, MI.ItemTypeID, MIT.Description AS ItemTypeName, MI.ItemSpecificationID, MIS.Description AS ItemSpecificationName,  " & vbNewLine &
"	MI.Thick, MI.Width, MI.Length, MI.Weight, MI.StatusID, MS.Name AS StatusInfo, ISNULL(TSI.Balance,0) AS Balance, ISNULL(TSI.OnProgressBalance,0) AS OnProgressBalance, " & vbNewLine &
"   TSI.OrderNumberSupplier, TSI.UnitPrice " & vbNewLine &
"FROM mstItem MI  " & vbNewLine &
"INNER JOIN mstItemType MIT ON  " & vbNewLine &
"	MI.ItemTypeID=MIT.ID  " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON  " & vbNewLine &
"	MI.ItemSpecificationID=MIS.ID  " & vbNewLine &
"INNER JOIN mstStatus MS ON  " & vbNewLine &
"	MI.StatusID=MS.ID  " & vbNewLine

                If bolIsLookup Then
                    .CommandText +=
"INNER JOIN  " & vbNewLine &
"( " & vbNewLine &
"	SELECT  " & vbNewLine &
"       TSI.ItemID, TSI.OrderNumberSupplier, TSI.UnitPrice, SUM(TSI.InTotalWeight)-SUM(TSI.OutWeight)-SUM(TSI.OutTotalWeightProcess) Balance, SUM(TSI.OutTotalWeightProcess) AS OnProgressBalance  " & vbNewLine &
"	FROM traStockIn TSI  " & vbNewLine &
"	GROUP BY TSI.ItemID, TSI.OrderNumberSupplier, TSI.UnitPrice  " & vbNewLine &
") TSI ON MI.ID=TSI.ItemID  " & vbNewLine
                Else
                    .CommandText +=
"LEFT JOIN  " & vbNewLine &
"( " & vbNewLine &
"	SELECT  " & vbNewLine &
"       TSI.ItemID, CAST('' AS VARCHAR(100)) AS OrderNumberSupplier, CAST(0 AS DECIMAL(18,4)) AS UnitPrice, SUM(TSI.InTotalWeight)-SUM(TSI.OutWeight)-SUM(TSI.OutTotalWeightProcess) Balance, SUM(TSI.OutTotalWeightProcess) AS OnProgressBalance  " & vbNewLine &
"	FROM traStockIn TSI  " & vbNewLine &
"	GROUP BY TSI.ItemID  " & vbNewLine &
") TSI ON MI.ID=TSI.ItemID  " & vbNewLine
                End If

                .CommandText += "WHERE 1=1 " & vbNewLine

                If Not bolShowAll Then
                    If intItemTypeID > 0 Then
                        .CommandText += "   AND MI.ItemTypeID=@ItemTypeID "
                        .Parameters.Add("@ItemTypeID", SqlDbType.Int).Value = intItemTypeID
                    End If

                    If intItemSpecificationID > 0 Then
                        .CommandText += "   AND MI.ItemSpecificationID=@ItemSpecificationID "
                        .Parameters.Add("@ItemSpecificationID", SqlDbType.Int).Value = intItemSpecificationID
                    End If
                End If

                If bolIsLookup Then .CommandText += "   AND ISNULL(TSI.Balance,0)>0 " & vbNewLine

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

    End Class

End Namespace