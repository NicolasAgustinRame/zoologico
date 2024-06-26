using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_zoologico.Migrations
{
    /// <inheritdoc />
    public partial class primera_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "especies_animales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreVulgar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Familia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeligroExtincion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especies_animales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "zoologicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanio = table.Column<double>(type: "float", nullable: false),
                    PresupuestoAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdAnimal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEspecie = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnioNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisDeOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zoologicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_zoologicos_especies_animales_IdEspecie",
                        column: x => x.IdEspecie,
                        principalTable: "especies_animales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_zoologicos_IdEspecie",
                table: "zoologicos",
                column: "IdEspecie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "zoologicos");

            migrationBuilder.DropTable(
                name: "especies_animales");
        }
    }
}
