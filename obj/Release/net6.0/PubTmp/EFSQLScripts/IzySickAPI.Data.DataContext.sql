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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE TABLE [Docteurss] (
        [DocteurId] int NOT NULL IDENTITY,
        [Specialisation] nvarchar(max) NULL,
        [Nom] nvarchar(max) NOT NULL,
        [Prenom] nvarchar(max) NOT NULL,
        [Age] int NULL,
        [Sexe] int NULL,
        [Email] nvarchar(max) NULL,
        [Telephone] nvarchar(max) NULL,
        [Mdp] nvarchar(max) NOT NULL,
        [Poste] nvarchar(max) NULL,
        [Image] varbinary(max) NULL,
        CONSTRAINT [PK_Docteurss] PRIMARY KEY ([DocteurId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE TABLE [Medicamentss] (
        [MedicamentsId] int NOT NULL IDENTITY,
        [NomMedicament] nvarchar(max) NOT NULL,
        [NbEnStock] int NULL,
        [Type] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Prix] int NULL,
        CONSTRAINT [PK_Medicamentss] PRIMARY KEY ([MedicamentsId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE TABLE [Receptionnistess] (
        [ReceptionnisteId] int NOT NULL IDENTITY,
        [Nom] nvarchar(max) NOT NULL,
        [Prenom] nvarchar(max) NOT NULL,
        [Age] int NULL,
        [Sexe] int NULL,
        [Email] nvarchar(max) NULL,
        [Telephone] nvarchar(max) NULL,
        [Mdp] nvarchar(max) NOT NULL,
        [Poste] nvarchar(max) NULL,
        [Image] varbinary(max) NULL,
        CONSTRAINT [PK_Receptionnistess] PRIMARY KEY ([ReceptionnisteId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE TABLE [MedicamentVenduss] (
        [MedicamentVenduId] int NOT NULL IDENTITY,
        [QuantiteVendu] int NULL,
        [MedicamentsId] int NOT NULL,
        CONSTRAINT [PK_MedicamentVenduss] PRIMARY KEY ([MedicamentVenduId]),
        CONSTRAINT [FK_MedicamentVenduss_Medicamentss_MedicamentsId] FOREIGN KEY ([MedicamentsId]) REFERENCES [Medicamentss] ([MedicamentsId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE TABLE [Patientss] (
        [PatientId] int NOT NULL IDENTITY,
        [Image] varbinary(max) NULL,
        [Urgence] int NULL,
        [Hospitalise] int NULL,
        [Batiment] nvarchar(max) NULL,
        [Chambre] int NULL,
        [Etage] int NULL,
        [Adresse] nvarchar(max) NULL,
        [Maladie] nvarchar(max) NULL,
        [Traitement] nvarchar(max) NULL,
        [MedicamentsId] int NULL,
        [DateRdv] datetime2 NULL,
        [DateHosp] datetime2 NULL,
        [DateSortie] datetime2 NULL,
        [Limite] int NULL,
        [Autorisation] int NULL,
        [Motif] nvarchar(max) NULL,
        [DocteurId] int NOT NULL,
        [Nom] nvarchar(max) NOT NULL,
        [Prenom] nvarchar(max) NOT NULL,
        [Age] int NULL,
        [Sexe] int NULL,
        [Email] nvarchar(max) NULL,
        [Telephone] nvarchar(max) NULL,
        CONSTRAINT [PK_Patientss] PRIMARY KEY ([PatientId]),
        CONSTRAINT [FK_Patientss_Docteurss_DocteurId] FOREIGN KEY ([DocteurId]) REFERENCES [Docteurss] ([DocteurId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Patientss_Medicamentss_MedicamentsId] FOREIGN KEY ([MedicamentsId]) REFERENCES [Medicamentss] ([MedicamentsId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE INDEX [IX_MedicamentVenduss_MedicamentsId] ON [MedicamentVenduss] ([MedicamentsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE INDEX [IX_Patientss_DocteurId] ON [Patientss] ([DocteurId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    CREATE INDEX [IX_Patientss_MedicamentsId] ON [Patientss] ([MedicamentsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231029081920_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231029081920_InitialCreate', N'7.0.13');
END;
GO

COMMIT;
GO

