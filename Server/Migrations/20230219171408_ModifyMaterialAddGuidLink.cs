using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    /// <inheritdoc />
    public partial class ModifyMaterialAddGuidLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LinkAllMaterial",
                table: "materials",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkAllMaterial",
                table: "materials");
        }
    }
}
