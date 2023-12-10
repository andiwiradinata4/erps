Namespace DL
    Public Class ARAP

        Public Shared Function PrintVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                          ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address AS CompanyAddress, ARH.ARNumber AS TransNumber, " & vbNewLine & _
                    "   ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote, SCH.PPN, SCH.PPH, SCH.TotalDPP, " & vbNewLine & _
                    "	SCH.TotalPPN, SCH.TotalPPH, GrandTotal=SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH+SCH.RoundingManual, MC.DirectorName AS CompanyDirectorName, " & vbNewLine & _
                    "	MBC.AccountName, MBC.BankName, MBC.AccountNumber, ARH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, " & vbNewLine & _
                    "	MI.Length AS ItemLength, MI.Weight, SCD.Quantity, SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, ARH.TotalAmount, ARH.Percentage,  " & vbNewLine & _
                    "   CAST('' AS VARCHAR(1000)) AS NumericToString " & vbNewLine & _
                    "FROM traAccountReceivable ARH " & vbNewLine & _
                    "INNER JOIN traAccountReceivableDet ARD ON " & vbNewLine & _
                    "	ARH.ID=ARD.ARID " & vbNewLine & _
                    "INNER JOIN mstStatus B ON " & vbNewLine & _
                    "    ARH.StatusID=B.ID " & vbNewLine & _
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine & _
                    "    ARH.BPID=C.ID " & vbNewLine & _
                    "INNER JOIN mstCompany MC ON " & vbNewLine & _
                    "    ARH.CompanyID=MC.ID " & vbNewLine & _
                    "INNER JOIN mstProgram MP ON " & vbNewLine & _
                    "    ARH.ProgramID=MP.ID " & vbNewLine & _
                    "INNER JOIN traSalesContract SCH ON " & vbNewLine & _
                    "	ARD.SalesID=SCH.ID " & vbNewLine & _
                    "INNER JOIN traSalesContractDet SCD ON " & vbNewLine & _
                    "	SCH.ID=SCD.SCID " & vbNewLine & _
                    "INNER JOIN mstItem MI ON 	  " & vbNewLine & _
                    "    SCD.ItemID=MI.ID 	  " & vbNewLine & _
                    "INNER JOIN mstItemType IT ON 	 	  " & vbNewLine & _
                    "    MI.ItemTypeID=IT.ID 	 	  " & vbNewLine & _
                    "INNER JOIN mstItemSpecification MIS ON 	 	  " & vbNewLine & _
                    "    MI.ItemSpecificationID=MIS.ID 	 	  " & vbNewLine & _
                    "INNER JOIN mstCompanyBankAccount MBC ON " & vbNewLine & _
                    "	SCH.CompanyBankAccountID=MBC.ID" & vbNewLine & _
                    "WHERE 	" & vbNewLine & _
                    "	ARH.ProgramID=@ProgramID " & vbNewLine & _
                    "	AND ARH.CompanyID=@CompanyID " & vbNewLine & _
                    "	AND ARH.ID=@ID 	" & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListPaymentHistory(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                  ByVal strReferencesID As String, ByVal dtmTransDate As DateTime,
                                                  ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText = _
                    "SELECT " & vbNewLine & _
                    "	ARD.Amount, ARH.Modules, ARH.Percentage  " & vbNewLine & _
                    "FROM traAccountReceivable ARH " & vbNewLine & _
                    "INNER JOIN traAccountReceivableDet ARD ON " & vbNewLine & _
                    "	ARH.ID=ARD.ARID " & vbNewLine & _
                    "WHERE " & vbNewLine & _
                    "	ARD.SalesID=@ReferencesID " & vbNewLine & _
                    "	AND ARH.ProgramID=@ProgramID" & vbNewLine & _
                    "	AND ARH.CompanyID=@CompanyID " & vbNewLine & _
                    "	AND ARH.ARDate<=@TransDate " & vbNewLine & _
                    "	AND ARH.ID<>@ID " & vbNewLine & _
                    "	AND ARH.IsDeleted=0" & vbNewLine

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@TransDate", SqlDbType.DateTime).Value = dtmTransDate
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

    End Class
End Namespace