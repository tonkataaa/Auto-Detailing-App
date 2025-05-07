using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoDetailingApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedServiceAndPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Description", "DurationMinutes", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("14d701f7-36e4-43e4-b14e-0d881a99a190"), new DateTime(2025, 5, 7, 5, 54, 9, 134, DateTimeKind.Utc).AddTicks(148), "Пране на мокет и текстилен салон\n Почистване и подхранване на всички повърхности\nИмпрегниране на текстил или кож", 120, "Вътрешно почистване", 210.00m },
                    { new Guid("4f54bc58-b3eb-4d7d-b867-2f1964968ae8"), new DateTime(2025, 5, 7, 5, 54, 9, 134, DateTimeKind.Utc).AddTicks(153), "Безконтактно измиване\nРъчно миене с премахване на смоли и лепила\nНанасяне на защитно покритие (до 3 месеца)", 120, "Външно почистване", 80.00m },
                    { new Guid("a36cce33-44df-4035-8d98-6b7f7978a04c"), new DateTime(2025, 5, 7, 5, 54, 9, 134, DateTimeKind.Utc).AddTicks(170), "Професионални услуги за възстановяване на блясъка и свежестта на Вашия автомобил – както отвън, така и отвътре", 240, "Цялостно детайлно почистване", 270.00m },
                    { new Guid("b79310c6-9da1-4f88-80f5-f8e7f099a642"), new DateTime(2025, 5, 7, 5, 54, 9, 134, DateTimeKind.Utc).AddTicks(167), "Възстановяване на прозрачността\nЗащитно покритие с трайност до 1 година\n", 120, "Полиране на фарове", 80.00m }
                });

            migrationBuilder.InsertData(
                table: "Pricings",
                columns: new[] { "Id", "EffectiveFrom", "Price", "ServiceId" },
                values: new object[,]
                {
                    { new Guid("e87c89a4-2a7f-4f0e-b1b8-001111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 210.00m, new Guid("14d701f7-36e4-43e4-b14e-0d881a99a190") },
                    { new Guid("e87c89a4-2a7f-4f0e-b1b8-002222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 270.00m, new Guid("a36cce33-44df-4035-8d98-6b7f7978a04c") },
                    { new Guid("e87c89a4-2a7f-4f0e-b1b8-003333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.00m, new Guid("4f54bc58-b3eb-4d7d-b867-2f1964968ae8") },
                    { new Guid("e87c89a4-2a7f-4f0e-b1b8-004444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.00m, new Guid("b79310c6-9da1-4f88-80f5-f8e7f099a642") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pricings",
                keyColumn: "Id",
                keyValue: new Guid("e87c89a4-2a7f-4f0e-b1b8-001111111111"));

            migrationBuilder.DeleteData(
                table: "Pricings",
                keyColumn: "Id",
                keyValue: new Guid("e87c89a4-2a7f-4f0e-b1b8-002222222222"));

            migrationBuilder.DeleteData(
                table: "Pricings",
                keyColumn: "Id",
                keyValue: new Guid("e87c89a4-2a7f-4f0e-b1b8-003333333333"));

            migrationBuilder.DeleteData(
                table: "Pricings",
                keyColumn: "Id",
                keyValue: new Guid("e87c89a4-2a7f-4f0e-b1b8-004444444444"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("14d701f7-36e4-43e4-b14e-0d881a99a190"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("4f54bc58-b3eb-4d7d-b867-2f1964968ae8"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a36cce33-44df-4035-8d98-6b7f7978a04c"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("b79310c6-9da1-4f88-80f5-f8e7f099a642"));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
