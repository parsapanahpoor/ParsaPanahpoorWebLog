using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class SliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogSelectedCategories_blogCategories_BlogCategoryId",
                table: "blogSelectedCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_blogSelectedCategories_Blogs_BlogId",
                table: "blogSelectedCategories");

            migrationBuilder.CreateTable(
                name: "sliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderImageName = table.Column<string>(maxLength: 50, nullable: true),
                    SliderText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sliders", x => x.SliderId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_blogSelectedCategories_blogCategories_BlogCategoryId",
                table: "blogSelectedCategories",
                column: "BlogCategoryId",
                principalTable: "blogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_blogSelectedCategories_Blogs_BlogId",
                table: "blogSelectedCategories",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogSelectedCategories_blogCategories_BlogCategoryId",
                table: "blogSelectedCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_blogSelectedCategories_Blogs_BlogId",
                table: "blogSelectedCategories");

            migrationBuilder.DropTable(
                name: "sliders");

            migrationBuilder.AddForeignKey(
                name: "FK_blogSelectedCategories_blogCategories_BlogCategoryId",
                table: "blogSelectedCategories",
                column: "BlogCategoryId",
                principalTable: "blogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogSelectedCategories_Blogs_BlogId",
                table: "blogSelectedCategories",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
