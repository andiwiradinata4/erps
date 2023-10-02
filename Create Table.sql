USE [ERPS]
GO
/****** Object:  Table [dbo].[mstAccess]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstAccess](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstAccess_ID]  DEFAULT ((0)),
	[Name] [varchar](50) NOT NULL CONSTRAINT [DF_mstAccess_Name]  DEFAULT (''),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_mstAccess_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstAccess_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstAccess_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstAccess_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstAccess_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstAccess_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstAccess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstCompany]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstCompany](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstCompany_ID]  DEFAULT ((0)),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_mstCompany_Name]  DEFAULT (''),
	[Address] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompany_Address]  DEFAULT (''),
	[Country] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompany_Country]  DEFAULT (''),
	[Province] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompany_Province]  DEFAULT (''),
	[City] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompany_City]  DEFAULT (''),
	[Warehouse] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompany_Warehouse]  DEFAULT (''),
	[PhoneNumber] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompany_PhoneNumber]  DEFAULT (''),
	[CompanyInitial] [varchar](3) NOT NULL CONSTRAINT [DF_mstCompany_CompanyInitial]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstCompany_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstCompany_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstCompany_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstCompany_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstCompany_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstCompany_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[mstCompanyBankAccount]    Script Date: 07/09/2023 17:43:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[mstCompanyBankAccount](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_ID]  DEFAULT ((0)),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_CompanyID]  DEFAULT ((0)),
	[AccountName] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_AccountName]  DEFAULT (''),
	[BankName] [varchar](500) NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_BankName]  DEFAULT (''),
	[AccountNumber] [varchar](150) NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_AccountNumber]  DEFAULT (''),
	[Currency] [varchar](100) NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_Currency]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_StatusID]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_Remarks]  DEFAULT (''),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstCompanyBankAccount_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstCompanyBankAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstModules]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstModules](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstModules_ID]  DEFAULT ((0)),
	[Name] [varchar](50) NOT NULL CONSTRAINT [DF_mstModules_Name]  DEFAULT (''),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_mstModules_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstModules_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstModules_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstModules_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstModules_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstModules_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstModulesAccess]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstModulesAccess](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstModulesAccess_ID]  DEFAULT ((0)),
	[ModulesID] [int] NOT NULL CONSTRAINT [DF_mstModulesAccess_ModulesID]  DEFAULT ((0)),
	[AccessID] [int] NOT NULL CONSTRAINT [DF_mstModulesAccess_AccessID]  DEFAULT ((0)),
 CONSTRAINT [PK_mstModulesAccess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mstPaymentType]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstPaymentType](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstPaymentType_ID]  DEFAULT ((0)),
	[Code] [varchar](100) NOT NULL CONSTRAINT [DF_mstPaymentType_Code]  DEFAULT (''),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_mstPaymentType_Name]  DEFAULT (''),
	[PaymentTypeCategoryID] [int] NOT NULL CONSTRAINT [DF_mstPaymentType_PaymentTypeCategoryID]  DEFAULT ((0)),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstPaymentType_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstPaymentType_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstPaymentType_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstPaymentType_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstPaymentType_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstPaymentType_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstPaymentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
GO
/****** Object:  Table [dbo].[mstPaymentTypeCategory]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstPaymentTypeCategory](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_ID]  DEFAULT ((0)),
	[Code] [varchar](100) NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_Code]  DEFAULT (''),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_Name]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstPaymentTypeCategory_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstPaymentTypeCategory_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstPaymentTypeCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstPaymentMode]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstPaymentMode](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstPaymentMode_ID]  DEFAULT ((0)),
	[Code] [varchar](100) NOT NULL CONSTRAINT [DF_mstPaymentMode_Code]  DEFAULT (''),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_mstPaymentMode_Name]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstPaymentMode_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstPaymentMode_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstPaymentMode_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstPaymentMode_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstPaymentMode_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstPaymentMode_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstPaymentMode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstProgram]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstProgram](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstProgram_ID]  DEFAULT ((0)),
	[Name] [varchar](50) NOT NULL CONSTRAINT [DF_mstProgram_Name]  DEFAULT (''),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_mstProgram_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstProgram_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstProgram_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstProgram_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstProgram_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstProgram_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstProgram] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstProgramModules]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstProgramModules](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstProgramModules_ID]  DEFAULT ((0)),
	[ModulesID] [int] NOT NULL CONSTRAINT [DF_mstProgramModules_ModulesID]  DEFAULT ((0)),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_mstProgramModules_ProgramID]  DEFAULT ((0)),
 CONSTRAINT [PK_mstProgramModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mstStatus]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstStatus](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstStatus_ID]  DEFAULT ((0)),
	[Name] [varchar](50) NOT NULL CONSTRAINT [DF_mstStatus_Name]  DEFAULT (''),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_mstStatus_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstStatus_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstStatus_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstStatus_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstStatus_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstStatus_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstStatusModules]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstStatusModules](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstStatusModules_ID]  DEFAULT ((0)),
	[ModulesID] [int] NOT NULL CONSTRAINT [DF_mstStatusModules_ModulesID]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstStatusModules_StatusID]  DEFAULT ((0)),
 CONSTRAINT [PK_mstStatusModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mstUOM]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstUOM](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstUOM_ID]  DEFAULT ((0)),
	[Code] [varchar](10) NOT NULL CONSTRAINT [DF_mstUOM_Code]  DEFAULT (''),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_mstUOM_Name]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstUOM_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstUOM_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstUOM_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstUOM_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstUOM_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstUOM_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstUOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstUser]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstUser](
	[ID] [varchar](20) NOT NULL CONSTRAINT [DF_mstUser_ID]  DEFAULT ((0)),
	[StaffID] [varchar](20) NOT NULL CONSTRAINT [DF_mstUser_StaffID]  DEFAULT (''),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_mstUser_Name]  DEFAULT (''),
	[Password] [nvarchar](250) NOT NULL CONSTRAINT [DF_mstUser_Password]  DEFAULT (''),
	[Position] [varchar](100) NOT NULL CONSTRAINT [DF_mstUser_Position]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstUser_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstUser_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstUser_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstUser_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstUser_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NULL CONSTRAINT [DF_mstUser_LogInc]  DEFAULT ((0)),
	[IsSuperUser] [bit] NOT NULL CONSTRAINT [DF_mstUser_IsSuperUser]  DEFAULT ((0)),
	[IsFirstCreated] [bit] NOT NULL CONSTRAINT [DF_mstUser_IsFirstCreated]  DEFAULT ((0)),
 CONSTRAINT [PK_mstUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstUserAccess]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstUserAccess](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstUserAccess_ID]  DEFAULT ((0)),
	[UserID] [varchar](20) NOT NULL CONSTRAINT [DF_mstUserAccess_UserID]  DEFAULT (''),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_mstUserAccess_ProgramID]  DEFAULT ((0)),
	[ModulesID] [int] NOT NULL CONSTRAINT [DF_mstUserAccess_ModulesID]  DEFAULT ((0)),
	[AccessID] [int] NOT NULL CONSTRAINT [DF_mstUserAccess_AccessID]  DEFAULT ((0)),
 CONSTRAINT [PK_mstUserAccess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mstUserCompany]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstUserCompany](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstUserCompany_ID]  DEFAULT ((0)),
	[UserID] [varchar](20) NOT NULL CONSTRAINT [DF_mstUserCompany_UserID]  DEFAULT (''),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_mstUserCompany_CompanyID]  DEFAULT ((0)),
 CONSTRAINT [PK_mstUserCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sysJournalPost]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sysJournalPost](
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_ProgramID]  DEFAULT ((0)),
	[CoAofRevenue] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofRevenue]  DEFAULT ((0)),
	[CoAofAccountReceivable] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofAccountReceivable]  DEFAULT ((0)),
	[CoAofSalesDisc] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofSalesDisc]  DEFAULT ((0)),
	[CoAofPrepaidIncome] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofPrepaidIncome]  DEFAULT ((0)),
	[CoAofCOGS] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofCOGS]  DEFAULT ((0)),
	[CoAofStock] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofStock]  DEFAULT ((0)),
	[CoAofCash] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofCash]  DEFAULT ((0)),
	[CoAofAccountPayable] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofAccountPayable]  DEFAULT ((0)),
	[CoAofPurchaseDisc] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofPurchaseDisc]  DEFAULT ((0)),
	[CoAofPurchaseEquipments] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofPurchaseEquipments]  DEFAULT ((0)),
	[CoAofAdvancePayment] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofAdvancePayment]  DEFAULT ((0)),
	[CoAofSalesTax] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofSalesTax]  DEFAULT ((0)),
	[CoAofPurchaseTax] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_CoAofPurchaseTax]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_sysJournalPost_Remarks]  DEFAULT (''),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_sysJournalPost_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_sysJournalPost_CreatedDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_sysJournalPost_LogInc]  DEFAULT ((0)),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_sysJournalPost_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_sysJournalPost_LogDate]  DEFAULT (getdate())
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[mstBusinessPartner]    Script Date: 07/09/2023 17:43:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[mstBusinessPartner](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartner_ID]  DEFAULT ((0)),
	[Code] [varchar](10) NOT NULL CONSTRAINT [DF_mstBusinessPartner_Code]  DEFAULT (''),
	[Name] [varchar](250) NOT NULL CONSTRAINT [DF_mstBusinessPartner_Name]  DEFAULT (''),
	[Address] [varchar](500) NOT NULL CONSTRAINT [DF_mstBusinessPartner_Address]  DEFAULT (''),
	[PICName] [varchar](150) NOT NULL CONSTRAINT [DF_mstBusinessPartner_PICName]  DEFAULT (''),
	[PICPhoneNumber] [varchar](100) NOT NULL CONSTRAINT [DF_mstBusinessPartner_PICPhoneNumber]  DEFAULT (''),
	[APBalance] [decimal](18, 2) NOT NULL CONSTRAINT [DF_mstBusinessPartner_APBalance]  DEFAULT ((0)),
	[ARBalance] [decimal](18, 2) NOT NULL CONSTRAINT [DF_mstBusinessPartner_ARBalance]  DEFAULT ((0)),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartner_StatusID]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_mstBusinessPartner_Remarks]  DEFAULT (''),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstBusinessPartner_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstBusinessPartner_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstBusinessPartner_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstBusinessPartner_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartner_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstBusinessPartner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[mstBusinessPartnerBankAccount]    Script Date: 07/09/2023 17:43:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[mstBusinessPartnerBankAccount](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_ID]  DEFAULT ((0)),
	[BPID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_BPID]  DEFAULT ((0)),
	[AccountName] [varchar](250) NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_AccountName]  DEFAULT (''),
	[BankName] [varchar](500) NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_BankName]  DEFAULT (''),
	[AccountNumber] [varchar](150) NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_AccountNumber]  DEFAULT (''),
	[Currency] [varchar](100) NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_Currency]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_StatusID]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_Remarks]  DEFAULT (''),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstBusinessPartnerBankAccount_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstBusinessPartnerBankAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
GO
/****** Object:  Table [dbo].[mstItemType]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstItemType](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstItemType_ID]  DEFAULT ((0)),
	[Description] [varchar](500) NOT NULL CONSTRAINT [DF_mstItemType_Description]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstItemType_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstItemType_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstItemType_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstItemType_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstItemType_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstItemType_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstItemType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
GO
/****** Object:  Table [dbo].[mstItemType]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstItemSpecification](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstItemSpecification_ID]  DEFAULT ((0)),
	[Description] [varchar](500) NOT NULL CONSTRAINT [DF_mstItemSpecification_Description]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstItemSpecification_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstItemSpecification_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstItemSpecification_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstItemSpecification_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstItemSpecification_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstItemSpecification_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstItemSpecification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
GO
/****** Object:  Table [dbo].[mstItem]    Script Date: 07/09/2023 17:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mstItem](
	[ID] [int] NOT NULL CONSTRAINT [DF_mstItem_ID]  DEFAULT ((0)),
	[ItemCode] [varchar](100) NOT NULL CONSTRAINT [DF_mstItem_ItemCode]  DEFAULT (''),
	[ItemName] [varchar](500) NOT NULL CONSTRAINT [DF_mstItem_ItemName]  DEFAULT (''),
	[ItemTypeID] [int] NOT NULL CONSTRAINT [DF_mstItem_ItemTypeID]  DEFAULT ((0)),
	[ItemSpecificationID] [int] NOT NULL CONSTRAINT [DF_mstItem_ItemSpecificationID]  DEFAULT ((0)),
	[Thick] [decimal](18,2) NOT NULL CONSTRAINT [DF_mstItem_Thick]  DEFAULT ((0)),
	[Width] [decimal](18,2) NOT NULL CONSTRAINT [DF_mstItem_Width]  DEFAULT ((0)),
	[Length] [decimal](18,2) NOT NULL CONSTRAINT [DF_mstItem_Length]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_mstItem_Weight]  DEFAULT ((0)),
	[BasePrice] [decimal](18,2) NOT NULL CONSTRAINT [DF_mstItem_BasePrice]  DEFAULT ((0)),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_mstItem_StatusID]  DEFAULT ((0)),
	[Remarks] [varchar](500) NOT NULL CONSTRAINT [DF_mstItem_Remarks]  DEFAULT (''),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstItem_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_mstItem_CreatedDate]  DEFAULT (getdate()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_mstItem_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_mstItem_LogDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_mstItem_LogInc]  DEFAULT ((0)),
 CONSTRAINT [PK_mstItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

GO
/****** Object:  Table [dbo].[mstChartOfAccount]    Script Date: 9/22/2022 7:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccount](
	[ID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccount_ID]  DEFAULT ((0)),
	[AccountGroupID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccount_AccountGroupID]  DEFAULT ((0)),
	[Code] [varchar](10) NOT NULL CONSTRAINT [DF_traChartOfAccount_Code]  DEFAULT (''),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_traChartOfAccount_Name]  DEFAULT (''),
	[FirstBalance] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traChartOfAccount_FirstBalance]  DEFAULT ((0)),
	[FirstBalanceDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccount_FirstBalanceDate]  DEFAULT ('2000/01/01'),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccount_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traChartOfAccount_CreatedBy]  DEFAULT (''),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccount_CreatedDate]  DEFAULT (GETDATE()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traChartOfAccount_LogBy]  DEFAULT (''),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccount_LogDate]  DEFAULT (GETDATE()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_traChartOfAccount_LogInc]  DEFAULT ((0)),
	[Initial] [varchar](10) NOT NULL CONSTRAINT [DF_traChartOfAccount_Initial]  DEFAULT (''),
 CONSTRAINT [PK_mstChartOfAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mstChartOfAccountAssign]    Script Date: 9/22/2022 7:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccountAssign](
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountAssign_CompanyID]  DEFAULT ((0)),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountAssign_ProgramID]  DEFAULT ((0)),
	[ID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountAssign_ID]  DEFAULT ((0)),
	[COAID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountAssign_COAID]  DEFAULT ((0)),
	[FirstBalance] [decimal](18, 2) NOT NULL CONSTRAINT [DF_traChartOfAccountAssign_FirstBalance]  DEFAULT ((0)),
	[FirstBalanceDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccountAssign_FirstBalanceDate]  DEFAULT ('2000/01/01'),
 CONSTRAINT [PK_mstChartOfAccountAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mstChartOfAccountGroup]    Script Date: 9/22/2022 7:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccountGroup](
	[ID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_ID]  DEFAULT ((0)),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_Name]  DEFAULT (''),
	[COAType] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_COAType]  DEFAULT ((0)),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_StatusID]  DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_CreatedBy]  DEFAULT (''),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_CreatedDate]  DEFAULT (GETDATE()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_LogBy]  DEFAULT (''),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_LogDate]  DEFAULT (GETDATE()),
	[LogInc] [int] NULL CONSTRAINT [DF_traChartOfAccountGroup_LogInc]  DEFAULT ((0)),
	[AliasName] [varchar](100) NOT NULL CONSTRAINT [DF_traChartOfAccountGroup_AliasName] DEFAULT (''),
 CONSTRAINT [PK_mstChartOfAccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mstChartOfAccountType]    Script Date: 9/22/2022 7:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccountType](
	[ID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountType_ID] DEFAULT ((0)),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_traChartOfAccountType_Name] DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traChartOfAccountType_StatusID] DEFAULT ((0)),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traChartOfAccountType_CreatedBy] DEFAULT (''),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccountType_CreatedDate] DEFAULT (GETDATE()),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traChartOfAccountType_LogBy] DEFAULT (''),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traChartOfAccountType_LogDate] DEFAULT (GETDATE()),
	[LogInc] [int] NULL CONSTRAINT [DF_traChartOfAccountType_LogInc] DEFAULT ((0)),
 CONSTRAINT [PK_mstChartOfAccountType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

GO

/****** Object:  Table [dbo].[traOrderRequest]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traOrderRequest](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequest_ID]  DEFAULT (''),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traOrderRequest_ProgramID]  DEFAULT ((0)),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traOrderRequest_CompanyID]  DEFAULT ((0)),
	[OrderNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequest_OrderNumber]  DEFAULT (('')),
	[OrderDate] [datetime] NOT NULL CONSTRAINT [DF_traOrderRequest_OrderDate]  DEFAULT (getdate()),
	[BPID] [int] NOT NULL CONSTRAINT [DF_traOrderRequest_BPID]  DEFAULT ((0)),
	[ReferencesNumber] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequest_ReferencesNumber]  DEFAULT (('')),
	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequest_TotalQuantity]  DEFAULT ((0)),
	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traOrderRequest_TotalWeight]  DEFAULT ((0)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traOrderRequest_IsDeleted]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequest_Remarks]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traOrderRequest_StatusID]  DEFAULT ((0)),
	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traOrderRequest_SubmitBy]  DEFAULT (''),
	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traOrderRequest_SubmitDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traOrderRequest_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traOrderRequest_CreatedDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_traOrderRequest_LogInc]  DEFAULT ((0)),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traOrderRequest_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traOrderRequest_LogDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_traOrderRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traOrderRequestDet]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traOrderRequestDet](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDet_ID]  DEFAULT (''),
	[OrderRequestID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestDet_OrderRequestID]  DEFAULT (''),
	[ItemID] [int] NOT NULL CONSTRAINT [DF_traOrderRequestDet_ItemID]  DEFAULT ((0)),
	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traOrderRequestDet_Quantity]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traOrderRequestDet_Weight]  DEFAULT ((0)),
	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traOrderRequestDet_TotalWeight]  DEFAULT ((0)),
	[POInternalQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traOrderRequestDet_POInternalQuantity]  DEFAULT ((0)),
	[POInternalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traOrderRequestDet_POInternalWeight]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequestDet_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_traOrderRequestDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traOrderRequestStatus]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traOrderRequestStatus](
	[ID] [varchar](30) NOT NULL CONSTRAINT [DF_traOrderRequestStatus_ID]  DEFAULT (''),
	[OrderRequestID] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestStatus_OrderRequestID]  DEFAULT (''),
	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traOrderRequestStatus_Status]  DEFAULT ((0)),
	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traOrderRequestStatus_StatusBy]  DEFAULT ((0)),
	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traOrderRequestStatus_StatusDate]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traOrderRequestStatus_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traOrderRequestStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseOrder]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseOrder](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrder_ID]  DEFAULT (''),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrder_ProgramID]  DEFAULT ((0)),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrder_CompanyID]  DEFAULT ((0)),
	[PONumber] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrder_PONumber]  DEFAULT (('')),
	[PODate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_PODate]  DEFAULT (getdate()),
	[OrderRequestID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrder_OrderRequestID]  DEFAULT (''),
	[BPID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrder_BPID]  DEFAULT ((0)),
	[PersonInCharge] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrder_PersonInCharge]  DEFAULT (''),
	[DeliveryPeriodFrom] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_DeliveryPeriodFrom]  DEFAULT (getdate()),
	[DeliveryPeriodTo] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_DeliveryPeriodTo]  DEFAULT (getdate()),
	[DeliveryAddress] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrder_DeliveryAddress]  DEFAULT (('')),
	[Validity] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrder_Validity]  DEFAULT (('')),
	[PPN] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseOrder_PPN]  DEFAULT ((0)),
	[PPH] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseOrder_PPH]  DEFAULT ((0)),
	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalQuantity]  DEFAULT ((0)),
	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalWeight]  DEFAULT ((0)),
	[TotalInternalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalInternalQuantity]  DEFAULT ((0)),
	[TotalInternalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalInternalWeight]  DEFAULT ((0)),
	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalDPP]  DEFAULT ((0)),
	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalPPN]  DEFAULT ((0)),
	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalPPH]  DEFAULT ((0)),
	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_RoundingManual]  DEFAULT ((0)),
	[TotalInternalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalInternalDPP]  DEFAULT ((0)),
	[TotalInternalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalInternalPPN]  DEFAULT ((0)),
	[TotalInternalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrder_TotalInternalPPH]  DEFAULT ((0)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traPurchaseOrder_IsDeleted]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrder_Remarks]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrder_StatusID]  DEFAULT ((0)),
	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrder_SubmitBy]  DEFAULT (''),
	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_SubmitDate]  DEFAULT (getdate()),
	[ApproveL1] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrder_ApproveL1]  DEFAULT (''),
	[ApproveL1Date] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_ApproveL1Date]  DEFAULT (getdate()),
	[ApprovedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrder_ApprovedBy]  DEFAULT (''),
	[ApprovedDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_ApprovedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrder_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_CreatedDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrder_LogInc]  DEFAULT ((0)),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrder_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrder_LogDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_traPurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseOrderDet]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseOrderDet](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_ID]  DEFAULT (''),
	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_POID]  DEFAULT (''),
	[OrderRequestDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_OrderRequestDetailID]  DEFAULT (''),
	[GroupID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_GroupID]  DEFAULT ((0)),
	[ItemID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_ItemID]  DEFAULT ((0)),
	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_Quantity]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_Weight]  DEFAULT ((0)),
	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_TotalWeight]  DEFAULT ((0)),
	[UnitPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_UnitPrice]  DEFAULT ((0)),
	[CuttingPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_CuttingPrice]  DEFAULT ((0)),
	[TransportPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_TransportPrice]  DEFAULT ((0)),
	[TotalPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_TotalPrice]  DEFAULT ((0)),
	[CuttingQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_CuttingQuantity]  DEFAULT ((0)),
	[CuttingWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_CuttingWeight]  DEFAULT ((0)),
	[TransportQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_TransportQuantity]  DEFAULT ((0)),
	[TransportWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_TransportWeight]  DEFAULT ((0)),
	[COQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_COQuantity]  DEFAULT ((0)),
	[COWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_COWeight]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrderDet_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_traPurchaseOrderDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseOrderDetInternal]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseOrderDetInternal](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_ID]  DEFAULT (''),
	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_POID]  DEFAULT (''),
	[OrderRequestDetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_OrderRequestDetailID]  DEFAULT (''),
	[GroupID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_GroupID]  DEFAULT ((0)),
	[ItemID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_ItemID]  DEFAULT ((0)),
	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_Quantity]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_Weight]  DEFAULT ((0)),
	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_TotalWeight]  DEFAULT ((0)),
	[UnitPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_UnitPrice]  DEFAULT ((0)),
	[CuttingPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_CuttingPrice]  DEFAULT ((0)),
	[TransportPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_TransportPrice]  DEFAULT ((0)),
	[TotalPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_TotalPrice]  DEFAULT ((0)),
	[SalesContractQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_SalesContractQuantity]  DEFAULT ((0)),
	[SalesContractWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_SalesContractWeight]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrderDetInternal_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_traPurchaseOrderDetInternal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseOrderPaymentTerm]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseOrderPaymentTerm](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderPaymentTerm_ID]  DEFAULT (''),
	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderPaymentTerm_POID]  DEFAULT (''),
	[Percentage] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseOrderPaymentTerm_Percentage]  DEFAULT ((0)),
	[PaymentTypeID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderPaymentTerm_PaymentTypeID]  DEFAULT ((0)),
	[PaymentModeID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderPaymentTerm_PaymentModeID]  DEFAULT ((0)),
	[CreditTerm] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderPaymentTerm_CreditTerm]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrderPaymentTerm_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traPurchaseOrderPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseOrderStatus]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseOrderStatus](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderStatus_ID]  DEFAULT (''),
	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderStatus_OrderRequestID]  DEFAULT (''),
	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderStatus_Status]  DEFAULT ((0)),
	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrderStatus_StatusBy]  DEFAULT ((0)),
	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderStatus_StatusDate]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrderStatus_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traPurchaseOrderStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


GO

/****** Object:  Table [dbo].[traPurchaseOrderCutting]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseOrderCutting](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_ID]  DEFAULT (''),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_ProgramID]  DEFAULT ((0)),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_CompanyID]  DEFAULT ((0)),
	[PONumber] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_PONumber]  DEFAULT (('')),
	[PODate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_PODate]  DEFAULT (getdate()),
	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_POID]  DEFAULT (''),
	[BPID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_BPID]  DEFAULT ((0)),
	[PersonInCharge] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_PersonInCharge]  DEFAULT (''),
	[DeliveryPeriodFrom] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_DeliveryPeriodFrom]  DEFAULT (getdate()),
	[DeliveryPeriodTo] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_DeliveryPeriodTo]  DEFAULT (getdate()),
	[PPN] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_PPN]  DEFAULT ((0)),
	[PPH] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_PPH]  DEFAULT ((0)),
	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_TotalQuantity]  DEFAULT ((0)),
	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_TotalWeight]  DEFAULT ((0)),
	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_TotalDPP]  DEFAULT ((0)),
	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_TotalPPN]  DEFAULT ((0)),
	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_TotalPPH]  DEFAULT ((0)),
	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_RoundingManual]  DEFAULT ((0)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_IsDeleted]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_Remarks]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_StatusID]  DEFAULT ((0)),
	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_SubmitBy]  DEFAULT (''),
	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_SubmitDate]  DEFAULT (getdate()),
	[ApproveL1] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_ApproveL1]  DEFAULT (''),
	[ApproveL1Date] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_ApproveL1Date]  DEFAULT (getdate()),
	[ApprovedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_ApprovedBy]  DEFAULT (''),
	[ApprovedDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_ApprovedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_CreatedDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_LogInc]  DEFAULT ((0)),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseOrderCutting_LogDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_traPurchaseOrderCutting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseOrderCuttingDet]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseOrderCuttingDet](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_ID]  DEFAULT (''),
	[POID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_POID]  DEFAULT (''),
	[PODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_PODetailID]  DEFAULT (''),
	[ItemID] [int] NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_ItemID]  DEFAULT ((0)),
	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_Quantity]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_Weight]  DEFAULT ((0)),
	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_TotalWeight]  DEFAULT ((0)),
	[UnitPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_UnitPrice]  DEFAULT ((0)),
	[TotalPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_TotalPrice]  DEFAULT ((0)),
	[SPKQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_SPKQuantity]  DEFAULT ((0)),
	[SPKWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_SPKWeight]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseOrderCuttingDet_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_traPurchaseOrderCuttingDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traConfirmationOrder]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traConfirmationOrder](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrder_ID]  DEFAULT (''),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrder_ProgramID]  DEFAULT ((0)),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrder_CompanyID]  DEFAULT ((0)),
	[CONumber] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrder_CONumber]  DEFAULT (('')),
	[CODate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationOrder_CODate]  DEFAULT (getdate()),
	[BPID] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrder_BPID]  DEFAULT ((0)),
	[DeliveryPeriodFrom] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationOrder_DeliveryPeriodFrom]  DEFAULT (getdate()),
	[DeliveryPeriodTo] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationOrder_DeliveryPeriodTo]  DEFAULT (getdate()),
	[AllowanceProduction] [decimal](18,2) NOT NULL CONSTRAINT [DF_traConfirmationOrder_AllowanceProduction]  DEFAULT ((0)),
	[PPN] [decimal](18,2) NOT NULL CONSTRAINT [DF_traConfirmationOrder_PPN]  DEFAULT ((0)),
	[PPH] [decimal](18,2) NOT NULL CONSTRAINT [DF_traConfirmationOrder_PPH]  DEFAULT ((0)),
	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationOrder_TotalQuantity]  DEFAULT ((0)),
	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationOrder_TotalWeight]  DEFAULT ((0)),
	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationOrder_TotalDPP]  DEFAULT ((0)),
	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationOrder_TotalPPN]  DEFAULT ((0)),
	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationOrder_TotalPPH]  DEFAULT ((0)),
	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traConfirmationOrder_RoundingManual]  DEFAULT ((0)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traConfirmationOrder_IsDeleted]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traConfirmationOrder_Remarks]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrder_StatusID]  DEFAULT ((0)),
	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationOrder_SubmitBy]  DEFAULT (''),
	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationOrder_SubmitDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationOrder_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationOrder_CreatedDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrder_LogInc]  DEFAULT ((0)),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationOrder_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationOrder_LogDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_traConfirmationOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traConfirmationOrderDet]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traConfirmationOrderDet](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_ID]  DEFAULT (''),
	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_COID]  DEFAULT (''),
	[PODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_PODetailID]  DEFAULT (''),
	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_OrderNumberSupplier]  DEFAULT (''),
	[DeliveryAddress] [varchar](1000) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_DeliveryAddress]  DEFAULT (''),
	[ItemID] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_ItemID]  DEFAULT ((0)),
	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_Quantity]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_Weight]  DEFAULT ((0)),
	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_TotalWeight]  DEFAULT ((0)),
	[UnitPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_UnitPrice]  DEFAULT ((0)),
	[TotalPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_TotalPrice]  DEFAULT ((0)),
	[PCQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_PCQuantity]  DEFAULT ((0)),
	[PCWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_PCWeight]  DEFAULT ((0)),
	[DCQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_DCQuantity]  DEFAULT ((0)),
	[DCWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_DCWeight]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traConfirmationOrderDet_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_traConfirmationOrderDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traConfirmationOrderPaymentTerm]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traConfirmationOrderPaymentTerm](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderPaymentTerm_ID]  DEFAULT (''),
	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderPaymentTerm_COID]  DEFAULT (''),
	[Percentage] [decimal](18,2) NOT NULL CONSTRAINT [DF_traConfirmationOrderPaymentTerm_Percentage]  DEFAULT ((0)),
	[PaymentTypeID] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrderPaymentTerm_PaymentTypeID]  DEFAULT ((0)),
	[PaymentModeID] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrderPaymentTerm_PaymentModeID]  DEFAULT ((0)),
	[CreditTerm] [int] NOT NULL CONSTRAINT [DF_traConfirmationOrderPaymentTerm_CreditTerm]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traConfirmationOrderPaymentTerm_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traConfirmationOrderPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traConfirmationOrderStatus]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traConfirmationOrderStatus](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderStatus_ID]  DEFAULT (''),
	[COID] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderStatus_COID]  DEFAULT (''),
	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traConfirmationOrderStatus_Status]  DEFAULT ((0)),
	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traConfirmationOrderStatus_StatusBy]  DEFAULT ((0)),
	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traConfirmationOrderStatus_StatusDate]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traConfirmationOrderStatus_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traConfirmationOrderStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseContract]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseContract](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContract_ID]  DEFAULT (''),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traPurchaseContract_ProgramID]  DEFAULT ((0)),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traPurchaseContract_CompanyID]  DEFAULT ((0)),
	[PCNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContract_PCNumber]  DEFAULT (('')),
	[PCDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_PCDate]  DEFAULT (getdate()),
	[BPID] [int] NOT NULL CONSTRAINT [DF_traPurchaseContract_BPID]  DEFAULT ((0)),
	[DeliveryPeriodFrom] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_DeliveryPeriodFrom]  DEFAULT (getdate()),
	[DeliveryPeriodTo] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_DeliveryPeriodTo]  DEFAULT (getdate()),
	[AllowanceProduction] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseContract_AllowanceProduction]  DEFAULT ((0)),
	[Franco] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseContract_Franco]  DEFAULT (''),
	[PPN] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseContract_PPN]  DEFAULT ((0)),
	[PPH] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseContract_PPH]  DEFAULT ((0)),
	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_TotalQuantity]  DEFAULT ((0)),
	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_TotalWeight]  DEFAULT ((0)),
	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_TotalDPP]  DEFAULT ((0)),
	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_TotalPPN]  DEFAULT ((0)),
	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_TotalPPH]  DEFAULT ((0)),
	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_RoundingManual]  DEFAULT ((0)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traPurchaseContract_IsDeleted]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseContract_Remarks]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traPurchaseContract_StatusID]  DEFAULT ((0)),
	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseContract_SubmitBy]  DEFAULT (''),
	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_SubmitDate]  DEFAULT (getdate()),
	[ApproveL1] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseContract_ApproveL1]  DEFAULT (''),
	[ApproveL1Date] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_ApproveL1Date]  DEFAULT (getdate()),
	[ApprovedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseContract_ApprovedBy]  DEFAULT (''),
	[ApprovedDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_ApprovedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseContract_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_CreatedDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_traPurchaseContract_LogInc]  DEFAULT ((0)),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseContract_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContract_LogDate]  DEFAULT (getdate()),
	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_DPAmount]  DEFAULT ((0)),
	[ReceiveAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traPurchaseContract_ReceiveAmount]  DEFAULT ((0)),
 CONSTRAINT [PK_traPurchaseContract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseContractDet]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseContractDet](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_ID]  DEFAULT (''),
	[PCID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_PCID]  DEFAULT (''),
	[CODetailID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_CODetailID]  DEFAULT (''),
	[ItemID] [int] NOT NULL CONSTRAINT [DF_traPurchaseContractDet_ItemID]  DEFAULT ((0)),
	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_Quantity]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_Weight]  DEFAULT ((0)),
	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_TotalWeight]  DEFAULT ((0)),
	[UnitPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_UnitPrice]  DEFAULT ((0)),
	[TotalPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_TotalPrice]  DEFAULT ((0)),
	[DCQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_DCQuantity]  DEFAULT ((0)),
	[DCWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_DCWeight]  DEFAULT ((0)),
	[CuttingQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_CuttingQuantity]  DEFAULT ((0)),
	[CuttingWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_CuttingWeight]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseContractDet_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_traPurchaseContractDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseContractPaymentTerm]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseContractPaymentTerm](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractPaymentTerm_ID]  DEFAULT (''),
	[PCID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractPaymentTerm_PCID]  DEFAULT (''),
	[Percentage] [decimal](18,2) NOT NULL CONSTRAINT [DF_traPurchaseContractPaymentTerm_Percentage]  DEFAULT ((0)),
	[PaymentTypeID] [int] NOT NULL CONSTRAINT [DF_traPurchaseContractPaymentTerm_PaymentTypeID]  DEFAULT ((0)),
	[PaymentModeID] [int] NOT NULL CONSTRAINT [DF_traPurchaseContractPaymentTerm_PaymentModeID]  DEFAULT ((0)),
	[CreditTerm] [int] NOT NULL CONSTRAINT [DF_traPurchaseContractPaymentTerm_CreditTerm]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseContractPaymentTerm_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traPurchaseContractPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traPurchaseContractStatus]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traPurchaseContractStatus](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractStatus_ID]  DEFAULT (''),
	[PCID] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractStatus_PCID]  DEFAULT (''),
	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traPurchaseContractStatus_Status]  DEFAULT ((0)),
	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traPurchaseContractStatus_StatusBy]  DEFAULT ((0)),
	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traPurchaseContractStatus_StatusDate]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traPurchaseContractStatus_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traPurchaseContractStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traSalesContract]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traSalesContract](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContract_ID]  DEFAULT (''),
	[ProgramID] [int] NOT NULL CONSTRAINT [DF_traSalesContract_ProgramID]  DEFAULT ((0)),
	[CompanyID] [int] NOT NULL CONSTRAINT [DF_traSalesContract_CompanyID]  DEFAULT ((0)),
	[SCNumber] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContract_SCNumber]  DEFAULT (('')),
	[SCDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_SCDate]  DEFAULT (getdate()),
	[BPID] [int] NOT NULL CONSTRAINT [DF_traSalesContract_BPID]  DEFAULT ((0)),
	[DeliveryPeriodFrom] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_DeliveryPeriodFrom]  DEFAULT (getdate()),
	[DeliveryPeriodTo] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_DeliveryPeriodTo]  DEFAULT (getdate()),
	[AllowanceProduction] [decimal](18,2) NOT NULL CONSTRAINT [DF_traSalesContract_AllowanceProduction]  DEFAULT ((0)),
	[Franco] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContract_Franco]  DEFAULT (''),
	[DelegationSeller] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContract_DelegationSeller]  DEFAULT (''),
	[DelegationPositionSeller] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContract_DelegationPositionSeller]  DEFAULT (''),
	[DelegationBuyer] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContract_DelegationBuyer]  DEFAULT (''),
	[DelegationPositionBuyer] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContract_DelegationPositionBuyer]  DEFAULT (''),
	[PPN] [decimal](18,2) NOT NULL CONSTRAINT [DF_traSalesContract_PPN]  DEFAULT ((0)),
	[PPH] [decimal](18,2) NOT NULL CONSTRAINT [DF_traSalesContract_PPH]  DEFAULT ((0)),
	[TotalQuantity] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_TotalQuantity]  DEFAULT ((0)),
	[TotalWeight] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_TotalWeight]  DEFAULT ((0)),
	[TotalDPP] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_TotalDPP]  DEFAULT ((0)),
	[TotalPPN] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_TotalPPN]  DEFAULT ((0)),
	[TotalPPH] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_TotalPPH]  DEFAULT ((0)),
	[RoundingManual] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_RoundingManual]  DEFAULT ((0)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_traSalesContract_IsDeleted]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContract_Remarks]  DEFAULT (''),
	[StatusID] [int] NOT NULL CONSTRAINT [DF_traSalesContract_StatusID]  DEFAULT ((0)),
	[CompanyBankAccountID] [int] NOT NULL CONSTRAINT [DF_traSalesContract_CompanyBankAccountID]  DEFAULT ((0)),
	[SubmitBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesContract_SubmitBy]  DEFAULT (''),
	[SubmitDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_SubmitDate]  DEFAULT (getdate()),
	[ApproveL1] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesContract_ApproveL1]  DEFAULT (''),
	[ApproveL1Date] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_ApproveL1Date]  DEFAULT (getdate()),
	[ApprovedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesContract_ApprovedBy]  DEFAULT (''),
	[ApprovedDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_ApprovedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesContract_CreatedBy]  DEFAULT ('SYSTEM'),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_CreatedDate]  DEFAULT (getdate()),
	[LogInc] [int] NOT NULL CONSTRAINT [DF_traSalesContract_LogInc]  DEFAULT ((0)),
	[LogBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesContract_LogBy]  DEFAULT ('SYSTEM'),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesContract_LogDate]  DEFAULT (getdate()),
	[DPAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_DPAmount]  DEFAULT ((0)),
	[ReceiveAmount] [decimal](18, 4) NOT NULL CONSTRAINT [DF_traSalesContract_ReceiveAmount]  DEFAULT ((0)),
 CONSTRAINT [PK_traSalesContract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traSalesContractDet]    Script Date: 07/09/2023 17:54:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traSalesContractDet](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDet_ID]  DEFAULT (''),
	[SCID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDet_SCID]  DEFAULT (''),
	[PODetailInternalID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDet_PODetailInternalID]  DEFAULT (''),
	[OrderNumberSupplier] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractDet_OrderNumberSupplier]  DEFAULT (''),
	[ItemID] [int] NOT NULL CONSTRAINT [DF_traSalesContractDet_ItemID]  DEFAULT ((0)),
	[Quantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_Quantity]  DEFAULT ((0)),
	[Weight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_Weight]  DEFAULT ((0)),
	[TotalWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_TotalWeight]  DEFAULT ((0)),
	[UnitPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_UnitPrice]  DEFAULT ((0)),
	[TotalPrice] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_TotalPrice]  DEFAULT ((0)),
	[DCQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_DCQuantity]  DEFAULT ((0)),
	[DCWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_DCWeight]  DEFAULT ((0)),
	[CuttingQuantity] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_CuttingQuantity]  DEFAULT ((0)),
	[CuttingWeight] [decimal](18,4) NOT NULL CONSTRAINT [DF_traSalesContractDet_CuttingWeight]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContractDet_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_traSalesContractDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traSalesContractPaymentTerm]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traSalesContractPaymentTerm](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractPaymentTerm_ID]  DEFAULT (''),
	[SCID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractPaymentTerm_SCID]  DEFAULT (''),
	[Percentage] [decimal](18,2) NOT NULL CONSTRAINT [DF_traSalesContractPaymentTerm_Percentage]  DEFAULT ((0)),
	[PaymentTypeID] [int] NOT NULL CONSTRAINT [DF_traSalesContractPaymentTerm_PaymentTypeID]  DEFAULT ((0)),
	[PaymentModeID] [int] NOT NULL CONSTRAINT [DF_traSalesContractPaymentTerm_PaymentModeID]  DEFAULT ((0)),
	[CreditTerm] [int] NOT NULL CONSTRAINT [DF_traSalesContractPaymentTerm_CreditTerm]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContractPaymentTerm_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traSalesContractPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO

/****** Object:  Table [dbo].[traSalesContractStatus]    Script Date: 07/09/2023 18:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[traSalesContractStatus](
	[ID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractStatus_ID]  DEFAULT (''),
	[SCID] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractStatus_SCID]  DEFAULT (''),
	[Status] [varchar](100) NOT NULL CONSTRAINT [DF_traSalesContractStatus_Status]  DEFAULT ((0)),
	[StatusBy] [varchar](20) NOT NULL CONSTRAINT [DF_traSalesContractStatus_StatusBy]  DEFAULT ((0)),
	[StatusDate] [datetime] NOT NULL CONSTRAINT [DF_traSalesContractStatus_StatusDate]  DEFAULT ((0)),
	[Remarks] [varchar](250) NOT NULL CONSTRAINT [DF_traSalesContractStatus_Remarks]  DEFAULT ((0)),
 CONSTRAINT [PK_traSalesContractStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




