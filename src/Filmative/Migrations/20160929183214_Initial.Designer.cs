using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Filmative.Models;

namespace Filmative.Migrations
{
    [DbContext(typeof(FilmativeContext))]
    [Migration("20160929183214_Initial")]
    partial class Initial
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

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Filmative.Models.Scores", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MovieId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<int?>("UserId");

                    b.HasKey("ScoreId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Filmative.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Filmative.Models.Scores", b =>
                {
                    b.HasOne("Filmative.Models.Movie", "Movie")
                        .WithMany("Users")
                        .HasForeignKey("MovieId");

                    b.HasOne("Filmative.Models.User", "User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId");
                });
        }
    }
}
