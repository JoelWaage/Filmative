using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmative.Migrations
{
    public partial class Score2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "ScoreId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoreId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ScoreId",
                table: "Users",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ScoreId",
                table: "Movies",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Scores_ScoreId",
                table: "Movies",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "ScoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Scores_ScoreId",
                table: "Users",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "ScoreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Scores_ScoreId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Scores_ScoreId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ScoreId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ScoreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Scores",
                nullable: false,
                defaultValue: 0);
        }
    }
}
