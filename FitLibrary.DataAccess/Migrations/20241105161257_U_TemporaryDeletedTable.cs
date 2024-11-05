using Microsoft.EntityFrameworkCore.Migrations;

namespace FitLibrary.DataAccess.Migrations
{
    public partial class U_TemporaryDeletedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
