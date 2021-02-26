using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Models
{
    public class GetCourse
    {
        public String cs_title { get; set; }

        public String cs_duration { get; set; }
        public String cs_institute { get; set; }
        public String cs_content { get; set; }
        public String cs_level { get; set; }
        public String cs_language { get; set; }
        public String cs_skills { get; set; }
        public String cs_description { get; set; }
        public int cs_type_id { get; set; }
    }
}
