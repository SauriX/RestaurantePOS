using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantePOS.Migrations
{
    /// <inheritdoc />
    public partial class configurationes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    EstablecimientoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Representante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnviarSMS = table.Column<bool>(type: "bit", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BkpAlias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoBackup = table.Column<bool>(type: "bit", nullable: false),
                    AutoPrint = table.Column<bool>(type: "bit", nullable: false),
                    AbrirCaja = table.Column<bool>(type: "bit", nullable: false),
                    ImpresoraDomicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpresoraCuentas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpresoraCobros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpresoraCortes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlertaCorte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailNotificacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");
        }
    }
}
