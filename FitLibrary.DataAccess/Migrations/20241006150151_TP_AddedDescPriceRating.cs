using Microsoft.EntityFrameworkCore.Migrations;

namespace FitLibrary.DataAccess.Migrations
{
    public partial class TP_AddedDescPriceRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingPlans",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TrainingPlans",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "TrainingPlans",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TrainingPlans");
        }
    }
}
