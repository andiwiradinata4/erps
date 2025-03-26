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
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CASE WHEN MC.Warehouse='' THEN '' ELSE CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse END AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	SCH.PPN, SCH.PPH, CASE WHEN ARH.IsDP=1 THEN SCH.TotalDPP ELSE ARH.ReceiveAmount+ARH.DPAmount END AS TotalDPP, CASE WHEN ARH.IsDP=1 THEN SCH.TotalPPN ELSE (ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPN/100 END AS TotalPPN, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN SCH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPH/100 END AS TotalPPH,  " & vbNewLine &
"	GrandTotal=CASE WHEN ARH.IsDP=1 THEN SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)+((ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPN/100)-((ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPH/100) END, SCH.DelegationSeller AS DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,MBC.AccountName) AS BankAccountName1, ISNULL(MBC1.BankName,MBC.BankName) AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,MBC.AccountNumber) AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	CASE WHEN MI.ItemCodeExternal='' THEN MIS.Description ELSE MI.ItemCodeExternal END AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength, " & vbNewLine &
"	SCD.Weight, ARI.Quantity, ARI.TotalWeight AS TotalWeightItem, SCD.UnitPrice, CASE WHEN ARH.IsDP=1 THEN SCD.UnitPrice*ARI.TotalWeight ELSE ARI.Amount+ARI.DPAmount END AS TotalPrice, " & vbNewLine &
"	ARI.Amount+ARI.PPN-ARI.PPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ARH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH ELSE ARH.DPAmount+(ARH.DPAmount*SCH.PPN/100) END AS DPAmount, ARH.IsDP, ARH.ARNumber AS RefTransNumber, ARI.ReferencesDetailID " & vbNewLine &
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
"INNER JOIN mstItemType IT ON 	 	      " & vbNewLine &
"    MI.ItemTypeID=IT.ID 	 	      " & vbNewLine &
"LEFT JOIN mstCompanyBankAccount MBC ON     " & vbNewLine &
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
"	MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, MI.Thick, MI.Width, MI.Length, IT.LengthInitial, SCD.Weight, ARI.Quantity,  " & vbNewLine &
"	ARI.TotalWeight, SCD.TotalWeight, SCD.UnitPrice, ARI.Amount, ARI.DPAmount, ARH.ReceiveAmount, ARH.DPAmount, ARI.PPN, ARI.PPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, " & vbNewLine &
"   C.NPWP, ARH.ReferencesNumber, ARH.IsDP, SCH.TotalDPP, SCH.TotalPPN, SCH.TotalPPH, SCD.Quantity, SCH.TotalWeight, SCD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, MI.ItemCodeExternal, ARI.ReferencesDetailID   " & vbNewLine

                '# Klaim Biaya Potong ke Pelanggan
                .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CASE WHEN MC.Warehouse='' THEN '' ELSE CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse END AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	SCH.PPN, SCH.PPH, CASE WHEN ARH.IsDP=1 THEN SCH.TotalDPP ELSE ARH.ReceiveAmount+ARH.DPAmount END AS TotalDPP, CASE WHEN ARH.IsDP=1 THEN SCH.TotalPPN ELSE (ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPN/100 END AS TotalPPN, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN SCH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPH/100 END AS TotalPPH,  " & vbNewLine &
"	GrandTotal=CASE WHEN ARH.IsDP=1 THEN SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)+((ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPN/100)-((ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPH/100) END, MC.DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,'') AS BankAccountName1, ISNULL(MBC1.BankName,'') AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,'') AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	CASE WHEN MI.ItemCodeExternal='' THEN MIS.Description ELSE MI.ItemCodeExternal END AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength, " & vbNewLine &
"	SCD.Weight, Quantity=CASE WHEN ARH.IsDP=1 THEN SCD.Quantity ELSE ARI.Quantity END, CASE WHEN ARH.IsDP=1 THEN SCD.TotalWeight ELSE ARI.TotalWeight END AS TotalWeightItem, SCD.UnitPrice, CASE WHEN ARH.IsDP=1 THEN SCD.TotalPrice ELSE ARI.Amount+ARI.DPAmount END AS TotalPrice, " & vbNewLine &
"	ARI.Amount+ARI.PPN-ARI.PPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ARH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH ELSE ARH.DPAmount+(ARH.DPAmount*SCH.PPN/100) END AS DPAmount, ARH.IsDP, ARH.ARNumber AS RefTransNumber, ARI.ReferencesDetailID " & vbNewLine &
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
"INNER JOIN traCutting SCH ON     " & vbNewLine &
"	ARD.SalesID=SCH.ID     " & vbNewLine &
"INNER JOIN traCuttingDetResult SCD ON     " & vbNewLine &
"	SCH.ID=SCD.CuttingID     " & vbNewLine &
"INNER JOIN mstItem MI ON 	      " & vbNewLine &
"    SCD.ItemID=MI.ID 	      " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
"INNER JOIN mstItemType IT ON 	 	      " & vbNewLine &
"    MI.ItemTypeID=IT.ID 	 	      " & vbNewLine &
"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
"	ARH.ID=ARI.ParentID     " & vbNewLine &
"	AND SCD.CuttingID=ARI.ReferencesID     " & vbNewLine &
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
"	ARH.ReferencesNote, SCH.PPN, SCH.PPH, MC.DirectorName, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber,  " & vbNewLine &
"	MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, MI.Thick, MI.Width, MI.Length, IT.LengthInitial, SCD.Weight, ARI.Quantity,  " & vbNewLine &
"	ARI.TotalWeight, SCD.TotalWeight, SCD.UnitPrice, ARI.Amount, ARI.DPAmount, ARH.ReceiveAmount, ARH.DPAmount, ARI.PPN, ARI.PPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, " & vbNewLine &
"   C.NPWP, ARH.ReferencesNumber, ARH.IsDP, SCH.TotalDPP, SCH.TotalPPN, SCH.TotalPPH, SCD.Quantity, SCH.TotalWeight, SCD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, MI.ItemCodeExternal, ARI.ReferencesDetailID   " & vbNewLine

                '# Klaim Kompensasi ke Pemasok
                .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CASE WHEN MC.Warehouse='' THEN '' ELSE CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse END AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	SCH.PPN, SCH.PPH, CASE WHEN ARH.IsDP=1 THEN SCH.TotalDPP ELSE ARH.ReceiveAmount+ARH.DPAmount END AS TotalDPP, CASE WHEN ARH.IsDP=1 THEN SCH.TotalPPN ELSE (ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPN/100 END AS TotalPPN, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN SCH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPH/100 END AS TotalPPH,  " & vbNewLine &
"	GrandTotal=CASE WHEN ARH.IsDP=1 THEN SCH.TotalDPP+SCH.TotalPPN-SCH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)+((ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPN/100)-((ARH.ReceiveAmount+ARH.DPAmount)*SCH.PPH/100) END, MC.DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,'') AS BankAccountName1, ISNULL(MBC1.BankName,'') AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,'') AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	CASE WHEN MI.ItemCodeExternal='' THEN MIS.Description ELSE MI.ItemCodeExternal END AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength, " & vbNewLine &
"	SCD.Weight, Quantity=CASE WHEN ARH.IsDP=1 THEN SCD.Quantity ELSE ARI.Quantity END, CASE WHEN ARH.IsDP=1 THEN SCD.TotalWeight ELSE ARI.TotalWeight END AS TotalWeightItem, SCD.UnitPrice, CASE WHEN ARH.IsDP=1 THEN SCD.TotalPrice ELSE ARI.Amount+ARI.DPAmount END AS TotalPrice, " & vbNewLine &
"	ARI.Amount+ARI.PPN-ARI.PPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ARH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH ELSE ARH.DPAmount+(ARH.DPAmount*SCH.PPN/100) END AS DPAmount, ARH.IsDP, ARH.ARNumber AS RefTransNumber, ARI.ReferencesDetailID " & vbNewLine &
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
"INNER JOIN traConfirmationClaim SCH ON     " & vbNewLine &
"	ARD.SalesID=SCH.ID     " & vbNewLine &
"INNER JOIN traConfirmationClaimDet SCD ON     " & vbNewLine &
"	SCH.ID=SCD.ConfirmationClaimID     " & vbNewLine &
"INNER JOIN mstItem MI ON 	      " & vbNewLine &
"    SCD.ItemID=MI.ID 	      " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
"INNER JOIN mstItemType IT ON 	 	      " & vbNewLine &
"    MI.ItemTypeID=IT.ID 	 	      " & vbNewLine &
"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
"	ARH.ID=ARI.ParentID     " & vbNewLine &
"	AND SCD.ConfirmationClaimID=ARI.ReferencesID     " & vbNewLine &
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
"	ARH.ReferencesNote, SCH.PPN, SCH.PPH, MC.DirectorName, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber,  " & vbNewLine &
"	MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, MI.Thick, MI.Width, MI.Length, IT.LengthInitial, SCD.Weight, ARI.Quantity,  " & vbNewLine &
"	ARI.TotalWeight, SCD.TotalWeight, SCD.UnitPrice, ARI.Amount, ARI.DPAmount, ARH.ReceiveAmount, ARH.DPAmount, ARI.PPN, ARI.PPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, " & vbNewLine &
"   C.NPWP, ARH.ReferencesNumber, ARH.IsDP, SCH.TotalDPP, SCH.TotalPPN, SCH.TotalPPH, SCD.Quantity, SCH.TotalWeight, SCD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, MI.ItemCodeExternal, ARI.ReferencesDetailID   " & vbNewLine

                .CommandText +=
"UNION ALL " & vbNewLine &
"SELECT     " & vbNewLine &
"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CASE WHEN MC.Warehouse='' THEN '' ELSE CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse END AS CompanyAddress,     " & vbNewLine &
"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
"	ORH.PPN, ORH.PPH, CASE WHEN ARH.IsDP=1 THEN ORH.TotalDPP ELSE ARH.ReceiveAmount+ARH.DPAmount END AS TotalDPP, CASE WHEN ARH.IsDP=1 THEN ORH.TotalPPN ELSE (ARH.ReceiveAmount+ARH.DPAmount)*ORH.PPN/100 END AS TotalPPN, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN ORH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)*ORH.PPH/100 END AS TotalPPH,  " & vbNewLine &
"	GrandTotal=CASE WHEN ARH.IsDP=1 THEN ORH.TotalDPP+ORH.TotalPPN-ORH.TotalPPH ELSE (ARH.ReceiveAmount+ARH.DPAmount)+((ARH.ReceiveAmount+ARH.DPAmount)*ORH.PPN/100)-((ARH.ReceiveAmount+ARH.DPAmount)*ORH.PPH/100) END, MC.DirectorName AS DirectorName,  " & vbNewLine &
"	ISNULL(MBC1.AccountName,'') AS BankAccountName1, ISNULL(MBC1.BankName,'') AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,'') AS BankAccountNumber1,  " & vbNewLine &
"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
"	CASE WHEN MI.ItemCodeExternal='' THEN MIS.Description ELSE MI.ItemCodeExternal END AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, CASE WHEN MI.Length=0 THEN IT.LengthInitial ELSE CAST(MI.Length AS VARCHAR(100)) END AS ItemLength, " & vbNewLine &
"	ORD.Weight, ARI.Quantity, ARI.TotalWeight AS TotalWeightItem, ORD.UnitPrice, CASE WHEN ARH.IsDP=1 THEN ORD.UnitPrice*ARI.TotalWeight ELSE ARI.Amount+ARI.DPAmount END AS TotalPrice, " & vbNewLine &
"	ARI.Amount+ARI.PPN-ARI.PPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ARH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, " & vbNewLine &
"   CASE WHEN ARH.IsDP=1 THEN ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH ELSE ARH.DPAmount+(ARH.DPAmount*ORH.PPN/100) END AS DPAmount, ARH.IsDP, ARH.ARNumber AS RefTransNumber, ARI.ReferencesDetailID " & vbNewLine &
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
"INNER JOIN traOrderRequest ORH ON  " & vbNewLine &
"	ARD.SalesID=ORH.ID  " & vbNewLine &
"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine &
"	ORH.ID=ORD.OrderRequestID " & vbNewLine &
"INNER JOIN mstItem MI ON 	      " & vbNewLine &
"    ORD.ItemID=MI.ID 	      " & vbNewLine &
"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
"INNER JOIN mstItemType IT ON 	 	      " & vbNewLine &
"    MI.ItemTypeID=IT.ID 	 	      " & vbNewLine &
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
"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID,     " & vbNewLine &
"	ARH.ReferencesNote, ORH.PPN, ORH.PPH, MC.DirectorName, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber,  " & vbNewLine &
"	MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, MI.Thick, MI.Width, MI.Length, IT.LengthInitial, ORD.Weight, ARI.Quantity,  " & vbNewLine &
"	ARI.TotalWeight, ORD.TotalWeight, ORD.UnitPrice, ARI.Amount, ARI.DPAmount, ARH.ReceiveAmount, ARH.DPAmount, ARI.PPN, ARI.PPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, " & vbNewLine &
"   C.NPWP, ARH.ReferencesNumber, ARH.IsDP, ORH.TotalDPP, ORH.TotalPPN, ORH.TotalPPH, ORD.Quantity, ORH.TotalWeight, ORD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, MI.ItemCodeExternal, ARI.ReferencesDetailID" & vbNewLine


                '                .CommandText +=
                '"UNION ALL " & vbNewLine &
                '"SELECT " & vbNewLine &
                '"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress,     " & vbNewLine &
                '"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
                '"	TDH.PPN, TDH.PPH, SUM(SCD.TotalPrice) AS TotalDPP, SUM(SCD.TotalPrice)*TDH.PPN/100 AS TotalPPN, SUM(SCD.TotalPrice)*TDH.PPH/100 AS TotalPPH,  " & vbNewLine &
                '"	GrandTotal=SUM(SCD.TotalPrice)+(SUM(SCD.TotalPrice)*TDH.PPN/100)-(SUM(SCD.TotalPrice)*TDH.PPH/100), SCH.DelegationSeller AS DirectorName,  " & vbNewLine &
                '"	ISNULL(MBC1.AccountName,MBC.AccountName) AS BankAccountName1, ISNULL(MBC1.BankName,MBC.BankName) AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,MBC.AccountNumber) AS BankAccountNumber1,  " & vbNewLine &
                '"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
                '"	MIS.Description AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, MI.Length AS ItemLength, TDD.Weight, SCD.Quantity,  " & vbNewLine &
                '"	SCD.TotalWeight AS TotalWeightItem, SCD.UnitPrice, SCD.TotalPrice, ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate,  " & vbNewLine &
                '"	ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, ARH.DPAmount " & vbNewLine &
                '"FROM traAccountReceivable ARH     " & vbNewLine &
                '"INNER JOIN traAccountReceivableDet ARD ON     " & vbNewLine &
                '"	ARH.ID=ARD.ARID     " & vbNewLine &
                '"INNER JOIN mstStatus B ON     " & vbNewLine &
                '"    ARH.StatusID=B.ID     " & vbNewLine &
                '"INNER JOIN mstBusinessPartner C ON     " & vbNewLine &
                '"    ARH.BPID=C.ID     " & vbNewLine &
                '"INNER JOIN mstCompany MC ON     " & vbNewLine &
                '"    ARH.CompanyID=MC.ID     " & vbNewLine &
                '"INNER JOIN mstProgram MP ON     " & vbNewLine &
                '"    ARH.ProgramID=MP.ID     " & vbNewLine &
                '"INNER JOIN traDelivery TDH ON     " & vbNewLine &
                '"	ARD.SalesID=TDH.ID     " & vbNewLine &
                '"INNER JOIN traDeliveryDet TDD ON     " & vbNewLine &
                '"	TDH.ID=TDD.DeliveryID     " & vbNewLine &
                '"INNER JOIN traSalesContract SCH ON     " & vbNewLine &
                '"	TDH.SCID=SCH.ID     " & vbNewLine &
                '"INNER JOIN traSalesContractDet SCD ON     " & vbNewLine &
                '"	SCH.ID=SCD.SCID     " & vbNewLine &
                '"	AND SCD.ID=TDD.SCDetailID  " & vbNewLine &
                '"INNER JOIN traOrderRequestDet ORD ON  " & vbNewLine &
                '"	SCD.ORDetailID=ORD.ID  " & vbNewLine &
                '"INNER JOIN traOrderRequest ORH ON  " & vbNewLine &
                '"	ORD.OrderRequestID=ORH.ID  " & vbNewLine &
                '"INNER JOIN mstItem MI ON 	      " & vbNewLine &
                '"    SCD.ItemID=MI.ID 	      " & vbNewLine &
                '"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
                '"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
                '"INNER JOIN mstCompanyBankAccount MBC ON     " & vbNewLine &
                '"	SCH.CompanyBankAccountID=MBC.ID     " & vbNewLine &
                '"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
                '"	ARH.ID=ARI.ParentID     " & vbNewLine &
                '"	AND TDD.DeliveryID=ARI.ReferencesID     " & vbNewLine &
                '"	AND TDD.ID=ARI.ReferencesDetailID     " & vbNewLine &
                '"LEFT JOIN mstCompanyBankAccount MBC1 ON  " & vbNewLine &
                '"	ARH.CompanyBankAccountID1=MBC1.ID  " & vbNewLine &
                '"LEFT JOIN mstCompanyBankAccount MBC2 ON  " & vbNewLine &
                '"	ARH.CompanyBankAccountID2=MBC2.ID  " & vbNewLine &
                '"WHERE 	    " & vbNewLine &
                '"	ARH.ProgramID=@ProgramID     " & vbNewLine &
                '"	AND ARH.CompanyID=@CompanyID     " & vbNewLine &
                '"	AND ARH.ID=@ID 	    " & vbNewLine &
                '"GROUP BY     " & vbNewLine &
                '"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID, ARH.ReferencesNote, " & vbNewLine &
                '"	TDH.PPN, TDH.PPH, SCH.DelegationSeller, MBC1.AccountName, MBC.AccountName, MBC1.BankName, MBC.BankName, MBC1.AccountNumber, MBC.AccountNumber, MBC2.AccountName, MBC2.BankName, " & vbNewLine &
                '"   MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, MI.Thick, MI.Width, MI.Length, TDD.Weight, SCD.Quantity, SCD.TotalWeight, SCD.UnitPrice, SCD.TotalPrice, " & vbNewLine &
                '"   ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber, ARH.DPAmount " & vbNewLine

                '                .CommandText +=
                '"UNION ALL " & vbNewLine &
                '"SELECT " & vbNewLine &
                '"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress,     " & vbNewLine &
                '"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
                '"	TDH.PPN, TDH.PPH, SUM(ORD.TotalPrice) AS TotalDPP, SUM(ORD.TotalPrice)*TDH.PPN/100 AS TotalPPN, SUM(ORD.TotalPrice)*TDH.PPH/100 AS TotalPPH,  " & vbNewLine &
                '"	GrandTotal=SUM(ORD.TotalPrice)+(SUM(ORD.TotalPrice)*TDH.PPN/100)-(SUM(ORD.TotalPrice)*TDH.PPH/100), C.PICName AS DirectorName,  " & vbNewLine &
                '"	ISNULL(MBC1.AccountName,'') AS BankAccountName1, ISNULL(MBC1.BankName,'') AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,'') AS BankAccountNumber1,  " & vbNewLine &
                '"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
                '"	MIS.Description AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, MI.Length AS ItemLength, TDD.Weight, ORD.Quantity,  " & vbNewLine &
                '"	ORD.TotalWeight AS TotalWeightItem, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate,  " & vbNewLine &
                '"	ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, ARH.DPAmount " & vbNewLine &
                '"FROM traAccountReceivable ARH     " & vbNewLine &
                '"INNER JOIN traAccountReceivableDet ARD ON     " & vbNewLine &
                '"	ARH.ID=ARD.ARID     " & vbNewLine &
                '"INNER JOIN mstStatus B ON     " & vbNewLine &
                '"    ARH.StatusID=B.ID     " & vbNewLine &
                '"INNER JOIN mstBusinessPartner C ON     " & vbNewLine &
                '"    ARH.BPID=C.ID     " & vbNewLine &
                '"INNER JOIN mstCompany MC ON     " & vbNewLine &
                '"    ARH.CompanyID=MC.ID     " & vbNewLine &
                '"INNER JOIN mstProgram MP ON     " & vbNewLine &
                '"    ARH.ProgramID=MP.ID     " & vbNewLine &
                '"INNER JOIN traDelivery TDH ON     " & vbNewLine &
                '"	ARD.SalesID=TDH.ID     " & vbNewLine &
                '"INNER JOIN traDeliveryDet TDD ON     " & vbNewLine &
                '"	TDH.ID=TDD.DeliveryID     " & vbNewLine &
                '"INNER JOIN traOrderRequest ORH ON     " & vbNewLine &
                '"	TDH.SCID=ORH.ID     " & vbNewLine &
                '"INNER JOIN traOrderRequestDet ORD ON     " & vbNewLine &
                '"	ORH.ID=ORD.OrderRequestID     " & vbNewLine &
                '"	AND ORD.ID=TDD.SCDetailID  " & vbNewLine &
                '"INNER JOIN mstItem MI ON 	      " & vbNewLine &
                '"    ORD.ItemID=MI.ID 	      " & vbNewLine &
                '"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
                '"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
                '"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
                '"	ARH.ID=ARI.ParentID     " & vbNewLine &
                '"	AND TDD.DeliveryID=ARI.ReferencesID     " & vbNewLine &
                '"	AND TDD.ID=ARI.ReferencesDetailID     " & vbNewLine &
                '"LEFT JOIN mstCompanyBankAccount MBC1 ON  " & vbNewLine &
                '"	ARH.CompanyBankAccountID1=MBC1.ID  " & vbNewLine &
                '"LEFT JOIN mstCompanyBankAccount MBC2 ON  " & vbNewLine &
                '"	ARH.CompanyBankAccountID2=MBC2.ID  " & vbNewLine &
                '"WHERE 	    " & vbNewLine &
                '"	ARH.ProgramID=@ProgramID     " & vbNewLine &
                '"	AND ARH.CompanyID=@CompanyID     " & vbNewLine &
                '"	AND ARH.ID=@ID 	    " & vbNewLine &
                '"GROUP BY     " & vbNewLine &
                '"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID, ARH.ReferencesNote, " & vbNewLine &
                '"	TDH.PPN, TDH.PPH, C.PICName, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber, MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, " & vbNewLine &
                '"   MI.Thick, MI.Width, MI.Length, TDD.Weight, ORD.Quantity, ORD.TotalWeight, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber, ARH.DPAmount " & vbNewLine

                '                .CommandText +=
                '"UNION ALL " & vbNewLine &
                '"SELECT " & vbNewLine &
                '"	ARH.ID, ARH.ProgramID, MP.Name AS ProgramName, ARH.CompanyID, MC.Name AS CompanyName, MC.Address + CHAR(10) + 'WAREHOUSE: ' + MC.Warehouse AS CompanyAddress,     " & vbNewLine &
                '"	ARH.ARNumber AS TransNumber, ARH.ARDate AS TransDate, ARH.BPID, C.Code AS BPCode, C.Name AS BPName, C.Address AS BPAddress, ARH.ReferencesID, ARH.ReferencesNote,     " & vbNewLine &
                '"	ORH.PPN, ORH.PPH, SUM(ORD.TotalPrice) AS TotalDPP, SUM(ORD.TotalPrice)*ORH.PPN/100 AS TotalPPN, SUM(ORD.TotalPrice)*ORH.PPH/100 AS TotalPPH,  " & vbNewLine &
                '"	GrandTotal=SUM(ORD.TotalPrice)+(SUM(ORD.TotalPrice)*ORH.PPN/100)-(SUM(ORD.TotalPrice)*ORH.PPH/100), MC.DirectorName,  " & vbNewLine &
                '"	ISNULL(MBC1.AccountName,'') AS BankAccountName1, ISNULL(MBC1.BankName,'') AS BankAccountBankName1, ISNULL(MBC1.AccountNumber,'') AS BankAccountNumber1,  " & vbNewLine &
                '"	ISNULL(MBC2.AccountName,'') AS BankAccountName2, ISNULL(MBC2.BankName,'') AS BankAccountBankName2, ISNULL(MBC2.AccountNumber,'') AS BankAccountNumber2, ARH.StatusID,  " & vbNewLine &
                '"	MIS.Description AS ItemSpec, ARI.OrderNumberSupplier AS ItemType, MI.Thick AS ItemThick, MI.Width AS ItemWidth, MI.Length AS ItemLength, ORD.Weight, ORD.Quantity,  " & vbNewLine &
                '"	ORD.TotalWeight AS TotalWeightItem, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH AS TotalAmount, ARH.Percentage, CAST('' AS VARCHAR(1000)) AS NumericToString, ARH.Modules, ARH.CreatedDate,  " & vbNewLine &
                '"	ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber AS PurchaseNumber, CAST('' AS VARCHAR(1000)) AS ContractNumber, ARH.DPAmount " & vbNewLine &
                '"FROM traAccountReceivable ARH     " & vbNewLine &
                '"INNER JOIN traAccountReceivableDet ARD ON     " & vbNewLine &
                '"	ARH.ID=ARD.ARID     " & vbNewLine &
                '"INNER JOIN mstStatus B ON     " & vbNewLine &
                '"    ARH.StatusID=B.ID     " & vbNewLine &
                '"INNER JOIN mstBusinessPartner C ON     " & vbNewLine &
                '"    ARH.BPID=C.ID     " & vbNewLine &
                '"INNER JOIN mstCompany MC ON     " & vbNewLine &
                '"    ARH.CompanyID=MC.ID     " & vbNewLine &
                '"INNER JOIN mstProgram MP ON     " & vbNewLine &
                '"    ARH.ProgramID=MP.ID     " & vbNewLine &
                '"INNER JOIN traOrderRequest ORH ON     " & vbNewLine &
                '"	ARD.SalesID=ORH.ID     " & vbNewLine &
                '"INNER JOIN traOrderRequestDet ORD ON     " & vbNewLine &
                '"	ORH.ID=ORD.OrderRequestID     " & vbNewLine &
                '"INNER JOIN mstItem MI ON 	      " & vbNewLine &
                '"    ORD.ItemID=MI.ID 	      " & vbNewLine &
                '"INNER JOIN mstItemSpecification MIS ON 	 	      " & vbNewLine &
                '"    MI.ItemSpecificationID=MIS.ID 	 	      " & vbNewLine &
                '"INNER JOIN traARAPItem ARI ON     " & vbNewLine &
                '"	ARH.ID=ARI.ParentID     " & vbNewLine &
                '"	AND ORD.OrderRequestID=ARI.ReferencesID     " & vbNewLine &
                '"	AND ORD.ID=ARI.ReferencesDetailID     " & vbNewLine &
                '"LEFT JOIN mstCompanyBankAccount MBC1 ON  " & vbNewLine &
                '"	ARH.CompanyBankAccountID1=MBC1.ID  " & vbNewLine &
                '"LEFT JOIN mstCompanyBankAccount MBC2 ON  " & vbNewLine &
                '"	ARH.CompanyBankAccountID2=MBC2.ID  " & vbNewLine &
                '"WHERE 	    " & vbNewLine &
                '"	ARH.ProgramID=@ProgramID     " & vbNewLine &
                '"	AND ARH.CompanyID=@CompanyID     " & vbNewLine &
                '"	AND ARH.ID=@ID 	    " & vbNewLine &
                '"GROUP BY     " & vbNewLine &
                '"	ARH.ID, ARH.ProgramID, MP.Name, ARH.CompanyID, MC.Name, MC.Address, MC.Warehouse, ARH.ARNumber, ARH.ARDate, ARH.BPID, C.Code, C.Name, C.Address, ARH.ReferencesID, ARH.ReferencesNote, " & vbNewLine &
                '"	ORH.PPN, ORH.PPH, MC.DirectorName, MBC1.AccountName, MBC1.BankName, MBC1.AccountNumber, MBC2.AccountName, MBC2.BankName, MBC2.AccountNumber, ARH.StatusID, MIS.Description, ARI.OrderNumberSupplier, " & vbNewLine &
                '"	MI.Thick, MI.Width, MI.Length, ORD.Weight, ORD.Quantity, ORD.TotalWeight, ORD.UnitPrice, ORD.TotalPrice, ARH.TotalAmount, ARH.TotalPPN, ARH.TotalPPH, ARH.Percentage, ARH.Modules, ARH.CreatedDate, ARH.TaxInvoiceNumber, C.NPWP, ORH.ReferencesNumber, ARH.DPAmount" & vbNewLine

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

        Public Shared Function ListPaymentHistoryVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                       ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                       ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "	ARH.TotalAmount+ARH.TotalPPN-ARH.TotalPPH AS Amount, ARH.Modules, ARH.Percentage, ARH.ARDate, ARH.CreatedDate  " & vbNewLine &
                    "FROM traAccountReceivable ARH " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "	ARH.ProgramID=@ProgramID" & vbNewLine &
                    "	AND ARH.CompanyID=@CompanyID " & vbNewLine &
                    "	AND ARH.ID=@ID  " & vbNewLine &
                    "	AND ARH.IsDeleted=0" & vbNewLine &
                    "ORDER BY ARH.ARDate, ARH.CreatedDate "

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListPaymentDPVer02(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strParentID As String, ByVal bolIsFullDP As Boolean) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolIsFullDP Then
                    .CommandText =
"SELECT  " & vbNewLine &
"	SUM(DP.DPAmount+(DP.DPAmount*ARH.PPNPercentage/100)) AS Amount, ARH.Modules, CAST(0 AS DECIMAL(18,2)) AS Percentage, CAST(GETDATE() AS DATETIME) AS ARDate, CAST(GETDATE() AS DATETIME) AS CreatedDate  " & vbNewLine &
"FROM traARAPDP DP  " & vbNewLine &
"INNER JOIN traAccountReceivable ARH ON  " & vbNewLine &
"	DP.DPID=ARH.ID  " & vbNewLine &
"INNER JOIN traAccountReceivableDet ARD ON  " & vbNewLine &
"	ARH.ID=ARD.ARID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	DP.ParentID=@ParentID  " & vbNewLine &
"GROUP BY ARH.Modules " & vbNewLine

                Else
                    .CommandText =
"SELECT  " & vbNewLine &
"	DP.DPAmount+(DP.DPAmount*ARH.PPNPercentage/100) AS Amount, ARH.Modules, ARH.Percentage, ARH.ARDate, ARH.CreatedDate  " & vbNewLine &
"FROM traARAPDP DP  " & vbNewLine &
"INNER JOIN traAccountReceivable ARH ON  " & vbNewLine &
"	DP.DPID=ARH.ID  " & vbNewLine &
"INNER JOIN traAccountReceivableDet ARD ON  " & vbNewLine &
"	ARH.ID=ARD.ARID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	DP.ParentID=@ParentID  " & vbNewLine &
"ORDER BY ARH.ARDate, ARH.CreatedDate "

                End If
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function PrintVoucherVer01(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine &
"	MC.Name AS CompanyName, 'VOUCHER BANK IN' AS HeaderName, ARI.VoucherNumber, ARI.VoucherDate,  " & vbNewLine &
"	ARH.BPID, BP.Code AS BPCode, BP.Name AS BPName, ARI.TotalAmount, ARH.ARNumber + ' ' + ARH.ReferencesNote AS PaymentDescription,  " & vbNewLine &
"	ARIT.OrderNumberSupplier, MIT.Description AS ItemTypeName, MI.ItemName, MI.Thick, SUM(ART.TotalWeight) AS TotalWeight, CAST('' AS VARCHAR(1000)) AS ItemDescriptions,  " & vbNewLine &
"	MCR.Name AS CreatedBy, NULL AS CheckedBy, NULL AS AcknowledgedBy, MC.City, CAST('' AS VARCHAR(250)) AS LocationAndDate " & vbNewLine &
"FROM traAccountReceivable ARH  " & vbNewLine &
"INNER JOIN traARAPInvoice ARI ON  " & vbNewLine &
"	ARH.ID=ARI.ParentID  " & vbNewLine &
"INNER JOIN traARAPItem ART ON  " & vbNewLine &
"	ARH.ID=ART.ParentID " & vbNewLine &
"INNER JOIN traARAPInvoiceItem ARIT ON  " & vbNewLine &
"	ARI.ID=ARIT.ParentID  " & vbNewLine &
"	AND ART.ItemID=ARIT.ItemID  " & vbNewLine &
"INNER JOIN mstItem MI ON  " & vbNewLine &
"	ARIT.ItemID=MI.ID  " & vbNewLine &
"INNER JOIN mstCompany MC ON  " & vbNewLine &
"	ARH.CompanyID=MC.ID  " & vbNewLine &
"INNER JOIN mstBusinessPartner BP ON	 " & vbNewLine &
"	ARH.BPID=BP.ID  " & vbNewLine &
"INNER JOIN mstItemType MIT ON  " & vbNewLine &
"	MI.ItemTypeID=MIT.ID  " & vbNewLine &
"LEFT JOIN mstUser MCR ON  " & vbNewLine &
"	ARI.CreatedBy=MCR.ID  " & vbNewLine &
"WHERE ARI.ID=@ID " & vbNewLine &
"GROUP BY " & vbNewLine &
"	MC.Name, ARI.VoucherNumber, ARI.VoucherDate, ARH.BPID, BP.Code, BP.Name, ARI.TotalAmount, ARH.ARNumber, ARH.ReferencesNote,  " & vbNewLine &
"	ARIT.OrderNumberSupplier, MIT.Description, MI.ItemName, MI.Thick, MCR.Name, MC.City " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

#End Region

#Region "Down Payment"

        Public Shared Function ListDataDownPaymentReceive(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal strDPID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"SELECT  " & vbNewLine &
"	AR.ARNumber AS TransNumber, AR.ARDate AS TransDate, DP.DPAmount, " & vbNewLine &
"	AR.TaxInvoiceNumber, AR.InvoiceNumberBP, AR.Remarks, AR.CreatedBy, AR.CreatedDate, AR.LogBy, AR.LogDate  " & vbNewLine &
"FROM traARAPDP DP  " & vbNewLine &
"INNER JOIN traAccountReceivable AR ON  " & vbNewLine &
"	DP.ParentID=AR.ID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	AR.IsDeleted=0  " & vbNewLine &
"	AND DP.DPID=@DPID  " & vbNewLine &
" " & vbNewLine &
"UNION ALL  " & vbNewLine &
"SELECT  " & vbNewLine &
"	AR.APNumber AS TransNumber, AR.APDate AS TransDate, DP.DPAmount, " & vbNewLine &
"	AR.TaxInvoiceNumber, AR.InvoiceNumberBP, AR.Remarks, AR.CreatedBy, AR.CreatedDate, AR.LogBy, AR.LogDate  " & vbNewLine &
"FROM traARAPDP DP  " & vbNewLine &
"INNER JOIN traAccountPayable AR ON  " & vbNewLine &
"	DP.ParentID=AR.ID  " & vbNewLine &
"WHERE  " & vbNewLine &
"	AR.IsDeleted=0  " & vbNewLine &
"	AND DP.DPID=@DPID  " & vbNewLine &
" " & vbNewLine

                .Parameters.Add("@DPID", SqlDbType.VarChar, 100).Value = strDPID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

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

        Public Shared Function GetMaxIDInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 3),'000') AS ID " & vbNewLine &
                        "FROM traARAPInvoice " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

#End Region

#Region "Invoice"

        Public Shared Function ListDataInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "	ARI.ID, ARI.ParentID, ARI.InvoiceNumber, ARI.InvoiceDate, ARI.CoAID, ISNULL(COA.Code,'') AS CoACode, ISNULL(COA.Name,'') AS CoAName, " & vbNewLine &
                    "	ARI.PPN, ARI.PPH, ARI.TotalAmount, ARI.TotalDPP, ARI.TotalPPN, ARI.TotalPPH, ARI.TaxInvoiceNumber, ARI.InvoiceNumberExternal, " & vbNewLine &
                    "	ARI.SubmitBy, ARI.SubmitDate, ARI.ApprovedBy, ARI.ApprovedDate, ARI.IsDeleted, ARI.Remarks, ARI.CreatedBy, ARI.CreatedDate, " & vbNewLine &
                    "	ARI.LogBy, ARI.LogDate, ARI.LogInc, ARI.VoucherNumber, ARI.VoucherDate, ARI.Rounding, ARI.StatusID, StatusInfo=MS.Name" & vbNewLine &
                    "FROM traARAPInvoice ARI " & vbNewLine &
                    "INNER JOIN mstStatus MS ON " & vbNewLine &
                    "	ARI.StatusID=MS.ID " & vbNewLine &
                    "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "	ARI.CoAID=COA.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "	ARI.ParentID=@ParentID " & vbNewLine &
                    "ORDER BY ARI.InvoiceDate "

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal bolNew As Boolean, ByVal clsData As VO.ARAPInvoice)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                If bolNew Then
                    .CommandText =
                    "INSERT INTO traARAPInvoice " & vbNewLine &
                    "   (ID, ParentID, InvoiceNumber, InvoiceDate, CoAID, PPN, PPH, TotalAmount, TotalDPP, TotalPPN, TotalPPH, StatusID, ReferencesNumber, CreatedBy, Rounding) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @InvoiceNumber, @InvoiceDate, @CoAID, @PPN, @PPH, @TotalAmount, @TotalDPP, @TotalPPN, @TotalPPH, @StatusID, @ReferencesNumber, @LogBy, @Rounding) " & vbNewLine
                Else
                    .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "   ID=@ID," & vbNewLine &
                    "   ParentID=@ParentID," & vbNewLine &
                    "   InvoiceNumber=@InvoiceNumber," & vbNewLine &
                    "   InvoiceDate=@InvoiceDate," & vbNewLine &
                    "   CoAID=@CoAID," & vbNewLine &
                    "   PPN=@PPN," & vbNewLine &
                    "   PPH=@PPH," & vbNewLine &
                    "   TotalAmount=@TotalAmount," & vbNewLine &
                    "   TotalDPP=@TotalDPP," & vbNewLine &
                    "   TotalPPN=@TotalPPN," & vbNewLine &
                    "   TotalPPH=@TotalPPH," & vbNewLine &
                    "   StatusID=@StatusID," & vbNewLine &
                    "   ReferencesNumber=@ReferencesNumber, " & vbNewLine &
                    "   LogBy=@LogBy, " & vbNewLine &
                    "   LogDate=GETDATE(), " & vbNewLine &
                    "   LogInc=LogInc+1, " & vbNewLine &
                    "   Rounding=@Rounding " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine
                End If

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@InvoiceNumber", SqlDbType.VarChar, 100).Value = clsData.InvoiceNumber
                .Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = clsData.InvoiceDate
                .Parameters.Add("@CoAID", SqlDbType.Int).Value = clsData.CoAID
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
                .Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = clsData.TotalAmount
                .Parameters.Add("@TotalDPP", SqlDbType.Decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.Decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.Decimal).Value = clsData.TotalPPH
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = clsData.StatusID
                .Parameters.Add("@ReferencesNumber", SqlDbType.VarChar, 100).Value = clsData.ReferencesNumber
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = clsData.LogBy
                .Parameters.Add("@Rounding", SqlDbType.Decimal).Value = clsData.Rounding
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "   StatusID=@StatusID, " & vbNewLine &
                    "   IsDeleted=1 " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Deleted
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateInvoiceAmount(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strTable As String, ByVal strID As String,
                                              ByVal decTotalInvoiceAmount As Decimal, ByVal decTotalDPPInvoiceAmount As Decimal,
                                              ByVal decTotalPPNInvoiceAmount As Decimal, ByVal decTotalPPHInvoiceAmount As Decimal)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE " & strTable & " SET " & vbNewLine &
                    "    TotalInvoiceAmount=@TotalInvoiceAmount, " & vbNewLine &
                    "    TotalDPPInvoiceAmount=@TotalDPPInvoiceAmount, " & vbNewLine &
                    "    TotalPPNInvoiceAmount=@TotalPPNInvoiceAmount, " & vbNewLine &
                    "    TotalPPHInvoiceAmount=@TotalPPHInvoiceAmount " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@TotalInvoiceAmount", SqlDbType.Decimal).Value = decTotalInvoiceAmount
                .Parameters.Add("@TotalDPPInvoiceAmount", SqlDbType.Decimal).Value = decTotalDPPInvoiceAmount
                .Parameters.Add("@TotalPPNInvoiceAmount", SqlDbType.Decimal).Value = decTotalPPNInvoiceAmount
                .Parameters.Add("@TotalPPHInvoiceAmount", SqlDbType.Decimal).Value = decTotalPPHInvoiceAmount
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetStatusIDInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlcmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   StatusID " & vbNewLine &
                        "FROM traARAPInvoice " & vbNewLine &
                        "WHERE  " & vbNewLine &
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("StatusID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Sub SubmitInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    SubmitBy=@LogBy, " & vbNewLine &
                    "    SubmitDate=GETDATE() " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = ERPSLib.UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UnsubmitInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    SubmitBy='' " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Draft
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub ApproveInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal strID As String, ByVal dtmPaymentDate As DateTime,
                                         ByVal intCoAID As Integer)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    ApproveL1=@LogBy, " & vbNewLine &
                    "    ApproveL1Date=GETDATE(), " & vbNewLine &
                    "    ApprovedBy=@LogBy, " & vbNewLine &
                    "    ApprovedDate=GETDATE(), " & vbNewLine &
                    "    PaymentDate=@PaymentDate, " & vbNewLine &
                    "    CoAID=@CoAID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Approved
                .Parameters.Add("@LogBy", SqlDbType.VarChar, 20).Value = ERPSLib.UI.usUserApp.UserID
                .Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = dtmPaymentDate
                .Parameters.Add("@CoAID", SqlDbType.Int).Value = intCoAID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UnapproveInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    StatusID=@StatusID, " & vbNewLine &
                    "    ApproveL1='', " & vbNewLine &
                    "    ApprovedBy='' " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@StatusID", SqlDbType.Int).Value = VO.Status.Values.Submit
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetailInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strID As String) As VO.ARAPInvoice
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ARAPInvoice
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "	ARI.ID, ARI.ParentID, ARI.InvoiceNumber, ARI.InvoiceDate, ARI.CoAID, ISNULL(COA.Code,'') AS CoACode, ISNULL(COA.Name,'') AS CoAName, " & vbNewLine &
                        "	ARI.PPN, ARI.PPH, ARI.TotalAmount, ARI.TotalDPP, ARI.TotalPPN, ARI.TotalPPH, ARI.StatusID, ARI.IsDeleted, ARI.ReferencesNumber, " & vbNewLine &
                        "   ARI.TaxInvoiceNumber, ARI.InvoiceNumberExternal, ARI.SubmitBy, ARI.SubmitDate, ARI.ApproveL1, ARI.ApproveL1Date, ARI.ApprovedBy, ARI.ApprovedDate, " & vbNewLine &
                        "   ARI.JournalID, ARI.Remarks, ARI.CreatedBy, ARI.CreatedDate, ARI.LogBy, ARI.LogDate, ARI.LogInc, ARI.PaymentDate, ARI.Rounding " & vbNewLine &
                        "FROM traARAPInvoice ARI " & vbNewLine &
                        "LEFT JOIN mstChartOfAccount COA ON " & vbNewLine &
                        "	ARI.CoAID=COA.ID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "	ARI.ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ParentID = .Item("ParentID")
                        voReturn.InvoiceNumber = .Item("InvoiceNumber")
                        voReturn.InvoiceDate = .Item("InvoiceDate")
                        voReturn.CoAID = .Item("CoAID")
                        voReturn.CoACode = .Item("CoACode")
                        voReturn.CoAName = .Item("CoAName")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalAmount = .Item("TotalAmount")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.IsDeleted = .Item("IsDeleted")
                        voReturn.ReferencesNumber = .Item("ReferencesNumber")
                        voReturn.TaxInvoiceNumber = .Item("TaxInvoiceNumber")
                        voReturn.InvoiceNumberExternal = .Item("InvoiceNumberExternal")
                        voReturn.SubmitBy = .Item("SubmitBy")
                        voReturn.SubmitDate = .Item("SubmitDate")
                        voReturn.ApproveL1 = .Item("ApproveL1")
                        voReturn.ApproveL1Date = .Item("ApproveL1Date")
                        voReturn.ApprovedBy = .Item("ApprovedBy")
                        voReturn.ApprovedDate = .Item("ApprovedDate")
                        voReturn.JournalID = .Item("JournalID")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.PaymentDate = .Item("PaymentDate")
                        voReturn.Rounding = .Item("Rounding")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub UpdateJournalIDInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String, ByVal strJournalID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    JournalID=@JournalID " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@JournalID", SqlDbType.VarChar, 100).Value = strJournalID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateTaxInvoiceNumber(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                 ByVal strID As String, ByVal strTaxInvoiceNumber As String,
                                                 ByVal strRemarks As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    TaxInvoiceNumber=@TaxInvoiceNumber " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@TaxInvoiceNumber", SqlDbType.VarChar, 100).Value = strTaxInvoiceNumber
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = strRemarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateInvoiceNumberExternal(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strID As String, ByVal strInvoiceNumberExternal As String,
                                                      ByVal strRemarks As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    InvoiceNumberExternal=@InvoiceNumberExternal " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@InvoiceNumberExternal", SqlDbType.VarChar, 100).Value = strInvoiceNumberExternal
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = strRemarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateVoucherNumberInvoice(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                     ByVal strID As String, ByVal strVoucherNumber As String,
                                                     ByVal dtmVoucherDate As DateTime)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "UPDATE traARAPInvoice SET " & vbNewLine &
                    "    VoucherNumber=@VoucherNumber, " & vbNewLine &
                    "    VoucherDate=@VoucherDate " & vbNewLine &
                    "WHERE   " & vbNewLine &
                    "    ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@VoucherNumber", SqlDbType.VarChar, 100).Value = strVoucherNumber
                .Parameters.Add("@VoucherDate", SqlDbType.DateTime).Value = dtmVoucherDate
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ListDataInvoiceStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ParentID, A.Status, A.StatusBy, A.StatusDate, A.Remarks " & vbNewLine &
                    "FROM traARAPInvoiceStatus A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataInvoiceStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal clsData As VO.ARAPInvoiceStatus)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPInvoiceStatus " & vbNewLine &
                    "   (ID, ParentID, Status, StatusBy, StatusDate, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @Status, @StatusBy, GETDATE(), @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@Status", SqlDbType.VarChar, 100).Value = clsData.Status
                .Parameters.Add("@StatusBy", SqlDbType.VarChar, 20).Value = clsData.StatusBy
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxIDInvoiceStatus(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                     ByVal strParentID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ISNULL(RIGHT(ID,3),'000') AS ID " & vbNewLine &
                        "FROM traARAPInvoiceStatus " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ParentID=@ParentID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

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

        Public Shared Function ListDataInvoiceItemWithOutstanding(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                  ByVal strID As String, ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   CAST (1 AS BIT) AS Pick, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, A.ItemID, A.Amount, A.PPN, A.PPH, A.Rounding, " & vbNewLine &
                    "   B.Amount-B.TotalDPPInvoiceAmount+A.Amount AS MaxPaymentAmount, B.PPN-B.TotalPPNInvoiceAmount+A.PPN AS MaxPPNAmount, B.PPH-B.TotalPPHInvoiceAmount+A.PPH AS MaxPPHAmount, " & vbNewLine &
                    "   MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, " & vbNewLine &
                    "   MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPInvoiceItem A " & vbNewLine &
                    "INNER JOIN traARAPItem B ON " & vbNewLine &
                    "   A.ReferencesID=B.ParentID " & vbNewLine &
                    "   And A.ReferencesDetailID=B.ID " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ID " & vbNewLine &
                    "" & vbNewLine &
                    "UNION ALL " & vbNewLine &
                    "SELECT " & vbNewLine &
                    "   CAST(0 AS BIT) AS Pick, CAST('' AS VARCHAR(100)) AS ParentID, A.ParentID AS ReferencesID, A.ID AS ReferencesDetailID, A.OrderNumberSupplier, A.ItemID, A.Amount-A.TotalDPPInvoiceAmount AS Amount, A.PPN-A.TotalPPNInvoiceAmount AS PPN, A.PPH-A.TotalPPHInvoiceAmount AS PPH, CAST(0 AS DECIMAL(18,4)) AS Rounding, " & vbNewLine &
                    "   A.Amount-A.TotalDPPInvoiceAmount AS MaxPaymentAmount, A.PPN-A.TotalPPNInvoiceAmount AS MaxPPNAmount, A.PPH-A.TotalPPHInvoiceAmount AS MaxPPHAmount, " & vbNewLine &
                    "   MI.ItemCode, MI.ItemName, MI.Thick, MI.Width, MI.Length, MIS.ID AS ItemSpecificationID, MIS.Description AS ItemSpecificationName, MIT.ID AS ItemTypeID, " & vbNewLine &
                    "   MIT.Description AS ItemTypeName, A.LevelItem, A.ReferencesParentID, MI.ItemCodeExternal " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "INNER JOIN mstItem MI ON " & vbNewLine &
                    "   A.ItemID=MI.ID " & vbNewLine &
                    "INNER JOIN mstItemSpecification MIS ON " & vbNewLine &
                    "   MI.ItemSpecificationID=MIS.ID " & vbNewLine &
                    "INNER JOIN mstItemType MIT ON " & vbNewLine &
                    "   MI.ItemTypeID=MIT.ID " & vbNewLine &
                    "WHERE  " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine &
                    "   AND A.Amount-A.TotalDPPInvoiceAmount>0 " & vbNewLine

                If strID.Trim <> "" Then .CommandText += "   AND A.ID NOT IN (SELECT ReferencesDetailID FROM traARAPInvoiceItem WHERE ParentID=@ID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
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
                    "   (ID, ParentID, ReferencesID, ReferencesDetailID, OrderNumberSupplier, ItemID, Amount, PPN, PPH, DPAmount, Rounding, LevelItem, ReferencesParentID, Quantity, Weight, TotalWeight, SplitFrom, InvoiceDateBP, ReceiveDateInvoice, InvoiceNumberBP) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @ReferencesID, @ReferencesDetailID, @OrderNumberSupplier, @ItemID, @Amount, @PPN, @PPH, @DPAmount, @Rounding, @LevelItem, @ReferencesParentID, @Quantity, @Weight, @TotalWeight, @SplitFrom, @InvoiceDateBP, @ReceiveDateInvoice, @InvoiceNumberBP) " & vbNewLine

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
                .Parameters.Add("@SplitFrom", SqlDbType.VarChar, 100).Value = clsData.SplitFrom
                .Parameters.Add("@InvoiceDateBP", SqlDbType.DateTime).Value = clsData.InvoiceDateBP
                .Parameters.Add("@ReceiveDateInvoice", SqlDbType.DateTime).Value = clsData.ReceiveDateInvoice
                .Parameters.Add("@InvoiceNumberBP", SqlDbType.VarChar, 1000).Value = clsData.InvoiceNumberBP
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

        Public Shared Function ListDataOrderNumberSupplier(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                      ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.OrderNumberSupplier " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataByReferencesDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal strReferencesDetailID As String, ByVal intItemID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID AS ARAPItemID " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ReferencesDetailID=@ReferencesDetailID " & vbNewLine &
                    "   AND A.ItemID=@ItemID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataByReferencesDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal strReferencesDetailID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID AS ARAPItemID " & vbNewLine &
                    "FROM traARAPItem A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ReferencesDetailID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub ChangeItemIDItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                           ByVal strReferencesDetailID As String, ByVal intOldItemID As Integer, ByVal intNewItemID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traARAPItem SET  " & vbNewLine &
"	ItemID=@NewItemID " & vbNewLine &
"WHERE " & vbNewLine &
"	ItemID=@OldItemID " & vbNewLine &
"	AND ReferencesDetailID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@OldItemID", SqlDbType.Int).Value = intOldItemID
                .Parameters.Add("@NewItemID", SqlDbType.Int).Value = intNewItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub ChangeOrderNumberSupplierDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                          ByVal strReferencesDetailID As String, ByVal strOldOrderNumberSupplier As String,
                                                          ByVal strNewOrderNumberSupplier As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traARAPItem SET  " & vbNewLine &
"	OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"WHERE " & vbNewLine &
"	OrderNumberSupplier=@OldOrderNumberSupplier " & vbNewLine &
"	AND ReferencesDetailID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@OldOrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOldOrderNumberSupplier
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strNewOrderNumberSupplier
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub CalculateTotalInvoiceItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"UPDATE traARAPItem SET 	" & vbNewLine &
"	InvoiceQuantity=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(INV.Quantity),0) Quantity " & vbNewLine &
"		FROM traARAPInvoiceItem INV " & vbNewLine &
"		INNER JOIN traARAPInvoice ARI ON " & vbNewLine &
"		    INV.ParentID=ARI.ID " & vbNewLine &
"		    AND ARI.IsDeleted=0 " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			INV.ReferencesDetailID=@ID " & vbNewLine &
"	), " & vbNewLine &
"	InvoiceTotalWeight=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(INV.TotalWeight),0) TotalWeight " & vbNewLine &
"		FROM traARAPInvoiceItem INV " & vbNewLine &
"		INNER JOIN traARAPInvoice ARI ON " & vbNewLine &
"		    INV.ParentID=ARI.ID " & vbNewLine &
"		    AND ARI.IsDeleted=0 " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			INV.ReferencesDetailID=@ID " & vbNewLine &
"	), " & vbNewLine &
"	TotalInvoiceAmount=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(INV.Amount+INV.PPN-INV.PPH),0) TotalAmount " & vbNewLine &
"		FROM traARAPInvoiceItem INV " & vbNewLine &
"		INNER JOIN traARAPInvoice ARI ON " & vbNewLine &
"		    INV.ParentID=ARI.ID " & vbNewLine &
"		    AND ARI.IsDeleted=0 " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			INV.ReferencesDetailID=@ID " & vbNewLine &
"	), " & vbNewLine &
"	TotalDPPInvoiceAmount=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(INV.Amount),0) PPN " & vbNewLine &
"		FROM traARAPInvoiceItem INV " & vbNewLine &
"		INNER JOIN traARAPInvoice ARI ON " & vbNewLine &
"		    INV.ParentID=ARI.ID " & vbNewLine &
"		    AND ARI.IsDeleted=0 " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			INV.ReferencesDetailID=@ID " & vbNewLine &
"	), " & vbNewLine &
"	TotalPPNInvoiceAmount=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(INV.PPN),0) PPN " & vbNewLine &
"		FROM traARAPInvoiceItem INV " & vbNewLine &
"		INNER JOIN traARAPInvoice ARI ON " & vbNewLine &
"		    INV.ParentID=ARI.ID " & vbNewLine &
"		    AND ARI.IsDeleted=0 " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			INV.ReferencesDetailID=@ID " & vbNewLine &
"	), " & vbNewLine &
"	TotalPPHInvoiceAmount=	" & vbNewLine &
"	(	" & vbNewLine &
"		SELECT	" & vbNewLine &
"			ISNULL(SUM(INV.PPH),0) PPH " & vbNewLine &
"		FROM traARAPInvoiceItem INV " & vbNewLine &
"		INNER JOIN traARAPInvoice ARI ON " & vbNewLine &
"		    INV.ParentID=ARI.ID " & vbNewLine &
"		    AND ARI.IsDeleted=0 " & vbNewLine &
"		WHERE 	" & vbNewLine &
"			INV.ReferencesDetailID=@ID " & vbNewLine &
"	) " & vbNewLine &
"WHERE ID=@ID " & vbNewLine
                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetailAmountByReferencesDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                   ByVal strReferencesDetailID As String) As VO.ARAPItem
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ARAPItem
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1" & vbNewLine &
                        "	ARH.Percentage, SUM(ARI.Amount) Amount, SUM(ARI.PPN) PPN, SUM(ARI.PPH) PPH, SUM(ARI.Quantity) Quantity, ARI.Weight, SUM(ARI.TotalWeight) TotalWeight, ARH.PPNPercentage, ARH.PPHPercentage " & vbNewLine &
                        "FROM traAccountReceivable ARH " & vbNewLine &
                        "INNER JOIN traARAPItem ARI ON " & vbNewLine &
                        "	ARH.ID=ARI.ParentID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "	ARI.ReferencesDetailID=@ReferencesDetailID " & vbNewLine &
                        "	AND ARH.IsDeleted=0" & vbNewLine &
                        "GROUP BY ARH.Percentage, ARI.Weight, ARH.PPNPercentage, ARH.PPHPercentage " & vbNewLine &
                        "UNION ALL " & vbNewLine &
                        "SELECT TOP 1" & vbNewLine &
                        "	APH.Percentage, SUM(ARI.Amount) Amount, SUM(ARI.PPN) PPN, SUM(ARI.PPH) PPH, SUM(ARI.Quantity) Quantity, ARI.Weight, SUM(ARI.TotalWeight) TotalWeight, APH.PPNPercentage, APH.PPHPercentage " & vbNewLine &
                        "FROM traAccountPayable APH " & vbNewLine &
                        "INNER JOIN traARAPItem ARI ON " & vbNewLine &
                        "	APH.ID=ARI.ParentID " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "	ARI.ReferencesDetailID=@ReferencesDetailID " & vbNewLine &
                        "	AND APH.IsDeleted=0" & vbNewLine &
                        "GROUP BY APH.Percentage, ARI.Weight, APH.PPNPercentage, APH.PPHPercentage " & vbNewLine

                    .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.Percentage = .Item("Percentage")
                        voReturn.Amount = .Item("Amount")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.Quantity = .Item("Quantity")
                        voReturn.Weight = .Item("Weight")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.PPNPercentage = .Item("PPNPercentage")
                        voReturn.PPHPercentage = .Item("PPHPercentage")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub UpdateSplitItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal clsData As VO.ARAPItem)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"UPDATE traARAPItem SET 	" & vbNewLine &
