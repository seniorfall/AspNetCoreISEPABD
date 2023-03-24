using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAuthentification.Data.Migrations
{
    public partial class add_dateprochain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProchainConsultation",
                table: "Consultation",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProchainConsultation",
                table: "Consultation");
        }
    }
}
