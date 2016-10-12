using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmative.Migrations
{
    public partial class ExpandMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Metascore",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rated",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Released",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Runtime",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Writer",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Movies",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Review",
                table: "Scores",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Metascore",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rated",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Released",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Runtime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Writer",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Review",
                table: "Scores",
                nullable: true);
        }
    }
}
