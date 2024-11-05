using Microsoft.EntityFrameworkCore.Migrations;

namespace FitLibrary.DataAccess.Migrations
{
    public partial class TP_AddedForeignKeyToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "TrainingPlans",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_CreatorId",
                table: "TrainingPlans",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_AspNetUsers_CreatorId",
                table: "TrainingPlans",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_AspNetUsers_CreatorId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_CreatorId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TrainingPlans");
        }
    }
}
