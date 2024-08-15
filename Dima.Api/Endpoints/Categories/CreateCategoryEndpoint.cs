using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
              .WithName("Categories: Create")
              .WithSummary("Cria uma nova categoria")
              .WithDescription("Cria uma nova categoria")
              .WithOrder(1)
              .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        CreateCategoryRequest request,
        ICategoryHandler handler)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;

        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}

//app.MapPost(
//            "/v1/categories",
//            async (CreateCategoryRequest request, ICategoryHandler handler)
//                => await handler.CreateAsync(request))
//    .WithName("Categories: Create")
//    .WithSummary("Cria uma nova categoria")
//    .Produces<Response<Category?>>();