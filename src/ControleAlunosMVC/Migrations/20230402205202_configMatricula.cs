using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleAlunosMVC.Migrations
{
    public partial class configMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateStudentSubject",
                table: "StudentSubject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Obersavation",
                table: "StudentSubject",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateStudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "Obersavation",
                table: "StudentSubject");
        }
    }
}
