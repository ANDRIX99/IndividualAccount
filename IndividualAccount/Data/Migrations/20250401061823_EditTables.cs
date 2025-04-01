using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividualAccount.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "VersioniDistintaBase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "VersioniDistintaBase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "VersioniDistintaBase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "DistinteBase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "DistinteBase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DistinteBase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VersioniDistintaBase_CreatedById",
                table: "VersioniDistintaBase",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VersioniDistintaBase_DeletedById",
                table: "VersioniDistintaBase",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_VersioniDistintaBase_ModifiedById",
                table: "VersioniDistintaBase",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DistinteBase_CreatedById",
                table: "DistinteBase",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DistinteBase_DeletedById",
                table: "DistinteBase",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DistinteBase_ModifiedById",
                table: "DistinteBase",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DistinteBase_AspNetUsers_CreatedById",
                table: "DistinteBase",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DistinteBase_AspNetUsers_DeletedById",
                table: "DistinteBase",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DistinteBase_AspNetUsers_ModifiedById",
                table: "DistinteBase",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VersioniDistintaBase_AspNetUsers_CreatedById",
                table: "VersioniDistintaBase",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VersioniDistintaBase_AspNetUsers_DeletedById",
                table: "VersioniDistintaBase",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VersioniDistintaBase_AspNetUsers_ModifiedById",
                table: "VersioniDistintaBase",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistinteBase_AspNetUsers_CreatedById",
                table: "DistinteBase");

            migrationBuilder.DropForeignKey(
                name: "FK_DistinteBase_AspNetUsers_DeletedById",
                table: "DistinteBase");

            migrationBuilder.DropForeignKey(
                name: "FK_DistinteBase_AspNetUsers_ModifiedById",
                table: "DistinteBase");

            migrationBuilder.DropForeignKey(
                name: "FK_VersioniDistintaBase_AspNetUsers_CreatedById",
                table: "VersioniDistintaBase");

            migrationBuilder.DropForeignKey(
                name: "FK_VersioniDistintaBase_AspNetUsers_DeletedById",
                table: "VersioniDistintaBase");

            migrationBuilder.DropForeignKey(
                name: "FK_VersioniDistintaBase_AspNetUsers_ModifiedById",
                table: "VersioniDistintaBase");

            migrationBuilder.DropIndex(
                name: "IX_VersioniDistintaBase_CreatedById",
                table: "VersioniDistintaBase");

            migrationBuilder.DropIndex(
                name: "IX_VersioniDistintaBase_DeletedById",
                table: "VersioniDistintaBase");

            migrationBuilder.DropIndex(
                name: "IX_VersioniDistintaBase_ModifiedById",
                table: "VersioniDistintaBase");

            migrationBuilder.DropIndex(
                name: "IX_DistinteBase_CreatedById",
                table: "DistinteBase");

            migrationBuilder.DropIndex(
                name: "IX_DistinteBase_DeletedById",
                table: "DistinteBase");

            migrationBuilder.DropIndex(
                name: "IX_DistinteBase_ModifiedById",
                table: "DistinteBase");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "VersioniDistintaBase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "VersioniDistintaBase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "VersioniDistintaBase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "DistinteBase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "DistinteBase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DistinteBase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
