using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAuthentification.Data.Migrations
{
    public partial class create_typeconsultation_add_typeconsultationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeConsultationId",
                table: "Consultation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeConsultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeConsultation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_TypeConsultationId",
                table: "Consultation",
                column: "TypeConsultationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_TypeConsultation_TypeConsultationId",
                table: "Consultation",
                column: "TypeConsultationId",
                principalTable: "TypeConsultation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_TypeConsultation_TypeConsultationId",
                table: "Consultation");

            migrationBuilder.DropTable(
                name: "TypeConsultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_TypeConsultationId",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "TypeConsultationId",
                table: "Consultation");
        }
    }
}
