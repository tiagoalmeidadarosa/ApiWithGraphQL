using ApiWithGraphQL.Entities;
using GraphQL.Types;

namespace ApiWithGraphQL.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Product id.");
            Field(x => x.Name)
                .Description("Name property of the product object.");
            Field(x => x.ImageUrl)
                .Description("ImageUrl property of the product object.");
        }
    }
}
