using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Filmative.Models;

namespace Filmative.Migrations
{
    [DbContext(typeof(FilmativeContext))]
    [Migration("20160928183534_Score2")]
    partial class Score2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Filmative.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ScoreId");

                    b.Property<string>("Title");

                    b.HasKey("MovieId");

                    b.HasIndex("ScoreId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Filmative.Models.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.HasKey("ScoreId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Filmative.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ScoreId");

                    b.HasKey("UserId");

                    b.HasIndex("ScoreId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Filmative.Models.Movie", b =>
                {
                    b.HasOne("Filmative.Models.Score")
                        .WithMany("Movies")
                        .HasForeignKey("ScoreId");
                });

            modelBuilder.Entity("Filmative.Models.User", b =>
                {
                    b.HasOne("Filmative.Models.Score")
                        .WithMany("Users")
                        .HasForeignKey("ScoreId");
                });
        }
    }
}
