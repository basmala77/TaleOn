using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "childUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "childUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChildrenCount",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
