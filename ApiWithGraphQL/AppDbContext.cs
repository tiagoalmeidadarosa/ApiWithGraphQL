using ApiWithGraphQL.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace ApiWithGraphQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasData(new List<Category>()
                {
                    GenerateFakeCategory(categoryId: 1),
                    GenerateFakeCategory(categoryId: 2),
                });

            modelBuilder.Entity<Product>()
                .HasData(new List<Product>()
                {
                    GenerateFakeProduct(id: 1, categoryId: 1),
                    GenerateFakeProduct(id: 2, categoryId: 1),
                    GenerateFakeProduct(id: 3, categoryId: 1),
                    GenerateFakeProduct(id: 4, categoryId: 2),
                    GenerateFakeProduct(id: 5, categoryId: 2),
                });
        }

        public Category GenerateFakeCategory(int categoryId)
        {
            return new Faker<Category>()
                .RuleFor(p => p.CategoryId, categoryId)
                .RuleFor(p => p.Name, p => p.Commerce.Department())
                .RuleFor(p => p.ImageUrl, p => p.Internet.Url())
                .Generate();
        }

        public Product GenerateFakeProduct(int id, int categoryId)
        {
            return new Faker<Product>()
                .RuleFor(p => p.Id, id)
                .RuleFor(p => p.Name, p => p.Commerce.Product())
                .RuleFor(p => p.Description, p => p.Lorem.Sentence(5))
                .RuleFor(p => p.Price, p => Math.Round(p.Random.Decimal(1, 100), 2))
                .RuleFor(p => p.ImageUrl, p => p.Internet.Url())
                .RuleFor(p => p.Stock, p => p.Random.Int(1, 10))
                .RuleFor(p => p.Date, p => DateTime.Now)
                .RuleFor(p => p.CategoryId, categoryId)
                .Generate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
