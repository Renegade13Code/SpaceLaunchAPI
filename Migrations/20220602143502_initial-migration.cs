using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceLaunchAPI.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaunchPads",
                columns: table => new
                {
                    LaunchpadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchPads", x => x.LaunchpadId);
                });

            migrationBuilder.CreateTable(
                name: "Rockets",
                columns: table => new
                {
                    RocketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeightMt = table.Column<double>(type: "float", nullable: false),
                    HeightFt = table.Column<double>(type: "float", nullable: false),
                    DiameterMt = table.Column<double>(type: "float", nullable: false),
                    DiameterFt = table.Column<double>(type: "float", nullable: false),
                    MassKg = table.Column<double>(type: "float", nullable: false),
                    MassLb = table.Column<double>(type: "float", nullable: false),
                    Stages = table.Column<int>(type: "int", nullable: false),
                    Boosters = table.Column<int>(type: "int", nullable: false),
                    CostPerLaunch = table.Column<double>(type: "float", nullable: false),
                    Engines = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rockets", x => x.RocketId);
                });

            migrationBuilder.CreateTable(
                name: "Launches",
                columns: table => new
                {
                    LaunchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RocketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LaunchpadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Failures = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launches", x => x.LaunchId);
                    table.ForeignKey(
                        name: "FK_Launches_LaunchPads_LaunchpadId",
                        column: x => x.LaunchpadId,
                        principalTable: "LaunchPads",
                        principalColumn: "LaunchpadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Launches_Rockets_RocketId",
                        column: x => x.RocketId,
                        principalTable: "Rockets",
                        principalColumn: "RocketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capsules",
                columns: table => new
                {
                    CapsuleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReuseCount = table.Column<int>(type: "int", nullable: false),
                    WaterLandings = table.Column<int>(type: "int", nullable: false),
                    LandLandings = table.Column<int>(type: "int", nullable: false),
                    LaunchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capsules", x => x.CapsuleId);
                    table.ForeignKey(
                        name: "FK_Capsules_Launches_LaunchId",
                        column: x => x.LaunchId,
                        principalTable: "Launches",
                        principalColumn: "LaunchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayLoads",
                columns: table => new
                {
                    PayloadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reused = table.Column<bool>(type: "bit", nullable: false),
                    Manufacturers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MassKg = table.Column<double>(type: "float", nullable: true),
                    MassLb = table.Column<double>(type: "float", nullable: true),
                    Orbit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayLoads", x => x.PayloadId);
                    table.ForeignKey(
                        name: "FK_PayLoads_Launches_LaunchId",
                        column: x => x.LaunchId,
                        principalTable: "Launches",
                        principalColumn: "LaunchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capsules_LaunchId",
                table: "Capsules",
                column: "LaunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_LaunchpadId",
                table: "Launches",
                column: "LaunchpadId");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_RocketId",
                table: "Launches",
                column: "RocketId");

            migrationBuilder.CreateIndex(
                name: "IX_PayLoads_LaunchId",
                table: "PayLoads",
                column: "LaunchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capsules");

            migrationBuilder.DropTable(
                name: "PayLoads");

            migrationBuilder.DropTable(
                name: "Launches");

            migrationBuilder.DropTable(
                name: "LaunchPads");

            migrationBuilder.DropTable(
                name: "Rockets");
        }
    }
}
