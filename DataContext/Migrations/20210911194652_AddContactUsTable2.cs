using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class AddContactUsTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emial",
                table: "ContactUs");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ContactUs",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ContactUs");

            migrationBuilder.AddColumn<string>(
                name: "Emial",
                table: "ContactUs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
