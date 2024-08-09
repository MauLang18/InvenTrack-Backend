using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTrackCore.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Locations_LocateId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_LocateId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "LocateId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Tickets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Tickets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LocationId",
                table: "Tickets",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Locations_LocationId",
                table: "Tickets",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Locations_LocationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_LocationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocateId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LocateId",
                table: "Tickets",
                column: "LocateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Locations_LocateId",
                table: "Tickets",
                column: "LocateId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }
    }
}
