using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Filmative.Models;

namespace Filmative.Migrations
{
    [DbContext(typeof(FilmativeContext))]
    partial class FilmativeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Filmative.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Filmative.Models.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MovieId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<int>("UserId");

                    b.HasKey("ScoreId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Filmative.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
        }
    }
}
