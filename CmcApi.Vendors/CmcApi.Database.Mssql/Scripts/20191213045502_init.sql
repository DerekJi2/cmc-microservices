IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Vendors] (
    [Id] int NOT NULL IDENTITY,
    [Guid] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [Version] int NULL DEFAULT 1,
    [Created] datetime2 NOT NULL DEFAULT (GETDATE()),
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT 0,
    [Code] nvarchar(25) NULL,
    [AbnNum] nvarchar(25) NULL,
    [LegalName] nvarchar(255) NULL,
    [BusinessName] nvarchar(255) NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191213045502_init', N'2.2.6-servicing-10079');

GO

