using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class updateProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageName",
                table: "projects",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageName",
                table: "projects");
        }
    }
}
