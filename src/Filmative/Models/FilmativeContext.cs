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

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Filmative;integrated security=True");
        }
    }
}
