using Microsoft.EntityFrameworkCore.Migrations;

namespace GYM.Data.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDate1",
                table: "AspNetUsers",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "Phone1",
                table: "AspNetUsers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Name1",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName1",
                table: "AspNetUsers",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "AspNetUsers",
                newName: "RegistrationDate1");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "AspNetUsers",
                newName: "Phone1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Name1");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "LastName1");
        }
    }
}
