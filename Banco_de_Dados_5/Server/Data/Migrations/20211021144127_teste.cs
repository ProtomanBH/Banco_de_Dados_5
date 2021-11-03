using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_de_Dados_5.Server.Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Pessoas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pessoas",
                type: "datetime2",
                nullable: true);
        }
    }
}
