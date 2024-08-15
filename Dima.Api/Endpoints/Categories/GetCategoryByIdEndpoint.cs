using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
              .WithName("Categories: Get by Id")
              .WithSummary("Recupera uma categoria")
              .WithDescription("Recupera uma categoria")
              .WithOrder(4)
              .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        long id)
    {
        var request = new GetCategoryByIdRequest
        {
            Id = id,
            UserId = user.Identity?.Name ?? string.Empty
        };

        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

//app.MapGet(
//            "/v1/categories/{id}",
//            async (long id, ICategoryHandler handler)
//                =>
//            {
//                var request = new GetCategoryByIdRequest
//                {
//                    Id = id,
//                    UserId = "teste@email.com"
//                };
//                return await handler.GetByIdAsync(request);
//            })
//    .WithName("Categories: Get by Id")
//    .WithSummary("Retorna uma categoria")
//    .Produces<Response<Category?>>();