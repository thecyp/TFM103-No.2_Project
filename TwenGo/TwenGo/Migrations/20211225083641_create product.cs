using Microsoft.EntityFrameworkCore.Migrations;

namespace TwenGo.Migrations
{
    public partial class createproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "ID");
        }
    }
}
