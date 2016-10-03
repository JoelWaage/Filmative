using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filmative.Models;

namespace Filmative.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        public string Movie { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
