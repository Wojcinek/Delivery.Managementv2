using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Management.Persistence.Migrations
{
    public partial class SeedingDeliveryTypesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Warehouse",
                value: "Warehouse 1");

            migrationBuilder.InsertData(
                table: "DeliveryAllocations",
                columns: new[] { "Id", "Section", "Warehouse" },
                values: new object[,]
                {
                    { 3, "3", "Warehouse 1" },
                    { 4, "1", "Warehouse 2" },
                    { 5, "2", "Warehouse 2" },
                    { 6, "3", "Warehouse 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Warehouse",
                value: "Warehouse 2");
        }
    }
}
