using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class TPT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Herbs",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsBiological",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LabName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyAdress_City",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyAdress_StreetAddress",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Biologicals",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Herbs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biologicals", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Biologicals_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chemicals",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyAdress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyAdress_StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemicals", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Chemicals_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biologicals");

            migrationBuilder.DropTable(
                name: "Chemicals");

            migrationBuilder.AddColumn<string>(
                name: "Herbs",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsBiological",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LabName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyAdress_City",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyAdress_StreetAddress",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
