using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultinationalTourAndTravels.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class itinerary_table_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Itineraries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Itineraries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
