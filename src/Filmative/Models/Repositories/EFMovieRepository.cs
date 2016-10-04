using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Filmative.Models.Repositories
{
    public class EFMovieRepository : IMovieRepository
    {
        FilmativeContext db = new FilmativeContext();

        public IQueryable<Movie> Movies
        { get { return db.Movies; } }

        public Movie Save(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return movie;
        }

        public Movie Edit(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return movie;
        }

        public void Remove(Movie movie)
        {
            db.Movies.Remove(movie);
            db.SaveChanges();
        }
    }
}
