using Dima.Api;
using Dima.Api.Common.Api;
using Dima.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=c:\\DimaDB.db;Version=1;"

builder.AddConfiguration();

builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();
app.MapEndpoints();

app.UseHttpsRedirection();

/*
 * app.MapPost(
            "/v1/categories",
            async (CreateCategoryRequest request, ICategoryHandler handler)
                => await handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response<Category?>>();

app.MapPut(
            "/v1/categories/{id}",
            async (long id, UpdateCategoryRequest request, ICategoryHandler handler)
                =>
            {
                request.Id = id;
                return await handler.UpdateAsync(request);
            })
    .WithName("Categories: Update")
    .WithSummary("Atualiza uma categoria")
    .Produces<Response<Category?>>();

app.MapDelete(
            "/v1/categories/{id}",
            async (long id, ICategoryHandler handler)
                =>
            {
                var request = new DeleteCategoryRequest
                {
                    Id = id,
                    UserId = "teste@email.com"
                };
                return await handler.DeleteAsync(request);
            })
    .WithName("Categories: Delete")
    .WithSummary("Exclui uma categoria")
    .Produces<Response<Category?>>();

app.MapGet(
            "/v1/categories/{id}",
            async (long id, ICategoryHandler handler)
                =>
            {
                var request = new GetCategoryByIdRequest
                {
                    Id = id,
                    UserId = "teste@email.com"
                };
                return await handler.GetByIdAsync(request);
            })
    .WithName("Categories: Get by Id")
    .WithSummary("Retorna uma categoria")
    .Produces<Response<Category?>>();

app.MapGet(
            "/v1/categories",
            async (ICategoryHandler handler)
                =>
            {
                var request = new GetAllCategoriesRequest
                {
                    UserId = "teste@email.com"
                };
                return await handler.GetAllAsync(request);
            })
    .WithName("Categories: Get All")
    .WithSummary("Retorna todas as categorias de um usuário")
    .Produces<PagedResponse<List<Category>>>();
*/

app.Run();