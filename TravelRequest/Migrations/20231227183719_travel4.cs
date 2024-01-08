using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class travel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Travels",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "TravelWEmployee",
                table: "Travels",
                newName: "RentalCar");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Travels",
                newName: "WhichCampaign");

            migrationBuilder.AlterColumn<string>(
                name: "TravelLocation",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByWho",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfNights",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForTravel",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravellingWithOthers",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravellingWithWho",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByWho",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "NumberOfNights",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "ReasonForTravel",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "TravellingWithOthers",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "TravellingWithWho",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Travels",
                newName: "EmployeeID");

            migrationBuilder.RenameColumn(
                name: "WhichCampaign",
                table: "Travels",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "RentalCar",
                table: "Travels",
                newName: "TravelWEmployee");

            migrationBuilder.AlterColumn<bool>(
                name: "TravelLocation",
                table: "Travels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
