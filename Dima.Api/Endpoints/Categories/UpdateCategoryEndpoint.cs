using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
              .WithName("Categories: Update")
              .WithSummary("Atualiza uma categoria")
              .WithDescription("Atualiza uma categoria")
              .WithOrder(2)
              .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        UpdateCategoryRequest request,
        ICategoryHandler handler,
        long id)
    {
        request.Id = id;
        request.UserId = user.Identity?.Name ?? string.Empty;

        var result = await handler.UpdateAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

//app.MapPut(
//            "/v1/categories/{id}",
//            async (long id, UpdateCategoryRequest request, ICategoryHandler handler)
//                =>
//            {
//                request.Id = id;
//                return await handler.UpdateAsync(request);
//            })
//    .WithName("Categories: Update")
//    .WithSummary("Atualiza uma categoria")
//    .Produces<Response<Category?>>();