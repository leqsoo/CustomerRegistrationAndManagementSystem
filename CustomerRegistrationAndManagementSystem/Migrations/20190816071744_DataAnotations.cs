using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerRegistrationAndManagementSystem.Migrations
{
    public partial class DataAnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PriviteID",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PriviteID",
                table: "Customers",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