"	Amount=@Amount,	" & vbNewLine &
"	PPN=@PPN,	" & vbNewLine &
"	PPH=@PPH,	" & vbNewLine &
"	Quantity=@Quantity,	" & vbNewLine &
"	Weight=@Weight,	" & vbNewLine &
"	TotalWeight=@TotalWeight	" & vbNewLine &
"WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
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

        Public Shared Function GetMaxIDARAPItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 3),'000') AS ID " & vbNewLine &
                        "FROM traARAPItem " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Function GetDetailIItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strID As String) As VO.ARAPItem
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.ARAPItem
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "	A.ID, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, A.ItemID, A.Amount, " & vbNewLine &
                        "	A.PPN, A.PPH, A.DPAmount, A.Rounding, A.LevelItem, A.ReferencesParentID, A.Quantity, A.Weight, A.TotalWeight, " & vbNewLine &
                        "   A.InvoiceQuantity, A.InvoiceWeight, A.InvoiceTotalWeight, A.TotalInvoiceAmount, A.TotalDPPInvoiceAmount, A.TotalPPNInvoiceAmount, A.TotalPPHInvoiceAmount" & vbNewLine &
                        "FROM traARAPItem A" & vbNewLine &
                        "WHERE" & vbNewLine &
                        "	ID=@ID" & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voReturn.ID = .Item("ID")
                        voReturn.ParentID = .Item("ParentID")
                        voReturn.ReferencesID = .Item("ReferencesID")
                        voReturn.ReferencesDetailID = .Item("ReferencesDetailID")
                        voReturn.OrderNumberSupplier = .Item("OrderNumberSupplier")
                        voReturn.ItemID = .Item("ItemID")
                        voReturn.Amount = .Item("Amount")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.Rounding = .Item("Rounding")
                        voReturn.LevelItem = .Item("LevelItem")
                        voReturn.ReferencesParentID = .Item("ReferencesParentID")
                        voReturn.Quantity = .Item("Quantity")
                        voReturn.Weight = .Item("Weight")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.InvoiceQuantity = .Item("InvoiceQuantity")
                        voReturn.InvoiceWeight = .Item("InvoiceWeight")
                        voReturn.InvoiceTotalWeight = .Item("InvoiceTotalWeight")
                        voReturn.TotalInvoiceAmount = .Item("TotalInvoiceAmount")
                        voReturn.TotalDPPInvoiceAmount = .Item("TotalDPPInvoiceAmount")
                        voReturn.TotalPPNInvoiceAmount = .Item("TotalPPNInvoiceAmount")
                        voReturn.TotalPPHInvoiceAmount = .Item("TotalPPHInvoiceAmount")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return voReturn
        End Function

        Public Shared Sub DeleteDataItemByID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPItem  " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Invoice Item"

        Public Shared Function ListDataDetailInvoiceItemOnly(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                             ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ParentID, A.ReferencesID, A.ReferencesDetailID, A.OrderNumberSupplier, " & vbNewLine &
                    "   A.ItemID, A.Amount, A.PPN, A.PPH, A.LevelItem, A.ReferencesParentID  " & vbNewLine &
                    "FROM traARAPInvoiceItem A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataInvoiceItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal clsData As VO.ARAPInvoiceItem)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPInvoiceItem " & vbNewLine &
                    "   (ID, ParentID, ReferencesID, ReferencesDetailID, OrderNumberSupplier, ItemID, Amount, PPN, PPH, Rounding, LevelItem, ReferencesParentID, Quantity, Weight, TotalWeight) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @ReferencesID, @ReferencesDetailID, @OrderNumberSupplier, @ItemID, @Amount, @PPN, @PPH, @Rounding, @LevelItem, @ReferencesParentID, @Quantity, @Weight, @TotalWeight) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = clsData.ReferencesID
                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = clsData.ReferencesDetailID
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = clsData.OrderNumberSupplier
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = clsData.ItemID
                .Parameters.Add("@Amount", SqlDbType.Decimal).Value = clsData.Amount
                .Parameters.Add("@PPN", SqlDbType.Decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.Decimal).Value = clsData.PPH
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

        Public Shared Sub DeleteDataInvoiceItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPInvoiceItem  " & vbNewLine &
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

        Public Shared Function ListDataInvoiceItemOrderNumberSupplier(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                      ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.OrderNumberSupplier " & vbNewLine &
                    "FROM traARAPInvoiceItem A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Function ListDataInvoiceItemByReferencesDetailID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                       ByVal strReferencesDetailID As String, ByVal intItemID As Integer) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT DISTINCT " & vbNewLine &
                    "   A.ID AS ARAPItemID " & vbNewLine &
                    "FROM traARAPInvoiceItem A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ReferencesDetailID=@ReferencesDetailID " & vbNewLine &
                    "   AND A.ItemID=@ItemID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@ItemID", SqlDbType.Int).Value = intItemID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub ChangeItemIDInvoiceItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strReferencesDetailID As String, ByVal intOldItemID As Integer, ByVal intNewItemID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traARAPInvoiceItem SET  " & vbNewLine &
"	ItemID=@NewItemID " & vbNewLine &
"WHERE " & vbNewLine &
"	ItemID=@OldItemID " & vbNewLine &
"	AND ReferencesDetailID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@OldItemID", SqlDbType.Int).Value = intOldItemID
                .Parameters.Add("@NewItemID", SqlDbType.Int).Value = intNewItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Sub ChangeInvoiceItemOrderNumberSupplierDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                                     ByVal strReferencesDetailID As String, ByVal strOldOrderNumberSupplier As String,
                                                                     ByVal strNewOrderNumberSupplier As String, ByVal intNewItemID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText =
