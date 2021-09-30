using Microsoft.EntityFrameworkCore.Migrations;

namespace DuckTracker.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ducks",
                table: "Ducks");

            migrationBuilder.RenameTable(
                name: "Ducks",
                newName: "Duck");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Duck",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Duck",
                table: "Duck",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Duck",
                table: "Duck");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Duck");

            migrationBuilder.RenameTable(
                name: "Duck",
                newName: "Ducks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ducks",
                table: "Ducks",
                column: "Id");
        }
    }
}
