using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityModel.Migrations
{
    /// <inheritdoc />
    public partial class updatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "WeatherForecast");

            migrationBuilder.AddColumn<Guid>(
                name: "WeatherSummaryId",
                table: "WeatherForecast",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "WeatherSummary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherSummary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_WeatherSummaryId",
                table: "WeatherForecast",
                column: "WeatherSummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecast_WeatherSummary_WeatherSummaryId",
                table: "WeatherForecast",
                column: "WeatherSummaryId",
                principalTable: "WeatherSummary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecast_WeatherSummary_WeatherSummaryId",
                table: "WeatherForecast");

            migrationBuilder.DropTable(
                name: "WeatherSummary");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecast_WeatherSummaryId",
                table: "WeatherForecast");

            migrationBuilder.DropColumn(
                name: "WeatherSummaryId",
                table: "WeatherForecast");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "WeatherForecast",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
