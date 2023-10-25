using ApiWithGraphQL.Entities;
using ApiWithGraphQL.GraphQL.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace ApiWithGraphQL.GraphQL.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(/*AppDbContext dbContext*/)
        {
            //Field<ListGraphType<ProductType>>(
            //   "products",
            //   resolve: context => dbContext.Products.ToListAsync()
            //);
            Field<ListGraphType<ProductType>>(
               "products",
               resolve: context => new List<Product>()
               {
                    new Product
                    {
                        Id = 1,
                        Name = "Sample",
                        Description = "Sample description",
                        Price = 10.00m,
                        DateCreation = DateTime.Now,
                        ImageUrl = "http://sample.com"
                    }
               }
            );
        }
    }
}
