using Microsoft.EntityFrameworkCore;
using TechnicalTest.Domain.Models;

namespace TechnicalTest.DataAccess.Clients.Database;

public class CandidateDbContext : DbContext
{
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<CandidateExperience> CandidateExperiences { get; set; }

    public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar IdCandidate como PK autoincremental
        modelBuilder.Entity<Candidate>()
            .HasKey(c => c.IdCandidate);
        modelBuilder.Entity<Candidate>()
            .Property(c => c.IdCandidate)
            .ValueGeneratedOnAdd();

        // Configurar Email como AK
        modelBuilder.Entity<Candidate>()
            .HasIndex(c => c.Email)
            .IsUnique();

        // Configurar IdCandidateExperience como PK autoincremental
        modelBuilder.Entity<CandidateExperience>()
            .HasKey(ce => ce.IdCandidateExperience);
        modelBuilder.Entity<CandidateExperience>()
            .Property(ce => ce.IdCandidateExperience)
            .ValueGeneratedOnAdd();

        // Configurar IdCandidate como FK
        modelBuilder.Entity<CandidateExperience>()
            .HasOne<Candidate>()
            .WithMany()
            .HasForeignKey(ce => ce.IdCandidate);
    }
}
