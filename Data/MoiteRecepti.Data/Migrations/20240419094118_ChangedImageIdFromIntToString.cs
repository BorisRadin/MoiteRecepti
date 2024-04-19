using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoiteRecepti.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedImageIdFromIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AddedByUserId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AddedByUserId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AddedByUserId1",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "AddedByUserId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AddedByUserId",
                table: "Images",
                column: "AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AddedByUserId",
                table: "Images",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AddedByUserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AddedByUserId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "AddedByUserId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId1",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AddedByUserId1",
                table: "Images",
                column: "AddedByUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AddedByUserId1",
                table: "Images",
                column: "AddedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
