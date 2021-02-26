using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cs_id { get; set; }
        public String cs_title { get; set; }

        public String cs_duration { get; set; }
        public String cs_institute { get; set; }
      public String cs_content {get;set;}
      public String cs_level { get; set; }
      public String cs_language { get; set; }
      public String cs_skills { get; set; }

        public int is_active { get; set; }
      public String cs_description { get; set; }
        [ForeignKey("CourseType")]
        public int cs_type_id { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }

    }
}
