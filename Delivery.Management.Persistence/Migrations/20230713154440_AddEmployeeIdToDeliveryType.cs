using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Management.Persistence.Migrations
{
    public partial class AddEmployeeIdToDeliveryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "DeliveryTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "DeliveryTypes");
        }
    }
}
