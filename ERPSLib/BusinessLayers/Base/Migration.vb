Namespace BL
    Public Class Migration
        Public Shared Sub Migrate()
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                CreateTableMigration(sqlCon, Nothing)
                AddColumnPCIDInTableConfirmationOrderAddJournalIDAndTotalPayemntInTableReceive_ID1(sqlCon, Nothing)
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
            clsData.Name = "Add Column Contract ID In Table Confirmation Order"
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

    End Class
End Namespace