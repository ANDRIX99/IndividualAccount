using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividualAccount.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVersioneType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Versione",
                table: "VersioniDistintaBase",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Versione",
                table: "VersioniDistintaBase",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
