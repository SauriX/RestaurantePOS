using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantePOS.Migrations
{
    /// <inheritdoc />
    public partial class configuracion_options : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AutoPrint",
                table: "Configurations",
                newName: "ImpresoraUnica");

            migrationBuilder.RenameColumn(
                name: "AbrirCaja",
                table: "Configurations",
                newName: "CobroDirecto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImpresoraUnica",
                table: "Configurations",
                newName: "AutoPrint");

            migrationBuilder.RenameColumn(
                name: "CobroDirecto",
                table: "Configurations",
                newName: "AbrirCaja");
        }
    }
}
