using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthCheckupCampaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckupCampaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSuppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplyType = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCampaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCampaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthCheckupCampaignUser",
                columns: table => new
                {
                    HealthCheckupCampaignsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalStaffsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckupCampaignUser", x => new { x.HealthCheckupCampaignsId, x.MedicalStaffsId });
                    table.ForeignKey(
                        name: "FK_HealthCheckupCampaignUser_HealthCheckupCampaigns_HealthCheckupCampaignsId",
                        column: x => x.HealthCheckupCampaignsId,
                        principalTable: "HealthCheckupCampaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthCheckupCampaignUser_Users_MedicalStaffsId",
                        column: x => x.MedicalStaffsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserVaccinationCampaign",
                columns: table => new
                {
                    MedicalStaffsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationCampaignsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVaccinationCampaign", x => new { x.MedicalStaffsId, x.VaccinationCampaignsId });
                    table.ForeignKey(
                        name: "FK_UserVaccinationCampaign_Users_MedicalStaffsId",
                        column: x => x.MedicalStaffsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVaccinationCampaign_VaccinationCampaigns_VaccinationCampaignsId",
                        column: x => x.VaccinationCampaignsId,
                        principalTable: "VaccinationCampaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCheckupConsentForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCheckupCampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsentStatus = table.Column<bool>(type: "bit", nullable: false),
                    ConsentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonForDecline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckupConsentForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheckupConsentForms_HealthCheckupCampaigns_HealthCheckupCampaignId",
                        column: x => x.HealthCheckupCampaignId,
                        principalTable: "HealthCheckupCampaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HealthCheckupConsentForms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChronicDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisionLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisionRight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HearingLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HearingRight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccinationHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalIncidents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentType = table.Column<int>(type: "int", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionsTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ParentNotified = table.Column<bool>(type: "bit", nullable: false),
                    ParentNotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalIncidents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MedicalStaffNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MedicalStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationRequests_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationRequests_Users_MedicalStaffId",
                        column: x => x.MedicalStaffId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicineDiaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineDiaries_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentHealthCheckupSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCheckupCampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHealthCheckupSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentHealthCheckupSchedules_HealthCheckupCampaigns_HealthCheckupCampaignId",
                        column: x => x.HealthCheckupCampaignId,
                        principalTable: "HealthCheckupCampaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentHealthCheckupSchedules_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentVaccinationSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationCampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentVaccinationSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentVaccinationSchedules_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentVaccinationSchedules_VaccinationCampaigns_VaccinationCampaignId",
                        column: x => x.VaccinationCampaignId,
                        principalTable: "VaccinationCampaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinationConsentForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationCampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsentStatus = table.Column<bool>(type: "bit", nullable: false),
                    ConsentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonForDecline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationConsentForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationConsentForms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VaccinationConsentForms_VaccinationCampaigns_VaccinationCampaignId",
                        column: x => x.VaccinationCampaignId,
                        principalTable: "VaccinationCampaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalSupplyUsages",
                columns: table => new
                {
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false),
                    UsageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSupplyUsages", x => new { x.SupplyId, x.IncidentId });
                    table.ForeignKey(
                        name: "FK_MedicalSupplyUsages_MedicalIncidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "MedicalIncidents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalSupplyUsages_MedicalSuppliers_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "MedicalSuppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthCheckupResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCheckupScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CheckupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    VisionLeftResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisionRightResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HearingLeftResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HearingRightResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodPressureSys = table.Column<float>(type: "real", nullable: true),
                    BloodPressureDia = table.Column<float>(type: "real", nullable: true),
                    HeartRate = table.Column<float>(type: "real", nullable: true),
                    DentalCheckupResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbnormalSigns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentResultNotified = table.Column<bool>(type: "bit", nullable: false),
                    ParentResultNotificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckupResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheckupResults_StudentHealthCheckupSchedules_HealthCheckupScheduleId",
                        column: x => x.HealthCheckupScheduleId,
                        principalTable: "StudentHealthCheckupSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinationResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DosageGiven = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationResults_StudentVaccinationSchedules_VaccinationScheduleId",
                        column: x => x.VaccinationScheduleId,
                        principalTable: "StudentVaccinationSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalConsultations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultationNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalConsultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalConsultations_HealthCheckupResults_ResultId",
                        column: x => x.ResultId,
                        principalTable: "HealthCheckupResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalConsultations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalConsultations_Users_MedicalStaffId",
                        column: x => x.MedicalStaffId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckupCampaignUser_MedicalStaffsId",
                table: "HealthCheckupCampaignUser",
                column: "MedicalStaffsId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckupConsentForms_HealthCheckupCampaignId",
                table: "HealthCheckupConsentForms",
                column: "HealthCheckupCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckupConsentForms_StudentId",
                table: "HealthCheckupConsentForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckupResults_HealthCheckupScheduleId",
                table: "HealthCheckupResults",
                column: "HealthCheckupScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_StudentId",
                table: "HealthRecords",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultations_MedicalStaffId",
                table: "MedicalConsultations",
                column: "MedicalStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultations_ResultId",
                table: "MedicalConsultations",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultations_StudentId",
                table: "MedicalConsultations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalIncidents_StudentId",
                table: "MedicalIncidents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSupplyUsages_IncidentId",
                table: "MedicalSupplyUsages",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRequests_MedicalStaffId",
                table: "MedicationRequests",
                column: "MedicalStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRequests_StudentId",
                table: "MedicationRequests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDiaries_StudentId",
                table: "MedicineDiaries",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHealthCheckupSchedules_HealthCheckupCampaignId",
                table: "StudentHealthCheckupSchedules",
                column: "HealthCheckupCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHealthCheckupSchedules_StudentId",
                table: "StudentHealthCheckupSchedules",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentId",
                table: "Students",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentVaccinationSchedules_StudentId",
                table: "StudentVaccinationSchedules",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentVaccinationSchedules_VaccinationCampaignId",
                table: "StudentVaccinationSchedules",
                column: "VaccinationCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVaccinationCampaign_VaccinationCampaignsId",
                table: "UserVaccinationCampaign",
                column: "VaccinationCampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationConsentForms_StudentId",
                table: "VaccinationConsentForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationConsentForms_VaccinationCampaignId",
                table: "VaccinationConsentForms",
                column: "VaccinationCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationResults_VaccinationScheduleId",
                table: "VaccinationResults",
                column: "VaccinationScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "HealthCheckupCampaignUser");

            migrationBuilder.DropTable(
                name: "HealthCheckupConsentForms");

            migrationBuilder.DropTable(
                name: "HealthRecords");

            migrationBuilder.DropTable(
                name: "MedicalConsultations");

            migrationBuilder.DropTable(
                name: "MedicalSupplyUsages");

            migrationBuilder.DropTable(
                name: "MedicationRequests");

            migrationBuilder.DropTable(
                name: "MedicineDiaries");

            migrationBuilder.DropTable(
                name: "UserVaccinationCampaign");

            migrationBuilder.DropTable(
                name: "VaccinationConsentForms");

            migrationBuilder.DropTable(
                name: "VaccinationResults");

            migrationBuilder.DropTable(
                name: "HealthCheckupResults");

            migrationBuilder.DropTable(
                name: "MedicalIncidents");

            migrationBuilder.DropTable(
                name: "MedicalSuppliers");

            migrationBuilder.DropTable(
                name: "StudentVaccinationSchedules");

            migrationBuilder.DropTable(
                name: "StudentHealthCheckupSchedules");

            migrationBuilder.DropTable(
                name: "VaccinationCampaigns");

            migrationBuilder.DropTable(
                name: "HealthCheckupCampaigns");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
