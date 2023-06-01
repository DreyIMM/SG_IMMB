using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Immb.Data.Migrations
{
    public partial class WithReligiosidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Religiosidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MembroId = table.Column<Guid>(nullable: false),
                    DataReligiosidade = table.Column<DateTime>(nullable: false),
                    TotalMinistracao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religiosidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Religiosidades_Membros_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Religiosidades_MembroId",
                table: "Religiosidades",
                column: "MembroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Religiosidades");
        }
    }
}
