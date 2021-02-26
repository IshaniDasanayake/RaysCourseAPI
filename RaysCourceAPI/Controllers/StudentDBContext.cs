using Microsoft.EntityFrameworkCore;
using RaysCourceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCourceAPI.Controllers
{
    public class StudentDBContext: DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

        public DbSet<CourseType> CourseType { get; set; }

        public DbSet<Role> Role { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(et => new { et.cs_id, et.st_id });
            modelBuilder.Entity<StudentCourse>()
                .HasOne(et => et.Student)
                .WithMany(e => e.StudentCourse)
                .HasForeignKey(et => et.st_id);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(et => et.Course)
                .WithMany(t => t.StudentCourse)
                .HasForeignKey(et => et.cs_id);
        }
    }
}
