
USE [ERPS]
GO
/****** Object:  Table [dbo].[mstAccess]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstAccess](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
 CONSTRAINT [PK_mstAccess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstBusinessPartner]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstBusinessPartner](
	[ID] [int] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[PICName] [varchar](150) NOT NULL,
	[PICPhoneNumber] [varchar](100) NOT NULL,
	[APBalance] [decimal](18, 2) NOT NULL,
	[ARBalance] [decimal](18, 2) NOT NULL,
	[JournalIDForAPBalance] [varchar](100) NOT NULL,
	[JournalIDForARBalance] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[Initial] [varchar](150) NULL,
 CONSTRAINT [PK_mstBusinessPartner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstBusinessPartnerAPBalance]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstBusinessPartnerAPBalance](
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[ID] [varchar](100) NOT NULL,
	[BPID] [int] NOT NULL,
	[InvoiceNumber] [varchar](100) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[TotalDPP] [decimal](18, 2) NOT NULL,
	[TotalPPN] [decimal](18, 2) NOT NULL,
	[TotalPPH] [decimal](18, 2) NOT NULL,
	[TotalPaymentDP] [decimal](18, 2) NOT NULL,
	[TotalPayment] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_mstBusinessPartnerAPBalance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstBusinessPartnerARBalance]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstBusinessPartnerARBalance](
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[ID] [varchar](100) NOT NULL,
	[BPID] [int] NOT NULL,
	[InvoiceNumber] [varchar](100) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[TotalDPP] [decimal](18, 2) NOT NULL,
	[TotalPPN] [decimal](18, 2) NOT NULL,
	[TotalPPH] [decimal](18, 2) NOT NULL,
	[TotalPaymentDP] [decimal](18, 2) NOT NULL,
	[TotalPayment] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_mstBusinessPartnerARBalance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstBusinessPartnerAssign]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstBusinessPartnerAssign](
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[BPID] [int] NOT NULL,
	[FirstBalance] [decimal](18, 2) NOT NULL,
	[FirstBalanceDate] [datetime] NOT NULL,
 CONSTRAINT [PK_mstBusinessPartnerAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstBusinessPartnerBankAccount]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstBusinessPartnerBankAccount](
	[ID] [int] NOT NULL,
	[BPID] [int] NOT NULL,
	[AccountName] [varchar](250) NOT NULL,
	[BankName] [varchar](500) NOT NULL,
	[AccountNumber] [varchar](150) NOT NULL,
	[Currency] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
 CONSTRAINT [PK_mstBusinessPartnerBankAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstChartOfAccount]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccount](
	[ID] [int] NOT NULL,
	[AccountGroupID] [int] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[FirstBalance] [decimal](18, 2) NOT NULL,
	[FirstBalanceDate] [datetime] NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[Initial] [varchar](10) NOT NULL,
 CONSTRAINT [PK_mstChartOfAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstChartOfAccountAssign]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccountAssign](
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[COAID] [int] NOT NULL,
	[FirstBalance] [decimal](18, 2) NOT NULL,
	[FirstBalanceDate] [datetime] NOT NULL,
 CONSTRAINT [PK_mstChartOfAccountAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstChartOfAccountGroup]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccountGroup](
	[ID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[COAType] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
	[AliasName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_mstChartOfAccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstChartOfAccountType]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstChartOfAccountType](
	[ID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstChartOfAccountType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstCompany]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstCompany](
	[ID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](250) NOT NULL,
	[Country] [varchar](250) NOT NULL,
	[Province] [varchar](250) NOT NULL,
	[City] [varchar](250) NOT NULL,
	[Warehouse] [varchar](250) NOT NULL,
	[SubDistrict] [varchar](250) NOT NULL,
	[Area] [varchar](250) NOT NULL,
	[DirectorName] [varchar](250) NOT NULL,
	[PhoneNumber] [varchar](250) NOT NULL,
	[CompanyInitial] [varchar](3) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstCompanyBankAccount]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstCompanyBankAccount](
	[ID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[AccountName] [varchar](250) NOT NULL,
	[BankName] [varchar](500) NOT NULL,
	[AccountNumber] [varchar](150) NOT NULL,
	[Currency] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
 CONSTRAINT [PK_mstCompanyBankAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstItem]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstItem](
	[ID] [int] NOT NULL,
	[ItemCode] [varchar](100) NOT NULL,
	[ItemName] [varchar](500) NOT NULL,
	[ItemTypeID] [int] NOT NULL,
	[ItemSpecificationID] [int] NOT NULL,
	[Thick] [decimal](18, 2) NOT NULL,
	[Width] [decimal](18, 2) NOT NULL,
	[Length] [decimal](18, 2) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[BasePrice] [decimal](18, 2) NOT NULL,
	[StatusID] [int] NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[ItemCodeExternal] [varchar](150) NULL,
 CONSTRAINT [PK_mstItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstItemSpecification]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstItemSpecification](
	[ID] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
 CONSTRAINT [PK_mstItemSpecification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstItemType]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstItemType](
	[ID] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
 CONSTRAINT [PK_mstItemType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstModuleIDARAP]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstModuleIDARAP](
	[ID] [int] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstModuleIDARAP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstModules]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstModules](
	[ID] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstModulesAccess]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstModulesAccess](
	[ID] [int] NOT NULL,
	[ModulesID] [int] NOT NULL,
	[AccessID] [int] NOT NULL,
 CONSTRAINT [PK_mstModulesAccess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstPaymentMode]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstPaymentMode](
	[ID] [int] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstPaymentMode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstPaymentType]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstPaymentType](
	[ID] [int] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[PaymentTypeCategoryID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstPaymentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstPaymentTypeCategory]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstPaymentTypeCategory](
	[ID] [int] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstPaymentTypeCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstProgram]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstProgram](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
 CONSTRAINT [PK_mstProgram] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstProgramModules]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstProgramModules](
	[ID] [int] NOT NULL,
	[ModulesID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
 CONSTRAINT [PK_mstProgramModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstStatus](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstStatusModules]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstStatusModules](
	[ID] [int] NOT NULL,
	[ModulesID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_mstStatusModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstUOM]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstUOM](
	[ID] [int] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
 CONSTRAINT [PK_mstUOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstUser]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstUser](
	[ID] [varchar](20) NOT NULL,
	[StaffID] [varchar](20) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Position] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogInc] [int] NULL,
	[IsSuperUser] [bit] NOT NULL,
	[IsFirstCreated] [bit] NOT NULL,
 CONSTRAINT [PK_mstUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstUserAccess]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstUserAccess](
	[ID] [int] NOT NULL,
	[UserID] [varchar](20) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[ModulesID] [int] NOT NULL,
	[AccessID] [int] NOT NULL,
 CONSTRAINT [PK_mstUserAccess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mstUserCompany]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mstUserCompany](
	[ID] [int] NOT NULL,
	[UserID] [varchar](20) NOT NULL,
	[CompanyID] [int] NOT NULL,
 CONSTRAINT [PK_mstUserCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysJournalPost]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysJournalPost](
	[ProgramID] [int] NOT NULL,
	[CoAofRevenue] [int] NOT NULL,
	[CoAofAccountReceivable] [int] NOT NULL,
	[CoAofSalesDisc] [int] NOT NULL,
	[CoAofPrepaidIncome] [int] NOT NULL,
	[CoAofCOGS] [int] NOT NULL,
	[CoAofStock] [int] NOT NULL,
	[CoAofCash] [int] NOT NULL,
	[CoAofAccountPayable] [int] NOT NULL,
	[CoAofPurchaseDisc] [int] NOT NULL,
	[CoAofPurchaseEquipments] [int] NOT NULL,
	[CoAofAdvancePayment] [int] NOT NULL,
	[CoAofSalesTax] [int] NOT NULL,
	[CoAofPurchaseTax] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[CoAofVentureCapital] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traAccountPayable]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traAccountPayable](
	[ID] [varchar](100) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[APNumber] [varchar](100) NOT NULL,
	[BPID] [int] NOT NULL,
	[CoAIDOfOutgoingPayment] [int] NOT NULL,
	[Modules] [varchar](250) NOT NULL,
	[ReferencesID] [varchar](250) NOT NULL,
	[ReferencesNote] [varchar](250) NOT NULL,
	[APDate] [datetime] NOT NULL,
	[DueDateValue] [int] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[TotalAmountDPAllocate] [decimal](18, 2) NOT NULL,
	[Percentage] [decimal](18, 4) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[PaymentBy] [varchar](20) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TaxInvoiceNumber] [varchar](250) NOT NULL,
	[IsClosedPeriod] [bit] NOT NULL,
	[ClosedPeriodBy] [varchar](20) NOT NULL,
	[ClosedPeriodDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[TotalPPN] [decimal](18, 2) NOT NULL,
	[TotalPPH] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_traAccountPayable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traAccountPayableDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traAccountPayableDet](
	[ID] [varchar](100) NOT NULL,
	[APID] [varchar](100) NOT NULL,
	[PurchaseID] [varchar](100) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_traAccountPayableDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traAccountPayableStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traAccountPayableStatus](
	[ID] [varchar](100) NOT NULL,
	[APID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traAccountPayableStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traAccountReceivable]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traAccountReceivable](
	[ID] [varchar](100) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[ARNumber] [varchar](100) NOT NULL,
	[BPID] [int] NOT NULL,
	[CoAIDOfIncomePayment] [int] NOT NULL,
	[Modules] [varchar](250) NOT NULL,
	[ReferencesID] [varchar](250) NOT NULL,
	[ReferencesNote] [varchar](250) NOT NULL,
	[ARDate] [datetime] NOT NULL,
	[DueDateValue] [int] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[TotalAmountDPAllocate] [decimal](18, 2) NOT NULL,
	[Percentage] [decimal](18, 4) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[PaymentBy] [varchar](20) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TaxInvoiceNumber] [varchar](250) NOT NULL,
	[IsClosedPeriod] [bit] NOT NULL,
	[ClosedPeriodBy] [varchar](20) NOT NULL,
	[ClosedPeriodDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[TotalPPN] [decimal](18, 2) NOT NULL,
	[TotalPPH] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_traAccountReceivable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traAccountReceivableDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traAccountReceivableDet](
	[ID] [varchar](100) NOT NULL,
	[ARID] [varchar](100) NOT NULL,
	[SalesID] [varchar](100) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_traAccountReceivableDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traAccountReceivableStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traAccountReceivableStatus](
	[ID] [varchar](100) NOT NULL,
	[ARID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traAccountReceivableStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traBukuBesar]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traBukuBesar](
	[ID] [varchar](100) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[ReferencesID] [varchar](100) NOT NULL,
	[COAIDParent] [int] NOT NULL,
	[COAIDChild] [int] NOT NULL,
	[DebitAmount] [decimal](18, 2) NOT NULL,
	[CreditAmount] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReferencesNo] [varchar](100) NULL,
	[IsClosedPeriod] [bit] NOT NULL,
	[ClosedPeriodBy] [varchar](20) NOT NULL,
	[ClosedPeriodDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traBukuBesar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traConfirmationOrder]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traConfirmationOrder](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CONumber] [varchar](100) NOT NULL,
	[CODate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[DeliveryPeriodFrom] [datetime] NOT NULL,
	[DeliveryPeriodTo] [datetime] NOT NULL,
	[AllowanceProduction] [decimal](18, 2) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traConfirmationOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traConfirmationOrderDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traConfirmationOrderDet](
	[ID] [varchar](100) NOT NULL,
	[COID] [varchar](100) NOT NULL,
	[PODetailID] [varchar](100) NOT NULL,
	[OrderNumberSupplier] [varchar](100) NOT NULL,
	[DeliveryAddress] [varchar](1000) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[PCQuantity] [decimal](18, 4) NOT NULL,
	[PCWeight] [decimal](18, 4) NOT NULL,
	[DCQuantity] [decimal](18, 4) NOT NULL,
	[DCWeight] [decimal](18, 4) NOT NULL,
	[SCQuantity] [decimal](18, 4) NOT NULL,
	[SCWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traConfirmationOrderDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traConfirmationOrderPaymentTerm]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traConfirmationOrderPaymentTerm](
	[ID] [varchar](100) NOT NULL,
	[COID] [varchar](100) NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[PaymentTypeID] [int] NOT NULL,
	[PaymentModeID] [int] NOT NULL,
	[CreditTerm] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traConfirmationOrderPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traConfirmationOrderStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traConfirmationOrderStatus](
	[ID] [varchar](100) NOT NULL,
	[COID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traConfirmationOrderStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traCost]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traCost](
	[ID] [varchar](100) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CostNumber] [varchar](100) NOT NULL,
	[CoAID] [int] NOT NULL,
	[ReferencesID] [varchar](250) NOT NULL,
	[ReferencesNote] [varchar](250) NOT NULL,
	[CostDate] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[PaymentBy] [varchar](20) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TaxInvoiceNumber] [varchar](250) NOT NULL,
	[IsClosedPeriod] [bit] NOT NULL,
	[ClosedPeriodBy] [varchar](20) NOT NULL,
	[ClosedPeriodDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traCost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traCostDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traCostDet](
	[ID] [varchar](100) NOT NULL,
	[CostID] [varchar](100) NOT NULL,
	[COAID] [varchar](100) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
 CONSTRAINT [PK_traCostDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traCostStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traCostStatus](
	[ID] [varchar](100) NOT NULL,
	[CostID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traCostStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traCutting]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traCutting](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CuttingNumber] [varchar](100) NOT NULL,
	[CuttingDate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[ReferencesNumber] [varchar](250) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traCutting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traCuttingDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traCuttingDet](
	[ID] [varchar](100) NOT NULL,
	[CuttingID] [varchar](100) NOT NULL,
	[PODetailID] [varchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traCuttingDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traCuttingDetResult]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traCuttingDetResult](
	[ID] [varchar](100) NOT NULL,
	[CuttingID] [varchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traCuttingDetResult] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traCuttingStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traCuttingStatus](
	[ID] [varchar](100) NOT NULL,
	[CuttingID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traCuttingStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traDelivery]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traDelivery](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[DeliveryNumber] [varchar](100) NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[SCID] [varchar](100) NOT NULL,
	[PlatNumber] [varchar](100) NOT NULL,
	[Driver] [varchar](100) NOT NULL,
	[ReferencesNumber] [varchar](100) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[TotalDPPTransport] [decimal](18, 4) NOT NULL,
	[TotalPPNTransport] [decimal](18, 4) NOT NULL,
	[TotalPPHTransport] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traDelivery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traDeliveryDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traDeliveryDet](
	[ID] [varchar](100) NOT NULL,
	[DeliveryID] [varchar](100) NOT NULL,
	[SCDetailID] [varchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traDeliveryDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traDeliveryDetTransport]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traDeliveryDetTransport](
	[ID] [varchar](100) NOT NULL,
	[DeliveryID] [varchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[PODetailID] [varchar](100) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traDeliveryDetTransport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traDeliveryStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traDeliveryStatus](
	[ID] [varchar](100) NOT NULL,
	[DeliveryID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traDeliveryStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traJournal]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traJournal](
	[ID] [varchar](100) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[JournalNo] [varchar](100) NOT NULL,
	[ReferencesID] [varchar](100) NOT NULL,
	[JournalDate] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[IsAutoGenerate] [bit] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[IsClosedPeriod] [bit] NOT NULL,
	[ClosedPeriodBy] [varchar](20) NOT NULL,
	[ClosedPeriodDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[Initial] [varchar](10) NOT NULL,
 CONSTRAINT [PK_traJournal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traJournalDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traJournalDet](
	[ID] [varchar](100) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[COAID] [int] NOT NULL,
	[DebitAmount] [decimal](18, 2) NOT NULL,
	[CreditAmount] [decimal](18, 2) NOT NULL,
	[Remarks] [varchar](500) NOT NULL,
 CONSTRAINT [PK_traJournalDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traJournalStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traJournalStatus](
	[ID] [varchar](100) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traJournalStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traOrderRequest]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traOrderRequest](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[OrderNumber] [varchar](100) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[ReferencesNumber] [varchar](250) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traOrderRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traOrderRequestDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traOrderRequestDet](
	[ID] [varchar](100) NOT NULL,
	[OrderRequestID] [varchar](100) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[SCQuantity] [decimal](18, 4) NOT NULL,
	[SCWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traOrderRequestDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traOrderRequestStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traOrderRequestStatus](
	[ID] [varchar](30) NOT NULL,
	[OrderRequestID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traOrderRequestStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseContract]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseContract](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[PCNumber] [varchar](100) NOT NULL,
	[PCDate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[DeliveryPeriodFrom] [datetime] NOT NULL,
	[DeliveryPeriodTo] [datetime] NOT NULL,
	[AllowanceProduction] [decimal](18, 2) NOT NULL,
	[Franco] [varchar](250) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[DPAmount] [decimal](18, 4) NOT NULL,
	[ReceiveAmount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_traPurchaseContract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseContractDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseContractDet](
	[ID] [varchar](100) NOT NULL,
	[PCID] [varchar](100) NOT NULL,
	[CODetailID] [varchar](100) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[DCQuantity] [decimal](18, 4) NOT NULL,
	[DCWeight] [decimal](18, 4) NOT NULL,
	[CuttingQuantity] [decimal](18, 4) NOT NULL,
	[CuttingWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[ReceiveAmount] [decimal](18, 4) NULL,
 CONSTRAINT [PK_traPurchaseContractDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseContractPaymentTerm]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseContractPaymentTerm](
	[ID] [varchar](100) NOT NULL,
	[PCID] [varchar](100) NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[PaymentTypeID] [int] NOT NULL,
	[PaymentModeID] [int] NOT NULL,
	[CreditTerm] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traPurchaseContractPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseContractStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseContractStatus](
	[ID] [varchar](100) NOT NULL,
	[PCID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traPurchaseContractStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrder]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrder](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[PONumber] [varchar](100) NOT NULL,
	[PODate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[PersonInCharge] [varchar](100) NOT NULL,
	[DeliveryPeriodFrom] [datetime] NOT NULL,
	[DeliveryPeriodTo] [datetime] NOT NULL,
	[DeliveryAddress] [varchar](250) NOT NULL,
	[Validity] [varchar](250) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traPurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrderCutting]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrderCutting](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[PONumber] [varchar](100) NOT NULL,
	[PODate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[PersonInCharge] [varchar](100) NOT NULL,
	[DeliveryPeriodFrom] [datetime] NOT NULL,
	[DeliveryPeriodTo] [datetime] NOT NULL,
	[DeliveryAddress] [varchar](250) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[DPAmount] [decimal](18, 4) NOT NULL,
	[ReceiveAmount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_traPurchaseOrderCutting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrderCuttingDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrderCuttingDet](
	[ID] [varchar](100) NOT NULL,
	[POID] [varchar](100) NOT NULL,
	[PCDetailID] [varchar](100) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[DoneQuantity] [decimal](18, 4) NOT NULL,
	[DoneWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traPurchaseOrderCuttingDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrderDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrderDet](
	[ID] [varchar](100) NOT NULL,
	[POID] [varchar](100) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[COQuantity] [decimal](18, 4) NOT NULL,
	[COWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traPurchaseOrderDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrderPaymentTerm]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrderPaymentTerm](
	[ID] [varchar](100) NOT NULL,
	[POID] [varchar](100) NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[PaymentTypeID] [int] NOT NULL,
	[PaymentModeID] [int] NOT NULL,
	[CreditTerm] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traPurchaseOrderPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrderStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrderStatus](
	[ID] [varchar](100) NOT NULL,
	[POID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traPurchaseOrderStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrderTransport]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrderTransport](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[PONumber] [varchar](100) NOT NULL,
	[PODate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[SCID] [varchar](100) NOT NULL,
	[PersonInCharge] [varchar](100) NOT NULL,
	[DeliveryPeriodFrom] [datetime] NOT NULL,
	[DeliveryPeriodTo] [datetime] NOT NULL,
	[DeliveryAddress] [varchar](250) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[DPAmount] [decimal](18, 4) NOT NULL,
	[ReceiveAmount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_traPurchaseOrderTransport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traPurchaseOrderTransportDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traPurchaseOrderTransportDet](
	[ID] [varchar](100) NOT NULL,
	[POID] [varchar](100) NOT NULL,
	[SCDetailID] [varchar](100) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[DoneQuantity] [decimal](18, 4) NOT NULL,
	[DoneWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traPurchaseOrderTransportDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traReceive]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traReceive](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ReceiveNumber] [varchar](100) NOT NULL,
	[ReceiveDate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[PlatNumber] [varchar](100) NOT NULL,
	[Driver] [varchar](100) NOT NULL,
	[ReferencesNumber] [varchar](100) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[StatusID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_traReceive] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traReceiveDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traReceiveDet](
	[ID] [varchar](100) NOT NULL,
	[ReceiveID] [varchar](100) NOT NULL,
	[PCDetailID] [varchar](100) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traReceiveDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traReceiveStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traReceiveStatus](
	[ID] [varchar](100) NOT NULL,
	[ReceiveID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traReceiveStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traSalesContract]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traSalesContract](
	[ID] [varchar](100) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[SCNumber] [varchar](100) NOT NULL,
	[SCDate] [datetime] NOT NULL,
	[BPID] [int] NOT NULL,
	[DeliveryPeriodFrom] [datetime] NOT NULL,
	[DeliveryPeriodTo] [datetime] NOT NULL,
	[AllowanceProduction] [decimal](18, 2) NOT NULL,
	[Franco] [varchar](250) NOT NULL,
	[DelegationSeller] [varchar](250) NOT NULL,
	[DelegationPositionSeller] [varchar](250) NOT NULL,
	[DelegationBuyer] [varchar](250) NOT NULL,
	[DelegationPositionBuyer] [varchar](250) NOT NULL,
	[PPN] [decimal](18, 2) NOT NULL,
	[PPH] [decimal](18, 2) NOT NULL,
	[TotalQuantity] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[TotalDPP] [decimal](18, 4) NOT NULL,
	[TotalPPN] [decimal](18, 4) NOT NULL,
	[TotalPPH] [decimal](18, 4) NOT NULL,
	[RoundingManual] [decimal](18, 4) NOT NULL,
	[COTotalQuantity] [decimal](18, 4) NOT NULL,
	[COTotalWeight] [decimal](18, 4) NOT NULL,
	[COTotalDPP] [decimal](18, 4) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[JournalID] [varchar](100) NOT NULL,
	[StatusID] [int] NOT NULL,
	[CompanyBankAccountID] [int] NOT NULL,
	[SubmitBy] [varchar](20) NOT NULL,
	[SubmitDate] [datetime] NOT NULL,
	[ApproveL1] [varchar](20) NOT NULL,
	[ApproveL1Date] [datetime] NOT NULL,
	[ApprovedBy] [varchar](20) NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LogInc] [int] NOT NULL,
	[LogBy] [varchar](20) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[DPAmount] [decimal](18, 4) NOT NULL,
	[ReceiveAmount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_traSalesContract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traSalesContractDet]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traSalesContractDet](
	[ID] [varchar](100) NOT NULL,
	[SCID] [varchar](100) NOT NULL,
	[ORDetailID] [varchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[DCQuantity] [decimal](18, 4) NOT NULL,
	[DCWeight] [decimal](18, 4) NOT NULL,
	[POTransportQuantity] [decimal](18, 4) NOT NULL,
	[POTransportWeight] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
	[ReceiveAmount] [decimal](18, 4) NULL,
 CONSTRAINT [PK_traSalesContractDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traSalesContractDetConfirmationOrder]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traSalesContractDetConfirmationOrder](
	[ID] [varchar](100) NOT NULL,
	[SCID] [varchar](100) NOT NULL,
	[CODetailID] [varchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traSalesContractDetConfirmationOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traSalesContractPaymentTerm]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traSalesContractPaymentTerm](
	[ID] [varchar](100) NOT NULL,
	[SCID] [varchar](100) NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[PaymentTypeID] [int] NOT NULL,
	[PaymentModeID] [int] NOT NULL,
	[CreditTerm] [int] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traSalesContractPaymentTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traSalesContractStatus]    Script Date: 1/12/2024 6:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traSalesContractStatus](
	[ID] [varchar](100) NOT NULL,
	[SCID] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[StatusBy] [varchar](20) NOT NULL,
	[StatusDate] [datetime] NOT NULL,
	[Remarks] [varchar](250) NOT NULL,
 CONSTRAINT [PK_traSalesContractStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstAccess] ADD  CONSTRAINT [DF_mstAccess_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_Address]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_PICName]  DEFAULT ('') FOR [PICName]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_PICPhoneNumber]  DEFAULT ('') FOR [PICPhoneNumber]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_APBalance]  DEFAULT ((0)) FOR [APBalance]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_ARBalance]  DEFAULT ((0)) FOR [ARBalance]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_JournalIDForAPBalance]  DEFAULT ('') FOR [JournalIDForAPBalance]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_JournalIDForARBalance]  DEFAULT ('') FOR [JournalIDForARBalance]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstBusinessPartner] ADD  CONSTRAINT [DF_mstBusinessPartner_Initial]  DEFAULT ('') FOR [Initial]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_InvoiceNumber]  DEFAULT ('') FOR [InvoiceNumber]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_InvoiceDate]  DEFAULT ('2000/01/01') FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_TotalPaymentDP]  DEFAULT ((0)) FOR [TotalPaymentDP]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAPBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerAPBalance_TotalPayment]  DEFAULT ((0)) FOR [TotalPayment]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_InvoiceNumber]  DEFAULT ('') FOR [InvoiceNumber]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_InvoiceDate]  DEFAULT ('2000/01/01') FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_TotalPaymentDP]  DEFAULT ((0)) FOR [TotalPaymentDP]
GO
ALTER TABLE [dbo].[mstBusinessPartnerARBalance] ADD  CONSTRAINT [DF_tramstBusinessPartnerARBalance_TotalPayment]  DEFAULT ((0)) FOR [TotalPayment]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAssign] ADD  CONSTRAINT [DF_tramstBusinessPartnerAssignAssign_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAssign] ADD  CONSTRAINT [DF_tramstBusinessPartnerAssignAssign_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAssign] ADD  CONSTRAINT [DF_tramstBusinessPartnerAssignAssign_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAssign] ADD  CONSTRAINT [DF_tramstBusinessPartnerAssignAssign_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAssign] ADD  CONSTRAINT [DF_tramstBusinessPartnerAssignAssign_FirstBalance]  DEFAULT ((0)) FOR [FirstBalance]
GO
ALTER TABLE [dbo].[mstBusinessPartnerAssign] ADD  CONSTRAINT [DF_tramstBusinessPartnerAssignAssign_FirstBalanceDate]  DEFAULT ('2000/01/01') FOR [FirstBalanceDate]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_AccountName]  DEFAULT ('') FOR [AccountName]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_BankName]  DEFAULT ('') FOR [BankName]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_AccountNumber]  DEFAULT ('') FOR [AccountNumber]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_Currency]  DEFAULT ('') FOR [Currency]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstBusinessPartnerBankAccount] ADD  CONSTRAINT [DF_mstBusinessPartnerBankAccount_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_AccountGroupID]  DEFAULT ((0)) FOR [AccountGroupID]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_FirstBalance]  DEFAULT ((0)) FOR [FirstBalance]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_FirstBalanceDate]  DEFAULT ('2000/01/01') FOR [FirstBalanceDate]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_CreatedBy]  DEFAULT ('') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_LogBy]  DEFAULT ('') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstChartOfAccount] ADD  CONSTRAINT [DF_traChartOfAccount_Initial]  DEFAULT ('') FOR [Initial]
GO
ALTER TABLE [dbo].[mstChartOfAccountAssign] ADD  CONSTRAINT [DF_traChartOfAccountAssign_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[mstChartOfAccountAssign] ADD  CONSTRAINT [DF_traChartOfAccountAssign_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[mstChartOfAccountAssign] ADD  CONSTRAINT [DF_traChartOfAccountAssign_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstChartOfAccountAssign] ADD  CONSTRAINT [DF_traChartOfAccountAssign_COAID]  DEFAULT ((0)) FOR [COAID]
GO
ALTER TABLE [dbo].[mstChartOfAccountAssign] ADD  CONSTRAINT [DF_traChartOfAccountAssign_FirstBalance]  DEFAULT ((0)) FOR [FirstBalance]
GO
ALTER TABLE [dbo].[mstChartOfAccountAssign] ADD  CONSTRAINT [DF_traChartOfAccountAssign_FirstBalanceDate]  DEFAULT ('2000/01/01') FOR [FirstBalanceDate]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_COAType]  DEFAULT ((0)) FOR [COAType]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_CreatedBy]  DEFAULT ('') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_LogBy]  DEFAULT ('') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstChartOfAccountGroup] ADD  CONSTRAINT [DF_traChartOfAccountGroup_AliasName]  DEFAULT ('') FOR [AliasName]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_CreatedBy]  DEFAULT ('') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_LogBy]  DEFAULT ('') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstChartOfAccountType] ADD  CONSTRAINT [DF_traChartOfAccountType_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_Address]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_Country]  DEFAULT ('') FOR [Country]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_Province]  DEFAULT ('') FOR [Province]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_City]  DEFAULT ('') FOR [City]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_Warehouse]  DEFAULT ('') FOR [Warehouse]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_SubDistrict]  DEFAULT ('') FOR [SubDistrict]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_Area]  DEFAULT ('') FOR [Area]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_DirectorName]  DEFAULT ('') FOR [DirectorName]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_PhoneNumber]  DEFAULT ('') FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_CompanyInitial]  DEFAULT ('') FOR [CompanyInitial]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstCompany] ADD  CONSTRAINT [DF_mstCompany_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_AccountName]  DEFAULT ('') FOR [AccountName]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_BankName]  DEFAULT ('') FOR [BankName]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_AccountNumber]  DEFAULT ('') FOR [AccountNumber]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_Currency]  DEFAULT ('') FOR [Currency]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstCompanyBankAccount] ADD  CONSTRAINT [DF_mstCompanyBankAccount_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_ItemCode]  DEFAULT ('') FOR [ItemCode]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_ItemName]  DEFAULT ('') FOR [ItemName]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_ItemTypeID]  DEFAULT ((0)) FOR [ItemTypeID]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_ItemSpecificationID]  DEFAULT ((0)) FOR [ItemSpecificationID]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_Thick]  DEFAULT ((0)) FOR [Thick]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_Width]  DEFAULT ((0)) FOR [Width]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_Length]  DEFAULT ((0)) FOR [Length]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_BasePrice]  DEFAULT ((0)) FOR [BasePrice]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstItem] ADD  CONSTRAINT [DF_mstItem_ItemCodeExternal]  DEFAULT ('') FOR [ItemCodeExternal]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstItemSpecification] ADD  CONSTRAINT [DF_mstItemSpecification_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstItemType] ADD  CONSTRAINT [DF_mstItemType_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstModuleIDARAP] ADD  CONSTRAINT [DF_mstModuleIDARAP_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstModules] ADD  CONSTRAINT [DF_mstModules_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstModulesAccess] ADD  CONSTRAINT [DF_mstModulesAccess_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstModulesAccess] ADD  CONSTRAINT [DF_mstModulesAccess_ModulesID]  DEFAULT ((0)) FOR [ModulesID]
GO
ALTER TABLE [dbo].[mstModulesAccess] ADD  CONSTRAINT [DF_mstModulesAccess_AccessID]  DEFAULT ((0)) FOR [AccessID]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstPaymentMode] ADD  CONSTRAINT [DF_mstPaymentMode_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_PaymentTypeCategoryID]  DEFAULT ((0)) FOR [PaymentTypeCategoryID]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstPaymentType] ADD  CONSTRAINT [DF_mstPaymentType_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstPaymentTypeCategory] ADD  CONSTRAINT [DF_mstPaymentTypeCategory_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstProgram] ADD  CONSTRAINT [DF_mstProgram_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstProgramModules] ADD  CONSTRAINT [DF_mstProgramModules_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstProgramModules] ADD  CONSTRAINT [DF_mstProgramModules_ModulesID]  DEFAULT ((0)) FOR [ModulesID]
GO
ALTER TABLE [dbo].[mstProgramModules] ADD  CONSTRAINT [DF_mstProgramModules_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstStatus] ADD  CONSTRAINT [DF_mstStatus_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstStatusModules] ADD  CONSTRAINT [DF_mstStatusModules_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstStatusModules] ADD  CONSTRAINT [DF_mstStatusModules_ModulesID]  DEFAULT ('') FOR [ModulesID]
GO
ALTER TABLE [dbo].[mstStatusModules] ADD  CONSTRAINT [DF_mstStatusModules_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstUOM] ADD  CONSTRAINT [DF_mstUOM_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_StaffID]  DEFAULT ('') FOR [StaffID]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_Position]  DEFAULT ('') FOR [Position]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_IsSuperUser]  DEFAULT ((0)) FOR [IsSuperUser]
GO
ALTER TABLE [dbo].[mstUser] ADD  CONSTRAINT [DF_mstUser_IsFirstCreated]  DEFAULT ((0)) FOR [IsFirstCreated]
GO
ALTER TABLE [dbo].[mstUserAccess] ADD  CONSTRAINT [DF_mstUserAccess_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstUserAccess] ADD  CONSTRAINT [DF_mstUserAccess_UserID]  DEFAULT ('') FOR [UserID]
GO
ALTER TABLE [dbo].[mstUserAccess] ADD  CONSTRAINT [DF_mstUserAccess_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[mstUserAccess] ADD  CONSTRAINT [DF_mstUserAccess_ModulesID]  DEFAULT ((0)) FOR [ModulesID]
GO
ALTER TABLE [dbo].[mstUserAccess] ADD  CONSTRAINT [DF_mstUserAccess_AccessID]  DEFAULT ((0)) FOR [AccessID]
GO
ALTER TABLE [dbo].[mstUserCompany] ADD  CONSTRAINT [DF_mstUserCompany_ID]  DEFAULT ((0)) FOR [ID]
GO
ALTER TABLE [dbo].[mstUserCompany] ADD  CONSTRAINT [DF_mstUserCompany_UserID]  DEFAULT ('') FOR [UserID]
GO
ALTER TABLE [dbo].[mstUserCompany] ADD  CONSTRAINT [DF_mstUserCompany_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofRevenue]  DEFAULT ((0)) FOR [CoAofRevenue]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofAccountReceivable]  DEFAULT ((0)) FOR [CoAofAccountReceivable]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofSalesDisc]  DEFAULT ((0)) FOR [CoAofSalesDisc]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofPrepaidIncome]  DEFAULT ((0)) FOR [CoAofPrepaidIncome]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofCOGS]  DEFAULT ((0)) FOR [CoAofCOGS]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofStock]  DEFAULT ((0)) FOR [CoAofStock]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofCash]  DEFAULT ((0)) FOR [CoAofCash]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofAccountPayable]  DEFAULT ((0)) FOR [CoAofAccountPayable]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofPurchaseDisc]  DEFAULT ((0)) FOR [CoAofPurchaseDisc]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofPurchaseEquipments]  DEFAULT ((0)) FOR [CoAofPurchaseEquipments]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofAdvancePayment]  DEFAULT ((0)) FOR [CoAofAdvancePayment]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofSalesTax]  DEFAULT ((0)) FOR [CoAofSalesTax]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofPurchaseTax]  DEFAULT ((0)) FOR [CoAofPurchaseTax]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[sysJournalPost] ADD  CONSTRAINT [DF_sysJournalPost_CoAofVentureCapital]  DEFAULT ((0)) FOR [CoAofVentureCapital]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_APNumber]  DEFAULT ('') FOR [APNumber]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_CoAIDOfOutgoingPayment]  DEFAULT ((0)) FOR [CoAIDOfOutgoingPayment]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_Modules]  DEFAULT ('') FOR [Modules]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ReferencesID]  DEFAULT ('') FOR [ReferencesID]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ReferencesNote]  DEFAULT ('') FOR [ReferencesNote]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_APDate]  DEFAULT (getdate()) FOR [APDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_DueDateValue]  DEFAULT ((0)) FOR [DueDateValue]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_DueDate]  DEFAULT (getdate()) FOR [DueDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_TotalAmount]  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_TotalAmountDPAllocate]  DEFAULT ((0)) FOR [TotalAmountDPAllocate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_Percentage]  DEFAULT ((0)) FOR [Percentage]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_PaymentBy]  DEFAULT ('') FOR [PaymentBy]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_PaymentDate]  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_TaxInvoiceNumber]  DEFAULT ('') FOR [TaxInvoiceNumber]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_IsClosedPeriod]  DEFAULT ((0)) FOR [IsClosedPeriod]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ClosedPeriodBy]  DEFAULT ('') FOR [ClosedPeriodBy]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_ClosedPeriodDate]  DEFAULT (getdate()) FOR [ClosedPeriodDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traAccountPayable] ADD  CONSTRAINT [DF_traAccountPayable_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traAccountPayableDet] ADD  CONSTRAINT [DF_traAccountPayableDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traAccountPayableDet] ADD  CONSTRAINT [DF_traAccountPayableDet_APID]  DEFAULT ('') FOR [APID]
GO
ALTER TABLE [dbo].[traAccountPayableDet] ADD  CONSTRAINT [DF_traAccountPayableDet_PurchaseID]  DEFAULT ('') FOR [PurchaseID]
GO
ALTER TABLE [dbo].[traAccountPayableDet] ADD  CONSTRAINT [DF_traAccountPayableDet_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[traAccountPayableDet] ADD  CONSTRAINT [DF_traAccountPayableDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traAccountPayableDet] ADD  CONSTRAINT [DF_traAccountPayableDet_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traAccountPayableDet] ADD  CONSTRAINT [DF_traAccountPayableDet_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traAccountPayableStatus] ADD  CONSTRAINT [DF_traAccountPayableStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traAccountPayableStatus] ADD  CONSTRAINT [DF_traAccountPayableStatus_APID]  DEFAULT ('') FOR [APID]
GO
ALTER TABLE [dbo].[traAccountPayableStatus] ADD  CONSTRAINT [DF_traAccountPayableStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traAccountPayableStatus] ADD  CONSTRAINT [DF_traAccountPayableStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traAccountPayableStatus] ADD  CONSTRAINT [DF_traAccountPayableStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traAccountPayableStatus] ADD  CONSTRAINT [DF_traAccountPayableStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ARNumber]  DEFAULT ('') FOR [ARNumber]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_CoAIDOfIncomePayment]  DEFAULT ((0)) FOR [CoAIDOfIncomePayment]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_Modules]  DEFAULT ('') FOR [Modules]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ReferencesID]  DEFAULT ('') FOR [ReferencesID]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ReferencesNote]  DEFAULT ('') FOR [ReferencesNote]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ARDate]  DEFAULT (getdate()) FOR [ARDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_DueDateValue]  DEFAULT ((0)) FOR [DueDateValue]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_DueDate]  DEFAULT (getdate()) FOR [DueDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_TotalAmount]  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_TotalAmountDPAllocate]  DEFAULT ((0)) FOR [TotalAmountDPAllocate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_Percentage]  DEFAULT ((0)) FOR [Percentage]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_PaymentBy]  DEFAULT ('') FOR [PaymentBy]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_PaymentDate]  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_TaxInvoiceNumber]  DEFAULT ('') FOR [TaxInvoiceNumber]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_IsClosedPeriod]  DEFAULT ((0)) FOR [IsClosedPeriod]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ClosedPeriodBy]  DEFAULT ('') FOR [ClosedPeriodBy]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_ClosedPeriodDate]  DEFAULT (getdate()) FOR [ClosedPeriodDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traAccountReceivable] ADD  CONSTRAINT [DF_traAccountReceivable_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traAccountReceivableDet] ADD  CONSTRAINT [DF_traAccountReceivableDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traAccountReceivableDet] ADD  CONSTRAINT [DF_traAccountReceivableDet_ARID]  DEFAULT ('') FOR [ARID]
GO
ALTER TABLE [dbo].[traAccountReceivableDet] ADD  CONSTRAINT [DF_traAccountReceivableDet_SalesID]  DEFAULT ('') FOR [SalesID]
GO
ALTER TABLE [dbo].[traAccountReceivableDet] ADD  CONSTRAINT [DF_traAccountReceivableDet_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[traAccountReceivableDet] ADD  CONSTRAINT [DF_traAccountReceivableDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traAccountReceivableDet] ADD  CONSTRAINT [DF_traAccountReceivableDet_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traAccountReceivableDet] ADD  CONSTRAINT [DF_traAccountReceivableDet_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traAccountReceivableStatus] ADD  CONSTRAINT [DF_traAccountReceivableStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traAccountReceivableStatus] ADD  CONSTRAINT [DF_traAccountReceivableStatus_ARID]  DEFAULT ('') FOR [ARID]
GO
ALTER TABLE [dbo].[traAccountReceivableStatus] ADD  CONSTRAINT [DF_traAccountReceivableStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traAccountReceivableStatus] ADD  CONSTRAINT [DF_traAccountReceivableStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traAccountReceivableStatus] ADD  CONSTRAINT [DF_traAccountReceivableStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traAccountReceivableStatus] ADD  CONSTRAINT [DF_traAccountReceivableStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_TransactionDate]  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_ReferencesID]  DEFAULT ('') FOR [ReferencesID]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_COAIDParent]  DEFAULT ((0)) FOR [COAIDParent]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_COAIDChild]  DEFAULT ((0)) FOR [COAIDChild]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_DebitAmount]  DEFAULT ((0)) FOR [DebitAmount]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_CreditAmount]  DEFAULT ((0)) FOR [CreditAmount]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_ReferencesNo]  DEFAULT ('') FOR [ReferencesNo]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_IsClosedPeriod]  DEFAULT ((0)) FOR [IsClosedPeriod]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_ClosedPeriodBy]  DEFAULT ('') FOR [ClosedPeriodBy]
GO
ALTER TABLE [dbo].[traBukuBesar] ADD  CONSTRAINT [DF_traBukuBesar_ClosedPeriodDate]  DEFAULT (getdate()) FOR [ClosedPeriodDate]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_CONumber]  DEFAULT ('') FOR [CONumber]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_CODate]  DEFAULT (getdate()) FOR [CODate]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_DeliveryPeriodFrom]  DEFAULT (getdate()) FOR [DeliveryPeriodFrom]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_DeliveryPeriodTo]  DEFAULT (getdate()) FOR [DeliveryPeriodTo]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_AllowanceProduction]  DEFAULT ((0)) FOR [AllowanceProduction]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traConfirmationOrder] ADD  CONSTRAINT [DF_traConfirmationOrder_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_COID]  DEFAULT ('') FOR [COID]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_PODetailID]  DEFAULT ('') FOR [PODetailID]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_OrderNumberSupplier]  DEFAULT ('') FOR [OrderNumberSupplier]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_DeliveryAddress]  DEFAULT ('') FOR [DeliveryAddress]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_PCQuantity]  DEFAULT ((0)) FOR [PCQuantity]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_PCWeight]  DEFAULT ((0)) FOR [PCWeight]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_DCQuantity]  DEFAULT ((0)) FOR [DCQuantity]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_DCWeight]  DEFAULT ((0)) FOR [DCWeight]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_SCQuantity]  DEFAULT ((0)) FOR [SCQuantity]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_SCWeight]  DEFAULT ((0)) FOR [SCWeight]
GO
ALTER TABLE [dbo].[traConfirmationOrderDet] ADD  CONSTRAINT [DF_traConfirmationOrderDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traConfirmationOrderPaymentTerm] ADD  CONSTRAINT [DF_traConfirmationOrderPaymentTerm_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traConfirmationOrderPaymentTerm] ADD  CONSTRAINT [DF_traConfirmationOrderPaymentTerm_COID]  DEFAULT ('') FOR [COID]
GO
ALTER TABLE [dbo].[traConfirmationOrderPaymentTerm] ADD  CONSTRAINT [DF_traConfirmationOrderPaymentTerm_Percentage]  DEFAULT ((0)) FOR [Percentage]
GO
ALTER TABLE [dbo].[traConfirmationOrderPaymentTerm] ADD  CONSTRAINT [DF_traConfirmationOrderPaymentTerm_PaymentTypeID]  DEFAULT ((0)) FOR [PaymentTypeID]
GO
ALTER TABLE [dbo].[traConfirmationOrderPaymentTerm] ADD  CONSTRAINT [DF_traConfirmationOrderPaymentTerm_PaymentModeID]  DEFAULT ((0)) FOR [PaymentModeID]
GO
ALTER TABLE [dbo].[traConfirmationOrderPaymentTerm] ADD  CONSTRAINT [DF_traConfirmationOrderPaymentTerm_CreditTerm]  DEFAULT ((0)) FOR [CreditTerm]
GO
ALTER TABLE [dbo].[traConfirmationOrderPaymentTerm] ADD  CONSTRAINT [DF_traConfirmationOrderPaymentTerm_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traConfirmationOrderStatus] ADD  CONSTRAINT [DF_traConfirmationOrderStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traConfirmationOrderStatus] ADD  CONSTRAINT [DF_traConfirmationOrderStatus_COID]  DEFAULT ('') FOR [COID]
GO
ALTER TABLE [dbo].[traConfirmationOrderStatus] ADD  CONSTRAINT [DF_traConfirmationOrderStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traConfirmationOrderStatus] ADD  CONSTRAINT [DF_traConfirmationOrderStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traConfirmationOrderStatus] ADD  CONSTRAINT [DF_traConfirmationOrderStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traConfirmationOrderStatus] ADD  CONSTRAINT [DF_traConfirmationOrderStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_CostNumber]  DEFAULT ('') FOR [CostNumber]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_CoAID]  DEFAULT ((0)) FOR [CoAID]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ReferencesID]  DEFAULT ('') FOR [ReferencesID]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ReferencesNote]  DEFAULT ('') FOR [ReferencesNote]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_CostDate]  DEFAULT (getdate()) FOR [CostDate]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_TotalAmount]  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_PaymentBy]  DEFAULT ('') FOR [PaymentBy]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_PaymentDate]  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_TaxInvoiceNumber]  DEFAULT ('') FOR [TaxInvoiceNumber]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_IsClosedPeriod]  DEFAULT ((0)) FOR [IsClosedPeriod]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ClosedPeriodBy]  DEFAULT ('') FOR [ClosedPeriodBy]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_ClosedPeriodDate]  DEFAULT (getdate()) FOR [ClosedPeriodDate]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traCost] ADD  CONSTRAINT [DF_traCost_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traCostDet] ADD  CONSTRAINT [DF_traCostDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traCostDet] ADD  CONSTRAINT [DF_traCostDet_CostID]  DEFAULT ('') FOR [CostID]
GO
ALTER TABLE [dbo].[traCostDet] ADD  CONSTRAINT [DF_traCostDet_COAID]  DEFAULT ('') FOR [COAID]
GO
ALTER TABLE [dbo].[traCostDet] ADD  CONSTRAINT [DF_traCostDet_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[traCostDet] ADD  CONSTRAINT [DF_traCostDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traCostStatus] ADD  CONSTRAINT [DF_traCostStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traCostStatus] ADD  CONSTRAINT [DF_traCostStatus_CostID]  DEFAULT ('') FOR [CostID]
GO
ALTER TABLE [dbo].[traCostStatus] ADD  CONSTRAINT [DF_traCostStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traCostStatus] ADD  CONSTRAINT [DF_traCostStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traCostStatus] ADD  CONSTRAINT [DF_traCostStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traCostStatus] ADD  CONSTRAINT [DF_traCostStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_CuttingNumber]  DEFAULT ('') FOR [CuttingNumber]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_CuttingDate]  DEFAULT (getdate()) FOR [CuttingDate]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_ReferencesNumber]  DEFAULT ('') FOR [ReferencesNumber]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traCutting] ADD  CONSTRAINT [DF_traCutting_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_CuttingID]  DEFAULT ('') FOR [CuttingID]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_PODetailID]  DEFAULT ('') FOR [PODetailID]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_GroupID]  DEFAULT ((0)) FOR [GroupID]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traCuttingDet] ADD  CONSTRAINT [DF_traCuttingDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_CuttingID]  DEFAULT ('') FOR [CuttingID]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_GroupID]  DEFAULT ((0)) FOR [GroupID]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traCuttingDetResult] ADD  CONSTRAINT [DF_traCuttingDetResult_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traCuttingStatus] ADD  CONSTRAINT [DF_traCuttingStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traCuttingStatus] ADD  CONSTRAINT [DF_traCuttingStatus_CuttingID]  DEFAULT ('') FOR [CuttingID]
GO
ALTER TABLE [dbo].[traCuttingStatus] ADD  CONSTRAINT [DF_traCuttingStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traCuttingStatus] ADD  CONSTRAINT [DF_traCuttingStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traCuttingStatus] ADD  CONSTRAINT [DF_traCuttingStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traCuttingStatus] ADD  CONSTRAINT [DF_traCuttingStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_DeliveryNumber]  DEFAULT ('') FOR [DeliveryNumber]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_DeliveryDate]  DEFAULT (getdate()) FOR [DeliveryDate]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_SCID]  DEFAULT ('') FOR [SCID]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_PlatNumber]  DEFAULT ('') FOR [PlatNumber]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_Driver]  DEFAULT ('') FOR [Driver]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_ReferencesNumber]  DEFAULT ('') FOR [ReferencesNumber]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalDPPTransport]  DEFAULT ((0)) FOR [TotalDPPTransport]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalPPNTransport]  DEFAULT ((0)) FOR [TotalPPNTransport]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_TotalPPHTransport]  DEFAULT ((0)) FOR [TotalPPHTransport]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traDelivery] ADD  CONSTRAINT [DF_traDelivery_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_DeliveryID]  DEFAULT ('') FOR [DeliveryID]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_SCDetailID]  DEFAULT ('') FOR [SCDetailID]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_GroupID]  DEFAULT ((0)) FOR [GroupID]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traDeliveryDet] ADD  CONSTRAINT [DF_traDeliveryDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_DeliveryID]  DEFAULT ('') FOR [DeliveryID]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_GroupID]  DEFAULT ((0)) FOR [GroupID]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_PODetailID]  DEFAULT ('') FOR [PODetailID]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traDeliveryDetTransport] ADD  CONSTRAINT [DF_traDeliveryDetTransport_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traDeliveryStatus] ADD  CONSTRAINT [DF_traDeliveryStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traDeliveryStatus] ADD  CONSTRAINT [DF_traDeliveryStatus_DeliveryID]  DEFAULT ('') FOR [DeliveryID]
GO
ALTER TABLE [dbo].[traDeliveryStatus] ADD  CONSTRAINT [DF_traDeliveryStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traDeliveryStatus] ADD  CONSTRAINT [DF_traDeliveryStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traDeliveryStatus] ADD  CONSTRAINT [DF_traDeliveryStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traDeliveryStatus] ADD  CONSTRAINT [DF_traDeliveryStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_JournalNo]  DEFAULT ('') FOR [JournalNo]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ReferencesID]  DEFAULT ('') FOR [ReferencesID]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_JournalDate]  DEFAULT (getdate()) FOR [JournalDate]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_TotalAmount]  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_IsAutoGenerate]  DEFAULT ((0)) FOR [IsAutoGenerate]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_IsClosedPeriod]  DEFAULT ((0)) FOR [IsClosedPeriod]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ClosedPeriodBy]  DEFAULT ('') FOR [ClosedPeriodBy]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_ClosedPeriodDate]  DEFAULT (getdate()) FOR [ClosedPeriodDate]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traJournal] ADD  CONSTRAINT [DF_traJournal_Initial]  DEFAULT ('') FOR [Initial]
GO
ALTER TABLE [dbo].[traJournalDet] ADD  CONSTRAINT [DF_traJournalDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traJournalDet] ADD  CONSTRAINT [DF_traJournalDet_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traJournalDet] ADD  CONSTRAINT [DF_traJournalDet_COAID]  DEFAULT ((0)) FOR [COAID]
GO
ALTER TABLE [dbo].[traJournalDet] ADD  CONSTRAINT [DF_traJournalDet_DebitAmount]  DEFAULT ((0)) FOR [DebitAmount]
GO
ALTER TABLE [dbo].[traJournalDet] ADD  CONSTRAINT [DF_traJournalDet_CreditAmount]  DEFAULT ((0)) FOR [CreditAmount]
GO
ALTER TABLE [dbo].[traJournalDet] ADD  CONSTRAINT [DF_traJournalDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traJournalStatus] ADD  CONSTRAINT [DF_traJournalStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traJournalStatus] ADD  CONSTRAINT [DF_traJournalStatus_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traJournalStatus] ADD  CONSTRAINT [DF_traJournalStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traJournalStatus] ADD  CONSTRAINT [DF_traJournalStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traJournalStatus] ADD  CONSTRAINT [DF_traJournalStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traJournalStatus] ADD  CONSTRAINT [DF_traJournalStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_OrderNumber]  DEFAULT ('') FOR [OrderNumber]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_ReferencesNumber]  DEFAULT ('') FOR [ReferencesNumber]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traOrderRequest] ADD  CONSTRAINT [DF_traOrderRequest_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_OrderRequestID]  DEFAULT ('') FOR [OrderRequestID]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_SCQuantity]  DEFAULT ((0)) FOR [SCQuantity]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_SCWeight]  DEFAULT ((0)) FOR [SCWeight]
GO
ALTER TABLE [dbo].[traOrderRequestDet] ADD  CONSTRAINT [DF_traOrderRequestDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traOrderRequestStatus] ADD  CONSTRAINT [DF_traOrderRequestStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traOrderRequestStatus] ADD  CONSTRAINT [DF_traOrderRequestStatus_OrderRequestID]  DEFAULT ('') FOR [OrderRequestID]
GO
ALTER TABLE [dbo].[traOrderRequestStatus] ADD  CONSTRAINT [DF_traOrderRequestStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traOrderRequestStatus] ADD  CONSTRAINT [DF_traOrderRequestStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traOrderRequestStatus] ADD  CONSTRAINT [DF_traOrderRequestStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traOrderRequestStatus] ADD  CONSTRAINT [DF_traOrderRequestStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_PCNumber]  DEFAULT ('') FOR [PCNumber]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_PCDate]  DEFAULT (getdate()) FOR [PCDate]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_DeliveryPeriodFrom]  DEFAULT (getdate()) FOR [DeliveryPeriodFrom]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_DeliveryPeriodTo]  DEFAULT (getdate()) FOR [DeliveryPeriodTo]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_AllowanceProduction]  DEFAULT ((0)) FOR [AllowanceProduction]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_Franco]  DEFAULT ('') FOR [Franco]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_DPAmount]  DEFAULT ((0)) FOR [DPAmount]
GO
ALTER TABLE [dbo].[traPurchaseContract] ADD  CONSTRAINT [DF_traPurchaseContract_ReceiveAmount]  DEFAULT ((0)) FOR [ReceiveAmount]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_PCID]  DEFAULT ('') FOR [PCID]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_CODetailID]  DEFAULT ('') FOR [CODetailID]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_DCQuantity]  DEFAULT ((0)) FOR [DCQuantity]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_DCWeight]  DEFAULT ((0)) FOR [DCWeight]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_CuttingQuantity]  DEFAULT ((0)) FOR [CuttingQuantity]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_CuttingWeight]  DEFAULT ((0)) FOR [CuttingWeight]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseContractDet] ADD  CONSTRAINT [DF_traPurchaseContractDet_ReceiveAmount]  DEFAULT ((0)) FOR [ReceiveAmount]
GO
ALTER TABLE [dbo].[traPurchaseContractPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseContractPaymentTerm_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseContractPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseContractPaymentTerm_PCID]  DEFAULT ('') FOR [PCID]
GO
ALTER TABLE [dbo].[traPurchaseContractPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseContractPaymentTerm_Percentage]  DEFAULT ((0)) FOR [Percentage]
GO
ALTER TABLE [dbo].[traPurchaseContractPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseContractPaymentTerm_PaymentTypeID]  DEFAULT ((0)) FOR [PaymentTypeID]
GO
ALTER TABLE [dbo].[traPurchaseContractPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseContractPaymentTerm_PaymentModeID]  DEFAULT ((0)) FOR [PaymentModeID]
GO
ALTER TABLE [dbo].[traPurchaseContractPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseContractPaymentTerm_CreditTerm]  DEFAULT ((0)) FOR [CreditTerm]
GO
ALTER TABLE [dbo].[traPurchaseContractPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseContractPaymentTerm_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseContractStatus] ADD  CONSTRAINT [DF_traPurchaseContractStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseContractStatus] ADD  CONSTRAINT [DF_traPurchaseContractStatus_PCID]  DEFAULT ('') FOR [PCID]
GO
ALTER TABLE [dbo].[traPurchaseContractStatus] ADD  CONSTRAINT [DF_traPurchaseContractStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traPurchaseContractStatus] ADD  CONSTRAINT [DF_traPurchaseContractStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traPurchaseContractStatus] ADD  CONSTRAINT [DF_traPurchaseContractStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traPurchaseContractStatus] ADD  CONSTRAINT [DF_traPurchaseContractStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_PONumber]  DEFAULT ('') FOR [PONumber]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_PODate]  DEFAULT (getdate()) FOR [PODate]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_PersonInCharge]  DEFAULT ('') FOR [PersonInCharge]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_DeliveryPeriodFrom]  DEFAULT (getdate()) FOR [DeliveryPeriodFrom]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_DeliveryPeriodTo]  DEFAULT (getdate()) FOR [DeliveryPeriodTo]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_DeliveryAddress]  DEFAULT ('') FOR [DeliveryAddress]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_Validity]  DEFAULT ('') FOR [Validity]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traPurchaseOrder] ADD  CONSTRAINT [DF_traPurchaseOrder_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_PONumber]  DEFAULT ('') FOR [PONumber]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_PODate]  DEFAULT (getdate()) FOR [PODate]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_PersonInCharge]  DEFAULT ('') FOR [PersonInCharge]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_DeliveryPeriodFrom]  DEFAULT ('2000/01/01') FOR [DeliveryPeriodFrom]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_DeliveryPeriodTo]  DEFAULT ('2000/01/01') FOR [DeliveryPeriodTo]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_DeliveryAddress]  DEFAULT ('') FOR [DeliveryAddress]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_DPAmount]  DEFAULT ((0)) FOR [DPAmount]
GO
ALTER TABLE [dbo].[traPurchaseOrderCutting] ADD  CONSTRAINT [DF_traPurchaseOrderCutting_ReceiveAmount]  DEFAULT ((0)) FOR [ReceiveAmount]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_POID]  DEFAULT ('') FOR [POID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_PCDetailID]  DEFAULT ('') FOR [PCDetailID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_DoneQuantity]  DEFAULT ((0)) FOR [DoneQuantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_DoneWeight]  DEFAULT ((0)) FOR [DoneWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderCuttingDet] ADD  CONSTRAINT [DF_traPurchaseOrderCuttingDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_POID]  DEFAULT ('') FOR [POID]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_COQuantity]  DEFAULT ((0)) FOR [COQuantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_COWeight]  DEFAULT ((0)) FOR [COWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderDet] ADD  CONSTRAINT [DF_traPurchaseOrderDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrderPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseOrderPaymentTerm_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrderPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseOrderPaymentTerm_POID]  DEFAULT ('') FOR [POID]
GO
ALTER TABLE [dbo].[traPurchaseOrderPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseOrderPaymentTerm_Percentage]  DEFAULT ((0)) FOR [Percentage]
GO
ALTER TABLE [dbo].[traPurchaseOrderPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseOrderPaymentTerm_PaymentTypeID]  DEFAULT ((0)) FOR [PaymentTypeID]
GO
ALTER TABLE [dbo].[traPurchaseOrderPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseOrderPaymentTerm_PaymentModeID]  DEFAULT ((0)) FOR [PaymentModeID]
GO
ALTER TABLE [dbo].[traPurchaseOrderPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseOrderPaymentTerm_CreditTerm]  DEFAULT ((0)) FOR [CreditTerm]
GO
ALTER TABLE [dbo].[traPurchaseOrderPaymentTerm] ADD  CONSTRAINT [DF_traPurchaseOrderPaymentTerm_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrderStatus] ADD  CONSTRAINT [DF_traPurchaseOrderStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrderStatus] ADD  CONSTRAINT [DF_traPurchaseOrderStatus_OrderRequestID]  DEFAULT ('') FOR [POID]
GO
ALTER TABLE [dbo].[traPurchaseOrderStatus] ADD  CONSTRAINT [DF_traPurchaseOrderStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traPurchaseOrderStatus] ADD  CONSTRAINT [DF_traPurchaseOrderStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderStatus] ADD  CONSTRAINT [DF_traPurchaseOrderStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderStatus] ADD  CONSTRAINT [DF_traPurchaseOrderStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_PONumber]  DEFAULT ('') FOR [PONumber]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_PODate]  DEFAULT (getdate()) FOR [PODate]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_CustomerID]  DEFAULT ((0)) FOR [CustomerID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_SCID]  DEFAULT ('') FOR [SCID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_PersonInCharge]  DEFAULT ('') FOR [PersonInCharge]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_DeliveryPeriodFrom]  DEFAULT ('2000/01/01') FOR [DeliveryPeriodFrom]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_DeliveryPeriodTo]  DEFAULT ('2000/01/01') FOR [DeliveryPeriodTo]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_DeliveryAddress]  DEFAULT ('') FOR [DeliveryAddress]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_DPAmount]  DEFAULT ((0)) FOR [DPAmount]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransport] ADD  CONSTRAINT [DF_traPurchaseOrderTransport_ReceiveAmount]  DEFAULT ((0)) FOR [ReceiveAmount]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_POID]  DEFAULT ('') FOR [POID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_SCDetailID]  DEFAULT ('') FOR [SCDetailID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_DoneQuantity]  DEFAULT ((0)) FOR [DoneQuantity]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_DoneWeight]  DEFAULT ((0)) FOR [DoneWeight]
GO
ALTER TABLE [dbo].[traPurchaseOrderTransportDet] ADD  CONSTRAINT [DF_traPurchaseOrderTransportDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_ReceiveNumber]  DEFAULT ('') FOR [ReceiveNumber]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_ReceiveDate]  DEFAULT (getdate()) FOR [ReceiveDate]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_PlatNumber]  DEFAULT ('') FOR [PlatNumber]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_Driver]  DEFAULT ('') FOR [Driver]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_ReferencesNumber]  DEFAULT ('') FOR [ReferencesNumber]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traReceive] ADD  CONSTRAINT [DF_traReceive_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_ReceiveID]  DEFAULT ('') FOR [ReceiveID]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_PCDetailID]  DEFAULT ('') FOR [PCDetailID]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traReceiveDet] ADD  CONSTRAINT [DF_traReceiveDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traReceiveStatus] ADD  CONSTRAINT [DF_traReceiveStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traReceiveStatus] ADD  CONSTRAINT [DF_traReceiveStatus_ReceiveID]  DEFAULT ('') FOR [ReceiveID]
GO
ALTER TABLE [dbo].[traReceiveStatus] ADD  CONSTRAINT [DF_traReceiveStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traReceiveStatus] ADD  CONSTRAINT [DF_traReceiveStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traReceiveStatus] ADD  CONSTRAINT [DF_traReceiveStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traReceiveStatus] ADD  CONSTRAINT [DF_traReceiveStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_ProgramID]  DEFAULT ((0)) FOR [ProgramID]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_CompanyID]  DEFAULT ((0)) FOR [CompanyID]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_SCNumber]  DEFAULT ('') FOR [SCNumber]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_SCDate]  DEFAULT (getdate()) FOR [SCDate]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_BPID]  DEFAULT ((0)) FOR [BPID]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_DeliveryPeriodFrom]  DEFAULT (getdate()) FOR [DeliveryPeriodFrom]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_DeliveryPeriodTo]  DEFAULT (getdate()) FOR [DeliveryPeriodTo]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_AllowanceProduction]  DEFAULT ((0)) FOR [AllowanceProduction]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_Franco]  DEFAULT ('') FOR [Franco]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_DelegationSeller]  DEFAULT ('') FOR [DelegationSeller]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_DelegationPositionSeller]  DEFAULT ('') FOR [DelegationPositionSeller]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_DelegationBuyer]  DEFAULT ('') FOR [DelegationBuyer]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_DelegationPositionBuyer]  DEFAULT ('') FOR [DelegationPositionBuyer]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_PPN]  DEFAULT ((0)) FOR [PPN]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_PPH]  DEFAULT ((0)) FOR [PPH]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_TotalQuantity]  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_TotalDPP]  DEFAULT ((0)) FOR [TotalDPP]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_TotalPPN]  DEFAULT ((0)) FOR [TotalPPN]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_TotalPPH]  DEFAULT ((0)) FOR [TotalPPH]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_RoundingManual]  DEFAULT ((0)) FOR [RoundingManual]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_COTotalQuantity]  DEFAULT ((0)) FOR [COTotalQuantity]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_COTotalWeight]  DEFAULT ((0)) FOR [COTotalWeight]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_COTotalDPP]  DEFAULT ((0)) FOR [COTotalDPP]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_JournalID]  DEFAULT ('') FOR [JournalID]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_StatusID]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_CompanyBankAccountID]  DEFAULT ((0)) FOR [CompanyBankAccountID]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_SubmitBy]  DEFAULT ('') FOR [SubmitBy]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_SubmitDate]  DEFAULT (getdate()) FOR [SubmitDate]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_ApproveL1]  DEFAULT ('') FOR [ApproveL1]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_ApproveL1Date]  DEFAULT (getdate()) FOR [ApproveL1Date]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_ApprovedBy]  DEFAULT ('') FOR [ApprovedBy]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_ApprovedDate]  DEFAULT (getdate()) FOR [ApprovedDate]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_CreatedBy]  DEFAULT ('SYSTEM') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_LogInc]  DEFAULT ((0)) FOR [LogInc]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_LogBy]  DEFAULT ('SYSTEM') FOR [LogBy]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_DPAmount]  DEFAULT ((0)) FOR [DPAmount]
GO
ALTER TABLE [dbo].[traSalesContract] ADD  CONSTRAINT [DF_traSalesContract_ReceiveAmount]  DEFAULT ((0)) FOR [ReceiveAmount]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_SCID]  DEFAULT ('') FOR [SCID]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_ORDetailID]  DEFAULT ('') FOR [ORDetailID]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_GroupID]  DEFAULT ((0)) FOR [GroupID]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_DCQuantity]  DEFAULT ((0)) FOR [DCQuantity]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_DCWeight]  DEFAULT ((0)) FOR [DCWeight]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_POTransportQuantity]  DEFAULT ((0)) FOR [POTransportQuantity]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_POTransportWeight]  DEFAULT ((0)) FOR [POTransportWeight]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traSalesContractDet] ADD  CONSTRAINT [DF_traSalesContractDet_ReceiveAmount]  DEFAULT ((0)) FOR [ReceiveAmount]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_SCID]  DEFAULT ('') FOR [SCID]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_CODetailID]  DEFAULT ('') FOR [CODetailID]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_GroupID]  DEFAULT ((0)) FOR [GroupID]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_ItemID]  DEFAULT ((0)) FOR [ItemID]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_TotalPrice]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[traSalesContractDetConfirmationOrder] ADD  CONSTRAINT [DF_traSalesContractDetConfirmationOrder_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[traSalesContractPaymentTerm] ADD  CONSTRAINT [DF_traSalesContractPaymentTerm_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traSalesContractPaymentTerm] ADD  CONSTRAINT [DF_traSalesContractPaymentTerm_SCID]  DEFAULT ('') FOR [SCID]
GO
ALTER TABLE [dbo].[traSalesContractPaymentTerm] ADD  CONSTRAINT [DF_traSalesContractPaymentTerm_Percentage]  DEFAULT ((0)) FOR [Percentage]
GO
ALTER TABLE [dbo].[traSalesContractPaymentTerm] ADD  CONSTRAINT [DF_traSalesContractPaymentTerm_PaymentTypeID]  DEFAULT ((0)) FOR [PaymentTypeID]
GO
ALTER TABLE [dbo].[traSalesContractPaymentTerm] ADD  CONSTRAINT [DF_traSalesContractPaymentTerm_PaymentModeID]  DEFAULT ((0)) FOR [PaymentModeID]
GO
ALTER TABLE [dbo].[traSalesContractPaymentTerm] ADD  CONSTRAINT [DF_traSalesContractPaymentTerm_CreditTerm]  DEFAULT ((0)) FOR [CreditTerm]
GO
ALTER TABLE [dbo].[traSalesContractPaymentTerm] ADD  CONSTRAINT [DF_traSalesContractPaymentTerm_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
ALTER TABLE [dbo].[traSalesContractStatus] ADD  CONSTRAINT [DF_traSalesContractStatus_ID]  DEFAULT ('') FOR [ID]
GO
ALTER TABLE [dbo].[traSalesContractStatus] ADD  CONSTRAINT [DF_traSalesContractStatus_SCID]  DEFAULT ('') FOR [SCID]
GO
ALTER TABLE [dbo].[traSalesContractStatus] ADD  CONSTRAINT [DF_traSalesContractStatus_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[traSalesContractStatus] ADD  CONSTRAINT [DF_traSalesContractStatus_StatusBy]  DEFAULT ((0)) FOR [StatusBy]
GO
ALTER TABLE [dbo].[traSalesContractStatus] ADD  CONSTRAINT [DF_traSalesContractStatus_StatusDate]  DEFAULT ((0)) FOR [StatusDate]
GO
ALTER TABLE [dbo].[traSalesContractStatus] ADD  CONSTRAINT [DF_traSalesContractStatus_Remarks]  DEFAULT ((0)) FOR [Remarks]
GO
