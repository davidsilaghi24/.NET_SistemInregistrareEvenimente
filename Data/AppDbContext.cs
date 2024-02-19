using Microsoft.EntityFrameworkCore;
using SistemInregistrareEvenimente.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Eveniment> Evenimente { get; set; }
    public DbSet<Locatie> Locatii { get; set; }
    public DbSet<Artist> Artisti { get; set; }
    public DbSet<Bilet> Bilete { get; set; }
    public DbSet<EvenimentArtist> EvenimentArtisti { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurarea relației one-to-many între Locatie și Evenimente
        modelBuilder.Entity<Eveniment>()
            .HasOne(e => e.Locatie)
            .WithMany(l => l.Evenimente)
            .HasForeignKey(e => e.LocatieId);

        // Configurarea relației many-to-many între Evenimente și Artisti
        modelBuilder.Entity<EvenimentArtist>()
            .HasKey(ea => new { ea.EvenimentId, ea.ArtistId });

        modelBuilder.Entity<EvenimentArtist>()
            .HasOne(ea => ea.Eveniment)
            .WithMany(e => e.EvenimentArtisti)
            .HasForeignKey(ea => ea.EvenimentId);

        modelBuilder.Entity<EvenimentArtist>()
            .HasOne(ea => ea.Artist)
            .WithMany(a => a.EvenimentArtisti)
            .HasForeignKey(ea => ea.ArtistId);

        modelBuilder.Entity<Bilet>()
            .HasOne(b => b.Eveniment)
            .WithMany(e => e.Bilete)
            .HasForeignKey(b => b.EvenimentId);
    }
}
