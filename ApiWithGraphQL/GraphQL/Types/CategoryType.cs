using ApiWithGraphQL.Entities;
using GraphQL.Types;

namespace ApiWithGraphQL.GraphQL.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Name = "Category";
            Field(x => x.CategoryId, type: typeof(IdGraphType))
                .Description("Category id.");
            Field(x => x.Name)
                .Description("Name property of the category object.");
            Field(x => x.ImageUrl)
                .Description("ImageUrl property of the category object.");
        }
    }
}
