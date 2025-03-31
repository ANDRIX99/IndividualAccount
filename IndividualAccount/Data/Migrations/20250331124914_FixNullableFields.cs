using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividualAccount.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_DeletedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ModifiedById",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_DeletedById",
                table: "Items",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_ModifiedById",
                table: "Items",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_DeletedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ModifiedById",
                table: "Items");

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
    }
}
