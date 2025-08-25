using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class Childwimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_childUsers_ImageId",
                table: "childUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_childUsers_Images_ImageId",
                table: "childUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_childUsers_Images_ImageId",
                table: "childUsers");

            migrationBuilder.DropIndex(
                name: "IX_childUsers_ImageId",
                table: "childUsers");
        }
    }
}
