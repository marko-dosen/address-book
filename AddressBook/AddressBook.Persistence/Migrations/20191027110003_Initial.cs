using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AddressBook.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    AddressLine1 = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    City = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    State = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Zip = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Id",
                table: "Contact",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Name_AddressLine1_AddressLine2_AddressLine3_City_St~",
                table: "Contact",
                columns: new[] { "Name", "AddressLine1", "AddressLine2", "AddressLine3", "City", "State", "Zip", "Country" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_ContactId",
                table: "PhoneNumber",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
