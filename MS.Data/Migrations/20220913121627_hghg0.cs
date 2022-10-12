using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterStors.API.Data.Migrations
{
    public partial class hghg0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AspNetUsers_OnwerId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "OnewrId",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "OnwerId",
                table: "Stores",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_OnwerId",
                table: "Stores",
                newName: "IX_Stores_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AspNetUsers_OwnerId",
                table: "Stores",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AspNetUsers_OwnerId",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Stores",
                newName: "OnwerId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_OwnerId",
                table: "Stores",
                newName: "IX_Stores_OnwerId");

            migrationBuilder.AddColumn<string>(
                name: "OnewrId",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AspNetUsers_OnwerId",
                table: "Stores",
                column: "OnwerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
