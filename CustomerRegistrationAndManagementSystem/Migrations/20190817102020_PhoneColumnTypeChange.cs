using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerRegistrationAndManagementSystem.Migrations
{
    public partial class PhoneColumnTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Mobile",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
