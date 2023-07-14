using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Management.Persistence.Migrations
{
    public partial class SeedingDeliveryTypesv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Unloading" });

            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Preparing" });

            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Sent" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
