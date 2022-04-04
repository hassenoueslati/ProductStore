using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class TablePorteuse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Achat",
                columns: table => new
                {
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductFK = table.Column<int>(type: "int", nullable: false),
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achat", x => new { x.DateAchat, x.ClientFK, x.ProductFK });
                    table.ForeignKey(
                        name: "FK_Achat_Client_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Client",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Achat_Products_ProductFK",
                        column: x => x.ProductFK,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achat_ClientFK",
                table: "Achat",
                column: "ClientFK");

            migrationBuilder.CreateIndex(
                name: "IX_Achat_ProductFK",
                table: "Achat",
                column: "ProductFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achat");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
