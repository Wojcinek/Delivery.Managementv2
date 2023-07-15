using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Management.Persistence.Migrations
{
    public partial class DeliveryRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeliveryRequests",
                columns: new[] { "Id", "City", "DeliveryAllocationId", "DeliveryTypeId", "HouseNumber", "RequestComments", "Street", "ZipCode" },
                values: new object[] { 1, "Cracow", 101, 1000, 12, "No Comment", "Zielona", "30‑063" });

            migrationBuilder.InsertData(
                table: "DeliveryRequests",
                columns: new[] { "Id", "City", "DeliveryAllocationId", "DeliveryTypeId", "HouseNumber", "RequestComments", "Street", "ZipCode" },
                values: new object[] { 2, "Cracow", 102, 1001, 12, "No Comment", "Zielona", "30‑063" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryRequests",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
