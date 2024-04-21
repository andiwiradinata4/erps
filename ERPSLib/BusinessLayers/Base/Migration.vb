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

        ''# ID = 10
        'Private Shared Sub AlterTableTraJournalDet_ID10(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
        '    Dim clsData As New VO.Migration
        '    clsData.ID = 10
        '    clsData.Name = "Alter Table traJournalDet"
        '    clsData.Scripts = "ALTER TABLE traJournalDet ADD GroupID INT NOT NULL CONSTRAINT DF_traJournalDet_GroupID DEFAULT ((0)) " & vbNewLine

        '    clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        '    If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
        '        DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
        '        DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
        '    End If
        'End Sub

        ''# ID = 11
        'Private Shared Sub AddBPIDAndReferencesNoInJournalAndBukuBesar_ID11(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction)
        '    Dim clsData As New VO.Migration
        '    clsData.ID = 10
        '    clsData.Name = "Alter Table traJournalDet"
        '    clsData.Scripts = "ALTER TABLE traJournalDet ADD BPID INT NOT NULL CONSTRAINT DF_traJournalDet_BPID DEFAULT ((0)) " & vbNewLine &
        '        "ALTER TABLE traBukuBesar ADD BPID INT NOT NULL CONSTRAINT DF_traBukuBesar_BPID DEFAULT ((0)) " & vbNewLine &
        '        "ALTER TABLE traJournal ADD ReferencesNo VARCHAR(100) NOT NULL CONSTRAINT DF_traJournal_ReferencesNo DEFAULT ('') " & vbNewLine

        '    clsData.LogBy = ERPSLib.UI.usUserApp.UserID
        '    If Not DL.Migration.IsIDExists(sqlCon, sqlTrans, clsData.ID) Then
        '        DL.Migration.ExecuteScripts(sqlCon, sqlTrans, clsData.Scripts)
        '        DL.Migration.SaveData(sqlCon, sqlTrans, clsData)
        '    End If
        'End Sub

    End Class
End Namespace