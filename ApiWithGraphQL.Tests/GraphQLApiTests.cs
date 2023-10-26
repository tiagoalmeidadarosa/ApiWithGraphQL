using ApiWithGraphQL.GraphQL.Queries;
using ApiWithGraphQL.GraphQL.Schemas;
using GraphQL;
using GraphQL.SystemTextJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiWithGraphQL.Tests
{
    public class GraphQLApiTests
    {
        private readonly IServiceProvider _resolver;
        private JsonSerializerOptions _jsonSerializerOptions;

        public GraphQLApiTests()
        {
            var services = new ServiceCollection();

            // Register your Schema and any other types needed
            services.AddScoped<ProductQuery>();
            services.AddScoped<ProductSchema>();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "GraphQlExampleTests"));
            services.AddGraphQL(options => options.AddGraphTypes(Assembly.GetAssembly(typeof(AppDbContext))!));
            services.AddSingleton<IGraphQLTextSerializer, GraphQLSerializer>();

            // Build the dependency resolver
            _resolver = services.BuildServiceProvider();

            // Register any dependencies needed for your API
            services.AddScoped(s => _resolver);

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        [Fact]
        public async Task ProductQuery_ReturnsProductsWithoutCategory()
        {
            // Arrange
            var schema = new ProductSchema(_resolver);
            var query = @"{ products { name description price imageUrl stock date } }";

            // Act
            var result = await schema.ExecuteAsync(_ =>
            {
                _.Query = query;
            });

            var response = JsonSerializer.Deserialize<GraphQLResponse<ProductsData>>(result, _jsonSerializerOptions);

            // Assert
            Assert.NotNull(response);
            Assert.Null(response.Errors);
            Assert.Null(response.Data!.Products!.First().Category);
        }

        [Fact]
        public async Task ProductQuery_ReturnsProductsWithCategory()
        {
            // Arrange
            var schema = new ProductSchema(_resolver);
            var query = @"{ products { name description price imageUrl stock date category { name imageUrl } } }";

            // Act
            var result = await schema.ExecuteAsync(_ =>
            {
                _.Query = query;
            });

            var response = JsonSerializer.Deserialize<GraphQLResponse<ProductsData>>(result, _jsonSerializerOptions);

            // Assert
            Assert.NotNull(response);
            Assert.Null(response.Errors);
            Assert.NotNull(response.Data!.Products!.First().Category);
        }

        [Fact]
        public async Task ProductQuery_ReturnsError()
        {
            // Arrange
            var schema = new ProductSchema(_resolver);
            var query = @"{ products { xxx }";

            // Act
            var result = await schema.ExecuteAsync(_ =>
            {
                _.Query = query;
            });

            var response = JsonSerializer.Deserialize<GraphQLResponse<ProductsData>>(result, _jsonSerializerOptions);

            // Assert
            Assert.NotNull(response?.Errors);
        }
    }
}