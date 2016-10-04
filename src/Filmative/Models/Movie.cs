using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filmative.Models;


namespace Filmative.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }

        public override bool Equals(System.Object otherMovie)
        {
            if (!(otherMovie is Movie))
            {
                return false;
            }
            else
            {
                Movie newMovie = (Movie)otherMovie;
                return this.MovieId.Equals(newMovie.MovieId);
            }
        }

        public override int GetHashCode()
        {
            return this.MovieId.GetHashCode();
        }
    }
}
