﻿using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
              .WithName("Categories: Get All")
              .WithSummary("Recupera todas as categoria")
              .WithDescription("Recupera todas as categoria")
              .WithOrder(5)
              .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetAllAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

//app.MapGet(
//            "/v1/categories",
//            async (ICategoryHandler handler)
//                =>
//            {
//                var request = new GetAllCategoriesRequest
//                {
//                    UserId = "teste@email.com"
//                };
//                return await handler.GetAllAsync(request);
//            })
//    .WithName("Categories: Get All")
//    .WithSummary("Retorna todas as categorias de um usuário")
//    .Produces<PagedResponse<List<Category>>>();