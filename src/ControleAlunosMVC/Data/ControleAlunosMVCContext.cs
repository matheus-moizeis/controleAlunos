using ControleAlunosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunosMVC.Data
{
    public class ControleAlunosMVCContext : DbContext
    {
        public ControleAlunosMVCContext(DbContextOptions<ControleAlunosMVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>().HasKey(sc => new { sc.StudentId, sc.SubjectId });
        }

        public DbSet<Subject> Subject { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }

    }
}
