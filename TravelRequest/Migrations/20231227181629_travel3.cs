using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class travel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravelCar",
                table: "Travels",
                newName: "Budget");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "Travels",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Travels",
                newName: "TravelCar");
        }
    }
}
