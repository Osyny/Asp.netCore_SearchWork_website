using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Search_Work.Data.Migrations
{
    public partial class AddInitiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Childrens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childrens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceOfWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameField = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceOfWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormTrainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormTrainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelTechnologyPossessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelTechnologyPossessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaternSearchResumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<Guid>(nullable: false),
                    Education = table.Column<Guid>(nullable: false),
                    Employment = table.Column<Guid>(nullable: false),
                    ExperienceOfWork = table.Column<Guid>(nullable: false),
                    FieldActivity = table.Column<Guid>(nullable: false),
                    IsInName = table.Column<bool>(nullable: false),
                    IsLiteTestPassed = table.Column<bool>(nullable: false),
                    Request = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaternSearchResumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaternSearchVacancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<Guid>(nullable: false),
                    Employment = table.Column<Guid>(nullable: false),
                    ExperienceOfWork = table.Column<Guid>(nullable: false),
                    FieldActivity = table.Column<Guid>(nullable: false),
                    Request = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaternSearchVacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponsesType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsesType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponsesTypeToResume",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsesTypeToResume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: true),
                    CompanyLogoUrl = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Requirements = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountUserId = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    ChildrenId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    FamilyStatusId = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_AspNetUsers_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Childrens_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Childrens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_FamilyStatuses_FamilyStatusId",
                        column: x => x.FamilyStatusId,
                        principalTable: "FamilyStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountUserId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_AspNetUsers_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionalRequirements = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false),
                    ContactNamePerson = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmailPerson = table.Column<string>(nullable: true),
                    EmployerId = table.Column<Guid>(nullable: false),
                    ExperienceOfWorkId = table.Column<Guid>(nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    FieldActivityId = table.Column<Guid>(nullable: false),
                    ForeignLanguages = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsUseCompanyContact = table.Column<bool>(nullable: false),
                    IsUsePersonalContact = table.Column<bool>(nullable: false),
                    Linkedin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumberPerson = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    Responsibilities = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    TypeEmploymentId = table.Column<Guid>(nullable: false),
                    Wage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancy_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancy_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancy_ExperienceOfWorks_ExperienceOfWorkId",
                        column: x => x.ExperienceOfWorkId,
                        principalTable: "ExperienceOfWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancy_FieldActivities_FieldActivityId",
                        column: x => x.FieldActivityId,
                        principalTable: "FieldActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancy_Employments_TypeEmploymentId",
                        column: x => x.TypeEmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AditinalInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResumeId = table.Column<Guid>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AditinalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AditinalInfos_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false),
                    SiteUrlEdition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    DateWorkFrom = table.Column<DateTime>(nullable: false),
                    DateWorkTo = table.Column<DateTime>(nullable: false),
                    FormTrainingId = table.Column<Guid>(nullable: false),
                    LevelEducationId = table.Column<Guid>(nullable: false),
                    NameInstitution = table.Column<string>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false),
                    Specialization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_FormTrainings_FormTrainingId",
                        column: x => x.FormTrainingId,
                        principalTable: "FormTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_LevelEducations_LevelEducationId",
                        column: x => x.LevelEducationId,
                        principalTable: "LevelEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateWorkFrom = table.Column<DateTime>(nullable: false),
                    DateWorkTo = table.Column<DateTime>(nullable: false),
                    EmploymentId = table.Column<Guid>(nullable: false),
                    IsWorkingNow = table.Column<bool>(nullable: false),
                    NameOrganization = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Progres = table.Column<string>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false),
                    Task = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldsActivityResume",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FieldActivityId = table.Column<Guid>(nullable: false),
                    ResumeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldsActivityResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldsActivityResume_FieldActivities_FieldActivityId",
                        column: x => x.FieldActivityId,
                        principalTable: "FieldActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldsActivityResume_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeignLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LevelLanguageId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignLanguages_LevelLanguages_LevelLanguageId",
                        column: x => x.LevelLanguageId,
                        principalTable: "LevelLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForeignLanguages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImplementedProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateWorkFrom = table.Column<DateTime>(nullable: false),
                    DateWorkTo = table.Column<DateTime>(nullable: false),
                    LinkToProgect = table.Column<string>(nullable: true),
                    NameProgect = table.Column<string>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImplementedProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImplementedProjects_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false),
                    SiteEdition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedResumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: false),
                    EmployerId = table.Column<Guid>(nullable: false),
                    ResumeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedResumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedResumes_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedResumes_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowsResume",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResumeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowsResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowsResume_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftWares",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LevelTechnologyPossessionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftWares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftWares_LevelTechnologyPossessions_LevelTechnologyPossessionId",
                        column: x => x.LevelTechnologyPossessionId,
                        principalTable: "LevelTechnologyPossessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftWares_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAndCources",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberCertification = table.Column<int>(nullable: false),
                    ResumeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAndCources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingAndCources_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendedVacancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedVacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendedVacancies_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendedVacancies_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsesToResume",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataResponse = table.Column<DateTime>(nullable: false),
                    ResponseTypeToResumeId = table.Column<Guid>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsesToResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsesToResume_ResponsesTypeToResume_ResponseTypeToResumeId",
                        column: x => x.ResponseTypeToResumeId,
                        principalTable: "ResponsesTypeToResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsesToResume_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsesToResume_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsesToVacancy",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: true),
                    DataResponse = table.Column<DateTime>(nullable: false),
                    ResponseTypeId = table.Column<Guid>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsesToVacancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsesToVacancy_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsesToVacancy_ResponsesType_ResponseTypeId",
                        column: x => x.ResponseTypeId,
                        principalTable: "ResponsesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsesToVacancy_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsesToVacancy_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedVacancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedVacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedVacancies_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedVacancies_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewsPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataView = table.Column<DateTime>(nullable: false),
                    EmployerId = table.Column<Guid>(nullable: true),
                    ResumeId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewsPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewsPages_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewsPages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewsPages_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AditinalInfos_ResumeId",
                table: "AditinalInfos",
                column: "ResumeId",
                unique: true,
                filter: "[ResumeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_ResumeId",
                table: "Awards",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AccountUserId",
                table: "Candidates",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ChildrenId",
                table: "Candidates",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CityId",
                table: "Candidates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_FamilyStatusId",
                table: "Candidates",
                column: "FamilyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FormTrainingId",
                table: "Educations",
                column: "FormTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_LevelEducationId",
                table: "Educations",
                column: "LevelEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ResumeId",
                table: "Educations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_AccountUserId",
                table: "Employers",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_CompanyId",
                table: "Employers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_EmploymentId",
                table: "Experiences",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ResumeId",
                table: "Experiences",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsActivityResume_FieldActivityId",
                table: "FieldsActivityResume",
                column: "FieldActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsActivityResume_ResumeId",
                table: "FieldsActivityResume",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignLanguages_LevelLanguageId",
                table: "ForeignLanguages",
                column: "LevelLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignLanguages_ResumeId",
                table: "ForeignLanguages",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImplementedProjects_ResumeId",
                table: "ImplementedProjects",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ResumeId",
                table: "Publications",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedVacancies_CandidateId",
                table: "RecommendedVacancies",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedVacancies_VacancyId",
                table: "RecommendedVacancies",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesToResume_ResponseTypeToResumeId",
                table: "ResponsesToResume",
                column: "ResponseTypeToResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesToResume_ResumeId",
                table: "ResponsesToResume",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesToResume_VacancyId",
                table: "ResponsesToResume",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesToVacancy_CandidateId",
                table: "ResponsesToVacancy",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesToVacancy_ResponseTypeId",
                table: "ResponsesToVacancy",
                column: "ResponseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesToVacancy_ResumeId",
                table: "ResponsesToVacancy",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesToVacancy_VacancyId",
                table: "ResponsesToVacancy",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_CandidateId",
                table: "Resumes",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedResumes_EmployerId",
                table: "SavedResumes",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedResumes_ResumeId",
                table: "SavedResumes",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedVacancies_CandidateId",
                table: "SavedVacancies",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedVacancies_VacancyId",
                table: "SavedVacancies",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowsResume_ResumeId",
                table: "ShowsResume",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftWares_LevelTechnologyPossessionId",
                table: "SoftWares",
                column: "LevelTechnologyPossessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftWares_ResumeId",
                table: "SoftWares",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAndCources_ResumeId",
                table: "TrainingAndCources",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_CityId",
                table: "Vacancy",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_EmployerId",
                table: "Vacancy",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_ExperienceOfWorkId",
                table: "Vacancy",
                column: "ExperienceOfWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_FieldActivityId",
                table: "Vacancy",
                column: "FieldActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_TypeEmploymentId",
                table: "Vacancy",
                column: "TypeEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewsPages_EmployerId",
                table: "ViewsPages",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewsPages_ResumeId",
                table: "ViewsPages",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewsPages_VacancyId",
                table: "ViewsPages",
                column: "VacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AditinalInfos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "FieldsActivityResume");

            migrationBuilder.DropTable(
                name: "ForeignLanguages");

            migrationBuilder.DropTable(
                name: "ImplementedProjects");

            migrationBuilder.DropTable(
                name: "PaternSearchResumes");

            migrationBuilder.DropTable(
                name: "PaternSearchVacancies");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "RecommendedVacancies");

            migrationBuilder.DropTable(
                name: "ResponsesToResume");

            migrationBuilder.DropTable(
                name: "ResponsesToVacancy");

            migrationBuilder.DropTable(
                name: "SavedResumes");

            migrationBuilder.DropTable(
                name: "SavedVacancies");

            migrationBuilder.DropTable(
                name: "ShowsResume");

            migrationBuilder.DropTable(
                name: "SoftWares");

            migrationBuilder.DropTable(
                name: "TrainingAndCources");

            migrationBuilder.DropTable(
                name: "ViewsPages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FormTrainings");

            migrationBuilder.DropTable(
                name: "LevelEducations");

            migrationBuilder.DropTable(
                name: "LevelLanguages");

            migrationBuilder.DropTable(
                name: "ResponsesTypeToResume");

            migrationBuilder.DropTable(
                name: "ResponsesType");

            migrationBuilder.DropTable(
                name: "LevelTechnologyPossessions");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "Vacancy");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "ExperienceOfWorks");

            migrationBuilder.DropTable(
                name: "FieldActivities");

            migrationBuilder.DropTable(
                name: "Employments");

            migrationBuilder.DropTable(
                name: "Childrens");

            migrationBuilder.DropTable(
                name: "FamilyStatuses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
