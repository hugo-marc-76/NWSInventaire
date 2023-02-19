using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialCategorieModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialType");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "materials",
                newName: "StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "materials",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "materialCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materialCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_materials_StudentId",
                table: "materials",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_materialCategories_MaterialId",
                table: "materials",
                column: "MaterialId",
                principalTable: "materialCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_materials_students_StudentId",
                table: "materials",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_materialCategories_MaterialId",
                table: "materials");

            migrationBuilder.DropForeignKey(
                name: "FK_materials_students_StudentId",
                table: "materials");

            migrationBuilder.DropTable(
                name: "materialCategories");

            migrationBuilder.DropIndex(
                name: "IX_materials_StudentId",
                table: "materials");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "materials",
                newName: "studentId");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "materials",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "MaterialType",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialType", x => x.id);
                });
        }
    }
}
