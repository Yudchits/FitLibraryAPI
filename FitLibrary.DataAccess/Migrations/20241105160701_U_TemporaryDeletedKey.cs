using Microsoft.EntityFrameworkCore.Migrations;

namespace FitLibrary.DataAccess.Migrations
{
    public partial class U_TemporaryDeletedKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Users_CreatorId",
                table: "TrainingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_CreatorId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TrainingPlans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "TrainingPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_CreatorId",
                table: "TrainingPlans",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Users_CreatorId",
                table: "TrainingPlans",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
