using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class TsiTravelModelFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "TsiTravelModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TravelLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckInDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckOutDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfNights = table.Column<int>(type: "int", nullable: true),
                    TravellingWithOthers = table.Column<bool>(type: "bit", nullable: true),
                    TravellingWithWho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForTravel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhichCampaign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedByWho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalCar = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TsiTravelModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TsiTravelModels");

          
        }
    }
}
