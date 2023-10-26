using ApiWithGraphQL.Entities;
using GraphQL.Types;

namespace ApiWithGraphQL.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";
            Field(x => x.Id, type: typeof(IdGraphType))
                .Description("Product id.");
            Field(x => x.Name)
                .Description("Name property of the product object.");
            Field(x => x.Description)
                .Description("Description property of the product object.");
            Field(x => x.Price)
                .Description("Price property of the product object.");
            Field(x => x.ImageUrl)
                .Description("ImageUrl property of the product object.");
            Field(x => x.Date, type: typeof(DateTimeGraphType))
                .Description("Date creation property of the product object.");
            Field(x => x.Stock)
                .Description("Stock property of the product object.");
            Field(x => x.Category, type: typeof(CategoryType))
                .Description("Category property of the product object.");
        }
    }
}
