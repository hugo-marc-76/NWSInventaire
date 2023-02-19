using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialCategorie01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "materialCategories",
                newName: "MaterialCategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaterialCategorieId",
                table: "materialCategories",
                newName: "Id");
        }
    }
}
