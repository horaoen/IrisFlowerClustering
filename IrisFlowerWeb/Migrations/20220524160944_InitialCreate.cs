using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrisFlowerWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IrisFlower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SepalLength = table.Column<float>(type: "REAL", nullable: false),
                    SepalWidth = table.Column<float>(type: "REAL", nullable: false),
                    PetalLength = table.Column<float>(type: "REAL", nullable: false),
                    PetalWidth = table.Column<float>(type: "REAL", nullable: false),
                    FlowerType = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrisFlower", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IrisFlower");
        }
    }
}
