using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    /// <inheritdoc />
    public partial class modelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_MaterialType_materialTypeid",
                table: "materials");

            migrationBuilder.DropForeignKey(
                name: "FK_materials_students_StudentId",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_materialTypeid",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_StudentId",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "materialTypeid",
                table: "materials");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "materials",
                newName: "studentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartLend",
                table: "materials",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastReminder",
                table: "materials",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndLend",
                table: "materials",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "materials",
                newName: "StudentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartLend",
                table: "materials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastReminder",
                table: "materials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndLend",
                table: "materials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "materialTypeid",
                table: "materials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_materials_materialTypeid",
                table: "materials",
                column: "materialTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_materials_StudentId",
                table: "materials",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_MaterialType_materialTypeid",
                table: "materials",
                column: "materialTypeid",
                principalTable: "MaterialType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_materials_students_StudentId",
                table: "materials",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
