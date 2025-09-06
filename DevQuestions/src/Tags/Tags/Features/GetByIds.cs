using CSharpFunctionalExtensions;
using Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Shared.Abstarctions;
using Shared.FullTextSearch;
using Tags.Contracts;
using Tags.Contracts.Dtos;
using Tags.Database;

namespace Tags.Features;

public sealed class GetByIds
{
    public record GetByIdsQuery(GetByIdsDto Dto): IQuery;

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("tags/get-by-ids", async (
                GetByIdsDto GetByIdsDto,
                IQueryHandler<IReadOnlyList<TagDto>,
                GetByIdsQuery> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.Handle(
                    new GetByIdsQuery(GetByIdsDto),
                    cancellationToken);

                return Results.Ok(result);
            });
        }
    }

    public sealed class Handler: IQueryHandler<IReadOnlyList<TagDto>, GetByIdsQuery>
    {
        private readonly TagsDbContext _dbContext;

        public Handler(TagsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<TagDto>> Handle(
            GetByIdsQuery query,
            CancellationToken cancellationToken = default)
        {
            var tags = await _dbContext.Tags
                .Where(t => query.Dto.Id.Contains(t.Id))
                .ToListAsync(cancellationToken);

            var response = tags
                .Select(t => new TagDto(t.Id, t.Name))
                .ToList();

            return response;
        }
    }
}