using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDetailingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false, defaultValue: "Pending"),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Services",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DateTime",
                table: "Appointments",
                column: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Status",
                table: "Appointments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_ServiceId",
                table: "Pricings",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ContactRequests");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
