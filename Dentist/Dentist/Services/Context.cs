using System.IO;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace Dentist.Services
{
    class Context : DbContext
    {

        public DbSet<Cabinet> Cabinete { get; set; }
        public DbSet<Client> Clienti { get; set; }
        public DbSet<Programare> Programari { get; set; }

        public Context()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "dbprogramari.db3");

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinet>().HasKey(b => b.CabinetId).HasName("PrimaryKey_CabinetId");
            modelBuilder.Entity<Cabinet>().Property(e => e.CabinetId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().HasKey(b => b.ClientId).HasName("PrimaryKey_Client");
            modelBuilder.Entity<Client>().Property(e => e.ClientId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Programare>().HasKey(b => b.ProgramareId).HasName("PrimaryKey_CabinetId");
            modelBuilder.Entity<Programare>().Property(e => e.ProgramareId).ValueGeneratedOnAdd();
        }
    }
}