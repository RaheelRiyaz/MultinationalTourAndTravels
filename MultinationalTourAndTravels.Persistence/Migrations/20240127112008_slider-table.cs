using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultinationalTourAndTravels.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class slidertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "ShowSlide",
                table: "AppFiles");

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowSlide = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "ShowSlide",
                table: "AppFiles",
                type: "tinyint",
                nullable: true);
        }
    }
}
