using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultinationalTourAndTravels.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class itinerary_table_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itineraries_Itineraries_ItineraryId",
                table: "Itineraries");

            migrationBuilder.DropIndex(
                name: "IX_Itineraries_ItineraryId",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "ItineraryId",
                table: "Itineraries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItineraryId",
                table: "Itineraries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_ItineraryId",
                table: "Itineraries",
                column: "ItineraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itineraries_Itineraries_ItineraryId",
                table: "Itineraries",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id");
        }
    }
}
