using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Models
{
    public class StudentCourse
    {
        [Key]
        public int cs_id { get; set; }
        [Key]
        public int st_id { get; set; }
        public int is_active { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}
