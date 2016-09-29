using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Filmative.Models;

namespace Filmative.Migrations
{
    [DbContext(typeof(FilmativeContext))]
    [Migration("20160929003948_Join")]
    partial class Join
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

                    b.Property<int?>("MovieId1");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("UserId");

                    b.HasKey("MovieId");

                    b.HasIndex("MovieId1");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Filmative.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Filmative.Models.Movie", b =>
                {
                    b.HasOne("Filmative.Models.Movie")
                        .WithMany("Movies")
                        .HasForeignKey("MovieId1");

                    b.HasOne("Filmative.Models.User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId");
                });
        }
    }
}
