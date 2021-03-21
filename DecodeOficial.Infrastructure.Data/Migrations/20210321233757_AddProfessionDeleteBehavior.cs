using Microsoft.EntityFrameworkCore.Migrations;

namespace DecodeOficial.Infrastructure.Data.Migrations
{
    public partial class AddProfessionDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Professions_ProfessionId",
                table: "People");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Professions_ProfessionId",
                table: "People",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Professions_ProfessionId",
                table: "People");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Professions_ProfessionId",
                table: "People",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
