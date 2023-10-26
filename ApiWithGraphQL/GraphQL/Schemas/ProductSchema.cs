using ApiWithGraphQL.GraphQL.Queries;
using GraphQL.Types;

namespace ApiWithGraphQL.GraphQL.Schemas
{
    public class ProductSchema : Schema
    {
        public ProductSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ProductQuery>();
        }
    }
}
