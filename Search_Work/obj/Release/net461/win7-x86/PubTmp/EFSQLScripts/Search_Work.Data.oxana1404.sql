IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [Email] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [LockoutEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [PasswordHash] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [UserName] nvarchar(256) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Childrens] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Childrens] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Cities] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Employments] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Employments] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ExperienceOfWorks] (
        [Id] uniqueidentifier NOT NULL,
        [NameField] nvarchar(max) NULL,
        CONSTRAINT [PK_ExperienceOfWorks] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [FamilyStatuses] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_FamilyStatuses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [FieldActivities] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_FieldActivities] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [FormTrainings] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_FormTrainings] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [LevelEducations] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_LevelEducations] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [LevelLanguages] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_LevelLanguages] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [LevelTechnologyPossessions] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_LevelTechnologyPossessions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [PaternSearchResumes] (
        [Id] uniqueidentifier NOT NULL,
        [City] uniqueidentifier NOT NULL,
        [Education] uniqueidentifier NOT NULL,
        [Employment] uniqueidentifier NOT NULL,
        [ExperienceOfWork] uniqueidentifier NOT NULL,
        [FieldActivity] uniqueidentifier NOT NULL,
        [IsInName] bit NOT NULL,
        [IsLiteTestPassed] bit NOT NULL,
        [Request] nvarchar(max) NULL,
        [Salary] int NOT NULL,
        CONSTRAINT [PK_PaternSearchResumes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [PaternSearchVacancies] (
        [Id] uniqueidentifier NOT NULL,
        [City] uniqueidentifier NOT NULL,
        [Employment] uniqueidentifier NOT NULL,
        [ExperienceOfWork] uniqueidentifier NOT NULL,
        [FieldActivity] uniqueidentifier NOT NULL,
        [Request] nvarchar(max) NULL,
        [Salary] int NOT NULL,
        CONSTRAINT [PK_PaternSearchVacancies] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ResponsesType] (
        [Id] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ResponsesType] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ResponsesTypeToResume] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_ResponsesTypeToResume] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Companies] (
        [Id] uniqueidentifier NOT NULL,
        [Adress] nvarchar(max) NULL,
        [CityId] uniqueidentifier NULL,
        [CompanyLogoUrl] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Facebook] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [Requirements] nvarchar(max) NULL,
        [Site] nvarchar(max) NULL,
        CONSTRAINT [PK_Companies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Companies_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Candidates] (
        [Id] uniqueidentifier NOT NULL,
        [AccountUserId] nvarchar(450) NULL,
        [ApartmentNumber] nvarchar(max) NULL,
        [Avatar] nvarchar(max) NULL,
        [Birthday] datetime2 NOT NULL,
        [ChildrenId] uniqueidentifier NOT NULL,
        [CityId] uniqueidentifier NULL,
        [Country] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Facebook] nvarchar(max) NULL,
        [FamilyStatusId] uniqueidentifier NOT NULL,
        [LastName] nvarchar(max) NULL,
        [Linkedin] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [Region] nvarchar(max) NULL,
        [Sex] nvarchar(max) NULL,
        [Skype] nvarchar(max) NULL,
        [Street] nvarchar(max) NULL,
        [Surname] nvarchar(max) NULL,
        CONSTRAINT [PK_Candidates] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Candidates_AspNetUsers_AccountUserId] FOREIGN KEY ([AccountUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Candidates_Childrens_ChildrenId] FOREIGN KEY ([ChildrenId]) REFERENCES [Childrens] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Candidates_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Candidates_FamilyStatuses_FamilyStatusId] FOREIGN KEY ([FamilyStatusId]) REFERENCES [FamilyStatuses] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Employers] (
        [Id] uniqueidentifier NOT NULL,
        [AccountUserId] nvarchar(450) NULL,
        [CompanyId] uniqueidentifier NULL,
        CONSTRAINT [PK_Employers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Employers_AspNetUsers_AccountUserId] FOREIGN KEY ([AccountUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Employers_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Resumes] (
        [Id] uniqueidentifier NOT NULL,
        [CandidateId] uniqueidentifier NOT NULL,
        [DateChange] datetime2 NOT NULL,
        [DateCreate] datetime2 NOT NULL,
        [Description] nvarchar(max) NULL,
        [Foto] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Position] nvarchar(max) NULL,
        [Salary] int NOT NULL,
        CONSTRAINT [PK_Resumes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Resumes_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Vacancy] (
        [Id] uniqueidentifier NOT NULL,
        [AdditionalRequirements] nvarchar(max) NULL,
        [CityId] uniqueidentifier NOT NULL,
        [ContactNamePerson] nvarchar(max) NULL,
        [DateCreate] datetime2 NOT NULL,
        [Description] nvarchar(max) NULL,
        [EmailPerson] nvarchar(max) NULL,
        [EmployerId] uniqueidentifier NOT NULL,
        [ExperienceOfWorkId] uniqueidentifier NOT NULL,
        [Facebook] nvarchar(max) NULL,
        [FieldActivityId] uniqueidentifier NOT NULL,
        [ForeignLanguages] nvarchar(max) NULL,
        [IsActive] bit NOT NULL,
        [IsUseCompanyContact] bit NOT NULL,
        [IsUsePersonalContact] bit NOT NULL,
        [Linkedin] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [PhoneNumberPerson] nvarchar(max) NULL,
        [Requirement] nvarchar(max) NULL,
        [Responsibilities] nvarchar(max) NULL,
        [Site] nvarchar(max) NULL,
        [TypeEmploymentId] uniqueidentifier NOT NULL,
        [Wage] int NOT NULL,
        CONSTRAINT [PK_Vacancy] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Vacancy_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Vacancy_Employers_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [Employers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Vacancy_ExperienceOfWorks_ExperienceOfWorkId] FOREIGN KEY ([ExperienceOfWorkId]) REFERENCES [ExperienceOfWorks] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Vacancy_FieldActivities_FieldActivityId] FOREIGN KEY ([FieldActivityId]) REFERENCES [FieldActivities] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Vacancy_Employments_TypeEmploymentId] FOREIGN KEY ([TypeEmploymentId]) REFERENCES [Employments] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [AditinalInfos] (
        [Id] uniqueidentifier NOT NULL,
        [ResumeId] uniqueidentifier NULL,
        [Text] nvarchar(max) NULL,
        CONSTRAINT [PK_AditinalInfos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AditinalInfos_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Awards] (
        [Id] uniqueidentifier NOT NULL,
        [Date] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        [SiteUrlEdition] nvarchar(max) NULL,
        CONSTRAINT [PK_Awards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Awards_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Educations] (
        [Id] uniqueidentifier NOT NULL,
        [City] nvarchar(max) NULL,
        [DateWorkFrom] datetime2 NOT NULL,
        [DateWorkTo] datetime2 NOT NULL,
        [FormTrainingId] uniqueidentifier NOT NULL,
        [LevelEducationId] uniqueidentifier NOT NULL,
        [NameInstitution] nvarchar(max) NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        [Specialization] nvarchar(max) NULL,
        CONSTRAINT [PK_Educations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Educations_FormTrainings_FormTrainingId] FOREIGN KEY ([FormTrainingId]) REFERENCES [FormTrainings] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Educations_LevelEducations_LevelEducationId] FOREIGN KEY ([LevelEducationId]) REFERENCES [LevelEducations] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Educations_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Experiences] (
        [Id] uniqueidentifier NOT NULL,
        [DateWorkFrom] datetime2 NOT NULL,
        [DateWorkTo] datetime2 NOT NULL,
        [EmploymentId] uniqueidentifier NOT NULL,
        [IsWorkingNow] bit NOT NULL,
        [NameOrganization] nvarchar(max) NULL,
        [Position] nvarchar(max) NULL,
        [Progres] nvarchar(max) NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        [Task] nvarchar(max) NULL,
        CONSTRAINT [PK_Experiences] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Experiences_Employments_EmploymentId] FOREIGN KEY ([EmploymentId]) REFERENCES [Employments] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Experiences_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [FieldsActivityResume] (
        [Id] uniqueidentifier NOT NULL,
        [FieldActivityId] uniqueidentifier NOT NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_FieldsActivityResume] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_FieldsActivityResume_FieldActivities_FieldActivityId] FOREIGN KEY ([FieldActivityId]) REFERENCES [FieldActivities] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_FieldsActivityResume_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ForeignLanguages] (
        [Id] uniqueidentifier NOT NULL,
        [LevelLanguageId] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ForeignLanguages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ForeignLanguages_LevelLanguages_LevelLanguageId] FOREIGN KEY ([LevelLanguageId]) REFERENCES [LevelLanguages] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ForeignLanguages_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ImplementedProjects] (
        [Id] uniqueidentifier NOT NULL,
        [DateWorkFrom] datetime2 NOT NULL,
        [DateWorkTo] datetime2 NOT NULL,
        [LinkToProgect] nvarchar(max) NULL,
        [NameProgect] nvarchar(max) NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ImplementedProjects] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ImplementedProjects_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [Publications] (
        [Id] uniqueidentifier NOT NULL,
        [Date] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        [SiteEdition] nvarchar(max) NULL,
        CONSTRAINT [PK_Publications] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Publications_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [SavedResumes] (
        [Id] uniqueidentifier NOT NULL,
        [DateSaved] datetime2 NOT NULL,
        [EmployerId] uniqueidentifier NOT NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_SavedResumes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SavedResumes_Employers_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [Employers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SavedResumes_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ShowsResume] (
        [Id] uniqueidentifier NOT NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ShowsResume] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShowsResume_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [SoftWares] (
        [Id] uniqueidentifier NOT NULL,
        [LevelTechnologyPossessionId] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_SoftWares] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SoftWares_LevelTechnologyPossessions_LevelTechnologyPossessionId] FOREIGN KEY ([LevelTechnologyPossessionId]) REFERENCES [LevelTechnologyPossessions] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SoftWares_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [TrainingAndCources] (
        [Id] uniqueidentifier NOT NULL,
        [DateFrom] datetime2 NOT NULL,
        [DateTo] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [NumberCertification] int NOT NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_TrainingAndCources] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrainingAndCources_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [RecommendedVacancies] (
        [Id] uniqueidentifier NOT NULL,
        [CandidateId] uniqueidentifier NOT NULL,
        [DateSaved] datetime2 NOT NULL,
        [VacancyId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_RecommendedVacancies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RecommendedVacancies_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RecommendedVacancies_Vacancy_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancy] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ResponsesToResume] (
        [Id] uniqueidentifier NOT NULL,
        [DataResponse] datetime2 NOT NULL,
        [ResponseTypeToResumeId] uniqueidentifier NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        [VacancyId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ResponsesToResume] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ResponsesToResume_ResponsesTypeToResume_ResponseTypeToResumeId] FOREIGN KEY ([ResponseTypeToResumeId]) REFERENCES [ResponsesTypeToResume] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ResponsesToResume_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ResponsesToResume_Vacancy_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancy] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ResponsesToVacancy] (
        [Id] uniqueidentifier NOT NULL,
        [CandidateId] uniqueidentifier NULL,
        [DataResponse] datetime2 NOT NULL,
        [ResponseTypeId] uniqueidentifier NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        [VacancyId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ResponsesToVacancy] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ResponsesToVacancy_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ResponsesToVacancy_ResponsesType_ResponseTypeId] FOREIGN KEY ([ResponseTypeId]) REFERENCES [ResponsesType] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ResponsesToVacancy_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ResponsesToVacancy_Vacancy_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancy] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [SavedVacancies] (
        [Id] uniqueidentifier NOT NULL,
        [CandidateId] uniqueidentifier NOT NULL,
        [DateSaved] datetime2 NOT NULL,
        [VacancyId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_SavedVacancies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SavedVacancies_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SavedVacancies_Vacancy_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancy] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE TABLE [ViewsPages] (
        [Id] uniqueidentifier NOT NULL,
        [DataView] datetime2 NOT NULL,
        [EmployerId] uniqueidentifier NULL,
        [ResumeId] uniqueidentifier NOT NULL,
        [VacancyId] uniqueidentifier NULL,
        CONSTRAINT [PK_ViewsPages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ViewsPages_Employers_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [Employers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ViewsPages_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ViewsPages_Vacancy_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancy] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE UNIQUE INDEX [IX_AditinalInfos_ResumeId] ON [AditinalInfos] ([ResumeId]) WHERE [ResumeId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Awards_ResumeId] ON [Awards] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Candidates_AccountUserId] ON [Candidates] ([AccountUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Candidates_ChildrenId] ON [Candidates] ([ChildrenId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Candidates_CityId] ON [Candidates] ([CityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Candidates_FamilyStatusId] ON [Candidates] ([FamilyStatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Companies_CityId] ON [Companies] ([CityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Educations_FormTrainingId] ON [Educations] ([FormTrainingId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Educations_LevelEducationId] ON [Educations] ([LevelEducationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Educations_ResumeId] ON [Educations] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Employers_AccountUserId] ON [Employers] ([AccountUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Employers_CompanyId] ON [Employers] ([CompanyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Experiences_EmploymentId] ON [Experiences] ([EmploymentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Experiences_ResumeId] ON [Experiences] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_FieldsActivityResume_FieldActivityId] ON [FieldsActivityResume] ([FieldActivityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_FieldsActivityResume_ResumeId] ON [FieldsActivityResume] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ForeignLanguages_LevelLanguageId] ON [ForeignLanguages] ([LevelLanguageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ForeignLanguages_ResumeId] ON [ForeignLanguages] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ImplementedProjects_ResumeId] ON [ImplementedProjects] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Publications_ResumeId] ON [Publications] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_RecommendedVacancies_CandidateId] ON [RecommendedVacancies] ([CandidateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_RecommendedVacancies_VacancyId] ON [RecommendedVacancies] ([VacancyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ResponsesToResume_ResponseTypeToResumeId] ON [ResponsesToResume] ([ResponseTypeToResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ResponsesToResume_ResumeId] ON [ResponsesToResume] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ResponsesToResume_VacancyId] ON [ResponsesToResume] ([VacancyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ResponsesToVacancy_CandidateId] ON [ResponsesToVacancy] ([CandidateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ResponsesToVacancy_ResponseTypeId] ON [ResponsesToVacancy] ([ResponseTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ResponsesToVacancy_ResumeId] ON [ResponsesToVacancy] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ResponsesToVacancy_VacancyId] ON [ResponsesToVacancy] ([VacancyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Resumes_CandidateId] ON [Resumes] ([CandidateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_SavedResumes_EmployerId] ON [SavedResumes] ([EmployerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_SavedResumes_ResumeId] ON [SavedResumes] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_SavedVacancies_CandidateId] ON [SavedVacancies] ([CandidateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_SavedVacancies_VacancyId] ON [SavedVacancies] ([VacancyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ShowsResume_ResumeId] ON [ShowsResume] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_SoftWares_LevelTechnologyPossessionId] ON [SoftWares] ([LevelTechnologyPossessionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_SoftWares_ResumeId] ON [SoftWares] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_TrainingAndCources_ResumeId] ON [TrainingAndCources] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Vacancy_CityId] ON [Vacancy] ([CityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Vacancy_EmployerId] ON [Vacancy] ([EmployerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Vacancy_ExperienceOfWorkId] ON [Vacancy] ([ExperienceOfWorkId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Vacancy_FieldActivityId] ON [Vacancy] ([FieldActivityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_Vacancy_TypeEmploymentId] ON [Vacancy] ([TypeEmploymentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ViewsPages_EmployerId] ON [ViewsPages] ([EmployerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ViewsPages_ResumeId] ON [ViewsPages] ([ResumeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    CREATE INDEX [IX_ViewsPages_VacancyId] ON [ViewsPages] ([VacancyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926202044_AddInitiall')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180926202044_AddInitiall', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926205112_AddFixCandidate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180926205112_AddFixCandidate', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926210352_AddFixCandidateNew')
BEGIN
    ALTER TABLE [Candidates] DROP CONSTRAINT [FK_Candidates_Childrens_ChildrenId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926210352_AddFixCandidateNew')
BEGIN
    ALTER TABLE [Candidates] DROP CONSTRAINT [FK_Candidates_FamilyStatuses_FamilyStatusId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926210352_AddFixCandidateNew')
BEGIN
    DROP INDEX [IX_Candidates_ChildrenId] ON [Candidates];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926210352_AddFixCandidateNew')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Candidates') AND [c].[name] = N'ChildrenId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Candidates] DROP COLUMN [ChildrenId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926210352_AddFixCandidateNew')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Candidates') AND [c].[name] = N'FamilyStatusId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Candidates] ALTER COLUMN [FamilyStatusId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926210352_AddFixCandidateNew')
BEGIN
    ALTER TABLE [Candidates] ADD CONSTRAINT [FK_Candidates_FamilyStatuses_FamilyStatusId] FOREIGN KEY ([FamilyStatusId]) REFERENCES [FamilyStatuses] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180926210352_AddFixCandidateNew')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180926210352_AddFixCandidateNew', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180927201023_AddFixCandidateNwe')
BEGIN
    ALTER TABLE [Candidates] ADD [ChildrenId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180927201023_AddFixCandidateNwe')
BEGIN
    CREATE INDEX [IX_Candidates_ChildrenId] ON [Candidates] ([ChildrenId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180927201023_AddFixCandidateNwe')
BEGIN
    ALTER TABLE [Candidates] ADD CONSTRAINT [FK_Candidates_Childrens_ChildrenId] FOREIGN KEY ([ChildrenId]) REFERENCES [Childrens] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180927201023_AddFixCandidateNwe')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180927201023_AddFixCandidateNwe', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Employers] DROP CONSTRAINT [FK_Employers_AspNetUsers_AccountUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [RecommendedVacancies] DROP CONSTRAINT [FK_RecommendedVacancies_Vacancy_VacancyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [ResponsesToResume] DROP CONSTRAINT [FK_ResponsesToResume_Vacancy_VacancyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [ResponsesToVacancy] DROP CONSTRAINT [FK_ResponsesToVacancy_Vacancy_VacancyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [SavedVacancies] DROP CONSTRAINT [FK_SavedVacancies_Vacancy_VacancyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancy] DROP CONSTRAINT [FK_Vacancy_Cities_CityId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancy] DROP CONSTRAINT [FK_Vacancy_Employers_EmployerId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancy] DROP CONSTRAINT [FK_Vacancy_ExperienceOfWorks_ExperienceOfWorkId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancy] DROP CONSTRAINT [FK_Vacancy_FieldActivities_FieldActivityId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancy] DROP CONSTRAINT [FK_Vacancy_Employments_TypeEmploymentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [ViewsPages] DROP CONSTRAINT [FK_ViewsPages_Vacancy_VacancyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancy] DROP CONSTRAINT [PK_Vacancy];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    DROP INDEX [IX_Employers_AccountUserId] ON [Employers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    DROP INDEX [IX_Candidates_AccountUserId] ON [Candidates];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Employers') AND [c].[name] = N'AccountUserId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Employers] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Employers] DROP COLUMN [AccountUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    EXEC sp_rename N'Vacancy', N'Vacancies';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    EXEC sp_rename N'Vacancies.IX_Vacancy_TypeEmploymentId', N'IX_Vacancies_TypeEmploymentId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    EXEC sp_rename N'Vacancies.IX_Vacancy_FieldActivityId', N'IX_Vacancies_FieldActivityId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    EXEC sp_rename N'Vacancies.IX_Vacancy_ExperienceOfWorkId', N'IX_Vacancies_ExperienceOfWorkId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    EXEC sp_rename N'Vacancies.IX_Vacancy_EmployerId', N'IX_Vacancies_EmployerId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    EXEC sp_rename N'Vacancies.IX_Vacancy_CityId', N'IX_Vacancies_CityId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [EmployerId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancies] ADD CONSTRAINT [PK_Vacancies] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    CREATE UNIQUE INDEX [IX_Candidates_AccountUserId] ON [Candidates] ([AccountUserId]) WHERE [AccountUserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    CREATE UNIQUE INDEX [IX_AspNetUsers_EmployerId] ON [AspNetUsers] ([EmployerId]) WHERE [EmployerId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Employers_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [Employers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [RecommendedVacancies] ADD CONSTRAINT [FK_RecommendedVacancies_Vacancies_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancies] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [ResponsesToResume] ADD CONSTRAINT [FK_ResponsesToResume_Vacancies_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancies] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [ResponsesToVacancy] ADD CONSTRAINT [FK_ResponsesToVacancy_Vacancies_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancies] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [SavedVacancies] ADD CONSTRAINT [FK_SavedVacancies_Vacancies_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancies] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancies] ADD CONSTRAINT [FK_Vacancies_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancies] ADD CONSTRAINT [FK_Vacancies_Employers_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [Employers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancies] ADD CONSTRAINT [FK_Vacancies_ExperienceOfWorks_ExperienceOfWorkId] FOREIGN KEY ([ExperienceOfWorkId]) REFERENCES [ExperienceOfWorks] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancies] ADD CONSTRAINT [FK_Vacancies_FieldActivities_FieldActivityId] FOREIGN KEY ([FieldActivityId]) REFERENCES [FieldActivities] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [Vacancies] ADD CONSTRAINT [FK_Vacancies_Employments_TypeEmploymentId] FOREIGN KEY ([TypeEmploymentId]) REFERENCES [Employments] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    ALTER TABLE [ViewsPages] ADD CONSTRAINT [FK_ViewsPages_Vacancies_VacancyId] FOREIGN KEY ([VacancyId]) REFERENCES [Vacancies] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013171915_AddNewTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181013171915_AddNewTables', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013175807_AddFixCompani')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Companies') AND [c].[name] = N'CompanyLogoUrl');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Companies] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Companies] ALTER COLUMN [CompanyLogoUrl] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013175807_AddFixCompani')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181013175807_AddFixCompani', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013180712_AddFixCompanies')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Companies') AND [c].[name] = N'CompanyLogoUrl');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Companies] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Companies] ALTER COLUMN [CompanyLogoUrl] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181013180712_AddFixCompanies')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181013180712_AddFixCompanies', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181029214021_AddFixEmployee')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181029214021_AddFixEmployee', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181209192322_AddStatuseCompany')
BEGIN
    ALTER TABLE [Companies] ADD [Status] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181209192322_AddStatuseCompany')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181209192322_AddStatuseCompany', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181209192452_AddNulableStatusCompany')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Companies') AND [c].[name] = N'Status');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Companies] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Companies] ALTER COLUMN [Status] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181209192452_AddNulableStatusCompany')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181209192452_AddNulableStatusCompany', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181216222513_AddContactToEmployee')
BEGIN
    CREATE TABLE [Contacts] (
        [Id] uniqueidentifier NOT NULL,
        [Avatar] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [EmployerId] uniqueidentifier NOT NULL,
        [Facebook] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Site] nvarchar(max) NULL,
        [Status] bit NOT NULL,
        [Surname] nvarchar(max) NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Contacts_Employers_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [Employers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181216222513_AddContactToEmployee')
BEGIN
    CREATE UNIQUE INDEX [IX_Contacts_EmployerId] ON [Contacts] ([EmployerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181216222513_AddContactToEmployee')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181216222513_AddContactToEmployee', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181222205417_AddFixVacansyStatusDatePublication')
BEGIN
    ALTER TABLE [Vacancies] ADD [DatePublication] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181222205417_AddFixVacansyStatusDatePublication')
BEGIN
    ALTER TABLE [Vacancies] ADD [Status] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181222205417_AddFixVacansyStatusDatePublication')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181222205417_AddFixVacansyStatusDatePublication', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181227211121_AddFixPageViews')
BEGIN
    ALTER TABLE [ViewsPages] ADD [CandidateId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181227211121_AddFixPageViews')
BEGIN
    CREATE INDEX [IX_ViewsPages_CandidateId] ON [ViewsPages] ([CandidateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181227211121_AddFixPageViews')
BEGIN
    ALTER TABLE [ViewsPages] ADD CONSTRAINT [FK_ViewsPages_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181227211121_AddFixPageViews')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181227211121_AddFixPageViews', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190127134727_AddFixResume')
BEGIN
    ALTER TABLE [Resumes] ADD [IsActiveResume] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190127134727_AddFixResume')
BEGIN
    ALTER TABLE [Resumes] ADD [IsAnonymousResume] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190127134727_AddFixResume')
BEGIN
    ALTER TABLE [Resumes] ADD [IsHideContact] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190127134727_AddFixResume')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190127134727_AddFixResume', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190210214514_AddFixViewPage')
BEGIN
    ALTER TABLE [ViewsPages] DROP CONSTRAINT [FK_ViewsPages_Resumes_ResumeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190210214514_AddFixViewPage')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'ViewsPages') AND [c].[name] = N'ResumeId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ViewsPages] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ViewsPages] ALTER COLUMN [ResumeId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190210214514_AddFixViewPage')
BEGIN
    ALTER TABLE [ViewsPages] ADD CONSTRAINT [FK_ViewsPages_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190210214514_AddFixViewPage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190210214514_AddFixViewPage', N'2.0.1-rtm-125');
END;

GO

