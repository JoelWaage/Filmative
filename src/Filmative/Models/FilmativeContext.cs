using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Filmative.Models
{
   public class FilmativeContext : IdentityDbContext<ApplicationUser>
    {
        public FilmativeContext(DbContextOptions options) : base(options)
        {

        }

        public FilmativeContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Follower>Follower { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Filmative;integrated security=True");
        }
    }
}
