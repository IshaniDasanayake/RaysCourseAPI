using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Models
{
    public class CourseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int type_id { get; set; }
        public String type_name { get; set; }
        public String type_description { get; set; }
        public int is_active { get; set; }
    }
}
