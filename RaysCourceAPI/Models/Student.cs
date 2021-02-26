using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int st_id { get; set; }
        public String st_name { get; set; }
        public String st_email { get; set; }
        public String st_institute { get; set; }
        public int is_active { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
