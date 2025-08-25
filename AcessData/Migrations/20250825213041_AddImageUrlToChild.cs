using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "childUsers");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "childUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "childUsers");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "childUsers",
                type: "int",
                nullable: true);
        }
    }
}
