using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogoJogos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaJogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    produtora = table.Column<string>(type: "text", nullable: true),
                    plataforma = table.Column<string>(type: "text", nullable: true),
                    genero = table.Column<string>(type: "text", nullable: true),
                    preco = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaJogos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaJogos");
        }
    }
}
