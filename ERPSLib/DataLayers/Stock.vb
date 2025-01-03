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
"   ISNULL(TSI.OrderNumberSupplier,'') AS OrderNumberSupplier, TSI.UnitPrice " & vbNewLine &
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
"       TSI.ItemID, TSI.OrderNumberSupplier, TSI.UnitPrice, SUM(TSI.InTotalWeight)-SUM(TSI.OutTotalWeight)-SUM(TSI.OutTotalWeightProcess) Balance, SUM(TSI.OutTotalWeightProcess) AS OnProgressBalance  " & vbNewLine &
"	FROM traStockIn TSI  " & vbNewLine &
"	GROUP BY TSI.ItemID, TSI.OrderNumberSupplier, TSI.UnitPrice  " & vbNewLine &
") TSI ON MI.ID=TSI.ItemID  " & vbNewLine
                Else
                    .CommandText +=
"LEFT JOIN  " & vbNewLine &
"( " & vbNewLine &
"	SELECT  " & vbNewLine &
"       TSI.ItemID, CAST('' AS VARCHAR(100)) AS OrderNumberSupplier, CAST(0 AS DECIMAL(18,4)) AS UnitPrice, SUM(TSI.InTotalWeight)-SUM(TSI.OutTotalWeight)-SUM(TSI.OutTotalWeightProcess) Balance, SUM(TSI.OutTotalWeightProcess) AS OnProgressBalance  " & vbNewLine &
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

        Public Shared Function ListDataHistory(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                               ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                               ByVal intItemID As Integer, ByVal strOrderNumberSupplier As String,
                                               ByVal enumHistory As VO.Stock.History) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If enumHistory = VO.Stock.History.SalesContract Then
                    .CommandText =
"SELECT	  " & vbNewLine & _
"    A1.ID, A1.ProgramID, MP.Name AS ProgramName, A1.CompanyID, MC.Name AS CompanyName, A1.SCNumber AS TransNumber, A1.SCDate AS TransDate,  " & vbNewLine & _
"	A1.BPID, BP.Code AS BPCode, BP.Name AS BPName, A.OrderNumberSupplier, A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.CreatedBy, A1.CreatedDate,  " & vbNewLine & _
"	A1.LogBy, A1.LogDate, A1.LogInc  " & vbNewLine & _
"FROM traSalesContractDet A  	  " & vbNewLine & _
"INNER JOIN traSalesContract A1 ON  	  " & vbNewLine & _
"    A.SCID=A1.ID  " & vbNewLine & _
"INNER JOIN mstProgram MP ON  " & vbNewLine & _
"	A1.ProgramID=MP.ID  " & vbNewLine & _
"INNER JOIN mstCompany MC ON  " & vbNewLine & _
"	A1.CompanyID=MC.ID  " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON  " & vbNewLine & _
"	A1.BPID=BP.ID  " & vbNewLine & _
"WHERE  	  " & vbNewLine & _
"	A1.ApprovedBy<>''  " & vbNewLine & _
"	AND A1.ProgramID=@ProgramID  " & vbNewLine & _
"	AND A1.CompanyID=@CompanyID  " & vbNewLine & _
"	AND A1.SCDate>=@DateFrom AND A1.SCDate<=@DateTo  " & vbNewLine & _
"	AND A.ItemID=@ItemID  " & vbNewLine

                    If strOrderNumberSupplier.Trim <> "" Then .CommandText += "	AND A.OrderNumberSupplier=@OrderNumberSupplier  " & vbNewLine

                    .CommandText += "ORDER BY A1.SCNumber ASC    " & vbNewLine

                ElseIf enumHistory = VO.Stock.History.PurchaseContract Then
                    .CommandText +=
"SELECT	  " & vbNewLine & _
"    A1.ID, A1.ProgramID, MP.Name AS ProgramName, A1.CompanyID, MC.Name AS CompanyName, A1.PCNumber AS TransNumber, A1.PCDate AS TransDate,  " & vbNewLine & _
"	A1.BPID, BP.Code AS BPCode, BP.Name AS BPName, A.OrderNumberSupplier, A.Quantity, A.Weight, A.TotalWeight, A.UnitPrice, A.TotalPrice, A1.CreatedBy, A1.CreatedDate,  " & vbNewLine & _
"	A1.LogBy, A1.LogDate, A1.LogInc  " & vbNewLine & _
"FROM traPurchaseContractDet A  	  " & vbNewLine & _
"INNER JOIN traPurchaseContract A1 ON  	  " & vbNewLine & _
"    A.PCID=A1.ID  " & vbNewLine & _
"INNER JOIN mstProgram MP ON  " & vbNewLine & _
"	A1.ProgramID=MP.ID  " & vbNewLine & _
"INNER JOIN mstCompany MC ON  " & vbNewLine & _
"	A1.CompanyID=MC.ID  " & vbNewLine & _
"INNER JOIN mstBusinessPartner BP ON  " & vbNewLine & _
"	A1.BPID=BP.ID  " & vbNewLine & _
"WHERE  	  " & vbNewLine & _
"	A1.ApprovedBy<>''  " & vbNewLine & _
"	AND A1.ProgramID=@ProgramID  " & vbNewLine & _
"	AND A1.CompanyID=@CompanyID  " & vbNewLine & _
"	AND A1.PCDate>=@DateFrom AND A1.PCDate<=@DateTo  " & vbNewLine & _
"	AND A.ItemID=@ItemID  " & vbNewLine

                    If strOrderNumberSupplier.Trim <> "" Then .CommandText += "	AND A.OrderNumberSupplier=@OrderNumberSupplier  " & vbNewLine

                    .CommandText += "ORDER BY A1.PCNumber ASC    " & vbNewLine
                End If

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom.Date
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOrderNumberSupplier
            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function
    End Class

End Namespace