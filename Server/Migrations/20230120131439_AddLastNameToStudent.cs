using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddLastNameToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "StudentMail",
                table: "students",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "StudentFirstName",
                table: "students",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentLastName",
                table: "students",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentFirstName",
                table: "students");

            migrationBuilder.DropColumn(
                name: "StudentLastName",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "StudentMail",
                table: "students",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "students",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
