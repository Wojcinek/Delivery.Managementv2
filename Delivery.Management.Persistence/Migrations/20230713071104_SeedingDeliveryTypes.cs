using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Management.Persistence.Migrations
{
    public partial class SeedingDeliveryTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAllocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false),
                    DeliveryAllocationId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryRequests_DeliveryAllocations_DeliveryAllocationId",
                        column: x => x.DeliveryAllocationId,
                        principalTable: "DeliveryAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryRequests_DeliveryTypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeliveryAllocations",
                columns: new[] { "Id", "Section", "Warehouse" },
                values: new object[] { 1, "1", "Warehouse 1" });

            migrationBuilder.InsertData(
                table: "DeliveryAllocations",
                columns: new[] { "Id", "Section", "Warehouse" },
                values: new object[] { 2, "2", "Warehouse 2" });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRequests_DeliveryAllocationId",
                table: "DeliveryRequests",
                column: "DeliveryAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRequests_DeliveryTypeId",
                table: "DeliveryRequests",
                column: "DeliveryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryRequests");

            migrationBuilder.DropTable(
                name: "DeliveryAllocations");

            migrationBuilder.DropTable(
                name: "DeliveryTypes");
        }
    }
}
