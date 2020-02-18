using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetup.Api.Migrations
{
    public partial class climacache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Climas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(nullable: false),
                    ClimaPrincipal = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    TempMax = table.Column<string>(nullable: true),
                    TempMin = table.Column<string>(nullable: true),
                    Humedad = table.Column<string>(nullable: true),
                    Noche = table.Column<string>(nullable: true),
                    Tarde = table.Column<string>(nullable: true),
                    Mañana = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Climas_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Climas_EventoId",
                table: "Climas",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Climas");
        }
    }
}
