
USE master

IF NOT EXISTS(SELECT * from sysdatabases where name='SkillsCrafter')
BEGIN
  CREATE DATABASE SkillsCrafter
END
GO

USE SkillsCrafter

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[Organizations]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [Organizations] (
	  [OrgId] 	[int] 			NOT NULL PRIMARY KEY,
	  [OrgName] [nvarchar] (64) NOT NULL UNIQUE
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[Resources]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [Resources] (
	  [resourceId] 	[int] 			NOT NULL PRIMARY KEY,
	  [OrgId] 		[int] 			NULL,
	  [Username] 	[nvarchar] (64) NOT NULL UNIQUE,
	  [Password] 	[nvarchar] (64) NOT NULL,	--TODO:change it to varbinary
	  [FirstName] 	[nvarchar] (32) NOT NULL,
	  [LastName] 	[nvarchar] (32) NOT NULL,
	  [Email] 		[nvarchar] (64) NOT NULL,
	  [Title] 		[nvarchar] (64) NOT NULL,
	  [Created] 	[datetime] 		NOT NULL DEFAULT GETDATE(),
	  [Modified] 	[datetime] 		NULL,
	  [StartDate] 	[datetime] 		NOT NULL DEFAULT GETDATE(),
	  [LastDate] 	[datetime] 		NULL,
	  [isActive] 	[bit] 			NOT NULL DEFAULT 1,
	  [isManager] 	[bit] 			NOT NULL DEFAULT 0,
	  [isAdmin] 	[bit] 			NOT NULL DEFAULT 0,
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[Portfolios]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [Portfolios] (
	  [Id] 			[int] 			NOT NULL PRIMARY KEY,
	  [OrgId] 		[int] 			NULL,
	  [Name] 		[nvarchar] (32) NOT NULL UNIQUE,
	  [isActive] 	[bit]		 	NOT NULL DEFAULT 1,
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[Products]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [Products] (
	  [Id] 			[int] 			NOT NULL PRIMARY KEY,
	  [OrgId] 		[int] 			NULL,
	  [Name] 		[nvarchar] (32) NOT NULL UNIQUE,
	  [isActive] 	[bit]		 	NOT NULL DEFAULT 1,
	  [PortfolioName] [nvarchar] (32) NOT NULL 
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[SkillsDefinitions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [SkillsDefinitions] (
	  [Id] 			[int] 			NOT NULL PRIMARY KEY,
	  [OrgId] 		[int] 			NULL,
	  [Name] 		[nvarchar] (64) NOT NULL UNIQUE,
	  [SkillType] 	[nvarchar] (32) NULL,
	  [Beginner] 	[nvarchar] (250) NULL,
	  [Intermediate] [nvarchar] (250) NULL,
	  [Proficient] 	[nvarchar] (250) NULL,
	  [Advanced] 	[nvarchar] (250) NULL,
	  [Expert] 		[nvarchar] (250) NULL,
	  [Created] 	[datetime] 		NOT NULL DEFAULT GETDATE(),
	  [Modified] 	[datetime] 		NULL,
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[SkillAssociations]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [SkillAssociations] (
	  [Id] 			[int] 			NOT NULL PRIMARY KEY,
	  [OrgId] 		[int] 			NULL,
	  [ProductName] [nvarchar] (32) NOT NULL,
	  [SkillName] 	[nvarchar] (64) NOT NULL,
	  [SkillType] 	[nvarchar] (32) NOT NULL,
	  [Categoty] 	[nvarchar] (32) NOT NULL,
	  [Role] 		[nvarchar] (32) NOT NULL,
	  [Created] 	[datetime] 		NOT NULL DEFAULT GETDATE(),
	  [Modified] 	[datetime] 		NULL,
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[SkillAssesment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [SkillAssesment] (
	  [Id] 			[int] 			NOT NULL PRIMARY KEY,
	  [OrgId] 		[int] 			NULL,
	  [ProductName] [nvarchar] (32) NOT NULL,
	  [SkillName] 	[nvarchar] (64) NOT NULL,
	  [SkillType] 	[nvarchar] (32) NOT NULL,
	  [Categoty] 	[nvarchar] (32) NOT NULL,
	  [Role] 		[nvarchar] (32) NOT NULL,
	  [resName] 	[nvarchar] (64) NOT NULL,
	  [resRating] 	[float] 		NULL,
	  [ManagerName] [nvarchar] (64) NOT NULL,
	  [ManagerRating] [float] 		NULL,
	  [FinalRating] [float] 		NULL,
	  [Created] 	[datetime] 		NOT NULL DEFAULT GETDATE(),
	  [Modified] 	[datetime] 		NULL,
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[KnowledgeActions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [KnowledgeActions] (
	  [Id] 			[int] 			NOT NULL PRIMARY KEY,
	  [OrgId] 		[int] 			NULL,
	  [ProductName] [nvarchar] (32) NOT NULL,
	  [TrainingCourse] 	[nvarchar] (64) NOT NULL,
	  [ActionType] 	[nvarchar] (32) NULL,
	  [Duration] 	[nvarchar] (32) NULL,
	  [SelfAssesment] [nvarchar] (250) NULL,
	  [Status] 		[nvarchar] (16) NULL,
	  [Created] 	[datetime] 		NOT NULL DEFAULT GETDATE(),
	  [Modified] 	[datetime] 		NULL,
	) ON [PRIMARY]
END
