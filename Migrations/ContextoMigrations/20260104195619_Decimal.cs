using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Entrada_Inventario_PA1.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class Decimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importe",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "Entrada",
                newName: "Concepto");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Producto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Producto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Concepto",
                table: "Entrada",
                newName: "NombreCliente");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Producto",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Costo",
                table: "Producto",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Importe",
                table: "Entrada",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
