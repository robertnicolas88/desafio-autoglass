using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioAutoGlass.Infrastructure.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValidateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FabricationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CodeProvider = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionProvider = table.Column<string>(type: "TEXT", nullable: true),
                    RegistryCodeProvider = table.Column<string>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
