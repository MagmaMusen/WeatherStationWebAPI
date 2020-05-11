using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherStationWebAPI.Migrations
{
    public partial class UniquePlaceProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Places_Latitude_Longitude",
                table: "Places",
                columns: new[] { "Latitude", "Longitude" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Places_Latitude_Longitude",
                table: "Places");
        }
    }
}
