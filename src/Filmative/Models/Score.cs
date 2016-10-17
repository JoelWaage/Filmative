using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filmative.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmative.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        public virtual Movie Movie { get; set; }
        [HiddenInput]
        public int Rating { get; set; }
        [StringLength(50)]
        public string Review { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
