using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_de_Dados_5.Server.Data.Migrations
{
    public partial class Relacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Pessoa",
                table: "Video_Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Video_Games_Id_Pessoa",
                table: "Video_Games",
                column: "Id_Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Games_Pessoas_Id_Pessoa",
                table: "Video_Games",
                column: "Id_Pessoa",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Games_Pessoas_Id_Pessoa",
                table: "Video_Games");

            migrationBuilder.DropIndex(
                name: "IX_Video_Games_Id_Pessoa",
                table: "Video_Games");

            migrationBuilder.DropColumn(
                name: "Id_Pessoa",
                table: "Video_Games");
        }
    }
}
