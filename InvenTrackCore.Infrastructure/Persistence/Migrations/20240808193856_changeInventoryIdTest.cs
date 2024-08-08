using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTrackCore.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeInventoryIdTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvetoryId",
                table: "Inventories",
                newName: "InventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Inventories",
                type: "text",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldUnicode: false,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "Inventories",
                newName: "InvetoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Inventories",
                type: "text",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldUnicode: false);
        }
    }
}
