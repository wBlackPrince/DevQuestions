using Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Tags.Contracts;
using Tags.Contracts.Dtos;
using Tags.Database;
using Tags.Domain;

namespace Tags.Features;

public sealed class Create
{
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("tags", Handler);
        }
    }

    private static async Task<IResult> Handler(
        CreateTagDto dto,
        TagsDbContext dbContext)
    {
        await dbContext.AddAsync(new Tag(){ Name = dto.Name });

        return Results.Ok();
    }
}