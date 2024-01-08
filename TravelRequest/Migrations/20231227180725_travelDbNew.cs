using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class travelDbNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelLocation = table.Column<bool>(type: "bit", nullable: true),
                    CheckInDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckOutDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelWEmployee = table.Column<bool>(type: "bit", nullable: true),
                    TravelCar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                });
                     


          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Travels");

          
        }
    }
}
