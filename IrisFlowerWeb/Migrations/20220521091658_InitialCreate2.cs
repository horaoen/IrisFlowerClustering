using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrisFlowerWeb.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlowerType",
                table: "IrisDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PetalLength",
                table: "IrisDatas",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PetalWidth",
                table: "IrisDatas",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SepalLength",
                table: "IrisDatas",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SepalWidth",
                table: "IrisDatas",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowerType",
                table: "IrisDatas");

            migrationBuilder.DropColumn(
                name: "PetalLength",
                table: "IrisDatas");

            migrationBuilder.DropColumn(
                name: "PetalWidth",
                table: "IrisDatas");

            migrationBuilder.DropColumn(
                name: "SepalLength",
                table: "IrisDatas");

            migrationBuilder.DropColumn(
                name: "SepalWidth",
                table: "IrisDatas");
        }
    }
}
