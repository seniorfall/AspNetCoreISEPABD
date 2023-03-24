using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAuthentification.Data.Migrations
{
    public partial class add_date_consultation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date_consultation",
                table: "Consultation",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_consultation",
                table: "Consultation");
        }
    }
}
