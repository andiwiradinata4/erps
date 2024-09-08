Namespace BL
    Public Class Migration

        Public Shared Sub Migrate()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                CreateTableMigration(sqlCon, Nothing)
                AddColumnPCIDInTableConfirmationOrderAddJournalIDAndTotalPayemntInTableReceive_ID1(sqlCon, Nothing)
                AddColumnIsAutoGenerateInTablePurchaseContract_ID2(sqlCon, Nothing)
                DevelopARAPForUsingDownPayment_ID3(sqlCon, Nothing)
                CreateTableARAPDP_ID4(sqlCon, Nothing)
                AlterTableCuttingAndDelivery_ID5(sqlCon, Nothing)
                AlterTableReceive_ID6(sqlCon, Nothing)
                AlterTableCutting_ID7(sqlCon, Nothing)
                CreateTableDeliveryTransport_ID8(sqlCon, Nothing)
                AlterTableSysJournalPost_ID9(sqlCon, Nothing)
                AlterTableSysJournalPost_ID10(sqlCon, Nothing)
                AlterTableForHandleCoAofStock_ID11(sqlCon, Nothing)
                AlterTableForHandleCoAofStock_ID12(sqlCon, Nothing)
                CreateTableBPLocation_ID13(sqlCon, Nothing)
                DevelopARAPForItem_ID14(sqlCon, Nothing)
                DevelopOnProgress_ID15(sqlCon, Nothing)
                DevelopOnProgress_ID16(sqlCon, Nothing)
                DevelopOnProgress_ID17(sqlCon, Nothing)
                DevelopOnProgress_ID18(sqlCon, Nothing)
                DevelopOnProgress_ID19(sqlCon, Nothing)
                DevelopOnProgress_ID20(sqlCon, Nothing)
                DevelopOnProgress_ID21(sqlCon, Nothing)
                DevelopOnProgress_ID22(sqlCon, Nothing)
                DevelopOnProgress_ID23(sqlCon, Nothing)
                DevelopOnProgress_ID24(sqlCon, Nothing)
                CreateTableAppVersion_ID25(sqlCon, Nothing)
                DevelopOnProgress_ID26(sqlCon, Nothing)
                DevelopOnProgress_ID27(sqlCon, Nothing)
                DevelopOnProgress_ID28(sqlCon, Nothing)
                DevelopOnProgress_ID29(sqlCon, Nothing)
                DevelopOnProgress_ID30(sqlCon, Nothing)
                DevelopOnProgress_ID31(sqlCon, Nothing)
            End Using
        End Sub

        '# ID = 0
        Private Shared Sub CreateTableMigration(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.Name = "Create Table sysMigration"
            clsData.Scripts =
"CREATE TABLE [dbo].[sysMigration](" & vbNewLine &
"	[ID] [bigint] NOT NULL CONSTRAINT [DF_sysMigration_ID]  DEFAULT ((0))," & vbNewLine &
"	[Name] [varchar](max) NOT NULL CONSTRAINT [DF_sysMigration_Name]  DEFAULT ('')," & vbNewLine &
"	[Scripts] [varchar](max) NOT NULL CONSTRAINT [DF_sysMigration_Scripts]  DEFAULT ('')," & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_sysMigration_CreatedBy]  DEFAULT ('SYSTEM')," & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_sysMigration_CreatedDate]  DEFAULT (GETDATE())," & vbNewLine &
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_sysMigration_LogBy]  DEFAULT ('SYSTEM')," & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_sysMigration_LogDate]  DEFAULT (GETDATE())," & vbNewLine &
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_sysMigration_LogInc]  DEFAULT ((0))," & vbNewLine &
"   CONSTRAINT [PK_sysMigration] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsTableExists(sqlCon, sqlTrans, "sysMigration") Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
            End If
        End Sub

        '# ID = 1
        Private Shared Sub AddColumnPCIDInTableConfirmationOrderAddJournalIDAndTotalPayemntInTableReceive_ID1(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 1
            clsData.Name = "Add Column PCID In Table Confirmation Order, Add JournalID And TotalPayemnt In Table Receive"
            clsData.Scripts =
                "ALTER TABLE traConfirmationOrder ADD PCID VARCHAR(100) NOT NULL CONSTRAINT DF_traConfirmationOrder_PCID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traReceive ADD JournalID VARCHAR(100) NOT NULL CONSTRAINT DF_traReceive_JournalID DEFAULT ('') " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 2
        Private Shared Sub AddColumnIsAutoGenerateInTablePurchaseContract_ID2(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 2
            clsData.Name = "Add Column IsAutoGenerate In Table Purchase Contract"
            clsData.Scripts =
                "ALTER TABLE traPurchaseContract ADD IsAutoGenerate BIT NOT NULL CONSTRAINT DF_traPurchaseContract_IsAutoGenerate DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceive ADD TotalPayment DECIMAL(18,2) NOT NULL CONSTRAINT DF_traReceive_TotalPayment DEFAULT ((0)) " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 3
        Private Shared Sub DevelopARAPForUsingDownPayment_ID3(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 3
            clsData.Name = "Develop ARAP for using Down Payment"
            clsData.Scripts =
                "ALTER TABLE traReceive ADD DPAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traReceive_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD IsDP BIT NOT NULL CONSTRAINT DF_traAccountPayable_IsDP DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD DPAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountPayable_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD ReceiveAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountPayable_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD TotalAmountUsed DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountPayable_TotalAmountUsed DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayableDet ADD DPAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountPayableDet_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayableDet ADD Rounding DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountPayableDet_Rounding DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD DPAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traDelivery_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD TotalPayment DECIMAL(18,2) NOT NULL CONSTRAINT DF_traDelivery_TotalPayment DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD IsDP DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_IsDP DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD DPAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD ReceiveAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD TotalAmountUsed DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_TotalAmountUsed DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivableDet ADD DPAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountReceivableDet_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivableDet ADD Rounding DECIMAL(18,2) NOT NULL CONSTRAINT DF_traAccountReceivableDet_Rounding DEFAULT ((0)) " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 4
        Private Shared Sub CreateTableARAPDP_ID4(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 4
            clsData.Name = "Create Table traARAPDP"
            clsData.Scripts =
"CREATE TABLE [dbo].[traARAPDP](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDP_ID]  DEFAULT ('')," & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDP_ParentID]  DEFAULT ('')," & vbNewLine &
"	[DPID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDP_DPID]  DEFAULT ('')," & vbNewLine &
"	[DPAmount] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPDP_DPAmount]  DEFAULT ((0))," & vbNewLine &
"   CONSTRAINT [PK_traARAPDP] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
"" & vbNewLine &
"CREATE TABLE [dbo].[traARAPDPDet](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDPDet_ID]  DEFAULT ('')," & vbNewLine &
"	[ParentDetID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDPDet_ParentDetID]  DEFAULT ('')," & vbNewLine &
"	[DPID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDPDet_DPID]  DEFAULT ('')," & vbNewLine &
"	[DPAmount] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPDPDet_DPAmount]  DEFAULT ((0))," & vbNewLine &
"   CONSTRAINT [PK_traARAPDPDet] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 5
        Private Shared Sub AlterTableCuttingAndDelivery_ID5(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 5
            clsData.Name = "Alter Table Cutting"
            clsData.Scripts =
                "ALTER TABLE traCutting ADD PPN DECIMAL(18,2) NOT NULL CONSTRAINT DF_traCutting_PPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD PPH DECIMAL(18,2) NOT NULL CONSTRAINT DF_traCutting_PPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD TotalDPP DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCutting_TotalDPP DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD TotalPPN DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCutting_TotalPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD TotalPPH DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCutting_TotalPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD RoundingManual DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCutting_RoundingManual DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD DPAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCutting_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD TotalPayment DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCutting_TotalPayment DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD JournalID VARCHAR(100) NOT NULL CONSTRAINT DF_traCutting_JournalID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD UnitPrice DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_UnitPrice DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD TotalPrice DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_TotalPrice DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD RoundingManualTransport DECIMAL(18,4) NOT NULL CONSTRAINT DF_traDelivery_RoundingManualTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD DPAmountTransport DECIMAL(18,4) NOT NULL CONSTRAINT DF_traDelivery_DPAmountTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD TotalPaymentTransport DECIMAL(18,4) NOT NULL CONSTRAINT DF_traDelivery_TotalPaymentTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD JournalID VARCHAR(100) NOT NULL CONSTRAINT DF_traDelivery_JournalID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traDelivery ADD JournalIDTransport VARCHAR(100) NOT NULL CONSTRAINT DF_traDelivery_JournalIDTransport DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 6
        Private Shared Sub AlterTableReceive_ID6(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 6
            clsData.Name = "Alter Table Receive"
            clsData.Scripts =
                "ALTER TABLE traReceive ADD PCID VARCHAR(100) NOT NULL CONSTRAINT DF_traReceive_PCID DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 7
        Private Shared Sub AlterTableCutting_ID7(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 7
            clsData.Name = "Alter Table Cutting"
            clsData.Scripts =
                "ALTER TABLE traCutting ADD POID VARCHAR(100) NOT NULL CONSTRAINT DF_traCutting_POID DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 8
        Private Shared Sub CreateTableDeliveryTransport_ID8(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 8
            clsData.Name = "Create Table Delivery Transport"
            clsData.Scripts =
"CREATE TABLE [dbo].[traDeliveryTransport](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traDeliveryTransport_ID]  DEFAULT (''), " & vbNewLine & _
"	[DeliveryID] [varchar](100) NOT NULL CONSTRAINT [DF_traDeliveryTransport_DeliveryID]  DEFAULT (''), " & vbNewLine & _
"	[DeliveryNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traDeliveryTransport_DeliveryNumber]  DEFAULT (''), " & vbNewLine & _
"	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traDeliveryTransport_POID]  DEFAULT (''), " & vbNewLine & _
"	[BPID] [int] NOT NULL CONSTRAINT [DF_traDeliveryTransport_BPID]  DEFAULT ((0)), " & vbNewLine & _
"	[PPN] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traDeliveryTransport_PPN]  DEFAULT ((0)), " & vbNewLine & _
"	[PPH] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traDeliveryTransport_PPH]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traDeliveryTransport_TotalQuantity]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traDeliveryTransport_TotalWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traDeliveryTransport_TotalDPP]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traDeliveryTransport_TotalPPN]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traDeliveryTransport_TotalPPH]  DEFAULT ((0)), " & vbNewLine & _
"	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traDeliveryTransport_RoundingManual]  DEFAULT ((0)), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traDeliveryTransport_Remarks]  DEFAULT (''), " & vbNewLine & _
"	[DPAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traDeliveryTransport_DPAmount]  DEFAULT (''), " & vbNewLine & _
"	[TotalPayment] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traDeliveryTransport_TotalPayment]  DEFAULT (''), " & vbNewLine & _
"	[JournalID] [varchar](100) NOT NULL CONSTRAINT [DF_traDeliveryTransport_JournalID]  DEFAULT (''), " & vbNewLine & _
"   CONSTRAINT [PK_traDeliveryTransport] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
"" & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 9
        Private Shared Sub AlterTableSysJournalPost_ID9(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 9
            clsData.Name = "Alter Table SysJournal Post"
            clsData.Scripts =
                "ALTER TABLE sysJournalPost ADD CoAOfPPHSales INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAOfPPHSales DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAOfPPHPurchase INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAOfPPHPurchase DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofPrepaidIncomeCutting INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofPrepaidIncomeCutting DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofPrepaidIncomeTransport INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofPrepaidIncomeTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofStockCutting INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofStockCutting DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofStockCutting2 INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofStockCutting2 DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofStockCutting3 INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofStockCutting3 DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofStockTransport INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofStockTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountPayableCutting INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountPayableCutting DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountPayableCutting2 INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountPayableCutting2 DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountPayableCutting3 INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountPayableCutting3 DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountPayableTransport INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountPayableTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountReceivableOutstandingPayment INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountReceivableOutstandingPayment DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountPayableOutstandingPayment INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountPayableOutstandingPayment DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountPayableCuttingOutstandingPayment INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountPayableCuttingOutstandingPayment DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofAccountPayableTransportOutstandingPayment INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofAccountPayableTransportOutstandingPayment DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traJournalDet ADD GroupID INT NOT NULL CONSTRAINT DF_traJournalDet_GroupID DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traJournalDet ADD BPID INT NOT NULL CONSTRAINT DF_traJournalDet_BPID DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traBukuBesar ADD BPID INT NOT NULL CONSTRAINT DF_traBukuBesar_BPID DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traJournal ADD ReferencesNo VARCHAR(100) NOT NULL CONSTRAINT DF_traJournal_ReferencesNo DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traReceive ADD CoAofStock INT NOT NULL CONSTRAINT DF_traReceive_CoAofStock DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD JournalIDInvoice VARCHAR(100) NOT NULL CONSTRAINT DF_traAccountReceivable_JournalIDInvoice DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD JournalIDInvoice VARCHAR(100) NOT NULL CONSTRAINT DF_traAccountPayable_JournalIDInvoice DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 10
        Private Shared Sub AlterTableSysJournalPost_ID10(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 10
            clsData.Name = "Alter Table sysJournalPost"
            clsData.Scripts =
            "ALTER TABLE sysJournalPost ADD CoAOfCutting INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAOfCutting DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE sysJournalPost ADD CoAOfTransport INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAOfTransport DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 11
        Private Shared Sub AlterTableForHandleCoAofStock_ID11(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 11
            clsData.Name = "Alter Table For Handle CoA of Stock"
            clsData.Scripts =
                "ALTER TABLE traCutting ADD CoAIDofStock INT NOT NULL CONSTRAINT DF_traCutting_CoAIDofStock DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE mstBusinessPartner ADD CoAIDofStock INT NOT NULL CONSTRAINT DF_mstBusinessPartner_CoAIDofStock DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAOfCostRawMaterial INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAOfCostRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD TotalCostRawMaterial DECIMAL(18,4) NOT NULL CONSTRAINT DF_traDelivery_TotalCostRawMaterial DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 12
        Private Shared Sub AlterTableForHandleCoAofStock_ID12(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 12
            clsData.Name = "Alter Table For Handle CoA of Stock Rev 1"
            clsData.Scripts =
                "ALTER TABLE traPurchaseOrderCutting ADD TotalDPPRawMaterial DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_TotalDPPRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD UnitPriceRawMaterial DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_UnitPriceRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD TotalPriceRawMaterial DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_TotalPriceRawMaterial DEFAULT ((0)) " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 13
        Private Shared Sub CreateTableBPLocation_ID13(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 13
            clsData.Name = "Create Table BP Location"
            clsData.Scripts =
"CREATE TABLE [dbo].[mstBusinessPartnerLocation](" & vbNewLine &
"	[ID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_ID]  DEFAULT ((0)), " & vbNewLine &
"	[BPID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_BPID]  DEFAULT ((0)), " & vbNewLine &
"	[Address] [varchar](2000) NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_Address]  DEFAULT (''), " & vbNewLine &
"	[IsDefault] [bit] NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_IsDefault]  DEFAULT ((0)), " & vbNewLine &
"	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_StatusID]  DEFAULT ((0)), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_Remarks]  DEFAULT (''), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_CreatedBy]  DEFAULT (''), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_CreatedDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_LogBy]  DEFAULT (''), " & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_LogDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerLocation_LogInc]  DEFAULT ((0)), " & vbNewLine &
"   CONSTRAINT [PK_mstBusinessPartnerLocation] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
"" & vbNewLine &
"ALTER TABLE traSalesContract ADD BPLocationID int NOT NULL CONSTRAINT DF_traSalesContract_BPLocationID DEFAULT ((0)) " & vbNewLine &
"" & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 14
        Private Shared Sub DevelopARAPForItem_ID14(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 14
            clsData.Name = "Develop ARAP for Item"
            clsData.Scripts =
"ALTER TABLE traPurchaseContractDet ADD DPAmount decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_DPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traReceiveDet ADD DPAmount decimal(18,4) NOT NULL CONSTRAINT DF_traReceiveDet_DPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traReceiveDet ADD ReceiveAmount decimal(18,4) NOT NULL CONSTRAINT DF_traReceiveDet_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD DPAmount decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_DPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ReceiveAmount decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traCuttingDet ADD DPAmount decimal(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_DPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traCuttingDet ADD ReceiveAmount decimal(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traSalesContractDet ADD DPAmount decimal(18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_DPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDelivery ADD TransporterID int NOT NULL CONSTRAINT DF_traDelivery_TransporterID DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDelivery ADD PPNTransport decimal(18,4) NOT NULL CONSTRAINT DF_traDelivery_PPNTransport DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDelivery ADD PPHTransport decimal(18,4) NOT NULL CONSTRAINT DF_traDelivery_PPHTransport DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDelivery ADD IsFreePPNTransport bit NOT NULL CONSTRAINT DF_traDelivery_IsFreePPNTransport DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDelivery ADD IsFreePPHTransport bit NOT NULL CONSTRAINT DF_traDelivery_IsFreePPHTransport DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDeliveryDet ADD UnitPriceTransport decimal(18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_UnitPriceTransport DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDeliveryDet ADD DPAmount decimal(18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_DPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDeliveryDet ADD ReceiveAmount decimal(18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traAccountPayable ADD CompanyBankAccountID1 int NOT NULL CONSTRAINT DF_traAccountPayable_CompanyBankAccountID1 DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traAccountPayable ADD CompanyBankAccountID2 int NOT NULL CONSTRAINT DF_traAccountPayable_CompanyBankAccountID2 DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traAccountPayable ADD OtherExpenses decimal(18,4) NOT NULL CONSTRAINT DF_traAccountPayable_OtherExpenses DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traAccountPayable ADD InvoiceNumberBP varchar(1000) NOT NULL CONSTRAINT DF_traAccountPayable_InvoiceNumberBP DEFAULT ('') " & vbNewLine &
"ALTER TABLE traAccountReceivable ADD CompanyBankAccountID1 int NOT NULL CONSTRAINT DF_traAccountReceivable_CompanyBankAccountID1 DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traAccountReceivable ADD CompanyBankAccountID2 int NOT NULL CONSTRAINT DF_traAccountReceivable_CompanyBankAccountID2 DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traAccountReceivable ADD OtherExpenses decimal(18,4) NOT NULL CONSTRAINT DF_traAccountReceivable_OtherExpenses DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traAccountReceivable ADD InvoiceNumberBP varchar(1000) NOT NULL CONSTRAINT DF_traAccountReceivable_InvoiceNumberBP DEFAULT ('') " & vbNewLine &
"CREATE TABLE [dbo].[traARAPItem](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItem_ID]  DEFAULT (''), " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItem_ParentID]  DEFAULT (''), " & vbNewLine &
"	[ReferencesID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItem_ReferencesID]  DEFAULT (''), " & vbNewLine &
"	[ReferencesDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItem_ReferencesDetailID]  DEFAULT (''), " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItem_OrderNumberSupplier]  DEFAULT (''), " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traARAPItem_BPID]  DEFAULT ((0)), " & vbNewLine &
"	[Amount] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPItem_Amount]  DEFAULT ((0)), " & vbNewLine &
"	[PPN] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPItem_PPN]  DEFAULT ((0)), " & vbNewLine &
"	[PPH] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPItem_PPH]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmount] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPItem_DPAmount]  DEFAULT ((0)), " & vbNewLine &
"	[Rounding] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPItem_Rounding]  DEFAULT ((0)), " & vbNewLine &
"   CONSTRAINT [PK_traARAPItem] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 15
        Private Shared Sub DevelopOnProgress_ID15(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 15
            clsData.Name = "Develop On Progress 15"
            clsData.Scripts =
"ALTER TABLE traReceiveDet ADD OrderNumberSupplier varchar(100) NOT NULL CONSTRAINT DF_traReceiveDet_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
"ALTER TABLE traReceiveDet ADD OutQuantity decimal(18,4) NOT NULL CONSTRAINT DF_traReceiveDet_OutQuantity DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traReceiveDet ADD OutWeight decimal(18,4) NOT NULL CONSTRAINT DF_traReceiveDet_OutWeight DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traSalesContractDet ADD OrderNumberSupplier varchar(100) NOT NULL CONSTRAINT DF_traSalesContractDet_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
"ALTER TABLE traDeliveryDet ADD OrderNumberSupplier varchar(100) NOT NULL CONSTRAINT DF_traDeliveryDet_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD OrderNumberSupplier varchar(100) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
"ALTER TABLE traCuttingDet ADD OrderNumberSupplier varchar(100) NOT NULL CONSTRAINT DF_traCuttingDet_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
"ALTER TABLE traCuttingDet ADD OutQuantity decimal(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_OutQuantity DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traCuttingDet ADD OutWeight decimal(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_OutWeight DEFAULT ((0)) " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 16
        Private Shared Sub DevelopOnProgress_ID16(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 16
            clsData.Name = "Develop On Progress 16"
            clsData.Scripts =
"ALTER TABLE traConfirmationOrder ADD IsUseSubItem bit NOT NULL CONSTRAINT DF_traConfirmationOrder_IsUseSubItem DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseContract ADD IsUseSubItem bit NOT NULL CONSTRAINT DF_traPurchaseContract_IsUseSubItem DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traSalesContract ADD IsUseSubItem bit NOT NULL CONSTRAINT DF_traSalesContract_IsUseSubItem DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traSalesContractDet ADD IsIgnoreValidationPayment bit NOT NULL CONSTRAINT DF_traSalesContractDet_IsIgnoreValidationPayment DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD GroupID int NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_GroupID DEFAULT ((0)) " & vbNewLine &
"CREATE TABLE [dbo].[traPurchaseOrderCuttingDetResult](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDetResult_ID]  DEFAULT (''), " & vbNewLine &
"	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDetResult_POID]  DEFAULT (''), " & vbNewLine &
"	[GroupID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDetResult_GroupID]  DEFAULT ((0)), " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDetResult_BPID]  DEFAULT ((0)), " & vbNewLine &
"	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDetResult_Quantity]  DEFAULT ((0)), " & vbNewLine &
"	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDetResult_Weight]  DEFAULT ((0)), " & vbNewLine &
"	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDetResult_TotalWeight]  DEFAULT ((0)), " & vbNewLine &
"   CONSTRAINT [PK_traPurchaseOrderCuttingDetResult] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
"CREATE TABLE [dbo].[traStockIn](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traStockIn_ID]  DEFAULT (''), " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traStockIn_ParentID]  DEFAULT (''), " & vbNewLine &
"	[ParentDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traStockIn_ParentDetailID]  DEFAULT (''), " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traStockIn_OrderNumberSupplier]  DEFAULT (''), " & vbNewLine &
"	[SourceData] [varchar](100) NOT NULL CONSTRAINT [DF_traStockIn_SourceData]  DEFAULT (''), " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traStockIn_ItemID]  DEFAULT ((0)), " & vbNewLine &
"	[InQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockIn_InQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[InWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockIn_InWeight]  DEFAULT ((0)), " & vbNewLine &
"	[InTotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockIn_InTotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[OutQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockIn_OutQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[OutWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockIn_OutWeight]  DEFAULT ((0)), " & vbNewLine &
"	[OutTotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockIn_OutTotalWeight]  DEFAULT ((0)), " & vbNewLine &
"   CONSTRAINT [PK_traStockIn] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
"CREATE TABLE [dbo].[traStockOut](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traStockOut_ID]  DEFAULT (''), " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traStockOut_ParentID]  DEFAULT (''), " & vbNewLine &
"	[ParentDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traStockOut_ParentDetailID]  DEFAULT (''), " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traStockOut_OrderNumberSupplier]  DEFAULT (''), " & vbNewLine &
"	[SourceData] [varchar](100) NOT NULL CONSTRAINT [DF_traStockOut_SourceData]  DEFAULT (''), " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traStockOut_ItemID]  DEFAULT ((0)), " & vbNewLine &
"	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockOut_Quantity]  DEFAULT ((0)), " & vbNewLine &
"	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockOut_Weight]  DEFAULT ((0)), " & vbNewLine &
"	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traStockOut_TotalWeight]  DEFAULT ((0)), " & vbNewLine &
"   CONSTRAINT [PK_traStockOut] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine


            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 17
        Private Shared Sub DevelopOnProgress_ID17(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 17
            clsData.Name = "Develop On Progress 17"
            clsData.Scripts =
"ALTER TABLE mstCompany ADD NPWP varchar(100) NOT NULL CONSTRAINT DF_mstCompany_NPWP DEFAULT ('') " & vbNewLine &
"ALTER TABLE mstBusinessPartner ADD NPWP varchar(100) NOT NULL CONSTRAINT DF_mstBusinessPartner_NPWP DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 18
        Private Shared Sub DevelopOnProgress_ID18(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 18
            clsData.Name = "Develop On Progress 18"
            clsData.Scripts = _
"ALTER TABLE traDelivery ADD UnitPriceTransport decimal(18,4) NOT NULL CONSTRAINT DF_traDelivery_UnitPriceTransport DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE mstBusinessPartner ADD PPN decimal(18,4) NOT NULL CONSTRAINT DF_mstBusinessPartner_PPN DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE mstBusinessPartner ADD IsFreePPN bit NOT NULL CONSTRAINT DF_mstBusinessPartner_IsFreePPN DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE mstBusinessPartner ADD PPH decimal(18,4) NOT NULL CONSTRAINT DF_mstBusinessPartner_PPH DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE mstBusinessPartner ADD IsFreePPH bit NOT NULL CONSTRAINT DF_mstBusinessPartner_IsFreePPH DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 19
        Private Shared Sub DevelopOnProgress_ID19(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 19
            clsData.Name = "Develop On Progress 19"
            clsData.Scripts =
"ALTER TABLE traPurchaseOrderCuttingDetResult ADD DoneQuantity decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_DoneQuantity DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDetResult ADD DoneWeight decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_DoneWeight DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDetResult ADD OrderNumberSupplier varchar(100) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDetResult ADD Remarks varchar(250) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_Remarks DEFAULT ('') " & vbNewLine &
"ALTER TABLE traCuttingDetResult ADD PODetailResultID varchar(100) NOT NULL CONSTRAINT DF_traCuttingDetResult_PODetailResultID DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 20
        Private Shared Sub DevelopOnProgress_ID20(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 20
            clsData.Name = "Develop On Progress 20"
            clsData.Scripts =
                "ALTER TABLE traCuttingDetResult ADD OrderNumberSupplier varchar(100) NOT NULL CONSTRAINT DF_traCuttingDetResult_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD TotalPriceTransport decimal(18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_TotalPriceTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD DPAmountTransport decimal(18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_DPAmountTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD ReceiveAmountTransport decimal(18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReceiveAmountTransport DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 21
        Private Shared Sub DevelopOnProgress_ID21(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 21
            clsData.Name = "Develop On Progress 21"
            clsData.Scripts =
                "ALTER TABLE traConfirmationOrderDet ADD LevelItem int NOT NULL CONSTRAINT DF_traConfirmationOrderDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traConfirmationOrderDet ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traConfirmationOrderDet_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD LevelItem int NOT NULL CONSTRAINT DF_traPurchaseContractDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traPurchaseContractDet_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD LevelItem int NOT NULL CONSTRAINT DF_traReceiveDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traReceiveDet_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD LevelItem int NOT NULL CONSTRAINT DF_traSalesContractDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traSalesContractDet_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD LevelItem int NOT NULL CONSTRAINT DF_traDeliveryDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traDeliveryDet_ParentID DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 22
        Private Shared Sub DevelopOnProgress_ID22(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 22
            clsData.Name = "Develop On Progress 22"
            clsData.Scripts =
                "ALTER TABLE traReceive ADD IsUseSubItem bit NOT NULL CONSTRAINT DF_traReceiveDet_IsUseSubItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD IsUseSubItem bit NOT NULL CONSTRAINT DF_traDelivery_IsUseSubItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD IsUseSubItem bit NOT NULL CONSTRAINT DF_traAccountPayable_IsUseSubItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD IsUseSubItem bit NOT NULL CONSTRAINT DF_traAccountReceivable_IsUseSubItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traARAPItem ADD LevelItem int NOT NULL CONSTRAINT DF_traARAPItem_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traARAPItem ADD ReferencesParentID varchar(100) NOT NULL CONSTRAINT DF_traARAPItem_ReferencesParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traAccountPayableDet ADD LevelItem int NOT NULL CONSTRAINT DF_traAccountPayableDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayableDet ADD ReferencesParentID varchar(100) NOT NULL CONSTRAINT DF_traAccountPayableDet_ReferencesParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traAccountReceivableDet ADD LevelItem int NOT NULL CONSTRAINT DF_traAccountReceivableDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivableDet ADD ReferencesParentID varchar(100) NOT NULL CONSTRAINT DF_traAccountReceivableDet_ReferencesParentID DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 23
        Private Shared Sub DevelopOnProgress_ID23(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 23
            clsData.Name = "Develop On Progress 23"
            clsData.Scripts =
                "ALTER TABLE traPurchaseOrderDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traConfirmationOrderDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traConfirmationOrderDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traReceiveDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDetConfirmationOrder ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traSalesContractDetConfirmationOrder_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDetConfirmationOrder ADD LevelItem int NOT NULL CONSTRAINT DF_traSalesContractDetConfirmationOrder_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDetConfirmationOrder ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traSalesContractDetConfirmationOrder_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD LevelItem int NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD LevelItem int NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD LevelItem int NOT NULL CONSTRAINT DF_traCuttingDet_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traCuttingDet_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traCuttingDetResult ADD RoundingWeight decimal(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_RoundingWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDetResult ADD LevelItem int NOT NULL CONSTRAINT DF_traCuttingDetResult_LevelItem DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDetResult ADD ParentID varchar(100) NOT NULL CONSTRAINT DF_traCuttingDetResult_ParentID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traStockIn ADD OutTotalWeightProcess decimal(18,4) NOT NULL CONSTRAINT DF_traStockIn_OutTotalWeightProcess DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traStockIn ADD OutTotalQuantityProcess decimal(18,4) NOT NULL CONSTRAINT DF_traStockIn_OutTotalQuantityProcess DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 24
        Private Shared Sub DevelopOnProgress_ID24(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 24
            clsData.Name = "Develop On Progress 24"
            clsData.Scripts =
                "ALTER TABLE traSalesContractDet ADD UnitPriceHPP decimal(18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_UnitPriceHPP DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 25
        Private Shared Sub CreateTableAppVersion_ID25(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 25
            clsData.Name = "Create Table App Version"
            clsData.Scripts =
"CREATE TABLE [dbo].[sysAppVersion](" & vbNewLine &
"	[ID] [int] NOT NULL CONSTRAINT [DF_sysAppVersion_ID]  DEFAULT ((0)), " & vbNewLine &
"	[Version] [varchar](100) NOT NULL CONSTRAINT [DF_sysAppVersion_Version]  DEFAULT (''), " & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_sysAppVersion_LogDate]  DEFAULT (GETDATE()), " & vbNewLine &
"   CONSTRAINT [PK_sysAppVersion] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
"" & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 26
        Private Shared Sub DevelopOnProgress_ID26(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 26
            clsData.Name = "Develop On Progress 26"
            clsData.Scripts =
                "ALTER TABLE traOrderRequestDet ADD OrderNumberSupplier [varchar](100) NOT NULL CONSTRAINT DF_traOrderRequestDet_OrderNumberSupplier DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traDelivery ADD IsStock [bit] NOT NULL CONSTRAINT DF_traDelivery_IsStock DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD IsStock [bit] NOT NULL CONSTRAINT DF_traOrderRequest_IsStock DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD IsDone [bit] NOT NULL CONSTRAINT DF_traOrderRequest_IsDone DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD DoneBy [varchar](20) NOT NULL CONSTRAINT DF_traOrderRequest_DoneBy DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD DoneDate [datetime] NOT NULL CONSTRAINT DF_traOrderRequest_DoneDate DEFAULT (GETDATE()) " & vbNewLine &
                "ALTER TABLE traSalesContract ADD IsDone [bit] NOT NULL CONSTRAINT DF_traSalesContract_IsDone DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContract ADD DoneBy [varchar](20) NOT NULL CONSTRAINT DF_traSalesContract_DoneBy DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traSalesContract ADD DoneDate [datetime] NOT NULL CONSTRAINT DF_traSalesContract_DoneDate DEFAULT (GETDATE()) " & vbNewLine &
                "ALTER TABLE traPurchaseOrder ADD IsDone [bit] NOT NULL CONSTRAINT DF_traPurchaseOrder_IsDone DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrder ADD DoneBy [varchar](20) NOT NULL CONSTRAINT DF_traPurchaseOrder_DoneBy DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traPurchaseOrder ADD DoneDate [datetime] NOT NULL CONSTRAINT DF_traPurchaseOrder_DoneDate DEFAULT (GETDATE()) " & vbNewLine &
                "ALTER TABLE traConfirmationOrder ADD IsDone [bit] NOT NULL CONSTRAINT DF_traConfirmationOrder_IsDone DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traConfirmationOrder ADD DoneBy [varchar](20) NOT NULL CONSTRAINT DF_traConfirmationOrder_DoneBy DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traConfirmationOrder ADD DoneDate [datetime] NOT NULL CONSTRAINT DF_traConfirmationOrder_DoneDate DEFAULT (GETDATE()) " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD IsDone [bit] NOT NULL CONSTRAINT DF_traPurchaseContract_IsDone DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD DoneBy [varchar](20) NOT NULL CONSTRAINT DF_traPurchaseContract_DoneBy DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD DoneDate [datetime] NOT NULL CONSTRAINT DF_traPurchaseContract_DoneDate DEFAULT (GETDATE()) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCutting ADD IsDone [bit] NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_IsDone DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCutting ADD DoneBy [varchar](20) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_DoneBy DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCutting ADD DoneDate [datetime] NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_DoneDate DEFAULT (GETDATE()) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 27
        Private Shared Sub DevelopOnProgress_ID27(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 27
            clsData.Name = "Develop On Progress 27"
            clsData.Scripts =
                "ALTER TABLE traOrderRequestDet ADD UnitPriceHPP [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_UnitPriceHPP DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traStockIn ADD UnitPrice [decimal](18,4) NOT NULL CONSTRAINT DF_traStockIn_UnitPrice DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 28
        Private Shared Sub DevelopOnProgress_ID28(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 28
            clsData.Name = "Develop On Progress 28"
            clsData.Scripts =
                "ALTER TABLE traOrderRequest ADD DPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequest_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD ReceiveAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequest_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD DPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_DPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD ReceiveAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD IsIgnoreValidationPayment [bit] NOT NULL CONSTRAINT DF_traOrderRequestDet_IsIgnoreValidationPayment DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 29
        Private Shared Sub DevelopOnProgress_ID29(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 29
            clsData.Name = "Develop On Progress 29"
            clsData.Scripts =
                "ALTER TABLE traCutting ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD TotalPaymentPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_TotalPaymentPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCutting ADD TotalPaymentPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_TotalPaymentPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD TotalPaymentPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_TotalPaymentPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD TotalPaymentPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_TotalPaymentPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD DPAmountPPNTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_DPAmountPPNTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD DPAmountPPHTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_DPAmountPPHTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD TotalPaymentPPNTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_TotalPaymentPPNTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDelivery ADD TotalPaymentPPHTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDelivery_TotalPaymentPPHTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD DPAmountPPNTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_DPAmountPPNTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD DPAmountPPHTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_DPAmountPPHTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD ReceiveAmountPPNTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReceiveAmountPPNTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD ReceiveAmountPPHTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReceiveAmountPPHTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequest_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequest_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequest_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequest_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequestDet ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContract_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContract_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContract_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContract_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCutting ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCutting ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCutting ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCutting ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceive ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traReceive_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceive ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traReceive_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceive ADD TotalPaymentPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traReceive_TotalPaymentPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceive ADD TotalPaymentPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traReceive_TotalPaymentPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContract ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContract_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContract ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContract_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContract ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContract_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContract ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContract_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD DPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD DPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD ReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD ReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 30
        Private Shared Sub DevelopOnProgress_ID30(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 30
            clsData.Name = "Develop On Progress 30"
            clsData.Scripts = "ALTER TABLE traSalesContractDetConfirmationOrder ADD LocationID [int] NOT NULL CONSTRAINT DF_traSalesContractDetConfirmationOrder_LocationID DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 31
        Private Shared Sub DevelopOnProgress_ID31(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 31
            clsData.Name = "Create Table traOrderRequestDetConfirmationOrder"
            clsData.Scripts =
"GO   " & vbNewLine &
"   " & vbNewLine &
"/****** Object:  Table [dbo].[traOrderRequestDetConfirmationOrder]    Script Date: 9/5/2024 9:21:12 PM ******/   " & vbNewLine &
"SET ANSI_NULLS ON   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"SET QUOTED_IDENTIFIER ON   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"SET ANSI_PADDING ON   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"CREATE TABLE [dbo].[traOrderRequestDetConfirmationOrder](   " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_ID]  DEFAULT (''),   " & vbNewLine &
"	[MapID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_MapID]  DEFAULT (''),   " & vbNewLine &
"	[OrderRequestID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_OrderRequestID]  DEFAULT (''),   " & vbNewLine &
"	[ORDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_ORDetailID]  DEFAULT (''),   " & vbNewLine &
"	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_COID]  DEFAULT (''),   " & vbNewLine &
"	[CODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_CODetailID]  DEFAULT (''),   " & vbNewLine &
"	[GroupID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_GroupID]  DEFAULT ((0)),   " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_ItemID]  DEFAULT ((0)),   " & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_Quantity]  DEFAULT ((0)),   " & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_Weight]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_TotalWeight]  DEFAULT ((0)),   " & vbNewLine &
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_UnitPrice]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_TotalPrice]  DEFAULT ((0)),   " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_Remarks]  DEFAULT (''),   " & vbNewLine &
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_RoundingWeight]  DEFAULT ((0)),   " & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_LevelItem]  DEFAULT ((0)),   " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_ParentID]  DEFAULT (''),   " & vbNewLine &
"	[LocationID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_LocationID]  DEFAULT ((0)),   " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrder_OrderNumberSupplier]  DEFAULT (''),   " & vbNewLine &
" CONSTRAINT [PK_traOrderRequestDetConfirmationOrder] PRIMARY KEY CLUSTERED    " & vbNewLine &
"(   " & vbNewLine &
"	[ID] ASC   " & vbNewLine &
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]   " & vbNewLine &
") ON [PRIMARY]   " & vbNewLine &
"   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"SET ANSI_PADDING OFF   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"/****** Object:  Table [dbo].[traOrderRequestDetConfirmationOrderDet]    Script Date: 9/5/2024 9:21:12 PM ******/   " & vbNewLine &
"SET ANSI_NULLS ON   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"SET QUOTED_IDENTIFIER ON   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"SET ANSI_PADDING ON   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"CREATE TABLE [dbo].[traOrderRequestDetConfirmationOrderDet](   " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_ID]  DEFAULT (''),   " & vbNewLine &
"	[MapID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_MapID]  DEFAULT (''),   " & vbNewLine &
"	[OrderRequestID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_OrderRequestID]  DEFAULT (''),   " & vbNewLine &
"	[ORDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_ORDetailID]  DEFAULT (''),   " & vbNewLine &
"	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_COID]  DEFAULT (''),   " & vbNewLine &
"	[CODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_CODetailID]  DEFAULT (''),   " & vbNewLine &
"	[GroupID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_GroupID]  DEFAULT ((0)),   " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_ItemID]  DEFAULT ((0)),   " & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_Quantity]  DEFAULT ((0)),   " & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_Weight]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_TotalWeight]  DEFAULT ((0)),   " & vbNewLine &
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_UnitPrice]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_TotalPrice]  DEFAULT ((0)),   " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_Remarks]  DEFAULT (''),   " & vbNewLine &
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_RoundingWeight]  DEFAULT ((0)),   " & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_LevelItem]  DEFAULT ((0)),   " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_ParentID]  DEFAULT (''),   " & vbNewLine &
"	[LocationID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_LocationID]  DEFAULT ((0)),   " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDetConfirmationOrderDet_OrderNumberSupplier]  DEFAULT (''),   " & vbNewLine &
" CONSTRAINT [PK_traOrderRequestDetConfirmationOrderDet] PRIMARY KEY CLUSTERED    " & vbNewLine &
"(   " & vbNewLine &
"	[ID] ASC   " & vbNewLine &
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]   " & vbNewLine &
") ON [PRIMARY]   " & vbNewLine &
"   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"SET ANSI_PADDING OFF   " & vbNewLine &
"GO   " & vbNewLine &
"   " & vbNewLine &
"ALTER TABLE traConfirmationOrderDet ADD ORQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traConfirmationOrderDet_ORQuantity DEFAULT ((0))    " & vbNewLine &
"ALTER TABLE traConfirmationOrderDet ADD ORWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traConfirmationOrderDet_ORWeight DEFAULT ((0))   " & vbNewLine &
"ALTER TABLE traOrderRequestDet ADD COQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_COQuantity DEFAULT ((0))    " & vbNewLine &
"ALTER TABLE traOrderRequestDet ADD COWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_COWeight DEFAULT ((0))   " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

    End Class
End Namespace