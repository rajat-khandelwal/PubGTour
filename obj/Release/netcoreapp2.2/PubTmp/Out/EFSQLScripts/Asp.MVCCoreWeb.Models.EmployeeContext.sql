IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191001165119_initialcrate')
BEGIN
    CREATE TABLE [Employees] (
        [EmployeeID] int NOT NULL IDENTITY,
        [FullName] nvarchar(250) NOT NULL,
        [EmpCode] varchar(10) NULL,
        [Position] varchar(10) NULL,
        [OfficeLocation] varchar(10) NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191001165119_initialcrate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191001165119_initialcrate', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191020045250_signinidentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191020045250_signinidentity', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'EmpCode');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Employees] DROP COLUMN [EmpCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'FullName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Employees] DROP COLUMN [FullName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'OfficeLocation');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Employees] DROP COLUMN [OfficeLocation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'Position');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Employees] DROP COLUMN [Position];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    ALTER TABLE [Employees] ADD [ConfirmPassword] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    ALTER TABLE [Employees] ADD [Password] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    ALTER TABLE [Employees] ADD [Phone] nvarchar(10) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    ALTER TABLE [Employees] ADD [UserName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    CREATE TABLE [Payments] (
        [Id] bigint NOT NULL IDENTITY,
        [TournamentID] bigint NOT NULL,
        [Phone] nvarchar(10) NULL,
        [email] nvarchar(max) NULL,
        [amount] float NOT NULL,
        [CallBacklurl] nvarchar(max) NULL,
        CONSTRAINT [PK_Payments] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027155149_payment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191027155149_payment', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028151032_updatepaymenttable')
BEGIN
    ALTER TABLE [Payments] ADD [PAYMENTMODE] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028151032_updatepaymenttable')
BEGIN
    ALTER TABLE [Payments] ADD [RESPCODE] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028151032_updatepaymenttable')
BEGIN
    ALTER TABLE [Payments] ADD [Sataus] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028151032_updatepaymenttable')
BEGIN
    ALTER TABLE [Payments] ADD [TXNID] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028151032_updatepaymenttable')
BEGIN
    ALTER TABLE [Payments] ADD [time] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028151032_updatepaymenttable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191028151032_updatepaymenttable', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028162916_Tounaments')
BEGIN
    ALTER TABLE [Payments] ADD [UserId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028162916_Tounaments')
BEGIN
    CREATE TABLE [tournment] (
        [Id] bigint NOT NULL IDENTITY,
        [Date_Time] datetime2 NOT NULL,
        [type] nvarchar(max) NULL,
        [Slots] int NOT NULL,
        [fee] float NOT NULL,
        [Prize] float NOT NULL,
        [Details] nvarchar(max) NULL,
        CONSTRAINT [PK_tournment] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191028162916_Tounaments')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191028162916_Tounaments', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029055928_newcoloumntitletournament')
BEGIN
    ALTER TABLE [tournment] ADD [title] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029055928_newcoloumntitletournament')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191029055928_newcoloumntitletournament', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029082010_newcoloumnuseritpayment')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Payments]') AND [c].[name] = N'UserId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Payments] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Payments] ALTER COLUMN [UserId] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029082010_newcoloumnuseritpayment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191029082010_newcoloumnuseritpayment', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191104182513_extidentityuser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [PubG_UserName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191104182513_extidentityuser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191104182513_extidentityuser', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191106175530_uniqueusername')
BEGIN
    ALTER TABLE [Employees] ADD [PubG_UserName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191106175530_uniqueusername')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'PhoneNumber');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [PhoneNumber] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191106175530_uniqueusername')
BEGIN
    CREATE UNIQUE INDEX [IX_AspNetUsers_PhoneNumber] ON [AspNetUsers] ([PhoneNumber]) WHERE [PhoneNumber] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191106175530_uniqueusername')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191106175530_uniqueusername', N'2.2.6-servicing-10079');
END;

GO

