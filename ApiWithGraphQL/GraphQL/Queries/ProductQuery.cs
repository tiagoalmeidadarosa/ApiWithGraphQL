using ApiWithGraphQL.GraphQL.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace ApiWithGraphQL.GraphQL.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            FieldAsync<ListGraphType<ProductType>>(
                name: "products",
                arguments: null,
                resolve: async context =>
                {
                    var products = await dbContext.Products
                        .Include(p => p.Category)
                        .ToListAsync();

                    return products;
                }
            );
        }
    }
}
