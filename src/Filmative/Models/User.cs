using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmative.Models
{
    public class User
    {
        public User() { }

        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
