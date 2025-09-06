using Shared.Abstarctions;
using Tags.Contracts;
using Tags.Contracts.Dtos;
using Tags.Database;
using Tags.Features;

namespace Tags.Presenters;

public class TagsContract: ITagsContract
{
    private readonly IQueryHandler<IReadOnlyList<TagDto>, GetByIds.GetByIdsQuery> _handler;
    private readonly TagsDbContext _dbContext;

    public TagsContract(
        IQueryHandler<IReadOnlyList<TagDto>, GetByIds.GetByIdsQuery> handler,
        TagsDbContext dbContext)
    {
        _handler = handler;
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<TagDto>> GetByIds(
        GetByIdsDto dto)
    {
        return await _handler.Handle(new GetByIds.GetByIdsQuery(dto));
    }
}