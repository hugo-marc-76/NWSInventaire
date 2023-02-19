using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialCategorie00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_materialCategories_MaterialId",
                table: "materials");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "materials",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "MaterialCategorieId",
                table: "materials",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_materials_MaterialCategorieId",
                table: "materials",
                column: "MaterialCategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_materialCategories_MaterialCategorieId",
                table: "materials",
                column: "MaterialCategorieId",
                principalTable: "materialCategories",
                principalColumn: "MaterialCategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_materialCategories_MaterialCategorieId",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_MaterialCategorieId",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "MaterialCategorieId",
                table: "materials");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "materials",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_materials_materialCategories_MaterialId",
                table: "materials",
                column: "MaterialId",
                principalTable: "materialCategories",
                principalColumn: "MaterialCategorieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
