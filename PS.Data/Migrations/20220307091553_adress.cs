using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Products",
                newName: "MyAdress_StreetAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Products",
                newName: "MyAdress_City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyAdress_StreetAddress",
                table: "Products",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "MyAdress_City",
                table: "Products",
                newName: "City");
        }
    }
}
