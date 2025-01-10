using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.API.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Atores",
                columns: new[] { "Id", "AwardsCount", "BirthDate", "Gender", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(1965, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Fernanda Torres", "Brasileira" },
                    { 2, 14, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Leonardo DiCaprio", "Americana" },
                    { 3, 8, new DateTime(1970, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Uma Thurman", "Americana" },
                    { 4, 4, new DateTime(1947, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Sam Neill", "Neozelandês" },
                    { 5, 10, new DateTime(1967, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Jamie Foxx", "Americana" },
                    { 6, 3, new DateTime(1971, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Henry Thomas", "Americana" }
                });

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan" },
                    { 2, "Walter Salles" },
                    { 3, "Quentin Tarantino" },
                    { 4, "Steven Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Ano", "DiretorId", "Titulo" },
                values: new object[,]
                {
                    { 1, 2024, 2, "Ainda estou aqui" },
                    { 2, 2010, 1, "Inception" },
                    { 3, 1994, 3, "Pulp Fiction" },
                    { 4, 1993, 4, "Jurassic Park" },
                    { 5, 2012, 3, "Django Unchained" },
                    { 6, 1982, 4, "E.T. the Extra-Terrestrial" }
                });

            migrationBuilder.InsertData(
                table: "AtorFilme",
                columns: new[] { "AtoresId", "FilmesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "AtorFilme",
                keyColumns: new[] { "AtoresId", "FilmesId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
