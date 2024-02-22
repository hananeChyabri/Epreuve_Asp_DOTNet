﻿/*
Deployment script for DB_ProduitEco

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_ProduitEco"
:setvar DefaultFilePrefix "DB_ProduitEco"
:setvar DefaultDataPath "C:\Users\h.chyabri\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\h.chyabri\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Categorie]...';


GO
CREATE TABLE [dbo].[Categorie] (
    [Categorie] NVARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([Categorie] ASC)
);


GO
PRINT N'Creating Table [dbo].[Commande]...';


GO
CREATE TABLE [dbo].[Commande] (
    [Id_Commande]   INT      IDENTITY (1, 1) NOT NULL,
    [Date_Commande] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Commande] ASC)
);


GO
PRINT N'Creating Table [dbo].[EcoScore]...';


GO
CREATE TABLE [dbo].[EcoScore] (
    [EcoScore] CHAR (1) NOT NULL,
    PRIMARY KEY CLUSTERED ([EcoScore] ASC)
);


GO
PRINT N'Creating Table [dbo].[Media]...';


GO
CREATE TABLE [dbo].[Media] (
    [Id_Media]   INT            IDENTITY (1, 1) NOT NULL,
    [url_image]  NVARCHAR (256) NOT NULL,
    [Id_Produit] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Media] ASC)
);


GO
PRINT N'Creating Table [dbo].[Panier]...';


GO
CREATE TABLE [dbo].[Panier] (
    [Id_Panier]   INT IDENTITY (1, 1) NOT NULL,
    [Id_Commande] INT NOT NULL,
    [Id_Produit]  INT NOT NULL,
    [Quantite]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Panier] ASC)
);


GO
PRINT N'Creating Table [dbo].[Produit]...';


GO
CREATE TABLE [dbo].[Produit] (
    [Id_Produit]   INT             IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (100)  NOT NULL,
    [Description]  NVARCHAR (255)  NOT NULL,
    [prix]         DECIMAL (10, 2) NOT NULL,
    [Nombre_vente] INT             NOT NULL,
    [EcoScore]     CHAR (1)        NOT NULL,
    [Categorie]    NVARCHAR (64)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Produit] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Media_Produit]...';


GO
ALTER TABLE [dbo].[Media]
    ADD CONSTRAINT [FK_Media_Produit] FOREIGN KEY ([Id_Produit]) REFERENCES [dbo].[Produit] ([Id_Produit]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Panier_Commande]...';


GO
ALTER TABLE [dbo].[Panier]
    ADD CONSTRAINT [FK_Panier_Commande] FOREIGN KEY ([Id_Commande]) REFERENCES [dbo].[Commande] ([Id_Commande]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Panier_Produit]...';


GO
ALTER TABLE [dbo].[Panier]
    ADD CONSTRAINT [FK_Panier_Produit] FOREIGN KEY ([Id_Produit]) REFERENCES [dbo].[Produit] ([Id_Produit]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Produit_EcoScore]...';


GO
ALTER TABLE [dbo].[Produit]
    ADD CONSTRAINT [FK_Produit_EcoScore] FOREIGN KEY ([EcoScore]) REFERENCES [dbo].[EcoScore] ([EcoScore]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Produit_Categorie]...';


GO
ALTER TABLE [dbo].[Produit]
    ADD CONSTRAINT [FK_Produit_Categorie] FOREIGN KEY ([Categorie]) REFERENCES [dbo].[Categorie] ([Categorie]);


GO
PRINT N'Creating Procedure [dbo].[SP_Categorie_GetAll]...';


GO
CREATE PROCEDURE [dbo].[SP_Categorie_GetAll]
AS
BEGIN
    SELECT [Categorie]
    FROM [Categorie];
END
GO
PRINT N'Creating Procedure [dbo].[SP_Media_Insert]...';


GO
CREATE PROCEDURE [dbo].[SP_Media_Insert]
    @url_image NVARCHAR(256),
    @Id_Produit INT
AS

    INSERT INTO Media (url_image, Id_Produit)
    VALUES (@url_image, @Id_Produit);
GO
PRINT N'Creating Procedure [dbo].[SP_Produit_Delete]...';


GO
CREATE PROCEDURE [dbo].[SP_Produit_Delete]
	@id_produit INT
AS
	DELETE FROM [Produit]
		WHERE [Id_Produit] = @id_produit
GO
PRINT N'Creating Procedure [dbo].[SP_Produit_GetAll]...';


GO
CREATE PROCEDURE [dbo].[SP_Produit_GetAll]
AS
	SELECT	[Id_Produit],
			[Nom],
			[Description],
			[prix],
			[Nombre_vente],
			[EcoScore],
			[Categorie]
		FROM [Produit]
GO
PRINT N'Creating Procedure [dbo].[SP_Produit_GetById]...';


GO
CREATE PROCEDURE [dbo].[SP_Produit_GetById]
    @id_Produit INT
AS
    SELECT [Id_Produit],
           [Nom],
           [Description],
           [prix],
           [Nombre_vente],
           [EcoScore],
           [Categorie]
    FROM [dbo].[Produit]
    WHERE [Id_Produit] = @id_Produit;
GO
PRINT N'Creating Procedure [dbo].[SP_Produit_GetPlusPopulaires]...';


GO
CREATE PROCEDURE [dbo].[SP_Produit_GetPlusPopulaires]
AS
BEGIN
  SELECT [Id_Produit], [Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie]
  FROM [Produit]
  WHERE [Nombre_vente] > (SELECT AVG(Nombre_vente) FROM Produit);
END
GO
PRINT N'Creating Procedure [dbo].[SP_Produit_Insert]...';


GO
CREATE PROCEDURE [dbo].[SP_Produit_Insert]
    @nom NVARCHAR(64),
    @description NVARCHAR(64),
    @prix DECIMAL(10, 2),
    @nombreVente INT,
    @ecoScore CHAR,
    @categorie NVARCHAR(64)
AS
    INSERT INTO [Produit] ([Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie])
	OUTPUT [inserted].[Id_Produit]
    VALUES (@nom, @description, @prix, @nombreVente, @ecoScore, @categorie)
GO
PRINT N'Creating Procedure [dbo].[SP_Produit_Update]...';


GO
CREATE PROCEDURE [dbo].[SP_Produit_Update]
    @id_Produit INT,
    @nom NVARCHAR(100),
    @description NVARCHAR(255),
    @prix DECIMAL(10, 2),
    @ecoScore CHAR,
    @categorie NVARCHAR(64)
AS
    UPDATE [dbo].[Produit]
    SET [Nom] = @nom,
        [Description] = @description,
        [prix] = @prix,
        [EcoScore] = @ecoScore,
        [Categorie] = @categorie
    WHERE [Id_Produit] = @id_Produit
GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