"UPDATE traARAPInvoiceItem SET  " & vbNewLine &
"	ItemID=@ItemID, " & vbNewLine &
"	OrderNumberSupplier=@OrderNumberSupplier " & vbNewLine &
"WHERE " & vbNewLine &
"	OrderNumberSupplier=@OldOrderNumberSupplier " & vbNewLine &
"	AND ReferencesDetailID=@ReferencesDetailID " & vbNewLine

                .Parameters.Add("@ReferencesDetailID", SqlDbType.VarChar, 100).Value = strReferencesDetailID
                .Parameters.Add("@OldOrderNumberSupplier", SqlDbType.VarChar, 100).Value = strOldOrderNumberSupplier
                .Parameters.Add("@OrderNumberSupplier", SqlDbType.VarChar, 100).Value = strNewOrderNumberSupplier
                .Parameters.Add("@ItemID", SqlDbType.VarChar, 100).Value = intNewItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

#End Region

#Region "Split"

        Public Shared Function IsExistsSplit(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                             ByVal strID As String) As Boolean
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolReturn As Boolean
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 ID " & vbNewLine &
                        "FROM traARAPItemSplit " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ID=@ID " & vbNewLine

                    .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolReturn = True
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return bolReturn
        End Function

        Public Shared Sub SaveDataSplitItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"INSERT INTO traARAPItemSplit " & vbNewLine &
