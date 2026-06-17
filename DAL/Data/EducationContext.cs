using Azure;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Data
{
    public class EducationContext(DbContextOptions<EducationContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<EnrollmentCourse> EnrollmentCourses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EnrollmentCourse>()
                .HasKey(ec => new { ec.EnrollmentId, ec.CourseId });

            modelBuilder.Entity<EnrollmentCourse>()
                .HasOne(ec => ec.Enrollment)
                .WithMany(e => e.EnrollmentCourses)
                .HasForeignKey(ec => ec.EnrollmentId);

            modelBuilder.Entity<EnrollmentCourse>()
                .HasOne(ec => ec.Course)
                .WithMany(c => c.EnrollmentCourses)
                .HasForeignKey(ec => ec.CourseId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId);
        }
    }
}
