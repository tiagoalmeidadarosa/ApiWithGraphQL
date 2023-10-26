using ApiWithGraphQL.Entities;

namespace ApiWithGraphQL.Tests
{
    public class GraphQLResponse<T>
    {
        public T? Data { get; set; }
        public List<GraphQLError>? Errors { get; set; }
    }

    public class GraphQLError
    {
        public string? Message { get; set; }
    }

    public class ProductsData
    {
        public List<Product>? Products { get; set; }
    }
}
