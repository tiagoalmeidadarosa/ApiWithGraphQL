using ApiWithGraphQL;
using ApiWithGraphQL.GraphQL.Queries;
using ApiWithGraphQL.GraphQL.Schemas;
using GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "GraphQlExample"));

builder.Services.AddScoped<ProductQuery>();
builder.Services.AddScoped<ProductSchema>();
builder.Services.AddGraphQL(options => options.AddGraphTypes());
builder.Services.AddSingleton<IGraphQLTextSerializer, GraphQL.SystemTextJson.GraphQLSerializer>();

var app = builder.Build();

CreateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL<ProductSchema>();
app.UseGraphQLPlayground("/playground");

app.MapControllers();

app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}
