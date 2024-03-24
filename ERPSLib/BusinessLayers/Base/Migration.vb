Namespace BL
    Public Class Migration
        Public Shared Sub Migrate()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                CreateTableMigration(sqlCon, Nothing)
                AddColumnPCIDInTableConfirmationOrderAddJournalIDAndTotalPayemntInTableReceive_ID1(sqlCon, Nothing)
                AddColumnIsAutoGenerateInTablePurchaseContract_ID2(sqlCon, Nothing)
                DevelopARAPForUsingDownPayment_ID3(sqlCon, Nothing)
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
                "ALTER TABLE traReceive ADD JournalID VARCHAR(100) NOT NULL CONSTRAINT DF_traReceive_JournalID DEFAULT ('') " & vbNewLine &
                "ALTER TABLE traReceive ADD TotalPayment DECIMAL(18,2) NOT NULL CONSTRAINT DF_traReceive_TotalPayment DEFAULT ((0)) " & vbNewLine
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
                "ALTER TABLE traPurchaseContract ADD IsAutoGenerate BIT NOT NULL CONSTRAINT DF_traPurchaseContract_IsAutoGenerate DEFAULT ((0)) " & vbNewLine
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
                "ALTER TABLE traReceive ADD TotalPayment DECIMAL(18,2) NOT NULL CONSTRAINT DF_traReceive_TotalPayment DEFAULT ((0)) " & vbNewLine &
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

    End Class
End Namespace