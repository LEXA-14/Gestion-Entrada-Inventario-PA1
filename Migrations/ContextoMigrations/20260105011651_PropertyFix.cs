using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Entrada_Inventario_PA1.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class PropertyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaDetalle_Entrada_Entrada",
                table: "EntradaDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_EntradaDetalle_Producto_Producto",
                table: "EntradaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_EntradaDetalle_Entrada",
                table: "EntradaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_EntradaDetalle_Producto",
                table: "EntradaDetalle");

            migrationBuilder.DropColumn(
                name: "Entrada",
                table: "EntradaDetalle");

            migrationBuilder.DropColumn(
                name: "Producto",
                table: "EntradaDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_entradaId",
                table: "EntradaDetalle",
                column: "entradaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_ProductoId",
                table: "EntradaDetalle",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaDetalle_Entrada_entradaId",
                table: "EntradaDetalle",
                column: "entradaId",
                principalTable: "Entrada",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaDetalle_Producto_ProductoId",
                table: "EntradaDetalle",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaDetalle_Entrada_entradaId",
                table: "EntradaDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_EntradaDetalle_Producto_ProductoId",
                table: "EntradaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_EntradaDetalle_entradaId",
                table: "EntradaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_EntradaDetalle_ProductoId",
                table: "EntradaDetalle");

            migrationBuilder.AddColumn<int>(
                name: "Entrada",
                table: "EntradaDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Producto",
                table: "EntradaDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_Entrada",
                table: "EntradaDetalle",
                column: "Entrada");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_Producto",
                table: "EntradaDetalle",
                column: "Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaDetalle_Entrada_Entrada",
                table: "EntradaDetalle",
                column: "Entrada",
                principalTable: "Entrada",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaDetalle_Producto_Producto",
                table: "EntradaDetalle",
                column: "Producto",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
