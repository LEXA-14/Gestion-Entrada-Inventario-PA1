using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Entrada_Inventario_PA1.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class entrada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Productoid",
                table: "Producto",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "EntradaId",
                table: "EntradaDetalle",
                newName: "entradaId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "EntradaDetalle",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Entrada",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Producto",
                newName: "Productoid");

            migrationBuilder.RenameColumn(
                name: "entradaId",
                table: "EntradaDetalle",
                newName: "EntradaId");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "EntradaDetalle",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
