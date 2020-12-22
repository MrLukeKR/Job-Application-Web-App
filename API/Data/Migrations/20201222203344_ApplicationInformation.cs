using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ApplicationInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Applicants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeAddressID",
                table: "Applicants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                table: "Applicants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Applicants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Applicants",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address1 = table.Column<string>(type: "TEXT", nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address3 = table.Column<string>(type: "TEXT", nullable: true),
                    Town = table.Column<string>(type: "TEXT", nullable: true),
                    County = table.Column<string>(type: "TEXT", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_HomeAddressID",
                table: "Applicants",
                column: "HomeAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Address_HomeAddressID",
                table: "Applicants",
                column: "HomeAddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Address_HomeAddressID",
                table: "Applicants");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_HomeAddressID",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "HomeAddressID",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Applicants");
        }
    }
}
