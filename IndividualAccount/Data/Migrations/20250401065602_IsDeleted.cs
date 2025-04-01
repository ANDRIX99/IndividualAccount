using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividualAccount.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "versione",
                table: "VersioniDistintaBase",
                newName: "Versione");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VersioniDistintaBase",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DistinteBase",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VersioniDistintaBase");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DistinteBase");

            migrationBuilder.RenameColumn(
                name: "Versione",
                table: "VersioniDistintaBase",
                newName: "versione");
        }
    }
}
