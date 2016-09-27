using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmative.Models
{
    [Table("Scores")]
    public class Score
    {
        [Key]
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
