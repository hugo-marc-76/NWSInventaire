using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    /// <inheritdoc />
    public partial class ModifyMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_materialCategories_MaterialCategorieId",
                table: "materials");

            migrationBuilder.DropForeignKey(
                name: "FK_materials_students_StudentId",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_MaterialCategorieId",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_StudentId",
                table: "materials");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "materials",
                newName: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "materials",
                newName: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_materials_MaterialCategorieId",
                table: "materials",
                column: "MaterialCategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_materials_StudentId",
                table: "materials",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_materialCategories_MaterialCategorieId",
                table: "materials",
                column: "MaterialCategorieId",
                principalTable: "materialCategories",
                principalColumn: "MaterialCategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_students_StudentId",
                table: "materials",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId");
        }
    }
}