"       ([ID]" & vbNewLine &
"      ,[ParentID]" & vbNewLine &
"      ,[ReferencesID]" & vbNewLine &
"      ,[ReferencesDetailID]" & vbNewLine &
"      ,[OrderNumberSupplier]" & vbNewLine &
"      ,[ItemID]" & vbNewLine &
"      ,[Amount]" & vbNewLine &
"      ,[PPN]" & vbNewLine &
"      ,[PPH]" & vbNewLine &
"      ,[DPAmount]" & vbNewLine &
"      ,[Rounding]" & vbNewLine &
"      ,[LevelItem]" & vbNewLine &
"      ,[ReferencesParentID]" & vbNewLine &
"      ,[Quantity]" & vbNewLine &
"      ,[Weight]" & vbNewLine &
"      ,[TotalWeight]" & vbNewLine &
"      ,[InvoiceQuantity]" & vbNewLine &
"      ,[InvoiceWeight]" & vbNewLine &
"      ,[InvoiceTotalWeight]" & vbNewLine &
"      ,[TotalInvoiceAmount]" & vbNewLine &
"      ,[TotalDPPInvoiceAmount]" & vbNewLine &
"      ,[TotalPPNInvoiceAmount]" & vbNewLine &
"      ,[TotalPPHInvoiceAmount])" & vbNewLine &
"SELECT [ID]" & vbNewLine &
"      ,[ParentID]" & vbNewLine &
"      ,[ReferencesID]" & vbNewLine &
"      ,[ReferencesDetailID]" & vbNewLine &
"      ,[OrderNumberSupplier]" & vbNewLine &
"      ,[ItemID]" & vbNewLine &
"      ,[Amount]" & vbNewLine &
"      ,[PPN]" & vbNewLine &
"      ,[PPH]" & vbNewLine &
"      ,[DPAmount]" & vbNewLine &
"      ,[Rounding]" & vbNewLine &
"      ,[LevelItem]" & vbNewLine &
"      ,[ReferencesParentID]" & vbNewLine &
"      ,[Quantity]" & vbNewLine &
"      ,[Weight]" & vbNewLine &
"      ,[TotalWeight]" & vbNewLine &
"      ,[InvoiceQuantity]" & vbNewLine &
"      ,[InvoiceWeight]" & vbNewLine &
"      ,[InvoiceTotalWeight]" & vbNewLine &
"      ,[TotalInvoiceAmount]" & vbNewLine &
"      ,[TotalDPPInvoiceAmount]" & vbNewLine &
"      ,[TotalPPNInvoiceAmount]" & vbNewLine &
"      ,[TotalPPHInvoiceAmount]" & vbNewLine &
"FROM [dbo].[traARAPItem]" & vbNewLine &
"WHERE ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataSplitItemFrom(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                  ByVal strSplitFrom As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DELETE traARAPItem " & vbNewLine &
"WHERE " & vbNewLine &
"   SplitFrom=@SplitFrom " & vbNewLine

                .Parameters.Add("@SplitFrom", SqlDbType.VarChar, 100).Value = strSplitFrom
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub RevertDataSplitItem(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                              ByVal strID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"INSERT INTO traARAPItem " & vbNewLine &
"       ([ID]" & vbNewLine &
"      ,[ParentID]" & vbNewLine &
"      ,[ReferencesID]" & vbNewLine &
"      ,[ReferencesDetailID]" & vbNewLine &
"      ,[OrderNumberSupplier]" & vbNewLine &
"      ,[ItemID]" & vbNewLine &
"      ,[Amount]" & vbNewLine &
"      ,[PPN]" & vbNewLine &
"      ,[PPH]" & vbNewLine &
"      ,[DPAmount]" & vbNewLine &
"      ,[Rounding]" & vbNewLine &
"      ,[LevelItem]" & vbNewLine &
"      ,[ReferencesParentID]" & vbNewLine &
"      ,[Quantity]" & vbNewLine &
"      ,[Weight]" & vbNewLine &
"      ,[TotalWeight]" & vbNewLine &
"      ,[InvoiceQuantity]" & vbNewLine &
"      ,[InvoiceWeight]" & vbNewLine &
"      ,[InvoiceTotalWeight]" & vbNewLine &
"      ,[TotalInvoiceAmount]" & vbNewLine &
"      ,[TotalDPPInvoiceAmount]" & vbNewLine &
"      ,[TotalPPNInvoiceAmount]" & vbNewLine &
"      ,[TotalPPHInvoiceAmount])" & vbNewLine &
"SELECT [ID]" & vbNewLine &
"      ,[ParentID]" & vbNewLine &
"      ,[ReferencesID]" & vbNewLine &
"      ,[ReferencesDetailID]" & vbNewLine &
"      ,[OrderNumberSupplier]" & vbNewLine &
"      ,[ItemID]" & vbNewLine &
"      ,[Amount]" & vbNewLine &
"      ,[PPN]" & vbNewLine &
"      ,[PPH]" & vbNewLine &
"      ,[DPAmount]" & vbNewLine &
"      ,[Rounding]" & vbNewLine &
"      ,[LevelItem]" & vbNewLine &
"      ,[ReferencesParentID]" & vbNewLine &
"      ,[Quantity]" & vbNewLine &
"      ,[Weight]" & vbNewLine &
"      ,[TotalWeight]" & vbNewLine &
"      ,[InvoiceQuantity]" & vbNewLine &
"      ,[InvoiceWeight]" & vbNewLine &
"      ,[InvoiceTotalWeight]" & vbNewLine &
"      ,[TotalInvoiceAmount]" & vbNewLine &
"      ,[TotalDPPInvoiceAmount]" & vbNewLine &
"      ,[TotalPPNInvoiceAmount]" & vbNewLine &
"      ,[TotalPPHInvoiceAmount]" & vbNewLine &
"FROM [dbo].[traARAPItemSplit]" & vbNewLine &
"WHERE " & vbNewLine &
"   ID=@ID " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = strID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataSplitItemByReferencesID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                            ByVal strReferencesID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
"DELETE traARAPItemSplit " & vbNewLine &
"WHERE " & vbNewLine &
"   ReferencesID=@ReferencesID " & vbNewLine

                .Parameters.Add("@ReferencesID", SqlDbType.VarChar, 100).Value = strReferencesID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "Remarks"

        Public Shared Function ListDataRemarks(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal strParentID As String) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ID, A.ParentID, A.Remarks " & vbNewLine &
                    "FROM traARAPRemarks A " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "   A.ParentID=@ParentID " & vbNewLine

                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = strParentID
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataRemarks(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal clsData As VO.ARAPRemarks)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPRemarks " & vbNewLine &
                    "   (ID, ParentID, Remarks) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @ParentID, @Remarks) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataRemarks(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPRemarks " & vbNewLine &
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

#Region "Voucher"

        Public Shared Function ListDataVoucher(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                               ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                               ByVal enumVoucherType As VO.VoucherType.Values) As DataTable
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "SELECT " & vbNewLine &
                    "   A.ProgramID, A.CompanyID, A.ID, A.VoucherNumber, A.TransDate, A.VoucherType, B.Name AS VoucherTypeName, A.ParentID, " & vbNewLine &
                    "   A.InvoiceNumber, A.CoAID, COA.Code AS CoACode, COA.Name AS CoAName, A.TotalAmount, A.Remarks, " & vbNewLine &
                    "   A.CreatedBy, A.CreatedDate " & vbNewLine &
                    "FROM traARAPVoucher A " & vbNewLine &
                    "INNER JOIN mstVoucherType B ON " & vbNewLine &
                    "    A.VoucherType=B.ID " & vbNewLine &
                    "INNER JOIN mstChartOfAccount COA ON " & vbNewLine &
                    "    A.CoAID=COA.ID " & vbNewLine &
                    "WHERE " & vbNewLine &
                    "	A.ProgramID=@ProgramID " & vbNewLine &
                    "	AND A.CompanyID=@CompanyID " & vbNewLine &
                    "	AND A.TransDate>=@DateFrom AND A.TransDate<=@DateTo " & vbNewLine

                If enumVoucherType <> VO.VoucherType.Values.All Then .CommandText += "	AND A.VoucherType=@VoucherType " & vbNewLine

                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom.Date
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
                .Parameters.Add("@VoucherType", SqlDbType.Int).Value = enumVoucherType
            End With
            Return SQL.QueryDataTable(sqlCmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveDataVoucher(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                          ByVal clsData As VO.ARAPVoucher)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "INSERT INTO traARAPVoucher " & vbNewLine &
                    "   (ID, TransDate, VoucherType, ParentID, InvoiceNumber, CoAID, TotalAmount, Remarks, CreatedBy, CreatedDate, VoucherNumber, ProgramID, CompanyID) " & vbNewLine &
                    "VALUES " & vbNewLine &
                    "   (@ID, @TransDate, @VoucherType, @ParentID, @InvoiceNumber, @CoAID, @TotalAmount, @Remarks, @CreatedBy, GETDATE(), @VoucherNumber, @ProgramID, @CompanyID) " & vbNewLine

                .Parameters.Add("@ID", SqlDbType.VarChar, 100).Value = clsData.ID
                .Parameters.Add("@TransDate", SqlDbType.DateTime).Value = clsData.TransDate
                .Parameters.Add("@VoucherType", SqlDbType.Int).Value = clsData.VoucherType
                .Parameters.Add("@ParentID", SqlDbType.VarChar, 100).Value = clsData.ParentID
                .Parameters.Add("@InvoiceNumber", SqlDbType.VarChar, 100).Value = clsData.InvoiceNumber
                .Parameters.Add("@CoAID", SqlDbType.Int).Value = clsData.CoAID
                .Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = clsData.TotalAmount
                .Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = clsData.Remarks
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = clsData.CreatedBy
                .Parameters.Add("@VoucherNumber", SqlDbType.VarChar, 100).Value = clsData.VoucherNumber
                .Parameters.Add("@ProgramID", SqlDbType.Int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.Int).Value = clsData.CompanyID
            End With
            Try
                SQL.ExecuteNonQuery(sqlCmdExecute, sqlTrans)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDataVoucher(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                            ByVal strParentID As String)
            Dim sqlCmdExecute As New SqlCommand
            With sqlCmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandType = CommandType.Text
                .CommandText =
                    "DELETE traARAPVoucher " & vbNewLine &
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

        Public Shared Function GetMaxIDVoucher(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                               ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                               ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(ID, 4),'0000') AS ID " & vbNewLine &
                        "FROM traARAPVoucher " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ProgramID=@ProgramID " & vbNewLine &
                        "   AND CompanyID=@CompanyID " & vbNewLine &
                        "   AND LEFT(ID,@Length)=@ID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

        Public Shared Function GetMaxVoucherNumber(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                                   ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                                   ByVal strNewID As String) As Integer
            Dim sqlCmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim intReturn As Integer = 0
            Try
                With sqlCmdExecute
                    .Connection = sqlCon
                    .Transaction = sqlTrans
                    .CommandType = CommandType.Text
                    .CommandText =
                        "SELECT TOP 1 " & vbNewLine &
                        "   ISNULL(RIGHT(VoucherNumber, 4),'0000') AS ID " & vbNewLine &
                        "FROM traARAPVoucher " & vbNewLine &
                        "WHERE " & vbNewLine &
                        "   ProgramID=@ProgramID " & vbNewLine &
                        "   AND CompanyID=@CompanyID " & vbNewLine &
                        "   AND LEFT(VoucherNumber,@Length)=@ID " & vbNewLine &
                        "ORDER BY ID DESC " & vbNewLine

                    .Parameters.Add("@ProgramID", SqlDbType.Int).Value = intProgramID
                    .Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID
                    .Parameters.Add("@ID", SqlDbType.VarChar, strNewID.Length).Value = strNewID
                    .Parameters.Add("@Length", SqlDbType.Int).Value = strNewID.Length
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlCmdExecute)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intReturn = .Item("ID")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                If Not sqlrdData Is Nothing Then sqlrdData.Close()
            End Try
            Return intReturn
        End Function

#End Region

    End Class
End Namespace