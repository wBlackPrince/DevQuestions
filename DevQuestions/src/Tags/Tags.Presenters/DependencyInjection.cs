using Microsoft.Extensions.DependencyInjection;
using Shared.Abstarctions;
using Tags.Contracts;
using Tags.Contracts.Dtos;
using Tags.Database;
using Tags.Features;

namespace Tags.Presenters;

public static class DependencyInjection
{
    public static IServiceCollection AddTagsModule(this IServiceCollection services)
    {
        services.AddScoped<ITagsContract, TagsContract>();
        services.AddScoped<IQueryHandler<IReadOnlyList<TagDto>, GetByIds.GetByIdsQuery>, GetByIds.Handler>();
        services.AddDbContext<TagsDbContext>();

        return services;
    }
}