using Microsoft.EntityFrameworkCore.Migrations;

namespace DecodeOficial.Infrastructure.Data.Migrations
{
    public partial class AddProfessionEntityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_ProfessionId",
                table: "People",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Professions_ProfessionId",
                table: "People",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Professions_ProfessionId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_People_ProfessionId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
