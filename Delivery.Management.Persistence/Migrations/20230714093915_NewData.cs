using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Management.Persistence.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "DeliveryTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DeliveryTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DeliveryTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "DeliveryAllocations",
                columns: new[] { "Id", "Section", "Warehouse" },
                values: new object[,]
                {
                    { 101, "3", "Standard" },
                    { 102, "2", "Express" },
                    { 103, "5", "Palette" },
                    { 104, "14", "International By Plane" },
                    { 105, "45", "International by Ship" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1000, "Unloading" },
                    { 1001, "Preparing" },
                    { 1002, "Sent" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "DeliveryAllocations",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "DeliveryTypes",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "DeliveryTypes",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "DeliveryTypes",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.InsertData(
                table: "DeliveryAllocations",
                columns: new[] { "Id", "Section", "Warehouse" },
                values: new object[,]
                {
                    { 1, "1", "Warehouse 1" },
                    { 2, "2", "Warehouse 1" },
                    { 3, "3", "Warehouse 1" },
                    { 4, "1", "Warehouse 2" },
                    { 5, "2", "Warehouse 2" },
                    { 6, "3", "Warehouse 2" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Unloading" },
                    { 11, "Preparing" },
                    { 12, "Sent" }
                });
        }
    }
}
