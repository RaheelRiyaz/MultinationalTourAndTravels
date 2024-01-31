using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultinationalTourAndTravels.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DestinationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageType = table.Column<byte>(type: "tinyint", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinationDetails_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationDetails_PackageDestinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "PackageDestinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationDetails_DestinationId",
                table: "DestinationDetails",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationDetails_HotelId",
                table: "DestinationDetails",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationDetails");
        }
    }
}
