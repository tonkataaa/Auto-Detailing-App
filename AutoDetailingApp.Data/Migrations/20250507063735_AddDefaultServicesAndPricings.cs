using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDetailingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultServicesAndPricings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
	   table: "Services",
	   columns: new[] { "Id", "CreatedAt", "Description", "DurationMinutes", "Name", "Price" },
	   values: new object[,]
	   {
			{ new Guid("14d701f7-36e4-43e4-b14e-0d881a99a190"), DateTime.UtcNow, "Пране на мокет и текстилен салон...", 120, "Вътрешно почистване", 210.00m },
			{ new Guid("4f54bc58-b3eb-4d7d-b867-2f1964968ae8"), DateTime.UtcNow, "Безконтактно измиване...", 120, "Външно почистване", 80.00m },
			{ new Guid("a36cce33-44df-4035-8d98-6b7f7978a04c"), DateTime.UtcNow, "Професионални услуги...", 240, "Цялостно детайлно почистване", 270.00m },
			{ new Guid("b79310c6-9da1-4f88-80f5-f8e7f099a642"), DateTime.UtcNow, "Възстановяване на прозрачността...", 120, "Полиране на фарове", 80.00m }
	   });

			migrationBuilder.InsertData(
				table: "Pricings",
				columns: new[] { "Id", "EffectiveFrom", "Price", "ServiceId" },
				values: new object[,]
				{
			{ new Guid("e87c89a4-2a7f-4f0e-b1b8-001111111111"), new DateTime(2025, 1, 1), 210.00m, new Guid("14d701f7-36e4-43e4-b14e-0d881a99a190") },
			{ new Guid("e87c89a4-2a7f-4f0e-b1b8-002222222222"), new DateTime(2025, 1, 1), 270.00m, new Guid("a36cce33-44df-4035-8d98-6b7f7978a04c") },
			{ new Guid("e87c89a4-2a7f-4f0e-b1b8-003333333333"), new DateTime(2025, 1, 1), 80.00m, new Guid("4f54bc58-b3eb-4d7d-b867-2f1964968ae8") },
			{ new Guid("e87c89a4-2a7f-4f0e-b1b8-004444444444"), new DateTime(2025, 1, 1), 80.00m, new Guid("b79310c6-9da1-4f88-80f5-f8e7f099a642") }
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
