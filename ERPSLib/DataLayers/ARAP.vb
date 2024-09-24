Namespace DL
    Public Class ARAP

#Region "Main"

        Public Shared Function PrintVer00(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                  ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                  ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress, ARH.ARNumber AS TransNumber, " & vbNewLine &
                    "   ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote, SCH.PPN, SCH.PPH, SCH.TotalDPP, " & vbNewLine &
                    "	SCH.TotalPPN, SCH.TotalPPH, GrandTotal=SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH+SCH.RoundingManual, MC.DirectorName AS CompanyDirectorName, " & vbNewLine &
                    "	MBC.AccountName, MBC.BankName, MBC.AccountNumber, ARH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, " & vbNewLine &
                    "	MI.Length AS ItemLength, MI.Weight, SCD.Quantity, SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, ARH.TotalAmount, ARH.Percentage,  " & vbNewLine &
                    "   CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate " & vbNewLine &
                    "FROM traAccountReceivable ARH " & vbNewLine &
                    "INNER JOIN traAccountReceivableDet ARD ON " & vbNewLine &
                    "	ARH.ID=ARD.ARID " & vbNewLine &
                    "INNER JOIN mstStatus B ON " & vbNewLine &
                    "    ARH.StatusID=B.ID " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON " & vbNewLine &
                    "    ARH.BPID=C.ID " & vbNewLine &
                    "INNER JOIN mstCompany MC ON " & vbNewLine &
                    "    ARH.CompanyID=MC.ID " & vbNewLine &
                    "INNER JOIN mstProgram MP ON " & vbNewLine &
                    "    ARH.ProgramID=MP.ID " & vbNewLine &
                    "INNER JOIN traSalesContract SCH ON " & vbNewLine &
                    "	ARD.SalesID=SCH.ID " & vbNewLine &
                    "INNER JOIN traSalesContractDet SCD ON " & vbNewLine &
                    "	SCH.ID=SCD.SCID " & vbNewLine &
                    "INNER JOIN mstItem MI ON 	  " & vbNewLine &
                    "    SCD.ItemID=MI.ID 	  " & vbNewLine &
                    "INNER JOIN mstItemType IT ON 	 	  " & vbNewLine &
                    "    MI.ItemTypeID=IT.ID 	 	  " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON 	 	  " & vbNewLine &
                    "    MI.ItemSpecificationID=MIS.ID 	 	  " & vbNewLine &
                    "INNER JOIN mstCompanyBankAccount MBC ON " & vbNewLine &
                    "	SCH.CompanyBankAccountID=MBC.ID" & vbNewLine &
                    "WHERE 	" & vbNewLine &
                    "	ARH.ProgramID=@ProgramID " & vbNewLine &
                    "	AND ARH.CompanyID=@CompanyID " & vbNewLine &
                    "	AND ARH.ID=@ID 	" & vbNewLine

                .CommandText +=
                    "UNION ALL  " & vbNewLine &
                    "SELECT  " & vbNewLine &
                    "	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress, ARH.ARNumber AS TransNumber,  " & vbNewLine &
                    "	ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote, SCH.PPN, SCH.PPH, SCH.TotalDPP,  " & vbNewLine &
                    "	SCH.TotalPPN, SCH.TotalPPH, GrandTotal=SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH+SCH.RoundingManual, MC.DirectorName AS CompanyDirectorName,  " & vbNewLine &
                    "	MBC.AccountName, MBC.BankName, MBC.AccountNumber, ARH.StatusID, MIS.Description AS ItemSpec, IT.Description AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth,  " & vbNewLine &
                    "	MI.Length AS ItemLength, MI.Weight, SCD.Quantity, SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, ARH.TotalAmount, ARH.Percentage,   " & vbNewLine &
                    "   CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate  " & vbNewLine &
                    "FROM traAccountReceivable ARH  " & vbNewLine &
                    "INNER JOIN traAccountReceivableDet ARD ON  " & vbNewLine &
                    "	ARH.ID=ARD.ARID  " & vbNewLine &
                    "INNER JOIN mstStatus B ON  " & vbNewLine &
                    "    ARH.StatusID=B.ID  " & vbNewLine &
                    "INNER JOIN mstBusinessPartner C ON  " & vbNewLine &
                    "    ARH.BPID=C.ID  " & vbNewLine &
                    "INNER JOIN mstCompany MC ON  " & vbNewLine &
                    "    ARH.CompanyID=MC.ID  " & vbNewLine &
                    "INNER JOIN mstProgram MP ON  " & vbNewLine &
                    "    ARH.ProgramID=MP.ID  " & vbNewLine &
                    "INNER JOIN traDelivery TDH ON  " & vbNewLine &
                    "	ARD.SalesID=TDH.ID  " & vbNewLine &
                    "INNER JOIN traSalesContract SCH ON  " & vbNewLine &
                    "	TDH.SCID=SCH.ID  " & vbNewLine &
                    "INNER JOIN traSalesContractDet SCD ON  " & vbNewLine &
                    "	SCH.ID=SCD.SCID  " & vbNewLine &
                    "INNER JOIN mstItem MI ON 	   " & vbNewLine &
                    "    SCD.ItemID=MI.ID 	   " & vbNewLine &
                    "INNER JOIN mstItemType IT ON 	 	   " & vbNewLine &
                    "    MI.ItemTypeID=IT.ID 	 	   " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON 	 	   " & vbNewLine &
                    "    MI.ItemSpecificationID=MIS.ID 	 	   " & vbNewLine &
                    "INNER JOIN mstCompanyBankAccount MBC ON  " & vbNewLine &
                    "	SCH.CompanyBankAccountID=MBC.ID " & vbNewLine &
                    "WHERE 	 " & vbNewLine &
                    "	ARH.ProgramID=@ProgramID  " & vbNewLine &
                    "	AND ARH.CompanyID=@CompanyID  " & vbNewLine &
                    "	AND ARH.ID=@ID 	 " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function PrintVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                          ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	SCH.PPN, SCH.PPH, CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount ELSE ARH.ReceiveAmount+ARH.DPAmount END AS TotalDPP, (CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount ELSE ARH.ReceiveAmount+ARH.DPAmount END)*SCH.PPN/100 AS TotalPPN, " & vbNewLine &
"   (CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount ELSE ARH.ReceiveAmount+ARH.DPAmount END)*SCH.PPH/100 AS TotalPPH,  " & vbNewLine &
"	GrandTotal=(CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount ELSE ARH.ReceiveAmount+ARH.DPAmount END)+((CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount ELSE ARH.ReceiveAmount+ARH.DPAmount END)*SCH.PPN/100)-((CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount ELSE ARH.ReceiveAmount+ARH.DPAmount END)*SCH.PPH/100), SCH.DelegationSeller AS DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,MBC.AccountName) AS BankAccountName1, ISNULL(MBC1.BankName,MBC.BankName) AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,MBC.AccountNumber) AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	MIS.Description AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, MI.Length AS ItemLength, SCD.Weight, Quantity=CASE WHEN ARH.IsDP=1 THEN SCD.Quantity ELSE ARI.Quantity END,  " & vbNewLine &
"	CASE WHEN ARH.IsDP=1 THEN SCH.TotalWeight ELSE ARI.TotalWeight END AS TotalWeightItem, SCD.UnitPrice, ARI.Amount+ARI.DPAmount AS TotalPrice, ARI.Amount+ARI.PPN-ARI.PPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate,  " & vbNewLine &
"	ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, ARH.DPAmount+(ARH.DPAmount*SCH.PPN/100) AS DPAmount  " & vbNewLine &
"FROM traAccountReceivable ARH     " & vbNewLine &
"INNER JOIN traAccountReceivableDet ARD ON     " & vbNewLine &
"	ARH.ID=ARD.ARID     " & vbNewLine &
"INNER JOIN mstStatus B ON     " & vbNewLine &
"    ARH.StatusID=B.ID     " & vbNewLine &
"INNER JOIN mstBusinessPartner C ON     " & vbNewLine &
"    ARH.BPID=C.ID     " & vbNewLine &
"INNER JOIN mstCompany MC ON     " & vbNewLine &
"    ARH.CompanyID=MC.ID     " & vbNewLine &
"INNER JOIN mstProgram MP ON     " & vbNewLine &
"    ARH.ProgramID=MP.ID     " & vbNewLine &
"INNER JOIN traSalesContract SCH ON     " & vbNewLine &
"	ARD.SalesID=SCH.ID     " & vbNewLine &
"INNER JOIN traSalesContractDet SCD ON     " & vbNewLine &
"	SCH.ID=SCD.SCID     " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine &
"	SCD.ORDetailID=ORD.ID  " & vbNewLine &
"INNER JOIN traOrderRequest ORH ON  " & vbNewLine &
"	ORD.OrderRequestID=ORH.ID  " & vbNewLine &
"INNER JOIN mstItem MI ON 	      " & vbNewLine &
"    SCD.ItemID=MI.ID 	      " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
"INNER JOIN mstCompanyBankAccount MBC ON     " & vbNewLine &
"	SCH.CompanyBankAccountID=MBC.ID     " & vbNewLine &
"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
"	ARH.ID=ARI.ParentID     " & vbNewLine &
"	AND SCD.SCID=ARI.ReferencesID     " & vbNewLine &
"	AND SCD.ID=ARI.ReferencesDetailID     " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC1 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID1=MBC1.ID  " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC2 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID2=MBC2.ID  " & vbNewLine &
"WHERE 	    " & vbNewLine &
"	ARH.ProgramID=@ProgramID     " & vbNewLine &
"	AND ARH.CompanyID=@CompanyID     " & vbNewLine &
"	AND ARH.ID=@ID 	    " & vbNewLine &
"GROUP BY     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID,     " & vbNewLine &
"	ARH.ReferencesNote, SCH.PPN, SCH.PPH, SCH.DelegationSeller, MBC.AccountName, MBC.BankName, MBC.AccountNumber, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber,  " & vbNewLine &
"	MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, MI.Thick, MI.Width, MI.Length, SCD.Weight, ARI.Quantity,  " & vbNewLine &
"	ARI.TotalWeight, SCD.UnitPrice, ARI.Amount, ARI.DPAmount, ARH.ReceiveAmount, ARH.DPAmount, ARI.PPN, ARI.PPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, " & vbNewLine &
"   C.NPWP, ORH.ReferencesNumber, ARH.IsDP, ARH.TotalAmount, SCD.Quantity, SCH.TotalWeight   " & vbNewLine

                .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	TDH.PPN, TDH.PPH, SUM(SCD.TotalPrice) AS TotalDPP, SUM(SCD.TotalPrice)*TDH.PPN/100 AS TotalPPN, SUM(SCD.TotalPrice)*TDH.PPH/100 AS TotalPPH,  " & vbNewLine &
"	GrandTotal=SUM(SCD.TotalPrice)+(SUM(SCD.TotalPrice)*TDH.PPN/100)-(SUM(SCD.TotalPrice)*TDH.PPH/100), SCH.DelegationSeller AS DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,MBC.AccountName) AS BankAccountName1, ISNULL(MBC1.BankName,MBC.BankName) AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,MBC.AccountNumber) AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	MIS.Description AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, MI.Length AS ItemLength, TDD.Weight, SCD.Quantity,  " & vbNewLine &
"	SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate,  " & vbNewLine &
"	ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, ARH.DPAmount " & vbNewLine &
"FROM traAccountReceivable ARH     " & vbNewLine &
"INNER JOIN traAccountReceivableDet ARD ON     " & vbNewLine &
"	ARH.ID=ARD.ARID     " & vbNewLine &
"INNER JOIN mstStatus B ON     " & vbNewLine &
"    ARH.StatusID=B.ID     " & vbNewLine &
"INNER JOIN mstBusinessPartner C ON     " & vbNewLine &
"    ARH.BPID=C.ID     " & vbNewLine &
"INNER JOIN mstCompany MC ON     " & vbNewLine &
"    ARH.CompanyID=MC.ID     " & vbNewLine &
"INNER JOIN mstProgram MP ON     " & vbNewLine &
"    ARH.ProgramID=MP.ID     " & vbNewLine &
"INNER JOIN traDelivery TDH ON     " & vbNewLine &
"	ARD.SalesID=TDH.ID     " & vbNewLine &
"INNER JOIN traDeliveryDet TDD ON     " & vbNewLine &
"	TDH.ID=TDD.DeliveryID     " & vbNewLine &
"INNER JOIN traSalesContract SCH ON     " & vbNewLine &
"	TDH.SCID=SCH.ID     " & vbNewLine &
"INNER JOIN traSalesContractDet SCD ON     " & vbNewLine &
"	SCH.ID=SCD.SCID     " & vbNewLine &
"	AND SCD.ID=TDD.SCDetailID  " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine &
"	SCD.ORDetailID=ORD.ID  " & vbNewLine &
"INNER JOIN traOrderRequest ORH ON  " & vbNewLine &
"	ORD.OrderRequestID=ORH.ID  " & vbNewLine &
"INNER JOIN mstItem MI ON 	      " & vbNewLine &
"    SCD.ItemID=MI.ID 	      " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
"INNER JOIN mstCompanyBankAccount MBC ON     " & vbNewLine &
"	SCH.CompanyBankAccountID=MBC.ID     " & vbNewLine &
"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
"	ARH.ID=ARI.ParentID     " & vbNewLine &
"	AND TDD.DeliveryID=ARI.ReferencesID     " & vbNewLine &
"	AND TDD.ID=ARI.ReferencesDetailID     " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC1 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID1=MBC1.ID  " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC2 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID2=MBC2.ID  " & vbNewLine &
"WHERE 	    " & vbNewLine &
"	ARH.ProgramID=@ProgramID     " & vbNewLine &
"	AND ARH.CompanyID=@CompanyID     " & vbNewLine &
"	AND ARH.ID=@ID 	    " & vbNewLine &
"GROUP BY     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID, ARH.ReferencesNote, " & vbNewLine &
"	TDH.PPN, TDH.PPH, SCH.DelegationSeller, MBC1.AccountName, MBC.AccountName, MBC1.BankName, MBC.BankName, MBC1.AccountNumber, MBC.AccountNumber, MBC2.AccountName, MBC2.BankName, " & vbNewLine &
"   MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, MI.Thick, MI.Width, MI.Length, TDD.Weight, SCD.Quantity, SCD.TotalWeight, SCD.UnitPrice, SCD.TotalPrice, " & vbNewLine &
"   ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber, ARH.DPAmount " & vbNewLine

                .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	TDH.PPN, TDH.PPH, SUM(ORD.TotalPrice) AS TotalDPP, SUM(ORD.TotalPrice)*TDH.PPN/100 AS TotalPPN, SUM(ORD.TotalPrice)*TDH.PPH/100 AS TotalPPH,  " & vbNewLine &
"	GrandTotal=SUM(ORD.TotalPrice)+(SUM(ORD.TotalPrice)*TDH.PPN/100)-(SUM(ORD.TotalPrice)*TDH.PPH/100), C.PICName AS DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,'') AS BankAccountName1, ISNULL(MBC1.BankName,'') AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,'') AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	MIS.Description AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, MI.Length AS ItemLength, TDD.Weight, ORD.Quantity,  " & vbNewLine &
"	ORD.TotalWeight AS TotalWeightItem, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate,  " & vbNewLine &
"	ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, ARH.DPAmount " & vbNewLine &
"FROM traAccountReceivable ARH     " & vbNewLine &
"INNER JOIN traAccountReceivableDet ARD ON     " & vbNewLine &
"	ARH.ID=ARD.ARID     " & vbNewLine &
"INNER JOIN mstStatus B ON     " & vbNewLine &
"    ARH.StatusID=B.ID     " & vbNewLine &
"INNER JOIN mstBusinessPartner C ON     " & vbNewLine &
"    ARH.BPID=C.ID     " & vbNewLine &
"INNER JOIN mstCompany MC ON     " & vbNewLine &
"    ARH.CompanyID=MC.ID     " & vbNewLine &
"INNER JOIN mstProgram MP ON     " & vbNewLine &
"    ARH.ProgramID=MP.ID     " & vbNewLine &
"INNER JOIN traDelivery TDH ON     " & vbNewLine &
"	ARD.SalesID=TDH.ID     " & vbNewLine &
"INNER JOIN traDeliveryDet TDD ON     " & vbNewLine &
"	TDH.ID=TDD.DeliveryID     " & vbNewLine &
"INNER JOIN traOrderRequest ORH ON     " & vbNewLine &
"	TDH.SCID=ORH.ID     " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON     " & vbNewLine &
"	ORH.ID=ORD.OrderRequestID     " & vbNewLine &
"	AND ORD.ID=TDD.SCDetailID  " & vbNewLine &
"INNER JOIN mstItem MI ON 	      " & vbNewLine &
"    ORD.ItemID=MI.ID 	      " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
"	ARH.ID=ARI.ParentID     " & vbNewLine &
"	AND TDD.DeliveryID=ARI.ReferencesID     " & vbNewLine &
"	AND TDD.ID=ARI.ReferencesDetailID     " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC1 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID1=MBC1.ID  " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC2 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID2=MBC2.ID  " & vbNewLine &
"WHERE 	    " & vbNewLine &
"	ARH.ProgramID=@ProgramID     " & vbNewLine &
"	AND ARH.CompanyID=@CompanyID     " & vbNewLine &
"	AND ARH.ID=@ID 	    " & vbNewLine &
"GROUP BY     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID, ARH.ReferencesNote, " & vbNewLine &
"	TDH.PPN, TDH.PPH, C.PICName, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber, MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, " & vbNewLine &
"   MI.Thick, MI.Width, MI.Length, TDD.Weight, ORD.Quantity, ORD.TotalWeight, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber, ARH.DPAmount " & vbNewLine

                .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	ORH.PPN, ORH.PPH, SUM(ORD.TotalPrice) AS TotalDPP, SUM(ORD.TotalPrice)*ORH.PPN/100 AS TotalPPN, SUM(ORD.TotalPrice)*ORH.PPH/100 AS TotalPPH,  " & vbNewLine &
"	GrandTotal=SUM(ORD.TotalPrice)+(SUM(ORD.TotalPrice)*ORH.PPN/100)-(SUM(ORD.TotalPrice)*ORH.PPH/100), MC.DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,'') AS BankAccountName1, ISNULL(MBC1.BankName,'') AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,'') AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	MIS.Description AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, MI.Length AS ItemLength, ORD.Weight, ORD.Quantity,  " & vbNewLine &
"	ORD.TotalWeight AS TotalWeightItem, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate,  " & vbNewLine &
"	ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, ARH.DPAmount " & vbNewLine &
"FROM traAccountReceivable ARH     " & vbNewLine &
"INNER JOIN traAccountReceivableDet ARD ON     " & vbNewLine &
"	ARH.ID=ARD.ARID     " & vbNewLine &
"INNER JOIN mstStatus B ON     " & vbNewLine &
"    ARH.StatusID=B.ID     " & vbNewLine &
"INNER JOIN mstBusinessPartner C ON     " & vbNewLine &
"    ARH.BPID=C.ID     " & vbNewLine &
"INNER JOIN mstCompany MC ON     " & vbNewLine &
"    ARH.CompanyID=MC.ID     " & vbNewLine &
"INNER JOIN mstProgram MP ON     " & vbNewLine &
"    ARH.ProgramID=MP.ID     " & vbNewLine &
"INNER JOIN traOrderRequest ORH ON     " & vbNewLine &
"	ARD.SalesID=ORH.ID     " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON     " & vbNewLine &
"	ORH.ID=ORD.OrderRequestID     " & vbNewLine &
"INNER JOIN mstItem MI ON 	      " & vbNewLine &
"    ORD.ItemID=MI.ID 	      " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
"	ARH.ID=ARI.ParentID     " & vbNewLine &
"	AND ORD.OrderRequestID=ARI.ReferencesID     " & vbNewLine &
"	AND ORD.ID=ARI.ReferencesDetailID     " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC1 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID1=MBC1.ID  " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC2 ON  " & vbNewLine &
"	ARH.CompanyBankAccountID2=MBC2.ID  " & vbNewLine &
"WHERE 	    " & vbNewLine &
"	ARH.ProgramID=@ProgramID     " & vbNewLine &
"	AND ARH.CompanyID=@CompanyID     " & vbNewLine &
"	AND ARH.ID=@ID 	    " & vbNewLine &
"GROUP BY     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID, ARH.ReferencesNote, " & vbNewLine &
"	ORH.PPN, ORH.PPH, MC.DirectorName, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber, MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, " & vbNewLine &
"	MI.Thick, MI.Width, MI.Length, ORD.Weight, ORD.Quantity, ORD.TotalWeight, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber, ARH.DPAmount" & vbNewLine

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
                .CommandText =
                    "SELECT " & vbNewLine &
                    "	ARD.Amount+ARD.PPN-ARD.PPH AS Amount, ARH.Modules, ARH.Percentage, ARH.ARDate, ARH.CreatedDate  " & vbNewLine &
                    "FROM traAccountReceivable ARH " & vbNewLine &
                    "INNER JOIN traAccountReceivableDet ARD ON " & vbNewLine &
                    "	ARH.ID=ARD.ARID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "	ARD.SalesID=@ReferencesID " & vbNewLine &
                    "	AND ARH.ProgramID=@ProgramID" & vbNewLine &
                    "	AND ARH.CompanyID=@CompanyID " & vbNewLine &
                    "	AND ARH.ID<>@ID  " & vbNewLine &
                    "	AND ARH.IsDP=1 " & vbNewLine &
                    "	AND ARH.IsDeleted=0" & vbNewLine &
                    "ORDER BY ARH.ARDate, ARH.CreatedDate "

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@TransDate", SqlDbType.DateTime).Value = dtmTransDate
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Down Payment"

        Public Shared Sub SaveDataDP(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                     ByVal clsData As VO.ARAPDP)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPDP " & vbNewLine &
                    "   (ID, ParentID, DPID, DPAmount) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @DPID, @DPAmount) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@DPID", SqlDbType.VarChar, 100).Value = clsData.DPID
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataDP(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPDP  " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalAmountUsed(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal strID As String, ByVal enumDPType As VO.ARAP.ARAPTypeValue)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If enumDPType = VO.ARAP.ARAPTypeValue.Purchase Then
                    .CommandText =
                        "UPDATE traAccountPayable SET 	" & vbNewLine &
                        "	TotalAmountUsed=	" & vbNewLine &
                        "	(	" & vbNewLine &
                        "		SELECT	" & vbNewLine &
                        "			ISNULL(SUM(DP.DPAmount),0) DPAmount " & vbNewLine &
                        "		FROM traARAPDP DP " & vbNewLine &
                        "		WHERE 	" & vbNewLine &
                        "			DP.DPID=@ID " & vbNewLine &
                        "	) " & vbNewLine &
                        "WHERE ID=@ID " & vbNewLine
                ElseIf enumDPType = VO.ARAP.ARAPTypeValue.Sales Then
                    .CommandText =
                        "UPDATE traAccountReceivable SET 	" & vbNewLine &
                        "	TotalAmountUsed=	" & vbNewLine &
                        "	(	" & vbNewLine &
                        "		SELECT	" & vbNewLine &
                        "			ISNULL(SUM(DP.DPAmount),0) DPAmount " & vbNewLine &
                        "		FROM traARAPDP DP " & vbNewLine &
                        "		WHERE 	" & vbNewLine &
                        "			DP.DPID=@ID " & vbNewLine &
                        "	) " & vbNewLine &
                        "WHERE ID=@ID " & vbNewLine
                End If
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Item"

        Public Shared Function ListDataDetailItemOnly(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strAPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Amount, A.PPN, A.PPH, A.LevelItem, A.ReferencesParentID  " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@APID " & vbNewLine

                .Parameters.Add("@APID", SqlDbType.VarChar, 100).Value = strAPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal clsData As VO.ARAPItem)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPItem " & vbNewLine &
                    "   (ID, ParentID, ReferencesID, ReferencesDetailID, OrderNumberSupplier, ItemID, Amount, PPN, PPH, DPAmount, Rounding, LevelItem, ReferencesParentID, Quantity, Weight, TotalWeight) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @ReferencesID, @ReferencesDetailID, @OrderNumberSupplier, @ItemID, @Amount, @PPN, @PPH, @DPAmount, @Rounding, @LevelItem, @ReferencesParentID, @Quantity, @Weight, @TotalWeight) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = clsData.ReferencesID
                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = clsData.ReferencesDetailID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@DPAmount", SqlDbType.Decimal).Value = clsData.DPAmount
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
                .Parameters.Add("@LevelItem", SqlDbType.Int).Value = clsData.LevelItem
                .Parameters.Add("@ReferencesParentID", SqlDbType.VarChar, 100).Value = clsData.ReferencesParentID
                .Parameters.Add("@Quantity", SqlDbType.Decimal).Value = clsData.Quantity
                .Parameters.Add("@Weight", SqlDbType.Decimal).Value = clsData.Weight
                .Parameters.Add("@TotalWeight", SqlDbType.Decimal).Value = clsData.TotalWeight
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                       ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPItem  " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

    End Class
End Namespace