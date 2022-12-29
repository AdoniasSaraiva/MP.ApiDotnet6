using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Infra.Data.Context
{
    public class ApplicationContextDb : DbContext
    {
        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContextDb).Assembly);
        }
    }
}
