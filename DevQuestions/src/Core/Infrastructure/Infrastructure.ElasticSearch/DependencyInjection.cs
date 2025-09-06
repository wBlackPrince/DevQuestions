using Microsoft.Extensions.DependencyInjection;
using Shared.FullTextSearch;

namespace DevQuestions.Infrastructure.ElasticSearch;

public static class DependencyInjection
{
    public static IServiceCollection AddElasticSearch(this IServiceCollection services)
    {
        services.AddScoped<ISearchProvider, ElasticSearchProvider>();

        return services;
    }
}