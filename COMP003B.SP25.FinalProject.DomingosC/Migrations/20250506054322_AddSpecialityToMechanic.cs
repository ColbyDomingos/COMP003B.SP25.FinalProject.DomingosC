using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.SP25.FinalProject.DomingosC.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialityToMechanic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Mechanics");
        }
    }
}
