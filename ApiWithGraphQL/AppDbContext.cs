using ApiWithGraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiWithGraphQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData(new Product 
                { 
                    Id = 1, 
                    Name = "Sample", 
                    Description = "Sample description",
                    Price = 10.00m,
                    DateCreation = DateTime.Now,
                    ImageUrl = "http://sample.com" 
                });
        }

        public DbSet<Product> Products { get; set; }
    }
}
