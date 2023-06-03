using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { }

        public DbSet<Student> Students { get; set; }

        public DbSet<ExamPass> ExamPasses { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<FieldStudy> FieldStudies{ get; set; }

        public DbSet<Faculty> Faculties { get; set;}

        public DbSet<EducationLevel> EducationLevels { get; set; }

        public DbSet<AdmissionInformation> AdmissionInformations{ get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PassingScore> PassingScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Faculty>()
                .HasOne(faculty => faculty.University)
                .WithMany(univervity => univervity.Faculties);
            modelBuilder.Entity<FieldStudy>()
                .HasOne(filedStudy => filedStudy.EducationLevel)
                .WithMany(educationLevel => educationLevel.FieldStudies);
            modelBuilder.Entity<FieldStudy>()
                .HasOne(filedStudy => filedStudy.Faculty)
                .WithMany(faculty => faculty.FieldStudies);
            modelBuilder.Entity<AdmissionInformation>()
                .HasOne(ai => ai.FieldStudy)
                .WithMany(filedStudy => filedStudy.AdmissionInformations);
            modelBuilder.Entity<ExamPass>()
                .HasKey(ep => new { ep.StudentId, ep.SubjectId });
            modelBuilder.Entity<ExamPass>()
                .HasOne(ep => ep.Student)
                .WithMany(s => s.ExamPasses)
                .HasForeignKey(ep => ep.StudentId)
                .HasPrincipalKey(s => s.Id);
            modelBuilder.Entity<ExamPass>()
                .HasOne(ep => ep.Subject)
                .WithMany(s => s.ExamPasses)
                .HasForeignKey(ep => ep.SubjectId)
                .HasPrincipalKey(s => s.Id);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User);
            modelBuilder.Entity<Subject>()
                .HasMany(subject => subject.PassingScores)
                .WithOne(passingScore => passingScore.Subject);
            modelBuilder.Entity<AdmissionInformation>()
                .HasMany(ai => ai.PassingScores)
                .WithOne(ps => ps.AdmissionInformation);

            //Добавление индексов для ускорения поиска по таблице
            modelBuilder.Entity<UserEntity>()
                .HasIndex(user => user.Login)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(student => new { student.Inn, student.Snils })
                .IsUnique();
        }
    }
}
