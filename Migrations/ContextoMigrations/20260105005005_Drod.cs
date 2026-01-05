using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Entrada_Inventario_PA1.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class Drod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Entrada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Entrada",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
