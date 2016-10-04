using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmative.Models.Repositories
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
        Movie Save(Movie movie);
        Movie Edit(Movie movie);
        void Remove(Movie movie);
    }
}
