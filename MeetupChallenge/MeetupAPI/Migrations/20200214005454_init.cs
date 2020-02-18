using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetup.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuracions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuracions_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 60, nullable: true),
                    TopicoId = table.Column<int>(nullable: false),
                    Ciudad = table.Column<string>(maxLength: 30, nullable: false),
                    Sucursal = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    OrganizadorId = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_Usuario_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_Topico_TopicoId",
                        column: x => x.TopicoId,
                        principalTable: "Topico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    CheckIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Notificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 15, nullable: false),
                    Mensaje = table.Column<string>(maxLength: 100, nullable: false),
                    Leida = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacion_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuracions_UsuarioId",
                table: "Configuracions",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_OrganizadorId",
                table: "Evento",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_TopicoId",
                table: "Evento",
                column: "TopicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_EventoId",
                table: "Inscripcion",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_UsuarioId",
                table: "Inscripcion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_EventoId",
                table: "Notificacion",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_UsuarioId",
                table: "Notificacion",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracions");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Notificacion");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Topico");
        }
    }
}
