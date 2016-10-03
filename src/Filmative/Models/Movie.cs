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
    }
}
