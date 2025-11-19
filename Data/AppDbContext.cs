using Microsoft.EntityFrameworkCore;
using Aplikacja_wspierajaca_rozwoj_dziecka.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Jeśli już skonfigurowane przez DI – nic nie rób
            if (optionsBuilder.IsConfigured)
                return;

            // Fallback: wczytaj connection string z appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DomyslnePolaczenie");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Dziecko> Dzieci { get; set; }
        public DbSet<Umiejetnosc> Umiejetnosci { get; set; }
        public DbSet<DzieckoUmiejetnosc> DzieckoUmiejetnosci { get; set; }
        public DbSet<Aktywnosc> Aktywnosci { get; set; }
        public DbSet<DziennikAktywnosci> DziennikiAktywnosci { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DzieckoUmiejetnosc>()
                .HasIndex(x => new { x.DzieckoId, x.UmiejetnoscId })
                .IsUnique();

            modelBuilder.Entity<Dziecko>()
                .Property(d => d.DataUrodzenia)
                .HasColumnType("date");

            modelBuilder.Entity<DziennikAktywnosci>()
                .Property(d => d.Data)
                .HasColumnType("date");

            modelBuilder.Entity<Aktywnosc>()
                .HasMany(a => a.Umiejetnosci)
                .WithMany(u => u.Aktywnosci)
                .UsingEntity(j => j.ToTable("AktywnosciUmiejetnosci"));
        }
    }
}
