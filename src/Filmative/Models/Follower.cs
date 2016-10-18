using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Filmative.Models
{
    public class Follower
    {
        [Key]
        public int FollowId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Score Score { get; set; }
    }
}
