using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherStationWebAPI.Migrations
{
    public partial class OneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Observations",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Observations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId1",
                table: "Observations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observations_PlaceId",
                table: "Observations",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_PlaceId1",
                table: "Observations",
                column: "PlaceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Places_PlaceId",
                table: "Observations",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Places_PlaceId1",
                table: "Observations",
                column: "PlaceId1",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Places_PlaceId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Places_PlaceId1",
                table: "Observations");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Observations_PlaceId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_PlaceId1",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "PlaceId1",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Observations",
                newName: "ID");
        }
    }
}
