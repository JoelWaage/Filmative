using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Filmative.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Users = new HashSet<User>();
        }
        
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; } 
        public virtual ICollection<User> Users { get; set; }
    }
}
