using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DegreeLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyLevels",
                columns: table => new
                {
                    TechnologyLevelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyLevels", x => x.TechnologyLevelId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "BusinessesContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployerId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    SecondaryPhone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    IsAnEmployee = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessesContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessesContacts_AspNetUsers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessesInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployerId = table.Column<string>(type: "TEXT", nullable: false),
                    BusinessName = table.Column<string>(type: "TEXT", nullable: false),
                    Cuit = table.Column<string>(type: "TEXT", nullable: false),
                    LineOfBusiness = table.Column<string>(type: "TEXT", nullable: false),
                    LegalAddress = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumer = table.Column<string>(type: "TEXT", nullable: false),
                    Web = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessesInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessesInformation_AspNetUsers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsExtraData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Curriculum = table.Column<byte[]>(type: "BLOB", nullable: true),
                    HighSchoolDegree = table.Column<string>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsExtraData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsExtraData_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsPersonalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Legajo = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Cuit = table.Column<string>(type: "TEXT", nullable: false),
                    SecondaryEmail = table.Column<string>(type: "TEXT", nullable: false),
                    IdentifierType = table.Column<int>(type: "INTEGER", nullable: false),
                    IndentifierNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBith = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    MaritalStatus = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentHomeNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FloorNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Apartment = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Province = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SecondaryPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyCountry = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyProvince = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyCity = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyAddress = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SecondaryFamilyPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyNumberHome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsPersonalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsPersonalInformation_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HiredEmployeeOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkingHours = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    EmployerId = table.Column<string>(type: "TEXT", nullable: false),
                    EmailReceiver = table.Column<string>(type: "TEXT", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PositionsToFill = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    WorkLocation = table.Column<string>(type: "TEXT", nullable: false),
                    DegreeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiredEmployeeOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiredEmployeeOffers_AspNetUsers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiredEmployeeOffers_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HasAnAgreement = table.Column<bool>(type: "INTEGER", nullable: false),
                    MonthsOfDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployerId = table.Column<string>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    EmailReceiver = table.Column<string>(type: "TEXT", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PositionsToFill = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    WorkLocation = table.Column<string>(type: "TEXT", nullable: false),
                    DegreeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipOffers_AspNetUsers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipOffers_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCollegeInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false),
                    DegreeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApprovedSubjects = table.Column<int>(type: "INTEGER", nullable: false),
                    YearOfStudyPlan = table.Column<int>(type: "INTEGER", nullable: false),
                    CollegeYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Schedule = table.Column<string>(type: "TEXT", nullable: false),
                    AverageWithNotApproved = table.Column<double>(type: "REAL", nullable: false),
                    AverageWithApproved = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCollegeInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsCollegeInformation_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCollegeInformation_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherSkills",
                columns: table => new
                {
                    OtherSkillsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TechnologyLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    TechnologyName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSkills", x => x.OtherSkillsId);
                    table.ForeignKey(
                        name: "FK_OtherSkills_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherSkills_TechnologyLevels_TechnologyLevelId",
                        column: x => x.TechnologyLevelId,
                        principalTable: "TechnologyLevels",
                        principalColumn: "TechnologyLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TechnologyLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    TechnologyId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_TechnologyLevels_TechnologyLevelId",
                        column: x => x.TechnologyLevelId,
                        principalTable: "TechnologyLevels",
                        principalColumn: "TechnologyLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HiredApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HiredEmployeeOfferId = table.Column<int>(type: "INTEGER", nullable: false),
                    InternshipOfferId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiredApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiredApplications_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiredApplications_HiredEmployeeOffers_HiredEmployeeOfferId",
                        column: x => x.HiredEmployeeOfferId,
                        principalTable: "HiredEmployeeOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiredApplications_InternshipOffers_InternshipOfferId",
                        column: x => x.InternshipOfferId,
                        principalTable: "InternshipOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InternshipApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InternshipOfferId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipApplications_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipApplications_InternshipOffers_InternshipOfferId",
                        column: x => x.InternshipOfferId,
                        principalTable: "InternshipOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "601f0ede-374e-45f0-9373-50cba7a8183e", "601f0ede-374e-45f0-9373-50cba7a8183e", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "886bad89-d81f-4c6d-8c98-e3ba074c23dd", "886bad89-d81f-4c6d-8c98-e3ba074c23dd", "Employer", "EMPLOYER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "", "260fba02-339e-4827-8ebd-830f239c844d", "User", "admin@frro.utn.edu.ar", true, "administracion", "UTN", false, null, "ADMIN@FRRO.UTN.EDU.AR", "ADMIN1", "AQAAAAEAACcQAAAAEPBzyUMY5eXVWblJb7Qp8CwWJ2+25Vqe72E/o7ilAW50WPo/BRFYtHcmrKZe3w9bew==", null, false, "75a18479-240c-440e-83a3-6704fb1df07b", false, "admin1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "272cf1fd-6e8b-4bdb-87b8-b136033fad9e", 0, "", "94294faa-f048-4f58-b1cb-11ff9997d826", "User", "student@frro.utn.edu.ar", true, "Carlos", "Perez", false, null, "STUDENT@FRRO.UTN.EDU.AR", "STUDENT1", "AQAAAAEAACcQAAAAEErpsWOAkoMypaIrEs1g6i/Bp+rfT3TAaSqaBoT3KbhB4CXyqcuKagnmHg5uyL3+NQ==", null, false, "123789a4-3632-4b40-b526-a7b5e75b7d7c", false, "student1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bdc961f7-6fb6-4b7e-9319-c35a8b09dd36", 0, "", "05fd21bb-9b7c-40eb-a430-035be1d01132", "User", "employer@frro.utn.edu.ar", true, "Mercado Libre", "Argentina", false, null, "EMPLOYER@FRRO.UTN.EDU.AR", "EMPLOYER1", "AQAAAAEAACcQAAAAENbSkhK1/PcuOwU0f6we8Bf6YBAbiBoZr7urhB/vmDLbbTvdfo6UGTnAGlBOJif2rg==", null, false, "8a1dd316-798d-4f2f-beb5-008bb7dade38", false, "employer1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "601f0ede-374e-45f0-9373-50cba7a8183e", "272cf1fd-6e8b-4bdb-87b8-b136033fad9e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "886bad89-d81f-4c6d-8c98-e3ba074c23dd", "bdc961f7-6fb6-4b7e-9319-c35a8b09dd36" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessesContacts_EmployerId",
                table: "BusinessesContacts",
                column: "EmployerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessesInformation_EmployerId",
                table: "BusinessesInformation",
                column: "EmployerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HiredApplications_HiredEmployeeOfferId",
                table: "HiredApplications",
                column: "HiredEmployeeOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_HiredApplications_InternshipOfferId",
                table: "HiredApplications",
                column: "InternshipOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_HiredApplications_StudentId",
                table: "HiredApplications",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HiredEmployeeOffers_DegreeId",
                table: "HiredEmployeeOffers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_HiredEmployeeOffers_EmployerId",
                table: "HiredEmployeeOffers",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipApplications_InternshipOfferId",
                table: "InternshipApplications",
                column: "InternshipOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipApplications_StudentId",
                table: "InternshipApplications",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipOffers_DegreeId",
                table: "InternshipOffers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipOffers_EmployerId",
                table: "InternshipOffers",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherSkills_StudentId",
                table: "OtherSkills",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherSkills_TechnologyLevelId",
                table: "OtherSkills",
                column: "TechnologyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StudentId",
                table: "Skills",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TechnologyId",
                table: "Skills",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TechnologyLevelId",
                table: "Skills",
                column: "TechnologyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCollegeInformation_DegreeId",
                table: "StudentsCollegeInformation",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCollegeInformation_StudentId",
                table: "StudentsCollegeInformation",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsExtraData_StudentId",
                table: "StudentsExtraData",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsPersonalInformation_StudentId",
                table: "StudentsPersonalInformation",
                column: "StudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BusinessesContacts");

            migrationBuilder.DropTable(
                name: "BusinessesInformation");

            migrationBuilder.DropTable(
                name: "HiredApplications");

            migrationBuilder.DropTable(
                name: "InternshipApplications");

            migrationBuilder.DropTable(
                name: "OtherSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "StudentsCollegeInformation");

            migrationBuilder.DropTable(
                name: "StudentsExtraData");

            migrationBuilder.DropTable(
                name: "StudentsPersonalInformation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HiredEmployeeOffers");

            migrationBuilder.DropTable(
                name: "InternshipOffers");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "TechnologyLevels");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Degrees");
        }
    }
}
