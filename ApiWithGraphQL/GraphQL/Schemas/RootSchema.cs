using ApiWithGraphQL.GraphQL.Queries;
using GraphQL.Types;

namespace ApiWithGraphQL.GraphQL.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
        }
    }
}
