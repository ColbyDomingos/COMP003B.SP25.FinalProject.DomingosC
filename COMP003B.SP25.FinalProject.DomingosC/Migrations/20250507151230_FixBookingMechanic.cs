using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.SP25.FinalProject.DomingosC.Migrations
{
    /// <inheritdoc />
    public partial class FixBookingMechanic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingMechanic_Bookings_BookingId",
                table: "BookingMechanic");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingMechanic_Mechanics_MechanicId",
                table: "BookingMechanic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingMechanic",
                table: "BookingMechanic");

            migrationBuilder.RenameTable(
                name: "BookingMechanic",
                newName: "BookingMechanics");

            migrationBuilder.RenameIndex(
                name: "IX_BookingMechanic_MechanicId",
                table: "BookingMechanics",
                newName: "IX_BookingMechanics_MechanicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingMechanics",
                table: "BookingMechanics",
                columns: new[] { "BookingId", "MechanicId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingMechanics_Bookings_BookingId",
                table: "BookingMechanics",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingMechanics_Mechanics_MechanicId",
                table: "BookingMechanics",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingMechanics_Bookings_BookingId",
                table: "BookingMechanics");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingMechanics_Mechanics_MechanicId",
                table: "BookingMechanics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingMechanics",
                table: "BookingMechanics");

            migrationBuilder.RenameTable(
                name: "BookingMechanics",
                newName: "BookingMechanic");

            migrationBuilder.RenameIndex(
                name: "IX_BookingMechanics_MechanicId",
                table: "BookingMechanic",
                newName: "IX_BookingMechanic_MechanicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingMechanic",
                table: "BookingMechanic",
                columns: new[] { "BookingId", "MechanicId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingMechanic_Bookings_BookingId",
                table: "BookingMechanic",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingMechanic_Mechanics_MechanicId",
                table: "BookingMechanic",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
