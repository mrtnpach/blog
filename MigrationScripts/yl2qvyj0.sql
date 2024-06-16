IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Class] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Year] int NOT NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Colleges] (
    [Id] int NOT NULL IDENTITY,
    [University] nvarchar(max) NOT NULL,
    [Faculty] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Colleges] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Students] (
    [Id] int NOT NULL IDENTITY,
    [Legajo] int NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [EmailAddress] nvarchar(max) NOT NULL,
    [CollegeId] int NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Students_Colleges_CollegeId] FOREIGN KEY ([CollegeId]) REFERENCES [Colleges] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Assignments] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Date] datetime2 NOT NULL,
    [Filename] nvarchar(max) NULL,
    [StudentId] int NOT NULL,
    [ClassId] int NOT NULL,
    CONSTRAINT [PK_Assignments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Assignments_Class_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [Class] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Assignments_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [InfoItems] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [StudentId] int NULL,
    CONSTRAINT [PK_InfoItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InfoItems_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([Id])
);
GO

CREATE INDEX [IX_Assignments_ClassId] ON [Assignments] ([ClassId]);
GO

CREATE INDEX [IX_Assignments_StudentId] ON [Assignments] ([StudentId]);
GO

CREATE INDEX [IX_InfoItems_StudentId] ON [InfoItems] ([StudentId]);
GO

CREATE INDEX [IX_Students_CollegeId] ON [Students] ([CollegeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240616041658_InitialMigration', N'6.0.31');
GO

COMMIT;
GO

