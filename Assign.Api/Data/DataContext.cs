using Assign.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Assign.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<City> Cities { get; set; }
        public DbSet<Extras> Extras { get; set; }

        public DbSet<CityExtras> CityExtras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Quotation;Integrated Security=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasMany(x => x.CityExtras)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId);
            modelBuilder.Entity<Extras>()
                .HasMany(x => x.CityExtras)
                .WithOne(x => x.Extras)
                .HasForeignKey(x => x.ExtrasId);
            modelBuilder.Entity<CityExtras>()
                .HasKey(x => new { x.CityId, x.ExtrasId });
        }


    }
}
