using RaysCourceAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Models
{
    public class StudentCourseRepository
    {
        private readonly StudentDBContext _context;
        public StudentCourseRepository(StudentDBContext context)
        {
            _context = context;
        }

        public IEnumerable<CourseType> GetTypes()
        {
            List<CourseType> test = _context.CourseType
            .Where(e => e.is_active == 1)
          .ToList();
            return test;
        }
        public IEnumerable<Course> GetCourses(int type_id)
        {
            List<Course> test = _context.Course
            .Where(e => e.cs_type_id == type_id && e.is_active == 1)
          .ToList();
            return test;
        }

        public Boolean InsertCourse(Course c)
        {
            try
            {
                _context.Course.Add(c);
                _context.SaveChanges();
                return true;

            }
            catch (System.Threading.ThreadAbortException)
            {
                return false;
            }

        }

        public Boolean UpdateCourse(Course t)
        {
            try
            {
                t.is_active = 1;
                _context.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Boolean DeleteCourse(int id)
        {

            try
            {
                var info = _context.Course.Where(c => c.is_active == 1 && c.cs_id == id)
                .FirstOrDefault();
                info.is_active = 0;
                _context.Entry(info).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public Course GetCourseById(int id)
        {
            var test = _context.Course
                .Where(et => et.cs_id == id && et.is_active==1)
                .FirstOrDefault();
            return test;
        }

        public CourseType GetTypeById(int id)
        {
            var test = _context.CourseType
                .Where(et => et.type_id == id && et.is_active ==1)
                .FirstOrDefault();
            return test;
        }

        public Boolean AddType(CourseType c)
        {
            try
            {
                _context.CourseType.Add(c);
                _context.SaveChanges();
                return true;

            }
            catch (System.Threading.ThreadAbortException)
            {
                return false;
            }
        }

        public Boolean DeleteCourseType(int id)
        {

            try
            {
                var info = _context.CourseType.Where(c => c.is_active == 1 && c.type_id == id)
                .FirstOrDefault();
                info.is_active = 0;
                _context.Entry(info).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            List<Course> test = _context.Course
            .Where(e => e.is_active == 1)
          .ToList();
            return test;
        }

        public int EnrolStudent(Student c)
        {
            try
            {
                _context.Student.Add(c);
                _context.SaveChanges();

                int result = _context.Student.Max(p => p.st_id);

                return result;

            }
            catch (System.Threading.ThreadAbortException)
            {
                return 0;
            }
        }

        public Boolean EnrolCourse(StudentCourse c)
        {
            try
            {
                _context.StudentCourse.Add(c);
                _context.SaveChanges();
                return true;

            }
            catch (System.Threading.ThreadAbortException)
            {
                return false;
            }
        }

    }
}
