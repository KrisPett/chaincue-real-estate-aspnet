using System.Collections.Generic;
using chaincue_real_estate_aspnet.Models;
using Microsoft.EntityFrameworkCore;

namespace chaincue_real_estate_aspnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<HouseImage> HouseImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
