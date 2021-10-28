
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/24/2021 15:44:36
-- Generated from EDMX file: D:\Projects\Asp.NETMVCCRUD-master\Asp.NETMVCCRUD-master\Asp.NETMVCCRUD\Models\DBModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MvcCRUDDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CarDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarDetails];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Position] varchar(50)  NULL,
    [Office] varchar(50)  NULL,
    [Age] int  NULL,
    [Salary] int  NULL
);
GO

-- Creating table 'CarDetails'
CREATE TABLE [dbo].[CarDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CarId] int  NOT NULL,
    [PlateNumber] varchar(50)  NOT NULL,
    [Model] nvarchar(50)  NULL,
    [Colour] nvarchar(50)  NULL,
    [Description] varchar(100)  NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CarName] varchar(50)  NULL,
    [SerialNumber] int  NULL,
    [Manufacturer] varchar(50)  NULL,
    [YearOfMenufacturer] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [Id], [PlateNumber] in table 'CarDetails'
ALTER TABLE [dbo].[CarDetails]
ADD CONSTRAINT [PK_CarDetails]
    PRIMARY KEY CLUSTERED ([Id], [PlateNumber] ASC);
GO

-- Creating primary key on [Id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------