using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ailes",
                columns: table => new
                {
                    AisleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AisleNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ailes", x => x.AisleID);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    ShelfID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AisleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.ShelfID);
                    table.ForeignKey(
                        name: "FK_Shelves_Ailes_AisleID",
                        column: x => x.AisleID,
                        principalTable: "Ailes",
                        principalColumn: "AisleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_AisleID",
                table: "Shelves",
                column: "AisleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Ailes");
        }
    }
}
