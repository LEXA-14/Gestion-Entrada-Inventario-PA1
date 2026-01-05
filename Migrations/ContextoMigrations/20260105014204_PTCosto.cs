using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Entrada_Inventario_PA1.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class PTCosto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "EntradaDetalle",
                newName: "Costo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Costo",
                table: "EntradaDetalle",
                newName: "Precio");
        }
    }
}
