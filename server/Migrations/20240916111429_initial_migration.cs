using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FVA.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ActiveFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActiveTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OutOfArea = table.Column<bool>(type: "boolean", nullable: false),
                    Objectives = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    ParentOrganisationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organisation_Organisation_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Forename = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostcodeData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OutwardCode = table.Column<string>(type: "text", nullable: false),
                    CouncilWard = table.Column<string>(type: "text", nullable: false),
                    CouncilConstituency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcodeData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PublicContact = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    ReferralDetails = table.Column<string>(type: "text", nullable: false),
                    OperatingHours = table.Column<string>(type: "text", nullable: false),
                    ServiceObjectives = table.Column<string>(type: "text", nullable: false),
                    DemographicRestrictions = table.Column<string>(type: "text", nullable: false),
                    ServiceCost = table.Column<int>(type: "integer", nullable: false),
                    WorkerGenderChoice = table.Column<string>(type: "text", nullable: false),
                    OutOfArea = table.Column<bool>(type: "boolean", nullable: false),
                    AimsObjectives = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingName = table.Column<string>(type: "text", nullable: false),
                    BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Town = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    Postcode = table.Column<string>(type: "text", nullable: false),
                    ParkingDetails = table.Column<string>(type: "text", nullable: false),
                    LocationType = table.Column<string>(type: "text", nullable: false),
                    PostcodeDataId = table.Column<int>(type: "integer", nullable: false),
                    LongtitudeLattitude = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_PostcodeData_PostcodeDataId",
                        column: x => x.PostcodeDataId,
                        principalTable: "PostcodeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    PeopleContactId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationRole_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganisationRole_PeopleContact_PeopleContactId",
                        column: x => x.PeopleContactId,
                        principalTable: "PeopleContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganisationRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    PeopleContactId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRole_PeopleContact_PeopleContactId",
                        column: x => x.PeopleContactId,
                        principalTable: "PeopleContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessibilityFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Feature = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessibilityFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessibilityFeature_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganisationLocation_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceLocation_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessibilityFeature_LocationId",
                table: "AccessibilityFeature",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_PostcodeDataId",
                table: "Location",
                column: "PostcodeDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_ParentId",
                table: "Organisation",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationLocation_LocationId",
                table: "OrganisationLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationLocation_OrganisationId",
                table: "OrganisationLocation",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationRole_OrganisationId",
                table: "OrganisationRole",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationRole_PeopleContactId",
                table: "OrganisationRole",
                column: "PeopleContactId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationRole_RoleId",
                table: "OrganisationRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_OrganisationId",
                table: "Service",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLocation_LocationId",
                table: "ServiceLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLocation_ServiceId",
                table: "ServiceLocation",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRole_PeopleContactId",
                table: "ServiceRole",
                column: "PeopleContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRole_RoleId",
                table: "ServiceRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessibilityFeature");

            migrationBuilder.DropTable(
                name: "OrganisationLocation");

            migrationBuilder.DropTable(
                name: "OrganisationRole");

            migrationBuilder.DropTable(
                name: "ServiceLocation");

            migrationBuilder.DropTable(
                name: "ServiceRole");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "PeopleContact");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "PostcodeData");

            migrationBuilder.DropTable(
                name: "Organisation");
        }
    }
}
