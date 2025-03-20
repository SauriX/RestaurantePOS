using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantePOS.Migrations
{
    /// <inheritdoc />
    public partial class discunts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discunts",
                columns: table => new
                {
                    DiscuntId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscuntName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porcent = table.Column<int>(type: "int", precision: 0, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discunts", x => x.DiscuntId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discunts");
        }
    }
}
