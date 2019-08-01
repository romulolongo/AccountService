using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountService.Infra.Data.Migrations
{
    public partial class Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    HolderAccountName = table.Column<string>(maxLength: 100, nullable: false),
                    ValueBalance = table.Column<double>(nullable: false),
                    ValueLimit = table.Column<double>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Guid", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
