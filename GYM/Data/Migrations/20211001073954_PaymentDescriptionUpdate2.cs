using Microsoft.EntityFrameworkCore.Migrations;

namespace GYM.Data.Migrations
{
    public partial class PaymentDescriptionUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PaymentTypes");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_DescriptionId",
                table: "PaymentTypes",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_PaymentDescriptions_DescriptionId",
                table: "PaymentTypes",
                column: "DescriptionId",
                principalTable: "PaymentDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_PaymentDescriptions_DescriptionId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTypes_DescriptionId",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "PaymentTypes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PaymentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
