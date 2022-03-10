using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class Annotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Providers_Providersid",
                table: "ProductProvider");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Providers");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Providers",
                newName: "ProviderCode");

            migrationBuilder.RenameColumn(
                name: "Providersid",
                table: "ProductProvider",
                newName: "ProvidersProviderCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProvider_Providersid",
                table: "ProductProvider",
                newName: "IX_ProductProvider_ProvidersProviderCode");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersProviderCode",
                table: "ProductProvider",
                column: "ProvidersProviderCode",
                principalTable: "Providers",
                principalColumn: "ProviderCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersProviderCode",
                table: "ProductProvider");

            migrationBuilder.RenameColumn(
                name: "ProviderCode",
                table: "Providers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProvidersProviderCode",
                table: "ProductProvider",
                newName: "Providersid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProvider_ProvidersProviderCode",
                table: "ProductProvider",
                newName: "IX_ProductProvider_Providersid");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Providers_Providersid",
                table: "ProductProvider",
                column: "Providersid",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
