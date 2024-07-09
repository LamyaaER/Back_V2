using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppQuizz.Models;

namespace AppQuizz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agent>()
                .HasMany(a => a.Quizs)
                .WithOne(q => q.Agent)
                .HasForeignKey(q => q.AgentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Agent>()
                .HasMany(a => a.Candidates)
                .WithOne(c => c.Agent)
                .HasForeignKey(c => c.AgentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.Quizs)
                .WithOne(q => q.Candidate)
                .HasForeignKey(q => q.CandidateId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Technology>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Technology)
                .HasForeignKey(q => q.TechnologyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Response)
                .WithOne()
                .HasForeignKey<Question>(q => q.ResponseId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
