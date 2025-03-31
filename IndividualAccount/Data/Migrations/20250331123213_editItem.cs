using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividualAccount.Data.Migrations
{
    /// <inheritdoc />
    public partial class editItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_CreatedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_DeletedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ModifiedById",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_CreatedById",
                table: "Items",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_DeletedById",
                table: "Items",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_ModifiedById",
                table: "Items",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_CreatedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_DeletedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ModifiedById",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "Items",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "Items",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_CreatedById",
                table: "Items",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_DeletedById",
                table: "Items",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_ModifiedById",
                table: "Items",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
