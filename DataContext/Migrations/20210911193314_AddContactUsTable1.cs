using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class AddContactUsTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactUs",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "ContactUsID",
                table: "ContactUs");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "ContactUs",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactUs",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Emial",
                table: "ContactUs",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ContactUs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactUs",
                table: "ContactUs",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactUs",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ContactUs");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Emial",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "ContactUsID",
                table: "ContactUs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactUs",
                table: "ContactUs",
                column: "ContactUsID");
        }
    }
}
