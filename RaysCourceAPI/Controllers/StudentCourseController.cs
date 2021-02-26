using Microsoft.AspNetCore.Mvc;
using RaysCourceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class StudentCourseController : Controller
    {
        private readonly StudentDBContext _context;
        private readonly StudentCourseRepository _service;
        public StudentCourseController(StudentDBContext context)
        {
            _context = context;
            _service = new StudentCourseRepository(_context);
        }


        [Produces("application/json")]
        [HttpGet("courseTypes")]
        public IActionResult GetOrdersForFarmer()
        {


            var result = _service.GetTypes();
            return Ok(result);


        }

        [Produces("application/json")]
        [HttpGet("courses/{id}")]
        public IActionResult GetCourses(int id)
        {


            var result = _service.GetCourses(id);
            return Ok(result);


        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("insertCourse")]
        public IActionResult InsertCourse([FromBody] GetCourse c)
        {
            Course course = new Course();
            
            course.cs_content = c.cs_content;
            course.cs_description = c.cs_description;
            course.cs_duration = c.cs_duration;
            course.cs_institute = c.cs_institute;
            course.cs_language = c.cs_language;
            course.cs_level = c.cs_level;
            course.cs_skills = c.cs_skills;
            course.cs_title = c.cs_title;
            course.cs_type_id = c.cs_type_id;
            course.is_active = 1;

            Boolean id = _service.InsertCourse(course);
            if (id)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("updateCourse")]
        public IActionResult updateCourse([FromBody] Course c)
        {

            if (_service.UpdateCourse(c))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [HttpGet("deleteCourse/{id}")]
        public Boolean DeleteCourse(int id)
        {
            return _service.DeleteCourse(id);
        }

        [Produces("application/json")]
        [HttpGet("courseDetails/{id}")]
        public Course GetCourseById(int id)
        {
            return _service.GetCourseById(id);

        }


        [Produces("application/json")]
        [HttpGet("typeById/{id}")]
        public CourseType GetTypeById(int id)
        {
            return _service.GetTypeById(id);

        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("insertType")]
        public IActionResult AddType([FromBody] GetType t)
        {
            CourseType course = new CourseType();
            course.type_name = t.type_name;
            course.type_description = t.type_description;
            course.is_active = 1;
            Boolean id = _service.AddType(course);
            if (id)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("deleteType/{id}")]
        public Boolean DeleteCourseType(int id)
        {
            return _service.DeleteCourseType(id);
        }

        [Produces("application/json")]
        [HttpGet("allCourses")]
        public IActionResult GetAllCourses()
        {


            var result = _service.GetAllCourses();
            return Ok(result);


        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("login")]
        public Boolean Login([FromBody] GetRole t)
        {
            String password = "Admin1234";
            Role role = new Role();
            if(t.password == password)
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("enrol")]
        public IActionResult Enrol([FromBody] GetEnrol t)
        {
            Student st = new Student();
            st.st_email = t.st_email;
            st.st_name = t.st_name;
            st.st_institute = t.st_institute;
            st.is_active = 1;

            
            

            int st_id = _service.EnrolStudent(st);
            if (st_id!=0)
            {
                StudentCourse sc = new StudentCourse();
                sc.cs_id = t.cs_id;
                sc.st_id = st_id;
                sc.is_active = 1;

                Boolean is_add = _service.EnrolCourse(sc);
                if (is_add)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
                
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
