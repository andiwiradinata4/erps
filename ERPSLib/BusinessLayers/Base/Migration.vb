Namespace BL
    Public Class Migration

        Public Shared Sub Migrate()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try
                    CreateTableMigration(sqlCon, sqlTrans)
                    AddColumnPCIDInTableConfirmationOrderAddJournalIDAndTotalPayemntInTableReceive_ID1(sqlCon, sqlTrans)
                    AddColumnIsAutoGenerateInTablePurchaseContract_ID2(sqlCon, sqlTrans)
                    DevelopARAPForUsingDownPayment_ID3(sqlCon, sqlTrans)
                    CreateTableARAPDP_ID4(sqlCon, sqlTrans)
                    AlterTableCuttingAndDelivery_ID5(sqlCon, sqlTrans)
                    AlterTableReceive_ID6(sqlCon, sqlTrans)
                    AlterTableCutting_ID7(sqlCon, sqlTrans)
                    CreateTableDeliveryTransport_ID8(sqlCon, sqlTrans)
                    AlterTableSysJournalPost_ID9(sqlCon, sqlTrans)
                    AlterTableSysJournalPost_ID10(sqlCon, sqlTrans)
                    AlterTableForHandleCoAofStock_ID11(sqlCon, sqlTrans)
                    AlterTableForHandleCoAofStock_ID12(sqlCon, sqlTrans)
                    CreateTableBPLocation_ID13(sqlCon, sqlTrans)
                    DevelopARAPForItem_ID14(sqlCon, sqlTrans)
                    DevelopOnProgress_ID15(sqlCon, sqlTrans)
                    DevelopOnProgress_ID16(sqlCon, sqlTrans)
                    DevelopOnProgress_ID17(sqlCon, sqlTrans)
                    DevelopOnProgress_ID18(sqlCon, sqlTrans)
                    DevelopOnProgress_ID19(sqlCon, sqlTrans)
                    DevelopOnProgress_ID20(sqlCon, sqlTrans)
                    DevelopOnProgress_ID21(sqlCon, sqlTrans)
                    DevelopOnProgress_ID22(sqlCon, sqlTrans)
                    DevelopOnProgress_ID23(sqlCon, sqlTrans)
                    DevelopOnProgress_ID24(sqlCon, sqlTrans)
                    CreateTableAppVersion_ID25(sqlCon, sqlTrans)
                    DevelopOnProgress_ID26(sqlCon, sqlTrans)
                    DevelopOnProgress_ID27(sqlCon, sqlTrans)
                    DevelopOnProgress_ID28(sqlCon, sqlTrans)
                    DevelopOnProgress_ID29(sqlCon, sqlTrans)
                    DevelopOnProgress_ID30(sqlCon, sqlTrans)
                    DevelopOnProgress_ID31(sqlCon, sqlTrans)
                    DevelopOnProgress_ID32(sqlCon, sqlTrans)
                    DevelopOnProgress_ID33(sqlCon, sqlTrans)
                    DevelopOnProgress_ID34(sqlCon, sqlTrans)
                    DevelopOnProgress_ID35(sqlCon, sqlTrans)
                    DevelopOnProgress_ID36(sqlCon, sqlTrans)
                    DevelopOnProgress_ID37(sqlCon, sqlTrans)
                    DevelopOnProgress_ID38(sqlCon, sqlTrans)
                    DevelopOnProgress_ID39(sqlCon, sqlTrans)
                    DevelopOnProgress_ID40(sqlCon, sqlTrans)
                    DevelopOnProgress_ID41(sqlCon, sqlTrans)
                    DevelopOnProgress_ID42(sqlCon, sqlTrans)
                    DevelopOnProgress_ID43(sqlCon, sqlTrans)
                    DevelopOnProgress_ID44(sqlCon, sqlTrans)
                    DevelopOnProgress_ID45(sqlCon, sqlTrans)
                    DevelopOnProgress_ID46(sqlCon, sqlTrans)
                    DevelopOnProgress_ID47(sqlCon, sqlTrans)
                    DevelopOnProgress_ID48(sqlCon, sqlTrans)
                    DevelopOnProgress_ID49(sqlCon, sqlTrans)
                    DevelopOnProgress_ID50(sqlCon, sqlTrans)
                    DevelopOnProgress_ID51(sqlCon, sqlTrans)
                    DevelopOnProgress_ID52(sqlCon, sqlTrans)
                    DevelopOnProgress_ID53(sqlCon, sqlTrans)
                    CreateTableItemResult_ID54(sqlCon, sqlTrans)
                    DevelopOnProgress_ID55(sqlCon, sqlTrans)
                    DevelopOnProgress_ID56(sqlCon, sqlTrans)
                    DevelopOnProgress_ID57(sqlCon, sqlTrans)
                    DevelopOnProgress_ID58(sqlCon, sqlTrans)
                    DevelopOnProgress_ID59(sqlCon, sqlTrans)
                    DevelopOnProgress_ID60(sqlCon, sqlTrans)
                    DevelopOnProgress_ID61(sqlCon, sqlTrans)
                    DevelopOnProgress_ID62(sqlCon, sqlTrans)
                    DevelopOnProgress_ID63(sqlCon, sqlTrans)
                    DevelopOnProgress_ID64(sqlCon, sqlTrans)
                    DevelopOnProgress_ID65(sqlCon, sqlTrans)
                    DevelopOnProgress_ID66(sqlCon, sqlTrans)
                    DevelopOnProgress_ID67(sqlCon, sqlTrans)
                    DevelopOnProgress_ID68(sqlCon, sqlTrans)
                    DevelopOnProgress_ID69(sqlCon, sqlTrans)
                    DevelopOnProgress_ID70(sqlCon, sqlTrans)
                    CreateARAPInvoiceItem_ID71(sqlCon, sqlTrans)
                    DevelopOnProgress_ID72(sqlCon, sqlTrans)
                    DevelopOnProgress_ID73(sqlCon, sqlTrans)
                    DevelopOnProgress_ID74(sqlCon, sqlTrans)
                    DevelopOnProgress_ID75(sqlCon, sqlTrans)
                    DevelopOnProgress_ID76(sqlCon, sqlTrans)
                    DevelopOnProgress_ID77(sqlCon, sqlTrans)
                    DevelopOnProgress_ID78(sqlCon, sqlTrans)
                    DevelopOnProgress_ID79(sqlCon, sqlTrans)
                    DevelopOnProgress_ID80(sqlCon, sqlTrans)
                    DevelopOnProgress_ID81(sqlCon, sqlTrans)
                    DevelopOnProgress_ID82(sqlCon, sqlTrans)
                    DevelopOnProgress_ID83(sqlCon, sqlTrans)
                    DevelopOnProgress_ID84(sqlCon, sqlTrans)
                    DevelopOnProgress_ID85(sqlCon, sqlTrans)
                    DevelopOnProgress_ID86(sqlCon, sqlTrans)
                    DevelopOnProgress_ID87(sqlCon, sqlTrans)
                    DevelopOnProgress_ID88(sqlCon, sqlTrans)
                    CreateARAPVoucher_ID89(sqlCon, sqlTrans)
                    DevelopOnProgress_ID90(sqlCon, sqlTrans)
                    DevelopOnProgress_ID91(sqlCon, sqlTrans)
                    DevelopOnProgress_ID92(sqlCon, sqlTrans)
                    DevelopOnProgress_ID93(sqlCon, sqlTrans)
                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
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
"CREATE TABLE [dbo].[traOrderRequestConfirmationOrder](   " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_ID]  DEFAULT (''),   " & vbNewLine &
"	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_ProgramID]  DEFAULT ((0)),   " & vbNewLine &
"	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_CompanyID]  DEFAULT ((0)),   " & vbNewLine &
"	[OrderRequestID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_OrderRequestID]  DEFAULT (''),   " & vbNewLine &
"	[TransactionNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_TransactionNumber]  DEFAULT (''),   " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_Remarks]  DEFAULT (''), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_CreatedBy]  DEFAULT (''), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_CreatedDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_LogBy]  DEFAULT (''), " & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_LogDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrder_LogInc]  DEFAULT ((0)), " & vbNewLine &
"   CONSTRAINT [PK_traOrderRequestConfirmationOrder] PRIMARY KEY CLUSTERED    " & vbNewLine &
"   (   " & vbNewLine &
"   	[ID] ASC   " & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traOrderRequestConfirmationOrderDet](   " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_ID]  DEFAULT (''),   " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_ParentID]  DEFAULT (''),   " & vbNewLine &
"	[ORDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_ORDetailID]  DEFAULT (''),   " & vbNewLine &
"	[CODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_CODetailID]  DEFAULT (''),   " & vbNewLine &
"	[GroupID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_GroupID]  DEFAULT ((0)),   " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_ItemID]  DEFAULT ((0)),   " & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_Quantity]  DEFAULT ((0)),   " & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_Weight]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_TotalWeight]  DEFAULT ((0)),   " & vbNewLine &
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_UnitPrice]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_TotalPrice]  DEFAULT ((0)),   " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_Remarks]  DEFAULT (''),   " & vbNewLine &
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_RoundingWeight]  DEFAULT ((0)),   " & vbNewLine &
"	[QuantityCO] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_QuantityCO]  DEFAULT ((0)),   " & vbNewLine &
"	[WeightCO] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_WeightCO]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalWeightCO] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_TotalWeightCO]  DEFAULT ((0)),   " & vbNewLine &
"	[UnitPriceCO] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_UnitPriceCO]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalPriceCO] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_TotalPriceCO]  DEFAULT ((0)),   " & vbNewLine &
"	[RoundingWeightCO] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_RoundingWeightCO]  DEFAULT ((0)),   " & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_LevelItem]  DEFAULT ((0)),   " & vbNewLine &
"	[LocationID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_LocationID]  DEFAULT ((0)),   " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_OrderNumberSupplier]  DEFAULT (''),   " & vbNewLine &
"	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_DPAmount]  DEFAULT ((0)),   " & vbNewLine &
"	[ReceiveAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_ReceiveAmount]  DEFAULT ((0)),   " & vbNewLine &
"	[UnitPriceHPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_UnitPriceHPP]  DEFAULT ((0)),   " & vbNewLine &
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_DPAmountPPN]  DEFAULT ((0)),   " & vbNewLine &
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_DPAmountPPH]  DEFAULT ((0)),   " & vbNewLine &
"	[ReceiveAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_ReceiveAmountPPN]  DEFAULT ((0)),   " & vbNewLine &
"	[ReceiveAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequestConfirmationOrderDet_ReceiveAmountPPH]  DEFAULT ((0)),   " & vbNewLine &
"   CONSTRAINT [PK_traOrderRequestConfirmationOrderDet] PRIMARY KEY CLUSTERED    " & vbNewLine &
"   (   " & vbNewLine &
"   	[ID] ASC   " & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
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

        '# ID = 32
        Private Shared Sub DevelopOnProgress_ID32(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 32
            clsData.Name = "Alter Table traOrderRequestDet Add GroupID"
            clsData.Scripts = "ALTER TABLE traOrderRequestDet ADD GroupID [int] NOT NULL CONSTRAINT DF_traOrderRequestDet_GroupID DEFAULT ((0))    " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 33
        Private Shared Sub DevelopOnProgress_ID33(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 33
            clsData.Name = "Alter Table Sales Contract and Purchase Contract Add Allocate DP Amount"
            clsData.Scripts =
"ALTER TABLE traSalesContractDet ADD AllocateDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_AllocateDPAmount DEFAULT ((0))    " & vbNewLine &
"ALTER TABLE traPurchaseContractDet ADD AllocateDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_AllocateDPAmount DEFAULT ((0))    " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 34
        Private Shared Sub DevelopOnProgress_ID34(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 34
            clsData.Name = "Alter Table Order Request Add Allocate DP Amount"
            clsData.Scripts = "ALTER TABLE traOrderRequestDet ADD AllocateDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_AllocateDPAmount DEFAULT ((0))    " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 35
        Private Shared Sub DevelopOnProgress_ID35(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 35
            clsData.Name = "Alter Table Purchase Order Cutting Add Allocate DP Amount"
            clsData.Scripts = "ALTER TABLE traPurchaseOrderCuttingDet ADD AllocateDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_AllocateDPAmount DEFAULT ((0))    " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 36
        Private Shared Sub DevelopOnProgress_ID36(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 36
            clsData.Name = "Alter Table Cutting Detail Result Add HPP"
            clsData.Scripts = "ALTER TABLE traCuttingDetResult ADD UnitPriceHPP [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_UnitPriceHPP DEFAULT ((0))    " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 37
        Private Shared Sub DevelopOnProgress_ID37(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 37
            clsData.Name = "Alter Table Sales Contract Detail | Add Invoice Quantity dan Weight"
            clsData.Scripts =
                "ALTER TABLE traSalesContractDet ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traARAPItem ADD Quantity [decimal](18,4) NOT NULL CONSTRAINT DF_traARAPItem_Quantity DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traARAPItem ADD Weight [decimal](18,4) NOT NULL CONSTRAINT DF_traARAPItem_Weight DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traARAPItem ADD TotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traARAPItem_TotalWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivableDet ADD Quantity [decimal](18,4) NOT NULL CONSTRAINT DF_traAccountReceivableDet_Quantity DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traAccountReceivableDet ADD Weight [decimal](18,4) NOT NULL CONSTRAINT DF_traAccountReceivableDet_Weight DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traAccountReceivableDet ADD TotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traAccountReceivableDet_TotalWeight DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 38
        Private Shared Sub DevelopOnProgress_ID38(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 38
            clsData.Name = "Alter Table traAccountReceivable | List Payment Term"
            clsData.Scripts =
                "ALTER TABLE traAccountReceivable ADD PaymentTerm1 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm1 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm2 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm2 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm3 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm3 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm4 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm4 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm5 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm5 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm6 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm6 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm7 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm7 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm8 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm8 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm9 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm9 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PaymentTerm10 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_PaymentTerm10 DEFAULT ('')  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 39
        Private Shared Sub DevelopOnProgress_ID39(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 39
            clsData.Name = "Alter Table traAccountPayable | List Payment Term"
            clsData.Scripts =
                "ALTER TABLE traAccountPayable ADD PaymentTerm1 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm1 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm2 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm2 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm3 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm3 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm4 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm4 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm5 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm5 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm6 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm6 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm7 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm7 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm8 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm8 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm9 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm9 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PaymentTerm10 [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_PaymentTerm10 DEFAULT ('')  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 40
        Private Shared Sub DevelopOnProgress_ID40(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 40
            clsData.Name = "Alter Table traSalesContract | References Number"
            clsData.Scripts = "ALTER TABLE traSalesContract ADD ReferencesNumber [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_ReferencesNumber DEFAULT ('')  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 41
        Private Shared Sub DevelopOnProgress_ID41(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 41
            clsData.Name = "Alter Table traConfirmationOrder and traPurchaseContract | Payment Type ID"
            clsData.Scripts =
                "ALTER TABLE traConfirmationOrder ADD PaymentTypeID [int] NOT NULL CONSTRAINT DF_traConfirmationOrder_PaymentTypeID DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traPurchaseContract ADD PaymentTypeID [int] NOT NULL CONSTRAINT DF_traPurchaseContract_PaymentTypeID DEFAULT ((0))  " & vbNewLine &
                "INSERT INTO mstPaymentType (ID, Code, Name, PaymentTypeCategoryID, StatusID) VALUES (14, 'TT30DAYS', 'TT 30 HARI', 2, 1)" & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 42
        Private Shared Sub DevelopOnProgress_ID42(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 42
            clsData.Name = "Alter Table Delivery Detail / Cutting Detail / AP Detail | Add Invoice Quantity dan Weight"
            clsData.Scripts =
                "ALTER TABLE traDeliveryDet ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traReceiveDet ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayableDet ADD Quantity [decimal](18,4) NOT NULL CONSTRAINT DF_traAccountPayableDet_Quantity DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traAccountPayableDet ADD Weight [decimal](18,4) NOT NULL CONSTRAINT DF_traAccountPayableDet_Weight DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traAccountPayableDet ADD TotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traAccountPayableDet_TotalWeight DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 43
        Private Shared Sub DevelopOnProgress_ID43(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 43
            clsData.Name = "Alter Table Delivery | Add BP Location ID"
            clsData.Scripts = "ALTER TABLE traDelivery ADD BPLocationID [int] NOT NULL CONSTRAINT DF_traDelivery_BPLocationID DEFAULT ((0)) " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 44
        Private Shared Sub DevelopOnProgress_ID44(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 44
            clsData.Name = "Alter Table Delivery Detail | Add Invoice Quantity dan Weight Transport"
            clsData.Scripts =
                "ALTER TABLE traDeliveryDet ADD InvoiceQuantityTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_InvoiceQuantityTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD InvoiceWeightTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_InvoiceWeightTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD InvoiceTotalWeightTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_InvoiceTotalWeightTransport DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD AllocateDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_AllocateDPAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traDeliveryDet ADD AllocateDPAmountTransport [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_AllocateDPAmountTransport DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 45
        Private Shared Sub DevelopOnProgress_ID45(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 45
            clsData.Name = "Alter Table Purchase Contract Detail | Add Order Number Supplier"
            clsData.Scripts = "ALTER TABLE traPurchaseContractDet ADD OrderNumberSupplier [varchar](100) NOT NULL CONSTRAINT DF_traPurchaseContractDet_OrderNumberSupplier DEFAULT ('') " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 46
        Private Shared Sub DevelopOnProgress_ID46(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 46
            clsData.Name = "Alter Table Sales Contract Detail | Add CODetailID"
            clsData.Scripts = "ALTER TABLE traSalesContractDet ADD CODetailID [varchar](100) NOT NULL CONSTRAINT DF_traSalesContractDet_CODetailID DEFAULT ('') " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 47
        Private Shared Sub DevelopOnProgress_ID47(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 47
            clsData.Name = "Alter Table Purchase Order Cutting Result | Add Unit Price and Total Price Raw Material"
            clsData.Scripts +=
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD UnitPriceRawMaterial [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_UnitPriceRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD TotalPriceRawMaterial [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_TotalPriceRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD UnitPriceRawMaterial [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_UnitPriceRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD TotalPriceRawMaterial [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_TotalPriceRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traCuttingDetResult ADD TotalPriceHPP [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_TotalPriceHPP DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD TotalInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountPayable_TotalInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD TotalDPPInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountPayable_TotalDPPInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD TotalPPNInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountPayable_TotalPPNInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD TotalPPHInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountPayable_TotalPPHInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PPNPercentage [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountPayable_PPNPercentage DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD PPHPercentage [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountPayable_PPHPercentage DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD TotalInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_TotalInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD TotalDPPInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_TotalDPPInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD TotalPPNInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_TotalPPNInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD TotalPPHInvoiceAmount [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_TotalPPHInvoiceAmount DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PPNPercentage [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_PPNPercentage DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD PPHPercentage [decimal](18,2) NOT NULL CONSTRAINT DF_traAccountReceivable_PPHPercentage DEFAULT ((0)) " & vbNewLine

            clsData.Scripts +=
"CREATE TABLE [dbo].[traARAPInvoice](   " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoice_ID]  DEFAULT (''),   " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoice_ParentID]  DEFAULT (''),   " & vbNewLine &
"	[InvoiceNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoice_InvoiceNumber]  DEFAULT (''),   " & vbNewLine &
"	[InvoiceDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPInvoice_InvoiceDate]  DEFAULT (GETDATE()),   " & vbNewLine &
"	[CoAID] [int] NOT NULL CONSTRAINT [DF_traARAPInvoice_CoAID]  DEFAULT ((0)), " & vbNewLine &
"	[PPN] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPInvoice_PPN]  DEFAULT ((0)),   " & vbNewLine &
"	[PPH] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPInvoice_PPH]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalAmount] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPInvoice_TotalAmount]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalDPP] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPInvoice_TotalDPP]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalPPN] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPInvoice_TotalPPN]  DEFAULT ((0)),   " & vbNewLine &
"	[TotalPPH] [decimal](18,2) NOT NULL CONSTRAINT [DF_traARAPInvoice_TotalPPH]  DEFAULT ((0)),   " & vbNewLine &
"	[StatusID] [int] NOT NULL CONSTRAINT [DF_traARAPInvoice_StatusID]  DEFAULT ((0)), " & vbNewLine &
"	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traARAPInvoice_IsDeleted]  DEFAULT ((0)), " & vbNewLine &
"	[ReferencesNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoice_ReferencesNumber]  DEFAULT (''), " & vbNewLine &
"	[TaxInvoiceNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoice_TaxInvoiceNumber]  DEFAULT (''), " & vbNewLine &
"	[InvoiceNumberExternal] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoice_InvoiceNumberExternal]  DEFAULT (''), " & vbNewLine &
"	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPInvoice_SubmitBy]  DEFAULT (''), " & vbNewLine &
"	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPInvoice_SubmitDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[ApproveL1] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPInvoice_ApproveL1]  DEFAULT (''), " & vbNewLine &
"	[ApproveL1Date] [datetime] NOT NULL CONSTRAINT [DF_traARAPInvoice_ApproveL1Date]  DEFAULT (GETDATE()), " & vbNewLine &
"	[ApprovedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPInvoice_ApprovedBy]  DEFAULT (''), " & vbNewLine &
"	[ApprovedDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPInvoice_ApprovedDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[JournalID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoice_JournalID]  DEFAULT (''), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traARAPInvoice_Remarks]  DEFAULT (''), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPInvoice_CreatedBy]  DEFAULT (''), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPInvoice_CreatedDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPInvoice_LogBy]  DEFAULT (''), " & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPInvoice_LogDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traARAPInvoice_LogInc]  DEFAULT ((0)) " & vbNewLine &
"   CONSTRAINT [PK_traARAPInvoice] PRIMARY KEY CLUSTERED    " & vbNewLine &
"   (   " & vbNewLine &
"   	[ID] ASC   " & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 48
        Private Shared Sub DevelopOnProgress_ID48(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 48
            clsData.Name = "Create Table traARAPDueDateHistory"
            clsData.Scripts +=
"CREATE TABLE [dbo].[traARAPDueDateHistory](   " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_ID]  DEFAULT (''),   " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_ParentID]  DEFAULT (''),   " & vbNewLine &
"	[DueDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_DueDate]  DEFAULT (GETDATE()),   " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_Remarks]  DEFAULT (''), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_CreatedBy]  DEFAULT (''), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_CreatedDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_LogBy]  DEFAULT (''), " & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_LogDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traARAPDueDateHistory_LogInc]  DEFAULT ((0)) " & vbNewLine &
"   CONSTRAINT [PK_traARAPDueDateHistory] PRIMARY KEY CLUSTERED    " & vbNewLine &
"   (   " & vbNewLine &
"   	[ID] ASC   " & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 49
        Private Shared Sub DevelopOnProgress_ID49(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 49
            clsData.Name = "Alter Table Purchase Contract Detail | Add SC Quantity and SC Weight"
            clsData.Scripts +=
                "ALTER TABLE traPurchaseContractDet ADD SCQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_SCQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseContractDet ADD SCWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseContractDet_SCWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesContractDet ADD PCDetailID [varchar](100) NOT NULL CONSTRAINT DF_traSalesContractDet_PCDetailID DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 50
        Private Shared Sub DevelopOnProgress_ID50(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 50
            clsData.Name = "Alter Table Sales Contract Detail Confirmation Order | Add PCDetailID"
            clsData.Scripts += "ALTER TABLE traSalesContractDetConfirmationOrder ADD PCDetailID [varchar](100) NOT NULL CONSTRAINT DF_traSalesContractDetConfirmationOrder_PCDetailID DEFAULT ('') " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 51
        Private Shared Sub DevelopOnProgress_ID51(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 51
            clsData.Name = "Create Table traARAPInvoiceStatus"
            clsData.Scripts +=
"CREATE TABLE [dbo].[traARAPInvoiceStatus](   " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceStatus_ID]  DEFAULT (''),   " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceStatus_ParentID]  DEFAULT (''),   " & vbNewLine &
"	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceStatus_Status]  DEFAULT (''),   " & vbNewLine &
"	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPInvoiceStatus_StatusBy]  DEFAULT (''), " & vbNewLine &
"	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPInvoiceStatus_StatusDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traARAPInvoiceStatus_Remarks]  DEFAULT (''), " & vbNewLine &
"   CONSTRAINT [PK_traARAPInvoiceStatus] PRIMARY KEY CLUSTERED    " & vbNewLine &
"   (   " & vbNewLine &
"   	[ID] ASC   " & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 52
        Private Shared Sub DevelopOnProgress_ID52(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 52
            clsData.Name = "Alter Table PO Cutting Header and Detail | Add CustomerID and ReceiveDetailID"
            clsData.Scripts +=
"ALTER TABLE traStockIn ADD ProgramID [int] NOT NULL CONSTRAINT DF_traStockIn_ProgramID DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traStockIn ADD CompanyID [int] NOT NULL CONSTRAINT DF_traStockIn_CompanyID DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traStockOut ADD ProgramID [int] NOT NULL CONSTRAINT DF_traStockOut_ProgramID DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traStockOut ADD CompanyID [int] NOT NULL CONSTRAINT DF_traStockOut_CompanyID DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD CustomerID [int] NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_CustomerID DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD IsClaimCustomer [bit] NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_IsClaimCustomer DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD ClaimDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ClaimDPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD ClaimDPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ClaimDPAmountPPN DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD ClaimDPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ClaimDPAmountPPH DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD ClaimReceiveAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ClaimReceiveAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD ClaimReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ClaimReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD ClaimReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_ClaimReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD PickupDate [datetime] NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_PickupDate DEFAULT (GETDATE()) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCutting ADD RemarksResult [varchar](1000) NOT NULL CONSTRAINT DF_traPurchaseOrderCutting_RemarksResult DEFAULT ('') " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimDPAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimDPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimDPAmountPPN DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimDPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimDPAmountPPH DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimReceiveAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimReceiveAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDet ADD ReceiveDetailID [varchar](100) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ReceiveDetailID DEFAULT ('') " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDetResult ADD IsShowPrintOut [bit] NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_IsShowPrintOut DEFAULT ((1)) " & vbNewLine &
"ALTER TABLE mstItem ADD LengthInitial [varchar](100) NOT NULL CONSTRAINT DF_mstItem_LengthInitial DEFAULT ('') " & vbNewLine &
"ALTER TABLE mstItem ADD UomID [int] NOT NULL CONSTRAINT DF_mstItem_UomID DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 53
        Private Shared Sub DevelopOnProgress_ID53(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 53
            clsData.Name = "Alter Table mstItemType | Add LengthInitial"
            clsData.Scripts += "ALTER TABLE mstItemType ADD LengthInitial [varchar](100) NOT NULL CONSTRAINT DF_mstItemType_LengthInitial DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 54
        Private Shared Sub CreateTableItemResult_ID54(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 54
            clsData.Name = "Create Table Item Result"
            clsData.Scripts += _
"CREATE TABLE [dbo].[traItemResult](  " & vbNewLine & _
"	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traItemResult_ProgramID]  DEFAULT ((0)),  " & vbNewLine & _
"	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traItemResult_CompanyID]  DEFAULT ((0)),  " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traItemResult_ID]  DEFAULT (''),  " & vbNewLine & _
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traItemResult_ItemID]  DEFAULT ((0)),  " & vbNewLine & _
"	[Name] [varchar](1000) NOT NULL CONSTRAINT [DF_traItemResult_Name]  DEFAULT (''),  " & vbNewLine & _
"	[StatusID] [int] NOT NULL CONSTRAINT [DF_traItemResult_StatusID]  DEFAULT ((0)),  " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traItemResult_Remarks]  DEFAULT (''),  " & vbNewLine & _
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traItemResult_CreatedBy]  DEFAULT ('SYSTEM'),  " & vbNewLine & _
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traItemResult_CreatedDate]  DEFAULT (GETDATE()),  " & vbNewLine & _
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traItemResult_LogBy]  DEFAULT ('SYSTEM'),  " & vbNewLine & _
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traItemResult_LogDate]  DEFAULT (GETDATE()),  " & vbNewLine & _
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traItemResult_LogInc]  DEFAULT ((0)),  " & vbNewLine & _
"   CONSTRAINT [PK_traItemResult] PRIMARY KEY CLUSTERED   " & vbNewLine & _
"   (  " & vbNewLine & _
"   	[ID] ASC  " & vbNewLine & _
"   )   " & vbNewLine & _
")  " & vbNewLine & _
"CREATE TABLE [dbo].[traItemResultDet](  " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traItemResultDet_ID]  DEFAULT (''),  " & vbNewLine & _
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traItemResultDet_ParentID]  DEFAULT (''),  " & vbNewLine & _
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traItemResultDet_ItemID]  DEFAULT ((0)),  " & vbNewLine & _
"	[Multiple] [decimal](18,2) NOT NULL CONSTRAINT [DF_traItemResultDet_Multiple]  DEFAULT ((0))," & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traItemResultDet_Remarks]  DEFAULT (''),  " & vbNewLine & _
"   CONSTRAINT [PK_traItemResultDet] PRIMARY KEY CLUSTERED   " & vbNewLine & _
"   (  " & vbNewLine & _
"   	[ID] ASC  " & vbNewLine & _
"   )   " & vbNewLine & _
")  " & vbNewLine & _
"CREATE TABLE [dbo].[traItemResultStatus](" & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traItemResultStatus_ID]  DEFAULT (''),  " & vbNewLine & _
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traItemResultStatus_ParentID]  DEFAULT (''),  " & vbNewLine & _
"	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traItemResultStatus_Status]  DEFAULT ('')," & vbNewLine & _
"	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traItemResultStatus_StatusBy]  DEFAULT ('')," & vbNewLine & _
"	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traItemResultStatus_StatusDate]  DEFAULT (GETDATE())," & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traItemResultStatus_Remarks]  DEFAULT ('')," & vbNewLine & _
"	CONSTRAINT [PK_traItemResultStatus] PRIMARY KEY CLUSTERED " & vbNewLine & _
"	(" & vbNewLine & _
"	[ID] ASC" & vbNewLine & _
"	)" & vbNewLine & _
")" & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 55
        Private Shared Sub DevelopOnProgress_ID55(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 55
            clsData.Name = "Alter Table traPurchaseOrderCuttingDet | Add ResultID"
            clsData.Scripts +=
"ALTER TABLE traPurchaseOrderCuttingDet ADD ResultID [varchar](100) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ResultID DEFAULT ('') " & vbNewLine &
"ALTER TABLE traPurchaseOrderCuttingDetResult ADD ResultID [varchar](100) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_ResultID DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 56
        Private Shared Sub DevelopOnProgress_ID56(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 56
            clsData.Name = "Alter Table traPurchaseOrderCuttingDet | Add ResultID"
            clsData.Scripts += "ALTER TABLE traCutting ADD CustomerID [int] NOT NULL CONSTRAINT DF_traCutting_CustomerID DEFAULT ((0)) " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 57
        Private Shared Sub DevelopOnProgress_ID57(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 57
            clsData.Name = "Alter Table traSalesContract | Additional Term"
            clsData.Scripts =
                "ALTER TABLE traSalesContract ADD AdditionalTerm1 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm1 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm2 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm2 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm3 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm3 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm4 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm4 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm5 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm5 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm6 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm6 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm7 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm7 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm8 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm8 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm9 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm9 DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traSalesContract ADD AdditionalTerm10 [varchar](5000) NOT NULL CONSTRAINT DF_traSalesContract_AdditionalTerm10 DEFAULT ('')  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 58
        Private Shared Sub DevelopOnProgress_ID58(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 58
            clsData.Name = "Alter Table Purchase Order Cutting Detail | Add Invoice Quantity dan Weight"
            clsData.Scripts =
                "ALTER TABLE traPurchaseOrderCuttingDet ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDetResult ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 59
        Private Shared Sub DevelopOnProgress_ID59(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 59
            clsData.Name = "Create Table Sales Return"
            clsData.Scripts =
"CREATE TABLE [dbo].[traSalesReturn]( " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturn_ID]  DEFAULT (''), " & vbNewLine & _
"	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traSalesReturn_ProgramID]  DEFAULT ((0)), " & vbNewLine & _
"	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traSalesReturn_CompanyID]  DEFAULT ((0)), " & vbNewLine & _
"	[SalesReturnNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturn_SalesReturnNumber]  DEFAULT (''), " & vbNewLine & _
"	[SalesReturnDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesReturn_SalesReturnDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[BPID] [int] NOT NULL CONSTRAINT [DF_traSalesReturn_BPID]  DEFAULT ((0)), " & vbNewLine & _
"	[DeliveryID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturn_DeliveryID]  DEFAULT (''), " & vbNewLine & _
"	[PlatNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturn_PlatNumber]  DEFAULT (''), " & vbNewLine & _
"	[Driver] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturn_Driver]  DEFAULT (''), " & vbNewLine & _
"	[ReferencesNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturn_ReferencesNumber]  DEFAULT (''), " & vbNewLine & _
"	[PPN] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traSalesReturn_PPN]  DEFAULT ((0)), " & vbNewLine & _
"	[PPH] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traSalesReturn_PPH]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalQuantity]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_RoundingManual]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalDPP]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPPN]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPPH]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalDPPTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalDPPTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPNTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPPNTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPHTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPPHTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[RoundingManualTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_RoundingManualTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traSalesReturn_IsDeleted]  DEFAULT ((0)), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesReturn_Remarks]  DEFAULT (''), " & vbNewLine & _
"	[StatusID] [int] NOT NULL CONSTRAINT [DF_traSalesReturn_StatusID]  DEFAULT ((0)), " & vbNewLine & _
"	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesReturn_SubmitBy]  DEFAULT (''), " & vbNewLine & _
"	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesReturn_SubmitDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[ApproveL1] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesReturn_ApproveL1]  DEFAULT (''), " & vbNewLine & _
"	[ApproveL1Date] [datetime] NOT NULL CONSTRAINT [DF_traSalesReturn_ApproveL1Date]  DEFAULT (getdate()), " & vbNewLine & _
"	[ApprovedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesReturn_ApprovedBy]  DEFAULT (''), " & vbNewLine & _
"	[ApprovedDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesReturn_ApprovedDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesReturn_CreatedBy]  DEFAULT ('SYSTEM'), " & vbNewLine & _
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesReturn_CreatedDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traSalesReturn_LogInc]  DEFAULT ((0)), " & vbNewLine & _
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesReturn_LogBy]  DEFAULT ('SYSTEM'), " & vbNewLine & _
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesReturn_LogDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[JournalID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturn_JournalID]  DEFAULT (''), " & vbNewLine & _
"	[DPAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traSalesReturn_DPAmount]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPayment] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPayment]  DEFAULT ((0)), " & vbNewLine & _
"	[CoAofStock] [int] NOT NULL CONSTRAINT [DF_traSalesReturn_CoAofStock]  DEFAULT ((0)), " & vbNewLine & _
"	[IsUseSubItem] [bit] NOT NULL CONSTRAINT [DF_traSalesReturnDet_IsUseSubItem]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_DPAmountPPN]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_DPAmountPPH]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPaymentPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPaymentPPN]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPaymentPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPaymentPPH]  DEFAULT ((0)), " & vbNewLine & _
"	[TransporterID] [int] NOT NULL CONSTRAINT [DF_traSalesReturn_TransporterID]  DEFAULT ((0)), " & vbNewLine & _
"	[PPNTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_PPNTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[PPHTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_PPHTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[IsFreePPNTransport] [bit] NOT NULL CONSTRAINT [DF_traSalesReturn_IsFreePPNTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[IsFreePPHTransport] [bit] NOT NULL CONSTRAINT [DF_traSalesReturn_IsFreePPHTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[UnitPriceTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_UnitPriceTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_DPAmountTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPaymentTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPaymentTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPNTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_DPAmountPPNTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPHTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_DPAmountPPHTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPaymentPPNTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPaymentPPNTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPaymentPPHTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturn_TotalPaymentPPHTransport]  DEFAULT ((0)), " & vbNewLine & _
"	CONSTRAINT [PK_traSalesReturn] PRIMARY KEY CLUSTERED  " & vbNewLine & _
"	( " & vbNewLine & _
"       [ID] ASC " & vbNewLine & _
"	) " & vbNewLine & _
") " & vbNewLine & _
"" & vbNewLine & _
"CREATE TABLE [dbo].[traSalesReturnDet]( " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ID]  DEFAULT (''), " & vbNewLine & _
"	[SalesReturnID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnDet_SalesReturnID]  DEFAULT (''), " & vbNewLine & _
"	[DeliveryDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnDet_DeliveryDetailID]  DEFAULT (''), " & vbNewLine & _
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traSalesReturnDet_ItemID]  DEFAULT ((0)), " & vbNewLine & _
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_Quantity]  DEFAULT ((0)), " & vbNewLine & _
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_Weight]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_TotalWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_UnitPrice]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_TotalPrice]  DEFAULT ((0)), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesReturnDet_Remarks]  DEFAULT (''), " & vbNewLine & _
"	[UnitPriceTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_UnitPriceTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_DPAmount]  DEFAULT ((0)), " & vbNewLine & _
"	[ReceiveAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ReceiveAmount]  DEFAULT ((0)), " & vbNewLine & _
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnDet_OrderNumberSupplier]  DEFAULT (''), " & vbNewLine & _
"	[TotalPriceTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_TotalPriceTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_DPAmountTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[ReceiveAmountTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ReceiveAmountTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traSalesReturnDet_LevelItem]  DEFAULT ((0)), " & vbNewLine & _
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ParentID]  DEFAULT (''), " & vbNewLine & _
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_RoundingWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_DPAmountPPN]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_DPAmountPPH]  DEFAULT ((0)), " & vbNewLine & _
"	[ReceiveAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ReceiveAmountPPN]  DEFAULT ((0)), " & vbNewLine & _
"	[ReceiveAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ReceiveAmountPPH]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPNTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_DPAmountPPNTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[DPAmountPPHTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_DPAmountPPHTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[ReceiveAmountPPNTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ReceiveAmountPPNTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[ReceiveAmountPPHTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_ReceiveAmountPPHTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[InvoiceQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_InvoiceQuantity]  DEFAULT ((0)), " & vbNewLine & _
"	[InvoiceWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_InvoiceWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[InvoiceTotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_InvoiceTotalWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[InvoiceQuantityTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_InvoiceQuantityTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[InvoiceWeightTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_InvoiceWeightTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[InvoiceTotalWeightTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_InvoiceTotalWeightTransport]  DEFAULT ((0)), " & vbNewLine & _
"	[AllocateDPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_AllocateDPAmount]  DEFAULT ((0)), " & vbNewLine & _
"	[AllocateDPAmountTransport] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesReturnDet_AllocateDPAmountTransport]  DEFAULT ((0)), " & vbNewLine & _
"	CONSTRAINT [PK_traSalesReturnDet] PRIMARY KEY CLUSTERED  " & vbNewLine & _
"	( " & vbNewLine & _
"       [ID] ASC " & vbNewLine & _
"	) " & vbNewLine & _
")  " & vbNewLine & _
"" & vbNewLine & _
"CREATE TABLE [dbo].[traSalesReturnStatus]( " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnStatus_ID]  DEFAULT (''), " & vbNewLine & _
"	[SalesReturnID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnStatus_SalesReturnID]  DEFAULT (''), " & vbNewLine & _
"	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesReturnStatus_Status]  DEFAULT (''), " & vbNewLine & _
"	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesReturnStatus_StatusBy]  DEFAULT (''), " & vbNewLine & _
"	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesReturnStatus_StatusDate]  DEFAULT (GETDATE()), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesReturnStatus_Remarks]  DEFAULT (''), " & vbNewLine & _
"	CONSTRAINT [PK_traSalesReturnStatus] PRIMARY KEY CLUSTERED  " & vbNewLine & _
"	( " & vbNewLine & _
"       [ID] ASC " & vbNewLine & _
"	) " & vbNewLine & _
") " & vbNewLine & _
"" & vbNewLine & _
"ALTER TABLE traDeliveryDet ADD ReturnQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReturnQuantity DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traDeliveryDet ADD ReturnWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traDeliveryDet_ReturnWeight DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traStockIn ADD CoAofStock [int] NOT NULL CONSTRAINT DF_traStockIn_CoAofStock DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traStockOut ADD CoAofStock [int] NOT NULL CONSTRAINT DF_traStockOut_CoAofStock DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 60
        Private Shared Sub DevelopOnProgress_ID60(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 60
            clsData.Name = "Alter Table Delivery Detail | Add Invoice Quantity dan Weight"
            clsData.Scripts =
                "ALTER TABLE traDelivery ADD CoAofStock [int] NOT NULL CONSTRAINT DF_traDelivery_CoAofStock DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traOrderRequest ADD CoAofStock [int] NOT NULL CONSTRAINT DF_traOrderRequest_CoAofStock DEFAULT ((0)) " & vbNewLine
            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 61
        Private Shared Sub DevelopOnProgress_ID61(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 61
            clsData.Name = "Alter Table Sales Return Detail | Add UnitPriceHPP"
            clsData.Scripts =
                "ALTER TABLE sysJournalPost ADD CoAOfSalesReturn [int] NOT NULL CONSTRAINT DF_sysJournalPost_CoAOfSalesReturn DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesReturn ADD TotalCostRawMaterial [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesReturn_TotalCostRawMaterial DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesReturnDet ADD UnitPriceHPP [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesReturnDet_UnitPriceHPP DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traSalesReturnDet ADD TotalPriceHPP [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesReturnDet_TotalPriceHPP DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 62
        Private Shared Sub DevelopOnProgress_ID62(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 62
            clsData.Name = "Alter Table PO Cutting Detail | Add Claim InvoiceWeight"
            clsData.Scripts =
                "ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimInvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimInvoiceQuantity DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimInvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimInvoiceWeight DEFAULT ((0)) " & vbNewLine &
                "ALTER TABLE traPurchaseOrderCuttingDet ADD ClaimInvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_ClaimInvoiceTotalWeight DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 63
        Private Shared Sub DevelopOnProgress_ID63(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 63
            clsData.Name = "Create Table Claim and Confirmation Claim"
            clsData.Scripts =
"ALTER TABLE traSalesContractDet ADD ClaimQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_ClaimQuantity DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traSalesContractDet ADD ClaimWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traSalesContractDet_ClaimWeight DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traReceiveDet ADD ClaimQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_ClaimQuantity DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traReceiveDet ADD ClaimWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traReceiveDet_ClaimWeight DEFAULT ((0)) " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traClaim]( " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaim_ID]  DEFAULT (''), " & vbNewLine &
"	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traClaim_ProgramID]  DEFAULT ((0)), " & vbNewLine &
"	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traClaim_CompanyID]  DEFAULT ((0)), " & vbNewLine &
"	[ClaimType] [int] NOT NULL CONSTRAINT [DF_traClaim_ClaimType]  DEFAULT ((0)), " & vbNewLine &
"	[ClaimNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traClaim_ClaimNumber]  DEFAULT (''), " & vbNewLine &
"	[ClaimDate] [datetime] NOT NULL CONSTRAINT [DF_traClaim_ClaimDate]  DEFAULT (getdate()), " & vbNewLine &
"	[BPID] [int] NOT NULL CONSTRAINT [DF_traClaim_BPID]  DEFAULT ((0)), " & vbNewLine &
"	[ReferencesID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaim_ReferencesID]  DEFAULT (''), " & vbNewLine &
"	[PlatNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traClaim_PlatNumber]  DEFAULT (''), " & vbNewLine &
"	[Driver] [varchar](100) NOT NULL CONSTRAINT [DF_traClaim_Driver]  DEFAULT (''), " & vbNewLine &
"	[ReferencesNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traClaim_ReferencesNumber]  DEFAULT (''), " & vbNewLine &
"	[PPN] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traClaim_PPN]  DEFAULT ((0)), " & vbNewLine &
"	[PPH] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traClaim_PPH]  DEFAULT ((0)), " & vbNewLine &
"	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_TotalQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_TotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_TotalDPP]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_TotalPPN]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_TotalPPH]  DEFAULT ((0)), " & vbNewLine &
"	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_RoundingManual]  DEFAULT ((0)), " & vbNewLine &
"	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traClaim_IsDeleted]  DEFAULT ((0)), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traClaim_Remarks]  DEFAULT (''), " & vbNewLine &
"	[StatusID] [int] NOT NULL CONSTRAINT [DF_traClaim_StatusID]  DEFAULT ((0)), " & vbNewLine &
"	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traClaim_SubmitBy]  DEFAULT (''), " & vbNewLine &
"	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traClaim_SubmitDate]  DEFAULT (getdate()), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traClaim_CreatedBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traClaim_CreatedDate]  DEFAULT (getdate()), " & vbNewLine &
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traClaim_LogInc]  DEFAULT ((0)), " & vbNewLine &
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traClaim_LogBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traClaim_LogDate]  DEFAULT (getdate()), " & vbNewLine &
"	[DPAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traClaim_DPAmount]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPayment] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traClaim_TotalPayment]  DEFAULT ((0)), " & vbNewLine &
"	[JournalID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaim_JournalID]  DEFAULT (''), " & vbNewLine &
"	[IsUseSubItem] [bit] NOT NULL CONSTRAINT [DF_traClaim_IsUseSubItem]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_DPAmountPPN]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_DPAmountPPH]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPaymentPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_TotalPaymentPPN]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPaymentPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaim_TotalPaymentPPH]  DEFAULT ((0)), " & vbNewLine &
"	CONSTRAINT [PK_traClaim] PRIMARY KEY CLUSTERED  " & vbNewLine &
"	( " & vbNewLine &
"       [ID] ASC " & vbNewLine &
"	) " & vbNewLine &
") " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traClaimDet]( " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimDet_ID]  DEFAULT (''), " & vbNewLine &
"	[ClaimID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimDet_ClaimID]  DEFAULT (''), " & vbNewLine &
"	[ReferencesDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimDet_ReferencesDetailID]  DEFAULT (''), " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traClaimDet_ItemID]  DEFAULT ((0)), " & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_Quantity]  DEFAULT ((0)), " & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_Weight]  DEFAULT ((0)), " & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_TotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_UnitPrice]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_TotalPrice]  DEFAULT ((0)), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traClaimDet_Remarks]  DEFAULT (''), " & vbNewLine &
"	[UnitPriceProduct] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_UnitPriceProduct]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPriceProduct] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_TotalPriceProduct]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_DPAmount]  DEFAULT ((0)), " & vbNewLine &
"	[ReceiveAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_ReceiveAmount]  DEFAULT ((0)), " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimDet_OrderNumberSupplier]  DEFAULT (''), " & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traClaimDet_LevelItem]  DEFAULT ((0)), " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimDet_ParentID]  DEFAULT (''), " & vbNewLine &
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_RoundingWeight]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_DPAmountPPN]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_DPAmountPPH]  DEFAULT ((0)), " & vbNewLine &
"	[ReceiveAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_ReceiveAmountPPN]  DEFAULT ((0)), " & vbNewLine &
"	[ReceiveAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_ReceiveAmountPPH]  DEFAULT ((0)), " & vbNewLine &
"	[InvoiceQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_InvoiceQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[InvoiceWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_InvoiceWeight]  DEFAULT ((0)), " & vbNewLine &
"	[InvoiceTotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_InvoiceTotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[AllocateDPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_AllocateDPAmount]  DEFAULT ((0)), " & vbNewLine &
"	[ConfirmationQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_ConfirmationQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[ConfirmationWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traClaimDet_ConfirmationWeight]  DEFAULT ((0)), " & vbNewLine &
"	CONSTRAINT [PK_traClaimDet] PRIMARY KEY CLUSTERED  " & vbNewLine &
"	( " & vbNewLine &
"       [ID] ASC " & vbNewLine &
"	) " & vbNewLine &
") " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traClaimStatus]( " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimStatus_ID]  DEFAULT (''), " & vbNewLine &
"	[ClaimID] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimStatus_ClaimID]  DEFAULT (''), " & vbNewLine &
"	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traClaimStatus_Status]  DEFAULT ((0)), " & vbNewLine &
"	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traClaimStatus_StatusBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traClaimStatus_StatusDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traClaimStatus_Remarks]  DEFAULT (''), " & vbNewLine &
"	CONSTRAINT [PK_traClaimStatus] PRIMARY KEY CLUSTERED  " & vbNewLine &
"	( " & vbNewLine &
"       [ID] ASC " & vbNewLine &
"	) " & vbNewLine &
") " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traConfirmationClaim]( " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaim_ID]  DEFAULT (''), " & vbNewLine &
"	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaim_ProgramID]  DEFAULT ((0)), " & vbNewLine &
"	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaim_CompanyID]  DEFAULT ((0)), " & vbNewLine &
"	[ClaimType] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaim_ClaimType]  DEFAULT ((0)), " & vbNewLine &
"	[ConfirmationClaimNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaim_ConfirmationClaimNumber]  DEFAULT (''), " & vbNewLine &
"	[ConfirmationClaimDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationClaim_ConfirmationClaimDate]  DEFAULT (getdate()), " & vbNewLine &
"	[BPID] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaim_BPID]  DEFAULT ((0)), " & vbNewLine &
"	[ClaimID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaim_ClaimID]  DEFAULT (''), " & vbNewLine &
"	[ReferencesNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaim_ReferencesNumber]  DEFAULT (''), " & vbNewLine &
"	[PPN] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traConfirmationClaim_PPN]  DEFAULT ((0)), " & vbNewLine &
"	[PPH] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traConfirmationClaim_PPH]  DEFAULT ((0)), " & vbNewLine &
"	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalDPP]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalPPN]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalPPH]  DEFAULT ((0)), " & vbNewLine &
"	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_RoundingManual]  DEFAULT ((0)), " & vbNewLine &
"	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traConfirmationClaim_IsDeleted]  DEFAULT ((0)), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traConfirmationClaim_Remarks]  DEFAULT (''), " & vbNewLine &
"	[StatusID] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaim_StatusID]  DEFAULT ((0)), " & vbNewLine &
"	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationClaim_SubmitBy]  DEFAULT (''), " & vbNewLine &
"	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationClaim_SubmitDate]  DEFAULT (getdate()), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationClaim_CreatedBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationClaim_CreatedDate]  DEFAULT (getdate()), " & vbNewLine &
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaim_LogInc]  DEFAULT ((0)), " & vbNewLine &
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationClaim_LogBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationClaim_LogDate]  DEFAULT (getdate()), " & vbNewLine &
"	[DPAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traConfirmationClaim_DPAmount]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPayment] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalPayment]  DEFAULT ((0)), " & vbNewLine &
"	[JournalID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaim_JournalID]  DEFAULT (''), " & vbNewLine &
"	[IsUseSubItem] [bit] NOT NULL CONSTRAINT [DF_traConfirmationClaim_IsUseSubItem]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_DPAmountPPN]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_DPAmountPPH]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPaymentPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalPaymentPPN]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPaymentPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaim_TotalPaymentPPH]  DEFAULT ((0)), " & vbNewLine &
"	CONSTRAINT [PK_traConfirmationClaim] PRIMARY KEY CLUSTERED  " & vbNewLine &
"	( " & vbNewLine &
"       [ID] ASC " & vbNewLine &
"	) " & vbNewLine &
") " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traConfirmationClaimDet]( " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ID]  DEFAULT (''), " & vbNewLine &
"	[ConfirmationClaimID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ConfirmationClaimID]  DEFAULT (''), " & vbNewLine &
"	[ClaimDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ClaimDetailID]  DEFAULT (''), " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ItemID]  DEFAULT ((0)), " & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_Quantity]  DEFAULT ((0)), " & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_Weight]  DEFAULT ((0)), " & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_TotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_UnitPrice]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_TotalPrice]  DEFAULT ((0)), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_Remarks]  DEFAULT (''), " & vbNewLine &
"	[UnitPriceProduct] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_UnitPriceProduct]  DEFAULT ((0)), " & vbNewLine &
"	[TotalPriceProduct] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_TotalPriceProduct]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_DPAmount]  DEFAULT ((0)), " & vbNewLine &
"	[ReceiveAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ReceiveAmount]  DEFAULT ((0)), " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_OrderNumberSupplier]  DEFAULT (''), " & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_LevelItem]  DEFAULT ((0)), " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ParentID]  DEFAULT (''), " & vbNewLine &
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_RoundingWeight]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_DPAmountPPN]  DEFAULT ((0)), " & vbNewLine &
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_DPAmountPPH]  DEFAULT ((0)), " & vbNewLine &
"	[ReceiveAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ReceiveAmountPPN]  DEFAULT ((0)), " & vbNewLine &
"	[ReceiveAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ReceiveAmountPPH]  DEFAULT ((0)), " & vbNewLine &
"	[InvoiceQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_InvoiceQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[InvoiceWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_InvoiceWeight]  DEFAULT ((0)), " & vbNewLine &
"	[InvoiceTotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_InvoiceTotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[AllocateDPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_AllocateDPAmount]  DEFAULT ((0)), " & vbNewLine &
"	[ConfirmationQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ConfirmationQuantity]  DEFAULT ((0)), " & vbNewLine &
"	[ConfirmationWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationClaimDet_ConfirmationWeight]  DEFAULT ((0)), " & vbNewLine &
"	CONSTRAINT [PK_traConfirmationClaimDet] PRIMARY KEY CLUSTERED  " & vbNewLine &
"	( " & vbNewLine &
"       [ID] ASC " & vbNewLine &
"	) " & vbNewLine &
") " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traConfirmationClaimStatus]( " & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimStatus_ID]  DEFAULT (''), " & vbNewLine &
"	[ConfirmationClaimID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimStatus_ConfirmationClaimID]  DEFAULT (''), " & vbNewLine &
"	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationClaimStatus_Status]  DEFAULT ((0)), " & vbNewLine &
"	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationClaimStatus_StatusBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationClaimStatus_StatusDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traConfirmationClaimStatus_Remarks]  DEFAULT (''), " & vbNewLine &
"	CONSTRAINT [PK_traConfirmationClaimStatus] PRIMARY KEY CLUSTERED  " & vbNewLine &
"	( " & vbNewLine &
"       [ID] ASC " & vbNewLine &
"	) " & vbNewLine &
") " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 64
        Private Shared Sub DevelopOnProgress_ID64(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 64
            clsData.Name = "Add References Number in Account Receivable and Account Payable"
            clsData.Scripts =
"ALTER TABLE traAccountReceivable ADD ReferencesNumber [varchar](5000) NOT NULL CONSTRAINT DF_traAccountReceivable_ReferencesNumber DEFAULT ('') " & vbNewLine &
"ALTER TABLE traAccountPayable ADD ReferencesNumber [varchar](5000) NOT NULL CONSTRAINT DF_traAccountPayable_ReferencesNumber DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 65
        Private Shared Sub DevelopOnProgress_ID65(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 65
            clsData.Name = "Add IsFullDP in Account Receivable and Account Payable"
            clsData.Scripts =
"ALTER TABLE traAccountReceivable ADD IsFullDP [bit] NOT NULL CONSTRAINT DF_traAccountReceivable_IsFullDP DEFAULT (0) " & vbNewLine &
"ALTER TABLE traAccountPayable ADD IsFullDP [bit] NOT NULL CONSTRAINT DF_traAccountPayable_IsFullDP DEFAULT (0) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 66
        Private Shared Sub DevelopOnProgress_ID66(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 66
            clsData.Name = "Add ReceiveDate in ARAP Invoice"
            clsData.Scripts = "ALTER TABLE traARAPInvoice ADD PaymentDate [datetime] NOT NULL CONSTRAINT DF_traARAPInvoice_PaymentDate DEFAULT (GETDATE()) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 67
        Private Shared Sub DevelopOnProgress_ID67(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 67
            clsData.Name = "Add ItemDescription in Claim"
            clsData.Scripts = "ALTER TABLE traClaim ADD ItemDescription [varchar](5000) NOT NULL CONSTRAINT DF_traClaim_ItemDescription DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 68
        Private Shared Sub DevelopOnProgress_ID68(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 68
            clsData.Name = "Add CoAofCompensasionRevenue and CoAofClaimCost in Claim"
            clsData.Scripts =
            "ALTER TABLE sysJournalPost ADD CoAofCompensasionRevenue INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofCompensasionRevenue DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE sysJournalPost ADD CoAofClaimCost INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofClaimCost DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 69
        Private Shared Sub DevelopOnProgress_ID69(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 69
            clsData.Name = "Create Table Remarks Result"
            clsData.Scripts += _
"CREATE TABLE [dbo].[traPurchaseOrderRemarksResult](  " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderRemarksResult_ID]  DEFAULT (''),  " & vbNewLine & _
"	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderRemarksResult_POID]  DEFAULT (''),  " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrderRemarksResult_Remarks]  DEFAULT (''),  " & vbNewLine & _
"   CONSTRAINT [PK_traPurchaseOrderRemarksResult] PRIMARY KEY CLUSTERED   " & vbNewLine & _
"   (  " & vbNewLine & _
"   	[ID] ASC  " & vbNewLine & _
"   )   " & vbNewLine & _
")  " & vbNewLine & _
"" & vbNewLine & _
"ALTER TABLE mstItem ADD RefID INT NOT NULL CONSTRAINT DF_mstItem_RefID DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 70
        Private Shared Sub DevelopOnProgress_ID70(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 70
            clsData.Name = "Add Invoice Information in traPurchaseOrderCuttingDetResult"
            clsData.Scripts =
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD DPAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_DPAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD DPAmountPPN DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD DPAmountPPH DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD ReceiveAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD ReceiveAmountPPN DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD ReceiveAmountPPH DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD AllocateDPAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_AllocateDPAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD UnitPrice DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_UnitPrice DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traPurchaseOrderCuttingDetResult ADD TotalPrice DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDetResult_TotalPrice DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 71
        Private Shared Sub CreateARAPInvoiceItem_ID71(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 71
            clsData.Name = "Create ARAP Invoice Item"
            clsData.Scripts =
"ALTER TABLE traARAPItem ADD InvoiceQuantity decimal(18,4) NOT NULL CONSTRAINT DF_traARAPItem_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traARAPItem ADD InvoiceWeight decimal(18,4) NOT NULL CONSTRAINT DF_traARAPItem_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traARAPItem ADD InvoiceTotalWeight decimal(18,4) NOT NULL CONSTRAINT DF_traARAPItem_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traARAPItem ADD TotalInvoiceAmount decimal(18,4) NOT NULL CONSTRAINT DF_traARAPItem_TotalInvoiceAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traARAPItem ADD TotalDPPInvoiceAmount decimal(18,4) NOT NULL CONSTRAINT DF_traARAPItem_TotalDPPInvoiceAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traARAPItem ADD TotalPPNInvoiceAmount decimal(18,4) NOT NULL CONSTRAINT DF_traARAPItem_TotalPPNInvoiceAmount DEFAULT ((0)) " & vbNewLine &
"ALTER TABLE traARAPItem ADD TotalPPHInvoiceAmount decimal(18,4) NOT NULL CONSTRAINT DF_traARAPItem_TotalPPHInvoiceAmount DEFAULT ((0)) " & vbNewLine &
"CREATE TABLE [dbo].[traARAPInvoiceItem](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_ID]  DEFAULT (''), " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_ParentID]  DEFAULT (''), " & vbNewLine &
"	[ReferencesID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_ReferencesID]  DEFAULT (''), " & vbNewLine &
"	[ReferencesDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_ReferencesDetailID]  DEFAULT (''), " & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_OrderNumberSupplier]  DEFAULT (''), " & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_ItemID]  DEFAULT ((0)), " & vbNewLine &
"	[Amount] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_Amount]  DEFAULT ((0)), " & vbNewLine &
"	[PPN] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_PPN]  DEFAULT ((0)), " & vbNewLine &
"	[PPH] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_PPH]  DEFAULT ((0)), " & vbNewLine &
"	[Rounding] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_Rounding]  DEFAULT ((0)), " & vbNewLine &
"	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_Quantity]  DEFAULT ((0)), " & vbNewLine &
"	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_Weight]  DEFAULT ((0)), " & vbNewLine &
"	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_TotalWeight]  DEFAULT ((0)), " & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_LevelItem]  DEFAULT ((0)), " & vbNewLine &
"	[ReferencesParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPInvoiceItem_ReferencesParentID]  DEFAULT (''), " & vbNewLine &
"   CONSTRAINT [PK_traARAPInvoiceItem] PRIMARY KEY CLUSTERED " & vbNewLine &
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

        '# ID = 72
        Private Shared Sub DevelopOnProgress_ID72(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 72
            clsData.Name = "Add Column GroupID and PickupDate in traPurchaseOrderRemarksResult and traCutting"
            clsData.Scripts =
            "ALTER TABLE traPurchaseOrderRemarksResult ADD GroupID INT NOT NULL CONSTRAINT DF_traPurchaseOrderRemarksResult_GroupID DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCutting ADD PickupDate DATETIME NOT NULL CONSTRAINT DF_traCutting_PickupDate DEFAULT ('2000/01/01') " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD InvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_InvoiceQuantity DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD InvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_InvoiceWeight DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD InvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_InvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD DPAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_DPAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD DPAmountPPN DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_DPAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD DPAmountPPH DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_DPAmountPPH DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD ReceiveAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_ReceiveAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD ReceiveAmountPPN DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_ReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD ReceiveAmountPPH DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_ReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD AllocateDPAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_AllocateDPAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD UnitPrice DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_UnitPrice DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDetResult ADD TotalPrice DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_TotalPrice DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimDPAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimDPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimDPAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimDPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimDPAmountPPH DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimReceiveAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimReceiveAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimReceiveAmountPPH DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimInvoiceQuantity [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimInvoiceQuantity DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimInvoiceWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimInvoiceWeight DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCuttingDet ADD ClaimInvoiceTotalWeight [decimal](18,4) NOT NULL CONSTRAINT DF_traCuttingDet_ClaimInvoiceTotalWeight DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCutting ADD ClaimDPAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_ClaimDPAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCutting ADD ClaimDPAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_ClaimDPAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCutting ADD ClaimDPAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_ClaimDPAmountPPH DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCutting ADD ClaimReceiveAmount [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_ClaimReceiveAmount DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCutting ADD ClaimReceiveAmountPPN [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_ClaimReceiveAmountPPN DEFAULT ((0)) " & vbNewLine &
            "ALTER TABLE traCutting ADD ClaimReceiveAmountPPH [decimal](18,4) NOT NULL CONSTRAINT DF_traCutting_ClaimReceiveAmountPPH DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 73
        Private Shared Sub DevelopOnProgress_ID73(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 73
            clsData.Name = "Add Column pic in traOrderRequest"
            clsData.Scripts = "ALTER TABLE traOrderRequest ADD PIC VARCHAR(250) NOT NULL CONSTRAINT DF_traOrderRequest_PIC DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 74
        Private Shared Sub DevelopOnProgress_ID74(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 74
            clsData.Name = "Add Column VoucherNumber and VoucherDate in traARAPInvoice"
            clsData.Scripts =
                "ALTER TABLE traARAPInvoice ADD VoucherNumber VARCHAR(100) NOT NULL CONSTRAINT DF_traARAPInvoice_VoucherNumber DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traARAPInvoice ADD VoucherDate DATETIME NOT NULL CONSTRAINT DF_traARAPInvoice_VoucherDate DEFAULT (GETDATE()) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 75
        Private Shared Sub DevelopOnProgress_ID75(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 75
            clsData.Name = "Add Column IsShowCoil in traPurchaseOrderCuttingDet"
            clsData.Scripts =
                "ALTER TABLE traPurchaseOrderCuttingDet ADD IsShowCoil BIT NOT NULL CONSTRAINT DF_traPurchaseOrderCuttingDet_IsShowCoil DEFAULT ((0)) " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 76
        Private Shared Sub DevelopOnProgress_ID76(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 76
            clsData.Name = "Add Column Address2 in mstCompany"
            clsData.Scripts = "ALTER TABLE mstCompany ADD Address2 VARCHAR(250) NOT NULL CONSTRAINT DF_mstCompany_Address2 DEFAULT ('') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 77
        Private Shared Sub DevelopOnProgress_ID77(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 77
            clsData.Name = "Create Table for Handle Split"
            clsData.Scripts =
"ALTER TABLE traSalesContractDet ADD SplitFrom VARCHAR(100) NOT NULL CONSTRAINT DF_traSalesContractDetSplit_SplitFrom DEFAULT ('') " & vbNewLine &
"ALTER TABLE traSalesContractDetConfirmationOrder ADD SplitFrom VARCHAR(100) NOT NULL CONSTRAINT DF_traSalesContractDetConfirmationOrder_SplitFrom DEFAULT ('') " & vbNewLine &
"ALTER TABLE traARAPItem ADD SplitFrom VARCHAR(100) NOT NULL CONSTRAINT DF_traARAPItem_SplitFrom DEFAULT ('') " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traSalesContractDetSplit](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ID]  DEFAULT ('')," & vbNewLine &
"	[SCID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_SCID]  DEFAULT ('')," & vbNewLine &
"	[ORDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ORDetailID]  DEFAULT ('')," & vbNewLine &
"	[GroupID] [int] NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_GroupID]  DEFAULT ((0))," & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ItemID]  DEFAULT ((0))," & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_Quantity]  DEFAULT ((0))," & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_Weight]  DEFAULT ((0))," & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_TotalWeight]  DEFAULT ((0))," & vbNewLine &
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_UnitPrice]  DEFAULT ((0))," & vbNewLine &
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_TotalPrice]  DEFAULT ((0))," & vbNewLine &
"	[DCQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_DCQuantity]  DEFAULT ((0))," & vbNewLine &
"	[DCWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_DCWeight]  DEFAULT ((0))," & vbNewLine &
"	[POTransportQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_POTransportQuantity]  DEFAULT ((0))," & vbNewLine &
"	[POTransportWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_POTransportWeight]  DEFAULT ((0))," & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_Remarks]  DEFAULT ('')," & vbNewLine &
"	[ReceiveAmount] [decimal](18, 4) NULL CONSTRAINT [DF_traSalesContractDetSplit_ReceiveAmount]  DEFAULT ((0))," & vbNewLine &
"	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_DPAmount]  DEFAULT ((0))," & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_OrderNumberSupplier]  DEFAULT ('')," & vbNewLine &
"	[IsIgnoreValidationPayment] [bit] NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_IsIgnoreValidationPayment]  DEFAULT ((0))," & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_LevelItem]  DEFAULT ((0))," & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ParentID]  DEFAULT ('')," & vbNewLine &
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_RoundingWeight]  DEFAULT ((0))," & vbNewLine &
"	[UnitPriceHPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_UnitPriceHPP]  DEFAULT ((0))," & vbNewLine &
"	[DPAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_DPAmountPPN]  DEFAULT ((0))," & vbNewLine &
"	[DPAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_DPAmountPPH]  DEFAULT ((0))," & vbNewLine &
"	[ReceiveAmountPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ReceiveAmountPPN]  DEFAULT ((0))," & vbNewLine &
"	[ReceiveAmountPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ReceiveAmountPPH]  DEFAULT ((0))," & vbNewLine &
"	[AllocateDPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_AllocateDPAmount]  DEFAULT ((0))," & vbNewLine &
"	[InvoiceQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_InvoiceQuantity]  DEFAULT ((0))," & vbNewLine &
"	[InvoiceWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_InvoiceWeight]  DEFAULT ((0))," & vbNewLine &
"	[InvoiceTotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_InvoiceTotalWeight]  DEFAULT ((0))," & vbNewLine &
"	[CODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_CODetailID]  DEFAULT ('')," & vbNewLine &
"	[PCDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_PCDetailID]  DEFAULT ('')," & vbNewLine &
"	[ClaimQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ClaimQuantity]  DEFAULT ((0))," & vbNewLine &
"	[ClaimWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetSplit_ClaimWeight]  DEFAULT ((0))," & vbNewLine &
"	CONSTRAINT [PK_traSalesContractDetSplit] PRIMARY KEY CLUSTERED " & vbNewLine &
"	(" & vbNewLine &
"		[ID] ASC" & vbNewLine &
"	)" & vbNewLine &
") " & vbNewLine &
"" & vbNewLine &
"CREATE TABLE [dbo].[traSalesContractDetConfirmationOrderSplit](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_ID]  DEFAULT ('')," & vbNewLine &
"	[SCID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_SCID]  DEFAULT ('')," & vbNewLine &
"	[CODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_CODetailID]  DEFAULT ('')," & vbNewLine &
"	[GroupID] [int] NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_GroupID]  DEFAULT ((0))," & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_ItemID]  DEFAULT ((0))," & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_Quantity]  DEFAULT ((0))," & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_Weight]  DEFAULT ((0))," & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_TotalWeight]  DEFAULT ((0))," & vbNewLine &
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_UnitPrice]  DEFAULT ((0))," & vbNewLine &
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_TotalPrice]  DEFAULT ((0))," & vbNewLine &
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_Remarks]  DEFAULT ('')," & vbNewLine &
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_RoundingWeight]  DEFAULT ((0))," & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_LevelItem]  DEFAULT ((0))," & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_ParentID]  DEFAULT ('')," & vbNewLine &
"	[LocationID] [int] NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_LocationID]  DEFAULT ((0))," & vbNewLine &
"	[PCDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDetConfirmationOrderSplit_PCDetailID]  DEFAULT ('')," & vbNewLine &
"	CONSTRAINT [PK_traSalesContractDetConfirmationOrderSplit] PRIMARY KEY CLUSTERED " & vbNewLine &
"	(" & vbNewLine &
"		[ID] ASC" & vbNewLine &
"	)" & vbNewLine &
")" & vbNewLine &
"" & vbNewLine &
"CREATE TABLE [dbo].[traARAPItemSplit](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItemSplit_ID]  DEFAULT ('')," & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItemSplit_ParentID]  DEFAULT ('')," & vbNewLine &
"	[ReferencesID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItemSplit_ReferencesID]  DEFAULT ('')," & vbNewLine &
"	[ReferencesDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItemSplit_ReferencesDetailID]  DEFAULT ('')," & vbNewLine &
"	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItemSplit_OrderNumberSupplier]  DEFAULT ('')," & vbNewLine &
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traARAPItemSplit_BPID]  DEFAULT ((0))," & vbNewLine &
"	[Amount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_Amount]  DEFAULT ((0))," & vbNewLine &
"	[PPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_PPN]  DEFAULT ((0))," & vbNewLine &
"	[PPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_PPH]  DEFAULT ((0))," & vbNewLine &
"	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_DPAmount]  DEFAULT ((0))," & vbNewLine &
"	[Rounding] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_Rounding]  DEFAULT ((0))," & vbNewLine &
"	[LevelItem] [int] NOT NULL CONSTRAINT [DF_traARAPItemSplit_LevelItem]  DEFAULT ((0))," & vbNewLine &
"	[ReferencesParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPItemSplit_ReferencesParentID]  DEFAULT ('')," & vbNewLine &
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_Quantity]  DEFAULT ((0))," & vbNewLine &
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_Weight]  DEFAULT ((0))," & vbNewLine &
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_TotalWeight]  DEFAULT ((0))," & vbNewLine &
"	[InvoiceQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_InvoiceQuantity]  DEFAULT ((0))," & vbNewLine &
"	[InvoiceWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_InvoiceWeight]  DEFAULT ((0))," & vbNewLine &
"	[InvoiceTotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_InvoiceTotalWeight]  DEFAULT ((0))," & vbNewLine &
"	[TotalInvoiceAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_TotalInvoiceAmount]  DEFAULT ((0))," & vbNewLine &
"	[TotalDPPInvoiceAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_TotalDPPInvoiceAmount]  DEFAULT ((0))," & vbNewLine &
"	[TotalPPNInvoiceAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_TotalPPNInvoiceAmount]  DEFAULT ((0))," & vbNewLine &
"	[TotalPPHInvoiceAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traARAPItemSplit_TotalPPHInvoiceAmount]  DEFAULT ((0))," & vbNewLine &
"	CONSTRAINT [PK_traARAPItemSplit] PRIMARY KEY CLUSTERED " & vbNewLine &
"	(" & vbNewLine &
"		[ID] ASC" & vbNewLine &
"	)" & vbNewLine &
")" & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 78
        Private Shared Sub DevelopOnProgress_ID78(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 78
            clsData.Name = "Create Table Sales Confirmation Order"
            clsData.Scripts =
"CREATE TABLE [dbo].[traSalesConfirmationOrder]( " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_ID]  DEFAULT (''), " & vbNewLine & _
"	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_ProgramID]  DEFAULT ((0)), " & vbNewLine & _
"	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_CompanyID]  DEFAULT ((0)), " & vbNewLine & _
"	[CONumber] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_CONumber]  DEFAULT (''), " & vbNewLine & _
"	[CODate] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_CODate]  DEFAULT (getdate()), " & vbNewLine & _
"	[BPID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_BPID]  DEFAULT ((0)), " & vbNewLine & _
"	[DeliveryPeriodFrom] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DeliveryPeriodFrom]  DEFAULT (getdate()), " & vbNewLine & _
"	[DeliveryPeriodTo] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DeliveryPeriodTo]  DEFAULT (getdate()), " & vbNewLine & _
"	[PPN] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_PPN]  DEFAULT ((0)), " & vbNewLine & _
"	[PPH] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_PPH]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_TotalQuantity]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_TotalWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_TotalDPP]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_TotalPPN]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_TotalPPH]  DEFAULT ((0)), " & vbNewLine & _
"	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_RoundingManual]  DEFAULT ((0)), " & vbNewLine & _
"	[DelegationSeller] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DelegationSeller]  DEFAULT (''), " & vbNewLine & _
"	[DelegationPositionSeller] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DelegationPositionSeller]  DEFAULT (''), " & vbNewLine & _
"	[DelegationBuyer] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DelegationBuyer]  DEFAULT (''), " & vbNewLine & _
"	[DelegationPositionBuyer] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DelegationPositionBuyer]  DEFAULT (''), " & vbNewLine & _
"	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_IsDeleted]  DEFAULT ((0)), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_Remarks]  DEFAULT (''), " & vbNewLine & _
"	[StatusID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_StatusID]  DEFAULT ((0)), " & vbNewLine & _
"	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_SubmitBy]  DEFAULT (''), " & vbNewLine & _
"	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_SubmitDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[ApproveL1] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_ApproveL1]  DEFAULT (''), " & vbNewLine & _
"	[ApproveL1Date] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_ApproveL1Date]  DEFAULT (getdate()), " & vbNewLine & _
"	[ApprovedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_ApprovedBy]  DEFAULT (''), " & vbNewLine & _
"	[ApprovedDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_ApprovedDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_CreatedBy]  DEFAULT ('SYSTEM'), " & vbNewLine & _
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_CreatedDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[LogInc] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_LogInc]  DEFAULT ((0)), " & vbNewLine & _
"	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_LogBy]  DEFAULT ('SYSTEM'), " & vbNewLine & _
"	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_LogDate]  DEFAULT (getdate()), " & vbNewLine & _
"	[IsDone] [bit] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_IsDone]  DEFAULT ((0)), " & vbNewLine & _
"	[DoneBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DoneBy]  DEFAULT (''), " & vbNewLine & _
"	[DoneDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrder_DoneDate]  DEFAULT (getdate()), " & vbNewLine & _
"	CONSTRAINT [PK_traSalesConfirmationOrder] PRIMARY KEY CLUSTERED  " & vbNewLine & _
"	( " & vbNewLine & _
"[ID] ASC " & vbNewLine & _
"	) " & vbNewLine & _
") " & vbNewLine & _
" " & vbNewLine & _
"CREATE TABLE [dbo].[traSalesConfirmationOrderDet]( " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_ID]  DEFAULT (''), " & vbNewLine & _
"	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_COID]  DEFAULT (''), " & vbNewLine & _
"	[ORDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_ORDetailID]  DEFAULT (''), " & vbNewLine & _
"	[PODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_PODetailID]  DEFAULT (''), " & vbNewLine & _
"	[ItemID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_ItemID]  DEFAULT ((0)), " & vbNewLine & _
"	[Quantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_Quantity]  DEFAULT ((0)), " & vbNewLine & _
"	[Weight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_Weight]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_TotalWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[UnitPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_UnitPrice]  DEFAULT ((0)), " & vbNewLine & _
"	[TotalPrice] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_TotalPrice]  DEFAULT ((0)), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_Remarks]  DEFAULT (''), " & vbNewLine & _
"	[RoundingWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_RoundingWeight]  DEFAULT ((0)), " & vbNewLine & _
"	[ItemMin] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_ItemMin]  DEFAULT ((0)), " & vbNewLine & _
"	[ItemMax] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_ItemMax]  DEFAULT ((0)), " & vbNewLine & _
"	[ItemTolerances] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_ItemTolerances]  DEFAULT ((0)), " & vbNewLine & _
"	[LocationID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderDet_LocationID]  DEFAULT ((0)), " & vbNewLine & _
"	CONSTRAINT [PK_traSalesConfirmationOrderDet] PRIMARY KEY CLUSTERED  " & vbNewLine & _
"	( " & vbNewLine & _
"[ID] ASC " & vbNewLine & _
"	) " & vbNewLine & _
") " & vbNewLine & _
" " & vbNewLine & _
"CREATE TABLE [dbo].[traSalesConfirmationOrderPaymentTerm]( " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderPaymentTerm_ID]  DEFAULT (''), " & vbNewLine & _
"	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderPaymentTerm_COID]  DEFAULT (''), " & vbNewLine & _
"	[Percentage] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderPaymentTerm_Percentage]  DEFAULT ((0)), " & vbNewLine & _
"	[PaymentTypeID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderPaymentTerm_PaymentTypeID]  DEFAULT ((0)), " & vbNewLine & _
"	[PaymentModeID] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderPaymentTerm_PaymentModeID]  DEFAULT ((0)), " & vbNewLine & _
"	[CreditTerm] [int] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderPaymentTerm_CreditTerm]  DEFAULT ((0)), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderPaymentTerm_Remarks]  DEFAULT ((0)), " & vbNewLine & _
"	CONSTRAINT [PK_traSalesConfirmationOrderPaymentTerm] PRIMARY KEY CLUSTERED  " & vbNewLine & _
"	( " & vbNewLine & _
"[ID] ASC " & vbNewLine & _
"	) " & vbNewLine & _
") " & vbNewLine & _
" " & vbNewLine & _
"CREATE TABLE [dbo].[traSalesConfirmationOrderStatus]( " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderStatus_ID]  DEFAULT (''), " & vbNewLine & _
"	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderStatus_COID]  DEFAULT (''), " & vbNewLine & _
"	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderStatus_Status]  DEFAULT ((0)), " & vbNewLine & _
"	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderStatus_StatusBy]  DEFAULT ((0)), " & vbNewLine & _
"	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderStatus_StatusDate]  DEFAULT ((0)), " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesConfirmationOrderStatus_Remarks]  DEFAULT ((0)), " & vbNewLine & _
"	CONSTRAINT [PK_traSalesConfirmationOrderStatus] PRIMARY KEY CLUSTERED  " & vbNewLine & _
"	( " & vbNewLine & _
"[ID] ASC " & vbNewLine & _
"	) " & vbNewLine & _
") " & vbNewLine & _
"" & vbNewLine & _
"ALTER TABLE traPurchaseOrderDet ADD SCOQuantity DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderDet_SCOQuantity DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traPurchaseOrderDet ADD SCOWeight DECIMAL(18,4) NOT NULL CONSTRAINT DF_traPurchaseOrderDet_SCOWeight DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequestDet ADD SCOQuantity DECIMAL(18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_SCOQuantity DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequestDet ADD SCOWeight DECIMAL(18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_SCOWeight DEFAULT ((0))  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 79
        Private Shared Sub DevelopOnProgress_ID79(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 79
            clsData.Name = "Development On Progress 79 | Enchance Order Request to use Receive Payment"
            clsData.Scripts =
"ALTER TABLE traOrderRequestDet ADD InvoiceQuantity DECIMAL(18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_InvoiceQuantity DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequestDet ADD InvoiceWeight DECIMAL(18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_InvoiceWeight DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequestDet ADD InvoiceTotalWeight DECIMAL(18,4) NOT NULL CONSTRAINT DF_traOrderRequestDet_InvoiceTotalWeight DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequestDet ADD LevelItem INT NOT NULL CONSTRAINT DF_traOrderRequestDet_LevelItem DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequestDet ADD ParentID VARCHAR(100) NOT NULL CONSTRAINT DF_traOrderRequestDet_ParentID DEFAULT ('')  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm1 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm1 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm2 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm2 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm3 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm3 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm4 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm4 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm5 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm5 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm6 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm6 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm7 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm7 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm8 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm8 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm9 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm9 DEFAULT ((0))  " & vbNewLine & _
"ALTER TABLE traOrderRequest ADD AdditionalTerm10 VARCHAR(5000) NOT NULL CONSTRAINT DF_traOrderRequest_AdditionalTerm10 DEFAULT ((0))  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 80
        Private Shared Sub DevelopOnProgress_ID80(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 80
            clsData.Name = "Development On Progress 80"
            clsData.Scripts =
                "ALTER TABLE traSalesReturn ADD JournalIDTransport VARCHAR(100) NOT NULL CONSTRAINT DF_traSalesReturn_JournalIDTransport DEFAULT ('')  " & vbNewLine &
                "UPDATE sysAppVersion SET Version='1.0.0.53' " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 81
        Private Shared Sub DevelopOnProgress_ID81(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 81
            clsData.Name = "Development On Progress 81"
            clsData.Scripts =
                "ALTER TABLE traAccountPayable ADD IsGenerate BIT NOT NULL CONSTRAINT DF_traAccountPayable_IsGenerate DEFAULT (0)  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD IsGenerate BIT NOT NULL CONSTRAINT DF_traAccountReceivable_IsGenerate DEFAULT (0)  " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD UnitPriceClaim DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_UnitPriceClaim DEFAULT (0)  " & vbNewLine &
                "ALTER TABLE traCuttingDet ADD TotalPriceClaim DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDet_TotalPriceClaim DEFAULT (0)  " & vbNewLine &
                "ALTER TABLE traCuttingDetResult ADD UnitPriceClaim DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_UnitPriceClaim DEFAULT (0)  " & vbNewLine &
                "ALTER TABLE traCuttingDetResult ADD TotalPriceClaim DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCuttingDetResult_TotalPriceClaim DEFAULT (0)  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 82
        Private Shared Sub DevelopOnProgress_ID82(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 82
            clsData.Name = "Development On Progress 82"
            clsData.Scripts =
                "ALTER TABLE traCost ADD PaidTo VARCHAR(250) NOT NULL CONSTRAINT DF_traCost_PaidTo DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traCost ADD PaidAccount VARCHAR(250) NOT NULL CONSTRAINT DF_traCost_PaidAccount DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traCostDet ADD ReceiveDate DATETIME NOT NULL CONSTRAINT DF_traCostDet_ReceiveDate DEFAULT (GETDATE())  " & vbNewLine &
                "ALTER TABLE traCostDet ADD InvoiceDate DATETIME NOT NULL CONSTRAINT DF_traCostDet_InvoiceDate DEFAULT (GETDATE())  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 83
        Private Shared Sub DevelopOnProgress_ID83(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 83
            clsData.Name = "Development On Progress 83"
            clsData.Scripts =
                "ALTER TABLE traCost ADD TotalDPP DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCost_TotalDPP DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traCost ADD TotalPPN DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCost_TotalPPN DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traCost ADD TotalPPH DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCost_TotalPPH DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traCostDet ADD PPNAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCostDet_PPNAmount DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traCostDet ADD PPHAmount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCostDet_PPHAmount DEFAULT ((0))  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 84
        Private Shared Sub DevelopOnProgress_ID84(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 84
            clsData.Name = "Development On Progress 84"
            clsData.Scripts =
"ALTER TABLE traAccountPayableDet ADD ReceiveDate DATETIME NOT NULL CONSTRAINT DF_traAccountPayableDet_ReceiveDate DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traAccountPayableDet ADD InvoiceDate DATETIME NOT NULL CONSTRAINT DF_traAccountPayableDet_InvoiceDate DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traAccountReceivableDet ADD ReceiveDate DATETIME NOT NULL CONSTRAINT DF_traAccountReceivableDet_ReceiveDate DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traAccountReceivableDet ADD InvoiceDate DATETIME NOT NULL CONSTRAINT DF_traAccountReceivableDet_InvoiceDate DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traDelivery ADD TotalDiscountTransport DECIMAL(18,4) NOT NULL CONSTRAINT DF_traDelivery_TotalDiscountTransport DEFAULT ((0))  " & vbNewLine &
"ALTER TABLE traCutting ADD TotalDiscount DECIMAL(18,4) NOT NULL CONSTRAINT DF_traCutting_TotalDiscount DEFAULT ((0))  " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traARAPRemarks](  " & vbNewLine & _
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPRemarks_ID]  DEFAULT (''),  " & vbNewLine & _
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPRemarks_ParentID]  DEFAULT (''),  " & vbNewLine & _
"	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traARAPRemarks_Remarks]  DEFAULT (''),  " & vbNewLine & _
"   CONSTRAINT [PK_traARAPRemarks] PRIMARY KEY CLUSTERED   " & vbNewLine & _
"   (  " & vbNewLine & _
"   	[ID] ASC  " & vbNewLine & _
"   )   " & vbNewLine & _
")  " & vbNewLine & _
"" & vbNewLine 

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 85
        Private Shared Sub DevelopOnProgress_ID85(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 85
            clsData.Name = "Development On Progress 85"
            clsData.Scripts =
"ALTER TABLE traAccountPayable ADD BPBankAccountID INT NOT NULL CONSTRAINT DF_traAccountPayable_BPBankAccountID DEFAULT ((0))  " & vbNewLine &
"ALTER TABLE traAccountPayable ADD InvoiceDateBP DATETIME NOT NULL CONSTRAINT DF_traAccountPayable_InvoiceDateBP DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traAccountPayable ADD ReceiveDateInvoice DATETIME NOT NULL CONSTRAINT DF_traAccountPayable_ReceiveDateInvoice DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traAccountReceivable ADD BPBankAccountID INT NOT NULL CONSTRAINT DF_traAccountReceivable_BPBankAccountID DEFAULT ((0))  " & vbNewLine &
"ALTER TABLE traAccountReceivable ADD InvoiceDateBP DATETIME NOT NULL CONSTRAINT DF_traAccountReceivable_InvoiceDateBP DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traAccountReceivable ADD ReceiveDateInvoice DATETIME NOT NULL CONSTRAINT DF_traAccountReceivable_ReceiveDateInvoice DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traDelivery ADD IsManualTransportPrice BIT NOT NULL CONSTRAINT DF_traDelivery_IsManualTransportPrice DEFAULT ((0))  " & vbNewLine &
"ALTER TABLE traSalesReturn ADD IsManualTransportPrice BIT NOT NULL CONSTRAINT DF_traSalesReturn_IsManualTransportPrice DEFAULT ((0))  " & vbNewLine &
"ALTER TABLE traCostDet ADD InvoiceNumberBP VARCHAR(1000) NOT NULL CONSTRAINT DF_traCostDet_InvoiceNumberBP DEFAULT ('')  " & vbNewLine &
"ALTER TABLE traAccountPayableDet ADD InvoiceNumberBP VARCHAR(1000) NOT NULL CONSTRAINT DF_traAccountPayableDet_InvoiceNumberBP DEFAULT ('')  " & vbNewLine &
"ALTER TABLE traAccountReceivableDet ADD InvoiceNumberBP VARCHAR(1000) NOT NULL CONSTRAINT DF_traAccountReceivableDet_InvoiceNumberBP DEFAULT ('')  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 86
        Private Shared Sub DevelopOnProgress_ID86(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 86
            clsData.Name = "Development On Progress 86"
            clsData.Scripts =
"ALTER TABLE traARAPItem ADD InvoiceDateBP DATETIME NOT NULL CONSTRAINT DF_traARAPItem_InvoiceDateBP DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traARAPItem ADD ReceiveDateInvoice DATETIME NOT NULL CONSTRAINT DF_traARAPItem_ReceiveDateInvoice DEFAULT (GETDATE())  " & vbNewLine &
"ALTER TABLE traARAPItem ADD InvoiceNumberBP VARCHAR(1000) NOT NULL CONSTRAINT DF_traARAPItem_InvoiceNumberBP DEFAULT ('')  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 87
        Private Shared Sub DevelopOnProgress_ID87(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 87
            clsData.Name = "Alter Chart of Account"
            clsData.Scripts =
"ALTER TABLE mstChartOfAccount ADD ProgramID INT NOT NULL CONSTRAINT DF_mstChartOfAccount_ProgramID DEFAULT ((0))  " & vbNewLine &
"ALTER TABLE mstChartOfAccount ADD CompanyID INT NOT NULL CONSTRAINT DF_mstChartOfAccount_CompanyID DEFAULT ((0))  " & vbNewLine &
"" & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 88
        Private Shared Sub DevelopOnProgress_ID88(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 88
            clsData.Name = "Alter Default Journal Post"
            clsData.Scripts = "ALTER TABLE sysJournalPost ADD CompanyID INT NOT NULL CONSTRAINT DF_sysJournalPost_CompanyID DEFAULT ((0))  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 89
        Private Shared Sub CreateARAPVoucher_ID89(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 89
            clsData.Name = "Create ARAP Voucher"
            clsData.Scripts =
"CREATE TABLE [dbo].[mstVoucherType](" & vbNewLine &
"	[ID] [int] NOT NULL CONSTRAINT [DF_mstVoucherType_ID]  DEFAULT ((0)), " & vbNewLine &
"	[Name] [varchar](250) NOT NULL CONSTRAINT [DF_mstVoucherType_Name]  DEFAULT (''), " & vbNewLine &
"	[Remarks] [varchar](5000) NOT NULL CONSTRAINT [DF_mstVoucherType_Remarks]  DEFAULT (''), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstVoucherType_CreatedBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstVoucherType_CreatedDate]  DEFAULT (GETDATE()), " & vbNewLine &
"   CONSTRAINT [PK_mstVoucherType] PRIMARY KEY CLUSTERED " & vbNewLine &
"   (" & vbNewLine &
"   	[ID] ASC" & vbNewLine &
"   ) " & vbNewLine &
") " & vbNewLine &
" " & vbNewLine &
"CREATE TABLE [dbo].[traARAPVoucher](" & vbNewLine &
"	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPVoucher_ID]  DEFAULT (''), " & vbNewLine &
"	[TransDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPVoucher_TransDate]  DEFAULT (GETDATE()), " & vbNewLine &
"	[VoucherType] [int] NOT NULL CONSTRAINT [DF_traARAPVoucher_VoucherType]  DEFAULT (''), " & vbNewLine &
"	[ParentID] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPVoucher_ParentID]  DEFAULT (''), " & vbNewLine &
"	[InvoiceNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traARAPVoucher_InvoiceNumber]  DEFAULT (''), " & vbNewLine &
"	[CoAID] [int] NOT NULL CONSTRAINT [DF_traARAPVoucher_CoAID]  DEFAULT ((0)), " & vbNewLine &
"	[TotalAmount] [decimal](18,4) NOT NULL CONSTRAINT [DF_traARAPVoucher_TotalAmount]  DEFAULT ((0)), " & vbNewLine &
"	[Remarks] [varchar](5000) NOT NULL CONSTRAINT [DF_traARAPVoucher_Remarks]  DEFAULT (''), " & vbNewLine &
"	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traARAPVoucher_CreatedBy]  DEFAULT ('SYSTEM'), " & vbNewLine &
"	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traARAPVoucher_CreatedDate]  DEFAULT (GETDATE()), " & vbNewLine &
"   CONSTRAINT [PK_traARAPVoucher] PRIMARY KEY CLUSTERED " & vbNewLine &
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

        '# ID = 90
        Private Shared Sub DevelopOnProgress_ID90(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 90
            clsData.Name = "Add Rounding in Account Payable and Account Receivable"
            clsData.Scripts =
                "ALTER TABLE traAccountPayable ADD Rounding DECIMAL(18,4) NOT NULL CONSTRAINT DF_traAccountPayable_Rounding DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD Rounding DECIMAL(18,4) NOT NULL CONSTRAINT DF_traAccountReceivable_Rounding DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE sysJournalPost ADD CoAofRounding INT NOT NULL CONSTRAINT DF_sysJournalPost_CoAofRounding DEFAULT ((0))  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 91
        Private Shared Sub DevelopOnProgress_ID91(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 91
            clsData.Name = "Add Rounding in ARAP Invoice"
            clsData.Scripts =
                "ALTER TABLE traARAPInvoice ADD Rounding DECIMAL(18,4) NOT NULL CONSTRAINT DF_traARAPInvoice_Rounding DEFAULT ((0))  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 92
        Private Shared Sub DevelopOnProgress_ID92(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 92
            clsData.Name = "Insert Data Voucher Type"
            clsData.Scripts =
                "ALTER TABLE traARAPVoucher ADD ProgramID INT NOT NULL CONSTRAINT DF_traARAPVoucher_ProgramID DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traARAPVoucher ADD CompanyID INT NOT NULL CONSTRAINT DF_traARAPVoucher_CompanyID DEFAULT ((0))  " & vbNewLine &
                "ALTER TABLE traARAPVoucher ADD VoucherNumber VARCHAR(100) NOT NULL CONSTRAINT DF_traARAPVoucher_VoucherNumber DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE mstVoucherType ADD Initial VARCHAR(100) NOT NULL CONSTRAINT DF_mstVoucherType_Initial DEFAULT ('')  " & vbNewLine 

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 93
        Private Shared Sub DevelopOnProgress_ID93(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 93
            clsData.Name = "Insert Data Voucher Type"
            clsData.Scripts =
                "INSERT INTO mstVoucherType (ID, Name, Initial) VALUES (1, 'BANK IN', 'BI') " & vbNewLine &
                "INSERT INTO mstVoucherType (ID, Name, Initial) VALUES (2, 'BANK OUT', 'BO') " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub

        '# ID = 94
        Private Shared Sub DevelopOnProgress_ID94(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
            Dim clsData As New VO.Migration
            clsData.ID = 94
            clsData.Name = "Add Voucher Number and Voucher Date"
            clsData.Scripts =
                "ALTER TABLE traAccountPayable ADD VoucherNumber VARCHAR(100) NOT NULL CONSTRAINT DF_traAccountPayable_VoucherNumber DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountPayable ADD VoucherDate DATEIME NOT NULL CONSTRAINT DF_traAccountPayable_VoucherDate DEFAULT (GETDATE())  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD VoucherNumber VARCHAR(100) NOT NULL CONSTRAINT DF_traAccountReceivable_VoucherNumber DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traAccountReceivable ADD VoucherDate DATEIME NOT NULL CONSTRAINT DF_traAccountReceivable_VoucherDate DEFAULT (GETDATE())  " & vbNewLine &
                "ALTER TABLE traCost ADD VoucherNumber VARCHAR(100) NOT NULL CONSTRAINT DF_traCost_VoucherNumber DEFAULT ('')  " & vbNewLine &
                "ALTER TABLE traCost ADD VoucherDate DATEIME NOT NULL CONSTRAINT DF_traCost_VoucherDate DEFAULT (GETDATE())  " & vbNewLine

            clsData.LogBy = ERPSLib.UI.usUserApp.UserID
            If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
                DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
                DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
            End If
        End Sub
    End Class
End Namespace